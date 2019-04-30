<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmJournalSpecialTxns
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.txtTaxAmount = New System.Windows.Forms.TextBox()
        Me.lblTaxAmt = New System.Windows.Forms.Label()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.cboSampleNarration = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDeprecPerc = New System.Windows.Forms.TextBox()
        Me.lblDeprecPerc = New System.Windows.Forms.Label()
        Me.btnCalcDeprecAmt = New System.Windows.Forms.Button()
        Me.txtOpBalFAVal = New System.Windows.Forms.TextBox()
        Me.lblOpBalFAVal = New System.Windows.Forms.Label()
        Me.txtCurYrFAVal = New System.Windows.Forms.TextBox()
        Me.lblCurYrFAVal = New System.Windows.Forms.Label()
        Me.txtTotFAVal = New System.Windows.Forms.TextBox()
        Me.lblTolFAVal = New System.Windows.Forms.Label()
        Me.btnLoadTDActInCrCombo = New System.Windows.Forms.Button()
        Me.btnLoadTDActInDrCombo = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboPaymentMode = New System.Windows.Forms.ComboBox()
        Me.cboInstrumentNo = New System.Windows.Forms.ComboBox()
        Me.lblInstrumentDate = New System.Windows.Forms.Label()
        Me.dtpInstrumentDate = New System.Windows.Forms.DateTimePicker()
        Me.lblInstrumentNo = New System.Windows.Forms.Label()
        Me.cboBankName = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.panelPaymentMode = New System.Windows.Forms.Panel()
        CType(Me.dgvJournal_b, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelPaymentMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSave.Location = New System.Drawing.Point(28, 273)
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
        Me.btnCancel.Location = New System.Drawing.Point(84, 273)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(43, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtTxnAmount
        '
        Me.txtTxnAmount.Location = New System.Drawing.Point(368, 40)
        Me.txtTxnAmount.MaxLength = 12
        Me.txtTxnAmount.Name = "txtTxnAmount"
        Me.txtTxnAmount.Size = New System.Drawing.Size(157, 20)
        Me.txtTxnAmount.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(301, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Amount"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 41)
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
        Me.dtpTxnDate.Location = New System.Drawing.Point(136, 38)
        Me.dtpTxnDate.Name = "dtpTxnDate"
        Me.dtpTxnDate.Size = New System.Drawing.Size(149, 20)
        Me.dtpTxnDate.TabIndex = 2
        '
        'lblRemarks
        '
        Me.lblRemarks.Location = New System.Drawing.Point(8, 200)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(122, 20)
        Me.lblRemarks.TabIndex = 90
        Me.lblRemarks.Text = "Narration"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNarration
        '
        Me.txtNarration.Location = New System.Drawing.Point(136, 180)
        Me.txtNarration.MaxLength = 5000
        Me.txtNarration.Multiline = True
        Me.txtNarration.Name = "txtNarration"
        Me.txtNarration.Size = New System.Drawing.Size(1424, 50)
        Me.txtNarration.TabIndex = 8
        Me.txtNarration.TabStop = False
        '
        'lblDebitDesc
        '
        Me.lblDebitDesc.Location = New System.Drawing.Point(6, 149)
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
        Me.cboDebitAccount.Location = New System.Drawing.Point(136, 149)
        Me.cboDebitAccount.Name = "cboDebitAccount"
        Me.cboDebitAccount.Size = New System.Drawing.Size(287, 21)
        Me.cboDebitAccount.TabIndex = 6
        '
        'lblCreditDesc
        '
        Me.lblCreditDesc.Location = New System.Drawing.Point(6, 123)
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
        Me.cboCreditAccount.Location = New System.Drawing.Point(136, 120)
        Me.cboCreditAccount.Name = "cboCreditAccount"
        Me.cboCreditAccount.Size = New System.Drawing.Size(287, 21)
        Me.cboCreditAccount.TabIndex = 7
        '
        'txtDebitActDesc
        '
        Me.txtDebitActDesc.Location = New System.Drawing.Point(765, 149)
        Me.txtDebitActDesc.MaxLength = 12
        Me.txtDebitActDesc.Multiline = True
        Me.txtDebitActDesc.Name = "txtDebitActDesc"
        Me.txtDebitActDesc.ReadOnly = True
        Me.txtDebitActDesc.Size = New System.Drawing.Size(795, 24)
        Me.txtDebitActDesc.TabIndex = 111
        '
        'txtCreditActDesc
        '
        Me.txtCreditActDesc.Location = New System.Drawing.Point(765, 120)
        Me.txtCreditActDesc.MaxLength = 12
        Me.txtCreditActDesc.Multiline = True
        Me.txtCreditActDesc.Name = "txtCreditActDesc"
        Me.txtCreditActDesc.ReadOnly = True
        Me.txtCreditActDesc.Size = New System.Drawing.Size(795, 22)
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
        Me.lblDrBalance.Location = New System.Drawing.Point(429, 152)
        Me.lblDrBalance.Name = "lblDrBalance"
        Me.lblDrBalance.Size = New System.Drawing.Size(117, 19)
        Me.lblDrBalance.TabIndex = 121
        Me.lblDrBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCrBalance
        '
        Me.lblCrBalance.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblCrBalance.Location = New System.Drawing.Point(429, 123)
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
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournal_b.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvJournal_b.Location = New System.Drawing.Point(12, 306)
        Me.dgvJournal_b.Name = "dgvJournal_b"
        Me.dgvJournal_b.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvJournal_b.RowHeadersVisible = False
        Me.dgvJournal_b.RowTemplate.Height = 24
        Me.dgvJournal_b.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvJournal_b.Size = New System.Drawing.Size(1548, 543)
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
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "D"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.TxnDate_b.DefaultCellStyle = DataGridViewCellStyle7
        Me.TxnDate_b.HeaderText = "TxnDate"
        Me.TxnDate_b.MaxInputLength = 11
        Me.TxnDate_b.Name = "TxnDate_b"
        Me.TxnDate_b.ReadOnly = True
        '
        'Narration_b
        '
        Me.Narration_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Narration_b.DefaultCellStyle = DataGridViewCellStyle8
        Me.Narration_b.HeaderText = "Narration"
        Me.Narration_b.MaxInputLength = 255
        Me.Narration_b.MinimumWidth = 10
        Me.Narration_b.Name = "Narration_b"
        Me.Narration_b.ReadOnly = True
        Me.Narration_b.Width = 500
        '
        'DocRef_b
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DocRef_b.DefaultCellStyle = DataGridViewCellStyle9
        Me.DocRef_b.HeaderText = "DocRef"
        Me.DocRef_b.MinimumWidth = 100
        Me.DocRef_b.Name = "DocRef_b"
        Me.DocRef_b.Width = 250
        '
        'AccountNo_b
        '
        Me.AccountNo_b.HeaderText = "AccountNo"
        Me.AccountNo_b.Name = "AccountNo_b"
        Me.AccountNo_b.Width = 250
        '
        'DrAmount_b
        '
        Me.DrAmount_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DrAmount_b.DefaultCellStyle = DataGridViewCellStyle10
        Me.DrAmount_b.HeaderText = "DrAmount"
        Me.DrAmount_b.MaxInputLength = 13
        Me.DrAmount_b.Name = "DrAmount_b"
        '
        'CrAmount_b
        '
        Me.CrAmount_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CrAmount_b.DefaultCellStyle = DataGridViewCellStyle11
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
        Me.btnQueryTxn.Location = New System.Drawing.Point(143, 273)
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
        Me.lblCnt_b.Location = New System.Drawing.Point(421, 271)
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
        Me.lblBalance_b.Location = New System.Drawing.Point(525, 271)
        Me.lblBalance_b.Name = "lblBalance_b"
        Me.lblBalance_b.Size = New System.Drawing.Size(150, 22)
        Me.lblBalance_b.TabIndex = 135
        Me.lblBalance_b.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDelete
        '
        Me.btnDelete.AutoSize = True
        Me.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDelete.Location = New System.Drawing.Point(234, 273)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(48, 23)
        Me.btnDelete.TabIndex = 141
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblTxnType
        '
        Me.lblTxnType.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblTxnType.Location = New System.Drawing.Point(379, 8)
        Me.lblTxnType.Name = "lblTxnType"
        Me.lblTxnType.Size = New System.Drawing.Size(1181, 19)
        Me.lblTxnType.TabIndex = 143
        Me.lblTxnType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTaxAmount
        '
        Me.txtTaxAmount.Location = New System.Drawing.Point(642, 39)
        Me.txtTaxAmount.MaxLength = 12
        Me.txtTaxAmount.Name = "txtTaxAmount"
        Me.txtTaxAmount.Size = New System.Drawing.Size(95, 20)
        Me.txtTaxAmount.TabIndex = 144
        '
        'lblTaxAmt
        '
        Me.lblTaxAmt.AutoSize = True
        Me.lblTaxAmt.Location = New System.Drawing.Point(556, 43)
        Me.lblTaxAmt.Name = "lblTaxAmt"
        Me.lblTaxAmt.Size = New System.Drawing.Size(64, 13)
        Me.lblTaxAmt.TabIndex = 145
        Me.lblTaxAmt.Text = "Tax Amount"
        Me.lblTaxAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCopy
        '
        Me.btnCopy.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopy.Location = New System.Drawing.Point(135, 236)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(43, 27)
        Me.btnCopy.TabIndex = 148
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'cboSampleNarration
        '
        Me.cboSampleNarration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSampleNarration.FormattingEnabled = True
        Me.cboSampleNarration.Location = New System.Drawing.Point(185, 239)
        Me.cboSampleNarration.Name = "cboSampleNarration"
        Me.cboSampleNarration.Size = New System.Drawing.Size(1363, 21)
        Me.cboSampleNarration.TabIndex = 147
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 146
        Me.Label4.Text = "Sample Narration"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDeprecPerc
        '
        Me.txtDeprecPerc.Location = New System.Drawing.Point(1336, 37)
        Me.txtDeprecPerc.MaxLength = 12
        Me.txtDeprecPerc.Name = "txtDeprecPerc"
        Me.txtDeprecPerc.Size = New System.Drawing.Size(53, 20)
        Me.txtDeprecPerc.TabIndex = 149
        '
        'lblDeprecPerc
        '
        Me.lblDeprecPerc.AutoSize = True
        Me.lblDeprecPerc.Location = New System.Drawing.Point(1226, 40)
        Me.lblDeprecPerc.Name = "lblDeprecPerc"
        Me.lblDeprecPerc.Size = New System.Drawing.Size(78, 13)
        Me.lblDeprecPerc.TabIndex = 150
        Me.lblDeprecPerc.Text = "Depreciation %"
        Me.lblDeprecPerc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCalcDeprecAmt
        '
        Me.btnCalcDeprecAmt.AutoSize = True
        Me.btnCalcDeprecAmt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCalcDeprecAmt.Location = New System.Drawing.Point(1395, 35)
        Me.btnCalcDeprecAmt.Name = "btnCalcDeprecAmt"
        Me.btnCalcDeprecAmt.Size = New System.Drawing.Size(124, 23)
        Me.btnCalcDeprecAmt.TabIndex = 151
        Me.btnCalcDeprecAmt.Text = "Calculate Depreciation"
        Me.btnCalcDeprecAmt.UseVisualStyleBackColor = True
        '
        'txtOpBalFAVal
        '
        Me.txtOpBalFAVal.Location = New System.Drawing.Point(806, 39)
        Me.txtOpBalFAVal.MaxLength = 12
        Me.txtOpBalFAVal.Name = "txtOpBalFAVal"
        Me.txtOpBalFAVal.Size = New System.Drawing.Size(95, 20)
        Me.txtOpBalFAVal.TabIndex = 152
        '
        'lblOpBalFAVal
        '
        Me.lblOpBalFAVal.AutoSize = True
        Me.lblOpBalFAVal.Location = New System.Drawing.Point(749, 42)
        Me.lblOpBalFAVal.Name = "lblOpBalFAVal"
        Me.lblOpBalFAVal.Size = New System.Drawing.Size(39, 13)
        Me.lblOpBalFAVal.TabIndex = 153
        Me.lblOpBalFAVal.Text = "Op Bal"
        Me.lblOpBalFAVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCurYrFAVal
        '
        Me.txtCurYrFAVal.Location = New System.Drawing.Point(963, 39)
        Me.txtCurYrFAVal.MaxLength = 12
        Me.txtCurYrFAVal.Name = "txtCurYrFAVal"
        Me.txtCurYrFAVal.Size = New System.Drawing.Size(95, 20)
        Me.txtCurYrFAVal.TabIndex = 154
        '
        'lblCurYrFAVal
        '
        Me.lblCurYrFAVal.AutoSize = True
        Me.lblCurYrFAVal.Location = New System.Drawing.Point(904, 42)
        Me.lblCurYrFAVal.Name = "lblCurYrFAVal"
        Me.lblCurYrFAVal.Size = New System.Drawing.Size(40, 13)
        Me.lblCurYrFAVal.TabIndex = 155
        Me.lblCurYrFAVal.Text = "This Yr"
        Me.lblCurYrFAVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotFAVal
        '
        Me.txtTotFAVal.Location = New System.Drawing.Point(1111, 37)
        Me.txtTotFAVal.MaxLength = 12
        Me.txtTotFAVal.Name = "txtTotFAVal"
        Me.txtTotFAVal.Size = New System.Drawing.Size(95, 20)
        Me.txtTotFAVal.TabIndex = 156
        '
        'lblTolFAVal
        '
        Me.lblTolFAVal.AutoSize = True
        Me.lblTolFAVal.Location = New System.Drawing.Point(1066, 40)
        Me.lblTolFAVal.Name = "lblTolFAVal"
        Me.lblTolFAVal.Size = New System.Drawing.Size(31, 13)
        Me.lblTolFAVal.TabIndex = 157
        Me.lblTolFAVal.Text = "Total"
        Me.lblTolFAVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnLoadTDActInCrCombo
        '
        Me.btnLoadTDActInCrCombo.Location = New System.Drawing.Point(556, 124)
        Me.btnLoadTDActInCrCombo.Name = "btnLoadTDActInCrCombo"
        Me.btnLoadTDActInCrCombo.Size = New System.Drawing.Size(134, 25)
        Me.btnLoadTDActInCrCombo.TabIndex = 158
        Me.btnLoadTDActInCrCombo.Text = "Load TD In Cr Combo"
        Me.btnLoadTDActInCrCombo.UseVisualStyleBackColor = True
        '
        'btnLoadTDActInDrCombo
        '
        Me.btnLoadTDActInDrCombo.Location = New System.Drawing.Point(556, 149)
        Me.btnLoadTDActInDrCombo.Name = "btnLoadTDActInDrCombo"
        Me.btnLoadTDActInDrCombo.Size = New System.Drawing.Size(134, 25)
        Me.btnLoadTDActInDrCombo.TabIndex = 159
        Me.btnLoadTDActInDrCombo.Text = "Load TD In Dr Combo"
        Me.btnLoadTDActInDrCombo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 161
        Me.Label3.Text = "Payment Mode"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPaymentMode
        '
        Me.cboPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboPaymentMode.FormattingEnabled = True
        Me.cboPaymentMode.Items.AddRange(New Object() {"CASH", "CHEQUE", "ONLINE"})
        Me.cboPaymentMode.Location = New System.Drawing.Point(101, 16)
        Me.cboPaymentMode.Name = "cboPaymentMode"
        Me.cboPaymentMode.Size = New System.Drawing.Size(99, 21)
        Me.cboPaymentMode.TabIndex = 160
        '
        'cboInstrumentNo
        '
        Me.cboInstrumentNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInstrumentNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboInstrumentNo.FormattingEnabled = True
        Me.cboInstrumentNo.Location = New System.Drawing.Point(334, 17)
        Me.cboInstrumentNo.Name = "cboInstrumentNo"
        Me.cboInstrumentNo.Size = New System.Drawing.Size(161, 21)
        Me.cboInstrumentNo.TabIndex = 165
        '
        'lblInstrumentDate
        '
        Me.lblInstrumentDate.Location = New System.Drawing.Point(497, 20)
        Me.lblInstrumentDate.Name = "lblInstrumentDate"
        Me.lblInstrumentDate.Size = New System.Drawing.Size(101, 17)
        Me.lblInstrumentDate.TabIndex = 164
        Me.lblInstrumentDate.Text = "Instrument Date"
        Me.lblInstrumentDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpInstrumentDate
        '
        Me.dtpInstrumentDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpInstrumentDate.Enabled = False
        Me.dtpInstrumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInstrumentDate.Location = New System.Drawing.Point(608, 17)
        Me.dtpInstrumentDate.Name = "dtpInstrumentDate"
        Me.dtpInstrumentDate.Size = New System.Drawing.Size(114, 20)
        Me.dtpInstrumentDate.TabIndex = 162
        '
        'lblInstrumentNo
        '
        Me.lblInstrumentNo.Location = New System.Drawing.Point(223, 22)
        Me.lblInstrumentNo.Name = "lblInstrumentNo"
        Me.lblInstrumentNo.Size = New System.Drawing.Size(107, 16)
        Me.lblInstrumentNo.TabIndex = 163
        Me.lblInstrumentNo.Text = "Instrument No"
        Me.lblInstrumentNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboBankName
        '
        Me.cboBankName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboBankName.FormattingEnabled = True
        Me.cboBankName.Location = New System.Drawing.Point(854, 19)
        Me.cboBankName.Name = "cboBankName"
        Me.cboBankName.Size = New System.Drawing.Size(162, 21)
        Me.cboBankName.TabIndex = 167
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(768, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 17)
        Me.Label6.TabIndex = 166
        Me.Label6.Text = "Bank Name"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelPaymentMode
        '
        Me.panelPaymentMode.Controls.Add(Me.cboInstrumentNo)
        Me.panelPaymentMode.Controls.Add(Me.cboBankName)
        Me.panelPaymentMode.Controls.Add(Me.cboPaymentMode)
        Me.panelPaymentMode.Controls.Add(Me.Label6)
        Me.panelPaymentMode.Controls.Add(Me.Label3)
        Me.panelPaymentMode.Controls.Add(Me.lblInstrumentNo)
        Me.panelPaymentMode.Controls.Add(Me.lblInstrumentDate)
        Me.panelPaymentMode.Controls.Add(Me.dtpInstrumentDate)
        Me.panelPaymentMode.Location = New System.Drawing.Point(12, 64)
        Me.panelPaymentMode.Name = "panelPaymentMode"
        Me.panelPaymentMode.Size = New System.Drawing.Size(1049, 50)
        Me.panelPaymentMode.TabIndex = 168
        '
        'frmJournalSpecialTxns
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1564, 881)
        Me.Controls.Add(Me.panelPaymentMode)
        Me.Controls.Add(Me.btnLoadTDActInDrCombo)
        Me.Controls.Add(Me.btnLoadTDActInCrCombo)
        Me.Controls.Add(Me.txtTotFAVal)
        Me.Controls.Add(Me.lblTolFAVal)
        Me.Controls.Add(Me.txtCurYrFAVal)
        Me.Controls.Add(Me.lblCurYrFAVal)
        Me.Controls.Add(Me.txtOpBalFAVal)
        Me.Controls.Add(Me.lblOpBalFAVal)
        Me.Controls.Add(Me.btnCalcDeprecAmt)
        Me.Controls.Add(Me.txtDeprecPerc)
        Me.Controls.Add(Me.lblDeprecPerc)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.cboSampleNarration)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTaxAmount)
        Me.Controls.Add(Me.lblTaxAmt)
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
        Me.Name = "frmJournalSpecialTxns"
        Me.Text = "Journal Special Transactions"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvJournal_b, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelPaymentMode.ResumeLayout(False)
        Me.panelPaymentMode.PerformLayout()
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
    Friend WithEvents lblTxnType As System.Windows.Forms.Label
    Friend WithEvents txtTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxAmt As System.Windows.Forms.Label
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
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents cboSampleNarration As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDeprecPerc As System.Windows.Forms.TextBox
    Friend WithEvents lblDeprecPerc As System.Windows.Forms.Label
    Friend WithEvents btnCalcDeprecAmt As System.Windows.Forms.Button
    Friend WithEvents txtOpBalFAVal As System.Windows.Forms.TextBox
    Friend WithEvents lblOpBalFAVal As System.Windows.Forms.Label
    Friend WithEvents txtCurYrFAVal As System.Windows.Forms.TextBox
    Friend WithEvents lblCurYrFAVal As System.Windows.Forms.Label
    Friend WithEvents txtTotFAVal As System.Windows.Forms.TextBox
    Friend WithEvents lblTolFAVal As System.Windows.Forms.Label
    Friend WithEvents btnLoadTDActInCrCombo As Button
    Friend WithEvents btnLoadTDActInDrCombo As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cboPaymentMode As ComboBox
    Friend WithEvents cboInstrumentNo As ComboBox
    Friend WithEvents lblInstrumentDate As Label
    Friend WithEvents dtpInstrumentDate As DateTimePicker
    Friend WithEvents lblInstrumentNo As Label
    Friend WithEvents cboBankName As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents panelPaymentMode As Panel
End Class
