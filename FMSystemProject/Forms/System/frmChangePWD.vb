Public Class frmChangePWD


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        On Error GoTo errH

        If txtNewPWD.Text <> txtNewPWD2.Text Then
            MsgBox("Mismatch in 'New Password' and 'Confirm New Password'.")
            Exit Sub
        End If

        tmpRS = gcon.Execute("select * from tblusers where Status='A' and tblid=" & gUserID)
        If tmpRS.EOF = True Then
            MsgBox("Invalid session. Closing the session.")
            frmLogin.Close()
        End If

        If tmpRS("enc_pwd").Value.ToString <> GenerateHash(txtOldPWD.Text) Then
            MsgBox("Incorrect old password. Try again.")
            Exit Sub
        End If

        gcon.Execute("update tblusers set enc_pwd='" & GenerateHash(txtNewPWD.Text) & "' where tblid=" & gUserID)
        gItemAction = "Update"
        gItemCode = "UserPassword"
        gItemID = gLoginID
        If logUserActivity() = False Then Exit Sub

        MsgBox("Password change successful. Pls. re-login.")
        frmMain.Close()

        gItemAction = "Logoff"
        gItemCode = "System Logoff"
        gItemID = gLoginID
        If logUserActivity() = False Then Exit Sub


        gLoginID = ""
        gUserName = ""
        frmLogin.resetForm()
        frmLogin.Show()

        Me.Close()
        Me.Dispose()

        Exit Sub
errH:
        MsgBox(Err.Description)
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose
    End Sub

End Class
