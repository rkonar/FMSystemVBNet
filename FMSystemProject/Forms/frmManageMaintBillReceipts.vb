Public Class frmManageMaintBillReceipts

    Private Sub frmManageMaintBillReceipts_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboSearchApartment.DataSource = FLATS
        dgvReceipts.Rows.Clear()
        btnAddRow.Enabled = False
        btnDeleteRow.Enabled = False
        btnSaveRow.Enabled = False
        btnUpdateRow.Enabled = False

        Dim cboCol As DataGridViewComboBoxColumn
        cboCol = dgvReceipts.Columns("InstrumentType")
        cboCol.Items.AddRange(INSTRUMENT_TYPES)

    End Sub

    Private Sub btnQuery_Click(sender As System.Object, e As System.EventArgs) Handles btnQuery.Click
        Dim tmpSql As String

        tmpSql = getQueryReceiptsSQL()

        If tmpSql <> "" Then
            rsReceipts = gcon.Execute(tmpSql)
            If rsReceipts.EOF = False Then
                PopulateReceipts()


                btnAddRow.Enabled = True
                btnDeleteRow.Enabled = False
                btnSaveRow.Enabled = False
                btnUpdateRow.Enabled = False
            End If
        End If

        tmpSql = getQueryBillsSQL()

        If tmpSql <> "" Then
            rsBills = gcon.Execute(tmpSql)
            If rsBills.EOF = False Then
                PopulateBills()
            End If
        End If

    End Sub

    Private Function getQueryReceiptsSQL() As String
        On Error GoTo errH

        Dim tmpSql As String
        tmpSql = "Select * from tblreceipt where 1 = 1 "
        If Trim(cboSearchApartment.Text) <> "" Then
            tmpSql = tmpSql & " and FlatCode='" & Trim(cboSearchApartment.Text) & "'"
        End If

        If chkOnlyUnadjusted.Checked = True Then
            tmpSql = tmpSql & " and AdjustedAmt < ReceiptAmt"
        End If

        getQueryReceiptsSQL = tmpSql
        Exit Function
errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
        getQueryReceiptsSQL = ""
    End Function
    Private Function getQueryBillsSQL() As String
        On Error GoTo errH

        Dim tmpSql As String
        tmpSql = "Select * from tblbill where 1 = 1 "
        If Trim(cboSearchApartment.Text) <> "" Then
            tmpSql = tmpSql & " and FlatCode='" & Trim(cboSearchApartment.Text) & "'"
        End If

        If chkOnlyUnadjusted.Checked = True Then
            'tmpSql = tmpSql & " and BillAmtPaid < BillAmt"
        End If

        getQueryBillsSQL = tmpSql
        Exit Function
errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
        getQueryBillsSQL = ""
    End Function

    Sub PopulateReceipts()
        On Error GoTo errH

        Dim i As Long, tmpRC As Long, tmpLC As Long

        dgvReceipts.Rows.Clear()
        rsReceipts.MoveFirst()

        While rsReceipts.EOF = False

            i = dgvReceipts.Rows.Add()
            dgvReceipts.Rows(i).DefaultCellStyle.BackColor = Color.Gray
            dgvReceipts.Rows(i).Cells("ReceiptRowState").Value = "Q"
            dgvReceipts.Rows(i).Cells("ReceiptID").Value = rsReceipts("tblid").Value
            dgvReceipts.Rows(i).Cells("ReceiptNo").Value = rsReceipts("ReceiptNo").Value & ""
            dgvReceipts.Rows(i).Cells("ReceiptDate").Value = formatInt2Date(rsReceipts("ReceiptDate").Value & "")
            dgvReceipts.Rows(i).Cells("ReceiptAmt").Value = rsReceipts("ReceiptAmt").Value & ""
            dgvReceipts.Rows(i).Cells("ReceiptAdjAmt").Value = rsReceipts("AdjustedAmt").Value & ""
            dgvReceipts.Rows(i).Cells("InstrumentType").Value = rsReceipts("InstrumentType").Value & ""
            dgvReceipts.Rows(i).Cells("InstrumentDate").Value = formatInt2Date(rsReceipts("InstrumentDate").Value & "")
            dgvReceipts.Rows(i).Cells("InstrumentBank").Value = rsReceipts("InstrumentBank").Value & ""
            dgvReceipts.Rows(i).Cells("InstrumentNo").Value = rsReceipts("InstrumentNo").Value & ""

            dgvReceipts.Rows(i).ReadOnly = True

            rsReceipts.MoveNext()

        End While

        'lblNoOfRecords.Text = dgvReceipts.Rows.Count & " Rows"

        'grset.Close()
        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub
    Sub PopulateBills()
        On Error GoTo errH

        Dim i As Long, tmpRC As Long, tmpLC As Long

        dgvBills.Rows.Clear()
        rsBills.MoveFirst()

        While rsBills.EOF = False

            i = dgvBills.Rows.Add()
            dgvBills.Rows(i).DefaultCellStyle.BackColor = Color.Gray
            dgvBills.Rows(i).Cells("BillRowState").Value = "Q"
            dgvBills.Rows(i).Cells("BillID").Value = rsBills("tblid").Value
            dgvBills.Rows(i).Cells("BillNo").Value = rsBills("BillNo").Value & ""
            dgvBills.Rows(i).Cells("BillDate").Value = formatInt2Date(rsBills("BillDate").Value & "")
            dgvBills.Rows(i).Cells("BillAmt").Value = rsBills("BillAmt").Value & ""
            'dgvBills.Rows(i).Cells("BillPaidAmt").Value = rsBills("BillAmtPaid").Value & ""
            dgvBills.Rows(i).Cells("BillType").Value = rsBills("BillType").Value & ""
            dgvBills.Rows(i).Cells("DueDate").Value = formatInt2Date(rsBills("DueDate").Value & "")
            dgvBills.Rows(i).Cells("BillFrom").Value = rsBills("BillMonthFrom").Value & ""
            dgvBills.Rows(i).Cells("BillTo").Value = rsBills("BillMonthTo").Value & ""

            dgvBills.Rows(i).ReadOnly = True

            rsBills.MoveNext()

        End While

        'lblNoOfRecords.Text = dgvReceipts.Rows.Count & " Rows"

        'grset.Close()
        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub
    Private Sub dgvReceipts_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceipts.CellClick
        Dim tmpR As Integer
        tmpR = dgvReceipts.CurrentRow.Index
        If dgvReceipts.Rows(tmpR).Cells("ReceiptRowState").Value = "N" Then
            btnAddRow.Enabled = True
            btnDeleteRow.Enabled = True
            'btnSaveRow.Enabled = False
            btnUpdateRow.Enabled = False
        ElseIf dgvReceipts.Rows(tmpR).Cells("ReceiptRowState").Value = "U" Then
            btnAddRow.Enabled = True
            btnDeleteRow.Enabled = False
            'btnSaveRow.Enabled = False
            btnUpdateRow.Enabled = False
        ElseIf dgvReceipts.Rows(tmpR).Cells("ReceiptRowState").Value = "Q" Then
            btnAddRow.Enabled = True
            btnDeleteRow.Enabled = True
            'btnSaveRow.Enabled = False
            btnUpdateRow.Enabled = True
        ElseIf dgvReceipts.Rows(tmpR).Cells("ReceiptRowState").Value = "D" Then
            btnAddRow.Enabled = True
            btnDeleteRow.Enabled = False
            'btnSaveRow.Enabled = False
            btnUpdateRow.Enabled = False
        End If
    End Sub

    Private Sub btnAddRow_Click(sender As System.Object, e As System.EventArgs) Handles btnAddRow.Click
        Dim tmpR As Integer
        tmpR = dgvReceipts.Rows.Add()
        dgvReceipts.Rows(tmpR).Cells("ReceiptRowState").Value = "N"
        dgvReceipts.Rows(tmpR).Cells("ReceiptDate").Value = Today.ToString
        dgvReceipts.Rows(tmpR).Cells("InstrumentType").Value = "CHEQUE"
        dgvReceipts.Rows(tmpR).Cells("InstrumentDate").Value = Today.ToString
        btnSaveRow.Enabled = True
    End Sub
    Private Sub btnDeleteRow_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteRow.Click
        Dim tmpR As Integer
        tmpR = dgvReceipts.CurrentRow.Index
        If dgvReceipts.Rows(tmpR).Cells("ReceiptRowState").Value = "N" Then
            dgvReceipts.Rows.RemoveAt(tmpR)
            If btnSaveRow.Enabled = True Then
                btnSaveRow.Enabled = False
                For tmpR = 0 To dgvReceipts.Rows.Count - 1
                    If dgvReceipts.Rows(tmpR).Cells("ReceiptRowState").Value <> "Q" Then
                        btnSaveRow.Enabled = True
                        Exit For
                    End If
                Next
            End If
        Else
            dgvReceipts.Rows(tmpR).Cells("ReceiptRowState").Value = "D"
            dgvReceipts.Rows(tmpR).DefaultCellStyle.BackColor = Color.Red
            'dgvReceipts.Rows(tmpR).Visible = False
            btnSaveRow.Enabled = True
        End If

    End Sub
    Private Sub btnUpdateRow_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateRow.Click
        Dim tmpR As Integer
        tmpR = dgvReceipts.CurrentRow.Index

        btnAddRow.Enabled = False
        btnDeleteRow.Enabled = False
        btnSaveRow.Enabled = True
        btnUpdateRow.Enabled = False

        dgvReceipts.Rows(tmpR).ReadOnly = False
        dgvReceipts.Rows(tmpR).Cells("ReceiptRowState").Value = "U"
        dgvReceipts.Rows(tmpR).DefaultCellStyle.BackColor = Color.Beige
        btnSaveRow.Enabled = True
    End Sub

    Private Sub btnSaveRow_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveRow.Click
        btnAddRow.Enabled = True
        btnDeleteRow.Enabled = False
        btnSaveRow.Enabled = False
        btnUpdateRow.Enabled = True
    End Sub


    Private Sub dgvReceipts_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceipts.CellContentDoubleClick
        Dim tmpR As Integer, tmpC As Integer
        tmpR = dgvReceipts.CurrentRow.Index
        tmpC = dgvReceipts.CurrentCell.ColumnIndex

        If dgvReceipts.Rows(tmpR).ReadOnly = True Then Exit Sub

        If tmpC = dgvReceipts.Rows(tmpR).Cells("ReceiptDate").ColumnIndex Then
            dtpDateSelected = dgvReceipts.Rows(tmpR).Cells("ReceiptDate").Value
            dlgDtpDialog.ShowDialog()
            dlgDtpDialog.Dispose()
            dgvReceipts.Rows(tmpR).Cells("ReceiptDate").Value = dtpDateSelected
        End If
        If tmpC = dgvReceipts.Rows(tmpR).Cells("InstrumentDate").ColumnIndex Then
            dtpDateSelected = dgvReceipts.Rows(tmpR).Cells("InstrumentDate").Value
            dlgDtpDialog.ShowDialog()
            dlgDtpDialog.Dispose()
            dgvReceipts.Rows(tmpR).Cells("InstrumentDate").Value = dtpDateSelected
        End If
    End Sub



    Private Sub dgvReceipts_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceipts.CellValueChanged
        Dim tmpR As Integer, tmpC As Integer

        If dgvReceipts.CurrentRow Is Nothing Then Exit Sub

        tmpR = dgvReceipts.CurrentRow.Index
        tmpC = dgvReceipts.CurrentCell.ColumnIndex

        If dgvReceipts.Rows(tmpR).ReadOnly = True Then Exit Sub

        If tmpC = dgvReceipts.Rows(tmpR).Cells("InstrumentType").ColumnIndex Then
            If dgvReceipts.Rows(tmpR).Cells("InstrumentType").Value = "CASH" Then
                dgvReceipts.Rows(tmpR).Cells("InstrumentDate").Value = ""
                dgvReceipts.Rows(tmpR).Cells("InstrumentBank").Value = ""
                dgvReceipts.Rows(tmpR).Cells("InstrumentNo").Value = ""

                dgvReceipts.Rows(tmpR).Cells("InstrumentDate").ReadOnly = True
                dgvReceipts.Rows(tmpR).Cells("InstrumentBank").ReadOnly = True
                dgvReceipts.Rows(tmpR).Cells("InstrumentNo").ReadOnly = True

            ElseIf dgvReceipts.Rows(tmpR).Cells("InstrumentType").Value = "CHEQUE" Then
                dgvReceipts.Rows(tmpR).Cells("InstrumentDate").Value = Now.ToString

                dgvReceipts.Rows(tmpR).Cells("InstrumentDate").ReadOnly = False
                dgvReceipts.Rows(tmpR).Cells("InstrumentBank").ReadOnly = False
                dgvReceipts.Rows(tmpR).Cells("InstrumentNo").ReadOnly = False
            ElseIf dgvReceipts.Rows(tmpR).Cells("InstrumentType").Value = "ONLINE" Then
                dgvReceipts.Rows(tmpR).Cells("InstrumentDate").Value = Now.ToString

                dgvReceipts.Rows(tmpR).Cells("InstrumentDate").ReadOnly = False
                dgvReceipts.Rows(tmpR).Cells("InstrumentNo").ReadOnly = False
                dgvReceipts.Rows(tmpR).Cells("InstrumentNo").ReadOnly = False
            End If
        End If

    End Sub

    Private Sub dgvReceipts_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceipts.CellContentClick

    End Sub

    Private Sub dgvBills_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBills.CellContentClick

    End Sub
End Class