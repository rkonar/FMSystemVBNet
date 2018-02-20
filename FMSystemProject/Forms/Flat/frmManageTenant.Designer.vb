<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageTenant
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
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageTenant))
        Me.dgvTenants = New System.Windows.Forms.DataGridView()
        Me.tblid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlatCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TenantName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TenantType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Photo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ApplicationForm = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TenancyAgreement = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IDProof = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PoliceForm = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FeePaid = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.cboTower = New System.Windows.Forms.ComboBox()
        Me.txtFlat = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOwner = New System.Windows.Forms.TextBox()
        Me.cboNoOfRooms = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboDuplex = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPortal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSoftBill = New System.Windows.Forms.ComboBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCnt = New System.Windows.Forms.Label()
        Me.chkOnlyActive = New System.Windows.Forms.CheckBox()
        Me.cboFlatCode = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        Me.chkOnlyExpiringInNDays = New System.Windows.Forms.CheckBox()
        Me.txtExpiringInDays = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.dgvTenants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvTenants
        '
        Me.dgvTenants.AllowUserToAddRows = False
        Me.dgvTenants.AllowUserToDeleteRows = False
        Me.dgvTenants.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTenants.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvTenants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTenants.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tblid, Me.FlatCode, Me.TenantName, Me.Gender, Me.TenantType, Me.StartDate, Me.EndDate, Me.Email, Me.Phone, Me.Address, Me.Photo, Me.ApplicationForm, Me.TenancyAgreement, Me.IDProof, Me.PoliceForm, Me.FeePaid})
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle48.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTenants.DefaultCellStyle = DataGridViewCellStyle48
        Me.dgvTenants.Location = New System.Drawing.Point(12, 45)
        Me.dgvTenants.Name = "dgvTenants"
        Me.dgvTenants.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvTenants.RowHeadersVisible = False
        Me.dgvTenants.RowTemplate.Height = 24
        Me.dgvTenants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTenants.Size = New System.Drawing.Size(1314, 777)
        Me.dgvTenants.TabIndex = 31
        '
        'tblid
        '
        Me.tblid.HeaderText = "tblid"
        Me.tblid.Name = "tblid"
        Me.tblid.ReadOnly = True
        Me.tblid.Visible = False
        '
        'FlatCode
        '
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FlatCode.DefaultCellStyle = DataGridViewCellStyle33
        Me.FlatCode.HeaderText = "Flat Code"
        Me.FlatCode.Name = "FlatCode"
        Me.FlatCode.ReadOnly = True
        Me.FlatCode.Width = 60
        '
        'TenantName
        '
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TenantName.DefaultCellStyle = DataGridViewCellStyle34
        Me.TenantName.HeaderText = "Tenant Name"
        Me.TenantName.Name = "TenantName"
        Me.TenantName.ReadOnly = True
        Me.TenantName.Width = 200
        '
        'Gender
        '
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Gender.DefaultCellStyle = DataGridViewCellStyle35
        Me.Gender.HeaderText = "Gender"
        Me.Gender.Name = "Gender"
        Me.Gender.ReadOnly = True
        Me.Gender.Width = 60
        '
        'TenantType
        '
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TenantType.DefaultCellStyle = DataGridViewCellStyle36
        Me.TenantType.HeaderText = "Type"
        Me.TenantType.Name = "TenantType"
        Me.TenantType.ReadOnly = True
        '
        'StartDate
        '
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.StartDate.DefaultCellStyle = DataGridViewCellStyle37
        Me.StartDate.HeaderText = "Start Date"
        Me.StartDate.Name = "StartDate"
        Me.StartDate.ReadOnly = True
        '
        'EndDate
        '
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EndDate.DefaultCellStyle = DataGridViewCellStyle38
        Me.EndDate.HeaderText = "End Date"
        Me.EndDate.Name = "EndDate"
        Me.EndDate.ReadOnly = True
        '
        'Email
        '
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Email.DefaultCellStyle = DataGridViewCellStyle39
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Visible = False
        Me.Email.Width = 150
        '
        'Phone
        '
        Me.Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle40.Format = "D"
        DataGridViewCellStyle40.NullValue = Nothing
        DataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Phone.DefaultCellStyle = DataGridViewCellStyle40
        Me.Phone.HeaderText = "Phone"
        Me.Phone.MaxInputLength = 100
        Me.Phone.Name = "Phone"
        Me.Phone.ReadOnly = True
        '
        'Address
        '
        Me.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Address.DefaultCellStyle = DataGridViewCellStyle41
        Me.Address.HeaderText = "Permanent Address"
        Me.Address.MaxInputLength = 255
        Me.Address.MinimumWidth = 10
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        Me.Address.Visible = False
        Me.Address.Width = 250
        '
        'Photo
        '
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle42.NullValue = False
        DataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Photo.DefaultCellStyle = DataGridViewCellStyle42
        Me.Photo.HeaderText = "Photo Taken"
        Me.Photo.Name = "Photo"
        Me.Photo.ReadOnly = True
        Me.Photo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Photo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ApplicationForm
        '
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle43.NullValue = False
        DataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ApplicationForm.DefaultCellStyle = DataGridViewCellStyle43
        Me.ApplicationForm.HeaderText = "Application Form"
        Me.ApplicationForm.Name = "ApplicationForm"
        Me.ApplicationForm.ReadOnly = True
        Me.ApplicationForm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ApplicationForm.Width = 125
        '
        'TenancyAgreement
        '
        Me.TenancyAgreement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle44.NullValue = False
        DataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TenancyAgreement.DefaultCellStyle = DataGridViewCellStyle44
        Me.TenancyAgreement.HeaderText = "Agreement"
        Me.TenancyAgreement.Name = "TenancyAgreement"
        Me.TenancyAgreement.ReadOnly = True
        Me.TenancyAgreement.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TenancyAgreement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TenancyAgreement.Width = 95
        '
        'IDProof
        '
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle45.NullValue = False
        DataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IDProof.DefaultCellStyle = DataGridViewCellStyle45
        Me.IDProof.HeaderText = "ID Proof"
        Me.IDProof.Name = "IDProof"
        Me.IDProof.ReadOnly = True
        Me.IDProof.Width = 70
        '
        'PoliceForm
        '
        DataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle46.NullValue = False
        DataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PoliceForm.DefaultCellStyle = DataGridViewCellStyle46
        Me.PoliceForm.HeaderText = "Police Form"
        Me.PoliceForm.Name = "PoliceForm"
        Me.PoliceForm.ReadOnly = True
        Me.PoliceForm.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PoliceForm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PoliceForm.Width = 105
        '
        'FeePaid
        '
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle47.NullValue = False
        DataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FeePaid.DefaultCellStyle = DataGridViewCellStyle47
        Me.FeePaid.HeaderText = "Fee Paid"
        Me.FeePaid.Name = "FeePaid"
        Me.FeePaid.ReadOnly = True
        Me.FeePaid.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FeePaid.Width = 80
        '
        'btnQuery
        '
        Me.btnQuery.AutoSize = True
        Me.btnQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuery.Location = New System.Drawing.Point(1110, 12)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(45, 23)
        Me.btnQuery.TabIndex = 127
        Me.btnQuery.Text = "Query"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'cboTower
        '
        Me.cboTower.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboTower.FormattingEnabled = True
        Me.cboTower.Items.AddRange(New Object() {"2", "3"})
        Me.cboTower.Location = New System.Drawing.Point(73, 18)
        Me.cboTower.Name = "cboTower"
        Me.cboTower.Size = New System.Drawing.Size(135, 21)
        Me.cboTower.TabIndex = 153
        Me.cboTower.TabStop = False
        '
        'txtFlat
        '
        Me.txtFlat.Location = New System.Drawing.Point(249, 19)
        Me.txtFlat.Name = "txtFlat"
        Me.txtFlat.Size = New System.Drawing.Size(44, 20)
        Me.txtFlat.TabIndex = 152
        Me.txtFlat.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(214, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 151
        Me.Label9.Text = "Flat"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 150
        Me.Label8.Text = "Tower"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(302, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "Address"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(615, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "Phone"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(6, 62)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblEmail.TabIndex = 147
        Me.lblEmail.Text = "Email"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(383, 59)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(225, 20)
        Me.txtAddress.TabIndex = 146
        Me.txtAddress.TabStop = False
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(665, 57)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(196, 20)
        Me.txtPhone.TabIndex = 145
        Me.txtPhone.TabStop = False
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(73, 59)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(224, 20)
        Me.txtEmail.TabIndex = 144
        Me.txtEmail.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(613, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "Owner"
        '
        'txtOwner
        '
        Me.txtOwner.Location = New System.Drawing.Point(665, 19)
        Me.txtOwner.Name = "txtOwner"
        Me.txtOwner.Size = New System.Drawing.Size(196, 20)
        Me.txtOwner.TabIndex = 142
        Me.txtOwner.TabStop = False
        '
        'cboNoOfRooms
        '
        Me.cboNoOfRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNoOfRooms.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboNoOfRooms.FormattingEnabled = True
        Me.cboNoOfRooms.Items.AddRange(New Object() {"ALL", "2", "3"})
        Me.cboNoOfRooms.Location = New System.Drawing.Point(518, 18)
        Me.cboNoOfRooms.Name = "cboNoOfRooms"
        Me.cboNoOfRooms.Size = New System.Drawing.Size(64, 21)
        Me.cboNoOfRooms.TabIndex = 141
        Me.cboNoOfRooms.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(465, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 140
        Me.Label4.Text = "Rooms"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(318, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Duplex?"
        '
        'cboDuplex
        '
        Me.cboDuplex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDuplex.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboDuplex.FormattingEnabled = True
        Me.cboDuplex.Items.AddRange(New Object() {"ALL", "DUPLEX", "NON-DUPLEX"})
        Me.cboDuplex.Location = New System.Drawing.Point(383, 18)
        Me.cboDuplex.Name = "cboDuplex"
        Me.cboDuplex.Size = New System.Drawing.Size(76, 21)
        Me.cboDuplex.TabIndex = 138
        Me.cboDuplex.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(865, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Using Portal"
        '
        'cboPortal
        '
        Me.cboPortal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPortal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboPortal.FormattingEnabled = True
        Me.cboPortal.Items.AddRange(New Object() {"ALL", "YES", "NO"})
        Me.cboPortal.Location = New System.Drawing.Point(969, 18)
        Me.cboPortal.Name = "cboPortal"
        Me.cboPortal.Size = New System.Drawing.Size(83, 21)
        Me.cboPortal.TabIndex = 156
        Me.cboPortal.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(865, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Opted Soft Bill"
        '
        'cboSoftBill
        '
        Me.cboSoftBill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSoftBill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboSoftBill.FormattingEnabled = True
        Me.cboSoftBill.Items.AddRange(New Object() {"ALL", "YES", "NO"})
        Me.cboSoftBill.Location = New System.Drawing.Point(969, 55)
        Me.cboSoftBill.Name = "cboSoftBill"
        Me.cboSoftBill.Size = New System.Drawing.Size(83, 21)
        Me.cboSoftBill.TabIndex = 158
        Me.cboSoftBill.TabStop = False
        '
        'btnReset
        '
        Me.btnReset.AutoSize = True
        Me.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnReset.Location = New System.Drawing.Point(1075, 40)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(45, 23)
        Me.btnReset.TabIndex = 160
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = True
        Me.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAdd.Location = New System.Drawing.Point(1171, 12)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(98, 23)
        Me.btnAdd.TabIndex = 161
        Me.btnAdd.Text = "Add New Tenant"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtAddress)
        Me.Panel1.Controls.Add(Me.cboDuplex)
        Me.Panel1.Controls.Add(Me.btnReset)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cboSoftBill)
        Me.Panel1.Controls.Add(Me.cboNoOfRooms)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtOwner)
        Me.Panel1.Controls.Add(Me.cboPortal)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cboTower)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.txtFlat)
        Me.Panel1.Controls.Add(Me.txtPhone)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lblEmail)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(64, 213)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1133, 100)
        Me.Panel1.TabIndex = 162
        Me.Panel1.Visible = False
        '
        'lblCnt
        '
        Me.lblCnt.BackColor = System.Drawing.Color.Black
        Me.lblCnt.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCnt.ForeColor = System.Drawing.Color.White
        Me.lblCnt.Location = New System.Drawing.Point(12, 20)
        Me.lblCnt.Name = "lblCnt"
        Me.lblCnt.Size = New System.Drawing.Size(67, 22)
        Me.lblCnt.TabIndex = 163
        Me.lblCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkOnlyActive
        '
        Me.chkOnlyActive.AutoSize = True
        Me.chkOnlyActive.Checked = True
        Me.chkOnlyActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOnlyActive.Location = New System.Drawing.Point(340, 18)
        Me.chkOnlyActive.Name = "chkOnlyActive"
        Me.chkOnlyActive.Size = New System.Drawing.Size(110, 17)
        Me.chkOnlyActive.TabIndex = 197
        Me.chkOnlyActive.Text = "Show Only Active"
        Me.chkOnlyActive.UseVisualStyleBackColor = True
        '
        'cboFlatCode
        '
        Me.cboFlatCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboFlatCode.FormattingEnabled = True
        Me.cboFlatCode.Location = New System.Drawing.Point(981, 13)
        Me.cboFlatCode.Name = "cboFlatCode"
        Me.cboFlatCode.Size = New System.Drawing.Size(119, 21)
        Me.cboFlatCode.TabIndex = 198
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(926, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 199
        Me.Label10.Text = "FlatCode"
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.AutoSize = True
        Me.btnExportToExcel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.Location = New System.Drawing.Point(1303, 20)
        Me.btnExportToExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(22, 22)
        Me.btnExportToExcel.TabIndex = 200
        Me.btnExportToExcel.UseVisualStyleBackColor = True
        '
        'chkOnlyExpiringInNDays
        '
        Me.chkOnlyExpiringInNDays.AutoSize = True
        Me.chkOnlyExpiringInNDays.Location = New System.Drawing.Point(477, 18)
        Me.chkOnlyExpiringInNDays.Name = "chkOnlyExpiringInNDays"
        Me.chkOnlyExpiringInNDays.Size = New System.Drawing.Size(128, 17)
        Me.chkOnlyExpiringInNDays.TabIndex = 201
        Me.chkOnlyExpiringInNDays.Text = "Show Only Expiring in"
        Me.chkOnlyExpiringInNDays.UseVisualStyleBackColor = True
        '
        'txtExpiringInDays
        '
        Me.txtExpiringInDays.Enabled = False
        Me.txtExpiringInDays.Location = New System.Drawing.Point(604, 16)
        Me.txtExpiringInDays.Name = "txtExpiringInDays"
        Me.txtExpiringInDays.Size = New System.Drawing.Size(44, 20)
        Me.txtExpiringInDays.TabIndex = 202
        Me.txtExpiringInDays.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(653, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 203
        Me.Label11.Text = "Days"
        '
        'frmManageTenant
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1338, 831)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtExpiringInDays)
        Me.Controls.Add(Me.chkOnlyExpiringInNDays)
        Me.Controls.Add(Me.btnExportToExcel)
        Me.Controls.Add(Me.cboFlatCode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.chkOnlyActive)
        Me.Controls.Add(Me.lblCnt)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.dgvTenants)
        Me.Name = "frmManageTenant"
        Me.Text = "Manage Tenants"
        CType(Me.dgvTenants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvTenants As System.Windows.Forms.DataGridView
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents cboTower As System.Windows.Forms.ComboBox
    Friend WithEvents txtFlat As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOwner As System.Windows.Forms.TextBox
    Friend WithEvents cboNoOfRooms As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDuplex As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPortal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSoftBill As System.Windows.Forms.ComboBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCnt As System.Windows.Forms.Label
    Friend WithEvents tblid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FlatCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TenantName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TenantType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Photo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ApplicationForm As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TenancyAgreement As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IDProof As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PoliceForm As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FeePaid As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkOnlyActive As System.Windows.Forms.CheckBox
    Friend WithEvents cboFlatCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnExportToExcel As System.Windows.Forms.Button
    Friend WithEvents chkOnlyExpiringInNDays As System.Windows.Forms.CheckBox
    Friend WithEvents txtExpiringInDays As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
