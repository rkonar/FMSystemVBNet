Public Class frmCOA
    Dim lastSelectedNode As TreeNode
    Dim OperCode As String
    Dim curAccountID As String, curAccountNo As String, reportSql As String

    Private Sub frmCOA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadCOA()
        'If gLoginID <> "sa" Then
        'tsmiShowAccountReport.Enabled = False
        'tsmiAddAccount.Enabled = False
        'tsmiEditAccount.Enabled = False
        'tsmiTrialBalance.Enabled = False
        'End If
    End Sub

    Sub loadCOA()
        On Error GoTo errH

        Dim thisNode As TreeNode, thisAccountNo As String, tmpNode As TreeNode

        'Load Account Type Combo Box
        tmpRS = gcon.Execute("select distinct AccountType from tblaccounts")
        If tmpRS.EOF = True Then
            MsgBox("Account table corrupted. Contact System Administrator.")
            Exit Sub
        End If
        While tmpRS.EOF = False
            cboAccountType.Items.Add(tmpRS("AccountType").Value.ToString)
            tmpRS.MoveNext()
        End While

        tvCOA.Nodes.Clear()
        'Load The COA Tree
        tvCOA.BeginUpdate()

        'Load the Root Node
        tmpRS = gcon.Execute("select * from tblaccounts where  ParentAccountNo is null")
        If tmpRS.EOF = True Then
            MsgBox("Account table corrupted. Contact System Administrator.")
            Exit Sub
        End If

        thisNode = tvCOA.Nodes.Add(tmpRS("AccountNo").Value.ToString)
        thisNode.ToolTipText = tmpRS("AccountNo").Value.ToString
        thisNode.Tag = tmpRS("tblid").Value.ToString & "|" & tmpRS("AccountNo").Value.ToString & "|" & tmpRS("AccountName").Value.ToString & "|" & tmpRS("ParentAccountNo").Value.ToString & "|" & tmpRS("AccountType").Value.ToString & "|" & tmpRS("Status").Value.ToString & "|" & tmpRS("CreditOrDebit").Value.ToString & "|" & tmpRS("LeafAccount").Value.ToString & "|"
        thisAccountNo = tmpRS("AccountNo").Value.ToString
        tmpRS.Close()

        'Load all child nodes
        loadAccountNode(thisNode, thisAccountNo)

        tvCOA.EndUpdate()

        tvCOA.Nodes(0).Expand()
        For Each tmpNode In tvCOA.Nodes(0).Nodes
            tmpNode.Expand()
        Next

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Sub loadAccountNode(ByRef curTreeNode As TreeNode, ByRef curAccountNo As String)
        Dim curRS As ADODB.Recordset
        Dim thisNode As TreeNode, thisAccountNo As String

        curRS = gcon.Execute("select * from tblaccounts where  ParentAccountNo='" & curAccountNo & "' order by AccountNo")
        If curRS.EOF = True Then Exit Sub

        While curRS.EOF = False

            thisNode = curTreeNode.Nodes.Add(curRS("AccountNo").Value.ToString)
            thisNode.ToolTipText = curRS("AccountNo").Value.ToString
            thisNode.Tag = curRS("tblid").Value.ToString & "|" & curRS("AccountNo").Value.ToString & "|" & curRS("AccountName").Value.ToString & "|" & curRS("ParentAccountNo").Value.ToString & "|" & curRS("AccountType").Value.ToString & "|" & curRS("Status").Value.ToString & "|" & curRS("CreditOrDebit").Value.ToString & "|" & curRS("LeafAccount").Value.ToString & "|"
            thisAccountNo = curRS("AccountNo").Value.ToString

            thisNode.ForeColor = Color.Black
            If curRS("CreditOrDebit").Value.ToString = "C" Then
                thisNode.ForeColor = Color.Blue
            ElseIf curRS("CreditOrDebit").Value.ToString = "D" Then
                thisNode.ForeColor = Color.Green
            End If

            thisNode.BackColor = Color.White
            If curRS("Status").Value.ToString = "I" Then
                thisNode.BackColor = Color.Gray
            End If

            thisNode.NodeFont = New Font(tvCOA.Font, FontStyle.Regular)
            If curRS("LeafAccount").Value.ToString = "Y" Then
                thisNode.NodeFont = New Font(tvCOA.Font, FontStyle.Bold)
            Else
                loadAccountNode(thisNode, thisAccountNo)
            End If


            curRS.MoveNext()
        End While
        curRS.Close()
    End Sub

    Sub getAllChildAccounts(ByRef parNode As TreeNode)
        Dim chdNode As TreeNode

        'Updated to include non leaf nodes also - 10Aug14
        ''if node is leaf node then include it in the account list
        'If parNode.Nodes.Count = 0 Then
        gChildActStr = gChildActStr & ",'" & parNode.ToolTipText & "'"
        'End If

        For Each chdNode In parNode.Nodes

            getAllChildAccounts(chdNode)

        Next

    End Sub

    Sub PopulateBalance(curNode As TreeNode, includeChilds As Boolean)
        Dim actRS1 As ADODB.Recordset, childNode As TreeNode, tmpSQL As String

        gChildActStr = "'" & curNode.ToolTipText & "'" '"''"
        getAllChildAccounts(curNode)
        tmpSQL = "select sum(DrAmount - CrAmount) as netamt from tbljournal where Status is null and AccountNo in (" & gChildActStr & ") and TxnDate <='" & DateTime.Parse(dtpDate.Value).ToString(DB_DATEFORMAT) & "'"
        actRS1 = gcon.Execute(tmpSQL)
        curNode.Text = curNode.ToolTipText & "(" & addThousandSeparator(actRS1("netamt").Value.ToString, True) & ")"
        actRS1.Close()
        If includeChilds = True Then
            For Each childNode In curNode.Nodes
                PopulateBalance(childNode, True)
            Next
        End If
    End Sub

    Private Sub tvCOA_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvCOA.NodeMouseClick
        'If e.Node.Text = tvCOA.Nodes(0).Text Then Exit Sub
        tvCOA.SelectedNode = e.Node
        lastSelectedNode = e.Node
        PopulateAccountFields(e.Node.Tag)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            coaContextMenu.Show()
            coaContextMenu.Left = Cursor.Position.X
            coaContextMenu.Top = Cursor.Position.Y
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then

        End If

    End Sub

    Sub PopulateAccountFields(delimitedData As String)
        Dim startPos As Integer, delPos As Integer

        startPos = 1
        delPos = InStr(startPos, delimitedData, "|")
        curAccountID = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        txtAccountNo.Text = delimitedData.Substring(startPos - 1, delPos - startPos)
        curAccountNo = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        txtAccountName.Text = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        txtParentAccountNo.Text = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        cboAccountType.Text = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        optActive.Checked = True
        If delimitedData.Substring(startPos - 1, delPos - startPos) = "I" Then optInactive.Checked = True

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        If delimitedData.Substring(startPos - 1, delPos - startPos) = "C" Then
            optCredit.Checked = True
        ElseIf delimitedData.Substring(startPos - 1, delPos - startPos) = "D" Then
            optDebit.Checked = True
        Else
            optCredit.Checked = False
            optDebit.Checked = False
        End If
        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        chkLeafAccount.Checked = False
        If delimitedData.Substring(startPos - 1, delPos - startPos) = "Y" Then chkLeafAccount.Checked = True

    End Sub

    Private Sub tsmiAddAccount_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAddAccount.Click
        'PopulateAccountFields(tvCOA.SelectedNode.Tag)

        OperCode = "ADD"

        If chkLeafAccount.Checked = True Then
            MsgBox("New account can't be created under a leaf account")
            Exit Sub
        End If

        tvCOA.Enabled = False

        txtParentAccountNo.Text = txtAccountNo.Text
        txtAccountName.Text = ""
        txtAccountNo.Text = ""

        txtAccountName.ReadOnly = False
        txtAccountNo.ReadOnly = False

        optActive.Enabled = True
        optInactive.Enabled = True
        chkLeafAccount.Enabled = True

    End Sub

    Private Sub Cancel_Click(sender As System.Object, e As System.EventArgs) Handles Cancel.Click
        txtAccountName.ReadOnly = True
        txtAccountNo.ReadOnly = True

        optActive.Enabled = False
        optInactive.Enabled = False
        chkLeafAccount.Enabled = False

        tvCOA.Enabled = True
        PopulateAccountFields(lastSelectedNode.Tag)
        tvCOA.SelectedNode = lastSelectedNode
        tvCOA.Select()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo errH
        gcon.BeginTrans()
        If OperCode = "ADD" Then
            ssql = "Insert into tblaccounts (AccountNo,AccountName,ParentAccountNo,AccountType,CreditOrDebit,Status,LeafAccount) values ( "
            ssql = ssql & "'" & txtAccountNo.Text & "','" & txtAccountName.Text & "','" & txtParentAccountNo.Text & "','" & cboAccountType.Text & "',"
            If optCredit.Checked = True Then
                ssql = ssql & "'C',"
            ElseIf optDebit.Checked = True Then
                ssql = ssql & "'D',"
            End If
            If optActive.Checked = True Then
                ssql = ssql & "'A',"
            ElseIf optInactive.Checked = True Then
                ssql = ssql & "'I',"
            End If
            If chkLeafAccount.Checked = True Then
                ssql = ssql & "'Y')"
            Else
                ssql = ssql & "'N')"
            End If

            gcon.Execute(ssql)

            MsgBox("Account addition successful")
        ElseIf OperCode = "EDIT" Then


            If Trim(txtAccountNo.Text) <> Trim(curAccountNo) Then
                gcon.Execute("update tblaccounts set ParentAccountNo='" & txtAccountNo.Text & "' where ParentAccountNo='" & curAccountNo & "'")
                gcon.Execute("update tbljournal set AccountNo='" & txtAccountNo.Text & "' where AccountNo='" & curAccountNo & "'")
                gcon.Execute("update tbljournal_cult set AccountNo='" & txtAccountNo.Text & "' where AccountNo='" & curAccountNo & "'")
            End If

            ssql = "Update tblaccounts set "
            ssql = ssql & "AccountNo='" & txtAccountNo.Text & "'"
            ssql = ssql & ",AccountName='" & txtAccountName.Text & "'"
            'If optCredit.Checked = True Then
            '    ssql = ssql & "CreditOrDebit='C',"
            'ElseIf optDebit.Checked = True Then
            '    ssql = ssql & "CreditOrDebit='D',"
            'End If
            If optActive.Checked = True Then
                ssql = ssql & ",Status='A'"
            ElseIf optInactive.Checked = True Then
                ssql = ssql & ",Status='I'"
            End If
            If chkLeafAccount.Checked = True Then
                ssql = ssql & ",LeafAccount='Y'"
            Else
                ssql = ssql & ",LeafAccount='N'"
            End If

            ssql = ssql & " where tblid=" & curAccountID

            gcon.Execute(ssql)


            MsgBox("Account update successful")
        End If
        gcon.CommitTrans()

        Call loadCOA()


        txtAccountName.ReadOnly = True
        txtAccountNo.ReadOnly = True

        optActive.Enabled = False
        optInactive.Enabled = False
        chkLeafAccount.Enabled = False

        tvCOA.Enabled = True
        'PopulateAccountFields(lastSelectedNode.Tag)
        'tvCOA.SelectedNode = lastSelectedNode
        tvCOA.Select()

        Exit Sub
errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)

    End Sub

    Private Sub tsmiEditAccount_Click(sender As System.Object, e As System.EventArgs) Handles tsmiEditAccount.Click
        OperCode = "EDIT"

        'If chkLeafAccount.Checked = True Then
        '    MsgBox("New account can't be created under a leaf account")
        '    Exit Sub
        'End If

        tvCOA.Enabled = False

        'txtParentAccountNo.Text = txtAccountNo.Text
        'txtAccountName.Text = ""
        'txtAccountNo.Text = ""

        txtAccountName.ReadOnly = False
        txtAccountNo.ReadOnly = False

        optActive.Enabled = True
        optInactive.Enabled = True
        chkLeafAccount.Enabled = True
    End Sub

    Private Sub tsmiShowBalance_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowBalance.Click
        PopulateBalance(tvCOA.SelectedNode, False)
    End Sub

    Private Sub tsmiShowAllBalances_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAllBalances.Click
        tvCOA.BeginUpdate()
        PopulateBalance(tvCOA.SelectedNode, True)
        tvCOA.EndUpdate()
    End Sub

    '    Private Sub tsmiShowSummaryReport_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAccountReport.Click
    '        On Error GoTo errH

    '        dlgReportPeriod.ShowDialog()
    '        dlgReportPeriod.Dispose()
    '        If dtpFromDateSelected = "" Then Exit Sub


    '        Dim actRS1 As ADODB.Recordset, r As Long, NetDrAmt As Double, NetCrAmt As Double

    '        xlApp = New Microsoft.Office.Interop.Excel.Application
    '        templateWrkBook = xlApp.Workbooks.Open(getSysParamValue("PATH_ACCOUNT_SUMMARY_REPORT"), False, True)
    '        templateSht = templateWrkBook.Sheets("ActSumRep")



    '        gChildActStr = "''"
    '        getAllChildAccounts(tvCOA.SelectedNode)
    '        ssql = "select * from tbljournal where Status is null and AccountNo in (" & gChildActStr & ")"
    '        ssql = ssql & " and TxnDate >=" & dtpFromDateSelected
    '        ssql = ssql & " and TxnDate <=" & dtpToDateSelected
    '        ssql = ssql & " order by AccountNo, TxnDate"
    '        actRS1 = gcon.Execute(ssql)

    '        r = 2
    '        NetDrAmt = 0
    '        NetCrAmt = 0
    '        While actRS1.EOF = False
    '            r = r + 1
    '            templateSht.Cells(r, "B").value = actRS1("AccountNo").Value.ToString
    '            templateSht.Cells(r, "C").value = formatInt2Date(actRS1("TxnDate").Value.ToString)
    '            templateSht.Cells(r, "D").value = actRS1("Narration").Value.ToString
    '            templateSht.Cells(r, "E").value = actRS1("DocRef").Value.ToString
    '            templateSht.Cells(r, "F").value = actRS1("DrAmount").Value.ToString
    '            templateSht.Cells(r, "G").value = actRS1("CrAmount").Value.ToString

    '            NetDrAmt = NetDrAmt + actRS1("DrAmount").Value.ToString
    '            NetCrAmt = NetCrAmt + actRS1("CrAmount").Value.ToString

    '            actRS1.MoveNext()
    '        End While
    '        r = r + 1
    '        templateSht.Cells(r, "E").value = "Total"
    '        templateSht.Cells(r, "F").value = NetDrAmt
    '        templateSht.Cells(r, "G").value = NetCrAmt

    '        r = r + 1
    '        templateSht.Cells(r, "E").value = "NET"
    '        If NetDrAmt > NetCrAmt Then
    '            templateSht.Cells(r, "F").value = NetDrAmt - NetCrAmt
    '        ElseIf NetDrAmt < NetCrAmt Then
    '            templateSht.Cells(r, "G").value = NetCrAmt - NetDrAmt
    '        Else
    '            templateSht.Cells(r, "F").value = 0
    '            templateSht.Cells(r, "G").value = 0
    '        End If

    '        actRS1.Close()

    '        'templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, getSysParamValue("PATH_TEMP") & gUserID & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)

    '        xlApp.Visible = True

    '        'templateWrkBook.Close(False)
    '        'xlApp.Quit()

    '        releaseObject(xlApp)
    '        releaseObject(templateWrkBook)
    '        releaseObject(templateSht)
    '        Exit Sub
    'errH:
    '        On Error Resume Next
    '        frmMain.sslabel3.Text = Err.Description
    '        If Err.Description <> "" Then MsgBox(Err.Description)
    '        xlApp.Quit()
    '        releaseObject(xlApp)
    '        releaseObject(templateWrkBook)
    '        releaseObject(templateSht)
    '    End Sub


    Sub GenReport_TrialBalance()
        On Error GoTo errH

        Dim actRS1 As ADODB.Recordset, r As Long, NetDrAmt As Double, NetCrAmt As Double, subNetDrAmt As Double, subNetCrAmt As Double, curAcctNo As String, prevAcctNo As String
        Dim printSummary As Boolean


        gChildActStr = "''"
        getAllChildAccounts(tvCOA.SelectedNode)
        actRS1 = gcon.Execute("select * from tbljournal where Status is null and AccountNo in (" & gChildActStr & ") order by AccountNo, TxnDate")

        '-----------------
        xlApp = New Microsoft.Office.Interop.Excel.Application
        templateWrkBook = xlApp.Workbooks.Open(getSysParamValue("PATH_ACCOUNT_SUMMARY_REPORT"), False, True)
        templateSht = templateWrkBook.Sheets("ActSumRep")
        'xlApp.Visible = True
        '-----------------
        r = 2
        NetDrAmt = 0
        NetCrAmt = 0
        subNetDrAmt = 0
        subNetCrAmt = 0
        prevAcctNo = ""

        While actRS1.EOF = False

            curAcctNo = actRS1("AccountNo").Value.ToString

            r = r + 1
            templateSht.Cells(r, "B").value = actRS1("AccountNo").Value.ToString
            templateSht.Cells(r, "C").value = formatInt2Date(actRS1("TxnDate").Value.ToString)
            templateSht.Cells(r, "D").value = actRS1("Narration").Value.ToString
            templateSht.Cells(r, "E").value = actRS1("DocRef").Value.ToString
            templateSht.Cells(r, "F").value = actRS1("DrAmount").Value.ToString
            templateSht.Cells(r, "G").value = actRS1("CrAmount").Value.ToString
            '------------------------------------------------------------------------------
            subNetCrAmt = subNetCrAmt + actRS1("CrAmount").Value.ToString
            subNetDrAmt = subNetDrAmt + actRS1("DrAmount").Value.ToString

            NetDrAmt = NetDrAmt + actRS1("DrAmount").Value.ToString
            NetCrAmt = NetCrAmt + actRS1("CrAmount").Value.ToString
            '------------------------------------------------------------------------------
            actRS1.MoveNext()

            If actRS1.EOF = True Then
                printSummary = True
            ElseIf curAcctNo <> actRS1("AccountNo").Value.ToString Then 'Last record or new account start
                printSummary = True
            Else
                printSummary = False
            End If

            If printSummary = True Then
                r = r + 1
                templateSht.Cells(r, "E").value = "Total - " & curAcctNo
                templateSht.Cells(r, "F").value = subNetDrAmt
                templateSht.Cells(r, "G").value = subNetCrAmt

                r = r + 1
                templateSht.Cells(r, "E").value = "NET - " & curAcctNo
                If subNetDrAmt > subNetCrAmt Then
                    templateSht.Cells(r, "F").value = subNetDrAmt - subNetCrAmt
                ElseIf subNetDrAmt < subNetCrAmt Then
                    templateSht.Cells(r, "G").value = subNetCrAmt - subNetDrAmt
                Else
                    templateSht.Cells(r, "F").value = 0
                    templateSht.Cells(r, "G").value = 0
                End If
                subNetDrAmt = 0
                subNetCrAmt = 0
                DrawBorder(templateSht, "B" & (r - 1) & ":G" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)
            End If

            '------------------------------------------------------------------------------

        End While

        r = r + 1
        templateSht.Cells(r, "E").value = "Total"
        templateSht.Cells(r, "F").value = NetDrAmt
        templateSht.Cells(r, "G").value = NetCrAmt

        r = r + 1
        templateSht.Cells(r, "E").value = "NET"
        If NetDrAmt > NetCrAmt Then
            templateSht.Cells(r, "F").value = NetDrAmt - NetCrAmt
        ElseIf NetDrAmt < NetCrAmt Then
            templateSht.Cells(r, "G").value = NetCrAmt - NetDrAmt
        Else
            templateSht.Cells(r, "F").value = 0
            templateSht.Cells(r, "G").value = 0
        End If

        DrawBorder(templateSht, "B" & (r - 1) & ":G" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)

        actRS1.Close()

        'templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, getSysParamValue("PATH_TEMP") & gUserID & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)
        'Autofit columns
        templateSht.Columns("B:G").EntireColumn.AutoFit()
        xlApp.Visible = True

        'templateWrkBook.Close(False)
        'xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)
        Exit Sub
errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
        If xlApp IsNot Nothing Then xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)
    End Sub

    Private Sub tsmiTrialBalance_Click(sender As System.Object, e As System.EventArgs) Handles tsmiTrialBalance.Click
        GenReport_TrialBalance()
    End Sub


    Private Sub tsmiShowAccountReport_AsOf_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAccountReport_AsOf.Click
        gChildActStr = "''"
        getAllChildAccounts(tvCOA.SelectedNode)

        dlgDtpDialog.ShowDialog()
        dlgDtpDialog.Dispose()
        If dtpDateSelected = "" Then Exit Sub

        dtpToDateSelected = dtpDateSelected

        If Month(DateTime.Now) < 4 Then
            dtpFromDateSelected = "01-Apr-" & Year(DateTime.Now) - 1
        Else
            dtpFromDateSelected = "01-Apr-" & Year(DateTime.Now)
        End If

        reportSql = "select * from tbljournal where Status is null and AccountNo in (" & gChildActStr & ")"
        reportSql = reportSql & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        reportSql = reportSql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        reportSql = reportSql & " order by AccountNo, TxnDate"

        genAccountReport()
    End Sub

    Private Sub tsmiShowAccountReport_Between_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAccountReport_Between.Click
        dlgReportPeriod.ShowDialog()
        dlgReportPeriod.Dispose()
        If dtpFromDateSelected = "" Then Exit Sub

        gChildActStr = "''"
        getAllChildAccounts(tvCOA.SelectedNode)

        reportSql = "select * from tbljournal where Status is null and AccountNo in (" & gChildActStr & ")"
        reportSql = reportSql & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        reportSql = reportSql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        reportSql = reportSql & " order by AccountNo, TxnDate"
        genAccountReport()

    End Sub

    Private Sub tsmiShowAccountReport_YTD_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAccountReport_YTD.Click
        gChildActStr = "''"
        getAllChildAccounts(tvCOA.SelectedNode)

        If Month(DateTime.Now) < 4 Then
            dtpFromDateSelected = "01-Apr-" & Year(DateTime.Now) - 1
        Else
            dtpFromDateSelected = "01-Apr-" & Year(DateTime.Now)
        End If

        dtpToDateSelected = DateTime.Now.ToString

        reportSql = "select * from tbljournal where Status is null and AccountNo in (" & gChildActStr & ")"
        reportSql = reportSql & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        reportSql = reportSql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        reportSql = reportSql & " order by AccountNo, TxnDate"
        genAccountReport()

    End Sub

    Private Sub tsmiShowAccountReport_TillDate_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAccountReport_TillDate.Click
        gChildActStr = "''"
        getAllChildAccounts(tvCOA.SelectedNode)

        dtpFromDateSelected = "01-Apr-2011"
        dtpToDateSelected = DateTime.Now.ToString

        reportSql = "select * from tbljournal where Status is null and AccountNo in (" & gChildActStr & ")"
        reportSql = reportSql & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        reportSql = reportSql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        reportSql = reportSql & " order by AccountNo, TxnDate"
        genAccountReport()

    End Sub



    Sub genAccountReport()
        On Error GoTo errH

        Dim actRS1 As ADODB.Recordset, r As Long, NetDrAmt As Double, NetCrAmt As Double, subNetDrAmt As Double, subNetCrAmt As Double, curAcctNo As String, prevAcctNo As String
        Dim printSummary As Boolean

        actRS1 = gcon.Execute(reportSql)

        '-----------------
        xlApp = New Microsoft.Office.Interop.Excel.Application
        templateWrkBook = xlApp.Workbooks.Add
        'templateWrkBook = xlApp.Workbooks.Open(getSysParamValue("PATH_ACCOUNT_SUMMARY_REPORT"), False, True)
        templateSht = templateWrkBook.Sheets(1)
        'xlApp.Visible = True
        '-----------------
        r = 2
        templateSht.Range("D" & r & ":H" & r).Select()
        With xlApp.Selection
            .mergecells = True
            .Font.Bold = True
            .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            .WrapText = False
        End With
        templateSht.Cells(r, "D").value = "From Date :" & dtpFromDateSelected & " To Date : " & dtpToDateSelected & " Account : " & tvCOA.SelectedNode.Text
        '-----------------
        r = 3
        templateSht.Cells(r, "B").value = "AccountNo"
        templateSht.Cells(r, "C").value = "TxnDate"
        templateSht.Cells(r, "D").value = "Narration"
        templateSht.Cells(r, "E").value = "DocRef"
        templateSht.Cells(r, "F").value = "DrAmount"
        templateSht.Cells(r, "G").value = "CrAmount"
        templateSht.Cells(r, "H").value = "Balance (Dr - Cr)"
        DrawBorder(templateSht, "B" & r & ":H" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)

        templateSht.Columns("A:A").Select()
        xlApp.Selection.ColumnWidth = 1

        '-----------------
        r = 4
        NetDrAmt = 0
        NetCrAmt = 0
        subNetDrAmt = 0
        subNetCrAmt = 0
        prevAcctNo = ""
        printSummary = True

        While actRS1.EOF = False

            curAcctNo = actRS1("AccountNo").Value.ToString

            r = r + 1
            If printSummary = True Then
                printSummary = False
                templateSht.Cells(r, "B").value = actRS1("AccountNo").Value.ToString
            End If
            templateSht.Cells(r, "C").value = formatInt2Date(actRS1("TxnDate").Value.ToString)
            templateSht.Cells(r, "D").value = actRS1("Narration").Value.ToString
            templateSht.Cells(r, "E").value = actRS1("DocRef").Value.ToString
            templateSht.Cells(r, "F").value = actRS1("DrAmount").Value.ToString
            templateSht.Cells(r, "G").value = actRS1("CrAmount").Value.ToString

            '------------------------------------------------------------------------------
            subNetCrAmt = subNetCrAmt + actRS1("CrAmount").Value.ToString
            subNetDrAmt = subNetDrAmt + actRS1("DrAmount").Value.ToString

            NetDrAmt = NetDrAmt + actRS1("DrAmount").Value.ToString
            NetCrAmt = NetCrAmt + actRS1("CrAmount").Value.ToString
            '------------------------------------------------------------------------------
            templateSht.Cells(r, "H").value = subNetDrAmt - subNetCrAmt
            '------------------------------------------------------------------------------
            actRS1.MoveNext()

            If actRS1.EOF = True Then
                printSummary = True
            ElseIf curAcctNo <> actRS1("AccountNo").Value.ToString Then 'Last record or new account start
                printSummary = True
            Else
                printSummary = False
            End If

            If printSummary = True Then
                r = r + 1
                templateSht.Cells(r, "E").value = "Net - " & curAcctNo
                templateSht.Cells(r, "F").value = subNetDrAmt
                templateSht.Cells(r, "G").value = subNetCrAmt
                templateSht.Cells(r, "H").value = subNetDrAmt - subNetCrAmt

                'r = r + 1
                'templateSht.Cells(r, "E").value = "NET - " & curAcctNo
                'If subNetDrAmt > subNetCrAmt Then
                '    templateSht.Cells(r, "F").value = subNetDrAmt - subNetCrAmt
                'ElseIf subNetDrAmt < subNetCrAmt Then
                '    templateSht.Cells(r, "G").value = subNetCrAmt - subNetDrAmt
                'Else
                '    templateSht.Cells(r, "F").value = 0
                '    templateSht.Cells(r, "G").value = 0
                'End If
                subNetDrAmt = 0
                subNetCrAmt = 0
                DrawBorder(templateSht, "B" & r & ":H" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)
            End If

            '------------------------------------------------------------------------------

        End While

        r = r + 1
        templateSht.Cells(r, "E").value = "NET"
        templateSht.Cells(r, "F").value = NetDrAmt
        templateSht.Cells(r, "G").value = NetCrAmt
        templateSht.Cells(r, "H").value = NetDrAmt - NetCrAmt

        'r = r + 1
        'templateSht.Cells(r, "E").value = "NET"
        'If NetDrAmt > NetCrAmt Then
        '    templateSht.Cells(r, "F").value = NetDrAmt - NetCrAmt
        'ElseIf NetDrAmt < NetCrAmt Then
        '    templateSht.Cells(r, "G").value = NetCrAmt - NetDrAmt
        'Else
        '    templateSht.Cells(r, "F").value = 0
        '    templateSht.Cells(r, "G").value = 0
        'End If

        DrawBorder(templateSht, "B" & r & ":H" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)

        actRS1.Close()

        'templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, getSysParamValue("PATH_TEMP") & gUserID & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)
        'Autofit columns
        templateSht.Columns("B:H").EntireColumn.AutoFit()
        'xlApp.DisplayGridlines = False
        xlApp.Visible = True

        'templateWrkBook.Close(False)
        'xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)
        Exit Sub
errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
        If xlApp IsNot Nothing Then xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)
    End Sub

    Private Sub tvCOA_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvCOA.AfterSelect

    End Sub
End Class

