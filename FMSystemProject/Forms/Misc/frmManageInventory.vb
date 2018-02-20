Public Class frmManageInventory
    Dim lastSelectedNode As TreeNode
    Dim OperCode As String
    Dim curTblId As String, curThisCode As String, reportSql As String



    Sub loadTreeView()
        On Error GoTo errH

        Dim thisNode As TreeNode, thisNodeCode As String, tmpNode As TreeNode

        'Load Account Type Combo Box
        'tmpRS = gcon.Execute("select distinct AccountType from tblaccounts")
        'If tmpRS.EOF = True Then
        '    MsgBox("Inventory table corrupted. Contact System Administrator.")
        '    Exit Sub
        'End If
        'While tmpRS.EOF = False
        '    cboAccountType.Items.Add(tmpRS("AccountType").Value.ToString)
        '    tmpRS.MoveNext()
        'End While

        tvInventory.Nodes.Clear()
        'Load The COA Tree
        tvInventory.BeginUpdate()

        'Load the Root Node
        tmpRS = gcon.Execute("select * from tblinventory where  ParentCode is null")
        If tmpRS.EOF = True Then
            MsgBox("Inventory table corrupted. Contact System Administrator.")
            Exit Sub
        End If

        thisNode = tvInventory.Nodes.Add(tmpRS("thisCode").Value.ToString)
        thisNode.ToolTipText = tmpRS("thisCode").Value.ToString
        thisNodeCode = tmpRS("thisCode").Value.ToString

        thisNode.Tag = tmpRS("tblid").Value.ToString & "|" & tmpRS("thisCode").Value.ToString & "|" & tmpRS("thisDesc").Value.ToString & "|" & tmpRS("ParentCode").Value.ToString & "|" & tmpRS("Status").Value.ToString & "|" & tmpRS("isLeaf").Value.ToString & "|" & tmpRS("PurchaseDate").Value.ToString & "|" & tmpRS("CommissionDate").Value.ToString & "|" & tmpRS("RetireDate").Value.ToString & "|" & tmpRS("RetireReason").Value.ToString & "|" & tmpRS("IdentificationType").Value.ToString & "|" & tmpRS("IdentificationNo").Value.ToString & "|" & tmpRS("Make").Value.ToString & "|"

        tmpRS.Close()

        'Load all child nodes
        loadThisNode(thisNode, thisNodeCode)

        tvInventory.EndUpdate()

        tvInventory.Nodes(0).Expand()
        'For Each tmpNode In tvInventory.Nodes(0).Nodes
        '    tmpNode.Expand()
        'Next

        tvInventory.SelectedNode = tvInventory.Nodes(0)
        lastSelectedNode = tvInventory.Nodes(0)
        PopulateAccountFields(tvInventory.Nodes(0).Tag)


        Exit Sub

errH:
        'On Error Resume Next
        MsgBox(Err.Description)
    End Sub

    Sub loadThisNode(ByRef curTreeNode As TreeNode, ByRef curTreeNodeCode As String)
        Dim curRS As ADODB.Recordset
        Dim thisNode As TreeNode, thisNodeNo As String

        curRS = gcon.Execute("select * from tblinventory where  ParentCode='" & curTreeNodeCode & "' order by thisCode")
        If curRS.EOF = True Then Exit Sub

        While curRS.EOF = False

            thisNode = curTreeNode.Nodes.Add(curRS("thisCode").Value.ToString)
            thisNode.ToolTipText = curRS("thisCode").Value.ToString
            thisNode.Tag = curRS("tblid").Value.ToString & "|" & curRS("thisCode").Value.ToString & "|" & curRS("thisDesc").Value.ToString & "|" & curRS("ParentCode").Value.ToString & "|" & curRS("Status").Value.ToString & "|" & curRS("isLeaf").Value.ToString & "|" & curRS("PurchaseDate").Value.ToString & "|" & curRS("CommissionDate").Value.ToString & "|" & curRS("RetireDate").Value.ToString & "|" & curRS("RetireReason").Value.ToString & "|" & curRS("IdentificationType").Value.ToString & "|" & curRS("IdentificationNo").Value.ToString & "|" & curRS("Make").Value.ToString & "|"
            thisNodeNo = curRS("thisCode").Value.ToString

            thisNode.BackColor = Color.White
            If curRS("Status").Value.ToString = "I" Then
                thisNode.BackColor = Color.Gray
            End If


            thisNode.ForeColor = Color.Green
            thisNode.NodeFont = New Font(tvInventory.Font, FontStyle.Regular)
            If curRS("isLeaf").Value.ToString = "Y" Then
                thisNode.ForeColor = Color.Blue
                thisNode.NodeFont = New Font(tvInventory.Font, FontStyle.Bold)
            Else
                loadThisNode(thisNode, thisNodeNo)
            End If


            curRS.MoveNext()
        End While
        curRS.Close()
    End Sub

    Sub getAllChildAccounts(ByRef parNode As TreeNode)
        Dim chdNode As TreeNode

        'if node is leaf node then include it in the account list
        If parNode.Nodes.Count = 0 Then
            gChildActStr = gChildActStr & ",'" & parNode.ToolTipText & "'"
        End If

        For Each chdNode In parNode.Nodes

            getAllChildAccounts(chdNode)

        Next

    End Sub

    'Sub PopulateBalance(curNode As TreeNode, includeChilds As Boolean)
    '    Dim actRS1 As ADODB.Recordset, childNode As TreeNode, tmpSQL As String

    '    gChildActStr = "''"
    '    getAllChildAccounts(curNode)
    '    tmpSQL = "select sum(DrAmount - CrAmount) as netamt from tbljournal where Status is null and AccountNo in (" & gChildActStr & ") and TxnDate <='" & DateTime.Parse(dtpDate.Value).ToString(DB_DATEFORMAT) & "'"
    '    actRS1 = gcon.Execute(tmpSQL)
    '    curNode.Text = curNode.ToolTipText & "(" & addThousandSeparator(actRS1("netamt").Value.ToString, True) & ")"
    '    actRS1.Close()
    '    If includeChilds = True Then
    '        For Each childNode In curNode.Nodes
    '            PopulateBalance(childNode, True)
    '        Next
    '    End If
    'End Sub

    'thisNode.Tag = curRS("tblid").Value.ToString & "|" & curRS("thisCode").Value.ToString & "|" & curRS("thisDesc").Value.ToString & "|" & curRS("ParentCode").Value.ToString & "|" & curRS("Status").Value.ToString & "|" & curRS("isLeaf").Value.ToString & "|" & curRS("PurchaseDate").Value.ToString & "|" & curRS("CommissionDate").Value.ToString & "|" & curRS("RetireDate").Value.ToString & "|" & curRS("RetireReason").Value.ToString & "|" & curRS("RetireBy").Value.ToString & "|" & curRS("IdentificationType").Value.ToString & "|" & curRS("IdentificationNo").Value.ToString & "|" & curRS("Make").Value.ToString & "|"
    Sub PopulateAccountFields(delimitedData As String)
        Dim startPos As Integer, delPos As Integer, tmpdate As String

        startPos = 1
        delPos = InStr(startPos, delimitedData, "|")
        curTblId = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        txtThisCode.Text = delimitedData.Substring(startPos - 1, delPos - startPos)
        curThisCode = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        txtThisDesc.Text = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        txtParentCode.Text = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        optActive.Checked = True
        If delimitedData.Substring(startPos - 1, delPos - startPos) = "I" Then optInactive.Checked = True

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        chkLeafAccount.Checked = False
        If delimitedData.Substring(startPos - 1, delPos - startPos) = "Y" Then chkLeafAccount.Checked = True

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        tmpdate = delimitedData.Substring(startPos - 1, delPos - startPos)
        If tmpdate = "" Then
            dtpPurchaseDate.Checked = False
        Else
            dtpPurchaseDate.Checked = True
            dtpPurchaseDate.Text = formatInt2Date(tmpdate)
        End If


        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        tmpdate = delimitedData.Substring(startPos - 1, delPos - startPos)
        If tmpdate = "" Then
            dtpCommissionDate.Checked = False
        Else
            dtpCommissionDate.Checked = True
            dtpCommissionDate.Text = formatInt2Date(tmpdate)
        End If

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        tmpdate = delimitedData.Substring(startPos - 1, delPos - startPos)
        If tmpdate = "" Then
            dtpRetireDate.Checked = False
        Else
            dtpRetireDate.Checked = True
            dtpRetireDate.Text = formatInt2Date(tmpdate)
        End If

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        txtRetireReason.Text = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        cboIdentificationType.Text = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        txtIdentificationNo.Text = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        cboMake.Text = delimitedData.Substring(startPos - 1, delPos - startPos)

        makeEditable(False)

    End Sub



    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo errH
        gcon.BeginTrans()
        If OperCode = "ADD" Then
            ssql = "INSERT INTO tblinventory (thisCode,thisDesc,ParentCode,Status,isLeaf,PurchaseDate,CommissionDate,RetireDate,RetireReason,IdentificationType,IdentificationNo,Make) values ( "
            ssql = ssql & "'" & UCase(txtThisCode.Text) & "','" & Replace(txtThisDesc.Text, "'", "''") & "','" & txtParentCode.Text & "',"

            If optActive.Checked = True Then
                ssql = ssql & "'A',"
            ElseIf optInactive.Checked = True Then
                ssql = ssql & "'I',"
            End If
            If chkLeafAccount.Checked = True Then
                ssql = ssql & "'Y',"
                If dtpPurchaseDate.Checked = True Then
                    ssql = ssql & DateTime.Parse(dtpPurchaseDate.Text).ToString(DB_DATEFORMAT) & ","
                Else
                    ssql = ssql & "NULL" & ","
                End If
                If dtpCommissionDate.Checked = True Then
                    ssql = ssql & DateTime.Parse(dtpCommissionDate.Text).ToString(DB_DATEFORMAT) & ","
                Else
                    ssql = ssql & "NULL" & ","
                End If
                If dtpRetireDate.Checked = True Then
                    ssql = ssql & DateTime.Parse(dtpRetireDate.Text).ToString(DB_DATEFORMAT) & ","
                Else
                    ssql = ssql & "NULL" & ","
                End If

                ssql = ssql & "'" & Replace(txtRetireReason.Text, "'", "''") & "','" & cboIdentificationType.Text & "','" & Replace(txtIdentificationNo.Text, "'", "''") & "',"
                ssql = ssql & "'" & cboMake.Text & "')"
            Else
                ssql = ssql & "'N',"
                ssql = ssql & "NULL,NULL,NULL,"
                ssql = ssql & "NULL,NULL,NULL,"
                ssql = ssql & "NULL)"
            End If

            gcon.Execute(ssql)

            MsgBox("Addition successful")
        ElseIf OperCode = "EDIT" Then


            If Trim(txtThisCode.Text) <> Trim(curThisCode) Then
                gcon.Execute("update tblinventory set ParentCode='" & txtThisCode.Text & "' where ParentCode='" & curThisCode & "'")
                'gcon.Execute("update tbljournal set AccountNo='" & txtThisCode.Text & "' where AccountNo='" & curThisCode & "'")
            End If

            ssql = "Update tblinventory set "
            ssql = ssql & "thisCode='" & UCase(txtThisCode.Text) & "'"
            ssql = ssql & ",thisDesc='" & Replace(txtThisDesc.Text, "'", "''") & "'"

            If optActive.Checked = True Then
                ssql = ssql & ",Status='A'"
            ElseIf optInactive.Checked = True Then
                ssql = ssql & ",Status='I'"
            End If
            If chkLeafAccount.Checked = True Then
                ssql = ssql & ",isLeaf='Y'"
            Else
                ssql = ssql & ",isLeaf='N'"
            End If

            If dtpPurchaseDate.Checked = True Then
                ssql = ssql & ",PurchaseDate=" & DateTime.Parse(dtpPurchaseDate.Text).ToString(DB_DATEFORMAT)
            Else
                ssql = ssql & ",PurchaseDate=NULL"
            End If
            If dtpCommissionDate.Checked = True Then
                ssql = ssql & ",CommissionDate=" & DateTime.Parse(dtpCommissionDate.Text).ToString(DB_DATEFORMAT)
            Else
                ssql = ssql & ",CommissionDate=NULL"
            End If
            If dtpRetireDate.Checked = True Then
                ssql = ssql & ",RetireDate=" & DateTime.Parse(dtpRetireDate.Text).ToString(DB_DATEFORMAT)
            Else
                ssql = ssql & ",RetireDate=NULL"
            End If

            ssql = ssql & ",RetireReason='" & Replace(txtRetireReason.Text, "'", "''") & "'"
            ssql = ssql & ",IdentificationType='" & cboIdentificationType.Text & "'"

            ssql = ssql & ",IdentificationNo='" & Replace(txtIdentificationNo.Text, "'", "''") & "'"
            ssql = ssql & ",Make='" & cboMake.Text & "'"

            ssql = ssql & " where tblid=" & curTblId

            gcon.Execute(ssql)


            MsgBox("Update successful")
        End If
        gcon.CommitTrans()

        Call loadTreeView()

        makeEditable(False)

        tvInventory.Enabled = True
        tvInventory.Select()

        Exit Sub
errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)

    End Sub

    Sub makeEditable(thisVal As Boolean)
        txtThisDesc.ReadOnly = Not thisVal
        txtThisCode.ReadOnly = Not thisVal
        txtParentCode.ReadOnly = True
        txtRetireReason.ReadOnly = Not thisVal
        txtIdentificationNo.ReadOnly = Not thisVal

        cboIdentificationType.Enabled = thisVal
        cboMake.Enabled = thisVal
        optActive.Enabled = thisVal
        optInactive.Enabled = thisVal
        chkLeafAccount.Enabled = thisVal

        dtpPurchaseDate.Enabled = thisVal
        dtpCommissionDate.Enabled = thisVal
        dtpRetireDate.Enabled = thisVal

        btnSave.Enabled = thisVal
        btnCancel.Enabled = thisVal


        panelLeaf.Visible = chkLeafAccount.Checked

    End Sub


    Private Sub tsmiShowBalance_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowBalance.Click
        'PopulateBalance(tvInventory.SelectedNode, False)
    End Sub

    Private Sub tsmiShowAllBalances_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAllBalances.Click
        'tvInventory.BeginUpdate()
        'PopulateBalance(tvInventory.SelectedNode, True)
        'tvInventory.EndUpdate()
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
        getAllChildAccounts(tvInventory.SelectedNode)
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
        getAllChildAccounts(tvInventory.SelectedNode)

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
        getAllChildAccounts(tvInventory.SelectedNode)

        reportSql = "select * from tbljournal where Status is null and AccountNo in (" & gChildActStr & ")"
        reportSql = reportSql & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        reportSql = reportSql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        reportSql = reportSql & " order by AccountNo, TxnDate"
        genAccountReport()

    End Sub

    Private Sub tsmiShowAccountReport_YTD_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowAccountReport_YTD.Click
        gChildActStr = "''"
        getAllChildAccounts(tvInventory.SelectedNode)

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
        getAllChildAccounts(tvInventory.SelectedNode)

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
        templateSht.Cells(r, "D").value = "From Date :" & dtpFromDateSelected & " To Date : " & dtpToDateSelected & " Account : " & tvInventory.SelectedNode.Text
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


    Private Sub frmManageInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTreeView()
    End Sub

    

    Private Sub tvInventory_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvInventory.NodeMouseClick
        'If e.Node.Text = tvCOA.Nodes(0).Text Then Exit Sub
        tvInventory.SelectedNode = e.Node
        lastSelectedNode = e.Node
        PopulateAccountFields(e.Node.Tag)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu1.Show()
            ContextMenu1.Left = Cursor.Position.X
            ContextMenu1.Top = Cursor.Position.Y
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then

        End If
    End Sub

    
    Private Sub chkLeafAccount_CheckedChanged(sender As Object, e As EventArgs) Handles chkLeafAccount.CheckedChanged
        panelLeaf.Visible = chkLeafAccount.Checked
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtThisDesc.ReadOnly = True
        txtThisCode.ReadOnly = True

        optActive.Enabled = False
        optInactive.Enabled = False
        chkLeafAccount.Enabled = False

        tvInventory.Enabled = True
        PopulateAccountFields(lastSelectedNode.Tag)
        tvInventory.SelectedNode = lastSelectedNode
        tvInventory.Select()
    End Sub

    Private Sub tsmiAdd_Click(sender As Object, e As EventArgs) Handles tsmiAdd.Click

        OperCode = "ADD"

        If chkLeafAccount.Checked = True Then
            MsgBox("New node can't be created under a leaf node")
            Exit Sub
        End If

        tvInventory.Enabled = False

        makeEditable(True)

        txtParentCode.Text = txtThisCode.Text
        txtThisCode.Text = ""
        txtThisDesc.Text = ""


    End Sub

    Private Sub tsmiEdit_Click(sender As Object, e As EventArgs) Handles tsmiEdit.Click
        OperCode = "EDIT"
        tvInventory.Enabled = False
        makeEditable(True)
        txtParentCode.ReadOnly = False
    End Sub

    Private Sub txtThisCode_LostFocus(sender As Object, e As EventArgs) Handles txtThisCode.LostFocus
        txtThisCode.Text = UCase(txtThisCode.Text)
        If txtParentCode.Text <> "" Then
            If InStr(txtThisCode.Text, txtParentCode.Text & "-") = 0 Then
                txtThisCode.Text = txtParentCode.Text & "-" & txtThisCode.Text
            End If
        End If
    End Sub

End Class

