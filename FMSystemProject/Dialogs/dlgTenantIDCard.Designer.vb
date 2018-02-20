<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTenantIDCard
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
        Me.btnPrintIDCard = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblOwnerContact = New System.Windows.Forms.Label()
        Me.lblFlatCode = New System.Windows.Forms.Label()
        Me.lblOwnerName = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.picBoxTenant = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkFamily = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkIndividual = New System.Windows.Forms.CheckBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.chkCompany = New System.Windows.Forms.CheckBox()
        Me.lblMobile1 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblStartdate = New System.Windows.Forms.Label()
        Me.lblEmail1 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblFamilyChildCount = New System.Windows.Forms.Label()
        Me.lblTenantName = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFamilyAdultCount = New System.Windows.Forms.Label()
        Me.lblPage1H1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.picBoxTenant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrintIDCard
        '
        Me.btnPrintIDCard.AutoSize = True
        Me.btnPrintIDCard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPrintIDCard.BackColor = System.Drawing.Color.Yellow
        Me.btnPrintIDCard.Location = New System.Drawing.Point(2, 33)
        Me.btnPrintIDCard.Name = "btnPrintIDCard"
        Me.btnPrintIDCard.Size = New System.Drawing.Size(94, 27)
        Me.btnPrintIDCard.TabIndex = 209
        Me.btnPrintIDCard.Text = "Print To File"
        Me.btnPrintIDCard.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblOwnerContact)
        Me.Panel1.Controls.Add(Me.lblFlatCode)
        Me.Panel1.Controls.Add(Me.lblOwnerName)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Location = New System.Drawing.Point(2, 326)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(368, 112)
        Me.Panel1.TabIndex = 207
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(135, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 19)
        Me.Label7.TabIndex = 230
        Me.Label7.Text = "Owner Contact"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOwnerContact
        '
        Me.lblOwnerContact.BackColor = System.Drawing.Color.Transparent
        Me.lblOwnerContact.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOwnerContact.Location = New System.Drawing.Point(258, 2)
        Me.lblOwnerContact.Name = "lblOwnerContact"
        Me.lblOwnerContact.Size = New System.Drawing.Size(105, 24)
        Me.lblOwnerContact.TabIndex = 229
        Me.lblOwnerContact.Text = "9999999999"
        Me.lblOwnerContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFlatCode
        '
        Me.lblFlatCode.BackColor = System.Drawing.Color.Transparent
        Me.lblFlatCode.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlatCode.Location = New System.Drawing.Point(61, 3)
        Me.lblFlatCode.Name = "lblFlatCode"
        Me.lblFlatCode.Size = New System.Drawing.Size(81, 22)
        Me.lblFlatCode.TabIndex = 227
        Me.lblFlatCode.Text = "XXXXXX"
        Me.lblFlatCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOwnerName
        '
        Me.lblOwnerName.BackColor = System.Drawing.Color.Transparent
        Me.lblOwnerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblOwnerName.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOwnerName.Location = New System.Drawing.Point(61, 43)
        Me.lblOwnerName.Name = "lblOwnerName"
        Me.lblOwnerName.Size = New System.Drawing.Size(302, 63)
        Me.lblOwnerName.TabIndex = 225
        Me.lblOwnerName.Text = "<Owner Name> \n <CoOwnerName>"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 19)
        Me.Label8.TabIndex = 226
        Me.Label8.Text = "Owner"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 19)
        Me.Label12.TabIndex = 225
        Me.Label12.Text = "Flat"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picBoxTenant
        '
        Me.picBoxTenant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBoxTenant.Location = New System.Drawing.Point(3, 93)
        Me.picBoxTenant.Name = "picBoxTenant"
        Me.picBoxTenant.Size = New System.Drawing.Size(256, 230)
        Me.picBoxTenant.TabIndex = 204
        Me.picBoxTenant.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(364, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 19)
        Me.Label6.TabIndex = 192
        Me.Label6.Text = "Child"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(265, 217)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 19)
        Me.Label4.TabIndex = 190
        Me.Label4.Text = "Adult"
        '
        'chkFamily
        '
        Me.chkFamily.AutoSize = True
        Me.chkFamily.BackColor = System.Drawing.Color.Transparent
        Me.chkFamily.Enabled = False
        Me.chkFamily.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFamily.Location = New System.Drawing.Point(267, 188)
        Me.chkFamily.Name = "chkFamily"
        Me.chkFamily.Size = New System.Drawing.Size(89, 27)
        Me.chkFamily.TabIndex = 3
        Me.chkFamily.Text = "Family"
        Me.chkFamily.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(285, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 23)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "Valid From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(462, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 23)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "Valid To"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnPrintIDCard)
        Me.Panel3.Controls.Add(Me.btnClose)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.chkIndividual)
        Me.Panel3.Controls.Add(Me.lblAddress)
        Me.Panel3.Controls.Add(Me.chkCompany)
        Me.Panel3.Controls.Add(Me.lblMobile1)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Controls.Add(Me.lblEndDate)
        Me.Panel3.Controls.Add(Me.lblStartdate)
        Me.Panel3.Controls.Add(Me.lblEmail1)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.lblFamilyChildCount)
        Me.Panel3.Controls.Add(Me.lblTenantName)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.lblFamilyAdultCount)
        Me.Panel3.Controls.Add(Me.lblPage1H1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.picBoxTenant)
        Me.Panel3.Controls.Add(Me.chkFamily)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(592, 443)
        Me.Panel3.TabIndex = 210
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClose.BackColor = System.Drawing.Color.Yellow
        Me.btnClose.Location = New System.Drawing.Point(129, 33)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(53, 27)
        Me.btnClose.TabIndex = 212
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Location = New System.Drawing.Point(376, 383)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(211, 55)
        Me.Panel4.TabIndex = 213
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 17)
        Me.Label3.TabIndex = 209
        Me.Label3.Text = "FM Signature"
        '
        'chkIndividual
        '
        Me.chkIndividual.AutoSize = True
        Me.chkIndividual.BackColor = System.Drawing.Color.Transparent
        Me.chkIndividual.Enabled = False
        Me.chkIndividual.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIndividual.Location = New System.Drawing.Point(464, 188)
        Me.chkIndividual.Name = "chkIndividual"
        Me.chkIndividual.Size = New System.Drawing.Size(112, 27)
        Me.chkIndividual.TabIndex = 222
        Me.chkIndividual.Text = "Individual"
        Me.chkIndividual.UseVisualStyleBackColor = False
        '
        'lblAddress
        '
        Me.lblAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblAddress.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.Location = New System.Drawing.Point(263, 239)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(324, 84)
        Me.lblAddress.TabIndex = 234
        Me.lblAddress.Text = "<Address>"
        '
        'chkCompany
        '
        Me.chkCompany.AutoSize = True
        Me.chkCompany.BackColor = System.Drawing.Color.Transparent
        Me.chkCompany.Enabled = False
        Me.chkCompany.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCompany.Location = New System.Drawing.Point(354, 188)
        Me.chkCompany.Name = "chkCompany"
        Me.chkCompany.Size = New System.Drawing.Size(115, 27)
        Me.chkCompany.TabIndex = 221
        Me.chkCompany.Text = "Company"
        Me.chkCompany.UseVisualStyleBackColor = False
        '
        'lblMobile1
        '
        Me.lblMobile1.BackColor = System.Drawing.Color.Transparent
        Me.lblMobile1.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMobile1.Location = New System.Drawing.Point(334, 146)
        Me.lblMobile1.Name = "lblMobile1"
        Me.lblMobile1.Size = New System.Drawing.Size(250, 19)
        Me.lblMobile1.TabIndex = 233
        Me.lblMobile1.Text = "<Phone>"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(268, 146)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(56, 19)
        Me.Label29.TabIndex = 232
        Me.Label29.Text = "Phone"
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEndDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblEndDate.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndDate.ForeColor = System.Drawing.Color.Red
        Me.lblEndDate.Location = New System.Drawing.Point(429, 122)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(155, 24)
        Me.lblEndDate.TabIndex = 220
        Me.lblEndDate.Text = "DD-MMM-YYYY"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStartdate
        '
        Me.lblStartdate.AutoSize = True
        Me.lblStartdate.BackColor = System.Drawing.Color.Transparent
        Me.lblStartdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblStartdate.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartdate.Location = New System.Drawing.Point(265, 122)
        Me.lblStartdate.Name = "lblStartdate"
        Me.lblStartdate.Size = New System.Drawing.Size(155, 24)
        Me.lblStartdate.TabIndex = 219
        Me.lblStartdate.Text = "DD-MMM-YYYY"
        Me.lblStartdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEmail1
        '
        Me.lblEmail1.BackColor = System.Drawing.Color.Transparent
        Me.lblEmail1.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail1.Location = New System.Drawing.Point(334, 170)
        Me.lblEmail1.Name = "lblEmail1"
        Me.lblEmail1.Size = New System.Drawing.Size(250, 19)
        Me.lblEmail1.TabIndex = 231
        Me.lblEmail1.Text = "<Email>"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(268, 170)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(49, 19)
        Me.Label31.TabIndex = 230
        Me.Label31.Text = "Email"
        '
        'lblFamilyChildCount
        '
        Me.lblFamilyChildCount.AutoSize = True
        Me.lblFamilyChildCount.BackColor = System.Drawing.Color.Transparent
        Me.lblFamilyChildCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblFamilyChildCount.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFamilyChildCount.Location = New System.Drawing.Point(416, 218)
        Me.lblFamilyChildCount.Name = "lblFamilyChildCount"
        Me.lblFamilyChildCount.Size = New System.Drawing.Size(20, 19)
        Me.lblFamilyChildCount.TabIndex = 218
        Me.lblFamilyChildCount.Text = "X"
        Me.lblFamilyChildCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTenantName
        '
        Me.lblTenantName.BackColor = System.Drawing.Color.Red
        Me.lblTenantName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTenantName.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenantName.ForeColor = System.Drawing.Color.White
        Me.lblTenantName.Location = New System.Drawing.Point(0, 63)
        Me.lblTenantName.Name = "lblTenantName"
        Me.lblTenantName.Size = New System.Drawing.Size(590, 29)
        Me.lblTenantName.TabIndex = 211
        Me.lblTenantName.Text = "<TENANT NAME>"
        Me.lblTenantName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(376, 326)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(211, 55)
        Me.Panel2.TabIndex = 208
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 17)
        Me.Label5.TabIndex = 213
        Me.Label5.Text = "Tenant Signature"
        '
        'lblFamilyAdultCount
        '
        Me.lblFamilyAdultCount.AutoSize = True
        Me.lblFamilyAdultCount.BackColor = System.Drawing.Color.Transparent
        Me.lblFamilyAdultCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblFamilyAdultCount.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFamilyAdultCount.Location = New System.Drawing.Point(318, 218)
        Me.lblFamilyAdultCount.Name = "lblFamilyAdultCount"
        Me.lblFamilyAdultCount.Size = New System.Drawing.Size(20, 19)
        Me.lblFamilyAdultCount.TabIndex = 217
        Me.lblFamilyAdultCount.Text = "X"
        Me.lblFamilyAdultCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPage1H1
        '
        Me.lblPage1H1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPage1H1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPage1H1.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPage1H1.Location = New System.Drawing.Point(-1, 0)
        Me.lblPage1H1.Name = "lblPage1H1"
        Me.lblPage1H1.Size = New System.Drawing.Size(592, 62)
        Me.lblPage1H1.TabIndex = 205
        Me.lblPage1H1.Text = "TENANT IDENTITY CARD /n CARD NUMBER <xxxx>"
        Me.lblPage1H1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dlgTenantIDCard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(592, 445)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgTenantIDCard"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlgTenantIDCard"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picBoxTenant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPrintIDCard As System.Windows.Forms.Button
    Friend WithEvents picBoxTenant As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkFamily As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblPage1H1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblTenantName As System.Windows.Forms.Label
    Friend WithEvents chkIndividual As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompany As System.Windows.Forms.CheckBox
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblStartdate As System.Windows.Forms.Label
    Friend WithEvents lblFamilyChildCount As System.Windows.Forms.Label
    Friend WithEvents lblFamilyAdultCount As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblOwnerName As System.Windows.Forms.Label
    Friend WithEvents lblOwnerContact As System.Windows.Forms.Label
    Friend WithEvents lblFlatCode As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblMobile1 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblEmail1 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
