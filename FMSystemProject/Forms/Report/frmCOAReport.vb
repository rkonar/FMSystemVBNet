Public Class frmCOAReport
    Dim lastSelectedNode As TreeNode
    Dim OperCode As String
    Dim curAccountID As String, curAccountNo As String, reportSql As String, reportSqlOB As String, lSortCol As String, lSortColVal As String
    Dim lQuickBalanceLevel As Integer = 3

    Private Sub frmCOAReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        With cboOrderBy
            .Items.Add("Date")
            .Items.Add("Amount")
            .Items.Add("Account")
            .SelectedIndex = 0
        End With

        With cboDirection
            .Items.Add("Ascending")
            .Items.Add("Descending")
            .SelectedIndex = 0
        End With

        handleMenuText()

        loadCOA()

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
        Dim netBal As Double, thisBal As String, journalTblName As String = ""

        gChildActStr = "'" & curNode.ToolTipText & "'" '"''"
        getAllChildAccounts(curNode)
        netBal = 0

        If InStr(curNode.ToolTipText, "-CULT") > 0 Or InStr(curNode.ToolTipText, "EXPCULTCUR") > 0 Then
            journalTblName = "tbljournal_cult"
        Else
            journalTblName = "tbljournal"
        End If

        'print opening balance before selected period - added 26Jul14
        tmpSQL = "select sum(DrAmount - CrAmount) as netamt from " & journalTblName & " where Status is null and AccountNo in (" & gChildActStr & ") "
        'tmpSQL = tmpSQL & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        tmpSQL = tmpSQL & " and TxnDate <'" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        actRS1 = gcon.Execute(tmpSQL)
        thisBal = IIf(DBNull.Value.Equals(actRS1.Fields(0).Value), 0, actRS1.Fields(0).Value.ToString)
        netBal = netBal + CDbl(thisBal)
        curNode.Text = curNode.ToolTipText & "[OpBal " & DateTime.Parse(dtpFromDateSelected).ToString("ddMMMyy") & ": Rs. " & addThousandSeparator(thisBal, False) & "]"
        actRS1.Close()

        'print selected period's value
        tmpSQL = "select sum(DrAmount - CrAmount) as netamt from " & journalTblName & " where Status is null and AccountNo in (" & gChildActStr & ") "
        tmpSQL = tmpSQL & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        tmpSQL = tmpSQL & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        actRS1 = gcon.Execute(tmpSQL)
        thisBal = IIf(DBNull.Value.Equals(actRS1.Fields(0).Value), 0, actRS1.Fields(0).Value.ToString)
        netBal = netBal + CDbl(thisBal)
        curNode.Text = curNode.Text & "[CurPeriodBal: Rs. " & addThousandSeparator(thisBal, False) & "]"
        actRS1.Close()

        'print Net balance - added 26Jul14
        curNode.Text = curNode.Text & "[NetBal " & DateTime.Parse(dtpToDateSelected).ToString("ddMMMyy") & ": Rs. " & addThousandSeparator(netBal, False) & "]"

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


    Private Sub tsmiShowBalance_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowBalance.Click
        '    PopulateBalance(tvCOA.SelectedNode, False)
    End Sub

    Private Sub tsmiShowAllBalances_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAllBalances.Click
        'tvCOA.BeginUpdate()
        'PopulateBalance(tvCOA.SelectedNode, True)
        'tvCOA.EndUpdate()
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
       
        dlgDtpDialog.ShowDialog()
        dlgDtpDialog.Dispose()
        If dtpDateSelected = "" Then Exit Sub

        dtpToDateSelected = dtpDateSelected
        dtpFromDateSelected = "01-Apr-2011"

        'If Month(DateTime.Now) < 4 Then
        '    dtpFromDateSelected = "01-Apr-" & Year(dtpToDateSelected) - 1
        'Else
        '    dtpFromDateSelected = "01-Apr-" & Year(dtpToDateSelected)
        'End If

        ShowBalanceOrGenReport
    End Sub

    Private Sub tsmiShowAccountReport_Between_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAccountReport_Between.Click
        dlgReportPeriod.ShowDialog()
        dlgReportPeriod.Dispose()
        If dtpFromDateSelected = "" Then Exit Sub

        ShowBalanceOrGenReport()

    End Sub

    Private Sub tsmiShowAccountReport_YTD_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAccountReport_YTD.Click

        If Month(DateTime.Now) < 4 Then
            dtpFromDateSelected = "01-Apr-" & Year(DateTime.Now) - 1
        Else
            dtpFromDateSelected = "01-Apr-" & Year(DateTime.Now)
        End If

        dtpToDateSelected = DateTime.Now.ToString

        ShowBalanceOrGenReport
    End Sub

    Private Sub tsmiShowAccountReport_TillDate_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAccountReport_TillDate.Click

        dtpFromDateSelected = "01-Apr-2011"
        dtpToDateSelected = DateTime.Now.ToString

        ShowBalanceOrGenReport
    End Sub

    Function getOrderbyStr() As String
        getOrderbyStr = " Order by "
        Select Case cboOrderBy.Text
            Case "Date"
                If cboDirection.Text = "Ascending" Then
                    getOrderbyStr = getOrderbyStr & " TxnDate Asc,AccountNo Asc"
                Else
                    getOrderbyStr = getOrderbyStr & " TxnDate Desc,AccountNo Asc"
                End If
            Case "Amount"
                If cboDirection.Text = "Ascending" Then
                    getOrderbyStr = getOrderbyStr & " DrAmount Asc,CrAmount Asc,AccountNo Asc"
                Else
                    getOrderbyStr = getOrderbyStr & " DrAmount Desc,CrAmount Desc,AccountNo Asc"
                End If
            Case "Account"
                If cboDirection.Text = "Ascending" Then
                    getOrderbyStr = getOrderbyStr & " AccountNo Asc,TxnDate Asc"
                Else
                    getOrderbyStr = getOrderbyStr & " AccountNo Desc,TxnDate Asc"
                End If
        End Select
    End Function


    Sub genAccountReport()
        On Error GoTo errH

        Dim actRS1 As ADODB.Recordset, actRSOB As ADODB.Recordset, r As Long, NetDrAmt As Double, NetCrAmt As Double, subNetDrAmt As Double, subNetCrAmt As Double, curAcctNo As String, prevAcctNo As String
        Dim isSummaryLine As Boolean, includeSummary As Boolean, onlySummary As Boolean, tmpSortColVal As String = ""

        includeSummary = chkSummaryLine.Checked
        onlySummary = chkOnlySummary.Checked

        actRS1 = gcon.Execute(reportSql)

        '-----------------
        xlApp = New Microsoft.Office.Interop.Excel.Application
        templateWrkBook = xlApp.Workbooks.Add
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
        If onlySummary = False Then
            r = r + 1
            templateSht.Cells(r, "B").value = "AccountNo"
            templateSht.Cells(r, "C").value = "Txn Date"
            templateSht.Cells(r, "D").value = "Txn Type"
            templateSht.Cells(r, "E").value = "Narration"
            templateSht.Cells(r, "F").value = "DocRef"
            templateSht.Cells(r, "G").value = "Dr Amount"
            templateSht.Cells(r, "H").value = "Cr Amount"
            templateSht.Cells(r, "I").value = "Balance (Dr - Cr)"
            DrawBorder(templateSht, "B" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, False, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)

            'templateSht.Columns("A:A").Select()
            'xlApp.Selection.ColumnWidth = 1
        End If


        '==========================================================================================================================
        If chkIncludeOpBal.Checked = True Then
            'print opening balance
            ssql = "select sum(DrAmount) as netDrAmt, sum(CrAmount) as netCrAmt from tbljournal where Status is null and AccountNo in (" & gChildActStr & ")"
            ssql = ssql & " and TxnDate < '" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
            actRSOB = gcon.Execute(ssql)

            NetDrAmt = adjDouble(actRSOB("netDrAmt").Value.ToString)
            NetCrAmt = adjDouble(actRSOB("netCrAmt").Value.ToString)
            actRSOB.Close()

            r = r + 2

            templateSht.Cells(r, "F").value = "Opening Balance"
            templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt

        Else

            r = r + 1
            NetDrAmt = 0
            NetCrAmt = 0
            subNetDrAmt = 0
            subNetCrAmt = 0
            
        End If
        '==========================================================================================================================

        subNetDrAmt = NetDrAmt
        subNetCrAmt = NetCrAmt
        prevAcctNo = ""
        'isSummaryLine = True
        

        While actRS1.EOF = False

            curAcctNo = actRS1("AccountNo").Value.ToString

            If lSortCol = "TxnDate" Then
                lSortColVal = formatInt2Date(actRS1(lSortCol).Value.ToString)
                lSortColVal = DateTime.Parse(lSortColVal).ToString("MMM-yyyy")
            ElseIf lSortCol = "Amount" Then
                lSortColVal = actRS1("DrAmount").Value.ToString + actRS1("CrAmount").Value.ToString
            Else
                lSortColVal = actRS1(lSortCol).Value.ToString
            End If

            '------------------------------------------------------------------------------
            subNetCrAmt = subNetCrAmt + actRS1("CrAmount").Value.ToString
            subNetDrAmt = subNetDrAmt + actRS1("DrAmount").Value.ToString

            NetDrAmt = NetDrAmt + actRS1("DrAmount").Value.ToString
            NetCrAmt = NetCrAmt + actRS1("CrAmount").Value.ToString
            '------------------------------------------------------------------------------


            If onlySummary = False Then
                r = r + 1
                'If isSummaryLine = True Then
                isSummaryLine = False
                templateSht.Cells(r, "B").value = actRS1("AccountNo").Value.ToString
                'End If
                templateSht.Cells(r, "C").value = formatInt2Date(actRS1("TxnDate").Value.ToString)
                templateSht.Cells(r, "D").value = actRS1("TxnType").Value.ToString
                templateSht.Cells(r, "E").value = actRS1("Narration").Value.ToString
                templateSht.Cells(r, "F").value = actRS1("DocRef").Value.ToString
                templateSht.Cells(r, "G").value = actRS1("DrAmount").Value.ToString
                templateSht.Cells(r, "H").value = actRS1("CrAmount").Value.ToString

                templateSht.Cells(r, "I").value = subNetDrAmt - subNetCrAmt
            End If

            actRS1.MoveNext()


            If includeSummary = True Then

                If actRS1.EOF = True Then
                    isSummaryLine = True
                    'ElseIf curAcctNo <> actRS1("AccountNo").Value.ToString Then 'Last record or new account start
                Else
                    If lSortCol = "TxnDate" Then
                        tmpSortColVal = formatInt2Date(actRS1(lSortCol).Value.ToString)
                        tmpSortColVal = DateTime.Parse(tmpSortColVal).ToString("MMM-yyyy")
                    ElseIf lSortCol = "Amount" Then
                        lSortColVal = actRS1("DrAmount").Value.ToString + actRS1("CrAmount").Value.ToString
                    Else
                        tmpSortColVal = actRS1(lSortCol).Value.ToString
                    End If

                    If lSortColVal <> tmpSortColVal Then 'Last record or new account start
                        isSummaryLine = True
                    Else
                        isSummaryLine = False
                    End If
                End If

                If isSummaryLine = True Then
                    r = r + 1
                    'templateSht.Cells(r, "F").value = "Net - " & curAcctNo
                    templateSht.Cells(r, "F").value = "Net - " & lSortColVal
                    templateSht.Cells(r, "G").value = subNetDrAmt
                    templateSht.Cells(r, "H").value = subNetCrAmt
                    templateSht.Cells(r, "I").value = subNetDrAmt - subNetCrAmt

                    subNetDrAmt = 0
                    subNetCrAmt = 0
                    DrawBorder(templateSht, "B" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, True)
                End If

            End If
            '------------------------------------------------------------------------------

        End While

        r = r + 1
        templateSht.Cells(r, "F").value = "Final Closing Balance"
        templateSht.Cells(r, "G").value = NetDrAmt
        templateSht.Cells(r, "H").value = NetCrAmt
        templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt

        DrawBorder(templateSht, "B" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, True)

        actRS1.Close()



        DrawBorder(templateSht, "B" & "5" & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline, False, False, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)
        'Set Font 
        templateSht.Cells.Select()
        With xlApp.Selection.Font
            .Name = "Arial Narrow"
            .Size = 8
            .Strikethrough = False
            .Superscript = False
            .Subscript = False
            .OutlineFont = False
            .Shadow = False
            .Underline = -4142 ' xlUnderlineStyleNone
            '.ThemeColor = xlThemeColorLight1
            .TintAndShade = 0
            '.ThemeFont = xlThemeFontNone
        End With
        templateSht.Range("A1").Select()


        'Autofit columns
        templateSht.Columns("B:I").EntireColumn.AutoFit()
        templateSht.Cells.Select()
        xlApp.Selection.Rows.AutoFit()
        xlApp.Selection.VerticalAlignment = -4108 'xlCenter
        'xlApp.Selection.WrapText = True

        'set column width : total 73
        templateSht.Columns("A:A").Select()
        xlApp.Selection.ColumnWidth = 0.1

        'templateSht.Columns("B:B").Select()
        'xlApp.Selection.ColumnWidth = 15
        'xlApp.Selection.WrapText = True

        templateSht.Columns("D:D").Select()
        xlApp.Selection.ColumnWidth = 7
        xlApp.Selection.WrapText = True

        templateSht.Columns("E:E").Select()
        xlApp.Selection.ColumnWidth = 30
        xlApp.Selection.WrapText = True

        templateSht.Columns("F:F").Select()
        xlApp.Selection.ColumnWidth = 30
        xlApp.Selection.WrapText = True

        'templateSht.Columns("G:G").Select()
        'xlApp.Selection.ColumnWidth = 7
        'xlApp.Selection.WrapText = True

        'templateSht.Columns("H:H").Select()
        'xlApp.Selection.ColumnWidth = 7
        'xlApp.Selection.WrapText = True

        'templateSht.Columns("I:I").Select()
        'xlApp.Selection.ColumnWidth = 8
        'xlApp.Selection.WrapText = True


        'templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, getSysParamValue("PATH_TEMP") & gUserID & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)
        templateSht.Columns("G:G").NumberFormat = "#,##0.00"
        templateSht.Columns("H:H").NumberFormat = "#,##0.00"
        templateSht.Columns("I:I").NumberFormat = "#,##0.00"

        With templateSht.PageSetup
            .PrintTitleRows = "$3:$3"
            .LeftHeader = ""
            .CenterHeader = ""
            .RightHeader = ""
            .LeftFooter = ""
            .CenterFooter = ""
            .RightFooter = ""
            .LeftMargin = 0 'Application.InchesToPoints(0.708661417322835)
            .RightMargin = 0 'Application.InchesToPoints(0.708661417322835)
            .TopMargin = 0 ' Application.InchesToPoints(0.748031496062992)
            .BottomMargin = 0 ' Application.InchesToPoints(0.748031496062992)
            '.HeaderMargin = Application.InchesToPoints(0.31496062992126)
            '.FooterMargin = Application.InchesToPoints(0.31496062992126)
            .PrintHeadings = False
            .PrintGridlines = False
            '.PrintComments = xlPrintNoComments
            '.PrintQuality = -3
            '.CenterHorizontally = True
            '.CenterVertically = True
            '.Orientation = 1 ' xlPortrait
            .Draft = False
            '.PaperSize = 9 ' xlPaperA4
            '.FirstPageNumber = xlAutomatic
            '.Order = xlDownThenOver
            .BlackAndWhite = False
            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = 10000
            '.PrintErrors = xlPrintErrorsDisplayed
            .OddAndEvenPagesHeaderFooter = False
            .DifferentFirstPageHeaderFooter = False
            .ScaleWithDocHeaderFooter = True
            .AlignMarginsHeaderFooter = True
            .EvenPage.LeftHeader.Text = ""
            .EvenPage.CenterHeader.Text = ""
            .EvenPage.RightHeader.Text = ""
            .EvenPage.LeftFooter.Text = ""
            .EvenPage.CenterFooter.Text = ""
            .EvenPage.RightFooter.Text = ""
            .FirstPage.LeftHeader.Text = ""
            .FirstPage.CenterHeader.Text = ""
            .FirstPage.RightHeader.Text = ""
            .FirstPage.LeftFooter.Text = ""
            .FirstPage.CenterFooter.Text = ""
            .FirstPage.RightFooter.Text = ""
        End With

        'print header (shud be placed at last as cells are merged with affects single col selection)
        r = 2
        templateSht.Range("B" & r & ":I" & r).Select()
        With xlApp.Selection
            .mergecells = True
            .Font.Bold = True
            .Font.Name = "Arial Narrow"
            .Font.Size = 8
            .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            .WrapText = False
        End With
        templateSht.Cells(r, "B").value = "From Date :" & dtpFromDateSelected & "   To Date :" & dtpToDateSelected & "   Account :" & tvCOA.SelectedNode.Text
        '-----------------

        templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, getSysParamValue("PATH_TEMP") & gUserID & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)

        'On Error Resume Next
        'templateWrkBook.Close(False)
        'If xlApp IsNot Nothing Then xlApp.Quit()



        'Autofit columns
        ''templateSht.Columns("B:I").EntireColumn.AutoFit()
        'xlApp.DisplayGridlines = False
        xlApp.Visible = True

        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)
        Exit Sub
errH:
        MsgBox(Err.Description)
        'frmMain.sslabel3.Text = Err.Description
        'If Err.Description <> "" Then MsgBox(Err.Description)
        On Error Resume Next
        If xlApp IsNot Nothing Then xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)
    End Sub

    Private Sub cboOrderBy_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboOrderBy.SelectedValueChanged
        Select Case cboOrderBy.Text
            Case "Date"
                lSortCol = "TxnDate"
            Case "Amount"
                lSortCol = "Amount"
            Case "Account"
                lSortCol = "AccountNo"
        End Select
    End Sub

    Private Sub chkOnlySummary_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOnlySummary.CheckedChanged
        If chkOnlySummary.Checked = True Then chkSummaryLine.Checked = True
    End Sub

    Private Sub chkSummaryLine_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSummaryLine.CheckedChanged
        If chkOnlySummary.Checked = True Then chkSummaryLine.Checked = True
    End Sub

   

    Sub handleMenuText()
        grpReport.Enabled = chkGenReport.Checked
        chkIncludeChildAccounts.Enabled = Not chkGenReport.Checked
        chkIncludeOpBal.Enabled = chkGenReport.Checked
        'chkIncludeChildAccounts.Checked = Not chkGenReport.Checked
        If chkGenReport.Checked = True Then
            tsmiShowAccountReport.Text = "Show Report"
        Else
            If chkIncludeChildAccounts.Checked = True Then
                tsmiShowAccountReport.Text = "Show All Balances"
            Else
                tsmiShowAccountReport.Text = "Show Balance"
            End If
        End If
    End Sub

    Private Sub chkGenReport_CheckedChanged(sender As Object, e As EventArgs) Handles chkGenReport.CheckedChanged
        handleMenuText()
    End Sub

    Private Sub chkIncludeChildAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncludeChildAccounts.CheckedChanged
        handleMenuText()
    End Sub

    Private Sub Upto31Mar2013ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Upto31Mar2013ToolStripMenuItem.Click
        dtpFromDateSelected = "01-Apr-2011"
        dtpToDateSelected = "31-Mar-2013"

        ShowBalanceOrGenReport
    End Sub

    Sub ShowBalanceOrGenReport()
        Dim journalTblName As String = ""

        If chkGenReport.Checked = False Then
            tvCOA.BeginUpdate()
            If chkQuickBalance.Checked = True Then
                showQuickBalance(tvCOA.TopNode, lQuickBalanceLevel)
            Else
                PopulateBalance(tvCOA.SelectedNode, chkIncludeChildAccounts.Checked)
            End If
            tvCOA.EndUpdate()
        Else
            If InStr(tvCOA.SelectedNode.ToolTipText, "-CULT") > 0 Or InStr(tvCOA.SelectedNode.ToolTipText, "EXPCULTCUR") > 0 Then
                journalTblName = "tbljournal_cult"
            Else
                journalTblName = "tbljournal"
            End If

            gChildActStr = "''"
            getAllChildAccounts(tvCOA.SelectedNode)

            'Opening Balance SQL
            'reportSqlOB = "select * from tbljournal where Status is null and AccountNo in (" & gChildActStr & ")"
            'reportSqlOB = reportSqlOB & " and TxnDate <'" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"

            'Period Txn Sql
            reportSql = "select * from " & journalTblName & " where Status is null and AccountNo in (" & gChildActStr & ")"
            reportSql = reportSql & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
            reportSql = reportSql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
            reportSql = reportSql & getOrderbyStr()

            genAccountReport()
        End If

    End Sub

    Sub showQuickBalance(curNode As TreeNode, upToLevel As Integer)
        Dim childNode As TreeNode
        For Each childNode In curNode.Nodes
            If childNode.Level <= upToLevel Then
                PopulateBalance(childNode, False)
                showQuickBalance(childNode, upToLevel)
            Else
                Exit Sub ' all child will be at same level as first child
            End If
        Next
    End Sub

    Private Sub chkQuickBalance_CheckedChanged(sender As Object, e As EventArgs) Handles chkQuickBalance.CheckedChanged
        If chkQuickBalance.Checked = True Then chkGenReport.Checked = False
    End Sub

    Private Sub FY201314ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FY201314ToolStripMenuItem.Click
        dtpFromDateSelected = "01-Apr-2013"
        dtpToDateSelected = "31-Mar-2014"

        ShowBalanceOrGenReport()
    End Sub
End Class

