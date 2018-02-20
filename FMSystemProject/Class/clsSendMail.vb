Public Class clsSendMail

    Public mailSubject As String
    Public mailBody As String
    Public mailHost As String
    Public mailPort As Integer
    Public fromMailID As String
    Public fromMailName As String
    Public toMailID As String
    Public ccMailID As String
    Public mailUID As String
    Public mailPWD As String
    Public IsBodyHtml As Boolean
    Public Attachments() As String = Nothing
    Public replyToMailID As String
    Public sendStatus As Boolean

    Public Sub New()
        ResetAll()
    End Sub

    Public Sub SendMail_EOD()

        fromMailID = getSysParamValue("MAIL_FROM_UID_EOD")
        fromMailName = "Mailer, GFH HIG Association"
        toMailID = getSysParamValue("MAIL_TO_UID_EOD")
        mailUID = fromMailID
        mailPWD = getSysParamValue("MAIL_FROM_PWD_EOD")
        replyToMailID = getSysParamValue("MAIL_REPLYTO_EOD")
        If isEmailBlocked(toMailID) = False Then SendMailUsingGmailSMTP()

    End Sub
    Public Sub SendMail_Expense(to_mailid As String)

        fromMailID = getSysParamValue("MAIL_FROM_UID_EOD")
        fromMailName = "Mailer, GFH HIG Association"
        If to_mailid = "" Then
            toMailID = getSysParamValue("MAIL_DL_ASSOCIATION")
        Else
            toMailID = to_mailid
            ccMailID = getSysParamValue("MAIL_DL_ASSOCIATION")
        End If
        mailUID = fromMailID
        mailPWD = getSysParamValue("MAIL_FROM_PWD_EOD")
        replyToMailID = getSysParamValue("MAIL_REPLYTO_EXPENSE")
        If isEmailBlocked(toMailID) = False Then SendMailUsingGmailSMTP()

    End Sub
    Public Sub SendMail_Expense_Cultural(to_mailid As String)

        fromMailID = getSysParamValue("MAIL_FROM_UID_EOD")
        fromMailName = "Mailer, Cultural Sub-Committee, GFH HIG Association"
        If to_mailid = "" Then
            toMailID = getSysParamValue("MAIL_DL_SUBCOMMITTEE_CULTURAL") & "," & getSysParamValue("MAIL_DL_ASSOCIATION")
        Else
            toMailID = to_mailid
            ccMailID = getSysParamValue("MAIL_DL_SUBCOMMITTEE_CULTURAL") & "," & getSysParamValue("MAIL_DL_ASSOCIATION")
        End If
        mailUID = fromMailID
        mailPWD = getSysParamValue("MAIL_FROM_PWD_EOD")
        replyToMailID = getSysParamValue("MAIL_REPLYTO_EXPENSE_CULTURAL")
        If isEmailBlocked(toMailID) = False Then SendMailUsingGmailSMTP()

    End Sub
    Public Sub SendMail_BILL()


        mailUID = getSysParamValue("MAILUID")
        If mailPWD = "" Then mailPWD = getSysParamValue("MAILPWD")

        'If fromMailID = "" Then fromMailID = getSysParamValue("MAIL_FROM_UID_BILL")
        fromMailID = mailUID

        'replyToMailID = getSysParamValue("MAIL_REPLYTO_BILL")
        replyToMailID = mailUID

        'fromMailName = "Mailer, GFH HIG Association"
        fromMailName = "Admin Greenfield Heights HIG Association"

        'IsBodyHtml = False

        If isEmailBlocked(toMailID) = False Then SendMailUsingGmailSMTP()

    End Sub
    Public Sub SendMail_eVoting()

        fromMailID = "tothefm.gfh.hig@gmail.com"
        fromMailName = "FM, GFH HIG Association"
        mailUID = fromMailID
        mailPWD = "Z3JlZW4wMDAw"
        replyToMailID = fromMailID
        If isEmailBlocked(toMailID) = False Then SendMailUsingGmailSMTP()

    End Sub

    Public Sub SendMail_RECEIPT()

        fromMailID = getSysParamValue("MAIL_FROM_UID_RECEIPT")
        fromMailName = gUserName & ", GFH HIG Association"
        mailUID = fromMailID
        mailPWD = getSysParamValue("MAIL_FROM_PWD_RECEIPT")
        replyToMailID = getSysParamValue("MAIL_REPLYTO_RECEIPT")
        If isEmailBlocked(toMailID) = False Then SendMailUsingGmailSMTP()

    End Sub


    Private Sub ResetAll()
        fromMailID = ""
        fromMailName = ""
        toMailID = ""
        ccMailID = ""
        mailHost = ""
        mailPort = 0
        mailUID = ""
        mailPWD = ""
        mailBody = ""
        mailSubject = ""
        IsBodyHtml = True
        Attachments = Nothing
        replyToMailID = ""
    End Sub

    'Private Sub SendMail()

    '    ''create a SmtpClient object to allow applications to send e-mail by using the Simple Mail Transfer Protocol (SMTP).
    '    Dim MailClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient(mailHost, mailPort)
    '    ''create a MailMessage object to represent an e-mail message that can be sent using the SmtpClient class
    '    Dim MailMessage = New System.Net.Mail.MailMessage(fromMailID, toMailID, mailSubject, mailBody)
    '    ''sets a value indicating whether the mail message body is in Html.
    '    MailMessage.IsBodyHtml = IsBodyHtml
    '    ''sets the credentials used to authenticate the sender
    '    MailClient.Credentials = New System.Net.NetworkCredential(mailUID, System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(mailPWD)))
    '    ''add the files as the attachments for the mailmessage object
    '    If (Attachments IsNot Nothing) Then
    '        For Each FileName In Attachments
    '            MailMessage.Attachments.Add(New System.Net.Mail.Attachment(FileName))
    '        Next
    '    End If
    '    MailClient.Send(MailMessage)
    'End Sub

    Private Sub SendMailUsingGmailSMTP()
        On Error GoTo errH

        sendStatus = False

        Dim MailClient As New System.Net.Mail.SmtpClient
        Dim MailMessage = New System.Net.Mail.MailMessage
        'order of steps are important here
        MailClient.Host = getSysParamValue("MAILHOST")
        MailClient.Port = getSysParamValue("MAILPORT")
        MailClient.EnableSsl = True
        MailClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
        MailClient.UseDefaultCredentials = False
        MailClient.Credentials = New System.Net.NetworkCredential(mailUID, mailPWD)
        MailMessage.From = New System.Net.Mail.MailAddress(fromMailID, fromMailName)
        

        MailMessage.To.Add(toMailID)
        If ccMailID <> "" Then MailMessage.CC.Add(ccMailID)
        MailMessage.Subject = mailSubject
        MailMessage.Body = mailBody
        MailMessage.IsBodyHtml = IsBodyHtml
        MailMessage.ReplyToList.Add(New System.Net.Mail.MailAddress(replyToMailID))
        If (Attachments IsNot Nothing) Then
            For Each FileName In Attachments
                MailMessage.Attachments.Add(New System.Net.Mail.Attachment(FileName))
            Next
        End If
        
        MailClient.Send(MailMessage)

        ResetAll()
        sendStatus = True
        Exit Sub

errH:
        MsgBox(Err.Description)
        ResetAll()
        sendStatus = False
    End Sub

End Class
