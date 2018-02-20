Module modCommonFunctions


    Function SetConnection() As Boolean
        On Error GoTo errH
        Dim dsn As String = "", uid As String = "", pwd As String = "", dbname As String = ""
        Dim reader As New System.Configuration.AppSettingsReader

        SetConnection = False


        dsn = reader.GetValue("dsn", GetType(String))
        uid = reader.GetValue("uid", GetType(String))
        pwd = reader.GetValue("pwd", GetType(String))
        dbname = reader.GetValue("dbname", GetType(String))

        If gcon.State = 0 Then
            gcon.ConnectionString = "DSN=" & dsn & ";User ID=" & System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(uid)) & ";Password=" & System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(pwd))

            gcon.Mode = ADODB.ConnectModeEnum.adModeReadWrite
            gcon.Open()
            gcon.DefaultDatabase = dbname
        End If

        SetConnection = True
        Exit Function
errH:
        MsgBox(Err.Description)
    End Function
    Function SetConnection2() As Boolean
        On Error GoTo errH
        Dim dsn As String = "", uid As String = "", pwd As String = "", dbname As String = ""
        Dim reader As New System.Configuration.AppSettingsReader

        SetConnection2 = False
        If gcon2.State <> 0 Then gcon2.Close()

        dsn = reader.GetValue("dsn", GetType(String))
        uid = reader.GetValue("uid", GetType(String))
        pwd = reader.GetValue("pwd", GetType(String))
        dbname = reader.GetValue("dbname", GetType(String))

        If gcon2.State = 0 Then
            gcon2.ConnectionString = "DSN=" & dsn & ";User ID=" & System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(uid)) & ";Password=" & System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(pwd))

            gcon2.Mode = ADODB.ConnectModeEnum.adModeReadWrite
            gcon2.Open()
            gcon2.DefaultDatabase = dbname
        End If

        SetConnection2 = True
        Exit Function
errH:
        MsgBox(Err.Description)
    End Function
    Function CloseConnection() As Boolean
        On Error GoTo errH

        CloseConnection = False
        If gcon.State = 1 Then
            gcon.Close()
            gcon = Nothing
        End If
        CloseConnection = True
        Exit Function
errH:
        MsgBox(Err.Description)
    End Function

    Function adjNull(ByVal arg As Object) As String
        adjNull = CStr(arg)
    End Function
    Function adjDate(ByVal arg As Object) As String
        adjDate = arg & ""
        If adjDate <> "" Then
            adjDate = Format(arg, "dd-mmm-yyyy")
        End If
    End Function
    Function adjInt(ByVal arg As Object) As Integer
        arg = arg & ""
        If arg = "" Then
            adjInt = "0"
        Else
            adjInt = arg
        End If
    End Function
    Function adjLong(ByVal arg As Object) As Long
        arg = arg & ""
        If arg = "" Then
            adjLong = "0"
        Else
            adjLong = arg
        End If
    End Function

    Function adjDouble(ByVal arg As Object) As Double
        arg = arg & ""
        If arg = "" Then
            adjDouble = "0"
        Else
            adjDouble = arg
        End If
    End Function

    Function adjMoney(ByVal arg As Object) As Double
        arg = arg & ""
        If arg = "" Then
            adjMoney = "0"
        Else
            adjMoney = arg
        End If

        adjMoney = IIf(adjMoney = "0", 0, Format(adjMoney, "0.00"))

    End Function
    Function getQueryRecordset(ByVal QuerySQL As String) As ADODB.Recordset
        On Error GoTo errH
        Dim rs As New ADODB.Recordset
        'rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        'rs = getQueryRecordset(QuerySQL, )
        rs.Open(QuerySQL, gcon, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        getQueryRecordset = rs

        If getSysParamValue("ENABLE_SQL_LOGGING") = "Y" Then
            Dim tmpSql As String
            tmpSql = "Insert into tblsql (sqltext,sqlDT,sqlBy,componentname) VALUES( "
            tmpSql = tmpSql & "'" & Replace(QuerySQL, "'", "''") & "','" & DateTime.Now.ToString(DB_DATETIMEFORMAT) & "','" & gLoginID & "','" & gItemCode & "')"
            gcon.Execute(tmpSql)
        End If

        Exit Function

errH:
        MsgBox(Err.Description)

    End Function
    Function ExecuteSql(ByVal sqlString As String) As Boolean
        On Error GoTo errH
        ExecuteSql = False

        'Dim grecAffected As Long
        gcon.Execute(sqlString)

        'grecAffected = gcmd.ExecuteNonQuery

        '    If grecAffected = 0 Then
        '        MsgBox "No record updated/deleted"
        '    End If

        ExecuteSql = True
        Exit Function

errH:
        MsgBox(Err.Description)

    End Function

    '    Function ExecuteSql2(ByVal sqlString As String) As Integer
    '        On Error GoTo errH

    '        gcon.Execute(sqlString)
    '        ExecuteSql2 = gcmd.ExecuteNonQuery

    '        Exit Function

    'errH:
    '        MsgBox(Err.Description)

    '    End Function

    '    Function GetRecordset(ByVal sqlString As String) As ADODB.Recordset
    '        On Error GoTo errH

    '        gcon.Execute(sqlString)
    '        GetRecordset = gcmd.ExecuteReader

    '        Exit Function

    'errH:
    '        MsgBox(Err.Description)

    '    End Function

    Function addThousandSeparator(ByVal arg As Object, Optional ByVal stripFracPart As Boolean = False) As String
        On Error GoTo errH

        Dim intPart As String, fracPart As String, negativePart As String, decimalPointPos As Integer, out As String


        If IsNumeric(arg) = False Then
            addThousandSeparator = arg
            Exit Function
        End If

        arg = CStr(arg)

        negativePart = ""
        If Left(arg, 1) = "-" Then
            negativePart = "-"
            arg = Right(arg, Len(arg) - 1)
        End If

        intPart = arg
        fracPart = "00"

        decimalPointPos = InStr(1, arg, ".")
        If decimalPointPos > 0 Then
            intPart = Left(arg, decimalPointPos - 1)
            fracPart = Right(arg, Len(arg) - decimalPointPos)
        End If

        If Len(fracPart) = 1 Then fracPart = fracPart & "0"

        Select Case Len(intPart)
            Case 1 To 3
                out = intPart
            Case 4
                out = Mid(intPart, 1, 1) & "," & Mid(intPart, 2, 3)
            Case 5
                out = Mid(intPart, 1, 2) & "," & Mid(intPart, 3, 3)
            Case 6
                out = Mid(intPart, 1, 1) & "," & Mid(intPart, 2, 2) & "," & Mid(intPart, 4, 3)
            Case 7
                out = Mid(intPart, 1, 2) & "," & Mid(intPart, 3, 2) & "," & Mid(intPart, 5, 3)
            Case 8
                out = Mid(intPart, 1, 1) & "," & Mid(intPart, 2, 2) & "," & Mid(intPart, 4, 2) & "," & Mid(intPart, 6, 3)
            Case 9
                out = Mid(intPart, 1, 2) & "," & Mid(intPart, 3, 2) & "," & Mid(intPart, 5, 2) & "," & Mid(intPart, 7, 3)
            Case Else
                out = Mid(intPart, 1, Len(intPart) - 7) & "," & Mid(intPart, Len(intPart) - 6, 2) & "," & Mid(intPart, Len(intPart) - 4, 2) & "," & Mid(intPart, Len(intPart) - 2, 3)

        End Select

        If stripFracPart = True Then
            addThousandSeparator = negativePart & out
        Else
            addThousandSeparator = negativePart & out & "." & fracPart
        End If

        Exit Function

errH:
        MsgBox(Err.Description)
    End Function

    

    'Public Function leftPad(ByVal str As String, ByVal n As Integer) As String
    'leftPad = IIf(Len(str) < n, String(n - Len(str), " ") & str, str)
    'End Function

    'Public Function rightPad(ByVal str As String, ByVal n As Integer) As String
    'rightPad = IIf(Len(str) < n, str & String(n - Len(str), " "), str)
    'End Function

    'Sub copyListViewToGrid()

    '    With grd
    '        ReDim .row(0)
    '        ReDim .row(0).col(0)

    '        'copy header row
    '        ReDim Preserve .row(1)
    '        For j = 1 To gLV.ColumnHeaders.Count
    '            ReDim Preserve .row(1).col(j)
    '            .row(1).col(j) = gLV.ColumnHeaders(j).Text
    '        Next j
    '        'print data rows
    '        For i = 1 To gLV.ListItems.Count
    '            ReDim Preserve .row(i + 1)
    '            ReDim Preserve .row(i + 1).col(1)
    '            .row(i + 1).col(1) = gLV.ListItems(i).Text
    '            For j = 1 To gLV.ColumnHeaders.Count - 1
    '                ReDim Preserve .row(i + 1).col(j + 1)
    '                .row(i + 1).col(j + 1) = gLV.ListItems(i).SubItems(j)
    '            Next j
    '        Next i
    '    End With
    'End Sub

    '    Sub PrintGridToExcelSheet(ByVal inXlSht As Excel.Worksheet)
    '        On Error GoTo errH

    '        Dim i As Long, j As Long

    '        With grd

    '            'print grid rows
    '            For i = 1 To UBound(.row)
    '                For j = 1 To UBound(.row(i).col)
    '                    inXlSht.Cells(i + 1, j + 1) = .row(i).col(j)
    '                Next j
    '            Next i

    '        End With
    '        Exit Sub
    'errH:
    '        MsgBox(Err.Description)
    '    End Sub

    'Sub PrintListViewToExcelSheet(ByVal inXlSht As Excel.Worksheet)
    '    Call copyListViewToGrid()
    '    Call PrintGridToExcelSheet(inXlSht)
    'End Sub
    Sub reloadCache()
        loadSysParams()
        'loadUserList()
        'loadSkipUserList()
        'loadTaskTxnName()
        'loadTaskTxnFormat()
        'loadPMList()
        'loadWITypes()
        'loadWIStatus()

    End Sub
    
    Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Function getTowerName(flatcode As String) As String
        Dim tmpStr As String
        getTowerName = ""
        tmpStr = Left(flatcode, 3)
        Select Case tmpStr
            Case "SAP"
                getTowerName = "SAPTARSHI"
            Case "SAN"
                getTowerName = "SANDHYATARA"
            Case "SUK"
                getTowerName = "SUKTARA"
            Case "SHR"
                getTowerName = "SHROBONA"
        End Select
    End Function

    Function stripLeadingZero(inData As String) As String
        stripLeadingZero = inData.TrimStart("0"c)
    End Function

    Function gIsAllowedToViewModule(moduleName As String) As Boolean
        'standard entry check code start
        gIsAllowedToViewModule = False
        gItemCode = moduleName
        getRolePermission()
        If gCanView <> "Y" Then
            'gItemCode = "-"
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Function
        End If
        gIsAllowedToViewModule = True
        'standard entry check code end
    End Function

    Sub myMsgBox(msg As String)
        If Trim(msg) <> "" Then
            MsgBox(msg)
        End If
    End Sub
    Sub ExportGridToExcelSheet(ByVal dgv As DataGridView, showHiddenCols As Boolean)
        On Error GoTo errH

        Dim r As Long, c As Long, i As Integer = 0, h As Integer = 0, theGridCellVal As String = ""

        '-----------------
        Dim xlApp = New Microsoft.Office.Interop.Excel.Application
        Dim xlWrkBk As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWrkSht As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlWrkBk = xlApp.Workbooks.Add(misValue)
        While xlWrkBk.Sheets.Count > 1
            xlWrkSht = xlWrkBk.Sheets(1)
            xlWrkSht.Delete()
        End While
        xlWrkSht = xlWrkBk.Sheets(1)
        xlApp.Visible = True
        '-----------------
        'Export Header Names Start
        h = 0
        For Each column In dgv.Columns
            If showHiddenCols = True Then
                xlWrkSht.Cells(1, column.Index + 1).Value = column.HeaderText
            Else
                If column.Visible = True Then
                    h = h + 1
                    xlWrkSht.Cells(1, h).Value = column.HeaderText
                End If
            End If

        Next
        'xlWrkSht.Range("A1" & ":AA1").Select()
        'With xlApp.Selection
        '    .Font.Bold = True
        '    '.Font.Name = "Arial Narrow"
        '    .Font.Size = 10
        '    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        '    .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        '    '.WrapText = True
        'End With

        For i = 0 To dgv.RowCount - 1
            h = 0
            For j = 0 To dgv.ColumnCount - 1
                If dgv(j, i).Value = Nothing Then
                    theGridCellVal = ""
                Else
                    theGridCellVal = dgv(j, i).Value.ToString()
                End If

                If showHiddenCols = True Then
                    xlWrkSht.Cells(i + 2, j + 1) = theGridCellVal
                Else
                    If dgv.Columns(j).Visible = True Then
                        h = h + 1
                        xlWrkSht.Cells(i + 2, h) = theGridCellVal
                    End If
                End If
            Next
        Next
        'xlWrkSht.Columns("A:AA").EntireColumn.AutoFit()

        formatExcelSht(xlWrkSht, dgv.RowCount + 1)


        'If System.IO.File.Exists(exportPath) = True Then System.IO.File.Delete(exportPath)
        'xlWrkSht.SaveAs(exportPath)
        'xlWrkSht.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, exportPath & ".pdf", Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:=True)
        'xlWrkBk.Close()
        'xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWrkBk)
        releaseObject(xlWrkSht)
        Exit Sub
errH:
        MsgBox(Err.Description)
    End Sub
    Sub formatExcelSht(ByRef curSht As Microsoft.Office.Interop.Excel.Worksheet, Optional ByVal mr As Long = 0)
        Dim xlapp As Microsoft.Office.Interop.Excel.Application
        Dim x As Long, mc As String = "", ad1 As Object

        xlapp = curSht.Application

        If mr = 0 Then
            For x = 1 To 1000000
                If Trim(curSht.Cells(x, "A").Value) = "" Then
                    mr = x - 1
                    Exit For
                End If
            Next x
        End If

        For x = 1 To 100
            If Trim(curSht.Cells(1, x).Value) = "" Then
                ad1 = curSht.Cells(1, x - 1).Address
                mc = Mid(ad1, InStr(ad1, "$") + 1, InStr(2, ad1, "$") - 2)
                Exit For
            End If
        Next x

        curSht.Cells.Select()
        With xlapp.Selection.Font
            .Name = "Arial Narrow"
            .Size = 8
        End With

        curSht.Cells.Select()

        DrawBorder2(curSht, "A1:" & mc & "1", Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, False, True)
        DrawBorder2(curSht, "A2:" & mc & mr, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, False, False)


        xlapp.Selection.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter 'xlCenter

        curSht.Range("A1:" & mc & "1").Select()
        xlapp.Selection.AutoFilter()

        curSht.Range("A1:" & mc & "1").Select()
        xlapp.Selection.Font.Bold = True

        curSht.Cells.EntireColumn.AutoFit()
        xlapp.Selection.Rows.AutoFit()

        curSht.Range("A1").Select()

        xlapp.ActiveWindow.DisplayGridlines = False
        xlapp.DisplayAlerts = False

    End Sub
End Module
