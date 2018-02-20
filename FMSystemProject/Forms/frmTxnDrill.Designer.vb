<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTxnDrill
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvJournal = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTxnType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFromAmount = New System.Windows.Forms.TextBox()
        Me.txtToAmount = New System.Windows.Forms.TextBox()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.txtDocRefLike = New System.Windows.Forms.TextBox()
        Me.txtNarrationLike = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.tblid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Narration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvJournal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvJournal
        '
        Me.dgvJournal.AllowUserToAddRows = False
        Me.dgvJournal.AllowUserToDeleteRows = False
        Me.dgvJournal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvJournal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvJournal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tblid, Me.gid, Me.TxnType, Me.TxnDate, Me.Narration, Me.DocRef, Me.AccountNo, Me.Amount})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournal.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvJournal.Location = New System.Drawing.Point(12, 106)
        Me.dgvJournal.Name = "dgvJournal"
        Me.dgvJournal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvJournal.RowHeadersVisible = False
        Me.dgvJournal.RowTemplate.Height = 24
        Me.dgvJournal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvJournal.Size = New System.Drawing.Size(1361, 666)
        Me.dgvJournal.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(8, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(8, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "From Date"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(100, 40)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(123, 20)
        Me.dtpToDate.TabIndex = 33
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(100, 12)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(123, 20)
        Me.dtpFromDate.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Transaction Type"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTxnType
        '
        Me.cboTxnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTxnType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboTxnType.FormattingEnabled = True
        Me.cboTxnType.Location = New System.Drawing.Point(368, 10)
        Me.cboTxnType.Name = "cboTxnType"
        Me.cboTxnType.Size = New System.Drawing.Size(237, 21)
        Me.cboTxnType.TabIndex = 121
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(634, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 124
        Me.Label4.Text = "To Amount"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(634, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 123
        Me.Label5.Text = "From Amount"
        '
        'txtFromAmount
        '
        Me.txtFromAmount.Location = New System.Drawing.Point(745, 7)
        Me.txtFromAmount.MaxLength = 12
        Me.txtFromAmount.Name = "txtFromAmount"
        Me.txtFromAmount.Size = New System.Drawing.Size(157, 20)
        Me.txtFromAmount.TabIndex = 125
        '
        'txtToAmount
        '
        Me.txtToAmount.Location = New System.Drawing.Point(745, 35)
        Me.txtToAmount.MaxLength = 12
        Me.txtToAmount.Name = "txtToAmount"
        Me.txtToAmount.Size = New System.Drawing.Size(157, 20)
        Me.txtToAmount.TabIndex = 126
        '
        'btnQuery
        '
        Me.btnQuery.AutoSize = True
        Me.btnQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuery.Location = New System.Drawing.Point(1011, 17)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(45, 23)
        Me.btnQuery.TabIndex = 127
        Me.btnQuery.Text = "Query"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'txtDocRefLike
        '
        Me.txtDocRefLike.Location = New System.Drawing.Point(807, 81)
        Me.txtDocRefLike.MaxLength = 12
        Me.txtDocRefLike.Name = "txtDocRefLike"
        Me.txtDocRefLike.Size = New System.Drawing.Size(288, 20)
        Me.txtDocRefLike.TabIndex = 131
        '
        'txtNarrationLike
        '
        Me.txtNarrationLike.Location = New System.Drawing.Point(413, 78)
        Me.txtNarrationLike.MaxLength = 12
        Me.txtNarrationLike.Name = "txtNarrationLike"
        Me.txtNarrationLike.Size = New System.Drawing.Size(272, 20)
        Me.txtNarrationLike.TabIndex = 130
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(719, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "DocRef Like"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(315, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 128
        Me.Label7.Text = "Narration Like"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(238, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 132
        Me.Label8.Text = "Account No"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(365, 47)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(240, 11)
        Me.lblAccountNo.TabIndex = 133
        Me.lblAccountNo.Text = "Account No"
        Me.lblAccountNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tblid
        '
        Me.tblid.HeaderText = "tblid"
        Me.tblid.Name = "tblid"
        Me.tblid.Visible = False
        '
        'gid
        '
        Me.gid.HeaderText = "gid"
        Me.gid.MaxInputLength = 1
        Me.gid.Name = "gid"
        Me.gid.Visible = False
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "D"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.TxnDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.TxnDate.HeaderText = "TxnDate"
        Me.TxnDate.MaxInputLength = 11
        Me.TxnDate.Name = "TxnDate"
        Me.TxnDate.ReadOnly = True
        '
        'Narration
        '
        Me.Narration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Narration.DefaultCellStyle = DataGridViewCellStyle2
        Me.Narration.HeaderText = "Narration"
        Me.Narration.MaxInputLength = 255
        Me.Narration.MinimumWidth = 10
        Me.Narration.Name = "Narration"
        Me.Narration.ReadOnly = True
        Me.Narration.Width = 500
        '
        'DocRef
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DocRef.DefaultCellStyle = DataGridViewCellStyle3
        Me.DocRef.HeaderText = "DocRef"
        Me.DocRef.MinimumWidth = 100
        Me.DocRef.Name = "DocRef"
        Me.DocRef.Width = 350
        '
        'AccountNo
        '
        Me.AccountNo.HeaderText = "AccountNo"
        Me.AccountNo.Name = "AccountNo"
        Me.AccountNo.Width = 250
        '
        'Amount
        '
        Me.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle4
        Me.Amount.HeaderText = "Amount"
        Me.Amount.MaxInputLength = 13
        Me.Amount.Name = "Amount"
        Me.Amount.Width = 150
        '
        'frmTxnDrill
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1382, 784)
        Me.Controls.Add(Me.lblAccountNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtDocRefLike)
        Me.Controls.Add(Me.txtNarrationLike)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.txtToAmount)
        Me.Controls.Add(Me.txtFromAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTxnType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpFromDate)
        Me.Controls.Add(Me.dgvJournal)
        Me.Name = "frmTxnDrill"
        Me.Text = "frmManageJournal"
        CType(Me.dgvJournal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvJournal As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTxnType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFromAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtToAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents txtDocRefLike As System.Windows.Forms.TextBox
    Friend WithEvents txtNarrationLike As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents tblid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Narration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
