Public Class frmManageVoucherBook
    Dim tablename_voucherbook As String = ""

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo errH


        gcon.BeginTrans()

        Dim tmpRS As ADODB.Recordset, vchNo As Integer, bookID As String


        If (txtStartNo.Text = "") Then
            gErrMsg = "Provide Starting Voucher No."
            GoTo errH
        End If
        If (txtEndNo.Text = "") Then
            gErrMsg = "Provide End Voucher No."
            GoTo errH
        End If

        If IsNumeric(txtStartNo.Text) = False Then
            gErrMsg = "Starting Voucher No is not numeric"
            GoTo errH
        End If
        If IsNumeric(txtEndNo.Text) = False Then
            gErrMsg = "End Voucher No is not numeric"
            GoTo errH
        End If
        If CLng(txtStartNo.Text) > CLng(txtEndNo.Text) Then
            gErrMsg = "End Voucher No can't be less than Start Voucher no"
            GoTo errH
        End If

        txtStartNo.Text = stripLeadingZero(txtStartNo.Text)
        txtEndNo.Text = stripLeadingZero(txtEndNo.Text)


        ssql = "select tblid from " & tablename_voucherbook & " where "
        ssql = ssql & " VoucherNo >= " & txtStartNo.Text & " and VoucherNo <=" & txtEndNo.Text
        tmpRS = gcon.Execute(ssql)

        If tmpRS.EOF = False Then
            gErrMsg = "This voucher book range is already entered in system"
            GoTo errH
        End If
        bookID = txtStartNo.Text & "-" & txtEndNo.Text

        For vchNo = txtStartNo.Text To txtEndNo.Text
            ssql = "Insert into " & tablename_voucherbook & " (BookID,VoucherNo) values ('" & bookID & "'," & vchNo & ")"
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


        dgvData.Rows.Clear()

        QuerySQL = "select * from " & tablename_voucherbook & " where BookID='" & cboBookID.Text & "'"
        QuerySQL = QuerySQL & " order by tblid desc"
        rsData = gcon.Execute(QuerySQL)


        With dgvData

            While rsData.EOF = False

                i = .Rows.Add()
                .Rows(i).Cells("tblid").Value = rsData("tblid").Value.ToString
                .Rows(i).Cells("BookID").Value = rsData("BookID").Value.ToString
                .Rows(i).Cells("VoucherNo").Value = rsData("VoucherNo").Value.ToString
                .Rows(i).Cells("ActivatedBy").Value = rsData("ActivatedBy").Value.ToString
                .Rows(i).Cells("ActivationDate").Value = formatInt2Date(rsData("ActivationDate").Value.ToString)
                .Rows(i).Cells("Remarks").Value = rsData("Remarks").Value.ToString

                .Rows(i).ReadOnly = True

                If rsData("Status").Value.ToString = "" Then
                    .Rows(i).Cells("Status").Value = "Inactive"
                    .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                ElseIf rsData("Status").Value.ToString = "A" Then
                    .Rows(i).Cells("Status").Value = "Available"
                    .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                ElseIf rsData("Status").Value.ToString = "U" Then
                    .Rows(i).Cells("Status").Value = "Used"
                    .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                ElseIf rsData("Status").Value.ToString = "O" Then
                    .Rows(i).Cells("Status").Value = "Not Used & Obsolete"
                    .Rows(i).DefaultCellStyle.ForeColor = Color.White
                    .Rows(i).DefaultCellStyle.BackColor = Color.Black
                End If

                rsData.MoveNext()

            End While

            'Enable row level activation???
            btnActivateThisBook.Enabled = False
            If dgvData.Rows.Count > 0 Then
                If dgvData.Rows(1).Cells("Status").Value = "Inactive" Then
                    btnActivateThisBook.Enabled = True
                End If
            End If
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
        dgvData.Rows.Clear()

        cboBookID.Items.Clear()
        cboBookID.SelectedIndex = -1

        If formMode = "Q" Then
            ssql = "select distinct BookID from " & tablename_voucherbook & " order by tblid desc"
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

    Private Sub frmManageVoucherBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboBookType.Items.Clear()
        cboBookType.Items.Add("Maintenance")
        cboBookType.Items.Add("Cultural")
        cboBookType.Text = "Maintenance"
        tablename_voucherbook = "tblvoucherbook"

        resetFields("Q")
        PopulateGrid()
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

    Private Sub btnActivateThisBook_Click(sender As Object, e As EventArgs) Handles btnActivateThisBook.Click
        ssql = "Update " & tablename_voucherbook & " set Status='A', ActivatedBy='" & gUserName & "', ActivationDate=" & DateTime.Now.ToString(DB_DATEFORMAT) & " where BookID='" & cboBookID.Text & "'"
        gcon.Execute(ssql)
        btnActivateThisBook.Enabled = False
        PopulateGrid()
    End Sub

    Private Sub txtStartNo_TextChanged(sender As Object, e As EventArgs) Handles txtStartNo.TextChanged
        If IsNumeric(txtStartNo.Text) = True Then txtEndNo.Text = CLng(txtStartNo.Text) + 99
    End Sub

    Private Sub cboBookType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBookType.SelectedIndexChanged
        If cboBookType.Text = "Maintenance" Then
            tablename_voucherbook = "tblvoucherbook"
        ElseIf cboBookType.Text = "Cultural" Then
            tablename_voucherbook = "tblvoucherbook_cult"
        Else
            tablename_voucherbook = ""
        End If
        resetFields("Q")
    End Sub
End Class
