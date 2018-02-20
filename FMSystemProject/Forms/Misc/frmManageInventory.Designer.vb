<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageInventory
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
        Me.tvInventory = New System.Windows.Forms.TreeView()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEdit = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.txtParentCode = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optInactive = New System.Windows.Forms.RadioButton()
        Me.optActive = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtThisCode = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtThisDesc = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.cboIdentificationType = New System.Windows.Forms.ComboBox()
        Me.dtpPurchaseDate = New System.Windows.Forms.DateTimePicker()
        Me.panelLeaf = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboMake = New System.Windows.Forms.ComboBox()
        Me.txtIdentificationNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRetireReason = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpRetireDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpCommissionDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ContextMenu1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.panelLeaf.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvInventory
        '
        Me.tvInventory.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvInventory.Location = New System.Drawing.Point(12, 12)
        Me.tvInventory.Name = "tvInventory"
        Me.tvInventory.Size = New System.Drawing.Size(544, 866)
        Me.tvInventory.TabIndex = 0
        '
        'ContextMenu1
        '
        Me.ContextMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAdd, Me.tsmiEdit, Me.tsmiShowBalance, Me.tsmiShowAllBalances, Me.tsmiShowAccountReport, Me.tsmiShowDetailedReport, Me.tsmiTrialBalance})
        Me.ContextMenu1.Name = "coaContextMenu"
        Me.ContextMenu1.Size = New System.Drawing.Size(225, 172)
        '
        'tsmiAdd
        '
        Me.tsmiAdd.Name = "tsmiAdd"
        Me.tsmiAdd.Size = New System.Drawing.Size(224, 24)
        Me.tsmiAdd.Text = "Add"
        '
        'tsmiEdit
        '
        Me.tsmiEdit.Name = "tsmiEdit"
        Me.tsmiEdit.Size = New System.Drawing.Size(224, 24)
        Me.tsmiEdit.Text = "Edit"
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
        Me.GroupBox1.Controls.Add(Me.txtParentCode)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtThisCode)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.txtThisDesc)
        Me.GroupBox1.Controls.Add(Me.PasswordLabel)
        Me.GroupBox1.Controls.Add(Me.UsernameLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(569, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 435)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'chkLeafAccount
        '
        Me.chkLeafAccount.AutoSize = True
        Me.chkLeafAccount.Enabled = False
        Me.chkLeafAccount.Location = New System.Drawing.Point(17, 344)
        Me.chkLeafAccount.Name = "chkLeafAccount"
        Me.chkLeafAccount.Size = New System.Drawing.Size(113, 21)
        Me.chkLeafAccount.TabIndex = 7
        Me.chkLeafAccount.Text = "Leaf Account"
        Me.chkLeafAccount.UseVisualStyleBackColor = True
        '
        'txtParentCode
        '
        Me.txtParentCode.Location = New System.Drawing.Point(17, 235)
        Me.txtParentCode.Name = "txtParentCode"
        Me.txtParentCode.ReadOnly = True
        Me.txtParentCode.Size = New System.Drawing.Size(233, 22)
        Me.txtParentCode.TabIndex = 22
        '
        'GroupBox3
        '
        Me.GroupBox3.AutoSize = True
        Me.GroupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox3.Controls.Add(Me.optInactive)
        Me.GroupBox3.Controls.Add(Me.optActive)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 272)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 209)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Parent Code"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtThisCode
        '
        Me.txtThisCode.Location = New System.Drawing.Point(17, 54)
        Me.txtThisCode.Name = "txtThisCode"
        Me.txtThisCode.ReadOnly = True
        Me.txtThisCode.Size = New System.Drawing.Size(233, 22)
        Me.txtThisCode.TabIndex = 8
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(122, 381)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(17, 381)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        '
        'txtThisDesc
        '
        Me.txtThisDesc.Location = New System.Drawing.Point(17, 102)
        Me.txtThisDesc.Multiline = True
        Me.txtThisDesc.Name = "txtThisDesc"
        Me.txtThisDesc.ReadOnly = True
        Me.txtThisDesc.Size = New System.Drawing.Size(234, 95)
        Me.txtThisDesc.TabIndex = 10
        '
        'PasswordLabel
        '
        Me.PasswordLabel.AutoSize = True
        Me.PasswordLabel.Location = New System.Drawing.Point(17, 78)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(79, 17)
        Me.PasswordLabel.TabIndex = 11
        Me.PasswordLabel.Text = "Description"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.Location = New System.Drawing.Point(17, 28)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(41, 17)
        Me.UsernameLabel.TabIndex = 9
        Me.UsernameLabel.Text = "Code"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboIdentificationType
        '
        Me.cboIdentificationType.Enabled = False
        Me.cboIdentificationType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboIdentificationType.FormattingEnabled = True
        Me.cboIdentificationType.Location = New System.Drawing.Point(132, 254)
        Me.cboIdentificationType.Name = "cboIdentificationType"
        Me.cboIdentificationType.Size = New System.Drawing.Size(202, 24)
        Me.cboIdentificationType.TabIndex = 21
        '
        'dtpPurchaseDate
        '
        Me.dtpPurchaseDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPurchaseDate.Location = New System.Drawing.Point(127, 10)
        Me.dtpPurchaseDate.MinDate = New Date(2008, 1, 1, 0, 0, 0, 0)
        Me.dtpPurchaseDate.Name = "dtpPurchaseDate"
        Me.dtpPurchaseDate.ShowCheckBox = True
        Me.dtpPurchaseDate.Size = New System.Drawing.Size(123, 22)
        Me.dtpPurchaseDate.TabIndex = 4
        '
        'panelLeaf
        '
        Me.panelLeaf.Controls.Add(Me.Label9)
        Me.panelLeaf.Controls.Add(Me.cboMake)
        Me.panelLeaf.Controls.Add(Me.txtIdentificationNo)
        Me.panelLeaf.Controls.Add(Me.Label8)
        Me.panelLeaf.Controls.Add(Me.Label7)
        Me.panelLeaf.Controls.Add(Me.Label6)
        Me.panelLeaf.Controls.Add(Me.txtRetireReason)
        Me.panelLeaf.Controls.Add(Me.cboIdentificationType)
        Me.panelLeaf.Controls.Add(Me.Label5)
        Me.panelLeaf.Controls.Add(Me.dtpRetireDate)
        Me.panelLeaf.Controls.Add(Me.Label4)
        Me.panelLeaf.Controls.Add(Me.dtpCommissionDate)
        Me.panelLeaf.Controls.Add(Me.Label3)
        Me.panelLeaf.Controls.Add(Me.dtpPurchaseDate)
        Me.panelLeaf.Location = New System.Drawing.Point(868, 28)
        Me.panelLeaf.Name = "panelLeaf"
        Me.panelLeaf.Size = New System.Drawing.Size(345, 349)
        Me.panelLeaf.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 211)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 17)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Make"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMake
        '
        Me.cboMake.Enabled = False
        Me.cboMake.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboMake.FormattingEnabled = True
        Me.cboMake.Location = New System.Drawing.Point(132, 206)
        Me.cboMake.Name = "cboMake"
        Me.cboMake.Size = New System.Drawing.Size(202, 24)
        Me.cboMake.TabIndex = 32
        '
        'txtIdentificationNo
        '
        Me.txtIdentificationNo.Location = New System.Drawing.Point(8, 308)
        Me.txtIdentificationNo.Name = "txtIdentificationNo"
        Me.txtIdentificationNo.ReadOnly = True
        Me.txtIdentificationNo.Size = New System.Drawing.Size(326, 22)
        Me.txtIdentificationNo.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(105, 288)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 17)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Identification No"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 259)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 17)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Identification Type"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(105, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 17)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Retire Reason"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRetireReason
        '
        Me.txtRetireReason.Location = New System.Drawing.Point(8, 124)
        Me.txtRetireReason.Multiline = True
        Me.txtRetireReason.Name = "txtRetireReason"
        Me.txtRetireReason.ReadOnly = True
        Me.txtRetireReason.Size = New System.Drawing.Size(326, 72)
        Me.txtRetireReason.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 17)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Retire Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpRetireDate
        '
        Me.dtpRetireDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpRetireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRetireDate.Location = New System.Drawing.Point(127, 73)
        Me.dtpRetireDate.MinDate = New Date(2008, 1, 1, 0, 0, 0, 0)
        Me.dtpRetireDate.Name = "dtpRetireDate"
        Me.dtpRetireDate.ShowCheckBox = True
        Me.dtpRetireDate.Size = New System.Drawing.Size(123, 22)
        Me.dtpRetireDate.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 17)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Commission Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpCommissionDate
        '
        Me.dtpCommissionDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpCommissionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCommissionDate.Location = New System.Drawing.Point(127, 38)
        Me.dtpCommissionDate.MinDate = New Date(2008, 1, 1, 0, 0, 0, 0)
        Me.dtpCommissionDate.Name = "dtpCommissionDate"
        Me.dtpCommissionDate.ShowCheckBox = True
        Me.dtpCommissionDate.Size = New System.Drawing.Size(123, 22)
        Me.dtpCommissionDate.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Purchase Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmManageInventory
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1225, 890)
        Me.Controls.Add(Me.panelLeaf)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tvInventory)
        Me.Name = "frmManageInventory"
        Me.Text = "Manage Inventory"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenu1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.panelLeaf.ResumeLayout(False)
        Me.panelLeaf.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tvInventory As System.Windows.Forms.TreeView
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowBalance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowAllBalances As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtThisCode As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtThisDesc As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents cboIdentificationType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents optInactive As System.Windows.Forms.RadioButton
    Friend WithEvents optActive As System.Windows.Forms.RadioButton
    Friend WithEvents txtParentCode As System.Windows.Forms.TextBox
    Friend WithEvents chkLeafAccount As System.Windows.Forms.CheckBox
    Friend WithEvents tsmiShowAccountReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowDetailedReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiTrialBalance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowAccountReport_AsOf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowAccountReport_Between As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowAccountReport_YTD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowAccountReport_TillDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpPurchaseDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents panelLeaf As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboMake As System.Windows.Forms.ComboBox
    Friend WithEvents txtIdentificationNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRetireReason As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpRetireDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpCommissionDate As System.Windows.Forms.DateTimePicker
End Class
