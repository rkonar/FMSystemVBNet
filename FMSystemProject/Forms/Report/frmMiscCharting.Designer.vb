<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMiscCharting
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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Me.Chart_1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.cboReportType = New System.Windows.Forms.ComboBox()
        Me.lvwExclude = New System.Windows.Forms.ListView()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnSetDates = New System.Windows.Forms.Button()
        Me.txtFromDate = New System.Windows.Forms.TextBox()
        Me.txtToDate = New System.Windows.Forms.TextBox()
        CType(Me.Chart_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart_1
        '
        ChartArea3.Name = "ChartArea1"
        Me.Chart_1.ChartAreas.Add(ChartArea3)
        Me.Chart_1.Location = New System.Drawing.Point(12, 133)
        Me.Chart_1.Margin = New System.Windows.Forms.Padding(0)
        Me.Chart_1.Name = "Chart_1"
        Me.Chart_1.Size = New System.Drawing.Size(1584, 905)
        Me.Chart_1.TabIndex = 0
        Me.Chart_1.Text = "Chart1"
        '
        'btnShow
        '
        Me.btnShow.AutoSize = True
        Me.btnShow.Location = New System.Drawing.Point(12, 101)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(80, 27)
        Me.btnShow.TabIndex = 122
        Me.btnShow.Text = "Show"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'cboReportType
        '
        Me.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportType.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReportType.ForeColor = System.Drawing.Color.Blue
        Me.cboReportType.FormattingEnabled = True
        Me.cboReportType.Location = New System.Drawing.Point(12, 7)
        Me.cboReportType.Name = "cboReportType"
        Me.cboReportType.Size = New System.Drawing.Size(252, 24)
        Me.cboReportType.TabIndex = 123
        '
        'lvwExclude
        '
        Me.lvwExclude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwExclude.CheckBoxes = True
        Me.lvwExclude.ForeColor = System.Drawing.Color.Red
        Me.lvwExclude.GridLines = True
        Me.lvwExclude.Location = New System.Drawing.Point(270, 7)
        Me.lvwExclude.Name = "lvwExclude"
        Me.lvwExclude.Size = New System.Drawing.Size(1326, 123)
        Me.lvwExclude.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwExclude.TabIndex = 125
        Me.lvwExclude.UseCompatibleStateImageBehavior = False
        Me.lvwExclude.View = System.Windows.Forms.View.List
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(184, 70)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(80, 27)
        Me.btnSelectAll.TabIndex = 126
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnClearAll
        '
        Me.btnClearAll.Location = New System.Drawing.Point(184, 101)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(80, 27)
        Me.btnClearAll.TabIndex = 127
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'btnSetDates
        '
        Me.btnSetDates.AutoSize = True
        Me.btnSetDates.Location = New System.Drawing.Point(12, 37)
        Me.btnSetDates.Name = "btnSetDates"
        Me.btnSetDates.Size = New System.Drawing.Size(80, 27)
        Me.btnSetDates.TabIndex = 128
        Me.btnSetDates.Text = "Set Dates"
        Me.btnSetDates.UseVisualStyleBackColor = True
        '
        'txtFromDate
        '
        Me.txtFromDate.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFromDate.ForeColor = System.Drawing.Color.Blue
        Me.txtFromDate.Location = New System.Drawing.Point(98, 39)
        Me.txtFromDate.Name = "txtFromDate"
        Me.txtFromDate.ReadOnly = True
        Me.txtFromDate.Size = New System.Drawing.Size(80, 22)
        Me.txtFromDate.TabIndex = 129
        '
        'txtToDate
        '
        Me.txtToDate.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToDate.ForeColor = System.Drawing.Color.Blue
        Me.txtToDate.Location = New System.Drawing.Point(184, 39)
        Me.txtToDate.Name = "txtToDate"
        Me.txtToDate.ReadOnly = True
        Me.txtToDate.Size = New System.Drawing.Size(80, 22)
        Me.txtToDate.TabIndex = 130
        '
        'frmMiscCharting
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1608, 1047)
        Me.Controls.Add(Me.txtToDate)
        Me.Controls.Add(Me.txtFromDate)
        Me.Controls.Add(Me.btnSetDates)
        Me.Controls.Add(Me.btnClearAll)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.lvwExclude)
        Me.Controls.Add(Me.cboReportType)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.Chart_1)
        Me.Name = "frmMiscCharting"
        Me.Text = "Miscelleneous Charting"
        CType(Me.Chart_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart_1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents cboReportType As System.Windows.Forms.ComboBox
    Friend WithEvents lvwExclude As System.Windows.Forms.ListView
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnSetDates As System.Windows.Forms.Button
    Friend WithEvents txtFromDate As System.Windows.Forms.TextBox
    Friend WithEvents txtToDate As System.Windows.Forms.TextBox
End Class
