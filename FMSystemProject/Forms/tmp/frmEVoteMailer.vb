Public Class frmEVoteMailer

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
        flSql = "select fo.* from tblflatowners fo "
        flSql = flSql & " where fo.IsActiveOwner='Y' and fo.FlatCode like '%" & towerCode & "%'"
        flSql = flSql & " order by FlatCode"
        flatRS = gcon.Execute(flSql)

        With dgvFlat

            While flatRS.EOF = False
                pem = flatRS("evoting_mailid").Value.ToString
                'em = flatRS("email1").Value.ToString
                'mob1 = flatRS("mobile1").Value.ToString

                i = .Rows.Add()
                .Rows(i).Cells("tblid").Value = flatRS("tblid").Value.ToString
                '.Rows(i).Cells("BillNo").Value = flatRS("BillNo").Value.ToString
                .Rows(i).Cells("flatCode").Value = flatRS("FlatCode").Value.ToString
                '.Rows(i).Cells("DueDate").Value = flatRS("DueDate").Value.ToString
                'If flatRS("billMailed").Value.ToString = "" Then
                .Rows(i).Cells("billMailed").Value = flatRS("evoting_mail_verification_sent").Value.ToString
                '.Rows(i).Cells("billSMSed").Value = flatRS("billSMSed").Value.ToString
                'Else
                '.Rows(i).Cells("billMailed").Value = "Yes"
                'End If
                If ((pem <> "") And (InStr(pem, "@") > 0)) Then
                  
                    .Rows(i).Cells("evoting_mailid").Value = pem

                    dgvFlat.Rows(i).Cells("chkMail").Value = chkSelectAll4Mail.Checked
                Else 'invalid email
                    '.Rows(i).Cells("evoting_mailid").Value = "invalid or no email"
                    dgvFlat.Rows(i).Cells("chkMail").ReadOnly = True
                    dgvFlat.Rows(i).Cells("chkMail").Style.BackColor = Color.Red
                    '.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If
                '.Rows(i).Cells("Mobile1").Value = mob1
                'If mob1 <> "" Then
                '    dgvFlat.Rows(i).Cells("chkSMS").Value = chkSelectAll4SMS.Checked
                'Else
                '    dgvFlat.Rows(i).Cells("chkSMS").ReadOnly = True
                '    dgvFlat.Rows(i).Cells("chkSMS").Style.BackColor = Color.Red
                'End If

                .Rows(i).Cells("ownerName").Value = flatRS("OwnerFullName").Value.ToString

                If flatRS("CoOwnerFullName").Value.ToString <> "" Then
                    .Rows(i).Cells("ownerName").Value = .Rows(i).Cells("ownerName").Value & ", " & flatRS("CoOwnerFullName").Value.ToString
                End If

                .Rows(i).Cells("AllEmails").Value = getUniqueValidEmails(flatRS("p_email1").Value.ToString, flatRS("p_email2").Value.ToString, flatRS("email1").Value.ToString, flatRS("PrimaryEmail").Value.ToString)

                'If flatRS("p_softBill").Value.ToString = "Y" Then
                '    .Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
                '    .Rows(i).Cells("softBill").Value = "Yes"
                'Else
                '    .Rows(i).Cells("softBill").Value = "No"
                'End If
                'If flatRS("usingPortal").Value.ToString = "Y" Then
                '    .Rows(i).Cells("UsingPortal").Value = "Yes"
                'Else
                '    .Rows(i).Cells("UsingPortal").Value = "No"
                'End If

                flatRS.MoveNext()
            End While

        End With

    End Sub



    Private Sub btnMailBill_Click(sender As System.Object, e As System.EventArgs) Handles btnMailBill.Click
        On Error GoTo errH
        Dim myMailer As New clsSendMail, billMonth As String, billYear As String, thisFlatCode As String, thisFlatShortCode As String, thisOwnerName As String, thisEmailid As String, thisAllEmails As String, billid As String, thisBillNo As String, isSoftBill As String, IsUsingPortal As String, tmpStr As String, thisBillFilePath As String = ""


        If MsgBox("Email Bill to selected flats - Confirm", vbYesNo) = vbNo Then Exit Sub

        'billMonth = DateTime.Parse(formatInt2Date(pCurBillingDate)).ToString("MMM-yyyy")
        'billYear = DateTime.Parse(formatInt2Date(pCurBillingDate)).ToString("yyyy")

        lblMsg.Text = ""

        Dim r As Integer
        For r = 0 To dgvFlat.Rows.Count - 1
            If dgvFlat.Rows(r).Cells("chkMail").Value = True Then
                thisFlatCode = dgvFlat.Rows(r).Cells("flatCode").Value
                thisFlatShortCode = stripLeadingZero(myRight(thisFlatCode, 3))
                billid = dgvFlat.Rows(r).Cells("tblid").Value
                'thisBillNo = dgvFlat.Rows(r).Cells("BillNo").Value
                thisOwnerName = dgvFlat.Rows(r).Cells("ownerName").Value
                thisEmailid = dgvFlat.Rows(r).Cells("evoting_mailid").Value
                thisAllEmails = Trim(dgvFlat.Rows(r).Cells("AllEmails").Value)
                'isSoftBill = dgvFlat.Rows(r).Cells("softBill").Value
                'IsUsingPortal = dgvFlat.Rows(r).Cells("UsingPortal").Value
                tmpStr = ""
                If thisEmailid <> "" Then
                    With myMailer

                        lblMsg.Text = "Sending mail to " & thisFlatCode

                        .mailSubject = "Confirmation of your eVoting Mail ID: " & thisEmailid & " for Flat: " & thisFlatCode & " in Greenfield Heights HIG, Newtown"

                        tmpStr = "Dear " & thisOwnerName

                        'tmpStr = tmpStr & "<br>We noticed a minor glitch in the Jul-2012 bill mailed to you earlier. We have corrected the same. Your revised maintenance bill for " & billMonth & " is attached."
                        'tmpStr = tmpStr & "<br>Please ignore the previous bill. Sorry for any inconveniences caused."
                        tmpStr = tmpStr & "<br><br>This mail is to confirm your <B>'registered email-id for the e-Voting purpose'</B> as mentioned in earlier email communication 'ELECTION TO EXECUTIVE COMMITTEE - GFH HIG ASSOCIATIO​N' dtd. 16/9/2013."
                        tmpStr = tmpStr & "<br><br>Based on data furnished by you earlier while registering your contact details with Facility Management System, the eVoting mail id for your flat has been identified."
                        tmpStr = tmpStr & "<br><br><br><B>Please note that your 'registered email-id for the e-Voting purpose' is : " & thisEmailid & "</B><br><br><br>"
                        tmpStr = tmpStr & "<br><B>Once the eVoting window opens (refer already published election schedule), you may exercise your voting right by sending a mail from " & thisEmailid & " mailid only."
                        tmpStr = tmpStr & "<br>The mail need to be sent to eBallot Mail Box ID which will be shared later."
                        tmpStr = tmpStr & "<br>You will also need to mention your flat no in the eVoting mail incase you own duplex or multiple flats and using same eVoting mail id for all flats</B><br>"
                        tmpStr = tmpStr & "<br>This communication is being copied to your all emails ids registered in FM system or Portal.<br>"
                        tmpStr = tmpStr & "<br><B>INCASE, YOU WISH TO SELECT A DIFFERENT EMAIL-ID FOR eVoting</B>, please let us know the new eVoting mail id by replying to this mail before the deadline mentioned in election schedule.<br>"
                        tmpStr = tmpStr & "<br> Upon receiving such alteration request, the eVoting mail id will be updated against your flat and we will confirm you back via reply email.<br>"
                        tmpStr = tmpStr & "<br>The final list of flat wise eVoting email ids will be published as per election schedule shared earlier.<br>"

                        tmpStr = tmpStr & "<br><br>With Warm Regards,"
                        tmpStr = tmpStr & "<br>Facility Manager"
                        tmpStr = tmpStr & "<br>Greenfield Heights HIG"
                        tmpStr = tmpStr & "<br>tothefm.gfh.hig@gmail.com"
                        tmpStr = tmpStr & "<br>033-23245051"
                        tmpStr = tmpStr & "<br>" & DateTime.Now.ToString("dd-MMM-yyyy HH:mm") & " IST"

                        .mailBody = tmpStr
                        .IsBodyHtml = True
                        .toMailID = thisEmailid
                        .ccMailID = thisAllEmails
                        .SendMail_eVoting()

                        If .sendStatus = True Then
                            gcon.Execute("update tblflatowners set evoting_mail_verification_sent=evoting_mail_verification_sent+1 where tblid=" & billid)
                            frmMain.sslabel3.Text = "Mail sent to:" & thisFlatCode
                            Application.DoEvents()
                        Else
                            lblMsg.Text = "Interrupted!!! All mails may not have been sent"
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
            If InStr(dgvFlat.Rows(r).Cells("evoting_mailid").Value, "@") > 0 Then
                dgvFlat.Rows(r).Cells("chkMail").Value = chkSelectAll4Mail.Checked
            End If
        Next

    End Sub



   

    Private Sub btnShowAllEmailsFromPortal_Click(sender As Object, e As EventArgs) Handles btnShowAllEmailsFromPortal.Click
        Dim pSql As String = "", allEmails As String = "", pRS As ADODB.Recordset
        'pSql = "select u.email,c.cb_secondaryemail from joomla25schema.j25_users u, joomla25schema.j25_comprofiler c  where u.id = c.user_id and u.block=0 and c.confirmed=1"
        pSql = "select fo.p_email1,fo.p_email2,fo.email1,fo.PrimaryEmail from tblflatowners fo where fo.IsActiveOwner='Y' "

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

        If myLeft(tmp, 1) = "," Then tmp = myRight(tmp, Len(tmp) - 1)

        getUniqueValidEmails = tmp

    End Function
    Private Sub txtAllPortalEmails_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtAllPortalEmails.MouseDoubleClick
        txtAllPortalEmails.Visible = False
    End Sub

    Private Sub frmEVoteMailer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If gRoleCode <> "SystemAdmin" Then
            MsgBox("Not allowed")
            Me.Close()
        End If
    End Sub

    Private Sub btnSMSBill_Click(sender As Object, e As EventArgs) Handles btnSMSBill.Click

    End Sub
End Class