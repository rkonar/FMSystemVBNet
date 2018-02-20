Public Class frmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        On Error GoTo errH

        'SetConnection()

        tmpRS = gcon.Execute("select * from tblusers where Status='A' and LoginId='" & Trim(UsernameTextBox.Text) & "'")
        If tmpRS.EOF = True Then
            MsgBox("Invalid login credential supplied. Try again.")
            Exit Sub
        End If
        If tmpRS("enc_pwd").Value.ToString <> GenerateHash(PasswordTextBox.Text) Then
            MsgBox("Invalid login credential supplied. Try again.")
            Exit Sub
        End If
        'Set user activity params
        gUserID = tmpRS("tblid").Value.ToString
        gLoginID = tmpRS("LoginID").Value.ToString
        gUserName = tmpRS("FullName").Value.ToString
        gItemCode = "frmLogin"
        gItemAction = "System Login"
        gItemID = "-"
        tmpRS.Close()

        'Check Roles
        tmpRS = gcon.Execute("select ru.RoleID, r.RoleCode from tblmap_role_user ru, tblroles r where r.Status='A' and ru.RoleID = r.tblid and ru.UserID=" & gUserID)
        If tmpRS.EOF = True Then
            MsgBox("Sorry. You do not have sufficient permission to login. Contact System Administrator.")
            Exit Sub
        Else
            While tmpRS.EOF = False
                gRoleID = gRoleID & tmpRS("RoleID").Value.ToString & ","
                gRoleCode = gRoleCode & tmpRS("RoleCode").Value.ToString & ","
                tmpRS.MoveNext()
            End While
            gRoleID = myLeft(gRoleID, Len(gRoleID) - 1)   'remove last comma
            gRoleCode = myLeft(gRoleCode, Len(gRoleCode) - 1)   'remove last comma
        End If

        tmpRS.Close()

        'Check Permission
        getRolePermission()

        If gCanView <> "Y" Then
            MsgBox("Sorry. You do not have sufficient permission to login. Contact System Administrator.")
            Exit Sub
        End If

        If logUserActivity() = False Then Exit Sub
        frmMain.Show()
        Exit Sub
errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Public Sub resetForm()
        UsernameTextBox.Text = ""
        PasswordTextBox.Text = ""
        gLoginID = ""
        gUserID = ""
        gRoleID = ""
    End Sub

    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If SetConnection() = False Then
            OK.Enabled = False
        Else
            reloadCache()
            resetForm()
        End If
       
    End Sub

   
    Private Sub LogoPictureBox_Click(sender As Object, e As EventArgs) Handles LogoPictureBox.Click
        frmGeneratePassword.ShowDialog()
        frmGeneratePassword.Dispose()
    End Sub
End Class
