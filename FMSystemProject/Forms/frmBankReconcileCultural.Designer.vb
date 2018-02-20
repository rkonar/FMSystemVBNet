<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankReconcileCultural
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvJournal_b = New System.Windows.Forms.DataGridView()
        Me.tblid_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gid_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnType_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnDate_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Narration_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocRef_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNo_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrAmount_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CrAmount_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvJournal_a = New System.Windows.Forms.DataGridView()
        Me.tblid_a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gid_a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnType_a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnDate_a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Narration_a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocRef_a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNo_a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrAmount_a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CrAmount_a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAutoReconcile = New System.Windows.Forms.Button()
        Me.pbarProgress = New System.Windows.Forms.ProgressBar()
        Me.chkShowOnlyUnReconciled = New System.Windows.Forms.CheckBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblBalance_a = New System.Windows.Forms.Label()
        Me.lblBalance_b = New System.Windows.Forms.Label()
        Me.lblCnt_a = New System.Windows.Forms.Label()
        Me.lblCnt_b = New System.Windows.Forms.Label()
        Me.btnOpenJournalBankStatement = New System.Windows.Forms.Button()
        Me.txtToAmount = New System.Windows.Forms.TextBox()
        Me.txtFromAmount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.btnManualReconcile = New System.Windows.Forms.Button()
        Me.chkSortOnAmount = New System.Windows.Forms.CheckBox()
        Me.btnOpenBillReceiptScreen = New System.Windows.Forms.Button()
        Me.grpExpenseType = New System.Windows.Forms.GroupBox()
        Me.optIncludeNeft = New System.Windows.Forms.RadioButton()
        Me.optIncludeAll = New System.Windows.Forms.RadioButton()
        Me.optIncludeCheque = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optWithdrawal = New System.Windows.Forms.RadioButton()
        Me.optDeposit = New System.Windows.Forms.RadioButton()
        Me.receiptContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiEditReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBookReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnFlatOwnerSearch = New System.Windows.Forms.Button()
        Me.txtChequeToFind = New System.Windows.Forms.TextBox()
        Me.btnLocate = New System.Windows.Forms.Button()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.chkOneToManyReconcileFlag = New System.Windows.Forms.CheckBox()
        CType(Me.dgvJournal_b, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvJournal_a, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpExpenseType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.receiptContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvJournal_b
        '
        Me.dgvJournal_b.AllowUserToAddRows = False
        Me.dgvJournal_b.AllowUserToDeleteRows = False
        Me.dgvJournal_b.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvJournal_b.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvJournal_b.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvJournal_b.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tblid_b, Me.gid_b, Me.TxnType_b, Me.TxnDate_b, Me.Narration_b, Me.DocRef_b, Me.AccountNo_b, Me.DrAmount_b, Me.CrAmount_b})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournal_b.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvJournal_b.Location = New System.Drawing.Point(0, 142)
        Me.dgvJournal_b.MultiSelect = False
        Me.dgvJournal_b.Name = "dgvJournal_b"
        Me.dgvJournal_b.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvJournal_b.RowHeadersVisible = False
        Me.dgvJournal_b.RowTemplate.Height = 24
        Me.dgvJournal_b.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJournal_b.Size = New System.Drawing.Size(621, 683)
        Me.dgvJournal_b.TabIndex = 32
        '
        'tblid_b
        '
        Me.tblid_b.HeaderText = "tblid"
        Me.tblid_b.Name = "tblid_b"
        Me.tblid_b.Visible = False
        '
        'gid_b
        '
        Me.gid_b.HeaderText = "gid"
        Me.gid_b.MaxInputLength = 1
        Me.gid_b.Name = "gid_b"
        Me.gid_b.Visible = False
        '
        'TxnType_b
        '
        Me.TxnType_b.HeaderText = "TxnType"
        Me.TxnType_b.Name = "TxnType_b"
        Me.TxnType_b.Visible = False
        '
        'TxnDate_b
        '
        Me.TxnDate_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "D"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.TxnDate_b.DefaultCellStyle = DataGridViewCellStyle1
        Me.TxnDate_b.HeaderText = "TxnDate"
        Me.TxnDate_b.MaxInputLength = 11
        Me.TxnDate_b.Name = "TxnDate_b"
        Me.TxnDate_b.ReadOnly = True
        Me.TxnDate_b.Width = 90
        '
        'Narration_b
        '
        Me.Narration_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Narration_b.DefaultCellStyle = DataGridViewCellStyle2
        Me.Narration_b.HeaderText = "Narration"
        Me.Narration_b.MaxInputLength = 255
        Me.Narration_b.MinimumWidth = 10
        Me.Narration_b.Name = "Narration_b"
        Me.Narration_b.ReadOnly = True
        Me.Narration_b.Width = 125
        '
        'DocRef_b
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DocRef_b.DefaultCellStyle = DataGridViewCellStyle3
        Me.DocRef_b.HeaderText = "DocRef"
        Me.DocRef_b.MinimumWidth = 100
        Me.DocRef_b.Name = "DocRef_b"
        Me.DocRef_b.Width = 125
        '
        'AccountNo_b
        '
        Me.AccountNo_b.HeaderText = "AccountNo"
        Me.AccountNo_b.Name = "AccountNo_b"
        Me.AccountNo_b.Width = 130
        '
        'DrAmount_b
        '
        Me.DrAmount_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DrAmount_b.DefaultCellStyle = DataGridViewCellStyle4
        Me.DrAmount_b.HeaderText = "DrAmount"
        Me.DrAmount_b.MaxInputLength = 13
        Me.DrAmount_b.Name = "DrAmount_b"
        Me.DrAmount_b.Width = 90
        '
        'CrAmount_b
        '
        Me.CrAmount_b.HeaderText = "CrAmount"
        Me.CrAmount_b.Name = "CrAmount_b"
        Me.CrAmount_b.Visible = False
        Me.CrAmount_b.Width = 90
        '
        'dgvJournal_a
        '
        Me.dgvJournal_a.AllowUserToAddRows = False
        Me.dgvJournal_a.AllowUserToDeleteRows = False
        Me.dgvJournal_a.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvJournal_a.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvJournal_a.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvJournal_a.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tblid_a, Me.gid_a, Me.TxnType_a, Me.TxnDate_a, Me.Narration_a, Me.DocRef_a, Me.AccountNo_a, Me.DrAmount_a, Me.CrAmount_a})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial Narrow", 7.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournal_a.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvJournal_a.Location = New System.Drawing.Point(627, 142)
        Me.dgvJournal_a.MultiSelect = False
        Me.dgvJournal_a.Name = "dgvJournal_a"
        Me.dgvJournal_a.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvJournal_a.RowHeadersVisible = False
        Me.dgvJournal_a.RowTemplate.Height = 24
        Me.dgvJournal_a.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJournal_a.Size = New System.Drawing.Size(603, 683)
        Me.dgvJournal_a.TabIndex = 33
        '
        'tblid_a
        '
        Me.tblid_a.HeaderText = "tblid"
        Me.tblid_a.Name = "tblid_a"
        Me.tblid_a.Visible = False
        '
        'gid_a
        '
        Me.gid_a.HeaderText = "gid"
        Me.gid_a.MaxInputLength = 1
        Me.gid_a.Name = "gid_a"
        Me.gid_a.Visible = False
        '
        'TxnType_a
        '
        Me.TxnType_a.HeaderText = "TxnType"
        Me.TxnType_a.Name = "TxnType_a"
        Me.TxnType_a.Visible = False
        '
        'TxnDate_a
        '
        Me.TxnDate_a.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "D"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.TxnDate_a.DefaultCellStyle = DataGridViewCellStyle6
        Me.TxnDate_a.HeaderText = "TxnDate"
        Me.TxnDate_a.MaxInputLength = 11
        Me.TxnDate_a.Name = "TxnDate_a"
        Me.TxnDate_a.ReadOnly = True
        Me.TxnDate_a.Width = 90
        '
        'Narration_a
        '
        Me.Narration_a.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Narration_a.DefaultCellStyle = DataGridViewCellStyle7
        Me.Narration_a.HeaderText = "Narration"
        Me.Narration_a.MaxInputLength = 255
        Me.Narration_a.MinimumWidth = 10
        Me.Narration_a.Name = "Narration_a"
        Me.Narration_a.ReadOnly = True
        Me.Narration_a.Width = 125
        '
        'DocRef_a
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DocRef_a.DefaultCellStyle = DataGridViewCellStyle8
        Me.DocRef_a.HeaderText = "DocRef"
        Me.DocRef_a.MinimumWidth = 100
        Me.DocRef_a.Name = "DocRef_a"
        Me.DocRef_a.Width = 125
        '
        'AccountNo_a
        '
        Me.AccountNo_a.HeaderText = "AccountNo"
        Me.AccountNo_a.Name = "AccountNo_a"
        Me.AccountNo_a.Width = 130
        '
        'DrAmount_a
        '
        Me.DrAmount_a.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DrAmount_a.DefaultCellStyle = DataGridViewCellStyle9
        Me.DrAmount_a.HeaderText = "DrAmount"
        Me.DrAmount_a.MaxInputLength = 13
        Me.DrAmount_a.Name = "DrAmount_a"
        Me.DrAmount_a.Width = 90
        '
        'CrAmount_a
        '
        Me.CrAmount_a.HeaderText = "CrAmount"
        Me.CrAmount_a.Name = "CrAmount_a"
        Me.CrAmount_a.Visible = False
        Me.CrAmount_a.Width = 90
        '
        'btnAutoReconcile
        '
        Me.btnAutoReconcile.AutoSize = True
        Me.btnAutoReconcile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAutoReconcile.Enabled = False
        Me.btnAutoReconcile.Location = New System.Drawing.Point(967, 43)
        Me.btnAutoReconcile.Name = "btnAutoReconcile"
        Me.btnAutoReconcile.Size = New System.Drawing.Size(90, 23)
        Me.btnAutoReconcile.TabIndex = 128
        Me.btnAutoReconcile.Text = "Auto Reconcile"
        Me.btnAutoReconcile.UseVisualStyleBackColor = True
        '
        'pbarProgress
        '
        Me.pbarProgress.BackColor = System.Drawing.Color.Yellow
        Me.pbarProgress.Location = New System.Drawing.Point(483, 91)
        Me.pbarProgress.Name = "pbarProgress"
        Me.pbarProgress.Size = New System.Drawing.Size(273, 23)
        Me.pbarProgress.TabIndex = 129
        '
        'chkShowOnlyUnReconciled
        '
        Me.chkShowOnlyUnReconciled.AutoSize = True
        Me.chkShowOnlyUnReconciled.Checked = True
        Me.chkShowOnlyUnReconciled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowOnlyUnReconciled.Location = New System.Drawing.Point(445, 46)
        Me.chkShowOnlyUnReconciled.Name = "chkShowOnlyUnReconciled"
        Me.chkShowOnlyUnReconciled.Size = New System.Drawing.Size(118, 17)
        Me.chkShowOnlyUnReconciled.TabIndex = 130
        Me.chkShowOnlyUnReconciled.Text = "Only UnReconciled"
        Me.chkShowOnlyUnReconciled.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.AutoSize = True
        Me.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRefresh.Location = New System.Drawing.Point(748, 43)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(54, 23)
        Me.btnRefresh.TabIndex = 131
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'lblBalance_a
        '
        Me.lblBalance_a.BackColor = System.Drawing.Color.Black
        Me.lblBalance_a.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalance_a.ForeColor = System.Drawing.Color.White
        Me.lblBalance_a.Location = New System.Drawing.Point(627, 117)
        Me.lblBalance_a.Name = "lblBalance_a"
        Me.lblBalance_a.Size = New System.Drawing.Size(150, 22)
        Me.lblBalance_a.TabIndex = 133
        Me.lblBalance_a.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBalance_b
        '
        Me.lblBalance_b.BackColor = System.Drawing.Color.Black
        Me.lblBalance_b.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalance_b.ForeColor = System.Drawing.Color.White
        Me.lblBalance_b.Location = New System.Drawing.Point(471, 117)
        Me.lblBalance_b.Name = "lblBalance_b"
        Me.lblBalance_b.Size = New System.Drawing.Size(150, 22)
        Me.lblBalance_b.TabIndex = 132
        Me.lblBalance_b.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCnt_a
        '
        Me.lblCnt_a.BackColor = System.Drawing.Color.Black
        Me.lblCnt_a.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCnt_a.ForeColor = System.Drawing.Color.White
        Me.lblCnt_a.Location = New System.Drawing.Point(781, 117)
        Me.lblCnt_a.Name = "lblCnt_a"
        Me.lblCnt_a.Size = New System.Drawing.Size(100, 22)
        Me.lblCnt_a.TabIndex = 135
        Me.lblCnt_a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCnt_b
        '
        Me.lblCnt_b.BackColor = System.Drawing.Color.Black
        Me.lblCnt_b.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCnt_b.ForeColor = System.Drawing.Color.White
        Me.lblCnt_b.Location = New System.Drawing.Point(367, 117)
        Me.lblCnt_b.Name = "lblCnt_b"
        Me.lblCnt_b.Size = New System.Drawing.Size(100, 22)
        Me.lblCnt_b.TabIndex = 134
        Me.lblCnt_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOpenJournalBankStatement
        '
        Me.btnOpenJournalBankStatement.AutoSize = True
        Me.btnOpenJournalBankStatement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOpenJournalBankStatement.Location = New System.Drawing.Point(1022, 0)
        Me.btnOpenJournalBankStatement.Name = "btnOpenJournalBankStatement"
        Me.btnOpenJournalBankStatement.Size = New System.Drawing.Size(159, 23)
        Me.btnOpenJournalBankStatement.TabIndex = 136
        Me.btnOpenJournalBankStatement.Text = "Open Journal Bank Statement"
        Me.btnOpenJournalBankStatement.UseVisualStyleBackColor = True
        '
        'txtToAmount
        '
        Me.txtToAmount.Location = New System.Drawing.Point(710, 3)
        Me.txtToAmount.MaxLength = 12
        Me.txtToAmount.Name = "txtToAmount"
        Me.txtToAmount.Size = New System.Drawing.Size(111, 20)
        Me.txtToAmount.TabIndex = 144
        '
        'txtFromAmount
        '
        Me.txtFromAmount.Location = New System.Drawing.Point(514, 3)
        Me.txtFromAmount.MaxLength = 12
        Me.txtFromAmount.Name = "txtFromAmount"
        Me.txtFromAmount.Size = New System.Drawing.Size(111, 20)
        Me.txtFromAmount.TabIndex = 143
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(630, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "To Amount"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(418, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "From Amount"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(206, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "From Date"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(282, 5)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(123, 20)
        Me.dtpToDate.TabIndex = 138
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(79, 7)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(123, 20)
        Me.dtpFromDate.TabIndex = 137
        '
        'btnManualReconcile
        '
        Me.btnManualReconcile.AutoSize = True
        Me.btnManualReconcile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnManualReconcile.Location = New System.Drawing.Point(200, 113)
        Me.btnManualReconcile.Name = "btnManualReconcile"
        Me.btnManualReconcile.Size = New System.Drawing.Size(110, 23)
        Me.btnManualReconcile.TabIndex = 145
        Me.btnManualReconcile.Text = "Reconcile Selected"
        Me.btnManualReconcile.UseVisualStyleBackColor = True
        '
        'chkSortOnAmount
        '
        Me.chkSortOnAmount.AutoSize = True
        Me.chkSortOnAmount.Location = New System.Drawing.Point(602, 46)
        Me.chkSortOnAmount.Name = "chkSortOnAmount"
        Me.chkSortOnAmount.Size = New System.Drawing.Size(101, 17)
        Me.chkSortOnAmount.TabIndex = 146
        Me.chkSortOnAmount.Text = "Sort On Amount"
        Me.chkSortOnAmount.UseVisualStyleBackColor = True
        '
        'btnOpenBillReceiptScreen
        '
        Me.btnOpenBillReceiptScreen.AutoSize = True
        Me.btnOpenBillReceiptScreen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOpenBillReceiptScreen.Location = New System.Drawing.Point(842, 0)
        Me.btnOpenBillReceiptScreen.Name = "btnOpenBillReceiptScreen"
        Me.btnOpenBillReceiptScreen.Size = New System.Drawing.Size(136, 23)
        Me.btnOpenBillReceiptScreen.TabIndex = 147
        Me.btnOpenBillReceiptScreen.Text = "Open Bill Receipt Screen"
        Me.btnOpenBillReceiptScreen.UseVisualStyleBackColor = True
        '
        'grpExpenseType
        '
        Me.grpExpenseType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpExpenseType.Controls.Add(Me.optIncludeNeft)
        Me.grpExpenseType.Controls.Add(Me.optIncludeAll)
        Me.grpExpenseType.Controls.Add(Me.optIncludeCheque)
        Me.grpExpenseType.Location = New System.Drawing.Point(6, 34)
        Me.grpExpenseType.Name = "grpExpenseType"
        Me.grpExpenseType.Size = New System.Drawing.Size(233, 44)
        Me.grpExpenseType.TabIndex = 148
        Me.grpExpenseType.TabStop = False
        '
        'optIncludeNeft
        '
        Me.optIncludeNeft.AutoSize = True
        Me.optIncludeNeft.Location = New System.Drawing.Point(162, 15)
        Me.optIncludeNeft.Name = "optIncludeNeft"
        Me.optIncludeNeft.Size = New System.Drawing.Size(53, 17)
        Me.optIncludeNeft.TabIndex = 3
        Me.optIncludeNeft.Text = "NEFT"
        Me.optIncludeNeft.UseVisualStyleBackColor = True
        '
        'optIncludeAll
        '
        Me.optIncludeAll.AutoSize = True
        Me.optIncludeAll.Checked = True
        Me.optIncludeAll.Location = New System.Drawing.Point(13, 15)
        Me.optIncludeAll.Name = "optIncludeAll"
        Me.optIncludeAll.Size = New System.Drawing.Size(36, 17)
        Me.optIncludeAll.TabIndex = 2
        Me.optIncludeAll.TabStop = True
        Me.optIncludeAll.Text = "All"
        Me.optIncludeAll.UseVisualStyleBackColor = True
        '
        'optIncludeCheque
        '
        Me.optIncludeCheque.AutoSize = True
        Me.optIncludeCheque.Location = New System.Drawing.Point(78, 15)
        Me.optIncludeCheque.Name = "optIncludeCheque"
        Me.optIncludeCheque.Size = New System.Drawing.Size(62, 17)
        Me.optIncludeCheque.TabIndex = 1
        Me.optIncludeCheque.Text = "Cheque"
        Me.optIncludeCheque.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.optWithdrawal)
        Me.GroupBox1.Controls.Add(Me.optDeposit)
        Me.GroupBox1.Location = New System.Drawing.Point(245, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(194, 44)
        Me.GroupBox1.TabIndex = 149
        Me.GroupBox1.TabStop = False
        '
        'optWithdrawal
        '
        Me.optWithdrawal.AutoSize = True
        Me.optWithdrawal.Location = New System.Drawing.Point(92, 14)
        Me.optWithdrawal.Name = "optWithdrawal"
        Me.optWithdrawal.Size = New System.Drawing.Size(78, 17)
        Me.optWithdrawal.TabIndex = 3
        Me.optWithdrawal.Text = "Withdrawal"
        Me.optWithdrawal.UseVisualStyleBackColor = True
        '
        'optDeposit
        '
        Me.optDeposit.AutoSize = True
        Me.optDeposit.Checked = True
        Me.optDeposit.Location = New System.Drawing.Point(8, 14)
        Me.optDeposit.Name = "optDeposit"
        Me.optDeposit.Size = New System.Drawing.Size(61, 17)
        Me.optDeposit.TabIndex = 1
        Me.optDeposit.TabStop = True
        Me.optDeposit.Text = "Deposit"
        Me.optDeposit.UseVisualStyleBackColor = True
        '
        'receiptContextMenu
        '
        Me.receiptContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiEditReceipt, Me.tsmiBookReceipt})
        Me.receiptContextMenu.Name = "coaContextMenu"
        Me.receiptContextMenu.Size = New System.Drawing.Size(210, 48)
        '
        'tsmiEditReceipt
        '
        Me.tsmiEditReceipt.Name = "tsmiEditReceipt"
        Me.tsmiEditReceipt.Size = New System.Drawing.Size(209, 22)
        Me.tsmiEditReceipt.Text = "View/Edit This Receipt"
        '
        'tsmiBookReceipt
        '
        Me.tsmiBookReceipt.Name = "tsmiBookReceipt"
        Me.tsmiBookReceipt.Size = New System.Drawing.Size(209, 22)
        Me.tsmiBookReceipt.Text = "View This Flat's Financials"
        '
        'btnFlatOwnerSearch
        '
        Me.btnFlatOwnerSearch.AutoSize = True
        Me.btnFlatOwnerSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFlatOwnerSearch.Location = New System.Drawing.Point(1086, 43)
        Me.btnFlatOwnerSearch.Name = "btnFlatOwnerSearch"
        Me.btnFlatOwnerSearch.Size = New System.Drawing.Size(107, 23)
        Me.btnFlatOwnerSearch.TabIndex = 150
        Me.btnFlatOwnerSearch.Text = "Flat/Owner Search"
        Me.btnFlatOwnerSearch.UseVisualStyleBackColor = True
        '
        'txtChequeToFind
        '
        Me.txtChequeToFind.Location = New System.Drawing.Point(891, 91)
        Me.txtChequeToFind.MaxLength = 12
        Me.txtChequeToFind.Name = "txtChequeToFind"
        Me.txtChequeToFind.Size = New System.Drawing.Size(213, 20)
        Me.txtChequeToFind.TabIndex = 151
        '
        'btnLocate
        '
        Me.btnLocate.AutoSize = True
        Me.btnLocate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnLocate.Location = New System.Drawing.Point(1110, 86)
        Me.btnLocate.Name = "btnLocate"
        Me.btnLocate.Size = New System.Drawing.Size(50, 23)
        Me.btnLocate.TabIndex = 152
        Me.btnLocate.Text = "Locate"
        Me.btnLocate.UseVisualStyleBackColor = True
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(931, 117)
        Me.txtBankName.MaxLength = 12
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.ReadOnly = True
        Me.txtBankName.Size = New System.Drawing.Size(297, 20)
        Me.txtBankName.TabIndex = 153
        '
        'chkOneToManyReconcileFlag
        '
        Me.chkOneToManyReconcileFlag.AutoSize = True
        Me.chkOneToManyReconcileFlag.Location = New System.Drawing.Point(78, 115)
        Me.chkOneToManyReconcileFlag.Name = "chkOneToManyReconcileFlag"
        Me.chkOneToManyReconcileFlag.Size = New System.Drawing.Size(91, 17)
        Me.chkOneToManyReconcileFlag.TabIndex = 154
        Me.chkOneToManyReconcileFlag.Text = "One To Many"
        Me.chkOneToManyReconcileFlag.UseVisualStyleBackColor = True
        '
        'frmBankReconcileCultural
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1237, 837)
        Me.Controls.Add(Me.chkOneToManyReconcileFlag)
        Me.Controls.Add(Me.txtBankName)
        Me.Controls.Add(Me.btnLocate)
        Me.Controls.Add(Me.txtChequeToFind)
        Me.Controls.Add(Me.btnFlatOwnerSearch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpExpenseType)
        Me.Controls.Add(Me.btnOpenBillReceiptScreen)
        Me.Controls.Add(Me.chkSortOnAmount)
        Me.Controls.Add(Me.btnManualReconcile)
        Me.Controls.Add(Me.txtToAmount)
        Me.Controls.Add(Me.txtFromAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpFromDate)
        Me.Controls.Add(Me.btnOpenJournalBankStatement)
        Me.Controls.Add(Me.lblCnt_a)
        Me.Controls.Add(Me.lblCnt_b)
        Me.Controls.Add(Me.lblBalance_a)
        Me.Controls.Add(Me.lblBalance_b)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.chkShowOnlyUnReconciled)
        Me.Controls.Add(Me.btnAutoReconcile)
        Me.Controls.Add(Me.pbarProgress)
        Me.Controls.Add(Me.dgvJournal_a)
        Me.Controls.Add(Me.dgvJournal_b)
        Me.Name = "frmBankReconcileCultural"
        Me.Text = "Reconcile Bank Statement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvJournal_b, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvJournal_a, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpExpenseType.ResumeLayout(False)
        Me.grpExpenseType.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.receiptContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvJournal_b As System.Windows.Forms.DataGridView
    Friend WithEvents dgvJournal_a As System.Windows.Forms.DataGridView
    Friend WithEvents btnAutoReconcile As System.Windows.Forms.Button
    Friend WithEvents pbarProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents chkShowOnlyUnReconciled As System.Windows.Forms.CheckBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblBalance_a As System.Windows.Forms.Label
    Friend WithEvents lblBalance_b As System.Windows.Forms.Label
    Friend WithEvents lblCnt_a As System.Windows.Forms.Label
    Friend WithEvents lblCnt_b As System.Windows.Forms.Label
    Friend WithEvents btnOpenJournalBankStatement As System.Windows.Forms.Button
    Friend WithEvents txtToAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtFromAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnManualReconcile As System.Windows.Forms.Button
    Friend WithEvents chkSortOnAmount As System.Windows.Forms.CheckBox
    Friend WithEvents tblid_a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gid_a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnType_a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnDate_a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Narration_a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocRef_a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNo_a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DrAmount_a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrAmount_a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnOpenBillReceiptScreen As System.Windows.Forms.Button
    Friend WithEvents grpExpenseType As System.Windows.Forms.GroupBox
    Friend WithEvents optIncludeNeft As System.Windows.Forms.RadioButton
    Friend WithEvents optIncludeAll As System.Windows.Forms.RadioButton
    Friend WithEvents optIncludeCheque As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optWithdrawal As System.Windows.Forms.RadioButton
    Friend WithEvents optDeposit As System.Windows.Forms.RadioButton
    Friend WithEvents tblid_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gid_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnType_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnDate_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Narration_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocRef_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNo_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DrAmount_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrAmount_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents receiptContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiEditReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBookReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFlatOwnerSearch As System.Windows.Forms.Button
    Friend WithEvents txtChequeToFind As System.Windows.Forms.TextBox
    Friend WithEvents btnLocate As System.Windows.Forms.Button
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents chkOneToManyReconcileFlag As System.Windows.Forms.CheckBox
End Class
