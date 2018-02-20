Public Class clsSysParam
    Public tblid As String
    Public paramname As String
    Public paramvalue As String
    Public encrypted As String
    Public remarks As String

    Public rowstatus As String
    Public cb As String
    Public cdt As String
    Public lub As String
    Public ludt As String

    Public Status As Boolean

    Dim dataRS As ADODB.Recordset

    Public Sub New()
        resetAll()
    End Sub

    Public Sub resetAll()
        tblid = -1
        paramname = ""
        paramvalue = ""
        encrypted = ""
        remarks = ""

        rowstatus = ""
        cb = ""
        cdt = ""
        lub = ""
        ludt = ""

        Status = False
    End Sub

    Public Sub loadSingleSysParam()
        On Error GoTo errH

        Status = False

        If tblid <> "" Then
            ssql = "select * from tblsysparams where tblid=" & tblid
        Else
            resetAll()
            Exit Sub
        End If

        dataRS = getQueryRecordset(ssql)

        If dataRS.EOF = True Then
            Status = False
            MsgBox("clsSysParam/loadSingleSysParam: No Sys Param found for tblid=" & tblid)
            Exit Sub
        End If

        tblid = dataRS("tblid").Value.ToString

        paramname = dataRS("paramname").Value.ToString
        paramvalue = dataRS("paramvalue").Value.ToString

        encrypted = dataRS("encrypted").Value.ToString
        remarks = dataRS("remarks").Value.ToString


        rowstatus = dataRS("rowstatus").Value.ToString
        cb = dataRS("cb").Value.ToString
        cdt = formatInt2DateTime(dataRS("cdt").Value.ToString)
        lub = dataRS("lub").Value.ToString
        ludt = formatInt2DateTime(dataRS("ludt").Value.ToString)


        dataRS.Close()
        releaseObject(dataRS)

        Status = True

        Exit Sub

errH:
        gErrDesc = Err.Description
        If gErrDesc <> "" Then MsgBox(gErrDesc)
    End Sub

    Public Sub createSysParam()
        On Error GoTo errH

        Status = False

        ssql = "Insert into tblsysparams (paramname,paramvalue,encrypted,remarks,rowstatus,cb,cdt,lub,ludt) values ("

        ssql = ssql & "'" & Trim(paramname) & "',"
        If encrypted.ToUpper.Equals("N") Then
            ssql = ssql & "'" & Replace(Trim(paramvalue), "\", "\\") & "',"
        Else
            ssql = ssql & "'" & Trim(paramvalue) & "',"
        End If
        ssql = ssql & "'" & Trim(encrypted.ToUpper) & "',"


        ssql = ssql & "'" & Replace(Trim(remarks), "'", "''") & "',"

        ssql = ssql & "null,'" & gLoginID & "'," & DateTime.Parse(Now).ToString(DB_DATETIMEFORMAT) & ",null,null)"

        gcon.Execute(ssql)

        Status = True
        Exit Sub

errH:
        gErrDesc = Err.Description
        If gErrDesc <> "" Then MsgBox(gErrDesc)
    End Sub

    Public Sub updateSysParam()
        On Error GoTo errH

        Status = False

        'Update in tblreceipt
        ssql = "Update tblsysparams set " '(paramname,paramvalue,encrypted,remarks,rowstatus,cb,cdt,lub,ludt) values ("

        ssql = ssql & " paramname='" & Trim(paramname) & "'"
        If encrypted.ToUpper.Equals("N") Then
            ssql = ssql & " ,paramvalue='" & Replace(Trim(paramvalue), "\", "\\") & "'"
        Else
            ssql = ssql & " ,paramvalue='" & Trim(paramvalue) & "'"
        End If

        ssql = ssql & " ,encrypted='" & Trim(encrypted.ToUpper) & "'"

        ssql = ssql & " ,remarks='" & Replace(Trim(remarks), "'", "''") & "'"

        If rowstatus = "" Then
            ssql = ssql & " ,rowstatus=null"
        Else
            ssql = ssql & " ,rowstatus='" & rowstatus & "'"
        End If
        ssql = ssql & " ,lub='" & gLoginID & "'"
        ssql = ssql & " ,ludt=" & DateTime.Parse(Now).ToString(DB_DATETIMEFORMAT)

        ssql = ssql & " where tblid=" & tblid

        gcon.Execute(ssql)

        Status = True
        Exit Sub

errH:
        gErrDesc = Err.Description
        If gErrDesc <> "" Then MsgBox(gErrDesc)
    End Sub
    Public Sub deleteSysParam()
        rowstatus = "D"
        updateSysParam()
    End Sub
End Class


