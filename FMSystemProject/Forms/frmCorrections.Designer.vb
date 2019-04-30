<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCorrections
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCorrectReceiptAmount = New System.Windows.Forms.Button()
        Me.txtReceiptAmountNew = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboReceiptNo = New System.Windows.Forms.ComboBox()
        Me.btnSaveViewReceiptImage = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.txtInstrumentType = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFlat = New System.Windows.Forms.TextBox()
        Me.txtReceiptDate = New System.Windows.Forms.TextBox()
        Me.txtInstrumentDate = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtReceiptAmount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblInstrumentDate = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtInstrumentNo = New System.Windows.Forms.TextBox()
        Me.lblInstrumentNo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNarration = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkReconciled = New System.Windows.Forms.CheckBox()
        Me.txtrefgid = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtgid = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblFinYear = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboFinYear = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblFinYear)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtrefgid)
        Me.GroupBox1.Controls.Add(Me.cboFinYear)
        Me.GroupBox1.Controls.Add(Me.chkReconciled)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.btnCorrectReceiptAmount)
        Me.GroupBox1.Controls.Add(Me.txtgid)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtReceiptAmountNew)
        Me.GroupBox1.Controls.Add(Me.txtNarration)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblInstrumentNo)
        Me.GroupBox1.Controls.Add(Me.cboReceiptNo)
        Me.GroupBox1.Controls.Add(Me.txtInstrumentNo)
        Me.GroupBox1.Controls.Add(Me.txtInstrumentType)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtBankName)
        Me.GroupBox1.Controls.Add(Me.txtFlat)
        Me.GroupBox1.Controls.Add(Me.lblInstrumentDate)
        Me.GroupBox1.Controls.Add(Me.txtReceiptDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtInstrumentDate)
        Me.GroupBox1.Controls.Add(Me.txtReceiptAmount)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1219, 201)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Receipt - Correct Amount"
        '
        'btnCorrectReceiptAmount
        '
        Me.btnCorrectReceiptAmount.AutoSize = True
        Me.btnCorrectReceiptAmount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCorrectReceiptAmount.Location = New System.Drawing.Point(360, 172)
        Me.btnCorrectReceiptAmount.Name = "btnCorrectReceiptAmount"
        Me.btnCorrectReceiptAmount.Size = New System.Drawing.Size(130, 23)
        Me.btnCorrectReceiptAmount.TabIndex = 10
        Me.btnCorrectReceiptAmount.Text = "Correct Receipt Amount"
        Me.btnCorrectReceiptAmount.UseVisualStyleBackColor = True
        '
        'txtReceiptAmountNew
        '
        Me.txtReceiptAmountNew.Location = New System.Drawing.Point(242, 173)
        Me.txtReceiptAmountNew.MaxLength = 12
        Me.txtReceiptAmountNew.Name = "txtReceiptAmountNew"
        Me.txtReceiptAmountNew.Size = New System.Drawing.Size(95, 20)
        Me.txtReceiptAmountNew.TabIndex = 153
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(168, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 154
        Me.Label1.Text = "New Amount"
        '
        'cboReceiptNo
        '
        Me.cboReceiptNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReceiptNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboReceiptNo.FormattingEnabled = True
        Me.cboReceiptNo.Location = New System.Drawing.Point(456, 19)
        Me.cboReceiptNo.Name = "cboReceiptNo"
        Me.cboReceiptNo.Size = New System.Drawing.Size(104, 21)
        Me.cboReceiptNo.TabIndex = 152
        '
        'btnSaveViewReceiptImage
        '
        Me.btnSaveViewReceiptImage.AutoSize = True
        Me.btnSaveViewReceiptImage.Location = New System.Drawing.Point(787, 236)
        Me.btnSaveViewReceiptImage.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSaveViewReceiptImage.Name = "btnSaveViewReceiptImage"
        Me.btnSaveViewReceiptImage.Size = New System.Drawing.Size(142, 23)
        Me.btnSaveViewReceiptImage.TabIndex = 142
        Me.btnSaveViewReceiptImage.Text = "Save/View Receipt Image"
        Me.btnSaveViewReceiptImage.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(1075, 236)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 23)
        Me.btnSave.TabIndex = 141
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.AutoSize = True
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(1015, 236)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(56, 23)
        Me.btnEdit.TabIndex = 140
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'txtInstrumentType
        '
        Me.txtInstrumentType.Location = New System.Drawing.Point(96, 56)
        Me.txtInstrumentType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInstrumentType.MaxLength = 12
        Me.txtInstrumentType.Name = "txtInstrumentType"
        Me.txtInstrumentType.ReadOnly = True
        Me.txtInstrumentType.Size = New System.Drawing.Size(74, 20)
        Me.txtInstrumentType.TabIndex = 139
        Me.txtInstrumentType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(72, 142)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 138
        Me.Label10.Text = "Flat"
        '
        'txtFlat
        '
        Me.txtFlat.Location = New System.Drawing.Point(100, 139)
        Me.txtFlat.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFlat.Name = "txtFlat"
        Me.txtFlat.ReadOnly = True
        Me.txtFlat.Size = New System.Drawing.Size(54, 20)
        Me.txtFlat.TabIndex = 137
        Me.txtFlat.TabStop = False
        Me.txtFlat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtReceiptDate
        '
        Me.txtReceiptDate.Location = New System.Drawing.Point(297, 100)
        Me.txtReceiptDate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReceiptDate.MaxLength = 12
        Me.txtReceiptDate.Name = "txtReceiptDate"
        Me.txtReceiptDate.ReadOnly = True
        Me.txtReceiptDate.Size = New System.Drawing.Size(74, 20)
        Me.txtReceiptDate.TabIndex = 136
        Me.txtReceiptDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtInstrumentDate
        '
        Me.txtInstrumentDate.Location = New System.Drawing.Point(657, 56)
        Me.txtInstrumentDate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInstrumentDate.MaxLength = 20
        Me.txtInstrumentDate.Name = "txtInstrumentDate"
        Me.txtInstrumentDate.ReadOnly = True
        Me.txtInstrumentDate.Size = New System.Drawing.Size(72, 20)
        Me.txtInstrumentDate.TabIndex = 135
        Me.txtInstrumentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.Location = New System.Drawing.Point(940, 236)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 134
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtReceiptAmount
        '
        Me.txtReceiptAmount.Location = New System.Drawing.Point(100, 102)
        Me.txtReceiptAmount.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReceiptAmount.MaxLength = 12
        Me.txtReceiptAmount.Name = "txtReceiptAmount"
        Me.txtReceiptAmount.ReadOnly = True
        Me.txtReceiptAmount.Size = New System.Drawing.Size(82, 20)
        Me.txtReceiptAmount.TabIndex = 124
        Me.txtReceiptAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 104)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Receipt Amount"
        '
        'lblInstrumentDate
        '
        Me.lblInstrumentDate.AutoSize = True
        Me.lblInstrumentDate.Location = New System.Drawing.Point(571, 59)
        Me.lblInstrumentDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblInstrumentDate.Name = "lblInstrumentDate"
        Me.lblInstrumentDate.Size = New System.Drawing.Size(82, 13)
        Me.lblInstrumentDate.TabIndex = 132
        Me.lblInstrumentDate.Text = "Instrument Date"
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(255, 56)
        Me.txtBankName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBankName.MaxLength = 20
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.ReadOnly = True
        Me.txtBankName.Size = New System.Drawing.Size(119, 20)
        Me.txtBankName.TabIndex = 122
        Me.txtBankName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(192, 59)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 131
        Me.Label6.Text = "Bank Name"
        '
        'txtInstrumentNo
        '
        Me.txtInstrumentNo.Location = New System.Drawing.Point(461, 56)
        Me.txtInstrumentNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInstrumentNo.MaxLength = 50
        Me.txtInstrumentNo.Name = "txtInstrumentNo"
        Me.txtInstrumentNo.ReadOnly = True
        Me.txtInstrumentNo.Size = New System.Drawing.Size(92, 20)
        Me.txtInstrumentNo.TabIndex = 123
        Me.txtInstrumentNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblInstrumentNo
        '
        Me.lblInstrumentNo.AutoSize = True
        Me.lblInstrumentNo.Location = New System.Drawing.Point(385, 59)
        Me.lblInstrumentNo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblInstrumentNo.Name = "lblInstrumentNo"
        Me.lblInstrumentNo.Size = New System.Drawing.Size(73, 13)
        Me.lblInstrumentNo.TabIndex = 130
        Me.lblInstrumentNo.Text = "Instrument No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(217, 103)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 129
        Me.Label5.Text = "Receipt Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(390, 23)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "Receipt No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(402, 102)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 127
        Me.Label9.Text = "Narration"
        '
        'txtNarration
        '
        Me.txtNarration.Location = New System.Drawing.Point(456, 94)
        Me.txtNarration.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNarration.MaxLength = 255
        Me.txtNarration.Multiline = True
        Me.txtNarration.Name = "txtNarration"
        Me.txtNarration.ReadOnly = True
        Me.txtNarration.Size = New System.Drawing.Size(545, 41)
        Me.txtNarration.TabIndex = 125
        Me.txtNarration.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 59)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = "Instrument Type"
        '
        'chkReconciled
        '
        Me.chkReconciled.AutoSize = True
        Me.chkReconciled.Location = New System.Drawing.Point(574, 22)
        Me.chkReconciled.Name = "chkReconciled"
        Me.chkReconciled.Size = New System.Drawing.Size(118, 17)
        Me.chkReconciled.TabIndex = 155
        Me.chkReconciled.Text = "Already Reconciled"
        Me.chkReconciled.UseVisualStyleBackColor = True
        '
        'txtrefgid
        '
        Me.txtrefgid.Location = New System.Drawing.Point(778, 52)
        Me.txtrefgid.MaxLength = 12
        Me.txtrefgid.Name = "txtrefgid"
        Me.txtrefgid.ReadOnly = True
        Me.txtrefgid.Size = New System.Drawing.Size(223, 20)
        Me.txtrefgid.TabIndex = 177
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(741, 55)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(33, 13)
        Me.Label23.TabIndex = 178
        Me.Label23.Text = "refgid"
        '
        'txtgid
        '
        Me.txtgid.Location = New System.Drawing.Point(778, 24)
        Me.txtgid.MaxLength = 12
        Me.txtgid.Name = "txtgid"
        Me.txtgid.ReadOnly = True
        Me.txtgid.Size = New System.Drawing.Size(223, 20)
        Me.txtgid.TabIndex = 175
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(739, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(21, 13)
        Me.Label15.TabIndex = 176
        Me.Label15.Text = "gid"
        '
        'lblFinYear
        '
        Me.lblFinYear.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblFinYear.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinYear.Location = New System.Drawing.Point(247, 16)
        Me.lblFinYear.Name = "lblFinYear"
        Me.lblFinYear.Size = New System.Drawing.Size(137, 25)
        Me.lblFinYear.TabIndex = 171
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(8, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 13)
        Me.Label20.TabIndex = 170
        Me.Label20.Text = "Financial Year"
        '
        'cboFinYear
        '
        Me.cboFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFinYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboFinYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFinYear.ForeColor = System.Drawing.Color.Blue
        Me.cboFinYear.FormattingEnabled = True
        Me.cboFinYear.Location = New System.Drawing.Point(102, 16)
        Me.cboFinYear.Name = "cboFinYear"
        Me.cboFinYear.Size = New System.Drawing.Size(136, 21)
        Me.cboFinYear.TabIndex = 169
        '
        'frmCorrections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1237, 837)
        Me.Controls.Add(Me.btnSaveViewReceiptImage)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "frmCorrections"
        Me.Text = "frmCorrections"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtReceiptAmountNew As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboReceiptNo As ComboBox
    Friend WithEvents btnCorrectReceiptAmount As Button
    Friend WithEvents btnSaveViewReceiptImage As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents txtInstrumentType As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtFlat As TextBox
    Friend WithEvents txtReceiptDate As TextBox
    Friend WithEvents txtInstrumentDate As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents txtReceiptAmount As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblInstrumentDate As Label
    Friend WithEvents txtBankName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtInstrumentNo As TextBox
    Friend WithEvents lblInstrumentNo As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNarration As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents chkReconciled As CheckBox
    Friend WithEvents txtrefgid As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtgid As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents lblFinYear As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cboFinYear As ComboBox
End Class
