Imports System.Windows.Forms

Public Class dlgSelReportAccount


    Private Sub dlgSelBankAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getBankAccountsAsString()
    End Sub

    Sub getBankAccountsAsString()
        Dim actRS1 As ADODB.Recordset

        cboBankAccount.Items.Clear()
        ssql = "select AccountNo from tblaccounts where ParentAccountNo like '" & gParentReportAccount & "%' and LeafAccount='Y'"
        actRS1 = gcon.Execute(ssql)
        While actRS1.EOF = False
            cboBankAccount.Items.Add(actRS1("AccountNo").Value.ToString)
            actRS1.MoveNext()
        End While
        actRS1.Close()
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        gSelectedReportAccount = cboBankAccount.Text
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


End Class
