Public Class frmManageChequeBook


    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo errH


        gcon.BeginTrans()

        Dim tmpRS As ADODB.Recordset, chqNo As Integer, bookID As String


        If (txtStartNo.Text = "") Then
            gErrMsg = "Provide Starting Cheque No."
            GoTo errH
        End If
        If (txtEndNo.Text = "") Then
            gErrMsg = "Provide End Cheque No."
            GoTo errH
        End If
        If (txtMICR.Text = "") Then
            gErrMsg = "Provide MICR No."
            GoTo errH
        End If

        If IsNumeric(txtStartNo.Text) = False Then
            gErrMsg = "Starting Cheque No is not numeric"
            GoTo errH
        End If
        If IsNumeric(txtEndNo.Text) = False Then
            gErrMsg = "End Cheque No is not numeric"
            GoTo errH
        End If
        If IsNumeric(txtMICR.Text) = False Then
            gErrMsg = "MICR No is not numeric"
            GoTo errH
        End If
        If CLng(txtStartNo.Text) > CLng(txtEndNo.Text) Then
            gErrMsg = "End Cheque No can't be less than Start Cheque no"
            GoTo errH
        End If

        txtStartNo.Text = stripLeadingZero(txtStartNo.Text)
        txtEndNo.Text = stripLeadingZero(txtEndNo.Text)


        ssql = "select tblid from tblchequebook where AccountNo='" & cboAccount.Text & "' "
        ssql = ssql & " and ChequeNo >= " & txtStartNo.Text & " and ChequeNo <=" & txtEndNo.Text
        tmpRS = gcon.Execute(ssql)

        If tmpRS.EOF = False Then
            gErrMsg = "This Cheque book range is already entered in system"
            GoTo errH
        End If
        bookID = cboAccount.Text & "-" & txtStartNo.Text & "-" & txtEndNo.Text

        For chqNo = txtStartNo.Text To txtEndNo.Text
            ssql = "Insert into tblchequebook (BookID,ChequeNo,AccountNo,MICR,Remarks,UpdatedBy) values ('" & bookID & "'," & chqNo & ",'" & cboAccount.Text & "','" & txtMICR.Text & "','Available for use','" & gUserName & "')"
            tmpRS = gcon.Execute(ssql)
        Next
        gcon.CommitTrans()

        resetFields("Q")
        'PopulateGrid()

        Exit Sub
errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)
    End Sub


    Sub PopulateGrid()
        On Error GoTo errH
        Dim i As Long, rsData As ADODB.Recordset, QuerySQL As String
        Dim btnCancel As DataGridViewButtonCell

        dgvData.Rows.Clear()

        QuerySQL = "select * from tblchequebook where BookID='" & cboBookID.Text & "'"
        QuerySQL = QuerySQL & " order by tblid desc"
        rsData = gcon.Execute(QuerySQL)


        With dgvData

            While rsData.EOF = False

                i = .Rows.Add()
                .Rows(i).Cells("tblid").Value = rsData("tblid").Value.ToString
                .Rows(i).Cells("MICR").Value = rsData("MICR").Value.ToString
                txtMICR.Text = rsData("MICR").Value.ToString
                .Rows(i).Cells("BookID").Value = rsData("BookID").Value.ToString
                .Rows(i).Cells("ChequeNo").Value = rsData("ChequeNo").Value.ToString
                .Rows(i).Cells("VoucherNo").Value = rsData("VoucherNo").Value.ToString
                .Rows(i).Cells("UpdatedBy").Value = rsData("UpdatedBy").Value.ToString
                .Rows(i).Cells("Remarks").Value = rsData("Remarks").Value.ToString

                .Rows(i).ReadOnly = True
                btnCancel = .Rows(i).Cells("Cancel")
                btnCancel.FlatStyle = FlatStyle.Flat

                .Rows(i).Cells("Cancel").Value = ""

                If rsData("Status").Value.ToString = "" Then
                    .Rows(i).Cells("Status").Value = "Available"
                    .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                    .Rows(i).Cells("Cancel").Value = "Cancel"
                    btnCancel.FlatStyle = FlatStyle.Standard
                ElseIf rsData("Status").Value.ToString = "U" Then
                    .Rows(i).Cells("Status").Value = "Used"
                    .Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                ElseIf rsData("Status").Value.ToString = "O" Then
                    .Rows(i).Cells("Status").Value = "Not Used & Obsolete"
                    .Rows(i).DefaultCellStyle.ForeColor = Color.White
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gray
                ElseIf rsData("Status").Value.ToString = "C" Then
                    .Rows(i).Cells("Status").Value = "Cancelled"
                    .Rows(i).DefaultCellStyle.ForeColor = Color.White
                    .Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If

                rsData.MoveNext()

            End While

        End With

        rsData.Close()

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub



    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        resetFields("I")
    End Sub
    Sub resetFields(formMode As String)

        txtStartNo.Text = ""
        txtEndNo.Text = ""
        'txtMICR.Text = ""
        txtCancellationReason.Text = ""
        dgvData.Rows.Clear()

        cboBookID.Items.Clear()
        cboBookID.SelectedIndex = -1

        txtCancellationReason.Enabled = False

        If formMode = "Q" Then
            ssql = "select distinct BookID from tblchequebook where AccountNo='" & cboAccount.Text & "' order by tblid desc"
            tmpRS = gcon.Execute(ssql)

            While tmpRS.EOF = False
                cboBookID.Items.Add(tmpRS("BookID").Value.ToString)
                tmpRS.MoveNext()
                cboBookID.SelectedIndex = 0
            End While
            cboBookID.Enabled = True

            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnCancel.Enabled = False
            txtStartNo.Enabled = False
            txtEndNo.Enabled = False


        Else
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnCancel.Enabled = True
            txtStartNo.Enabled = True
            txtEndNo.Enabled = True
            cboBookID.Enabled = False
        End If

    End Sub

    Sub loadBankAccounts()
        Dim actRS As ADODB.Recordset

        cboAccount.Items.Clear()

        If cboBookType.Text = "Maintenance" Then
            ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Liabilities' and ParentAccountNo = 'CHEQUE-ISSUED-ALL'"
        ElseIf cboBookType.Text = "Cultural" Then
            ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Liabilities' and ParentAccountNo = 'CHEQUE-ISSUED-ALL-CULT'"
        Else
            ssql = ""
        End If

        actRS = gcon.Execute(ssql)
        While actRS.EOF = False
            cboAccount.Items.Add(actRS("AccountNo").Value.ToString)
            actRS.MoveNext()
            cboAccount.SelectedIndex = 0
        End While
        actRS.Close()

    End Sub


    Private Sub btnQueryTxn_Click(sender As Object, e As EventArgs) Handles btnQueryTxn.Click
        PopulateGrid()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        resetFields("Q")
        PopulateGrid()
    End Sub

    Private Sub cboBookID_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboBookID.SelectedValueChanged
        PopulateGrid()
    End Sub

    Private Sub txtStartNo_TextChanged(sender As Object, e As EventArgs) Handles txtStartNo.TextChanged
        If IsNumeric(txtStartNo.Text) = True Then txtEndNo.Text = CLng(txtStartNo.Text) + 24
    End Sub

    Private Sub cboAccount_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAccount.SelectedValueChanged
        txtActDesc.Text = getAccountName(cboAccount.Text)
        resetFields("Q")
        PopulateGrid()
    End Sub

    Private Sub frmManageCheckBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboBookType.Items.Clear()
        cboBookType.Items.Add("Maintenance")
        cboBookType.Items.Add("Cultural")
        cboBookType.Text = "Maintenance"

        loadBankAccounts()
        resetFields("Q")
        PopulateGrid()
    End Sub

   

    Private Sub dgvData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellContentClick
        Dim btnCell As DataGridViewButtonCell, chqNo As String, tblid As String

        'Start - Data Grid Click - common code to skip invalid clicks
        Dim ri As Integer, ci As Integer

        ri = dgvData.CurrentCell.RowIndex
        If ri < 0 Then Exit Sub
        ci = dgvData.CurrentCell.ColumnIndex
        If ci <> 8 Then Exit Sub

        btnCell = dgvData.Rows(ri).Cells(ci)
        chqNo = dgvData.Rows(ri).Cells(3).Value
        tblid = dgvData.Rows(ri).Cells(0).Value

        If btnCell.Value <> "Cancel" Then Exit Sub

        If Trim(txtCancellationReason.Text) = "" Then
            MsgBox("Provide Cancellation Reason")
            txtCancellationReason.Enabled = True
            Exit Sub
        End If

        If MsgBox("Are you sure you want to Cancel this cheque? Cheque No: " & chqNo, vbYesNo) = vbNo Then
            Exit Sub
        End If

        ssql = "Update tblchequebook set Status='C',Remarks='" & Replace(txtCancellationReason.Text, "'", "''") & "',UpdatedBy='" & gUserName & "' where tblid = " & tblid
        gcon.Execute(ssql)

        MsgBox("Cheque No: " & chqNo & " Cancelled")

        txtCancellationReason.Text = ""
        txtCancellationReason.Enabled = False

        btnQueryTxn.PerformClick()

    End Sub

    Private Sub cboBookType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBookType.SelectedIndexChanged
        loadBankAccounts()
        resetFields("Q")
    End Sub
End Class
