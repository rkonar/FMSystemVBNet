<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEditTenant
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
        Me.txtTenantName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEmail1 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMobile1 = New System.Windows.Forms.TextBox()
        Me.txtStartdate = New System.Windows.Forms.TextBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnStartDate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cboFlatCode = New System.Windows.Forms.ComboBox()
        Me.btnEndDate = New System.Windows.Forms.Button()
        Me.txtEndDate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEditFlatOwnerDetails = New System.Windows.Forms.Button()
        Me.lblOwnerDetails = New System.Windows.Forms.Label()
        Me.picBoxTenant = New System.Windows.Forms.PictureBox()
        Me.btnActivateCamera = New System.Windows.Forms.Button()
        Me.picBoxPreview = New System.Windows.Forms.PictureBox()
        Me.btnTakeSnap = New System.Windows.Forms.Button()
        Me.btnSavePicture = New System.Windows.Forms.Button()
        Me.lblImageSize = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAdultCount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtChildCount = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkFeePaid = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboTenantType = New System.Windows.Forms.ComboBox()
        Me.btnPrintIDCard = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboReceiptNo = New System.Windows.Forms.ComboBox()
        CType(Me.picBoxTenant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTenantName
        '
        Me.txtTenantName.Location = New System.Drawing.Point(148, 4)
        Me.txtTenantName.MaxLength = 100
        Me.txtTenantName.Name = "txtTenantName"
        Me.txtTenantName.ReadOnly = True
        Me.txtTenantName.Size = New System.Drawing.Size(386, 22)
        Me.txtTenantName.TabIndex = 1
        Me.txtTenantName.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Tenant Name"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(148, 219)
        Me.txtAddress.MaxLength = 255
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(386, 100)
        Me.txtAddress.TabIndex = 10
        Me.txtAddress.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 242)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 17)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Permanent Address"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 17)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Flat"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(274, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 17)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Email"
        '
        'txtEmail1
        '
        Me.txtEmail1.Location = New System.Drawing.Point(325, 141)
        Me.txtEmail1.MaxLength = 100
        Me.txtEmail1.Name = "txtEmail1"
        Me.txtEmail1.ReadOnly = True
        Me.txtEmail1.Size = New System.Drawing.Size(216, 22)
        Me.txtEmail1.TabIndex = 8
        Me.txtEmail1.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(270, 183)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 17)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Mobile"
        '
        'txtMobile1
        '
        Me.txtMobile1.Location = New System.Drawing.Point(325, 180)
        Me.txtMobile1.MaxLength = 100
        Me.txtMobile1.Name = "txtMobile1"
        Me.txtMobile1.ReadOnly = True
        Me.txtMobile1.Size = New System.Drawing.Size(216, 22)
        Me.txtMobile1.TabIndex = 9
        Me.txtMobile1.TabStop = False
        '
        'txtStartdate
        '
        Me.txtStartdate.Location = New System.Drawing.Point(148, 141)
        Me.txtStartdate.Name = "txtStartdate"
        Me.txtStartdate.ReadOnly = True
        Me.txtStartdate.Size = New System.Drawing.Size(89, 22)
        Me.txtStartdate.TabIndex = 44
        Me.txtStartdate.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.AutoSize = True
        Me.btnEdit.Location = New System.Drawing.Point(4, 399)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 27)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.Location = New System.Drawing.Point(119, 399)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 27)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Location = New System.Drawing.Point(234, 399)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 27)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnStartDate
        '
        Me.btnStartDate.AutoSize = True
        Me.btnStartDate.Location = New System.Drawing.Point(237, 139)
        Me.btnStartDate.Name = "btnStartDate"
        Me.btnStartDate.Size = New System.Drawing.Size(30, 27)
        Me.btnStartDate.TabIndex = 6
        Me.btnStartDate.Text = "..."
        Me.btnStartDate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClose.Location = New System.Drawing.Point(349, 399)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(53, 27)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cboFlatCode
        '
        Me.cboFlatCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlatCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboFlatCode.FormattingEnabled = True
        Me.cboFlatCode.Location = New System.Drawing.Point(54, 14)
        Me.cboFlatCode.Name = "cboFlatCode"
        Me.cboFlatCode.Size = New System.Drawing.Size(97, 24)
        Me.cboFlatCode.TabIndex = 173
        '
        'btnEndDate
        '
        Me.btnEndDate.AutoSize = True
        Me.btnEndDate.Location = New System.Drawing.Point(237, 178)
        Me.btnEndDate.Name = "btnEndDate"
        Me.btnEndDate.Size = New System.Drawing.Size(30, 27)
        Me.btnEndDate.TabIndex = 7
        Me.btnEndDate.Text = "..."
        Me.btnEndDate.UseVisualStyleBackColor = True
        '
        'txtEndDate
        '
        Me.txtEndDate.Location = New System.Drawing.Point(148, 180)
        Me.txtEndDate.Name = "txtEndDate"
        Me.txtEndDate.ReadOnly = True
        Me.txtEndDate.Size = New System.Drawing.Size(89, 22)
        Me.txtEndDate.TabIndex = 174
        Me.txtEndDate.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 145)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 17)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "Tenancy Start Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 17)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "Tenancy End Date"
        '
        'cboGender
        '
        Me.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGender.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboGender.FormattingEnabled = True
        Me.cboGender.Location = New System.Drawing.Point(148, 60)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(142, 24)
        Me.cboGender.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(83, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 178
        Me.Label3.Text = "Gender"
        '
        'btnEditFlatOwnerDetails
        '
        Me.btnEditFlatOwnerDetails.AutoSize = True
        Me.btnEditFlatOwnerDetails.Location = New System.Drawing.Point(511, 14)
        Me.btnEditFlatOwnerDetails.Name = "btnEditFlatOwnerDetails"
        Me.btnEditFlatOwnerDetails.Size = New System.Drawing.Size(30, 27)
        Me.btnEditFlatOwnerDetails.TabIndex = 180
        Me.btnEditFlatOwnerDetails.Text = "..."
        Me.btnEditFlatOwnerDetails.UseVisualStyleBackColor = True
        '
        'lblOwnerDetails
        '
        Me.lblOwnerDetails.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblOwnerDetails.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOwnerDetails.Location = New System.Drawing.Point(262, 9)
        Me.lblOwnerDetails.Name = "lblOwnerDetails"
        Me.lblOwnerDetails.Size = New System.Drawing.Size(243, 35)
        Me.lblOwnerDetails.TabIndex = 181
        '
        'picBoxTenant
        '
        Me.picBoxTenant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBoxTenant.Location = New System.Drawing.Point(562, 62)
        Me.picBoxTenant.Name = "picBoxTenant"
        Me.picBoxTenant.Size = New System.Drawing.Size(150, 150)
        Me.picBoxTenant.TabIndex = 182
        Me.picBoxTenant.TabStop = False
        '
        'btnActivateCamera
        '
        Me.btnActivateCamera.Location = New System.Drawing.Point(562, 215)
        Me.btnActivateCamera.Name = "btnActivateCamera"
        Me.btnActivateCamera.Size = New System.Drawing.Size(70, 27)
        Me.btnActivateCamera.TabIndex = 15
        Me.btnActivateCamera.Text = "Camera"
        Me.btnActivateCamera.UseVisualStyleBackColor = True
        '
        'picBoxPreview
        '
        Me.picBoxPreview.Location = New System.Drawing.Point(562, 244)
        Me.picBoxPreview.Name = "picBoxPreview"
        Me.picBoxPreview.Size = New System.Drawing.Size(150, 150)
        Me.picBoxPreview.TabIndex = 184
        Me.picBoxPreview.TabStop = False
        '
        'btnTakeSnap
        '
        Me.btnTakeSnap.AutoSize = True
        Me.btnTakeSnap.Enabled = False
        Me.btnTakeSnap.Location = New System.Drawing.Point(590, 399)
        Me.btnTakeSnap.Name = "btnTakeSnap"
        Me.btnTakeSnap.Size = New System.Drawing.Size(91, 27)
        Me.btnTakeSnap.TabIndex = 16
        Me.btnTakeSnap.Text = "Take Snap"
        Me.btnTakeSnap.UseVisualStyleBackColor = True
        '
        'btnSavePicture
        '
        Me.btnSavePicture.Enabled = False
        Me.btnSavePicture.Location = New System.Drawing.Point(643, 215)
        Me.btnSavePicture.Name = "btnSavePicture"
        Me.btnSavePicture.Size = New System.Drawing.Size(70, 27)
        Me.btnSavePicture.TabIndex = 17
        Me.btnSavePicture.Text = "Confirm"
        Me.btnSavePicture.UseVisualStyleBackColor = True
        '
        'lblImageSize
        '
        Me.lblImageSize.AutoSize = True
        Me.lblImageSize.Location = New System.Drawing.Point(667, 42)
        Me.lblImageSize.Name = "lblImageSize"
        Me.lblImageSize.Size = New System.Drawing.Size(39, 17)
        Me.lblImageSize.TabIndex = 187
        Me.lblImageSize.Text = "xx kb"
        Me.lblImageSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 17)
        Me.Label4.TabIndex = 190
        Me.Label4.Text = "Adult Count"
        '
        'txtAdultCount
        '
        Me.txtAdultCount.Enabled = False
        Me.txtAdultCount.Location = New System.Drawing.Point(148, 88)
        Me.txtAdultCount.MaxLength = 1
        Me.txtAdultCount.Name = "txtAdultCount"
        Me.txtAdultCount.Size = New System.Drawing.Size(37, 22)
        Me.txtAdultCount.TabIndex = 4
        Me.txtAdultCount.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(59, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 17)
        Me.Label6.TabIndex = 192
        Me.Label6.Text = "Child Count"
        '
        'txtChildCount
        '
        Me.txtChildCount.Enabled = False
        Me.txtChildCount.Location = New System.Drawing.Point(148, 116)
        Me.txtChildCount.MaxLength = 1
        Me.txtChildCount.Name = "txtChildCount"
        Me.txtChildCount.Size = New System.Drawing.Size(37, 22)
        Me.txtChildCount.TabIndex = 5
        Me.txtChildCount.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(160, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 17)
        Me.Label8.TabIndex = 193
        Me.Label8.Text = "Owner Details"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblOwnerDetails)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cboFlatCode)
        Me.Panel1.Controls.Add(Me.btnEditFlatOwnerDetails)
        Me.Panel1.Location = New System.Drawing.Point(6, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(548, 54)
        Me.Panel1.TabIndex = 194
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cboReceiptNo)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.chkFeePaid)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.cboTenantType)
        Me.Panel2.Controls.Add(Me.txtAddress)
        Me.Panel2.Controls.Add(Me.txtTenantName)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtChildCount)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtEmail1)
        Me.Panel2.Controls.Add(Me.txtAdultCount)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.txtMobile1)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.txtStartdate)
        Me.Panel2.Controls.Add(Me.btnStartDate)
        Me.Panel2.Controls.Add(Me.txtEndDate)
        Me.Panel2.Controls.Add(Me.btnEndDate)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cboGender)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(5, 61)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(549, 332)
        Me.Panel2.TabIndex = 195
        '
        'chkFeePaid
        '
        Me.chkFeePaid.AutoSize = True
        Me.chkFeePaid.Location = New System.Drawing.Point(308, 34)
        Me.chkFeePaid.Name = "chkFeePaid"
        Me.chkFeePaid.Size = New System.Drawing.Size(86, 21)
        Me.chkFeePaid.TabIndex = 196
        Me.chkFeePaid.Text = "Fee Paid"
        Me.chkFeePaid.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(50, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 17)
        Me.Label11.TabIndex = 195
        Me.Label11.Text = "Tenant Type"
        '
        'cboTenantType
        '
        Me.cboTenantType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTenantType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboTenantType.FormattingEnabled = True
        Me.cboTenantType.Location = New System.Drawing.Point(148, 32)
        Me.cboTenantType.Name = "cboTenantType"
        Me.cboTenantType.Size = New System.Drawing.Size(142, 24)
        Me.cboTenantType.TabIndex = 194
        '
        'btnPrintIDCard
        '
        Me.btnPrintIDCard.AutoSize = True
        Me.btnPrintIDCard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPrintIDCard.Location = New System.Drawing.Point(457, 399)
        Me.btnPrintIDCard.Name = "btnPrintIDCard"
        Me.btnPrintIDCard.Size = New System.Drawing.Size(98, 27)
        Me.btnPrintIDCard.TabIndex = 196
        Me.btnPrintIDCard.Text = "Print ID Card"
        Me.btnPrintIDCard.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(312, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 17)
        Me.Label12.TabIndex = 198
        Me.Label12.Text = "Receipt No"
        '
        'cboReceiptNo
        '
        Me.cboReceiptNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReceiptNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboReceiptNo.FormattingEnabled = True
        Me.cboReceiptNo.Location = New System.Drawing.Point(392, 59)
        Me.cboReceiptNo.Name = "cboReceiptNo"
        Me.cboReceiptNo.Size = New System.Drawing.Size(142, 24)
        Me.cboReceiptNo.TabIndex = 199
        '
        'frmAddEditTenant
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(724, 436)
        Me.Controls.Add(Me.btnPrintIDCard)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblImageSize)
        Me.Controls.Add(Me.btnSavePicture)
        Me.Controls.Add(Me.btnTakeSnap)
        Me.Controls.Add(Me.picBoxPreview)
        Me.Controls.Add(Me.btnActivateCamera)
        Me.Controls.Add(Me.picBoxTenant)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnEdit)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddEditTenant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.picBoxTenant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTenantName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtEmail1 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMobile1 As System.Windows.Forms.TextBox
    Friend WithEvents txtStartdate As System.Windows.Forms.TextBox
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnStartDate As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cboFlatCode As System.Windows.Forms.ComboBox
    Friend WithEvents btnEndDate As System.Windows.Forms.Button
    Friend WithEvents txtEndDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnEditFlatOwnerDetails As System.Windows.Forms.Button
    Friend WithEvents lblOwnerDetails As System.Windows.Forms.Label
    Friend WithEvents picBoxTenant As System.Windows.Forms.PictureBox
    Friend WithEvents btnActivateCamera As System.Windows.Forms.Button
    Friend WithEvents picBoxPreview As System.Windows.Forms.PictureBox
    Friend WithEvents btnTakeSnap As System.Windows.Forms.Button
    Friend WithEvents btnSavePicture As System.Windows.Forms.Button
    Friend WithEvents lblImageSize As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAdultCount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtChildCount As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnPrintIDCard As System.Windows.Forms.Button
    Friend WithEvents cboTenantType As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkFeePaid As System.Windows.Forms.CheckBox
    Friend WithEvents cboReceiptNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
