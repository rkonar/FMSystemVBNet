Public Class clsDocRef
    Dim pos1 As Integer, pos2 As Integer, keyStr As String, delStr As String, thisToken As String

    Public Function getVoucherNo(thisDocRef As String) As String
        '(Tran. Ref. No:, Tran. Date: 23-Jun-2012, Bank:South Indian Bank, VoucherNo:12345)

        thisToken = getToken(thisDocRef, "VoucherNo:", ")")
        getVoucherNo = thisToken

    End Function

    Public Function getFlatCode(thisDocRef As String) As String
        '(Receipt No:320, Cheque No:118141, Cheque Date: 07-Apr-2012, Payee:SAN16D)

        thisToken = getToken(thisDocRef, "Payee:", ")")
        getFlatCode = thisToken

    End Function
    Public Function getTransferDate(thisDocRef As String) As String
        '(Receipt No:320, Cheque No:118141, Cheque Date: 07-Apr-2012, Payee:SAN16D)

        thisToken = getToken(thisDocRef, "Transfer Date:", ",")

        'cheque date is always date, so strip-off any invalid characters from right
        While (Len(thisToken) > 0 And IsDate(thisToken) = False)
            thisToken = Left(thisToken, Len(thisToken) - 1)
        End While
        getTransferDate = thisToken

    End Function
    Public Function getTranDate(thisDocRef As String) As String
        '(Receipt No:320, Cheque No:118141, Cheque Date: 07-Apr-2012, Payee:SAN16D)

        thisToken = getToken(thisDocRef, "Tran. Date:", ",")
        getTranDate = thisToken

    End Function
    Public Function getNEFTRefNo(thisDocRef As String) As String
        '(Receipt No:320, Cheque No:118141, Cheque Date: 07-Apr-2012, Payee:SAN16D)

        thisToken = getToken(thisDocRef, "NEFT Ref:", ",")


        getNEFTRefNo = thisToken

    End Function
    Public Function getOnlineTransferRefNo(thisDocRef As String) As String
        '(Receipt No:320, Cheque No:118141, Cheque Date: 07-Apr-2012, Payee:SAN16D)

        thisToken = getToken(thisDocRef, "Online Transfer Ref:", ",")


        getOnlineTransferRefNo = thisToken

    End Function
    Public Function getBankName(thisDocRef As String) As String
        '(Receipt No:320, Cheque No:118141, Cheque Date: 07-Apr-2012, Payee:SAN16D)

        thisToken = getToken(thisDocRef, "Bank:", ",")


        getBankName = thisToken

    End Function
    Public Function getChequeDate(thisDocRef As String) As String
        '(Receipt No:320, Cheque No:118141, Cheque Date: 07-Apr-2012, Payee:SAN16D)

        thisToken = getToken(thisDocRef, "Cheque Date:", ",")

        'cheque date is always date, so strip-off any invalid characters from right
        While (Len(thisToken) > 0 And IsDate(thisToken) = False)
            thisToken = Left(thisToken, Len(thisToken) - 1)
        End While
        getChequeDate = thisToken

    End Function
    Public Function getChequeNo(thisDocRef As String) As String
        '(Receipt No:320, Cheque No:118141, Cheque Date: 07-Apr-2012, Payee:SAN16D)

        thisToken = getToken(thisDocRef, "Cheque No:", ",")

        'cheque no is always numeric, so strip-off any non-numeric characters from right
        While (Len(thisToken) > 0 And IsNumeric(thisToken) = False)
            thisToken = Left(thisToken, Len(thisToken) - 1)
        End While
        getChequeNo = thisToken

    End Function

    Public Function getReceiptNo(thisDocRef As String) As String
        '(Receipt No:320, Cheque No:118141, Cheque Date: 07-Apr-2012, Payee:SAN16D)

        thisToken = getToken(thisDocRef, "Receipt No:", ",")

        ''Receipt no is always numeric, so strip-off any non-numeric characters from right
        'This is no longer true as we have split receipts like 372/1 in some cases
        'While (Len(thisToken) > 0 And IsNumeric(thisToken) = False)
        '    thisToken = Left(thisToken, Len(thisToken) - 1)
        'End While
        getReceiptNo = thisToken

    End Function

    Public Function getFromDate(thisDocRef As String) As String
        '(From Date:01-May-2012, To Date: 16-May-2012, No of Days:16, Payee:SUK05C)

        getFromDate = getToken(thisDocRef, "From Date:", ",")

    End Function
    Public Function getDueDate(thisDocRef As String) As String
        '(From Date:01-May-2012, To Date: 16-May-2012, No of Days:16, Payee:SUK05C)

        getDueDate = getToken(thisDocRef, "Due Date:", ",")

    End Function
    Public Function getToDate(thisDocRef As String) As String
        '(From Date:01-May-2012, To Date: 16-May-2012, No of Days:16, Payee:SUK05C)

        getToDate = getToken(thisDocRef, "To Date:", ",")

    End Function
    Public Function getPaymentDate(thisDocRef As String) As String
        '(From Date:01-May-2012, To Date: 16-May-2012, No of Days:16, Payee:SUK05C)

        getPaymentDate = getToken(thisDocRef, "Payment Date:", ",")

    End Function
    Public Function getNoOfDays(thisDocRef As String) As String
        '(From Date:01-May-2012, To Date: 16-May-2012, No of Days:16, Payee:SUK05C)

        getNoOfDays = getToken(thisDocRef, "No of Days:", ",")

    End Function
    Public Function getDaysLate(thisDocRef As String) As String
        '(From Date:01-May-2012, To Date: 16-May-2012, No of Days:16, Payee:SUK05C)

        getDaysLate = getToken(thisDocRef, "Days Late:", ",")

    End Function
    Public Function getBillNo(thisDocRef As String) As String
        '(From Date:01-May-2012, To Date: 16-May-2012, No of Days:16, Payee:SUK05C)

        getBillNo = getToken(thisDocRef, "Bill No:", ",")

    End Function
    '.DocRef = "(Bill No:" & cboBill.Text & ",Due Date:" & dtpDueDate.Text & ",Payment Date: " & dtpPaymentDate.Text & ",Days late:" & txtNoOfDays.Text & ",Payee:" & cboFlatCode.Text & ")"
    Private Function getToken(thisStr As String, keyStr As String, delStr As String) As String
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

End Class
