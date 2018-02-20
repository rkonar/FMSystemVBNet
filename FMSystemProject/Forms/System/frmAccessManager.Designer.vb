<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccessManager
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tvComponents = New System.Windows.Forms.TreeView()
        Me.tvRoles = New System.Windows.Forms.TreeView()
        Me.tvUsers = New System.Windows.Forms.TreeView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmsPermission = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiAllowAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDenyAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAllow = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDeny = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiExpand = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiExpandAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCollapse = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCollapseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCreateUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEditUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCreateRole = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEditRole = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsPermission.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvComponents
        '
        Me.tvComponents.AllowDrop = True
        Me.tvComponents.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvComponents.HotTracking = True
        Me.tvComponents.Location = New System.Drawing.Point(12, 49)
        Me.tvComponents.Name = "tvComponents"
        Me.tvComponents.Size = New System.Drawing.Size(310, 672)
        Me.tvComponents.TabIndex = 1
        '
        'tvRoles
        '
        Me.tvRoles.AllowDrop = True
        Me.tvRoles.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvRoles.HotTracking = True
        Me.tvRoles.Location = New System.Drawing.Point(366, 49)
        Me.tvRoles.Name = "tvRoles"
        Me.tvRoles.Size = New System.Drawing.Size(310, 672)
        Me.tvRoles.TabIndex = 2
        '
        'tvUsers
        '
        Me.tvUsers.AllowDrop = True
        Me.tvUsers.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvUsers.HotTracking = True
        Me.tvUsers.Location = New System.Drawing.Point(720, 49)
        Me.tvUsers.Name = "tvUsers"
        Me.tvUsers.Size = New System.Drawing.Size(310, 672)
        Me.tvUsers.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(38, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(254, 19)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Roles assigned to Components"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(423, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 19)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Users assigned to Roles"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(850, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 19)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Users"
        '
        'cmsPermission
        '
        Me.cmsPermission.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAllowAll, Me.tsmiDenyAll, Me.tsmiAllow, Me.tsmiDeny, Me.tsmiExpand, Me.tsmiExpandAll, Me.tsmiCollapse, Me.tsmiCollapseAll, Me.tsmiCreateUser, Me.tsmiEditUser, Me.tsmiCreateRole, Me.tsmiEditRole})
        Me.cmsPermission.Name = "cmsPermission"
        Me.cmsPermission.Size = New System.Drawing.Size(158, 292)
        '
        'tsmiAllowAll
        '
        Me.tsmiAllowAll.ForeColor = System.Drawing.Color.Green
        Me.tsmiAllowAll.Name = "tsmiAllowAll"
        Me.tsmiAllowAll.Size = New System.Drawing.Size(157, 24)
        Me.tsmiAllowAll.Text = "Allow All"
        '
        'tsmiDenyAll
        '
        Me.tsmiDenyAll.ForeColor = System.Drawing.Color.Red
        Me.tsmiDenyAll.Name = "tsmiDenyAll"
        Me.tsmiDenyAll.Size = New System.Drawing.Size(157, 24)
        Me.tsmiDenyAll.Text = "Deny All"
        '
        'tsmiAllow
        '
        Me.tsmiAllow.ForeColor = System.Drawing.Color.Green
        Me.tsmiAllow.Name = "tsmiAllow"
        Me.tsmiAllow.Size = New System.Drawing.Size(157, 24)
        Me.tsmiAllow.Text = "Allow"
        '
        'tsmiDeny
        '
        Me.tsmiDeny.ForeColor = System.Drawing.Color.Red
        Me.tsmiDeny.Name = "tsmiDeny"
        Me.tsmiDeny.Size = New System.Drawing.Size(157, 24)
        Me.tsmiDeny.Text = "Deny"
        '
        'tsmiExpand
        '
        Me.tsmiExpand.Name = "tsmiExpand"
        Me.tsmiExpand.Size = New System.Drawing.Size(157, 24)
        Me.tsmiExpand.Text = "Expand"
        '
        'tsmiExpandAll
        '
        Me.tsmiExpandAll.Name = "tsmiExpandAll"
        Me.tsmiExpandAll.Size = New System.Drawing.Size(157, 24)
        Me.tsmiExpandAll.Text = "Expand All"
        '
        'tsmiCollapse
        '
        Me.tsmiCollapse.Name = "tsmiCollapse"
        Me.tsmiCollapse.Size = New System.Drawing.Size(157, 24)
        Me.tsmiCollapse.Text = "Collapse"
        '
        'tsmiCollapseAll
        '
        Me.tsmiCollapseAll.Name = "tsmiCollapseAll"
        Me.tsmiCollapseAll.Size = New System.Drawing.Size(157, 24)
        Me.tsmiCollapseAll.Text = "Collapse All"
        '
        'tsmiCreateUser
        '
        Me.tsmiCreateUser.Name = "tsmiCreateUser"
        Me.tsmiCreateUser.Size = New System.Drawing.Size(157, 24)
        Me.tsmiCreateUser.Text = "Create User"
        '
        'tsmiEditUser
        '
        Me.tsmiEditUser.Name = "tsmiEditUser"
        Me.tsmiEditUser.Size = New System.Drawing.Size(157, 24)
        Me.tsmiEditUser.Text = "Edit User"
        '
        'tsmiCreateRole
        '
        Me.tsmiCreateRole.Name = "tsmiCreateRole"
        Me.tsmiCreateRole.Size = New System.Drawing.Size(157, 24)
        Me.tsmiCreateRole.Text = "Create Role"
        '
        'tsmiEditRole
        '
        Me.tsmiEditRole.Name = "tsmiEditRole"
        Me.tsmiEditRole.Size = New System.Drawing.Size(157, 24)
        Me.tsmiEditRole.Text = "Edit Role"
        '
        'frmAccessManager
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1096, 733)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tvUsers)
        Me.Controls.Add(Me.tvRoles)
        Me.Controls.Add(Me.tvComponents)
        Me.Name = "frmAccessManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Access Manager"
        Me.cmsPermission.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tvComponents As System.Windows.Forms.TreeView
    Friend WithEvents tvRoles As System.Windows.Forms.TreeView
    Friend WithEvents tvUsers As System.Windows.Forms.TreeView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmsPermission As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiAllow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiDeny As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiExpand As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiExpandAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCollapse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAllowAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiDenyAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCollapseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCreateUser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiEditUser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCreateRole As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiEditRole As System.Windows.Forms.ToolStripMenuItem
End Class
