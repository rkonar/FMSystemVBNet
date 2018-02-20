<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCOA
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
        Me.tvCOA = New System.Windows.Forms.TreeView()
        Me.coaContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiAddAccount = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEditAccount = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowBalance = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAllBalances = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAccountReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAccountReport_AsOf = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAccountReport_Between = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAccountReport_YTD = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAccountReport_TillDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowDetailedReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiTrialBalance = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkLeafAccount = New System.Windows.Forms.CheckBox()
        Me.txtParentAccountNo = New System.Windows.Forms.TextBox()
        Me.cboAccountType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optInactive = New System.Windows.Forms.RadioButton()
        Me.optActive = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optCredit = New System.Windows.Forms.RadioButton()
        Me.optDebit = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAccountNo = New System.Windows.Forms.TextBox()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtAccountName = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.coaContextMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvCOA
        '
        Me.tvCOA.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvCOA.Location = New System.Drawing.Point(12, 12)
        Me.tvCOA.Name = "tvCOA"
        Me.tvCOA.Size = New System.Drawing.Size(544, 866)
        Me.tvCOA.TabIndex = 0
        '
        'coaContextMenu
        '
        Me.coaContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAddAccount, Me.tsmiEditAccount, Me.tsmiShowBalance, Me.tsmiShowAllBalances, Me.tsmiShowAccountReport, Me.tsmiShowDetailedReport, Me.tsmiTrialBalance})
        Me.coaContextMenu.Name = "coaContextMenu"
        Me.coaContextMenu.Size = New System.Drawing.Size(225, 172)
        '
        'tsmiAddAccount
        '
        Me.tsmiAddAccount.Name = "tsmiAddAccount"
        Me.tsmiAddAccount.Size = New System.Drawing.Size(224, 24)
        Me.tsmiAddAccount.Text = "Add Account"
        '
        'tsmiEditAccount
        '
        Me.tsmiEditAccount.Name = "tsmiEditAccount"
        Me.tsmiEditAccount.Size = New System.Drawing.Size(224, 24)
        Me.tsmiEditAccount.Text = "Edit Account"
        '
        'tsmiShowBalance
        '
        Me.tsmiShowBalance.Name = "tsmiShowBalance"
        Me.tsmiShowBalance.Size = New System.Drawing.Size(224, 24)
        Me.tsmiShowBalance.Text = "Show Balance"
        '
        'tsmiShowAllBalances
        '
        Me.tsmiShowAllBalances.Name = "tsmiShowAllBalances"
        Me.tsmiShowAllBalances.Size = New System.Drawing.Size(224, 24)
        Me.tsmiShowAllBalances.Text = "Show All Balance"
        '
        'tsmiShowAccountReport
        '
        Me.tsmiShowAccountReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiShowAccountReport_AsOf, Me.tsmiShowAccountReport_Between, Me.tsmiShowAccountReport_YTD, Me.tsmiShowAccountReport_TillDate})
        Me.tsmiShowAccountReport.Enabled = False
        Me.tsmiShowAccountReport.Name = "tsmiShowAccountReport"
        Me.tsmiShowAccountReport.Size = New System.Drawing.Size(224, 24)
        Me.tsmiShowAccountReport.Text = "Show Account Report"
        '
        'tsmiShowAccountReport_AsOf
        '
        Me.tsmiShowAccountReport_AsOf.Name = "tsmiShowAccountReport_AsOf"
        Me.tsmiShowAccountReport_AsOf.Size = New System.Drawing.Size(135, 24)
        Me.tsmiShowAccountReport_AsOf.Text = "As Of"
        '
        'tsmiShowAccountReport_Between
        '
        Me.tsmiShowAccountReport_Between.Name = "tsmiShowAccountReport_Between"
        Me.tsmiShowAccountReport_Between.Size = New System.Drawing.Size(135, 24)
        Me.tsmiShowAccountReport_Between.Text = "Between"
        '
        'tsmiShowAccountReport_YTD
        '
        Me.tsmiShowAccountReport_YTD.Name = "tsmiShowAccountReport_YTD"
        Me.tsmiShowAccountReport_YTD.Size = New System.Drawing.Size(135, 24)
        Me.tsmiShowAccountReport_YTD.Text = "YTD"
        '
        'tsmiShowAccountReport_TillDate
        '
        Me.tsmiShowAccountReport_TillDate.Name = "tsmiShowAccountReport_TillDate"
        Me.tsmiShowAccountReport_TillDate.Size = New System.Drawing.Size(135, 24)
        Me.tsmiShowAccountReport_TillDate.Text = "Till Date"
        '
        'tsmiShowDetailedReport
        '
        Me.tsmiShowDetailedReport.Enabled = False
        Me.tsmiShowDetailedReport.Name = "tsmiShowDetailedReport"
        Me.tsmiShowDetailedReport.Size = New System.Drawing.Size(224, 24)
        Me.tsmiShowDetailedReport.Text = "Show Detailed Report"
        '
        'tsmiTrialBalance
        '
        Me.tsmiTrialBalance.Enabled = False
        Me.tsmiTrialBalance.Name = "tsmiTrialBalance"
        Me.tsmiTrialBalance.Size = New System.Drawing.Size(224, 24)
        Me.tsmiTrialBalance.Text = "Trial Balance"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkLeafAccount)
        Me.GroupBox1.Controls.Add(Me.txtParentAccountNo)
        Me.GroupBox1.Controls.Add(Me.cboAccountType)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAccountNo)
        Me.GroupBox1.Controls.Add(Me.Cancel)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.txtAccountName)
        Me.GroupBox1.Controls.Add(Me.PasswordLabel)
        Me.GroupBox1.Controls.Add(Me.UsernameLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(569, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 550)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'chkLeafAccount
        '
        Me.chkLeafAccount.AutoSize = True
        Me.chkLeafAccount.Enabled = False
        Me.chkLeafAccount.Location = New System.Drawing.Point(17, 473)
        Me.chkLeafAccount.Name = "chkLeafAccount"
        Me.chkLeafAccount.Size = New System.Drawing.Size(113, 21)
        Me.chkLeafAccount.TabIndex = 7
        Me.chkLeafAccount.Text = "Leaf Account"
        Me.chkLeafAccount.UseVisualStyleBackColor = True
        '
        'txtParentAccountNo
        '
        Me.txtParentAccountNo.Location = New System.Drawing.Point(17, 235)
        Me.txtParentAccountNo.Name = "txtParentAccountNo"
        Me.txtParentAccountNo.ReadOnly = True
        Me.txtParentAccountNo.Size = New System.Drawing.Size(233, 22)
        Me.txtParentAccountNo.TabIndex = 22
        '
        'cboAccountType
        '
        Me.cboAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountType.Enabled = False
        Me.cboAccountType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboAccountType.FormattingEnabled = True
        Me.cboAccountType.Location = New System.Drawing.Point(17, 292)
        Me.cboAccountType.Name = "cboAccountType"
        Me.cboAccountType.Size = New System.Drawing.Size(226, 24)
        Me.cboAccountType.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 268)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 17)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Account Type"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.AutoSize = True
        Me.GroupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox3.Controls.Add(Me.optInactive)
        Me.GroupBox3.Controls.Add(Me.optActive)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 401)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(157, 63)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        '
        'optInactive
        '
        Me.optInactive.AutoSize = True
        Me.optInactive.Enabled = False
        Me.optInactive.Location = New System.Drawing.Point(74, 21)
        Me.optInactive.Name = "optInactive"
        Me.optInactive.Size = New System.Drawing.Size(77, 21)
        Me.optInactive.TabIndex = 1
        Me.optInactive.TabStop = True
        Me.optInactive.Text = "Inactive"
        Me.optInactive.UseVisualStyleBackColor = True
        '
        'optActive
        '
        Me.optActive.AutoSize = True
        Me.optActive.Enabled = False
        Me.optActive.Location = New System.Drawing.Point(9, 21)
        Me.optActive.Name = "optActive"
        Me.optActive.Size = New System.Drawing.Size(67, 21)
        Me.optActive.TabIndex = 0
        Me.optActive.TabStop = True
        Me.optActive.Text = "Active"
        Me.optActive.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSize = True
        Me.GroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox2.Controls.Add(Me.optCredit)
        Me.GroupBox2.Controls.Add(Me.optDebit)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 320)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(155, 63)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'optCredit
        '
        Me.optCredit.AutoSize = True
        Me.optCredit.Enabled = False
        Me.optCredit.Location = New System.Drawing.Point(83, 21)
        Me.optCredit.Name = "optCredit"
        Me.optCredit.Size = New System.Drawing.Size(66, 21)
        Me.optCredit.TabIndex = 1
        Me.optCredit.TabStop = True
        Me.optCredit.Text = "Credit"
        Me.optCredit.UseVisualStyleBackColor = True
        '
        'optDebit
        '
        Me.optDebit.AutoSize = True
        Me.optDebit.Enabled = False
        Me.optDebit.Location = New System.Drawing.Point(16, 21)
        Me.optDebit.Name = "optDebit"
        Me.optDebit.Size = New System.Drawing.Size(62, 21)
        Me.optDebit.TabIndex = 0
        Me.optDebit.TabStop = True
        Me.optDebit.Text = "Debit"
        Me.optDebit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 209)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Parent Account No"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Location = New System.Drawing.Point(17, 54)
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.ReadOnly = True
        Me.txtAccountNo.Size = New System.Drawing.Size(233, 22)
        Me.txtAccountNo.TabIndex = 8
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(122, 510)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 14
        Me.Cancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(17, 510)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        '
        'txtAccountName
        '
        Me.txtAccountName.Location = New System.Drawing.Point(17, 102)
        Me.txtAccountName.Multiline = True
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.ReadOnly = True
        Me.txtAccountName.Size = New System.Drawing.Size(234, 95)
        Me.txtAccountName.TabIndex = 10
        '
        'PasswordLabel
        '
        Me.PasswordLabel.AutoSize = True
        Me.PasswordLabel.Location = New System.Drawing.Point(17, 78)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(100, 17)
        Me.PasswordLabel.TabIndex = 11
        Me.PasswordLabel.Text = "Account Name"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.Location = New System.Drawing.Point(17, 28)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(81, 17)
        Me.UsernameLabel.TabIndex = 9
        Me.UsernameLabel.Text = "Account No"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(569, 597)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(123, 22)
        Me.dtpDate.TabIndex = 4
        '
        'frmCOA
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(846, 890)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tvCOA)
        Me.Name = "frmCOA"
        Me.Text = "Manage Chart Of Accounts"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.coaContextMenu.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tvCOA As System.Windows.Forms.TreeView
    Friend WithEvents coaContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiAddAccount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiEditAccount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowBalance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowAllBalances As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAccountNo As System.Windows.Forms.TextBox
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents cboAccountType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents optInactive As System.Windows.Forms.RadioButton
    Friend WithEvents optActive As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optCredit As System.Windows.Forms.RadioButton
    Friend WithEvents optDebit As System.Windows.Forms.RadioButton
    Friend WithEvents txtParentAccountNo As System.Windows.Forms.TextBox
    Friend WithEvents chkLeafAccount As System.Windows.Forms.CheckBox
    Friend WithEvents tsmiShowAccountReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowDetailedReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiTrialBalance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowAccountReport_AsOf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowAccountReport_Between As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowAccountReport_YTD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowAccountReport_TillDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
End Class
