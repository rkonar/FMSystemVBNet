<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchFlat
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvFlats = New System.Windows.Forms.DataGridView()
        Me.FlatCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duplex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlatOwner = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Portal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SoftBill = New System.Windows.Forms.DataGridViewCheckBoxColumn()
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
        CType(Me.dgvFlats, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFlats
        '
        Me.dgvFlats.AllowUserToAddRows = False
        Me.dgvFlats.AllowUserToDeleteRows = False
        Me.dgvFlats.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFlats.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvFlats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFlats.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FlatCode, Me.Duplex, Me.FlatOwner, Me.Email, Me.Phone, Me.Address, Me.Portal, Me.SoftBill})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFlats.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvFlats.Location = New System.Drawing.Point(12, 95)
        Me.dgvFlats.Name = "dgvFlats"
        Me.dgvFlats.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvFlats.RowHeadersVisible = False
        Me.dgvFlats.RowTemplate.Height = 24
        Me.dgvFlats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvFlats.Size = New System.Drawing.Size(1115, 724)
        Me.dgvFlats.TabIndex = 31
        '
        'FlatCode
        '
        Me.FlatCode.HeaderText = "FlatCode"
        Me.FlatCode.Name = "FlatCode"
        '
        'Duplex
        '
        Me.Duplex.HeaderText = "Duplex"
        Me.Duplex.Name = "Duplex"
        '
        'FlatOwner
        '
        Me.FlatOwner.HeaderText = "Owner/CoOwner"
        Me.FlatOwner.MaxInputLength = 1
        Me.FlatOwner.Name = "FlatOwner"
        Me.FlatOwner.Width = 200
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.Width = 150
        '
        'Phone
        '
        Me.Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "D"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Phone.DefaultCellStyle = DataGridViewCellStyle1
        Me.Phone.HeaderText = "Phone"
        Me.Phone.MaxInputLength = 11
        Me.Phone.Name = "Phone"
        Me.Phone.ReadOnly = True
        Me.Phone.Width = 150
        '
        'Address
        '
        Me.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Address.DefaultCellStyle = DataGridViewCellStyle2
        Me.Address.HeaderText = "Address"
        Me.Address.MaxInputLength = 255
        Me.Address.MinimumWidth = 10
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        Me.Address.Width = 250
        '
        'Portal
        '
        Me.Portal.HeaderText = "Portal"
        Me.Portal.Name = "Portal"
        Me.Portal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Portal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Portal.Width = 60
        '
        'SoftBill
        '
        Me.SoftBill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.NullValue = False
        Me.SoftBill.DefaultCellStyle = DataGridViewCellStyle3
        Me.SoftBill.HeaderText = "Soft Bill"
        Me.SoftBill.Name = "SoftBill"
        Me.SoftBill.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SoftBill.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SoftBill.Width = 80
        '
        'btnQuery
        '
        Me.btnQuery.AutoSize = True
        Me.btnQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuery.Location = New System.Drawing.Point(1072, 47)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(57, 27)
        Me.btnQuery.TabIndex = 127
        Me.btnQuery.Text = "Query"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'cboTower
        '
        Me.cboTower.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboTower.FormattingEnabled = True
        Me.cboTower.Items.AddRange(New Object() {"2", "3"})
        Me.cboTower.Location = New System.Drawing.Point(78, 13)
        Me.cboTower.Name = "cboTower"
        Me.cboTower.Size = New System.Drawing.Size(135, 24)
        Me.cboTower.TabIndex = 153
        Me.cboTower.TabStop = False
        '
        'txtFlat
        '
        Me.txtFlat.Location = New System.Drawing.Point(254, 14)
        Me.txtFlat.Name = "txtFlat"
        Me.txtFlat.Size = New System.Drawing.Size(44, 22)
        Me.txtFlat.TabIndex = 152
        Me.txtFlat.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(219, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 17)
        Me.Label9.TabIndex = 151
        Me.Label9.Text = "Flat"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 17)
        Me.Label8.TabIndex = 150
        Me.Label8.Text = "Tower"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(307, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 17)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "Address"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(620, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 17)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "Phone"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(11, 57)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(42, 17)
        Me.lblEmail.TabIndex = 147
        Me.lblEmail.Text = "Email"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(388, 54)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(225, 22)
        Me.txtAddress.TabIndex = 146
        Me.txtAddress.TabStop = False
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(670, 52)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(196, 22)
        Me.txtPhone.TabIndex = 145
        Me.txtPhone.TabStop = False
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(78, 54)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(224, 22)
        Me.txtEmail.TabIndex = 144
        Me.txtEmail.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(618, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "Owner"
        '
        'txtOwner
        '
        Me.txtOwner.Location = New System.Drawing.Point(670, 14)
        Me.txtOwner.Name = "txtOwner"
        Me.txtOwner.Size = New System.Drawing.Size(196, 22)
        Me.txtOwner.TabIndex = 142
        Me.txtOwner.TabStop = False
        '
        'cboNoOfRooms
        '
        Me.cboNoOfRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNoOfRooms.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboNoOfRooms.FormattingEnabled = True
        Me.cboNoOfRooms.Items.AddRange(New Object() {"ALL", "2", "3"})
        Me.cboNoOfRooms.Location = New System.Drawing.Point(523, 13)
        Me.cboNoOfRooms.Name = "cboNoOfRooms"
        Me.cboNoOfRooms.Size = New System.Drawing.Size(64, 24)
        Me.cboNoOfRooms.TabIndex = 141
        Me.cboNoOfRooms.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(470, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 140
        Me.Label4.Text = "Rooms"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(323, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 17)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Duplex?"
        '
        'cboDuplex
        '
        Me.cboDuplex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDuplex.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboDuplex.FormattingEnabled = True
        Me.cboDuplex.Items.AddRange(New Object() {"ALL", "DUPLEX", "NON-DUPLEX"})
        Me.cboDuplex.Location = New System.Drawing.Point(388, 13)
        Me.cboDuplex.Name = "cboDuplex"
        Me.cboDuplex.Size = New System.Drawing.Size(76, 24)
        Me.cboDuplex.TabIndex = 138
        Me.cboDuplex.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(870, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 17)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Using Portal"
        '
        'cboPortal
        '
        Me.cboPortal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPortal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboPortal.FormattingEnabled = True
        Me.cboPortal.Items.AddRange(New Object() {"ALL", "YES", "NO"})
        Me.cboPortal.Location = New System.Drawing.Point(974, 13)
        Me.cboPortal.Name = "cboPortal"
        Me.cboPortal.Size = New System.Drawing.Size(83, 24)
        Me.cboPortal.TabIndex = 156
        Me.cboPortal.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(870, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 17)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Opted Soft Bill"
        '
        'cboSoftBill
        '
        Me.cboSoftBill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSoftBill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboSoftBill.FormattingEnabled = True
        Me.cboSoftBill.Items.AddRange(New Object() {"ALL", "YES", "NO"})
        Me.cboSoftBill.Location = New System.Drawing.Point(974, 50)
        Me.cboSoftBill.Name = "cboSoftBill"
        Me.cboSoftBill.Size = New System.Drawing.Size(83, 24)
        Me.cboSoftBill.TabIndex = 158
        Me.cboSoftBill.TabStop = False
        '
        'btnReset
        '
        Me.btnReset.AutoSize = True
        Me.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnReset.Location = New System.Drawing.Point(1072, 12)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(55, 27)
        Me.btnReset.TabIndex = 160
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'frmSearchFlat
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1140, 831)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboSoftBill)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPortal)
        Me.Controls.Add(Me.cboTower)
        Me.Controls.Add(Me.txtFlat)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtOwner)
        Me.Controls.Add(Me.cboNoOfRooms)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboDuplex)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.dgvFlats)
        Me.Name = "frmSearchFlat"
        Me.Text = "Search Flat"
        CType(Me.dgvFlats, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvFlats As System.Windows.Forms.DataGridView
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
    Friend WithEvents FlatCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Duplex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FlatOwner As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Portal As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SoftBill As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
