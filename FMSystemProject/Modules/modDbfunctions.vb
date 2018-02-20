Module modDbfunctions


    Function logUserActivity() As Boolean
        On Error GoTo errH
        logUserActivity = False

        Dim tmpSql As String
        tmpSql = "Insert into tbluseractivity (ItemCode,ItemID,ItemAction,ActionDate,ActionTime,ActionBy) VALUES( "
        tmpSql = tmpSql & "'" & gItemCode & "','" & gItemID & "','" & gItemAction & "'," & DateTime.Now.ToString(DB_DATEFORMAT) & ",'" & DateTime.Now.ToString(DB_TIMEFORMAT) & "','" & gLoginID & "')"

        gcon.Execute(tmpSql)

        logUserActivity = True
        Exit Function
errH:
        MsgBox(Err.Description)
    End Function
    Function logError(errorText As String, key1 As String, key2 As String, key3 As String, key4 As String) As Boolean
        On Error GoTo errH
        logError = False

        Dim tmpSql As String
        tmpSql = "Insert into tblerror (errorDate,errorTime,LoginID,ErrorText,key1,key2,key3,key4) VALUES( "
        tmpSql = tmpSql & Now.ToString(DB_DATEFORMAT) & "," & Now.ToString(DB_TIMEFORMAT) & ",'" & gLoginID & "','" & Replace(errorText, "'", "''") & "'"
        tmpSql = tmpSql & ",'" & key1 & "'"
        tmpSql = tmpSql & ",'" & key2 & "'"
        tmpSql = tmpSql & ",'" & key3 & "'"
        tmpSql = tmpSql & ",'" & key4 & "'"
        tmpSql = tmpSql & ")"


        gcon.Execute(tmpSql)

        logError = True
        Exit Function
errH:
        MsgBox(Err.Description)
    End Function
    Function logSMS(sentTo As String, smsText As String, msgType As String, msgID As String) As Boolean
        On Error GoTo errH
        logSMS = False

        Dim tmpSql As String
        tmpSql = "Insert into tblsmslog (sentTo,smsText,sendDate,sendTime,LoginID,msgType,msgID) VALUES( "
        tmpSql = tmpSql & stripLeadingZero(sentTo) & ",'" & Replace(smsText, "'", "''") & "','"
        tmpSql = tmpSql & Now.ToString(DB_DATEFORMAT) & "','" & Now.ToString(DB_TIMEFORMAT) & "','" & gLoginID & "'" & ",'" & msgType & "'" & ",'" & msgID & "'"
        tmpSql = tmpSql & ")"


        gcon.Execute(tmpSql)

        logSMS = True
        Exit Function
errH:
        MsgBox(Err.Description)
    End Function

    Function isSMSAlreadySent(msgType As String, msgID As String, sentTo As String) As String
        On Error GoTo errH
        Dim smsRS As ADODB.Recordset, tmpsql As String

        isSMSAlreadySent = ""
        tmpsql = "select count(*) as cnt from tblsmslog where msgType='" & msgType & "' and msgID='" & msgID & "' and sentTo='" & stripLeadingZero(sentTo) & "'"
        smsRS = gcon.Execute(tmpsql)
        If smsRS("cnt").Value.ToString <> "" And smsRS("cnt").Value.ToString > 0 Then
            isSMSAlreadySent = "Y"
        Else
            isSMSAlreadySent = "N"
        End If
        smsRS.Close()

        Exit Function
errH:
        MsgBox(Err.Description)
    End Function

    Sub getRolePermission()
        Dim tmpRS1 As ADODB.Recordset, tmpSql As String = ""

        tmpSql = "select rc.canView, rc.canCreate, rc.canEdit, rc.canDelete from tblmap_role_component rc, tblcomponents c "
        tmpSql = tmpSql & " where rc.ComponentID=c.tblid "
        tmpSql = tmpSql & " and rc.RoleID in (" & gRoleID & ")"
        tmpSql = tmpSql & " and c.ComponentName='" & gItemCode & "'"

        tmpRS1 = gcon.Execute(tmpSql)
        If tmpRS1.EOF = True Then
            gCanView = "N"
            gCanCreate = "N"
            gCanEdit = "N"
            gCanDelete = "N"
            Exit Sub
        End If
        gCanView = tmpRS1("canView").Value.ToString
        gCanCreate = tmpRS1("canCreate").Value.ToString
        gCanEdit = tmpRS1("canEdit").Value.ToString
        gCanDelete = tmpRS1("canDelete").Value.ToString
        tmpRS1.Close()
    End Sub
    
    Function getUserEmail(fullname As String) As String
        Dim tmpRS1 As ADODB.Recordset

        tmpRS1 = gcon.Execute("select Email from tblusers where FullName='" & fullname & "'")
        If tmpRS1.EOF = True Then
            getUserEmail = ""
        Else
            getUserEmail = tmpRS1("Email").Value.ToString
        End If
       
        tmpRS1.Close()
    End Function
    Function isMemberOfRole(loginid As String, rolecode As String) As Boolean
        Dim tmpRS1 As ADODB.Recordset, tmpsql As String
        isMemberOfRole = False
        tmpsql = "select ru.tblid from tblmap_role_user ru, tblusers u, tblroles r where r.Status='A' and r.tblid=ru.RoleID and ru.UserID=u.tblid and r.RoleCode = '" & rolecode & "' and u.LoginID='" & loginid & "'"
        tmpRS1 = gcon.Execute(tmpsql)
        If tmpRS1.EOF = False Then
            isMemberOfRole = True
        End If

        tmpRS1.Close()
    End Function
    Sub getBankNames()
        Dim tmpRS1 As ADODB.Recordset
        ReDim BankNames(0)
        tmpRS1 = gcon.Execute("select distinct InstrumentBank from tblreceipt")

        While tmpRS1.EOF = False
            ReDim Preserve BankNames(UBound(BankNames) + 1)
            BankNames(UBound(BankNames)) = tmpRS1("InstrumentBank").Value.ToString
            tmpRS1.MoveNext()
        End While

        tmpRS1.Close()

    End Sub
    Sub getBankNames_Cult()
        Dim tmpRS1 As ADODB.Recordset
        ReDim BankNames(0)
        tmpRS1 = gcon.Execute("select distinct InstrumentBank from tblreceipt_cult")

        While tmpRS1.EOF = False
            ReDim Preserve BankNames(UBound(BankNames) + 1)
            BankNames(UBound(BankNames)) = tmpRS1("InstrumentBank").Value.ToString
            tmpRS1.MoveNext()
        End While

        tmpRS1.Close()

    End Sub



    Function getOutstandingForFlat() As Double
        On Error GoTo errH
        Dim outstandingRS As ADODB.Recordset
        ssql = "select sum(DrAmount-CrAmount) as netAmt from tbljournal where Status is null and AccountNo='DEBTOR-FLAT-" & gCurFlatCode & "'"
        outstandingRS = gcon.Execute(ssql)
        getOutstandingForFlat = CDbl(outstandingRS("netAmt").Value.ToString)
        outstandingRS.Close()
        Exit Function
errH:
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Function

    Function getBankAccountsAsString() As String
        Dim actRS1 As ADODB.Recordset, tmpStr As String = ""

        getBankAccountsAsString = ""
        ssql = "select AccountNo from tblaccounts where Status='A' and LeafAccount='Y' and AccountType='Assets' and ParentAccountNo = 'CASH-AT-BANK'"
        actRS1 = gcon.Execute(ssql)
        While actRS1.EOF = False
            tmpStr = tmpStr & ",'" & actRS1("AccountNo").Value.ToString & "'"
            actRS1.MoveNext()
        End While
        If tmpStr <> "" Then getBankAccountsAsString = myRight(tmpStr, Len(tmpStr) - 1)
        actRS1.Close()
    End Function

    Function getAccountBalance(asofDate As String, accountNo As String) As String
        Dim actRS1 As ADODB.Recordset
        getAccountBalance = ""
        ssql = "select sum(DrAmount-CrAmount) as netAmt from tbljournal where status is null and AccountNo = '" & accountNo & "' and TxnDate <= '" & DateTime.Parse(asofDate).ToString(DB_DATEFORMAT) & "'"
        actRS1 = gcon.Execute(ssql)
        getAccountBalance = actRS1("netAmt").Value.ToString
        actRS1.Close()
    End Function
    Function getAccountBalance_Cult(asofDate As String, accountNo As String) As String
        Dim actRS1 As ADODB.Recordset
        getAccountBalance_Cult = ""
        ssql = "select sum(DrAmount-CrAmount) as netAmt from tbljournal_cult where status is null and AccountNo = '" & accountNo & "' and TxnDate <= '" & DateTime.Parse(asofDate).ToString(DB_DATEFORMAT) & "'"
        actRS1 = gcon.Execute(ssql)
        getAccountBalance_Cult = actRS1("netAmt").Value.ToString
        actRS1.Close()
    End Function

    Function getRefDetailsFromGid(gid As String, glTableName As String) As String
        Dim actRS1 As ADODB.Recordset

        getRefDetailsFromGid = ""

        If gid = "" Or gid = "-" Then Exit Function

        ssql = "select AccountNo,VoucherNo, Narration,DocRef from " & glTableName & " where refgid= '" & gid & "' and DrAmount>0"
        actRS1 = gcon.Execute(ssql)

        While actRS1.EOF = False 'case of 1 to many reconciliation
            getRefDetailsFromGid = getRefDetailsFromGid & "~~" & actRS1("AccountNo").Value.ToString & "^^" & actRS1("VoucherNo").Value.ToString & "^^" & actRS1("DocRef").Value.ToString & "^^" & actRS1("Narration").Value.ToString
            
            actRS1.MoveNext()
        End While

        getRefDetailsFromGid = Right(getRefDetailsFromGid, Len(getRefDetailsFromGid) - 2)

        actRS1.Close()
    End Function
    Function getMultiReceiptNarrationFromRefGid(gid As String, glTableName As String) As String
        Dim actRS1 As ADODB.Recordset, cd As New clsDocRef

        getMultiReceiptNarrationFromRefGid = ""

        If gid = "" Or gid = "-" Then Exit Function

        ssql = "select  DocRef,Narration from " & glTableName & " where refgid= '" & gid & "' and CrAmount>0"
        actRS1 = gcon.Execute(ssql)

        While actRS1.EOF = False 'case of 1 to many reconciliation
            getMultiReceiptNarrationFromRefGid = getMultiReceiptNarrationFromRefGid & "~~" & cd.getReceiptNo(actRS1("DocRef").Value.ToString) & "^^" & actRS1("Narration").Value.ToString

            actRS1.MoveNext()
        End While

        getMultiReceiptNarrationFromRefGid = Right(getMultiReceiptNarrationFromRefGid, Len(getMultiReceiptNarrationFromRefGid) - 2)

        actRS1.Close()
    End Function

    Function getAccountNoFromGID(gid As String, DRorCR As String) As String
        Dim actRS1 As ADODB.Recordset

        getAccountNoFromGID = ""

        If gid = "" Or gid = "-" Then Exit Function

        If DRorCR = "CR" Then
            ssql = "select AccountNo from tbljournal where gid= '" & gid & "' and DrAmount=0"
            actRS1 = gcon.Execute(ssql)

            getAccountNoFromGID = actRS1("AccountNo").Value.ToString
        Else
            ssql = "select AccountNo from tbljournal where gid= '" & gid & "' and CrAmount=0"
            actRS1 = gcon.Execute(ssql)
            getAccountNoFromGID = actRS1("AccountNo").Value.ToString
        End If

        actRS1.Close()
    End Function
    Function getAccountName(strAccountNo As String) As String
        Dim tmpRS1 As ADODB.Recordset
        tmpRS1 = gcon.Execute("select AccountName from tblaccounts where AccountNo='" & strAccountNo & "'")
        If tmpRS1.EOF = True Then
            getAccountName = ""
        Else
            getAccountName = tmpRS1("AccountName").Value.ToString
        End If
        tmpRS1.Close()

    End Function

    Function getAccountsByAccountType(strAccountType As String) As String
        Dim tmpRS1 As ADODB.Recordset
        getAccountsByAccountType = "''"
        tmpRS1 = gcon.Execute("select AccountNo from tblaccounts where AccountType='" & strAccountType & "' and LeafAccount='Y' ")
        While tmpRS1.EOF = False
            getAccountsByAccountType = getAccountsByAccountType & ",'" & tmpRS1("AccountNo").Value.ToString & "'"
            tmpRS1.MoveNext()
        End While
        tmpRS1.Close()

    End Function
    Function getAccountsByParentAccountNo(strParentAccountNo As String, includeOnlyImmediateChilds As Boolean) As String
        Dim tmpRS1 As ADODB.Recordset
        getAccountsByParentAccountNo = "''"
        If includeOnlyImmediateChilds = True Then
            tmpRS1 = gcon.Execute("select AccountNo from tblaccounts where ParentAccountNo ='" & strParentAccountNo & "' and LeafAccount='Y' ")
        Else
            tmpRS1 = gcon.Execute("select AccountNo from tblaccounts where ParentAccountNo like'" & strParentAccountNo & "%' and LeafAccount='Y' ")
        End If
        While tmpRS1.EOF = False
            getAccountsByParentAccountNo = getAccountsByParentAccountNo & ",'" & tmpRS1("AccountNo").Value.ToString & "'"
            tmpRS1.MoveNext()
        End While
        tmpRS1.Close()

    End Function

    Function getDrORCrAccountNo(gid As String, DrORCr As String, glTableName As String) As String
        Dim tmpRS1 As ADODB.Recordset

        If DrORCr = "DR" Then
            tmpRS1 = gcon.Execute("select AccountNo from " & glTableName & " where DrAmount > 0 and gid='" & gid & "'")
        Else
            tmpRS1 = gcon.Execute("select AccountNo from " & glTableName & " where CrAmount > 0 and gid='" & gid & "'")
        End If

        If tmpRS1.EOF = True Then
            getDrORCrAccountNo = ""
        Else
            getDrORCrAccountNo = tmpRS1("AccountNo").Value.ToString
        End If
        tmpRS1.Close()

    End Function
    'Function GetRowCount(ByRef inRecordSet As ADODB.Recordset) As Long
    '    GetRowCount = 0
    '    inRecordSet.MoveFirst()
    '    While inRecordSet.EOF = False
    '        GetRowCount = GetRowCount + 1
    '        inRecordSet.MoveNext()
    '    End While
    '    inRecordSet.Requery()
    'End Function

    Function getSysParamValue(ByVal thisParamName As String) As String
        getSysParamValue = ""

        Dim i = gSysParams.FindIndex(Function(pname As structSysParams) (thisParamName.Equals(pname.paramname)))

        If i >= 0 Then
            If gSysParams(i).encrypted = "Y" Then
                getSysParamValue = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(gSysParams(i).paramvalue))
            Else
                getSysParamValue = gSysParams(i).paramvalue
            End If
        End If

    End Function
    Sub loadSysParams()
        On Error GoTo errH
        Dim rsSysParam As ADODB.Recordset, thisItem As New structSysParams

        gSysParams.Clear()
        rsSysParam = getQueryRecordset("select paramname,paramvalue,encrypted from tblsysparams where rowstatus is null")
        While rsSysParam.EOF = False
            thisItem.paramname = rsSysParam("paramname").Value.ToString
            thisItem.paramvalue = rsSysParam("paramvalue").Value.ToString
            thisItem.encrypted = rsSysParam("encrypted").Value.ToString

            gSysParams.Add(thisItem)

            rsSysParam.MoveNext()
        End While
        rsSysParam.Close()
        releaseObject(rsSysParam)

        releaseObject(thisItem)

        Exit Sub

errH:
        gErrDesc = Err.Description
        If gErrDesc <> "" Then MsgBox(gErrDesc)
        rsSysParam.Close()
        releaseObject(rsSysParam)
    End Sub

    Function isEmailBlocked(ByVal email As String) As Boolean
        Dim pSql As String = "", allEmails As String = "", eRS As ADODB.Recordset
        pSql = "select count(*) as cnt from tblflatowners fo where fo.blockedemails like '%" & Trim(email) & "%'"

        eRS = gcon.Execute(pSql)


        If Not DBNull.Value.Equals(eRS("cnt")) And eRS("cnt").Value > 0 Then
            isEmailBlocked = True
        Else
            isEmailBlocked = False
        End If

        eRS.Close()
    End Function
End Module
