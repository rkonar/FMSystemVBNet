Public Class frmShowReceipt

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        gCurReceiptNo = ""
        Me.Close()
    End Sub

    Private Sub frmShowReceipt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowReceipt()
        controlFieldStatus(False)
        Me.PerformAutoScale()
    End Sub

    Sub ShowReceipt()
        Dim tmpSql As String, tmpReceiptRS As ADODB.Recordset

        tmpSql = "Select * from tblreceipt where ReceiptNo='" & gCurReceiptNo & "'"
        tmpReceiptRS = gcon.Execute(tmpSql)
        With tmpReceiptRS
            If .EOF = False Then
                txtReceiptNo.Text = tmpReceiptRS("ReceiptNo").Value.ToString
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
End Class