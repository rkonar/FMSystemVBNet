Public Class clsSecurity
    Public Function encryptString(InputString As String) As String
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(InputString) 'convert string to byte array
        encryptString = Convert.ToBase64String(byt) 'do base64 encoding
    End Function

    Public Function decryptString(InputString As String) As String
        decryptString = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(InputString)) 'do base64 decoding
    End Function

    Public Sub ProtectExcelFile(thisWrkBook As Microsoft.Office.Interop.Excel.Workbook)
        Dim tmppwd As String, cnt As Integer

        tmppwd = decryptString(getSysParamValue("PASSWORD_PROTECT_EXCEL_WORKSHEET"))
        For cnt = 1 To thisWrkBook.Sheets.Count
            thisWrkBook.Sheets(cnt).Protect(Password:=tmppwd, DrawingObjects:=True, Contents:=True, Scenarios:=True, AllowFormattingCells:=True, AllowFormattingColumns:=True, AllowFormattingRows:=True, AllowSorting:=True, AllowFiltering:=True)
        Next
        tmppwd = decryptString(getSysParamValue("PASSWORD_PROTECT_EXCEL_WORKBOOK"))
        thisWrkBook.Protect(Password:=tmppwd, Structure:=True, Windows:=False)

        thisWrkBook.Application.CutCopyMode = False
        thisWrkBook.Application.CellDragAndDrop = False
    End Sub
End Class
