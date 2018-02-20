Imports System.Windows.Forms

Public Class dlgSortCol


    Private Sub dlgSortCol_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gSortCol = ""
        With cboOrderBy
            .Items.Add("Date")
            .Items.Add("Amount")
            .Items.Add("Account")
            .SelectedIndex = 0
        End With

        With cboDirection
            .Items.Add("Ascending")
            .Items.Add("Descending")
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        getOrderbyStr()
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub getOrderbyStr()
        gSortCol = cboOrderBy.Text

        gOrderbyStr = " Order by "
        Select Case cboOrderBy.Text
            Case "Date"
                If cboDirection.Text = "Ascending" Then
                    gOrderbyStr = gOrderbyStr & " TxnDate Asc,AccountNo Asc"
                Else
                    gOrderbyStr = gOrderbyStr & " TxnDate Desc,AccountNo Asc"
                End If
            Case "Amount"
                If cboDirection.Text = "Ascending" Then
                    gOrderbyStr = gOrderbyStr & " DrAmount Asc,CrAmount Asc,AccountNo Asc"
                Else
                    gOrderbyStr = gOrderbyStr & " DrAmount Desc,CrAmount Desc,AccountNo Asc"
                End If
            Case "Account"
                If cboDirection.Text = "Ascending" Then
                    gOrderbyStr = gOrderbyStr & " AccountNo Asc,TxnDate Asc"
                Else
                    gOrderbyStr = gOrderbyStr & " AccountNo Desc,TxnDate Asc"
                End If
        End Select
    End Sub
End Class
