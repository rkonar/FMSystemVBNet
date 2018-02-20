<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmJournalSpecialTxnsCultural
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtTxnAmount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpTxnDate = New System.Windows.Forms.DateTimePicker()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtNarration = New System.Windows.Forms.TextBox()
        Me.lblDebitDesc = New System.Windows.Forms.Label()
        Me.cboDebitAccount = New System.Windows.Forms.ComboBox()
        Me.lblCreditDesc = New System.Windows.Forms.Label()
        Me.cboCreditAccount = New System.Windows.Forms.ComboBox()
        Me.txtDebitActDesc = New System.Windows.Forms.TextBox()
        Me.txtCreditActDesc = New System.Windows.Forms.TextBox()
        Me.cboTxnType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDrBalance = New System.Windows.Forms.Label()
        Me.lblCrBalance = New System.Windows.Forms.Label()
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
        Me.refgid_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnQueryTxn = New System.Windows.Forms.Button()
        Me.lblCnt_b = New System.Windows.Forms.Label()
        Me.lblBalance_b = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblTxnType = New System.Windows.Forms.Label()
        Me.lblInstrumentDate = New System.Windows.Forms.Label()
        Me.dtpInstrumentDate = New System.Windows.Forms.DateTimePicker()
        Me.cboInstrumentNo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.cboSampleNarration = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgvJournal_b, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSave.Location = New System.Drawing.Point(28, 295)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(42, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCancel.Location = New System.Drawing.Point(84, 295)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(43, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtTxnAmount
        '
        Me.txtTxnAmount.Location = New System.Drawing.Point(424, 39)
        Me.txtTxnAmount.MaxLength = 12
        Me.txtTxnAmount.Name = "txtTxnAmount"
        Me.txtTxnAmount.Size = New System.Drawing.Size(157, 20)
        Me.txtTxnAmount.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(357, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Amount"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "Transaction Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpTxnDate
        '
        Me.dtpTxnDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTxnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTxnDate.Location = New System.Drawing.Point(136, 39)
        Me.dtpTxnDate.Name = "dtpTxnDate"
        Me.dtpTxnDate.Size = New System.Drawing.Size(149, 20)
        Me.dtpTxnDate.TabIndex = 2
        '
        'lblRemarks
        '
        Me.lblRemarks.Location = New System.Drawing.Point(9, 200)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(122, 20)
        Me.lblRemarks.TabIndex = 90
        Me.lblRemarks.Text = "Narration"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNarration
        '
        Me.txtNarration.Location = New System.Drawing.Point(137, 180)
        Me.txtNarration.MaxLength = 5000
        Me.txtNarration.Multiline = True
        Me.txtNarration.Name = "txtNarration"
        Me.txtNarration.Size = New System.Drawing.Size(1415, 50)
        Me.txtNarration.TabIndex = 8
        Me.txtNarration.TabStop = False
        '
        'lblDebitDesc
        '
        Me.lblDebitDesc.Location = New System.Drawing.Point(6, 71)
        Me.lblDebitDesc.Name = "lblDebitDesc"
        Me.lblDebitDesc.Size = New System.Drawing.Size(115, 24)
        Me.lblDebitDesc.TabIndex = 107
        Me.lblDebitDesc.Text = "Debit"
        Me.lblDebitDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDebitAccount
        '
        Me.cboDebitAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDebitAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboDebitAccount.FormattingEnabled = True
        Me.cboDebitAccount.Location = New System.Drawing.Point(136, 73)
        Me.cboDebitAccount.Name = "cboDebitAccount"
        Me.cboDebitAccount.Size = New System.Drawing.Size(287, 21)
        Me.cboDebitAccount.TabIndex = 6
        '
        'lblCreditDesc
        '
        Me.lblCreditDesc.Location = New System.Drawing.Point(6, 119)
        Me.lblCreditDesc.Name = "lblCreditDesc"
        Me.lblCreditDesc.Size = New System.Drawing.Size(115, 17)
        Me.lblCreditDesc.TabIndex = 109
        Me.lblCreditDesc.Text = "Credit"
        Me.lblCreditDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCreditAccount
        '
        Me.cboCreditAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCreditAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboCreditAccount.FormattingEnabled = True
        Me.cboCreditAccount.Location = New System.Drawing.Point(136, 117)
        Me.cboCreditAccount.Name = "cboCreditAccount"
        Me.cboCreditAccount.Size = New System.Drawing.Size(287, 21)
        Me.cboCreditAccount.TabIndex = 7
        '
        'txtDebitActDesc
        '
        Me.txtDebitActDesc.Location = New System.Drawing.Point(562, 73)
        Me.txtDebitActDesc.MaxLength = 12
        Me.txtDebitActDesc.Multiline = True
        Me.txtDebitActDesc.Name = "txtDebitActDesc"
        Me.txtDebitActDesc.ReadOnly = True
        Me.txtDebitActDesc.Size = New System.Drawing.Size(990, 21)
        Me.txtDebitActDesc.TabIndex = 111
        '
        'txtCreditActDesc
        '
        Me.txtCreditActDesc.Location = New System.Drawing.Point(562, 116)
        Me.txtCreditActDesc.MaxLength = 12
        Me.txtCreditActDesc.Multiline = True
        Me.txtCreditActDesc.Name = "txtCreditActDesc"
        Me.txtCreditActDesc.ReadOnly = True
        Me.txtCreditActDesc.Size = New System.Drawing.Size(990, 22)
        Me.txtCreditActDesc.TabIndex = 112
        '
        'cboTxnType
        '
        Me.cboTxnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTxnType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboTxnType.FormattingEnabled = True
        Me.cboTxnType.Location = New System.Drawing.Point(136, 5)
        Me.cboTxnType.Name = "cboTxnType"
        Me.cboTxnType.Size = New System.Drawing.Size(237, 21)
        Me.cboTxnType.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Transaction Type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDrBalance
        '
        Me.lblDrBalance.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblDrBalance.Location = New System.Drawing.Point(429, 74)
        Me.lblDrBalance.Name = "lblDrBalance"
        Me.lblDrBalance.Size = New System.Drawing.Size(117, 19)
        Me.lblDrBalance.TabIndex = 121
        Me.lblDrBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCrBalance
        '
        Me.lblCrBalance.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblCrBalance.Location = New System.Drawing.Point(429, 118)
        Me.lblCrBalance.Name = "lblCrBalance"
        Me.lblCrBalance.Size = New System.Drawing.Size(117, 19)
        Me.lblCrBalance.TabIndex = 122
        Me.lblCrBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvJournal_b
        '
        Me.dgvJournal_b.AllowUserToAddRows = False
        Me.dgvJournal_b.AllowUserToDeleteRows = False
        Me.dgvJournal_b.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvJournal_b.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvJournal_b.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvJournal_b.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tblid_b, Me.gid_b, Me.TxnType_b, Me.TxnDate_b, Me.Narration_b, Me.DocRef_b, Me.AccountNo_b, Me.DrAmount_b, Me.CrAmount_b, Me.refgid_b})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournal_b.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvJournal_b.Location = New System.Drawing.Point(9, 320)
        Me.dgvJournal_b.Name = "dgvJournal_b"
        Me.dgvJournal_b.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvJournal_b.RowHeadersVisible = False
        Me.dgvJournal_b.RowTemplate.Height = 24
        Me.dgvJournal_b.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvJournal_b.Size = New System.Drawing.Size(1002, 549)
        Me.dgvJournal_b.TabIndex = 123
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
        Me.Narration_b.Width = 250
        '
        'DocRef_b
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DocRef_b.DefaultCellStyle = DataGridViewCellStyle3
        Me.DocRef_b.HeaderText = "DocRef"
        Me.DocRef_b.MinimumWidth = 100
        Me.DocRef_b.Name = "DocRef_b"
        Me.DocRef_b.Width = 250
        '
        'AccountNo_b
        '
        Me.AccountNo_b.HeaderText = "AccountNo"
        Me.AccountNo_b.Name = "AccountNo_b"
        Me.AccountNo_b.Width = 150
        '
        'DrAmount_b
        '
        Me.DrAmount_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DrAmount_b.DefaultCellStyle = DataGridViewCellStyle4
        Me.DrAmount_b.HeaderText = "DrAmount"
        Me.DrAmount_b.MaxInputLength = 13
        Me.DrAmount_b.Name = "DrAmount_b"
        '
        'CrAmount_b
        '
        Me.CrAmount_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CrAmount_b.DefaultCellStyle = DataGridViewCellStyle5
        Me.CrAmount_b.HeaderText = "CrAmount"
        Me.CrAmount_b.MaxInputLength = 13
        Me.CrAmount_b.Name = "CrAmount_b"
        '
        'refgid_b
        '
        Me.refgid_b.HeaderText = "refgid"
        Me.refgid_b.Name = "refgid_b"
        Me.refgid_b.ReadOnly = True
        Me.refgid_b.Visible = False
        '
        'btnQueryTxn
        '
        Me.btnQueryTxn.AutoSize = True
        Me.btnQueryTxn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQueryTxn.Location = New System.Drawing.Point(143, 295)
        Me.btnQueryTxn.Name = "btnQueryTxn"
        Me.btnQueryTxn.Size = New System.Drawing.Size(66, 23)
        Me.btnQueryTxn.TabIndex = 124
        Me.btnQueryTxn.Text = "Query Txn"
        Me.btnQueryTxn.UseVisualStyleBackColor = True
        '
        'lblCnt_b
        '
        Me.lblCnt_b.BackColor = System.Drawing.Color.Black
        Me.lblCnt_b.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCnt_b.ForeColor = System.Drawing.Color.White
        Me.lblCnt_b.Location = New System.Drawing.Point(421, 295)
        Me.lblCnt_b.Name = "lblCnt_b"
        Me.lblCnt_b.Size = New System.Drawing.Size(100, 22)
        Me.lblCnt_b.TabIndex = 136
        Me.lblCnt_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBalance_b
        '
        Me.lblBalance_b.BackColor = System.Drawing.Color.Black
        Me.lblBalance_b.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalance_b.ForeColor = System.Drawing.Color.White
        Me.lblBalance_b.Location = New System.Drawing.Point(525, 295)
        Me.lblBalance_b.Name = "lblBalance_b"
        Me.lblBalance_b.Size = New System.Drawing.Size(150, 22)
        Me.lblBalance_b.TabIndex = 135
        Me.lblBalance_b.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDelete
        '
        Me.btnDelete.AutoSize = True
        Me.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDelete.Location = New System.Drawing.Point(234, 295)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(48, 23)
        Me.btnDelete.TabIndex = 141
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Visible = False
        '
        'lblTxnType
        '
        Me.lblTxnType.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblTxnType.Location = New System.Drawing.Point(379, 8)
        Me.lblTxnType.Name = "lblTxnType"
        Me.lblTxnType.Size = New System.Drawing.Size(1173, 19)
        Me.lblTxnType.TabIndex = 143
        Me.lblTxnType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblInstrumentDate
        '
        Me.lblInstrumentDate.AutoSize = True
        Me.lblInstrumentDate.Location = New System.Drawing.Point(59, 149)
        Me.lblInstrumentDate.Name = "lblInstrumentDate"
        Me.lblInstrumentDate.Size = New System.Drawing.Size(70, 13)
        Me.lblInstrumentDate.TabIndex = 145
        Me.lblInstrumentDate.Text = "Cheque Date"
        '
        'dtpInstrumentDate
        '
        Me.dtpInstrumentDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpInstrumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInstrumentDate.Location = New System.Drawing.Point(135, 145)
        Me.dtpInstrumentDate.Name = "dtpInstrumentDate"
        Me.dtpInstrumentDate.Size = New System.Drawing.Size(134, 20)
        Me.dtpInstrumentDate.TabIndex = 144
        '
        'cboInstrumentNo
        '
        Me.cboInstrumentNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInstrumentNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboInstrumentNo.FormattingEnabled = True
        Me.cboInstrumentNo.Location = New System.Drawing.Point(351, 143)
        Me.cboInstrumentNo.Name = "cboInstrumentNo"
        Me.cboInstrumentNo.Size = New System.Drawing.Size(157, 21)
        Me.cboInstrumentNo.TabIndex = 161
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(275, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 160
        Me.Label8.Text = "Cheque No"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCopy
        '
        Me.btnCopy.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopy.Location = New System.Drawing.Point(136, 245)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(43, 27)
        Me.btnCopy.TabIndex = 164
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'cboSampleNarration
        '
        Me.cboSampleNarration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSampleNarration.FormattingEnabled = True
        Me.cboSampleNarration.Location = New System.Drawing.Point(189, 248)
        Me.cboSampleNarration.Name = "cboSampleNarration"
        Me.cboSampleNarration.Size = New System.Drawing.Size(1363, 21)
        Me.cboSampleNarration.TabIndex = 163
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "Sample Narration"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmJournalSpecialTxnsCultural
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1564, 881)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.cboSampleNarration)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboInstrumentNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblInstrumentDate)
        Me.Controls.Add(Me.dtpInstrumentDate)
        Me.Controls.Add(Me.lblTxnType)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblCnt_b)
        Me.Controls.Add(Me.lblBalance_b)
        Me.Controls.Add(Me.btnQueryTxn)
        Me.Controls.Add(Me.dgvJournal_b)
        Me.Controls.Add(Me.lblCrBalance)
        Me.Controls.Add(Me.lblDrBalance)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTxnType)
        Me.Controls.Add(Me.txtCreditActDesc)
        Me.Controls.Add(Me.txtDebitActDesc)
        Me.Controls.Add(Me.lblCreditDesc)
        Me.Controls.Add(Me.cboCreditAccount)
        Me.Controls.Add(Me.lblDebitDesc)
        Me.Controls.Add(Me.cboDebitAccount)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtTxnAmount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpTxnDate)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.txtNarration)
        Me.Name = "frmJournalSpecialTxnsCultural"
        Me.Text = "Journal Special Transactions - Cultural"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvJournal_b, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtTxnAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpTxnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtNarration As System.Windows.Forms.TextBox
    Friend WithEvents lblDebitDesc As System.Windows.Forms.Label
    Friend WithEvents cboDebitAccount As System.Windows.Forms.ComboBox
    Friend WithEvents lblCreditDesc As System.Windows.Forms.Label
    Friend WithEvents cboCreditAccount As System.Windows.Forms.ComboBox
    Friend WithEvents txtDebitActDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditActDesc As System.Windows.Forms.TextBox
    Friend WithEvents cboTxnType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDrBalance As System.Windows.Forms.Label
    Friend WithEvents lblCrBalance As System.Windows.Forms.Label
    Friend WithEvents dgvJournal_b As System.Windows.Forms.DataGridView
    Friend WithEvents btnQueryTxn As System.Windows.Forms.Button
    Friend WithEvents lblCnt_b As System.Windows.Forms.Label
    Friend WithEvents lblBalance_b As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents tblid_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gid_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnType_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnDate_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Narration_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocRef_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNo_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DrAmount_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrAmount_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents refgid_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTxnType As System.Windows.Forms.Label
    Friend WithEvents lblInstrumentDate As System.Windows.Forms.Label
    Friend WithEvents dtpInstrumentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboInstrumentNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCopy As Button
    Friend WithEvents cboSampleNarration As ComboBox
    Friend WithEvents Label4 As Label
End Class
