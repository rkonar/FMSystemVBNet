
Public Class frmAddEditServiceCase

    Dim AddOrEdit As String = ""

    Sub PopulateGrid()
        On Error GoTo errH

        Dim tmpSql As String, i As Integer, strDT As String, pos As Integer, strTM As String

        tmpSql = "select * from tblservicerequest where FlatCode='" & txtFlatCode.Text & "'"
        tmpRS = gcon.Execute(tmpSql)
        If tmpRS.EOF = True Then
            setControlState("CLEAR-N-DISABLE")
            Exit Sub
        End If

        With dgvCase
            .Rows.Clear()
            While tmpRS.EOF = False

                i = .Rows.Add()
                .Rows(i).Cells("tblid").Value = tmpRS("tblid").Value.ToString
                .Rows(i).Cells("FlatCode").Value = tmpRS("FlatCode").Value.ToString
                .Rows(i).Cells("CaseType").Value = tmpRS("CaseType").Value.ToString
                .Rows(i).Cells("CaseNo").Value = tmpRS("CaseNo").Value.ToString
                .Rows(i).Cells("CaseDesc").Value = tmpRS("CaseDesc").Value.ToString
                .Rows(i).Cells("RequestedBy").Value = tmpRS("RequestedBy").Value.ToString
                .Rows(i).Cells("RequestedVia").Value = tmpRS("RequestedVia").Value.ToString

                .Rows(i).Cells("LogTimePosition").Value = tmpRS("LogTimePosition").Value.ToString
                .Rows(i).Cells("AssignedTo").Value = tmpRS("CaseAssignedTo").Value.ToString

                .Rows(i).Cells("ClosureComment").Value = tmpRS("ClosureComment").Value.ToString
                .Rows(i).Cells("Status").Value = tmpRS("Status").Value.ToString

                .Rows(i).Cells("LogDateTime").Value = formatInt2Date(tmpRS("CaseLogDate").Value.ToString) & " " & formatInt2Time(tmpRS("CaseLogTime").Value.ToString)
                .Rows(i).Cells("CloseDateTime").Value = formatInt2Date(tmpRS("CaseCompleteDate").Value.ToString) & " " & formatInt2Time(tmpRS("CaseCompleteTime").Value.ToString)


                .Rows(i).ReadOnly = True

                If tmpRS("Status").Value.ToString = "CLOSED" Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Green
                ElseIf tmpRS("Status").Value.ToString = "TERMINATED" Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gray
                Else
                    .Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If
                tmpRS.MoveNext()

            End While

        End With

        tmpRS.Close()

        setControlState("CLEAR-N-DISABLE")

        Exit Sub

errH:

        MsgBox(Err.Description)
    End Sub
    Sub PopulateBlock(tmpTblid As String)
        On Error GoTo errH

        Dim tmpSql As String, i As Integer, strDT As String, pos As Integer, strTM As String


        tmpSql = "select * from tblservicerequest where tblid=" & tmpTblid
        tmpRS = gcon.Execute(tmpSql)
        If tmpRS.EOF = True Then
            Exit Sub
        End If

        cboCaseType.Text = tmpRS("CaseType").Value.ToString
        txtCaseNo.Text = tmpRS("CaseNo").Value.ToString
        txtCaseDesc.Text = tmpRS("CaseDesc").Value.ToString
        txtRequestedBy.Text = tmpRS("RequestedBy").Value.ToString
        cboRequestedVia.Text = tmpRS("RequestedVia").Value.ToString

        txtLogTimePosition.Text = tmpRS("LogTimePosition").Value.ToString
        cboAssignedTo.Text = tmpRS("CaseAssignedTo").Value.ToString

        txtClosureComment.Text = tmpRS("ClosureComment").Value.ToString

        setCaseStatus(tmpRS("Status").Value.ToString)

        txtLogDate.Text = formatInt2Date(tmpRS("CaseLogDate").Value.ToString) & " " & formatInt2Time(tmpRS("CaseLogTime").Value.ToString)
        txtCompleteDate.Text = formatInt2Date(tmpRS("CaseCompleteDate").Value.ToString) & " " & formatInt2Time(tmpRS("CaseCompleteTime").Value.ToString)

        txtPresentPosition.Text = getPresentPosition()

        If tmpRS("Status").Value.ToString = "CLOSED" Then
            setControlState("VIEW")
            btnSMS.Enabled = True
        ElseIf tmpRS("Status").Value.ToString = "TERMINATED" Then
            setControlState("VIEW")
            btnSMS.Enabled = False
        ElseIf tmpRS("Status").Value.ToString = "OPEN" Then
            setControlState("EDIT")
            btnSMS.Enabled = True
        ElseIf tmpRS("Status").Value.ToString = "NEW" Then
            setControlState("EDIT")
            btnSMS.Enabled = False
        ElseIf tmpRS("Status").Value.ToString = "HOLD" Then
            setControlState("EDIT")
            btnSMS.Enabled = False
        End If

        tmpRS.Close()


        Exit Sub

errH:

        MsgBox(Err.Description)
    End Sub

    Sub setCaseStatus(thisStatus As String)
        With cboCaseStatus
            .Items.Clear()
            Select Case thisStatus
                Case "NEW"
                    .Items.Add("NEW")
                    .Items.Add("OPEN")
                    .Items.Add("HOLD")
                    .Items.Add("CLOSED")
                    .Items.Add("TERMINATED")
                Case "OPEN"
                    .Items.Add("OPEN")
                    .Items.Add("HOLD")
                    .Items.Add("CLOSED")
                    .Items.Add("TERMINATED")
                Case "HOLD"
                    .Items.Add("HOLD")
                    .Items.Add("CLOSED")
                    .Items.Add("TERMINATED")
                Case "CLOSED"
                    .Items.Add("CLOSED")
                Case "TERMINATED"
                    .Items.Add("TERMINATED")
                Case Else

            End Select
            .Text = thisStatus
        End With
    End Sub


    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        PopulateGrid()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        On Error GoTo errH

        Dim tmpSql As String = ""


        If validateDetails() = False Then Exit Sub

        If AddOrEdit = "E" Then

            tmpSql = "update tblservicerequest set "
            tmpSql = tmpSql & "CaseDesc='" & Replace(Trim(txtCaseDesc.Text), "'", "''") & "',"
            tmpSql = tmpSql & "RequestedBy='" & Replace(Trim(txtRequestedBy.Text), "'", "''") & "',"
            tmpSql = tmpSql & "RequestedVia='" & cboRequestedVia.Text & "',"
            tmpSql = tmpSql & "CaseAssignedTo='" & cboAssignedTo.Text & "',"
            tmpSql = tmpSql & "ClosureComment='" & Replace(Trim(txtClosureComment.Text), "'", "''") & "',"
            If cboCaseStatus.Text = "CLOSED" Or cboCaseStatus.Text = "TERMINATED" Then
                tmpSql = tmpSql & "ClosedBy='" & gLoginID & "',"
                tmpSql = tmpSql & "CaseCompleteDate='" & Now.ToString(DB_DATEFORMAT) & "',"
                tmpSql = tmpSql & "CaseCompleteTime='" & Now.ToString(DB_TIMEFORMAT) & "',"
            End If
            tmpSql = tmpSql & "Status='" & cboCaseStatus.Text & "'"
            tmpSql = tmpSql & " where CaseNo='" & txtCaseNo.Text & "'"

            gItemAction = "Update Case Details"

        ElseIf AddOrEdit = "A" Then

            tmpSql = "Insert into tblservicerequest (CaseType,CaseNo,CaseDesc,FlatCode,RequestedBy,RequestedVia,CaseLogDate,CaseLogTime,LogTimePosition,CaseAssignedTo,CaseCompleteDate,CaseCompleteTime,ClosureComment,Status,CreatedBy,ClosedBy) values ( "
            tmpSql = tmpSql & "'" & cboCaseType.Text & "',"
            tmpSql = tmpSql & "'" & txtCaseNo.Text & "',"
            tmpSql = tmpSql & "'" & Replace(Trim(txtCaseDesc.Text), "'", "''") & "',"
            tmpSql = tmpSql & "'" & txtFlatCode.Text & "',"
            tmpSql = tmpSql & "'" & Replace(Trim(txtRequestedBy.Text), "'", "''") & "',"
            tmpSql = tmpSql & "'" & cboRequestedVia.Text & "',"
            tmpSql = tmpSql & "'" & Now.ToString(DB_DATEFORMAT) & "',"
            tmpSql = tmpSql & "'" & Now.ToString(DB_TIMEFORMAT) & "',"
            tmpSql = tmpSql & txtLogTimePosition.Text & ","
            tmpSql = tmpSql & "'" & cboAssignedTo.Text & "',"
            tmpSql = tmpSql & "NULL" & ","
            tmpSql = tmpSql & "NULL" & ","
            tmpSql = tmpSql & "NULL" & ","
            tmpSql = tmpSql & "'" & cboCaseStatus.Text & "',"
            tmpSql = tmpSql & "'" & gLoginID & "',"
            tmpSql = tmpSql & "NULL"
            tmpSql = tmpSql & ")"

            gItemAction = "Add Service Case"
        End If

        gcon.Execute(tmpSql)

        gItemID = "Case No=" & txtCaseNo.Text

        MsgBox("Save successful")

        If chkNoSMS.Checked = False Then
            sendCaseUpdateViaSMS()
        Else
            MsgBox("SMS was skipped")
        End If


        If logUserActivity() = False Then Exit Sub

        PopulateGrid()

        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub

    Function validateDetails() As Boolean
        validateDetails = False
        If Trim(txtCaseNo.Text) = "" Then
            MsgBox("Invalid Case No")
            Exit Function
        End If
        If Trim(cboCaseType.Text) = "" Then
            MsgBox("Provide Case Type")
            Exit Function
        End If
        If cboCaseStatus.Text <> "NEW" And (cboAssignedTo.Text = "Not Assigned" Or cboAssignedTo.Text = "") Then
            MsgBox("Enter Assigned To")
            Exit Function
        End If

        If Trim(txtCaseDesc.Text) = "" Then
            MsgBox("Provide Case Description")
            Exit Function
        End If
        If cboCaseStatus.Text = "HOLD" Or cboCaseStatus.Text = "CLOSED" Or cboCaseStatus.Text = "TERMINATED" Then
            If Trim(txtClosureComment.Text) = "" Then
                MsgBox("Comment is mandatory for hold, closure or termination of a case")
                Exit Function
            End If
        End If

        validateDetails = True
    End Function

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub fetchFlatOwner()
        Dim tmpRS As ADODB.Recordset
        tmpRS = gcon.Execute("select * from tblflatowners where FlatCode='" & txtFlatCode.Text & "' and IsActiveOwner='Y'")
        If tmpRS.EOF = False Then
            lblOwner.Text = tmpRS("OwnerFullName").Value.ToString
            lblCoOwner.Text = tmpRS("CoOwnerFullName").Value.ToString
        Else
            lblOwner.Text = ""
            lblCoOwner.Text = ""
        End If
        tmpRS.Close()
    End Sub

    Private Sub btnEditFlatOwnerDetails_Click(sender As Object, e As EventArgs) Handles btnEditFlatOwnerDetails.Click
        gCurFlatCode = txtFlatCode.Text
        frmManageFlats.ShowDialog()
        frmManageFlats.Dispose()
    End Sub


    Private Sub frmAddEditServiceCase_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtCaseNo.Enabled = False
        txtCompleteDate.Enabled = False
        txtFlatCode.Enabled = False
        txtLogDate.Enabled = False
        txtLogTimePosition.Enabled = False
        txtPresentPosition.Enabled = False


        txtFlatCode.Text = gCurFlatCode

        cboCaseType.Items.Add("PLUMBING")
        cboCaseType.Items.Add("ELECTRICAL")
        cboCaseType.Items.Add("HOUSEKEEPING")
        cboCaseType.Items.Add("LIFT")

        'Do not change the ordering below as index position has been used in code
        cboRequestedVia.Items.Add("Face2Face")
        cboRequestedVia.Items.Add("Phone")
        cboRequestedVia.Items.Add("Email")
        cboRequestedVia.Items.Add("Portal")

        cboCaseStatus.Items.Add("NEW")
        cboCaseStatus.Items.Add("OPEN") ' when assigned
        cboCaseStatus.Items.Add("HOLD")
        cboCaseStatus.Items.Add("CLOSED")
        cboCaseStatus.Items.Add("TERMINATED")

        fetchFlatOwner()

        PopulateGrid()

    End Sub
    Sub loadSampleCaseDesc()
        Dim tmpRS As ADODB.Recordset
        cboSampleCaseDesc.Items.Clear()
        If AddOrEdit = "A" Then
            tmpRS = gcon.Execute("select distinct CaseDesc as sample from tblservicerequest ")
        ElseIf AddOrEdit = "E" Then
            tmpRS = gcon.Execute("select distinct ClosureComment as sample from tblservicerequest ")
        Else
            tmpRS = gcon.Execute("select distinct CaseDesc as sample from tblservicerequest ")
        End If
        While tmpRS.EOF = False
            cboSampleCaseDesc.Items.Add(tmpRS("sample").Value.ToString)
            tmpRS.MoveNext()
        End While
        tmpRS.Close()

    End Sub
    Sub loadAssignedTo()
        Dim tmpRS As ADODB.Recordset

        cboAssignedTo.Items.Clear()
        cboAssignedTo.Items.Add("Not Assigned")
        tmpRS = gcon.Execute("select * from tblserviceteam where Status ='A' and TeamName='" & cboCaseType.Text & "'")
        While tmpRS.EOF = False
            cboAssignedTo.Items.Add(tmpRS("TMName").Value.ToString)
            tmpRS.MoveNext()
        End While
        tmpRS.Close()
    End Sub
    Private Sub cboCaseType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCaseType.SelectedValueChanged
        loadAssignedTo()
        txtCaseNo.Text = getNewCaseNumber()
    End Sub

    Sub setControlState(forThis As String)

        Select Case forThis
            Case "ADD"
                txtCaseDesc.Text = ""
                txtCaseDesc.Enabled = True

                txtCaseNo.Text = ""

                txtClosureComment.Text = ""
                txtClosureComment.Enabled = False

                txtCompleteDate.Text = ""

                txtLogDate.Text = Now.ToString(SCREEN_DATETIMEFORMAT)

                txtLogTimePosition.Text = ""

                txtPresentPosition.Text = ""

                txtRequestedBy.Text = lblOwner.Text
                txtRequestedBy.Enabled = True

                cboAssignedTo.SelectedIndex = -1
                cboAssignedTo.Enabled = True

                cboCaseStatus.Items.Clear()
                cboCaseStatus.Items.Add("NEW")
                cboCaseStatus.Items.Add("OPEN")
                cboCaseStatus.Text = "NEW"

                cboCaseStatus.Enabled = True

                cboCaseType.SelectedIndex = 0
                cboCaseType.Enabled = True

                cboRequestedVia.SelectedIndex = 0
                cboRequestedVia.Enabled = True

                cboSampleCaseDesc.SelectedIndex = -1
                cboSampleCaseDesc.Enabled = True

                btnAdd.Enabled = False
                btnSave.Enabled = True
                btnCancel.Enabled = True
                btnCopyToCaseDesc.Enabled = True

                AddOrEdit = "A"

            Case "EDIT"
                txtCaseDesc.Enabled = True

                txtClosureComment.Enabled = True

                txtRequestedBy.Enabled = False

                cboAssignedTo.Enabled = True

                cboCaseStatus.Enabled = True

                cboCaseType.Enabled = False

                cboRequestedVia.Enabled = False

                cboSampleCaseDesc.SelectedIndex = -1
                cboSampleCaseDesc.Enabled = True

                btnAdd.Enabled = False
                btnSave.Enabled = True
                btnCancel.Enabled = True
                btnCopyToCaseDesc.Enabled = True

                AddOrEdit = "E"

            Case "VIEW"
                txtCaseDesc.Enabled = False

                txtClosureComment.Enabled = False

                txtRequestedBy.Enabled = False

                cboAssignedTo.Enabled = False

                cboCaseStatus.Enabled = False

                cboCaseType.Enabled = False

                cboRequestedVia.Enabled = False

                cboSampleCaseDesc.SelectedIndex = -1
                cboSampleCaseDesc.Enabled = False

                btnAdd.Enabled = True
                btnSave.Enabled = False
                btnCancel.Enabled = False
                btnCopyToCaseDesc.Enabled = False

                AddOrEdit = ""

            Case "CLEAR-N-DISABLE"
                txtCaseDesc.Text = ""
                txtCaseDesc.Enabled = False

                txtCaseNo.Text = ""

                txtClosureComment.Text = ""
                txtClosureComment.Enabled = False

                txtCompleteDate.Text = ""

                txtLogDate.Text = ""

                txtLogTimePosition.Text = ""

                txtPresentPosition.Text = ""

                txtRequestedBy.Text = ""
                txtRequestedBy.Enabled = False

                cboAssignedTo.SelectedIndex = -1
                cboAssignedTo.Enabled = False

                cboCaseStatus.Enabled = False
                cboCaseStatus.SelectedIndex = -1

                cboCaseType.SelectedIndex = -1
                cboCaseType.Enabled = False

                cboRequestedVia.SelectedIndex = -1
                cboRequestedVia.Enabled = False

                cboSampleCaseDesc.SelectedIndex = -1
                cboSampleCaseDesc.Enabled = False

                btnAdd.Enabled = True
                btnSave.Enabled = False
                btnCancel.Enabled = False
                btnSMS.Enabled = False
                btnCopyToCaseDesc.Enabled = False

                AddOrEdit = ""


            Case Else

        End Select
        chkNoSMS.Checked = False

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        setControlState("ADD")
        txtCaseNo.Text = getNewCaseNumber()
        txtLogTimePosition.Text = getLogTimePosition()
        loadSampleCaseDesc()
    End Sub

    Function getNewCaseNumber() As String
        getNewCaseNumber = ""
        If cboCaseType.Text = "" Then Exit Function

        Dim tmpRS As ADODB.Recordset, maxTblid As String, maxCaseNumber As String
        tmpRS = gcon.Execute("select max(tblid) as maxTblid from tblservicerequest where CaseType='" & cboCaseType.Text & "'")
        maxTblid = tmpRS("maxTblid").Value.ToString
        tmpRS.Close()

        If maxTblid = "" And cboCaseType.Text <> "" Then
            getNewCaseNumber = myLeft(cboCaseType.Text, 1) & "1"
            Exit Function
        End If

        tmpRS = gcon.Execute("select CaseNo from tblservicerequest where tblid=" & maxTblid)
        maxCaseNumber = tmpRS("CaseNo").Value.ToString
        tmpRS.Close()

        maxCaseNumber = myRight(maxCaseNumber, Len(maxCaseNumber) - 1)

        getNewCaseNumber = myLeft(cboCaseType.Text, 1) & maxCaseNumber + 1

    End Function

    Function getLogTimePosition() As String
        Dim tmpRS As ADODB.Recordset
        tmpRS = gcon.Execute("select (count(*) + 1) as cnt from tblservicerequest where CaseType='" & cboCaseType.Text & "' and (Status='NEW' or Status='OPEN')")
        getLogTimePosition = tmpRS("cnt").Value.ToString
        tmpRS.Close()

    End Function
    Function getPresentPosition() As String
        Dim tmpRS As ADODB.Recordset, tmpsql As String

        tmpsql = "select (count(*) + 1) as cnt from tblservicerequest where CaseType='" & cboCaseType.Text & "' and (Status='NEW' or Status='OPEN') and substr(CaseNo,2) < " & myRight(txtCaseNo.Text, Len(txtCaseNo.Text) - 1)
        tmpRS = gcon.Execute(tmpsql)
        getPresentPosition = tmpRS("cnt").Value.ToString
        tmpRS.Close()

    End Function

    Private Sub dgvCase_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCase.CellContentDoubleClick
        On Error GoTo errH

        Dim ri As Integer, ci As Integer, tmpSql As String = ""


        ri = dgvCase.CurrentCell.RowIndex
        ci = dgvCase.CurrentCell.ColumnIndex
        'gCurTblID = dgvCase.Rows(ri).Cells(0).Value 'tblid

        PopulateBlock(dgvCase.Rows(ri).Cells(0).Value)
        loadSampleCaseDesc()

        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub

    Sub sendCaseUpdateViaSMS()
        Dim mySMS As New clsSendSMS
        mySMS.msgID = txtCaseNo.Text & "-" & cboCaseStatus.Text
        If mySMS.sendSMS4Case(txtCaseNo.Text) = True Then MsgBox("SMS sent successfully")
    End Sub

    Private Sub btnSMS_Click(sender As Object, e As EventArgs) Handles btnSMS.Click
        sendCaseUpdateViaSMS()
    End Sub

    Private Sub btnCopyToCaseDesc_Click(sender As Object, e As EventArgs) Handles btnCopyToCaseDesc.Click
        If AddOrEdit = "A" Then
            txtCaseDesc.Text = cboSampleCaseDesc.Text
        ElseIf AddOrEdit = "E" Then
            txtClosureComment.Text = cboSampleCaseDesc.Text
        End If
    End Sub


    Private Sub cboAssignedTo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAssignedTo.SelectedValueChanged
        If cboAssignedTo.SelectedIndex > 0 And (cboCaseStatus.Text = "NEW" Or cboCaseStatus.Text = "") Then cboCaseStatus.Text = "OPEN"
        If cboAssignedTo.SelectedIndex = 0 And (cboCaseStatus.Text = "OPEN" Or cboCaseStatus.Text = "") Then cboCaseStatus.Text = "NEW"
    End Sub

    Private Sub cboCaseType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCaseType.SelectedIndexChanged

    End Sub

    Private Sub dgvCase_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCase.CellContentClick

    End Sub
End Class