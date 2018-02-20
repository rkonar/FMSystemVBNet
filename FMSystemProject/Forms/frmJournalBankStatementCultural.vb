Public Class frmJournalBankStatementCultural

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim tmpRS As ADODB.Recordset

        If DateTime.Parse(dtpTxnDate.Text) > DateTime.Now.Date Then
            MsgBox("Payment date can't be future date")
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

        If cboTxnType.Text = "CHEQUE-2-BANK" Then
            ssql = "select tblid from tbljournal_cult where Status is null and DocRef like '%Cheque No:" & stripLeadingZero(txtInstrumentNo.Text) & ",%' and TxnDate='" & DateTime.Parse(dtpTxnDate.Text).ToString(DB_DATEFORMAT) & "'"
            tmpRS = gcon.Execute(ssql)

            If tmpRS.EOF = False Then
                gUserResponse = MsgBox("Similar entry with same cheque no has already been entered into system on " & dtpTxnDate.Text & ". Still you want to Save?", MsgBoxStyle.YesNo, "Possible duplicate entry!!!")
                If gUserResponse = vbNo Then Exit Sub
            End If

            If (txtInstrumentNo.Text = "") Then
                MsgBox("Provide Cheque no.")
                Exit Sub
            End If

        ElseIf cboTxnType.Text = "NEFT-2-BANK" Then
            ssql = "select tblid from tbljournal_cult where Status is null and DocRef like '%NEFT Ref:" & stripLeadingZero(txtInstrumentNo.Text) & "%' and TxnDate='" & DateTime.Parse(dtpTxnDate.Text).ToString(DB_DATEFORMAT) & "'"
            tmpRS = gcon.Execute(ssql)

            If tmpRS.EOF = False Then
                gUserResponse = MsgBox("Similar NEFT Txn has already been entered into system on " & dtpTxnDate.Text & ". Still you want to Save?", MsgBoxStyle.YesNo, "Possible duplicate entry!!!")
                If gUserResponse = vbNo Then Exit Sub
            End If
            If (txtInstrumentNo.Text = "") Then
                MsgBox("Provide NEFT ref. no.")
                Exit Sub
            End If

        ElseIf cboTxnType.Text = "BANK-2-DD" Then
            If (txtInstrumentNo.Text = "") Then
                MsgBox("Provide Cheque no.")
                Exit Sub
            End If
        Else

            If Trim(txtNarration.Text) = "" Then
                MsgBox("Enter remarks")
                Exit Sub
            End If
        End If

        JournalPayment()

        lblDrBalance.Text = addThousandSeparator(getAccountBalance_cult(dtpTxnDate.Text, cboDebitAccount.Text), False)
        lblCrBalance.Text = addThousandSeparator(getAccountBalance_cult(dtpTxnDate.Text, cboCreditAccount.Text), False)
        frmMain.sslabel3.Text = "Success"

        txtTxnAmount.Text = ""
        txtInstrumentNo.Text = ""
        txtNarration.Text = ""

        PopulateJournal_b()

        txtInstrumentNo.Focus()
    End Sub



    Sub JournalPayment()
        On Error GoTo errH

        Dim tmpStr As String

        'Journalise Payment
        Dim thisJournal As New clsJournal_Cult
        With thisJournal
            .Narration = txtNarration.Text
            .DocRef = cboTxnType.Text & ",as per bank statement"
            If cboTxnType.Text = "CHEQUE-2-BANK" Then
                .DocRef = .DocRef & ",Cheque No:" & stripLeadingZero(txtInstrumentNo.Text)
                .DocRef = .DocRef & "," & txtNarration.Text
                .Narration = "Not reconciled yet"
                .VoucherType = "RV"
            ElseIf (cboTxnType.Text = "BANK-2-CHEQUE") Then
                .DocRef = .DocRef & ",Cheque No:" & stripLeadingZero(txtInstrumentNo.Text)
                .DocRef = .DocRef & "," & txtNarration.Text
                .Narration = "Not reconciled yet"
                .VoucherType = "PV"
            ElseIf cboTxnType.Text = "NEFT-2-BANK" Then
                .DocRef = .DocRef & ",NEFT Ref:" & stripLeadingZero(txtInstrumentNo.Text)
                '.DocRef = .DocRef & "," & txtNarration.Text
                .Narration = "Not reconciled yet"
                .VoucherType = "RV"
            ElseIf (cboTxnType.Text = "BANK-2-CASH") Then
                .DocRef = .DocRef & ",Yourself withdrawal"
                .VoucherType = "CV"
            ElseIf cboTxnType.Text = "CASH-2-BANK" Then
                .DocRef = .DocRef & ",By Cash"
                .VoucherType = "CV"


                'ElseIf cboTxnType.Text = "DD-2-BANK" Then
                '    .DocRef = .DocRef & ",By DD/PO"
                'ElseIf cboTxnType.Text = "BANK-2-DD" Then
                '    .DocRef = .DocRef & ",Cheque No:" & stripLeadingZero(txtInstrumentNo.Text)


            ElseIf cboTxnType.Text = "INTEREST-4M-BANK" Then
                .DocRef = .DocRef & ",Bank Interest"
                .VoucherType = "RV"
            End If

            .DrAccountNo = cboDebitAccount.Text
            .CrAccountNo = cboCreditAccount.Text
            .Amount = txtTxnAmount.Text
            .TxnDate = dtpTxnDate.Text
            .TxnType = cboTxnType.Text
            gcon.BeginTrans()
            .CreateTransaction()

            If .Status = False Then GoTo errH
            gcon.CommitTrans()

            gItemAction = "Create"
            gItemID = .DocRef
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
        dtpInstrumentDate.Enabled = False
        txtInstrumentNo.Enabled = False

        dtpInstrumentDate.Text = ""
        txtInstrumentNo.Text = ""

        txtTxnAmount.Text = ""
        txtNarration.Text = ""
        cboDebitAccount.Text = ""
        cboCreditAccount.Text = ""
        cboDebitAccount.Items.Clear()
        cboCreditAccount.Items.Clear()
        cboDebitAccount.SelectedIndex = -1
        cboCreditAccount.SelectedIndex = -1

        txtCreditActDesc.Text = ""
        txtDebitActDesc.Text = ""

        cboTxnType.Items.Clear()
        cboTxnType.Items.Add("CHEQUE-2-BANK")
        cboTxnType.Items.Add("NEFT-2-BANK")
        cboTxnType.Items.Add("CASH-2-BANK")
        'cboTxnType.Items.Add("DD-2-BANK")
        cboTxnType.Items.Add("BANK-2-BANK")
        'cboTxnType.Items.Add("CASH-2-DD")
        'cboTxnType.Items.Add("BANK-2-DD")
        cboTxnType.Items.Add("BANK-2-CASH")
        cboTxnType.Items.Add("BANK-2-CHEQUE")
        cboTxnType.Items.Add("INTEREST-4M-BANK")


        'cboTxnType.Items.Add("ONLINE PAYMENTS")

        cboTxnType.SelectedIndex = -1

    End Sub


    Sub loadBankInterestAccounts()
        Dim expActRS As ADODB.Recordset

        cboCreditAccount.Items.Clear()
        ssql = "select AccountNo from tblaccounts where Status='A' and AccountType='Revenues' and LeafAccount='Y' and ParentAccountNo = 'REV-CULT-BANK-INTEREST'"
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

        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Assets' and ParentAccountNo = 'CASH-AT-BANK-CULT'"
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

    Sub loadChequeIssuedCultAccounts()
        Dim expActRS As ADODB.Recordset

        cboDebitAccount.Items.Clear()
        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Liabilities' and ParentAccountNo = 'CHEQUE-ISSUED-ALL-CULT'"
        expActRS = gcon.Execute(ssql)

        While expActRS.EOF = False
            cboDebitAccount.Items.Add(expActRS("AccountNo").Value.ToString)
            expActRS.MoveNext()
        End While
        expActRS.Close()
    End Sub

    Private Sub btnAddNewAccount_Click(sender As System.Object, e As System.EventArgs) Handles btnAddNewAccount.Click
        frmCOA.ShowDialog()
        frmCOA.Dispose()
    End Sub

    Private Sub btnOpenBillReceiptScreen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenBillReceiptScreen.Click
        'standard entry check code start
        gOldItemCode = gItemCode
        gItemCode = "frmBookReceiptCultural"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = gOldItemCode
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end
        gCurFlatCode = ""
        frmBookReceiptCultural.ShowDialog()
        frmBookReceiptCultural.Dispose()
        gItemCode = gOldItemCode
        gCurFlatCode = ""
    End Sub


    Private Sub cboDebitAccount_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboDebitAccount.SelectedValueChanged
        txtDebitActDesc.Text = getAccountName(cboDebitAccount.Text)
        lblDrBalance.Text = addThousandSeparator(getAccountBalance_cult(dtpTxnDate.Text, cboDebitAccount.Text), False)
        btnQueryTxn.PerformClick()
    End Sub


    Private Sub cboCreditAccount_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboCreditAccount.SelectedValueChanged
        txtCreditActDesc.Text = getAccountName(cboCreditAccount.Text)
        lblCrBalance.Text = addThousandSeparator(getAccountBalance_cult(dtpTxnDate.Text, cboCreditAccount.Text), False)
        btnQueryTxn.PerformClick()
    End Sub


    Private Sub frmJournalBankStatementCultural_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        resetFields()
    End Sub



    Sub PopulateJournal_b()
        On Error GoTo errH
        Dim i As Long, netDrAmt As Double, netCrAmt As Double, rsJournal As ADODB.Recordset, journalQuerySQL As String

        netDrAmt = 0
        netCrAmt = 0

        dgvJournal_b.Rows.Clear()

        If myLeft(cboTxnType.Text, 7) = "BANK-2-" Then
            journalQuerySQL = "select * from tbljournal_cult where DrAmount=0 "
            If cboCreditAccount.Text <> "" Then
                journalQuerySQL = journalQuerySQL & " and AccountNo='" & cboCreditAccount.Text & "'"
            End If
        Else
            journalQuerySQL = "select * from tbljournal_cult where CrAmount=0 "
            If cboDebitAccount.Text <> "" Then
                journalQuerySQL = journalQuerySQL & " and AccountNo='" & cboDebitAccount.Text & "'"
            End If
        End If

        journalQuerySQL = journalQuerySQL & " and TxnDate='" & DateTime.Parse(dtpTxnDate.Text).ToString(DB_DATEFORMAT) & "'"
        journalQuerySQL = journalQuerySQL & " and TxnType='" & cboTxnType.Text & "'"
        'journalQuerySQL = journalQuerySQL & " and status is null"
        journalQuerySQL = journalQuerySQL & " order by tblid desc"
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

    Private Sub btnQueryChequeNeftTxn_Click(sender As System.Object, e As System.EventArgs) Handles btnQueryTxn.Click
        PopulateJournal_b()
    End Sub

    Private Sub cboTxnType_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboTxnType.SelectedValueChanged
        txtInstrumentNo.Enabled = False

        lblRemarks.Text = "Bank comments"
        txtNarration.Text = ""
        txtNarration.Enabled = True

        Select Case cboTxnType.Text

            Case "CHEQUE-2-BANK"
                loadBankAccounts("DR")
                cboCreditAccount.Items.Add("CHEQUE-IN-HAND-CULT")
                cboCreditAccount.Text = "CHEQUE-IN-HAND-CULT"
                cboDebitAccount.Enabled = True
                cboCreditAccount.Enabled = False
                lblInstrumentNo.Text = "Cheque No"
                txtInstrumentNo.Enabled = True

                lblTxnType.Text = "Cheque deposited into our bank account"

            Case "BANK-2-CHEQUE"
                loadChequeIssuedCultAccounts()
                'cboDebitAccount.Items.Add("CHEQUE-ISSUED")
                'cboDebitAccount.Text = "CHEQUE-ISSUED"

                loadBankAccounts("CR")
                cboDebitAccount.Enabled = True
                cboCreditAccount.Enabled = True
                lblInstrumentNo.Text = "Cheque No"
                txtInstrumentNo.Enabled = True

                lblTxnType.Text = "We paid from our bank account through cheque"

            Case "NEFT-2-BANK"
                loadBankAccounts("DR")
                cboCreditAccount.Items.Add("NEFT-NOT-RECONCILED-CULT")
                cboCreditAccount.Text = "NEFT-NOT-RECONCILED-CULT"
                cboDebitAccount.Enabled = True
                cboCreditAccount.Enabled = False
                lblInstrumentNo.Text = "NEFT Ref"
                txtInstrumentNo.Enabled = True
                txtNarration.Enabled = False

                lblTxnType.Text = "NEFT transfer into our bank account"

            Case "BANK-2-CASH"
                cboDebitAccount.Items.Add("CASHBOX-CULT")
                cboDebitAccount.Text = "CASHBOX-CULT"
                loadBankAccounts("CR")
                cboDebitAccount.Enabled = False
                cboCreditAccount.Enabled = True
                txtInstrumentNo.Enabled = True

                lblTxnType.Text = "Cash withdrawal from our bank account"


            Case "CASH-2-BANK"
                loadBankAccounts("DR")
                cboCreditAccount.Items.Add("CASHBOX-CULT")
                cboCreditAccount.Text = "CASHBOX-CULT"
                cboDebitAccount.Enabled = True
                cboCreditAccount.Enabled = False

                lblTxnType.Text = "Cash deposit into our bank account"

            Case "DD-2-BANK"
                loadBankAccounts("DR")
                cboCreditAccount.Items.Add("DD-CULT")
                cboCreditAccount.Text = "DD-CULT"
                cboDebitAccount.Enabled = True
                cboCreditAccount.Enabled = False

                lblTxnType.Text = "Demand Draft/Pay Order deposited into our bank account"

            Case "BANK-2-DD"
                cboDebitAccount.Items.Add("DD-CULT")
                cboDebitAccount.Text = "DD-CULT"
                loadBankAccounts("CR")
                cboDebitAccount.Enabled = False
                cboCreditAccount.Enabled = True
                txtInstrumentNo.Enabled = True
                lblInstrumentNo.Text = "Cheque No"

                lblTxnType.Text = "We created demand draft/pay order from our bank account through cheque"

            Case "CASH-2-DD"
                cboDebitAccount.Items.Add("DD-CULT")
                cboDebitAccount.Text = "DD-CULT"
                cboCreditAccount.Items.Add("CASHBOX-CULT")
                cboCreditAccount.Text = "CASHBOX-CULT"
                cboDebitAccount.Enabled = False
                cboCreditAccount.Enabled = False

                lblTxnType.Text = "We created demand draft/pay order through cash"

            Case "BANK-2-BANK"
                loadBankAccounts("BOTH")
                cboDebitAccount.Enabled = True
                cboCreditAccount.Enabled = True

                lblTxnType.Text = "We transferred from one of our bank account to another account"

            Case "INTEREST-4M-BANK"
                loadBankAccounts("DR")
                loadBankInterestAccounts()
                'cboCreditAccount.Items.Add("REV-BANK-INTEREST")
                'cboCreditAccount.Text = "REV-BANK-INTEREST"
                cboDebitAccount.Enabled = True
                cboCreditAccount.Enabled = True

                lblTxnType.Text = "Bank Interest credited into our bank account"

            Case Else


        End Select

        lblDrBalance.Text = addThousandSeparator(getAccountBalance_cult(dtpTxnDate.Text, cboDebitAccount.Text), False)
        lblCrBalance.Text = addThousandSeparator(getAccountBalance_cult(dtpTxnDate.Text, cboCreditAccount.Text), False)
        txtCreditActDesc.Text = getAccountName(cboCreditAccount.Text)
        txtDebitActDesc.Text = getAccountName(cboDebitAccount.Text)

        btnQueryTxn.PerformClick()
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
        btnQueryTxn.PerformClick()
    End Sub


    Private Sub btnAddBankCharge_Click(sender As Object, e As EventArgs) Handles btnAddBankCharge.Click
        gAllowBankChargeEntryOnly = True
        frmManagePaymentCultural.ShowDialog()
        frmManagePaymentCultural.Dispose()
        gAllowBankChargeEntryOnly = False
    End Sub

    
    Private Sub cboTxnType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTxnType.SelectedIndexChanged

    End Sub
End Class
