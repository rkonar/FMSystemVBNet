Public Class frmMailPreview

   
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMail_Click(sender As System.Object, e As System.EventArgs) Handles btnMail.Click
        On Error GoTo errH

        Dim myMailer As New clsSendMail

        With myMailer
            .toMailID = txtTo.Text
            .mailSubject = txtSubject.Text
            .mailBody = txtBody.Text
            .mailBody = Replace(.mailBody, vbCrLf, "<br>")
            .replyToMailID = txtReplyTo.Text
            .fromMailName = txtFrom.Text

            btnMail.Enabled = False
            .SendMail_RECEIPT()
            btnMail.Enabled = True
        End With

        MsgBox("Mail sent successfully")

        Exit Sub
errH:
        MsgBox(Err.Description)
        btnMail.Enabled = True
    End Sub

    
End Class