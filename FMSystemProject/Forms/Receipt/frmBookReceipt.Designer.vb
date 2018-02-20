<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookReceipt
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.cboFlatCode = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvJournalBilled = New System.Windows.Forms.DataGridView()
        Me.JournalID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Narration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvJournalPaid = New System.Windows.Forms.DataGridView()
        Me.JournalIDPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnTypePaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnDatePaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NarrationPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnAmtPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.receiptContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiEditReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEmailReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiContraReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSMSReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboInstrumentType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNarration = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpReceiptDate = New System.Windows.Forms.DateTimePicker()
        Me.txtInstrumentNo = New System.Windows.Forms.TextBox()
        Me.lblInstrumentNo = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblInstrumentDate = New System.Windows.Forms.Label()
        Me.dtpInstrumentDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtReceiptAmount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblOwnerDetails = New System.Windows.Forms.Label()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.btnEditFlatOwnerDetails = New System.Windows.Forms.Button()
        Me.btnBookPenalty = New System.Windows.Forms.Button()
        Me.cboBankName = New System.Windows.Forms.ComboBox()
        Me.grpExpenseType = New System.Windows.Forms.GroupBox()
        Me.optMiscCollection_FlatOwner = New System.Windows.Forms.RadioButton()
        Me.optFacilitationFeeReceipt = New System.Windows.Forms.RadioButton()
        Me.optTenancyRegistrationFeeReceipt = New System.Windows.Forms.RadioButton()
        Me.optOnDemandFlatServiceReceipt = New System.Windows.Forms.RadioButton()
        Me.optMiscCollection_NonFlatOwner = New System.Windows.Forms.RadioButton()
        Me.optEarthMoversCollection = New System.Windows.Forms.RadioButton()
        Me.optMaintBillCollection = New System.Windows.Forms.RadioButton()
        Me.optStartrekCollection = New System.Windows.Forms.RadioButton()
        Me.optAssocFormFundCollection = New System.Windows.Forms.RadioButton()
        Me.btnBookOtherCharges = New System.Windows.Forms.Button()
        Me.btnOldMaintenanceBills = New System.Windows.Forms.Button()
        Me.btnOldEAMCBills = New System.Windows.Forms.Button()
        Me.btnMarkAsBGFOutstandingPayment = New System.Windows.Forms.Button()
        Me.btnMarkAsHIGAssocPayment = New System.Windows.Forms.Button()
        Me.lblDiffBGF = New System.Windows.Forms.Label()
        Me.btnAdjustExtraPayment = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnShowChequeDetails = New System.Windows.Forms.Button()
        Me.cboChequeNo = New System.Windows.Forms.ComboBox()
        Me.txtDuplexFlatCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblSelectionSum = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblDiffAssoc = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboFinYear = New System.Windows.Forms.ComboBox()
        Me.lblFinYear = New System.Windows.Forms.Label()
        Me.btnAdjustCorpusOutstanding = New System.Windows.Forms.Button()
        Me.cboReceiptNo = New System.Windows.Forms.ComboBox()
        Me.btnQuickEntry = New System.Windows.Forms.Button()
        Me.optUntracedPaymentReceipt = New System.Windows.Forms.RadioButton()
        CType(Me.dgvJournalBilled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvJournalPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.receiptContextMenu.SuspendLayout()
        Me.grpExpenseType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnQuery
        '
        Me.btnQuery.AutoSize = True
        Me.btnQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuery.Location = New System.Drawing.Point(249, 7)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(44, 23)
        Me.btnQuery.TabIndex = 12
        Me.btnQuery.Text = "Fetch"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'cboFlatCode
        '
        Me.cboFlatCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlatCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboFlatCode.FormattingEnabled = True
        Me.cboFlatCode.Location = New System.Drawing.Point(82, 8)
        Me.cboFlatCode.Name = "cboFlatCode"
        Me.cboFlatCode.Size = New System.Drawing.Size(97, 21)
        Me.cboFlatCode.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Payee"
        '
        'dgvJournalBilled
        '
        Me.dgvJournalBilled.AllowUserToAddRows = False
        Me.dgvJournalBilled.AllowUserToDeleteRows = False
        Me.dgvJournalBilled.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvJournalBilled.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalBilled.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvJournalBilled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvJournalBilled.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JournalID, Me.TxnType, Me.TxnDate, Me.Narration, Me.TxnAmt})
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournalBilled.DefaultCellStyle = DataGridViewCellStyle29
        Me.dgvJournalBilled.Location = New System.Drawing.Point(2, 317)
        Me.dgvJournalBilled.Name = "dgvJournalBilled"
        Me.dgvJournalBilled.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalBilled.RowHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.dgvJournalBilled.RowHeadersVisible = False
        Me.dgvJournalBilled.RowTemplate.Height = 24
        Me.dgvJournalBilled.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvJournalBilled.Size = New System.Drawing.Size(550, 580)
        Me.dgvJournalBilled.TabIndex = 30
        '
        'JournalID
        '
        Me.JournalID.HeaderText = "JournalID"
        Me.JournalID.Name = "JournalID"
        Me.JournalID.Visible = False
        '
        'TxnType
        '
        Me.TxnType.HeaderText = "TxnType"
        Me.TxnType.Name = "TxnType"
        Me.TxnType.Visible = False
        '
        'TxnDate
        '
        Me.TxnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle26.Format = "D"
        DataGridViewCellStyle26.NullValue = Nothing
        Me.TxnDate.DefaultCellStyle = DataGridViewCellStyle26
        Me.TxnDate.HeaderText = "Date"
        Me.TxnDate.MaxInputLength = 11
        Me.TxnDate.Name = "TxnDate"
        Me.TxnDate.ReadOnly = True
        '
        'Narration
        '
        Me.Narration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Narration.DefaultCellStyle = DataGridViewCellStyle27
        Me.Narration.HeaderText = "Narration"
        Me.Narration.MaxInputLength = 255
        Me.Narration.MinimumWidth = 10
        Me.Narration.Name = "Narration"
        Me.Narration.ReadOnly = True
        Me.Narration.Width = 300
        '
        'TxnAmt
        '
        Me.TxnAmt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TxnAmt.DefaultCellStyle = DataGridViewCellStyle28
        Me.TxnAmt.HeaderText = "Amount"
        Me.TxnAmt.MaxInputLength = 13
        Me.TxnAmt.Name = "TxnAmt"
        '
        'dgvJournalPaid
        '
        Me.dgvJournalPaid.AllowUserToAddRows = False
        Me.dgvJournalPaid.AllowUserToDeleteRows = False
        Me.dgvJournalPaid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvJournalPaid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalPaid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle31
        Me.dgvJournalPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvJournalPaid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JournalIDPaid, Me.TxnTypePaid, Me.TxnDatePaid, Me.NarrationPaid, Me.TxnAmtPaid})
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournalPaid.DefaultCellStyle = DataGridViewCellStyle35
        Me.dgvJournalPaid.Location = New System.Drawing.Point(558, 317)
        Me.dgvJournalPaid.Name = "dgvJournalPaid"
        Me.dgvJournalPaid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalPaid.RowHeadersDefaultCellStyle = DataGridViewCellStyle36
        Me.dgvJournalPaid.RowHeadersVisible = False
        Me.dgvJournalPaid.RowTemplate.Height = 24
        Me.dgvJournalPaid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvJournalPaid.Size = New System.Drawing.Size(550, 580)
        Me.dgvJournalPaid.TabIndex = 31
        '
        'JournalIDPaid
        '
        Me.JournalIDPaid.HeaderText = "JournalID"
        Me.JournalIDPaid.Name = "JournalIDPaid"
        Me.JournalIDPaid.Visible = False
        '
        'TxnTypePaid
        '
        Me.TxnTypePaid.HeaderText = "TxnTypePaid"
        Me.TxnTypePaid.Name = "TxnTypePaid"
        Me.TxnTypePaid.Visible = False
        '
        'TxnDatePaid
        '
        Me.TxnDatePaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.Format = "D"
        DataGridViewCellStyle32.NullValue = Nothing
        Me.TxnDatePaid.DefaultCellStyle = DataGridViewCellStyle32
        Me.TxnDatePaid.HeaderText = "Txn Date"
        Me.TxnDatePaid.MaxInputLength = 11
        Me.TxnDatePaid.Name = "TxnDatePaid"
        Me.TxnDatePaid.ReadOnly = True
        '
        'NarrationPaid
        '
        Me.NarrationPaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NarrationPaid.DefaultCellStyle = DataGridViewCellStyle33
        Me.NarrationPaid.HeaderText = "Narration"
        Me.NarrationPaid.MaxInputLength = 255
        Me.NarrationPaid.MinimumWidth = 10
        Me.NarrationPaid.Name = "NarrationPaid"
        Me.NarrationPaid.ReadOnly = True
        Me.NarrationPaid.Width = 300
        '
        'TxnAmtPaid
        '
        Me.TxnAmtPaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TxnAmtPaid.DefaultCellStyle = DataGridViewCellStyle34
        Me.TxnAmtPaid.HeaderText = "Amount"
        Me.TxnAmtPaid.MaxInputLength = 13
        Me.TxnAmtPaid.Name = "TxnAmtPaid"
        '
        'receiptContextMenu
        '
        Me.receiptContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiEditReceipt, Me.tsmiEmailReceipt, Me.tsmiContraReceipt, Me.tsmiSMSReceipt})
        Me.receiptContextMenu.Name = "coaContextMenu"
        Me.receiptContextMenu.Size = New System.Drawing.Size(167, 92)
        '
        'tsmiEditReceipt
        '
        Me.tsmiEditReceipt.Name = "tsmiEditReceipt"
        Me.tsmiEditReceipt.Size = New System.Drawing.Size(166, 22)
        Me.tsmiEditReceipt.Text = "Edit/View Receipt"
        '
        'tsmiEmailReceipt
        '
        Me.tsmiEmailReceipt.Name = "tsmiEmailReceipt"
        Me.tsmiEmailReceipt.Size = New System.Drawing.Size(166, 22)
        Me.tsmiEmailReceipt.Text = "Email Receipt"
        '
        'tsmiContraReceipt
        '
        Me.tsmiContraReceipt.Enabled = False
        Me.tsmiContraReceipt.Name = "tsmiContraReceipt"
        Me.tsmiContraReceipt.Size = New System.Drawing.Size(166, 22)
        Me.tsmiContraReceipt.Text = "Cancel Receipt"
        Me.tsmiContraReceipt.Visible = False
        '
        'tsmiSMSReceipt
        '
        Me.tsmiSMSReceipt.Name = "tsmiSMSReceipt"
        Me.tsmiSMSReceipt.Size = New System.Drawing.Size(166, 22)
        Me.tsmiSMSReceipt.Text = "SMS Receipt"
        '
        'cboInstrumentType
        '
        Me.cboInstrumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInstrumentType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboInstrumentType.FormattingEnabled = True
        Me.cboInstrumentType.Location = New System.Drawing.Point(451, 43)
        Me.cboInstrumentType.Name = "cboInstrumentType"
        Me.cboInstrumentType.Size = New System.Drawing.Size(113, 21)
        Me.cboInstrumentType.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(350, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Payment Mode"
        '
        'txtNarration
        '
        Me.txtNarration.Location = New System.Drawing.Point(337, 105)
        Me.txtNarration.MaxLength = 5000
        Me.txtNarration.Multiline = True
        Me.txtNarration.Name = "txtNarration"
        Me.txtNarration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNarration.Size = New System.Drawing.Size(450, 40)
        Me.txtNarration.TabIndex = 8
        Me.txtNarration.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(251, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Narration"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Receipt No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Receipt Date"
        '
        'dtpReceiptDate
        '
        Me.dtpReceiptDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReceiptDate.Location = New System.Drawing.Point(106, 76)
        Me.dtpReceiptDate.Name = "dtpReceiptDate"
        Me.dtpReceiptDate.Size = New System.Drawing.Size(134, 20)
        Me.dtpReceiptDate.TabIndex = 6
        '
        'txtInstrumentNo
        '
        Me.txtInstrumentNo.Location = New System.Drawing.Point(692, 43)
        Me.txtInstrumentNo.MaxLength = 50
        Me.txtInstrumentNo.Name = "txtInstrumentNo"
        Me.txtInstrumentNo.Size = New System.Drawing.Size(95, 20)
        Me.txtInstrumentNo.TabIndex = 5
        '
        'lblInstrumentNo
        '
        Me.lblInstrumentNo.Location = New System.Drawing.Point(568, 46)
        Me.lblInstrumentNo.Name = "lblInstrumentNo"
        Me.lblInstrumentNo.Size = New System.Drawing.Size(118, 18)
        Me.lblInstrumentNo.TabIndex = 58
        Me.lblInstrumentNo.Text = "Instrument No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(251, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Bank Name"
        '
        'lblInstrumentDate
        '
        Me.lblInstrumentDate.AutoSize = True
        Me.lblInstrumentDate.Location = New System.Drawing.Point(1, 104)
        Me.lblInstrumentDate.Name = "lblInstrumentDate"
        Me.lblInstrumentDate.Size = New System.Drawing.Size(70, 13)
        Me.lblInstrumentDate.TabIndex = 63
        Me.lblInstrumentDate.Text = "Cheque Date"
        '
        'dtpInstrumentDate
        '
        Me.dtpInstrumentDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpInstrumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInstrumentDate.Location = New System.Drawing.Point(106, 103)
        Me.dtpInstrumentDate.Name = "dtpInstrumentDate"
        Me.dtpInstrumentDate.Size = New System.Drawing.Size(134, 20)
        Me.dtpInstrumentDate.TabIndex = 7
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSave.Location = New System.Drawing.Point(5, 131)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(82, 23)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save Receipt"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Location = New System.Drawing.Point(110, 131)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(48, 23)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtReceiptAmount
        '
        Me.txtReceiptAmount.Location = New System.Drawing.Point(250, 45)
        Me.txtReceiptAmount.MaxLength = 12
        Me.txtReceiptAmount.Name = "txtReceiptAmount"
        Me.txtReceiptAmount.Size = New System.Drawing.Size(95, 20)
        Me.txtReceiptAmount.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(192, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Amount"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(243, 291)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 16)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "Receivables"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(788, 291)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 16)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Payments"
        '
        'lblOwnerDetails
        '
        Me.lblOwnerDetails.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblOwnerDetails.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOwnerDetails.Location = New System.Drawing.Point(521, 3)
        Me.lblOwnerDetails.Name = "lblOwnerDetails"
        Me.lblOwnerDetails.Size = New System.Drawing.Size(243, 35)
        Me.lblOwnerDetails.TabIndex = 70
        '
        'lblBalance
        '
        Me.lblBalance.BackColor = System.Drawing.Color.Black
        Me.lblBalance.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalance.ForeColor = System.Drawing.Color.White
        Me.lblBalance.Location = New System.Drawing.Point(308, 9)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(207, 22)
        Me.lblBalance.TabIndex = 71
        Me.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEditFlatOwnerDetails
        '
        Me.btnEditFlatOwnerDetails.AutoSize = True
        Me.btnEditFlatOwnerDetails.Location = New System.Drawing.Point(765, 7)
        Me.btnEditFlatOwnerDetails.Name = "btnEditFlatOwnerDetails"
        Me.btnEditFlatOwnerDetails.Size = New System.Drawing.Size(30, 27)
        Me.btnEditFlatOwnerDetails.TabIndex = 13
        Me.btnEditFlatOwnerDetails.Text = "..."
        Me.btnEditFlatOwnerDetails.UseVisualStyleBackColor = True
        '
        'btnBookPenalty
        '
        Me.btnBookPenalty.AutoSize = True
        Me.btnBookPenalty.BackColor = System.Drawing.Color.Red
        Me.btnBookPenalty.Location = New System.Drawing.Point(5, 160)
        Me.btnBookPenalty.Name = "btnBookPenalty"
        Me.btnBookPenalty.Size = New System.Drawing.Size(101, 27)
        Me.btnBookPenalty.TabIndex = 11
        Me.btnBookPenalty.Text = "Book Penalty"
        Me.btnBookPenalty.UseVisualStyleBackColor = False
        '
        'cboBankName
        '
        Me.cboBankName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboBankName.FormattingEnabled = True
        Me.cboBankName.Location = New System.Drawing.Point(337, 74)
        Me.cboBankName.Name = "cboBankName"
        Me.cboBankName.Size = New System.Drawing.Size(450, 21)
        Me.cboBankName.TabIndex = 4
        '
        'grpExpenseType
        '
        Me.grpExpenseType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpExpenseType.Controls.Add(Me.optUntracedPaymentReceipt)
        Me.grpExpenseType.Controls.Add(Me.optMiscCollection_FlatOwner)
        Me.grpExpenseType.Controls.Add(Me.optFacilitationFeeReceipt)
        Me.grpExpenseType.Controls.Add(Me.optTenancyRegistrationFeeReceipt)
        Me.grpExpenseType.Controls.Add(Me.optOnDemandFlatServiceReceipt)
        Me.grpExpenseType.Controls.Add(Me.optMiscCollection_NonFlatOwner)
        Me.grpExpenseType.Controls.Add(Me.optEarthMoversCollection)
        Me.grpExpenseType.Controls.Add(Me.optMaintBillCollection)
        Me.grpExpenseType.Controls.Add(Me.optStartrekCollection)
        Me.grpExpenseType.Controls.Add(Me.optAssocFormFundCollection)
        Me.grpExpenseType.Location = New System.Drawing.Point(798, -4)
        Me.grpExpenseType.Name = "grpExpenseType"
        Me.grpExpenseType.Size = New System.Drawing.Size(310, 283)
        Me.grpExpenseType.TabIndex = 117
        Me.grpExpenseType.TabStop = False
        '
        'optMiscCollection_FlatOwner
        '
        Me.optMiscCollection_FlatOwner.AutoSize = True
        Me.optMiscCollection_FlatOwner.Location = New System.Drawing.Point(14, 174)
        Me.optMiscCollection_FlatOwner.Name = "optMiscCollection_FlatOwner"
        Me.optMiscCollection_FlatOwner.Size = New System.Drawing.Size(173, 17)
        Me.optMiscCollection_FlatOwner.TabIndex = 8
        Me.optMiscCollection_FlatOwner.Text = "Misc. Receipt (from Flat Owner)"
        Me.optMiscCollection_FlatOwner.UseVisualStyleBackColor = True
        '
        'optFacilitationFeeReceipt
        '
        Me.optFacilitationFeeReceipt.AutoSize = True
        Me.optFacilitationFeeReceipt.Location = New System.Drawing.Point(14, 147)
        Me.optFacilitationFeeReceipt.Name = "optFacilitationFeeReceipt"
        Me.optFacilitationFeeReceipt.Size = New System.Drawing.Size(136, 17)
        Me.optFacilitationFeeReceipt.TabIndex = 7
        Me.optFacilitationFeeReceipt.Text = "Facilitation Fee Receipt"
        Me.optFacilitationFeeReceipt.UseVisualStyleBackColor = True
        '
        'optTenancyRegistrationFeeReceipt
        '
        Me.optTenancyRegistrationFeeReceipt.AutoSize = True
        Me.optTenancyRegistrationFeeReceipt.Location = New System.Drawing.Point(14, 120)
        Me.optTenancyRegistrationFeeReceipt.Name = "optTenancyRegistrationFeeReceipt"
        Me.optTenancyRegistrationFeeReceipt.Size = New System.Drawing.Size(187, 17)
        Me.optTenancyRegistrationFeeReceipt.TabIndex = 6
        Me.optTenancyRegistrationFeeReceipt.Text = "Tenancy Registration Fee Receipt"
        Me.optTenancyRegistrationFeeReceipt.UseVisualStyleBackColor = True
        '
        'optOnDemandFlatServiceReceipt
        '
        Me.optOnDemandFlatServiceReceipt.AutoSize = True
        Me.optOnDemandFlatServiceReceipt.Location = New System.Drawing.Point(14, 93)
        Me.optOnDemandFlatServiceReceipt.Name = "optOnDemandFlatServiceReceipt"
        Me.optOnDemandFlatServiceReceipt.Size = New System.Drawing.Size(181, 17)
        Me.optOnDemandFlatServiceReceipt.TabIndex = 5
        Me.optOnDemandFlatServiceReceipt.Text = "On Demand Flat Service Receipt"
        Me.optOnDemandFlatServiceReceipt.UseVisualStyleBackColor = True
        '
        'optMiscCollection_NonFlatOwner
        '
        Me.optMiscCollection_NonFlatOwner.AutoSize = True
        Me.optMiscCollection_NonFlatOwner.Location = New System.Drawing.Point(14, 201)
        Me.optMiscCollection_NonFlatOwner.Name = "optMiscCollection_NonFlatOwner"
        Me.optMiscCollection_NonFlatOwner.Size = New System.Drawing.Size(194, 17)
        Me.optMiscCollection_NonFlatOwner.TabIndex = 4
        Me.optMiscCollection_NonFlatOwner.Text = "Misc. Receipt (from non Flat Owner)"
        Me.optMiscCollection_NonFlatOwner.UseVisualStyleBackColor = True
        '
        'optEarthMoversCollection
        '
        Me.optEarthMoversCollection.AutoSize = True
        Me.optEarthMoversCollection.Location = New System.Drawing.Point(14, 251)
        Me.optEarthMoversCollection.Name = "optEarthMoversCollection"
        Me.optEarthMoversCollection.Size = New System.Drawing.Size(137, 17)
        Me.optEarthMoversCollection.TabIndex = 3
        Me.optEarthMoversCollection.Text = "Earth Movers Collection"
        Me.optEarthMoversCollection.UseVisualStyleBackColor = True
        Me.optEarthMoversCollection.Visible = False
        '
        'optMaintBillCollection
        '
        Me.optMaintBillCollection.AutoSize = True
        Me.optMaintBillCollection.Checked = True
        Me.optMaintBillCollection.Location = New System.Drawing.Point(14, 12)
        Me.optMaintBillCollection.Name = "optMaintBillCollection"
        Me.optMaintBillCollection.Size = New System.Drawing.Size(143, 17)
        Me.optMaintBillCollection.TabIndex = 2
        Me.optMaintBillCollection.TabStop = True
        Me.optMaintBillCollection.Text = "Maintenance Bill Receipt"
        Me.optMaintBillCollection.UseVisualStyleBackColor = True
        '
        'optStartrekCollection
        '
        Me.optStartrekCollection.AutoSize = True
        Me.optStartrekCollection.Location = New System.Drawing.Point(14, 66)
        Me.optStartrekCollection.Name = "optStartrekCollection"
        Me.optStartrekCollection.Size = New System.Drawing.Size(151, 17)
        Me.optStartrekCollection.TabIndex = 1
        Me.optStartrekCollection.Text = "Startrek Collection Receipt"
        Me.optStartrekCollection.UseVisualStyleBackColor = True
        '
        'optAssocFormFundCollection
        '
        Me.optAssocFormFundCollection.AutoSize = True
        Me.optAssocFormFundCollection.Location = New System.Drawing.Point(14, 39)
        Me.optAssocFormFundCollection.Name = "optAssocFormFundCollection"
        Me.optAssocFormFundCollection.Size = New System.Drawing.Size(222, 17)
        Me.optAssocFormFundCollection.TabIndex = 0
        Me.optAssocFormFundCollection.Text = "Assoc. Formation Fund Collection Receipt"
        Me.optAssocFormFundCollection.UseVisualStyleBackColor = True
        '
        'btnBookOtherCharges
        '
        Me.btnBookOtherCharges.AutoSize = True
        Me.btnBookOtherCharges.BackColor = System.Drawing.Color.Red
        Me.btnBookOtherCharges.Location = New System.Drawing.Point(5, 188)
        Me.btnBookOtherCharges.Name = "btnBookOtherCharges"
        Me.btnBookOtherCharges.Size = New System.Drawing.Size(147, 27)
        Me.btnBookOtherCharges.TabIndex = 118
        Me.btnBookOtherCharges.Text = "Book Other Charges"
        Me.btnBookOtherCharges.UseVisualStyleBackColor = False
        '
        'btnOldMaintenanceBills
        '
        Me.btnOldMaintenanceBills.AutoSize = True
        Me.btnOldMaintenanceBills.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOldMaintenanceBills.Location = New System.Drawing.Point(5, 216)
        Me.btnOldMaintenanceBills.Name = "btnOldMaintenanceBills"
        Me.btnOldMaintenanceBills.Size = New System.Drawing.Size(119, 23)
        Me.btnOldMaintenanceBills.TabIndex = 119
        Me.btnOldMaintenanceBills.Text = "Old Maintenance Bills"
        Me.btnOldMaintenanceBills.UseVisualStyleBackColor = True
        '
        'btnOldEAMCBills
        '
        Me.btnOldEAMCBills.AutoSize = True
        Me.btnOldEAMCBills.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOldEAMCBills.Location = New System.Drawing.Point(5, 245)
        Me.btnOldEAMCBills.Name = "btnOldEAMCBills"
        Me.btnOldEAMCBills.Size = New System.Drawing.Size(87, 23)
        Me.btnOldEAMCBills.TabIndex = 120
        Me.btnOldEAMCBills.Text = "Old EAMC Bills"
        Me.btnOldEAMCBills.UseVisualStyleBackColor = True
        '
        'btnMarkAsBGFOutstandingPayment
        '
        Me.btnMarkAsBGFOutstandingPayment.AutoSize = True
        Me.btnMarkAsBGFOutstandingPayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnMarkAsBGFOutstandingPayment.Location = New System.Drawing.Point(559, 150)
        Me.btnMarkAsBGFOutstandingPayment.Name = "btnMarkAsBGFOutstandingPayment"
        Me.btnMarkAsBGFOutstandingPayment.Size = New System.Drawing.Size(135, 23)
        Me.btnMarkAsBGFOutstandingPayment.TabIndex = 121
        Me.btnMarkAsBGFOutstandingPayment.Text = "MarkAsBGFOut.Payment"
        Me.btnMarkAsBGFOutstandingPayment.UseVisualStyleBackColor = True
        '
        'btnMarkAsHIGAssocPayment
        '
        Me.btnMarkAsHIGAssocPayment.AutoSize = True
        Me.btnMarkAsHIGAssocPayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnMarkAsHIGAssocPayment.Location = New System.Drawing.Point(559, 183)
        Me.btnMarkAsHIGAssocPayment.Name = "btnMarkAsHIGAssocPayment"
        Me.btnMarkAsHIGAssocPayment.Size = New System.Drawing.Size(136, 23)
        Me.btnMarkAsHIGAssocPayment.TabIndex = 122
        Me.btnMarkAsHIGAssocPayment.Text = "MarkAsHIGAssoPayment"
        Me.btnMarkAsHIGAssocPayment.UseVisualStyleBackColor = True
        '
        'lblDiffBGF
        '
        Me.lblDiffBGF.BackColor = System.Drawing.Color.Black
        Me.lblDiffBGF.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiffBGF.ForeColor = System.Drawing.Color.White
        Me.lblDiffBGF.Location = New System.Drawing.Point(117, 902)
        Me.lblDiffBGF.Name = "lblDiffBGF"
        Me.lblDiffBGF.Size = New System.Drawing.Size(145, 22)
        Me.lblDiffBGF.TabIndex = 123
        Me.lblDiffBGF.Visible = False
        '
        'btnAdjustExtraPayment
        '
        Me.btnAdjustExtraPayment.AutoSize = True
        Me.btnAdjustExtraPayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAdjustExtraPayment.Location = New System.Drawing.Point(559, 216)
        Me.btnAdjustExtraPayment.Name = "btnAdjustExtraPayment"
        Me.btnAdjustExtraPayment.Size = New System.Drawing.Size(111, 23)
        Me.btnAdjustExtraPayment.TabIndex = 124
        Me.btnAdjustExtraPayment.Text = "AdjustExtraPayment"
        Me.btnAdjustExtraPayment.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnShowChequeDetails)
        Me.GroupBox1.Controls.Add(Me.cboChequeNo)
        Me.GroupBox1.Location = New System.Drawing.Point(337, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(205, 63)
        Me.GroupBox1.TabIndex = 125
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cheque Search"
        '
        'btnShowChequeDetails
        '
        Me.btnShowChequeDetails.Location = New System.Drawing.Point(169, 22)
        Me.btnShowChequeDetails.Name = "btnShowChequeDetails"
        Me.btnShowChequeDetails.Size = New System.Drawing.Size(30, 27)
        Me.btnShowChequeDetails.TabIndex = 118
        Me.btnShowChequeDetails.Text = "..."
        Me.btnShowChequeDetails.UseVisualStyleBackColor = True
        '
        'cboChequeNo
        '
        Me.cboChequeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboChequeNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboChequeNo.FormattingEnabled = True
        Me.cboChequeNo.Location = New System.Drawing.Point(8, 23)
        Me.cboChequeNo.Name = "cboChequeNo"
        Me.cboChequeNo.Size = New System.Drawing.Size(157, 21)
        Me.cboChequeNo.Sorted = True
        Me.cboChequeNo.TabIndex = 116
        '
        'txtDuplexFlatCode
        '
        Me.txtDuplexFlatCode.Enabled = False
        Me.txtDuplexFlatCode.Location = New System.Drawing.Point(182, 9)
        Me.txtDuplexFlatCode.MaxLength = 20
        Me.txtDuplexFlatCode.Name = "txtDuplexFlatCode"
        Me.txtDuplexFlatCode.Size = New System.Drawing.Size(64, 20)
        Me.txtDuplexFlatCode.TabIndex = 128
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Green
        Me.Label10.Location = New System.Drawing.Point(560, 902)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(142, 9)
        Me.Label10.TabIndex = 129
        Me.Label10.Text = "Reconciled with bank statement"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(772, 902)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(160, 9)
        Me.Label11.TabIndex = 130
        Me.Label11.Text = "Not Reconciled with bank statement"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1002, 902)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 9)
        Me.Label12.TabIndex = 131
        Me.Label12.Text = "Non Banking Txn"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(342, 245)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(159, 15)
        Me.Label13.TabIndex = 138
        Me.Label13.Text = "1 CHEQUE - 1 RECEIPT"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSelectionSum
        '
        Me.lblSelectionSum.BackColor = System.Drawing.Color.Black
        Me.lblSelectionSum.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblSelectionSum.ForeColor = System.Drawing.Color.White
        Me.lblSelectionSum.Location = New System.Drawing.Point(510, 291)
        Me.lblSelectionSum.Name = "lblSelectionSum"
        Me.lblSelectionSum.Size = New System.Drawing.Size(91, 22)
        Me.lblSelectionSum.TabIndex = 139
        Me.lblSelectionSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(541, 246)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 15)
        Me.Label14.TabIndex = 140
        Me.Label14.Text = "1 FLAT - 1 CHEQUE"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(12, 904)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 15)
        Me.Label15.TabIndex = 141
        Me.Label15.Text = "BGF Due"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label15.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(286, 904)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 15)
        Me.Label16.TabIndex = 143
        Me.Label16.Text = "Assoc. Due"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDiffAssoc
        '
        Me.lblDiffAssoc.BackColor = System.Drawing.Color.Black
        Me.lblDiffAssoc.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiffAssoc.ForeColor = System.Drawing.Color.White
        Me.lblDiffAssoc.Location = New System.Drawing.Point(391, 902)
        Me.lblDiffAssoc.Name = "lblDiffAssoc"
        Me.lblDiffAssoc.Size = New System.Drawing.Size(145, 22)
        Me.lblDiffAssoc.TabIndex = 142
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(205, 160)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 13)
        Me.Label17.TabIndex = 145
        Me.Label17.Text = "Financial Year"
        '
        'cboFinYear
        '
        Me.cboFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFinYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboFinYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFinYear.ForeColor = System.Drawing.Color.Blue
        Me.cboFinYear.FormattingEnabled = True
        Me.cboFinYear.Location = New System.Drawing.Point(195, 183)
        Me.cboFinYear.Name = "cboFinYear"
        Me.cboFinYear.Size = New System.Drawing.Size(136, 21)
        Me.cboFinYear.TabIndex = 144
        '
        'lblFinYear
        '
        Me.lblFinYear.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblFinYear.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinYear.Location = New System.Drawing.Point(195, 212)
        Me.lblFinYear.Name = "lblFinYear"
        Me.lblFinYear.Size = New System.Drawing.Size(137, 25)
        Me.lblFinYear.TabIndex = 146
        '
        'btnAdjustCorpusOutstanding
        '
        Me.btnAdjustCorpusOutstanding.AutoSize = True
        Me.btnAdjustCorpusOutstanding.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAdjustCorpusOutstanding.Location = New System.Drawing.Point(345, 216)
        Me.btnAdjustCorpusOutstanding.Name = "btnAdjustCorpusOutstanding"
        Me.btnAdjustCorpusOutstanding.Size = New System.Drawing.Size(142, 23)
        Me.btnAdjustCorpusOutstanding.TabIndex = 147
        Me.btnAdjustCorpusOutstanding.Text = "Adjust Corpus Outstanding"
        Me.btnAdjustCorpusOutstanding.UseVisualStyleBackColor = True
        '
        'cboReceiptNo
        '
        Me.cboReceiptNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReceiptNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboReceiptNo.FormattingEnabled = True
        Me.cboReceiptNo.Location = New System.Drawing.Point(82, 44)
        Me.cboReceiptNo.Name = "cboReceiptNo"
        Me.cboReceiptNo.Size = New System.Drawing.Size(104, 21)
        Me.cboReceiptNo.TabIndex = 148
        '
        'btnQuickEntry
        '
        Me.btnQuickEntry.AutoSize = True
        Me.btnQuickEntry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuickEntry.BackColor = System.Drawing.Color.Yellow
        Me.btnQuickEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuickEntry.ForeColor = System.Drawing.Color.Red
        Me.btnQuickEntry.Location = New System.Drawing.Point(128, 246)
        Me.btnQuickEntry.Name = "btnQuickEntry"
        Me.btnQuickEntry.Size = New System.Drawing.Size(83, 23)
        Me.btnQuickEntry.TabIndex = 149
        Me.btnQuickEntry.Text = "Quick Entry"
        Me.btnQuickEntry.UseVisualStyleBackColor = False
        '
        'optUntracedPaymentReceipt
        '
        Me.optUntracedPaymentReceipt.AutoSize = True
        Me.optUntracedPaymentReceipt.ContextMenuStrip = Me.receiptContextMenu
        Me.optUntracedPaymentReceipt.Location = New System.Drawing.Point(14, 225)
        Me.optUntracedPaymentReceipt.Name = "optUntracedPaymentReceipt"
        Me.optUntracedPaymentReceipt.Size = New System.Drawing.Size(113, 17)
        Me.optUntracedPaymentReceipt.TabIndex = 9
        Me.optUntracedPaymentReceipt.Text = "Untraced Payment"
        Me.optUntracedPaymentReceipt.UseVisualStyleBackColor = True
        '
        'frmBookReceipt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1112, 977)
        Me.Controls.Add(Me.btnQuickEntry)
        Me.Controls.Add(Me.cboReceiptNo)
        Me.Controls.Add(Me.btnAdjustCorpusOutstanding)
        Me.Controls.Add(Me.lblFinYear)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cboFinYear)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.lblDiffAssoc)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblSelectionSum)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDuplexFlatCode)
        Me.Controls.Add(Me.lblDiffBGF)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAdjustExtraPayment)
        Me.Controls.Add(Me.btnOldEAMCBills)
        Me.Controls.Add(Me.btnMarkAsHIGAssocPayment)
        Me.Controls.Add(Me.btnMarkAsBGFOutstandingPayment)
        Me.Controls.Add(Me.grpExpenseType)
        Me.Controls.Add(Me.btnOldMaintenanceBills)
        Me.Controls.Add(Me.btnBookOtherCharges)
        Me.Controls.Add(Me.cboBankName)
        Me.Controls.Add(Me.btnBookPenalty)
        Me.Controls.Add(Me.btnEditFlatOwnerDetails)
        Me.Controls.Add(Me.lblBalance)
        Me.Controls.Add(Me.lblOwnerDetails)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtReceiptAmount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblInstrumentDate)
        Me.Controls.Add(Me.dtpInstrumentDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtInstrumentNo)
        Me.Controls.Add(Me.lblInstrumentNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpReceiptDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNarration)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboInstrumentType)
        Me.Controls.Add(Me.dgvJournalPaid)
        Me.Controls.Add(Me.dgvJournalBilled)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.cboFlatCode)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmBookReceipt"
        Me.Text = "Record Receipts in Journal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvJournalBilled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvJournalPaid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.receiptContextMenu.ResumeLayout(False)
        Me.grpExpenseType.ResumeLayout(False)
        Me.grpExpenseType.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFlatCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents dgvJournalBilled As System.Windows.Forms.DataGridView
    Friend WithEvents dgvJournalPaid As System.Windows.Forms.DataGridView
    Friend WithEvents cboInstrumentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNarration As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpReceiptDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtInstrumentNo As System.Windows.Forms.TextBox
    Friend WithEvents lblInstrumentNo As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblInstrumentDate As System.Windows.Forms.Label
    Friend WithEvents dtpInstrumentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtReceiptAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblOwnerDetails As System.Windows.Forms.Label
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents btnEditFlatOwnerDetails As System.Windows.Forms.Button
    Friend WithEvents btnBookPenalty As System.Windows.Forms.Button
    Friend WithEvents cboBankName As System.Windows.Forms.ComboBox
    Friend WithEvents grpExpenseType As System.Windows.Forms.GroupBox
    Friend WithEvents optMaintBillCollection As System.Windows.Forms.RadioButton
    Friend WithEvents optStartrekCollection As System.Windows.Forms.RadioButton
    Friend WithEvents optAssocFormFundCollection As System.Windows.Forms.RadioButton
    Friend WithEvents optEarthMoversCollection As System.Windows.Forms.RadioButton
    Friend WithEvents btnBookOtherCharges As System.Windows.Forms.Button
    Friend WithEvents btnOldMaintenanceBills As System.Windows.Forms.Button
    Friend WithEvents btnOldEAMCBills As System.Windows.Forms.Button
    Friend WithEvents btnMarkAsBGFOutstandingPayment As System.Windows.Forms.Button
    Friend WithEvents btnMarkAsHIGAssocPayment As System.Windows.Forms.Button
    Friend WithEvents lblDiffBGF As System.Windows.Forms.Label
    Friend WithEvents btnAdjustExtraPayment As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnShowChequeDetails As System.Windows.Forms.Button
    Friend WithEvents cboChequeNo As System.Windows.Forms.ComboBox
    Friend WithEvents txtDuplexFlatCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblSelectionSum As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents receiptContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiEditReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiEmailReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiContraReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JournalID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Narration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents optMiscCollection_NonFlatOwner As System.Windows.Forms.RadioButton
    Friend WithEvents optOnDemandFlatServiceReceipt As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblDiffAssoc As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboFinYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblFinYear As System.Windows.Forms.Label
    Friend WithEvents btnAdjustCorpusOutstanding As System.Windows.Forms.Button
    Friend WithEvents cboReceiptNo As System.Windows.Forms.ComboBox
    Friend WithEvents JournalIDPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnTypePaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnDatePaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NarrationPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnAmtPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents optFacilitationFeeReceipt As System.Windows.Forms.RadioButton
    Friend WithEvents optTenancyRegistrationFeeReceipt As System.Windows.Forms.RadioButton
    Friend WithEvents optMiscCollection_FlatOwner As System.Windows.Forms.RadioButton
    Friend WithEvents btnQuickEntry As System.Windows.Forms.Button
    Friend WithEvents tsmiSMSReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents optUntracedPaymentReceipt As System.Windows.Forms.RadioButton
End Class
