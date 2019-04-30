Public Class frmJournalSpecialTxnsCultural
    Private allAccountsStr As String = ""
    Private lFinYear As New clsFinYear
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim tmpRS As ADODB.Recordset

        If DateTime.Parse(dtpTxnDate.Text) > DateTime.Now.Date Then
            MsgBox("Transaction date can't be future date")
            Exit Sub
        End If

        If cboCreditAccount.Text = cboDebitAccount.Text Then
            MsgBox("Debit/Credit accounts can't be same")
            Exit Sub
        End If
        If (cboCreditAccount.Text = "") Then
            MsgBox("Provide Credit account.")
            Exit Sub
        End If
        If (cboDebitAccount.Text = "") Then
            MsgBox("Provide Debit account.")
            Exit Sub
        End If


        If Trim(txtNarration.Text) = "" Then
            MsgBox("Enter narration")
            Exit Sub
        End If

        If cboTxnType.Text = "CASH-WITHDRAWAL-BY-CHEQUE" Then
            If Trim(cboInstrumentNo.Text) = "" Then
                MsgBox("Enter cheque number")
                Exit Sub
            End If
            'Check that the cheque number is available for use
            ssql = "select tblid from tblchequebook where ChequeNo = '" & stripLeadingZero(cboInstrumentNo.Text) & "' and Status is null and AccountNo='" & cboCreditAccount.Text & "'"
            tmpRS = gcon.Execute(ssql)

            If tmpRS.EOF = True Then
                MsgBox("This cheque no " & cboInstrumentNo.Text & " is not available for use as per defined Cheque Books for this account in the system")
                Exit Sub
            End If
        End If

        If cboTxnType.Text = "ELECTRICITY-REFUND" Then
            If Trim(cboInstrumentNo.Text) = "" Then
                MsgBox("Enter cheque number")
                Exit Sub
            End If
        End If

        'End If

        JournalPayment()


        lblDrBalance.Text = addThousandSeparator(getAccountBalance(dtpTxnDate.Text, cboDebitAccount.Text), False)
        lblCrBalance.Text = addThousandSeparator(getAccountBalance(dtpTxnDate.Text, cboCreditAccount.Text), False)
        frmMain.sslabel3.Text = "Success"

        txtTxnAmount.Text = ""
        'txtInstrumentNo.Text = ""
        txtNarration.Text = ""

        PopulateJournal_b()

        'txtInstrumentNo.Focus()
    End Sub

    Sub JournalPayment()
        On Error GoTo errH

        Dim tmpStr As String

        'Journalise Payment
        Dim thisJournal As New clsJournal_Cult
        With thisJournal
            .Narration = txtNarration.Text
            .TxnType = cboTxnType.Text
            '.DocRef = cboTxnType.Text & ",as per bank statement"
            'If cboTxnType.Text = "PROVISION-FOR-TAX" Then
            '    .DocRef = "(Provisioned for expense)"
            '    .VoucherType = "JV"
            '    .TxnType = "EXPENSE"
            'ElseIf cboTxnType.Text = "GENERAL-FUND-2-CORPUS-FUND" Then
            '    .DocRef = "-"
            '    .VoucherType = "JV"
            '    .TxnType = "BALANCESHEET-TXN"
            'End If

            If cboTxnType.Text = "ELECTRICITY-ADVANCE-PAYMENT" Then
                .DocRef = cboTxnType.Text & ",Electricity Advance By CASH"
                .VoucherType = "JV"
                .TxnType = "ADVANCE"
            ElseIf cboTxnType.Text = "ELECTRICITY-REFUND" Then
                .DocRef = cboTxnType.Text & ",Cheque No:" & stripLeadingZero(cboInstrumentNo.Text) & ",Cheque Date:" & dtpInstrumentDate.Value & ",Electricity Refund"
                .VoucherType = "JV"
                .TxnType = "ADVANCE"
            ElseIf cboTxnType.Text = "ELECTRICITY-CONSUMPTION-AGAINST-ADVANCE" Then
                .DocRef = cboTxnType.Text & ",Electricity Consumption to be adjusted against Advance"
                .VoucherType = "JV"
                .TxnType = "EXPENSE"
            ElseIf (cboTxnType.Text = "CASH-WITHDRAWAL-BY-CHEQUE") Then
                .DocRef = cboTxnType.Text & ",Cheque No:" & stripLeadingZero(cboInstrumentNo.Text) & ",Cheque Date:" & dtpInstrumentDate.Value & ",Yourself withdrawal"
                .VoucherType = "CV"
            ElseIf cboTxnType.Text = "PROVISION-FOR-AUDIT-FEE" Then
                .DocRef = "(Provisioned for expense)"
                .VoucherType = "JV"
                .TxnType = "EXPENSE"
                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = txtTxnAmount.Text
                .TxnDate = dtpTxnDate.Text


            ElseIf cboTxnType.Text = "GENERAL-FUND-2-CORPUS-FUND" Then
                .DocRef = "-"
                .VoucherType = "JV"
                .TxnType = "BALANCESHEET-TXN"
                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = txtTxnAmount.Text
                .TxnDate = dtpTxnDate.Text


            End If

            'If cboTxnType.Text = "CHEQUE-2-BANK" Then
            '    .DocRef = .DocRef & ",Cheque No:" & stripLeadingZero(txtInstrumentNo.Text)
            '    .DocRef = .DocRef & "," & txtNarration.Text
            '    .Narration = "Not reconciled yet"
            '    .VoucherType = "RV"
            'ElseIf (cboTxnType.Text = "BANK-2-CHEQUE") Then
            '    .DocRef = .DocRef & ",Cheque No:" & stripLeadingZero(txtInstrumentNo.Text)
            '    .DocRef = .DocRef & "," & txtNarration.Text
            '    .Narration = "Not reconciled yet"
            '    .VoucherType = "PV"
            'ElseIf cboTxnType.Text = "NEFT-2-BANK" Then
            '    .DocRef = .DocRef & ",NEFT Ref:" & stripLeadingZero(txtInstrumentNo.Text)
            '    '.DocRef = .DocRef & "," & txtNarration.Text
            '    .Narration = "Not reconciled yet"
            '    .VoucherType = "RV"
            'ElseIf (cboTxnType.Text = "BANK-2-CASH") Then
            '    .DocRef = .DocRef & ",Yourself withdrawal"
            '    .VoucherType = "CV"
            'ElseIf cboTxnType.Text = "CASH-2-BANK" Then
            '    .DocRef = .DocRef & ",By Cash"
            '    .VoucherType = "CV"


            'ElseIf cboTxnType.Text = "DD-2-BANK" Then
            '    .DocRef = .DocRef & ",By DD/PO"
            'ElseIf cboTxnType.Text = "BANK-2-DD" Then
            '    .DocRef = .DocRef & ",Cheque No:" & stripLeadingZero(txtInstrumentNo.Text)


            'ElseIf cboTxnType.Text = "INTEREST-4M-BANK" Then
            '.DocRef = .DocRef & ",Bank Interest"
            '.VoucherType = "RV"
            'ElseIf cboTxnType.Text = "BANK-2-TD" Then
            '.DocRef = .DocRef & ",New TD Created"
            '.VoucherType = "PV"
            'ElseIf cboTxnType.Text = "TD-2-BANK" Then
            '.DocRef = .DocRef & ",TD Closed"
            '.VoucherType = "RV"
            'End If

            .DrAccountNo = cboDebitAccount.Text
            .CrAccountNo = cboCreditAccount.Text
            .Amount = txtTxnAmount.Text
            .TxnDate = dtpTxnDate.Text

            gcon.BeginTrans()
            .CreateTransaction()

            If .Status = False Then GoTo errH
            If (cboTxnType.Text = "CASH-WITHDRAWAL-BY-CHEQUE") Then
                ssql = "Update tblchequebook set Status='U',Remarks='Used' where ChequeNo = '" & stripLeadingZero(cboInstrumentNo.Text) & "' and AccountNo='" & cboCreditAccount.Text & "'"
                gcon.Execute(ssql)
            End If
            gcon.CommitTrans()

            gItemAction = "Create"
            gItemID = cboTxnType.Text
        End With

        If logUserActivity() = False Then GoTo errH

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
        gcon.RollbackTrans()
    End Sub

    Sub resetFields()
        'dtpInstrumentDate.Enabled = False
        'txtInstrumentNo.Enabled = False

        'dtpInstrumentDate.Text = ""
        'txtInstrumentNo.Text = ""

        txtTxnAmount.Text = ""
        txtNarration.Text = ""
        'cboDebitAccount.Text = ""
        'cboCreditAccount.Text = ""
        cboDebitAccount.Items.Clear()
        cboCreditAccount.Items.Clear()
        cboDebitAccount.SelectedIndex = -1
        cboCreditAccount.SelectedIndex = -1

        txtCreditActDesc.Text = ""
        txtDebitActDesc.Text = ""

        cboTxnType.Items.Clear()

        cboTxnType.Items.Add("CASH-WITHDRAWAL-BY-CHEQUE")
        cboTxnType.Items.Add("ELECTRICITY-ADVANCE-PAYMENT")
        cboTxnType.Items.Add("ELECTRICITY-REFUND")
        cboTxnType.Items.Add("ELECTRICITY-CONSUMPTION-AGAINST-ADVANCE")
        cboTxnType.Items.Add("PROVISION-FOR-AUDIT-FEE")
        cboTxnType.Items.Add("GENERAL-FUND-2-CORPUS-FUND")

        cboInstrumentNo.Enabled = False
        cboInstrumentNo.DropDownStyle = ComboBoxStyle.DropDown

        'cboTxnType.Items.Add("CHEQUE-2-BANK")
        'cboTxnType.Items.Add("NEFT-2-BANK")
        'cboTxnType.Items.Add("CASH-2-BANK")
        ''cboTxnType.Items.Add("DD-2-BANK")
        'cboTxnType.Items.Add("BANK-2-BANK")
        ''cboTxnType.Items.Add("CASH-2-DD")
        ''cboTxnType.Items.Add("BANK-2-DD")
        'cboTxnType.Items.Add("BANK-2-CASH")
        'cboTxnType.Items.Add("BANK-2-CHEQUE")
        'cboTxnType.Items.Add("INTEREST-4M-BANK")
        'cboTxnType.Items.Add("BANK-2-TD")
        'cboTxnType.Items.Add("TD-2-BANK")

        'cboTxnType.Items.Add("ONLINE PAYMENTS")

        cboTxnType.SelectedIndex = -1

    End Sub

    Sub loadChequeIssuedCultAccounts()
        Dim expActRS As ADODB.Recordset

        cboCreditAccount.Items.Clear()
        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Liabilities' and ParentAccountNo = 'CHEQUE-ISSUED-ALL-CULT'"
        expActRS = gcon.Execute(ssql)

        While expActRS.EOF = False
            cboCreditAccount.Items.Add(expActRS("AccountNo").Value.ToString)
            expActRS.MoveNext()
        End While
        expActRS.Close()
    End Sub

    Sub loadAvailableCheques()
        Dim expActRS As ADODB.Recordset

        cboInstrumentNo.Items.Clear()
        ssql = "select ChequeNo from tblchequebook where Status is null and AccountNo='" & cboCreditAccount.Text & "'"
        expActRS = gcon.Execute(ssql)

        While expActRS.EOF = False
            cboInstrumentNo.Items.Add(expActRS("ChequeNo").Value.ToString)
            expActRS.MoveNext()
        End While
        expActRS.Close()
    End Sub

    Private Sub cboDebitAccount_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboDebitAccount.SelectedValueChanged
        txtDebitActDesc.Text = getAccountName(cboDebitAccount.Text)
        lblDrBalance.Text = addThousandSeparator(getAccountBalance_Cult(dtpTxnDate.Text, cboDebitAccount.Text), False)
        loadNarrationTemplates()
        'btnQueryTxn.PerformClick()
    End Sub


    Private Sub cboCreditAccount_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboCreditAccount.SelectedValueChanged
        txtCreditActDesc.Text = getAccountName(cboCreditAccount.Text)
        lblCrBalance.Text = addThousandSeparator(getAccountBalance_Cult(dtpTxnDate.Text, cboCreditAccount.Text), False)
        'btnQueryTxn.PerformClick()
        loadAvailableCheques()
        loadNarrationTemplates()
    End Sub


    Private Sub frmJournalSpecialTxns_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        resetFields()
    End Sub


    Sub PopulateJournal_b()
        On Error GoTo errH
        Dim i As Long, netDrAmt As Double, netCrAmt As Double, rsJournal As ADODB.Recordset, journalQuerySQL As String


        netDrAmt = 0
        netCrAmt = 0

        dgvJournal_b.Rows.Clear()

        journalQuerySQL = "select * from tbljournal_cult WHERE "

        If cboTxnType.Text = "CASH-WITHDRAWAL-BY-CHEQUE" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='CASH-WITHDRAWAL-BY-CHEQUE'"
        ElseIf cboTxnType.Text = "ELECTRICITY-ADVANCE-PAYMENT" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='ADVANCE'"
        ElseIf cboTxnType.Text = "ELECTRICITY-REFUND" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='ADVANCE'"
        ElseIf cboTxnType.Text = "ELECTRICITY-CONSUMPTION-AGAINST-ADVANCE" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='EXPENSE' and AccountNo in ('ADVANCE-WBSEB-CULT','EXPCULTCUR-ELECTRICALS')"
        ElseIf cboTxnType.Text = "PROVISION-FOR-AUDIT-FEE" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='EXPENSE'"
        ElseIf cboTxnType.Text = "GENERAL-FUND-2-CORPUS-FUND" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='BALANCESHEET-TXN'"
            'ElseIf cboTxnType.Text = "GENERAL-FUND-2-CORPUS-FUND" Then
            '    journalQuerySQL = journalQuerySQL & " and TxnType ='BALANCESHEET-TXN'"
            'ElseIf cboTxnType.Text = "DEPRECIATION-EXPENSE" Then
            '    journalQuerySQL = journalQuerySQL & " and TxnType ='DEPRECIATION-EXPENSE'"

        End If
        'journalQuerySQL = journalQuerySQL & " AND TxnDate='" & DateTime.Parse(dtpTxnDate.Text).ToString(DB_DATEFORMAT) & "'"

        'journalQuerySQL = journalQuerySQL & " (AccountNo='" & cboCreditAccount.Text & "' OR "
        'journalQuerySQL = journalQuerySQL & "  AccountNo='" & cboDebitAccount.Text & "' )"
        'journalQuerySQL = journalQuerySQL & " and status is null"
        journalQuerySQL = journalQuerySQL & " order by TxnDate desc"
        rsJournal = gcon.Execute(journalQuerySQL)

        With dgvJournal_b

            While rsJournal.EOF = False

                i = .Rows.Add()
                .Rows(i).Cells("tblid_b").Value = rsJournal("tblid").Value.ToString
                .Rows(i).Cells("gid_b").Value = rsJournal("gid").Value.ToString
                .Rows(i).Cells("TxnType_b").Value = rsJournal("TxnType").Value.ToString
                .Rows(i).Cells("TxnDate_b").Value = formatInt2Date(rsJournal("TxnDate").Value.ToString)
                .Rows(i).Cells("Narration_b").Value = rsJournal("Narration").Value.ToString
                .Rows(i).Cells("DocRef_b").Value = rsJournal("DocRef").Value.ToString
                .Rows(i).Cells("AccountNo_b").Value = rsJournal("AccountNo").Value.ToString
                .Rows(i).Cells("DrAmount_b").Value = rsJournal("DrAmount").Value.ToString
                .Rows(i).Cells("CrAmount_b").Value = rsJournal("CrAmount").Value.ToString
                .Rows(i).Cells("refgid_b").Value = rsJournal("refgid").Value.ToString

                netDrAmt = netDrAmt + rsJournal("DrAmount").Value.ToString
                netCrAmt = netCrAmt + rsJournal("CrAmount").Value.ToString

                .Rows(i).ReadOnly = True
                'if not reconciled with bank, then set forecolor to red, else green.
                If rsJournal("refgid").Value.ToString = "" Then
                    .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                End If
                If rsJournal("Status").Value.ToString = "C" Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Black
                Else
                    .Rows(i).DefaultCellStyle.BackColor = Color.White
                End If
                rsJournal.MoveNext()

            End While

            lblBalance_b.Text = "Rs. " & addThousandSeparator(netDrAmt)
            lblCnt_b.Text = "Txn Cnt: " & dgvJournal_b.Rows.Count

        End With

        rsJournal.Close()

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Private Sub btnQueryTxn_Click(sender As System.Object, e As System.EventArgs) Handles btnQueryTxn.Click
        PopulateJournal_b()
    End Sub

    Private Sub cboTxnType_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboTxnType.SelectedValueChanged
        'txtInstrumentNo.Enabled = False

        'lblRemarks.Text = "Bank comments"
        txtNarration.Text = ""
        txtNarration.Enabled = True
        'btnLoadTDAccountsInCrCombo.Enabled = False
        'btnLoadTDAccountsInDrCombo.Enabled = False
        cboInstrumentNo.Enabled = False
        cboInstrumentNo.DropDownStyle = ComboBoxStyle.DropDown

        Select Case cboTxnType.Text

            Case "PROVISION-FOR-AUDIT-FEE"
                With cboDebitAccount
                    .Items.Clear()
                    .Items.Add("EXP-AUDIT-FEES-CULT")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                With cboCreditAccount
                    .Items.Clear()
                    .Items.Add("PROVISION-FOR-AUDIT-FEE-CULT")
                    .SelectedIndex = 0
                    .Enabled = False
                End With

            Case "GENERAL-FUND-2-CORPUS-FUND"
                With cboDebitAccount
                    .Items.Clear()
                    .Items.Add("GENERAL-FUND-CULT")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                With cboCreditAccount
                    .Items.Clear()
                    .Items.Add("CORPUS-FUND-ADD-CULT")
                    .SelectedIndex = 0
                    .Enabled = False
                End With

            Case "CASH-WITHDRAWAL-BY-CHEQUE"
                With cboDebitAccount
                    .Items.Clear()
                    .Items.Add("CASHBOX-CULT")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                loadChequeIssuedCultAccounts()
                cboInstrumentNo.Enabled = True
                cboInstrumentNo.DropDownStyle = ComboBoxStyle.DropDownList

            Case "ELECTRICITY-ADVANCE-PAYMENT" 'Payment by Cash and Refund by Cheque - need to support both cash & cheque later
                With cboDebitAccount
                    .Items.Clear()
                    .Items.Add("ADVANCE-WBSEB-CULT")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                With cboCreditAccount
                    .Items.Clear()
                    .Items.Add("CASHBOX-CULT")
                    .SelectedIndex = 0
                    .Enabled = False
                End With

            Case "ELECTRICITY-REFUND" 'Payment by Cash and Refund by Cheque - need to support both cash & cheque later
                With cboDebitAccount
                    .Items.Clear()
                    .Items.Add("CHEQUE-IN-HAND-CULT")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                With cboCreditAccount
                    .Items.Clear()
                    .Items.Add("ADVANCE-WBSEB-CULT")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                cboInstrumentNo.Enabled = True

            Case "ELECTRICITY-CONSUMPTION-AGAINST-ADVANCE"
                With cboDebitAccount
                    .Items.Clear()
                    .Items.Add("EXPCULTCUR-ELECTRICALS")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                With cboCreditAccount
                    .Items.Clear()
                    .Items.Add("ADVANCE-WBSEB-CULT")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                'Dim myAuditReports As New clsAuditReports
                'txtTxnAmount.Text = (-1) * myAuditReports.getAccountBalanceBetweenDates(gFinYear.startDate, gFinYear.endDate, "INCOME-OVER-EXPENSE", "NET")

                '    'loadBankAccounts("DR")
                '    'cboCreditAccount.Items.Add("CHEQUE-IN-HAND")
                '    'cboCreditAccount.Text = "CHEQUE-IN-HAND"
                '    'cboDebitAccount.Enabled = True
                '    'cboCreditAccount.Enabled = False
                '    'lblInstrumentNo.Text = "Cheque No"
                '    'txtInstrumentNo.Enabled = True

                '    'lblTxnType.Text = "Cheque deposited into our bank account"


                'Case "CHEQUE-2-BANK"
                '    loadBankAccounts("DR")
                '    cboCreditAccount.Items.Add("CHEQUE-IN-HAND")
                '    cboCreditAccount.Text = "CHEQUE-IN-HAND"
                '    cboDebitAccount.Enabled = True
                '    cboCreditAccount.Enabled = False
                '    lblInstrumentNo.Text = "Cheque No"
                '    txtInstrumentNo.Enabled = True

                '    lblTxnType.Text = "Cheque deposited into our bank account"

                'Case "BANK-2-CHEQUE"
                '    loadChequeIssuedAccounts()
                '    'cboDebitAccount.Items.Add("CHEQUE-ISSUED")
                '    'cboDebitAccount.Text = "CHEQUE-ISSUED"

                '    loadBankAccounts("CR")
                '    cboDebitAccount.Enabled = True
                '    cboCreditAccount.Enabled = True
                '    lblInstrumentNo.Text = "Cheque No"
                '    txtInstrumentNo.Enabled = True

                '    lblTxnType.Text = "We paid from our bank account through cheque"

                'Case "NEFT-2-BANK"
                '    loadBankAccounts("DR")
                '    cboCreditAccount.Items.Add("NEFT-NOT-RECONCILED")
                '    cboCreditAccount.Text = "NEFT-NOT-RECONCILED"
                '    cboDebitAccount.Enabled = True
                '    cboCreditAccount.Enabled = False
                '    lblInstrumentNo.Text = "NEFT Ref"
                '    txtInstrumentNo.Enabled = True
                '    txtNarration.Enabled = False

                '    lblTxnType.Text = "NEFT transfer into our bank account"

                'Case "BANK-2-CASH"
                '    cboDebitAccount.Items.Add("CASHBOX")
                '    cboDebitAccount.Text = "CASHBOX"
                '    loadBankAccounts("CR")
                '    cboDebitAccount.Enabled = False
                '    cboCreditAccount.Enabled = True
                '    txtInstrumentNo.Enabled = True

                '    lblTxnType.Text = "Cash withdrawal from our bank account"


                'Case "CASH-2-BANK"
                '    loadBankAccounts("DR")
                '    cboCreditAccount.Items.Add("CASHBOX")
                '    cboCreditAccount.Text = "CASHBOX"
                '    cboDebitAccount.Enabled = True
                '    cboCreditAccount.Enabled = False

                '    lblTxnType.Text = "Cash deposit into our bank account"

                'Case "DD-2-BANK"
                '    loadBankAccounts("DR")
                '    cboCreditAccount.Items.Add("DD")
                '    cboCreditAccount.Text = "DD"
                '    cboDebitAccount.Enabled = True
                '    cboCreditAccount.Enabled = False

                '    lblTxnType.Text = "Demand Draft/Pay Order deposited into our bank account"

                'Case "BANK-2-DD"
                '    cboDebitAccount.Items.Add("DD")
                '    cboDebitAccount.Text = "DD"
                '    loadBankAccounts("CR")
                '    cboDebitAccount.Enabled = False
                '    cboCreditAccount.Enabled = True
                '    txtInstrumentNo.Enabled = True
                '    lblInstrumentNo.Text = "Cheque No"

                '    lblTxnType.Text = "We created demand draft/pay order from our bank account through cheque"

                'Case "CASH-2-DD"
                '    cboDebitAccount.Items.Add("DD")
                '    cboDebitAccount.Text = "DD"
                '    cboCreditAccount.Items.Add("CASHBOX")
                '    cboCreditAccount.Text = "CASHBOX"
                '    cboDebitAccount.Enabled = False
                '    cboCreditAccount.Enabled = False

                '    lblTxnType.Text = "We created demand draft/pay order through cash"

                'Case "BANK-2-BANK"
                '    loadBankAccounts("BOTH")
                '    cboDebitAccount.Enabled = True
                '    cboCreditAccount.Enabled = True
                '    btnLoadTDAccountsInCrCombo.Enabled = True
                '    btnLoadTDAccountsInDrCombo.Enabled = True

                '    lblTxnType.Text = "We transferred from one of our bank account to another account"

                'Case "INTEREST-4M-BANK"
                '    loadBankAccounts("DR")
                '    loadBankInterestAccounts()
                '    'cboCreditAccount.Items.Add("REV-BANK-INTEREST")
                '    'cboCreditAccount.Text = "REV-BANK-INTEREST"
                '    cboDebitAccount.Enabled = True
                '    cboCreditAccount.Enabled = True

                '    lblTxnType.Text = "Bank Interest credited into our bank account"

                'Case "BANK-2-TD"
                '    loadBankAccounts("CR")
                '    loadTDBankAccounts("DR")

                '    cboDebitAccount.Enabled = True
                '    cboCreditAccount.Enabled = True
                '    lblInstrumentNo.Text = "Intrument No"
                '    txtInstrumentNo.Enabled = True

                '    lblTxnType.Text = "We paid from our bank account through cheque/direct transfer"




                '    'loadBankAccounts("BOTH")
                '    'cboDebitAccount.Enabled = True
                '    'cboCreditAccount.Enabled = True
                '    'btnLoadTDAccountsInCrCombo.Enabled = True
                '    'btnLoadTDAccountsInDrCombo.Enabled = True

                '    'lblTxnType.Text = "We transferred from one of our bank account to another account"

                'Case "TD-2-BANK"
                '    loadBankAccounts("DR")
                '    loadTDBankAccounts("CR")

                '    cboDebitAccount.Enabled = True
                '    cboCreditAccount.Enabled = True
                '    lblInstrumentNo.Text = "Intrument No"
                '    txtInstrumentNo.Enabled = True

                '    lblTxnType.Text = "Term Deposit matured and deposited to our bank account through direct transfer"

            Case Else


        End Select

        'lblDrBalance.Text = addThousandSeparator(getAccountBalance(dtpTxnDate.Text, cboDebitAccount.Text), False)
        'lblCrBalance.Text = addThousandSeparator(getAccountBalance(dtpTxnDate.Text, cboCreditAccount.Text), False)
        'txtCreditActDesc.Text = getAccountName(cboCreditAccount.Text)
        'txtDebitActDesc.Text = getAccountName(cboDebitAccount.Text)

        'btnQueryTxn.PerformClick()
    End Sub

    'Private Sub cboCreditAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCreditAccount.SelectedIndexChanged
    '    btnQueryTxn.PerformClick()
    'End Sub

    'Private Sub cboDebitAccount_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDebitAccount.SelectedIndexChanged
    '    btnQueryTxn.PerformClick()
    'End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        On Error GoTo errH

        Dim ri As Integer, ci As Integer, tmpSql As String = "", thisTxnDate As String = ""


        ri = dgvJournal_b.CurrentCell.RowIndex
        ci = dgvJournal_b.CurrentCell.ColumnIndex
        gCurGID = dgvJournal_b.Rows(ri).Cells("gid_b").Value 'gid
        gCurRefGID = dgvJournal_b.Rows(ri).Cells("refgid_b").Value 'refgid
        thisTxnDate = dgvJournal_b.Rows(ri).Cells("TxnDate_b").Value

        If gCurRefGID <> "" Then
            MsgBox("This transaction is already reconciled. Can not be deleted.")
            Exit Sub
        End If
        If gFinYear.IsDateInFinYear(DateTime.Parse(thisTxnDate).ToString(DB_DATEFORMAT)) = False Then
            MsgBox("The date does not fall inside current financial year.")
            Exit Sub
        End If

        If MsgBox("Are you sure, you want to delete?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub

        gcon.Execute("delete from tbljournal_cult where gid='" & gCurGID & "'")
        gCurGID = ""
        gCurRefGID = ""
        MsgBox("Deleted")
        btnQueryTxn.PerformClick()
        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub

    Private Sub dtpTxnDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpTxnDate.ValueChanged
        'btnQueryTxn.PerformClick()
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        If cboSampleNarration.Text = "" Then Exit Sub
        txtNarration.Text = cboSampleNarration.Text
    End Sub
    Sub loadNarrationTemplates()
        Dim expActRS As ADODB.Recordset
        cboSampleNarration.Items.Clear()

        If cboDebitAccount.Text = "" Then Exit Sub

        ssql = "select distinct Narration from tbljournal_cult where AccountNo = '" & cboDebitAccount.Text & "'"
        If cboTxnType.Text = "ELECTRICITY-ADVANCE-PAYMENT" Or cboTxnType.Text = "ELECTRICITY-REFUND" Then
            ssql = ssql & " and TxnType ='ADVANCE'"
        End If
        If cboTxnType.Text = "ELECTRICITY-CONSUMPTION-AGAINST-ADVANCE" Then
            ssql = ssql & " and TxnType ='EXPENSE' and AccountNo = 'EXPCULTCUR-ELECTRICALS'"
        End If
        If cboTxnType.Text = "CASH-WITHDRAWAL-BY-CHEQUE" Then
            ssql = ssql & " and TxnType ='CASH-WITHDRAWAL-BY-CHEQUE'"
        End If
        If cboTxnType.Text = "PROVISION-FOR-AUDIT-FEE" Then
            ssql = ssql & " and TxnType ='EXPENSE'"
        End If
        If cboTxnType.Text = "GENERAL-FUND-2-CORPUS-FUND" Then
            ssql = ssql & " and TxnType ='BALANCESHEET-TXN'"
        End If
        'If cboTxnType.Text = "PROVISION-FOR-AUDIT-FEE" Then
        '    ssql = ssql & " and TxnType ='EXPENSE'"
        'End If
        'If cboTxnType.Text = "GENERAL-FUND-2-CORPUS-FUND" Then
        '    ssql = ssql & " and TxnType ='BALANCESHEET-TXN'"
        'End If
        'If cboTxnType.Text = "DEPRECIATION-EXPENSE" Then
        '    ssql = ssql & " and TxnType ='DEPRECIATION-EXPENSE'"
        'End If
        ssql = ssql & "  order by Narration"
        ssql = ssql & " LIMIT 0, 25"

        expActRS = gcon.Execute(ssql)
        While expActRS.EOF = False
            cboSampleNarration.Items.Add(expActRS("Narration").Value.ToString)
            expActRS.MoveNext()
        End While
    End Sub


End Class
