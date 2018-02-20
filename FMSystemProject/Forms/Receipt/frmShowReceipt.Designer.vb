<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowReceipt
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
        Me.txtReceiptAmount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblInstrumentDate = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtInstrumentNo = New System.Windows.Forms.TextBox()
        Me.lblInstrumentNo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtReceiptNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNarration = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtInstrumentDate = New System.Windows.Forms.TextBox()
        Me.txtReceiptDate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFlat = New System.Windows.Forms.TextBox()
        Me.txtInstrumentType = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSaveViewReceiptImage = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtReceiptAmount
        '
        Me.txtReceiptAmount.Location = New System.Drawing.Point(131, 65)
        Me.txtReceiptAmount.MaxLength = 12
        Me.txtReceiptAmount.Name = "txtReceiptAmount"
        Me.txtReceiptAmount.ReadOnly = True
        Me.txtReceiptAmount.Size = New System.Drawing.Size(108, 22)
        Me.txtReceiptAmount.TabIndex = 72
        Me.txtReceiptAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 17)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Receipt Amount"
        '
        'lblInstrumentDate
        '
        Me.lblInstrumentDate.AutoSize = True
        Me.lblInstrumentDate.Location = New System.Drawing.Point(1027, 12)
        Me.lblInstrumentDate.Name = "lblInstrumentDate"
        Me.lblInstrumentDate.Size = New System.Drawing.Size(108, 17)
        Me.lblInstrumentDate.TabIndex = 81
        Me.lblInstrumentDate.Text = "Instrument Date"
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(606, 9)
        Me.txtBankName.MaxLength = 20
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.ReadOnly = True
        Me.txtBankName.Size = New System.Drawing.Size(157, 22)
        Me.txtBankName.TabIndex = 69
        Me.txtBankName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(521, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 17)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "Bank Name"
        '
        'txtInstrumentNo
        '
        Me.txtInstrumentNo.Location = New System.Drawing.Point(880, 9)
        Me.txtInstrumentNo.MaxLength = 50
        Me.txtInstrumentNo.Name = "txtInstrumentNo"
        Me.txtInstrumentNo.ReadOnly = True
        Me.txtInstrumentNo.Size = New System.Drawing.Size(121, 22)
        Me.txtInstrumentNo.TabIndex = 70
        Me.txtInstrumentNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblInstrumentNo
        '
        Me.lblInstrumentNo.AutoSize = True
        Me.lblInstrumentNo.Location = New System.Drawing.Point(778, 12)
        Me.lblInstrumentNo.Name = "lblInstrumentNo"
        Me.lblInstrumentNo.Size = New System.Drawing.Size(96, 17)
        Me.lblInstrumentNo.TabIndex = 79
        Me.lblInstrumentNo.Text = "Instrument No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(287, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 17)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Receipt Date"
        '
        'txtReceiptNo
        '
        Me.txtReceiptNo.Location = New System.Drawing.Point(131, 9)
        Me.txtReceiptNo.MaxLength = 20
        Me.txtReceiptNo.Name = "txtReceiptNo"
        Me.txtReceiptNo.ReadOnly = True
        Me.txtReceiptNo.Size = New System.Drawing.Size(121, 22)
        Me.txtReceiptNo.TabIndex = 67
        Me.txtReceiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Receipt No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(533, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Narration"
        '
        'txtNarration
        '
        Me.txtNarration.Location = New System.Drawing.Point(606, 55)
        Me.txtNarration.MaxLength = 255
        Me.txtNarration.Multiline = True
        Me.txtNarration.Name = "txtNarration"
        Me.txtNarration.ReadOnly = True
        Me.txtNarration.Size = New System.Drawing.Size(655, 50)
        Me.txtNarration.TabIndex = 74
        Me.txtNarration.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(278, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 17)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Instrument Type"
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.Location = New System.Drawing.Point(739, 123)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 27)
        Me.btnClose.TabIndex = 88
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtInstrumentDate
        '
        Me.txtInstrumentDate.Location = New System.Drawing.Point(1141, 9)
        Me.txtInstrumentDate.MaxLength = 20
        Me.txtInstrumentDate.Name = "txtInstrumentDate"
        Me.txtInstrumentDate.ReadOnly = True
        Me.txtInstrumentDate.Size = New System.Drawing.Size(94, 22)
        Me.txtInstrumentDate.TabIndex = 89
        Me.txtInstrumentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtReceiptDate
        '
        Me.txtReceiptDate.Location = New System.Drawing.Point(393, 63)
        Me.txtReceiptDate.MaxLength = 12
        Me.txtReceiptDate.Name = "txtReceiptDate"
        Me.txtReceiptDate.ReadOnly = True
        Me.txtReceiptDate.Size = New System.Drawing.Size(97, 22)
        Me.txtReceiptDate.TabIndex = 90
        Me.txtReceiptDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(94, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 17)
        Me.Label10.TabIndex = 92
        Me.Label10.Text = "Flat"
        '
        'txtFlat
        '
        Me.txtFlat.Location = New System.Drawing.Point(131, 111)
        Me.txtFlat.Name = "txtFlat"
        Me.txtFlat.ReadOnly = True
        Me.txtFlat.Size = New System.Drawing.Size(71, 22)
        Me.txtFlat.TabIndex = 91
        Me.txtFlat.TabStop = False
        Me.txtFlat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtInstrumentType
        '
        Me.txtInstrumentType.Location = New System.Drawing.Point(393, 9)
        Me.txtInstrumentType.MaxLength = 12
        Me.txtInstrumentType.Name = "txtInstrumentType"
        Me.txtInstrumentType.ReadOnly = True
        Me.txtInstrumentType.Size = New System.Drawing.Size(97, 22)
        Me.txtInstrumentType.TabIndex = 93
        Me.txtInstrumentType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(452, 123)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 27)
        Me.btnSave.TabIndex = 95
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.AutoSize = True
        Me.btnEdit.Location = New System.Drawing.Point(338, 123)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 27)
        Me.btnEdit.TabIndex = 94
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSaveViewReceiptImage
        '
        Me.btnSaveViewReceiptImage.AutoSize = True
        Me.btnSaveViewReceiptImage.Location = New System.Drawing.Point(547, 123)
        Me.btnSaveViewReceiptImage.Name = "btnSaveViewReceiptImage"
        Me.btnSaveViewReceiptImage.Size = New System.Drawing.Size(177, 27)
        Me.btnSaveViewReceiptImage.TabIndex = 120
        Me.btnSaveViewReceiptImage.Text = "Save/View Receipt Image"
        Me.btnSaveViewReceiptImage.UseVisualStyleBackColor = True
        '
        'frmShowReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1274, 167)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSaveViewReceiptImage)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.txtInstrumentType)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtFlat)
        Me.Controls.Add(Me.txtReceiptDate)
        Me.Controls.Add(Me.txtInstrumentDate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtReceiptAmount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblInstrumentDate)
        Me.Controls.Add(Me.txtBankName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtInstrumentNo)
        Me.Controls.Add(Me.lblInstrumentNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtReceiptNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNarration)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmShowReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Show Receipt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtReceiptAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblInstrumentDate As System.Windows.Forms.Label
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtInstrumentNo As System.Windows.Forms.TextBox
    Friend WithEvents lblInstrumentNo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtReceiptNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNarration As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtInstrumentDate As System.Windows.Forms.TextBox
    Friend WithEvents txtReceiptDate As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtFlat As System.Windows.Forms.TextBox
    Friend WithEvents txtInstrumentType As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnSaveViewReceiptImage As System.Windows.Forms.Button
End Class
