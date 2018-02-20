Public Class frmGeneratePassword

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnEncrypt_Click(sender As System.Object, e As System.EventArgs) Handles btnEncrypt.Click
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(txtPWD.Text)
        txtOutput.Text = Convert.ToBase64String(byt)
    End Sub

    Private Sub btnDecode_Click(sender As Object, e As EventArgs) Handles btnDecode.Click
        txtOutput.Text = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(txtPWD.Text))
    End Sub

    Private Sub frmGeneratePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If gLoginID <> "sa" Then
        '    btnEncrypt.Enabled = False
        '    btnDecode.Enabled = False
        'End If
    End Sub
End Class