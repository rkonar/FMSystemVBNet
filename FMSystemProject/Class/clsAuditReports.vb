Public Class clsAuditReports

    Private allAccountsStr As String = ""
    Private lFinYear As New clsFinYear

    Public Function getUnClearedChequePayments(stDt As Long, enDt As Long, cutDt As Long, chqIssuesAc As String) As Double
        Dim actRS1 As ADODB.Recordset, retStr As String = ""
        getUnClearedChequePayments = 0

        ssql = "select sum(CrAmount) as sumamt from tbljournal where AccountNo='" & chqIssuesAc & "' and gid in ( "
        ssql = ssql & "SELECT j1.gid FROM tbljournal j1 left outer join tbljournal j2 on j1.refgid=j2.gid "
        ssql = ssql & " where j1.Status is null and j2.Status is null "
        ssql = ssql & " and j1.TxnDate <= " & enDt
        ssql = ssql & " and j1.TxnDate >= " & stDt
        ssql = ssql & " AND j1.DocRef like '(Cheque No:%'"
        ssql = ssql & " AND (j1.AccountNo LIKE 'EXPC%' OR j1.AccountNo LIKE 'FIXED-ASSET%' OR j1.AccountNo LIKE 'DEFERRED-EXP%' OR j1.AccountNo LIKE 'DEFERRED-LIAB%') "
        ssql = ssql & " AND j2.DrAmount>0 "
        ssql = ssql & " and j2.TxnDate > " & cutDt
        ssql = ssql & " )"

        actRS1 = gcon.Execute(ssql)
        getUnClearedChequePayments = IIf(DBNull.Value.Equals(actRS1.Fields(0).Value), 0, actRS1.Fields(0).Value.ToString)
        actRS1.Close()

        releaseObject(actRS1)
    End Function
    Public Function getTDSPaidOnSavingsAccount(stDt As Long, enDt As Long, nonTDBankAcNo As String) As Double
        Dim actRS1 As ADODB.Recordset, retStr As String = ""
        getTDSPaidOnSavingsAccount = 0

        ssql = "select sum(CrAmount) as sumamt from tbljournal where Status is null and AccountNo='" & nonTDBankAcNo & "'"
        ssql = ssql & " and TxnDate <= " & enDt
        ssql = ssql & " and TxnDate >= " & stDt
        ssql = ssql & " and TxnType = 'TAX-TDS'"

        actRS1 = gcon.Execute(ssql)
        getTDSPaidOnSavingsAccount = IIf(DBNull.Value.Equals(actRS1.Fields(0).Value), 0, actRS1.Fields(0).Value.ToString)
        actRS1.Close()

        releaseObject(actRS1)
    End Function
    Public Function getTaxRefund(stDt As Long, enDt As Long) As Double
        Dim actRS1 As ADODB.Recordset, retStr As String = ""
        getTaxRefund = 0

        ssql = "select sum(CrAmount) as sumamt from tbljournal where Status is null and AccountNo='TAX-TDS'"
        ssql = ssql & " and TxnDate <= " & enDt
        ssql = ssql & " and TxnDate >= " & stDt
        ssql = ssql & " and TxnType = 'TAX-REFUND'"

        actRS1 = gcon.Execute(ssql)
        getTaxRefund = IIf(DBNull.Value.Equals(actRS1.Fields(0).Value), 0, actRS1.Fields(0).Value.ToString)
        actRS1.Close()

        releaseObject(actRS1)
    End Function
    Public Function getTermDepositCreated(stDt As Long, enDt As Long, txnType As String) As Double
        Dim actRS1 As ADODB.Recordset, retStr As String = ""
        getTermDepositCreated = 0

        ssql = "SELECT sum(CrAmount) FROM tbljournal WHERE Status is null and CrAmount > 0"
        ssql = ssql & " and TxnDate <= " & enDt
        ssql = ssql & " and TxnDate >= " & stDt
        ssql = ssql & " and TxnType = '" & txnType & "'"

        actRS1 = gcon.Execute(ssql)
        getTermDepositCreated = IIf(DBNull.Value.Equals(actRS1.Fields(0).Value), 0, actRS1.Fields(0).Value.ToString)
        actRS1.Close()

        releaseObject(actRS1)
    End Function
    Public Function getAccountBalanceBetweenDates(stDt As Long, enDt As Long, accountNo As String, drORcrORnet As String, Optional extraWhereCondition As String = "") As String
        Dim actRS1 As ADODB.Recordset, retStr As String = ""
        getAccountBalanceBetweenDates = ""

        allAccountsStr = "'" & accountNo & "'"
        getAllChildAccounts(accountNo)

        If drORcrORnet = "DR" Then
            retStr = "sum(DrAmount)"
        ElseIf drORcrORnet = "CR" Then
            retStr = "sum(CrAmount)"
        ElseIf drORcrORnet = "NET" Then
            retStr = "sum(DrAmount-CrAmount)"
        End If

        ssql = "select " & retStr & " as netAmt from tbljournal where status is null and AccountNo in (" & allAccountsStr & ")"
        ssql = ssql & " and TxnDate <= " & enDt
        ssql = ssql & " and TxnDate >= " & stDt
        If extraWhereCondition <> "" Then ssql = ssql & " " & extraWhereCondition

        actRS1 = gcon.Execute(ssql)
        getAccountBalanceBetweenDates = IIf(DBNull.Value.Equals(actRS1.Fields(0).Value), 0, actRS1.Fields(0).Value.ToString)
        actRS1.Close()
    End Function
    Public Function getAccountBalanceAsOfDate(asOfDt As Long, accountNo As String, drORcrORnet As String) As String
        Dim actRS1 As ADODB.Recordset, retStr As String = ""
        getAccountBalanceAsOfDate = ""

        allAccountsStr = "'" & accountNo & "'"
        getAllChildAccounts(accountNo)
        If drORcrORnet = "DR" Then
            retStr = "sum(DrAmount)"
        ElseIf drORcrORnet = "CR" Then
            retStr = "sum(CrAmount)"
        ElseIf drORcrORnet = "NET" Then
            retStr = "sum(DrAmount-CrAmount)"
        End If

        ssql = "select " & retStr & " as netAmt from tbljournal where status is null and AccountNo in (" & allAccountsStr & ")"
        ssql = ssql & " and TxnDate <= " & asOfDt
        ssql = ssql & " and TxnDate >= " & "20110101"

        actRS1 = gcon.Execute(ssql)
        getAccountBalanceAsOfDate = IIf(DBNull.Value.Equals(actRS1.Fields(0).Value), 0, actRS1.Fields(0).Value.ToString)
        actRS1.Close()
    End Function
    Public Sub getAllChildAccounts(ByRef parAccount As String)
        Dim tmpSql As String
        Dim tmpRS As ADODB.Recordset

        tmpSql = "select AccountNo,LeafAccount from tblaccounts where ParentAccountNo ='" & parAccount & "'"
        tmpRS = gcon.Execute(tmpSql)

        While tmpRS.EOF = False

            If tmpRS("LeafAccount").Value.ToString() = "N" Then
                getAllChildAccounts(tmpRS("AccountNo").Value.ToString())
            Else
                allAccountsStr = allAccountsStr & ",'" & tmpRS("AccountNo").Value.ToString() & "'"
            End If

            tmpRS.MoveNext()
        End While

        tmpRS.Close()

    End Sub

    Sub genBSReport()
        On Error GoTo errH

        Const COL_BSTEMPLATE_LIABILITY_TEXT = "B"
        Const COL_BSTEMPLATE_LIABILITY_AMOUNT1 = "C"
        Const COL_BSTEMPLATE_LIABILITY_AMOUNT2 = "D"
        Const COL_BSTEMPLATE_ASSET_TEXT = "E"
        Const COL_BSTEMPLATE_ASSET_AMOUNT1 = "F"
        Const COL_BSTEMPLATE_ASSET_AMOUNT2 = "G"

        Const ROW_BSTEMPLATE_DATA_START = 7
        Const ROW_BSTEMPLATE_DATA_END = 62

        Dim LiabTotal As Double, AssetTotal As Double
        Dim curStartDate As Long, curEndDate As Long, PrevStartDate As Long, PrevEndDate As Long
        Dim pv As Double = 0, pv2 As Double = 0, cv As Double = 0, an As String, sr As Integer, cvA As Double, cvP As Double, cv2 As Double, cv3 As Double

        '=========================================
        dlgDtpDialog.ShowDialog()
        dlgDtpDialog.Dispose()
        If dtpDateSelected = "" Then Exit Sub
        '=========================================
        curEndDate = DateTime.Parse(dtpDateSelected).ToString(DB_DATEFORMAT)
        lFinYear.SetToFinYearByDate(curEndDate)
        curStartDate = lFinYear.startDate
        ' ''PrevStartDate = "20110622" 'First transaction date in system is of 23-Jun-2011
        PrevEndDate = (lFinYear.endYear - 1) & "0331"

        PrevStartDate = DateTime.Parse(CDate(lFinYear.startDateDisplay).AddYears(-1)).ToString(DB_DATEFORMAT)


        If curEndDate = "20130331" Then 'First Year Audit was done for the period between 23/06/2011 to 31/03/2013
            curStartDate = "20110623"
            PrevEndDate = "20110622"
        End If


        '=========================================
        xlApp = New Microsoft.Office.Interop.Excel.Application
        
        templateWrkBook = xlApp.Workbooks.Open(getSysParamValue("TEMPLATEPATH_AUDITREPORT_BS"), False, True)
        templateSht = templateWrkBook.Sheets("active_template")
        templateSht.Select()
        '=========================================
        LiabTotal = 0
        AssetTotal = 0
        '=========================================
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START - 4)).Value = dtpDateSelected


        '================================================PRINT LIABILITY SIDE======================================

        sr = 0

        'General Fund
        an = "INCOME-EXPENSE"
        pv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        an = "INCOME-OVER-EXPENSE"
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        an = "CORPUS-FUND-ADD"
        cv2 = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        LiabTotal = LiabTotal + pv + cv - cv2

        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "General Fund"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "   Add:Excess of Income Over Expenditure"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Value = "   Less:Transfer to Corpus Fund"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Value = cv2
        DrawUnderline(templateSht, COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 3), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Value = pv + cv - cv2
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Font.Bold = FontStyle.Bold
        sr = sr + 4

        'Corpus Fund
        If curEndDate = "20130331" Then
            an = "CORPUS-FUND-ORG"
            pv = (-1) * getAccountBalanceAsOfDate(curEndDate, an, "NET")
        Else
            an = "CORPUS-FUND"
            pv = (-1) * getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        End If


        an = "GENERAL-FUND"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        LiabTotal = LiabTotal + pv + cv

        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Corpus Fund"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "   Add:Transfer from General Fund"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        DrawUnderline(templateSht, COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = pv + cv
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Font.Bold = FontStyle.Bold
        sr = sr + 3


        'O/S General Maintenance Payable
        an = "CHEQUE-ISSUED-ALL"
        pv2 = (-1) * getAccountBalanceAsOfDate(PrevEndDate, an, "NET")

        an = "DEFERRED-LIAB"
        pv = (-1) * getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
       
        an = "DEFERRED-LIAB"
        cvA = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")

        an = "DEFERRED-LIAB"
        cvP = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR") + pv2 'This is paid this year; add last year check issued not realised as paid this year


        an = "CHEQUE-ISSUED-ALL"
        cv2 = (-1) * getAccountBalanceAsOfDate(curEndDate, an, "NET")

        If Not (pv = 0 And pv2 = 0 And cvA = 0 And cv2 = 0 And cvP = 0) Then

            LiabTotal = LiabTotal + pv + pv2 + cvA + cv2 - cvP

            templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "O/S General Maintenance Payable"
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv + pv2
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "   Add:This year"
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cvA
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Value = "   Add:Uncleared Cheques Issued"
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Value = cv2
            DrawUnderline(templateSht, COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 3), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = pv + pv2 + cvA + cv2
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 5)).Value = "   Less:Paid"
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 5)).Value = cvP
            DrawUnderline(templateSht, COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 5), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 5)).Value = pv + pv2 + cvA + cv2 - cvP
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 5)).Font.Bold = FontStyle.Bold
            sr = sr + 6
        End If

        'Association Formation Fund
        an = "ASSOCIATION-FORMATION-FUND"
        pv = (-1) * getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        LiabTotal = LiabTotal + pv + cv

        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Association Formation Fund"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "   Add:This year"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        DrawUnderline(templateSht, COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = pv + cv
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Font.Bold = FontStyle.Bold
        sr = sr + 3



        'Provision For Taxation
        an = "PROVISION-FOR-TAX"
        pv = (-1) * getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")

        an = "TAX-SELF-PAID"
        pv2 = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        cv2 = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")

        'an = "TAX-REFUND"
        'cv3 = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")


        LiabTotal = LiabTotal + pv - pv2 + cv - cv2 '+ cv3

        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Provision For Taxation"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv - pv2
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "   Add:This year"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Value = pv - pv2 + cv
        DrawUnderline(templateSht, COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = "   Less:Self Assessment Tax Paid This year"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = cv2

        'templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 5)).Value = "   Add:Refund received from Income Tax Dept."
        'templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 5)).Value = cv3

        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = pv - pv2 + cv - cv2 '+ cv3
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Font.Bold = FontStyle.Bold
        sr = sr + 5


        'Provision For Expenses
        an = "PROVISION-FOR-EXPENSE"
        cv = (-1) * getAccountBalanceAsOfDate(curEndDate, an, "NET")
        If cv > 0 Then
            LiabTotal = LiabTotal + cv

            templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Provision for Expenses"
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If
        'Provision For Audit
        an = "PROVISION-FOR-AUDIT-FEE"
        cv = (-1) * getAccountBalanceAsOfDate(curEndDate, an, "NET")
        LiabTotal = LiabTotal + cv

        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Provision for Audit Fees"
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Value = cv
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        sr = sr + 1

        'Net of Maintenance Advance - Maintenance Receivable
        an = "DEBTOR-FLATS"
        cv = (-1) * getAccountBalanceAsOfDate(curEndDate, an, "NET")

        If cv > 0 Then
            LiabTotal = LiabTotal + cv

            templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Advance Received (Less Maintenance Receivable)"
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If


        'PRINT TOTAL
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_END)).Value = LiabTotal
        templateSht.Range(COL_BSTEMPLATE_LIABILITY_AMOUNT2 & (ROW_BSTEMPLATE_DATA_END)).Font.Bold = FontStyle.Bold



        '================================================PRINT ASSET SIDE======================================

        sr = 0

        'General Fund
        an = "FIXED-ASSET-COMP-PERIPHERAL"
        pv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        cv2 = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")
        AssetTotal = AssetTotal + pv + cv - cv2

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Computer & Peripherals"
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "    Add:This year"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Value = pv + cv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = "    Less:Depreciation 60% p.a."
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = cv2
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = pv + cv - cv2
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Font.Bold = FontStyle.Bold
        sr = sr + 5


        'Furniture & Fixture
        an = "FIXED-ASSET-FURNITURE"
        pv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        cv2 = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")
        AssetTotal = AssetTotal + pv + cv - cv2

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Furniture & Fixture"
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "    Add:This year"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Value = pv + cv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = "    Less:Depreciation 10% p.a."
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = cv2
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = pv + cv - cv2
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Font.Bold = FontStyle.Bold
        sr = sr + 5

        'Air Conditioner
        an = "FIXED-ASSET-AC"
        pv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        cv2 = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")
        AssetTotal = AssetTotal + pv + cv - cv2

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Air Conditioner"
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "    Add:This year"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Value = pv + cv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = "    Less:Depreciation 15% p.a."
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = cv2
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = pv + cv - cv2
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Font.Bold = FontStyle.Bold
        sr = sr + 5


        'Electrical Equipments
        an = "FIXED-ASSET-ELECTRICALS"
        pv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        cv2 = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")
        AssetTotal = AssetTotal + pv + cv - cv2

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Electrical Equipments"
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "    Add:This year"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Value = pv + cv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = "    Less:Depreciation 15% p.a."
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = cv2
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = pv + cv - cv2
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Font.Bold = FontStyle.Bold
        sr = sr + 5

        'CC TV & Related Equipments
        an = "FIXED-ASSET-CCTV"
        pv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        cv2 = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")
        AssetTotal = AssetTotal + pv + cv - cv2

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "CCTV & Related Equipments"
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "    Add:This year"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 3)).Value = pv + cv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = "    Less:Depreciation 15% p.a."
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = cv2
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 4), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Value = pv + cv - cv2
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 4)).Font.Bold = FontStyle.Bold
        sr = sr + 5

        'Term Deposit
        an = "TERM-DEPOSIT"
        pv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        'cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        AssetTotal = AssetTotal + pv + cv

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Term Deposit"
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "    Add:This year"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = pv + cv
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Font.Bold = FontStyle.Bold
        sr = sr + 3

        'TDS
        an = "TAX-TDS"
        pv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        'cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        AssetTotal = AssetTotal + pv + cv

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "TDS"
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "    Add:This year"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = pv + cv
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Font.Bold = FontStyle.Bold
        sr = sr + 3


        'an = "TAX-SELF-PAID"
        'pv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        'cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        ''cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        'AssetTotal = AssetTotal + pv + cv

        'templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Self Assessment Tax Paid"
        'templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold

        'templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   As per last a/c"
        'templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = pv
        'templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "    Add:This year"
        'templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv
        'DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        'templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = pv + cv
        'templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Font.Bold = FontStyle.Bold
        'sr = sr + 3

        'Prepaid Maintenance
        an = "DEFERRED-EXP-EAMC"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        an = "DEFERRED-EXP-DG-AMC"
        cv2 = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        AssetTotal = AssetTotal + cv + cv2

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Prepaid Maintenance"
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   Lift"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = cv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "   Generator"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv2
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv + cv2
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Font.Bold = FontStyle.Bold
        sr = sr + 3

        'Cheque in Hand
        an = "CHEQUE-IN-HAND"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        AssetTotal = AssetTotal + cv

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Cheque in Hand"
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Value = cv
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        sr = sr + 1

        'Cash in Hand
        an = "CASH-IN-HAND"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        AssetTotal = AssetTotal + cv

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Cash in Hand"
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Value = cv
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        sr = sr + 1

        'Cash at Bank
        an = "BANK-SIBL0000656053000002552"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        an = "BANK-SIBL0000656073000000009"
        cv2 = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        AssetTotal = AssetTotal + cv + cv2

        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Cash at Bank"
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = "   South Indian Bank Ltd - SB A/C 0656053000002552"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 1)).Value = cv
        templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = "   South Indian Bank Ltd - SB A/C 0656073000000009"
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv2
        DrawUnderline(templateSht, COL_BSTEMPLATE_ASSET_AMOUNT1 & (ROW_BSTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Value = cv + cv2
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr + 2)).Font.Bold = FontStyle.Bold
        sr = sr + 3

        'Net of Maintenance Receivable - Maintenance Advance
        an = "DEBTOR-FLATS"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")

        If cv > 0 Then
            AssetTotal = AssetTotal + cv

            templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Maintenance Receivable (Less Advance)"
            templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Unknown NEFT Deposit at Bank
        an = "NEFT-NOT-RECONCILED"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")

        If cv <> 0 Then
            AssetTotal = AssetTotal + cv

            templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Value = "Unknown NEFT Deposit at Bank"
            templateSht.Range(COL_BSTEMPLATE_ASSET_TEXT & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If


        'PRINT TOTAL
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_END)).Value = AssetTotal
        templateSht.Range(COL_BSTEMPLATE_ASSET_AMOUNT2 & (ROW_BSTEMPLATE_DATA_END)).Font.Bold = FontStyle.Bold

        '==============================================

        xlApp.Visible = True
        templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, getSysParamValue("PATH_TEMP") & "BS" & DateTime.Parse(Now).ToString("_ddMMyy_hhmmss") & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)

        templateWrkBook.Close(False)
        xlApp.Quit()
        releaseObject(xlApp)
        'releaseObject(templateWrkBook)
        'releaseObject(templateSht)


        Exit Sub

errH:
        MsgBox(Err.Description)
        On Error Resume Next
        gcon.RollbackTrans()
        templateWrkBook.Close(False)
        If xlApp IsNot Nothing Then xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)

    End Sub

    'Receipts Payments Report
    Sub genRPReport()
        On Error GoTo errH

        Const COL_RPTEMPLATE_RECEIPTS_TEXT = "B"
        Const COL_RPTEMPLATE_RECEIPTS_AMOUNT1 = "C"
        Const COL_RPTEMPLATE_RECEIPTS_AMOUNT2 = "D"
        Const COL_RPTEMPLATE_PAYMENTS_TEXT = "E"
        Const COL_RPTEMPLATE_PAYMENTS_AMOUNT1 = "F"
        Const COL_RPTEMPLATE_PAYMENTS_AMOUNT2 = "G"

        Const ROW_RPTEMPLATE_DATA_START = 7
        Const ROW_RPTEMPLATE_DATA_END = 62

        Dim ReceiptsTotal As Double, PaymentsTotal As Double
        Dim curStartDate As Long, curEndDate As Long, PrevStartDate As Long, PrevEndDate As Long
        Dim pv As Double = 0, cv As Double = 0, an As String, sr As Integer, cvA As Double, cvP As Double, cv2 As Double = 0, nv As Double = 0, cv3 As Double = 0

        '=========================================
        dlgReportPeriod.ShowDialog()
        dlgReportPeriod.Dispose()
        If dtpFromDateSelected = "" Then Exit Sub
        '=========================================
        curStartDate = DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT)
        curEndDate = DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT)
        PrevEndDate = DateTime.Parse(CDate(dtpFromDateSelected).AddDays(-1)).ToString(DB_DATEFORMAT)
        PrevStartDate = DateTime.Parse(CDate(dtpFromDateSelected).AddYears(-1)).ToString(DB_DATEFORMAT)
    

        'PrevStartDate = "20110622" 'First transaction date in system is of 23-Jun-2011

        If curEndDate = "20130331" Then 'First Year Audit was done for the period between 23/06/2011 to 31/03/2013
            curStartDate = "20110623"
            PrevEndDate = "20110622"
        End If


        '=========================================
        xlApp = New Microsoft.Office.Interop.Excel.Application
        
        templateWrkBook = xlApp.Workbooks.Open(getSysParamValue("TEMPLATEPATH_AUDITREPORT_RP"), False, True)
        templateSht = templateWrkBook.Sheets("active_template")
        templateSht.Select()
        '=========================================
        ReceiptsTotal = 0
        PaymentsTotal = 0
        '=========================================
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START - 4)).Value = "THE PERIOD: " & dtpFromDateSelected & " to " & dtpToDateSelected


        '================================================PRINT RECEIPTS SIDE======================================

        sr = 0

        'OPENING BALANCE
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Opening Balance"
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        sr = sr + 1

        'Cash in Hand
        an = "CASH-IN-HAND"
        cv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        ReceiptsTotal = ReceiptsTotal + cv

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "    Cash in Hand"

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        sr = sr + 1

        'Cheque in Hand
        an = "CHEQUE-IN-HAND"
        cv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        ReceiptsTotal = ReceiptsTotal + cv

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "    Cheque in Hand"

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        sr = sr + 1


        'Cash at Bank
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "    Cash at Bank"

        an = "BANK-SIBL0000656053000002552"
        cv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")

        ReceiptsTotal = ReceiptsTotal + cv

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "        South Indian Bank Ltd - SB A/C 0656053000002552"

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv ' ''- cv2
        sr = sr + 1

        an = "BANK-SIBL0000656073000000009"
        cv2 = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")

        ReceiptsTotal = ReceiptsTotal + cv2

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "        South Indian Bank Ltd - SB A/C 0656073000000009"

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv2 ' ''- cv2
        DrawUnderline(templateSht, COL_RPTEMPLATE_RECEIPTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 1), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

        sr = sr + 1
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv + cv2
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
        sr = sr + 1


        sr = sr + 1
        'Maintenance Collection
        an = "REV-MAINTENANCE"
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        ReceiptsTotal = ReceiptsTotal + cv

        an = "DEBTOR-FLATS"
        cv2 = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")

        ReceiptsTotal = ReceiptsTotal - cv2

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "Maintenance Collection"
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv - cv2
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
        sr = sr + 1

        'TD Received
        an = "BANK-SIBL0000656053000002552"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET", " AND TXNTYPE='TD-2-BANK'")
        ReceiptsTotal = ReceiptsTotal + cv

        an = "BANK-SIBL0000656073000000009"
        cv2 = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET", " AND TXNTYPE='TD-2-BANK'")
        ReceiptsTotal = ReceiptsTotal + cv2

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "Term Deposit Received"
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 2)).Value = "        South Indian Bank Ltd - SB A/C 0656073000002552"
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 2)).Value = cv

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 3)).Value = "        South Indian Bank Ltd - SB A/C 0656053000000009"
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 3)).Value = cv2
        DrawUnderline(templateSht, COL_RPTEMPLATE_RECEIPTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 3), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 4)).Value = cv + cv2
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 4)).Font.Bold = FontStyle.Bold
        sr = sr + 4

        'Misc Collection
        an = "REV-MISC"
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET", " and TxnType <> 'VODAFONE-TAX-ADJUSTMENT'")
        'VODAFONE-TAX-ADJUSTMENT : This is excluded as the Tax is never received in our book before being paid to govt. 
        'This Is a virtual receipt which is reflected in Income in income expenditure report but not in receipt-payment report
        ReceiptsTotal = ReceiptsTotal + cv

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "Misc Collection"
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
        sr = sr + 1

        'Bank Interest excluding Accrued Interest
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "Interest"
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
        sr = sr + 1

        an = "REV-BANK-INTEREST"
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        an = "REV-BANK-INTEREST-ACCRUED"
        cv = cv - (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")

        cv2 = getTDSPaidOnSavingsAccount(curStartDate, curEndDate, "BANK-SIBL0000656073000000009")
        cv2 = cv2 + getTDSPaidOnSavingsAccount(curStartDate, curEndDate, "BANK-SIBL0000656053000002552")

        'include TDS deducted by non-banking entity like Vodafone; assume all such TDS deducted payments are booked against REV-MISC-COLLECTION
        cv2 = cv2 + getTDSPaidOnSavingsAccount(curStartDate, curEndDate, "REV-MISC-COLLECTION")

        'Added tax refund (debited into bank account and credited to TAX-TDS)
        cv2 = cv2 + (-1) * getTaxRefund(curStartDate, curEndDate)

        ReceiptsTotal = ReceiptsTotal + cv - cv2

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "    Interest Received (Saving A/c)"
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv


        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 2)).Value = "    TDS"
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 2)).Value = (-1) * cv2
        DrawUnderline(templateSht, COL_RPTEMPLATE_RECEIPTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 2), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 3)).Value = cv - cv2
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 3)).Font.Bold = FontStyle.Bold
        sr = sr + 3

        'Association Formation Fund
        an = "ASSOCIATION-FORMATION-FUND"
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            ReceiptsTotal = ReceiptsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "Contribution to Association Formation Fund"
            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Misc. Loans received
        an = "MISC-LOAN"
        'cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")
        If cv <> 0 Then
            ReceiptsTotal = ReceiptsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "Received against Loan"
            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If


        'Corpus Fund Org (and any future topup; transfer from general fund is excluded)
        an = "CORPUS-FUND-ORG"
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            ReceiptsTotal = ReceiptsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "Contribution to Corpus Fund"
            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If


        'Income Tax Refund received this FY
        'an = "TAX-REFUND"
        'cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        'If cv <> 0 Then
        '    ReceiptsTotal = ReceiptsTotal + cv

        '    templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "Refund received from Income Tax Dept."
        '    templateSht.Range(COL_RPTEMPLATE_RECEIPTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
        '    templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv
        '    templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Font.Bold = FontStyle.Bold
        '    sr = sr + 1
        'End If

        'PRINT TOTAL
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_END)).Value = ReceiptsTotal
        templateSht.Range(COL_RPTEMPLATE_RECEIPTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_END)).Font.Bold = FontStyle.Bold



        '================================================PRINT PAYMENTS SIDE======================================

        sr = 0

        'Bank Charges
        an = "EXPCUR-BANKCHARGES"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Bank Charges"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Conveyance
        an = "EXPCUR-CONVEYANCE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Conveyance"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Office Expense
        an = "EXPCUR-OFFICE-EXPENSE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Office Expense"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Telephone Charges
        an = "EXPCUR-TELEPHONE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")

        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Telephone Charges"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Electricity Charges
        an = "EXPCUR-ELECTRICITY"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Electricity Charges"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Legal Charges
        an = "EXPCUR-LEGAL"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Legal Charges"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Meeting Expense
        an = "EXPCUR-GBM-MISC"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Meeting Expense"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Insurance Expense
        an = "EXPCUR-INSURANCE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Insurance Expense"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Social Events
        an = "EXPCUR-SOCIAL-EVENTS"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Social Events Expense"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If
        'Computer & Peripherals
        an = "FIXED-ASSET-COMP-PERIPHERAL"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Computer & Peripherals"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Furniture & Fixture
        an = "FIXED-ASSET-FURNITURE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Furniture & Fixture"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Air Conditioner
        an = "FIXED-ASSET-AC"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Air Conditioner"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Electrical Equipments
        an = "FIXED-ASSET-ELECTRICALS"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Electrical Equipments"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'CCTV & Related Equipments
        an = "FIXED-ASSET-CCTV"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "CCTV & Related Equipments"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If


        'EXPCAP (Only used upto 31-Mar-2013)
        an = "EXPCAP"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Misc. Expenses"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Term Deposit
        cv = getTermDepositCreated(curStartDate, curEndDate, "BANK-2-TD")
        PaymentsTotal = PaymentsTotal + cv

        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Term Deposit"
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        sr = sr + 1

        'Audit Fees Paid
        an = "PROVISION-FOR-AUDIT-FEE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR") 'Debit of Audit fee provision will happen when actually the provision is paid out; Audit fees are always paid next year after provisioning in audit year
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Audit Fees Paid"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Self Assessment Tax Paid
        an = "TAX-SELF-PAID"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Self Assessment Tax Paid"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Misc. Loans repaid
        an = "MISC-LOAN"
        'cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        If cv <> 0 Then
            PaymentsTotal = PaymentsTotal + cv

            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Paid as Loan"
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
            templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
            sr = sr + 1
        End If

        'Repair & Maintenance Charges
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Repair & Maintenance Charges"
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold

        an = "EXPCUR-REP-MAINT-CHARGES"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        nv = cv


        an = "DEFERRED-EXPENSE"
        cv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        nv = nv - cv

        an = "CHEQUE-ISSUED-0009"
        cv2 = (-1) * getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        an = "CHEQUE-ISSUED-2552"
        cv3 = (-1) * getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        nv = nv + cv2 + cv3


        an = "DEFERRED-EXPENSE"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        nv = nv + cv


        an = "DEFERRED-LIAB" ' "DEFERRED-EXPENSE"
        cv = getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        nv = nv - cv


        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        nv = nv + cv


        an = "CHEQUE-ISSUED-0009"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        nv = nv + cv


        an = "CHEQUE-ISSUED-2552"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        nv = nv + cv


        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = nv
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        'sr = sr + 2

        PaymentsTotal = PaymentsTotal + nv

        sr = sr + 1
        'Cheque in Hand
        an = "CHEQUE-IN-HAND"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        PaymentsTotal = PaymentsTotal + cv

        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Cheque in Hand"
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        sr = sr + 1

        'Cash in Hand
        an = "CASH-IN-HAND"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")
        PaymentsTotal = PaymentsTotal + cv

        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Cash in Hand"
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Value = cv
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold
        sr = sr + 1

        'Cash at Bank
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Value = "Cash at Bank"
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr)).Font.Bold = FontStyle.Bold

        '=====

        an = "BANK-SIBL0000656053000002552"
        cv = getAccountBalanceAsOfDate(curEndDate, an, "NET")

        PaymentsTotal = PaymentsTotal + cv

        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "        South Indian Bank Ltd - SB A/C 0656053000002552"
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv

        sr = sr + 1

        an = "BANK-SIBL0000656073000000009"
        cv2 = getAccountBalanceAsOfDate(curEndDate, an, "NET")

        PaymentsTotal = PaymentsTotal + cv2

        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_TEXT & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = "        South Indian Bank Ltd - SB A/C 0656073000000009"
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 1)).Value = cv2
        DrawUnderline(templateSht, COL_RPTEMPLATE_PAYMENTS_AMOUNT1 & (ROW_RPTEMPLATE_DATA_START + sr + 1), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 2)).Value = cv + cv2  ' - cv2
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_START + sr + 2)).Font.Bold = FontStyle.Bold

        sr = sr + 2


        'PRINT TOTAL
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_END)).Value = PaymentsTotal
        templateSht.Range(COL_RPTEMPLATE_PAYMENTS_AMOUNT2 & (ROW_RPTEMPLATE_DATA_END)).Font.Bold = FontStyle.Bold

        '==============================================
        xlApp.Visible = True
        templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, getSysParamValue("PATH_TEMP") & "RP" & DateTime.Parse(Now).ToString("_ddMMyy_hhmmss") & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)

        templateWrkBook.Close(False)
        xlApp.Quit()
        releaseObject(xlApp)
        'releaseObject(templateWrkBook)
        'releaseObject(templateSht)


        Exit Sub

errH:
        MsgBox(Err.Description)
        On Error Resume Next
        gcon.RollbackTrans()
        templateWrkBook.Close(False)
        If xlApp IsNot Nothing Then xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)

    End Sub


    Sub genIEReport()
        On Error GoTo errH

        Const COL_IETEMPLATE_EXPENDITURE_TEXT = "B"
        Const COL_IETEMPLATE_EXPENDITURE_AMOUNT1 = "C"
        Const COL_IETEMPLATE_EXPENDITURE_AMOUNT2 = "D"
        Const COL_IETEMPLATE_INCOME_TEXT = "E"
        Const COL_IETEMPLATE_INCOME_AMOUNT1 = "F"
        Const COL_IETEMPLATE_INCOME_AMOUNT2 = "G"

        Const ROW_IETEMPLATE_DATA_START = 7
        Const ROW_RPTEMPLATE_DATA_END = 62

        Dim ExpenditureTotal As Double, IncomeTotal As Double
        Dim curStartDate As Long, curEndDate As Long, PrevStartDate As Long, PrevEndDate As Long
        Dim pv As Double = 0, cv As Double = 0, cv1 As Double = 0, cv2 As Double = 0, cv3 As Double = 0, an As String, sr As Integer, cvA As Double, cvP As Double, nv As Double = 0

        '=========================================
        dlgReportPeriod.ShowDialog()
        dlgReportPeriod.Dispose()
        If dtpFromDateSelected = "" Then Exit Sub
        '=========================================
        curStartDate = DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT)
        curEndDate = DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT)
        PrevEndDate = DateTime.Parse(CDate(dtpFromDateSelected).AddDays(-1)).ToString(DB_DATEFORMAT)
        PrevStartDate = DateTime.Parse(CDate(dtpFromDateSelected).AddYears(-1)).ToString(DB_DATEFORMAT)
        'lFinYear.SetToFinYearByDate(curEndDate)
        'curStartDate = lFinYear.startDate

        'PrevStartDate = "20110622" 'First transaction date in system is of 23-Jun-2011
        'PrevEndDate = (lFinYear.endYear - 1) & "0331"

        If curEndDate = "20130331" Then 'First Year Audit was done for the period between 23/06/2011 to 31/03/2013
            curStartDate = "20110623"
            PrevEndDate = "20110622"
        End If


        '=========================================
        xlApp = New Microsoft.Office.Interop.Excel.Application
       
        templateWrkBook = xlApp.Workbooks.Open(getSysParamValue("TEMPLATEPATH_AUDITREPORT_IE"), False, True)
        templateSht = templateWrkBook.Sheets("active_template")
        templateSht.Select()
        '=========================================
        ExpenditureTotal = 0
        IncomeTotal = 0
        '=========================================
        templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (ROW_IETEMPLATE_DATA_START - 4)).Value = "THE PERIOD: " & dtpFromDateSelected & " to " & dtpToDateSelected


        '================================================PRINT EXPENSITURE SIDE======================================

        Dim esr As Integer = ROW_IETEMPLATE_DATA_START
        ExpenditureTotal = 0

        'Bank Charges
        an = "EXPCUR-BANKCHARGES"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            ExpenditureTotal = ExpenditureTotal + cv

            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Bank Charges"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
            esr = esr + 1
        End If

        'Conveyance
        an = "EXPCUR-CONVEYANCE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            ExpenditureTotal = ExpenditureTotal + cv

            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Conveyance"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
            esr = esr + 1
        End If

        'Office Expense
        an = "EXPCUR-OFFICE-EXPENSE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            ExpenditureTotal = ExpenditureTotal + cv

            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Office Expense"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
            esr = esr + 1
        End If

        'Telephone Charges
        an = "EXPCUR-TELEPHONE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")

        If cv <> 0 Then
            ExpenditureTotal = ExpenditureTotal + cv

            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Telephone Charges"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
            esr = esr + 1
        End If

        'Electricity Charges
        an = "EXPCUR-ELECTRICITY"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        If cv <> 0 Then
            ExpenditureTotal = ExpenditureTotal + cv

            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Electricity Charges"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
            esr = esr + 1
        End If

        'Legal Charges
        an = "EXPCUR-LEGAL"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        ExpenditureTotal = ExpenditureTotal + cv
        If cv <> 0 Then
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Legal Charges"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
            esr = esr + 1
        End If

        'Meeting Expense
        an = "EXPCUR-GBM-MISC"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        ExpenditureTotal = ExpenditureTotal + cv
        If cv <> 0 Then
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Meeting Expense"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
            esr = esr + 1
        End If

        'Insurance Expense
        an = "EXPCUR-INSURANCE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        ExpenditureTotal = ExpenditureTotal + cv
        If cv <> 0 Then
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Insurance Expense"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
            esr = esr + 1
        End If

        'Social Events Expense
        an = "EXPCUR-SOCIAL-EVENTS"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        ExpenditureTotal = ExpenditureTotal + cv
        If cv <> 0 Then
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Social Events Expense"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
            esr = esr + 1
        End If

        'Repair & Maintenance Charges (Only Current Year Expense is shown in IE report)
        an = "EXPCUR-REP-MAINT-CHARGES"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        ExpenditureTotal = ExpenditureTotal + cv

        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Repair & Maintenance Charges"
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
        esr = esr + 1

        'EXPCAP (Only used upto 31-Mar-2013)
        an = "EXPCAP"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        ExpenditureTotal = ExpenditureTotal + cv
        If cv <> 0 Then
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Misc. Expenses"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
            esr = esr + 1
        End If
        'Depreciation
        an = "EXP-DEPRECIATION"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        ExpenditureTotal = ExpenditureTotal + cv

        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Depreciation"
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
        esr = esr + 1

        'Audit Fees Paid
        an = "PROVISION-FOR-AUDIT-FEE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR") 'Show only what is provisioned 

        ExpenditureTotal = ExpenditureTotal + cv

        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Provision for Audit Fees"
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
        esr = esr + 1


        'Provision For Taxation
        an = "PROVISION-FOR-TAX"
        pv = (-1) * getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        ExpenditureTotal = ExpenditureTotal + cv

        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Provision For Taxation"
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
        esr = esr + 1

        'If curStartDate < 20170401 Then 'Changed from FY17-18: Earlier, auditor missed to note that this should not appera in Expense side in IE report. Hence corrected from next FY.

        'Provision For Expenses
        an = "PROVISION-FOR-EXPENSE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")
        ExpenditureTotal = ExpenditureTotal + cv
        If cv > 0 Then
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Value = "Provision for Expenses"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr)).Font.Bold = FontStyle.Bold
            esr = esr + 1
        End If

        'End If


        DrawUnderline(templateSht, COL_IETEMPLATE_EXPENDITURE_AMOUNT1 & (esr - 1), Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT2 & (esr)).Value = ExpenditureTotal
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT2 & (esr)).Font.Bold = FontStyle.Bold
        esr = esr + 1
        '================================================PRINT INCOME SIDE======================================

        Dim isr As Integer = ROW_IETEMPLATE_DATA_START
        IncomeTotal = 0

        'Maintenance Collection (only for current year without considering outstanding/advance
        an = "REV-MAINTENANCE"
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        IncomeTotal = IncomeTotal + cv

        templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr)).Value = "Maintenance Collection"
        templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (isr)).Value = cv
        templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (isr)).Font.Bold = FontStyle.Bold
        isr = isr + 1


        'Provision For Expenses
        an = "PROVISION-FOR-EXPENSE"
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
        IncomeTotal = IncomeTotal + cv
        If cv > 0 Then
            templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (esr)).Value = "Adjustment of Prov for Exp (Last yr)"
            templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (esr)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (esr)).Value = cv
            templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (esr)).Font.Bold = FontStyle.Bold
            isr = isr + 1
        End If

        'Misc Collection
        an = "REV-MISC"
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        IncomeTotal = IncomeTotal + cv

        templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr)).Value = "Misc Collection"
        templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr)).Font.Bold = FontStyle.Bold
        templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (isr)).Value = cv
        templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (isr)).Font.Bold = FontStyle.Bold
        isr = isr + 1

        'Interest
        templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr)).Value = "Interest"
        templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr)).Font.Bold = FontStyle.Bold
        isr = isr + 1

        an = "REV-BANK-INTEREST"
        cv = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")

        an = "REV-BANK-INTEREST-SAV"
        cv1 = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        an = "REV-BANK-INTEREST-TD"
        cv2 = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")
        an = "REV-BANK-INTEREST-ACCRUED"
        cv3 = (-1) * getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "NET")

        IncomeTotal = IncomeTotal + cv

        templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr)).Value = " Interest (Savings A/C)"
        templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT1 & (isr)).Value = cv1
        isr = isr + 1

        templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr)).Value = " Interest (Term Deposit)"
        templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT1 & (isr)).Value = cv2
        isr = isr + 1

        templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr)).Value = " Interest (Accrued)"
        templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT1 & (isr)).Value = cv3
        isr = isr + 1

        If (cv - cv1 - cv2 - cv3) <> 0 Then
            templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr)).Value = " Interest (Other)"
            templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT1 & (isr)).Value = cv - cv1 - cv2 - cv3
            isr = isr + 1
        End If

        templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (isr)).Value = cv
        templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (isr)).Font.Bold = FontStyle.Bold
        '==============================================
        If IncomeTotal > ExpenditureTotal Then
            'Excess of Income Over Expenditure
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr + 1)).Value = "Excess of Income Over Expenditure"
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_TEXT & (esr + 1)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT2 & (esr + 1)).Value = IncomeTotal - ExpenditureTotal
            templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT2 & (esr + 1)).Font.Bold = FontStyle.Bold
            ExpenditureTotal = IncomeTotal
        Else
            templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr + 1)).Value = "Excess of Expenditure Over Income"
            templateSht.Range(COL_IETEMPLATE_INCOME_TEXT & (isr + 1)).Font.Bold = FontStyle.Bold
            templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (isr + 1)).Value = ExpenditureTotal - IncomeTotal
            templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (isr + 1)).Font.Bold = FontStyle.Bold
            IncomeTotal = ExpenditureTotal
        End If
        '==============================================
        If esr < ROW_RPTEMPLATE_DATA_END Then
            esr = ROW_RPTEMPLATE_DATA_END
        Else
            esr = esr + 1
        End If
        If esr < isr Then
            esr = isr + 1
        End If
        'PRINT TOTAL
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT2 & (esr)).Value = ExpenditureTotal
        templateSht.Range(COL_IETEMPLATE_EXPENDITURE_AMOUNT2 & (esr)).Font.Bold = FontStyle.Bold
        'PRINT TOTAL
        templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (esr)).Value = IncomeTotal
        templateSht.Range(COL_IETEMPLATE_INCOME_AMOUNT2 & (esr)).Font.Bold = FontStyle.Bold
        '==============================================
        xlApp.Visible = True
        templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, getSysParamValue("PATH_TEMP") & "IE" & DateTime.Parse(Now).ToString("_ddMMyy_hhmmss") & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)

        templateWrkBook.Close(False)
        xlApp.Quit()
        releaseObject(xlApp)
        'releaseObject(templateWrkBook)
        'releaseObject(templateSht)


        Exit Sub

errH:
        MsgBox(Err.Description)
        On Error Resume Next
        gcon.RollbackTrans()
        templateWrkBook.Close(False)
        If xlApp IsNot Nothing Then xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)

    End Sub
End Class
