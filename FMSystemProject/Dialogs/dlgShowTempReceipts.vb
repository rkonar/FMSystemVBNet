Imports System.Windows.Forms

Public Class dlgShowTempReceipts

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub loadTempReceipts()
        lstTempReceipts.Items.Clear()
        tmpRS = gcon.Execute("select * from tblreceipt where ReceiptNo like '%TMP%'")
        While tmpRS.EOF = False
            lstTempReceipts.Items.Add(tmpRS("ReceiptNo").Value.ToString)
            tmpRS.MoveNext()
        End While
    End Sub

    Private Sub dlgShowTempReceipts_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadTempReceipts()
    End Sub

    Private Sub lstTempReceipts_DoubleClick(sender As Object, e As System.EventArgs) Handles lstTempReceipts.DoubleClick
        If lstTempReceipts.SelectedIndex < 0 Then Exit Sub

        Dim oldItemCode As String
        gCurReceiptNo = lstTempReceipts.SelectedItem.ToString
        oldItemCode = gItemCode
        gItemCode = "frmViewReceipt"
        Me.Hide()
        frmViewReceipt.ShowDialog()
        frmViewReceipt.Dispose()
        gItemCode = oldItemCode
        Me.Show()
    End Sub

   
End Class
