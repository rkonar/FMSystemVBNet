<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageChequeBook
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtStartNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEndNo = New System.Windows.Forms.TextBox()
        Me.lblInstrumentNo = New System.Windows.Forms.Label()
        Me.cboBookID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.tblid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MICR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChequeNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VoucherNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cancel = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnQueryTxn = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtActDesc = New System.Windows.Forms.TextBox()
        Me.lblDebitDesc = New System.Windows.Forms.Label()
        Me.cboAccount = New System.Windows.Forms.ComboBox()
        Me.txtMICR = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCancellationReason = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboBookType = New System.Windows.Forms.ComboBox()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSave.Location = New System.Drawing.Point(305, 154)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(42, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClose.Location = New System.Drawing.Point(83, 154)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(43, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtStartNo
        '
        Me.txtStartNo.Location = New System.Drawing.Point(110, 119)
        Me.txtStartNo.MaxLength = 12
        Me.txtStartNo.Name = "txtStartNo"
        Me.txtStartNo.Size = New System.Drawing.Size(100, 20)
        Me.txtStartNo.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Starting Cheque No"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEndNo
        '
        Me.txtEndNo.Enabled = False
        Me.txtEndNo.Location = New System.Drawing.Point(320, 119)
        Me.txtEndNo.MaxLength = 100
        Me.txtEndNo.Name = "txtEndNo"
        Me.txtEndNo.Size = New System.Drawing.Size(100, 20)
        Me.txtEndNo.TabIndex = 5
        '
        'lblInstrumentNo
        '
        Me.lblInstrumentNo.AutoSize = True
        Me.lblInstrumentNo.Location = New System.Drawing.Point(231, 122)
        Me.lblInstrumentNo.Name = "lblInstrumentNo"
        Me.lblInstrumentNo.Size = New System.Drawing.Size(83, 13)
        Me.lblInstrumentNo.TabIndex = 103
        Me.lblInstrumentNo.Text = "End Cheque No"
        '
        'cboBookID
        '
        Me.cboBookID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBookID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboBookID.FormattingEnabled = True
        Me.cboBookID.Location = New System.Drawing.Point(74, 86)
        Me.cboBookID.Name = "cboBookID"
        Me.cboBookID.Size = New System.Drawing.Size(369, 21)
        Me.cboBookID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Book No"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tblid, Me.MICR, Me.BookID, Me.ChequeNo, Me.VoucherNo, Me.Status, Me.UpdatedBy, Me.Remarks, Me.Cancel})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvData.Location = New System.Drawing.Point(9, 187)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowTemplate.Height = 24
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvData.Size = New System.Drawing.Size(870, 621)
        Me.dgvData.TabIndex = 123
        '
        'tblid
        '
        Me.tblid.HeaderText = "tblid"
        Me.tblid.Name = "tblid"
        Me.tblid.Visible = False
        '
        'MICR
        '
        Me.MICR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MICR.DefaultCellStyle = DataGridViewCellStyle7
        Me.MICR.HeaderText = "MICR"
        Me.MICR.MaxInputLength = 255
        Me.MICR.MinimumWidth = 10
        Me.MICR.Name = "MICR"
        Me.MICR.ReadOnly = True
        Me.MICR.Visible = False
        Me.MICR.Width = 250
        '
        'BookID
        '
        Me.BookID.HeaderText = "Book ID"
        Me.BookID.Name = "BookID"
        Me.BookID.Visible = False
        '
        'ChequeNo
        '
        Me.ChequeNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Format = "D"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ChequeNo.DefaultCellStyle = DataGridViewCellStyle8
        Me.ChequeNo.HeaderText = "Cheque No"
        Me.ChequeNo.MaxInputLength = 25
        Me.ChequeNo.Name = "ChequeNo"
        Me.ChequeNo.ReadOnly = True
        '
        'VoucherNo
        '
        Me.VoucherNo.HeaderText = "VoucherNo"
        Me.VoucherNo.Name = "VoucherNo"
        Me.VoucherNo.ReadOnly = True
        '
        'Status
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Status.DefaultCellStyle = DataGridViewCellStyle9
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 100
        Me.Status.Name = "Status"
        '
        'UpdatedBy
        '
        Me.UpdatedBy.HeaderText = "UpdatedBy"
        Me.UpdatedBy.Name = "UpdatedBy"
        Me.UpdatedBy.ReadOnly = True
        '
        'Remarks
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Remarks.DefaultCellStyle = DataGridViewCellStyle10
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.MinimumWidth = 10
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 300
        '
        'Cancel
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cancel.DefaultCellStyle = DataGridViewCellStyle11
        Me.Cancel.HeaderText = ""
        Me.Cancel.Name = "Cancel"
        Me.Cancel.ReadOnly = True
        Me.Cancel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'btnQueryTxn
        '
        Me.btnQueryTxn.AutoSize = True
        Me.btnQueryTxn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQueryTxn.Location = New System.Drawing.Point(162, 154)
        Me.btnQueryTxn.Name = "btnQueryTxn"
        Me.btnQueryTxn.Size = New System.Drawing.Size(45, 23)
        Me.btnQueryTxn.TabIndex = 124
        Me.btnQueryTxn.Text = "Query"
        Me.btnQueryTxn.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = True
        Me.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAdd.Location = New System.Drawing.Point(17, 154)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(36, 23)
        Me.btnAdd.TabIndex = 138
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCancel.Location = New System.Drawing.Point(370, 154)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(50, 23)
        Me.btnCancel.TabIndex = 139
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtActDesc
        '
        Me.txtActDesc.Location = New System.Drawing.Point(617, 12)
        Me.txtActDesc.MaxLength = 12
        Me.txtActDesc.Multiline = True
        Me.txtActDesc.Name = "txtActDesc"
        Me.txtActDesc.ReadOnly = True
        Me.txtActDesc.Size = New System.Drawing.Size(270, 70)
        Me.txtActDesc.TabIndex = 142
        '
        'lblDebitDesc
        '
        Me.lblDebitDesc.Location = New System.Drawing.Point(260, 12)
        Me.lblDebitDesc.Name = "lblDebitDesc"
        Me.lblDebitDesc.Size = New System.Drawing.Size(84, 24)
        Me.lblDebitDesc.TabIndex = 141
        Me.lblDebitDesc.Text = "Account No"
        Me.lblDebitDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAccount
        '
        Me.cboAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboAccount.FormattingEnabled = True
        Me.cboAccount.Location = New System.Drawing.Point(350, 13)
        Me.cboAccount.Name = "cboAccount"
        Me.cboAccount.Size = New System.Drawing.Size(261, 21)
        Me.cboAccount.TabIndex = 140
        '
        'txtMICR
        '
        Me.txtMICR.Location = New System.Drawing.Point(74, 47)
        Me.txtMICR.MaxLength = 9
        Me.txtMICR.Name = "txtMICR"
        Me.txtMICR.Size = New System.Drawing.Size(220, 20)
        Me.txtMICR.TabIndex = 144
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "MICR"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCancellationReason
        '
        Me.txtCancellationReason.Location = New System.Drawing.Point(439, 122)
        Me.txtCancellationReason.MaxLength = 255
        Me.txtCancellationReason.Multiline = True
        Me.txtCancellationReason.Name = "txtCancellationReason"
        Me.txtCancellationReason.Size = New System.Drawing.Size(440, 54)
        Me.txtCancellationReason.TabIndex = 146
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(614, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = "Cancellation Reason"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 149
        Me.Label4.Text = "ChequeBook Type"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboBookType
        '
        Me.cboBookType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBookType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboBookType.FormattingEnabled = True
        Me.cboBookType.Location = New System.Drawing.Point(114, 13)
        Me.cboBookType.Name = "cboBookType"
        Me.cboBookType.Size = New System.Drawing.Size(140, 21)
        Me.cboBookType.TabIndex = 148
        '
        'frmManageChequeBook
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(891, 812)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboBookType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCancellationReason)
        Me.Controls.Add(Me.txtMICR)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtActDesc)
        Me.Controls.Add(Me.lblDebitDesc)
        Me.Controls.Add(Me.cboAccount)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnQueryTxn)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboBookID)
        Me.Controls.Add(Me.txtEndNo)
        Me.Controls.Add(Me.lblInstrumentNo)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtStartNo)
        Me.Controls.Add(Me.Label7)
        Me.Name = "frmManageChequeBook"
        Me.Text = "Manage Cheque Book"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtStartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEndNo As System.Windows.Forms.TextBox
    Friend WithEvents lblInstrumentNo As System.Windows.Forms.Label
    Friend WithEvents cboBookID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents btnQueryTxn As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtActDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblDebitDesc As System.Windows.Forms.Label
    Friend WithEvents cboAccount As System.Windows.Forms.ComboBox
    Friend WithEvents txtMICR As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tblid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MICR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChequeNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cancel As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents txtCancellationReason As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboBookType As System.Windows.Forms.ComboBox
End Class
