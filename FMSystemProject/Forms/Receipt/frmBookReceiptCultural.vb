Public Class frmBookReceiptCultural
    Dim NetDrAmt As Double, NetCrAmt As Double, formLoadComplete As Boolean
    Dim lFinYear As New clsFinYear

    Sub loadAvailableReceipts()
        cboReceiptNo.Items.Clear()
        tmpRS = gcon.Execute("select ReceiptNo from tblreceiptbook_cult where Status='A' order by tblid Asc")
        While tmpRS.EOF = False
            cboReceiptNo.Items.Add(tmpRS("ReceiptNo").Value.ToString)
            tmpRS.MoveNext()
        End While
    End Sub

    Private Sub frmBookReceiptCultural_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        formLoadComplete = False
        gItemCode = "Receipts-Cultural"

        Dim tmpFlatCode As String
        If gCurFlatCode <> "" Then
            tmpFlatCode = gCurFlatCode
            cboFlatCode.Items.Add(gCurFlatCode)
            optCultCollection_NonFlatOwner.Enabled = False
            btnSave.Enabled = False
        Else
            tmpFlatCode = ""
            cboFlatCode.DataSource = FLATS
            cboFlatCode.SelectedIndex = 0
        End If

        cboInstrumentType.Items.AddRange(INSTRUMENT_TYPES)

        'txtNarration.Text = "Payment towards subscription for " ') & myLeft(gCurFlatCode, 3)

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
        ssql = "select InstrumentNo from tblreceipt_cult where InstrumentType='CHEQUE' and InstrumentReconciled is null order by InstrumentNo"
        expActRS = gcon.Execute(ssql)

        While expActRS.EOF = False
            cboChequeNo.Items.Add(expActRS("InstrumentNo").Value.ToString)
            expActRS.MoveNext()
        End While
    End Sub

    Sub PopulateJournalPaidOthers()
        On Error GoTo errH
        Dim i As Long, netAmt As Double, myReceipt As New clsReceipt_Cult, myDocRef As New clsDocRef, rcpt_no As String

        NetCrAmt = 0
        dgvJournalPaid.Rows.Clear()

        Dim tmpTxnType As String, tmpAccountNo As String, tmpSql1 As String, tmpsqlDup As String

        If optCultCollection_FlatOwner.Checked = True Then
            If optSubscription.Checked = True Then
                tmpSql1 = "select * from tbljournal_cult where DrAmount = 0 and (TxnType='CULT-RECEIPT-OWNER') and AccountNo = 'REV-CULT-SUBSCRIPTION-OWNER-" & cboFlatCode.Text & "' "
            ElseIf optOthers.Checked = True Then
                tmpSql1 = "select * from tbljournal_cult where DrAmount = 0 and (TxnType='CULT-RECEIPT-OWNER') and AccountNo like 'REV-CULT-OTHERS-OWNER-" & cboFlatCode.Text & "' "
            End If
        ElseIf optCultCollection_NonFlatOwner.Checked = True Then
            If optSubscription.Checked = True Then
                tmpSql1 = "select * from tbljournal_cult where DrAmount = 0 and (TxnType='CULT-RECEIPT-NONOWNER') and AccountNo = 'REV-CULT-SUBSCRIPTION-NONOWNER'"
            ElseIf optOthers.Checked = True Then
                tmpSql1 = "select * from tbljournal_cult where DrAmount = 0 and (TxnType='CULT-RECEIPT-NONOWNER') and AccountNo = 'REV-CULT-OTHERS-NONOWNER'"
            End If
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
        'ssql = "select * from tbljournal_cult where DrAmount = 0 and AccountNo='DEBTOR-FLAT-" & cboFlatCode.Text & "' order by TxnDate"
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
            'ssql = "select * from tbljournal_cult where DrAmount = 0 and AccountNo='DEBTOR-FLAT-" & txtDuplexFlatCode.Text & "' order by TxnDate"
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

        Dim thisJournal As New clsJournal_Cult

        With thisJournal
            If cboInstrumentType.Text = "CASH" Then
                .DocRef = "(Receipt No:" & rcpt_no & ", Payment Mode:CASH, Payee:" & cboFlatCode.Text & ")"
                .DrAccountNo = "CASHBOX-CULT"
                .TxnDate = dtpReceiptDate.Text
                .refgid = "-"
                .VoucherType = "RV"
            ElseIf cboInstrumentType.Text = "CHEQUE" Then
                .DocRef = "(Receipt No:" & rcpt_no & ", Cheque No:" & stripLeadingZero(txtInstrumentNo.Text) & ", Cheque Date:" & dtpInstrumentDate.Text & ", Payee:" & cboFlatCode.Text & ")"
                .DrAccountNo = "CHEQUE-IN-HAND-CULT"
                .TxnDate = dtpReceiptDate.Text
                .refgid = ""
                .VoucherType = "JV"
            ElseIf cboInstrumentType.Text = "ONLINE" Then
                .DocRef = "(Receipt No:" & rcpt_no & ", Online Transfer Ref:" & stripLeadingZero(txtInstrumentNo.Text) & ", Transfer Date:" & dtpInstrumentDate.Text & ", Payee:" & cboFlatCode.Text & ")"
                .DrAccountNo = "NEFT-NOT-RECONCILED-CULT" 'cboDebitAccount.Text
                .TxnDate = dtpInstrumentDate.Text
                .refgid = ""
                .VoucherType = "JV"
            End If


            .Amount = txtReceiptAmount.Text
            .Narration = txtNarration.Text

            If optSubscription.Checked = True Then
                If optCultCollection_FlatOwner.Checked = True Then
                    .CrAccountNo = "REV-CULT-SUBSCRIPTION-OWNER-" & gCurFlatCode
                ElseIf optCultCollection_NonFlatOwner.Checked = True Then
                    .CrAccountNo = "REV-CULT-SUBSCRIPTION-NONOWNER"
                End If
            ElseIf optOthers.Checked = True Then
                If optCultCollection_FlatOwner.Checked = True Then
                    .CrAccountNo = "REV-CULT-OTHERS-OWNER-" & gCurFlatCode
                ElseIf optCultCollection_NonFlatOwner.Checked = True Then
                    .CrAccountNo = "REV-CULT-OTHERS-NONOWNER"
                End If
            End If
            If optCultCollection_FlatOwner.Checked = True Then
                .TxnType = "CULT-RECEIPT-OWNER"
            ElseIf optCultCollection_NonFlatOwner.Checked = True Then
                .TxnType = "CULT-RECEIPT-NONOWNER"
            End If

            .CreateTransaction()

            If .Status = False Then GoTo errH

            gid = .gid

        End With

        'Create entry in tblreceipt_cult

        Dim thisReceipt As New clsReceipt_Cult

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

        If optCultCollection_FlatOwner.Checked = True Then
            Dim mySMS As New clsSendSMS_Cult
            mySMS.msgID = rcpt_no
            If mySMS.sendSMS4Receipt(rcpt_no) = True Then MsgBox("SMS sent successfully")
        End If

        refreshForm(True)
        'optMaintBillCollection.Checked = True


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
        If optCultCollection_NonFlatOwner.Checked = True Then
            cboFlatCode.DataSource = MISC_PAYEE_CULT
        Else
            cboFlatCode.DataSource = FLATS
        End If
        cboFlatCode.Text = tmpCode

        loadAvailableReceipts()
        PopulateJournalPaidOthers()

        If includeReceipts = True Then
            cboBankName.Text = ""
            txtInstrumentNo.Text = ""
            'txtNarration.Text = "Maintenance service charge payment (Bill No:"
            txtReceiptAmount.Text = ""
            cboReceiptNo.SelectedIndex = -1
            cboInstrumentType.SelectedIndex = -1
        End If

        getBankNames_Cult()
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

        If optCultCollection_NonFlatOwner.Checked = True Then
            If IsNumeric(Mid(cboFlatCode.Text, 4, 2)) = True Then
                MsgBox("Invalid Flat Code for non owner")
                Exit Function
            End If
        Else
            If IsNumeric(Mid(cboFlatCode.Text, 4, 2)) = False Then
                MsgBox("Invalid Flat Code for owner")
                Exit Function
            End If
        End If


        ssql = "select * from tblreceipt_cult where ReceiptNo='" & Trim(cboReceiptNo.Text) & "'"
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

    Private Sub dtpReceiptDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpReceiptDate.ValueChanged
        dtpInstrumentDate.Text = dtpReceiptDate.Text
    End Sub

    Sub loadDefaultNarration()

        If optCultCollection_FlatOwner.Checked = True Then
            If optSubscription.Checked = True Then
                txtNarration.Text = "Payment received towards subscription from Payee:" & cboFlatCode.Text & " for "
            ElseIf optOthers.Checked = True Then
                txtNarration.Text = "Payment received from Payee:" & cboFlatCode.Text & " for "
            End If
        ElseIf optCultCollection_NonFlatOwner.Checked = True Then
            If optSubscription.Checked = True Then
                txtNarration.Text = "Payment received towards subscription from Payee:"
            ElseIf optOthers.Checked = True Then
                txtNarration.Text = "Payment received from:"
            End If
        Else
            Exit Sub
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

        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Assets' and ParentAccountNo = 'CASH-AT-BANK-CULT'"
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
        Dim myDocRef As New clsDocRef, thisDocRef As String, thisReceiptAmt As String, thisMailId As String, tmpStr As String, myReceipt As New clsReceipt_Cult

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
        gItemCode = "frmViewReceiptCultural"
        frmViewReceiptCultural.ShowDialog()
        frmViewReceiptCultural.Dispose()
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


    Private Sub optCultCollection_FlatOwner_CheckedChanged(sender As Object, e As EventArgs) Handles optCultCollection_FlatOwner.CheckedChanged
        If optCultCollection_FlatOwner.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CASH"
    End Sub

    Private Sub optCultCollection_NonFlatOwner_CheckedChanged(sender As Object, e As EventArgs) Handles optCultCollection_NonFlatOwner.CheckedChanged
        If optCultCollection_NonFlatOwner.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CASH"
        'cboFlatCode.SelectedIndex = cboFlatCode.Items.Count - 1
    End Sub


    Private Sub tsmiSMSReceipt_Click(sender As Object, e As EventArgs) Handles tsmiSMSReceipt.Click
        Dim thisDocRef As String, tmpTxnType As String, myDocRef As New clsDocRef

        tmpTxnType = dgvJournalPaid.Rows(dgvJournalPaid.CurrentRow.Index).Cells(1).Value
        If tmpTxnType = "CULT-RECEIPT-NONOWNER" Then
            MsgBox("SMS facility is not available for receipts issued to non flat owners")
            Exit Sub
        End If
        thisDocRef = dgvJournalPaid.Rows(dgvJournalPaid.CurrentRow.Index).Cells(3).Value
        gCurReceiptNo = myDocRef.getReceiptNo(thisDocRef)

        Dim mySMS As New clsSendSMS_Cult
        mySMS.msgID = gCurReceiptNo
        If mySMS.sendSMS4Receipt(gCurReceiptNo) = True Then MsgBox("SMS sent successfully")

    End Sub

    Private Sub optSubscription_CheckedChanged(sender As Object, e As EventArgs) Handles optSubscription.CheckedChanged
        If optSubscription.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CASH"
    End Sub

    Private Sub optOthers_CheckedChanged(sender As Object, e As EventArgs) Handles optOthers.CheckedChanged
        If optOthers.Checked = False Then Exit Sub

        refreshForm(True)
        cboInstrumentType.Text = "CASH"
    End Sub

   
End Class