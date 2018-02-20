<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageFlats
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
        Me.cboDuplex = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboNoOfRooms = New System.Windows.Forms.ComboBox()
        Me.txtOwner = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCoOwner = New System.Windows.Forms.TextBox()
        Me.txtPrimaryEmail = New System.Windows.Forms.TextBox()
        Me.txtPrimaryPhone = New System.Windows.Forms.TextBox()
        Me.txtPresentAddress = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSBUArea = New System.Windows.Forms.TextBox()
        Me.txtTerraceArea = New System.Windows.Forms.TextBox()
        Me.txtTower = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFlat = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEmail1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEmail2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLandline1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtLandline2 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMobile2 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMobile1_SMS = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCommAddress = New System.Windows.Forms.TextBox()
        Me.txtOwnerSince = New System.Windows.Forms.TextBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOwnerSince = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpPortal = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtPortalLandline1 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtPortalEmail2 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtPortalEmail1 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtPortalMobile2 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPortalMobile1 = New System.Windows.Forms.TextBox()
        Me.btnAddNewOwner = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtEVotingEmailId = New System.Windows.Forms.TextBox()
        Me.btnAddEditPOA = New System.Windows.Forms.Button()
        Me.chkPOAExist = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtBlockedEmails = New System.Windows.Forms.TextBox()
        Me.txtEmailBlockReason = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.grpPortal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboDuplex
        '
        Me.cboDuplex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDuplex.Enabled = False
        Me.cboDuplex.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboDuplex.FormattingEnabled = True
        Me.cboDuplex.Items.AddRange(New Object() {"Y", "N"})
        Me.cboDuplex.Location = New System.Drawing.Point(990, 8)
        Me.cboDuplex.Name = "cboDuplex"
        Me.cboDuplex.Size = New System.Drawing.Size(64, 21)
        Me.cboDuplex.TabIndex = 6
        Me.cboDuplex.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(851, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Part Of Duplex?"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "SBU Area (Sq. Ft.)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(332, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Terrace Area (Sq. Ft.)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(617, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "No. of. Rooms"
        '
        'cboNoOfRooms
        '
        Me.cboNoOfRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNoOfRooms.Enabled = False
        Me.cboNoOfRooms.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboNoOfRooms.FormattingEnabled = True
        Me.cboNoOfRooms.Items.AddRange(New Object() {"2", "3"})
        Me.cboNoOfRooms.Location = New System.Drawing.Point(782, 8)
        Me.cboNoOfRooms.Name = "cboNoOfRooms"
        Me.cboNoOfRooms.Size = New System.Drawing.Size(64, 21)
        Me.cboNoOfRooms.TabIndex = 11
        Me.cboNoOfRooms.TabStop = False
        '
        'txtOwner
        '
        Me.txtOwner.Location = New System.Drawing.Point(143, 78)
        Me.txtOwner.Name = "txtOwner"
        Me.txtOwner.ReadOnly = True
        Me.txtOwner.Size = New System.Drawing.Size(356, 20)
        Me.txtOwner.TabIndex = 14
        Me.txtOwner.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Current Owner"
        '
        'txtCoOwner
        '
        Me.txtCoOwner.Location = New System.Drawing.Point(574, 78)
        Me.txtCoOwner.Name = "txtCoOwner"
        Me.txtCoOwner.ReadOnly = True
        Me.txtCoOwner.Size = New System.Drawing.Size(391, 20)
        Me.txtCoOwner.TabIndex = 16
        Me.txtCoOwner.TabStop = False
        '
        'txtPrimaryEmail
        '
        Me.txtPrimaryEmail.Location = New System.Drawing.Point(143, 114)
        Me.txtPrimaryEmail.Name = "txtPrimaryEmail"
        Me.txtPrimaryEmail.ReadOnly = True
        Me.txtPrimaryEmail.Size = New System.Drawing.Size(432, 20)
        Me.txtPrimaryEmail.TabIndex = 17
        Me.txtPrimaryEmail.TabStop = False
        '
        'txtPrimaryPhone
        '
        Me.txtPrimaryPhone.Location = New System.Drawing.Point(782, 114)
        Me.txtPrimaryPhone.Name = "txtPrimaryPhone"
        Me.txtPrimaryPhone.ReadOnly = True
        Me.txtPrimaryPhone.Size = New System.Drawing.Size(295, 20)
        Me.txtPrimaryPhone.TabIndex = 18
        Me.txtPrimaryPhone.TabStop = False
        '
        'txtPresentAddress
        '
        Me.txtPresentAddress.Location = New System.Drawing.Point(143, 269)
        Me.txtPresentAddress.Multiline = True
        Me.txtPresentAddress.Name = "txtPresentAddress"
        Me.txtPresentAddress.ReadOnly = True
        Me.txtPresentAddress.Size = New System.Drawing.Size(432, 126)
        Me.txtPresentAddress.TabIndex = 19
        Me.txtPresentAddress.TabStop = False
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(12, 117)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(69, 13)
        Me.lblEmail.TabIndex = 20
        Me.lblEmail.Text = "Primary Email"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(617, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Primary Phone"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 316)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Present Address"
        '
        'txtSBUArea
        '
        Me.txtSBUArea.Location = New System.Drawing.Point(143, 44)
        Me.txtSBUArea.Name = "txtSBUArea"
        Me.txtSBUArea.ReadOnly = True
        Me.txtSBUArea.Size = New System.Drawing.Size(85, 20)
        Me.txtSBUArea.TabIndex = 23
        Me.txtSBUArea.TabStop = False
        '
        'txtTerraceArea
        '
        Me.txtTerraceArea.Location = New System.Drawing.Point(486, 44)
        Me.txtTerraceArea.Name = "txtTerraceArea"
        Me.txtTerraceArea.ReadOnly = True
        Me.txtTerraceArea.Size = New System.Drawing.Size(85, 20)
        Me.txtTerraceArea.TabIndex = 24
        Me.txtTerraceArea.TabStop = False
        '
        'txtTower
        '
        Me.txtTower.Location = New System.Drawing.Point(143, 9)
        Me.txtTower.Name = "txtTower"
        Me.txtTower.ReadOnly = True
        Me.txtTower.Size = New System.Drawing.Size(178, 20)
        Me.txtTower.TabIndex = 26
        Me.txtTower.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Tower"
        '
        'txtFlat
        '
        Me.txtFlat.Location = New System.Drawing.Point(486, 9)
        Me.txtFlat.Name = "txtFlat"
        Me.txtFlat.ReadOnly = True
        Me.txtFlat.Size = New System.Drawing.Size(44, 20)
        Me.txtFlat.TabIndex = 28
        Me.txtFlat.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(428, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Flat"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Email1"
        '
        'txtEmail1
        '
        Me.txtEmail1.Location = New System.Drawing.Point(143, 148)
        Me.txtEmail1.Name = "txtEmail1"
        Me.txtEmail1.ReadOnly = True
        Me.txtEmail1.Size = New System.Drawing.Size(432, 20)
        Me.txtEmail1.TabIndex = 29
        Me.txtEmail1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(617, 151)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Email2"
        '
        'txtEmail2
        '
        Me.txtEmail2.Location = New System.Drawing.Point(782, 148)
        Me.txtEmail2.Name = "txtEmail2"
        Me.txtEmail2.ReadOnly = True
        Me.txtEmail2.Size = New System.Drawing.Size(432, 20)
        Me.txtEmail2.TabIndex = 31
        Me.txtEmail2.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 186)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Landline 1"
        '
        'txtLandline1
        '
        Me.txtLandline1.Location = New System.Drawing.Point(143, 183)
        Me.txtLandline1.Name = "txtLandline1"
        Me.txtLandline1.ReadOnly = True
        Me.txtLandline1.Size = New System.Drawing.Size(295, 20)
        Me.txtLandline1.TabIndex = 33
        Me.txtLandline1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(617, 186)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Landline 2"
        '
        'txtLandline2
        '
        Me.txtLandline2.Location = New System.Drawing.Point(782, 183)
        Me.txtLandline2.Name = "txtLandline2"
        Me.txtLandline2.ReadOnly = True
        Me.txtLandline2.Size = New System.Drawing.Size(295, 20)
        Me.txtLandline2.TabIndex = 35
        Me.txtLandline2.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(617, 220)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Mobile 2"
        '
        'txtMobile2
        '
        Me.txtMobile2.Location = New System.Drawing.Point(782, 217)
        Me.txtMobile2.Name = "txtMobile2"
        Me.txtMobile2.ReadOnly = True
        Me.txtMobile2.Size = New System.Drawing.Size(295, 20)
        Me.txtMobile2.TabIndex = 39
        Me.txtMobile2.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 231)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 13)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Mobile 1 (SMS)"
        '
        'txtMobile1_SMS
        '
        Me.txtMobile1_SMS.Location = New System.Drawing.Point(143, 228)
        Me.txtMobile1_SMS.Name = "txtMobile1_SMS"
        Me.txtMobile1_SMS.ReadOnly = True
        Me.txtMobile1_SMS.Size = New System.Drawing.Size(295, 20)
        Me.txtMobile1_SMS.TabIndex = 37
        Me.txtMobile1_SMS.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(617, 316)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 13)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Communication Address"
        '
        'txtCommAddress
        '
        Me.txtCommAddress.Location = New System.Drawing.Point(782, 269)
        Me.txtCommAddress.Multiline = True
        Me.txtCommAddress.Name = "txtCommAddress"
        Me.txtCommAddress.ReadOnly = True
        Me.txtCommAddress.Size = New System.Drawing.Size(432, 126)
        Me.txtCommAddress.TabIndex = 41
        Me.txtCommAddress.TabStop = False
        '
        'txtOwnerSince
        '
        Me.txtOwnerSince.Location = New System.Drawing.Point(975, 78)
        Me.txtOwnerSince.Name = "txtOwnerSince"
        Me.txtOwnerSince.ReadOnly = True
        Me.txtOwnerSince.Size = New System.Drawing.Size(118, 20)
        Me.txtOwnerSince.TabIndex = 44
        Me.txtOwnerSince.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.AutoSize = True
        Me.btnEdit.Location = New System.Drawing.Point(9, 774)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 27)
        Me.btnEdit.TabIndex = 45
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.Location = New System.Drawing.Point(123, 774)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 27)
        Me.btnSave.TabIndex = 46
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Location = New System.Drawing.Point(229, 774)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 27)
        Me.btnCancel.TabIndex = 47
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOwnerSince
        '
        Me.btnOwnerSince.AutoSize = True
        Me.btnOwnerSince.Location = New System.Drawing.Point(1097, 74)
        Me.btnOwnerSince.Name = "btnOwnerSince"
        Me.btnOwnerSince.Size = New System.Drawing.Size(30, 27)
        Me.btnOwnerSince.TabIndex = 48
        Me.btnOwnerSince.Text = "..."
        Me.btnOwnerSince.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClose.Location = New System.Drawing.Point(343, 776)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(43, 23)
        Me.btnClose.TabIndex = 95
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpPortal
        '
        Me.grpPortal.Controls.Add(Me.Label21)
        Me.grpPortal.Controls.Add(Me.txtPortalLandline1)
        Me.grpPortal.Controls.Add(Me.Label19)
        Me.grpPortal.Controls.Add(Me.txtPortalEmail2)
        Me.grpPortal.Controls.Add(Me.Label20)
        Me.grpPortal.Controls.Add(Me.txtPortalEmail1)
        Me.grpPortal.Controls.Add(Me.Label17)
        Me.grpPortal.Controls.Add(Me.txtPortalMobile2)
        Me.grpPortal.Controls.Add(Me.Label18)
        Me.grpPortal.Controls.Add(Me.txtPortalMobile1)
        Me.grpPortal.ForeColor = System.Drawing.Color.Red
        Me.grpPortal.Location = New System.Drawing.Point(15, 431)
        Me.grpPortal.Name = "grpPortal"
        Me.grpPortal.Size = New System.Drawing.Size(1199, 190)
        Me.grpPortal.TabIndex = 172
        Me.grpPortal.TabStop = False
        Me.grpPortal.Text = "Portal Registration Details"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(18, 139)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 13)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "Landline 1"
        '
        'txtPortalLandline1
        '
        Me.txtPortalLandline1.Location = New System.Drawing.Point(149, 136)
        Me.txtPortalLandline1.Name = "txtPortalLandline1"
        Me.txtPortalLandline1.ReadOnly = True
        Me.txtPortalLandline1.Size = New System.Drawing.Size(295, 20)
        Me.txtPortalLandline1.TabIndex = 49
        Me.txtPortalLandline1.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(623, 43)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 48
        Me.Label19.Text = "Email2"
        '
        'txtPortalEmail2
        '
        Me.txtPortalEmail2.Location = New System.Drawing.Point(788, 40)
        Me.txtPortalEmail2.Name = "txtPortalEmail2"
        Me.txtPortalEmail2.ReadOnly = True
        Me.txtPortalEmail2.Size = New System.Drawing.Size(400, 20)
        Me.txtPortalEmail2.TabIndex = 47
        Me.txtPortalEmail2.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(18, 43)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(38, 13)
        Me.Label20.TabIndex = 46
        Me.Label20.Text = "Email1"
        '
        'txtPortalEmail1
        '
        Me.txtPortalEmail1.Location = New System.Drawing.Point(149, 40)
        Me.txtPortalEmail1.Name = "txtPortalEmail1"
        Me.txtPortalEmail1.ReadOnly = True
        Me.txtPortalEmail1.Size = New System.Drawing.Size(400, 20)
        Me.txtPortalEmail1.TabIndex = 45
        Me.txtPortalEmail1.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(623, 94)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "Mobile 2"
        '
        'txtPortalMobile2
        '
        Me.txtPortalMobile2.Location = New System.Drawing.Point(788, 91)
        Me.txtPortalMobile2.Name = "txtPortalMobile2"
        Me.txtPortalMobile2.ReadOnly = True
        Me.txtPortalMobile2.Size = New System.Drawing.Size(295, 20)
        Me.txtPortalMobile2.TabIndex = 43
        Me.txtPortalMobile2.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(18, 94)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 13)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "Mobile 1"
        '
        'txtPortalMobile1
        '
        Me.txtPortalMobile1.Location = New System.Drawing.Point(149, 91)
        Me.txtPortalMobile1.Name = "txtPortalMobile1"
        Me.txtPortalMobile1.ReadOnly = True
        Me.txtPortalMobile1.Size = New System.Drawing.Size(295, 20)
        Me.txtPortalMobile1.TabIndex = 41
        Me.txtPortalMobile1.TabStop = False
        '
        'btnAddNewOwner
        '
        Me.btnAddNewOwner.AutoSize = True
        Me.btnAddNewOwner.Location = New System.Drawing.Point(423, 774)
        Me.btnAddNewOwner.Name = "btnAddNewOwner"
        Me.btnAddNewOwner.Size = New System.Drawing.Size(119, 27)
        Me.btnAddNewOwner.TabIndex = 173
        Me.btnAddNewOwner.Text = "Add New Owner"
        Me.btnAddNewOwner.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(992, 55)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 174
        Me.Label22.Text = "Owner Since"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(505, 79)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 13)
        Me.Label23.TabIndex = 175
        Me.Label23.Text = "CoOwner"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(12, 406)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 13)
        Me.Label24.TabIndex = 177
        Me.Label24.Text = "EVoting Email"
        '
        'txtEVotingEmailId
        '
        Me.txtEVotingEmailId.Location = New System.Drawing.Point(143, 403)
        Me.txtEVotingEmailId.Name = "txtEVotingEmailId"
        Me.txtEVotingEmailId.ReadOnly = True
        Me.txtEVotingEmailId.Size = New System.Drawing.Size(432, 20)
        Me.txtEVotingEmailId.TabIndex = 176
        Me.txtEVotingEmailId.TabStop = False
        '
        'btnAddEditPOA
        '
        Me.btnAddEditPOA.AutoSize = True
        Me.btnAddEditPOA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAddEditPOA.Location = New System.Drawing.Point(939, 776)
        Me.btnAddEditPOA.Name = "btnAddEditPOA"
        Me.btnAddEditPOA.Size = New System.Drawing.Size(74, 23)
        Me.btnAddEditPOA.TabIndex = 178
        Me.btnAddEditPOA.Text = "POA Details"
        Me.btnAddEditPOA.UseVisualStyleBackColor = True
        '
        'chkPOAExist
        '
        Me.chkPOAExist.AutoSize = True
        Me.chkPOAExist.Checked = True
        Me.chkPOAExist.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPOAExist.Enabled = False
        Me.chkPOAExist.Location = New System.Drawing.Point(841, 779)
        Me.chkPOAExist.Name = "chkPOAExist"
        Me.chkPOAExist.Size = New System.Drawing.Size(73, 17)
        Me.chkPOAExist.TabIndex = 198
        Me.chkPOAExist.Text = "POA Exist"
        Me.chkPOAExist.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.txtBlockedEmails)
        Me.Panel1.Controls.Add(Me.txtEmailBlockReason)
        Me.Panel1.Location = New System.Drawing.Point(16, 627)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1367, 141)
        Me.Panel1.TabIndex = 200
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(853, 17)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 63)
        Me.Label25.TabIndex = 201
        Me.Label25.Text = "Blocked eMails (Comma separated)"
        '
        'txtBlockedEmails
        '
        Me.txtBlockedEmails.Location = New System.Drawing.Point(923, 3)
        Me.txtBlockedEmails.Multiline = True
        Me.txtBlockedEmails.Name = "txtBlockedEmails"
        Me.txtBlockedEmails.ReadOnly = True
        Me.txtBlockedEmails.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtBlockedEmails.Size = New System.Drawing.Size(430, 126)
        Me.txtBlockedEmails.TabIndex = 200
        Me.txtBlockedEmails.TabStop = False
        '
        'txtEmailBlockReason
        '
        Me.txtEmailBlockReason.Location = New System.Drawing.Point(62, 3)
        Me.txtEmailBlockReason.Multiline = True
        Me.txtEmailBlockReason.Name = "txtEmailBlockReason"
        Me.txtEmailBlockReason.ReadOnly = True
        Me.txtEmailBlockReason.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtEmailBlockReason.Size = New System.Drawing.Size(785, 126)
        Me.txtEmailBlockReason.TabIndex = 20
        Me.txtEmailBlockReason.TabStop = False
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(7, 6)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 63)
        Me.Label26.TabIndex = 202
        Me.Label26.Text = "Reason for eMail Blocking"
        '
        'frmManageFlats
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1395, 821)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.chkPOAExist)
        Me.Controls.Add(Me.btnAddEditPOA)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtEVotingEmailId)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.btnAddNewOwner)
        Me.Controls.Add(Me.grpPortal)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOwnerSince)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.txtOwnerSince)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtCommAddress)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtMobile2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtMobile1_SMS)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtLandline2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtLandline1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtEmail2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtEmail1)
        Me.Controls.Add(Me.txtFlat)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTower)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTerraceArea)
        Me.Controls.Add(Me.txtSBUArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtPresentAddress)
        Me.Controls.Add(Me.txtPrimaryPhone)
        Me.Controls.Add(Me.txtPrimaryEmail)
        Me.Controls.Add(Me.txtCoOwner)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtOwner)
        Me.Controls.Add(Me.cboNoOfRooms)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboDuplex)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageFlats"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage Flats"
        Me.grpPortal.ResumeLayout(False)
        Me.grpPortal.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboDuplex As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboNoOfRooms As System.Windows.Forms.ComboBox
    Friend WithEvents txtOwner As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCoOwner As System.Windows.Forms.TextBox
    Friend WithEvents txtPrimaryEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtPrimaryPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtPresentAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSBUArea As System.Windows.Forms.TextBox
    Friend WithEvents txtTerraceArea As System.Windows.Forms.TextBox
    Friend WithEvents txtTower As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFlat As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtEmail1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtEmail2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLandline1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtLandline2 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMobile2 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMobile1_SMS As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCommAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtOwnerSince As System.Windows.Forms.TextBox
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOwnerSince As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grpPortal As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtPortalLandline1 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtPortalEmail2 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtPortalEmail1 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPortalMobile2 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtPortalMobile1 As System.Windows.Forms.TextBox
    Friend WithEvents btnAddNewOwner As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtEVotingEmailId As System.Windows.Forms.TextBox
    Friend WithEvents btnAddEditPOA As System.Windows.Forms.Button
    Friend WithEvents chkPOAExist As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtEmailBlockReason As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtBlockedEmails As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
End Class
