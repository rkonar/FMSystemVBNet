Public Class frmManageRole

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo errH

        If Trim(txtRoleCode.Text) = "" Then
            MsgBox("Enter Role Code.")
            Exit Sub
        End If
        If Trim(txtRoleDesc.Text) = "" Then
            MsgBox("Enter Role Description.")
            Exit Sub
        End If

        If gCurRoleID = "" Then

            tmpRS = gcon.Execute("select * from tblroles where RoleCode='" & txtRoleCode.Text & "'")
            If tmpRS.EOF = False Then
                MsgBox("This role code already exist")
                Exit Sub
            End If

            ssql = "Insert into tblroles (RoleCode, RoleDesc, Status) values ('" & txtRoleCode.Text & "','" & txtRoleDesc.Text & "'"

            If optActive.Checked = True Then
                ssql = ssql & ",'A'"
            Else
                ssql = ssql & ",'I'"
            End If
            ssql = ssql & ")"
        Else
            ssql = "Update tblroles set"
            ssql = ssql & " RoleCode='" & txtRoleCode.Text & "'"
            ssql = ssql & ", RoleDesc='" & txtRoleDesc.Text & "'"
            If optActive.Checked = True Then
                ssql = ssql & ", Status='A'"
            Else
                ssql = ssql & ", Status='I'"
            End If

            ssql = ssql & " where tblid=" & gCurRoleID
        End If

        gcon.Execute(ssql)

        If gCurRoleID = "" Then
            gItemAction = "Create"
        Else
            gItemAction = "Update"
        End If

        gItemCode = "Role"
        gItemID = gCurRoleCode
        If logUserActivity() = False Then Exit Sub

        MsgBox("Done")

        resetFields()
        Me.Close()
        Exit Sub
errH:
        MsgBox(Err.Description)
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub resetFields()
        txtRoleCode.Text = ""
        txtRoleDesc.Text = ""
        optInactive.Checked = True
        gCurRoleID = ""
        gCurRoleCode = ""
        gCurRoleDesc = ""
        gCurRoleStatus = "I"
    End Sub

    Private Sub frmManageRole_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtRoleCode.Text = gCurRoleCode
        txtRoleDesc.Text = gCurRoleDesc
        If gCurRoleStatus = "A" Then optActive.Checked = True
    End Sub
End Class
