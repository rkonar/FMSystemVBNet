Public Class frmBankReconcile
    Dim journalQuerySQL As String


    Sub PopulateJournal_b() 'FROM BANK
        On Error GoTo errH
        Dim i As Long, netDrAmt As Double, netCrAmt As Double, rsJournal As ADODB.Recordset

        netDrAmt = 0
        netCrAmt = 0

        dgvJournal_b.Rows.Clear()

        '1st part
        'journalQuerySQL = "select * from tbljournal where status is null"
        journalQuerySQL = "select * from tbljournal where 1=1"

        '2nd part
        If chkShowOnlyUnReconciled.Checked = True Then
            journalQuerySQL = journalQuerySQL & " and refgid is null"
        End If
        If optIncludeCheque.Checked = True Then
            journalQuerySQL = journalQuerySQL & " and DocRef like '%Cheque No%'"
        ElseIf optIncludeNeft.Checked = True Then
            journalQuerySQL = journalQuerySQL & " and DocRef like '%NEFT-2-BANK%'"
        ElseIf optIncludeAll.Checked = True Then
            'do nothing
        End If
        journalQuerySQL = journalQuerySQL & " and TxnDate >='" & DateTime.Parse(dtpFromDate.Text).ToString(DB_DATEFORMAT) & "'"
        journalQuerySQL = journalQuerySQL & " and TxnDate <='" & DateTime.Parse(dtpToDate.Text).ToString(DB_DATEFORMAT) & "'"

        '3rd part
        If optDeposit.Checked = True Then
            journalQuerySQL = journalQuerySQL & " and CrAmount=0 and DrAmount>0 and (TxnType='CHEQUE-2-BANK' OR TxnType='NEFT-2-BANK') "
            If txtFromAmount.Text <> "" Then
                journalQuerySQL = journalQuerySQL & " and ((DrAmount >=" & txtFromAmount.Text & " and CrAmount=0) OR (CrAmount >=" & txtFromAmount.Text & " and DrAmount=0))"
            End If
            If txtToAmount.Text <> "" Then
                journalQuerySQL = journalQuerySQL & " and ((DrAmount <=" & txtToAmount.Text & " and CrAmount=0) OR (CrAmount <=" & txtToAmount.Text & " and DrAmount=0))"
            End If
            If chkSortOnAmount.Checked = True Then
                journalQuerySQL = journalQuerySQL & " order by DrAmount desc"
            Else
                journalQuerySQL = journalQuerySQL & " order by TxnDate desc"
            End If
        ElseIf optWithdrawal.Checked = True Then
            journalQuerySQL = journalQuerySQL & " and DrAmount=0 and CrAmount>0 and (TxnType='BANK-2-CHEQUE') "
            If txtFromAmount.Text <> "" Then
                journalQuerySQL = journalQuerySQL & " and ((CrAmount >=" & txtFromAmount.Text & " and DrAmount=0) OR (DrAmount >=" & txtFromAmount.Text & " and CrAmount=0))"
            End If
            If txtToAmount.Text <> "" Then
                journalQuerySQL = journalQuerySQL & " and ((CrAmount <=" & txtToAmount.Text & " and DrAmount=0) OR (DrAmount <=" & txtToAmount.Text & " and CrAmount=0))"
            End If
            If chkSortOnAmount.Checked = True Then
                journalQuerySQL = journalQuerySQL & " order by CrAmount desc"
            Else
                journalQuerySQL = journalQuerySQL & " order by TxnDate desc"
            End If
        End If


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
                .Rows(i).Cells("DrAmount_b").Value = addThousandSeparator(rsJournal("DrAmount").Value.ToString)
                .Rows(i).Cells("CrAmount_b").Value = addThousandSeparator(rsJournal("CrAmount").Value.ToString)

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

            If optDeposit.Checked = True Then
                lblBalance_b.Text = "Rs. " & addThousandSeparator(netDrAmt)
            ElseIf optWithdrawal.Checked = True Then
                lblBalance_b.Text = "Rs. " & addThousandSeparator(netCrAmt)
            End If

            lblCnt_b.Text = "Txn Cnt: " & dgvJournal_b.Rows.Count

        End With

        rsJournal.Close()

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Sub PopulateJournal_a() 'FROM SYSTEM
        On Error GoTo errH
        Dim i As Long, netDrAmt As Double, netCrAmt As Double, rsJournal As ADODB.Recordset

        netDrAmt = 0
        netCrAmt = 0

        dgvJournal_a.Rows.Clear()

        '1st part
        'journalQuerySQL = "select * from tbljournal where AccountNo <> 'CASHBOX' and status is null and TxnType <> 'RECEIPT-BGF' "  'Exclude Earth Movers & Builders Pvt. Ltd. Receipts
        journalQuerySQL = "select * from tbljournal where AccountNo <> 'CASHBOX' and TxnType <> 'RECEIPT-BGF' "  'Exclude Earth Movers & Builders Pvt. Ltd. Receipts
        journalQuerySQL = journalQuerySQL & " and status is null "
        '2nd part
        If chkShowOnlyUnReconciled.Checked = True Then
            journalQuerySQL = journalQuerySQL & " and refgid is null"
        End If
        If optIncludeCheque.Checked = True Then
            journalQuerySQL = journalQuerySQL & " and DocRef like '%Cheque No%'"
        ElseIf optIncludeNeft.Checked = True Then
            journalQuerySQL = journalQuerySQL & " and DocRef like '%Online Transfer Ref%'"
        ElseIf optIncludeAll.Checked = True Then
            'do nothing
        End If
        journalQuerySQL = journalQuerySQL & " and TxnDate >='" & DateTime.Parse(dtpFromDate.Text).ToString(DB_DATEFORMAT) & "'"
        journalQuerySQL = journalQuerySQL & " and TxnDate <='" & DateTime.Parse(dtpToDate.Text).ToString(DB_DATEFORMAT) & "'"

        '3rd part
        If optDeposit.Checked = True Then
            'journalQuerySQL = journalQuerySQL & " and CrAmount=0 and (TxnType='RECEIPT' OR TxnType='MISC-RECEIPT' or TxnType='COMMUNITY-HALL-BOOKING') "
            journalQuerySQL = journalQuerySQL & " and CrAmount=0 and (AccountNo='CHEQUE-IN-HAND' OR AccountNo='NEFT-NOT-RECONCILED' OR AccountNo='EXP-RETURN-UNKNOWN-PAYMENT') "
            If txtFromAmount.Text <> "" Then
                journalQuerySQL = journalQuerySQL & " and ((DrAmount >=" & txtFromAmount.Text & " and CrAmount=0) OR (CrAmount >=" & txtFromAmount.Text & " and DrAmount=0))"
            End If
            If txtToAmount.Text <> "" Then
                journalQuerySQL = journalQuerySQL & " and ((DrAmount <=" & txtToAmount.Text & " and CrAmount=0) OR (CrAmount <=" & txtToAmount.Text & " and DrAmount=0))"
            End If
            If chkSortOnAmount.Checked = True Then
                journalQuerySQL = journalQuerySQL & " order by DrAmount desc"
            Else
                journalQuerySQL = journalQuerySQL & " order by TxnDate desc"
            End If
        ElseIf optWithdrawal.Checked = True Then
            'journalQuerySQL = journalQuerySQL & " and DrAmount=0 and (TxnType='EXPENSE') "
            journalQuerySQL = journalQuerySQL & " and DrAmount=0 and (AccountNo like 'CHEQUE-ISSUED%') "
            journalQuerySQL = journalQuerySQL & " and DocRef like '%Cheque No%'"
            If txtFromAmount.Text <> "" Then
                journalQuerySQL = journalQuerySQL & " and ((CrAmount >=" & txtFromAmount.Text & " and DrAmount=0) OR (DrAmount >=" & txtFromAmount.Text & " and CrAmount=0))"
            End If
            If txtToAmount.Text <> "" Then
                journalQuerySQL = journalQuerySQL & " and ((CrAmount <=" & txtToAmount.Text & " and DrAmount=0) OR (DrAmount <=" & txtToAmount.Text & " and CrAmount=0))"
            End If
            If chkSortOnAmount.Checked = True Then
                journalQuerySQL = journalQuerySQL & " order by CrAmount desc"
            Else
                journalQuerySQL = journalQuerySQL & " order by TxnDate desc"
            End If
        End If


        rsJournal = gcon.Execute(journalQuerySQL)


        With dgvJournal_a

            While rsJournal.EOF = False

                i = .Rows.Add()
                .Rows(i).Cells("tblid_a").Value = rsJournal("tblid").Value.ToString
                .Rows(i).Cells("gid_a").Value = rsJournal("gid").Value.ToString
                .Rows(i).Cells("TxnType_a").Value = rsJournal("TxnType").Value.ToString
                .Rows(i).Cells("TxnDate_a").Value = formatInt2Date(rsJournal("TxnDate").Value.ToString)
                .Rows(i).Cells("Narration_a").Value = rsJournal("Narration").Value.ToString
                .Rows(i).Cells("DocRef_a").Value = rsJournal("DocRef").Value.ToString
                .Rows(i).Cells("AccountNo_a").Value = rsJournal("AccountNo").Value.ToString
                .Rows(i).Cells("DrAmount_a").Value = addThousandSeparator(rsJournal("DrAmount").Value.ToString)
                .Rows(i).Cells("CrAmount_a").Value = addThousandSeparator(rsJournal("CrAmount").Value.ToString)

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

            If optDeposit.Checked = True Then
                lblBalance_a.Text = "Rs. " & addThousandSeparator(netDrAmt)
            ElseIf optWithdrawal.Checked = True Then
                lblBalance_a.Text = "Rs. " & addThousandSeparator(netCrAmt)
            End If

            lblCnt_a.Text = "Txn Cnt: " & dgvJournal_a.Rows.Count
        End With

        rsJournal.Close()

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Sub RefreshForm()
        PopulateJournal_b() 'from bank statement
        PopulateJournal_a() 'from system 
        pbarProgress.Minimum = 0
        pbarProgress.Maximum = dgvJournal_a.Rows.Count
        pbarProgress.Value = 0

        dgvJournal_a.ClearSelection()
        dgvJournal_b.ClearSelection()

        txtChequeToFind.Text = ""
        txtBankName.Text = ""
    End Sub
    Sub setFormSize()
        Debug.Print(My.Computer.Screen.WorkingArea.Height)
        Debug.Print(My.Computer.Screen.Bounds.Width)
        Debug.Print(My.Computer.Screen.Bounds.Height)
        dgvJournal_a.Width = Math.Round((600 / SCREEN_BASE_WIDTH) * My.Computer.Screen.Bounds.Width)
        dgvJournal_a.Height = Math.Round((600 / SCREEN_BASE_HEIGHT) * My.Computer.Screen.Bounds.Height)
        dgvJournal_b.Width = Math.Round((600 / SCREEN_BASE_WIDTH) * My.Computer.Screen.Bounds.Width)
        dgvJournal_b.Height = Math.Round((600 / SCREEN_BASE_HEIGHT) * My.Computer.Screen.Bounds.Height)
    End Sub

    Private Sub frmBankReconcile_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'setFormSize()
        'dgvJournal_b.Height = My.Computer.Screen.WorkingArea.Height
        'RefreshForm
        If Month(DateTime.Now) < 4 Then
            dtpFromDate.Text = "01-Apr-" & Year(DateTime.Now) - 1
        Else
            dtpFromDate.Text = "01-Apr-" & Year(DateTime.Now)
        End If
        dtpToDate.Text = DateTime.Now.ToString(SCREEN_DATEFORMAT)
        'If gRoleCode = "CommitteeMember" Or gRoleCode = "SystemAdmin" Then
        If gLoginID = "sa" Then
            chkOneToManyReconcileFlag.Visible = True
        End If
    End Sub

    Private Sub btnAutoReconcile_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoReconcile.Click
        On Error GoTo errH
        Dim cnt As Integer = 0
        Dim r_a As Integer, r_b As Integer, amt_a As String, amt_b As String, narration_a As String, narration_b As String, myDocRef As New clsDocRef, dRef_a As String, dRef_b As String, chqNo_a As String, chqNo_b As String, gid_a As String, gid_b As String


        pbarProgress.Value = 0

        For r_a = dgvJournal_a.Rows.Count - 1 To 0 Step -1
            dRef_a = dgvJournal_a.Rows(r_a).Cells("DocRef_a").Value
            narration_a = dgvJournal_a.Rows(r_a).Cells("Narration_a").Value
            gid_a = dgvJournal_a.Rows(r_a).Cells("gid_a").Value
            amt_a = dgvJournal_a.Rows(r_a).Cells("DrAmount_a").Value
            chqNo_a = myDocRef.getChequeNo(dRef_a)

            For r_b = dgvJournal_b.Rows.Count - 1 To 0 Step -1
                dRef_b = dgvJournal_b.Rows(r_b).Cells("DocRef_b").Value
                narration_b = dgvJournal_b.Rows(r_b).Cells("Narration_b").Value
                gid_b = dgvJournal_b.Rows(r_b).Cells("gid_b").Value
                amt_b = dgvJournal_b.Rows(r_b).Cells("DrAmount_b").Value
                chqNo_b = myDocRef.getChequeNo(dRef_b)

                If (chqNo_a <> "") And (chqNo_a = chqNo_b) And (amt_a = amt_b) Then
                    gcon.BeginTrans()

                    'Link bank with journal
                    If optDeposit.Checked = True Then
                        ssql = "update tbljournal set refgid='" & gid_a & "', Narration='" & dRef_a & "' where gid='" & gid_b & "'"
                    ElseIf optWithdrawal.Checked = True Then
                        ssql = "update tbljournal set refgid='" & gid_a & "', Narration='" & narration_a & "' where gid='" & gid_b & "'"
                    End If
                    gcon.Execute(ssql)

                    'Link journal with bank
                    ssql = "update tbljournal set refgid='" & gid_b & "' where gid='" & gid_a & "'"
                    gcon.Execute(ssql)

                    'Link receipt with bank
                    ssql = "Update tblreceipt set refgid='" & gid_b & "' where gid='" & gid_a & "'"
                    gcon.Execute(ssql)

                    gcon.CommitTrans()

                    cnt += 1
                    Exit For
                End If

            Next
            pbarProgress.Value = pbarProgress.Value + 1
        Next

        MsgBox(cnt & " Transaction(s) reconciled")

        RefreshForm()

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)


    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        RefreshForm()
    End Sub

    Private Sub btnOpenJournalBankStatement_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenJournalBankStatement.Click
        'standard entry check code start
        gItemCode = "frmJournalBankStatement"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = "frmJournalBankStatement"
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end
        frmJournalBankStatement.ShowDialog()
        frmJournalBankStatement.Dispose()
        gItemCode = "frmBankReconcile"
    End Sub

    Private Sub btnManualReconcile_Click(sender As System.Object, e As System.EventArgs) Handles btnManualReconcile.Click
        On Error GoTo errH
        Dim cnt As Integer = 0, aSelCnt As Integer, bSelCnt As Integer, aIndx As Integer
        Dim r_a As Integer, r_b As Integer

        aSelCnt = dgvJournal_a.SelectedRows.Count
        bSelCnt = dgvJournal_b.SelectedRows.Count

        If bSelCnt <> 1 Then Exit Sub
        If chkOneToManyReconcileFlag.Checked = False Then
            If aSelCnt <> 1 Then Exit Sub
        Else
            If aSelCnt < 2 Then Exit Sub
        End If


        gcon.BeginTrans()

        r_b = dgvJournal_b.SelectedRows(0).Index
        If chkOneToManyReconcileFlag.Checked = False Then
            r_a = dgvJournal_a.SelectedRows(0).Index
            PerformManualReconciliation(r_a, r_b, 0)
        Else
            For aIndx = 0 To aSelCnt - 1
                r_a = dgvJournal_a.SelectedRows(aIndx).Index
                PerformManualReconciliation(r_a, r_b, aIndx)
            Next
        End If

        gcon.CommitTrans()
        'MsgBox("Transaction reconciled")


        RefreshForm()

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)


    End Sub

    Private Sub PerformManualReconciliation(r_a As Integer, r_b As Integer, aIndx As Integer)
        On Error GoTo errH
        Dim cnt As Integer = 0
        Dim amt_a As String, amt_b As String, narration_a As String, narration_b As String, myDocRef As New clsDocRef, dRef_a As String, dRef_b As String, chqNo_a As String, chqNo_b As String, gid_a As String, gid_b As String
        Dim date_a_neft As String, date_b As String, chqDate_a As String, tmpNarration As String

        If r_a < 0 Or r_b < 0 Then Exit Sub

        dRef_a = Replace(dgvJournal_a.Rows(r_a).Cells("DocRef_a").Value, "'", "''")
        narration_a = Replace(dgvJournal_a.Rows(r_a).Cells("Narration_a").Value, "'", "''")
        gid_a = dgvJournal_a.Rows(r_a).Cells("gid_a").Value
        amt_a = dgvJournal_a.Rows(r_a).Cells("DrAmount_a").Value
        chqNo_a = myDocRef.getChequeNo(dRef_a)
        date_a_neft = stripLeadingZero(myDocRef.getTransferDate(dRef_a))
        chqDate_a = myDocRef.getChequeDate(dRef_a)

        dRef_b = Replace(dgvJournal_b.Rows(r_b).Cells("DocRef_b").Value, "'", "''")
        narration_b = Replace(dgvJournal_b.Rows(r_b).Cells("Narration_b").Value, "'", "''")
        gid_b = dgvJournal_b.Rows(r_b).Cells("gid_b").Value
        amt_b = dgvJournal_b.Rows(r_b).Cells("DrAmount_b").Value
        chqNo_b = myDocRef.getChequeNo(dRef_b)
        date_b = stripLeadingZero(dgvJournal_b.Rows(r_b).Cells("TxnDate_b").Value)

        If (chkOneToManyReconcileFlag.Checked = False) And (amt_a <> amt_b) Then
            MsgBox("Can't reconcile due to amount mismatch")
            Exit Sub
        End If

        If chqDate_a <> "" Then 'cheque
            If (chqNo_a <> chqNo_b) Then
                MsgBox("Can't reconcile due to cheque no mismatch")
                Exit Sub
            End If
        Else 'NEFT
            If (date_a_neft <> date_b) Then
                MsgBox("Can't reconcile due to date mismatch. Verify and correct(if required) transaction date in receipt/payment transaction")
                Exit Sub
            End If
        End If

        If MsgBox("Confirm reconcilliation", vbOKCancel) = vbCancel Then
            Exit Sub
        End If

        '_b=bank; _a=system
        'Link bank with journal
        ssql = "update tbljournal set refgid='" & gid_a & "',"

        If optDeposit.Checked = True Then
            If chkOneToManyReconcileFlag.Checked = False Then
                ssql = ssql & " Narration='" & dRef_a & "'"
            Else
                If aIndx = 0 Then
                    ssql = ssql & " Narration='" & dRef_a & "'"
                Else
                    ssql = ssql & " Narration= concat(Narration,' and " & dRef_a & "')"
                End If
            End If
        ElseIf optWithdrawal.Checked = True Then
            ssql = ssql & " Narration='" & narration_a & "'"
        End If
        ssql = ssql & " where gid='" & gid_b & "'"
        gcon.Execute(ssql)

        'Link journal with bank
        ssql = "update tbljournal set refgid='" & gid_b & "' where gid='" & gid_a & "'"
        gcon.Execute(ssql)

        'Link receipt with bank
        ssql = "Update tblreceipt set refgid='" & gid_b & "' where gid='" & gid_a & "'"
        gcon.Execute(ssql)

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        myMsgBox(gErrMsg)
    End Sub


    Private Sub btnOpenBillReceiptScreen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenBillReceiptScreen.Click
        gOldItemCode = gItemCode
        'standard entry check code start
        gItemCode = "frmBookReceipt"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = gOldItemCode
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end
        gCurFlatCode = ""
        frmBookReceipt.ShowDialog()
        frmBookReceipt.Dispose()
        gItemCode = gOldItemCode
        RefreshForm()
        gCurFlatCode = ""
    End Sub

    Private Sub optWithdrawal_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optWithdrawal.CheckedChanged
        dgvJournal_a.Rows.Clear()
        dgvJournal_b.Rows.Clear()
        If optWithdrawal.Checked = True Then
            dgvJournal_a.Columns("DrAmount_a").Visible = False
            dgvJournal_a.Columns("CrAmount_a").Visible = True
            dgvJournal_b.Columns("DrAmount_b").Visible = False
            dgvJournal_b.Columns("CrAmount_b").Visible = True
        ElseIf optDeposit.Checked = True Then
            dgvJournal_a.Columns("DrAmount_a").Visible = True
            dgvJournal_a.Columns("CrAmount_a").Visible = False
            dgvJournal_b.Columns("DrAmount_b").Visible = True
            dgvJournal_b.Columns("CrAmount_b").Visible = False
        End If

    End Sub

   

    Private Sub dgvJournal_a_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvJournal_a.CellMouseClick
        If optDeposit.Checked = False Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            If dgvJournal_a.CurrentRow.Index < 0 Then Exit Sub
            receiptContextMenu.Show()
            receiptContextMenu.Left = Cursor.Position.X
            receiptContextMenu.Top = Cursor.Position.Y
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then

        End If
    End Sub
    Private Sub tsmiEditReceipt_Click(sender As System.Object, e As System.EventArgs) Handles tsmiEditReceipt.Click
        On Error GoTo errH
        Dim myDocRef As New clsDocRef, thisDocRef As String
        thisDocRef = dgvJournal_a.Rows(dgvJournal_a.CurrentRow.Index).Cells(5).Value
        gCurReceiptNo = myDocRef.getReceiptNo(thisDocRef)
        gOldItemCode = gItemCode
        gItemCode = "frmViewReceipt"
        frmViewReceipt.ShowDialog()
        frmViewReceipt.Dispose()
        gCurReceiptNo = ""
        gItemCode = gOldItemCode
        gCurReceiptNo = ""
        Exit Sub

errH:
        MsgBox(Err.Description)
        gItemCode = gOldItemCode
    End Sub
    Private Sub tsmiBookReceipt_Click(sender As System.Object, e As System.EventArgs) Handles tsmiBookReceipt.Click
        On Error GoTo errH
        Dim myDocRef As New clsDocRef, thisDocRef As String
        thisDocRef = dgvJournal_a.Rows(dgvJournal_a.CurrentRow.Index).Cells(5).Value
        gCurFlatCode = myDocRef.getFlatCode(thisDocRef)
        gOldItemCode = gItemCode
        gItemCode = "frmBookReceipt"
        frmBookReceipt.ShowDialog()
        frmBookReceipt.Dispose()
        gCurFlatCode = ""
        gItemCode = gOldItemCode
        gCurReceiptNo = ""
        Exit Sub

errH:
        MsgBox(Err.Description)
        gItemCode = gOldItemCode
    End Sub

    Private Sub btnFlatOwnerSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnFlatOwnerSearch.Click
        gOldItemCode = gItemCode
        'standard entry check code start
        gItemCode = "frmSearchFlat"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = gOldItemCode
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end
        gCurFlatCode = ""
        frmSearchFlat.ShowDialog()
        frmSearchFlat.Dispose()
        gItemCode = gOldItemCode
    End Sub

    

    Private Sub dgvJournal_b_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvJournal_b.CellContentClick
        Dim dRef_b As String, r_b As Integer, chqNeftNo_b As String, myDocRef As New clsDocRef

        r_b = e.RowIndex

        If r_b < 0 Then Exit Sub

        txtChequeToFind.Text = ""

        dRef_b = dgvJournal_b.Rows(r_b).Cells("DocRef_b").Value

        chqNeftNo_b = myDocRef.getChequeNo(dRef_b)

        If chqNeftNo_b = "" Then
            chqNeftNo_b = myDocRef.getNEFTRefNo(dRef_b)
        End If

        txtChequeToFind.Text = chqNeftNo_b

        btnLocate.PerformClick()

    End Sub

   
    Private Sub btnLocate_Click(sender As Object, e As EventArgs) Handles btnLocate.Click
        Dim dRef_a As String, r_a As Integer, chqNeftNo_a As String, myDocRef As New clsDocRef, gid_a As String
        dgvJournal_a.ClearSelection()
        txtBankName.Text = ""

        For r_a = dgvJournal_a.Rows.Count - 1 To 0 Step -1
            dRef_a = dgvJournal_a.Rows(r_a).Cells("DocRef_a").Value
            chqNeftNo_a = myDocRef.getChequeNo(dRef_a)
            If chqNeftNo_a = "" Then
                chqNeftNo_a = myDocRef.getOnlineTransferRefNo(dRef_a)
            End If
            gid_a = dgvJournal_a.Rows(r_a).Cells("gid_a").Value

            If chqNeftNo_a = txtChequeToFind.Text Then
                dgvJournal_a.FirstDisplayedScrollingRowIndex = r_a
                dgvJournal_a.Rows(r_a).Selected = True

                'fetch bank name
                Dim tmpRS As ADODB.Recordset
                tmpRS = gcon.Execute("select InstrumentBank from tblreceipt where gid='" & gid_a & "'")
                If tmpRS.EOF = False Then txtBankName.Text = tmpRS("InstrumentBank").Value.ToString
                tmpRS.Close()
            End If
        Next
    End Sub

    Private Sub chkOneToManyReconcileFlag_CheckedChanged(sender As Object, e As EventArgs) Handles chkOneToManyReconcileFlag.CheckedChanged
        dgvJournal_a.MultiSelect = chkOneToManyReconcileFlag.Checked
    End Sub

    Private Sub btnMarkPayeeUntraced_Click(sender As Object, e As EventArgs) Handles btnMarkPayeeUntraced.Click
        On Error GoTo errH
        Dim cnt As Integer = 0, aSelCnt As Integer, bSelCnt As Integer, aIndx As Integer, gid_b As String = ""
        Dim r_a As Integer, r_b As Integer

        bSelCnt = dgvJournal_b.SelectedRows.Count

        If bSelCnt <> 1 Then Exit Sub

        gcon.BeginTrans()

        r_b = dgvJournal_b.SelectedRows(0).Index
        If r_b < 0 Then Exit Sub
        gid_b = dgvJournal_b.Rows(r_b).Cells("gid_b").Value
        'Replace Cr Account to REV-UNTRACED-PAYMENT
        ssql = "Update tbljournal set AccountNo='REV-UNTRACED-PAYMENT', narration='Untraced Payment' where gid='" & gid_b & "' and CrAmount > 0 and DrAmount=0"

        gcon.Execute(ssql)

        gcon.CommitTrans()
        MsgBox("Entry marked as untraced payment")


        RefreshForm()

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)
    End Sub
End Class