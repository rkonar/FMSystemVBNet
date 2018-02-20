Public Class frmBillMailer
    Dim pCurBillingDate As String

    Sub LoadBills()
        Dim billRS As ADODB.Recordset

        cboBill.Items.Clear()
        ssql = "select * from tblbillinghistory order by BillingDate desc,BillMonth desc"
        billRS = gcon.Execute(ssql)
        While billRS.EOF = False
            cboBill.Items.Add(MonthName(billRS("BillMonth").Value.ToString, True) & "-" & billRS("BillYear").Value.ToString & "     (Billing Date:" & formatInt2Date(billRS("BillingDate").Value.ToString) & ")")

            billRS.MoveNext()
        End While
        billRS.Close()
    End Sub

    Private Sub cboBill_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboBill.SelectedIndexChanged
        If cboBill.SelectedIndex < 0 Then
            pCurBillingDate = ""
        Else
            pCurBillingDate = DateTime.Parse(getToken(cboBill.Text, "Billing Date:", ")")).ToString(DB_DATEFORMAT)
        End If
        dgvFlat.Rows.Clear()
    End Sub

    Private Sub btnQuery_Click(sender As System.Object, e As System.EventArgs) Handles btnQuery.Click
        If optAll.Checked = True Then
            loadFlats("")
        ElseIf optSAP.Checked = True Then
            loadFlats("SAP")
        ElseIf optSAN.Checked = True Then
            loadFlats("SAN")
        ElseIf optSUK.Checked = True Then
            loadFlats("SUK")
        ElseIf optSHR.Checked = True Then
            loadFlats("SHR")
        End If
        lblMsg.Text = ""
    End Sub

    Sub loadFlats(towerCode As String)
        Dim i As Integer, flatRS As ADODB.Recordset, flSql As String, em As String, pem As String, mob1 As String
        dgvFlat.Rows.Clear()
        flSql = "select b.tblid,b.BillNo,b.billMailed,b.billSMSed,b.FlatCode,b.DueDate,fo.p_email1,fo.email1,fo.p_softBill,fo.OwnerFullName,fo.usingPortal,fo.mobile1 from tblbill b, tblflatowners fo "
        flSql = flSql & " where fo.IsActiveOwner='Y' and fo.FlatCode=b.FlatCode and b.BillDate = '" & pCurBillingDate & "' and b.FlatCode like '%" & towerCode & "%'"
        If chkSoftBill.Checked = True Then
            flSql = flSql & " and fo.p_softBill='Y'"
        End If
        flSql = flSql & " order by FlatCode"
        flatRS = gcon.Execute(flSql)

        With dgvFlat

            While flatRS.EOF = False
                pem = flatRS("p_email1").Value.ToString
                em = flatRS("email1").Value.ToString
                mob1 = flatRS("mobile1").Value.ToString

                i = .Rows.Add()
                .Rows(i).Cells("tblid").Value = flatRS("tblid").Value.ToString
                .Rows(i).Cells("BillNo").Value = flatRS("BillNo").Value.ToString
                .Rows(i).Cells("flatCode").Value = flatRS("FlatCode").Value.ToString
                .Rows(i).Cells("DueDate").Value = flatRS("DueDate").Value.ToString
                'If flatRS("billMailed").Value.ToString = "" Then
                .Rows(i).Cells("billMailed").Value = flatRS("billMailed").Value.ToString
                .Rows(i).Cells("billSMSed").Value = flatRS("billSMSed").Value.ToString
                'Else
                '.Rows(i).Cells("billMailed").Value = "Yes"
                'End If
                If ((pem <> "") And (InStr(pem, "@") > 0)) Or ((em <> "") And (InStr(em, "@") > 0)) Then
                    If pem = "" Then
                        .Rows(i).Cells("eMail").Value = em
                    Else
                        .Rows(i).Cells("eMail").Value = pem
                    End If
                    dgvFlat.Rows(i).Cells("chkMail").Value = chkSelectAll4Mail.Checked
                Else 'invalid email
                    .Rows(i).Cells("eMail").Value = "invalid or no email"
                    dgvFlat.Rows(i).Cells("chkMail").ReadOnly = True
                    dgvFlat.Rows(i).Cells("chkMail").Style.BackColor = Color.Red
                    '.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If
                .Rows(i).Cells("Mobile1").Value = mob1
                If mob1 <> "" Then
                    dgvFlat.Rows(i).Cells("chkSMS").Value = chkSelectAll4SMS.Checked
                Else
                    dgvFlat.Rows(i).Cells("chkSMS").ReadOnly = True
                    dgvFlat.Rows(i).Cells("chkSMS").Style.BackColor = Color.Red
                End If

                .Rows(i).Cells("ownerName").Value = flatRS("OwnerFullName").Value.ToString

                If flatRS("p_softBill").Value.ToString = "Y" Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
                    .Rows(i).Cells("softBill").Value = "Yes"
                Else
                    .Rows(i).Cells("softBill").Value = "No"
                End If
                If flatRS("usingPortal").Value.ToString = "Y" Then
                    .Rows(i).Cells("UsingPortal").Value = "Yes"
                Else
                    .Rows(i).Cells("UsingPortal").Value = "No"
                End If

                flatRS.MoveNext()
            End While

        End With

    End Sub
    'Commented below for removing html body
    '    Private Sub btnMailBill_Click(sender As System.Object, e As System.EventArgs) Handles btnMailBill.Click
    '        On Error GoTo errH
    '        Dim myMailer As New clsSendMail, billMonth As String, billYear As String, thisFlatCode As String, thisFlatShortCode As String, thisOwnerName As String, thisEmailid As String, billid As String, thisBillNo As String, isSoftBill As String, IsUsingPortal As String, tmpStr As String, thisBillFilePath As String = ""


    '        If MsgBox("Email Bill to selected flats - Confirm", vbYesNo) = vbNo Then Exit Sub

    '        billMonth = DateTime.Parse(formatInt2Date(pCurBillingDate)).ToString("MMM-yyyy")
    '        billYear = DateTime.Parse(formatInt2Date(pCurBillingDate)).ToString("yyyy")

    '        lblMsg.Text = ""

    '        Dim r As Integer
    '        For r = 0 To dgvFlat.Rows.Count - 1
    '            If dgvFlat.Rows(r).Cells("chkMail").Value = True Then
    '                thisFlatCode = dgvFlat.Rows(r).Cells("flatCode").Value
    '                thisFlatShortCode = stripLeadingZero(myRight(thisFlatCode, 3))
    '                billid = dgvFlat.Rows(r).Cells("tblid").Value
    '                thisBillNo = dgvFlat.Rows(r).Cells("BillNo").Value
    '                thisOwnerName = dgvFlat.Rows(r).Cells("ownerName").Value
    '                thisEmailid = dgvFlat.Rows(r).Cells("eMail").Value
    '                isSoftBill = dgvFlat.Rows(r).Cells("softBill").Value
    '                IsUsingPortal = dgvFlat.Rows(r).Cells("UsingPortal").Value
    '                tmpStr = ""
    '                If thisEmailid <> "" Then
    '                    With myMailer

    '                        lblMsg.Text = "Sending mail to " & thisFlatCode

    '                        .mailSubject = "Greenfield Heights(HIG) Association : Maintenance Bill of Flat " & thisFlatCode & " for " & billMonth

    '                        tmpStr = "Dear " & thisOwnerName

    '                        'tmpStr = tmpStr & "<br>We noticed a minor glitch in the Jul-2012 bill mailed to you earlier. We have corrected the same. Your revised maintenance bill for " & billMonth & " is attached."
    '                        'tmpStr = tmpStr & "<br>Please ignore the previous bill. Sorry for any inconveniences caused."
    '                        tmpStr = tmpStr & "<br>Your maintenance bill for " & billMonth & " is attached."
    '                        tmpStr = tmpStr & "<br><B>PS: This is a system generated mail, please do not reply to this mail id.</B>"
    '                        tmpStr = tmpStr & "<br>If you notice any discrepancy in your bill, please reply to email address:<B> tothefm.gfh.hig@gmail.com </B>or use the forum in the community portal: http://ghcommunity.selfip.com"
    '                        tmpStr = tmpStr & "<br>To open the attachment, you need Adobe Reader."


    '                        If isSoftBill = "No" Then

    '                            If IsUsingPortal = "No" Then
    '                                tmpStr = tmpStr & "<br><br>"
    '                                tmpStr = tmpStr & "<br>Our record shows that you haven't registered yourself in our Portal: http://ghcommunity.selfip.com."
    '                                tmpStr = tmpStr & "<br>Please do the same to get access to soft copy of all your current and old bills. You will also be able to collaborate with other residents and many more."
    '                                tmpStr = tmpStr & "<br><br>"
    '                                tmpStr = tmpStr & "<br><br>We have started moving from physical bill to soft bill. Would request to opt for soft bill while you register in the portal. We will deliver the bill to your email id immediately after it is generated"

    '                            Else
    '                                tmpStr = tmpStr & "<br><br>For your information, we have started moving from physical bill to soft bill. Would request to opt for soft bill in the portal. Yo can do so by editing your profile in the portal."
    '                                tmpStr = tmpStr & "<br>We will deliver the bill to your email id immediately after it is generated."

    '                            End If

    '                        Else

    '                            tmpStr = tmpStr & "<br>Our record shows that you have opted for soft bill in our portal: http://ghcommunity.selfip.com. Thank you for supporting the 'green billing' "

    '                        End If

    '                        tmpStr = tmpStr & "<br><br>With Warm Regards,"
    '                        tmpStr = tmpStr & "<br>Greenfield Heights HIG Association"
    '                        tmpStr = tmpStr & "<br>" & DateTime.Now.ToString("dd-MMM-yyyy HH:mm") & " IST"

    '                        Select Case myLeft(thisBillNo, 3)
    '                            Case "SAP"
    '                                thisBillFilePath = getSysParamValue("PATH_WEBSERVER_BILLDIR") & "SAPTARSHI\" & thisFlatShortCode & "\" & billYear & "\" & thisBillNo & ".pdf"
    '                            Case "SAN"
    '                                thisBillFilePath = getSysParamValue("PATH_WEBSERVER_BILLDIR") & "SANDHYATARA\" & thisFlatShortCode & "\" & billYear & "\" & thisBillNo & ".pdf"
    '                            Case "SHR"
    '                                thisBillFilePath = getSysParamValue("PATH_WEBSERVER_BILLDIR") & "SHROBONA\" & thisFlatShortCode & "\" & billYear & "\" & thisBillNo & ".pdf"
    '                            Case "SUK"
    '                                thisBillFilePath = getSysParamValue("PATH_WEBSERVER_BILLDIR") & "SUKTARA\" & thisFlatShortCode & "\" & billYear & "\" & thisBillNo & ".pdf"
    '                        End Select

    '                        .mailBody = tmpStr
    '                        .IsBodyHtml = True
    '                        .Attachments = New String() {thisBillFilePath}
    '                        .toMailID = thisEmailid
    '                        '.fromMailID = cboMailer.Text
    '                        '.mailPWD = txtSMTPPassword.Text
    '                        .SendMail_BILL()

    '                        If .sendStatus = True Then
    '                            gcon.Execute("update tblbill set billMailed=billMailed+1 where tblid=" & billid)
    '                            frmMain.sslabel3.Text = "Mail sent to:" & thisFlatCode
    '                            Dim t As Integer
    '                            For t = txtMailDelay.Text To 0 Step -1
    '                                lblMsg.Text = "Mail sent to:" & thisFlatCode & ". Waiting for " & t & " seconds..."
    '                                Application.DoEvents()
    '                                System.Threading.Thread.Sleep(1000)
    '                            Next t


    '                        Else
    '                            lblMsg.Text = "Interrupted while sending mail to " & thisFlatCode & " !!! All mails may not have been sent"
    '                            Exit Sub
    '                        End If
    '                    End With

    '                End If
    '            End If
    '        Next
    '        lblMsg.Text = "All mails sent"
    '        Exit Sub

    'errH:
    '        MsgBox(Err.Description)
    '        lblMsg.Text = "Could not send mail to " & thisFlatCode

    '    End Sub

    Private Sub btnMailBill_Click(sender As System.Object, e As System.EventArgs) Handles btnMailBill.Click
        On Error GoTo errH
        Dim myMailer As New clsSendMail, billMonth As String, billYear As String, thisFlatCode As String, thisFlatShortCode As String, thisOwnerName As String, thisEmailid As String, billid As String, thisBillNo As String, isSoftBill As String, IsUsingPortal As String, tmpStr As String, thisBillFilePath As String = ""


        If MsgBox("Email Bill to selected flats - Confirm", vbYesNo) = vbNo Then Exit Sub

        billMonth = DateTime.Parse(formatInt2Date(pCurBillingDate)).ToString("MMM-yyyy")
        billYear = DateTime.Parse(formatInt2Date(pCurBillingDate)).ToString("yyyy")

        lblMsg.Text = ""

        Dim r As Integer
        For r = 0 To dgvFlat.Rows.Count - 1
            If dgvFlat.Rows(r).Cells("chkMail").Value = True Then
                thisFlatCode = dgvFlat.Rows(r).Cells("flatCode").Value
                thisFlatShortCode = stripLeadingZero(myRight(thisFlatCode, 3))
                billid = dgvFlat.Rows(r).Cells("tblid").Value
                thisBillNo = dgvFlat.Rows(r).Cells("BillNo").Value
                thisOwnerName = dgvFlat.Rows(r).Cells("ownerName").Value
                thisEmailid = dgvFlat.Rows(r).Cells("eMail").Value
                isSoftBill = dgvFlat.Rows(r).Cells("softBill").Value
                IsUsingPortal = dgvFlat.Rows(r).Cells("UsingPortal").Value
                tmpStr = ""
                If thisEmailid <> "" Then
                    With myMailer

                        lblMsg.Text = "Sending mail to " & thisFlatCode

                        .mailSubject = "Greenfield Heights(HIG) Association : Maintenance Bill of Flat " & thisFlatCode & " for " & billMonth

                        tmpStr = "Dear " & thisOwnerName

                        'tmpStr = tmpStr & vbnewline & "We noticed a minor glitch in the Jul-2012 bill mailed to you earlier. We have corrected the same. Your revised maintenance bill for " & billMonth & " is attached."
                        'tmpStr = tmpStr & vbnewline & "Please ignore the previous bill. Sorry for any inconveniences caused."
                        tmpStr = tmpStr & vbNewLine & "Your maintenance bill for " & billMonth & " is attached."
                        tmpStr = tmpStr & vbNewLine & "PS: This is a system generated mail, please do not reply to this mail id."
                        tmpStr = tmpStr & vbNewLine & "If you notice any discrepancy in your bill, please reply to email address: tothefm.gfh.hig@gmail.com or use the forum in the community portal: http://ghcommunity.selfip.com"
                        tmpStr = tmpStr & vbNewLine & "To open the attachment, you need Adobe Reader."


                        If isSoftBill = "No" Then

                            If IsUsingPortal = "No" Then
                                tmpStr = tmpStr & vbNewLine & vbNewLine
                                tmpStr = tmpStr & vbNewLine & "Our record shows that you haven't registered yourself in our Portal: http://ghcommunity.selfip.com."
                                tmpStr = tmpStr & vbNewLine & "Please do the same to get access to soft copy of all your current and old bills. You will also be able to collaborate with other residents and many more."
                                tmpStr = tmpStr & vbNewLine & vbNewLine
                                tmpStr = tmpStr & vbNewLine & vbNewLine & "We have started moving from physical bill to soft bill. Would request to opt for soft bill while you register in the portal. We will deliver the bill to your email id immediately after it is generated"

                            Else
                                tmpStr = tmpStr & vbNewLine & vbNewLine & "For your information, we have started moving from physical bill to soft bill. Would request to opt for soft bill in the portal. Yo can do so by editing your profile in the portal."
                                tmpStr = tmpStr & vbNewLine & "We will deliver the bill to your email id immediately after it is generated."

                            End If

                        Else

                            tmpStr = tmpStr & vbNewLine & "Our record shows that you have opted for soft bill in our portal: http://ghcommunity.selfip.com. Thank you for supporting the 'green billing' "

                        End If

                        tmpStr = tmpStr & vbNewLine & vbNewLine & "With Warm Regards,"
                        tmpStr = tmpStr & vbNewLine & "Greenfield Heights HIG Association"
                        tmpStr = tmpStr & vbNewLine & "" & DateTime.Now.ToString("dd-MMM-yyyy HH:mm") & " IST"

                        Select Case myLeft(thisBillNo, 3)
                            Case "SAP"
                                thisBillFilePath = getSysParamValue("PATH_WEBSERVER_BILLDIR") & "SAPTARSHI\" & thisFlatShortCode & "\" & billYear & "\" & thisBillNo & ".pdf"
                            Case "SAN"
                                thisBillFilePath = getSysParamValue("PATH_WEBSERVER_BILLDIR") & "SANDHYATARA\" & thisFlatShortCode & "\" & billYear & "\" & thisBillNo & ".pdf"
                            Case "SHR"
                                thisBillFilePath = getSysParamValue("PATH_WEBSERVER_BILLDIR") & "SHROBONA\" & thisFlatShortCode & "\" & billYear & "\" & thisBillNo & ".pdf"
                            Case "SUK"
                                thisBillFilePath = getSysParamValue("PATH_WEBSERVER_BILLDIR") & "SUKTARA\" & thisFlatShortCode & "\" & billYear & "\" & thisBillNo & ".pdf"
                        End Select

                        .mailBody = tmpStr
                        .IsBodyHtml = False
                        .Attachments = New String() {thisBillFilePath}
                        .toMailID = thisEmailid
                        '.fromMailID = cboMailer.Text
                        '.mailPWD = txtSMTPPassword.Text
                        .SendMail_BILL()

                        If .sendStatus = True Then
                            gcon.Execute("update tblbill set billMailed=billMailed+1 where tblid=" & billid)
                            frmMain.sslabel3.Text = "Mail sent to:" & thisFlatCode
                            Dim t As Integer
                            For t = txtMailDelay.Text To 0 Step -1
                                lblMsg.Text = "Mail sent to:" & thisFlatCode & ". Waiting for " & t & " seconds..."
                                Application.DoEvents()
                                System.Threading.Thread.Sleep(1000)
                            Next t


                        Else
                            lblMsg.Text = "Interrupted while sending mail to " & thisFlatCode & " !!! All mails may not have been sent"
                            Exit Sub
                        End If
                    End With

                End If
            End If
        Next
        lblMsg.Text = "All mails sent"
        Exit Sub

errH:
        MsgBox(Err.Description)
        lblMsg.Text = "Could not send mail to " & thisFlatCode

    End Sub



    Private Sub chkSelectAll4Mail_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll4Mail.CheckedChanged
        Dim r As Integer

        For r = 0 To dgvFlat.Rows.Count - 1
            If InStr(dgvFlat.Rows(r).Cells("eMail").Value, "@") > 0 Then
                dgvFlat.Rows(r).Cells("chkMail").Value = chkSelectAll4Mail.Checked
            End If
        Next

    End Sub

    Private Sub chkSelectAll4SMS_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll4SMS.CheckedChanged
        Dim r As Integer

        For r = 0 To dgvFlat.Rows.Count - 1
            If IsNumeric(dgvFlat.Rows(r).Cells("Mobile1").Value) = True Then
                dgvFlat.Rows(r).Cells("chkSMS").Value = chkSelectAll4SMS.Checked
            End If
        Next

    End Sub


    Private Sub btnSMSBill_Click(sender As Object, e As EventArgs) Handles btnSMSBill.Click

        On Error GoTo errH
        Dim billMonth As String, thisFlatCode As String, thisDueDate As String, thisBillNo As String, billid As String


        If MsgBox("SMS Bill to selected flats - Confirm", vbYesNo) = vbNo Then Exit Sub

        billMonth = DateTime.Parse(formatInt2Date(pCurBillingDate)).ToString("MMM-yyyy")

        lblMsg.Text = ""

        Dim r As Integer
        For r = 0 To dgvFlat.Rows.Count - 1
            If dgvFlat.Rows(r).Cells("chkSMS").Value = True Then
                thisFlatCode = dgvFlat.Rows(r).Cells("flatCode").Value
                billid = dgvFlat.Rows(r).Cells("tblid").Value
                thisBillNo = dgvFlat.Rows(r).Cells("BillNo").Value
                thisDueDate = formatInt2Date(dgvFlat.Rows(r).Cells("DueDate").Value)

                Dim mySMS As New clsSendSMS
                mySMS.msgID = thisBillNo
                If mySMS.sendSMS4Bill(billMonth, thisFlatCode, thisBillNo, thisDueDate) = True Then
                    gcon.Execute("update tblbill set billSMSed=billSMSed+1 where tblid=" & billid)
                    lblMsg.Text = "SMS sent to:" & thisFlatCode
                    Application.DoEvents()
                End If
            End If

        Next
        lblMsg.Text = "All SMS sent"
        Exit Sub

errH:
        MsgBox(Err.Description)
        lblMsg.Text = "Could not send SMS to " & thisFlatCode
    End Sub

    Private Sub btnShowAllEmailsFromPortal_Click(sender As Object, e As EventArgs) Handles btnShowAllEmailsFromPortal.Click
        Dim pSql As String = "", allEmails As String = "", pRS As ADODB.Recordset
        ''pSql = "select u.email,c.cb_secondaryemail from joomla25schema.j25_users u, joomla25schema.j25_comprofiler c  where u.id = c.user_id and u.block=0 and c.confirmed=1"
        pSql = "select fo.p_email1,fo.p_email2,fo.email1,fo.PrimaryEmail from tblflatowners fo where fo.IsActiveOwner='Y' "
        'pSql = "select fo.email1,fo.PrimaryEmail from tblflatowners fo where fo.IsActiveOwner='Y' "

        pRS = gcon.Execute(pSql)

        While pRS.EOF = False
            allEmails = allEmails & "," & getUniqueValidEmails(pRS("p_email1").Value.ToString, pRS("p_email2").Value.ToString, pRS("email1").Value.ToString, pRS("PrimaryEmail").Value.ToString)

            'If pRS("p_email1").Value.ToString <> "" Then allEmails = allEmails & "," & Trim(pRS("p_email1").Value.ToString)
            'If (pRS("email1").Value.ToString <> pRS("p_email1").Value.ToString And pRS("email1").Value.ToString <> "") Then
            '    If InStr(pRS("email1").Value.ToString, "@") > 0 Then
            '        allEmails = allEmails & "," & Trim(pRS("email1").Value.ToString)
            '    End If
            'End If
            pRS.MoveNext()
        End While
        allEmails = Replace(allEmails, ",,", ",")
        txtAllPortalEmails.Text = myRight(allEmails, Len(allEmails) - 1)
        txtAllPortalEmails.Visible = True
    End Sub
    Function getUniqueValidEmails(e1 As String, e2 As String, e3 As String, e4 As String) As String
        Dim tmp As String
        e1 = LCase(Trim(e1))
        e2 = LCase(Trim(e2))
        e3 = LCase(Trim(e3))
        e4 = LCase(Trim(e4))

        If InStr(e1, "@") = 0 Then e1 = ""
        If InStr(e2, "@") = 0 Then e2 = ""
        If InStr(e3, "@") = 0 Then e3 = ""
        If InStr(e4, "@") = 0 Then e4 = ""

        If InStr(e1, ".") = 0 Then e1 = ""
        If InStr(e2, ".") = 0 Then e2 = ""
        If InStr(e3, ".") = 0 Then e3 = ""
        If InStr(e4, ".") = 0 Then e4 = ""

        tmp = ""
        If e1 <> "" Then tmp = tmp & e1
        If e2 <> "" Then
            If InStr(tmp, e2) = 0 Then tmp = tmp & "," & e2
        End If
        If e3 <> "" Then
            If InStr(tmp, e3) = 0 Then tmp = tmp & "," & e3
        End If
        If e4 <> "" Then
            If InStr(tmp, e4) = 0 Then tmp = tmp & "," & e4
        End If

        getUniqueValidEmails = tmp

    End Function
    Private Sub txtAllPortalEmails_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtAllPortalEmails.MouseDoubleClick
        txtAllPortalEmails.Visible = False
    End Sub

    
    Private Sub btnEvoting_Click(sender As Object, e As EventArgs) Handles btnEvoting.Click
        frmEVoteMailer.ShowDialog()
        frmEVoteMailer.Dispose()
    End Sub

    Private Sub frmBillMailer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBills()
        'cboMailer.SelectedIndex = 0
        'If gRoleCode = "CommitteeMember" Or gRoleCode = "SystemAdmin" Then
        If gLoginID = "sa" Then
            btnShowAllEmailsFromPortal.Visible = True
            btnEvoting.Visible = True
            btnSMSReminder.Visible = True
        End If
    End Sub

    Private Sub btnSMSReminder_Click(sender As Object, e As EventArgs) Handles btnSMSReminder.Click
        If gLoginID <> "sa" Then Exit Sub

        On Error GoTo errH
        Dim thisFlatCode As String

        If MsgBox("SMS Reminder to selected flats - Confirm", vbYesNo) = vbNo Then Exit Sub

        lblMsg.Text = ""

        Dim r As Integer
        For r = 0 To dgvFlat.Rows.Count - 1
            If dgvFlat.Rows(r).Cells("chkSMS").Value = True Then
                thisFlatCode = dgvFlat.Rows(r).Cells("flatCode").Value

                Dim mySMS As New clsSendSMS
                mySMS.msgID = "REM1"
                If mySMS.sendSMS4Reminder("REMINDER-ELECTION", thisFlatCode, "LAST-DATE-FOR-FILING-NOMINATION-TO-GFH-EXECUTIVE-COMMITTEE-ELECTION", "5-OCT-2013") = True Then
                    'gcon.Execute("update tblbill set billSMSed=billSMSed+1 where tblid=" & billid)
                    lblMsg.Text = "Reminder SMS sent to:" & thisFlatCode
                    Application.DoEvents()
                End If
            End If

        Next
        lblMsg.Text = "All SMS sent"
        Exit Sub

errH:
        MsgBox(Err.Description)
        lblMsg.Text = "Could not send Reminder SMS to " & thisFlatCode
        
    End Sub

    

End Class