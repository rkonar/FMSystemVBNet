Public Class frmBookOtherCharge
    Dim mCurGID As String

    Private Sub frmBookPenalty_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        cboFlatCode.Items.Add(gCurFlatCode)
        cboFlatCode.Text = gCurFlatCode
        txtNarration.Text = "Charges due to:"

        If gCurTblID <> "" Then
            btnDelete.Enabled = True
            loadTheRecord()
        End If

    End Sub

    Sub loadTheRecord()
        Dim myDocRef As New clsDocRef, thisDocRef As String, myJournal As New clsJournal

        myJournal.loadSingleTransactionFromJournalID(gCurTblID)

        With myJournal
            mCurGID = .gid
            thisDocRef = .DocRef
            txtNarration.Text = .Narration
            dtpBookDate.Text = formatInt2Date(.TxnDate)
            txtChargeAmount.Text = .Amount
        End With

    End Sub


    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    
    

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If DateTime.Parse(dtpBookDate.Text) > DateTime.Now Then
            MsgBox("Book date can't be future date")
            Exit Sub
        End If

        If Trim(txtNarration.Text) = "" Then
            MsgBox("Enter remarks")
            Exit Sub
        End If


        BookCharge()

    End Sub

    Sub BookCharge()
        On Error GoTo errH

        'Journalise Panalty
        'Debit Debtor (Account Receivables)
        'Credit REV-MAINT-OTHER-CHARGES-<FlatCode>
        Dim thisJournal As New clsJournal
        With thisJournal
            .DocRef = "(Payee:" & cboFlatCode.Text & ")"
            .Amount = txtChargeAmount.Text
            .Narration = txtNarration.Text
            .TxnDate = dtpBookDate.Text

            If mCurGID = "" Then
                .DrAccountNo = "DEBTOR-FLAT-" & gCurFlatCode
                .CrAccountNo = "REV-MAINT-OTHER-CHARGES-" & gCurFlatCode
                .TxnType = "MAINT-BILL-OTHER-CHARGES"
                .VoucherType = "JV"
                gcon.BeginTrans()
                .CreateTransaction()
                gcon.CommitTrans()
                gItemAction = "Create"
            Else
                .gid = mCurGID
                gcon.BeginTrans()
                .UpdateJournalForPenaltyAndCharges()
                gcon.CommitTrans()
                gItemAction = "Update"
            End If

            If .Status = True Then
                gFormDataChanged = True
                gItemID = .DocRef
                If logUserActivity() = False Then GoTo errH
            End If

        End With


        MsgBox("Done")
        Me.Close()

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        On Error GoTo errH
        If gFinYear.IsDateInFinYear(DateTime.Parse(dtpBookDate.Value).ToString(DB_DATEFORMAT)) = False Then
            MsgBox("The date does not fall inside current financial year.")
            Exit Sub
        End If
        If MsgBox("Are you sure, you want to delete?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
        gcon.Execute("delete from tbljournal where gid='" & mCurGID & "'")
        MsgBox("Deleted")
        gFormDataChanged = True
        Me.Close()
        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub
End Class