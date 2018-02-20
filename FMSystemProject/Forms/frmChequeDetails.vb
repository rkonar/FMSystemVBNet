Public Class frmChequeDetails

    Private Sub frmChequeDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadCheques()
    End Sub
    Sub loadCheques()
        Dim expActRS As ADODB.Recordset

        cboChequeNo.Items.Clear()
        ssql = "select InstrumentNo from tblreceipt where InstrumentType='CHEQUE' order by InstrumentNo"
        expActRS = gcon.Execute(ssql)

        While expActRS.EOF = False
            cboChequeNo.Items.Add(expActRS("InstrumentNo").Value.ToString)
            expActRS.MoveNext()
        End While
    End Sub

    Private Sub cboChequeNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboChequeNo.SelectedIndexChanged
        Dim expActRS As ADODB.Recordset

        cboChequeNo.Items.Clear()
        ssql = "select ReceiptNo from tblreceipt where InstrumentNo='" & cboChequeNo.Text & "'"
        expActRS = gcon.Execute(ssql)

        If expActRS.EOF = False Then
            gCurReceiptNo = expActRS("ReceiptNo").Value.ToString
        Else
            gCurReceiptNo = ""
        End If
    End Sub

    Private Sub btnShowChequeDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnShowChequeDetails.Click
        frmViewReceipt.ShowDialog()
        frmViewReceipt.Dispose()
    End Sub
End Class