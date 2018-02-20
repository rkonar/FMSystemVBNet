<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowBill
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFlat = New System.Windows.Forms.TextBox()
        Me.txtBillPeriod = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBillNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBillDate = New System.Windows.Forms.TextBox()
        Me.txtBillType = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtDueDate = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBillAmount = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(368, 100)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 87
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(729, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 17)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "Flat"
        '
        'txtFlat
        '
        Me.txtFlat.Location = New System.Drawing.Point(766, 18)
        Me.txtFlat.Name = "txtFlat"
        Me.txtFlat.ReadOnly = True
        Me.txtFlat.Size = New System.Drawing.Size(71, 22)
        Me.txtFlat.TabIndex = 70
        Me.txtFlat.TabStop = False
        Me.txtFlat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBillPeriod
        '
        Me.txtBillPeriod.Location = New System.Drawing.Point(113, 56)
        Me.txtBillPeriod.Name = "txtBillPeriod"
        Me.txtBillPeriod.ReadOnly = True
        Me.txtBillPeriod.Size = New System.Drawing.Size(179, 22)
        Me.txtBillPeriod.TabIndex = 69
        Me.txtBillPeriod.TabStop = False
        Me.txtBillPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 17)
        Me.Label9.TabIndex = 68
        Me.Label9.Text = "Bill Period"
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(113, 18)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.ReadOnly = True
        Me.txtBillNo.Size = New System.Drawing.Size(178, 22)
        Me.txtBillNo.TabIndex = 67
        Me.txtBillNo.TabStop = False
        Me.txtBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 17)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Bill No"
        '
        'txtBillDate
        '
        Me.txtBillDate.Location = New System.Drawing.Point(395, 18)
        Me.txtBillDate.Name = "txtBillDate"
        Me.txtBillDate.ReadOnly = True
        Me.txtBillDate.Size = New System.Drawing.Size(95, 22)
        Me.txtBillDate.TabIndex = 65
        Me.txtBillDate.TabStop = False
        Me.txtBillDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBillType
        '
        Me.txtBillType.Location = New System.Drawing.Point(592, 56)
        Me.txtBillType.Name = "txtBillType"
        Me.txtBillType.ReadOnly = True
        Me.txtBillType.Size = New System.Drawing.Size(245, 22)
        Me.txtBillType.TabIndex = 64
        Me.txtBillType.TabStop = False
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(320, 59)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(68, 17)
        Me.lblEmail.TabIndex = 61
        Me.lblEmail.Text = "Due Date"
        '
        'txtDueDate
        '
        Me.txtDueDate.Location = New System.Drawing.Point(395, 56)
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.ReadOnly = True
        Me.txtDueDate.Size = New System.Drawing.Size(95, 22)
        Me.txtDueDate.TabIndex = 58
        Me.txtDueDate.TabStop = False
        Me.txtDueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(508, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 17)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Bill Amount"
        '
        'txtBillAmount
        '
        Me.txtBillAmount.Location = New System.Drawing.Point(592, 18)
        Me.txtBillAmount.Name = "txtBillAmount"
        Me.txtBillAmount.ReadOnly = True
        Me.txtBillAmount.Size = New System.Drawing.Size(117, 22)
        Me.txtBillAmount.TabIndex = 55
        Me.txtBillAmount.TabStop = False
        Me.txtBillAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(320, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 17)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Bill Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(508, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Bill Type"
        '
        'frmShowBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 135)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtFlat)
        Me.Controls.Add(Me.txtBillPeriod)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtBillNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtBillDate)
        Me.Controls.Add(Me.txtBillType)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtDueDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBillAmount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmShowBill"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Show Bill"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtFlat As System.Windows.Forms.TextBox
    Friend WithEvents txtBillPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBillDate As System.Windows.Forms.TextBox
    Friend WithEvents txtBillType As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBillAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
