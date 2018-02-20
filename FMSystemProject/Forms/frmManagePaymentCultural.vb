Public Class frmManagePaymentCultural
    Private mTblID As String, mGID As String, mDocRef As String, mEditFlag As Boolean
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click


        If (DateTime.Parse(dtpPaymentDate.Text) > DateTime.Now.Date) And (cboExpenseType.Text <> "ADJUST-AGAINST-PREPAID") Then
            MsgBox("Payment date can't be future date")
            Exit Sub
        End If

        If Trim(txtNarration.Text) = "" Then
            MsgBox("Enter remarks")
            Exit Sub
        End If

        If Trim(txtPaymentAmount.Text) = "" Then
            MsgBox("Enter Payment Amount")
            Exit Sub
        End If

        If Trim(cboApprovers.Text) = "" Then
            MsgBox("Enter Supervisor Name")
            Exit Sub
        End If


        If cboCreditAccount.Text = cboDebitAccount.Text Then
            MsgBox("Debit/Credit accounts can't be same")
            Exit Sub
        End If

        If cboCreditAccount.Text = "" Then
            MsgBox("Credit Account No not set.")
            Exit Sub
        ElseIf cboDebitAccount.Text = "" Then
            MsgBox("Debit Account No not set.")
            Exit Sub
        End If


        'If (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "PREPAID") Or (cboExpenseType.Text = "ADJUST-AGAINST-DEFERRED") Then
        If (cboPaymentMode.Text <> "ONLINE") And (cboPaymentMode.Text <> "") Then
            If Trim(cboVoucherNo.Text) = "" Then
                MsgBox("Voucher No not set.")
                Exit Sub
            End If
        End If
        'End If


        'If cboExpenseType.Text = "NORMAL" Then
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

        'End If

        btnSave.Enabled = False

        If cboTag1.Text = "" Or cboTag2.Text = "" Then
            MsgBox("Tag1 and Tag2 is mandatory")
            Exit Sub
        End If


        JournalPayment()



        If cboPaymentMode.Text = "CHEQUE" Then loadCheques()
        refreshCreditAccount()
        refreshDebitAccount()


        'If (txtPaymentAmount.Text > 500) And (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "PREPAID") Or (cboExpenseType.Text = "ADJUST-AGAINST-DEFERRED") Then

        '    Dim myMailer As New clsSendMail, tmpstr As String
        '    With myMailer

        '        .mailSubject = "Greenfield Heights(HIG) Association : Expense Notification (Rs. " & txtPaymentAmount.Text & ")"
        '        tmpstr = "Dear Committee Member<br>"
        '        tmpstr = tmpstr & "<br>Below expense has been entered into Facility Management Accounting System.<br>"
        '        tmpstr = tmpstr & "<br>Expense For:" & txtNarration.Text
        '        tmpstr = tmpstr & "<br>Expense Amount:" & txtPaymentAmount.Text
        '        tmpstr = tmpstr & "<br>Expense Date:" & dtpPaymentDate.Text
        '        tmpstr = tmpstr & "<br>Voucher No:" & cboVoucherNo.Text
        '        tmpstr = tmpstr & "<br>Payment By:" & cboPaymentMode.Text
        '        If cboPaymentMode.Text = "CHEQUE" Then
        '            tmpstr = tmpstr & "<br>Cheque No:" & cboInstrumentNo.Text
        '        End If

        '        tmpstr = tmpstr & "<br><br>Data entered into system by " & gUserName & " at " & DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") & " IST<br>"

        '        tmpstr = tmpstr & "<br><B>PS: This is a system generated mail, please do not reply to this mail id.</B>"
        '        tmpstr = tmpstr & "<br><br>If you have any query or observation regarding the above expense, please bring it in for discussion in the next committee meeting."

        '        .mailBody = tmpstr
        '        .IsBodyHtml = True

        '        .SendMail_Expense("")

        '    End With
        'End If

        btnQueryExpense.PerformClick()
        btnSave.Enabled = True
        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        btnSave.Enabled = True
        myMsgBox(gErrMsg)
        gErrMsg = ""

    End Sub

    Sub JournalPayment()
        On Error GoTo errH

        Dim tmpStr As String

        'Journalise Payment
        Dim thisJournal As New clsJournal_Cult
        With thisJournal
            .TxnStatus = "P"

            If (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "PREPAID") Or (cboExpenseType.Text = "ADJUST-AGAINST-DEFERRED") Or (cboExpenseType.Text = "FIXED-ASSET") Then
                If cboPaymentMode.Text = "CASH" Then
                    .DocRef = "(Paid in CASH"
                    .VoucherType = "PV"
                ElseIf cboPaymentMode.Text = "CHEQUE" Then
                    .DocRef = "(Cheque No:" & stripLeadingZero(cboInstrumentNo.Text) & ", Cheque Date: " & dtpInstrumentDate.Text & ", Bank:" & cboBankName.Text
                    .VoucherType = "PV"
                    'ElseIf cboPaymentMode.Text = "DD" Then
                    '    .DocRef = "(DD No:" & stripLeadingZero(cboInstrumentNo.Text) & ", DD Date: " & dtpInstrumentDate.Text & ", Bank:" & cboBankName.Text 
                ElseIf cboPaymentMode.Text = "ONLINE" Then
                    .DocRef = "(Tran. Ref. No:" & stripLeadingZero(cboInstrumentNo.Text) & ", Tran. Date: " & dtpInstrumentDate.Text & ", Bank:" & cboBankName.Text
                    .VoucherType = "PV"
                End If
            ElseIf cboExpenseType.Text = "ADJUST-AGAINST-PREPAID" Then
                .DocRef = "(Adjusted against prepaid expense)"
                .VoucherType = "JV"
            ElseIf cboExpenseType.Text = "DEFERRED" Then
                .DocRef = "(Provisioned for expense)"
                .VoucherType = "JV"
                .TxnStatus = ""
            Else
                .DocRef = ""
                .VoucherType = ""
            End If

            'If (cboPaymentMode.Text <> "ONLINE") And (cboPaymentMode.Text <> "") Then
            '    .DocRef = .DocRef & ", VoucherNo:" & stripLeadingZero(Trim(cboVoucherNo.Text)) & ")"
            'End If

            .DocRef = .DocRef & ")"

            .TxnType = getTxnTypeFromPaymentType(cboExpenseType.Text)

            .DrAccountNo = cboDebitAccount.Text
            .CrAccountNo = cboCreditAccount.Text
            .Amount = txtPaymentAmount.Text
            .Narration = txtNarration.Text
            .TxnDate = dtpPaymentDate.Text
            .VoucherNo = stripLeadingZero(Trim(cboVoucherNo.Text))
            .SupervisorName = cboApprovers.Text
            .Tag1 = cboTag1.Text
            .Tag2 = cboTag2.Text


            gcon.BeginTrans()
            .CreateTransaction()

            If .Status = False Then GoTo errH
            If cboPaymentMode.Text = "CHEQUE" Then
                'mark the cheque as used, approval pending
                ssql = "Update tblchequebook set Status='P',Remarks='Used but pending approval',UpdatedBy='" & gUserName & "', VoucherNo=" & cboVoucherNo.Text & " where ChequeNo = '" & stripLeadingZero(cboInstrumentNo.Text) & "' and Status is null and AccountNo='" & cboCreditAccount.Text & "'"
                gcon.Execute(ssql)
            End If

            'mark the voucher as used
            If (cboPaymentMode.Text <> "ONLINE") And (cboPaymentMode.Text <> "") Then
                ssql = "Update tblvoucherbook_cult set Status='U' where VoucherNo=" & stripLeadingZero(Trim(cboVoucherNo.Text))
                gcon.Execute(ssql)
            End If

            gcon.CommitTrans()

            gItemAction = "Create"
            gItemID = .DocRef
        End With
        If logUserActivity() = False Then GoTo errH

        MsgBox("Done")

        'resetFields() ' commented to enable faster expense entry


        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)
        gErrMsg = ""
    End Sub



    Sub loadDebitCombo()
        Dim expActRS As ADODB.Recordset, expAccountType As String, ssql As String

        cboDebitAccount.Items.Clear()
        cboDebitAccount.Text = ""
        txtDebitActDesc.Text = ""
        ssql = ""

        If (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "ADJUST-AGAINST-PREPAID") Or (cboExpenseType.Text = "DEFERRED") Then

            expAccountType = "EXPCULTCUR"
            If optCurExp.Checked = True Then
                expAccountType = "EXPCULTCUR"
            ElseIf optCapExp.Checked = True Then
                expAccountType = "EXPCULTCAP"
            End If

            ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Expenses' and AccountNo like '" & expAccountType & "%'"

        ElseIf cboExpenseType.Text = "PREPAID" Then
            expAccountType = "DEFERRED-EXP"
            ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Assets' and AccountNo like '" & expAccountType & "%'"
        ElseIf cboExpenseType.Text = "ADJUST-AGAINST-DEFERRED" Then
            expAccountType = "DEFERRED-LIAB"
            ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Liabilities' and (ParentAccountNo = 'DEFERRED-LIAB-CULT' Or AccountNo in ('PROVISION-FOR-AUDIT-FEE-CULT'))"
        ElseIf cboExpenseType.Text = "FIXED-ASSET" Then
            expAccountType = "FIXED-ASSET"
            ssql = "Select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Assets' and AccountNo like '" & expAccountType & "%'"

        Else
            Exit Sub
        End If

        expActRS = gcon.Execute(ssql)
        While expActRS.EOF = False
            cboDebitAccount.Items.Add(expActRS("AccountNo").Value.ToString)
            expActRS.MoveNext()
        End While



    End Sub

    Sub loadLiabilitiesAccounts()
        Dim expActRS As ADODB.Recordset

        cboCreditAccount.Items.Clear()
        ssql = "select AccountNo from tblaccounts where Status='A' and AccountType='Liabilities' and LeafAccount='Y' and AccountNo like 'DEFERRED-LIAB-CULT%'"
        expActRS = gcon.Execute(ssql)

        While expActRS.EOF = False
            cboCreditAccount.Items.Add(expActRS("AccountNo").Value.ToString)
            expActRS.MoveNext()
        End While
    End Sub
    Sub loadDeferredExpAccounts()
        Dim expActRS As ADODB.Recordset

        cboCreditAccount.Items.Clear()
        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Assets' and AccountNo like 'DEFERRED-EXP-CULT%'"
        expActRS = gcon.Execute(ssql)

        While expActRS.EOF = False
            cboCreditAccount.Items.Add(expActRS("AccountNo").Value.ToString)
            expActRS.MoveNext()
        End While
    End Sub
    Sub loadChequeIssuedAccounts()
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

        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Assets' and ParentAccountNo = 'CASH-AT-BANK-CULT'"
        actRS = gcon.Execute(ssql)
        While actRS.EOF = False
            If where2Load = "DR" Then
                cboDebitAccount.Items.Add(actRS("AccountNo").Value.ToString)
            ElseIf where2Load = "CR" Then
                cboCreditAccount.Items.Add(actRS("AccountNo").Value.ToString)
            ElseIf where2Load = "BOTH" Then
                cboDebitAccount.Items.Add(actRS("AccountNo").Value.ToString)
                cboCreditAccount.Items.Add(actRS("AccountNo").Value.ToString)
            End If
            actRS.MoveNext()
        End While
        actRS.Close()
        cboCreditAccount.Text = ""
        cboDebitAccount.Text = ""
    End Sub
    Private Sub frmBookPayments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        resetTheForm()
    End Sub
    Sub loadAvailableVouchers()
        cboVoucherNo.Items.Clear()
        tmpRS = gcon.Execute("select VoucherNo from tblvoucherbook_cult where Status='A' order by VoucherNo ASC")
        While tmpRS.EOF = False
            cboVoucherNo.Items.Add(tmpRS("VoucherNo").Value.ToString)
            tmpRS.MoveNext()
        End While
    End Sub
    Sub loadExpenseApprovers()
        Dim tmpsql As String, tmpRS As ADODB.Recordset
        cboApprovers.Items.Clear()
        cboApprovers.Items.Add("None")
        cboApprovers.Items.Add("BANK")
        tmpsql = "select u.FullName from tblmap_role_user ru, tblusers u, tblroles r where r.Status='A' and r.tblid=ru.RoleID and ru.UserID=u.tblid and r.RoleCode = 'ExpenseApproversCultural'"
        tmpRS = gcon.Execute(tmpsql)
        While tmpRS.EOF = False
            cboApprovers.Items.Add(tmpRS("FullName").Value.ToString)
            tmpRS.MoveNext()
        End While
    End Sub
    Sub resetTheForm()

        cboDebitAccount.DropDownStyle = ComboBoxStyle.DropDownList
        cboCreditAccount.DropDownStyle = ComboBoxStyle.DropDownList
        cboVoucherNo.DropDownStyle = ComboBoxStyle.DropDownList
        cboPaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        cboInstrumentNo.DropDownStyle = ComboBoxStyle.DropDownList

        mEditFlag = False

        cboExpenseType.Items.Clear()
        cboDebitAccount.Items.Clear()
        cboCreditAccount.Items.Clear()
        dgvJournal_b.Rows.Clear()

        cboPaymentMode.SelectedIndex = -1
        cboExpenseType.SelectedIndex = -1
        cboDebitAccount.SelectedIndex = -1
        cboCreditAccount.SelectedIndex = -1

        dtpInstrumentDate.Enabled = False
        cboInstrumentNo.Enabled = False
        cboBankName.Enabled = False
        cboExpenseType.Enabled = False

        cboInstrumentNo.Text = ""
        cboBankName.Text = ""
        cboDebitAccount.Text = ""
        cboCreditAccount.Text = ""

        txtPaymentAmount.Text = ""
        txtNarration.Text = ""
        txtCreditActDesc.Text = ""
        txtDebitActDesc.Text = ""

        lblApprovedBy.Text = ""
        lblApprovedDate.Text = ""

        'grpExpenseSubType.Visible = True
        optCurExp.Checked = True

        cboExpenseType.Items.Add("NORMAL")
        cboExpenseType.Items.Add("PREPAID")
        cboExpenseType.Items.Add("ADJUST-AGAINST-PREPAID")
        cboExpenseType.Items.Add("DEFERRED")
        cboExpenseType.Items.Add("ADJUST-AGAINST-DEFERRED")
        cboExpenseType.Items.Add("FIXED-ASSET")
        cboExpenseType.Text = "NORMAL"

        loadCheques()
        loadExpenseApprovers()

        cboBankName.Items.Clear()
        For x = 1 To OurBankNames.Length
            cboBankName.Items.Add(OurBankNames(x - 1))
        Next

        loadAvailableVouchers()
        loadTag1()
        loadTag2()
        cboTag1.SelectedIndex = -1
        cboTag2.SelectedIndex = -1
        cboTag1.Enabled = True
        cboTag2.Enabled = True

        btnSave.Enabled = True
        btnUpdatePayment.Enabled = False


        btnApprove.Enabled = False
        btnReject.Enabled = False
        btnEmailApprover.Enabled = False


        txtPaymentAmount.Enabled = True
        dtpPaymentDate.Enabled = True
        txtNarration.Enabled = True
        cboPaymentMode.Enabled = True
        cboApprovers.Enabled = True
        cboVoucherNo.Enabled = True
        cboDebitAccount.Enabled = True

        optNormalExpense.PerformClick()

        restrictForBankChargeOnly()

        If gLoginID <> "sa" Then
            btnChangeDebitSide.Visible = False
            btnUpdateDebitSide.Visible = False
        End If

    End Sub


    Sub restrictForBankChargeOnly()
        If gAllowBankChargeEntryOnly = True Then
            cboExpenseType.Text = "NORMAL"
            cboExpenseType.Enabled = False
            grpExpenseType.Enabled = False
            'grpExpenseSubType.Enabled = False
            cboPaymentMode.Text = "ONLINE"
            cboPaymentMode.Enabled = False
            cboDebitAccount.Text = "EXPCULTCUR-BANKCHARGES"
            cboDebitAccount.Enabled = False
            cboVoucherNo.Enabled = False
            cboApprovers.Text = "BANK"
            cboApprovers.Enabled = False

            btnAddNewAccount.Enabled = False
        End If
    End Sub

    'Private Sub cboDebitAccount_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDebitAccount.SelectedIndexChanged
    '    txtDebitActDesc.Text = getAccountName(cboDebitAccount.Text)
    '    lblDrBalance.Text = addThousandSeparator(getAccountBalance(dtpPaymentDate.Text, cboDebitAccount.Text), False)
    '    loadNarrationTemplates()
    'End Sub

    'Private Sub cboCreditAccount_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCreditAccount.SelectedIndexChanged
    '    txtCreditActDesc.Text = getAccountName(cboCreditAccount.Text)
    '    lblCrBalance.Text = addThousandSeparator(getAccountBalance(dtpPaymentDate.Text, cboCreditAccount.Text), False)
    'End Sub

    Private Sub optCapExp_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optCapExp.CheckedChanged
        loadDebitCombo()
    End Sub

    Private Sub optCurExp_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optCurExp.CheckedChanged
        loadDebitCombo()
    End Sub
    Sub loadNarrationTemplates()
        Dim expActRS As ADODB.Recordset
        cboSampleNarration.Items.Clear()

        If cboDebitAccount.Text = "" Then Exit Sub

        ssql = "select distinct Narration from tbljournal_cult where AccountNo = '" & cboDebitAccount.Text & "' order by Narration"
        expActRS = gcon.Execute(ssql)
        While expActRS.EOF = False
            cboSampleNarration.Items.Add(expActRS("Narration").Value.ToString)
            expActRS.MoveNext()
        End While
    End Sub
    Sub loadTag1()
        Dim tagRS As ADODB.Recordset

        cboTag1.Items.Clear()

        ssql = "select distinct Tag1 from tbljournal_cult" & " order by Tag1"
        tagRS = gcon.Execute(ssql)
        While tagRS.EOF = False
            cboTag1.Items.Add(tagRS("Tag1").Value.ToString)
            tagRS.MoveNext()
        End While
        tagRS.Close()
    End Sub
    Sub loadTag2()
        Dim tagRS As ADODB.Recordset

        cboTag2.Items.Clear()

        ssql = "select distinct Tag2 from tbljournal_cult" & " order by Tag2"
        tagRS = gcon.Execute(ssql)
        While tagRS.EOF = False
            cboTag2.Items.Add(tagRS("Tag2").Value.ToString)
            tagRS.MoveNext()
        End While
        tagRS.Close()
    End Sub



    'Sub loadAccounts()
    '    Dim expActRS As ADODB.Recordset, expAccountType As String


    '    ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Expenses' and AccountNo like '" & expAccountType & "%'"
    '    expActRS = gcon.Execute(ssql)

    '    While expActRS.EOF = False
    '        cboDebitAccount.Items.Add(expActRS("AccountNo").Value.ToString)
    '        expActRS.MoveNext()
    '    End While
    'End Sub

    Sub loadCheques()
        Dim expActRS As ADODB.Recordset

        cboChequeNo.Items.Clear()
        ssql = "select InstrumentNo from tblreceipt_cult where InstrumentType='CHEQUE' and InstrumentReconciled is null order by InstrumentNo"
        expActRS = gcon.Execute(ssql)

        While expActRS.EOF = False
            cboChequeNo.Items.Add(expActRS("InstrumentNo").Value.ToString)
            expActRS.MoveNext()
        End While
    End Sub


    Function SearchCheque() As Boolean
        Dim expActRS As ADODB.Recordset, tmpRcptNo As String, tmpRcptAmt As String
        SearchCheque = False
        cboChequeNo.Text = cboInstrumentNo.Text
        If cboChequeNo.Text = cboInstrumentNo.Text Then
            ssql = "select ReceiptNo,ReceiptAmt from tblreceipt_cult where InstrumentNo='" & cboChequeNo.Text & "'"
            expActRS = gcon.Execute(ssql)

            If expActRS.EOF = False Then
                tmpRcptNo = expActRS("ReceiptNo").Value.ToString
                tmpRcptAmt = expActRS("ReceiptAmt").Value.ToString
                gCurReceiptNo = tmpRcptNo

                SearchCheque = True

                ssql = "select * from tbljournal_cult where AccountNo like'BANK-CULT%' and DocRef like '%Cheque No%" & cboChequeNo.Text & "%'"
                expActRS = gcon.Execute(ssql)
                If expActRS.EOF = False Then
                    MsgBox("This cheque no already entered into system as CHEQUE2BANK txn on " & formatInt2Date(expActRS("TxnDate").Value.ToString))
                Else
                    frmViewReceipt.ShowDialog()
                    frmViewReceipt.Dispose()

                    txtNarration.Text = txtNarration.Text & gCurReceiptNo
                    txtPaymentAmount.Text = tmpRcptAmt
                End If

            End If
            expActRS.Close()
        End If

    End Function


    Private Sub btnShowChequeDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnShowChequeDetails.Click
        Dim expActRS As ADODB.Recordset

        ssql = "select ReceiptNo from tblreceipt_cult where InstrumentNo='" & cboChequeNo.Text & "'"
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

    'Private Sub btnSetChequeNo_Click(sender As System.Object, e As System.EventArgs) Handles btnSetChequeNo.Click
    '    On Error Resume Next
    '    If SearchCheque() = False Then
    '        cboInstrumentNo.Text = "0" & cboInstrumentNo.Text
    '        If SearchCheque() = False Then
    '            gCurReceiptNo = ""
    '            MsgBox("No matching receipt found")
    '        End If
    '    End If
    'End Sub

    Private Sub btnAddNewAccount_Click(sender As System.Object, e As System.EventArgs) Handles btnAddNewAccount.Click
        frmCOA.ShowDialog()
        frmCOA.Dispose()
    End Sub

    Private Sub cboInstrumentNo_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboInstrumentNo.KeyUp
        If e.KeyCode = Keys.Enter Then
            On Error Resume Next
            If SearchCheque() = False Then
                cboInstrumentNo.Text = "0" & cboInstrumentNo.Text
                If SearchCheque() = False Then
                    gCurReceiptNo = ""
                    MsgBox("No matching receipt found")
                End If
            End If
        End If
    End Sub


    Private Sub cboCreditAccount_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboCreditAccount.SelectedValueChanged
        refreshCreditAccount()
        If lblCrBalance.Text <> "" Then
            If lblCrBalance.Text < 0 Then
                MsgBox("There is no avaialable balance in this account. Don't make this payment")
            End If
        End If
        If cboPaymentMode.Text = "CHEQUE" Then ReloadCheques()
    End Sub

    Sub refreshCreditAccount()
        txtCreditActDesc.Text = getAccountName(cboCreditAccount.Text)
        lblCrBalance.Text = addThousandSeparator(getAccountBalance_Cult(dtpPaymentDate.Text, cboCreditAccount.Text), False)
    End Sub

    Sub ReloadCheques()
        cboInstrumentNo.Items.Clear()
        tmpRS = gcon.Execute("select ChequeNo from tblchequebook where Status is null and AccountNo='" & cboCreditAccount.Text & "' order by tblid Asc")
        While tmpRS.EOF = False
            cboInstrumentNo.Items.Add(tmpRS("ChequeNo").Value.ToString)
            tmpRS.MoveNext()
        End While
    End Sub

    Private Sub cboDebitAccount_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboDebitAccount.SelectedValueChanged
        refreshDebitAccount()

        loadNarrationTemplates()
    End Sub

    Sub refreshDebitAccount()
        txtDebitActDesc.Text = getAccountName(cboDebitAccount.Text)
        lblDrBalance.Text = addThousandSeparator(getAccountBalance_Cult(dtpPaymentDate.Text, cboDebitAccount.Text), False)
    End Sub

    Private Sub cboPaymentMode_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboPaymentMode.SelectedValueChanged

        loadDebitCombo()

        cboInstrumentNo.DropDownStyle = ComboBoxStyle.DropDownList

        If cboPaymentMode.Text = "CASH" Then
            dtpInstrumentDate.Enabled = False
            cboInstrumentNo.Enabled = False
            cboBankName.Enabled = False

            'dtpInstrumentDate.Text = ""
            cboInstrumentNo.Text = ""
            cboBankName.Text = ""

            'If (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "PREPAID") Then
            cboCreditAccount.Items.Clear()
            cboCreditAccount.Items.Add("CASHBOX-CULT")
            cboCreditAccount.Text = "CASHBOX-CULT"
            txtCreditActDesc.Text = getAccountName(cboCreditAccount.Text)
            'End If

        ElseIf cboPaymentMode.Text = "CHEQUE" Then
            dtpInstrumentDate.Enabled = True
            cboInstrumentNo.Enabled = True
            cboBankName.Enabled = True

            lblInstrumentDate.Text = "Cheque Date"
            lblInstrumentNo.Text = "Cheque No"

            'If (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "PREPAID") Then
            'cboCreditAccount.Items.Clear()
            'cboCreditAccount.Items.Add("CHEQUE-ISSUED")
            'cboCreditAccount.Text = "CHEQUE-ISSUED"
            loadChequeIssuedAccounts()
            cboCreditAccount.Enabled = True
            txtCreditActDesc.Text = ""
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
            cboBankName.Enabled = True
            lblInstrumentDate.Text = "Transfer Date"
            lblInstrumentNo.Text = "Transaction Ref. No"
            dtpInstrumentDate.Text = dtpPaymentDate.Text
            'If (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "PREPAID") Then
            loadBankAccounts("CR")
            cboCreditAccount.Enabled = True
            txtCreditActDesc.Text = ""
            'End If

        End If
        lblDrBalance.Text = addThousandSeparator(getAccountBalance_Cult(dtpPaymentDate.Text, cboDebitAccount.Text), False)
        lblCrBalance.Text = addThousandSeparator(getAccountBalance_Cult(dtpPaymentDate.Text, cboCreditAccount.Text), False)
    End Sub

    Private Sub dtpPaymentDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpPaymentDate.ValueChanged
        dtpInstrumentDate.Text = dtpPaymentDate.Text
        If mEditFlag = False Then btnQueryExpense.PerformClick()

    End Sub

    Private Sub btnCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnCopy.Click
        If cboSampleNarration.Text = "" Then Exit Sub
        txtNarration.Text = cboSampleNarration.Text
    End Sub

    Private Sub btnQueryExpense_Click(sender As System.Object, e As System.EventArgs) Handles btnQueryExpense.Click
        PopulateJournal_b(False, False)
    End Sub
    Private Sub btnShowAllPending_Click(sender As Object, e As EventArgs) Handles btnShowAllPending.Click
        PopulateJournal_b(True, False)
    End Sub
    Private Sub btnShowPendingWithMe_Click(sender As Object, e As EventArgs) Handles btnShowPendingWithMe.Click
        PopulateJournal_b(True, True)
    End Sub
    Sub PopulateJournal_b(onlyPending As Boolean, onlyCurUser As Boolean)
        On Error GoTo errH
        Dim i As Long, netDrAmt As Double, netCrAmt As Double, rsJournal As ADODB.Recordset, journalQuerySQL As String, journalQuerySQL2 As String, rsJournal2 As ADODB.Recordset

        netDrAmt = 0
        netCrAmt = 0

        dgvJournal_b.Rows.Clear()

        With dgvJournal_b

            .Columns("CrAmount_b").Visible = False
            .Columns("DrAccountNo_b").Visible = True
            .Columns("CrAccountNo_b").Visible = False
            .Columns("DocRef_b").Visible = False

            btnShowMoreInGrid.Text = "Show More"

        End With

        journalQuerySQL = "select * from tbljournal_cult where 1=1 " 'and status is null"

        'journalQuerySQL = journalQuerySQL & " and TxnDate='" & DateTime.Parse(dtpPaymentDate.Text).ToString(DB_DATEFORMAT) & "' "
        If (cboExpenseType.Text = "NORMAL") Or (cboExpenseType.Text = "ADJUST-AGAINST-PREPAID") Then
            journalQuerySQL = journalQuerySQL & " and CrAmount=0 and TxnType='EXPENSE' "
        ElseIf cboExpenseType.Text = "DEFERRED" Then
            journalQuerySQL = journalQuerySQL & " and DrAmount=0 and TxnType='EXPENSE' and AccountNo like 'DEFERRED-LIAB-CULT%' "
        ElseIf cboExpenseType.Text = "FIXED-ASSET" Then
            journalQuerySQL = journalQuerySQL & " and CrAmount=0 and TxnType='FIXED-ASSET' "
        ElseIf cboExpenseType.Text = "PREPAID" Then
            journalQuerySQL = journalQuerySQL & " and CrAmount=0 and TxnType='PREPAID-EXPENSE' "
        ElseIf cboExpenseType.Text = "ADJUST-AGAINST-DEFERRED" Then
            journalQuerySQL = journalQuerySQL & " and CrAmount=0 and TxnType='POSTPAID-EXPENSE' "
        Else
            MsgBox("Invalid Expense Type. Contact System Admin")
            Exit Sub
        End If

        If onlyPending = True Then
            journalQuerySQL = journalQuerySQL & " and status = 'P' and (TxnType like '%EXPENSE' or TxnType = 'FIXED-ASSET') "
            If onlyCurUser = True Then
                journalQuerySQL = journalQuerySQL & " and SupervisorName = '" & gUserName & "' "
            End If
        Else
            journalQuerySQL = journalQuerySQL & " and TxnDate='" & DateTime.Parse(dtpPaymentDate.Text).ToString(DB_DATEFORMAT) & "' "
        End If

        journalQuerySQL = journalQuerySQL & " order by tblid desc"
        rsJournal = gcon.Execute(journalQuerySQL)


        With dgvJournal_b

            While rsJournal.EOF = False

                i = .Rows.Add()
                .Rows(i).Cells("tblid_b").Value = rsJournal("tblid").Value.ToString
                .Rows(i).Cells("gid_b").Value = rsJournal("gid").Value.ToString
                .Rows(i).Cells("TxnType_b").Value = formatInt2Date(rsJournal("TxnType").Value.ToString)
                .Rows(i).Cells("TxnDate_b").Value = formatInt2Date(rsJournal("TxnDate").Value.ToString)
                .Rows(i).Cells("Narration_b").Value = rsJournal("Narration").Value.ToString
                .Rows(i).Cells("DocRef_b").Value = rsJournal("DocRef").Value.ToString
                .Rows(i).Cells("DrAccountNo_b").Value = rsJournal("AccountNo").Value.ToString
                .Rows(i).Cells("DrAmount_b").Value = rsJournal("DrAmount").Value.ToString
                .Rows(i).Cells("CrAmount_b").Value = rsJournal("CrAmount").Value.ToString
                .Rows(i).Cells("VoucherNo").Value = IIf(rsJournal("VoucherNo").Value.ToString = "", "Not Applicable", rsJournal("VoucherNo").Value.ToString)
                .Rows(i).Cells("SupervisorName").Value = IIf(rsJournal("SupervisorName").Value.ToString = "", "System", rsJournal("SupervisorName").Value.ToString)
                .Rows(i).Cells("Tag1").Value = rsJournal("Tag1").Value.ToString
                .Rows(i).Cells("Tag2").Value = rsJournal("Tag2").Value.ToString

                Select Case rsJournal("Status").Value.ToString
                    Case ""
                        .Rows(i).Cells("Status").Value = "Approved"
                        .Rows(i).Cells("ApprovedBy").Value = IIf(rsJournal("ApprovedBy").Value.ToString = "", "System", rsJournal("ApprovedBy").Value.ToString)
                        .Rows(i).Cells("ApprovedDate").Value = IIf(rsJournal("ApprovedDate").Value.ToString = "", formatInt2Date(rsJournal("TxnDate").Value.ToString), formatInt2Date(rsJournal("ApprovedDate").Value.ToString)) 'to support data prior to 1-Apr-2014
                    Case "P"
                        .Rows(i).Cells("Status").Value = "Pending"
                        .Rows(i).Cells("ApprovedBy").Value = rsJournal("ApprovedBy").Value.ToString
                        .Rows(i).Cells("ApprovedDate").Value = formatInt2Date(rsJournal("ApprovedDate").Value.ToString)
                    Case "C"
                        .Rows(i).Cells("Status").Value = "Cancelled"
                        .Rows(i).Cells("ApprovedBy").Value = IIf(rsJournal("ApprovedBy").Value.ToString = "", "System", rsJournal("ApprovedBy").Value.ToString)
                        .Rows(i).Cells("ApprovedDate").Value = IIf(rsJournal("ApprovedDate").Value.ToString = "", formatInt2Date(rsJournal("TxnDate").Value.ToString), formatInt2Date(rsJournal("ApprovedDate").Value.ToString)) 'to support data prior to 1-Apr-2014
                    Case "R"
                        .Rows(i).Cells("Status").Value = "Rejected"
                        .Rows(i).Cells("ApprovedBy").Value = IIf(rsJournal("ApprovedBy").Value.ToString = "", "System", rsJournal("ApprovedBy").Value.ToString)
                        .Rows(i).Cells("ApprovedDate").Value = IIf(rsJournal("ApprovedDate").Value.ToString = "", formatInt2Date(rsJournal("TxnDate").Value.ToString), formatInt2Date(rsJournal("ApprovedDate").Value.ToString)) 'to support data prior to 1-Apr-2014
                    Case Else
                        .Rows(i).Cells("Status").Value = "Undefined"
                        .Rows(i).Cells("ApprovedBy").Value = rsJournal("ApprovedBy").Value.ToString
                        .Rows(i).Cells("ApprovedDate").Value = formatInt2Date(rsJournal("ApprovedDate").Value.ToString)
                End Select

                netDrAmt = netDrAmt + rsJournal("DrAmount").Value.ToString
                netCrAmt = netCrAmt + rsJournal("CrAmount").Value.ToString

                '=======get credit a/c no=======
                journalQuerySQL2 = "Select AccountNo from tbljournal_cult where DrAmount=0 And gid='" & rsJournal("gid").Value.ToString & "'"
                rsJournal2 = gcon.Execute(journalQuerySQL2)

                If rsJournal2.EOF = False Then
                    .Rows(i).Cells("CrAccountNo_b").Value = rsJournal2("AccountNo").Value.ToString
                    rsJournal2.Close()
                End If
                '================================

                .Rows(i).ReadOnly = True
                'if not reconciled with bank, then set forecolor to red, else green.
                If rsJournal("refgid").Value.ToString = "" Then
                    .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                End If
                If .Rows(i).Cells("Status").Value = "Pending" Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Yellow
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
        gErrMsg = gErrMsg & " " & Err.Description
        myMsgBox(gErrMsg)
        gErrMsg = ""
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        'Call resetFields()
        resetTheForm()
    End Sub

    Private Sub cboExpenseType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboExpenseType.SelectedValueChanged

        loadDebitCombo()

        If cboExpenseType.Text = "ADJUST-AGAINST-PREPAID" Then
            'grpExpenseSubType.Visible = True

            cboPaymentMode.Enabled = False
            cboCreditAccount.Enabled = True

            dtpInstrumentDate.Enabled = False
            cboInstrumentNo.Enabled = False
            cboBankName.Enabled = False

            cboPaymentMode.SelectedIndex = -1
            'dtpInstrumentDate.Text = ""
            cboInstrumentNo.Text = ""
            cboBankName.Text = ""
            cboDebitAccount.Text = ""
            cboCreditAccount.SelectedIndex = -1
            txtDebitActDesc.Text = ""
            txtCreditActDesc.Text = ""
            cboBankName.SelectedIndex = -1

            loadDeferredExpAccounts() 'in credit account combo
            'loadCreditorAccounts() 'in credit account combo

            lblDebitDesc.Text = "Payment for "
            lblCreditDesc.Text = "Pay from"

        ElseIf cboExpenseType.Text = "ADJUST-AGAINST-DEFERRED" Then
            'grpExpenseSubType.Visible = False

            cboPaymentMode.Enabled = True
            cboCreditAccount.Enabled = False

            cboDebitAccount.Text = ""
            txtDebitActDesc.Text = ""
            cboCreditAccount.SelectedIndex = -1
            txtCreditActDesc.Text = ""
            cboBankName.SelectedIndex = -1

            lblDebitDesc.Text = "Payment for "
            lblCreditDesc.Text = "Paid through"

        ElseIf cboExpenseType.Text = "NORMAL" Then

            'grpExpenseSubType.Visible = True

            cboPaymentMode.Enabled = True
            cboCreditAccount.Enabled = False

            cboDebitAccount.Text = ""
            txtDebitActDesc.Text = ""
            cboCreditAccount.SelectedIndex = -1
            txtCreditActDesc.Text = ""
            cboBankName.SelectedIndex = -1

            lblDebitDesc.Text = "Payment for "
            lblCreditDesc.Text = "Paid through"

        ElseIf cboExpenseType.Text = "PREPAID" Then ' These are not expense, but top-up
            'grpExpenseSubType.Visible = False

            cboPaymentMode.Enabled = True
            cboCreditAccount.Enabled = False

            cboDebitAccount.Text = ""
            txtDebitActDesc.Text = ""
            cboCreditAccount.SelectedIndex = -1
            txtCreditActDesc.Text = ""
            cboBankName.SelectedIndex = -1

            lblDebitDesc.Text = "Payment for "
            lblCreditDesc.Text = "Paid through"

        ElseIf cboExpenseType.Text = "DEFERRED" Then ' These are not expense, but top-up
            'grpExpenseSubType.Visible = False

            cboPaymentMode.Enabled = False
            cboCreditAccount.Enabled = True

            cboDebitAccount.Text = ""
            txtDebitActDesc.Text = ""
            cboCreditAccount.SelectedIndex = -1
            txtCreditActDesc.Text = ""
            cboBankName.SelectedIndex = -1

            loadLiabilitiesAccounts() 'in credit account combo

            lblDebitDesc.Text = "Payment for "
            lblCreditDesc.Text = "To be paid to"

        ElseIf cboExpenseType.Text = "FIXED-ASSET" Then ' These are not expense, but ASSET PURCHASE - THE DEPRECIATION IS EXPENSE
            'grpExpenseSubType.Visible = True

            cboPaymentMode.Enabled = True
            cboCreditAccount.Enabled = False

            cboDebitAccount.Text = ""
            txtDebitActDesc.Text = ""
            cboCreditAccount.SelectedIndex = -1
            txtCreditActDesc.Text = ""
            cboBankName.SelectedIndex = -1

            lblDebitDesc.Text = "Payment for "
            lblCreditDesc.Text = "Paid through"


        End If

        cboPaymentMode.SelectedIndex = -1

        If mEditFlag = False Then btnQueryExpense.PerformClick()

    End Sub



    Private Sub optNormalExpense_Click(sender As Object, e As EventArgs) Handles optNormalExpense.Click
        cboExpenseType.Text = "Normal"
    End Sub



    Private Sub optFixedAsset_Click(sender As Object, e As EventArgs) Handles optFixedAsset.Click
        cboExpenseType.Text = "FIXED-ASSET"
    End Sub



    Private Sub optPrepaid_Click(sender As Object, e As EventArgs) Handles optPrepaid.Click
        cboExpenseType.Text = "PREPAID"
    End Sub


    Private Sub optAdjustPrepaid_Click(sender As Object, e As EventArgs) Handles optAdjustPrepaid.Click
        cboExpenseType.Text = "ADJUST-AGAINST-PREPAID"
    End Sub


    Private Sub optProvision_Click(sender As Object, e As EventArgs) Handles optProvision.Click
        cboExpenseType.Text = "DEFERRED"
    End Sub


    Private Sub optDeferredPayment_Click(sender As Object, e As EventArgs) Handles optDeferredPayment.Click
        cboExpenseType.Text = "ADJUST-AGAINST-DEFERRED"
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dtpPaymentDate.ShowUpDown = Not dtpPaymentDate.ShowUpDown
    End Sub

    '    Private Sub btnChangeDebitSide_Click(sender As Object, e As EventArgs) Handles btnChangeDebitSide.Click
    '        On Error GoTo errH
    '        Dim ri As Integer, ci As Integer

    '        If dgvJournal_b.Rows.Count = 0 Then Exit Sub

    '        ri = dgvJournal_b.CurrentCell.RowIndex
    '        If ri < 0 Then Exit Sub
    '        'If dgvJournal_b.CurrentRow.Index < 0 Then Exit Sub
    '        If MsgBox("This will set the screen for changing the payment type for transaction listed at row : " & (ri + 1) & " . Proceed?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub


    '        mTblID = ""

    '        'Populatr screen fields from grid
    '        With dgvJournal_b
    '            mTblID = .Rows(ri).Cells("tblid_b").Value
    '            txtNarration.Text = .Rows(ri).Cells("Narration_b").Value
    '            txtPaymentAmount.Text = .Rows(ri).Cells("DrAmount_b").Value
    '            cboExpenseType.Text = getPaymentTypeFromTxnType(.Rows(ri).Cells("TxnType_b").Value, .Rows(ri).Cells("DrAccountNo_b").Value)

    '        End With


    '        btnSave.Enabled = False
    '        btnChangeDebitSide.Enabled = False
    '        btnUpdateDebitSide.Enabled = True

    '        txtPaymentAmount.Enabled = False
    '        dtpPaymentDate.Enabled = False
    '        txtNarration.Enabled = False
    '        cboPaymentMode.Enabled = False

    '        Exit Sub

    'errH:
    '        gErrMsg = gErrMsg & " " & Err.Description
    '        myMsgBox(gErrMsg)
    '        gErrMsg = ""
    '    End Sub
    Private Sub DisplayVoucher()
        On Error GoTo errH
        Dim ri As Integer, ci As Integer
        Dim mDocRef As String, cracct As String

        If dgvJournal_b.Rows.Count = 0 Then Exit Sub

        ri = dgvJournal_b.CurrentCell.RowIndex
        If ri < 0 Then Exit Sub
        'If dgvJournal_b.CurrentRow.Index < 0 Then Exit Sub
        'If MsgBox("This will set the screen for changing the payment type for transaction listed at row : " & (ri + 1) & " . Proceed?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub


        mTblID = ""
        mEditFlag = True

        'Populatr screen fields from grid
        cboDebitAccount.DropDownStyle = ComboBoxStyle.Simple
        cboCreditAccount.DropDownStyle = ComboBoxStyle.Simple
        cboVoucherNo.DropDownStyle = ComboBoxStyle.Simple
        cboPaymentMode.DropDownStyle = ComboBoxStyle.Simple
        cboInstrumentNo.DropDownStyle = ComboBoxStyle.Simple



        With dgvJournal_b
            mGID = .Rows(ri).Cells("gid_b").Value
            mDocRef = .Rows(ri).Cells("DocRef_b").Value
            cracct = .Rows(ri).Cells("CrAccountNo_b").Value

            cboBankName.Text = ""
            cboInstrumentNo.Text = ""
            cboPaymentMode.Text = "-"

            'set this first before other controls as this triggers payment mode change event
            If InStr(cracct, "CASHBOX") > 0 Then
                cboPaymentMode.Text = "CASHBOX"
            ElseIf InStr(cracct, "CHEQUE") > 0 Then
                cboPaymentMode.Text = "CHEQUE"
                Dim myDR = New clsDocRef
                cboInstrumentNo.Text = myDR.getChequeNo(mDocRef)
                dtpInstrumentDate.Value = myDR.getChequeDate(mDocRef)
                cboBankName.Text = myDR.getBankName(mDocRef)
            ElseIf InStr(cracct, "BANK") > 0 Then
                cboPaymentMode.Text = "ONLINE"
                Dim myDR = New clsDocRef
                cboInstrumentNo.Text = myDR.getOnlineTransferRefNo(mDocRef)
                dtpInstrumentDate.Value = myDR.getTranDate(mDocRef)
                cboBankName.Text = myDR.getBankName(mDocRef)
            Else

            End If

            dtpPaymentDate.Value = .Rows(ri).Cells("TxnDate_b").Value
            txtNarration.Text = .Rows(ri).Cells("Narration_b").Value
            txtPaymentAmount.Text = .Rows(ri).Cells("DrAmount_b").Value
            cboExpenseType.Text = getPaymentTypeFromTxnType(.Rows(ri).Cells("TxnType_b").Value, .Rows(ri).Cells("DrAccountNo_b").Value)
            cboCreditAccount.Text = .Rows(ri).Cells("CrAccountNo_b").Value
            cboDebitAccount.Text = .Rows(ri).Cells("DrAccountNo_b").Value

            cboVoucherNo.Text = .Rows(ri).Cells("VoucherNo").Value

            lblApprovedBy.Text = .Rows(ri).Cells("ApprovedBy").Value
            lblApprovedDate.Text = formatInt2Date(.Rows(ri).Cells("ApprovedDate").Value)
            cboApprovers.Text = .Rows(ri).Cells("SupervisorName").Value

            cboTag1.Text = .Rows(ri).Cells("Tag1").Value
            cboTag2.Text = .Rows(ri).Cells("Tag2").Value

        End With

        btnSave.Enabled = False

        txtPaymentAmount.Enabled = False
        cboPaymentMode.Enabled = False
        cboBankName.Enabled = False

        If dgvJournal_b.Rows(ri).Cells("Status").Value = "Pending" Then
            btnEmailApprover.Enabled = True
            btnUpdatePayment.Enabled = True

            dtpPaymentDate.Enabled = True
            txtNarration.Enabled = True
            cboApprovers.Enabled = True

            If isMemberOfRole(gLoginID, "ExpenseApproversCultural") = True Then
                btnApprove.Enabled = True
                btnReject.Enabled = True
            End If
        Else
            btnApprove.Enabled = False
            btnReject.Enabled = False
            btnEmailApprover.Enabled = False
            btnUpdatePayment.Enabled = False

            dtpPaymentDate.Enabled = False
            txtNarration.Enabled = False
            cboApprovers.Enabled = False
        End If


        cboDebitAccount.Enabled = False
        cboCreditAccount.Enabled = False
        cboVoucherNo.Enabled = False
        cboPaymentMode.Enabled = False
        cboInstrumentNo.Enabled = False
        dtpInstrumentDate.Enabled = False

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        myMsgBox(gErrMsg)
        gErrMsg = ""
    End Sub

    Function getTxnTypeFromPaymentType(PType As String) As String
        Dim TType As String = ""

        If (PType = "NORMAL") Or (PType = "ADJUST-AGAINST-PREPAID") Or (PType = "DEFERRED") Then
            TType = "EXPENSE"
        ElseIf PType = "FIXED-ASSET" Then
            TType = "FIXED-ASSET"
        ElseIf PType = "PREPAID" Then
            TType = "PREPAID-EXPENSE"
        ElseIf PType = "ADJUST-AGAINST-DEFERRED" Then
            TType = "POSTPAID-EXPENSE"
        Else
            TType = ""
        End If

        getTxnTypeFromPaymentType = TType

    End Function

    Function getPaymentTypeFromTxnType(TType As String, Optional ActNo As String = "") As String
        Dim PType As String = ""

        If (TType = "EXPENSE") Then
            If InStr(ActNo, "DEFERRED-") > 0 Then
                PType = "DEFERRED"
            Else 'Or (PType = "ADJUST-AGAINST-PREPAID")  Then
                PType = "NORMAL"
            End If

        ElseIf TType = "FIXED-ASSET" Then
            PType = "FIXED-ASSET"
        ElseIf TType = "PREPAID-EXPENSE" Then
            PType = "PREPAID"
        ElseIf TType = "POSTPAID-EXPENSE" Then
            PType = "ADJUST-AGAINST-DEFERRED"
        Else
            TType = ""
        End If

        getPaymentTypeFromTxnType = TType

    End Function


    '    Private Sub btnUpdateDebitSide_Click(sender As Object, e As EventArgs) Handles btnUpdateDebitSide.Click
    '        On Error GoTo errH

    '        ssql = "Update tbljournal_cult set "
    '        ssql = ssql & " TxnType='" & getTxnTypeFromPaymentType(cboExpenseType.Text) & "'"
    '        ssql = ssql & ",AccountNo='" & cboDebitAccount.Text & "'"
    '        ssql = ssql & " where tblid=" & mTblID
    '        gcon.Execute(ssql)

    '        MsgBox("Done")

    '        txtNarration.Text = ""
    '        txtPaymentAmount.Text = ""

    '        btnSave.Enabled = True
    '        btnChangeDebitSide.Enabled = True
    '        btnUpdateDebitSide.Enabled = False

    '        txtPaymentAmount.Enabled = True
    '        dtpPaymentDate.Enabled = True
    '        txtNarration.Enabled = True
    '        cboPaymentMode.Enabled = True

    '        btnQueryExpense.PerformClick()

    '        Exit Sub
    'errH:
    '        gErrMsg = gErrMsg & " " & Err.Description
    '        myMsgBox(gErrMsg)
    '        gErrMsg = ""

    '    End Sub


    '    Private Sub btnEnableVoucherNoUpdate_Click(sender As Object, e As EventArgs) Handles btnEnableVoucherNoUpdate.Click
    '        On Error GoTo errH
    '        Dim ri As Integer, ci As Integer, tmpVN As String

    '        If dgvJournal_b.Rows.Count = 0 Then Exit Sub
    '        ri = dgvJournal_b.CurrentCell.RowIndex
    '        If ri < 0 Then Exit Sub
    '        'If dgvJournal_b.CurrentRow.Index < 0 Then Exit Sub
    '        If MsgBox("This will set the screen for correcting the voucher number for transaction listed at row : " & (ri + 1) & " . Proceed?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub


    '        mGID = ""
    '        mDocRef = ""
    '        Dim myDR = New clsDocRef

    '        'Populate screen fields from grid
    '        With dgvJournal_b
    '            mDocRef = .Rows(ri).Cells("DocRef_b").Value
    '            mGID = .Rows(ri).Cells("gid_b").Value
    '        End With

    '        tmpVN = myDR.getVoucherNo(mDocRef)
    '        If tmpVN <> "" Then
    '            MsgBox("Voucher No already exist")
    '            Exit Sub
    '        End If

    '        If (InStr(mDocRef, "Paid in CASH") = 0) And (InStr(mDocRef, "Cheque No:") = 0) Then
    '            MsgBox("This transaction is not valid for voucher number")
    '            Exit Sub
    '        End If


    '        cboVoucherNo.Text = tmpVN
    '        lblGID.Text = mGID

    '        btnSave.Enabled = False
    '        btnEnableVoucherNoUpdate.Enabled = False
    '        btnUpdateVoucherNo.Enabled = True

    '        cboVoucherNo.Focus()

    '        Exit Sub

    'errH:
    '        gErrMsg = gErrMsg & " " & Err.Description
    '        myMsgBox(gErrMsg)
    '        gErrMsg = ""
    '    End Sub

    '    Private Sub btnUpdateVoucherNo_Click(sender As Object, e As EventArgs) Handles btnUpdateVoucherNo.Click
    '        On Error GoTo errH


    '        mDocRef = myLeft(mDocRef, Len(mDocRef) - 1)
    '        mDocRef = mDocRef & ", VoucherNo:" & stripLeadingZero(Trim(cboVoucherNo.Text)) & ")"
    '        ssql = "Update tbljournal_cult set "
    '        ssql = ssql & " DocRef='" & mDocRef & "'"
    '        ssql = ssql & " VoucherNo=" & stripLeadingZero(Trim(cboVoucherNo.Text))
    '        ssql = ssql & " where gid='" & mGID & "'"
    '        gcon.Execute(ssql)
    '        'mark the voucher as used

    '        ssql = "Update tblvoucherbook_cult set Status='U' where VoucherNo=" & stripLeadingZero(Trim(cboVoucherNo.Text))
    '        gcon.Execute(ssql)

    '        MsgBox("Done")

    '        loadAvailableVouchers()
    '        cboVoucherNo.SelectedIndex = -1
    '        lblGID.Text = ""

    '        btnSave.Enabled = True
    '        btnEnableVoucherNoUpdate.Enabled = True
    '        btnUpdateVoucherNo.Enabled = False

    '        btnQueryExpense.PerformClick()

    '        Exit Sub
    'errH:
    '        gErrMsg = gErrMsg & " " & Err.Description
    '        myMsgBox(gErrMsg)
    '        gErrMsg = ""
    '    End Sub


    Private Sub dgvJournal_b_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvJournal_b.CellContentDoubleClick
        DisplayVoucher()
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        ApproveRejectTransaction(mGID, "A")
        eMailApprover("APPROVED")
    End Sub

    Private Sub ApproveRejectTransaction(thisGid As String, thisAction As String) 'thisAction=A|R
        On Error GoTo errH

        If MsgBox("Are you sure you want to " & IIf(thisAction = "A", "approve", "reject") & " this transaction? ", vbYesNo) = vbNo Then
            Exit Sub
        End If

        Dim thisJournal As New clsJournal_Cult
        With thisJournal
            .TxnStatus = thisAction 'A=>approve;R=reject
            .gid = thisGid
            .ApproveRejectJournal()
        End With

        If cboPaymentMode.Text = "CHEQUE" Then
            'mark the cheque as used, approval pending
            If thisAction = "A" Then
                ssql = "Update tblchequebook set Status='U',Remarks='Used. Approved by " & gUserName & "' where ChequeNo = '" & stripLeadingZero(cboInstrumentNo.Text) & "' and AccountNo='" & cboCreditAccount.Text & "'"
            ElseIf thisAction = "R" Then
                ssql = "Update tblchequebook set Status='R',Remarks='Rejected. Rejected by " & gUserName & "' where ChequeNo = '" & stripLeadingZero(cboInstrumentNo.Text) & "' and AccountNo='" & cboCreditAccount.Text & "'"
            End If
            gcon.Execute(ssql)
        End If


        If thisJournal.Status = True Then
            gItemAction = "Payment " & IIf(thisAction = "A", "approved", "rejected") & " by " & gLoginID
            gItemID = "Voucher No:" & cboVoucherNo.Text
            If logUserActivity() = False Then GoTo errH
            MsgBox("Done")
        End If

        btnShowPendingWithMe.PerformClick()

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        myMsgBox(gErrMsg)
        gErrMsg = ""
    End Sub


    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        ApproveRejectTransaction(mGID, "R")
        eMailApprover("REJECTED")
    End Sub


    Private Sub btnEmailApprover_Click(sender As Object, e As EventArgs) Handles btnEmailApprover.Click
        eMailApprover("NOTIFY-CREATE")
    End Sub

    Sub eMailApprover(action As String) 'action=NOTIFY-CREATE|NOTIFY-UPDATE|APPROVED|REJECTED
        On Error GoTo errH


        If cboApprovers.Text = "None" Or cboApprovers.Text = "BANK" Then
            MsgBox("Mail not sent")
            Exit Sub
        End If

        Dim myMailer As New clsSendMail, tmpstr As String
        With myMailer

            tmpstr = ""
            If action = "NOTIFY-CREATE" Then
                .mailSubject = "Payment Approval Notification : Cultural Sub-Committee, Greenfield Heights(HIG) Association : (Rs. " & txtPaymentAmount.Text & ")"
                tmpstr = "Dear " & cboApprovers.Text & "<br>"
                tmpstr = tmpstr & "Below payment has been recorded into Facility Management Accounting System.<br>"
                tmpstr = tmpstr & "<B>You are assigned as the Approver for this payment."
                tmpstr = tmpstr & "<br><B>Request you to review the payment details and APPROVE or REJECT it in the system at the earliest.</B><br>"

                tmpstr = tmpstr & "<table border=1><th align=center colspan=2 bgcolor=gray><b><font color=blue>Payment Details</font></B></th>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment For</td><td>" & txtNarration.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment Amount</td><td>" & "Rs. " & txtPaymentAmount.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment Date</td><td>" & dtpPaymentDate.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Voucher No</td><td>" & cboVoucherNo.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment By</td><td>" & cboPaymentMode.Text & "</td></tr>"
                If cboPaymentMode.Text = "CHEQUE" Then
                    tmpstr = tmpstr & "<tr><td bgcolor=gray>Cheque No</td><td>" & cboInstrumentNo.Text & "</td></tr>"
                End If
                tmpstr = tmpstr & "</table>"

                tmpstr = tmpstr & "<br>Payment entered into system by " & gUserName & " at " & DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") & " IST<br>"
                tmpstr = tmpstr & "<br><B><font color=red>PS: This is a system generated mail. Do not reply to this mail id.</font></B>"
            ElseIf action = "NOTIFY-UPDATE" Then
                .mailSubject = "Payment Approval Notification [UPDATE] : Cultural Sub-Committee, Greenfield Heights(HIG) Association : (Rs. " & txtPaymentAmount.Text & ")"
                tmpstr = "Dear " & cboApprovers.Text & "<br>"
                tmpstr = tmpstr & "Below payment details has been updated into Facility Management Accounting System.<br>"
                tmpstr = tmpstr & "<B>You were assigned as the Approver for this payment."
                tmpstr = tmpstr & "<br><B>Request you to review the updated payment details and APPROVE or REJECT it in the system at the earliest.</B><br>"

                tmpstr = tmpstr & "<table border=1><th align=center colspan=2 bgcolor=gray><b><font color=blue>Payment Details</font></B></th>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment For</td><td>" & txtNarration.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment Amount</td><td>" & "Rs. " & txtPaymentAmount.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment Date</td><td>" & dtpPaymentDate.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Voucher No</td><td>" & cboVoucherNo.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment By</td><td>" & cboPaymentMode.Text & "</td></tr>"
                If cboPaymentMode.Text = "CHEQUE" Then
                    tmpstr = tmpstr & "<tr><td bgcolor=gray>Cheque No</td><td>" & cboInstrumentNo.Text & "</td></tr>"
                End If
                tmpstr = tmpstr & "</table>"

                tmpstr = tmpstr & "<br>Payment updated into system by " & gUserName & " at " & DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") & " IST<br>"
                tmpstr = tmpstr & "<br><B><font color=red>PS: This is a system generated mail. Do not reply to this mail id.</font></B>"
            ElseIf action = "APPROVED" Then
                .mailSubject = "Payment Approved : Cultural Sub-Committee, Greenfield Heights(HIG) Association : (Rs. " & txtPaymentAmount.Text & ")"
                tmpstr = "Dear " & cboApprovers.Text & "<br>"
                tmpstr = tmpstr & "This is to record that below payment has been approved into Facility Management Accounting System by you at " & DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") & ".<br>"

                tmpstr = tmpstr & "<table border=1><th align=center colspan=2 bgcolor=gray><b><font color=blue>Payment Details</font></B></th>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment For</td><td>" & txtNarration.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment Amount</td><td>" & "Rs. " & txtPaymentAmount.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment Date</td><td>" & dtpPaymentDate.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Voucher No</td><td>" & cboVoucherNo.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment By</td><td>" & cboPaymentMode.Text & "</td></tr>"
                If cboPaymentMode.Text = "CHEQUE" Then
                    tmpstr = tmpstr & "<tr><td bgcolor=gray>Cheque No</td><td>" & cboInstrumentNo.Text & "</td></tr>"
                End If
                tmpstr = tmpstr & "</table>"

                tmpstr = tmpstr & "<br><B><font color=red>PS: This is a system generated mail. Do not reply to this mail id.</font></B>"

            ElseIf action = "REJECTED" Then
                .mailSubject = "Payment Rejected : Cultural Sub-Committee, Greenfield Heights(HIG) Association : (Rs. " & txtPaymentAmount.Text & ")"
                tmpstr = "Dear " & cboApprovers.Text & "<br>"
                tmpstr = tmpstr & "This is to record that below payment has been rejected into Facility Management Accounting System by you at " & DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") & ".<br>"

                tmpstr = tmpstr & "<table border=1><th align=center colspan=2 bgcolor=gray><b><font color=blue>Payment Details</font></B></th>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment For</td><td>" & txtNarration.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment Amount</td><td>" & "Rs. " & txtPaymentAmount.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment Date</td><td>" & dtpPaymentDate.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Voucher No</td><td>" & cboVoucherNo.Text & "</td></tr>"
                tmpstr = tmpstr & "<tr><td bgcolor=gray>Payment By</td><td>" & cboPaymentMode.Text & "</td></tr>"
                If cboPaymentMode.Text = "CHEQUE" Then
                    tmpstr = tmpstr & "<tr><td bgcolor=gray>Cheque No</td><td>" & cboInstrumentNo.Text & "</td></tr>"
                End If
                tmpstr = tmpstr & "</table>"

                tmpstr = tmpstr & "<br><B><font color=red>PS: This is a system generated mail. Do not reply to this mail id.</font></B>"
            End If

            .mailBody = tmpstr
            .IsBodyHtml = True

            If cboApprovers.Text <> "" Then
                .SendMail_Expense_Cultural(getUserEmail(cboApprovers.Text))
                If .sendStatus = True Then
                    MsgBox("Mail Sent")
                Else
                    MsgBox("Mail couldn't be send")
                End If
            Else
                MsgBox("No Approver selected")
            End If

        End With

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        myMsgBox(gErrMsg)
        gErrMsg = ""
    End Sub

    Private Sub btnShowMoreInGrid_Click(sender As Object, e As EventArgs) Handles btnShowMoreInGrid.Click

        Select Case btnShowMoreInGrid.Text
            Case "Show More"
                With dgvJournal_b

                    .Columns("CrAmount_b").Visible = True
                    .Columns("DrAccountNo_b").Visible = True
                    .Columns("CrAccountNo_b").Visible = True
                    .Columns("DocRef_b").Visible = True

                    btnShowMoreInGrid.Text = "Show Less"
                End With
            Case "Show Less"
                With dgvJournal_b

                    .Columns("CrAmount_b").Visible = False
                    .Columns("DrAccountNo_b").Visible = True
                    .Columns("CrAccountNo_b").Visible = False
                    .Columns("DocRef_b").Visible = False

                    btnShowMoreInGrid.Text = "Show More"
                End With


        End Select

    End Sub

    Private Sub lblTag1_Click(sender As Object, e As EventArgs) Handles lblTag1.Click
        cboTag1.Enabled = True
        btnUpdateTag.Enabled = True
    End Sub

    Private Sub lblTag2_Click(sender As Object, e As EventArgs) Handles lblTag2.Click
        cboTag2.Enabled = True
        btnUpdateTag.Enabled = True
    End Sub

    Private Sub btnUpdateTag_Click(sender As Object, e As EventArgs) Handles btnUpdateTag.Click
        On Error GoTo errH

        Dim thisJournal As New clsJournal_Cult
        gAllowBackDateEntry = True
        With thisJournal
            .gid = mGID
            .TxnDate = dtpPaymentDate.Text
            .Tag1 = cboTag1.Text
            .Tag2 = cboTag2.Text
            .UpdateJournalForTag()

            gItemAction = "Update"
            If .Status = True Then
                gItemID = cboTag1.Text & "|" & cboTag2.Text
                If logUserActivity() = False Then GoTo errH
                MsgBox("Done")
            End If
        End With
        gAllowBackDateEntry = False
        'btnUpdateTag.Enabled = False
        'cboTag1.Enabled = False
        'cboTag2.Enabled = False
        resetTheForm()
        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)
        gAllowBackDateEntry = False
    End Sub

    Private Sub cboExpenseType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboExpenseType.SelectedIndexChanged

    End Sub

    Private Sub btnUpdatePayment_Click(sender As Object, e As EventArgs) Handles btnUpdatePayment.Click
        On Error GoTo errH

        Dim thisJournal As New clsJournal_Cult
        With thisJournal
            .gid = mGID
            .Narration = txtNarration.Text
            .TxnDate = dtpPaymentDate.Text
            .SupervisorName = cboApprovers.Text
            .Tag1 = cboTag1.Text
            .Tag2 = cboTag2.Text
            .UpdateJournalForPayment()

            gItemAction = "Update"
            If .Status = True Then
                gItemID = cboVoucherNo.Text
                If logUserActivity() = False Then GoTo errH
                MsgBox("Done")
            End If


            eMailApprover("NOTIFY-UPDATE")
        End With

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)

    End Sub

    Private Sub btnChangeDebitSide_Click(sender As Object, e As EventArgs) Handles btnChangeDebitSide.Click
        On Error GoTo errH
        Dim ri As Integer, ci As Integer

        If dgvJournal_b.Rows.Count = 0 Then Exit Sub

        ri = dgvJournal_b.CurrentCell.RowIndex
        If ri < 0 Then Exit Sub
        'If dgvJournal_b.CurrentRow.Index < 0 Then Exit Sub
        If MsgBox("This will set the screen for changing the expense classification (Debit Account) for transaction listed at row : " & (ri + 1) & " . Proceed?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub


        mTblID = ""

        'Populatr screen fields from grid
        With dgvJournal_b
            mTblID = .Rows(ri).Cells("tblid_b").Value
            'txtNarration.Text = .Rows(ri).Cells("Narration_b").Value
            'txtPaymentAmount.Text = .Rows(ri).Cells("DrAmount_b").Value
            'cboExpenseType.Text = getPaymentTypeFromTxnType(.Rows(ri).Cells("TxnType_b").Value, .Rows(ri).Cells("DrAccountNo_b").Value)

        End With

        cboDebitAccount.DropDownStyle = ComboBoxStyle.DropDownList
        cboDebitAccount.Items.Clear()
        loadDebitCombo()
        cboDebitAccount.Enabled = True

        btnSave.Enabled = False
        btnChangeDebitSide.Enabled = False
        btnUpdateDebitSide.Enabled = True

        txtPaymentAmount.Enabled = False
        dtpPaymentDate.Enabled = False
        txtNarration.Enabled = False
        cboPaymentMode.Enabled = False

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        myMsgBox(gErrMsg)
        gErrMsg = ""
    End Sub
    Private Sub btnUpdateDebitSide_Click(sender As Object, e As EventArgs) Handles btnUpdateDebitSide.Click
        On Error GoTo errH

        ssql = "Update tbljournal_cult set "
        'ssql = ssql & " TxnType='" & getTxnTypeFromPaymentType(cboExpenseType.Text) & "'"
        ssql = ssql & " AccountNo='" & cboDebitAccount.Text & "'"
        ssql = ssql & " where tblid=" & mTblID
        gcon.Execute(ssql)

        MsgBox("Done")

        txtNarration.Text = ""
        txtPaymentAmount.Text = ""

        btnSave.Enabled = True
        btnChangeDebitSide.Enabled = True
        btnUpdateDebitSide.Enabled = False

        txtPaymentAmount.Enabled = True
        dtpPaymentDate.Enabled = True
        txtNarration.Enabled = True
        cboPaymentMode.Enabled = True

        btnQueryExpense.PerformClick()

        Exit Sub
errH:
        gErrMsg = gErrMsg & " " & Err.Description
        myMsgBox(gErrMsg)
        gErrMsg = ""

    End Sub

End Class
