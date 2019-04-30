<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManagePayment
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtPaymentAmount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpPaymentDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNarration = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboExpenseType = New System.Windows.Forms.ComboBox()
        Me.lblInstrumentDate = New System.Windows.Forms.Label()
        Me.dtpInstrumentDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblInstrumentNo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboPaymentMode = New System.Windows.Forms.ComboBox()
        Me.lblDebitDesc = New System.Windows.Forms.Label()
        Me.cboDebitAccount = New System.Windows.Forms.ComboBox()
        Me.lblCreditDesc = New System.Windows.Forms.Label()
        Me.cboCreditAccount = New System.Windows.Forms.ComboBox()
        Me.grpExpenseSubType = New System.Windows.Forms.GroupBox()
        Me.optCapExp = New System.Windows.Forms.RadioButton()
        Me.optCurExp = New System.Windows.Forms.RadioButton()
        Me.txtDebitActDesc = New System.Windows.Forms.TextBox()
        Me.txtCreditActDesc = New System.Windows.Forms.TextBox()
        Me.cboBankName = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnShowChequeDetails = New System.Windows.Forms.Button()
        Me.cboChequeNo = New System.Windows.Forms.ComboBox()
        Me.btnAddNewAccount = New System.Windows.Forms.Button()
        Me.lblCrBalance = New System.Windows.Forms.Label()
        Me.lblDrBalance = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboSampleNarration = New System.Windows.Forms.ComboBox()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.lblCnt_b = New System.Windows.Forms.Label()
        Me.lblBalance_b = New System.Windows.Forms.Label()
        Me.btnQueryExpense = New System.Windows.Forms.Button()
        Me.dgvJournal_b = New System.Windows.Forms.DataGridView()
        Me.tblid_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gid_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnType_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnDate_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Narration_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocRef_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrAccountNo_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CrAccountNo_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrAmount_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CrAmount_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VoucherNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupervisorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApprovedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApprovedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.cboInstrumentNo = New System.Windows.Forms.ComboBox()
        Me.grpExpenseType = New System.Windows.Forms.GroupBox()
        Me.optDeferredPayment = New System.Windows.Forms.RadioButton()
        Me.optProvision = New System.Windows.Forms.RadioButton()
        Me.optAdjustPrepaid = New System.Windows.Forms.RadioButton()
        Me.optPrepaid = New System.Windows.Forms.RadioButton()
        Me.optFixedAsset = New System.Windows.Forms.RadioButton()
        Me.optNormalExpense = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnChangeDebitSide = New System.Windows.Forms.Button()
        Me.btnUpdateDebitSide = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnUpdateVoucherNo = New System.Windows.Forms.Button()
        Me.cboVoucherNo = New System.Windows.Forms.ComboBox()
        Me.lblGID = New System.Windows.Forms.Label()
        Me.btnEnableVoucherNoUpdate = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.lblApprovedBy = New System.Windows.Forms.Label()
        Me.lblApprovedDate = New System.Windows.Forms.Label()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.btnShowAllPending = New System.Windows.Forms.Button()
        Me.cboApprovers = New System.Windows.Forms.ComboBox()
        Me.btnEmailApprover = New System.Windows.Forms.Button()
        Me.btnShowMoreInGrid = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnUpdatePayment = New System.Windows.Forms.Button()
        Me.btnShowPendingWithMe = New System.Windows.Forms.Button()
        Me.grpExpenseSubType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvJournal_b, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpExpenseType.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSave.Location = New System.Drawing.Point(7, 310)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(42, 23)
        Me.btnSave.TabIndex = 95
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCancel.Location = New System.Drawing.Point(214, 310)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(43, 23)
        Me.btnCancel.TabIndex = 94
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtPaymentAmount
        '
        Me.txtPaymentAmount.Location = New System.Drawing.Point(996, 58)
        Me.txtPaymentAmount.MaxLength = 12
        Me.txtPaymentAmount.Name = "txtPaymentAmount"
        Me.txtPaymentAmount.Size = New System.Drawing.Size(146, 20)
        Me.txtPaymentAmount.TabIndex = 92
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(889, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 13)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Payment Amount"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(46, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "Payment Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpPaymentDate
        '
        Me.dtpPaymentDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPaymentDate.Location = New System.Drawing.Point(126, 57)
        Me.dtpPaymentDate.Name = "dtpPaymentDate"
        Me.dtpPaymentDate.ShowUpDown = True
        Me.dtpPaymentDate.Size = New System.Drawing.Size(106, 20)
        Me.dtpPaymentDate.TabIndex = 88
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(70, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Narration"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNarration
        '
        Me.txtNarration.Location = New System.Drawing.Point(126, 204)
        Me.txtNarration.MaxLength = 5000
        Me.txtNarration.Multiline = True
        Me.txtNarration.Name = "txtNarration"
        Me.txtNarration.Size = New System.Drawing.Size(1435, 39)
        Me.txtNarration.TabIndex = 89
        Me.txtNarration.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(266, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboExpenseType
        '
        Me.cboExpenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExpenseType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboExpenseType.FormattingEnabled = True
        Me.cboExpenseType.Location = New System.Drawing.Point(297, 56)
        Me.cboExpenseType.Name = "cboExpenseType"
        Me.cboExpenseType.Size = New System.Drawing.Size(157, 21)
        Me.cboExpenseType.TabIndex = 96
        '
        'lblInstrumentDate
        '
        Me.lblInstrumentDate.Location = New System.Drawing.Point(287, 178)
        Me.lblInstrumentDate.Name = "lblInstrumentDate"
        Me.lblInstrumentDate.Size = New System.Drawing.Size(108, 17)
        Me.lblInstrumentDate.TabIndex = 105
        Me.lblInstrumentDate.Text = "Instrument Date"
        Me.lblInstrumentDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpInstrumentDate
        '
        Me.dtpInstrumentDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpInstrumentDate.Enabled = False
        Me.dtpInstrumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInstrumentDate.Location = New System.Drawing.Point(399, 175)
        Me.dtpInstrumentDate.Name = "dtpInstrumentDate"
        Me.dtpInstrumentDate.Size = New System.Drawing.Size(114, 20)
        Me.dtpInstrumentDate.TabIndex = 101
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(520, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 17)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "Bank Name"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblInstrumentNo
        '
        Me.lblInstrumentNo.Location = New System.Drawing.Point(12, 180)
        Me.lblInstrumentNo.Name = "lblInstrumentNo"
        Me.lblInstrumentNo.Size = New System.Drawing.Size(107, 16)
        Me.lblInstrumentNo.TabIndex = 103
        Me.lblInstrumentNo.Text = "Instrument No"
        Me.lblInstrumentNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(463, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Payment Mode"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPaymentMode
        '
        Me.cboPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentMode.Enabled = False
        Me.cboPaymentMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboPaymentMode.FormattingEnabled = True
        Me.cboPaymentMode.Items.AddRange(New Object() {"CASH", "CHEQUE", "ONLINE"})
        Me.cboPaymentMode.Location = New System.Drawing.Point(547, 57)
        Me.cboPaymentMode.Name = "cboPaymentMode"
        Me.cboPaymentMode.Size = New System.Drawing.Size(133, 21)
        Me.cboPaymentMode.TabIndex = 98
        '
        'lblDebitDesc
        '
        Me.lblDebitDesc.Location = New System.Drawing.Point(4, 93)
        Me.lblDebitDesc.Name = "lblDebitDesc"
        Me.lblDebitDesc.Size = New System.Drawing.Size(115, 21)
        Me.lblDebitDesc.TabIndex = 107
        Me.lblDebitDesc.Text = "Debit"
        Me.lblDebitDesc.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboDebitAccount
        '
        Me.cboDebitAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDebitAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboDebitAccount.FormattingEnabled = True
        Me.cboDebitAccount.Location = New System.Drawing.Point(124, 93)
        Me.cboDebitAccount.Name = "cboDebitAccount"
        Me.cboDebitAccount.Size = New System.Drawing.Size(328, 21)
        Me.cboDebitAccount.TabIndex = 106
        '
        'lblCreditDesc
        '
        Me.lblCreditDesc.Location = New System.Drawing.Point(41, 125)
        Me.lblCreditDesc.Name = "lblCreditDesc"
        Me.lblCreditDesc.Size = New System.Drawing.Size(77, 20)
        Me.lblCreditDesc.TabIndex = 109
        Me.lblCreditDesc.Text = "Credit"
        Me.lblCreditDesc.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboCreditAccount
        '
        Me.cboCreditAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCreditAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboCreditAccount.FormattingEnabled = True
        Me.cboCreditAccount.Location = New System.Drawing.Point(124, 122)
        Me.cboCreditAccount.Name = "cboCreditAccount"
        Me.cboCreditAccount.Size = New System.Drawing.Size(328, 21)
        Me.cboCreditAccount.TabIndex = 108
        '
        'grpExpenseSubType
        '
        Me.grpExpenseSubType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpExpenseSubType.Controls.Add(Me.optCapExp)
        Me.grpExpenseSubType.Controls.Add(Me.optCurExp)
        Me.grpExpenseSubType.Location = New System.Drawing.Point(1448, -2)
        Me.grpExpenseSubType.Name = "grpExpenseSubType"
        Me.grpExpenseSubType.Size = New System.Drawing.Size(101, 89)
        Me.grpExpenseSubType.TabIndex = 110
        Me.grpExpenseSubType.TabStop = False
        Me.grpExpenseSubType.Visible = False
        '
        'optCapExp
        '
        Me.optCapExp.AutoSize = True
        Me.optCapExp.Location = New System.Drawing.Point(11, 57)
        Me.optCapExp.Name = "optCapExp"
        Me.optCapExp.Size = New System.Drawing.Size(101, 17)
        Me.optCapExp.TabIndex = 1
        Me.optCapExp.Text = "Capital Expense"
        Me.optCapExp.UseVisualStyleBackColor = True
        '
        'optCurExp
        '
        Me.optCurExp.AutoSize = True
        Me.optCurExp.Checked = True
        Me.optCurExp.Location = New System.Drawing.Point(9, 21)
        Me.optCurExp.Name = "optCurExp"
        Me.optCurExp.Size = New System.Drawing.Size(103, 17)
        Me.optCurExp.TabIndex = 0
        Me.optCurExp.TabStop = True
        Me.optCurExp.Text = "Current Expense"
        Me.optCurExp.UseVisualStyleBackColor = True
        '
        'txtDebitActDesc
        '
        Me.txtDebitActDesc.Location = New System.Drawing.Point(582, 90)
        Me.txtDebitActDesc.MaxLength = 12
        Me.txtDebitActDesc.Multiline = True
        Me.txtDebitActDesc.Name = "txtDebitActDesc"
        Me.txtDebitActDesc.ReadOnly = True
        Me.txtDebitActDesc.Size = New System.Drawing.Size(979, 22)
        Me.txtDebitActDesc.TabIndex = 111
        '
        'txtCreditActDesc
        '
        Me.txtCreditActDesc.Location = New System.Drawing.Point(582, 125)
        Me.txtCreditActDesc.MaxLength = 12
        Me.txtCreditActDesc.Multiline = True
        Me.txtCreditActDesc.Name = "txtCreditActDesc"
        Me.txtCreditActDesc.ReadOnly = True
        Me.txtCreditActDesc.Size = New System.Drawing.Size(979, 20)
        Me.txtCreditActDesc.TabIndex = 112
        '
        'cboBankName
        '
        Me.cboBankName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboBankName.FormattingEnabled = True
        Me.cboBankName.Location = New System.Drawing.Point(606, 177)
        Me.cboBankName.Name = "cboBankName"
        Me.cboBankName.Size = New System.Drawing.Size(162, 21)
        Me.cboBankName.TabIndex = 113
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnShowChequeDetails)
        Me.GroupBox1.Controls.Add(Me.cboChequeNo)
        Me.GroupBox1.Location = New System.Drawing.Point(1237, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(205, 63)
        Me.GroupBox1.TabIndex = 119
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
        'btnAddNewAccount
        '
        Me.btnAddNewAccount.AutoSize = True
        Me.btnAddNewAccount.Location = New System.Drawing.Point(1031, 308)
        Me.btnAddNewAccount.Name = "btnAddNewAccount"
        Me.btnAddNewAccount.Size = New System.Drawing.Size(129, 27)
        Me.btnAddNewAccount.TabIndex = 120
        Me.btnAddNewAccount.Text = "Add New Account"
        Me.btnAddNewAccount.UseVisualStyleBackColor = True
        '
        'lblCrBalance
        '
        Me.lblCrBalance.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblCrBalance.Location = New System.Drawing.Point(459, 125)
        Me.lblCrBalance.Name = "lblCrBalance"
        Me.lblCrBalance.Size = New System.Drawing.Size(117, 19)
        Me.lblCrBalance.TabIndex = 124
        Me.lblCrBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDrBalance
        '
        Me.lblDrBalance.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblDrBalance.Location = New System.Drawing.Point(459, 93)
        Me.lblDrBalance.Name = "lblDrBalance"
        Me.lblDrBalance.Size = New System.Drawing.Size(117, 19)
        Me.lblDrBalance.TabIndex = 123
        Me.lblDrBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Sample Narration"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSampleNarration
        '
        Me.cboSampleNarration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSampleNarration.FormattingEnabled = True
        Me.cboSampleNarration.Location = New System.Drawing.Point(173, 249)
        Me.cboSampleNarration.Name = "cboSampleNarration"
        Me.cboSampleNarration.Size = New System.Drawing.Size(1388, 21)
        Me.cboSampleNarration.TabIndex = 127
        '
        'btnCopy
        '
        Me.btnCopy.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopy.Location = New System.Drawing.Point(124, 246)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(43, 27)
        Me.btnCopy.TabIndex = 128
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'lblCnt_b
        '
        Me.lblCnt_b.BackColor = System.Drawing.Color.Black
        Me.lblCnt_b.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCnt_b.ForeColor = System.Drawing.Color.White
        Me.lblCnt_b.Location = New System.Drawing.Point(750, 313)
        Me.lblCnt_b.Name = "lblCnt_b"
        Me.lblCnt_b.Size = New System.Drawing.Size(100, 22)
        Me.lblCnt_b.TabIndex = 140
        Me.lblCnt_b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBalance_b
        '
        Me.lblBalance_b.BackColor = System.Drawing.Color.Black
        Me.lblBalance_b.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalance_b.ForeColor = System.Drawing.Color.White
        Me.lblBalance_b.Location = New System.Drawing.Point(854, 313)
        Me.lblBalance_b.Name = "lblBalance_b"
        Me.lblBalance_b.Size = New System.Drawing.Size(150, 22)
        Me.lblBalance_b.TabIndex = 139
        Me.lblBalance_b.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnQueryExpense
        '
        Me.btnQueryExpense.AutoSize = True
        Me.btnQueryExpense.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQueryExpense.Location = New System.Drawing.Point(114, 310)
        Me.btnQueryExpense.Name = "btnQueryExpense"
        Me.btnQueryExpense.Size = New System.Drawing.Size(45, 23)
        Me.btnQueryExpense.TabIndex = 138
        Me.btnQueryExpense.Text = "Query"
        Me.btnQueryExpense.UseVisualStyleBackColor = True
        '
        'dgvJournal_b
        '
        Me.dgvJournal_b.AllowUserToAddRows = False
        Me.dgvJournal_b.AllowUserToDeleteRows = False
        Me.dgvJournal_b.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvJournal_b.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvJournal_b.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvJournal_b.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tblid_b, Me.gid_b, Me.TxnType_b, Me.TxnDate_b, Me.Narration_b, Me.DocRef_b, Me.DrAccountNo_b, Me.CrAccountNo_b, Me.DrAmount_b, Me.CrAmount_b, Me.VoucherNo, Me.Status, Me.SupervisorName, Me.ApprovedBy, Me.ApprovedDate})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournal_b.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvJournal_b.Location = New System.Drawing.Point(5, 341)
        Me.dgvJournal_b.Name = "dgvJournal_b"
        Me.dgvJournal_b.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvJournal_b.RowHeadersVisible = False
        Me.dgvJournal_b.RowTemplate.Height = 24
        Me.dgvJournal_b.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvJournal_b.Size = New System.Drawing.Size(1556, 600)
        Me.dgvJournal_b.TabIndex = 137
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Format = "D"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.TxnDate_b.DefaultCellStyle = DataGridViewCellStyle9
        Me.TxnDate_b.HeaderText = "TxnDate"
        Me.TxnDate_b.MaxInputLength = 11
        Me.TxnDate_b.Name = "TxnDate_b"
        Me.TxnDate_b.ReadOnly = True
        '
        'Narration_b
        '
        Me.Narration_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Narration_b.DefaultCellStyle = DataGridViewCellStyle10
        Me.Narration_b.HeaderText = "Narration"
        Me.Narration_b.MaxInputLength = 255
        Me.Narration_b.MinimumWidth = 10
        Me.Narration_b.Name = "Narration_b"
        Me.Narration_b.ReadOnly = True
        Me.Narration_b.Width = 300
        '
        'DocRef_b
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DocRef_b.DefaultCellStyle = DataGridViewCellStyle11
        Me.DocRef_b.HeaderText = "DocRef"
        Me.DocRef_b.MinimumWidth = 100
        Me.DocRef_b.Name = "DocRef_b"
        Me.DocRef_b.Width = 300
        '
        'DrAccountNo_b
        '
        Me.DrAccountNo_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DrAccountNo_b.DefaultCellStyle = DataGridViewCellStyle12
        Me.DrAccountNo_b.HeaderText = "DrAccountNo"
        Me.DrAccountNo_b.MaxInputLength = 255
        Me.DrAccountNo_b.Name = "DrAccountNo_b"
        Me.DrAccountNo_b.Width = 200
        '
        'CrAccountNo_b
        '
        Me.CrAccountNo_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CrAccountNo_b.DefaultCellStyle = DataGridViewCellStyle13
        Me.CrAccountNo_b.HeaderText = "CrAccountNo"
        Me.CrAccountNo_b.MaxInputLength = 255
        Me.CrAccountNo_b.Name = "CrAccountNo_b"
        Me.CrAccountNo_b.Width = 200
        '
        'DrAmount_b
        '
        Me.DrAmount_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DrAmount_b.DefaultCellStyle = DataGridViewCellStyle14
        Me.DrAmount_b.HeaderText = "DrAmount"
        Me.DrAmount_b.MaxInputLength = 13
        Me.DrAmount_b.Name = "DrAmount_b"
        '
        'CrAmount_b
        '
        Me.CrAmount_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CrAmount_b.DefaultCellStyle = DataGridViewCellStyle15
        Me.CrAmount_b.HeaderText = "CrAmount"
        Me.CrAmount_b.MaxInputLength = 13
        Me.CrAmount_b.Name = "CrAmount_b"
        '
        'VoucherNo
        '
        Me.VoucherNo.HeaderText = "VoucherNo"
        Me.VoucherNo.Name = "VoucherNo"
        Me.VoucherNo.ReadOnly = True
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'SupervisorName
        '
        Me.SupervisorName.HeaderText = "SupervisorName"
        Me.SupervisorName.Name = "SupervisorName"
        Me.SupervisorName.ReadOnly = True
        '
        'ApprovedBy
        '
        Me.ApprovedBy.HeaderText = "ApprovedBy"
        Me.ApprovedBy.Name = "ApprovedBy"
        Me.ApprovedBy.ReadOnly = True
        '
        'ApprovedDate
        '
        Me.ApprovedDate.HeaderText = "ApprovedDate"
        Me.ApprovedDate.Name = "ApprovedDate"
        Me.ApprovedDate.ReadOnly = True
        '
        'btnReset
        '
        Me.btnReset.AutoSize = True
        Me.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnReset.Location = New System.Drawing.Point(164, 310)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(45, 23)
        Me.btnReset.TabIndex = 141
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'cboInstrumentNo
        '
        Me.cboInstrumentNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInstrumentNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboInstrumentNo.FormattingEnabled = True
        Me.cboInstrumentNo.Location = New System.Drawing.Point(126, 175)
        Me.cboInstrumentNo.Name = "cboInstrumentNo"
        Me.cboInstrumentNo.Size = New System.Drawing.Size(161, 21)
        Me.cboInstrumentNo.TabIndex = 149
        '
        'grpExpenseType
        '
        Me.grpExpenseType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpExpenseType.Controls.Add(Me.optDeferredPayment)
        Me.grpExpenseType.Controls.Add(Me.optProvision)
        Me.grpExpenseType.Controls.Add(Me.optAdjustPrepaid)
        Me.grpExpenseType.Controls.Add(Me.optPrepaid)
        Me.grpExpenseType.Controls.Add(Me.optFixedAsset)
        Me.grpExpenseType.Controls.Add(Me.optNormalExpense)
        Me.grpExpenseType.Location = New System.Drawing.Point(26, 2)
        Me.grpExpenseType.Name = "grpExpenseType"
        Me.grpExpenseType.Size = New System.Drawing.Size(1104, 44)
        Me.grpExpenseType.TabIndex = 150
        Me.grpExpenseType.TabStop = False
        '
        'optDeferredPayment
        '
        Me.optDeferredPayment.AutoSize = True
        Me.optDeferredPayment.Location = New System.Drawing.Point(944, 14)
        Me.optDeferredPayment.Name = "optDeferredPayment"
        Me.optDeferredPayment.Size = New System.Drawing.Size(110, 17)
        Me.optDeferredPayment.TabIndex = 7
        Me.optDeferredPayment.Text = "Deferred Payment"
        Me.optDeferredPayment.UseVisualStyleBackColor = True
        '
        'optProvision
        '
        Me.optProvision.AutoSize = True
        Me.optProvision.Location = New System.Drawing.Point(808, 14)
        Me.optProvision.Name = "optProvision"
        Me.optProvision.Size = New System.Drawing.Size(68, 17)
        Me.optProvision.TabIndex = 6
        Me.optProvision.Text = "Provision"
        Me.optProvision.UseVisualStyleBackColor = True
        '
        'optAdjustPrepaid
        '
        Me.optAdjustPrepaid.AutoSize = True
        Me.optAdjustPrepaid.Location = New System.Drawing.Point(588, 14)
        Me.optAdjustPrepaid.Name = "optAdjustPrepaid"
        Me.optAdjustPrepaid.Size = New System.Drawing.Size(130, 17)
        Me.optAdjustPrepaid.TabIndex = 5
        Me.optAdjustPrepaid.Text = "Adjust against Prepaid"
        Me.optAdjustPrepaid.UseVisualStyleBackColor = True
        '
        'optPrepaid
        '
        Me.optPrepaid.AutoSize = True
        Me.optPrepaid.Location = New System.Drawing.Point(403, 14)
        Me.optPrepaid.Name = "optPrepaid"
        Me.optPrepaid.Size = New System.Drawing.Size(105, 17)
        Me.optPrepaid.TabIndex = 4
        Me.optPrepaid.Text = "Prepaid Expense"
        Me.optPrepaid.UseVisualStyleBackColor = True
        '
        'optFixedAsset
        '
        Me.optFixedAsset.AutoSize = True
        Me.optFixedAsset.Location = New System.Drawing.Point(189, 14)
        Me.optFixedAsset.Name = "optFixedAsset"
        Me.optFixedAsset.Size = New System.Drawing.Size(127, 17)
        Me.optFixedAsset.TabIndex = 3
        Me.optFixedAsset.Text = "Fixed Asset Purchase"
        Me.optFixedAsset.UseVisualStyleBackColor = True
        '
        'optNormalExpense
        '
        Me.optNormalExpense.AutoSize = True
        Me.optNormalExpense.Checked = True
        Me.optNormalExpense.Location = New System.Drawing.Point(8, 14)
        Me.optNormalExpense.Name = "optNormalExpense"
        Me.optNormalExpense.Size = New System.Drawing.Size(102, 17)
        Me.optNormalExpense.TabIndex = 1
        Me.optNormalExpense.TabStop = True
        Me.optNormalExpense.Text = "Normal Expense"
        Me.optNormalExpense.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(232, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 22)
        Me.Button1.TabIndex = 151
        Me.Button1.Text = "."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnChangeDebitSide
        '
        Me.btnChangeDebitSide.AutoSize = True
        Me.btnChangeDebitSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnChangeDebitSide.Location = New System.Drawing.Point(1418, 314)
        Me.btnChangeDebitSide.Name = "btnChangeDebitSide"
        Me.btnChangeDebitSide.Size = New System.Drawing.Size(142, 23)
        Me.btnChangeDebitSide.TabIndex = 152
        Me.btnChangeDebitSide.Text = "Enable Debit Side Change"
        Me.btnChangeDebitSide.UseVisualStyleBackColor = True
        '
        'btnUpdateDebitSide
        '
        Me.btnUpdateDebitSide.AutoSize = True
        Me.btnUpdateDebitSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUpdateDebitSide.Location = New System.Drawing.Point(1313, 314)
        Me.btnUpdateDebitSide.Name = "btnUpdateDebitSide"
        Me.btnUpdateDebitSide.Size = New System.Drawing.Size(101, 23)
        Me.btnUpdateDebitSide.TabIndex = 153
        Me.btnUpdateDebitSide.Text = "Update DebitSide"
        Me.btnUpdateDebitSide.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(688, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 155
        Me.Label8.Text = "Voucher No"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnUpdateVoucherNo
        '
        Me.btnUpdateVoucherNo.AutoSize = True
        Me.btnUpdateVoucherNo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUpdateVoucherNo.Location = New System.Drawing.Point(1334, 285)
        Me.btnUpdateVoucherNo.Name = "btnUpdateVoucherNo"
        Me.btnUpdateVoucherNo.Size = New System.Drawing.Size(70, 23)
        Me.btnUpdateVoucherNo.TabIndex = 156
        Me.btnUpdateVoucherNo.Text = "Update VN"
        Me.btnUpdateVoucherNo.UseVisualStyleBackColor = True
        '
        'cboVoucherNo
        '
        Me.cboVoucherNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVoucherNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboVoucherNo.FormattingEnabled = True
        Me.cboVoucherNo.Items.AddRange(New Object() {"CASH", "CHEQUE", "ONLINE"})
        Me.cboVoucherNo.Location = New System.Drawing.Point(768, 58)
        Me.cboVoucherNo.Name = "cboVoucherNo"
        Me.cboVoucherNo.Size = New System.Drawing.Size(113, 21)
        Me.cboVoucherNo.TabIndex = 159
        '
        'lblGID
        '
        Me.lblGID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGID.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGID.ForeColor = System.Drawing.Color.Blue
        Me.lblGID.Location = New System.Drawing.Point(1186, 63)
        Me.lblGID.Name = "lblGID"
        Me.lblGID.Size = New System.Drawing.Size(256, 20)
        Me.lblGID.TabIndex = 157
        Me.lblGID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblGID.Visible = False
        '
        'btnEnableVoucherNoUpdate
        '
        Me.btnEnableVoucherNoUpdate.AutoSize = True
        Me.btnEnableVoucherNoUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEnableVoucherNoUpdate.Location = New System.Drawing.Point(1410, 285)
        Me.btnEnableVoucherNoUpdate.Name = "btnEnableVoucherNoUpdate"
        Me.btnEnableVoucherNoUpdate.Size = New System.Drawing.Size(151, 23)
        Me.btnEnableVoucherNoUpdate.TabIndex = 158
        Me.btnEnableVoucherNoUpdate.Text = "Enable Voucher No Addition"
        Me.btnEnableVoucherNoUpdate.UseVisualStyleBackColor = True
        '
        'btnApprove
        '
        Me.btnApprove.AutoSize = True
        Me.btnApprove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnApprove.BackColor = System.Drawing.Color.Gray
        Me.btnApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApprove.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnApprove.Location = New System.Drawing.Point(506, 310)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(75, 23)
        Me.btnApprove.TabIndex = 159
        Me.btnApprove.Text = "APPROVE"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'lblApprovedBy
        '
        Me.lblApprovedBy.BackColor = System.Drawing.Color.Black
        Me.lblApprovedBy.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblApprovedBy.ForeColor = System.Drawing.Color.White
        Me.lblApprovedBy.Location = New System.Drawing.Point(1222, 173)
        Me.lblApprovedBy.Name = "lblApprovedBy"
        Me.lblApprovedBy.Size = New System.Drawing.Size(150, 22)
        Me.lblApprovedBy.TabIndex = 160
        Me.lblApprovedBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblApprovedDate
        '
        Me.lblApprovedDate.BackColor = System.Drawing.Color.Black
        Me.lblApprovedDate.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblApprovedDate.ForeColor = System.Drawing.Color.White
        Me.lblApprovedDate.Location = New System.Drawing.Point(1378, 173)
        Me.lblApprovedDate.Name = "lblApprovedDate"
        Me.lblApprovedDate.Size = New System.Drawing.Size(111, 22)
        Me.lblApprovedDate.TabIndex = 161
        Me.lblApprovedDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnReject
        '
        Me.btnReject.AutoSize = True
        Me.btnReject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnReject.BackColor = System.Drawing.Color.Gray
        Me.btnReject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReject.ForeColor = System.Drawing.Color.Red
        Me.btnReject.Location = New System.Drawing.Point(587, 310)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(64, 23)
        Me.btnReject.TabIndex = 162
        Me.btnReject.Text = "REJECT"
        Me.btnReject.UseVisualStyleBackColor = False
        '
        'btnShowAllPending
        '
        Me.btnShowAllPending.AutoSize = True
        Me.btnShowAllPending.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnShowAllPending.Location = New System.Drawing.Point(263, 310)
        Me.btnShowAllPending.Name = "btnShowAllPending"
        Me.btnShowAllPending.Size = New System.Drawing.Size(99, 23)
        Me.btnShowAllPending.TabIndex = 163
        Me.btnShowAllPending.Text = "Show all Pending"
        Me.btnShowAllPending.UseVisualStyleBackColor = True
        '
        'cboApprovers
        '
        Me.cboApprovers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboApprovers.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboApprovers.FormattingEnabled = True
        Me.cboApprovers.Items.AddRange(New Object() {"CASH", "CHEQUE", "ONLINE"})
        Me.cboApprovers.Location = New System.Drawing.Point(857, 175)
        Me.cboApprovers.Name = "cboApprovers"
        Me.cboApprovers.Size = New System.Drawing.Size(178, 21)
        Me.cboApprovers.TabIndex = 164
        '
        'btnEmailApprover
        '
        Me.btnEmailApprover.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEmailApprover.Location = New System.Drawing.Point(1039, 173)
        Me.btnEmailApprover.Name = "btnEmailApprover"
        Me.btnEmailApprover.Size = New System.Drawing.Size(178, 23)
        Me.btnEmailApprover.TabIndex = 165
        Me.btnEmailApprover.Text = "Email Supervisor for Approval"
        Me.btnEmailApprover.UseVisualStyleBackColor = True
        '
        'btnShowMoreInGrid
        '
        Me.btnShowMoreInGrid.AutoSize = True
        Me.btnShowMoreInGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnShowMoreInGrid.Location = New System.Drawing.Point(1166, 310)
        Me.btnShowMoreInGrid.Name = "btnShowMoreInGrid"
        Me.btnShowMoreInGrid.Size = New System.Drawing.Size(71, 23)
        Me.btnShowMoreInGrid.TabIndex = 166
        Me.btnShowMoreInGrid.Text = "Show More"
        Me.btnShowMoreInGrid.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(776, 180)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 168
        Me.Label9.Text = "Supervised By"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnUpdatePayment
        '
        Me.btnUpdatePayment.AutoSize = True
        Me.btnUpdatePayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUpdatePayment.Location = New System.Drawing.Point(56, 310)
        Me.btnUpdatePayment.Name = "btnUpdatePayment"
        Me.btnUpdatePayment.Size = New System.Drawing.Size(52, 23)
        Me.btnUpdatePayment.TabIndex = 169
        Me.btnUpdatePayment.Text = "Update"
        Me.btnUpdatePayment.UseVisualStyleBackColor = True
        '
        'btnShowPendingWithMe
        '
        Me.btnShowPendingWithMe.AutoSize = True
        Me.btnShowPendingWithMe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnShowPendingWithMe.Location = New System.Drawing.Point(368, 310)
        Me.btnShowPendingWithMe.Name = "btnShowPendingWithMe"
        Me.btnShowPendingWithMe.Size = New System.Drawing.Size(96, 23)
        Me.btnShowPendingWithMe.TabIndex = 170
        Me.btnShowPendingWithMe.Text = "Pending with Me"
        Me.btnShowPendingWithMe.UseVisualStyleBackColor = True
        '
        'frmManagePayment
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1564, 965)
        Me.Controls.Add(Me.btnShowPendingWithMe)
        Me.Controls.Add(Me.cboVoucherNo)
        Me.Controls.Add(Me.lblGID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnUpdatePayment)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnShowMoreInGrid)
        Me.Controls.Add(Me.btnEmailApprover)
        Me.Controls.Add(Me.cboApprovers)
        Me.Controls.Add(Me.btnShowAllPending)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.lblApprovedDate)
        Me.Controls.Add(Me.lblApprovedBy)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnEnableVoucherNoUpdate)
        Me.Controls.Add(Me.btnUpdateVoucherNo)
        Me.Controls.Add(Me.btnUpdateDebitSide)
        Me.Controls.Add(Me.btnChangeDebitSide)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grpExpenseType)
        Me.Controls.Add(Me.cboInstrumentNo)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.lblCnt_b)
        Me.Controls.Add(Me.lblBalance_b)
        Me.Controls.Add(Me.btnQueryExpense)
        Me.Controls.Add(Me.dgvJournal_b)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.cboSampleNarration)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblCrBalance)
        Me.Controls.Add(Me.lblDrBalance)
        Me.Controls.Add(Me.btnAddNewAccount)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboBankName)
        Me.Controls.Add(Me.txtCreditActDesc)
        Me.Controls.Add(Me.txtDebitActDesc)
        Me.Controls.Add(Me.grpExpenseSubType)
        Me.Controls.Add(Me.lblCreditDesc)
        Me.Controls.Add(Me.cboCreditAccount)
        Me.Controls.Add(Me.lblDebitDesc)
        Me.Controls.Add(Me.cboDebitAccount)
        Me.Controls.Add(Me.lblInstrumentDate)
        Me.Controls.Add(Me.dtpInstrumentDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblInstrumentNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboPaymentMode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboExpenseType)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtPaymentAmount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpPaymentDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNarration)
        Me.Name = "frmManagePayment"
        Me.Text = "Manage Payments"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpExpenseSubType.ResumeLayout(False)
        Me.grpExpenseSubType.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvJournal_b, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpExpenseType.ResumeLayout(False)
        Me.grpExpenseType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtPaymentAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNarration As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboExpenseType As System.Windows.Forms.ComboBox
    Friend WithEvents lblInstrumentDate As System.Windows.Forms.Label
    Friend WithEvents dtpInstrumentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblInstrumentNo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblDebitDesc As System.Windows.Forms.Label
    Friend WithEvents cboDebitAccount As System.Windows.Forms.ComboBox
    Friend WithEvents lblCreditDesc As System.Windows.Forms.Label
    Friend WithEvents cboCreditAccount As System.Windows.Forms.ComboBox
    Friend WithEvents grpExpenseSubType As System.Windows.Forms.GroupBox
    Friend WithEvents optCapExp As System.Windows.Forms.RadioButton
    Friend WithEvents optCurExp As System.Windows.Forms.RadioButton
    Friend WithEvents txtDebitActDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditActDesc As System.Windows.Forms.TextBox
    Friend WithEvents cboBankName As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnShowChequeDetails As System.Windows.Forms.Button
    Friend WithEvents cboChequeNo As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddNewAccount As System.Windows.Forms.Button
    Friend WithEvents lblCrBalance As System.Windows.Forms.Label
    Friend WithEvents lblDrBalance As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSampleNarration As System.Windows.Forms.ComboBox
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents lblCnt_b As System.Windows.Forms.Label
    Friend WithEvents lblBalance_b As System.Windows.Forms.Label
    Friend WithEvents btnQueryExpense As System.Windows.Forms.Button
    Friend WithEvents dgvJournal_b As System.Windows.Forms.DataGridView
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents cboInstrumentNo As System.Windows.Forms.ComboBox
    Friend WithEvents grpExpenseType As System.Windows.Forms.GroupBox
    Friend WithEvents optPrepaid As System.Windows.Forms.RadioButton
    Friend WithEvents optFixedAsset As System.Windows.Forms.RadioButton
    Friend WithEvents optNormalExpense As System.Windows.Forms.RadioButton
    Friend WithEvents optDeferredPayment As System.Windows.Forms.RadioButton
    Friend WithEvents optProvision As System.Windows.Forms.RadioButton
    Friend WithEvents optAdjustPrepaid As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnChangeDebitSide As System.Windows.Forms.Button
    Friend WithEvents btnUpdateDebitSide As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnUpdateVoucherNo As System.Windows.Forms.Button
    Friend WithEvents lblGID As System.Windows.Forms.Label
    Friend WithEvents btnEnableVoucherNoUpdate As System.Windows.Forms.Button
    Friend WithEvents cboVoucherNo As System.Windows.Forms.ComboBox
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents lblApprovedBy As System.Windows.Forms.Label
    Friend WithEvents lblApprovedDate As System.Windows.Forms.Label
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents btnShowAllPending As System.Windows.Forms.Button
    Friend WithEvents cboApprovers As System.Windows.Forms.ComboBox
    Friend WithEvents btnEmailApprover As System.Windows.Forms.Button
    Friend WithEvents btnShowMoreInGrid As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnUpdatePayment As System.Windows.Forms.Button
    Friend WithEvents btnShowPendingWithMe As System.Windows.Forms.Button
    Friend WithEvents tblid_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gid_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnType_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnDate_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Narration_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocRef_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DrAccountNo_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrAccountNo_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DrAmount_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrAmount_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupervisorName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovedDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
