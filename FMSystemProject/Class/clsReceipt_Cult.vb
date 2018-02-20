Public Class clsReceipt_Cult

    Public tblid As String
    Public gid As String
    Public refgid As String
    Public ReceiptNo As String
    Public FlatCode As String
    Public ReceiptDate As String
    Public ReceiptAmount As Double
    Public InstrumentType As String
    Public InstrumentNo As String
    Public InstrumentDate As String
    Public InstrumentBank As String
    Public Remarks As String
    Public InstrumentReconciled As String
    Public ReceiptStatus As String
    Public JournalDate As String
    Public CancelDate As String

    Public Status As Boolean

    Dim receiptRS As ADODB.Recordset

    Public Sub New()
        resetAll()
    End Sub

    Private Sub resetAll()
        tblid = ""
        gid = ""
        refgid = ""
        ReceiptNo = ""
        FlatCode = ""
        ReceiptDate = ""
        ReceiptAmount = 0
        InstrumentType = ""
        InstrumentNo = ""
        InstrumentDate = ""
        InstrumentBank = ""
        Remarks = ""
        InstrumentReconciled = ""
        ReceiptStatus = ""
        JournalDate = ""
        CancelDate = ""

        Status = False
    End Sub

    Public Sub loadSingleReceipt(receipt_id As String, receipt_no As String, g_id As String)
        On Error GoTo errH

        If receipt_id <> "" Then
            ssql = "select * from tblreceipt_cult where tblid=" & receipt_id
        ElseIf receipt_no <> "" Then
            ssql = "select * from tblreceipt_cult where ReceiptNo='" & receipt_no & "'"
        ElseIf g_id <> "" Then
            ssql = "select * from tblreceipt_cult where gid='" & g_id & "'"
        Else
            resetAll()
            MsgBox("clsReceipt_cult/loadSingleReceipt: atleast one of the input should be non blank")
            Exit Sub
        End If

        receiptRS = gcon.Execute(ssql)

        If receiptRS.EOF = True Then
            Status = False
            MsgBox("clsReceipt_cult/loadSingleReceipt: No receipt found for tblid/receiptno=" & receipt_id & "/" & receipt_no)
            Exit Sub
        End If

        tblid = receiptRS("tblid").Value.ToString
        gid = receiptRS("gid").Value.ToString
        refgid = receiptRS("refgid").Value.ToString
        ReceiptNo = receiptRS("ReceiptNo").Value.ToString
        FlatCode = receiptRS("FlatCode").Value.ToString
        ReceiptDate = formatInt2Date(receiptRS("ReceiptDate").Value.ToString)
        ReceiptAmount = receiptRS("ReceiptAmt").Value.ToString
        InstrumentType = receiptRS("InstrumentType").Value.ToString
        InstrumentNo = receiptRS("InstrumentNo").Value.ToString
        InstrumentDate = formatInt2Date(receiptRS("InstrumentDate").Value.ToString)
        InstrumentBank = receiptRS("InstrumentBank").Value.ToString
        Remarks = receiptRS("Remarks").Value.ToString
        InstrumentReconciled = receiptRS("InstrumentReconciled").Value.ToString
        ReceiptStatus = receiptRS("Status").Value.ToString
        receiptRS.Close()

        ssql = "select TxnDate from tbljournal_cult where gid='" & gid & "'"
        receiptRS = gcon.Execute(ssql)
        JournalDate = formatInt2Date(receiptRS("TxnDate").Value.ToString)
        receiptRS.Close()

        Status = True

        Exit Sub

errH:
        MsgBox(Err.Description)
        Status = False
    End Sub

    Public Sub CreateReceipt()
        On Error GoTo errH

        'Check that the TxnDate falls inside current FinYear
        If gFinYear.IsDateInFinYear(DateTime.Parse(ReceiptDate).ToString(DB_DATEFORMAT)) = False Then
            MsgBox("The date does not fall inside current financial year.")
            Exit Sub
        End If
        'Check that the receipt number is available for use
        ssql = "select tblid from tblreceiptbook_cult where ReceiptNo = '" & ReceiptNo & "' and Status='A'"
        tmpRS = gcon.Execute(ssql)

        If tmpRS.EOF = True Then
            MsgBox("This receipt no " & ReceiptNo & " is not available for use as per defined Receipt Books in the system")
            Exit Sub
        End If

        ssql = "Insert into tblreceipt_cult (gid,refgid,ReceiptNo,FlatCode,ReceiptDate,ReceiptAmt,InstrumentType,InstrumentDate,InstrumentBank,InstrumentNo,Remarks) values ("
        ssql = ssql & "'" & gid & "',"
        If refgid = "" Then
            ssql = ssql & "null,"
        Else
            ssql = ssql & "'" & refgid & "',"
        End If
        ssql = ssql & "'" & Trim(ReceiptNo) & "',"
        ssql = ssql & "'" & FlatCode & "',"
        ssql = ssql & "'" & DateTime.Parse(ReceiptDate).ToString(DB_DATEFORMAT) & "',"
        ssql = ssql & Trim(ReceiptAmount) & ","
        ssql = ssql & "'" & Trim(InstrumentType) & "',"
        If InstrumentType = "CASH" Then
            ssql = ssql & "null,"
            ssql = ssql & "'-',"
            ssql = ssql & "'-',"
        ElseIf (InstrumentType = "CHEQUE") Or (InstrumentType = "ONLINE") Then
            ssql = ssql & "'" & DateTime.Parse(InstrumentDate).ToString(DB_DATEFORMAT) & "',"
            ssql = ssql & "'" & Trim(InstrumentBank) & "',"
            ssql = ssql & "'" & stripLeadingZero(InstrumentNo) & "',"
        End If
        ssql = ssql & "'" & Replace(Trim(Remarks), "'", "''") & "')"

        gcon.Execute(ssql)


        'mark the receipt as used
        ssql = "Update tblreceiptbook_cult set Status='U' where ReceiptNo='" & ReceiptNo & "'"
        gcon.Execute(ssql)


        Status = True
        Exit Sub

errH:
        MsgBox(Err.Description)
        Status = False
    End Sub

    Public Sub UpdateReceipt()
        On Error GoTo errH
        Dim journalRS As ADODB.Recordset

        Status = False

        'Check that the TxnDate falls inside current FinYear
        If gFinYear.IsDateInFinYear(DateTime.Parse(JournalDate).ToString(DB_DATEFORMAT)) = False Then
            MsgBox("The date does not fall inside current financial year.")
            Exit Sub
        End If


        'Update in tblreceipt_cult
        ssql = "Update tblreceipt_cult set " '(ReceiptNo,FlatCode,ReceiptDate,ReceiptAmt,InstrumentType,InstrumentDate,InstrumentBank,InstrumentNo,Remarks) values "
        ssql = ssql & " Remarks='" & Replace(Trim(Remarks), "'", "''") & "'"
        ssql = ssql & " ,FlatCode='" & Trim(FlatCode) & "'"
        ssql = ssql & " ,InstrumentType='" & Trim(InstrumentType) & "'"

        If InstrumentType = "CASH" Then
            ssql = ssql & " ,InstrumentNo='-'"
            ssql = ssql & " ,InstrumentBank='-'"
            ssql = ssql & " ,InstrumentDate=null"
        ElseIf (InstrumentType = "CHEQUE") Or (InstrumentType = "ONLINE") Then
            ssql = ssql & " ,InstrumentNo='" & stripLeadingZero(InstrumentNo) & "'"
            ssql = ssql & " ,InstrumentBank='" & Trim(InstrumentBank) & "'"
            ssql = ssql & " ,InstrumentDate='" & DateTime.Parse(InstrumentDate).ToString(DB_DATEFORMAT) & "'"
        End If

        ssql = ssql & " ,ReceiptDate='" & DateTime.Parse(ReceiptDate).ToString(DB_DATEFORMAT) & "'"
        ssql = ssql & " ,ReceiptNo='" & ReceiptNo & "'"
        ssql = ssql & " ,ReceiptAmt=" & ReceiptAmount

        ssql = ssql & " where gid='" & gid & "'"

        gcon.Execute(ssql)

        'update in tbljournal_cult

        ssql = "select * from tbljournal_cult where gid='" & gid & "' "
        journalRS = gcon.Execute(ssql)

        If journalRS.EOF = True Then
            MsgBox("No journal entry found for this receipt. No update done.")
            gcon.RollbackTrans()
            Exit Sub
        End If

        Dim thisJournal As New clsJournal_cult, tmpDocRef As String = ""


        'update both entries
        While journalRS.EOF = False
            thisJournal.loadSingleTransactionFromJournalID(journalRS("tblid").Value.ToString)

            thisJournal.Narration = Remarks
            thisJournal.Amount = ReceiptAmount
            thisJournal.TxnDate = JournalDate
            If InstrumentType = "CASH" Then
                thisJournal.DocRef = "(Receipt No:" & ReceiptNo & ", Payment Mode: CASH, Payee:" & FlatCode & ")"
                thisJournal.DrAccountNo = "CASHBOX-CULT"
                'thisJournal.TxnDate = ReceiptDate
            ElseIf InstrumentType = "CHEQUE" Then
                thisJournal.DocRef = "(Receipt No:" & ReceiptNo & ", Cheque No:" & stripLeadingZero(InstrumentNo) & ", Cheque Date:" & InstrumentDate & ", Payee:" & FlatCode & ")"
                thisJournal.DrAccountNo = "CHEQUE-IN-HAND-CULT"
                'thisJournal.TxnDate = ReceiptDate
            ElseIf InstrumentType = "ONLINE" Then 'CASH/CHEQUE to ONLINE or Vice Versa is not allowed at present
                thisJournal.DocRef = "(Receipt No:" & ReceiptNo & ", Online Transfer Ref:" & stripLeadingZero(InstrumentNo) & ", Transfer Date:" & InstrumentDate & ", Payee:" & FlatCode & ")"
                'thisJournal.TxnDate = InstrumentDate
            End If

            'update in journal
            ssql = "Update tbljournal_cult set "
            ssql = ssql & " Narration='" & Replace(Trim(thisJournal.Narration), "'", "''") & "'"
            ssql = ssql & " ,DocRef='" & Trim(thisJournal.DocRef) & "'"
            ssql = ssql & " ,TxnDate='" & DateTime.Parse(thisJournal.TxnDate).ToString(DB_DATEFORMAT) & "'"

            If journalRS("CrAmount").Value.ToString = 0 Then ' so it is debit line
                ssql = ssql & " ,DrAmount='" & thisJournal.Amount & "'"
                ssql = ssql & " ,AccountNo='" & Trim(thisJournal.DrAccountNo) & "'"
            Else ' so it is credit line, no account update for receipts
                ssql = ssql & " ,CrAmount='" & thisJournal.Amount & "'"
                ssql = ssql & " ,AccountNo='" & Trim(thisJournal.CrAccountNo) & "'"
            End If
            ssql = ssql & " where tblid='" & thisJournal.tblid & "'"
            gcon.Execute(ssql)
            tmpDocRef = thisJournal.DocRef
            journalRS.MoveNext()
        End While

        'Update in journal - narration of both the bank payment received txn entries (for cheque & neft)
        ssql = "update tbljournal_cult set Narration='" & tmpDocRef & "' where refgid='" & gid & "'"
        gcon.Execute(ssql)

        Status = True
        Exit Sub

errH:
        MsgBox(Err.Description)
        Status = False
    End Sub

    Public Sub ContraReceipt()
        On Error GoTo errH
        Dim journalRS As ADODB.Recordset

        Status = False

        If gid = "" Then Exit Sub


        'Check that the TxnDate falls inside current FinYear
        If gFinYear.IsDateInFinYear(DateTime.Parse(ReceiptDate).ToString(DB_DATEFORMAT)) = False Then
            MsgBox("The date does not fall inside current financial year.")
            Exit Sub
        End If

        'Update in tblreceipt_cult
        ssql = "Update tblreceipt_cult set Status='C'" ', refgid=null" '(ReceiptNo,FlatCode,ReceiptDate,ReceiptAmt,InstrumentType,InstrumentDate,InstrumentBank,InstrumentNo,Remarks) values "
        ssql = ssql & ", Remarks=concat('[RECEIPT-REVERSED][REASON-" & Replace(Trim(Remarks), "'", "''") & "]:', Remarks)"
        ssql = ssql & " where gid='" & gid & "'"
        gcon.Execute(ssql)

        'Update in tbljournal_cult
        ssql = "Update tbljournal_cult set "
        ssql = ssql & " Narration = concat('[RECEIPT-REVERSED][REASON-" & Replace(Trim(Remarks), "'", "''") & "]:', Narration)"
        ssql = ssql & " where gid='" & gid & "'"
        gcon.Execute(ssql)

        'Create contra entry in journal
        Dim thisJournal As New clsJournal_cult, CrLine As New clsJournal_cult, DrLine As New clsJournal_cult

        'retrieve Dr & Cr Account No
        DrLine.loadDrTransactionFromGID(gid)
        CrLine.loadCrTransactionFromGID(gid)


        'Swap Dr & Cr Account No
        thisJournal = CrLine
        thisJournal.DrAccountNo = CrLine.CrAccountNo
        thisJournal.CrAccountNo = DrLine.DrAccountNo
        thisJournal.TxnType = "CONTRA-RECEIPT"
        thisJournal.TxnDate = CancelDate
        thisJournal.Narration = "[CONTRA-RECEIPT for :" & Replace(Trim(Remarks), "'", "''") & "][CONTRA ENTRY] " & thisJournal.Narration
        thisJournal.refgid = "-"

        thisJournal.CreateTransaction()


        ''update in tbljournal_cult
        ''Dim thisJournal As New clsJournal_cult
        'ssql = "Update tbljournal_cult set Status='C'" ',refgid=null" '(ReceiptNo,FlatCode,ReceiptDate,ReceiptAmt,InstrumentType,InstrumentDate,InstrumentBank,InstrumentNo,Remarks) values "
        'ssql = ssql & ", Narration=concat('[RECEIPT-CANCELLED:" & Replace(Trim(Remarks), "'", "''") & "] ', Narration)"
        'ssql = ssql & " where gid='" & gid & "'"
        'gcon.Execute(ssql)

        ''Unlink reconciled bank txns, if any
        'ssql = "Update tbljournal_cult set refgid=null" '(ReceiptNo,FlatCode,ReceiptDate,ReceiptAmt,InstrumentType,InstrumentDate,InstrumentBank,InstrumentNo,Remarks) values "
        'ssql = ssql & ", Narration=concat('[RECEIPT-CANCELLED:" & Replace(Trim(Remarks), "'", "''") & "] ', Narration)"
        'ssql = ssql & " where refgid='" & gid & "'"
        'gcon.Execute(ssql)

        Status = True
        Exit Sub

errH:
        MsgBox(Err.Description)
        Status = False
    End Sub


    '    Public Sub ReconcileInstrument(receipt_gid As String, bank_gid As String)
    '        On Error GoTo errH

    '        'Update in tblreceipt_cult
    '        ssql = "Update tblreceipt_cult set "  'InstrumentReconciled='Y'" '(ReceiptNo,FlatCode,ReceiptDate,ReceiptAmt,InstrumentType,InstrumentDate,InstrumentBank,InstrumentNo,Remarks) values "
    '        ssql = ssql & " refgid='" & bank_gid & "'"
    '        ssql = ssql & " where gid='" & receipt_gid & "'"
    '        gcon.Execute(ssql)

    '        Status = True
    '        Exit Sub

    'errH:
    '        MsgBox(Err.Description)
    '        Status = False
    '    End Sub




End Class
