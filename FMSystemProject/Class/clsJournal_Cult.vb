Public Class clsJournal_Cult

    Public tblid As String
    Public gid As String
    Public refgid As String
    Public TxnType As String
    Public TxnDate As String
    Public Narration As String
    Public DocRef As String
    Public DrAccountNo As String
    Public CrAccountNo As String
    Public Amount As Double
    Public TxnStatus As String
    Public VoucherNo As String
    Public VoucherType As String
    Public ApprovedDate As String
    Public ApprovedBy As String
    Public SupervisorName As String
    Public Tag1 As String
    Public Tag2 As String

    Public Status As Boolean


    Dim journalRS As ADODB.Recordset

    Public Sub New()
        resetAll()

    End Sub
    Private Sub resetAll()
        tblid = ""
        gid = ""
        refgid = ""
        TxnType = ""
        TxnDate = ""
        Narration = ""
        DocRef = ""
        DrAccountNo = ""
        CrAccountNo = ""
        Amount = 0
        TxnStatus = ""
        SupervisorName = ""
        ApprovedBy = ""
        ApprovedDate = ""
        Status = False
        VoucherNo = ""
        VoucherType = ""
        Tag1 = ""
        Tag2 = ""
    End Sub
    Public Sub CreateTransaction()
        On Error GoTo errH


        If CrAccountNo = "" Then
            MsgBox("Credit Account No not set. Contact System Admin.")
            Exit Sub
        ElseIf DrAccountNo = "" Then
            MsgBox("Debit Account No not set. Contact System Admin.")
            Exit Sub
        End If

        'Check that the TxnDate falls inside current FinYear
        If gFinYear.IsDateInFinYear(DateTime.Parse(TxnDate).ToString(DB_DATEFORMAT)) = False Then
            MsgBox("The date does not fall inside current financial year.")
            Exit Sub
        End If

        If VoucherNo = "" Then VoucherNo = "NULL"


        'Log Credit Line

        gid = DateTime.Now.ToString("yyyyMMddhhmmssffff") & Strings.Left(gLoginID, Math.Min(Strings.Len(gLoginID), 12))

        ssql = "Insert into tbljournal_cult (gid,refgid,TxnType,TxnDate,Narration,DocRef,AccountNo,DrAmount,CrAmount,VoucherNo,VoucherType,Status,SupervisorName,Tag1,Tag2) values ("
        ssql = ssql & "'" & gid & "',"
        If refgid = "" Then
            ssql = ssql & "null,"
        Else
            ssql = ssql & "'" & refgid & "',"
        End If
        ssql = ssql & "'" & TxnType & "',"
        ssql = ssql & "'" & DateTime.Parse(TxnDate).ToString(DB_DATEFORMAT) & "',"
        ssql = ssql & "'" & Replace(Narration, "'", "''") & "',"
        ssql = ssql & "'" & Replace(DocRef, "'", "''") & "',"
        ssql = ssql & "'" & CrAccountNo & "',"
        ssql = ssql & "0,"
        ssql = ssql & Amount & ","
        ssql = ssql & VoucherNo & ","
        ssql = ssql & "'" & VoucherType & "',"

        If TxnStatus = "" Then
            ssql = ssql & "null,"
        Else
            ssql = ssql & "'" & TxnStatus & "',"
        End If

        If SupervisorName = "" Then
            ssql = ssql & "null,"
        Else
            ssql = ssql & "'" & Replace(SupervisorName, "'", "''") & "',"
        End If
        ssql = ssql & IIf(Tag1 = "", "null", "'" & UCase(Tag1) & "'") & ","
        ssql = ssql & IIf(Tag2 = "", "null", "'" & UCase(Tag2) & "'")
        ssql = ssql & ")"

        gcon.Execute(ssql)

        'Log Debit Line
        ssql = "Insert into tbljournal_cult (gid,refgid,TxnType,TxnDate,Narration,DocRef,AccountNo,DrAmount,CrAmount,VoucherNo,VoucherType,Status,SupervisorName,Tag1,Tag2) values ("
        ssql = ssql & "'" & gid & "',"
        If refgid = "" Then
            ssql = ssql & "null,"
        Else
            ssql = ssql & "'" & refgid & "',"
        End If
        ssql = ssql & "'" & TxnType & "',"
        ssql = ssql & "'" & DateTime.Parse(TxnDate).ToString(DB_DATEFORMAT) & "',"
        ssql = ssql & "'" & Replace(Narration, "'", "''") & "',"
        ssql = ssql & "'" & Replace(DocRef, "'", "''") & "',"
        ssql = ssql & "'" & DrAccountNo & "',"
        ssql = ssql & Amount & ","
        ssql = ssql & "0,"
        ssql = ssql & VoucherNo & ","
        ssql = ssql & "'" & VoucherType & "',"

        If TxnStatus = "" Then
            ssql = ssql & "null,"
        Else
            ssql = ssql & "'" & TxnStatus & "',"
        End If

        If SupervisorName = "" Then
            ssql = ssql & "null,"
        Else
            ssql = ssql & "'" & Replace(SupervisorName, "'", "''") & "',"
        End If
        ssql = ssql & IIf(Tag1 = "", "null", "'" & UCase(Tag1) & "'") & ","
        ssql = ssql & IIf(Tag2 = "", "null", "'" & UCase(Tag2) & "'")
        ssql = ssql & ")"

        gcon.Execute(ssql)

        Status = True
        Exit Sub

errH:
        MsgBox(Err.Description)
        Status = False
    End Sub


    Public Sub UpdateJournalForPenaltyAndCharges() 'tblid,gid,refgid,TxnType,Account No,Status can't be updated from this function
        On Error GoTo errH
        Dim journalRS As ADODB.Recordset, drAmt As String, crAmt As String, tblid As String

        'Check that the TxnDate falls inside current FinYear
        If gFinYear.IsDateInFinYear(DateTime.Parse(TxnDate).ToString(DB_DATEFORMAT)) = False Then
            MsgBox("The date does not fall inside current financial year.")
            Exit Sub
        End If


        ssql = "select * from tbljournal_cult where gid='" & gid & "'"
        journalRS = gcon.Execute(ssql)

        While journalRS.EOF = False
            drAmt = journalRS("DrAmount").Value.ToString
            crAmt = journalRS("CrAmount").Value.ToString
            tblid = journalRS("tblid").Value.ToString

            'Update in tbljournal_cult
            ssql = "Update tbljournal_cult set "
            ssql = ssql & " Narration='" & Replace(Trim(Narration), "'", "''") & "'"
            ssql = ssql & " ,DocRef='" & Trim(DocRef) & "'"
            ssql = ssql & " ,TxnDate='" & DateTime.Parse(TxnDate).ToString(DB_DATEFORMAT) & "'"

            If drAmt = 0 Then
                ssql = ssql & " ,CrAmount=" & Amount
            Else
                ssql = ssql & " ,DrAmount=" & Amount
            End If

            ssql = ssql & " where tblid=" & tblid

            gcon.Execute(ssql)

            journalRS.MoveNext()
        End While
        journalRS.Close()
        Status = True
        Exit Sub

errH:
        MsgBox(Err.Description)
        Status = False
    End Sub
    Public Sub UpdateJournalForPayment()
        On Error GoTo errH

        'Check that the TxnDate falls inside current FinYear
        If gFinYear.IsDateInFinYear(DateTime.Parse(TxnDate).ToString(DB_DATEFORMAT)) = False Then
            MsgBox("The date does not fall inside current financial year.")
            Exit Sub
        End If

        'Update in tbljournal_cult
        ssql = "Update tbljournal_cult set "
        ssql = ssql & " Narration='" & Replace(Trim(Narration), "'", "''") & "'"
        ssql = ssql & " ,TxnDate='" & DateTime.Parse(TxnDate).ToString(DB_DATEFORMAT) & "'"
        ssql = ssql & ", SupervisorName='" & Replace(SupervisorName, "'", "''") & "'"
        ssql = ssql & ",Tag1=" & IIf(Tag1 = "", "null", "'" & UCase(Tag1) & "'")
        ssql = ssql & ",Tag2=" & IIf(Tag2 = "", "null", "'" & UCase(Tag2) & "'")

        ssql = ssql & " where gid='" & gid & "'"

        gcon.Execute(ssql)

        Status = True
        Exit Sub

errH:
        MsgBox(Err.Description)
        Status = False
    End Sub

    Public Sub UpdateJournalForTag()
        On Error GoTo errH

        'Check that the TxnDate falls inside current FinYear
        If gFinYear.IsDateInFinYear(DateTime.Parse(TxnDate).ToString(DB_DATEFORMAT)) = False Then
            MsgBox("The date does not fall inside current financial year.")
            Exit Sub
        End If

        'Update in tbljournal_cult
        ssql = "Update tbljournal_cult set "
        ssql = ssql & "Tag1=" & IIf(Tag1 = "", "null", "'" & UCase(Tag1) & "'")
        ssql = ssql & ",Tag2=" & IIf(Tag2 = "", "null", "'" & UCase(Tag2) & "'")

        ssql = ssql & " where gid='" & gid & "'"

        gcon.Execute(ssql)

        Status = True
        Exit Sub

errH:
        MsgBox(Err.Description)
        Status = False
    End Sub

    Public Sub ApproveRejectJournal() 'Applicable only for Payment/Expense related journal entries
        'Status=null means approved; Status=C means Cancelled; Status=P means Pending
        On Error GoTo errH
        Dim ssql As String

        'Check that the TxnDate falls inside current FinYear
        If gFinYear.IsDateInFinYear(DateTime.Parse(Now()).ToString(DB_DATEFORMAT)) = False Then
            MsgBox("The date does not fall inside current financial year.")
            Exit Sub
        End If

        'Update in tbljournal_cult
        ssql = "Update tbljournal_cult set "
        If TxnStatus = "A" Then
            ssql = ssql & " Status=null "
        ElseIf TxnStatus = "C" Then
            ssql = ssql & " Status='C' "
        ElseIf TxnStatus = "R" Then
            ssql = ssql & " Status='R' "
        Else
            MsgBox("Invalid journal status : " & TxnStatus)
            Exit Sub
        End If
        ssql = ssql & ", ApprovedBy='" & gUserName & "', ApprovedDate=" & DateTime.Parse(Now()).ToString(DB_DATEFORMAT) & "  Where gid='" & gid & "'"
        gcon.Execute(ssql)


        Status = True
        Exit Sub

errH:
        MsgBox(Err.Description)
        Status = False
    End Sub
    '    Public Sub UpdateJournalOneLine(journalid As String, AcctNo As String)
    '        On Error GoTo errH
    '        Dim journalRS As ADODB.Recordset

    '        'Update in tbljournal_cult
    '        ssql = "Update tbljournal_cult set "
    '        ssql = ssql & " Narration='" & Replace(Trim(Narration), "'", "''") & "'"
    '        ssql = ssql & " ,DocRef='" & Trim(DocRef) & "'"
    '        ssql = ssql & " ,TxnDate='" & DateTime.Parse(TxnDate).ToString(DB_DATEFORMAT) & "'"
    '        'ssql = ssql & " ,TxnDate='" & TxnDate & "'"
    '        'chk this -rajib
    '        ssql = ssql & " ,AccountNo='" & Trim(AcctNo) & "'"

    '        ssql = ssql & " where tblid='" & journalid & "'"

    '        gcon.Execute(ssql)
    '        Status = True
    '        Exit Sub

    'errH:
    '        MsgBox(Err.Description)
    '        Status = False
    '    End Sub


    Public Sub loadSingleTransactionFromJournalID(journalid As String)
        On Error GoTo errH

        resetAll()

        ssql = "select * from tbljournal_cult where tblid=" & journalid
        journalRS = gcon.Execute(ssql)

        If journalRS.EOF = True Then
            Status = False
            MsgBox("clsJournal_cult/loadSingleTransactionFromJournalID: No journal entry found for tblid=" & journalid)
            resetAll()
            Exit Sub
        End If

        setFieldsFromDB()


        Status = True
        Exit Sub
errH:
        MsgBox(Err.Description)
        Status = False
    End Sub
    Public Sub loadDrTransactionFromGID(thisgid As String)
        On Error GoTo errH

        resetAll()

        ssql = "select * from tbljournal_cult where DrAmount <> 0 and gid='" & thisgid & "'"
        journalRS = gcon.Execute(ssql)

        If journalRS.EOF = True Then
            Status = False
            MsgBox("clsJournal_cult/loadDrTransactionFromGID: No journal entry found for gid=" & thisgid)
            resetAll()
            Exit Sub
        End If

        setFieldsFromDB()


        Status = True
        Exit Sub

errH:
        MsgBox(Err.Description)
        Status = False
    End Sub
    Public Sub loadCrTransactionFromGID(thisgid As String)
        On Error GoTo errH

        resetAll()

        ssql = "select * from tbljournal_cult where CrAmount <> 0 and gid='" & thisgid & "'"
        journalRS = gcon.Execute(ssql)

        If journalRS.EOF = True Then
            Status = False
            MsgBox("clsJournal_cult/loadCrTransactionFromGID: No journal entry found for gid=" & thisgid)
            resetAll()
            Exit Sub
        End If

        setFieldsFromDB()


        Status = True
        Exit Sub

errH:
        MsgBox(Err.Description)
        Status = False
    End Sub
    '    Public Sub loadSingleTransactionFromReceiptNo(ReceiptNo As String)
    '        On Error GoTo errH

    '        ssql = "select * from tbljournal_cult where DocRef like '(Receipt No:" & ReceiptNo & "%' "
    '        journalRS = gcon.Execute(ssql)

    '        If journalRS.EOF = True Then
    '            Status = False
    '            MsgBox("clsJournal_cult/loadSingleTransactionFromReceiptNo: No journal entry found for ReceiptNo=" & ReceiptNo)
    '            Exit Sub
    '        End If

    '        setFieldsFromDB()


    '        Status = True
    '        Exit Sub

    'errH:
    '        MsgBox(Err.Description)
    '        Status = False
    '    End Sub

    Sub setFieldsFromDB()
        tblid = journalRS("tblid").Value.ToString
        gid = journalRS("gid").Value.ToString
        refgid = journalRS("refgid").Value.ToString
        TxnType = journalRS("TxnType").Value.ToString
        TxnDate = journalRS("TxnDate").Value.ToString
        Narration = journalRS("Narration").Value.ToString
        DocRef = journalRS("DocRef").Value.ToString
        TxnStatus = journalRS("Status").Value.ToString
        VoucherNo = journalRS("VoucherNo").Value.ToString
        VoucherType = journalRS("VoucherType").Value.ToString
        ApprovedDate = journalRS("ApprovedDate").Value.ToString
        ApprovedBy = journalRS("ApprovedBy").Value.ToString
        SupervisorName = journalRS("SupervisorName").Value.ToString
        Tag1 = journalRS("Tag1").Value.ToString
        Tag2 = journalRS("Tag2").Value.ToString

        If CDbl(journalRS("DrAmount").Value.ToString) > 0 Then
            Amount = journalRS("DrAmount").Value.ToString
            DrAccountNo = journalRS("AccountNo").Value.ToString
            CrAccountNo = ""
        Else
            Amount = journalRS("CrAmount").Value.ToString
            DrAccountNo = ""
            CrAccountNo = journalRS("AccountNo").Value.ToString
        End If

    End Sub

End Class



