Public Class frmAccessManager
    Dim fromTV As String, activeNode As TreeNode

    Private Sub frmAccessManager_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadComponents()
        loadRoles()
        loadUsers()
    End Sub

    Sub loadComponents()
        On Error GoTo errH

        Dim pNode As TreeNode, thisNode As TreeNode, componentRS As ADODB.Recordset

        componentRS = gcon.Execute("select * from tblcomponents")
        If componentRS.EOF = True Then
            MsgBox("Components table corrupted. Contact System Administrator.")
            Exit Sub
        End If
        tvComponents.Nodes.Clear()
        tvComponents.BeginUpdate()
        pNode = tvComponents.Nodes.Add("All")
        While componentRS.EOF = False

            thisNode = pNode.Nodes.Add(componentRS("ComponentDesc").Value.ToString)
            thisNode.ToolTipText = componentRS("tblid").Value.ToString
            thisNode.Tag = componentRS("tblid").Value.ToString & "|" & componentRS("ComponentName").Value.ToString & "|" & componentRS("ComponentDesc").Value.ToString & "|" & componentRS("Status").Value.ToString & "|"


            loadRoles4Component(thisNode)

            componentRS.MoveNext()
        End While
        tvComponents.EndUpdate()

        tvComponents.Nodes(0).Expand()


        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Sub loadRoles()
        On Error GoTo errH

        Dim pNode As TreeNode, thisNode As TreeNode, rolesRS As ADODB.Recordset

        rolesRS = gcon.Execute("select * from tblroles")
        If rolesRS.EOF = True Then
            MsgBox("Roles table corrupted. Contact System Administrator.")
            Exit Sub
        End If
        tvRoles.Nodes.Clear()
        tvRoles.BeginUpdate()
        pNode = tvRoles.Nodes.Add("All")
        While rolesRS.EOF = False

            thisNode = pNode.Nodes.Add(rolesRS("RoleDesc").Value.ToString)
            thisNode.ToolTipText = rolesRS("tblid").Value.ToString
            thisNode.Tag = rolesRS("tblid").Value.ToString & "|" & rolesRS("RoleCode").Value.ToString & "|" & rolesRS("RoleDesc").Value.ToString & "|" & rolesRS("Status").Value.ToString & "|"
            If rolesRS("Status").Value.ToString = "I" Then
                thisNode.BackColor = Color.Gray
            End If
            loadUsers4Role(thisNode)

            rolesRS.MoveNext()
        End While
        tvRoles.EndUpdate()

        tvRoles.Nodes(0).Expand()


        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Sub loadUsers()
        On Error GoTo errH

        Dim pNode As TreeNode, thisNode As TreeNode, usersRS As ADODB.Recordset

        usersRS = gcon.Execute("select * from tblusers")
        If usersRS.EOF = True Then
            MsgBox("Users table corrupted. Contact System Administrator.")
            Exit Sub
        End If
        tvUsers.Nodes.Clear()
        tvUsers.BeginUpdate()
        pNode = tvUsers.Nodes.Add("All")
        While usersRS.EOF = False

            thisNode = pNode.Nodes.Add(usersRS("FullName").Value.ToString)
            thisNode.ToolTipText = usersRS("tblid").Value.ToString
            thisNode.Tag = usersRS("tblid").Value.ToString & "|" & usersRS("LoginID").Value.ToString & "|" & usersRS("FullName").Value.ToString & "|" & usersRS("Address").Value.ToString & "|" & usersRS("Landline").Value.ToString & "|" & usersRS("Mobile").Value.ToString & "|" & usersRS("Status").Value.ToString

            usersRS.MoveNext()
        End While
        tvUsers.EndUpdate()

        tvUsers.Nodes(0).Expand()


        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Sub loadRoles4Component(curComponentNode As TreeNode)
        On Error GoTo errH

        Dim thisNode As TreeNode, tmpNode As TreeNode, roleComponentRS As ADODB.Recordset, permString As String

        roleComponentRS = gcon.Execute("select rc.tblid,rc.canView,rc.canCreate,rc.canEdit,rc.canDelete,r.RoleDesc from tblmap_role_component rc, tblroles r where r.tblid=rc.RoleID and rc.ComponentID=" & curComponentNode.ToolTipText)
        'If roleComponentRS.EOF = True Then
        '    MsgBox("Components table corrupted. Contact System Administrator.")
        '    Exit Sub
        'End If
        curComponentNode.Nodes.Clear()
        While roleComponentRS.EOF = False

            thisNode = curComponentNode.Nodes.Add(roleComponentRS("RoleDesc").Value.ToString)
            thisNode.ToolTipText = roleComponentRS("tblid").Value.ToString

            'permString = "View=" & roleComponentRS("canView").Value.ToString & ",Create=" & roleComponentRS("canCreate").Value.ToString & ",Edit=" & roleComponentRS("canEdit").Value.ToString & ",Delete=" & roleComponentRS("canDelete").Value.ToString
            tmpNode = thisNode.Nodes.Add("View=" & roleComponentRS("canView").Value.ToString)
            tmpNode.Tag = "V"
            tmpNode = thisNode.Nodes.Add("Create=" & roleComponentRS("canCreate").Value.ToString)
            tmpNode.Tag = "C"
            tmpNode = thisNode.Nodes.Add("Edit=" & roleComponentRS("canEdit").Value.ToString)
            tmpNode.Tag = "E"
            tmpNode = thisNode.Nodes.Add("Delete=" & roleComponentRS("canDelete").Value.ToString)
            tmpNode.Tag = "D"

            For Each tmpNode In thisNode.Nodes
                If myRight(tmpNode.Text, 1) = "Y" Then
                    tmpNode.ForeColor = Color.Green
                Else
                    tmpNode.ForeColor = Color.Red
                End If
            Next


            roleComponentRS.MoveNext()
        End While

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Sub loadUsers4Role(curRoleNode As TreeNode)
        On Error GoTo errH

        Dim thisNode As TreeNode, tmpNode As TreeNode, userRoleRS As ADODB.Recordset

        userRoleRS = gcon.Execute("select ru.UserID,u.FullName from tblmap_role_user ru, tblusers u where u.tblid=ru.UserID and ru.RoleID=" & curRoleNode.ToolTipText)
        'If userRoleRS.EOF = True Then
        '    MsgBox("Components table corrupted. Contact System Administrator.")
        '    Exit Sub
        'End If
        curRoleNode.Nodes.Clear()
        While userRoleRS.EOF = False

            thisNode = curRoleNode.Nodes.Add(userRoleRS("FullName").Value.ToString)
            thisNode.ToolTipText = userRoleRS("UserID").Value.ToString

            userRoleRS.MoveNext()
        End While

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub


    Private Sub tvComponents_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvComponents.NodeMouseClick
        tvComponents.SelectedNode = e.Node
        activeNode = e.Node

        If e.Button = Windows.Forms.MouseButtons.Right Then

            cmsPermission.Show()
            cmsPermission.Left = Cursor.Position.X
            cmsPermission.Top = Cursor.Position.Y
            tsmiCreateUser.Visible = False
            tsmiEditUser.Visible = False
            tsmiCreateRole.Visible = False
            tsmiEditRole.Visible = False


            tsmiAllow.Text = "Allow"
            tsmiDeny.Text = "Deny"

            If e.Node.IsExpanded = True Then
                tsmiExpand.Visible = False
                tsmiExpandAll.Visible = True
                tsmiCollapse.Visible = True
                tsmiCollapseAll.Visible = True
            Else
                tsmiExpand.Visible = True
                tsmiExpandAll.Visible = True
                tsmiCollapse.Visible = False
                tsmiCollapseAll.Visible = False
            End If


            If e.Node.Level = 0 Then

                tsmiAllow.Visible = False
                tsmiDeny.Visible = False
                tsmiAllowAll.Visible = False
                tsmiDenyAll.Visible = False

            ElseIf e.Node.Level = 1 Then

                tsmiAllow.Visible = False
                tsmiDeny.Visible = False
                tsmiAllowAll.Visible = False
                tsmiDenyAll.Visible = False

            ElseIf e.Node.Level = 2 Then

                tsmiExpand.Visible = False
                tsmiExpandAll.Visible = False
                tsmiCollapse.Visible = False
                tsmiCollapseAll.Visible = False

                tsmiAllow.Visible = False
                tsmiDeny.Visible = False

                e.Node.Expand()

                tsmiAllowAll.Visible = False
                tsmiDenyAll.Visible = False

                For Each tmpNode In e.Node.Nodes
                    If myRight(tmpNode.text, 1) <> "Y" Then
                        tsmiAllowAll.Visible = True
                        Exit For
                    End If
                Next
                For Each tmpNode In e.Node.Nodes
                    If myRight(tmpNode.text, 1) <> "N" Then
                        tsmiDenyAll.Visible = True
                        Exit For
                    End If
                Next

            ElseIf e.Node.Level = 3 Then

                tsmiExpand.Visible = False
                tsmiExpandAll.Visible = False
                tsmiCollapse.Visible = False
                tsmiCollapseAll.Visible = False

                tsmiAllowAll.Visible = False
                tsmiDenyAll.Visible = False
                tsmiAllow.Visible = False
                tsmiDeny.Visible = False

                If myRight(e.Node.Text, 1) = "Y" Then
                    tsmiDeny.Visible = True
                Else
                    tsmiAllow.Visible = True
                End If

                Select Case (e.Node.Text)
                    Case "V"
                        tsmiAllow.Text = tsmiAllow.Text & " View"
                        tsmiDeny.Text = tsmiAllow.Text & " View"
                    Case "C"
                        tsmiAllow.Text = tsmiAllow.Text & " Create"
                        tsmiDeny.Text = tsmiAllow.Text & " Create"
                    Case "E"
                        tsmiAllow.Text = tsmiAllow.Text & " Edit"
                        tsmiDeny.Text = tsmiAllow.Text & " Edit"
                    Case "D"
                        tsmiAllow.Text = tsmiAllow.Text & " Delete"
                        tsmiDeny.Text = tsmiAllow.Text & " Delete"

                End Select

            Else
                Exit Sub
            End If

        End If
    End Sub

    Private Sub tvRoles_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvRoles.NodeMouseClick
        tvRoles.SelectedNode = e.Node
        activeNode = e.Node

        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmsPermission.Show()
            cmsPermission.Left = Cursor.Position.X
            cmsPermission.Top = Cursor.Position.Y

            tsmiCreateUser.Visible = False
            tsmiEditUser.Visible = False
            tsmiCreateRole.Visible = True
            tsmiEditRole.Visible = True

            tsmiAllow.Visible = False
            tsmiAllowAll.Visible = False
            tsmiDeny.Visible = False
            tsmiDenyAll.Visible = False

            If e.Node.IsExpanded = True Then
                tsmiExpand.Visible = False
                tsmiExpandAll.Visible = True
                tsmiCollapse.Visible = True
                tsmiCollapseAll.Visible = True
            Else
                tsmiExpand.Visible = True
                tsmiExpandAll.Visible = True
                tsmiCollapse.Visible = False
                tsmiCollapseAll.Visible = False
            End If

        End If
    End Sub

    Private Sub tvUsers_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvUsers.NodeMouseClick
        tvRoles.SelectedNode = e.Node
        activeNode = e.Node

        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmsPermission.Show()
            cmsPermission.Left = Cursor.Position.X
            cmsPermission.Top = Cursor.Position.Y

            tsmiCreateUser.Visible = True
            tsmiEditUser.Visible = True
            tsmiCreateRole.Visible = False
            tsmiEditRole.Visible = False

            tsmiExpandAll.Visible = False
            tsmiCollapseAll.Visible = False

            tsmiAllow.Visible = False
            tsmiAllowAll.Visible = False
            tsmiDeny.Visible = False
            tsmiDenyAll.Visible = False

            If e.Node.Level = 0 Then
                tsmiExpand.Visible = False
                tsmiCollapse.Visible = True
            Else
                tsmiExpand.Visible = True
                tsmiCollapse.Visible = False

            End If
        End If
    End Sub

    
    Private Sub tsmiExpandAll_Click(sender As System.Object, e As System.EventArgs) Handles tsmiExpandAll.Click
        activeNode.ExpandAll()
    End Sub

    Private Sub tsmiExpand_Click(sender As System.Object, e As System.EventArgs) Handles tsmiExpand.Click
        activeNode.Expand()
    End Sub

    Private Sub tsmiCollapse_Click(sender As System.Object, e As System.EventArgs) Handles tsmiCollapse.Click
        activeNode.Collapse()
    End Sub
    Private Sub tsmiCollapseAll_Click(sender As System.Object, e As System.EventArgs) Handles tsmiCollapseAll.Click
        activeNode.TreeView.CollapseAll()
    End Sub

    Private Sub tsmiAllow_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAllow.Click
        On Error GoTo errH
        Dim curNode As TreeNode

        curNode = tvComponents.SelectedNode

        ssql = "update tblmap_role_component set "

        Select Case (curNode.Tag)
            Case "V"
                ssql = ssql & "canView='Y'"
            Case "C"
                ssql = ssql & "canCreate='Y'"
            Case "E"
                ssql = ssql & "canEdit='Y'"
            Case "D"
                ssql = ssql & "canDelete='Y'"
        End Select

        ssql = ssql & " where tblid=" & curNode.Parent.ToolTipText
        gcon.Execute(ssql)

        MsgBox("Done")
        loadComponents()
        tvComponents.SelectedNode = curNode

        Exit Sub

errH:
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Private Sub tsmiDeny_Click(sender As System.Object, e As System.EventArgs) Handles tsmiDeny.Click
        On Error GoTo errH

        Dim curNode As TreeNode

        curNode = tvComponents.SelectedNode

        ssql = "update tblmap_role_component set "

        Select Case (curNode.Tag)
            Case "V"
                ssql = ssql & "canView='N'"
            Case "C"
                ssql = ssql & "canCreate='N'"
            Case "E"
                ssql = ssql & "canEdit='N'"
            Case "D"
                ssql = ssql & "canDelete='N'"
        End Select

        ssql = ssql & " where tblid=" & curNode.Parent.ToolTipText
        gcon.Execute(ssql)

        MsgBox("Done")
        loadComponents()
        tvComponents.SelectedNode = curNode
        Exit Sub

errH:
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Private Sub tsmiAllowAll_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAllowAll.Click
        On Error GoTo errH
        Dim curNode As TreeNode

        curNode = tvComponents.SelectedNode

        ssql = "update tblmap_role_component set "

        ssql = ssql & "canView='Y'"
        ssql = ssql & ",canCreate='Y'"
        ssql = ssql & ",canEdit='Y'"
        ssql = ssql & ",canDelete='Y'"

        ssql = ssql & " where tblid=" & curNode.ToolTipText
        gcon.Execute(ssql)

        MsgBox("Done")
        loadComponents()
        tvComponents.SelectedNode = curNode
        Exit Sub

errH:
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Private Sub tsmiDenyAll_Click(sender As System.Object, e As System.EventArgs) Handles tsmiDenyAll.Click
        On Error GoTo errH
        Dim curNode As TreeNode

        curNode = tvComponents.SelectedNode

        ssql = "update tblmap_role_component set "

        ssql = ssql & "canView='N'"
        ssql = ssql & ",canCreate='N'"
        ssql = ssql & ",canEdit='N'"
        ssql = ssql & ",canDelete='N'"

        ssql = ssql & " where tblid=" & curNode.ToolTipText
        gcon.Execute(ssql)

        MsgBox("Done")
        loadComponents()
        tvComponents.SelectedNode = curNode
        Exit Sub

errH:
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    
    
    Private Sub tvComponents_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles tvComponents.DragDrop
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)

        'Get the TreeNode being dragged
        Dim dropNode As TreeNode = _
              CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

        'The target node should be selected from the DragOver event
        Dim targetNode As TreeNode = selectedTreeview.SelectedNode

        'Write code to perform action after drag drop to valid target node - rk
        If fromTV = "ROLE" Then
            If targetNode Is Nothing Then
                e.Effect = DragDropEffects.None
                Exit Sub
            End If
            If targetNode.Level <> 1 Then
                e.Effect = DragDropEffects.None
                Exit Sub
            End If
            ssql = "insert into tblmap_role_component (RoleID,ComponentID) values (" & dropNode.ToolTipText & "," & targetNode.ToolTipText & ")"
            gcon.Execute(ssql)
            loadComponents()
        End If


    End Sub
    Private Sub tvRoles_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles tvRoles.DragDrop
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)

        'Get the TreeNode being dragged
        Dim dropNode As TreeNode = _
              CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

        'The target node should be selected from the DragOver event
        Dim targetNode As TreeNode = selectedTreeview.SelectedNode

        'Write code to perform action after drag drop to valid target node - rk
        If fromTV = "COMPONENT" Then
            ssql = "delete from tblmap_role_component where tblid=" & dropNode.ToolTipText
            gcon.Execute(ssql)
            loadComponents()
        ElseIf fromTV = "USER" Then
            If targetNode Is Nothing Then
                e.Effect = DragDropEffects.None
                Exit Sub
            End If
            If targetNode.Level <> 1 Then
                e.Effect = DragDropEffects.None
                Exit Sub
            End If
            ssql = "insert into tblmap_role_user (UserID,RoleID) values (" & dropNode.ToolTipText & "," & targetNode.ToolTipText & ")"
            gcon.Execute(ssql)
            loadRoles()
        End If

    End Sub
    Private Sub tvUsers_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles tvUsers.DragDrop
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)

        'Get the TreeNode being dragged
        Dim dropNode As TreeNode = _
              CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

        'The target node should be selected from the DragOver event
        Dim targetNode As TreeNode = selectedTreeview.SelectedNode

        'Write code to perform action after drag drop to valid target node - rk
        If fromTV = "ROLE" Then
            ssql = "delete from tblmap_role_user where UserID=" & dropNode.ToolTipText & " and RoleID=" & dropNode.Parent.ToolTipText
            gcon.Execute(ssql)
            loadRoles()
        End If
    End Sub

    Private Sub tvComponents_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles tvComponents.DragOver
        If fromTV <> "ROLE" Then
            e.Effect = DragDropEffects.None
            Exit Sub
        End If
        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

        If dropNode.Level <> 1 Then
            e.Effect = DragDropEffects.None
            Exit Sub
        End If

        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)

        'As the mouse moves over nodes, provide feedback to the user by highlighting the node that is the current drop target
        Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim targetNode As TreeNode = selectedTreeview.GetNodeAt(pt)

        

        'See if the targetNode is currently selected, 
        'if so no need to validate again
        'If Not (selectedTreeview.SelectedNode Is targetNode) Then
        'Select the    node currently under the cursor
        'selectedTreeview.Focus()
        'selectedTreeview.SelectedNode = targetNode

        Dim childNode As TreeNode
        If targetNode IsNot Nothing Then
            If targetNode.Level = 1 Then
                For Each childNode In targetNode.Nodes
                    If childNode.Text = dropNode.Text Then
                        e.Effect = DragDropEffects.None
                        Exit Sub
                    End If
                Next
                'Currently selected node is a suitable target

            Else
                e.Effect = DragDropEffects.None
                Exit Sub
            End If
        Else
            e.Effect = DragDropEffects.None
            Exit Sub
        End If

        e.Effect = DragDropEffects.Copy
        'End If

    End Sub
    Private Sub tvRoles_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles tvRoles.DragOver
        If fromTV = "ROLE" Then
            e.Effect = DragDropEffects.None
            Exit Sub
        End If

        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)
        

        'As the mouse moves over nodes, provide feedback to the user by highlighting the node that is the current drop target
        Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim targetNode As TreeNode = selectedTreeview.GetNodeAt(pt)

        

        'See if the targetNode is currently selected, 
        'if so no need to validate again
        If Not (selectedTreeview.SelectedNode Is targetNode) Then
            'Select the node currently under the cursor
            selectedTreeview.Focus()
            selectedTreeview.SelectedNode = targetNode

            Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

            Dim childNode As TreeNode
            If targetNode IsNot Nothing Then
                If targetNode.Level = 1 Then
                    For Each childNode In targetNode.Nodes
                        If childNode.Text = dropNode.Text Then
                            e.Effect = DragDropEffects.None
                            Exit Sub
                        End If
                    Next
                    'Currently selected node is a suitable target
                    e.Effect = DragDropEffects.Copy
                Else
                    e.Effect = DragDropEffects.None
                End If
            End If

        End If
    End Sub
    Private Sub tvUsers_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles tvUsers.DragOver
        If fromTV <> "ROLE" Then
            e.Effect = DragDropEffects.None
            Exit Sub
        End If

        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
        If dropNode.Level <> 2 Then
            e.Effect = DragDropEffects.None
            Exit Sub
        Else
            e.Effect = DragDropEffects.Copy
        End If
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        ''Get the TreeView raising the event (incase multiple on form)
        'Dim selectedTreeview As TreeView = CType(sender, TreeView)


        ''As the mouse moves over nodes, provide feedback to the user by highlighting the node that is the current drop target
        'Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        'Dim targetNode As TreeNode = selectedTreeview.GetNodeAt(pt)
        'If targetNode Is Nothing Then
        '    e.Effect = DragDropEffects.None
        '    Exit Sub
        'End If

        'See if the targetNode is currently selected, 
        'if so no need to validate again
        'If Not (selectedTreeview.SelectedNode Is targetNode) Then
        '    'Select the node currently under the cursor
        '    selectedTreeview.Focus()
        '    selectedTreeview.SelectedNode = targetNode

        
        '    'Dim childNode As TreeNode
        '    'If targetNode IsNot Nothing Then
        '    '    If targetNode.Level = 1 Then
        '    '        For Each childNode In targetNode.Nodes
        '    '            If childNode.Text = dropNode.Text Then
        '    '                e.Effect = DragDropEffects.None
        '    '                Exit Sub
        '    '            End If
        '    '        Next
        '    '        'Currently selected node is a suitable target
        '    '        e.Effect = DragDropEffects.Copy
        '    '    Else
        '    '        e.Effect = DragDropEffects.None
        '    '    End If
        '    'End If

        'End If
    End Sub

    Private Sub tvComponents_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles tvComponents.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            'TreeNode found allow copy effect
            e.Effect = DragDropEffects.Copy
        Else
            'No TreeNode found, prevent copy
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub tvRoles_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles tvRoles.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            'TreeNode found allow copy effect
            e.Effect = DragDropEffects.Copy
        Else
            'No TreeNode found, prevent copy
            e.Effect = DragDropEffects.None
        End If
        'If tvRoles.SelectedNode Is Nothing Then
        '    e.Effect = DragDropEffects.None
        '    Exit Sub
        'End If
    End Sub
    Private Sub tvUsers_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles tvUsers.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            'TreeNode found allow copy effect
            e.Effect = DragDropEffects.Copy
        Else
            'No TreeNode found, prevent copy
            e.Effect = DragDropEffects.None
        End If
        'If tvUsers.SelectedNode Is Nothing Then
        '    e.Effect = DragDropEffects.None
        '    Exit Sub
        'End If
    End Sub

    Private Sub tvComponents_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles tvComponents.ItemDrag
        'If tvComponents.SelectedNode Is Nothing Then
        '    DoDragDrop(e.Item, DragDropEffects.None)
        '    Exit Sub
        'End If
        If tvComponents.SelectedNode.Level = 2 Then DoDragDrop(e.Item, DragDropEffects.Copy)
    End Sub
    Private Sub tvRoles_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles tvRoles.ItemDrag
        'If tvRoles.SelectedNode Is Nothing Then
        '    DoDragDrop(e.Item, DragDropEffects.None)
        '    Exit Sub
        'End If
        If (tvRoles.SelectedNode.Level = 1) Or (tvRoles.SelectedNode.Level = 2) Then DoDragDrop(e.Item, DragDropEffects.Copy)
        
    End Sub
    Private Sub tvUsers_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles tvUsers.ItemDrag
        'If tvUsers.SelectedNode Is Nothing Then
        '    DoDragDrop(e.Item, DragDropEffects.None)
        '    Exit Sub
        'End If
        If tvUsers.SelectedNode.Level = 1 Then DoDragDrop(e.Item, DragDropEffects.Copy)
    End Sub

    Private Sub tvComponents_NodeMouseHover(sender As Object, e As System.Windows.Forms.TreeNodeMouseHoverEventArgs) Handles tvComponents.NodeMouseHover
        tvComponents.Focus()
        tvComponents.SelectedNode = e.Node
    End Sub
    Private Sub tvRoles_NodeMouseHover(sender As Object, e As System.Windows.Forms.TreeNodeMouseHoverEventArgs) Handles tvRoles.NodeMouseHover
        tvRoles.Focus()
        tvRoles.SelectedNode = e.Node
    End Sub
    Private Sub tvUsers_NodeMouseHover(sender As Object, e As System.Windows.Forms.TreeNodeMouseHoverEventArgs) Handles tvUsers.NodeMouseHover
        tvUsers.Focus()
        tvUsers.SelectedNode = e.Node

    End Sub

    Private Sub tvComponents_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tvComponents.MouseDown
        fromTV = "COMPONENT"
    End Sub
    Private Sub tvRoles_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tvRoles.MouseDown
        fromTV = "ROLE"
    End Sub
    Private Sub tvUsers_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tvUsers.MouseDown
        fromTV = "USER"
    End Sub




    Private Sub tvRoles_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvRoles.AfterSelect

    End Sub


    Private Sub tvUsers_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvUsers.AfterSelect

    End Sub

    

    Private Sub tsmiCreateRole_Click(sender As System.Object, e As System.EventArgs) Handles tsmiCreateRole.Click
        gCurRoleID = ""
        gCurRoleCode = ""
        gCurRoleDesc = ""
        gCurRoleStatus = ""

        frmManageRole.ShowDialog()
        frmManageRole.Dispose()
        loadRoles()
    End Sub

    Private Sub tsmiEditRole_Click(sender As System.Object, e As System.EventArgs) Handles tsmiEditRole.Click
        gCurRoleID = activeNode.ToolTipText
        gCurRoleDesc = activeNode.Text


        Dim startPos As Integer, delPos As Integer, delimitedData As String

        delimitedData = activeNode.Tag

        startPos = 1
        delPos = InStr(startPos, delimitedData, "|")

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        gCurRoleCode = delimitedData.Substring(startPos - 1, delPos - startPos)

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")

        startPos = delPos + 1
        delPos = InStr(startPos, delimitedData, "|")
        gCurRoleStatus = delimitedData.Substring(startPos - 1, delPos - startPos)

        frmManageRole.ShowDialog()
        frmManageRole.Dispose()
        loadRoles()
    End Sub
End Class