Public Class frmPerformBilling

    Private Sub frmPerformBilling_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboFlatCode.DataSource = FLATS
        cboFlatCode.Enabled = False
        chkIndividualReBilling.Checked = False

        cboFromMonth.SelectedIndex = DateTime.Now.ToString("MM") - 1
        cboToMonth.SelectedIndex = DateTime.Now.ToString("MM") - 1

        cboFromYear.Items.Clear()
        cboFromYear.Items.Add(DateTime.Now.ToString("yyyy") - 1)
        cboFromYear.Items.Add(DateTime.Now.ToString("yyyy"))
        cboFromYear.Items.Add(DateTime.Now.ToString("yyyy") + 1)
        cboFromYear.SelectedIndex = 1

        dtpBillDate.Text = DateTime.Now.ToString("dd-MMM-yyyy")
        dtpDueDate.Text = DateTime.DaysInMonth(Year(DateTime.Now), Month(DateTime.Now)) & MonthName(Month(DateTime.Now), True) & Year(DateTime.Now)

        txtTemplateExcelPath.Text = getSysParamValue("PATH_BILLING_TEMPLATE")
        txtLineItemText.Text = "Being the proportionate share of consolidated maintenance cost in respect of your apartment's chargeable area for the month of "
        txtBillOutputPath.Text = getSysParamValue("PATH_BILL_OUTPUT") & cboFromMonth.Text & "-" & cboFromYear.Text
        txtBillRate.Text = getSysParamValue("SQFTRATE")
        btnPerformBilling.Enabled = True
        pbarBilling.Minimum = 0
        pbarBilling.Maximum = 272
        pbarBilling.Value = 0
        pbarBilling.Step = 1
    End Sub
    Private Sub btnPerformBilling_Click(sender As System.Object, e As System.EventArgs) Handles btnPerformBilling.Click
        If IsNumeric(txtBillRate.Text) = False Then
            MsgBox("Invalid Billing Rate")
            Exit Sub
        End If
        If chkAddLine2.Checked = True Then
            If IsNumeric(txtLineAmt2.Text) = False Then
                MsgBox("Invalid Amount for Additional Line")
                Exit Sub
            End If
        End If
        If MsgBox("Confirm", vbOKCancel) = vbCancel Then Exit Sub
        btnCancel.Enabled = False
        btnSimulate.Enabled = False
        pbarBilling.Value = 0
        frmMain.sslabel3.Text = "Billing in progress"

        If generateBilling(False) = True Then
            frmMain.sslabel3.Text = "Billing completed successfully"
            btnPerformBilling.Enabled = False
        End If
        btnSimulate.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub btnSimulate_Click(sender As System.Object, e As System.EventArgs) Handles btnSimulate.Click
        btnCancel.Enabled = False
        pbarBilling.Value = 0
        frmMain.sslabel3.Text = "Billing simulation in progress"

        If generateBilling(True) = True Then
            btnPerformBilling.Enabled = True
            frmMain.sslabel3.Text = "Simulation of billing completed successfully"
            txtBillOutputPath.Enabled = False
            txtBillRate.Enabled = False
            txtLineItemText.Enabled = False
            txtTemplateExcelPath.Enabled = False
            cboFromMonth.Enabled = False
            cboFromYear.Enabled = False
            cboToMonth.Enabled = False
        End If
        btnCancel.Enabled = True
    End Sub
    Function generateBilling(isSimulation As Boolean) As Boolean
        On Error GoTo errH

        Dim billFromMonthNum As String, billToMonthNum As String, billFromMonth As String, billToMonth As String, billDate As String, dueDate As String, billYear As String, billToYear As String, billNo As String
        Dim dueDateLineText As String, lineItemText As String, billPath As String, finalpath As String
        Dim shortFlatNo As String, billPeriod As String, towerName As String, billTo As String, billLine As Integer
        Dim chargeableArea As Double, perMonthBillAmt As Double, NetBillAmt As Double, billRate As Double
        Dim billRS As ADODB.Recordset, tmpRS1 As ADODB.Recordset
        Dim journalSql As String, bhSql As String, billSql As String, gid As String = "", tmpSql As String = "", p_email1 As String, p_softBill As String = ""
        Dim templateShtName As String
        Dim LastBillingDate As String, tmpDocRef As String, tmpFlatStr As String

        Dim oldFromMonth As Integer, oldToMonth As Integer, oldFromYear As Integer, oldToYear As Integer, oldBillPeriod As String

        generateBilling = False

        gcon.BeginTrans()

        'Prepare items
        billFromMonthNum = myRight("0" & (cboFromMonth.SelectedIndex + 1), 2)
        billToMonthNum = myRight("0" & (cboToMonth.SelectedIndex + 1), 2)
        billFromMonth = cboFromMonth.Text
        billToMonth = cboToMonth.Text
        billYear = cboFromYear.Text
        billToYear = billYear
        billRate = txtBillRate.Text
        billPath = txtBillOutputPath.Text
        If isSimulation = True Then billPath = txtBillOutputPath.Text & "\Simulate-deleteMe"
        billPeriod = billFromMonth & "-" & billYear

        If CInt(billFromMonthNum) > CInt(billToMonthNum) Then
            billToYear = CInt(billYear) + 1
            billPeriod = billPeriod & " to " & billToMonth & "-" & billToYear
        ElseIf CInt(billFromMonthNum) < CInt(billToMonthNum) Then
            billPeriod = billPeriod & " to " & billToMonth & "-" & billYear
        End If


        '*************Check if Billing already done***************
        Dim x As Integer, bhRS As ADODB.Recordset

        If chkIndividualReBilling.Checked = False Then


            If billToYear > billYear Then
                For x = billFromMonthNum To 12
                    bhSql = "select * from tblbillinghistory where BillingDone='Y' and BillMonth=" & x & " and BillYear=" & billYear
                    bhRS = gcon.Execute(bhSql)
                    If bhRS.EOF = False Then
                        MsgBox("Billing already done for " & MonthName(x) & "'" & billYear & " on " & formatInt2Date(bhRS("BillingDate").Value.ToString))
                        bhRS.Close()
                        GoTo errH
                    End If
                Next x
                For x = 1 To billToMonthNum
                    bhSql = "select * from tblbillinghistory where BillingDone='Y' and BillMonth=" & x & " and BillYear=" & billToYear
                    bhRS = gcon.Execute(bhSql)
                    If bhRS.EOF = False Then
                        MsgBox("Billing already done for " & MonthName(x) & "'" & billToYear & " on " & formatInt2Date(bhRS("BillingDate").Value.ToString))
                        bhRS.Close()
                        GoTo errH
                    End If
                Next x
            Else
                For x = billFromMonthNum To billToMonthNum
                    bhSql = "select * from tblbillinghistory where BillingDone='Y' and BillMonth=" & x & " and BillYear=" & billYear
                    bhRS = gcon.Execute(bhSql)
                    If bhRS.EOF = False Then
                        MsgBox("Billing already done for " & MonthName(x) & "'" & billYear & " on " & formatInt2Date(bhRS("BillingDate").Value.ToString))
                        bhRS.Close()
                        GoTo errH
                    End If
                Next x
            End If

        End If

        'Get last billing date
        bhSql = "select max(BillingDate) as lastBillingDate from tblbillinghistory where BillingDone='Y' "
        bhRS = gcon.Execute(bhSql)
        If bhRS("lastBillingDate").Value.ToString <> "" Then
            LastBillingDate = bhRS("lastBillingDate").Value.ToString
        Else
            LastBillingDate = DateTime.Parse("01-01-2012").ToString(DB_DATEFORMAT)
        End If
        bhRS.Close()
        '*********************************************************


        '*********************************************************
        gItemCode = "Perform Billing"
        gItemID = billPeriod
        gItemAction = "Billing"
        If logUserActivity() = False Then GoTo errH
        '*********************************************************

        billDate = dtpBillDate.Text
        dueDate = dtpDueDate.Text
        dueDateLineText = "Due Date: Within " & dueDate

        billRS = gcon.Execute("select * from tblFlats")
        If billRS.EOF = True Then
            MsgBox("tblFlat table corrupted. Contact System Administrator.")
            GoTo errH
        End If

        xlApp = New Microsoft.Office.Interop.Excel.Application
        'xlApp.Visible = True
        'xlApp.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
        If System.IO.Directory.Exists(getSysParamValue("PATH_BILL_PRINT") & "_" & billPeriod) = False Then System.IO.Directory.CreateDirectory(getSysParamValue("PATH_BILL_PRINT") & "_" & billPeriod) 'WILL CREATE THE LAST SUB DIR - MAKE SURE REST EXIST, NEED TO CREATE A SUB SIMILAR TO SOLARIS mkdir -p

        While billRS.EOF = False

            If chkIndividualReBilling.Checked = True Then
                gCurFlatCode = billRS("FlatCode").Value.ToString
                While (gCurFlatCode <> cboFlatCode.Text) And (billRS.EOF = False)
                    billRS.MoveNext()
                    gCurFlatCode = billRS("FlatCode").Value.ToString

                End While
                If gCurFlatCode <> cboFlatCode.Text Then
                    MsgBox("Flat Code " & cboFlatCode.Text & " not found")
                    GoTo errH
                End If
            End If


            '--------------------------------------------------------------------------------------------------
            towerName = billRS("TowerName").Value.ToString
            gCurFlatCode = billRS("FlatCode").Value.ToString
            lblFlatCode.Text = gCurFlatCode
            shortFlatNo = myRight(gCurFlatCode, 3)
            If myLeft(shortFlatNo, 1) = "0" Then shortFlatNo = myRight(shortFlatNo, 2)

            chargeableArea = billRS("SBUSqFtArea").Value.ToString + 0.5 * (billRS("TerraceSqFtArea").Value.ToString)
            perMonthBillAmt = Math.Round(billRate * chargeableArea, 2)
            NetBillAmt = Math.Round((billToMonthNum - billFromMonthNum + 1) * perMonthBillAmt, 0)

            '--------------------------------------------------------------------------------------------------
            'Create Bill No Example: SAN-1A-2012-05 / SAN-11A-2012-10
            billNo = myLeft(gCurFlatCode, 3) & "-" & shortFlatNo & "-" & billYear & "-" & billFromMonthNum
            If billFromMonthNum <> billToMonthNum Then billNo = billNo & "-" & billToMonthNum
            '--------------------------------------------------------------------------------------------------
            tmpRS1 = gcon.Execute("select OwnerFullName,CoOwnerFullName,PrimaryEmail,p_email1,p_softBill from tblflatowners where IsActiveOwner='Y' and FlatCode='" & gCurFlatCode & "'")
            If tmpRS1.EOF = True Then
                MsgBox("No active owner defined in tblflatowners table for flat code :" & gCurFlatCode & ". Contact System Administrator.")
                GoTo errH
            End If
            billTo = tmpRS1("OwnerFullName").Value.ToString
            If tmpRS1("CoOwnerFullName").Value.ToString <> "" Then billTo = billTo & "  " & tmpRS1("CoOwnerFullName").Value.ToString
            billTo = tmpRS1("OwnerFullName").Value.ToString
            If tmpRS1("CoOwnerFullName").Value.ToString <> "" Then billTo = billTo & "  " & tmpRS1("CoOwnerFullName").Value.ToString


            p_softBill = tmpRS1("p_softBill").Value.ToString
            p_email1 = tmpRS1("p_email1").Value.ToString
            If InStr(1, p_email1, "@") = 0 Then p_email1 = tmpRS1("PrimaryEmail").Value.ToString
            
            tmpRS1.Close()
            '--------------------------------------------
            Dim paintOption As String = "", paintExpenseDesc As String = "", paintAmount As Double = 0, paintBillMonthNo As Integer
            '--------------------------------------------------------------------------------------------------
            tmpRS1 = gcon.Execute("select PaymentOption from tblpaintpaymentoption where FlatCode='" & gCurFlatCode & "'")
            If tmpRS1.EOF = True Then
                paintOption = "C"
            Else
                paintOption = tmpRS1("PaymentOption").Value.ToString
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------------------
            templateShtName = "active_template"
            If paintOption = "A" Then
                templateShtName = "active_template_paint"
            ElseIf paintOption = "B" Then
                templateShtName = "active_template_paint"
            ElseIf paintOption = "C" Then
                templateShtName = "active_template_paint"
            End If
            If p_softBill = "Y" Then
                templateShtName = templateShtName & "_green"
            End If

            templateWrkBook = xlApp.Workbooks.Open(txtTemplateExcelPath.Text, False, True)
            templateSht = templateWrkBook.Sheets(templateShtName)
            templateSht.Select()


            '--------------------------------------------------------------------------------------------------
            'create the bill excel from master template

            templateSht.Range(RANGE_Template_BillDate).Value = billDate
            templateSht.Range(RANGE_Template_BillNum).Value = billNo
            templateSht.Range(RANGE_Template_Period).Value = billPeriod
            templateSht.Range(RANGE_Template_NAME).Value = billTo
            templateSht.Range(RANGE_Template_EMAIL).Value = p_email1
            templateSht.Range(RANGE_Template_TOWER).Value = towerName
            templateSht.Range(RANGE_Template_FLAT).Value = UCase(shortFlatNo)

            templateSht.Range(RANGE_Template_DueDate).Value = dtpDueDate.Text


            For billLine = billFromMonthNum To billToMonthNum 'below code sectins may not support multiple month billing. If multiple month billing is needed in future, review the below code (row numbers) and adjust
                templateSht.Range(myLeft(RANGE_Template_Table_R1C2, 1) & (myRight(RANGE_Template_Table_R1C2, 2) + billLine - billFromMonthNum)).Value = chargeableArea
                templateSht.Range(myLeft(RANGE_Template_Table_R1C3, 1) & (myRight(RANGE_Template_Table_R1C3, 2) + billLine - billFromMonthNum)).Value = billRate
                templateSht.Range(myLeft(RANGE_Template_Table_R1C4, 1) & (myRight(RANGE_Template_Table_R1C4, 2) + billLine - billFromMonthNum)).Value = Math.Round(perMonthBillAmt, 0)
            Next
            If paintOption <> "" Then
                templateSht.Range(RANGE_Template_Table_R2C2).Value = "Not Applicable"
                paintBillMonthNo = Math.Round(DateDiff(DateInterval.Day, DateTime.Parse("31-Mar-2016"), DateTime.Parse(dtpDueDate.Text)) / 31, 0)
                If (paintOption = "A") And (paintBillMonthNo = 1) Then
                    paintExpenseDesc = "Being the proportionate share of maintenance expense for building painting and associated works as agreed in GBM dtd.31.01.2016 and notified on 03.02.2016. Payment Option A (One time:Single Installment)"
                    paintAmount = 13236
                    templateSht.Range(RANGE_Template_Table_R2C1).Value = paintExpenseDesc
                    templateSht.Range(RANGE_Template_Table_R2C4).Value = paintAmount
                ElseIf (paintOption = "B") And ((paintBillMonthNo = 1) Or (paintBillMonthNo = 13)) Then
                    paintExpenseDesc = "Being the proportionate share of maintenance expense for building painting and associated works as agreed in GBM dtd.31.01.2016 and notified on 03.02.2016. Payment Option B (Yearly: First Installment)"
                    paintAmount = 6985
                    templateSht.Range(RANGE_Template_Table_R2C1).Value = paintExpenseDesc
                    templateSht.Range(RANGE_Template_Table_R2C4).Value = paintAmount
                ElseIf (paintOption = "C") And (paintBillMonthNo <= 24) Then
                    paintExpenseDesc = "Being the proportionate share of maintenance expense for building painting and associated works as agreed in GBM dtd.31.01.2016 and notified on 03.02.2016. Payment Option C (Monthly)  [Installment " & paintBillMonthNo & " of 24]"
                    paintAmount = 613
                    templateSht.Range(RANGE_Template_Table_R2C1).Value = paintExpenseDesc
                    templateSht.Range(RANGE_Template_Table_R2C4).Value = paintAmount
                End If

            End If

            If chkAddLine2.Checked = True Then
                If paintOption <> "" Then
                    templateSht.Range(RANGE_Template_Table_R3C1).Value = txtLineItem2Desc.Text
                    templateSht.Range(RANGE_Template_Table_R3C2).Value = "Not Applicable"
                    templateSht.Range(RANGE_Template_Table_R3C4).Value = txtLineAmt2.Text
                Else
                    templateSht.Range(RANGE_Template_Table_R2C1).Value = txtLineItem2Desc.Text
                    templateSht.Range(RANGE_Template_Table_R2C2).Value = "Not Applicable"
                    templateSht.Range(RANGE_Template_Table_R2C4).Value = txtLineAmt2.Text
                End If
            End If


            NetBillAmt = Math.Round(NetBillAmt + paintAmount, 0)

            If chkAddLine2.Checked = True Then
                NetBillAmt = Math.Round(NetBillAmt + txtLineAmt2.Text, 0)
            End If

                templateSht.Range(RANGE_Template_TotalBillAmount).Value = NetBillAmt

                'templateSht.Name = billNo
                '*****************************************************************************************************
                '*************************************SECOND PAGE - ADDITIONAL DETAILS********************************

                'FIND NO OF PENALTY LINES SINCE LAST BILLING DATE
                '--------------------------------------------------------------------------------------------------
                Dim curRow As Integer, nRows As Integer, srlNo As Integer, curDocRef As String
                tmpSql = "select count(*) cnt from tbljournal where Status is null and TxnType ='MAINT-BILL-PENALTY' and CrAmount > 0 and AccountNo like '%" & gCurFlatCode & "' "
                tmpSql = tmpSql & " and TxnDate > '" & LastBillingDate & "' and TxnDate <= '" & DateTime.Parse(billDate).ToString(DB_DATEFORMAT) & "'"
                tmpRS1 = gcon.Execute(tmpSql)
                nRows = tmpRS1("cnt").Value.ToString
                tmpRS1.Close()

                curRow = TEMPLATE_SHT_2ND_PAGE_STARTROW + 4

                If nRows > 1 Then
                    'make additional rows
                    templateSht.Rows(curRow & ":" & curRow).Select()
                    xlApp.Selection.copy()
                    templateSht.Rows(curRow + 1 & ":" & curRow + nRows - 1).Select()
                    xlApp.Selection.Insert(Shift:=Microsoft.Office.Interop.Excel.XlDirection.xlDown)
                    My.Computer.Clipboard.Clear()
                End If


                If nRows > 0 Then
                    tmpSql = "select * from tbljournal where Status is null and TxnType ='MAINT-BILL-PENALTY' and CrAmount > 0 and AccountNo like '%" & gCurFlatCode & "' "
                    tmpSql = tmpSql & " and TxnDate > '" & LastBillingDate & "' and TxnDate <= '" & DateTime.Parse(billDate).ToString(DB_DATEFORMAT) & "'"
                    tmpRS1 = gcon.Execute(tmpSql)

                    curRow = curRow - 1
                    srlNo = 0
                    While tmpRS1.EOF = False
                        curRow = curRow + 1
                        srlNo = srlNo + 1
                        templateSht.Range("B" & curRow).Value = srlNo

                        tmpDocRef = tmpRS1("DocRef").Value.ToString
                        tmpFlatStr = ", Payee:" & gCurFlatCode & ")"
                        tmpDocRef = Replace(tmpDocRef, tmpFlatStr, "")
                        tmpFlatStr = ",Payee:" & gCurFlatCode & ")"
                        tmpDocRef = Replace(tmpDocRef, tmpFlatStr, "")
                        tmpDocRef = Replace(tmpDocRef, "(", "")

                        templateSht.Range("C" & curRow).Value = Trim(tmpDocRef)
                        templateSht.Range("P" & curRow).Value = addThousandSeparator(tmpRS1("CrAmount").Value.ToString, False)

                        tmpRS1.MoveNext()
                    End While
                    tmpRS1.Close()
                End If

                'FIND NO OF Other Charges LINES SINCE LAST BILLING DATE (Example: Cheque bounce charge)
                '--------------------------------------------------------------------------------------------------
                'Dim curRow As Integer, nRows As Integer
                tmpSql = "select count(*) cnt from tbljournal where Status is null and TxnType ='MAINT-BILL-OTHER-CHARGES' and CrAmount > 0 and AccountNo like '%" & gCurFlatCode & "' "
                tmpSql = tmpSql & " and TxnDate > '" & LastBillingDate & "' and TxnDate <= '" & DateTime.Parse(billDate).ToString(DB_DATEFORMAT) & "'"
                tmpRS1 = gcon.Execute(tmpSql)
                nRows = tmpRS1("cnt").Value.ToString
                tmpRS1.Close()

                curRow = curRow + 4

                If nRows > 1 Then
                    'make additional rows
                    templateSht.Rows(curRow & ":" & curRow).Select()
                    xlApp.Selection.copy()
                    templateSht.Rows(curRow + 1 & ":" & curRow + nRows - 1).Select()
                    xlApp.Selection.Insert(Shift:=Microsoft.Office.Interop.Excel.XlDirection.xlDown)
                    My.Computer.Clipboard.Clear()
                End If


                If nRows > 0 Then
                    tmpSql = "select * from tbljournal where Status is null and TxnType ='MAINT-BILL-OTHER-CHARGES' and CrAmount > 0 and AccountNo like '%" & gCurFlatCode & "' "
                    tmpSql = tmpSql & " and TxnDate > '" & LastBillingDate & "' and TxnDate <= '" & DateTime.Parse(billDate).ToString(DB_DATEFORMAT) & "'"
                    tmpRS1 = gcon.Execute(tmpSql)

                    srlNo = 0
                    curRow = curRow - 1
                    While tmpRS1.EOF = False
                        curRow = curRow + 1
                        srlNo = srlNo + 1
                        templateSht.Range("B" & curRow).Value = srlNo

                        tmpDocRef = tmpRS1("DocRef").Value.ToString
                        tmpFlatStr = ", Payee:" & gCurFlatCode & ")"
                        tmpDocRef = Replace(tmpDocRef, tmpFlatStr, "")
                        tmpFlatStr = ",Payee:" & gCurFlatCode & ")"
                        tmpDocRef = Replace(tmpDocRef, tmpFlatStr, "")
                        tmpDocRef = Replace(tmpDocRef, "(", "")

                        templateSht.Range("C" & curRow).Value = tmpRS1("Narration").Value.ToString & ", " & Trim(tmpDocRef)
                        templateSht.Range("P" & curRow).Value = addThousandSeparator(tmpRS1("CrAmount").Value.ToString, False)

                        tmpRS1.MoveNext()
                    End While
                    tmpRS1.Close()
                End If

                'Print the last 3 bills
                '--------------------------------------------------------------------------------------------------
                curRow = curRow + 4

                tmpSql = "select * from tblbill where FlatCode = '" & gCurFlatCode & "' and BillDate < " & DateTime.Parse(billDate).ToString(DB_DATEFORMAT) & " order by BillDate desc"
                tmpRS1 = gcon.Execute(tmpSql)

                nRows = 0
                curRow = curRow - 1
                While tmpRS1.EOF = False
                    curRow = curRow + 1
                    nRows = nRows + 1

                    'BILL PERIOD
                    oldFromMonth = CInt(tmpRS1("BillMonthFrom").Value.ToString)
                    oldToMonth = CInt(tmpRS1("BillMonthTo").Value.ToString)
                    oldFromYear = CInt(tmpRS1("BillYearFrom").Value.ToString)
                    oldToYear = CInt(tmpRS1("BillYearTo").Value.ToString)

                    oldBillPeriod = MonthName(oldFromMonth, True) & "-" & oldFromYear
                    If oldFromMonth <> oldToMonth Then
                        oldBillPeriod = oldBillPeriod & " to " & MonthName(oldToMonth, True) & "-" & oldToYear
                    End If


                    templateSht.Range("B" & curRow).Value = oldBillPeriod
                    templateSht.Range("F" & curRow).Value = tmpRS1("BillNo").Value.ToString
                    templateSht.Range("L" & curRow).Value = formatInt2Date(tmpRS1("BillDate").Value.ToString)
                    templateSht.Range("N" & curRow).Value = formatInt2Date(tmpRS1("DueDate").Value.ToString)
                    templateSht.Range("P" & curRow).Value = addThousandSeparator(tmpRS1("BillAmt").Value.ToString, False)


                    If nRows = 3 Then Exit While

                    tmpRS1.MoveNext()
                End While
                tmpRS1.Close()

                'Print the last 3 receipts
                '--------------------------------------------------------------------------------------------------
                Dim myReceipt As New clsReceipt
                curRow = curRow + 3 - nRows
                curRow = curRow + 4

                tmpSql = "select * from tbljournal where Status is null and (TxnType='RECEIPT' or TxnType='RECEIPT-BGF') and AccountNo like '%" & gCurFlatCode & "' and TxnDate <= " & DateTime.Parse(billDate).ToString(DB_DATEFORMAT) & " order by TxnDate desc,tblid desc"
                tmpRS1 = gcon.Execute(tmpSql)

                nRows = 0
                curRow = curRow - 1
                While tmpRS1.EOF = False
                    curRow = curRow + 1
                    nRows = nRows + 1

                    tmpDocRef = tmpRS1("DocRef").Value.ToString
                    tmpFlatStr = ", Payee:" & gCurFlatCode & ")"
                    tmpDocRef = Replace(tmpDocRef, tmpFlatStr, "")
                    tmpFlatStr = ",Payee:" & gCurFlatCode & ")"
                    tmpDocRef = Replace(tmpDocRef, tmpFlatStr, "")
                    tmpDocRef = Replace(tmpDocRef, "(", "")

                    templateSht.Range("B" & curRow).Value = Trim(tmpDocRef)
                    templateSht.Range("P" & curRow).Value = addThousandSeparator(tmpRS1("CrAmount").Value.ToString, False)

                    myReceipt.loadSingleReceipt("", "", tmpRS1("gid").Value.ToString)
                    If myReceipt.Status = False Then Exit Function
                    templateSht.Range("N" & curRow).Value = myReceipt.ReceiptDate


                    If nRows = 3 Then Exit While

                    tmpRS1.MoveNext()
                End While
                tmpRS1.Close()


                '*****************************************************************************************************
                If System.IO.Directory.Exists(billPath) = False Then System.IO.Directory.CreateDirectory(billPath)
                finalpath = billPath & "\" & towerName
                If System.IO.Directory.Exists(finalpath) = False Then System.IO.Directory.CreateDirectory(finalpath)
                finalpath = billPath & "\" & towerName & "\" & shortFlatNo
                If System.IO.Directory.Exists(finalpath) = False Then System.IO.Directory.CreateDirectory(finalpath)
                finalpath = billPath & "\" & towerName & "\" & shortFlatNo & "\" & billYear
                If System.IO.Directory.Exists(finalpath) = False Then System.IO.Directory.CreateDirectory(finalpath)


                templateSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, finalpath & "\" & billNo & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=False)


                If InStr(1, templateShtName, "green") = 0 Then
                    System.IO.File.Copy(finalpath & "\" & billNo & ".pdf", getSysParamValue("PATH_BILL_PRINT") & "_" & billPeriod & "\" & billNo & ".print.pdf", True)
                End If

                If chkIndividualReBilling.Checked = False Then
                    'Journalise Bill
                    Dim thisJournal As New clsJournal

                    With thisJournal
                        .DocRef = "(Bill Period:" & billPeriod & ", Bill No:" & billNo & ", Payee:" & gCurFlatCode & ")"
                        .DrAccountNo = "DEBTOR-FLAT-" & gCurFlatCode
                        .CrAccountNo = "REV-MAINT-FLAT-" & gCurFlatCode
                        .Amount = NetBillAmt
                        .Narration = "Maintenance service charge"
                        .TxnDate = billDate
                        .TxnType = "MAINT-BILL"
                        .VoucherType = "JV"


                        .CreateTransaction()
                        If .Status = False Then GoTo errH
                        gid = .gid


                    End With


                    'Create entry in Bill table
                    billSql = "INSERT INTO tblbill (gid,BillNo,BillType,Billdate,BillMonthFrom,BillYearFrom,BillMonthTo,BillYearTo, BillAmt,DueDate,FlatCode) VALUES ("
                    billSql = billSql & "'" & gid & "','" & billNo & "','" & "Maintenance" & "'," & DateTime.Parse(billDate).ToString(DB_DATEFORMAT) & "," & billFromMonthNum & "," & billYear & "," & billToMonthNum & "," & billToYear & "," & NetBillAmt & "," & DateTime.Parse(dueDate).ToString(DB_DATEFORMAT) & ",'" & gCurFlatCode & "');"
                    gcon.Execute(billSql)


                    billRS.MoveNext()
                    pbarBilling.Value = pbarBilling.Value + 1
                End If

                templateWrkBook.Close(False)
                releaseObject(templateWrkBook)
                releaseObject(templateSht)

                If chkIndividualReBilling.Checked = True Then
                    Exit While
                End If
        End While

        If chkIndividualReBilling.Checked = False Then
            'record in billing history

            If billToYear > billYear Then
                For x = billFromMonthNum To 12
                    bhSql = "Insert into tblbillinghistory (BillMonth,BillYear,BillingDone,BillingDate,BillingBy) values ("
                    bhSql = bhSql & x & "," & billYear & ",'Y'," & DateTime.Now.ToString(DB_DATEFORMAT) & ",'" & gLoginID & "')"
                    gcon.Execute(bhSql)
                Next x
                For x = 1 To billToMonthNum
                    bhSql = "Insert into tblbillinghistory (BillMonth,BillYear,BillingDone,BillingDate,BillingBy) values ("
                    bhSql = bhSql & x & "," & billToYear & ",'Y'," & DateTime.Now.ToString(DB_DATEFORMAT) & ",'" & gLoginID & "')"
                    gcon.Execute(bhSql)
                Next x
            Else
                For x = billFromMonthNum To billToMonthNum
                    bhSql = "Insert into tblbillinghistory (BillMonth,BillYear,BillingDone,BillingDate,BillingBy) values ("
                    bhSql = bhSql & x & "," & billYear & ",'Y'," & DateTime.Now.ToString(DB_DATEFORMAT) & ",'" & gLoginID & "')"
                    gcon.Execute(bhSql)
                Next x
            End If

        End If


        xlApp.Quit()
        releaseObject(xlApp)
        'releaseObject(templateWrkBook)
        'releaseObject(templateSht)

        If isSimulation = True Then
            gcon.RollbackTrans()
        Else
            gcon.CommitTrans()
        End If

        generateBilling = True
        Exit Function

errH:
        MsgBox(Err.Description)
        On Error Resume Next
        gcon.RollbackTrans()
        templateWrkBook.Close(False)
        If xlApp IsNot Nothing Then xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(templateWrkBook)
        releaseObject(templateSht)

    End Function

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    

    Private Sub txtBillRate_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtBillRate.MouseClick
        btnPerformBilling.Enabled = True
    End Sub

   
    Private Sub chkIndividualReBilling_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIndividualReBilling.CheckedChanged
        cboFlatCode.Enabled = chkIndividualReBilling.Checked
    End Sub

    Private Sub chkAddLine2_CheckedChanged(sender As Object, e As EventArgs) Handles chkAddLine2.CheckedChanged
        txtLineItem2Desc.Enabled = chkAddLine2.Checked
        txtLineAmt2.Enabled = chkAddLine2.Checked
    End Sub
End Class