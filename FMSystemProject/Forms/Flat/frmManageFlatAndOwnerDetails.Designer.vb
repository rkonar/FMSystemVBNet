<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageFlatAndOwnerDetails
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvSAP = New System.Windows.Forms.DataGridView()
        Me.A = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.B = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.C = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.D = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgvSAN = New System.Windows.Forms.DataGridView()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn3 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn4 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgvSUK = New System.Windows.Forms.DataGridView()
        Me.DataGridViewButtonColumn5 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn6 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn7 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn8 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgvSHR = New System.Windows.Forms.DataGridView()
        Me.DataGridViewButtonColumn9 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn10 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn11 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn12 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.tbarOutstandingFrom = New System.Windows.Forms.TrackBar()
        Me.tbarOutstandingTo = New System.Windows.Forms.TrackBar()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.lblNet = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSap = New System.Windows.Forms.Label()
        Me.lblSan = New System.Windows.Forms.Label()
        Me.lblShr = New System.Windows.Forms.Label()
        Me.lblSuk = New System.Windows.Forms.Label()
        Me.chkCombineDuplexAmounts = New System.Windows.Forms.CheckBox()
        Me.btnFilterToADate = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optBoth = New System.Windows.Forms.RadioButton()
        Me.optBGF = New System.Windows.Forms.RadioButton()
        Me.optAssociation = New System.Windows.Forms.RadioButton()
        CType(Me.dgvSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSAN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSUK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSHR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarOutstandingFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarOutstandingTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvSAP
        '
        Me.dgvSAP.AllowUserToAddRows = False
        Me.dgvSAP.AllowUserToDeleteRows = False
        Me.dgvSAP.AllowUserToResizeColumns = False
        Me.dgvSAP.AllowUserToResizeRows = False
        Me.dgvSAP.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvSAP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSAP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvSAP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSAP.ColumnHeadersHeight = 4
        Me.dgvSAP.ColumnHeadersVisible = False
        Me.dgvSAP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.A, Me.B, Me.C, Me.D})
        Me.dgvSAP.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSAP.DefaultCellStyle = DataGridViewCellStyle25
        Me.dgvSAP.EnableHeadersVisualStyles = False
        Me.dgvSAP.Location = New System.Drawing.Point(4, 6)
        Me.dgvSAP.MultiSelect = False
        Me.dgvSAP.Name = "dgvSAP"
        Me.dgvSAP.ReadOnly = True
        Me.dgvSAP.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSAP.RowHeadersVisible = False
        Me.dgvSAP.RowTemplate.Height = 40
        Me.dgvSAP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSAP.Size = New System.Drawing.Size(305, 682)
        Me.dgvSAP.TabIndex = 30
        '
        'A
        '
        Me.A.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.A.DefaultCellStyle = DataGridViewCellStyle21
        Me.A.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.A.HeaderText = "A"
        Me.A.MinimumWidth = 60
        Me.A.Name = "A"
        Me.A.ReadOnly = True
        Me.A.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.A.Width = 60
        '
        'B
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.B.DefaultCellStyle = DataGridViewCellStyle22
        Me.B.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B.HeaderText = "B"
        Me.B.MinimumWidth = 60
        Me.B.Name = "B"
        Me.B.ReadOnly = True
        Me.B.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.B.Width = 70
        '
        'C
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C.DefaultCellStyle = DataGridViewCellStyle23
        Me.C.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.C.HeaderText = "C"
        Me.C.MinimumWidth = 60
        Me.C.Name = "C"
        Me.C.ReadOnly = True
        Me.C.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.C.Width = 70
        '
        'D
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.D.DefaultCellStyle = DataGridViewCellStyle24
        Me.D.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.D.HeaderText = "D"
        Me.D.MinimumWidth = 60
        Me.D.Name = "D"
        Me.D.ReadOnly = True
        Me.D.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.D.Width = 70
        '
        'dgvSAN
        '
        Me.dgvSAN.AllowUserToAddRows = False
        Me.dgvSAN.AllowUserToDeleteRows = False
        Me.dgvSAN.AllowUserToResizeColumns = False
        Me.dgvSAN.AllowUserToResizeRows = False
        Me.dgvSAN.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvSAN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSAN.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvSAN.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSAN.ColumnHeadersHeight = 4
        Me.dgvSAN.ColumnHeadersVisible = False
        Me.dgvSAN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewButtonColumn1, Me.DataGridViewButtonColumn2, Me.DataGridViewButtonColumn3, Me.DataGridViewButtonColumn4})
        Me.dgvSAN.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSAN.DefaultCellStyle = DataGridViewCellStyle30
        Me.dgvSAN.EnableHeadersVisualStyles = False
        Me.dgvSAN.Location = New System.Drawing.Point(312, 6)
        Me.dgvSAN.MultiSelect = False
        Me.dgvSAN.Name = "dgvSAN"
        Me.dgvSAN.ReadOnly = True
        Me.dgvSAN.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSAN.RowHeadersVisible = False
        Me.dgvSAN.RowTemplate.Height = 40
        Me.dgvSAN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSAN.Size = New System.Drawing.Size(305, 682)
        Me.dgvSAN.TabIndex = 31
        '
        'DataGridViewButtonColumn1
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn1.DefaultCellStyle = DataGridViewCellStyle26
        Me.DataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn1.HeaderText = "A"
        Me.DataGridViewButtonColumn1.MinimumWidth = 60
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.ReadOnly = True
        Me.DataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn1.Width = 70
        '
        'DataGridViewButtonColumn2
        '
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn2.DefaultCellStyle = DataGridViewCellStyle27
        Me.DataGridViewButtonColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn2.HeaderText = "B"
        Me.DataGridViewButtonColumn2.MinimumWidth = 60
        Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        Me.DataGridViewButtonColumn2.ReadOnly = True
        Me.DataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn2.Width = 70
        '
        'DataGridViewButtonColumn3
        '
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn3.DefaultCellStyle = DataGridViewCellStyle28
        Me.DataGridViewButtonColumn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn3.HeaderText = "C"
        Me.DataGridViewButtonColumn3.MinimumWidth = 60
        Me.DataGridViewButtonColumn3.Name = "DataGridViewButtonColumn3"
        Me.DataGridViewButtonColumn3.ReadOnly = True
        Me.DataGridViewButtonColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn3.Width = 70
        '
        'DataGridViewButtonColumn4
        '
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn4.DefaultCellStyle = DataGridViewCellStyle29
        Me.DataGridViewButtonColumn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn4.HeaderText = "D"
        Me.DataGridViewButtonColumn4.MinimumWidth = 60
        Me.DataGridViewButtonColumn4.Name = "DataGridViewButtonColumn4"
        Me.DataGridViewButtonColumn4.ReadOnly = True
        Me.DataGridViewButtonColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn4.Width = 70
        '
        'dgvSUK
        '
        Me.dgvSUK.AllowUserToAddRows = False
        Me.dgvSUK.AllowUserToDeleteRows = False
        Me.dgvSUK.AllowUserToResizeColumns = False
        Me.dgvSUK.AllowUserToResizeRows = False
        Me.dgvSUK.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvSUK.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSUK.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvSUK.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSUK.ColumnHeadersHeight = 4
        Me.dgvSUK.ColumnHeadersVisible = False
        Me.dgvSUK.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewButtonColumn5, Me.DataGridViewButtonColumn6, Me.DataGridViewButtonColumn7, Me.DataGridViewButtonColumn8})
        Me.dgvSUK.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle35.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSUK.DefaultCellStyle = DataGridViewCellStyle35
        Me.dgvSUK.EnableHeadersVisualStyles = False
        Me.dgvSUK.Location = New System.Drawing.Point(928, 6)
        Me.dgvSUK.MultiSelect = False
        Me.dgvSUK.Name = "dgvSUK"
        Me.dgvSUK.ReadOnly = True
        Me.dgvSUK.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSUK.RowHeadersVisible = False
        Me.dgvSUK.RowTemplate.Height = 40
        Me.dgvSUK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSUK.Size = New System.Drawing.Size(305, 682)
        Me.dgvSUK.TabIndex = 32
        '
        'DataGridViewButtonColumn5
        '
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn5.DefaultCellStyle = DataGridViewCellStyle31
        Me.DataGridViewButtonColumn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn5.HeaderText = "A"
        Me.DataGridViewButtonColumn5.MinimumWidth = 60
        Me.DataGridViewButtonColumn5.Name = "DataGridViewButtonColumn5"
        Me.DataGridViewButtonColumn5.ReadOnly = True
        Me.DataGridViewButtonColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn5.Width = 70
        '
        'DataGridViewButtonColumn6
        '
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn6.DefaultCellStyle = DataGridViewCellStyle32
        Me.DataGridViewButtonColumn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn6.HeaderText = "B"
        Me.DataGridViewButtonColumn6.MinimumWidth = 60
        Me.DataGridViewButtonColumn6.Name = "DataGridViewButtonColumn6"
        Me.DataGridViewButtonColumn6.ReadOnly = True
        Me.DataGridViewButtonColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn6.Width = 70
        '
        'DataGridViewButtonColumn7
        '
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn7.DefaultCellStyle = DataGridViewCellStyle33
        Me.DataGridViewButtonColumn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn7.HeaderText = "C"
        Me.DataGridViewButtonColumn7.MinimumWidth = 60
        Me.DataGridViewButtonColumn7.Name = "DataGridViewButtonColumn7"
        Me.DataGridViewButtonColumn7.ReadOnly = True
        Me.DataGridViewButtonColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn7.Width = 70
        '
        'DataGridViewButtonColumn8
        '
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn8.DefaultCellStyle = DataGridViewCellStyle34
        Me.DataGridViewButtonColumn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn8.HeaderText = "D"
        Me.DataGridViewButtonColumn8.MinimumWidth = 60
        Me.DataGridViewButtonColumn8.Name = "DataGridViewButtonColumn8"
        Me.DataGridViewButtonColumn8.ReadOnly = True
        Me.DataGridViewButtonColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn8.Width = 70
        '
        'dgvSHR
        '
        Me.dgvSHR.AllowUserToAddRows = False
        Me.dgvSHR.AllowUserToDeleteRows = False
        Me.dgvSHR.AllowUserToResizeColumns = False
        Me.dgvSHR.AllowUserToResizeRows = False
        Me.dgvSHR.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvSHR.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSHR.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvSHR.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSHR.ColumnHeadersHeight = 4
        Me.dgvSHR.ColumnHeadersVisible = False
        Me.dgvSHR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewButtonColumn9, Me.DataGridViewButtonColumn10, Me.DataGridViewButtonColumn11, Me.DataGridViewButtonColumn12})
        Me.dgvSHR.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle40.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle40.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSHR.DefaultCellStyle = DataGridViewCellStyle40
        Me.dgvSHR.EnableHeadersVisualStyles = False
        Me.dgvSHR.Location = New System.Drawing.Point(620, 6)
        Me.dgvSHR.MultiSelect = False
        Me.dgvSHR.Name = "dgvSHR"
        Me.dgvSHR.ReadOnly = True
        Me.dgvSHR.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSHR.RowHeadersVisible = False
        Me.dgvSHR.RowTemplate.Height = 40
        Me.dgvSHR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSHR.Size = New System.Drawing.Size(305, 682)
        Me.dgvSHR.TabIndex = 33
        '
        'DataGridViewButtonColumn9
        '
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn9.DefaultCellStyle = DataGridViewCellStyle36
        Me.DataGridViewButtonColumn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn9.HeaderText = "A"
        Me.DataGridViewButtonColumn9.MinimumWidth = 60
        Me.DataGridViewButtonColumn9.Name = "DataGridViewButtonColumn9"
        Me.DataGridViewButtonColumn9.ReadOnly = True
        Me.DataGridViewButtonColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn9.Width = 70
        '
        'DataGridViewButtonColumn10
        '
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn10.DefaultCellStyle = DataGridViewCellStyle37
        Me.DataGridViewButtonColumn10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn10.HeaderText = "B"
        Me.DataGridViewButtonColumn10.MinimumWidth = 60
        Me.DataGridViewButtonColumn10.Name = "DataGridViewButtonColumn10"
        Me.DataGridViewButtonColumn10.ReadOnly = True
        Me.DataGridViewButtonColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn10.Width = 70
        '
        'DataGridViewButtonColumn11
        '
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn11.DefaultCellStyle = DataGridViewCellStyle38
        Me.DataGridViewButtonColumn11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn11.HeaderText = "C"
        Me.DataGridViewButtonColumn11.MinimumWidth = 60
        Me.DataGridViewButtonColumn11.Name = "DataGridViewButtonColumn11"
        Me.DataGridViewButtonColumn11.ReadOnly = True
        Me.DataGridViewButtonColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn11.Width = 70
        '
        'DataGridViewButtonColumn12
        '
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn12.DefaultCellStyle = DataGridViewCellStyle39
        Me.DataGridViewButtonColumn12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonColumn12.HeaderText = "D"
        Me.DataGridViewButtonColumn12.MinimumWidth = 60
        Me.DataGridViewButtonColumn12.Name = "DataGridViewButtonColumn12"
        Me.DataGridViewButtonColumn12.ReadOnly = True
        Me.DataGridViewButtonColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonColumn12.Width = 70
        '
        'tbarOutstandingFrom
        '
        Me.tbarOutstandingFrom.LargeChange = 5000
        Me.tbarOutstandingFrom.Location = New System.Drawing.Point(129, 723)
        Me.tbarOutstandingFrom.Maximum = 200000
        Me.tbarOutstandingFrom.Minimum = -200000
        Me.tbarOutstandingFrom.Name = "tbarOutstandingFrom"
        Me.tbarOutstandingFrom.Size = New System.Drawing.Size(1104, 56)
        Me.tbarOutstandingFrom.SmallChange = 1000
        Me.tbarOutstandingFrom.TabIndex = 1
        Me.tbarOutstandingFrom.TickFrequency = 1000
        '
        'tbarOutstandingTo
        '
        Me.tbarOutstandingTo.LargeChange = 5000
        Me.tbarOutstandingTo.Location = New System.Drawing.Point(129, 783)
        Me.tbarOutstandingTo.Maximum = 200000
        Me.tbarOutstandingTo.Minimum = -200000
        Me.tbarOutstandingTo.Name = "tbarOutstandingTo"
        Me.tbarOutstandingTo.Size = New System.Drawing.Size(1104, 56)
        Me.tbarOutstandingTo.SmallChange = 1000
        Me.tbarOutstandingTo.TabIndex = 2
        Me.tbarOutstandingTo.TickFrequency = 1000
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(6, 757)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(40, 17)
        Me.lblFrom.TabIndex = 35
        Me.lblFrom.Text = "From"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(6, 817)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(25, 17)
        Me.lblTo.TabIndex = 36
        Me.lblTo.Text = "To"
        '
        'btnFilter
        '
        Me.btnFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnFilter.Location = New System.Drawing.Point(137, 838)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(82, 25)
        Me.btnFilter.TabIndex = 38
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'lblNet
        '
        Me.lblNet.BackColor = System.Drawing.Color.Black
        Me.lblNet.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNet.ForeColor = System.Drawing.Color.Red
        Me.lblNet.Location = New System.Drawing.Point(6, 706)
        Me.lblNet.Name = "lblNet"
        Me.lblNet.Size = New System.Drawing.Size(100, 22)
        Me.lblNet.TabIndex = 72
        Me.lblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 689)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 17)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Total"
        '
        'lblSap
        '
        Me.lblSap.BackColor = System.Drawing.Color.Black
        Me.lblSap.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSap.ForeColor = System.Drawing.Color.White
        Me.lblSap.Location = New System.Drawing.Point(134, 691)
        Me.lblSap.Name = "lblSap"
        Me.lblSap.Size = New System.Drawing.Size(100, 22)
        Me.lblSap.TabIndex = 74
        Me.lblSap.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSan
        '
        Me.lblSan.BackColor = System.Drawing.Color.Black
        Me.lblSan.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSan.ForeColor = System.Drawing.Color.White
        Me.lblSan.Location = New System.Drawing.Point(428, 691)
        Me.lblSan.Name = "lblSan"
        Me.lblSan.Size = New System.Drawing.Size(100, 22)
        Me.lblSan.TabIndex = 76
        Me.lblSan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblShr
        '
        Me.lblShr.BackColor = System.Drawing.Color.Black
        Me.lblShr.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShr.ForeColor = System.Drawing.Color.White
        Me.lblShr.Location = New System.Drawing.Point(755, 691)
        Me.lblShr.Name = "lblShr"
        Me.lblShr.Size = New System.Drawing.Size(100, 22)
        Me.lblShr.TabIndex = 78
        Me.lblShr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSuk
        '
        Me.lblSuk.BackColor = System.Drawing.Color.Black
        Me.lblSuk.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuk.ForeColor = System.Drawing.Color.White
        Me.lblSuk.Location = New System.Drawing.Point(1078, 691)
        Me.lblSuk.Name = "lblSuk"
        Me.lblSuk.Size = New System.Drawing.Size(100, 22)
        Me.lblSuk.TabIndex = 80
        Me.lblSuk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkCombineDuplexAmounts
        '
        Me.chkCombineDuplexAmounts.AutoSize = True
        Me.chkCombineDuplexAmounts.Checked = True
        Me.chkCombineDuplexAmounts.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCombineDuplexAmounts.Location = New System.Drawing.Point(515, 839)
        Me.chkCombineDuplexAmounts.Name = "chkCombineDuplexAmounts"
        Me.chkCombineDuplexAmounts.Size = New System.Drawing.Size(191, 21)
        Me.chkCombineDuplexAmounts.TabIndex = 81
        Me.chkCombineDuplexAmounts.Text = "Combine Duplex Amounts"
        Me.chkCombineDuplexAmounts.UseVisualStyleBackColor = True
        '
        'btnFilterToADate
        '
        Me.btnFilterToADate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnFilterToADate.Location = New System.Drawing.Point(225, 838)
        Me.btnFilterToADate.Name = "btnFilterToADate"
        Me.btnFilterToADate.Size = New System.Drawing.Size(186, 25)
        Me.btnFilterToADate.TabIndex = 82
        Me.btnFilterToADate.Text = "Filter Upto A Date"
        Me.btnFilterToADate.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox2.Controls.Add(Me.optBoth)
        Me.GroupBox2.Controls.Add(Me.optBGF)
        Me.GroupBox2.Controls.Add(Me.optAssociation)
        Me.GroupBox2.Location = New System.Drawing.Point(727, 817)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(401, 63)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'optBoth
        '
        Me.optBoth.AutoSize = True
        Me.optBoth.Checked = True
        Me.optBoth.Location = New System.Drawing.Point(273, 21)
        Me.optBoth.Name = "optBoth"
        Me.optBoth.Size = New System.Drawing.Size(58, 21)
        Me.optBoth.TabIndex = 2
        Me.optBoth.TabStop = True
        Me.optBoth.Text = "Both"
        Me.optBoth.UseVisualStyleBackColor = True
        '
        'optBGF
        '
        Me.optBGF.AutoSize = True
        Me.optBGF.Location = New System.Drawing.Point(168, 21)
        Me.optBGF.Name = "optBGF"
        Me.optBGF.Size = New System.Drawing.Size(90, 21)
        Me.optBGF.TabIndex = 1
        Me.optBGF.Text = "Only BGF"
        Me.optBGF.UseVisualStyleBackColor = True
        '
        'optAssociation
        '
        Me.optAssociation.AutoSize = True
        Me.optAssociation.Location = New System.Drawing.Point(16, 21)
        Me.optAssociation.Name = "optAssociation"
        Me.optAssociation.Size = New System.Drawing.Size(134, 21)
        Me.optAssociation.TabIndex = 0
        Me.optAssociation.Text = "Only Association"
        Me.optAssociation.UseVisualStyleBackColor = True
        '
        'frmManageFlatAndOwnerDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1242, 865)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnFilterToADate)
        Me.Controls.Add(Me.chkCombineDuplexAmounts)
        Me.Controls.Add(Me.lblSuk)
        Me.Controls.Add(Me.lblShr)
        Me.Controls.Add(Me.lblSan)
        Me.Controls.Add(Me.lblSap)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNet)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.tbarOutstandingTo)
        Me.Controls.Add(Me.tbarOutstandingFrom)
        Me.Controls.Add(Me.dgvSAP)
        Me.Controls.Add(Me.dgvSHR)
        Me.Controls.Add(Me.dgvSUK)
        Me.Controls.Add(Me.dgvSAN)
        Me.Name = "frmManageFlatAndOwnerDetails"
        Me.Text = "Manage All"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSAN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSUK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSHR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarOutstandingFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarOutstandingTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvSAP As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSAN As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSUK As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSHR As System.Windows.Forms.DataGridView
    Friend WithEvents tbarOutstandingFrom As System.Windows.Forms.TrackBar
    Friend WithEvents tbarOutstandingTo As System.Windows.Forms.TrackBar
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents A As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents B As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents C As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents D As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn3 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn4 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn5 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn6 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn7 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn8 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn9 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn10 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn11 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn12 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lblNet As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSap As System.Windows.Forms.Label
    Friend WithEvents lblSan As System.Windows.Forms.Label
    Friend WithEvents lblShr As System.Windows.Forms.Label
    Friend WithEvents lblSuk As System.Windows.Forms.Label
    Friend WithEvents chkCombineDuplexAmounts As System.Windows.Forms.CheckBox
    Friend WithEvents btnFilterToADate As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optBoth As System.Windows.Forms.RadioButton
    Friend WithEvents optBGF As System.Windows.Forms.RadioButton
    Friend WithEvents optAssociation As System.Windows.Forms.RadioButton
End Class
