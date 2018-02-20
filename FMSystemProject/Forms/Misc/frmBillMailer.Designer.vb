<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillMailer
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cboBill = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgvFlat = New System.Windows.Forms.DataGridView()
        Me.tblid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DueDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkMail = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.chkSMS = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.flatCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.billMailed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.billSMSed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.softBill = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ownerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eMail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mobile1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsingPortal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkSoftBill = New System.Windows.Forms.CheckBox()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnMailBill = New System.Windows.Forms.Button()
        Me.chkSelectAll4Mail = New System.Windows.Forms.CheckBox()
        Me.grpExpenseType = New System.Windows.Forms.GroupBox()
        Me.optSHR = New System.Windows.Forms.RadioButton()
        Me.optSUK = New System.Windows.Forms.RadioButton()
        Me.optAll = New System.Windows.Forms.RadioButton()
        Me.optSAN = New System.Windows.Forms.RadioButton()
        Me.optSAP = New System.Windows.Forms.RadioButton()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.btnSMSBill = New System.Windows.Forms.Button()
        Me.chkSelectAll4SMS = New System.Windows.Forms.CheckBox()
        Me.btnShowAllEmailsFromPortal = New System.Windows.Forms.Button()
        Me.txtAllPortalEmails = New System.Windows.Forms.TextBox()
        Me.btnEvoting = New System.Windows.Forms.Button()
        Me.btnSMSReminder = New System.Windows.Forms.Button()
        Me.txtMailDelay = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvFlat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpExpenseType.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboBill
        '
        Me.cboBill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboBill.FormattingEnabled = True
        Me.cboBill.Location = New System.Drawing.Point(52, 5)
        Me.cboBill.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cboBill.Name = "cboBill"
        Me.cboBill.Size = New System.Drawing.Size(444, 21)
        Me.cboBill.TabIndex = 144
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 7)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 145
        Me.Label9.Text = "For Bill"
        '
        'dgvFlat
        '
        Me.dgvFlat.AllowUserToAddRows = False
        Me.dgvFlat.AllowUserToDeleteRows = False
        Me.dgvFlat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFlat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvFlat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFlat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tblid, Me.BillNo, Me.DueDate, Me.chkMail, Me.chkSMS, Me.flatCode, Me.billMailed, Me.billSMSed, Me.softBill, Me.ownerName, Me.eMail, Me.Mobile1, Me.UsingPortal})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFlat.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvFlat.Location = New System.Drawing.Point(11, 119)
        Me.dgvFlat.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dgvFlat.Name = "dgvFlat"
        Me.dgvFlat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvFlat.RowHeadersVisible = False
        Me.dgvFlat.RowTemplate.Height = 24
        Me.dgvFlat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvFlat.Size = New System.Drawing.Size(760, 541)
        Me.dgvFlat.TabIndex = 146
        '
        'tblid
        '
        Me.tblid.HeaderText = "tblbill_id"
        Me.tblid.Name = "tblid"
        Me.tblid.Visible = False
        '
        'BillNo
        '
        Me.BillNo.HeaderText = "BillNo"
        Me.BillNo.Name = "BillNo"
        Me.BillNo.Visible = False
        '
        'DueDate
        '
        Me.DueDate.HeaderText = "DueDate"
        Me.DueDate.Name = "DueDate"
        Me.DueDate.ReadOnly = True
        Me.DueDate.Visible = False
        '
        'chkMail
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle8.NullValue = False
        Me.chkMail.DefaultCellStyle = DataGridViewCellStyle8
        Me.chkMail.HeaderText = "Mail"
        Me.chkMail.Name = "chkMail"
        Me.chkMail.Width = 40
        '
        'chkSMS
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle9.NullValue = False
        Me.chkSMS.DefaultCellStyle = DataGridViewCellStyle9
        Me.chkSMS.HeaderText = "SMS"
        Me.chkSMS.Name = "chkSMS"
        Me.chkSMS.Width = 40
        '
        'flatCode
        '
        Me.flatCode.HeaderText = "Flat"
        Me.flatCode.Name = "flatCode"
        Me.flatCode.ReadOnly = True
        Me.flatCode.Width = 80
        '
        'billMailed
        '
        Me.billMailed.HeaderText = "Bill Mailed"
        Me.billMailed.Name = "billMailed"
        Me.billMailed.ReadOnly = True
        Me.billMailed.Width = 80
        '
        'billSMSed
        '
        Me.billSMSed.HeaderText = "SMS Sent"
        Me.billSMSed.Name = "billSMSed"
        Me.billSMSed.ReadOnly = True
        Me.billSMSed.Width = 80
        '
        'softBill
        '
        Me.softBill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Format = "D"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.softBill.DefaultCellStyle = DataGridViewCellStyle10
        Me.softBill.HeaderText = "Soft Bill"
        Me.softBill.MaxInputLength = 11
        Me.softBill.Name = "softBill"
        Me.softBill.ReadOnly = True
        Me.softBill.Width = 70
        '
        'ownerName
        '
        Me.ownerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ownerName.DefaultCellStyle = DataGridViewCellStyle11
        Me.ownerName.HeaderText = "Owner Name"
        Me.ownerName.MaxInputLength = 13
        Me.ownerName.Name = "ownerName"
        Me.ownerName.ReadOnly = True
        Me.ownerName.Width = 200
        '
        'eMail
        '
        Me.eMail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.eMail.DefaultCellStyle = DataGridViewCellStyle12
        Me.eMail.HeaderText = "eMail"
        Me.eMail.MaxInputLength = 255
        Me.eMail.MinimumWidth = 10
        Me.eMail.Name = "eMail"
        Me.eMail.ReadOnly = True
        Me.eMail.Width = 200
        '
        'Mobile1
        '
        Me.Mobile1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Mobile1.DefaultCellStyle = DataGridViewCellStyle13
        Me.Mobile1.HeaderText = "Mobile1"
        Me.Mobile1.MaxInputLength = 20
        Me.Mobile1.Name = "Mobile1"
        Me.Mobile1.ReadOnly = True
        '
        'UsingPortal
        '
        Me.UsingPortal.HeaderText = "UsingPortal"
        Me.UsingPortal.Name = "UsingPortal"
        '
        'chkSoftBill
        '
        Me.chkSoftBill.AutoSize = True
        Me.chkSoftBill.Location = New System.Drawing.Point(329, 31)
        Me.chkSoftBill.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.chkSoftBill.Name = "chkSoftBill"
        Me.chkSoftBill.Size = New System.Drawing.Size(85, 17)
        Me.chkSoftBill.TabIndex = 147
        Me.chkSoftBill.Text = "Only Soft Bill"
        Me.chkSoftBill.UseVisualStyleBackColor = True
        Me.chkSoftBill.Visible = False
        '
        'btnQuery
        '
        Me.btnQuery.AutoSize = True
        Me.btnQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuery.BackColor = System.Drawing.Color.Yellow
        Me.btnQuery.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuery.ForeColor = System.Drawing.Color.Red
        Me.btnQuery.Location = New System.Drawing.Point(492, 96)
        Me.btnQuery.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(50, 23)
        Me.btnQuery.TabIndex = 148
        Me.btnQuery.Text = "Query"
        Me.btnQuery.UseVisualStyleBackColor = False
        '
        'btnMailBill
        '
        Me.btnMailBill.AutoSize = True
        Me.btnMailBill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnMailBill.ForeColor = System.Drawing.Color.Blue
        Me.btnMailBill.Location = New System.Drawing.Point(661, 94)
        Me.btnMailBill.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnMailBill.Name = "btnMailBill"
        Me.btnMailBill.Size = New System.Drawing.Size(113, 23)
        Me.btnMailBill.TabIndex = 149
        Me.btnMailBill.Text = "Email to All Selected"
        Me.btnMailBill.UseVisualStyleBackColor = True
        '
        'chkSelectAll4Mail
        '
        Me.chkSelectAll4Mail.AutoSize = True
        Me.chkSelectAll4Mail.Location = New System.Drawing.Point(372, 48)
        Me.chkSelectAll4Mail.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.chkSelectAll4Mail.Name = "chkSelectAll4Mail"
        Me.chkSelectAll4Mail.Size = New System.Drawing.Size(107, 17)
        Me.chkSelectAll4Mail.TabIndex = 150
        Me.chkSelectAll4Mail.Text = "Select All for Mail"
        Me.chkSelectAll4Mail.UseVisualStyleBackColor = True
        '
        'grpExpenseType
        '
        Me.grpExpenseType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpExpenseType.Controls.Add(Me.optSHR)
        Me.grpExpenseType.Controls.Add(Me.optSUK)
        Me.grpExpenseType.Controls.Add(Me.optAll)
        Me.grpExpenseType.Controls.Add(Me.optSAN)
        Me.grpExpenseType.Controls.Add(Me.optSAP)
        Me.grpExpenseType.Location = New System.Drawing.Point(12, 46)
        Me.grpExpenseType.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.grpExpenseType.Name = "grpExpenseType"
        Me.grpExpenseType.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.grpExpenseType.Size = New System.Drawing.Size(356, 41)
        Me.grpExpenseType.TabIndex = 155
        Me.grpExpenseType.TabStop = False
        '
        'optSHR
        '
        Me.optSHR.AutoSize = True
        Me.optSHR.Location = New System.Drawing.Point(280, 15)
        Me.optSHR.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optSHR.Name = "optSHR"
        Me.optSHR.Size = New System.Drawing.Size(71, 17)
        Me.optSHR.TabIndex = 4
        Me.optSHR.Text = "Shrobona"
        Me.optSHR.UseVisualStyleBackColor = True
        '
        'optSUK
        '
        Me.optSUK.AutoSize = True
        Me.optSUK.Location = New System.Drawing.Point(214, 15)
        Me.optSUK.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optSUK.Name = "optSUK"
        Me.optSUK.Size = New System.Drawing.Size(62, 17)
        Me.optSUK.TabIndex = 3
        Me.optSUK.Text = "Suktara"
        Me.optSUK.UseVisualStyleBackColor = True
        '
        'optAll
        '
        Me.optAll.AutoSize = True
        Me.optAll.Checked = True
        Me.optAll.Location = New System.Drawing.Point(10, 15)
        Me.optAll.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optAll.Name = "optAll"
        Me.optAll.Size = New System.Drawing.Size(36, 17)
        Me.optAll.TabIndex = 2
        Me.optAll.TabStop = True
        Me.optAll.Text = "All"
        Me.optAll.UseVisualStyleBackColor = True
        '
        'optSAN
        '
        Me.optSAN.AutoSize = True
        Me.optSAN.Location = New System.Drawing.Point(124, 15)
        Me.optSAN.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optSAN.Name = "optSAN"
        Me.optSAN.Size = New System.Drawing.Size(85, 17)
        Me.optSAN.TabIndex = 1
        Me.optSAN.Text = "Sandhyatara"
        Me.optSAN.UseVisualStyleBackColor = True
        '
        'optSAP
        '
        Me.optSAP.AutoSize = True
        Me.optSAP.Location = New System.Drawing.Point(50, 15)
        Me.optSAP.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optSAP.Name = "optSAP"
        Me.optSAP.Size = New System.Drawing.Size(69, 17)
        Me.optSAP.TabIndex = 0
        Me.optSAP.Text = "Saptarshi"
        Me.optSAP.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(510, 7)
        Me.lblMsg.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(39, 13)
        Me.lblMsg.TabIndex = 156
        Me.lblMsg.Text = "        "
        '
        'btnSMSBill
        '
        Me.btnSMSBill.AutoSize = True
        Me.btnSMSBill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSMSBill.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSMSBill.Location = New System.Drawing.Point(550, 94)
        Me.btnSMSBill.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSMSBill.Name = "btnSMSBill"
        Me.btnSMSBill.Size = New System.Drawing.Size(111, 23)
        Me.btnSMSBill.TabIndex = 157
        Me.btnSMSBill.Text = "SMS to All Selected"
        Me.btnSMSBill.UseVisualStyleBackColor = True
        '
        'chkSelectAll4SMS
        '
        Me.chkSelectAll4SMS.AutoSize = True
        Me.chkSelectAll4SMS.Location = New System.Drawing.Point(372, 70)
        Me.chkSelectAll4SMS.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.chkSelectAll4SMS.Name = "chkSelectAll4SMS"
        Me.chkSelectAll4SMS.Size = New System.Drawing.Size(111, 17)
        Me.chkSelectAll4SMS.TabIndex = 158
        Me.chkSelectAll4SMS.Text = "Select All for SMS"
        Me.chkSelectAll4SMS.UseVisualStyleBackColor = True
        '
        'btnShowAllEmailsFromPortal
        '
        Me.btnShowAllEmailsFromPortal.AutoSize = True
        Me.btnShowAllEmailsFromPortal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnShowAllEmailsFromPortal.ForeColor = System.Drawing.Color.Blue
        Me.btnShowAllEmailsFromPortal.Location = New System.Drawing.Point(238, 29)
        Me.btnShowAllEmailsFromPortal.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnShowAllEmailsFromPortal.Name = "btnShowAllEmailsFromPortal"
        Me.btnShowAllEmailsFromPortal.Size = New System.Drawing.Size(91, 23)
        Me.btnShowAllEmailsFromPortal.TabIndex = 159
        Me.btnShowAllEmailsFromPortal.Text = "Show All Emails"
        Me.btnShowAllEmailsFromPortal.UseVisualStyleBackColor = True
        Me.btnShowAllEmailsFromPortal.Visible = False
        '
        'txtAllPortalEmails
        '
        Me.txtAllPortalEmails.Location = New System.Drawing.Point(22, 158)
        Me.txtAllPortalEmails.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtAllPortalEmails.Multiline = True
        Me.txtAllPortalEmails.Name = "txtAllPortalEmails"
        Me.txtAllPortalEmails.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAllPortalEmails.Size = New System.Drawing.Size(744, 475)
        Me.txtAllPortalEmails.TabIndex = 160
        Me.txtAllPortalEmails.Visible = False
        '
        'btnEvoting
        '
        Me.btnEvoting.Location = New System.Drawing.Point(12, 29)
        Me.btnEvoting.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnEvoting.Name = "btnEvoting"
        Me.btnEvoting.Size = New System.Drawing.Size(103, 19)
        Me.btnEvoting.TabIndex = 161
        Me.btnEvoting.Text = "Manage eVoting"
        Me.btnEvoting.UseVisualStyleBackColor = True
        Me.btnEvoting.Visible = False
        '
        'btnSMSReminder
        '
        Me.btnSMSReminder.AutoSize = True
        Me.btnSMSReminder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSMSReminder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSMSReminder.Location = New System.Drawing.Point(119, 28)
        Me.btnSMSReminder.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSMSReminder.Name = "btnSMSReminder"
        Me.btnSMSReminder.Size = New System.Drawing.Size(118, 23)
        Me.btnSMSReminder.TabIndex = 162
        Me.btnSMSReminder.Text = "SMS Reminder To All"
        Me.btnSMSReminder.UseVisualStyleBackColor = True
        Me.btnSMSReminder.Visible = False
        '
        'txtMailDelay
        '
        Me.txtMailDelay.Location = New System.Drawing.Point(640, 72)
        Me.txtMailDelay.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtMailDelay.Name = "txtMailDelay"
        Me.txtMailDelay.Size = New System.Drawing.Size(26, 20)
        Me.txtMailDelay.TabIndex = 167
        Me.txtMailDelay.Text = "20"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(551, 74)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 168
        Me.Label3.Text = "Delay (Seconds)"
        '
        'frmBillMailer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 670)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMailDelay)
        Me.Controls.Add(Me.btnSMSReminder)
        Me.Controls.Add(Me.btnEvoting)
        Me.Controls.Add(Me.txtAllPortalEmails)
        Me.Controls.Add(Me.btnShowAllEmailsFromPortal)
        Me.Controls.Add(Me.chkSelectAll4SMS)
        Me.Controls.Add(Me.btnSMSBill)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.grpExpenseType)
        Me.Controls.Add(Me.chkSelectAll4Mail)
        Me.Controls.Add(Me.btnMailBill)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.chkSoftBill)
        Me.Controls.Add(Me.dgvFlat)
        Me.Controls.Add(Me.cboBill)
        Me.Controls.Add(Me.Label9)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmBillMailer"
        Me.Text = "Bill Mailer"
        CType(Me.dgvFlat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpExpenseType.ResumeLayout(False)
        Me.grpExpenseType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboBill As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvFlat As System.Windows.Forms.DataGridView
    Friend WithEvents chkSoftBill As System.Windows.Forms.CheckBox
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents btnMailBill As System.Windows.Forms.Button
    Friend WithEvents chkSelectAll4Mail As System.Windows.Forms.CheckBox
    Friend WithEvents grpExpenseType As System.Windows.Forms.GroupBox
    Friend WithEvents optSHR As System.Windows.Forms.RadioButton
    Friend WithEvents optSUK As System.Windows.Forms.RadioButton
    Friend WithEvents optAll As System.Windows.Forms.RadioButton
    Friend WithEvents optSAN As System.Windows.Forms.RadioButton
    Friend WithEvents optSAP As System.Windows.Forms.RadioButton
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents btnSMSBill As System.Windows.Forms.Button
    Friend WithEvents chkSelectAll4SMS As System.Windows.Forms.CheckBox
    Friend WithEvents tblid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkMail As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkSMS As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents flatCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents billMailed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents billSMSed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents softBill As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ownerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents eMail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mobile1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsingPortal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnShowAllEmailsFromPortal As System.Windows.Forms.Button
    Friend WithEvents txtAllPortalEmails As System.Windows.Forms.TextBox
    Friend WithEvents btnEvoting As System.Windows.Forms.Button
    Friend WithEvents btnSMSReminder As System.Windows.Forms.Button
    Friend WithEvents txtMailDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
