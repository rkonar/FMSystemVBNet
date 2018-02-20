<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookReceiptCultural
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.cboFlatCode = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblOwnerDetails = New System.Windows.Forms.Label()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.btnEditFlatOwnerDetails = New System.Windows.Forms.Button()
        Me.cboBankName = New System.Windows.Forms.ComboBox()
        Me.grpExpenseType = New System.Windows.Forms.GroupBox()
        Me.optCultCollection_FlatOwner = New System.Windows.Forms.RadioButton()
        Me.optCultCollection_NonFlatOwner = New System.Windows.Forms.RadioButton()
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
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboFinYear = New System.Windows.Forms.ComboBox()
        Me.lblFinYear = New System.Windows.Forms.Label()
        Me.cboReceiptNo = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optSubscription = New System.Windows.Forms.RadioButton()
        Me.optOthers = New System.Windows.Forms.RadioButton()
        CType(Me.dgvJournalPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.receiptContextMenu.SuspendLayout()
        Me.grpExpenseType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        'dgvJournalPaid
        '
        Me.dgvJournalPaid.AllowUserToAddRows = False
        Me.dgvJournalPaid.AllowUserToDeleteRows = False
        Me.dgvJournalPaid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvJournalPaid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalPaid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvJournalPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvJournalPaid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JournalIDPaid, Me.TxnTypePaid, Me.TxnDatePaid, Me.NarrationPaid, Me.TxnAmtPaid})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournalPaid.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvJournalPaid.Location = New System.Drawing.Point(15, 223)
        Me.dgvJournalPaid.Name = "dgvJournalPaid"
        Me.dgvJournalPaid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalPaid.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvJournalPaid.RowHeadersVisible = False
        Me.dgvJournalPaid.RowTemplate.Height = 24
        Me.dgvJournalPaid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvJournalPaid.Size = New System.Drawing.Size(1093, 649)
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "D"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.TxnDatePaid.DefaultCellStyle = DataGridViewCellStyle2
        Me.TxnDatePaid.HeaderText = "Txn Date"
        Me.TxnDatePaid.MaxInputLength = 11
        Me.TxnDatePaid.Name = "TxnDatePaid"
        Me.TxnDatePaid.ReadOnly = True
        '
        'NarrationPaid
        '
        Me.NarrationPaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NarrationPaid.DefaultCellStyle = DataGridViewCellStyle3
        Me.NarrationPaid.HeaderText = "Narration"
        Me.NarrationPaid.MaxInputLength = 255
        Me.NarrationPaid.MinimumWidth = 10
        Me.NarrationPaid.Name = "NarrationPaid"
        Me.NarrationPaid.ReadOnly = True
        Me.NarrationPaid.Width = 800
        '
        'TxnAmtPaid
        '
        Me.TxnAmtPaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TxnAmtPaid.DefaultCellStyle = DataGridViewCellStyle4
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
        Me.txtNarration.Size = New System.Drawing.Size(560, 57)
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(788, 197)
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
        Me.grpExpenseType.Controls.Add(Me.optCultCollection_FlatOwner)
        Me.grpExpenseType.Controls.Add(Me.optCultCollection_NonFlatOwner)
        Me.grpExpenseType.Location = New System.Drawing.Point(798, -4)
        Me.grpExpenseType.Name = "grpExpenseType"
        Me.grpExpenseType.Size = New System.Drawing.Size(175, 83)
        Me.grpExpenseType.TabIndex = 117
        Me.grpExpenseType.TabStop = False
        '
        'optCultCollection_FlatOwner
        '
        Me.optCultCollection_FlatOwner.AutoSize = True
        Me.optCultCollection_FlatOwner.Checked = True
        Me.optCultCollection_FlatOwner.Location = New System.Drawing.Point(8, 19)
        Me.optCultCollection_FlatOwner.Name = "optCultCollection_FlatOwner"
        Me.optCultCollection_FlatOwner.Size = New System.Drawing.Size(145, 17)
        Me.optCultCollection_FlatOwner.TabIndex = 8
        Me.optCultCollection_FlatOwner.TabStop = True
        Me.optCultCollection_FlatOwner.Text = "Receipt (from Flat Owner)"
        Me.optCultCollection_FlatOwner.UseVisualStyleBackColor = True
        '
        'optCultCollection_NonFlatOwner
        '
        Me.optCultCollection_NonFlatOwner.AutoSize = True
        Me.optCultCollection_NonFlatOwner.Location = New System.Drawing.Point(8, 46)
        Me.optCultCollection_NonFlatOwner.Name = "optCultCollection_NonFlatOwner"
        Me.optCultCollection_NonFlatOwner.Size = New System.Drawing.Size(166, 17)
        Me.optCultCollection_NonFlatOwner.TabIndex = 4
        Me.optCultCollection_NonFlatOwner.Text = "Receipt (from non Flat Owner)"
        Me.optCultCollection_NonFlatOwner.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnShowChequeDetails)
        Me.GroupBox1.Controls.Add(Me.cboChequeNo)
        Me.GroupBox1.Location = New System.Drawing.Point(903, 91)
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
        Me.Label10.Location = New System.Drawing.Point(560, 877)
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
        Me.Label11.Location = New System.Drawing.Point(772, 877)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(160, 9)
        Me.Label11.TabIndex = 130
        Me.Label11.Text = "Not Reconciled with bank statement"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1002, 877)
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
        Me.Label13.Location = New System.Drawing.Point(342, 176)
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
        Me.lblSelectionSum.Location = New System.Drawing.Point(510, 197)
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
        Me.Label14.Location = New System.Drawing.Point(541, 177)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 15)
        Me.Label14.TabIndex = 140
        Me.Label14.Text = "1 FLAT - 1 CHEQUE"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(14, 170)
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
        Me.cboFinYear.Location = New System.Drawing.Point(109, 167)
        Me.cboFinYear.Name = "cboFinYear"
        Me.cboFinYear.Size = New System.Drawing.Size(136, 21)
        Me.cboFinYear.TabIndex = 144
        '
        'lblFinYear
        '
        Me.lblFinYear.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblFinYear.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinYear.Location = New System.Drawing.Point(109, 195)
        Me.lblFinYear.Name = "lblFinYear"
        Me.lblFinYear.Size = New System.Drawing.Size(137, 25)
        Me.lblFinYear.TabIndex = 146
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
        'GroupBox2
        '
        Me.GroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox2.Controls.Add(Me.optSubscription)
        Me.GroupBox2.Controls.Add(Me.optOthers)
        Me.GroupBox2.Location = New System.Drawing.Point(979, -5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(123, 83)
        Me.GroupBox2.TabIndex = 118
        Me.GroupBox2.TabStop = False
        '
        'optSubscription
        '
        Me.optSubscription.AutoSize = True
        Me.optSubscription.Checked = True
        Me.optSubscription.Location = New System.Drawing.Point(8, 19)
        Me.optSubscription.Name = "optSubscription"
        Me.optSubscription.Size = New System.Drawing.Size(83, 17)
        Me.optSubscription.TabIndex = 8
        Me.optSubscription.TabStop = True
        Me.optSubscription.Text = "Subscription"
        Me.optSubscription.UseVisualStyleBackColor = True
        '
        'optOthers
        '
        Me.optOthers.AutoSize = True
        Me.optOthers.Location = New System.Drawing.Point(8, 46)
        Me.optOthers.Name = "optOthers"
        Me.optOthers.Size = New System.Drawing.Size(56, 17)
        Me.optOthers.TabIndex = 4
        Me.optOthers.Text = "Others"
        Me.optOthers.UseVisualStyleBackColor = True
        '
        'frmBookReceiptCultural
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1112, 977)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cboReceiptNo)
        Me.Controls.Add(Me.lblFinYear)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cboFinYear)
        Me.Controls.Add(Me.lblSelectionSum)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDuplexFlatCode)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpExpenseType)
        Me.Controls.Add(Me.cboBankName)
        Me.Controls.Add(Me.btnEditFlatOwnerDetails)
        Me.Controls.Add(Me.lblBalance)
        Me.Controls.Add(Me.lblOwnerDetails)
        Me.Controls.Add(Me.Label9)
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
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.cboFlatCode)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmBookReceiptCultural"
        Me.Text = "Record Receipts in Journal for Cultural Sub Committee"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvJournalPaid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.receiptContextMenu.ResumeLayout(False)
        Me.grpExpenseType.ResumeLayout(False)
        Me.grpExpenseType.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFlatCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnQuery As System.Windows.Forms.Button
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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblOwnerDetails As System.Windows.Forms.Label
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents btnEditFlatOwnerDetails As System.Windows.Forms.Button
    Friend WithEvents cboBankName As System.Windows.Forms.ComboBox
    Friend WithEvents grpExpenseType As System.Windows.Forms.GroupBox
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
    Friend WithEvents optCultCollection_NonFlatOwner As System.Windows.Forms.RadioButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboFinYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblFinYear As System.Windows.Forms.Label
    Friend WithEvents cboReceiptNo As System.Windows.Forms.ComboBox
    Friend WithEvents optCultCollection_FlatOwner As System.Windows.Forms.RadioButton
    Friend WithEvents tsmiSMSReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JournalIDPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnTypePaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnDatePaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NarrationPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnAmtPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optSubscription As System.Windows.Forms.RadioButton
    Friend WithEvents optOthers As System.Windows.Forms.RadioButton
End Class
