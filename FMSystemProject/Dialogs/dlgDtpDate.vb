Imports System.Windows.Forms

Public Class dlgDtpDialog

    

    Private Sub dlgDtpDialog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpDate.Text = dtpDateSelected
        
        dtpDate.Left = 0
        dtpDate.Top = 0

        btnDone.Left = dtpDate.Left + dtpDate.Width
        btnDone.Top = dtpDate.Top

        btnCancel.Left = btnDone.Left + btnDone.Width
        btnCancel.Top = dtpDate.Top

        Me.Width = dtpDate.Left + dtpDate.Width + btnDone.Width + btnCancel.Width
        Me.Height = dtpDate.Height

        Me.Left = Cursor.Position.X
        Me.Top = Cursor.Position.Y
    End Sub

    Private Sub btnDone_Click(sender As System.Object, e As System.EventArgs) Handles btnDone.Click
        dtpDateSelected = dtpDate.Text
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
