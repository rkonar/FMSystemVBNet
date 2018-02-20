<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageSysParams
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageSysParams))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnUndo = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.sysTblid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sysEncrypted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sysParamname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sysParamvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sysRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sysOptypeflag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sysRowstatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sysCb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sysCdt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sysLub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sysLudt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAddRow = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnClone = New System.Windows.Forms.Button()
        Me.btnShowGraph = New System.Windows.Forms.Button()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUndo
        '
        Me.btnUndo.AutoSize = True
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"), System.Drawing.Image)
        Me.btnUndo.Location = New System.Drawing.Point(172, 6)
        Me.btnUndo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(22, 22)
        Me.btnUndo.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnUndo, "Undo")
        Me.btnUndo.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.AutoSize = True
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(4, 6)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(22, 22)
        Me.btnRefresh.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.btnRefresh, "Refresh")
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sysTblid, Me.sysEncrypted, Me.sysParamname, Me.sysParamvalue, Me.sysRemarks, Me.sysOptypeflag, Me.sysRowstatus, Me.sysCb, Me.sysCdt, Me.sysLub, Me.sysLudt})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.Location = New System.Drawing.Point(6, 48)
        Me.dgv.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowTemplate.Height = 24
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv.Size = New System.Drawing.Size(1269, 630)
        Me.dgv.TabIndex = 18
        '
        'sysTblid
        '
        Me.sysTblid.HeaderText = "tblid"
        Me.sysTblid.Name = "sysTblid"
        Me.sysTblid.Width = 5
        '
        'sysEncrypted
        '
        Me.sysEncrypted.HeaderText = "Encrypted"
        Me.sysEncrypted.Name = "sysEncrypted"
        Me.sysEncrypted.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sysEncrypted.Width = 150
        '
        'sysParamname
        '
        Me.sysParamname.HeaderText = "Param Name"
        Me.sysParamname.Name = "sysParamname"
        Me.sysParamname.Width = 200
        '
        'sysParamvalue
        '
        Me.sysParamvalue.HeaderText = "Param Value"
        Me.sysParamvalue.Name = "sysParamvalue"
        Me.sysParamvalue.Width = 450
        '
        'sysRemarks
        '
        Me.sysRemarks.HeaderText = "Remarks"
        Me.sysRemarks.Name = "sysRemarks"
        Me.sysRemarks.Width = 200
        '
        'sysOptypeflag
        '
        Me.sysOptypeflag.HeaderText = "Operation Type Flag"
        Me.sysOptypeflag.Name = "sysOptypeflag"
        Me.sysOptypeflag.Visible = False
        '
        'sysRowstatus
        '
        Me.sysRowstatus.HeaderText = "RS"
        Me.sysRowstatus.Name = "sysRowstatus"
        Me.sysRowstatus.Visible = False
        Me.sysRowstatus.Width = 20
        '
        'sysCb
        '
        Me.sysCb.HeaderText = "CB"
        Me.sysCb.Name = "sysCb"
        Me.sysCb.Visible = False
        Me.sysCb.Width = 50
        '
        'sysCdt
        '
        Me.sysCdt.HeaderText = "CDT"
        Me.sysCdt.Name = "sysCdt"
        Me.sysCdt.Visible = False
        Me.sysCdt.Width = 70
        '
        'sysLub
        '
        Me.sysLub.HeaderText = "LUB"
        Me.sysLub.Name = "sysLub"
        '
        'sysLudt
        '
        Me.sysLudt.HeaderText = "LUDT"
        Me.sysLudt.Name = "sysLudt"
        Me.sysLudt.Width = 120
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(200, 6)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(22, 22)
        Me.btnSave.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.btnSave, "Save")
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.AutoSize = True
        Me.btnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.Location = New System.Drawing.Point(116, 6)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(22, 22)
        Me.btnUpdate.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.btnUpdate, "Edit")
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAddRow
        '
        Me.btnAddRow.AutoSize = True
        Me.btnAddRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAddRow.Image = CType(resources.GetObject("btnAddRow.Image"), System.Drawing.Image)
        Me.btnAddRow.Location = New System.Drawing.Point(60, 6)
        Me.btnAddRow.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Size = New System.Drawing.Size(22, 22)
        Me.btnAddRow.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.btnAddRow, "Add")
        Me.btnAddRow.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.AutoSize = True
        Me.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(144, 6)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(22, 22)
        Me.btnDelete.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnDelete, "Delete")
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnQuery)
        Me.Panel1.Controls.Add(Me.btnClone)
        Me.Panel1.Controls.Add(Me.btnShowGraph)
        Me.Panel1.Controls.Add(Me.btnExportToExcel)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnAddRow)
        Me.Panel1.Controls.Add(Me.btnUpdate)
        Me.Panel1.Controls.Add(Me.btnUndo)
        Me.Panel1.Location = New System.Drawing.Point(6, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(289, 33)
        Me.Panel1.TabIndex = 157
        '
        'btnQuery
        '
        Me.btnQuery.AutoSize = True
        Me.btnQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Location = New System.Drawing.Point(32, 6)
        Me.btnQuery.Margin = New System.Windows.Forms.Padding(4)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(22, 22)
        Me.btnQuery.TabIndex = 23
        Me.ToolTip1.SetToolTip(Me.btnQuery, "Query")
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnClone
        '
        Me.btnClone.AutoSize = True
        Me.btnClone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClone.Image = CType(resources.GetObject("btnClone.Image"), System.Drawing.Image)
        Me.btnClone.Location = New System.Drawing.Point(88, 5)
        Me.btnClone.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClone.Name = "btnClone"
        Me.btnClone.Size = New System.Drawing.Size(22, 22)
        Me.btnClone.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.btnClone, "Clone")
        Me.btnClone.UseVisualStyleBackColor = True
        '
        'btnShowGraph
        '
        Me.btnShowGraph.AutoSize = True
        Me.btnShowGraph.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnShowGraph.Image = CType(resources.GetObject("btnShowGraph.Image"), System.Drawing.Image)
        Me.btnShowGraph.Location = New System.Drawing.Point(256, 6)
        Me.btnShowGraph.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowGraph.Name = "btnShowGraph"
        Me.btnShowGraph.Size = New System.Drawing.Size(22, 22)
        Me.btnShowGraph.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.btnShowGraph, "Show Graph")
        Me.btnShowGraph.UseVisualStyleBackColor = True
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.AutoSize = True
        Me.btnExportToExcel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.Location = New System.Drawing.Point(228, 6)
        Me.btnExportToExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(22, 22)
        Me.btnExportToExcel.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.btnExportToExcel, "Export To Excel")
        Me.btnExportToExcel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.AutoSize = True
        Me.Button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1253, 13)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 22)
        Me.Button1.TabIndex = 24
        Me.ToolTip1.SetToolTip(Me.Button1, "Edit")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmManageSysParams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1284, 687)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmManageSysParams"
        Me.Text = "Manage System Params"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnAddRow As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUndo As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnClone As System.Windows.Forms.Button
    Friend WithEvents btnShowGraph As System.Windows.Forms.Button
    Friend WithEvents btnExportToExcel As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents sysTblid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sysEncrypted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sysParamname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sysParamvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sysRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sysOptypeflag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sysRowstatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sysCb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sysCdt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sysLub As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sysLudt As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
