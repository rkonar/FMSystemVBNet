Public Class frmShowBill

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmShowBill_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        showBill()
    End Sub

    Sub showBill()
        Dim tmpSql As String, tmpBillRS As ADODB.Recordset

        tmpSql = "Select * from tblbill where BillNo='" & gCurBillNo & "'"
        tmpBillRS = gcon.Execute(tmpSql)
        With tmpBillRS
            If .EOF = False Then
                txtBillNo.Text = tmpBillRS("BillNo").Value.ToString
                txtBillDate.Text = formatInt2Date(tmpBillRS("BillDate").Value.ToString)
                txtBillAmount.Text = tmpBillRS("BillAmt").Value.ToString
                txtBillType.Text = tmpBillRS("BillType").Value.ToString
                txtDueDate.Text = formatInt2Date(tmpBillRS("DueDate").Value.ToString)
                txtBillPeriod.Text = MonthName(tmpBillRS("BillMonthFrom").Value.ToString) & "'" & tmpBillRS("BillYearFrom").Value.ToString & " - " & MonthName(tmpBillRS("BillMonthTo").Value.ToString) & "'" & tmpBillRS("BillYearTo").Value.ToString
                txtFlat.Text = tmpBillRS("FlatCode").Value.ToString
            End If
        End With
    End Sub
End Class