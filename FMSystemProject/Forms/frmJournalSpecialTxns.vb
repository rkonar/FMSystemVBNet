Public Class frmJournalSpecialTxns
    Private allAccountsStr As String = ""
    Private lFinYear As New clsFinYear
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        'Dim tmpRS As ADODB.Recordset

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
        If cboTxnType.Text = "INTEREST-4M-BANK" Then
            If (txtTaxAmount.Text = "") Then
                MsgBox("Provide Tax deducted")
                txtTaxAmount.Focus()
                Exit Sub
            End If
            If IsNumeric(txtTaxAmount.Text) = False Then
                MsgBox("Invalid amount after Tax")
                txtTaxAmount.Focus()
                Exit Sub
            End If
            If txtTaxAmount.Text < 0 Then
                MsgBox("Invalid Tax amount")
                txtTaxAmount.Focus()
                Exit Sub
            End If
        End If

        If cboTxnType.Text = "TAX-SELF-PAID" Then
            If cboPaymentMode.Text = "CHEQUE" Then
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
        'If cboTxnType.Text = "CHEQUE-2-BANK" Then
        '    ssql = "select tblid from tbljournal where Status is null and DocRef like '%Cheque No:" & stripLeadingZero(txtInstrumentNo.Text) & ",%' and TxnDate='" & DateTime.Parse(dtpTxnDate.Text).ToString(DB_DATEFORMAT) & "'"
        '    tmpRS = gcon.Execute(ssql)

        '    If tmpRS.EOF = False Then
        '        gUserResponse = MsgBox("Similar entry with same cheque no has already been entered into system on " & dtpTxnDate.Text & ". Still you want to Save?", MsgBoxStyle.YesNo, "Possible duplicate entry!!!")
        '        If gUserResponse = vbNo Then Exit Sub
        '    End If

        '    If (txtInstrumentNo.Text = "") Then
        '        MsgBox("Provide Cheque no.")
        '        Exit Sub
        '    End If

        'ElseIf cboTxnType.Text = "NEFT-2-BANK" Then
        '    ssql = "select tblid from tbljournal where Status is null and DocRef like '%NEFT Ref:" & stripLeadingZero(txtInstrumentNo.Text) & "%' and TxnDate='" & DateTime.Parse(dtpTxnDate.Text).ToString(DB_DATEFORMAT) & "'"
        '    tmpRS = gcon.Execute(ssql)

        '    If tmpRS.EOF = False Then
        '        gUserResponse = MsgBox("Similar NEFT Txn has already been entered into system on " & dtpTxnDate.Text & ". Still you want to Save?", MsgBoxStyle.YesNo, "Possible duplicate entry!!!")
        '        If gUserResponse = vbNo Then Exit Sub
        '    End If
        '    If (txtInstrumentNo.Text = "") Then
        '        MsgBox("Provide NEFT ref. no.")
        '        Exit Sub
        '    End If

        'ElseIf cboTxnType.Text = "BANK-2-DD" Then
        '    If (txtInstrumentNo.Text = "") Then
        '        MsgBox("Provide Cheque no.")
        '        Exit Sub
        '    End If
        'Else
        If cboTxnType.Text = "TAX-REFUND" Then
            If (cboInstrumentNo.Text = "") Then
                MsgBox("Provide NEFT ref. no.")
                Exit Sub
            End If
        End If

        If Trim(txtNarration.Text) = "" Then
            MsgBox("Enter narration")
            Exit Sub
        End If
        'End If

        JournalPayment()

        If cboPaymentMode.Text = "CHEQUE" Then ReloadCheques()

        txtTxnAmount.Text = ""
        'txtInstrumentNo.Text = ""
        txtNarration.Text = ""
        cboInstrumentNo.Text = ""
        cboPaymentMode.Text = ""

        PopulateJournal_b()

        'txtInstrumentNo.Focus()
    End Sub

    Sub JournalPayment()
        On Error GoTo errH

        Dim tmpStr As String

        'Journalise Payment
        Dim thisJournal As New clsJournal
        With thisJournal
            .Narration = txtNarration.Text
            '.DocRef = cboTxnType.Text & ",as per bank statement"
            If cboTxnType.Text = "PROVISION-FOR-TAX" Then
                .DocRef = "(Provisioned for expense)"
                .VoucherType = "JV"
                .TxnType = "EXPENSE"
                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = txtTxnAmount.Text
                .TxnDate = dtpTxnDate.Text

                gcon.BeginTrans()
                .CreateTransaction()

                If .Status = False Then GoTo errH
                gcon.CommitTrans()
            ElseIf cboTxnType.Text = "PROVISION-FOR-AUDIT-FEE" Then
                .DocRef = "(Provisioned for expense)"
                .VoucherType = "JV"
                .TxnType = "EXPENSE"
                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = txtTxnAmount.Text
                .TxnDate = dtpTxnDate.Text

                gcon.BeginTrans()
                .CreateTransaction()

                If .Status = False Then GoTo errH
                gcon.CommitTrans()
            ElseIf cboTxnType.Text = "GENERAL-FUND-2-CORPUS-FUND" Then
                .DocRef = "-"
                .VoucherType = "JV"
                .TxnType = "BALANCESHEET-TXN"
                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = txtTxnAmount.Text
                .TxnDate = dtpTxnDate.Text

                gcon.BeginTrans()
                .CreateTransaction()

                If .Status = False Then GoTo errH
                gcon.CommitTrans()
            ElseIf cboTxnType.Text = "DEPRECIATION-EXPENSE" Then
                .DocRef = "-"
                .VoucherType = "JV"
                .TxnType = "DEPRECIATION-EXPENSE"
                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = txtTxnAmount.Text
                .TxnDate = dtpTxnDate.Text

                gcon.BeginTrans()
                .CreateTransaction()

                If .Status = False Then GoTo errH
                gcon.CommitTrans()
            ElseIf cboTxnType.Text = "INTEREST-4M-BANK" Then
                .DocRef = cboTxnType.Text & ",as per bank statement"
                .DocRef = .DocRef & ",Bank Interest"
                .VoucherType = "RV"
                .TxnDate = dtpTxnDate.Text


                'Txn-1
                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = CDbl(txtTxnAmount.Text) + CDbl(txtTaxAmount.Text)
                .TxnType = "INTEREST-4M-BANK"

                gcon.BeginTrans()
                .CreateTransaction()
                If .Status = False Then GoTo errH

                If txtTaxAmount.Text > 0 Then
                    'Txn-2
                    .TxnType = "TAX-TDS"
                    .DrAccountNo = "TAX-TDS"
                    .CrAccountNo = cboDebitAccount.Text
                    .Amount = CDbl(txtTaxAmount.Text)

                    .CreateTransaction()
                    If .Status = False Then GoTo errH
                End If

                gcon.CommitTrans()
            ElseIf cboTxnType.Text = "TAX-REFUND" Then
                If cboPaymentMode.Text = "ONLINE" Then
                    .DocRef = "(Online Transfer Ref. No" & stripLeadingZero(cboInstrumentNo.Text) & ", Transfer Date: " & dtpInstrumentDate.Text & ", Bank:" & cboBankName.Text
                End If

                .VoucherType = "RV"
                .TxnDate = dtpTxnDate.Text

                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = CDbl(txtTxnAmount.Text)
                .TxnType = "TAX-REFUND"

                gcon.BeginTrans()
                .CreateTransaction()
                If .Status = False Then GoTo errH
                gcon.CommitTrans()
            ElseIf cboTxnType.Text = "BANKCHARGE-REFUND" Then
                .DocRef = cboTxnType.Text & ",as per bank statement"
                .DocRef = .DocRef & ",Bank Charge Refund"
                .VoucherType = "RV"
                .TxnDate = dtpTxnDate.Text

                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = CDbl(txtTxnAmount.Text)
                .TxnType = "BANKCHARGE-REFUND"

                gcon.BeginTrans()
                .CreateTransaction()
                If .Status = False Then GoTo errH
                gcon.CommitTrans()
            ElseIf cboTxnType.Text = "TAX-SELF-PAID" Then
                If cboPaymentMode.Text = "CASH" Then
                    .DocRef = "(Paid in CASH)"
                    .VoucherType = "PV"
                ElseIf cboPaymentMode.Text = "CHEQUE" Then
                    .DocRef = "(Cheque No:" & stripLeadingZero(cboInstrumentNo.Text) & ", Cheque Date: " & dtpInstrumentDate.Text & ", Bank:" & cboBankName.Text & ")"
                    .VoucherType = "PV"
                    'ElseIf cboPaymentMode.Text = "DD" Then
                    '    .DocRef = "(DD No:" & stripLeadingZero(cboInstrumentNo.Text) & ", DD Date: " & dtpInstrumentDate.Text & ", Bank:" & cboBankName.Text 
                ElseIf cboPaymentMode.Text = "ONLINE" Then
                    .DocRef = "(Tran. Ref. No:" & stripLeadingZero(cboInstrumentNo.Text) & ", Tran. Date: " & dtpInstrumentDate.Text & ", Bank:" & cboBankName.Text
                    .VoucherType = "PV"
                End If

                .TxnType = "TAX-TDS"
                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = txtTxnAmount.Text
                .TxnDate = dtpTxnDate.Text

                gcon.BeginTrans()
                .CreateTransaction()

                If .Status = False Then GoTo errH
                gcon.CommitTrans()

            ElseIf (cboTxnType.Text = "CASH-WITHDRAWAL-BY-CHEQUE") Then
                .DocRef = cboTxnType.Text & ",Cheque No:" & stripLeadingZero(cboInstrumentNo.Text) & ",Cheque Date:" & dtpInstrumentDate.Value & ",Yourself withdrawal"
                .VoucherType = "CV"
                .TxnType = cboTxnType.Text
                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = txtTxnAmount.Text
                .TxnDate = dtpTxnDate.Text

                gcon.BeginTrans()
                .CreateTransaction()

                If .Status = False Then GoTo errH

                ssql = "Update tblchequebook set Status='U',Remarks='Used' where ChequeNo = '" & stripLeadingZero(cboInstrumentNo.Text) & "' and AccountNo='" & cboCreditAccount.Text & "'"
                gcon.Execute(ssql)

                gcon.CommitTrans()
            ElseIf cboTxnType.Text = "VODAFONE-TAX-ADJUSTMENT" Then
                .DocRef = cboTxnType.Text & ",as per Traces Form 26AS statement"
                .DocRef = .DocRef & ",Tax Paid Directly" 'Vodafone paying the TDS directly and doing us TDS deducted payment
                .VoucherType = "RV"
                .TxnDate = dtpTxnDate.Text

                .DrAccountNo = cboDebitAccount.Text
                .CrAccountNo = cboCreditAccount.Text
                .Amount = CDbl(txtTxnAmount.Text)
                .TxnType = "VODAFONE-TAX-ADJUSTMENT"

                gcon.BeginTrans()
                .CreateTransaction()
                If .Status = False Then GoTo errH
                gcon.CommitTrans()
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



            gItemAction = "Create"
            gItemID = cboTxnType.Text

        End With

        MsgBox("Added")

        If logUserActivity() = False Then GoTo errH

        lblDrBalance.Text = addThousandSeparator(getAccountBalance(dtpTxnDate.Text, cboDebitAccount.Text), False)
        lblCrBalance.Text = addThousandSeparator(getAccountBalance(dtpTxnDate.Text, cboCreditAccount.Text), False)
        frmMain.sslabel3.Text = "Success"

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
        cboTxnType.Items.Add("PROVISION-FOR-AUDIT-FEE")
        cboTxnType.Items.Add("PROVISION-FOR-TAX")
        cboTxnType.Items.Add("DEPRECIATION-EXPENSE")
        cboTxnType.Items.Add("GENERAL-FUND-2-CORPUS-FUND")
        cboTxnType.Items.Add("INTEREST-4M-BANK")
        cboTxnType.Items.Add("TAX-SELF-PAID")
        cboTxnType.Items.Add("BANKCHARGE-REFUND")
        cboTxnType.Items.Add("TAX-REFUND")
        cboTxnType.Items.Add("VODAFONE-TAX-ADJUSTMENT")


        cboBankName.Items.Clear()
        For x = 1 To OurBankNames.Length
            cboBankName.Items.Add(OurBankNames(x - 1))
        Next

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

    Sub loadCreditorAccounts()
        Dim expActRS As ADODB.Recordset

        cboCreditAccount.Items.Clear()
        ssql = "select AccountNo from tblaccounts where Status='A' and AccountType='Liabilities' and LeafAccount='Y'"
        expActRS = gcon.Execute(ssql)

        While expActRS.EOF = False
            cboCreditAccount.Items.Add(expActRS("AccountNo").Value.ToString)
            expActRS.MoveNext()
        End While
    End Sub

    Sub loadBankInterestAccounts()
        Dim expActRS As ADODB.Recordset

        cboCreditAccount.Items.Clear()
        ssql = "select AccountNo from tblaccounts where Status='A' and AccountType='Revenues' and LeafAccount='Y' and ParentAccountNo = 'REV-BANK-INTEREST'"
        expActRS = gcon.Execute(ssql)

        While expActRS.EOF = False
            cboCreditAccount.Items.Add(expActRS("AccountNo").Value.ToString)
            expActRS.MoveNext()
        End While
    End Sub

    Sub loadBankAccounts(where2Load As String)
        Dim actRS As ADODB.Recordset

        If where2Load = "DR" Then
            cboDebitAccount.Items.Clear()
        ElseIf where2Load = "CR" Then
            cboCreditAccount.Items.Clear()
        ElseIf where2Load = "BOTH" Then
            cboDebitAccount.Items.Clear()
            cboCreditAccount.Items.Clear()
        End If

        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Assets' and ParentAccountNo = 'CASH-AT-BANK'"
        actRS = gcon.Execute(ssql)
        While actRS.EOF = False
            If where2Load = "DR" Then
                cboDebitAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboDebitAccount.Text = ""
            ElseIf where2Load = "CR" Then
                cboCreditAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboCreditAccount.Text = ""
            ElseIf where2Load = "BOTH" Then
                cboDebitAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboCreditAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboCreditAccount.Text = ""
                cboDebitAccount.Text = ""
            End If
            actRS.MoveNext()
        End While
        actRS.Close()

    End Sub
    Sub loadFixedAssetAcInCreditCombo()
        Dim expActRS As ADODB.Recordset, ssql As String

        cboCreditAccount.Items.Clear()
        cboCreditAccount.Text = ""
        txtCreditActDesc.Text = ""
        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Assets' and ParentAccountNo='FIXED-ASSET'"

        expActRS = gcon.Execute(ssql)
        While expActRS.EOF = False
            cboCreditAccount.Items.Add(expActRS("AccountNo").Value.ToString)
            expActRS.MoveNext()
        End While
        expActRS.Close()
    End Sub
    Sub loadDepreciationAcInDebitCombo()
        Dim expActRS As ADODB.Recordset, ssql As String

        cboDebitAccount.Items.Clear()
        cboDebitAccount.Text = ""
        txtDebitActDesc.Text = ""
        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Expenses' and ParentAccountNo='EXP-DEPRECIATION'"
        If cboCreditAccount.Text <> "" Then ssql = ssql & " and AccountNo like '%" & cboCreditAccount.Text & "'"

        expActRS = gcon.Execute(ssql)
        While expActRS.EOF = False
            cboDebitAccount.Items.Add(expActRS("AccountNo").Value.ToString)
            expActRS.MoveNext()
        End While
        expActRS.Close()
    End Sub

    Sub loadTDBankAccounts(where2Load As String)
        Dim actRS As ADODB.Recordset

        If where2Load = "DR" Then
            cboDebitAccount.Items.Clear()
        ElseIf where2Load = "CR" Then
            cboCreditAccount.Items.Clear()
        ElseIf where2Load = "BOTH" Then
            cboDebitAccount.Items.Clear()
            cboCreditAccount.Items.Clear()
        End If

        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Assets' and ParentAccountNo = 'TD-AT-BANK'"
        actRS = gcon.Execute(ssql)
        While actRS.EOF = False
            If where2Load = "DR" Then
                cboDebitAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboDebitAccount.Text = ""
            ElseIf where2Load = "CR" Then
                cboCreditAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboCreditAccount.Text = ""
            ElseIf where2Load = "BOTH" Then
                cboDebitAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboCreditAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboCreditAccount.Text = ""
                cboDebitAccount.Text = ""
            End If
            actRS.MoveNext()
        End While
        actRS.Close()


    End Sub

    Sub loadChequeIssuedAccounts(where2Load As String)
        Dim actRS As ADODB.Recordset

        If where2Load = "DR" Then
            cboDebitAccount.Items.Clear()
        ElseIf where2Load = "CR" Then
            cboCreditAccount.Items.Clear()
        ElseIf where2Load = "BOTH" Then
            cboDebitAccount.Items.Clear()
            cboCreditAccount.Items.Clear()
        End If

        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Liabilities' and ParentAccountNo = 'CHEQUE-ISSUED-ALL'"
        actRS = gcon.Execute(ssql)
        While actRS.EOF = False
            If where2Load = "DR" Then
                cboDebitAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboDebitAccount.Text = ""
            ElseIf where2Load = "CR" Then
                cboCreditAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboCreditAccount.Text = ""
            ElseIf where2Load = "BOTH" Then
                cboDebitAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboCreditAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboCreditAccount.Text = ""
                cboDebitAccount.Text = ""
            End If
            actRS.MoveNext()
        End While
        actRS.Close()
    End Sub


    Private Sub cboDebitAccount_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboDebitAccount.SelectedValueChanged
        txtDebitActDesc.Text = getAccountName(cboDebitAccount.Text)
        lblDrBalance.Text = addThousandSeparator(getAccountBalance(dtpTxnDate.Text, cboDebitAccount.Text), False)

        loadNarrationTemplates()
        'btnQueryTxn.PerformClick()
    End Sub

    Private Sub cboCreditAccount_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboCreditAccount.SelectedValueChanged
        txtCreditActDesc.Text = getAccountName(cboCreditAccount.Text)
        lblCrBalance.Text = addThousandSeparator(getAccountBalance(dtpTxnDate.Text, cboCreditAccount.Text), False)
        'btnQueryTxn.PerformClick()

        If cboTxnType.Text = "DEPRECIATION-EXPENSE" Then
            loadDepreciationAcInDebitCombo()
        End If

        If cboPaymentMode.Text = "CHEQUE" Then ReloadCheques()

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

        journalQuerySQL = "select * from tbljournal where "
        'journalQuerySQL = journalQuerySQL & " TxnDate='" & DateTime.Parse(dtpTxnDate.Text).ToString(DB_DATEFORMAT) & "' and "

        If cboTxnType.Text = "CASH-WITHDRAWAL-BY-CHEQUE" Then
            journalQuerySQL = journalQuerySQL & "  TxnType ='CASH-WITHDRAWAL-BY-CHEQUE'"
        ElseIf cboTxnType.Text = "INTEREST-4M-BANK" Then
            journalQuerySQL = journalQuerySQL & " TxnType in ('INTEREST-4M-BANK','TAX-TDS')"
        ElseIf cboTxnType.Text = "PROVISION-FOR-TAX" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='EXPENSE' And TxnDate='" & DateTime.Parse(dtpTxnDate.Text).ToString(DB_DATEFORMAT) & "'"
        ElseIf cboTxnType.Text = "PROVISION-FOR-AUDIT-FEE" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='EXPENSE' And TxnDate='" & DateTime.Parse(dtpTxnDate.Text).ToString(DB_DATEFORMAT) & "'"
        ElseIf cboTxnType.Text = "GENERAL-FUND-2-CORPUS-FUND" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='BALANCESHEET-TXN'"
        ElseIf cboTxnType.Text = "DEPRECIATION-EXPENSE" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='DEPRECIATION-EXPENSE'"
        ElseIf cboTxnType.Text = "TAX-SELF-PAID" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='TAX-TDS'"
        ElseIf cboTxnType.Text = "BANKCHARGE-REFUND" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='BANKCHARGE-REFUND'"
        ElseIf cboTxnType.Text = "TAX-REFUND" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='TAX-REFUND'"
        ElseIf cboTxnType.Text = "VODAFONE-TAX-ADJUSTMENT" Then
            journalQuerySQL = journalQuerySQL & " TxnType ='VODAFONE-TAX-ADJUSTMENT'"
        End If
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
        txtTaxAmount.Visible = False
        lblTaxAmt.Visible = False
        txtDebitActDesc.Visible = False
        txtTxnAmount.ReadOnly = False

        lblOpBalFAVal.Visible = False
        lblCurYrFAVal.Visible = False
        lblTolFAVal.Visible = False
        lblDeprecPerc.Visible = False
        txtOpBalFAVal.Visible = False
        txtCurYrFAVal.Visible = False
        txtTotFAVal.Visible = False
        txtDeprecPerc.Visible = False
        btnCalcDeprecAmt.Visible = False
        'btnLoadTDAccountsInCrCombo.Enabled = False
        'btnLoadTDAccountsInDrCombo.Enabled = False

        panelPaymentMode.Enabled = False
        cboInstrumentNo.DropDownStyle = ComboBoxStyle.DropDown
        With cboPaymentMode
            .Items.Clear()
            .Items.Add("CASH")
            .Items.Add("CHEQUE")
            .Items.Add("ONLINE")
            .SelectedIndex = 0
            .Enabled = True
        End With

        Select Case cboTxnType.Text

            Case "CASH-WITHDRAWAL-BY-CHEQUE"
                With cboDebitAccount
                    .Items.Clear()
                    .Items.Add("CASHBOX")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                panelPaymentMode.Enabled = True
                With cboPaymentMode
                    .Items.Clear()
                    .Items.Add("CHEQUE")
                    .SelectedIndex = 0
                    .Enabled = True
                End With

                'cboPaymentMode.Text = "CHEQUE"
                'cboPaymentMode.Enabled = False
                loadChequeIssuedAccounts("CR")
                cboInstrumentNo.Enabled = True
                cboInstrumentNo.DropDownStyle = ComboBoxStyle.DropDownList

            Case "PROVISION-FOR-AUDIT-FEE"
                With cboDebitAccount
                    .Items.Clear()
                    .Items.Add("EXP-AUDIT-FEES")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                With cboCreditAccount
                    .Items.Clear()
                    .Items.Add("PROVISION-FOR-AUDIT-FEE")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
            Case "PROVISION-FOR-TAX"
                With cboDebitAccount
                    .Items.Clear()
                    .Items.Add("EXP-INCOME-TAX")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                With cboCreditAccount
                    .Items.Clear()
                    .Items.Add("PROVISION-FOR-TAX")
                    .SelectedIndex = 0
                    .Enabled = False
                End With

            Case "GENERAL-FUND-2-CORPUS-FUND"
                With cboDebitAccount
                    .Items.Clear()
                    .Items.Add("GENERAL-FUND")
                    .SelectedIndex = 0
                    .Enabled = False
                End With
                With cboCreditAccount
                    .Items.Clear()
                    .Items.Add("CORPUS-FUND-ADD")
                    .SelectedIndex = 0
                    .Enabled = False
                End With

            Case "DEPRECIATION-EXPENSE"
                loadFixedAssetAcInCreditCombo()
                loadDepreciationAcInDebitCombo()
                cboDebitAccount.Enabled = True
                cboCreditAccount.Enabled = True
                txtTxnAmount.ReadOnly = True
                lblOpBalFAVal.Visible = True
                lblCurYrFAVal.Visible = True
                lblTolFAVal.Visible = True
                lblDeprecPerc.Visible = True
                txtOpBalFAVal.Visible = True
                txtCurYrFAVal.Visible = True
                txtTotFAVal.Visible = True
                txtDeprecPerc.Visible = True
                btnCalcDeprecAmt.Visible = True
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
                '    loadChequeIssuedAccounts("DR")
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

            Case "INTEREST-4M-BANK"
                loadBankAccounts("DR")
                loadBankInterestAccounts()
                'cboCreditAccount.Items.Add("REV-BANK-INTEREST")
                'cboCreditAccount.Text = "REV-BANK-INTEREST"
                cboDebitAccount.Enabled = True
                cboCreditAccount.Enabled = True
                txtTaxAmount.Visible = True
                lblTaxAmt.Visible = True

                lblTxnType.Text = "Bank Interest credited into our bank account"

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

            Case "BANKCHARGE-REFUND"
                loadBankAccounts("DR")
                'loadBankInterestAccounts()
                cboCreditAccount.Items.Clear()
                cboCreditAccount.Items.Add("EXPCUR-BANKCHARGES")
                cboCreditAccount.Text = "EXPCUR-BANKCHARGES"
                cboDebitAccount.Enabled = True
                cboCreditAccount.Enabled = True
                txtTaxAmount.Visible = True
                lblTaxAmt.Visible = True

                lblTxnType.Text = "Bank refunded charges, applied earlier, into our bank account"

            Case "TAX-REFUND"
                panelPaymentMode.Enabled = True
                cboPaymentMode.Text = "ONLINE"
                cboDebitAccount.Items.Clear()
                cboDebitAccount.Items.Add("NEFT-NOT-RECONCILED")
                cboDebitAccount.Text = "NEFT-NOT-RECONCILED"
                'loadBankInterestAccounts()
                cboCreditAccount.Items.Clear()
                cboCreditAccount.Items.Add("TAX-TDS")
                cboCreditAccount.Text = "TAX-TDS"
                cboDebitAccount.Enabled = True
                cboCreditAccount.Enabled = True
                txtTaxAmount.Visible = True
                lblTaxAmt.Visible = True

                lblTxnType.Text = "Tax refund by income tax deposited directly into our bank account"

            Case "TAX-SELF-PAID"
                panelPaymentMode.Enabled = True
                With cboDebitAccount
                    .Items.Clear()
                    .Items.Add("TAX-SELF-PAID")
                    .SelectedIndex = 0
                    .Enabled = False
                End With

                Select Case cboPaymentMode.Text
                    Case "CHEQUE"
                        loadChequeIssuedAccounts("CR")
                    Case "CASH"
                        With cboCreditAccount
                            .Items.Clear()
                            .Items.Add("CASHBOX")
                            .SelectedIndex = 0
                            .Enabled = False
                        End With
                        'Case "ONLINE"
                        '    With cboCreditAccount
                        '        .Items.Clear()
                        '        .Items.Add("NEFT-NOT-RECONCILED")
                        '        .SelectedIndex = 0
                        '        .Enabled = False
                        '    End With


                End Select





                With cboCreditAccount
                    '.Items.Clear()
                    '.SelectedIndex = 0
                    .Enabled = True
                End With

            Case "VODAFONE-TAX-ADJUSTMENT"
                panelPaymentMode.Enabled = False
                cboDebitAccount.Items.Clear()
                cboDebitAccount.Items.Add("TAX-TDS")
                cboDebitAccount.Text = "TAX-TDS"

                cboCreditAccount.Items.Clear()
                cboCreditAccount.Items.Add("REV-MISC-COLLECTION")
                cboCreditAccount.Text = "REV-MISC-COLLECTION"

                lblTxnType.Text = "Vodafone paying the TDS directly and doing us TDS deducted payment"
            Case Else


        End Select

        lblDrBalance.Text = addThousandSeparator(getAccountBalance(dtpTxnDate.Text, cboDebitAccount.Text), False)
        lblCrBalance.Text = addThousandSeparator(getAccountBalance(dtpTxnDate.Text, cboCreditAccount.Text), False)
        txtCreditActDesc.Text = getAccountName(cboCreditAccount.Text)
        txtDebitActDesc.Text = getAccountName(cboDebitAccount.Text)

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

        gcon.Execute("delete from tbljournal where gid='" & gCurGID & "'")
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

        ssql = "select distinct Narration from tbljournal where AccountNo = '" & cboDebitAccount.Text & "'"
        If cboTxnType.Text = "CASH-WITHDRAWAL-BY-CHEQUE" Then
            ssql = ssql & " and TxnType ='CASH-WITHDRAWAL-BY-CHEQUE'"
        End If
        If cboTxnType.Text = "INTEREST-4M-BANK" Then
            ssql = ssql & " and TxnType in ('INTEREST-4M-BANK','TAX-TDS')"
        End If
        If cboTxnType.Text = "PROVISION-FOR-TAX" Then
            ssql = ssql & " and TxnType ='EXPENSE'"
        End If
        If cboTxnType.Text = "PROVISION-FOR-AUDIT-FEE" Then
            ssql = ssql & " and TxnType ='EXPENSE'"
        End If
        If cboTxnType.Text = "GENERAL-FUND-2-CORPUS-FUND" Then
            ssql = ssql & " and TxnType ='BALANCESHEET-TXN'"
        End If
        If cboTxnType.Text = "DEPRECIATION-EXPENSE" Then
            ssql = ssql & " and TxnType ='DEPRECIATION-EXPENSE'"
        End If
        If cboTxnType.Text = "BANKCHARGE-REFUND" Then
            ssql = ssql & " and TxnType ='BANKCHARGE-REFUND'"
        End If
        If cboTxnType.Text = "TAX-REFUND" Then
            ssql = ssql & " and TxnType ='TAX-REFUND'"
        End If
        If cboTxnType.Text = "VODAFONE-TAX-ADJUSTMENT" Then
            ssql = ssql & " and TxnType ='VODAFONE-TAX-ADJUSTMENT'"
        End If
        ssql = ssql & "  order by Narration"
        ssql = ssql & " LIMIT 0, 25"

        expActRS = gcon.Execute(ssql)
        While expActRS.EOF = False
            cboSampleNarration.Items.Add(expActRS("Narration").Value.ToString)
            expActRS.MoveNext()
        End While
    End Sub


    Private Sub btnCalcDeprecAmt_Click(sender As Object, e As EventArgs) Handles btnCalcDeprecAmt.Click
        If IsNumeric(txtDeprecPerc.Text) = False Then Exit Sub
        If cboCreditAccount.Text = "" Then Exit Sub


        Dim curStartDate As Long, curEndDate As Long, PrevStartDate As Long, PrevEndDate As Long
        Dim pv As Double = 0, cv As Double = 0
        '=========================================
        curEndDate = DateTime.Parse(dtpTxnDate.Value).ToString(DB_DATEFORMAT)
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
        pv = getAccountBalanceAsOfDate(PrevEndDate, cboCreditAccount.Text, "NET")
        cv = getAccountBalanceBetweenDates(curStartDate, curEndDate, cboCreditAccount.Text, "DR")

        txtOpBalFAVal.Text = pv
        txtCurYrFAVal.Text = cv
        txtTotFAVal.Text = pv + cv

        txtTxnAmount.Text = Math.Round(Double.Parse(txtDeprecPerc.Text) * (pv + cv) / 100, 0)
    End Sub
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

    Private Sub btnLoadTDActInCrCombo_Click(sender As Object, e As EventArgs) Handles btnLoadTDActInCrCombo.Click
        loadTDBankAccounts("CR")
    End Sub

    Private Sub btnLoadTDActInDrCombo_Click(sender As Object, e As EventArgs) Handles btnLoadTDActInDrCombo.Click
        loadTDBankAccounts("DR")
    End Sub
    Sub ReloadCheques()
        cboInstrumentNo.Items.Clear()
        tmpRS = gcon.Execute("select ChequeNo from tblchequebook where Status is null and AccountNo='" & cboCreditAccount.Text & "' order by tblid Asc")
        While tmpRS.EOF = False
            cboInstrumentNo.Items.Add(tmpRS("ChequeNo").Value.ToString)
            tmpRS.MoveNext()
        End While
    End Sub

    Private Sub cboPaymentMode_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboPaymentMode.SelectedValueChanged

        'cboInstrumentNo.DropDownStyle = ComboBoxStyle.DropDownList

        If cboPaymentMode.Text = "CASH" Then
            dtpInstrumentDate.Enabled = False
            cboInstrumentNo.Enabled = False
            'cboBankName.Enabled = False

            'dtpInstrumentDate.Text = ""
            cboInstrumentNo.Text = ""
            'cboBankName.Text = ""

            'If (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "PREPAID") Then
            cboCreditAccount.Items.Clear()
            cboCreditAccount.Items.Add("CASHBOX")
            cboCreditAccount.Text = "CASHBOX"
            'txtCreditActDesc.Text = getAccountName(cboCreditAccount.Text)
            'End If

        ElseIf cboPaymentMode.Text = "CHEQUE" Then
            dtpInstrumentDate.Enabled = True
            cboInstrumentNo.Enabled = True
            'cboBankName.Enabled = True

            lblInstrumentDate.Text = "Cheque Date"
            lblInstrumentNo.Text = "Cheque No"

            'If (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "PREPAID") Then
            cboCreditAccount.Items.Clear()
            cboCreditAccount.Items.Add("CHEQUE-ISSUED")
            cboCreditAccount.Text = "CHEQUE-ISSUED"
            loadChequeIssuedAccounts("CR")
            cboCreditAccount.Enabled = True

            'txtCreditActDesc.Text = ""
            'End If

            'ElseIf cboPaymentMode.Text = "DD" Then
            '    cboInstrumentNo.DropDownStyle = ComboBoxStyle.DropDown
            '    dtpInstrumentDate.Enabled = True
            '    cboInstrumentNo.Enabled = True
            '    cboBankName.Enabled = True

            '    lblInstrumentDate.Text = "DD Date"
            '    lblInstrumentNo.Text = "DD No"

            '    'If (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "PREPAID") Then
            '    cboCreditAccount.Items.Clear()
            '    cboCreditAccount.Items.Add("DD")
            '    cboCreditAccount.Text = "DD"
            '    txtCreditActDesc.Text = getAccountName(cboCreditAccount.Text)
            '    'End If

        ElseIf cboPaymentMode.Text = "ONLINE" Then
            cboInstrumentNo.DropDownStyle = ComboBoxStyle.DropDown
            dtpInstrumentDate.Enabled = True
            cboInstrumentNo.Enabled = True
            'cboBankName.Enabled = True
            lblInstrumentDate.Text = "Transfer Date"
            lblInstrumentNo.Text = "Transaction Ref. No"
            'dtpInstrumentDate.Text = dtpPaymentDate.Text
            'If (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "PREPAID") Then
            'loadBankAccounts("CR")
            'cboCreditAccount.Enabled = True
            'txtCreditActDesc.Text = ""
            'End If

        End If
        'lblDrBalance.Text = addThousandSeparator(getAccountBalance(dtpPaymentDate.Text, cboDebitAccount.Text), False)
        'lblCrBalance.Text = addThousandSeparator(getAccountBalance(dtpPaymentDate.Text, cboCreditAccount.Text), False)
    End Sub

    Private Sub cboPaymentMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaymentMode.SelectedIndexChanged

    End Sub

    Private Sub cboCreditAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCreditAccount.SelectedIndexChanged

    End Sub

    Private Sub cboTxnType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTxnType.SelectedIndexChanged

    End Sub
End Class
