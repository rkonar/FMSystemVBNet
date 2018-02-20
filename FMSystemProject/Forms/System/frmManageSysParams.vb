Public Class frmManageSysParams

    Dim thisObject As New clsSysParam, mAction As String = "", mCurGridRow As Long = -1
    Dim mFormLoaded As Boolean = False, mValueChangedByCode As Boolean = False

    Private Sub frmManageSysParams_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        releaseObject(Me)
    End Sub

    Private Sub frmManageSysParams_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set ComponentCode
        'With gComponent
        gOldItemCode = gItemCode
        gItemCode = "SystemParameters"
        'End With

        btnRefresh.PerformClick()


        mFormLoaded = True
    End Sub



    Sub lockUnlockPanel(ByVal lockunlock As String)
        Dim theVal As Boolean

        If lockunlock = "L" Then
            theVal = True
        Else
            theVal = False
        End If

        'cboFrom.Enabled = Not (theVal)
        'cboTo.Enabled = Not (theVal)
        'cboStatus.Enabled = Not (theVal)
        'cboPriority.Enabled = Not (theVal)

        'txtMessage.ReadOnly = theVal
        'txtResponse.ReadOnly = theVal

        dgv.Enabled = theVal

    End Sub

    Sub setButtonState(toState As String)
        Select Case (toState)

            Case "REFRESH"
                btnQuery.Enabled = True
                btnAddRow.Enabled = True
                btnClone.Enabled = True And (dgv.Rows.Count > 0)
                btnUpdate.Enabled = True And (dgv.Rows.Count > 0)
                btnDelete.Enabled = True And (dgv.Rows.Count > 0)
                btnSave.Enabled = False
                btnUndo.Enabled = False
                btnExportToExcel.Enabled = True And (dgv.Rows.Count > 0)
                btnShowGraph.Enabled = True And (dgv.Rows.Count > 0)

            Case "UNDO"

            Case "QUERY"
                btnQuery.Enabled = False
                btnAddRow.Enabled = True
                btnClone.Enabled = False
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
                btnSave.Enabled = False
                btnUndo.Enabled = False
                btnExportToExcel.Enabled = True And (dgv.Rows.Count > 0)
                btnShowGraph.Enabled = True And (dgv.Rows.Count > 0)

            Case "ADD"
                btnQuery.Enabled = False
                btnAddRow.Enabled = False
                btnClone.Enabled = False
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
                btnSave.Enabled = True
                btnUndo.Enabled = False
                btnExportToExcel.Enabled = True And (dgv.Rows.Count > 0)
                btnShowGraph.Enabled = True And (dgv.Rows.Count > 0)

            Case "CLONE"
                btnAddRow.Enabled = False
                btnClone.Enabled = False
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
                btnSave.Enabled = True
                btnUndo.Enabled = False
                btnExportToExcel.Enabled = True And (dgv.Rows.Count > 0)
                btnShowGraph.Enabled = True And (dgv.Rows.Count > 0)

            Case "UPDATE"
                btnAddRow.Enabled = False
                btnClone.Enabled = False
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
                btnSave.Enabled = True
                btnUndo.Enabled = True
                btnExportToExcel.Enabled = True And (dgv.Rows.Count > 0)
                btnShowGraph.Enabled = True And (dgv.Rows.Count > 0)

            Case "DELETE"
                btnAddRow.Enabled = False
                btnClone.Enabled = False
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
                btnSave.Enabled = True
                btnUndo.Enabled = False
                btnExportToExcel.Enabled = True And (dgv.Rows.Count > 0)
                btnShowGraph.Enabled = True And (dgv.Rows.Count > 0)

            Case "SAVE"
                btnAddRow.Enabled = True
                btnClone.Enabled = True And (dgv.Rows.Count > 0)
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
                btnUndo.Enabled = False
                btnExportToExcel.Enabled = True And (dgv.Rows.Count > 0)
                btnShowGraph.Enabled = True And (dgv.Rows.Count > 0)

            Case Else



        End Select

    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        'clearPanel()
        lockUnlockPanel("U")
        setButtonState("QUERY")
        mAction = "QUERY"

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        populateGrid()
        'selectGridRow(dgv, "mboxTblid", curtblid)
        setButtonState("REFRESH")
        mAction = "REFRESH"
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        Dim i As Long = 0
        'clearPanel()
        'lockUnlockPanel("U")
        setButtonState("ADD")
        mAction = "ADD"
        mValueChangedByCode = True

        With dgv
            i = .Rows.Add
            .Rows(i).Cells("sysOptypeflag").Value = "A"
            .Rows(i).Cells("sysEncrypted").Value = "N"
            .Rows(i).DefaultCellStyle.BackColor = Color.Cyan



            .Rows(i).Selected = True

            If i > 0 Then

                .Rows(i).Cells(4).Selected = True 'this set the current row

            End If

        End With

        mValueChangedByCode = False

        'mCurGridRow = i
        'cboFrom.Text = gLoggedUser.LoginID
        'cboStatus.Text = "OPEN"
        'lblStartDT.Text = DateTime.Parse(Now).ToString(SCREEN_DATETIMEFORMAT)
        'lblEndDT.Text = ""

        'cboFrom.Enabled = False
        'cboStatus.Enabled = False

        'txtResponse.ReadOnly = True

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim i As Long = 0
        i = dgv.CurrentRow.Index
        If i < 0 Then Exit Sub

        'lockUnlockPanel("U")
        setButtonState("UPDATE")
        mAction = "UPDATE"

        With dgv
            .Rows(i).Cells("sysOptypeflag").Value = "U"
            .Rows(i).DefaultCellStyle.BackColor = Color.Gold
            .Rows(i).ReadOnly = False
            .Rows(i).Selected = True

        End With
        mCurGridRow = i

        'cboFrom.Enabled = False
        'cboTo.Enabled = False
        'cboPriority.Enabled = False

        'If gLoggedUser.LoginID = lblCB.Text Then
        '    txtMessage.ReadOnly = False
        'Else
        '    txtMessage.ReadOnly = True
        'End If

    End Sub

    Private Sub btnClone_Click(sender As Object, e As EventArgs) Handles btnClone.Click
        lockUnlockPanel("U")
        setButtonState("CLONE")
        mAction = "ADD"

        'txtResponse.Text = ""

        'cboFrom.Text = gLoggedUser.LoginID
        'cboStatus.Text = "OPEN"
        'lblStartDT.Text = DateTime.Parse(Now).ToString(SCREEN_DATETIMEFORMAT)
        'lblEndDT.Text = ""

        'cboFrom.Enabled = False
        'cboStatus.Enabled = False

        'txtResponse.ReadOnly = True

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        setButtonState("DELETE")

        Dim i As Long = 0
        i = dgv.CurrentRow.Index
        If i < 0 Then Exit Sub

        'lockUnlockPanel("U")
        setButtonState("DELETE")
        mAction = "DELETE"

        With dgv
            .Rows(i).Cells("sysOptypeflag").Value = "D"
            .Rows(i).DefaultCellStyle.BackColor = Color.Red
            .Rows(i).ReadOnly = True
            .Rows(i).Selected = True
        End With
        'mCurGridRow = i

    End Sub

    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        'populatePanel()
    End Sub

    Sub loadCurrentRow(ByVal rowindx As Long)

        If rowindx < 0 Then Exit Sub

        With thisObject
            .tblid = dgv.Rows(rowindx).Cells("sysTblid").Value

            .paramname = dgv.Rows(rowindx).Cells("sysParamname").Value
            .paramvalue = dgv.Rows(rowindx).Cells("sysParamvalue").Value
            .encrypted = dgv.Rows(rowindx).Cells("sysEncrypted").Value
            .remarks = dgv.Rows(rowindx).Cells("sysRemarks").Value
        End With
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim rowAction As String = ""

        For i = 0 To dgv.Rows.Count - 1
            rowAction = dgv.Rows(i).Cells("sysOptypeflag").Value

            Select rowAction
                Case "Q"

                Case "A"
                    loadCurrentRow(i)
                    If validateSave() = False Then Exit Sub
                    thisObject.createSysParam()
                    If thisObject.Status = True Then MsgBox("Successful!")
                Case "U"
                    loadCurrentRow(i)
                    If validateSave() = False Then Exit Sub
                    thisObject.updateSysParam()
                    If thisObject.Status = True Then MsgBox("Successful!")

                Case "D"
                    loadCurrentRow(i)
                    If validateSave() = False Then Exit Sub
                    'thisObject.deleteSysParam()
                    'If thisObject.Status = True Then MsgBox("Successful!")

            End Select
        Next
        btnRefresh.PerformClick()
        setButtonState("SAVE")

        loadSysParams()

    End Sub

    Function validateSave() As Boolean
        On Error GoTo errH
        validateSave = False

        Dim i As Long = 0
        i = dgv.CurrentRow.Index
        If i < 0 Then Exit Function

        With thisObject
            If .paramname = "" Then
                MsgBox("Param Name is missing")
                Exit Function
            End If
            If .paramvalue = "" Then
                MsgBox("Param Value is missing")
                Exit Function
            End If


        End With
        'If validateControlForNotEmpty(txtMessage, "Message missing") = False Then Exit Function
        'If validateControlForNotEmpty(cboPriority, "Priority missing") = False Then Exit Function
        'If validateControlForNotEmpty(cboStatus, "Status missing") = False Then Exit Function

        validateSave = True
        Exit Function
errH:
        gErrDesc = Err.Description
        If gErrDesc <> "" Then MsgBox(gErrDesc)
    End Function

    '    Sub populatePanel()

    '        On Error GoTo errH

    '        'clearPanel()


    '        With thisObject
    '            'txtMessage.Text = .messagetext
    '            'txtResponse.Text = .messageresponse

    '            'cboFrom.Text = .messagefrom
    '            'cboTo.Text = .messageto

    '            'cboPriority.Text = .messagepriority
    '            'cboStatus.Text = .messagestatus

    '            'lblStartDT.Text = .startdt
    '            'lblEndDT.Text = .enddt


    '            lblCB.Text = .cb
    '            lblCDT.Text = .cdt
    '            lblLUB.Text = .lub
    '            lblLUDT.Text = .ludt
    '        End With

    '        Exit Sub

    'errH:
    '        gErrDesc = Err.Description
    '        If gErrDesc <> "" Then MsgBox(gErrDesc)
    '    End Sub

    Sub populateGrid()

        On Error GoTo errH
        Dim i As Long, rsData As ADODB.Recordset, QuerySQL As String

        'lblGridCount.Text = ""
        mValueChangedByCode = True
        'mGridCount = -1
        dgv.Rows.Clear()

        QuerySQL = "select * from tblsysparams where rowstatus is null "


        If mAction = "QUERY" Then

            'If cboFrom.Text <> "" Then QuerySQL = QuerySQL & " and messagefrom ='" & cboFrom.Text & "' "
            'If cboTo.Text <> "" Then QuerySQL = QuerySQL & " and messageto ='" & cboTo.Text & "' "
            'If cboPriority.Text <> "" Then QuerySQL = QuerySQL & " and messagepriority ='" & cboPriority.Text & "' "
            'If cboStatus.Text <> "" Then QuerySQL = QuerySQL & " and messagestatus='" & cboStatus.Text & "' "

            'If txtMessage.Text <> "" Then QuerySQL = QuerySQL & " and messagetext like '%" & Replace(txtMessage.Text, "'", "''") & "%' "
            'If txtResponse.Text <> "" Then QuerySQL = QuerySQL & " and messageresponse like '%" & Replace(txtResponse.Text, "'", "''") & "%' "


        End If


        QuerySQL = QuerySQL & " order by paramname asc"

        rsData = getQueryRecordset(QuerySQL)
        mFormLoaded = False
        With dgv
            .Rows.Clear()
            While rsData.EOF = False

                'mGridCount = mGridCount + 1

                i = .Rows.Add()

                .Rows(i).Cells("sysTblid").Value = rsData("tblid").Value.ToString
                .Rows(i).Cells("sysParamname").Value = rsData("paramname").Value.ToString
                .Rows(i).Cells("sysParamvalue").Value = rsData("paramvalue").Value.ToString
                .Rows(i).Cells("sysEncrypted").Value = rsData("encrypted").Value.ToString
                .Rows(i).Cells("sysRemarks").Value = rsData("remarks").Value.ToString

                .Rows(i).Cells("sysOptypeflag").Value = "Q"

                .Rows(i).Cells("sysRowstatus").Value = rsData("rowstatus").Value.ToString
                .Rows(i).Cells("sysCb").Value = rsData("cb").Value.ToString
                .Rows(i).Cells("sysCdt").Value = formatInt2DateTime(rsData("cdt").Value.ToString)
                .Rows(i).Cells("sysLub").Value = rsData("lub").Value.ToString
                .Rows(i).Cells("sysLudt").Value = formatInt2DateTime(rsData("ludt").Value.ToString)

                .Rows(i).ReadOnly = True

                rsData.MoveNext()

            End While

        End With
        mFormLoaded = True
        mValueChangedByCode = False

        rsData.Close()
        releaseObject(rsData)

        'lblGridCount.Text = dgv.Rows.Count

        Exit Sub

errH:
        gErrDesc = Err.Description
        If gErrDesc <> "" Then MsgBox(gErrDesc)
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        Dim ri As Long
        ri = dgv.CurrentRow.Index
        If ri < 0 Then Exit Sub

        'doGridRowClick(dgv, ri)
    End Sub


    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Dim ri As Long
        ri = dgv.CurrentRow.Index
        If ri < 0 Then Exit Sub
        'btnUpdate.PerformClick()
    End Sub


    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        ExportGridToExcelSheet(dgv, False)
    End Sub


    Private Sub btnShowGraph_Click(sender As Object, e As EventArgs) Handles btnShowGraph.Click
        'Dim tmpsql As String
        'ReDim gGraph(2)
        'tmpsql = " select f.XVal,f.YVal from ("
        'tmpsql = tmpsql & " select messagefrom as XVal,sum(messagepriority) as YVal from tblleaves where rowstatus is null"
        'If dtpFromDateSelected <> "" Then tmpsql = tmpsql & " and startdt >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        'If dtpToDateSelected <> "" Then tmpsql = tmpsql & " and enddt <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        'tmpsql = tmpsql & " group by messagefrom"
        'tmpsql = tmpsql & " ) as f order by f.YVal"
        'With gGraph(0)
        '    .sql = tmpsql
        '    .chartType = DataVisualization.Charting.SeriesChartType.Bar
        '    .chartName = "Team Member wise Leaves"
        '    .YTitle = "Leave Count (messagepriority)"
        '    .XTitle = "Team Member"
        '    .seriesName = "Leaves"
        '    .seriesColor = Color.Red
        'End With

        'tmpsql = " select f.XVal,f.YVal from ("
        'tmpsql = tmpsql & " select messagestatus as XVal,sum(messagepriority) as YVal from tblleaves where rowstatus is null"
        'If dtpFromDateSelected <> "" Then tmpsql = tmpsql & " and startdt >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        'If dtpToDateSelected <> "" Then tmpsql = tmpsql & " and enddt <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        'tmpsql = tmpsql & " group by messagestatus"
        'tmpsql = tmpsql & " ) as f order by f.YVal"
        'With gGraph(1)
        '    .sql = tmpsql
        '    .chartType = DataVisualization.Charting.SeriesChartType.Bar
        '    .chartName = "Type wise Leaves"
        '    .YTitle = "Leave Count (messagepriority)"
        '    .XTitle = "Leave Types"
        '    .seriesName = "Leaves Types"
        '    .seriesColor = Color.Blue
        'End With

        'tmpsql = " select f.XVal,f.YVal from ("
        'tmpsql = tmpsql & " select mid(startdt,1,6) as XVal,sum(messagepriority) as YVal from tblleaves where rowstatus is null"
        'If dtpFromDateSelected <> "" Then tmpsql = tmpsql & " and startdt >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        'If dtpToDateSelected <> "" Then tmpsql = tmpsql & " and enddt <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        'tmpsql = tmpsql & " group by mid(startdt,1,6)"
        'tmpsql = tmpsql & " ) as f order by f.YVal"
        'With gGraph(2)
        '    .sql = tmpsql
        '    .chartType = DataVisualization.Charting.SeriesChartType.Bar
        '    .chartName = "Month wise Leaves"
        '    .YTitle = "Leave Count (messagepriority)"
        '    .XTitle = "Months"
        '    .seriesName = "Leaves Months"
        '    .seriesColor = Color.Brown
        'End With

        'frmShowGraph.ShowDialog()
        'frmShowGraph.Dispose()
    End Sub



    Private Sub dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        'If mValueChangedByCode = False Then calculateCloseValues()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmGeneratePassword.ShowDialog()
        frmGeneratePassword.Dispose()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class