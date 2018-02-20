<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCharting
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart_SAP = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart_SAN = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart_SHR = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart_SUK = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.txtCutOffAmount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnShow = New System.Windows.Forms.Button()
        CType(Me.Chart_SAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart_SAN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart_SHR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart_SUK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart_SAP
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart_SAP.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart_SAP.Legends.Add(Legend1)
        Me.Chart_SAP.Location = New System.Drawing.Point(12, 37)
        Me.Chart_SAP.Name = "Chart_SAP"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart_SAP.Series.Add(Series1)
        Me.Chart_SAP.Size = New System.Drawing.Size(1218, 201)
        Me.Chart_SAP.TabIndex = 0
        Me.Chart_SAP.Text = "Chart1"
        '
        'Chart_SAN
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart_SAN.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart_SAN.Legends.Add(Legend2)
        Me.Chart_SAN.Location = New System.Drawing.Point(12, 244)
        Me.Chart_SAN.Name = "Chart_SAN"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart_SAN.Series.Add(Series2)
        Me.Chart_SAN.Size = New System.Drawing.Size(1218, 201)
        Me.Chart_SAN.TabIndex = 1
        Me.Chart_SAN.Text = "Chart1"
        '
        'Chart_SHR
        '
        ChartArea3.Name = "ChartArea1"
        Me.Chart_SHR.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.Chart_SHR.Legends.Add(Legend3)
        Me.Chart_SHR.Location = New System.Drawing.Point(12, 451)
        Me.Chart_SHR.Name = "Chart_SHR"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.Chart_SHR.Series.Add(Series3)
        Me.Chart_SHR.Size = New System.Drawing.Size(1218, 201)
        Me.Chart_SHR.TabIndex = 2
        Me.Chart_SHR.Text = "Chart1"
        '
        'Chart_SUK
        '
        ChartArea4.Name = "ChartArea1"
        Me.Chart_SUK.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Me.Chart_SUK.Legends.Add(Legend4)
        Me.Chart_SUK.Location = New System.Drawing.Point(12, 658)
        Me.Chart_SUK.Name = "Chart_SUK"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.Chart_SUK.Series.Add(Series4)
        Me.Chart_SUK.Size = New System.Drawing.Size(1218, 201)
        Me.Chart_SUK.TabIndex = 3
        Me.Chart_SUK.Text = "Chart1"
        '
        'txtCutOffAmount
        '
        Me.txtCutOffAmount.Location = New System.Drawing.Point(70, 6)
        Me.txtCutOffAmount.MaxLength = 12
        Me.txtCutOffAmount.Name = "txtCutOffAmount"
        Me.txtCutOffAmount.Size = New System.Drawing.Size(95, 22)
        Me.txtCutOffAmount.TabIndex = 67
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 17)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "CutOff"
        '
        'btnShow
        '
        Me.btnShow.AutoSize = True
        Me.btnShow.Location = New System.Drawing.Point(171, 4)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(75, 27)
        Me.btnShow.TabIndex = 122
        Me.btnShow.Text = "Show"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'frmCharting
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1242, 865)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.txtCutOffAmount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Chart_SUK)
        Me.Controls.Add(Me.Chart_SHR)
        Me.Controls.Add(Me.Chart_SAN)
        Me.Controls.Add(Me.Chart_SAP)
        Me.Name = "frmCharting"
        Me.Text = "Association & BGF Due Status"
        CType(Me.Chart_SAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart_SAN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart_SHR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart_SUK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart_SAP As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart_SAN As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart_SHR As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart_SUK As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents txtCutOffAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
End Class
