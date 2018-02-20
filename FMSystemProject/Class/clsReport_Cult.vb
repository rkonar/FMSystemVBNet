Public Class clsReport_Cult
    Public ReportSql As String
    Public ReportFileName As String
    Public HideBalance As Boolean
    Public AccountNo As String
    Public FromDate As String
    Public ToDate As String

    Public Status As Boolean

    Dim reportRS As ADODB.Recordset
    Dim lFinYear As New clsFinYear

    Public Sub New()
        ReportSql = ""
        ReportFileName = ""
        HideBalance = False
        AccountNo = ""
        FromDate = ""
        ToDate = ""

        Status = False
    End Sub
    '    Public Sub genEODReport()
    '        On Error GoTo errH

    '        Dim actRS1 As ADODB.Recordset, r As Long, NetDrAmt As Double, NetCrAmt As Double, subNetDrAmt As Double, subNetCrAmt As Double, curAcctNo As String, prevAcctNo As String
    '        Dim printSummary As Boolean


    '        ReportSql = "select * from tbljournal_cult where Status is null and ((AccountNo like 'CASH%') or (AccountNo like 'BANK%') or (AccountNo like 'CHEQUE%')) and TxnDate='" & DateTime.Now.ToString("yyyyMMdd") & "' order by AccountNo, DrAmount,CrAmount"

    '        actRS1 = gcon.Execute(ReportSql)

    '        '-----------------
    '        xlApp = New Microsoft.Office.Interop.Excel.Application
    '        templateWrkBook = xlApp.Workbooks.Add
    '        While templateWrkBook.Sheets.Count > 1
    '            templateSht = templateWrkBook.Sheets(1)
    '            templateSht.Delete()
    '        End While
    '        templateSht = templateWrkBook.Sheets(1)
    '        'xlApp.Visible = True
    '        '-----------------
    '        r = 2
    '        templateSht.Range("B" & r & ":F" & r).Select()
    '        With xlApp.Selection
    '            .mergecells = True
    '            .Font.Bold = True
    '            .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '            .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
    '            .WrapText = False
    '        End With
    '        templateSht.Cells(r, "B").value = "Date : " & FromDate & " Account : CASH/BANK/CHEQUE"
    '        DrawBorder(templateSht, "B" & r & ":F" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft, False)
    '        '-----------------
    '        r = 3
    '        templateSht.Cells(r, "B").value = "AccountNo"
    '        templateSht.Cells(r, "C").value = "Narration"
    '        templateSht.Cells(r, "D").value = "DocRef"
    '        templateSht.Cells(r, "E").value = "DrAmount"
    '        templateSht.Cells(r, "F").value = "CrAmount"
    '        DrawBorder(templateSht, "B" & r & ":F" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter, False)
    '        '-----------------
    '        NetDrAmt = 0
    '        NetCrAmt = 0
    '        subNetDrAmt = 0
    '        subNetCrAmt = 0
    '        prevAcctNo = ""
    '        printSummary = True

    '        While actRS1.EOF = False

    '            curAcctNo = actRS1("AccountNo").Value.ToString

    '            r = r + 1
    '            If printSummary = True Then
    '                printSummary = False
    '                templateSht.Cells(r, "B").value = actRS1("AccountNo").Value.ToString
    '            End If
    '            templateSht.Cells(r, "C").value = actRS1("Narration").Value.ToString
    '            templateSht.Cells(r, "D").value = actRS1("DocRef").Value.ToString
    '            templateSht.Cells(r, "E").value = actRS1("DrAmount").Value.ToString
    '            templateSht.Cells(r, "F").value = actRS1("CrAmount").Value.ToString

    '            '------------------------------------------------------------------------------
    '            subNetCrAmt = subNetCrAmt + actRS1("CrAmount").Value.ToString
    '            subNetDrAmt = subNetDrAmt + actRS1("DrAmount").Value.ToString

    '            NetDrAmt = NetDrAmt + actRS1("DrAmount").Value.ToString
    '            NetCrAmt = NetCrAmt + actRS1("CrAmount").Value.ToString
    '            '------------------------------------------------------------------------------
    '            actRS1.MoveNext()

    '            If actRS1.EOF = True Then
    '                printSummary = True
    '            ElseIf curAcctNo <> actRS1("AccountNo").Value.ToString Then 'Last record or new account start
    '                printSummary = True
    '            Else
    '                printSummary = False
    '            End If

    '            If printSummary = True Then
    '                r = r + 1
    '                templateSht.Cells(r, "D").value = "Net - " & curAcctNo
    '                templateSht.Cells(r, "E").value = subNetDrAmt
    '                templateSht.Cells(r, "F").value = subNetCrAmt
    '                templateSht.Cells(r, "G").value = subNetDrAmt - subNetCrAmt


    '                subNetDrAmt = 0
    '                subNetCrAmt = 0
    '                DrawBorder(templateSht, "B" & r & ":G" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)
    '            End If

    '            '------------------------------------------------------------------------------

    '        End While

    '        r = r + 1
    '        templateSht.Cells(r, "D").value = "NET"
    '        templateSht.Cells(r, "E").value = NetDrAmt
    '        templateSht.Cells(r, "F").value = NetCrAmt
    '        templateSht.Cells(r, "G").value = NetDrAmt - NetCrAmt

    '        DrawBorder(templateSht, "B" & r & ":G" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)

    '        actRS1.Close()

    '        'templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, getSysParamValue("PATH_TEMP") & gUserID & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)
    '        'Autofit columns
    '        templateSht.Columns("A:H").EntireColumn.AutoFit()
    '        'xlApp.Visible = True

    '        ReportFileName = getSysParamValue("PATH_TEMP") & "DailyReport-" & DateTime.Now.ToString("dd-MMM-yyyy_HH-mm") & ".xlsx"
    '        If System.IO.File.Exists(ReportFileName) = True Then System.IO.File.Delete(ReportFileName)

    '        templateWrkBook.SaveAs(ReportFileName)
    '        templateWrkBook.Close(True)
    '        xlApp.Quit()

    '        releaseObject(xlApp)
    '        releaseObject(templateWrkBook)
    '        releaseObject(templateSht)
    '        Exit Sub
    'errH:
    '        On Error Resume Next
    '        frmMain.sslabel3.Text = Err.Description
    '        If Err.Description <> "" Then MsgBox(Err.Description)
    '        If xlApp IsNot Nothing Then xlApp.Quit()
    '        releaseObject(xlApp)
    '        releaseObject(templateWrkBook)
    '        releaseObject(templateSht)
    '    End Sub

    '    Public Sub genDefaulterReport(cutoffAmt As Double, BGFOrAssociation As String)
    '        On Error GoTo errH

    '        Dim actRS1 As ADODB.Recordset, r As Long
    '        Dim printSummary As Boolean, flatCode As String
    '        Dim tmpBGFDue As Double, tmpAssocDue As Double, tmpDue As Double, reportTitle As String = "", tmpFlatIndx As Integer, tmpDupFlatIndx As Integer
    '        Dim startCol As String, endCol As String
    '        'dim actRS2 As ADODB.Recordset, actRS3 As ADODB.Recordset,NetDrAmt As Double, NetCrAmt As Double, subNetDrAmt As Double, subNetCrAmt As Double, curAcctNo As String, prevAcctNo As String

    '        gFlats.updateBalance()

    '        startCol = "B"
    '        endCol = "F"

    '        If BGFOrAssociation = "BGF" Then
    '            ReportSql = "SELECT sum(DrAmount-CrAmount) as Outstanding,AccountNo FROM tbljournal_cult where Status is null and AccountNo like 'DEBTOR-CORPUS-FUND-%' group by AccountNo having Outstanding > " & cutoffAmt
    '            reportTitle = "BGF Maintenance and Lift AMC Dues Defaulter List** "
    '        ElseIf BGFOrAssociation = "ASSOCIATION" Then
    '            ReportSql = "SELECT sum(DrAmount-CrAmount) as Outstanding,AccountNo FROM tbljournal_cult where Status is null and AccountNo like 'DEBTOR-FLAT-%' group by AccountNo having Outstanding > " & cutoffAmt
    '            reportTitle = "Maintenance Bill Defaulter List** "
    '        End If

    '        actRS1 = gcon.Execute(ReportSql)

    '        '-----------------
    '        xlApp = New Microsoft.Office.Interop.Excel.Application
    '        templateWrkBook = xlApp.Workbooks.Add
    '        While templateWrkBook.Sheets.Count > 1
    '            templateSht = templateWrkBook.Sheets(1)
    '            templateSht.Delete()
    '        End While
    '        templateSht = templateWrkBook.Sheets(1)
    '        templateSht.Name = "DefaulterList-" & DateTime.Now.ToString(SCREEN_DATEFORMAT)
    '        'xlApp.Visible = True
    '        '-----------------
    '        r = 2
    '        templateSht.Range(startCol & r & ":" & endCol & r).Select()
    '        With xlApp.Selection
    '            .mergecells = True
    '            .Font.Bold = True
    '            .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '            .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
    '            .WrapText = False
    '        End With
    '        templateSht.Cells(r, startCol).value = reportTitle & " As of : " & DateTime.Now.ToString(SCREEN_DATEFORMAT) & Chr(10) & "**NEFT payments may not have accounted (NEFT details shared is inconclusive to reconcile against bank statement)"
    '        DrawBorder(templateSht, startCol & r & ":" & endCol & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft, False)

    '        templateSht.Range(r & ":" & r).Select()
    '        xlApp.Selection.RowHeight = 35
    '        xlApp.Selection.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

    '        '-----------------
    '        r = 3
    '        templateSht.Cells(r, "B").value = "Flat No"
    '        templateSht.Cells(r, "C").value = "Outstanding"
    '        templateSht.Cells(r, "D").value = "Owner"
    '        templateSht.Cells(r, "E").value = "Email"
    '        templateSht.Cells(r, "F").value = "Phone"
    '        'templateSht.Cells(r, "G").value = "BGFOutstanding"

    '        DrawBorder(templateSht, startCol & r & ":" & endCol & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter, False)



    '        While actRS1.EOF = False
    '            flatCode = myRight(actRS1("AccountNo").Value.ToString, 6)


    '            tmpAssocDue = 0
    '            tmpBGFDue = 0
    '            tmpDue = 0
    '            tmpDupFlatIndx = 0
    '            tmpFlatIndx = 0

    '            tmpFlatIndx = gFlats.getArrayIndex(flatCode)
    '            tmpAssocDue = gFlats.allFlats(tmpFlatIndx).AssocBalance
    '            tmpBGFDue = gFlats.allFlats(tmpFlatIndx).BGFBalance

    '            If gFlats.allFlats(tmpFlatIndx).DuplexFlatCode <> "" Then
    '                tmpDupFlatIndx = gFlats.getArrayIndex(gFlats.allFlats(tmpFlatIndx).DuplexFlatCode)
    '                tmpAssocDue = tmpAssocDue + gFlats.allFlats(tmpDupFlatIndx).AssocBalance
    '                tmpBGFDue = tmpBGFDue + gFlats.allFlats(tmpDupFlatIndx).BGFBalance
    '            End If

    '            ' ''ReportSql = "SELECT sum(DrAmount-CrAmount) as BGFOutstanding FROM tbljournal_cult where AccountNo = 'DEBTOR-CORPUS-FUND-" & flatCode & "'"
    '            ' ''actRS2 = gcon.Execute(ReportSql)
    '            ' ''ReportSql = "SELECT OwnerFullName,PrimaryEmail,PrimaryPhone FROM tblflatowners where FlatCode = '" & flatCode & "'"
    '            ' ''actRS3 = gcon.Execute(ReportSql)

    '            If BGFOrAssociation = "BGF" Then
    '                tmpDue = tmpBGFDue
    '            Else
    '                tmpDue = tmpAssocDue
    '            End If

    '            If (tmpDue > cutoffAmt) Then

    '                r = r + 1
    '                templateSht.Cells(r, "B").value = flatCode
    '                templateSht.Cells(r, "C").value = tmpDue
    '                'actRS1("Outstanding").Value.ToString()
    '                templateSht.Cells(r, "D").value = gFlats.allFlats(tmpFlatIndx).OwnerFullName
    '                ' actRS3("OwnerFullName").Value.ToString
    '                templateSht.Cells(r, "E").value = gFlats.allFlats(tmpFlatIndx).PrimaryEmail
    '                'actRS3("PrimaryEmail").Value.ToString
    '                templateSht.Cells(r, "F").value = gFlats.allFlats(tmpFlatIndx).PrimaryPhone
    '                ' actRS3("PrimaryPhone").Value.ToString
    '                'templateSht.Cells(r, "G").value = tmpBGFDue
    '                ' actRS2("BGFOutstanding").Value.ToString

    '                ' ''actRS2.Close()
    '                ' ''actRS3.Close()
    '            End If


    '            actRS1.MoveNext()
    '        End While


    '        actRS1.Close()

    '        DrawBorder(templateSht, startCol & "4:" & endCol & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, False, False, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter, False)
    '        'Autofit columns
    '        templateSht.Columns(startCol & ":" & endCol).EntireColumn.AutoFit()

    '        templateSht.Columns("A:A").Select()
    '        xlApp.Selection.ColumnWidth = 1

    '        templateSht.Columns("E:E").Select()
    '        xlApp.Selection.NumberFormat = "@"

    '        templateSht.Columns("F:F").Select()
    '        xlApp.Selection.NumberFormat = "@"

    '        templateSht.Columns("C:C").Select()
    '        xlApp.Selection.NumberFormat = "#,##0"

    '        'templateSht.Columns("G:G").Select()
    '        'xlApp.Selection.NumberFormat = "#,##0"
    '        xlApp.Visible = True

    '        releaseObject(xlApp)
    '        releaseObject(templateWrkBook)
    '        releaseObject(templateSht)
    '        Exit Sub
    'errH:
    '        On Error Resume Next
    '        frmMain.sslabel3.Text = Err.Description
    '        If Err.Description <> "" Then MsgBox(Err.Description)
    '        If xlApp IsNot Nothing Then xlApp.Quit()
    '        releaseObject(xlApp)
    '        releaseObject(templateWrkBook)
    '        releaseObject(templateSht)
    '    End Sub




    Sub genCASHBANKBOOKReport(accountNo As String, includeSummary As Boolean)
        On Error GoTo errH

        Dim actRSOB As ADODB.Recordset, actRS1 As ADODB.Recordset, r As Long, NetDrAmt As Double, NetCrAmt As Double, subNetDrAmt As Double, subNetCrAmt As Double, curAcctNo As String, prevAcctNo As String
        Dim isSummaryLine As Boolean, onlySummary As Boolean, tmpSortColVal As String = ""
        Dim lSortCol As String, lSortColVal As String, shtCnt As Integer

        'includeSummary = True
        onlySummary = False
        lSortCol = "TxnDate"


        dlgReportPeriod.ShowDialog()
        dlgReportPeriod.Dispose()
        If dtpFromDateSelected = "" Then Exit Sub


        '-----------------
        xlApp = New Microsoft.Office.Interop.Excel.Application
        templateWrkBook = xlApp.Workbooks.Add

        'remove additional sheets,if any
        While templateWrkBook.Sheets.Count > 1
            templateSht = templateWrkBook.Sheets(2)
            templateSht.Delete()
        End While
        templateSht = templateWrkBook.Sheets(1)
        templateSht.Name = IIf(Len(accountNo) > MAX_XL_WRKSHT_NAME_LEN, Left(accountNo, MAX_XL_WRKSHT_NAME_LEN - 3) & "...", accountNo)


        '-----------------
        r = 2

        If onlySummary = False Then
            r = r + 1
            'templateSht.Cells(r, "B").value = "AccountNo"
            templateSht.Cells(r, "C").value = "Txn Date"
            templateSht.Cells(r, "D").value = "Txn Type"
            templateSht.Cells(r, "E").value = "Narration"
            templateSht.Cells(r, "F").value = "DocRef"
            templateSht.Cells(r, "G").value = "Dr Amount"
            templateSht.Cells(r, "H").value = "Cr Amount"
            templateSht.Cells(r, "I").value = "Balance (Dr - Cr)"
            DrawBorder(templateSht, "B" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, False, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter, True)

        End If

        '==========================================================================================================================
        'print opening balance
        ssql = "select sum(DrAmount+0) as netDrAmt, sum(CrAmount+0) as netCrAmt from tbljournal_cult where Status is null and AccountNo ='" & accountNo & "'"
        ssql = ssql & " and TxnDate < '" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        actRSOB = gcon.Execute(ssql)

        NetDrAmt = actRSOB("netDrAmt").Value.ToString
        NetCrAmt = actRSOB("netCrAmt").Value.ToString
        actRSOB.Close()

        r = r + 2

        templateSht.Cells(r, "F").value = "Opening Balance"
        templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt


        '==========================================================================================================================

        'print rest
        ReportSql = "select * from tbljournal_cult where Status is null and AccountNo ='" & accountNo & "'"
        ReportSql = ReportSql & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        ReportSql = ReportSql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        ReportSql = ReportSql & " order by " & lSortCol

        actRS1 = gcon.Execute(ReportSql)

        '-----------------
        'r = r + 1
        'NetDrAmt = 0
        'NetCrAmt = 0
        subNetDrAmt = 0
        subNetCrAmt = 0
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
                'templateSht.Cells(r, "B").value = actRS1("AccountNo").Value.ToString
                'End If
                templateSht.Cells(r, "C").value = formatInt2Date(actRS1("TxnDate").Value.ToString)
                templateSht.Cells(r, "D").value = actRS1("TxnType").Value.ToString
                templateSht.Cells(r, "E").value = actRS1("Narration").Value.ToString
                templateSht.Cells(r, "F").value = actRS1("DocRef").Value.ToString
                templateSht.Cells(r, "G").value = actRS1("DrAmount").Value.ToString
                templateSht.Cells(r, "H").value = actRS1("CrAmount").Value.ToString

                templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt ' subNetDrAmt - subNetCrAmt
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
                    templateSht.Cells(r, "F").value = "Closing Balance - " & lSortColVal
                    templateSht.Cells(r, "G").value = subNetDrAmt
                    templateSht.Cells(r, "H").value = subNetCrAmt
                    templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt ' subNetDrAmt - subNetCrAmt

                    'subNetDrAmt = 0
                    'subNetCrAmt = 0
                    DrawBorder(templateSht, "C" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, True)
                End If

            End If
            '------------------------------------------------------------------------------

        End While

        r = r + 2
        templateSht.Cells(r, "F").value = "Final Closing Balance"
        templateSht.Cells(r, "G").value = NetDrAmt
        templateSht.Cells(r, "H").value = NetCrAmt
        templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt

        DrawBorder(templateSht, "C" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, True)

        actRS1.Close()

        DrawBorder(templateSht, "C" & "5" & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline, False, False, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)

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


        'xlApp.Visible = True

        'Autofit columns
        templateSht.Columns("C:I").EntireColumn.AutoFit()
        templateSht.Cells.Select()
        xlApp.Selection.Rows.AutoFit()
        xlApp.Selection.VerticalAlignment = -4108 'xlCenter
        'xlApp.Selection.WrapText = True

        'set column width : total 73
        templateSht.Columns("A:A").Select()
        xlApp.Selection.ColumnWidth = 0.1
        'xlApp.Selection.WrapText = True
        templateSht.Columns("B:B").Select()
        xlApp.Selection.ColumnWidth = 0.1
        'xlApp.Selection.WrapText = True
        'templateSht.Columns("C:C").Select()
        'xlApp.Selection.ColumnWidth = 7
        'xlApp.Selection.Columns.AutoFit()
        'xlApp.Selection.WrapText = True
        templateSht.Columns("D:D").Select()
        xlApp.Selection.ColumnWidth = 7
        xlApp.Selection.WrapText = True

        templateSht.Columns("F:F").Select()
        xlApp.Selection.ColumnWidth = 30
        xlApp.Selection.WrapText = True

        'xlApp.Selection.Columns.AutoFit()
        templateSht.Columns("E:E").Select()
        xlApp.Selection.ColumnWidth = 33
        xlApp.Selection.WrapText = True

        'templateSht.Columns("G:G").Select()
        'xlApp.Selection.ColumnWidth = 7
        'xlApp.Selection.Columns.AutoFit()
        'xlApp.Selection.WrapText = True
        'templateSht.Columns("H:H").Select()
        'xlApp.Selection.ColumnWidth = 7
        'xlApp.Selection.Columns.AutoFit()
        'xlApp.Selection.WrapText = True
        'templateSht.Columns("I:I").Select()
        'xlApp.Selection.ColumnWidth = 7
        'xlApp.Selection.Columns.AutoFit()
        'xlApp.Selection.WrapText = True



        'protect
        'Dim thisSecurity As New clsSecurity
        'thisSecurity.ProtectExcelFile(templateWrkBook)

        'xlApp.ActiveWindow.DisplayGridlines = False

        'xlApp.Visible = True

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

        '-----------------
        'print header (shud be placed at last as cells are merged with affects single col selection)
        r = 2
        templateSht.Range("C" & r & ":I" & r).Select()
        With xlApp.Selection
            .mergecells = True
            .Font.Bold = True
            .Font.Name = "Arial Narrow"
            .Font.Size = 8
            .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            .WrapText = False
        End With
        templateSht.Cells(r, "C").value = "From Date :" & dtpFromDateSelected & "   To Date :" & dtpToDateSelected & "   Account :" & accountNo
        '-----------------

        templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, getSysParamValue("PATH_TEMP") & gUserID & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)

        xlApp.Visible = True
        'On Error Resume Next
        'templateWrkBook.Close(False)
        'If xlApp IsNot Nothing Then xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)
        Exit Sub
errH:
        MsgBox(Err.Description)
        'frmMain.sslabel3.Text = Err.Description
        'If Err.Description <> "" Then MsgBox(Err.Description)
        On Error Resume Next
        templateWrkBook.Close(False)
        If xlApp IsNot Nothing Then xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)
    End Sub
    '    Sub genCASHBANKBOOKReportNew(frmP As Form, accountNo As String, reportType As String, entity As String)
    '        On Error GoTo errH

    '        Dim actRSOB As ADODB.Recordset, actRS1 As ADODB.Recordset, r As Long, NetDrAmt As Double, NetCrAmt As Double, subNetDrAmt As Double, subNetCrAmt As Double, curAcctNo As String
    '        Dim isSummaryLine As Boolean, onlySummary As Boolean, tmpSortColVal As String = "", accountStr As String, refgid As String, an As String, thisAmt As Double, gid As String
    '        Dim lSortCol As String, lSortColVal As String, shtCnt As Integer, curMonth As String, newMonth As String, ReceiptOrVoucherNo As String = ""

    '        Dim cd As New clsDocRef, vndrnr As String, tmpArr2(4) As String, tmpArr(10) As String, tmpNarration As String, x As Integer, totCnt As Long, curCnt As Long

    '        Dim glTableName As String = ""

    '        If entity = "MAINTENANCE" Then
    '            glTableName = "tbljournal_cult"
    '        ElseIf entity = "CULTURAL" Then
    '            glTableName = "tbljournal_cult_cult"
    '        End If


    '        dlgReportPeriod.ShowDialog()
    '        dlgReportPeriod.Dispose()
    '        If dtpFromDateSelected = "" Then Exit Sub

    '        xlApp = New Microsoft.Office.Interop.Excel.Application
    '        templateWrkBook = xlApp.Workbooks.Add

    '        'remove additional sheets,if any
    '        While templateWrkBook.Sheets.Count > 1
    '            templateSht = templateWrkBook.Sheets(2)
    '            templateSht.Delete()
    '        End While
    '        templateSht = templateWrkBook.Sheets(1)
    '        'execl worksheet name limit
    '        templateSht.Name = IIf(Len(accountNo) > MAX_XL_WRKSHT_NAME_LEN, Left(accountNo, MAX_XL_WRKSHT_NAME_LEN - 3) & "...", accountNo)
    '        '-----------------
    '        r = 2

    '        r = r + 1
    '        templateSht.Cells(r, "A").value = "DrAccountNo"
    '        templateSht.Cells(r, "B").value = "CrAccountNo"
    '        templateSht.Cells(r, "C").value = "Txn Date"
    '        templateSht.Cells(r, "D").value = "Txn Type"
    '        templateSht.Cells(r, "E").value = "Narration"
    '        templateSht.Cells(r, "F").value = "DocRef"
    '        templateSht.Cells(r, "G").value = "Voucher"
    '        templateSht.Cells(r, "H").value = "Amount (Rs.)"
    '        templateSht.Cells(r, "I").value = "Total (Rs.)"
    '        DrawBorder(templateSht, "A" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, False, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter, True)

    '        '==========================================================================================================================
    '        'print opening balance
    '        ssql = "select sum(DrAmount) as netDrAmt, sum(CrAmount) as netCrAmt from " & glTableName & " where Status is null and AccountNo ='" & accountNo & "'"
    '        ssql = ssql & " and TxnDate < '" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
    '        actRSOB = gcon.Execute(ssql)

    '        NetDrAmt = adjDouble(actRSOB("netDrAmt").Value.ToString)
    '        NetCrAmt = adjDouble(actRSOB("netCrAmt").Value.ToString)
    '        actRSOB.Close()

    '        r = r + 2

    '        templateSht.Cells(r, "C").value = dtpFromDateSelected
    '        templateSht.Cells(r, "F").value = "Opening Balance - " & accountNo
    '        templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt
    '        '==========================================================================================================================

    '        'print rest
    '        ReportSql = "select * from " & glTableName & " where Status is null "
    '        ReportSql = ReportSql & " and AccountNo ='" & accountNo & "'"
    '        ReportSql = ReportSql & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
    '        ReportSql = ReportSql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
    '        ReportSql = ReportSql & " Order By TxnDate Asc"
    '        actRS1 = gcon.Execute(ReportSql, totCnt)


    '        '-----------------
    '        r = r + 1
    '        isSummaryLine = True
    '        curAcctNo = accountNo

    '        curCnt = 0
    '        While actRS1.EOF = False
    '            curCnt = curCnt + 1

    '            isSummaryLine = False
    '            r = r + 1

    '            curMonth = DateTime.Parse(formatInt2Date(actRS1("TxnDate").Value.ToString)).ToString("MMM-yyyy")
    '            refgid = actRS1("refgid").Value.ToString
    '            gid = actRS1("gid").Value.ToString
    '            thisAmt = actRS1("DrAmount").Value.ToString - actRS1("CrAmount").Value.ToString
    '            ReceiptOrVoucherNo = ""
    '            tmpNarration = ""

    '            NetCrAmt = NetCrAmt + actRS1("CrAmount").Value.ToString
    '            NetDrAmt = NetDrAmt + actRS1("DrAmount").Value.ToString

    '            templateSht.Cells(r, "C").value = formatInt2Date(actRS1("TxnDate").Value.ToString)

    '            templateSht.Cells(r, "F").value = actRS1("DocRef").Value.ToString

    '            templateSht.Cells(r, "H").value = thisAmt
    '            templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt


    '            If reportType = "CASHBOOK" Then
    '                templateSht.Cells(r, "E").value = actRS1("Narration").Value.ToString
    '                If thisAmt > 0 Then
    '                    templateSht.Cells(r, "A").value = actRS1("AccountNo").Value.ToString
    '                    templateSht.Cells(r, "B").value = getDrORCrAccountNo(gid, "CR", glTableName)
    '                    templateSht.Cells(r, "D").value = "Receipt"

    '                    ReceiptOrVoucherNo = "R#: " & cd.getReceiptNo(actRS1("DocRef").Value.ToString)
    '                ElseIf thisAmt < 0 Then
    '                    templateSht.Cells(r, "A").value = getDrORCrAccountNo(gid, "DR", glTableName)
    '                    templateSht.Cells(r, "B").value = actRS1("AccountNo").Value.ToString
    '                    templateSht.Cells(r, "D").value = "Payment"

    '                    ReceiptOrVoucherNo = "V#: " & actRS1("VoucherNo").Value.ToString
    '                Else
    '                    templateSht.Cells(r, "A").value = actRS1("AccountNo").Value.ToString
    '                    templateSht.Cells(r, "B").value = getDrORCrAccountNo(gid, "CR", glTableName)
    '                    templateSht.Cells(r, "D").value = "-"

    '                    ReceiptOrVoucherNo = "-"
    '                End If
    '                templateSht.Cells(r, "G").value = ReceiptOrVoucherNo

    '            ElseIf reportType = "BANKBOOK" Then

    '                If thisAmt > 0 Then
    '                    templateSht.Cells(r, "A").value = actRS1("AccountNo").Value.ToString

    '                    templateSht.Cells(r, "D").value = "Receipt"
    '                    If refgid <> "" Then 'reconciled 
    '                        templateSht.Cells(r, "B").value = getDrORCrAccountNo(refgid, "CR", glTableName) 'Get the CR account of reconciled receipt

    '                        ReDim tmpArr(10)
    '                        tmpArr = Split(getMultiReceiptNarrationFromRefGid(gid, glTableName), "~~")
    '                        For x = 1 To tmpArr.Length
    '                            tmpArr2 = Split(tmpArr(x - 1), "^^")

    '                            ReceiptOrVoucherNo = ReceiptOrVoucherNo & "R#: " & tmpArr2(0) & ","
    '                            tmpNarration = tmpNarration & tmpArr2(1) & ","
    '                        Next x
    '                        ReceiptOrVoucherNo = Left(ReceiptOrVoucherNo, Len(ReceiptOrVoucherNo) - 1)
    '                        tmpNarration = Left(tmpNarration, Len(tmpNarration) - 1)

    '                    Else
    '                        templateSht.Cells(r, "B").value = getDrORCrAccountNo(gid, "CR", glTableName) 'Get the CR account of this txn as it is not yet reconciled
    '                        ReceiptOrVoucherNo = "R#: " & cd.getReceiptNo(actRS1("Narration").Value.ToString)
    '                        tmpNarration = actRS1("Narration").Value.ToString
    '                    End If
    '                ElseIf thisAmt < 0 Then
    '                    If refgid = "" Then 'Not reconciled yet
    '                        templateSht.Cells(r, "A").value = getDrORCrAccountNo(gid, "DR", glTableName)
    '                        tmpNarration = actRS1("Narration").Value.ToString
    '                        ReceiptOrVoucherNo = "Reconciliation Not Found"
    '                    Else
    '                        tmpArr = Split(getRefDetailsFromGid(gid, glTableName), "^^")
    '                        templateSht.Cells(r, "A").value = tmpArr(0)
    '                        ReceiptOrVoucherNo = "V#: " & tmpArr(1)
    '                        tmpNarration = actRS1("Narration").Value.ToString

    '                        'If tmpArr.Length > 1 Then
    '                        '    Dim x As Integer = 1
    '                        '    While tmpArr(x) <> ""
    '                        '        tmpArr2 = Split(tmpArr(x), "^^")
    '                        '        templateSht.Cells(r, "A").value = templateSht.Cells(r, "A").value & ", " & tmpArr2(0)
    '                        '        ReceiptOrVoucherNo = ReceiptOrVoucherNo & ", " & "V#: " & tmpArr2(1)
    '                        '        x = x + 1
    '                        '    End While
    '                        'End If
    '                    End If

    '                    templateSht.Cells(r, "B").value = actRS1("AccountNo").Value.ToString
    '                    templateSht.Cells(r, "D").value = "Payment"
    '                    'End If
    '                Else
    '                    templateSht.Cells(r, "A").value = actRS1("AccountNo").Value.ToString
    '                    templateSht.Cells(r, "B").value = getDrORCrAccountNo(actRS1("gid").Value.ToString, "CR", glTableName)
    '                    templateSht.Cells(r, "D").value = "-"

    '                    ReceiptOrVoucherNo = "-"
    '                End If
    '                templateSht.Cells(r, "E").value = tmpNarration
    '                templateSht.Cells(r, "G").value = ReceiptOrVoucherNo
    '            End If 'end of report type



    '            actRS1.MoveNext()

    '            If actRS1.EOF = True Then
    '                newMonth = ""
    '            Else
    '                newMonth = DateTime.Parse(formatInt2Date(actRS1("TxnDate").Value.ToString)).ToString("MMM-yyyy")
    '            End If
    '            If newMonth <> curMonth Then 'Last record or new account start
    '                isSummaryLine = True
    '            Else
    '                isSummaryLine = False
    '            End If

    '            If isSummaryLine = True Then
    '                r = r + 1

    '                templateSht.Cells(r, "F").value = "Closing Balance - " & curMonth
    '                templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt

    '                DrawBorder(templateSht, "A" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, True)
    '            End If

    '            frmP.Text = gOrgCaption & " [ Report Progress : " & curCnt & " / " & totCnt & " ]"
    '            Application.DoEvents()
    '        End While

    '        r = r + 2
    '        templateSht.Cells(r, "F").value = "Final Closing Balance"
    '        templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt

    '        DrawBorder(templateSht, "A" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, True)

    '        actRS1.Close()

    '        DrawBorder(templateSht, "A" & "5" & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline, False, False, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)

    '        'Set Font 
    '        templateSht.Cells.Select()
    '        With xlApp.Selection.Font
    '            .Name = "Arial Narrow"
    '            .Size = 8
    '            .Strikethrough = False
    '            .Superscript = False
    '            .Subscript = False
    '            .OutlineFont = False
    '            .Shadow = False
    '            .Underline = -4142 ' xlUnderlineStyleNone
    '            '.ThemeColor = xlThemeColorLight1
    '            .TintAndShade = 0
    '            '.ThemeFont = xlThemeFontNone
    '        End With
    '        templateSht.Range("A1").Select()


    '        'xlApp.Visible = True

    '        'Autofit columns
    '        templateSht.Columns("A:I").EntireColumn.AutoFit()
    '        templateSht.Cells.Select()
    '        xlApp.Selection.Rows.AutoFit()
    '        xlApp.Selection.VerticalAlignment = -4108 'xlCenter
    '        'xlApp.Selection.WrapText = True

    '        templateSht.Columns("D:D").Select()
    '        xlApp.Selection.ColumnWidth = 6
    '        xlApp.Selection.WrapText = True

    '        templateSht.Columns("F:F").Select()
    '        xlApp.Selection.ColumnWidth = 30
    '        xlApp.Selection.WrapText = True

    '        'xlApp.Selection.Columns.AutoFit()
    '        templateSht.Columns("E:E").Select()
    '        xlApp.Selection.ColumnWidth = 33
    '        xlApp.Selection.WrapText = True


    '        'protect
    '        'Dim thisSecurity As New clsSecurity
    '        'thisSecurity.ProtectExcelFile(templateWrkBook)

    '        'xlApp.ActiveWindow.DisplayGridlines = False

    '        'xlApp.Visible = True

    '        'templateSht.Columns("G:G").NumberFormat = "#,##0.00"
    '        templateSht.Columns("H:H").NumberFormat = "#,##0.00"
    '        templateSht.Columns("I:I").NumberFormat = "#,##0.00"

    '        With templateSht.PageSetup
    '            .PrintTitleRows = "$3:$3"
    '            .LeftHeader = ""
    '            .CenterHeader = ""
    '            .RightHeader = ""
    '            .LeftFooter = ""
    '            .CenterFooter = ""
    '            .RightFooter = ""
    '            .LeftMargin = 0 'Application.InchesToPoints(0.708661417322835)
    '            .RightMargin = 0 'Application.InchesToPoints(0.708661417322835)
    '            .TopMargin = 0 ' Application.InchesToPoints(0.748031496062992)
    '            .BottomMargin = 0 ' Application.InchesToPoints(0.748031496062992)
    '            '.HeaderMargin = Application.InchesToPoints(0.31496062992126)
    '            '.FooterMargin = Application.InchesToPoints(0.31496062992126)
    '            .PrintHeadings = False
    '            .PrintGridlines = False
    '            '.PrintComments = xlPrintNoComments
    '            '.PrintQuality = -3
    '            '.CenterHorizontally = True
    '            '.CenterVertically = True
    '            '.Orientation = 1 ' xlPortrait
    '            .Draft = False
    '            '.PaperSize = 9 ' xlPaperA4
    '            '.FirstPageNumber = xlAutomatic
    '            '.Order = xlDownThenOver
    '            .BlackAndWhite = False
    '            .Zoom = False
    '            .FitToPagesWide = 1
    '            .FitToPagesTall = 10000
    '            '.PrintErrors = xlPrintErrorsDisplayed
    '            .OddAndEvenPagesHeaderFooter = False
    '            .DifferentFirstPageHeaderFooter = False
    '            .ScaleWithDocHeaderFooter = True
    '            .AlignMarginsHeaderFooter = True
    '            .EvenPage.LeftHeader.Text = ""
    '            .EvenPage.CenterHeader.Text = ""
    '            .EvenPage.RightHeader.Text = ""
    '            .EvenPage.LeftFooter.Text = ""
    '            .EvenPage.CenterFooter.Text = ""
    '            .EvenPage.RightFooter.Text = ""
    '            .FirstPage.LeftHeader.Text = ""
    '            .FirstPage.CenterHeader.Text = ""
    '            .FirstPage.RightHeader.Text = ""
    '            .FirstPage.LeftFooter.Text = ""
    '            .FirstPage.CenterFooter.Text = ""
    '            .FirstPage.RightFooter.Text = ""
    '        End With


    '        '-----------------
    '        'print header (shud be placed at last as cells are merged with affects single col selection)
    '        r = 2
    '        templateSht.Range("A" & r & ":I" & r).Select()
    '        With xlApp.Selection
    '            .mergecells = True
    '            .Font.Bold = True
    '            .Font.Name = "Arial Narrow"
    '            .Font.Size = 8
    '            .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '            .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
    '            .WrapText = False
    '        End With
    '        templateSht.Cells(r, "A").value = "From Date :" & dtpFromDateSelected & "   To Date :" & dtpToDateSelected & "   Account :" & accountNo
    '        '-----------------

    '        Dim tempPath As String = ""
    '        tempPath = getSysParamValue("PATH_TEMP") & entity & "_" & reportType & "_" & DateTime.Parse(Now).ToString("ddMMMyyHHmmss") & ".pdf"

    '        templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, tempPath, Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)

    '        xlApp.Visible = True
    '        'On Error Resume Next
    '        'templateWrkBook.Close(False)
    '        'If xlApp IsNot Nothing Then xlApp.Quit()

    '        releaseObject(xlApp)
    '        releaseObject(templateWrkBook)
    '        releaseObject(templateSht)
    '        Exit Sub
    'errH:
    '        MsgBox(Err.Description)
    '        'frmMain.sslabel3.Text = Err.Description
    '        'If Err.Description <> "" Then MsgBox(Err.Description)
    '        On Error Resume Next
    '        templateWrkBook.Close(False)
    '        If xlApp IsNot Nothing Then xlApp.Quit()
    '        releaseObject(xlApp)
    '        releaseObject(templateWrkBook)
    '        releaseObject(templateSht)
    '        frmP.Text = gOrgCaption
    '    End Sub
    Sub genExpenseReportCult(includeSummary As Boolean)
        On Error GoTo errH

        Dim actRS1 As ADODB.Recordset, r As Long, NetDrAmt As Double, NetCrAmt As Double, subNetDrAmt As Double, subNetCrAmt As Double, curAcctNo As String, prevAcctNo As String
        Dim isSummaryLine As Boolean, onlySummary As Boolean, tmpSortColVal As String = "", accountStr As String
        Dim lSortCol As String, lSortColVal As String = "", shtCnt As Integer


        'includeSummary = True
        onlySummary = False
        lSortCol = "TxnDate"

        dlgReportPeriod.ShowDialog()
        dlgReportPeriod.Dispose()
        If dtpFromDateSelected = "" Then Exit Sub

        dlgSortCol.ShowDialog()
        dlgSortCol.Dispose()
        If gSortCol = "" Then Exit Sub
        lSortCol = gSortCol
        '-----------------
        xlApp = New Microsoft.Office.Interop.Excel.Application
        templateWrkBook = xlApp.Workbooks.Add

        'remove additional sheets,if any
        While templateWrkBook.Sheets.Count > 1
            templateSht = templateWrkBook.Sheets(2)
            templateSht.Delete()
        End While
        templateSht = templateWrkBook.Sheets(1)
        templateSht.Name = "ExpenseReport"


        '-----------------
        r = 2

        If onlySummary = False Then
            r = r + 1
            templateSht.Cells(r, "A").value = "DrAccountNo"
            templateSht.Cells(r, "B").value = "CrAccountNo"
            templateSht.Cells(r, "C").value = "Txn Date"
            templateSht.Cells(r, "D").value = "Txn Type"
            templateSht.Cells(r, "E").value = "Narration"
            templateSht.Cells(r, "F").value = "DocRef"
            templateSht.Cells(r, "G").value = "Voucher"
            templateSht.Cells(r, "H").value = "Amount (Rs.)"
            templateSht.Cells(r, "I").value = "Total (Rs.)"
            DrawBorder(templateSht, "A" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, False, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter, True)

        End If

        'NO OPENING BALANCE FOR EXPENSE

        'print rest
        accountStr = getAccountsByAccountType("Expenses")

        'ReportSql = "select * from tbljournal_cult where Status is null and TxnType in ('EXPENSE','PREPAID-EXPENSE')"
        'ReportSql = ReportSql & " and (AccountNo ='CASHBOX' OR AccountNo ='DD' OR AccountNo LIKE 'CHEQUE%' OR AccountNo LIKE 'BANK%')"  
        ReportSql = "select * from tbljournal_cult where Status is null "
        ReportSql = ReportSql & " and AccountNo in (" & accountStr & ")"
        ReportSql = ReportSql & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        ReportSql = ReportSql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        ReportSql = ReportSql & gOrderbyStr

        actRS1 = gcon.Execute(ReportSql)

        '-----------------
        r = r + 1
        NetDrAmt = 0
        NetCrAmt = 0
        subNetDrAmt = 0
        subNetCrAmt = 0
        prevAcctNo = ""
        'isSummaryLine = True

        While actRS1.EOF = False

            curAcctNo = actRS1("AccountNo").Value.ToString

            If lSortCol = "Date" Then
                lSortColVal = formatInt2Date(actRS1("TxnDate").Value.ToString)
                lSortColVal = DateTime.Parse(lSortColVal).ToString("MMM-yyyy")
            ElseIf lSortCol = "Amount" Then
                lSortColVal = actRS1("DrAmount").Value.ToString + actRS1("CrAmount").Value.ToString
            ElseIf lSortCol = "Account" Then
                lSortColVal = actRS1("AccountNo").Value.ToString
            End If

            '------------------------------------------------------------------------------
            subNetCrAmt = subNetCrAmt + actRS1("CrAmount").Value.ToString
            subNetDrAmt = subNetDrAmt + actRS1("DrAmount").Value.ToString

            NetCrAmt = NetCrAmt + actRS1("CrAmount").Value.ToString
            NetDrAmt = NetDrAmt + actRS1("DrAmount").Value.ToString
            '------------------------------------------------------------------------------


            If onlySummary = False Then
                r = r + 1
                'If isSummaryLine = True Then
                isSummaryLine = False
                'templateSht.Cells(r, "B").value = actRS1("AccountNo").Value.ToString
                'End If

                templateSht.Cells(r, "A").value = actRS1("AccountNo").Value.ToString
                templateSht.Cells(r, "B").value = getDrORCrAccountNo(actRS1("gid").Value.ToString, "CR", "tbljournal_cult")
                templateSht.Cells(r, "C").value = formatInt2Date(actRS1("TxnDate").Value.ToString)
                templateSht.Cells(r, "D").value = actRS1("TxnType").Value.ToString
                templateSht.Cells(r, "E").value = actRS1("Narration").Value.ToString
                templateSht.Cells(r, "F").value = actRS1("DocRef").Value.ToString
                templateSht.Cells(r, "G").value = actRS1("VoucherNo").Value.ToString
                templateSht.Cells(r, "H").value = actRS1("DrAmount").Value.ToString - actRS1("CrAmount").Value.ToString

                templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt
            End If

            actRS1.MoveNext()


            If includeSummary = True Then

                If actRS1.EOF = True Then
                    isSummaryLine = True
                    'ElseIf curAcctNo <> actRS1("AccountNo").Value.ToString Then 'Last record or new account start
                Else
                    If lSortCol = "Date" Then
                        tmpSortColVal = formatInt2Date(actRS1("TxnDate").Value.ToString)
                        tmpSortColVal = DateTime.Parse(tmpSortColVal).ToString("MMM-yyyy")
                    ElseIf lSortCol = "Amount" Then
                        lSortColVal = actRS1("DrAmount").Value.ToString + actRS1("CrAmount").Value.ToString
                    ElseIf lSortCol = "Account" Then
                        tmpSortColVal = actRS1("AccountNo").Value.ToString
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
                    templateSht.Cells(r, "F").value = "Closing Balance - " & lSortColVal
                    'templateSht.Cells(r, "G").value = subNetDrAmt
                    templateSht.Cells(r, "H").value = subNetDrAmt - subNetCrAmt
                    templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt

                    subNetDrAmt = 0
                    subNetCrAmt = 0
                    DrawBorder(templateSht, "A" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, True)
                End If

            End If
            '------------------------------------------------------------------------------

        End While

        r = r + 2
        templateSht.Cells(r, "F").value = "Final Closing Balance"
        'templateSht.Cells(r, "G").value = NetDrAmt
        'templateSht.Cells(r, "H").value = subNetDrAmt - subNetCrAmt
        templateSht.Cells(r, "I").value = NetDrAmt - NetCrAmt

        DrawBorder(templateSht, "A" & r & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, True, True, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, True)

        actRS1.Close()

        DrawBorder(templateSht, "A" & "5" & ":I" & r, Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline, False, False, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight, False)

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


        'xlApp.Visible = True

        'Autofit columns
        templateSht.Columns("A:I").EntireColumn.AutoFit()
        templateSht.Cells.Select()
        xlApp.Selection.Rows.AutoFit()
        xlApp.Selection.VerticalAlignment = -4108 'xlCenter
        'xlApp.Selection.WrapText = True

        'set column width : total 73
        'templateSht.Columns("A:A").Select()
        'xlApp.Selection.ColumnWidth = 4
        'xlApp.Selection.WrapText = True

        'templateSht.Columns("B:B").Select()
        'xlApp.Selection.ColumnWidth = 4
        'xlApp.Selection.WrapText = True

        'templateSht.Columns("C:C").Select()
        'xlApp.Selection.ColumnWidth = 7
        'xlApp.Selection.Columns.AutoFit()
        'xlApp.Selection.WrapText = True

        templateSht.Columns("D:D").Select()
        xlApp.Selection.ColumnWidth = 6
        xlApp.Selection.WrapText = True

        templateSht.Columns("F:F").Select()
        xlApp.Selection.ColumnWidth = 30
        xlApp.Selection.WrapText = True

        'xlApp.Selection.Columns.AutoFit()
        templateSht.Columns("E:E").Select()
        xlApp.Selection.ColumnWidth = 33
        xlApp.Selection.WrapText = True

        'templateSht.Columns("G:G").Select()
        'xlApp.Selection.ColumnWidth = 7
        'xlApp.Selection.Columns.AutoFit()
        'xlApp.Selection.WrapText = True
        'templateSht.Columns("H:H").Select()
        'xlApp.Selection.ColumnWidth = 7
        'xlApp.Selection.Columns.AutoFit()
        'xlApp.Selection.WrapText = True
        'templateSht.Columns("I:I").Select()
        'xlApp.Selection.ColumnWidth = 7
        'xlApp.Selection.Columns.AutoFit()
        'xlApp.Selection.WrapText = True



        'protect
        'Dim thisSecurity As New clsSecurity
        'thisSecurity.ProtectExcelFile(templateWrkBook)

        'xlApp.ActiveWindow.DisplayGridlines = False

        'xlApp.Visible = True

        'templateSht.Columns("G:G").NumberFormat = "#,##0.00"
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

        '-----------------
        'print header (shud be placed at last as cells are merged with affects single col selection)
        r = 2
        templateSht.Range("A" & r & ":I" & r).Select()
        With xlApp.Selection
            .mergecells = True
            .Font.Bold = True
            .Font.Name = "Arial Narrow"
            .Font.Size = 8
            .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            .WrapText = False
        End With
        templateSht.Cells(r, "A").value = "From Date :" & dtpFromDateSelected & "   To Date :" & dtpToDateSelected & "   Report Type : Expense"
        '-----------------

        templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, getSysParamValue("PATH_TEMP") & gUserID & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)

        xlApp.Visible = True
        'On Error Resume Next
        'templateWrkBook.Close(False)
        'If xlApp IsNot Nothing Then xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)
        Exit Sub
errH:
        MsgBox(Err.Description)
        'frmMain.sslabel3.Text = Err.Description
        'If Err.Description <> "" Then MsgBox(Err.Description)
        On Error Resume Next
        templateWrkBook.Close(False)
        If xlApp IsNot Nothing Then xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)
    End Sub
End Class
