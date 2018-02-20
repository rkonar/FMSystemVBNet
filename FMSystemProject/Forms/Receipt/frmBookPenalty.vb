Public Class frmBookPenalty

    Private Sub frmBookPenalty_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        cboFlatCode.Items.Add(gCurFlatCode)
        cboFlatCode.Text = gCurFlatCode
        cboFlatCode.Enabled = False
        txtPenaltyPerDay.Text = getSysParamValue("PENALTYPERDAY")
        txtNarration.Text = "Penalty for payments made beyond due date"
        txtNarration.ReadOnly = True
        txtPenaltyPerDay.ReadOnly = True

        If gCurTblID <> "" Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
            btnAdd.Enabled = False
            loadPenaltyRecord()
            cboBill.Enabled = False
        Else
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnAdd.Enabled = True
            LoadBills()
            cboBill.Enabled = True

        End If

        
        cboBill.Select()
    End Sub
    Sub loadPenaltyRecord()
        Dim myDocRef As New clsDocRef, thisDocRef As String, myJournal As New clsJournal, thisBillNo As String

        myJournal.loadSingleTransactionFromJournalID(gCurTblID)

        With myJournal
            gCurGID = .gid
            thisDocRef = .DocRef

            dtpDueDate.Text = myDocRef.getDueDate(thisDocRef)
            dtpPaymentDate.Text = myDocRef.getPaymentDate(thisDocRef)
            dtpBookDate.Text = formatInt2Date(.TxnDate)
            thisBillNo = myDocRef.getBillNo(thisDocRef)
            cboBill.Items.Add(thisBillNo)
            cboBill.Text = thisBillNo
            txtPenaltyAmount.Text = .Amount

            txtPenaltyPerDay.Text = Math.Round(.Amount / myDocRef.getDaysLate(thisDocRef), 0)

        End With

    End Sub
    Sub LoadBills()
        Dim billRS As ADODB.Recordset

        cboBill.Items.Clear()
        ssql = "select BillNo from tblbill where FlatCode='" & cboFlatCode.Text & "' order by tblid desc"
        billRS = gcon.Execute(ssql)
        While billRS.EOF = False
            cboBill.Items.Add(billRS("BillNo").Value.ToString)
            billRS.MoveNext()
        End While
        billRS.Close()
    End Sub
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Sub CalculatePenalty()
        txtNoOfDays.Text = (DateDiff(DateInterval.Day, DateTime.Parse(dtpDueDate.Text), DateTime.Parse(dtpBookDate.Text)))
        If txtNoOfDays.Text < 0 Then txtNoOfDays.Text = 0
        txtPenaltyAmount.Text = txtPenaltyPerDay.Text * txtNoOfDays.Text
    End Sub

    Private Sub dtpPaymentDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpPaymentDate.ValueChanged
        dtpBookDate.Text = dtpPaymentDate.Text
        CalculatePenalty()
    End Sub


    


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        On Error GoTo errH
        If gFinYear.IsDateInFinYear(DateTime.Parse(dtpBookDate.Value).ToString(DB_DATEFORMAT)) = False Then
            MsgBox("The date does not fall inside current financial year.")
            Exit Sub
        End If
        If MsgBox("Are you sure, you want to delete?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
        gcon.Execute("delete from tbljournal where gid='" & gCurGID & "'")
        MsgBox("Deleted")
        gFormDataChanged = True
        Me.Close()
        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub

    Private Sub dtpBookDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpBookDate.ValueChanged
        CalculatePenalty()
    End Sub

    Private Sub cboBill_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboBill.SelectedValueChanged
        Dim billRS As ADODB.Recordset
        If cboBill.SelectedIndex < 0 Then Exit Sub

        billRS = gcon.Execute("select DueDate from tblbill where BillNo='" & cboBill.Text & "'")
        dtpDueDate.Text = formatInt2Date(billRS("DueDate").Value.ToString)
        billRS.Close()
        CalculatePenalty()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        On Error GoTo errH

        If DateTime.Parse(dtpDueDate.Text) > DateTime.Parse(dtpPaymentDate.Text) Then
            MsgBox("Due date can't be after Paid date")
            Exit Sub
        End If

        If Trim(txtNarration.Text) = "" Then
            MsgBox("Enter remarks")
            Exit Sub
        End If
        If cboBill.SelectedIndex = -1 Then
            MsgBox("Select Bill No")
            Exit Sub
        End If



        'Journalise Panalty
        'Debit Debtor (Account Receivables)
        'Credit REV-MAINT-OTHER-CHARGES-<FlatCode>
        Dim thisJournal As New clsJournal
        With thisJournal

            .Narration = txtNarration.Text
            .DocRef = "(Bill No:" & cboBill.Text & ",Due Date:" & dtpDueDate.Text & ",Payment Date: " & dtpPaymentDate.Text & ",Days Late:" & txtNoOfDays.Text & ",Payee:" & cboFlatCode.Text & ")"
            .TxnDate = dtpBookDate.Text
            .Amount = txtPenaltyAmount.Text


            .DrAccountNo = "DEBTOR-FLAT-" & gCurFlatCode
            .CrAccountNo = "REV-MAINT-OTHER-CHARGES-" & gCurFlatCode
            .TxnType = "MAINT-BILL-PENALTY"
            .VoucherType = "JV"

            gcon.BeginTrans()
            .CreateTransaction()
            gcon.CommitTrans()

            gItemAction = "Create"


            If .Status = True Then
                gFormDataChanged = True
                gItemID = .DocRef
                If logUserActivity() = False Then GoTo errH
            End If


        End With


        Me.Close()

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        On Error GoTo errH

        If DateTime.Parse(dtpDueDate.Text) > DateTime.Parse(dtpPaymentDate.Text) Then
            MsgBox("Due date can't be after Paid date")
            Exit Sub
        End If

        If Trim(txtNarration.Text) = "" Then
            MsgBox("Enter remarks")
            Exit Sub
        End If

        'Journalise Panalty
        'Debit Debtor (Account Receivables)
        'Credit REV-MAINT-OTHER-CHARGES-<FlatCode>
        Dim thisJournal As New clsJournal
        With thisJournal

            .Narration = txtNarration.Text
            .DocRef = "(Bill No:" & cboBill.Text & ",Due Date:" & dtpDueDate.Text & ",Payment Date: " & dtpPaymentDate.Text & ",Days Late:" & txtNoOfDays.Text & ",Payee:" & cboFlatCode.Text & ")"
            .TxnDate = dtpBookDate.Text
            .Amount = txtPenaltyAmount.Text

            .gid = gCurGID
            gcon.BeginTrans()
            .UpdateJournalForPenaltyAndCharges()
            gcon.CommitTrans()
            gItemAction = "Update"

            If .Status = True Then
                gFormDataChanged = True
                gItemID = .DocRef
                If logUserActivity() = False Then GoTo errH
            End If


        End With


        Me.Close()

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)


    End Sub

End Class