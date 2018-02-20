Public Class clsSendSMS_Cult

    ''TEMPLATES
    ''Dear XXXX Maintenance bill for flat XXXX generated. Bill Amount:Rs XXXX Due date: XXXX -GFH HIG Association

    ''Dear XXXX receipt# XXXX dtd XXXX issued to flat XXXX for your payment of Rs XXXX (Chq# XXXX dtd XXXX Bank: XXXX ) -GFH HIG Association

    ''Dear XXXX receipt# XXXX dtd. XXXX issued to flat XXXX for your payment of Rs XXXX by cash -GFH HIG Association

    ''Dear XXXX receipt# XXXX dtd XXXX issued to flat XXXX for your payment of Rs XXXX (Ref: XXXX Date: XXXX ) -GFH HIG Association

    ''Dear XXXX Chq# XXXX dtd XXXX bank: XXXX Amount:Rs XXXX returned by bank. Receipt# XXXX stands cancelled for flat XXXX -GFH HIG Association 

    ''Dear XXXX Case# XXXX dtd XXXX bank: XXXX Amount:Rs XXXX returned by bank. Receipt# XXXX stands cancelled for flat XXXX -GFH HIG Association

    ''Dear XXXX request for XXXX work flat XXXX registered with case# XXXX dtd XXXX & assigned to XXXX Pending case b4 this: XXXX

    ''Dear XXXX request for XXXX work flat XXXX case# XXXX is completed by XXXX dtd XXXX

    ''Attention! Work Assigned - XXXX work flat XXXX case# XXXX dtd XXXX & assigned to you XXXX

    ''Dear XXXX THIS IS A GENTLE REMINDER: XXXX IS XXXX

    Private strUrl As String
    Private strUID As String
    Private strPWD As String

    Public receipientNo As String
    Public msg As String
    Private msgType As String
    Public msgID As String
    Private strResp As String


    Public Function sendSMS() As Boolean
        On Error GoTo errH

        Dim tmpErrDesc As String

        sendSMS = False

        If receipientNo = "" Then
            logError("Error in clsSendSMS_Cult.sendSMS(): SMS was not sent because :No number registered", "Number:" & receipientNo, "Message:" & msg, "", "")
            MsgBox("SMS was not sent because :No number registered")
            Exit Function
        End If

        If IsNumeric(receipientNo) = False Then
            logError("Error in clsSendSMS_Cult.sendSMS(): SMS was not sent because :Invalid number", "Number:" & receipientNo, "Message:" & msg, "", "")
            MsgBox("SMS was not sent because :Invalid number " & receipientNo)
            Exit Function
        End If

        If Left(receipientNo, 1) <> "0" Then receipientNo = "0" & receipientNo

        'msg = "Dear S M Roychoudhury, receipt#9985 dtd 29May13 issued to flat SAP17C for your payment of Rs 2678/-(Ref:11111111111 Date:21Jun13) -GFH HIG Association"
        strUrl = getSysParamValue("SMSAPI")
        strUID = getSysParamValue("SMSUID")
        strPWD = getSysParamValue("SMSPWD")
        strUrl = Replace(strUrl, "***UID***", strUID)
        strUrl = Replace(strUrl, "***PWD***", strPWD)
        strUrl = Replace(strUrl, "***RECEIPIENTNO***", receipientNo)
        'msg = InputBox("Enter new msg value")
        strUrl = Replace(strUrl, "***MESSAGE***", msg)
        strUrl = Replace(strUrl, "***SENDERID***", "GFHHIG")

        'strUrl = http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=uid:pwd&senderID=TEST SMS&receipientno=9830721404&msgtxt=This is a test from mVaayoo API&state=4

        If DoWebRequest(strUrl) = False Then Exit Function

        If InStr(UCase(strResp), "STATUS=0") = 0 Then
            logError("Error in clsSendSMS_Cult.DoWebRequest(): SMS was not sent because: " & strResp, "Number:" & receipientNo, "Message:" & msg, "", "")
            MsgBox("SMS was not sent because: " & strResp)
            Exit Function
        End If

        'Keep a log of all SMS sent
        logSMS(receipientNo, msg, msgType, msgID)

        sendSMS = True
        Exit Function

errH:
        tmpErrDesc = Err.Description
        logError("Error in clsSendSMS_Cult.DoWebRequest(): " & tmpErrDesc, "Number:" & receipientNo, "Message:" & msg, "", "")
        MsgBox(tmpErrDesc)
    End Function

    'Do web Request Function
    Private Function DoWebRequest(url) As Boolean
        On Error GoTo errH

        DoWebRequest = False
        strResp = ""

        Dim objXML As Object, tmpErrDesc As String
        objXML = CreateObject("Microsoft.XMLHTTP")
        objXML.Open("GET", url, False)
        objXML.Send()

        strResp = objXML.ResponseText

        objXML = Nothing

        DoWebRequest = True

        Exit Function

errH:
        tmpErrDesc = Err.Description
        logError("Error in clsSendSMS_Cult.DoWebRequest(): " & tmpErrDesc, "Number:" & receipientNo, "Message:" & msg, "Response Code:" & strResp, "")
        MsgBox(tmpErrDesc)
        Exit Function
    End Function


    Function sendSMS4Receipt(rcpt_no As String) As Boolean
        On Error GoTo errH
        Dim indx As Integer, rcptDate As String, instrDate As String, PrimaryOwnerName As String, tmpBankName As String = "", tempArr() As String, i As Integer, instrNo As String, ret1 As String
        Dim chkPoint As Boolean = False, thisErr As String

        Dim myReceipt As New clsReceipt_Cult
        sendSMS4Receipt = False

        msgType = "RECEIPT"

        With myReceipt

            .loadSingleReceipt("", rcpt_no, "")
            If .Status = False Then Exit Function

            indx = gFlats.getArrayIndex(.FlatCode)
            rcptDate = DateTime.Parse(.ReceiptDate).ToString("ddMMMyy")
            instrDate = .InstrumentDate
            If Len(instrDate) = 8 Then instrDate = DateTime.Parse(.InstrumentDate).ToString("ddMMMyy")
            tempArr = Split(gFlats.allFlats(indx).OwnerFullName, " ")
            PrimaryOwnerName = tempArr(UBound(tempArr)) ' the last portion in full
            For i = UBound(tempArr) - 1 To 1 Step -1 ' exclude initial Mr. make sure all name starts with a salutation
                PrimaryOwnerName = myLeft(tempArr(i), 1).ToUpper & " " & PrimaryOwnerName
            Next

            tempArr = Split(.InstrumentBank, " ")
            If tempArr.Length = 1 Then
                tmpBankName = Trim(.InstrumentBank)
            Else
                For i = 0 To tempArr.Length - 1
                    tmpBankName = tmpBankName & myLeft(tempArr(i), 1).ToUpper
                Next
            End If

            instrNo = stripLeadingZero(.InstrumentNo)

            If .InstrumentType = "CHEQUE" Then
                msg = "Dear " & PrimaryOwnerName & ", receipt# " & .ReceiptNo & " dtd " & rcptDate & " issued to flat " & .FlatCode & " for your payment of Rs " & .ReceiptAmount & "/- (Chq# " & instrNo & " dtd " & instrDate & " Bank: " & tmpBankName & " )  -GFH HIG Association"
            ElseIf .InstrumentType = "ONLINE" Then
                msg = "Dear " & PrimaryOwnerName & ", receipt# " & .ReceiptNo & " dtd " & rcptDate & " issued to flat " & .FlatCode & " for your payment of Rs " & .ReceiptAmount & "/- (Ref: " & instrNo & " Date: " & instrDate & " )  -GFH HIG Association"
            ElseIf .InstrumentType = "CASH" Then
                msg = "Dear " & PrimaryOwnerName & ", receipt# " & .ReceiptNo & " dtd. " & rcptDate & " issued to flat " & .FlatCode & " for your payment of Rs " & .ReceiptAmount & "/- by cash -GFH HIG Association"
            End If


            receipientNo = gFlats.allFlats(indx).mobile1
            ret1 = isSMSAlreadySent(msgType, .ReceiptNo, receipientNo)

            If ret1 = "Y" Then
                If MsgBox("SMS already sent to:" & receipientNo & " for receipt:" & .ReceiptNo & ". Click Yes if you want to send it again, else click No", vbYesNo) = vbNo Then
                    Exit Function
                End If
            ElseIf ret1 = "" Then 'error
                Exit Function
            End If

        End With

        chkPoint = True
        sendSMS4Receipt = sendSMS()
        Exit Function

errH:
        thisErr = Err.Description
        MsgBox(thisErr)
        If chkPoint = False Then
            logError("Error in clsSendSMS_Cult.sendSMS4Receipt(): " & thisErr, "Number:" & receipientNo, "ReceiptNo:" & rcpt_no, "Flat:" & myReceipt.FlatCode, "")
        End If

    End Function

    '    Function sendSMS4Bill(billMonth As String, flatCode As String, billNo As String, dueDate As String) As Boolean
    '        '' Dear XXXX Maintenance bill of XXXX for flat XXXX generated. Due date: XXXX -GFH HIG Association

    '        On Error GoTo errH
    '        Dim indx As Integer, PrimaryOwnerName As String, tempArr() As String, i As Integer, ret1 As String
    '        Dim chkPoint As Boolean = False, thisErr As String

    '        sendSMS4Bill = False

    '        msgType = "BILL"

    '        indx = gFlats.getArrayIndex(flatCode)
    '        dueDate = DateTime.Parse(dueDate).ToString("ddMMMyy")

    '        tempArr = Split(gFlats.allFlats(indx).OwnerFullName, " ")
    '        PrimaryOwnerName = tempArr(UBound(tempArr)) ' the last portion in full
    '        For i = UBound(tempArr) - 1 To 1 Step -1 ' exclude initial Mr. make sure all name starts with a salutation
    '            PrimaryOwnerName = myLeft(tempArr(i), 1).ToUpper & " " & PrimaryOwnerName
    '        Next

    '        msg = "Dear " & PrimaryOwnerName & ", Maintenance bill of " & billMonth & " for flat " & flatCode & " generated. Due date: " & dueDate & " -GFH HIG Association"

    '        receipientNo = gFlats.allFlats(indx).mobile1
    '        ret1 = isSMSAlreadySent(msgType, billNo, receipientNo)

    '        If ret1 = "Y" Then
    '            If MsgBox("SMS already sent to:" & receipientNo & " for bill:" & billNo & ". Click Yes if you want to send it again, else click No", vbYesNo) = vbNo Then
    '                Exit Function
    '            End If
    '        ElseIf ret1 = "" Then 'error
    '            Exit Function
    '        End If

    '        chkPoint = True
    '        sendSMS4Bill = sendSMS()
    '        Exit Function

    'errH:
    '        thisErr = Err.Description
    '        MsgBox(thisErr)
    '        If chkPoint = False Then
    '            logError("Error in clsSendSMS_Cult.sendSMS4Bill(): " & thisErr, "Number:" & receipientNo, "BillNo:" & billNo, "Flat:" & flatCode, "")
    '        End If
    '    End Function



    '    Function sendSMS4Case(case_no As String) As Boolean
    '        On Error GoTo errH
    '        Dim indx As Integer, rcptDate As String, instrDate As String, PrimaryOwnerName As String, tmpBankName As String = "", tempArr() As String, i As Integer, instrNo As String, ret1 As String
    '        Dim chkPoint As Boolean = False, thisErr As String, tmpSql As String, tmpflatcode As String, tmpCaseDate As String, tmpCaseStatus As String, tmpCaseType As String, tmpLogTimePosition As Integer
    '        Dim tmpAssignedTo As String, msg2 As String = ""

    '        sendSMS4Case = False

    '        msgType = "CASE"

    '        tmpSql = "select * from tblservicerequest where CaseNo='" & case_no & "'"
    '        tmpRS = gcon.Execute(tmpSql)
    '        If tmpRS.EOF = True Then
    '            Exit Function
    '        End If
    '        tmpflatcode = tmpRS("FlatCode").Value.ToString
    '        tmpCaseType = tmpRS("CaseType").Value.ToString

    '        tmpLogTimePosition = tmpRS("LogTimePosition").Value.ToString
    '        tmpAssignedTo = tmpRS("CaseAssignedTo").Value.ToString
    '        tmpCaseStatus = tmpRS("Status").Value.ToString



    '        indx = gFlats.getArrayIndex(tmpflatcode)

    '        tempArr = Split(gFlats.allFlats(indx).OwnerFullName, " ")
    '        PrimaryOwnerName = tempArr(UBound(tempArr)) ' the last portion in full
    '        For i = UBound(tempArr) - 1 To 1 Step -1 ' exclude initial Mr. make sure all name starts with a salutation
    '            PrimaryOwnerName = myLeft(tempArr(i), 1).ToUpper & " " & PrimaryOwnerName
    '        Next
    '        ''Dear XXXX request for XXXX work flat XXXX registered with case# XXXX dtd XXXX & assigned to XXXX Pending case b4 this: XXXX
    '        ''Dear XXXX request for XXXX work flat XXXX case# XXXX is completed by XXXX dtd XXXX
    '        ''Attention! Work Assigned - XXXX work flat XXXX registered with case# XXXX dtd XXXX & assigned to you XXXX

    '        If tmpCaseStatus = "CLOSED" Then
    '            tmpCaseDate = formatInt2Date(tmpRS("CaseCompleteDate").Value.ToString) & " " & formatInt2Time(tmpRS("CaseCompleteTime").Value.ToString)

    '            msg = "Dear " & PrimaryOwnerName & ", request for " & tmpCaseType & " work flat " & tmpflatcode & " case# " & case_no & " is completed by " & tmpAssignedTo & " dtd " & tmpCaseDate

    '        ElseIf tmpCaseStatus = "OPEN" Then
    '            tmpCaseDate = formatInt2Date(tmpRS("CaseLogDate").Value.ToString) & " " & formatInt2Time(tmpRS("CaseLogTime").Value.ToString)

    '            msg = "Dear " & PrimaryOwnerName & ", request for " & tmpCaseType & " work flat " & tmpflatcode & " registered with case# " & case_no & " dtd " & tmpCaseDate & " %26 assigned to " & tmpAssignedTo & ". Pending case b4 this%3A " & (tmpLogTimePosition - 1)
    '            msg2 = "Attention! Work Assigned - " & tmpCaseType & " work flat " & tmpflatcode & " case# " & case_no & " dtd " & tmpCaseDate & " %26 assigned to you (" & tmpAssignedTo & ")"

    '        ElseIf tmpCaseStatus = "HOLD" Then
    '            'TBD
    '            MsgBox("TBD:Not implemented yet: SMS not allowed for HOLD")
    '            Exit Function
    '        Else
    '            Exit Function
    '        End If

    '        'send sms to requestor
    '        receipientNo = gFlats.allFlats(indx).mobile1
    '        ret1 = isSMSAlreadySent(msgType, case_no & "-" & tmpCaseStatus, receipientNo)

    '        If ret1 = "Y" Then
    '            If MsgBox("SMS already sent to: " & receipientNo & " for case: " & case_no & "-" & tmpCaseStatus & ". Click Yes if you want to send it again, else click No", vbYesNo) = vbYes Then
    '                chkPoint = True
    '                sendSMS4Case = sendSMS()
    '            End If
    '        ElseIf ret1 = "N" Then
    '            chkPoint = True
    '            sendSMS4Case = sendSMS()
    '        ElseIf ret1 = "" Then 'error
    '            Exit Function
    '        End If

    '        tmpRS.Close()
    '        'send sms to assigned to

    '        chkPoint = False
    '        If tmpCaseStatus = "OPEN" Then
    '            tmpSql = "select TMMobileNo from tblserviceteam where TMName='" & tmpAssignedTo & "'"
    '            tmpRS = gcon.Execute(tmpSql)
    '            If tmpRS.EOF = True Then
    '                Exit Function
    '            End If
    '            receipientNo = tmpRS("TMMobileNo").Value.ToString
    '            If receipientNo <> "" Then
    '                msg = msg2

    '                ret1 = isSMSAlreadySent(msgType, case_no & "-" & tmpCaseStatus, receipientNo)

    '                If ret1 = "Y" Then
    '                    If MsgBox("SMS already sent to: " & receipientNo & "(" & tmpAssignedTo & ") for case: " & case_no & "-" & tmpCaseStatus & ". Click Yes if you want to send it again, else click No", vbYesNo) = vbYes Then
    '                        chkPoint = True
    '                        sendSMS4Case = sendSMS()
    '                    End If
    '                ElseIf ret1 = "N" Then
    '                    chkPoint = True
    '                    sendSMS4Case = sendSMS()
    '                ElseIf ret1 = "" Then 'error
    '                    Exit Function
    '                End If
    '            End If
    '        End If

    '        Exit Function

    'errH:
    '        thisErr = Err.Description
    '        MsgBox(thisErr)
    '        If chkPoint = False Then
    '            logError("Error in clsSendSMS_Cult.sendSMS4Case(): " & thisErr, "Number:" & receipientNo, "CaseNo:" & case_no, "Flat:" & tmpflatcode, "")
    '        End If

    '    End Function
    Function sendSMS4Reminder(reminderType As String, flatCode As String, XXXX2 As String, XXXX3 As String) As Boolean
        '' Dear XXXX THIS IS A GENTLE REMINDER: XXXX IS XXXX 

        On Error GoTo errH
        Dim indx As Integer, PrimaryOwnerName As String, tempArr() As String, i As Integer, ret1 As String
        Dim chkPoint As Boolean = False, thisErr As String

        sendSMS4Reminder = False

        msgType = reminderType

        indx = gFlats.getArrayIndex(flatCode)

        tempArr = Split(gFlats.allFlats(indx).OwnerFullName, " ")
        PrimaryOwnerName = tempArr(UBound(tempArr)) ' the last portion in full
        For i = UBound(tempArr) - 1 To 1 Step -1 ' exclude initial Mr. make sure all name starts with a salutation
            PrimaryOwnerName = myLeft(tempArr(i), 1).ToUpper & " " & PrimaryOwnerName
        Next
        PrimaryOwnerName = PrimaryOwnerName.ToUpper
        msg = "Dear XXXX1 THIS IS A GENTLE REMINDER: XXXX2 IS XXXX3"
        msg = msg.Replace("XXXX1", PrimaryOwnerName & ",")
        msg = msg.Replace("XXXX2", XXXX2)
        msg = msg.Replace("XXXX3", XXXX3)

        receipientNo = gFlats.allFlats(indx).mobile1
        ret1 = isSMSAlreadySent(msgType, msgID, receipientNo)

        If ret1 = "Y" Then
            If MsgBox("SMS already sent to:" & receipientNo & " for reminder:" & msgID & ". Click Yes if you want to send it again, else click No", vbYesNo) = vbNo Then
                Exit Function
            End If
        ElseIf ret1 = "" Then 'error
            Exit Function
        End If

        chkPoint = True
        sendSMS4Reminder = sendSMS()
        Exit Function

errH:
        thisErr = Err.Description
        MsgBox(thisErr)
        If chkPoint = False Then
            logError("Error in clsSendSMS_Cult.sendSMS4Reminder(): " & thisErr, "Number:" & receipientNo, "MsgType:" & msgType, "Flat:" & flatCode, "")
        End If
    End Function
End Class

