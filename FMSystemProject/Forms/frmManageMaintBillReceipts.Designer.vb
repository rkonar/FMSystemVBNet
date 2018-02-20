<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageMaintBillReceipts
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageMaintBillReceipts))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.chkOnlyUnadjusted = New System.Windows.Forms.CheckBox()
        Me.cboSearchApartment = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvReceipts = New System.Windows.Forms.DataGridView()
        Me.ReceiptID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceiptRowState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceiptDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceiptAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InstrumentType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.InstrumentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InstrumentBank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InstrumentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceiptAdjAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnUpdateRow = New System.Windows.Forms.Button()
        Me.btnAddRow = New System.Windows.Forms.Button()
        Me.btnDeleteRow = New System.Windows.Forms.Button()
        Me.btnSaveRow = New System.Windows.Forms.Button()
        Me.dgvBills = New System.Windows.Forms.DataGridView()
        Me.BillID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillRowState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DueDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillPaidAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBills, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnQuery
        '
        Me.btnQuery.AutoSize = True
        Me.btnQuery.Location = New System.Drawing.Point(535, 6)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 27)
        Me.btnQuery.TabIndex = 27
        Me.btnQuery.Text = "Query"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'chkOnlyUnadjusted
        '
        Me.chkOnlyUnadjusted.AutoSize = True
        Me.chkOnlyUnadjusted.Location = New System.Drawing.Point(225, 9)
        Me.chkOnlyUnadjusted.Name = "chkOnlyUnadjusted"
        Me.chkOnlyUnadjusted.Size = New System.Drawing.Size(135, 21)
        Me.chkOnlyUnadjusted.TabIndex = 6
        Me.chkOnlyUnadjusted.Text = "Only Unadjusted"
        Me.chkOnlyUnadjusted.UseVisualStyleBackColor = True
        '
        'cboSearchApartment
        '
        Me.cboSearchApartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchApartment.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboSearchApartment.FormattingEnabled = True
        Me.cboSearchApartment.Location = New System.Drawing.Point(94, 7)
        Me.cboSearchApartment.Name = "cboSearchApartment"
        Me.cboSearchApartment.Size = New System.Drawing.Size(121, 24)
        Me.cboSearchApartment.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Apartment"
        '
        'dgvReceipts
        '
        Me.dgvReceipts.AllowUserToAddRows = False
        Me.dgvReceipts.AllowUserToDeleteRows = False
        Me.dgvReceipts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceipts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReceiptID, Me.ReceiptRowState, Me.ReceiptNo, Me.ReceiptDate, Me.ReceiptAmt, Me.InstrumentType, Me.InstrumentDate, Me.InstrumentBank, Me.InstrumentNo, Me.Remarks, Me.ReceiptAdjAmt})
        Me.dgvReceipts.Location = New System.Drawing.Point(2, 49)
        Me.dgvReceipts.Name = "dgvReceipts"
        Me.dgvReceipts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvReceipts.RowHeadersVisible = False
        Me.dgvReceipts.RowTemplate.Height = 24
        Me.dgvReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvReceipts.Size = New System.Drawing.Size(1225, 258)
        Me.dgvReceipts.TabIndex = 3
        '
        'ReceiptID
        '
        Me.ReceiptID.HeaderText = "ReceiptID"
        Me.ReceiptID.Name = "ReceiptID"
        Me.ReceiptID.Visible = False
        '
        'ReceiptRowState
        '
        Me.ReceiptRowState.HeaderText = "RowState"
        Me.ReceiptRowState.MaxInputLength = 1
        Me.ReceiptRowState.Name = "ReceiptRowState"
        Me.ReceiptRowState.Visible = False
        '
        'ReceiptNo
        '
        Me.ReceiptNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ReceiptNo.DefaultCellStyle = DataGridViewCellStyle1
        Me.ReceiptNo.HeaderText = "ReceiptNo"
        Me.ReceiptNo.MaxInputLength = 25
        Me.ReceiptNo.Name = "ReceiptNo"
        Me.ReceiptNo.Width = 99
        '
        'ReceiptDate
        '
        Me.ReceiptDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "D"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.ReceiptDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.ReceiptDate.HeaderText = "ReceiptDate"
        Me.ReceiptDate.MaxInputLength = 11
        Me.ReceiptDate.Name = "ReceiptDate"
        Me.ReceiptDate.ReadOnly = True
        Me.ReceiptDate.Width = 111
        '
        'ReceiptAmt
        '
        Me.ReceiptAmt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ReceiptAmt.DefaultCellStyle = DataGridViewCellStyle3
        Me.ReceiptAmt.HeaderText = "ReceiptAmt"
        Me.ReceiptAmt.MaxInputLength = 13
        Me.ReceiptAmt.Name = "ReceiptAmt"
        Me.ReceiptAmt.Width = 105
        '
        'InstrumentType
        '
        Me.InstrumentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.InstrumentType.DefaultCellStyle = DataGridViewCellStyle4
        Me.InstrumentType.HeaderText = "InstrumentType"
        Me.InstrumentType.Name = "InstrumentType"
        Me.InstrumentType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InstrumentType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.InstrumentType.Width = 131
        '
        'InstrumentDate
        '
        Me.InstrumentDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "D"
        Me.InstrumentDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.InstrumentDate.HeaderText = "InstrumentDate"
        Me.InstrumentDate.MaxInputLength = 11
        Me.InstrumentDate.Name = "InstrumentDate"
        Me.InstrumentDate.ReadOnly = True
        Me.InstrumentDate.Width = 129
        '
        'InstrumentBank
        '
        Me.InstrumentBank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.InstrumentBank.DefaultCellStyle = DataGridViewCellStyle6
        Me.InstrumentBank.HeaderText = "InstrumentBank"
        Me.InstrumentBank.MaxInputLength = 25
        Me.InstrumentBank.Name = "InstrumentBank"
        Me.InstrumentBank.Width = 131
        '
        'InstrumentNo
        '
        Me.InstrumentNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.InstrumentNo.DefaultCellStyle = DataGridViewCellStyle7
        Me.InstrumentNo.HeaderText = "InstrumentNo"
        Me.InstrumentNo.MaxInputLength = 15
        Me.InstrumentNo.Name = "InstrumentNo"
        Me.InstrumentNo.Width = 117
        '
        'Remarks
        '
        Me.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Remarks.DefaultCellStyle = DataGridViewCellStyle8
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.MaxInputLength = 255
        Me.Remarks.Name = "Remarks"
        Me.Remarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Remarks.Width = 255
        '
        'ReceiptAdjAmt
        '
        Me.ReceiptAdjAmt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ReceiptAdjAmt.DefaultCellStyle = DataGridViewCellStyle9
        Me.ReceiptAdjAmt.HeaderText = "ReceiptAdjAmt"
        Me.ReceiptAdjAmt.MaxInputLength = 13
        Me.ReceiptAdjAmt.Name = "ReceiptAdjAmt"
        Me.ReceiptAdjAmt.Width = 125
        '
        'btnUpdateRow
        '
        Me.btnUpdateRow.AutoSize = True
        Me.btnUpdateRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUpdateRow.Image = CType(resources.GetObject("btnUpdateRow.Image"), System.Drawing.Image)
        Me.btnUpdateRow.Location = New System.Drawing.Point(1230, 140)
        Me.btnUpdateRow.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdateRow.Name = "btnUpdateRow"
        Me.btnUpdateRow.Size = New System.Drawing.Size(22, 22)
        Me.btnUpdateRow.TabIndex = 26
        Me.btnUpdateRow.UseVisualStyleBackColor = True
        '
        'btnAddRow
        '
        Me.btnAddRow.AutoSize = True
        Me.btnAddRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAddRow.Image = CType(resources.GetObject("btnAddRow.Image"), System.Drawing.Image)
        Me.btnAddRow.Location = New System.Drawing.Point(1230, 90)
        Me.btnAddRow.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Size = New System.Drawing.Size(22, 22)
        Me.btnAddRow.TabIndex = 25
        Me.btnAddRow.UseVisualStyleBackColor = True
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.AutoSize = True
        Me.btnDeleteRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDeleteRow.Image = CType(resources.GetObject("btnDeleteRow.Image"), System.Drawing.Image)
        Me.btnDeleteRow.Location = New System.Drawing.Point(1230, 115)
        Me.btnDeleteRow.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(22, 22)
        Me.btnDeleteRow.TabIndex = 24
        Me.btnDeleteRow.UseVisualStyleBackColor = True
        '
        'btnSaveRow
        '
        Me.btnSaveRow.AutoSize = True
        Me.btnSaveRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSaveRow.Image = CType(resources.GetObject("btnSaveRow.Image"), System.Drawing.Image)
        Me.btnSaveRow.Location = New System.Drawing.Point(1230, 181)
        Me.btnSaveRow.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveRow.Name = "btnSaveRow"
        Me.btnSaveRow.Size = New System.Drawing.Size(22, 22)
        Me.btnSaveRow.TabIndex = 28
        Me.btnSaveRow.UseVisualStyleBackColor = True
        '
        'dgvBills
        '
        Me.dgvBills.AllowUserToAddRows = False
        Me.dgvBills.AllowUserToDeleteRows = False
        Me.dgvBills.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBills.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BillID, Me.BillRowState, Me.BillNo, Me.BillType, Me.BillDate, Me.BillFrom, Me.BillTo, Me.BillAmt, Me.DueDate, Me.BillPaidAmt})
        Me.dgvBills.Location = New System.Drawing.Point(2, 313)
        Me.dgvBills.Name = "dgvBills"
        Me.dgvBills.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvBills.RowHeadersVisible = False
        Me.dgvBills.RowTemplate.Height = 24
        Me.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvBills.Size = New System.Drawing.Size(1225, 258)
        Me.dgvBills.TabIndex = 29
        '
        'BillID
        '
        Me.BillID.HeaderText = "BillID"
        Me.BillID.Name = "BillID"
        Me.BillID.Visible = False
        '
        'BillRowState
        '
        Me.BillRowState.HeaderText = "RowState"
        Me.BillRowState.MaxInputLength = 1
        Me.BillRowState.Name = "BillRowState"
        Me.BillRowState.Visible = False
        '
        'BillNo
        '
        Me.BillNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.BillNo.DefaultCellStyle = DataGridViewCellStyle10
        Me.BillNo.HeaderText = "BillNo"
        Me.BillNo.MaxInputLength = 25
        Me.BillNo.Name = "BillNo"
        Me.BillNo.Width = 69
        '
        'BillType
        '
        Me.BillType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.BillType.DefaultCellStyle = DataGridViewCellStyle11
        Me.BillType.HeaderText = "BillType"
        Me.BillType.MaxInputLength = 25
        Me.BillType.Name = "BillType"
        Me.BillType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BillType.Width = 255
        '
        'BillDate
        '
        Me.BillDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Format = "D"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.BillDate.DefaultCellStyle = DataGridViewCellStyle12
        Me.BillDate.HeaderText = "BillDate"
        Me.BillDate.MaxInputLength = 11
        Me.BillDate.Name = "BillDate"
        Me.BillDate.ReadOnly = True
        Me.BillDate.Width = 81
        '
        'BillFrom
        '
        Me.BillFrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.BillFrom.DefaultCellStyle = DataGridViewCellStyle13
        Me.BillFrom.HeaderText = "BillFrom"
        Me.BillFrom.Name = "BillFrom"
        Me.BillFrom.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BillFrom.Width = 83
        '
        'BillTo
        '
        Me.BillTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.BillTo.DefaultCellStyle = DataGridViewCellStyle14
        Me.BillTo.HeaderText = "BillTo"
        Me.BillTo.MaxInputLength = 25
        Me.BillTo.Name = "BillTo"
        Me.BillTo.Width = 68
        '
        'BillAmt
        '
        Me.BillAmt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.BillAmt.DefaultCellStyle = DataGridViewCellStyle15
        Me.BillAmt.HeaderText = "BillAmt"
        Me.BillAmt.MaxInputLength = 13
        Me.BillAmt.Name = "BillAmt"
        Me.BillAmt.Width = 75
        '
        'DueDate
        '
        Me.DueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.Format = "D"
        Me.DueDate.DefaultCellStyle = DataGridViewCellStyle16
        Me.DueDate.HeaderText = "DueDate"
        Me.DueDate.MaxInputLength = 11
        Me.DueDate.Name = "DueDate"
        Me.DueDate.ReadOnly = True
        Me.DueDate.Width = 89
        '
        'BillPaidAmt
        '
        Me.BillPaidAmt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.BillPaidAmt.DefaultCellStyle = DataGridViewCellStyle17
        Me.BillPaidAmt.HeaderText = "BillPaidAmt"
        Me.BillPaidAmt.MaxInputLength = 13
        Me.BillPaidAmt.Name = "BillPaidAmt"
        Me.BillPaidAmt.Width = 103
        '
        'frmManageMaintBillReceipts
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1259, 643)
        Me.Controls.Add(Me.dgvBills)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.btnSaveRow)
        Me.Controls.Add(Me.chkOnlyUnadjusted)
        Me.Controls.Add(Me.cboSearchApartment)
        Me.Controls.Add(Me.btnUpdateRow)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnAddRow)
        Me.Controls.Add(Me.btnDeleteRow)
        Me.Controls.Add(Me.dgvReceipts)
        Me.Name = "frmManageMaintBillReceipts"
        Me.Text = "Manage Maintenance Bill Receipts"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBills, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkOnlyUnadjusted As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchApartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvReceipts As System.Windows.Forms.DataGridView
    Friend WithEvents btnUpdateRow As System.Windows.Forms.Button
    Friend WithEvents btnAddRow As System.Windows.Forms.Button
    Friend WithEvents btnDeleteRow As System.Windows.Forms.Button
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents btnSaveRow As System.Windows.Forms.Button
    Friend WithEvents dgvBills As System.Windows.Forms.DataGridView
    Friend WithEvents ReceiptID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptRowState As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstrumentType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents InstrumentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstrumentBank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstrumentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptAdjAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillRowState As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillPaidAmt As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
