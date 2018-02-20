<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEVoteMailer
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
        Me.dgvFlat = New System.Windows.Forms.DataGridView()
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
        Me.AllEmails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.evoting_mailid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvFlat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpExpenseType.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvFlat
        '
        Me.dgvFlat.AllowUserToAddRows = False
        Me.dgvFlat.AllowUserToDeleteRows = False
        Me.dgvFlat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFlat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvFlat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFlat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tblid, Me.BillNo, Me.DueDate, Me.chkMail, Me.chkSMS, Me.flatCode, Me.billMailed, Me.billSMSed, Me.softBill, Me.ownerName, Me.eMail, Me.AllEmails, Me.evoting_mailid})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFlat.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvFlat.Location = New System.Drawing.Point(15, 111)
        Me.dgvFlat.Name = "dgvFlat"
        Me.dgvFlat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvFlat.RowHeadersVisible = False
        Me.dgvFlat.RowTemplate.Height = 24
        Me.dgvFlat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvFlat.Size = New System.Drawing.Size(1518, 702)
        Me.dgvFlat.TabIndex = 146
        '
        'btnQuery
        '
        Me.btnQuery.AutoSize = True
        Me.btnQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuery.BackColor = System.Drawing.Color.Yellow
        Me.btnQuery.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuery.ForeColor = System.Drawing.Color.Red
        Me.btnQuery.Location = New System.Drawing.Point(506, 72)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(62, 27)
        Me.btnQuery.TabIndex = 148
        Me.btnQuery.Text = "Query"
        Me.btnQuery.UseVisualStyleBackColor = False
        '
        'btnMailBill
        '
        Me.btnMailBill.AutoSize = True
        Me.btnMailBill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnMailBill.ForeColor = System.Drawing.Color.Blue
        Me.btnMailBill.Location = New System.Drawing.Point(747, 51)
        Me.btnMailBill.Name = "btnMailBill"
        Me.btnMailBill.Size = New System.Drawing.Size(146, 27)
        Me.btnMailBill.TabIndex = 149
        Me.btnMailBill.Text = "Email to All Selected"
        Me.btnMailBill.UseVisualStyleBackColor = True
        '
        'chkSelectAll4Mail
        '
        Me.chkSelectAll4Mail.AutoSize = True
        Me.chkSelectAll4Mail.Location = New System.Drawing.Point(601, 54)
        Me.chkSelectAll4Mail.Name = "chkSelectAll4Mail"
        Me.chkSelectAll4Mail.Size = New System.Drawing.Size(138, 21)
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
        Me.grpExpenseType.Location = New System.Drawing.Point(16, 57)
        Me.grpExpenseType.Name = "grpExpenseType"
        Me.grpExpenseType.Size = New System.Drawing.Size(474, 50)
        Me.grpExpenseType.TabIndex = 155
        Me.grpExpenseType.TabStop = False
        '
        'optSHR
        '
        Me.optSHR.AutoSize = True
        Me.optSHR.Location = New System.Drawing.Point(374, 18)
        Me.optSHR.Name = "optSHR"
        Me.optSHR.Size = New System.Drawing.Size(91, 21)
        Me.optSHR.TabIndex = 4
        Me.optSHR.Text = "Shrobona"
        Me.optSHR.UseVisualStyleBackColor = True
        '
        'optSUK
        '
        Me.optSUK.AutoSize = True
        Me.optSUK.Location = New System.Drawing.Point(286, 18)
        Me.optSUK.Name = "optSUK"
        Me.optSUK.Size = New System.Drawing.Size(78, 21)
        Me.optSUK.TabIndex = 3
        Me.optSUK.Text = "Suktara"
        Me.optSUK.UseVisualStyleBackColor = True
        '
        'optAll
        '
        Me.optAll.AutoSize = True
        Me.optAll.Checked = True
        Me.optAll.Location = New System.Drawing.Point(13, 18)
        Me.optAll.Name = "optAll"
        Me.optAll.Size = New System.Drawing.Size(44, 21)
        Me.optAll.TabIndex = 2
        Me.optAll.TabStop = True
        Me.optAll.Text = "All"
        Me.optAll.UseVisualStyleBackColor = True
        '
        'optSAN
        '
        Me.optSAN.AutoSize = True
        Me.optSAN.Location = New System.Drawing.Point(166, 18)
        Me.optSAN.Name = "optSAN"
        Me.optSAN.Size = New System.Drawing.Size(110, 21)
        Me.optSAN.TabIndex = 1
        Me.optSAN.Text = "Sandhyatara"
        Me.optSAN.UseVisualStyleBackColor = True
        '
        'optSAP
        '
        Me.optSAP.AutoSize = True
        Me.optSAP.Location = New System.Drawing.Point(67, 18)
        Me.optSAP.Name = "optSAP"
        Me.optSAP.Size = New System.Drawing.Size(89, 21)
        Me.optSAP.TabIndex = 0
        Me.optSAP.Text = "Saptarshi"
        Me.optSAP.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(719, 9)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(48, 17)
        Me.lblMsg.TabIndex = 156
        Me.lblMsg.Text = "        "
        '
        'btnSMSBill
        '
        Me.btnSMSBill.AutoSize = True
        Me.btnSMSBill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSMSBill.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSMSBill.Location = New System.Drawing.Point(747, 82)
        Me.btnSMSBill.Name = "btnSMSBill"
        Me.btnSMSBill.Size = New System.Drawing.Size(141, 27)
        Me.btnSMSBill.TabIndex = 157
        Me.btnSMSBill.Text = "SMS to All Selected"
        Me.btnSMSBill.UseVisualStyleBackColor = True
        '
        'chkSelectAll4SMS
        '
        Me.chkSelectAll4SMS.AutoSize = True
        Me.chkSelectAll4SMS.Location = New System.Drawing.Point(601, 85)
        Me.chkSelectAll4SMS.Name = "chkSelectAll4SMS"
        Me.chkSelectAll4SMS.Size = New System.Drawing.Size(142, 21)
        Me.chkSelectAll4SMS.TabIndex = 158
        Me.chkSelectAll4SMS.Text = "Select All for SMS"
        Me.chkSelectAll4SMS.UseVisualStyleBackColor = True
        '
        'btnShowAllEmailsFromPortal
        '
        Me.btnShowAllEmailsFromPortal.AutoSize = True
        Me.btnShowAllEmailsFromPortal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnShowAllEmailsFromPortal.ForeColor = System.Drawing.Color.Blue
        Me.btnShowAllEmailsFromPortal.Location = New System.Drawing.Point(747, 9)
        Me.btnShowAllEmailsFromPortal.Name = "btnShowAllEmailsFromPortal"
        Me.btnShowAllEmailsFromPortal.Size = New System.Drawing.Size(116, 27)
        Me.btnShowAllEmailsFromPortal.TabIndex = 159
        Me.btnShowAllEmailsFromPortal.Text = "Show All Emails"
        Me.btnShowAllEmailsFromPortal.UseVisualStyleBackColor = True
        Me.btnShowAllEmailsFromPortal.Visible = False
        '
        'txtAllPortalEmails
        '
        Me.txtAllPortalEmails.Location = New System.Drawing.Point(29, 163)
        Me.txtAllPortalEmails.Multiline = True
        Me.txtAllPortalEmails.Name = "txtAllPortalEmails"
        Me.txtAllPortalEmails.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAllPortalEmails.Size = New System.Drawing.Size(990, 615)
        Me.txtAllPortalEmails.TabIndex = 160
        Me.txtAllPortalEmails.Visible = False
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
        Me.chkSMS.Visible = False
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
        Me.billMailed.HeaderText = "Mailed"
        Me.billMailed.Name = "billMailed"
        Me.billMailed.ReadOnly = True
        Me.billMailed.Width = 80
        '
        'billSMSed
        '
        Me.billSMSed.HeaderText = "SMS Sent"
        Me.billSMSed.Name = "billSMSed"
        Me.billSMSed.ReadOnly = True
        Me.billSMSed.Visible = False
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
        Me.softBill.Visible = False
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
        Me.ownerName.Width = 300
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
        Me.eMail.Visible = False
        Me.eMail.Width = 200
        '
        'AllEmails
        '
        Me.AllEmails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AllEmails.DefaultCellStyle = DataGridViewCellStyle13
        Me.AllEmails.HeaderText = "AllEmails"
        Me.AllEmails.MaxInputLength = 20
        Me.AllEmails.Name = "AllEmails"
        Me.AllEmails.ReadOnly = True
        Me.AllEmails.Width = 700
        '
        'evoting_mailid
        '
        Me.evoting_mailid.HeaderText = "eVotingID"
        Me.evoting_mailid.Name = "evoting_mailid"
        Me.evoting_mailid.Width = 300
        '
        'frmEVoteMailer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1545, 825)
        Me.Controls.Add(Me.txtAllPortalEmails)
        Me.Controls.Add(Me.btnShowAllEmailsFromPortal)
        Me.Controls.Add(Me.chkSelectAll4SMS)
        Me.Controls.Add(Me.btnSMSBill)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.grpExpenseType)
        Me.Controls.Add(Me.chkSelectAll4Mail)
        Me.Controls.Add(Me.btnMailBill)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.dgvFlat)
        Me.Name = "frmEVoteMailer"
        Me.Text = "EVoting Mailer"
        CType(Me.dgvFlat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpExpenseType.ResumeLayout(False)
        Me.grpExpenseType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvFlat As System.Windows.Forms.DataGridView
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
    Friend WithEvents btnShowAllEmailsFromPortal As System.Windows.Forms.Button
    Friend WithEvents txtAllPortalEmails As System.Windows.Forms.TextBox
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
    Friend WithEvents AllEmails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents evoting_mailid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
