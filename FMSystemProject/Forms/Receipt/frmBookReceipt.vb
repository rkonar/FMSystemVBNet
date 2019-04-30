Public Class frmBookReceipt
    Dim NetDrAmt As Double, NetCrAmt As Double, NetBGF As Double, formLoadComplete As Boolean
    Dim lFinYear As New clsFinYear

    Sub loadAvailableReceipts()
        cboReceiptNo.Items.Clear()
        tmpRS = gcon.Execute("select ReceiptNo from tblreceiptbook where Status='A' order by tblid Asc")
        While tmpRS.EOF = False
            cboReceiptNo.Items.Add(tmpRS("ReceiptNo").Value.ToString)
            tmpRS.MoveNext()
        End While
    End Sub

    Private Sub frmBookReceipt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        formLoadComplete = False
        gItemCode = "Receipts"

        Dim tmpFlatCode As String
        If gCurFlatCode <> "" Then
            tmpFlatCode = gCurFlatCode
            cboFlatCode.Items.Add(gCurFlatCode)
            optMiscCollection_NonFlatOwner.Enabled = False
            btnSave.Enabled = False
            btnBookPenalty.Enabled = False
            btnBookOtherCharges.Enabled = False

        Else
            tmpFlatCode = ""
            cboFlatCode.DataSource = FLATS
            cboFlatCode.SelectedIndex = 0

        End If


        cboInstrumentType.Items.AddRange(INSTRUMENT_TYPES)

        txtNarration.Text = "Maintenance service charge payment (Bill No:" ') & myLeft(gCurFlatCode, 3)

        cboFinYear.Items.Clear()
        Dim toYear As Integer
        If Month(DateTime.Now) > 3 Then
            toYear = Year(DateTime.Now)
        Else
            toYear = Year(DateTime.Now) - 1
        End If
        For x = 2012 To toYear
            cboFinYear.Items.Add(x & "-" & x + 1)
        Next
        'If Month(DateTime.Now) > 3 Then
        '    cboFinYear.Items.Add(Year(DateTime.Now) - 1 & "-" & Year(DateTime.Now))
        'End If

        'cboFinYear.Items.Add("2013-2014") 'delete later

        lFinYear.SetToCurFinYear()
        cboFinYear.Text = lFinYear.startYear & "-" & lFinYear.endYear


        getBankNames()
        cboBankName.Items.Clear()
        For x = 1 To UBound(BankNames)
            cboBankName.Items.Add(BankNames(x))
        Next

        If gLoginID <> "sa" Then
            optAssocFormFundCollection.Enabled = False
            'lblBalance.Visible = False
            btnMarkAsBGFOutstandingPayment.Visible = False
            btnMarkAsHIGAssocPayment.Visible = False
            btnAdjustExtraPayment.Visible = False
            btnAdjustCorpusOutstanding.Visible = False
        End If

        cboInstrumentType.Text = "CHEQUE"

        If tmpFlatCode <> "" Then
            gCurFlatCode = tmpFlatCode
            cboFlatCode.Text = tmpFlatCode
            cboFlatCode.Enabled = False
        Else

        End If

        'Me.PerformAutoScale()
        formLoadComplete = True
        btnQuery.PerformClick()
    End Sub

    Private Sub btnQuery_Click(sender As System.Object, e As System.EventArgs) Handles btnQuery.Click

        refreshForm(True)

    End Sub
    Sub loadCheques()
        Dim expActRS As ADODB.Recordset

        cboChequeNo.Items.Clear()
        ssql = "select InstrumentNo from tblreceipt where InstrumentType='CHEQUE' and InstrumentReconciled is null order by InstrumentNo"
        expActRS = gcon.Execute(ssql)

        While expActRS.EOF = False
            cboChequeNo.Items.Add(expActRS("InstrumentNo").Value.ToString)
            expActRS.MoveNext()
        End While
    End Sub

    Sub PopulateJournalBilled()
        On Error GoTo errH
        Dim i As Long, netAmt As Double

        NetBGF = 0
        NetDrAmt = 0
        dgvJournalBilled.Rows.Clear()

        If optOnDemandFlatServiceReceipt.Checked = True Then
            Exit Sub
        End If
        ' Add other types here

        If optMaintBillCollection.Checked = False Then
            Exit Sub
        End If

        '0:===========Print BGF Opening Balance for selected flat code==================
        'If cboFinYear.SelectedIndex > 0 Then
        '    lFinYear.SetToFinYear(cboFinYear.Items.Item(cboFinYear.SelectedIndex - 1).ToString)
        '    ssql = "select sum(DrAmount-CrAmount) as netAmt from tbljournal where Status is null "
        '    ssql = ssql & " and TxnDate <= '" & lFinYear.endDate & "'"
        '    If txtDuplexFlatCode.Text = "" Then
        '        ssql = ssql & " and AccountNo='DEBTOR-CORPUS-FUND-" & cboFlatCode.Text & "' "
        '    Else
        '        ssql = ssql & " and ((AccountNo='DEBTOR-CORPUS-FUND-" & cboFlatCode.Text & "') OR (AccountNo='DEBTOR-CORPUS-FUND-" & txtDuplexFlatCode.Text & "'))"
        '    End If

        '    lFinYear.SetToFinYear(cboFinYear.Text)
        '    rsJournalBilled = gcon.Execute(ssql)


        '    With dgvJournalBilled

        '        i = .Rows.Add()

        '        .Rows(i).Cells("Narration").Value = "CORPUS Due Carried Forward"

        '        .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("netAmt").Value.ToString
        '        NetDrAmt = NetDrAmt + rsJournalBilled("netAmt").Value.ToString
        '        NetBGF = NetBGF + rsJournalBilled("netAmt").Value.ToString

        '        .Rows(i).ReadOnly = True
        '        .Rows(i).DefaultCellStyle.BackColor = Color.Cyan

        '    End With
        '    rsJournalBilled.Close()

        'End If

            '0:===========Print Association Opening Balance for selected flat code==================
        If cboFinYear.SelectedIndex > 0 Then ' i.e. from second year onwards
            lFinYear.SetToFinYear(cboFinYear.Items.Item(cboFinYear.SelectedIndex - 1).ToString)
            ssql = "select sum(DrAmount-CrAmount) as netAmt from tbljournal where Status is null "
            ssql = ssql & " and TxnDate <= '" & lFinYear.endDate & "'"

            If txtDuplexFlatCode.Text = "" Then
                ssql = ssql & " and AccountNo='DEBTOR-FLAT-" & cboFlatCode.Text & "' "
            Else
                ssql = ssql & " and ((AccountNo='DEBTOR-FLAT-" & cboFlatCode.Text & "') OR (AccountNo='DEBTOR-FLAT-" & txtDuplexFlatCode.Text & "'))"
            End If

            lFinYear.SetToFinYear(cboFinYear.Text)
            rsJournalBilled = gcon.Execute(ssql)

            With dgvJournalBilled

                i = .Rows.Add()

                .Rows(i).Cells("TxnDate").Value = lFinYear.startDateDisplay
                .Rows(i).Cells("Narration").Value = "Association Due Carried Forward"

                .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("netAmt").Value.ToString
                NetDrAmt = NetDrAmt + rsJournalBilled("netAmt").Value.ToString

                .Rows(i).ReadOnly = True
                '.Rows(i).DefaultCellStyle.BackColor = Color.Cyan

            End With
            rsJournalBilled.Close()

        End If


            '1:if duplex, print selected flat code
            'If txtDuplexFlatCode.Text <> "" Then
            '    i = dgvJournalBilled.Rows.Add()
            '    dgvJournalBilled.Rows(i).Cells("Narration").Value = cboFlatCode.Text '& " - BGF"
            '    dgvJournalBilled.Rows(i).ReadOnly = True
            '    dgvJournalBilled.Rows(i).DefaultCellStyle.BackColor = Color.Brown
            'End If

            '2:===========Print BGF Bills for selected flat code==================
        If cboFinYear.SelectedIndex = 0 Then 'i.e. only for first year - second year onwards, we don't have any due related to BGF in our book
            'ssql = "select * from tbljournal where Status is null and DrAmount = 0 and AccountNo='CORPUS-FUND-" & cboFlatCode.Text & "'  order by TxnDate"
            ssql = "select * from tbljournal where Status is null and AccountNo='CORPUS-FUND-" & cboFlatCode.Text & "'"
            ssql = ssql & " and TxnDate >= '" & lFinYear.startDate & "' and TxnDate <= '" & lFinYear.endDate & "'"
            ssql = ssql & " order by TxnDate"

            rsJournalBilled = gcon.Execute(ssql)

            With dgvJournalBilled
                While rsJournalBilled.EOF = False
                    i = .Rows.Add()
                    .Rows(i).Cells("TxnType").Value = rsJournalBilled("TxnType").Value.ToString
                    .Rows(i).Cells("JournalID").Value = rsJournalBilled("tblid").Value.ToString
                    .Rows(i).Cells("TxnDate").Value = formatInt2Date(rsJournalBilled("TxnDate").Value.ToString)
                    .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("CrAmount").Value.ToString - rsJournalBilled("DrAmount").Value.ToString
                    .Rows(i).Cells("Narration").Value = rsJournalBilled("Narration").Value.ToString & " " & rsJournalBilled("DocRef").Value.ToString
                    NetDrAmt = NetDrAmt + rsJournalBilled("CrAmount").Value.ToString - rsJournalBilled("DrAmount").Value.ToString
                    NetBGF = NetBGF + rsJournalBilled("CrAmount").Value.ToString - rsJournalBilled("DrAmount").Value.ToString
                    .Rows(i).ReadOnly = True
                    .Rows(i).DefaultCellStyle.BackColor = Color.Cyan

                    rsJournalBilled.MoveNext()
                End While
            End With
            rsJournalBilled.Close()
        End If

        '3:if duplex, print BGF bills for duplex flat code
        If cboFinYear.SelectedIndex = 0 Then 'i.e. only for first year - second year onwards, we don't have any due related to BGF in our book
            If txtDuplexFlatCode.Text <> "" Then
                'i = dgvJournalBilled.Rows.Add()
                'dgvJournalBilled.Rows(i).Cells("Narration").Value = txtDuplexFlatCode.Text '& " - BGF"
                'dgvJournalBilled.Rows(i).ReadOnly = True
                'dgvJournalBilled.Rows(i).DefaultCellStyle.BackColor = Color.Brown


                '4:===========Print BGF Bills for duplex flat code==================
                ssql = "select * from tbljournal where Status is null and AccountNo='CORPUS-FUND-" & txtDuplexFlatCode.Text & "'"
                ssql = ssql & " and TxnDate >= '" & lFinYear.startDate & "' and TxnDate <= '" & lFinYear.endDate & "'"
                ssql = ssql & " order by TxnDate"
                rsJournalBilled = gcon.Execute(ssql)

                With dgvJournalBilled
                    While rsJournalBilled.EOF = False
                        i = .Rows.Add()
                        .Rows(i).Cells("JournalID").Value = rsJournalBilled("tblid").Value.ToString
                        .Rows(i).Cells("TxnType").Value = rsJournalBilled("TxnType").Value.ToString
                        .Rows(i).Cells("TxnDate").Value = formatInt2Date(rsJournalBilled("TxnDate").Value.ToString)
                        .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("CrAmount").Value.ToString
                        .Rows(i).Cells("Narration").Value = rsJournalBilled("Narration").Value.ToString & " " & rsJournalBilled("DocRef").Value.ToString
                        NetDrAmt = NetDrAmt + rsJournalBilled("CrAmount").Value.ToString
                        NetBGF = NetBGF + rsJournalBilled("CrAmount").Value.ToString
                        .Rows(i).ReadOnly = True
                        .Rows(i).DefaultCellStyle.BackColor = Color.Cyan

                        rsJournalBilled.MoveNext()
                    End While
                End With
                rsJournalBilled.Close()
            End If
        End If

        '5:if duplex, print selected flat code
        If txtDuplexFlatCode.Text <> "" Then
            i = dgvJournalBilled.Rows.Add()
            dgvJournalBilled.Rows(i).Cells("Narration").Value = cboFlatCode.Text '& " - HIG Association"
            dgvJournalBilled.Rows(i).ReadOnly = True
            dgvJournalBilled.Rows(i).DefaultCellStyle.BackColor = Color.Brown
        End If


        '6:===========Print HIG Association Bills for selected flat code==================
        'ssql = "select * from tbljournal where Status is null and DrAmount = 0 and (AccountNo='REV-MAINT-FLAT-" & cboFlatCode.Text & "' OR AccountNo='REV-MAINT-OTHER-CHARGES-" & cboFlatCode.Text & "')  order by TxnDate"
        ssql = "select * from tbljournal where Status is null and DrAmount = 0 and (TxnType = 'MAINT-BILL' or TxnType = 'MAINT-BILL-PENALTY' or TxnType = 'MAINT-BILL-OTHER-CHARGES') and AccountNo like '%" & cboFlatCode.Text & "%' "
        ssql = ssql & " and TxnDate >= '" & lFinYear.startDate & "' and TxnDate <= '" & lFinYear.endDate & "'"
        ssql = ssql & " order by TxnDate"
        rsJournalBilled = gcon.Execute(ssql)

        With dgvJournalBilled
            While rsJournalBilled.EOF = False
                i = .Rows.Add()
                .Rows(i).Cells("JournalID").Value = rsJournalBilled("tblid").Value.ToString
                .Rows(i).Cells("TxnType").Value = rsJournalBilled("TxnType").Value.ToString
                .Rows(i).Cells("TxnDate").Value = formatInt2Date(rsJournalBilled("TxnDate").Value.ToString)
                .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("CrAmount").Value.ToString
                .Rows(i).Cells("Narration").Value = rsJournalBilled("Narration").Value.ToString & " " & rsJournalBilled("DocRef").Value.ToString
                NetDrAmt = NetDrAmt + rsJournalBilled("CrAmount").Value.ToString
                .Rows(i).ReadOnly = True
                rsJournalBilled.MoveNext()
            End While
            rsJournalBilled.Close()
        End With

        '6A:===========Print Contra Receipts for selected flat code==================
        ssql = "select * from tbljournal where Status is null and CrAmount = 0 and TxnType = 'CONTRA-RECEIPT' and AccountNo like '%" & cboFlatCode.Text & "%' "
        ssql = ssql & " and TxnDate >= '" & lFinYear.startDate & "' and TxnDate <= '" & lFinYear.endDate & "'"
        ssql = ssql & " order by TxnDate"
        rsJournalBilled = gcon.Execute(ssql)

        With dgvJournalBilled
            While rsJournalBilled.EOF = False
                i = .Rows.Add()
                .Rows(i).Cells("JournalID").Value = rsJournalBilled("tblid").Value.ToString
                .Rows(i).Cells("TxnType").Value = rsJournalBilled("TxnType").Value.ToString
                .Rows(i).Cells("TxnDate").Value = formatInt2Date(rsJournalBilled("TxnDate").Value.ToString)
                .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("DrAmount").Value.ToString
                .Rows(i).Cells("Narration").Value = rsJournalBilled("Narration").Value.ToString & " " & rsJournalBilled("DocRef").Value.ToString
                NetDrAmt = NetDrAmt + rsJournalBilled("DrAmount").Value.ToString
                .Rows(i).ReadOnly = True
                rsJournalBilled.MoveNext()
            End While
            rsJournalBilled.Close()
        End With

        '7:if duplex, print duplex flat code
        If txtDuplexFlatCode.Text <> "" Then
            i = dgvJournalBilled.Rows.Add()
            dgvJournalBilled.Rows(i).Cells("Narration").Value = txtDuplexFlatCode.Text '& " - HIG Association"
            dgvJournalBilled.Rows(i).ReadOnly = True
            dgvJournalBilled.Rows(i).DefaultCellStyle.BackColor = Color.Brown


            '8:===========Print HIG Association Bills for duplex flat code==================
            'ssql = "select * from tbljournal where Status is null and DrAmount = 0 and (AccountNo='REV-MAINT-FLAT-" & txtDuplexFlatCode.Text & "' OR AccountNo='REV-MAINT-OTHER-CHARGES-" & txtDuplexFlatCode.Text & "')  order by TxnDate"
            ssql = "select * from tbljournal where Status is null and DrAmount = 0 and (TxnType = 'MAINT-BILL' or TxnType = 'MAINT-BILL-PENALTY' or TxnType = 'MAINT-BILL-OTHER-CHARGES') and AccountNo like '%" & txtDuplexFlatCode.Text & "%' "
            ssql = ssql & " and TxnDate >= '" & lFinYear.startDate & "' and TxnDate <= '" & lFinYear.endDate & "'"
            ssql = ssql & " order by TxnDate"
            rsJournalBilled = gcon.Execute(ssql)

            With dgvJournalBilled
                While rsJournalBilled.EOF = False
                    i = .Rows.Add()
                    .Rows(i).Cells("JournalID").Value = rsJournalBilled("tblid").Value.ToString
                    .Rows(i).Cells("TxnType").Value = rsJournalBilled("TxnType").Value.ToString
                    .Rows(i).Cells("TxnDate").Value = formatInt2Date(rsJournalBilled("TxnDate").Value.ToString)
                    .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("CrAmount").Value.ToString
                    .Rows(i).Cells("Narration").Value = rsJournalBilled("Narration").Value.ToString & " " & rsJournalBilled("DocRef").Value.ToString
                    NetDrAmt = NetDrAmt + rsJournalBilled("CrAmount").Value.ToString
                    .Rows(i).ReadOnly = True
                    rsJournalBilled.MoveNext()
                End While
                rsJournalBilled.Close()
            End With


            '8A:===========Print Contra Receipts for Duplex flat code==================
            ssql = "select * from tbljournal where Status is null and CrAmount = 0 and TxnType = 'CONTRA-RECEIPT' and AccountNo like '%" & txtDuplexFlatCode.Text & "%' "
            ssql = ssql & " and TxnDate >= '" & lFinYear.startDate & "' and TxnDate <= '" & lFinYear.endDate & "'"
            ssql = ssql & " order by TxnDate"
            rsJournalBilled = gcon.Execute(ssql)

            With dgvJournalBilled
                While rsJournalBilled.EOF = False
                    i = .Rows.Add()
                    .Rows(i).Cells("JournalID").Value = rsJournalBilled("tblid").Value.ToString
                    .Rows(i).Cells("TxnType").Value = rsJournalBilled("TxnType").Value.ToString
                    .Rows(i).Cells("TxnDate").Value = formatInt2Date(rsJournalBilled("TxnDate").Value.ToString)
                    .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("DrAmount").Value.ToString
                    .Rows(i).Cells("Narration").Value = rsJournalBilled("Narration").Value.ToString & " " & rsJournalBilled("DocRef").Value.ToString
                    NetDrAmt = NetDrAmt + rsJournalBilled("DrAmount").Value.ToString
                    .Rows(i).ReadOnly = True
                    rsJournalBilled.MoveNext()
                End While
                rsJournalBilled.Close()
            End With

        End If

        '9:Print final total line
        With dgvJournalBilled
            i = .Rows.Add()
            .Rows(i).Cells("Narration").Value = "Total (Rs.)"
            .Rows(i).Cells("TxnAmt").Value = addThousandSeparator(NetDrAmt)

            .Rows(i).ReadOnly = True
            NetLineStyle.Font = New Font(DataGridView.DefaultFont, FontStyle.Bold)
            .Rows(i).DefaultCellStyle = NetLineStyle
            .Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Rows(i).DefaultCellStyle.ForeColor = Color.Blue

            .Rows(0).Cells("TxnDate").Selected = False
            .Rows(i).Cells("TxnAmt").Selected = True
        End With

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then
            MsgBox(Err.Description)
        End If

    End Sub

    Sub PopulateJournalPaidOthers()
        On Error GoTo errH
        Dim i As Long, netAmt As Double, myReceipt As New clsReceipt, myDocRef As New clsDocRef, rcpt_no As String

        NetCrAmt = 0
        dgvJournalPaid.Rows.Clear()

        Dim tmpTxnType As String, tmpAccountNo As String, tmpSql1 As String, tmpsqlDup As String
        If optAssocFormFundCollection.Checked = True Then
            tmpSql1 = "select * from tbljournal where DrAmount = 0 and (TxnType='MISC-RECEIPT-OWNER') and AccountNo = 'ASSOCIATION-FORMATION-FUND' and DocRef like '%" & cboFlatCode.Text & "%' "
        ElseIf optMiscCollection_FlatOwner.Checked = True Then
            tmpSql1 = "select * from tbljournal where DrAmount = 0 and (TxnType='MISC-RECEIPT-OWNER') and AccountNo like 'REV-MAINT-OTHER-CHARGES-" & cboFlatCode.Text & "%' "
        ElseIf optMiscCollection_NonFlatOwner.Checked = True Then
            tmpSql1 = "select * from tbljournal where DrAmount = 0 and (TxnType='MISC-RECEIPT-NONOWNER') and AccountNo = 'REV-MISC-COLLECTION' and DocRef like '%" & cboFlatCode.Text & "%' "
        ElseIf optOnDemandFlatServiceReceipt.Checked = True Then
            tmpSql1 = "select * from tbljournal where DrAmount = 0 and (TxnType='ONDEMAND-MAINTENANCE-RECEIPT') and AccountNo like 'REV-MAINT-OTHER-CHARGES-" & cboFlatCode.Text & "%' "
        ElseIf optStartrekCollection.Checked = True Then
            tmpSql1 = "select * from tbljournal where DrAmount = 0 and (TxnType='COMMUNITY-HALL-BOOKING') and AccountNo = 'REV-STARTREK' and DocRef like '%" & cboFlatCode.Text & "%' "
        ElseIf optTenancyRegistrationFeeReceipt.Checked = True Then
            tmpSql1 = "select * from tbljournal where DrAmount = 0 and (TxnType='TENANCY-REGISTRATION-FEE-RECEIPT') and AccountNo like 'REV-MAINT-OTHER-CHARGES-" & cboFlatCode.Text & "%' "
        ElseIf optFacilitationFeeReceipt.Checked = True Then
            tmpSql1 = "select * from tbljournal where DrAmount = 0 and (TxnType='FACILITATION-FEE-RECEIPT') and AccountNo like 'REV-MAINT-OTHER-CHARGES-" & cboFlatCode.Text & "%' "
        ElseIf optUntracedPaymentReceipt.Checked = True Then
            tmpSql1 = "select * from tbljournal where DrAmount = 0 and (TxnType='UNTRACED-PAYEE-RECEIPT')"
        Else
            Exit Sub
        End If

        tmpSql1 = tmpSql1 & " and TxnDate >= '" & lFinYear.startDate & "' and TxnDate <= '" & lFinYear.endDate & "'"
        tmpSql1 = tmpSql1 & " order by TxnDate"

        '1:if duplex, print selected flat code
        'If txtDuplexFlatCode.Text <> "" Then
        '    i = dgvJournalPaid.Rows.Add()
        '    dgvJournalPaid.Rows(i).Cells("NarrationPaid").Value = cboFlatCode.Text '& " - BGF"
        '    dgvJournalPaid.Rows(i).ReadOnly = True
        '    dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Brown
        'End If

        '6:===========Print HIG Association payments for selected flat code==================
        'ssql = "select * from tbljournal where DrAmount = 0 and AccountNo='DEBTOR-FLAT-" & cboFlatCode.Text & "' order by TxnDate"
        ssql = tmpSql1
        rsJournalPaid = gcon.Execute(ssql)
        With dgvJournalPaid
            While rsJournalPaid.EOF = False
                i = .Rows.Add()
                .Rows(i).Cells("JournalIDPaid").Value = rsJournalPaid("tblid").Value.ToString
                .Rows(i).Cells("TxnTypePaid").Value = rsJournalPaid("TxnType").Value.ToString
                .Rows(i).Cells("TxnDatePaid").Value = formatInt2Date(rsJournalPaid("TxnDate").Value.ToString)
                .Rows(i).Cells("NarrationPaid").Value = rsJournalPaid("Narration").Value.ToString & " " & rsJournalPaid("DocRef").Value.ToString
                If rsJournalPaid("Status").Value.ToString = "" Then
                    .Rows(i).Cells("TxnAmtPaid").Value = rsJournalPaid("CrAmount").Value.ToString
                    NetCrAmt = NetCrAmt + rsJournalPaid("CrAmount").Value.ToString
                Else
                    .Rows(i).Cells("TxnAmtPaid").Value = 0
                End If
                .Rows(i).ReadOnly = True
                'if not reconciled with bank, then set forecolor to red, else green.
                rcpt_no = myDocRef.getReceiptNo(rsJournalPaid("DocRef").Value.ToString)
                If rcpt_no <> "" Then 'For null-split, there is no receipt
                    myReceipt.loadSingleReceipt("", rcpt_no, "")
                    If myReceipt.Status = False Then Exit Sub
                    If (myReceipt.InstrumentType = "CHEQUE" Or myReceipt.InstrumentType = "ONLINE") Then
                        If rsJournalPaid("refgid").Value.ToString = "" Then
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                        Else
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                        End If
                    Else
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    End If
                End If
                rsJournalPaid.MoveNext()
            End While
        End With

        '7:if duplex, print duplex flat code
        If txtDuplexFlatCode.Text <> "" Then

            tmpSql1 = Replace(tmpSql1, cboFlatCode.Text, txtDuplexFlatCode.Text)

            i = dgvJournalPaid.Rows.Add()
            dgvJournalPaid.Rows(i).Cells("NarrationPaid").Value = txtDuplexFlatCode.Text '& " - HIG Association"
            dgvJournalPaid.Rows(i).ReadOnly = True
            dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Brown


            '8:===========Print HIG Association payments for duplex flat code==================
            'ssql = "select * from tbljournal where DrAmount = 0 and AccountNo='DEBTOR-FLAT-" & txtDuplexFlatCode.Text & "' order by TxnDate"
            ssql = tmpSql1
            rsJournalPaid = gcon.Execute(ssql)
            With dgvJournalPaid
                While rsJournalPaid.EOF = False
                    i = .Rows.Add()
                    .Rows(i).Cells("JournalIDPaid").Value = rsJournalPaid("tblid").Value.ToString
                    .Rows(i).Cells("TxnTypePaid").Value = rsJournalPaid("TxnType").Value.ToString
                    .Rows(i).Cells("TxnDatePaid").Value = formatInt2Date(rsJournalPaid("TxnDate").Value.ToString)
                    .Rows(i).Cells("NarrationPaid").Value = rsJournalPaid("Narration").Value.ToString & " " & rsJournalPaid("DocRef").Value.ToString
                    If rsJournalPaid("Status").Value.ToString = "" Then
                        .Rows(i).Cells("TxnAmtPaid").Value = rsJournalPaid("CrAmount").Value.ToString
                        NetCrAmt = NetCrAmt + rsJournalPaid("CrAmount").Value.ToString
                    Else
                        .Rows(i).Cells("TxnAmtPaid").Value = 0
                        dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    End If
                    .Rows(i).ReadOnly = True
                    'if not reconciled with bank, then set forecolor to red, else green.
                    rcpt_no = myDocRef.getReceiptNo(rsJournalPaid("DocRef").Value.ToString)
                    If rcpt_no <> "" Then 'For null-split, there is no receipt
                        myReceipt.loadSingleReceipt("", rcpt_no, "")
                        If myReceipt.Status = False Then Exit Sub
                        If (myReceipt.InstrumentType = "CHEQUE" Or myReceipt.InstrumentType = "ONLINE") Then
                            If rsJournalPaid("refgid").Value.ToString = "" Then
                                .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                            Else
                                .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                            End If
                        Else
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                        End If
                    End If
                    rsJournalPaid.MoveNext()
                End While
            End With
        End If

        '9:Print final total line
        With dgvJournalPaid
            i = .Rows.Add()
            .Rows(i).Cells("NarrationPaid").Value = "Total (Rs.)"
            .Rows(i).Cells("TxnAmtPaid").Value = addThousandSeparator(NetCrAmt)

            .Rows(i).ReadOnly = True
            NetLineStyle.Font = New Font(DataGridView.DefaultFont, FontStyle.Bold)
            .Rows(i).DefaultCellStyle = NetLineStyle
            .Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Rows(i).DefaultCellStyle.ForeColor = Color.Blue

            .Rows(0).Cells("TxnDatePaid").Selected = False
            .Rows(i).Cells("TxnAmtPaid").Selected = True

        End With

        rsJournalPaid.Close()

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Sub PopulateJournalPaid()
        On Error GoTo errH
        Dim i As Long, netAmt As Double, myReceipt As New clsReceipt, myDocRef As New clsDocRef, rcpt_no As String

        NetCrAmt = 0
        dgvJournalPaid.Rows.Clear()

        If optMaintBillCollection.Checked = False And optEarthMoversCollection.Checked = False Then
            PopulateJournalPaidOthers()
            Exit Sub
        End If



        '1:if duplex, print selected flat code
        'If txtDuplexFlatCode.Text <> "" Then
        '    i = dgvJournalPaid.Rows.Add()
        '    dgvJournalPaid.Rows(i).Cells("NarrationPaid").Value = cboFlatCode.Text '& " - BGF"
        '    dgvJournalPaid.Rows(i).ReadOnly = True
        '    dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Brown
        'End If

        '2:===========Print BGF payments for selected flat code==================
        'Include cancelled receipts also
        If cboFinYear.SelectedIndex = 0 Then 'i.e. only for first year - second year onwards, we don't have any due related to BGF in our book
            ssql = "select * from tbljournal where DrAmount = 0 and AccountNo='DEBTOR-CORPUS-FUND-" & cboFlatCode.Text & "' "
            ssql = ssql & " and TxnDate >= '" & lFinYear.startDate & "' and TxnDate <= '" & lFinYear.endDate & "'"
            ssql = ssql & " order by TxnDate"
            rsJournalPaid = gcon.Execute(ssql)

            With dgvJournalPaid
                While rsJournalPaid.EOF = False
                    i = .Rows.Add()
                    .Rows(i).Cells("JournalIDPaid").Value = rsJournalPaid("tblid").Value.ToString
                    .Rows(i).Cells("TxnTypePaid").Value = rsJournalPaid("TxnType").Value.ToString
                    .Rows(i).Cells("TxnDatePaid").Value = formatInt2Date(rsJournalPaid("TxnDate").Value.ToString)
                    .Rows(i).Cells("NarrationPaid").Value = rsJournalPaid("Narration").Value.ToString & " " & rsJournalPaid("DocRef").Value.ToString
                    If rsJournalPaid("Status").Value.ToString = "" Then
                        .Rows(i).Cells("TxnAmtPaid").Value = rsJournalPaid("CrAmount").Value.ToString
                        NetCrAmt = NetCrAmt + rsJournalPaid("CrAmount").Value.ToString
                        NetBGF = NetBGF - rsJournalPaid("CrAmount").Value.ToString
                    Else 'for cancelled receipts, show the amount as zero
                        .Rows(i).Cells("TxnAmtPaid").Value = 0
                    End If
                    .Rows(i).ReadOnly = True
                    .Rows(i).DefaultCellStyle.BackColor = Color.Cyan

                    'if not reconciled with bank, then set forecolor to red, else green.
                    rcpt_no = myDocRef.getReceiptNo(rsJournalPaid("DocRef").Value.ToString)
                    If rcpt_no <> "" Then 'For null-split, there is no receipt
                        myReceipt.loadSingleReceipt("", rcpt_no, "")
                        If myReceipt.Status = False Then Exit Sub
                        If (myReceipt.InstrumentType = "CHEQUE" Or myReceipt.InstrumentType = "ONLINE") Then
                            If rsJournalPaid("refgid").Value.ToString = "" Then
                                .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                            Else
                                .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                            End If
                        Else
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                        End If
                    End If
                    rsJournalPaid.MoveNext()
                End While
            End With
            rsJournalPaid.Close()
        End If

        '3:if duplex, print duplex flat code
        If cboFinYear.SelectedIndex = 0 Then 'i.e. only for first year - second year onwards, we don't have any due related to BGF in our book
            If txtDuplexFlatCode.Text <> "" Then
                'i = dgvJournalPaid.Rows.Add()
                'dgvJournalPaid.Rows(i).Cells("NarrationPaid").Value = txtDuplexFlatCode.Text '& " - BGF"
                'dgvJournalPaid.Rows(i).ReadOnly = True
                'dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Brown


                '4:===========Print BGF payments for duplex flat code==================
                ssql = "select * from tbljournal where DrAmount = 0 and AccountNo='DEBTOR-CORPUS-FUND-" & txtDuplexFlatCode.Text & "' "
                ssql = ssql & " and TxnDate >= '" & lFinYear.startDate & "' and TxnDate <= '" & lFinYear.endDate & "'"
                ssql = ssql & " order by TxnDate"
                rsJournalPaid = gcon.Execute(ssql)

                With dgvJournalPaid
                    While rsJournalPaid.EOF = False
                        i = .Rows.Add()
                        .Rows(i).Cells("JournalIDPaid").Value = rsJournalPaid("tblid").Value.ToString
                        .Rows(i).Cells("TxnTypePaid").Value = rsJournalPaid("TxnType").Value.ToString
                        .Rows(i).Cells("TxnDatePaid").Value = formatInt2Date(rsJournalPaid("TxnDate").Value.ToString)
                        .Rows(i).Cells("NarrationPaid").Value = rsJournalPaid("Narration").Value.ToString & " " & rsJournalPaid("DocRef").Value.ToString
                        If rsJournalPaid("Status").Value.ToString = "" Then
                            .Rows(i).Cells("TxnAmtPaid").Value = rsJournalPaid("CrAmount").Value.ToString
                            NetCrAmt = NetCrAmt + rsJournalPaid("CrAmount").Value.ToString
                            NetBGF = NetBGF - rsJournalPaid("CrAmount").Value.ToString
                        Else
                            .Rows(i).Cells("TxnAmtPaid").Value = 0
                        End If
                        .Rows(i).ReadOnly = True
                        .Rows(i).DefaultCellStyle.BackColor = Color.Cyan
                        'if not reconciled with bank, then set forecolor to red, else green.
                        rcpt_no = myDocRef.getReceiptNo(rsJournalPaid("DocRef").Value.ToString)
                        If rcpt_no <> "" Then 'For null-split, there is no receipt
                            myReceipt.loadSingleReceipt("", rcpt_no, "")
                            If myReceipt.Status = False Then Exit Sub
                            If (myReceipt.InstrumentType = "CHEQUE" Or myReceipt.InstrumentType = "ONLINE") Then
                                If rsJournalPaid("refgid").Value.ToString = "" Then
                                    .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                                Else
                                    .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                                End If
                            Else
                                .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                            End If
                        End If
                        rsJournalPaid.MoveNext()
                    End While
                End With
                rsJournalPaid.Close()

            End If
        End If

        '5:if duplex, print selected flat code
        If txtDuplexFlatCode.Text <> "" Then
            i = dgvJournalPaid.Rows.Add()
            dgvJournalPaid.Rows(i).Cells("NarrationPaid").Value = cboFlatCode.Text '& " - HIG Association"
            dgvJournalPaid.Rows(i).ReadOnly = True
            dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Brown
        End If


        '6:===========Print HIG Association payments for selected flat code==================
        ssql = "select * from tbljournal where DrAmount = 0 and AccountNo='DEBTOR-FLAT-" & cboFlatCode.Text & "' "
        ssql = ssql & " and TxnDate >= '" & lFinYear.startDate & "' and TxnDate <= '" & lFinYear.endDate & "'"
        ssql = ssql & " order by TxnDate"
        'ssql = "select * from tbljournal where DrAmount = 0 and (TxnType='RECEIPT' OR TxnType='NULL-SPLIT') and AccountNo like '%" & cboFlatCode.Text & "' order by TxnDate"
        rsJournalPaid = gcon.Execute(ssql)
        With dgvJournalPaid
            While rsJournalPaid.EOF = False
                i = .Rows.Add()
                .Rows(i).Cells("JournalIDPaid").Value = rsJournalPaid("tblid").Value.ToString
                .Rows(i).Cells("TxnTypePaid").Value = rsJournalPaid("TxnType").Value.ToString
                .Rows(i).Cells("TxnDatePaid").Value = formatInt2Date(rsJournalPaid("TxnDate").Value.ToString)
                .Rows(i).Cells("NarrationPaid").Value = rsJournalPaid("Narration").Value.ToString & " " & rsJournalPaid("DocRef").Value.ToString
                If rsJournalPaid("Status").Value.ToString = "" Then
                    .Rows(i).Cells("TxnAmtPaid").Value = rsJournalPaid("CrAmount").Value.ToString
                    NetCrAmt = NetCrAmt + rsJournalPaid("CrAmount").Value.ToString
                Else
                    .Rows(i).Cells("TxnAmtPaid").Value = 0
                End If
                .Rows(i).ReadOnly = True
                'if not reconciled with bank, then set forecolor to red, else green.
                rcpt_no = myDocRef.getReceiptNo(rsJournalPaid("DocRef").Value.ToString)
                If rcpt_no <> "" Then 'For null-split, there is no receipt
                    myReceipt.loadSingleReceipt("", rcpt_no, "")
                    If myReceipt.Status = False Then Exit Sub
                    If (myReceipt.InstrumentType = "CHEQUE" Or myReceipt.InstrumentType = "ONLINE") Then
                        If rsJournalPaid("refgid").Value.ToString = "" Then
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                        Else
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                        End If
                    Else
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    End If
                End If
                rsJournalPaid.MoveNext()
            End While
        End With

        '7:if duplex, print duplex flat code
        If txtDuplexFlatCode.Text <> "" Then
            i = dgvJournalPaid.Rows.Add()
            dgvJournalPaid.Rows(i).Cells("NarrationPaid").Value = txtDuplexFlatCode.Text '& " - HIG Association"
            dgvJournalPaid.Rows(i).ReadOnly = True
            dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Brown


            '8:===========Print HIG Association payments for duplex flat code==================
            ssql = "select * from tbljournal where DrAmount = 0 and AccountNo='DEBTOR-FLAT-" & txtDuplexFlatCode.Text & "' "
            ssql = ssql & " and TxnDate >= '" & lFinYear.startDate & "' and TxnDate <= '" & lFinYear.endDate & "'"
            ssql = ssql & " order by TxnDate"
            'ssql = "select * from tbljournal where DrAmount = 0 and (TxnType='RECEIPT' OR TxnType='NULL-SPLIT') and AccountNo like '%" & txtDuplexFlatCode.Text & "' order by TxnDate"
            rsJournalPaid = gcon.Execute(ssql)
            With dgvJournalPaid
                While rsJournalPaid.EOF = False
                    i = .Rows.Add()
                    .Rows(i).Cells("JournalIDPaid").Value = rsJournalPaid("tblid").Value.ToString
                    .Rows(i).Cells("TxnTypePaid").Value = rsJournalPaid("TxnType").Value.ToString
                    .Rows(i).Cells("TxnDatePaid").Value = formatInt2Date(rsJournalPaid("TxnDate").Value.ToString)
                    .Rows(i).Cells("NarrationPaid").Value = rsJournalPaid("Narration").Value.ToString & " " & rsJournalPaid("DocRef").Value.ToString
                    If rsJournalPaid("Status").Value.ToString = "" Then
                        .Rows(i).Cells("TxnAmtPaid").Value = rsJournalPaid("CrAmount").Value.ToString
                        NetCrAmt = NetCrAmt + rsJournalPaid("CrAmount").Value.ToString
                    Else
                        .Rows(i).Cells("TxnAmtPaid").Value = 0
                        dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    End If
                    .Rows(i).ReadOnly = True
                    'if not reconciled with bank, then set forecolor to red, else green.
                    rcpt_no = myDocRef.getReceiptNo(rsJournalPaid("DocRef").Value.ToString)
                    If rcpt_no <> "" Then 'For null-split, there is no receipt
                        myReceipt.loadSingleReceipt("", rcpt_no, "")
                        If myReceipt.Status = False Then Exit Sub
                        If (myReceipt.InstrumentType = "CHEQUE" Or myReceipt.InstrumentType = "ONLINE") Then
                            If rsJournalPaid("refgid").Value.ToString = "" Then
                                .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                            Else
                                .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                            End If
                        Else
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                        End If
                    End If
                    rsJournalPaid.MoveNext()
                End While
            End With
        End If

        '9:Print final total line
        With dgvJournalPaid
            i = .Rows.Add()
            .Rows(i).Cells("NarrationPaid").Value = "Total (Rs.)"
            .Rows(i).Cells("TxnAmtPaid").Value = addThousandSeparator(NetCrAmt)

            .Rows(i).ReadOnly = True
            NetLineStyle.Font = New Font(DataGridView.DefaultFont, FontStyle.Bold)
            .Rows(i).DefaultCellStyle = NetLineStyle
            .Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Rows(i).DefaultCellStyle.ForeColor = Color.Blue

            .Rows(0).Cells("TxnDatePaid").Selected = False
            .Rows(i).Cells("TxnAmtPaid").Selected = True

        End With

        rsJournalPaid.Close()

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo errH

        Dim gid As String, rcpt_no As String

        rcpt_no = cboReceiptNo.Text
        txtInstrumentNo.Text = Trim(txtInstrumentNo.Text)
        txtNarration.Text = Trim(txtNarration.Text)

        'If cboInstrumentType.Text = "CASH" Then
        'gUserResponse = MsgBox("Ensure you have entered the receipt amount correctly. For CASH receipts, receipt amount cannot be altered later through this system. Proceed with Save?", MsgBoxStyle.YesNo, "CASH Receipt entry - Check Receipt Amount!!!")
        gUserResponse = MessageBox.Show("Ensure you have entered the receipt amount correctly. Receipt amount cannot be altered later through this system. Proceed with Save?", "Receipt entry - Check Receipt Amount!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If gUserResponse = vbNo Then
            MsgBox("Receipt not saved")
            Exit Sub
        End If
        'End If


        gcon.BeginTrans()

        If validateReceipt() = False Then GoTo errH

        'Journalise Receipt

        Dim thisJournal As New clsJournal

        With thisJournal
            If cboInstrumentType.Text = "CASH" Then
                .DocRef = "(Receipt No:" & rcpt_no & ", Payment Mode:CASH, Payee:" & cboFlatCode.Text & ")"
                .DrAccountNo = "CASHBOX"
                .TxnDate = dtpReceiptDate.Text
                .refgid = "-"
                .VoucherType = "RV"
            ElseIf cboInstrumentType.Text = "CHEQUE" Then
                .DocRef = "(Receipt No:" & rcpt_no & ", Cheque No:" & stripLeadingZero(txtInstrumentNo.Text) & ", Cheque Date:" & dtpInstrumentDate.Text & ", Payee:" & cboFlatCode.Text & ")"
                .DrAccountNo = "CHEQUE-IN-HAND"
                .TxnDate = dtpReceiptDate.Text
                .refgid = ""
                .VoucherType = "JV"
            ElseIf cboInstrumentType.Text = "ONLINE" Then
                .DocRef = "(Receipt No:" & rcpt_no & ", Online Transfer Ref:" & stripLeadingZero(txtInstrumentNo.Text) & ", Transfer Date:" & dtpInstrumentDate.Text & ", Payee:" & cboFlatCode.Text & ")"
                .DrAccountNo = "NEFT-NOT-RECONCILED" 'cboDebitAccount.Text
                .TxnDate = dtpInstrumentDate.Text
                .refgid = ""
                .VoucherType = "JV"
            End If


            .Amount = txtReceiptAmount.Text
            .Narration = txtNarration.Text


            If optAssocFormFundCollection.Checked = True Then
                .CrAccountNo = "ASSOCIATION-FORMATION-FUND"
                .TxnType = "MISC-RECEIPT-OWNER"
            ElseIf optStartrekCollection.Checked = True Then
                .CrAccountNo = "REV-STARTREK"
                .TxnType = "COMMUNITY-HALL-BOOKING"
            ElseIf optMaintBillCollection.Checked = True Then
                .CrAccountNo = "DEBTOR-FLAT-" & cboFlatCode.Text
                .TxnType = "RECEIPT"

                'ElseIf optEarthMoversCollection.Checked = True Then
                '    .CrAccountNo = "DEBTOR-CORPUS-FUND-" & cboFlatCode.Text 'reduce hig assoc receivable for transfer to BGF
                '    .DrAccountNo = "BGF-DIRECT-PAYMENT-" & cboFlatCode.Text 'reduce hig assoc liability to BGF
                '    .TxnType = "RECEIPT-BGF"
                '    .CreateBGFPaymentTransaction()            
            ElseIf optOnDemandFlatServiceReceipt.Checked = True Then
                .CrAccountNo = "REV-MAINT-OTHER-CHARGES-" & gCurFlatCode
                .TxnType = "ONDEMAND-MAINTENANCE-RECEIPT"
            ElseIf optFacilitationFeeReceipt.Checked = True Then
                .CrAccountNo = "REV-MAINT-OTHER-CHARGES-" & gCurFlatCode
                .TxnType = "FACILITATION-FEE-RECEIPT"
            ElseIf optTenancyRegistrationFeeReceipt.Checked = True Then
                .CrAccountNo = "REV-MAINT-OTHER-CHARGES-" & gCurFlatCode
                .TxnType = "TENANCY-REGISTRATION-FEE-RECEIPT"
            ElseIf optMiscCollection_FlatOwner.Checked = True Then
                .CrAccountNo = "REV-MAINT-OTHER-CHARGES-" & gCurFlatCode
                .TxnType = "MISC-RECEIPT-OWNER"
            ElseIf optMiscCollection_NonFlatOwner.Checked = True Then
                .CrAccountNo = "REV-MISC-COLLECTION"
                .TxnType = "MISC-RECEIPT-NONOWNER"
            ElseIf optUntracedPaymentReceipt.Checked = True Then
                .CrAccountNo = "REV-MISC-COLLECTION"
                .TxnType = "UNTRACED-PAYEE-RECEIPT"
            End If

            .CreateTransaction()

            If .Status = False Then GoTo errH

            gid = .gid

        End With

        'Create entry in tblreceipt

        Dim thisReceipt As New clsReceipt

        With thisReceipt

            .FlatCode = cboFlatCode.Text
            .ReceiptAmount = txtReceiptAmount.Text
            .ReceiptDate = dtpReceiptDate.Text
            .ReceiptNo = rcpt_no
            .Remarks = txtNarration.Text

            .InstrumentType = cboInstrumentType.Text

            If cboInstrumentType.Text = "CASH" Then
                .InstrumentNo = "-"
                .InstrumentDate = "-"
                .InstrumentBank = "-"
                .refgid = "-"
            ElseIf (cboInstrumentType.Text = "CHEQUE") Or (cboInstrumentType.Text = "ONLINE") Then
                .InstrumentNo = stripLeadingZero(txtInstrumentNo.Text)
                .InstrumentDate = dtpInstrumentDate.Text
                .InstrumentBank = cboBankName.Text
                .refgid = ""
            End If
            .gid = gid
            .CreateReceipt()

            If .Status = False Then GoTo errH

        End With


        gcon.CommitTrans()


        'Log user activity
        gItemID = "Receipt No:" & rcpt_no
        gItemAction = "Create"

        If logUserActivity() = False Then GoTo errH

        MsgBox("Receipt recorded successfully")
        frmMain.sslabel3.Text = "Receipt recorded successfully"

        'send SMS for receipt agaisnt flat owners only
        'Note: receipt should be committed in db before calling sendSMS

        If (optMiscCollection_NonFlatOwner.Checked = False) Or (optUntracedPaymentReceipt.Checked = False)  Then
            Dim mySMS As New clsSendSMS
            mySMS.msgID = rcpt_no
            If mySMS.sendSMS4Receipt(rcpt_no) = True Then MsgBox("SMS sent successfully")
        End If

        refreshForm(True)
        optMaintBillCollection.Checked = True


        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)


    End Sub

    Sub refreshForm(includeReceipts As Boolean)
        Dim tmpCode As String

        If formLoadComplete = False Then Exit Sub

        tmpCode = cboFlatCode.Text
        If optMiscCollection_NonFlatOwner.Checked = True Then
            cboFlatCode.DataSource = MISC_PAYEE
        ElseIf optUntracedPaymentReceipt.Checked = True Then
            cboFlatCode.DataSource = UNKNOWN_PAYEE
        Else
            cboFlatCode.DataSource = FLATS
        End If
        cboFlatCode.Text = tmpCode

        loadAvailableReceipts()

        PopulateJournalBilled()
        PopulateJournalPaid()
        lblBalance.Text = "Net Outstanding:" & addThousandSeparator((NetDrAmt - NetCrAmt), True)
        lblDiffBGF.Text = NetBGF
        lblDiffAssoc.Text = addThousandSeparator(NetDrAmt - NetCrAmt - NetBGF, True)

        If includeReceipts = True Then
            cboBankName.Text = ""
            txtInstrumentNo.Text = ""
            'txtNarration.Text = "Maintenance service charge payment (Bill No:"
            txtReceiptAmount.Text = ""
            cboReceiptNo.SelectedIndex = -1
            cboInstrumentType.SelectedIndex = -1
        End If

        getBankNames()
        cboBankName.Items.Clear()
        For x = 1 To UBound(BankNames)
            cboBankName.Items.Add(BankNames(x))
        Next

        cboInstrumentType.Text = "CHEQUE"

        loadDefaultNarration()

        loadCheques()
        cboFlatCode.Focus()

    End Sub

    Function validateReceipt() As Boolean
        validateReceipt = False

        If Not IsNumeric(txtReceiptAmount.Text) Then
            MsgBox("Invalid receipt amount")
            Exit Function
        End If

        If txtReceiptAmount.Text <= 0 Then
            MsgBox("Invalid receipt amount")
            Exit Function
        End If

        If DateTime.Parse(dtpReceiptDate.Text).ToString(DB_DATEFORMAT) > DateTime.Now.ToString(DB_DATEFORMAT) Then
            MsgBox("Receipt date can't be in future")
            Exit Function
        End If

        If Trim(cboReceiptNo.Text) = "" Then
            MsgBox("Provide receipt no")
            Exit Function
        End If

        If Trim(txtNarration.Text) = "" Then
            MsgBox("Provide narration")
            Exit Function
        End If

        If cboInstrumentType.Text = "CASH" Then

        ElseIf cboInstrumentType.Text = "CHEQUE" Then
            If Trim(txtInstrumentNo.Text) = "" Then
                MsgBox("Provide cheque no")
                Exit Function
            End If
            If Trim(cboBankName.Text) = "" Then
                MsgBox("Provide bank name")
                Exit Function
            End If
        ElseIf cboInstrumentType.Text = "ONLINE" Then
            If Trim(txtInstrumentNo.Text) = "" Then
                MsgBox("Provide transaction reference no")
                Exit Function
            End If
            If Trim(cboBankName.Text) = "" Then
                MsgBox("Provide bank name")
                Exit Function
            End If

            If DateTime.Parse(dtpInstrumentDate.Text).ToString(DB_DATEFORMAT) > DateTime.Now.ToString(DB_DATEFORMAT) Then
                MsgBox("Transfer date can't be in future")
                Exit Function
            End If
        End If

        If Not ((optMiscCollection_NonFlatOwner.Checked = True) Or (optUntracedPaymentReceipt.Checked = True)) Then
            If IsNumeric(Mid(cboFlatCode.Text, 4, 2)) = False Then
                MsgBox("Invalid Flat Code for owner")
                Exit Function
            End If
        End If


        ssql = "select * from tblreceipt where ReceiptNo='" & Trim(cboReceiptNo.Text) & "'"
        tmpRS = gcon.Execute(ssql)
        If tmpRS.EOF = False Then
            MsgBox("This receipt no is already issued to " & tmpRS("FlatCode").Value.ToString & " on " & formatInt2Date(tmpRS("ReceiptDate").Value.ToString))
            Exit Function
        End If

        validateReceipt = True
    End Function


    Sub fetchFlatOwner()
        tmpRS = gcon.Execute("select * from tblflatowners where FlatCode='" & cboFlatCode.Text & "' and IsActiveOwner='Y'")
        If tmpRS.EOF = False Then
            lblOwnerDetails.Text = tmpRS("OwnerFullName").Value.ToString & Chr(10) & tmpRS("CoOwnerFullName").Value.ToString
        Else
            lblOwnerDetails.Text = ""
        End If
        tmpRS.Close()
    End Sub

    Sub fetchDuplexFlat()
        tmpRS = gcon.Execute("select DuplexFlatCode from tblflats where FlatCode='" & cboFlatCode.Text & "'")
        If tmpRS.EOF = False Then
            txtDuplexFlatCode.Text = tmpRS("DuplexFlatCode").Value.ToString
        Else
            txtDuplexFlatCode.Text = ""
        End If
        tmpRS.Close()
    End Sub

    Private Sub btnEditFlatOwnerDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnEditFlatOwnerDetails.Click
        'standard entry check code start
        gOldItemCode = gItemCode
        gItemCode = "frmManageFlatAndOwnerDetails"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = gOldItemCode
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end
        gCurFlatCode = cboFlatCode.Text
        frmManageFlats.ShowDialog()
        frmManageFlats.Dispose()
        gItemCode = gOldItemCode
    End Sub


    Private Sub btnBookPenalty_Click(sender As System.Object, e As System.EventArgs) Handles btnBookPenalty.Click
        gCurFlatCode = cboFlatCode.Text
        gItemCode = "Penalty"
        gCurGID = ""
        gCurTblID = ""
        frmBookPenalty.ShowDialog()
        frmBookPenalty.Dispose()
        gItemCode = "Receipts"
        refreshForm(True)
        'lblBalance.Text = "Outstanding: Rs. " & addThousandSeparator((NetDrAmt - NetCrAmt), True)
    End Sub


    Private Sub dtpReceiptDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpReceiptDate.ValueChanged
        dtpInstrumentDate.Text = dtpReceiptDate.Text
    End Sub


    Private Sub optMaintBillCollection_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optMaintBillCollection.CheckedChanged
        If optMaintBillCollection.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CHEQUE"
    End Sub

    Private Sub optAssocFormFundCollection_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optAssocFormFundCollection.CheckedChanged
        If optAssocFormFundCollection.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CHEQUE"
    End Sub

    Private Sub optStartrekCollection_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optStartrekCollection.CheckedChanged
        If optStartrekCollection.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CASH"
    End Sub
    Private Sub optOnDemandFlatServiceReceipt_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optOnDemandFlatServiceReceipt.CheckedChanged
        If optOnDemandFlatServiceReceipt.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CASH"
    End Sub

    Private Sub optEarthMoversCollection_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optEarthMoversCollection.CheckedChanged
        If optEarthMoversCollection.Checked = False Then Exit Sub

        refreshForm(True)
        If optEarthMoversCollection.Checked = True Then
            cboReceiptNo.Text = "EMBPL/"
        Else
            cboReceiptNo.SelectedIndex = -1
        End If
    End Sub
    Sub loadDefaultNarration()
        If optAssocFormFundCollection.Checked = True Then
            txtNarration.Text = "For association formation"
        ElseIf optStartrekCollection.Checked = True Then
            txtNarration.Text = "For STARTREK booking. Purpose:"
        ElseIf optMaintBillCollection.Checked = True Then
            txtNarration.Text = "Maintenance service charge payment (Bill No:"
        ElseIf optEarthMoversCollection.Checked = True Then
            txtNarration.Text = "Paid to Earth Movers & Builders Pvt. Ltd. (Bill No: "
        ElseIf optOnDemandFlatServiceReceipt.Checked = True Then
            txtNarration.Text = "Payment received for providing on demand maintenance/repair work. Nature of work done:  "
        ElseIf optFacilitationFeeReceipt.Checked = True Then
            txtNarration.Text = "Payments received from new owner towards facilitation charges for change of ownership of flat:" & cboFlatCode.Text
        ElseIf optTenancyRegistrationFeeReceipt.Checked = True Then
            txtNarration.Text = "Payments received towards tenancy registration fee of flat:" & cboFlatCode.Text & " for Tenant: "
        ElseIf optMiscCollection_FlatOwner.Checked = True Then
            txtNarration.Text = "Payments received from Payee:" & cboFlatCode.Text & " for"
        ElseIf optMiscCollection_NonFlatOwner.Checked = True Then
            txtNarration.Text = "Payments received for "
        End If
    End Sub

    Private Sub cboInstrumentType_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboInstrumentType.SelectedValueChanged
        If cboInstrumentType.Text = "CASH" Then
            dtpInstrumentDate.Enabled = False
            txtInstrumentNo.Enabled = False
            cboBankName.Enabled = False

            dtpInstrumentDate.Text = ""
            txtInstrumentNo.Text = ""
            cboBankName.Text = ""


        ElseIf cboInstrumentType.Text = "CHEQUE" Then
            dtpInstrumentDate.Enabled = True
            txtInstrumentNo.Enabled = True
            cboBankName.Enabled = True

            lblInstrumentDate.Text = "Cheque Date"
            lblInstrumentNo.Text = "Cheque No"

        ElseIf cboInstrumentType.Text = "ONLINE" Then
            dtpInstrumentDate.Enabled = True
            txtInstrumentNo.Enabled = True
            cboBankName.Enabled = True

            lblInstrumentDate.Text = "Transfer Date"
            lblInstrumentNo.Text = "Transaction Ref. No"
            loadBankAccounts("DR")
        End If
    End Sub

    Sub loadBankAccounts(where2Load As String)
        Dim actRS As ADODB.Recordset

        If where2Load = "DR" Then
            'cboDebitAccount.Items.Clear()
            'ElseIf where2Load = "CR" Then
            '    cboCreditAccount.Items.Clear()
            'ElseIf where2Load = "BOTH" Then
            '    cboDebitAccount.Items.Clear()
            '    cboCreditAccount.Items.Clear()
        End If

        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Assets' and ParentAccountNo = 'CASH-AT-BANK'"
        actRS = gcon.Execute(ssql)
        While actRS.EOF = False
            If where2Load = "DR" Then
                'cboDebitAccount.Items.Add(actRS("AccountNo").Value.ToString)
                'ElseIf where2Load = "CR" Then
                '    cboCreditAccount.Items.Add(actRS("AccountNo").Value.ToString)
                'ElseIf where2Load = "BOTH" Then
                '    cboDebitAccount.Items.Add(actRS("AccountNo").Value.ToString)
                '    cboCreditAccount.Items.Add(actRS("AccountNo").Value.ToString)
            End If
            actRS.MoveNext()
        End While
        actRS.Close()
        'cboCreditAccount.Text = ""
        'cboDebitAccount.Text = ""
    End Sub

    Private Sub btnOldMaintenanceBills_Click(sender As System.Object, e As System.EventArgs) Handles btnOldMaintenanceBills.Click
        Dim shortFlatCode As String

        shortFlatCode = myRight(cboFlatCode.Text, 3)
        If myLeft(shortFlatCode, 1) = "0" Then shortFlatCode = myRight(shortFlatCode, 2)
        Process.Start("D:\GFHPortal\sw\Apache2.2\htdocs\GFH\Bills\" & getTowerName(cboFlatCode.Text) & "\" & shortFlatCode & "\UptoFeb2012\" & myLeft(cboFlatCode.Text, 3) & "-" & shortFlatCode & "-UptoFeb2012.pdf")
    End Sub

    Private Sub btnOldEAMCBills_Click(sender As System.Object, e As System.EventArgs) Handles btnOldEAMCBills.Click
        Dim shortFlatCode As String

        shortFlatCode = myRight(cboFlatCode.Text, 3)
        If myLeft(shortFlatCode, 1) = "0" Then shortFlatCode = myRight(shortFlatCode, 2)
        Process.Start("D:\GFHPortal\sw\Apache2.2\htdocs\GFH\Bills\" & getTowerName(cboFlatCode.Text) & "\" & shortFlatCode & "\UptoFeb2012\" & myLeft(cboFlatCode.Text, 3) & "-" & shortFlatCode & "-UptoFeb2012-EAMC.pdf")

    End Sub

    Private Sub btnMarkAsBGFOutstandingPayment_Click(sender As System.Object, e As System.EventArgs) Handles btnMarkAsBGFOutstandingPayment.Click
        Dim tblid As String

        tblid = dgvJournalPaid.Rows(dgvJournalPaid.CurrentRow.Index).Cells(0).Value
        ssql = "update tbljournal set AccountNo='DEBTOR-CORPUS-FUND-" & cboFlatCode.Text & "' where tblid=" & tblid
        gcon.Execute(ssql)
        refreshForm(True)
    End Sub

    Private Sub btnMarkAsHIGAssocPayment_Click(sender As System.Object, e As System.EventArgs) Handles btnMarkAsHIGAssocPayment.Click
        Dim tblid As String

        tblid = dgvJournalPaid.Rows(dgvJournalPaid.CurrentRow.Index).Cells(0).Value
        ssql = "update tbljournal set AccountNo='DEBTOR-FLAT-" & cboFlatCode.Text & "' where tblid=" & tblid
        gcon.Execute(ssql)
        refreshForm(True)
    End Sub

    Private Sub btnMarkAsPaidToBGF_Click(sender As System.Object, e As System.EventArgs)
        Dim tblid As String

        tblid = dgvJournalPaid.Rows(dgvJournalPaid.CurrentRow.Index).Cells(0).Value
        ssql = "update tbljournal set AccountNo='DEBTOR-CORPUS-FUND-" & cboFlatCode.Text & "' where tblid=" & tblid
        gcon.Execute(ssql)
        refreshForm(True)
    End Sub

    Private Sub btnAdjustExtraPayment_Click(sender As System.Object, e As System.EventArgs) Handles btnAdjustExtraPayment.Click
        Dim strTxnDate As String, strAmount As String, gid As String

        If lblDiffBGF.Text >= 0 Then Exit Sub

        strAmount = lblDiffBGF.Text

        strTxnDate = dgvJournalPaid.Rows(dgvJournalPaid.CurrentRow.Index).Cells(2).Value
        gid = DateTime.Now.ToString("yyyyMMddhhmmssffff") & Strings.Left(gLoginID, Math.Min(Strings.Len(gLoginID), 12))

        ssql = "Insert into tbljournal (gid,TxnType,TxnDate,Narration,DocRef,AccountNo,DrAmount,CrAmount) values ("
        ssql = ssql & "'" & gid & "',"
        ssql = ssql & "'NULL-SPLIT',"
        ssql = ssql & "'" & DateTime.Parse(strTxnDate).ToString(DB_DATEFORMAT) & "',"
        ssql = ssql & "'" & "Transfer of excess payment" & "',"
        ssql = ssql & "'(Payee:" & cboFlatCode.Text & ")',"
        ssql = ssql & "'DEBTOR-FLAT-" & cboFlatCode.Text & "',"
        ssql = ssql & "0,"
        ssql = ssql & strAmount & ")"

        gcon.Execute(ssql)


        strAmount = (-1) * strAmount
        ssql = "Insert into tbljournal (gid,TxnType,TxnDate,Narration,DocRef,AccountNo,DrAmount,CrAmount) values ("
        ssql = ssql & "'" & gid & "',"
        ssql = ssql & "'NULL-SPLIT',"
        ssql = ssql & "'" & DateTime.Parse(strTxnDate).ToString(DB_DATEFORMAT) & "',"
        ssql = ssql & "'" & "Transfer of excess payment" & "',"
        ssql = ssql & "'(Payee:" & cboFlatCode.Text & ")',"
        ssql = ssql & "'DEBTOR-FLAT-" & cboFlatCode.Text & "',"
        ssql = ssql & "0,"
        ssql = ssql & strAmount & ")"

        gcon.Execute(ssql)

        refreshForm(True)

    End Sub

    Private Sub btnShowChequeDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnShowChequeDetails.Click
        Dim expActRS As ADODB.Recordset

        ssql = "select ReceiptNo from tblreceipt where InstrumentNo='" & cboChequeNo.Text & "'"
        expActRS = gcon.Execute(ssql)

        If expActRS.EOF = False Then
            gCurReceiptNo = expActRS("ReceiptNo").Value.ToString
            frmViewReceipt.ShowDialog()
            frmViewReceipt.Dispose()
        Else
            gCurReceiptNo = ""
            MsgBox("No matching receipt found")
        End If
    End Sub

    Private Sub btnBookOtherCharges_Click(sender As System.Object, e As System.EventArgs) Handles btnBookOtherCharges.Click
        gCurFlatCode = cboFlatCode.Text
        gItemCode = "OtherCharges"
        'refreshForm(False)
        gCurTblID = ""
        gCurGID = ""
        frmBookOtherCharge.ShowDialog()
        frmBookOtherCharge.Dispose()
        gItemCode = "Receipts"
        refreshForm(True)
        'PopulateJournalBilled()
        'PopulateJournalPaid()
        'lblBalance.Text = "Outstanding: Rs. " & addThousandSeparator((NetDrAmt - NetCrAmt), True)
    End Sub

    Private Sub dgvJournalBilled_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJournalBilled.CellContentDoubleClick
        On Error GoTo errH
        Dim pos1 As Integer, pos2 As Integer, thisNarration As String, thisTxnType As String, myDocRef As New clsDocRef

        'Start - Data Grid Click - common code to skip invalid clicks
        Dim ri As Integer, ci As Integer

        ri = dgvJournalBilled.CurrentCell.RowIndex
        If ri = 0 Then Exit Sub
        ci = dgvJournalBilled.CurrentCell.ColumnIndex
        gCurTblID = dgvJournalBilled.Rows(ri).Cells(0).Value 'tblid
        If gCurTblID = "" Then Exit Sub

        'End  - Data Grid Click - common code to skip invalid clicks


        thisTxnType = dgvJournalBilled.Rows(ri).Cells(1).Value 'tblid
        thisNarration = dgvJournalBilled.Rows(ri).Cells(3).Value 'tblid

        gOldItemCode = gItemCode

        
        'identify the type of txn clicked
        Select Case thisTxnType
            Case "MAINT-BILL-PENALTY"
                gFormDataChanged = False
                gCurGID = ""
                frmBookPenalty.ShowDialog()
                frmBookPenalty.Dispose()
                
                If gFormDataChanged = True Then
                    gFormDataChanged = False
                    refreshForm(False)
                End If


            Case "MAINT-BILL-OTHER-CHARGES"
                gFormDataChanged = False
                gCurGID = ""
                frmBookOtherCharge.ShowDialog()
                frmBookOtherCharge.Dispose()

                If gFormDataChanged = True Then
                    gFormDataChanged = False
                    refreshForm(False)
                End If

            Case "MAINT-BILL"
                pos1 = InStr(1, thisNarration, "Bill No:")
                If pos1 = 0 Then Exit Sub
                pos2 = InStr(pos1 + 8 + 1, thisNarration, ",")
                gCurBillNo = Trim(Mid(thisNarration, pos1 + 8, pos2 - pos1 - 8))
                frmShowBill.ShowDialog()
                frmShowBill.Dispose()
            Case "BGF-MAINT-BILL"
                Exit Sub
            Case "BGF-EAMC-BILL"
                Exit Sub
            Case Else
                Exit Sub

        End Select


        gItemCode = gOldItemCode
        Exit Sub

errH:
        MsgBox(Err.Description)
        gItemCode = gOldItemCode
    End Sub

    Private Sub dgvJournalBilled_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJournalBilled.CellContentClick
        Dim x As Double, thisCell As DataGridViewCell

        'Start - Data Grid Click - common code to skip invalid clicks
        Dim ri As Integer, ci As Integer

        ri = dgvJournalBilled.CurrentCell.RowIndex
        If ri = 0 Then Exit Sub
        ci = dgvJournalBilled.CurrentCell.ColumnIndex
        If ci <> 4 Then Exit Sub

        'End  - Data Grid Click - common code to skip invalid clicks


        For Each thisCell In dgvJournalBilled.SelectedCells
            'If thisCell.ColumnIndex = 4 Then
            x += thisCell.Value.ToString
            'End If
        Next
        lblSelectionSum.Text = addThousandSeparator(x, False)

    End Sub

    Private Sub dgvJournalPaid_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJournalPaid.CellContentClick

        Dim x As Double, thisCell As DataGridViewCell

        'Start - Data Grid Click - common code to skip invalid clicks
        Dim ri As Integer, ci As Integer

        ri = dgvJournalPaid.CurrentCell.RowIndex
        If ri = 0 Then Exit Sub
        ci = dgvJournalPaid.CurrentCell.ColumnIndex
        If ci <> 4 Then Exit Sub

        'End  - Data Grid Click - common code to skip invalid clicks

        For Each thisCell In dgvJournalPaid.SelectedCells
            If thisCell.ColumnIndex = 4 Then
                x += thisCell.Value.ToString
            End If
        Next
        lblSelectionSum.Text = addThousandSeparator(x, False)


    End Sub


    Private Sub dgvJournalPaid_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvJournalPaid.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If dgvJournalPaid.CurrentRow.Index < 0 Then Exit Sub
            receiptContextMenu.Show()
            receiptContextMenu.Left = Cursor.Position.X
            receiptContextMenu.Top = Cursor.Position.Y
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then

        End If
    End Sub

    Private Sub tsmiEmailReceipt_Click(sender As System.Object, e As System.EventArgs) Handles tsmiEmailReceipt.Click
        Dim myDocRef As New clsDocRef, thisDocRef As String, thisReceiptAmt As String, thisMailId As String, tmpStr As String, myReceipt As New clsReceipt

        thisMailId = getMailID()
        If thisMailId = "" Then
            MsgBox(lblOwnerDetails.Text & " does not have a valid email id registered in the system")
            Exit Sub
        End If

        thisReceiptAmt = dgvJournalPaid.Rows(dgvJournalPaid.CurrentRow.Index).Cells(4).Value
        thisDocRef = dgvJournalPaid.Rows(dgvJournalPaid.CurrentRow.Index).Cells(3).Value
        gCurReceiptNo = myDocRef.getReceiptNo(thisDocRef)
        If MsgBox("Are you sure, you want to mail the confirmation for receipt no " & gCurReceiptNo & " of amount " & thisReceiptAmt & " to " & lblOwnerDetails.Text, MsgBoxStyle.YesNo) = vbNo Then Exit Sub

        myReceipt.loadSingleReceipt("", gCurReceiptNo, "")
        If myReceipt.Status = False Then Exit Sub


        tmpStr = "Dear " & lblOwnerDetails.Text
        tmpStr = tmpStr & vbCrLf & vbCrLf
        tmpStr = tmpStr & "This is to confirm that we have issued the receipt no - " & gCurReceiptNo & " against flat " & cboFlatCode.Text & " as per below details:"
        tmpStr = tmpStr & vbCrLf & vbCrLf
        tmpStr = tmpStr & thisDocRef

        If ((myReceipt.InstrumentType = "CHEQUE") And (myReceipt.refgid = "")) Then
            tmpStr = tmpStr & vbCrLf
            tmpStr = tmpStr & "Note: This receipt is subject to realization of the cheque."
        ElseIf ((myReceipt.InstrumentType = "ONLINE") And (myReceipt.refgid = "")) Then
            tmpStr = tmpStr & vbCrLf
            tmpStr = tmpStr & "Note: This receipt is subject to confirmation of the online transfer against bank statement."
        End If

        tmpStr = tmpStr & vbCrLf & vbCrLf
        tmpStr = tmpStr & "<B>PS: This is a system generated mail, please do not reply to this mail id.</B>"
        tmpStr = tmpStr & vbCrLf
        tmpStr = tmpStr & "If you notice any discrepancy in your receipt, please reply to email address:<B> tothefm.gfh.hig@gmail.com </B>"
        tmpStr = tmpStr & vbCrLf & vbCrLf
        tmpStr = tmpStr & "With Warm Regards,"
        tmpStr = tmpStr & vbCrLf
        tmpStr = tmpStr & "Greenfield Heights HIG Association"
        tmpStr = tmpStr & vbCrLf
        tmpStr = tmpStr & DateTime.Now.ToString("dd-MMM-yyyy HH:mm") & " IST"

        'standard entry check code start
        gOldItemCode = gItemCode
        gItemCode = "frmMailPreview"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = gOldItemCode
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end

        'launch form
        Dim frm As New frmMailPreview

        frm.WindowState = FormWindowState.Minimized
        frm.WindowState = FormWindowState.Normal

        frm.txtFrom.Text = gUserName & ", GFH HIG Association"
        frm.txtTo.Text = thisMailId
        frm.txtReplyTo.Text = getSysParamValue("MAIL_REPLYTO_RECEIPT")
        frm.txtSubject.Text = "Greenfield Heights(HIG) Association : Confirmation of Receipt - " & gCurReceiptNo
        frm.txtBody.Text = tmpStr
        'frm.Parent = Me
        'frm.MdiParent = frmMain
        frm.ShowDialog()
        gItemCode = gOldItemCode
        gCurReceiptNo = ""

    End Sub
    Function getMailID() As String
        Dim flatRS As ADODB.Recordset, flSql As String
        flSql = "select fo.p_email1,fo.PrimaryEmail from tblflatowners fo "
        flSql = flSql & " where fo.FlatCode = '" & cboFlatCode.Text & "' and fo.IsActiveOwner='Y'"

        flatRS = gcon.Execute(flSql)

        If (flatRS("p_email1").Value.ToString <> "") Then
            getMailID = flatRS("p_email1").Value.ToString
        ElseIf ((flatRS("PrimaryEmail").Value.ToString <> "") And (InStr(flatRS("PrimaryEmail").Value.ToString, "@") > 0)) Then
            getMailID = flatRS("PrimaryEmail").Value.ToString
        Else
            getMailID = ""
        End If

    End Function
    Private Sub tsmiEditReceipt_Click(sender As System.Object, e As System.EventArgs) Handles tsmiEditReceipt.Click
        On Error GoTo errH
        Dim myDocRef As New clsDocRef, thisDocRef As String

        'Start - Data Grid Click - common code to skip invalid clicks
        Dim ri As Integer, ci As Integer

        ri = dgvJournalPaid.CurrentCell.RowIndex
        If ri < 0 Then Exit Sub
        ci = dgvJournalPaid.CurrentCell.ColumnIndex

        thisDocRef = dgvJournalPaid.Rows(ri).Cells(3).Value
        gCurReceiptNo = myDocRef.getReceiptNo(thisDocRef)
        If gCurReceiptNo = "" Then
            MsgBox("This is not a valid receipt")
            Exit Sub
        End If
        'End  - Data Grid Click - common code to skip invalid clicks

        
        gOldItemCode = gItemCode
        gItemCode = "frmViewReceipt"
        frmViewReceipt.ShowDialog()
        frmViewReceipt.Dispose()
        gCurReceiptNo = ""
        refreshForm(True)
        gItemCode = gOldItemCode

        Exit Sub

errH:
        MsgBox(Err.Description)
        gItemCode = gOldItemCode
    End Sub


    Private Sub cboFinYear_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFinYear.SelectedValueChanged
        lFinYear.SetToFinYear(cboFinYear.Text)
        lblFinYear.Text = lFinYear.startDateDisplay & " - " & lFinYear.endDateDisplay
        btnQuery.PerformClick()

    End Sub


    Private Sub cboFlatCode_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFlatCode.SelectedValueChanged
        'dgvJournalBilled.Rows.Clear()
        'dgvJournalPaid.Rows.Clear()
        lblOwnerDetails.Text = ""
        lblBalance.Text = ""
        fetchFlatOwner()
        fetchDuplexFlat()
        gCurFlatCode = cboFlatCode.Text
        refreshForm(True)
        'PopulateJournalBilled()
        'PopulateJournalPaid()
        'loadDefaultNarration()
    End Sub

    Private Sub cboFinYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFinYear.SelectedIndexChanged

    End Sub

    Private Sub btnAdjustCorpusOutstanding_Click(sender As Object, e As EventArgs) Handles btnAdjustCorpusOutstanding.Click
        Dim strTxnDate As String, strAmount As String, gid As String

        If gLoginID <> "sa" Then Exit Sub

        If lblDiffBGF.Text <= 0 Then Exit Sub

        strAmount = lblDiffBGF.Text
        strAmount = (-1) * strAmount

        strTxnDate = "31-Mar-2013"
        gid = DateTime.Parse(strTxnDate).ToString("yyyyMMddhhmmssffff") & Strings.Left(gLoginID, Math.Min(Strings.Len(gLoginID), 12))

        ssql = "Insert into tbljournal (gid,TxnType,TxnDate,Narration,DocRef,AccountNo,DrAmount,CrAmount) values ("
        ssql = ssql & "'" & gid & "',"
        ssql = ssql & "'CONTRA-CORPUS',"
        ssql = ssql & "'" & DateTime.Parse(strTxnDate).ToString(DB_DATEFORMAT) & "',"
        ssql = ssql & "'" & "flat owner to settle this outstanding directly with BGF" & "',"
        ssql = ssql & "'(Payee:" & cboFlatCode.Text & ")',"
        ssql = ssql & "'CORPUS-FUND-" & cboFlatCode.Text & "',"
        ssql = ssql & "0,"
        ssql = ssql & strAmount & ")"

        gcon.Execute(ssql)



        ssql = "Insert into tbljournal (gid,TxnType,TxnDate,Narration,DocRef,AccountNo,CrAmount,DrAmount) values ("
        ssql = ssql & "'" & gid & "',"
        ssql = ssql & "'CONTRA-CORPUS',"
        ssql = ssql & "'" & DateTime.Parse(strTxnDate).ToString(DB_DATEFORMAT) & "',"
        ssql = ssql & "'" & "flat owner to settle this outstanding directly with BGF" & "',"
        ssql = ssql & "'(Payee:" & cboFlatCode.Text & ")',"
        ssql = ssql & "'DEBTOR-CORPUS-FUND-" & cboFlatCode.Text & "',"
        ssql = ssql & "0,"
        ssql = ssql & strAmount & ")"

        gcon.Execute(ssql)

        refreshForm(True)
    End Sub


    Private Sub optTenancyRegistrationFeeReceipt_CheckedChanged(sender As Object, e As EventArgs) Handles optTenancyRegistrationFeeReceipt.CheckedChanged
        If optTenancyRegistrationFeeReceipt.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CASH"
    End Sub

    Private Sub optFacilitationFeeReceipt_CheckedChanged(sender As Object, e As EventArgs) Handles optFacilitationFeeReceipt.CheckedChanged
        If optFacilitationFeeReceipt.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CHEQUE"
    End Sub

    Private Sub optMiscCollection_FlatOwner_CheckedChanged(sender As Object, e As EventArgs) Handles optMiscCollection_FlatOwner.CheckedChanged
        If optMiscCollection_FlatOwner.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CASH"
    End Sub

    Private Sub optMiscCollection_NonFlatOwner_CheckedChanged(sender As Object, e As EventArgs) Handles optMiscCollection_NonFlatOwner.CheckedChanged
        If optMiscCollection_NonFlatOwner.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CASH"
        'cboFlatCode.SelectedIndex = cboFlatCode.Items.Count - 1
    End Sub

    Private Sub btnQuickEntry_Click(sender As Object, e As EventArgs) Handles btnQuickEntry.Click

        If optMaintBillCollection.Checked = False Then Exit Sub

        Dim thisReceipt As New clsReceipt, quickRS As ADODB.Recordset
        quickRS = gcon.Execute("select max(tblid) lastReceiptId from tblreceipt where FlatCode='" & cboFlatCode.Text & "'")

        thisReceipt.loadSingleReceipt(quickRS("lastReceiptId").Value.ToString, "", "")
        If thisReceipt.Status = False Then Exit Sub

        With thisReceipt
            cboReceiptNo.SelectedIndex = 0
            txtReceiptAmount.Text = .ReceiptAmount
            cboInstrumentType.Text = .InstrumentType
            txtNarration.Text = txtNarration.Text & " - " & DateTime.Now.ToString("MMM-yyyy") & " )"
            If .InstrumentType = "CASH" Then

            ElseIf .InstrumentType = "CHEQUE" Then
                cboBankName.Text = .InstrumentBank
            ElseIf .InstrumentType = "ONLINE" Then
                cboBankName.Text = .InstrumentBank
            End If
        End With

    End Sub

    Private Sub tsmiSMSReceipt_Click(sender As Object, e As EventArgs) Handles tsmiSMSReceipt.Click
        Dim thisDocRef As String, tmpTxnType As String, myDocRef As New clsDocRef

        tmpTxnType = dgvJournalPaid.Rows(dgvJournalPaid.CurrentRow.Index).Cells(1).Value
        If tmpTxnType = "MISC-RECEIPT-NONOWNER" Then
            MsgBox("SMS facility is not available for receipts issued to non flat owners")
            Exit Sub
        End If
        thisDocRef = dgvJournalPaid.Rows(dgvJournalPaid.CurrentRow.Index).Cells(3).Value
        gCurReceiptNo = myDocRef.getReceiptNo(thisDocRef)

        Dim mySMS As New clsSendSMS
        mySMS.msgID = gCurReceiptNo
        If mySMS.sendSMS4Receipt(gCurReceiptNo) = True Then MsgBox("SMS sent successfully")

    End Sub

    Private Sub optUntracedPaymentReceipt_CheckedChanged(sender As Object, e As EventArgs) Handles optUntracedPaymentReceipt.CheckedChanged
        If optUntracedPaymentReceipt.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CASH"
    End Sub
End Class