<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCOAReport
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
        Me.tsmiShowBalance = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAllBalances = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAccountReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAccountReport_AsOf = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAccountReport_Between = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAccountReport_YTD = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowAccountReport_TillDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.Upto31Mar2013ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FY201314ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.txtAccountName = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkOnlySummary = New System.Windows.Forms.CheckBox()
        Me.cboDirection = New System.Windows.Forms.ComboBox()
        Me.chkSummaryLine = New System.Windows.Forms.CheckBox()
        Me.cboOrderBy = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkGenReport = New System.Windows.Forms.CheckBox()
        Me.chkIncludeChildAccounts = New System.Windows.Forms.CheckBox()
        Me.chkQuickBalance = New System.Windows.Forms.CheckBox()
        Me.chkIncludeOpBal = New System.Windows.Forms.CheckBox()
        Me.grpReport = New System.Windows.Forms.GroupBox()
        Me.coaContextMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvCOA
        '
        Me.tvCOA.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvCOA.Location = New System.Drawing.Point(12, 12)
        Me.tvCOA.Name = "tvCOA"
        Me.tvCOA.Size = New System.Drawing.Size(668, 866)
        Me.tvCOA.TabIndex = 0
        '
        'coaContextMenu
        '
        Me.coaContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiShowBalance, Me.tsmiShowAllBalances, Me.tsmiShowAccountReport, Me.tsmiShowDetailedReport, Me.tsmiTrialBalance})
        Me.coaContextMenu.Name = "coaContextMenu"
        Me.coaContextMenu.Size = New System.Drawing.Size(188, 114)
        '
        'tsmiShowBalance
        '
        Me.tsmiShowBalance.Name = "tsmiShowBalance"
        Me.tsmiShowBalance.Size = New System.Drawing.Size(187, 22)
        Me.tsmiShowBalance.Text = "Show Balance"
        Me.tsmiShowBalance.Visible = False
        '
        'tsmiShowAllBalances
        '
        Me.tsmiShowAllBalances.Name = "tsmiShowAllBalances"
        Me.tsmiShowAllBalances.Size = New System.Drawing.Size(187, 22)
        Me.tsmiShowAllBalances.Text = "Show All Balance"
        Me.tsmiShowAllBalances.Visible = False
        '
        'tsmiShowAccountReport
        '
        Me.tsmiShowAccountReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiShowAccountReport_AsOf, Me.tsmiShowAccountReport_Between, Me.tsmiShowAccountReport_YTD, Me.tsmiShowAccountReport_TillDate, Me.Upto31Mar2013ToolStripMenuItem, Me.FY201314ToolStripMenuItem})
        Me.tsmiShowAccountReport.Name = "tsmiShowAccountReport"
        Me.tsmiShowAccountReport.Size = New System.Drawing.Size(187, 22)
        Me.tsmiShowAccountReport.Text = "Show Report"
        '
        'tsmiShowAccountReport_AsOf
        '
        Me.tsmiShowAccountReport_AsOf.Name = "tsmiShowAccountReport_AsOf"
        Me.tsmiShowAccountReport_AsOf.Size = New System.Drawing.Size(160, 22)
        Me.tsmiShowAccountReport_AsOf.Text = "As Of"
        '
        'tsmiShowAccountReport_Between
        '
        Me.tsmiShowAccountReport_Between.Name = "tsmiShowAccountReport_Between"
        Me.tsmiShowAccountReport_Between.Size = New System.Drawing.Size(160, 22)
        Me.tsmiShowAccountReport_Between.Text = "Between"
        '
        'tsmiShowAccountReport_YTD
        '
        Me.tsmiShowAccountReport_YTD.Name = "tsmiShowAccountReport_YTD"
        Me.tsmiShowAccountReport_YTD.Size = New System.Drawing.Size(160, 22)
        Me.tsmiShowAccountReport_YTD.Text = "YTD"
        '
        'tsmiShowAccountReport_TillDate
        '
        Me.tsmiShowAccountReport_TillDate.Name = "tsmiShowAccountReport_TillDate"
        Me.tsmiShowAccountReport_TillDate.Size = New System.Drawing.Size(160, 22)
        Me.tsmiShowAccountReport_TillDate.Text = "Till Date"
        '
        'Upto31Mar2013ToolStripMenuItem
        '
        Me.Upto31Mar2013ToolStripMenuItem.Name = "Upto31Mar2013ToolStripMenuItem"
        Me.Upto31Mar2013ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.Upto31Mar2013ToolStripMenuItem.Text = "Upto 31Mar2013"
        '
        'FY201314ToolStripMenuItem
        '
        Me.FY201314ToolStripMenuItem.Name = "FY201314ToolStripMenuItem"
        Me.FY201314ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.FY201314ToolStripMenuItem.Text = "FY2013_14"
        '
        'tsmiShowDetailedReport
        '
        Me.tsmiShowDetailedReport.Enabled = False
        Me.tsmiShowDetailedReport.Name = "tsmiShowDetailedReport"
        Me.tsmiShowDetailedReport.Size = New System.Drawing.Size(187, 22)
        Me.tsmiShowDetailedReport.Text = "Show Detailed Report"
        Me.tsmiShowDetailedReport.Visible = False
        '
        'tsmiTrialBalance
        '
        Me.tsmiTrialBalance.Name = "tsmiTrialBalance"
        Me.tsmiTrialBalance.Size = New System.Drawing.Size(187, 22)
        Me.tsmiTrialBalance.Text = "Trial Balance"
        Me.tsmiTrialBalance.Visible = False
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
        Me.GroupBox1.Controls.Add(Me.txtAccountName)
        Me.GroupBox1.Controls.Add(Me.PasswordLabel)
        Me.GroupBox1.Controls.Add(Me.UsernameLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(693, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 261)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'chkLeafAccount
        '
        Me.chkLeafAccount.AutoSize = True
        Me.chkLeafAccount.Enabled = False
        Me.chkLeafAccount.Location = New System.Drawing.Point(432, 121)
        Me.chkLeafAccount.Name = "chkLeafAccount"
        Me.chkLeafAccount.Size = New System.Drawing.Size(90, 17)
        Me.chkLeafAccount.TabIndex = 7
        Me.chkLeafAccount.Text = "Leaf Account"
        Me.chkLeafAccount.UseVisualStyleBackColor = True
        '
        'txtParentAccountNo
        '
        Me.txtParentAccountNo.Location = New System.Drawing.Point(11, 223)
        Me.txtParentAccountNo.Name = "txtParentAccountNo"
        Me.txtParentAccountNo.ReadOnly = True
        Me.txtParentAccountNo.Size = New System.Drawing.Size(233, 20)
        Me.txtParentAccountNo.TabIndex = 22
        '
        'cboAccountType
        '
        Me.cboAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountType.Enabled = False
        Me.cboAccountType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboAccountType.FormattingEnabled = True
        Me.cboAccountType.Location = New System.Drawing.Point(250, 40)
        Me.cboAccountType.Name = "cboAccountType"
        Me.cboAccountType.Size = New System.Drawing.Size(226, 21)
        Me.cboAccountType.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(250, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Account Type"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox3.Controls.Add(Me.optInactive)
        Me.GroupBox3.Controls.Add(Me.optActive)
        Me.GroupBox3.Location = New System.Drawing.Point(338, 84)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(92, 101)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        '
        'optInactive
        '
        Me.optInactive.AutoSize = True
        Me.optInactive.Enabled = False
        Me.optInactive.Location = New System.Drawing.Point(9, 62)
        Me.optInactive.Name = "optInactive"
        Me.optInactive.Size = New System.Drawing.Size(63, 17)
        Me.optInactive.TabIndex = 1
        Me.optInactive.TabStop = True
        Me.optInactive.Text = "Inactive"
        Me.optInactive.UseVisualStyleBackColor = True
        '
        'optActive
        '
        Me.optActive.AutoSize = True
        Me.optActive.Enabled = False
        Me.optActive.Location = New System.Drawing.Point(9, 18)
        Me.optActive.Name = "optActive"
        Me.optActive.Size = New System.Drawing.Size(55, 17)
        Me.optActive.TabIndex = 0
        Me.optActive.TabStop = True
        Me.optActive.Text = "Active"
        Me.optActive.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox2.Controls.Add(Me.optCredit)
        Me.GroupBox2.Controls.Add(Me.optDebit)
        Me.GroupBox2.Location = New System.Drawing.Point(244, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(97, 101)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'optCredit
        '
        Me.optCredit.AutoSize = True
        Me.optCredit.Enabled = False
        Me.optCredit.Location = New System.Drawing.Point(16, 60)
        Me.optCredit.Name = "optCredit"
        Me.optCredit.Size = New System.Drawing.Size(52, 17)
        Me.optCredit.TabIndex = 1
        Me.optCredit.TabStop = True
        Me.optCredit.Text = "Credit"
        Me.optCredit.UseVisualStyleBackColor = True
        '
        'optDebit
        '
        Me.optDebit.AutoSize = True
        Me.optDebit.Enabled = False
        Me.optDebit.Location = New System.Drawing.Point(16, 18)
        Me.optDebit.Name = "optDebit"
        Me.optDebit.Size = New System.Drawing.Size(50, 17)
        Me.optDebit.TabIndex = 0
        Me.optDebit.TabStop = True
        Me.optDebit.Text = "Debit"
        Me.optDebit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Parent Account No"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Location = New System.Drawing.Point(11, 42)
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.ReadOnly = True
        Me.txtAccountNo.Size = New System.Drawing.Size(233, 20)
        Me.txtAccountNo.TabIndex = 8
        '
        'txtAccountName
        '
        Me.txtAccountName.Location = New System.Drawing.Point(9, 90)
        Me.txtAccountName.Multiline = True
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.ReadOnly = True
        Me.txtAccountName.Size = New System.Drawing.Size(234, 95)
        Me.txtAccountName.TabIndex = 10
        '
        'PasswordLabel
        '
        Me.PasswordLabel.AutoSize = True
        Me.PasswordLabel.Location = New System.Drawing.Point(11, 66)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(78, 13)
        Me.PasswordLabel.TabIndex = 11
        Me.PasswordLabel.Text = "Account Name"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.Location = New System.Drawing.Point(11, 16)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(64, 13)
        Me.UsernameLabel.TabIndex = 9
        Me.UsernameLabel.Text = "Account No"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(266, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Direction"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkOnlySummary
        '
        Me.chkOnlySummary.AutoSize = True
        Me.chkOnlySummary.Location = New System.Drawing.Point(269, 146)
        Me.chkOnlySummary.Name = "chkOnlySummary"
        Me.chkOnlySummary.Size = New System.Drawing.Size(93, 17)
        Me.chkOnlySummary.TabIndex = 23
        Me.chkOnlySummary.Text = "Only Summary"
        Me.chkOnlySummary.UseVisualStyleBackColor = True
        '
        'cboDirection
        '
        Me.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDirection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboDirection.FormattingEnabled = True
        Me.cboDirection.Location = New System.Drawing.Point(269, 100)
        Me.cboDirection.Name = "cboDirection"
        Me.cboDirection.Size = New System.Drawing.Size(127, 21)
        Me.cboDirection.TabIndex = 22
        '
        'chkSummaryLine
        '
        Me.chkSummaryLine.AutoSize = True
        Me.chkSummaryLine.Location = New System.Drawing.Point(9, 146)
        Me.chkSummaryLine.Name = "chkSummaryLine"
        Me.chkSummaryLine.Size = New System.Drawing.Size(107, 17)
        Me.chkSummaryLine.TabIndex = 7
        Me.chkSummaryLine.Text = "Include Summary"
        Me.chkSummaryLine.UseVisualStyleBackColor = True
        '
        'cboOrderBy
        '
        Me.cboOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrderBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboOrderBy.FormattingEnabled = True
        Me.cboOrderBy.Location = New System.Drawing.Point(14, 100)
        Me.cboOrderBy.Name = "cboOrderBy"
        Me.cboOrderBy.Size = New System.Drawing.Size(226, 21)
        Me.cboOrderBy.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Sort BY"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkGenReport
        '
        Me.chkGenReport.AutoSize = True
        Me.chkGenReport.Location = New System.Drawing.Point(693, 292)
        Me.chkGenReport.Name = "chkGenReport"
        Me.chkGenReport.Size = New System.Drawing.Size(101, 17)
        Me.chkGenReport.TabIndex = 25
        Me.chkGenReport.Text = "Export To Excel"
        Me.chkGenReport.UseVisualStyleBackColor = True
        '
        'chkIncludeChildAccounts
        '
        Me.chkIncludeChildAccounts.AutoSize = True
        Me.chkIncludeChildAccounts.Location = New System.Drawing.Point(843, 292)
        Me.chkIncludeChildAccounts.Name = "chkIncludeChildAccounts"
        Me.chkIncludeChildAccounts.Size = New System.Drawing.Size(135, 17)
        Me.chkIncludeChildAccounts.TabIndex = 26
        Me.chkIncludeChildAccounts.Text = "Include Child Accounts"
        Me.chkIncludeChildAccounts.UseVisualStyleBackColor = True
        '
        'chkQuickBalance
        '
        Me.chkQuickBalance.AutoSize = True
        Me.chkQuickBalance.Location = New System.Drawing.Point(693, 571)
        Me.chkQuickBalance.Name = "chkQuickBalance"
        Me.chkQuickBalance.Size = New System.Drawing.Size(96, 17)
        Me.chkQuickBalance.TabIndex = 27
        Me.chkQuickBalance.Text = "Quick Balance"
        Me.chkQuickBalance.UseVisualStyleBackColor = True
        '
        'chkIncludeOpBal
        '
        Me.chkIncludeOpBal.AutoSize = True
        Me.chkIncludeOpBal.Checked = True
        Me.chkIncludeOpBal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeOpBal.Location = New System.Drawing.Point(11, 34)
        Me.chkIncludeOpBal.Name = "chkIncludeOpBal"
        Me.chkIncludeOpBal.Size = New System.Drawing.Size(146, 17)
        Me.chkIncludeOpBal.TabIndex = 28
        Me.chkIncludeOpBal.Text = "Include Opening Balance"
        Me.chkIncludeOpBal.UseVisualStyleBackColor = True
        '
        'grpReport
        '
        Me.grpReport.Controls.Add(Me.Label4)
        Me.grpReport.Controls.Add(Me.chkIncludeOpBal)
        Me.grpReport.Controls.Add(Me.chkOnlySummary)
        Me.grpReport.Controls.Add(Me.cboDirection)
        Me.grpReport.Controls.Add(Me.chkSummaryLine)
        Me.grpReport.Controls.Add(Me.cboOrderBy)
        Me.grpReport.Controls.Add(Me.Label3)
        Me.grpReport.ForeColor = System.Drawing.Color.Blue
        Me.grpReport.Location = New System.Drawing.Point(693, 331)
        Me.grpReport.Name = "grpReport"
        Me.grpReport.Size = New System.Drawing.Size(552, 197)
        Me.grpReport.TabIndex = 29
        Me.grpReport.TabStop = False
        Me.grpReport.Text = "Generate Report"
        '
        'frmCOAReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1264, 890)
        Me.Controls.Add(Me.grpReport)
        Me.Controls.Add(Me.chkQuickBalance)
        Me.Controls.Add(Me.chkIncludeChildAccounts)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tvCOA)
        Me.Controls.Add(Me.chkGenReport)
        Me.Name = "frmCOAReport"
        Me.Text = "Manage Chart Of Accounts"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.coaContextMenu.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpReport.ResumeLayout(False)
        Me.grpReport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tvCOA As System.Windows.Forms.TreeView
    Friend WithEvents coaContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiShowBalance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowAllBalances As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAccountNo As System.Windows.Forms.TextBox
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
    Friend WithEvents chkSummaryLine As System.Windows.Forms.CheckBox
    Friend WithEvents cboOrderBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDirection As System.Windows.Forms.ComboBox
    Friend WithEvents chkOnlySummary As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkGenReport As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncludeChildAccounts As System.Windows.Forms.CheckBox
    Friend WithEvents Upto31Mar2013ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkQuickBalance As System.Windows.Forms.CheckBox
    Friend WithEvents FY201314ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkIncludeOpBal As System.Windows.Forms.CheckBox
    Friend WithEvents grpReport As System.Windows.Forms.GroupBox
End Class
