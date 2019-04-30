Public Class frmCorrections
    Dim lFinYear As New clsFinYear

    Private Sub frmCorrections_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadFinYearCombo()
        loadAllReceipts()
        controlFieldStatus(False)
        Me.PerformAutoScale()
    End Sub
    Sub ShowReceipt()
        Dim tmpSql As String, tmpReceiptRS As ADODB.Recordset

        clearFields()

        tmpSql = "Select * from tblreceipt where ReceiptNo='" & cboReceiptNo.Text & "'"
        tmpReceiptRS = gcon.Execute(tmpSql)
        With tmpReceiptRS
            If .EOF = False Then
                txtgid.Text = tmpReceiptRS("gid").Value.ToString
                txtrefgid.Text = tmpReceiptRS("refgid").Value.ToString
                chkReconciled.Checked = Not txtrefgid.Text.Equals("")
                btnCorrectReceiptAmount.Enabled = txtrefgid.Text.Equals("")
                txtReceiptAmountNew.ReadOnly = Not txtrefgid.Text.Equals("")
                txtReceiptDate.Text = formatInt2Date(tmpReceiptRS("ReceiptDate").Value.ToString)
                txtReceiptAmount.Text = tmpReceiptRS("ReceiptAmt").Value.ToString
                txtInstrumentType.Text = tmpReceiptRS("InstrumentType").Value.ToString
                txtInstrumentDate.Text = formatInt2Date(tmpReceiptRS("InstrumentDate").Value.ToString)
                txtInstrumentNo.Text = tmpReceiptRS("InstrumentNo").Value.ToString
                txtBankName.Text = tmpReceiptRS("InstrumentBank").Value.ToString
                txtNarration.Text = tmpReceiptRS("Remarks").Value.ToString
                txtFlat.Text = tmpReceiptRS("FlatCode").Value.ToString
            End If
        End With
        If txtInstrumentType.Text = "CASH" Then


        ElseIf txtInstrumentType.Text = "CHEQUE" Then

            lblInstrumentDate.Text = "Cheque Date"
            lblInstrumentNo.Text = "Cheque No"

        ElseIf txtInstrumentType.Text = "ONLINE" Then
            lblInstrumentDate.Text = "Transfer Date"
            lblInstrumentNo.Text = "Transaction Ref. No"
        End If
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        controlFieldStatus(True)
    End Sub

    Sub controlFieldStatus(makeEditable As Boolean)
        If makeEditable = False Then
            txtNarration.ReadOnly = True
            'txtReceiptNo.ReadOnly = True
            txtBankName.ReadOnly = True
            txtFlat.ReadOnly = True
            txtInstrumentDate.ReadOnly = True
            txtInstrumentNo.ReadOnly = True
            txtInstrumentType.ReadOnly = True
            'txtReceiptAmount.ReadOnly = True
            txtReceiptDate.ReadOnly = True
            btnCorrectReceiptAmount.Enabled = False
            chkReconciled.Enabled = False
            txtReceiptAmountNew.ReadOnly = True
            btnSave.Enabled = False
        Else
            txtNarration.ReadOnly = False
            'txtReceiptNo.ReadOnly = False
            txtBankName.ReadOnly = False
            txtFlat.ReadOnly = False
            txtInstrumentDate.ReadOnly = False
            txtInstrumentNo.ReadOnly = False
            txtInstrumentType.ReadOnly = False
            'txtReceiptAmount.ReadOnly = False
            txtReceiptDate.ReadOnly = False

            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        controlFieldStatus(False)
    End Sub


    Private Sub btnSaveViewReceiptImage_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveViewReceiptImage.Click
        ImageItemType = "RECEIPT"
        ImageItemNo = gCurReceiptNo
        frmSaveViewItemData.ShowDialog()
        frmSaveViewItemData.Dispose()
    End Sub

    Private Sub cboReceiptNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReceiptNo.SelectedIndexChanged
        ShowReceipt()
    End Sub

    Sub loadAllReceipts()
        cboReceiptNo.Items.Clear()
        tmpRS = gcon.Execute("select ReceiptNo from tblreceipt where ReceiptDate >= '" & lFinYear.startDate & "' and ReceiptDate <= '" & lFinYear.endDate & "' order by ReceiptNo desc")
        While tmpRS.EOF = False
            cboReceiptNo.Items.Add(tmpRS("ReceiptNo").Value.ToString)
            tmpRS.MoveNext()
        End While
    End Sub
    Sub clearFields()
        txtgid.Text = ""
        txtrefgid.Text = ""
        chkReconciled.Checked = False
        txtReceiptDate.Text = ""
        txtReceiptAmount.Text = ""
        txtReceiptAmountNew.Text = ""
        txtInstrumentType.Text = ""
        txtInstrumentDate.Text = ""
        txtInstrumentNo.Text = ""
        txtBankName.Text = ""
        txtNarration.Text = ""
        txtFlat.Text = ""
    End Sub

    Private Sub cboFinYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFinYear.SelectedIndexChanged
        lFinYear.SetToFinYear(cboFinYear.Text)
        lblFinYear.Text = lFinYear.startDateDisplay & " - " & lFinYear.endDateDisplay
        loadAllReceipts()
        clearFields()
        cboReceiptNo.SelectedIndex = -1
        cboReceiptNo.Text = ""
    End Sub

    Sub loadFinYearCombo()
        cboFinYear.Items.Clear()
        Dim toYear As Integer
        If Month(DateTime.Now) > 3 Then
            toYear = Year(DateTime.Now)
        Else
            toYear = Year(DateTime.Now) - 1
        End If
        For x = 2012 To toYear
            cboFinYear.Items.Add(x & "-" & x + 1)
        Next

        lFinYear.SetToCurFinYear()
        cboFinYear.Text = lFinYear.startYear & "-" & lFinYear.endYear
    End Sub


    Private Sub btnCorrectReceiptAmount_Click(sender As Object, e As EventArgs) Handles btnCorrectReceiptAmount.Click
        Try
            If Trim(txtReceiptAmount.Text).Equals("") Then
                MsgBox("Invalid New Receipt Amount)")
                Exit Sub
            End If
            If IsNumeric(txtReceiptAmount.Text) = False Then
                MsgBox("Invalid New Receipt Amount)")
                Exit Sub
            End If
            If Trim(txtReceiptAmount.Text) < 0 Then
                MsgBox("Invalid New Receipt Amount)")
                Exit Sub
            End If

            Dim ssql1 As String = "update tblreceipt set ReceiptAmt=" & Trim(txtReceiptAmountNew.Text) & " where ReceiptNo='" & cboReceiptNo.Text & "'"
            Dim ssql2 As String = "update tbljournal set CrAmount=" & Trim(txtReceiptAmountNew.Text) & " where DocRef like '(Receipt No:" & cboReceiptNo.Text & ",%' and CrAmount>0"
            Dim ssql3 As String = "update tbljournal set DrAmount=" & Trim(txtReceiptAmountNew.Text) & " where DocRef like '(Receipt No:" & cboReceiptNo.Text & ",%' and DrAmount>0"

            gcon.BeginTrans()

            gcon.Execute(ssql1)
            gcon.Execute(ssql2)
            gcon.Execute(ssql3)

            gcon.CommitTrans()


            MsgBox("Update successfull")

        Catch ex As Exception
            gcon.RollbackTrans()
            MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & "-->" & ex.Message)
        End Try
    End Sub
End Class