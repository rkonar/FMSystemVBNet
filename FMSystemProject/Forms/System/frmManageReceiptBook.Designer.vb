<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageReceiptBook
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
        Me.btnActivateThisBook = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.tblid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActivatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActivationDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnQueryTxn = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboBookType = New System.Windows.Forms.ComboBox()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSave.Location = New System.Drawing.Point(506, 78)
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
        Me.btnClose.Location = New System.Drawing.Point(82, 107)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(43, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtStartNo
        '
        Me.txtStartNo.Location = New System.Drawing.Point(142, 80)
        Me.txtStartNo.MaxLength = 12
        Me.txtStartNo.Name = "txtStartNo"
        Me.txtStartNo.Size = New System.Drawing.Size(100, 20)
        Me.txtStartNo.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Starting Receipt No"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEndNo
        '
        Me.txtEndNo.Enabled = False
        Me.txtEndNo.Location = New System.Drawing.Point(376, 80)
        Me.txtEndNo.MaxLength = 100
        Me.txtEndNo.Name = "txtEndNo"
        Me.txtEndNo.Size = New System.Drawing.Size(100, 20)
        Me.txtEndNo.TabIndex = 5
        '
        'lblInstrumentNo
        '
        Me.lblInstrumentNo.AutoSize = True
        Me.lblInstrumentNo.Location = New System.Drawing.Point(262, 83)
        Me.lblInstrumentNo.Name = "lblInstrumentNo"
        Me.lblInstrumentNo.Size = New System.Drawing.Size(83, 13)
        Me.lblInstrumentNo.TabIndex = 103
        Me.lblInstrumentNo.Text = "End Receipt No"
        '
        'cboBookID
        '
        Me.cboBookID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBookID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboBookID.FormattingEnabled = True
        Me.cboBookID.Location = New System.Drawing.Point(143, 47)
        Me.cboBookID.Name = "cboBookID"
        Me.cboBookID.Size = New System.Drawing.Size(211, 21)
        Me.cboBookID.TabIndex = 1
        '
        'btnActivateThisBook
        '
        Me.btnActivateThisBook.AutoSize = True
        Me.btnActivateThisBook.Location = New System.Drawing.Point(380, 46)
        Me.btnActivateThisBook.Name = "btnActivateThisBook"
        Me.btnActivateThisBook.Size = New System.Drawing.Size(135, 27)
        Me.btnActivateThisBook.TabIndex = 10
        Me.btnActivateThisBook.Text = "Activate This Book"
        Me.btnActivateThisBook.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 51)
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
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tblid, Me.BookID, Me.ReceiptNo, Me.ActivatedBy, Me.ActivationDate, Me.Status, Me.Remarks})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvData.Location = New System.Drawing.Point(9, 137)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowTemplate.Height = 24
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvData.Size = New System.Drawing.Size(874, 621)
        Me.dgvData.TabIndex = 123
        '
        'tblid
        '
        Me.tblid.HeaderText = "tblid"
        Me.tblid.Name = "tblid"
        Me.tblid.Visible = False
        '
        'BookID
        '
        Me.BookID.HeaderText = "Book ID"
        Me.BookID.Name = "BookID"
        Me.BookID.Visible = False
        '
        'ReceiptNo
        '
        Me.ReceiptNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "D"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.ReceiptNo.DefaultCellStyle = DataGridViewCellStyle7
        Me.ReceiptNo.HeaderText = "Receipt No"
        Me.ReceiptNo.MaxInputLength = 25
        Me.ReceiptNo.Name = "ReceiptNo"
        Me.ReceiptNo.ReadOnly = True
        '
        'ActivatedBy
        '
        Me.ActivatedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ActivatedBy.DefaultCellStyle = DataGridViewCellStyle8
        Me.ActivatedBy.HeaderText = "Activated By"
        Me.ActivatedBy.MaxInputLength = 255
        Me.ActivatedBy.MinimumWidth = 10
        Me.ActivatedBy.Name = "ActivatedBy"
        Me.ActivatedBy.ReadOnly = True
        Me.ActivatedBy.Width = 250
        '
        'ActivationDate
        '
        Me.ActivationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ActivationDate.DefaultCellStyle = DataGridViewCellStyle9
        Me.ActivationDate.HeaderText = "Activation Date"
        Me.ActivationDate.MaxInputLength = 15
        Me.ActivationDate.MinimumWidth = 10
        Me.ActivationDate.Name = "ActivationDate"
        Me.ActivationDate.ReadOnly = True
        '
        'Status
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Status.DefaultCellStyle = DataGridViewCellStyle10
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 100
        Me.Status.Name = "Status"
        '
        'Remarks
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Remarks.DefaultCellStyle = DataGridViewCellStyle11
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.MinimumWidth = 10
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 300
        '
        'btnQueryTxn
        '
        Me.btnQueryTxn.AutoSize = True
        Me.btnQueryTxn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQueryTxn.Location = New System.Drawing.Point(521, 46)
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
        Me.btnAdd.Location = New System.Drawing.Point(16, 107)
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
        Me.btnCancel.Location = New System.Drawing.Point(571, 78)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(50, 23)
        Me.btnCancel.TabIndex = 139
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Receipt Book Type"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboBookType
        '
        Me.cboBookType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBookType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboBookType.FormattingEnabled = True
        Me.cboBookType.Location = New System.Drawing.Point(143, 12)
        Me.cboBookType.Name = "cboBookType"
        Me.cboBookType.Size = New System.Drawing.Size(211, 21)
        Me.cboBookType.TabIndex = 140
        '
        'frmManageReceiptBook
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(900, 764)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboBookType)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnQueryTxn)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnActivateThisBook)
        Me.Controls.Add(Me.cboBookID)
        Me.Controls.Add(Me.txtEndNo)
        Me.Controls.Add(Me.lblInstrumentNo)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtStartNo)
        Me.Controls.Add(Me.Label7)
        Me.Name = "frmManageReceiptBook"
        Me.Text = "Manage Receipt Book"
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
    Friend WithEvents btnActivateThisBook As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents btnQueryTxn As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tblid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboBookType As System.Windows.Forms.ComboBox
End Class
