Module modUtils


    'Function getMatchingRow(ByVal wsht As Worksheet, ByVal col As String, ByVal startRow As Integer, ByVal searchStr As String) As Long
    '    Dim x As Long
    '    For x = startRow To MAX_XL_ROWCOUNT
    '        If Trim(wsht.Range(col & x)) = searchStr Then
    '            getMatchingRow = x
    '            Exit Function
    '        End If
    '    Next x
    'End Function
    'Function getNextNonEmptyRow(ByVal wsht As Worksheet, ByVal col As String, ByVal currentRow As Integer) As Integer
    '    Dim x As Long
    '    For x = currentRow + 1 To MAX_XL_ROWCOUNT
    '        If Trim(wsht.Range(col & x)) <> "" Then
    '            getNextNonEmptyRow = x
    '            Exit Function
    '        End If
    '    Next x
    'End Function

    Public Function getToken(thisStr As String, keyStr As String, delStr As String) As String
        Dim pos1 As Integer, pos2 As Integer
        pos1 = 0
        pos2 = 0
        getToken = ""

        pos1 = InStr(1, thisStr, keyStr)
        If pos1 > 0 Then
            pos2 = InStr(pos1 + Len(keyStr), thisStr, delStr)
            If pos2 = 0 Then 'last token, so no delimiter at end
                getToken = Trim(Right(thisStr, Len(thisStr) - pos1 - Len(keyStr) + 1))
            Else
                getToken = Trim(Mid(thisStr, pos1 + Len(keyStr), pos2 - pos1 - Len(keyStr)))
            End If
        End If

    End Function
    
    Function getMinInArray(ByVal arr) As String
        If UBound(arr) = -1 Then
            getMinInArray = 0
            Exit Function
        End If

        getMinInArray = arr(0)
        For i = 1 To UBound(arr)
            If arr(i) < getMinInArray Then getMinInArray = arr(i)
        Next i
    End Function
    Function getMaxInArray(ByVal arr) As String
        If UBound(arr) = -1 Then
            getMaxInArray = 0
            Exit Function
        End If
        getMaxInArray = arr(0)
        For i = 1 To UBound(arr)
            If arr(i) > getMaxInArray Then getMaxInArray = arr(i)
        Next i
    End Function

    Function adjustRateToTickSize(ByVal rate As Double) As Double
        Dim inRate, d, d1, d2, e As String
        Dim pos As Integer

        adjustRateToTickSize = rate

        inRate = rate
        e = 0
        pos = InStr(inRate, ".")
        If pos = 0 Then Exit Function

        d = Right(inRate, Len(inRate) - pos)

        If Len(d) <= 1 Then Exit Function

        d1 = Left(d, 1)
        d2 = Mid(d, 2, 1)

        If d2 <= 2 Then
            d2 = 0
        ElseIf d2 <= 7 Then
            d2 = 5
        Else
            d2 = 0
            e = 0.1
        End If

        adjustRateToTickSize = CDbl(Left(inRate, pos - 1) & "." & d1 & d2) + CDbl(e)


    End Function

    Function formatInt2Date(inp As String) As String
        Dim dd As Integer, yyyy As Integer, mm As Integer
        inp = inp & ""
        If (Len(Trim(inp)) <> 8) Or (IsNumeric(inp) = False) Then
            formatInt2Date = inp
            Exit Function
        End If
        dd = Right(inp, 2)
        yyyy = Left(inp, 4)
        mm = Mid(inp, 5, 2)

        formatInt2Date = dd & "-" & MonthName(mm, True) & "-" & yyyy
    End Function
    Function formatInt2Time(inp As String) As String
        Dim hh As String, mm As String, ss As String
        inp = inp & ""
        If (Len(Trim(inp)) <> 6) Or (IsNumeric(inp) = False) Then
            formatInt2Time = inp
            Exit Function
        End If
        ss = Right(inp, 2)
        hh = Left(inp, 2)
        mm = Mid(inp, 3, 2)

        formatInt2Time = hh & ":" & mm & ":" & ss
    End Function
    Function formatInt2DateTime(inp As String) As String
        Dim dd As String, yyyy As String, mm As String, hh As String, mi As String

        If inp Is Nothing Then inp = ""

        If Len(inp) = 8 Then inp = inp & "0000" 'add time part if missing

        If (Len(Trim(inp)) <> 12) Or (IsNumeric(inp) = False) Then
            formatInt2DateTime = inp
            Exit Function
        End If

        yyyy = Mid(inp, 1, 4)
        mm = Mid(inp, 5, 2)
        dd = Mid(inp, 7, 2)
        hh = Mid(inp, 9, 2)
        mi = Mid(inp, 11, 2)

        formatInt2DateTime = dd & "-" & MonthName(mm, True) & "-" & yyyy & " " & hh & ":" & mi
    End Function
    Function formatInt2DateTimeShort(inp As String) As String
        Dim dd As String, yyyy As String, mm As String, hh As String, mi As String

        If inp Is Nothing Then inp = ""

        If Len(inp) = 8 Then inp = inp & "0000" 'add time part if missing

        If (Len(Trim(inp)) <> 12) Or (IsNumeric(inp) = False) Then
            formatInt2DateTimeShort = inp
            Exit Function
        End If

        yyyy = Mid(inp, 1, 4)
        mm = Mid(inp, 5, 2)
        dd = Mid(inp, 7, 2)
        hh = Mid(inp, 9, 2)
        mi = Mid(inp, 11, 2)

        formatInt2DateTimeShort = mm & "/" & dd & " " & hh & ":" & mi
    End Function
    Function GenerateHash(ByVal SourceText As String) As String
        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New System.Text.UnicodeEncoding()
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New System.Security.Cryptography.MD5CryptoServiceProvider()
        'Compute the hash value from the source
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'And convert it to String format for return
        Return Convert.ToBase64String(ByteHash)
    End Function

    Function myLeft(ByVal originalString As String, strLength As Integer) As String
        myLeft = ""
        If strLength <= 0 Then Exit Function
        If Len(originalString) < strLength Then Exit Function
        myLeft = originalString.Substring(0, strLength)
    End Function
    Function myRight(ByVal originalString As String, strLength As Integer) As String
        myRight = ""
        If strLength <= 0 Then Exit Function
        If Len(originalString) < strLength Then Exit Function
        myRight = originalString.Substring(Len(originalString) - strLength, strLength)
    End Function

    Sub DrawBorder(sht As Microsoft.Office.Interop.Excel.Worksheet, rng As String, LineStyleVal As Microsoft.Office.Interop.Excel.XlBorderWeight, isOnlyOuter As Boolean, makeBold As Boolean, HAlignment As Microsoft.Office.Interop.Excel.XlHAlign, makeColor As Boolean)
        On Error Resume Next
        With sht.Range(rng)
            .Select()
            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = LineStyleVal

            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).Weight = LineStyleVal

            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).Weight = LineStyleVal

            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = LineStyleVal

            If isOnlyOuter = False Then
                .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).Weight = LineStyleVal
                .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).Weight = LineStyleVal
            End If

            If makeBold = True Then .Font.Bold = makeBold

            .HorizontalAlignment = HAlignment
            If makeColor = True Then .Cells.Interior.Color = Color.LightGray


        End With

    End Sub
    Sub DrawBorder2(sht As Microsoft.Office.Interop.Excel.Worksheet, rng As String, LineStyleVal As Microsoft.Office.Interop.Excel.XlBorderWeight, isOnlyOuter As Boolean, makeColor As Boolean)
        On Error Resume Next

        With sht.Range(rng)
            .Select()
            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = LineStyleVal

            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).Weight = LineStyleVal

            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).Weight = LineStyleVal

            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = LineStyleVal

            If isOnlyOuter = False Then
                .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).Weight = LineStyleVal
                .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).Weight = LineStyleVal
            End If


            If makeColor = True Then
                With sht.Range(rng).Interior
                    .Pattern = Microsoft.Office.Interop.Excel.Constants.xlSolid
                    .PatternColorIndex = Microsoft.Office.Interop.Excel.Constants.xlAutomatic
                    .ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorAccent6
                    .TintAndShade = -0.249977111117893
                    .PatternTintAndShade = 0
                End With

            End If


        End With

    End Sub
    Sub DrawUnderline(sht As Microsoft.Office.Interop.Excel.Worksheet, rng As String, LineStyleVal As Microsoft.Office.Interop.Excel.XlBorderWeight)
        On Error Resume Next
        With sht.Range(rng)
            .Select()

            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = LineStyleVal

        End With

    End Sub
    Sub makeBold(sht As Microsoft.Office.Interop.Excel.Worksheet, rng As String, LineStyleVal As Microsoft.Office.Interop.Excel.XlBorderWeight)
        On Error Resume Next
        With sht.Range(rng)
            .Select()
            .Font.Bold = FontStyle.Bold
        End With

    End Sub
End Module
