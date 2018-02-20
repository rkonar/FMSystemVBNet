<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEditServiceCase
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCaseDesc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtLogDate = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtCompleteDate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCaseType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEditFlatOwnerDetails = New System.Windows.Forms.Button()
        Me.lblOwner = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLogTimePosition = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPresentPosition = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCoOwner = New System.Windows.Forms.Label()
        Me.txtFlatCode = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cboRequestedVia = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboCaseStatus = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRequestedBy = New System.Windows.Forms.TextBox()
        Me.txtClosureComment = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboAssignedTo = New System.Windows.Forms.ComboBox()
        Me.txtCaseNo = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvCase = New System.Windows.Forms.DataGridView()
        Me.btnSMS = New System.Windows.Forms.Button()
        Me.cboSampleCaseDesc = New System.Windows.Forms.ComboBox()
        Me.btnCopyToCaseDesc = New System.Windows.Forms.Button()
        Me.chkNoSMS = New System.Windows.Forms.CheckBox()
        Me.tblid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlatCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaseType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaseNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaseDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CloseDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssignedTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClosureComment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestedVia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogTimePosition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvCase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Case Number"
        '
        'txtCaseDesc
        '
        Me.txtCaseDesc.Location = New System.Drawing.Point(742, 4)
        Me.txtCaseDesc.MaxLength = 255
        Me.txtCaseDesc.Multiline = True
        Me.txtCaseDesc.Name = "txtCaseDesc"
        Me.txtCaseDesc.Size = New System.Drawing.Size(470, 70)
        Me.txtCaseDesc.TabIndex = 10
        Me.txtCaseDesc.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(621, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 17)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Case Description"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 17)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Flat"
        '
        'txtLogDate
        '
        Me.txtLogDate.Location = New System.Drawing.Point(124, 98)
        Me.txtLogDate.Name = "txtLogDate"
        Me.txtLogDate.Size = New System.Drawing.Size(142, 22)
        Me.txtLogDate.TabIndex = 44
        Me.txtLogDate.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.Location = New System.Drawing.Point(1097, 307)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 27)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Location = New System.Drawing.Point(1097, 359)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 27)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClose.Location = New System.Drawing.Point(1097, 411)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 27)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtCompleteDate
        '
        Me.txtCompleteDate.Location = New System.Drawing.Point(124, 126)
        Me.txtCompleteDate.Name = "txtCompleteDate"
        Me.txtCompleteDate.Size = New System.Drawing.Size(142, 22)
        Me.txtCompleteDate.TabIndex = 174
        Me.txtCompleteDate.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "Logged At"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 17)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "Completed At"
        '
        'cboCaseType
        '
        Me.cboCaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaseType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboCaseType.FormattingEnabled = True
        Me.cboCaseType.Location = New System.Drawing.Point(124, 36)
        Me.cboCaseType.Name = "cboCaseType"
        Me.cboCaseType.Size = New System.Drawing.Size(142, 24)
        Me.cboCaseType.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 178
        Me.Label3.Text = "Case Type"
        '
        'btnEditFlatOwnerDetails
        '
        Me.btnEditFlatOwnerDetails.AutoSize = True
        Me.btnEditFlatOwnerDetails.Location = New System.Drawing.Point(589, 5)
        Me.btnEditFlatOwnerDetails.Name = "btnEditFlatOwnerDetails"
        Me.btnEditFlatOwnerDetails.Size = New System.Drawing.Size(30, 27)
        Me.btnEditFlatOwnerDetails.TabIndex = 180
        Me.btnEditFlatOwnerDetails.Text = "..."
        Me.btnEditFlatOwnerDetails.UseVisualStyleBackColor = True
        '
        'lblOwner
        '
        Me.lblOwner.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblOwner.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOwner.Location = New System.Drawing.Point(231, 6)
        Me.lblOwner.Name = "lblOwner"
        Me.lblOwner.Size = New System.Drawing.Size(175, 25)
        Me.lblOwner.TabIndex = 181
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(180, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 17)
        Me.Label4.TabIndex = 190
        Me.Label4.Text = "Initial Position"
        '
        'txtLogTimePosition
        '
        Me.txtLogTimePosition.Location = New System.Drawing.Point(281, 64)
        Me.txtLogTimePosition.MaxLength = 1
        Me.txtLogTimePosition.Name = "txtLogTimePosition"
        Me.txtLogTimePosition.Size = New System.Drawing.Size(40, 22)
        Me.txtLogTimePosition.TabIndex = 4
        Me.txtLogTimePosition.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(163, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 17)
        Me.Label6.TabIndex = 192
        Me.Label6.Text = "Present Position"
        '
        'txtPresentPosition
        '
        Me.txtPresentPosition.Location = New System.Drawing.Point(281, 93)
        Me.txtPresentPosition.MaxLength = 1
        Me.txtPresentPosition.Name = "txtPresentPosition"
        Me.txtPresentPosition.Size = New System.Drawing.Size(40, 22)
        Me.txtPresentPosition.TabIndex = 5
        Me.txtPresentPosition.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(129, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 17)
        Me.Label8.TabIndex = 193
        Me.Label8.Text = "Owner Details"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblCoOwner)
        Me.Panel1.Controls.Add(Me.txtFlatCode)
        Me.Panel1.Controls.Add(Me.lblOwner)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.btnEditFlatOwnerDetails)
        Me.Panel1.Location = New System.Drawing.Point(6, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(630, 37)
        Me.Panel1.TabIndex = 194
        '
        'lblCoOwner
        '
        Me.lblCoOwner.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblCoOwner.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoOwner.Location = New System.Drawing.Point(411, 6)
        Me.lblCoOwner.Name = "lblCoOwner"
        Me.lblCoOwner.Size = New System.Drawing.Size(175, 25)
        Me.lblCoOwner.TabIndex = 206
        '
        'txtFlatCode
        '
        Me.txtFlatCode.Location = New System.Drawing.Point(53, 7)
        Me.txtFlatCode.MaxLength = 100
        Me.txtFlatCode.Name = "txtFlatCode"
        Me.txtFlatCode.ReadOnly = True
        Me.txtFlatCode.Size = New System.Drawing.Size(69, 22)
        Me.txtFlatCode.TabIndex = 205
        Me.txtFlatCode.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.txtClosureComment)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.cboAssignedTo)
        Me.Panel2.Controls.Add(Me.txtCaseDesc)
        Me.Panel2.Controls.Add(Me.txtCaseNo)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtLogDate)
        Me.Panel2.Controls.Add(Me.txtCompleteDate)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cboCaseType)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(5, 45)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1226, 158)
        Me.Panel2.TabIndex = 195
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel3.Controls.Add(Me.cboRequestedVia)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.cboCaseStatus)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.txtRequestedBy)
        Me.Panel3.Controls.Add(Me.txtLogTimePosition)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtPresentPosition)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(272, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(339, 144)
        Me.Panel3.TabIndex = 195
        '
        'cboRequestedVia
        '
        Me.cboRequestedVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRequestedVia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboRequestedVia.FormattingEnabled = True
        Me.cboRequestedVia.Location = New System.Drawing.Point(108, 34)
        Me.cboRequestedVia.Name = "cboRequestedVia"
        Me.cboRequestedVia.Size = New System.Drawing.Size(213, 24)
        Me.cboRequestedVia.TabIndex = 194
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(1, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 17)
        Me.Label11.TabIndex = 195
        Me.Label11.Text = "Requested Via"
        '
        'cboCaseStatus
        '
        Me.cboCaseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaseStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboCaseStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCaseStatus.ForeColor = System.Drawing.Color.Red
        Me.cboCaseStatus.FormattingEnabled = True
        Me.cboCaseStatus.Location = New System.Drawing.Point(9, 110)
        Me.cboCaseStatus.Name = "cboCaseStatus"
        Me.cboCaseStatus.Size = New System.Drawing.Size(142, 24)
        Me.cboCaseStatus.TabIndex = 204
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(54, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 17)
        Me.Label16.TabIndex = 203
        Me.Label16.Text = "Status"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 17)
        Me.Label13.TabIndex = 199
        Me.Label13.Text = "Requested By"
        '
        'txtRequestedBy
        '
        Me.txtRequestedBy.Location = New System.Drawing.Point(108, 9)
        Me.txtRequestedBy.MaxLength = 100
        Me.txtRequestedBy.Name = "txtRequestedBy"
        Me.txtRequestedBy.Size = New System.Drawing.Size(213, 22)
        Me.txtRequestedBy.TabIndex = 198
        Me.txtRequestedBy.TabStop = False
        '
        'txtClosureComment
        '
        Me.txtClosureComment.Location = New System.Drawing.Point(742, 78)
        Me.txtClosureComment.MaxLength = 255
        Me.txtClosureComment.Multiline = True
        Me.txtClosureComment.Name = "txtClosureComment"
        Me.txtClosureComment.Size = New System.Drawing.Size(470, 70)
        Me.txtClosureComment.TabIndex = 200
        Me.txtClosureComment.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(669, 103)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 17)
        Me.Label14.TabIndex = 201
        Me.Label14.Text = "Comment"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 17)
        Me.Label12.TabIndex = 197
        Me.Label12.Text = "Assigned To"
        '
        'cboAssignedTo
        '
        Me.cboAssignedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssignedTo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboAssignedTo.FormattingEnabled = True
        Me.cboAssignedTo.Location = New System.Drawing.Point(124, 66)
        Me.cboAssignedTo.Name = "cboAssignedTo"
        Me.cboAssignedTo.Size = New System.Drawing.Size(142, 24)
        Me.cboAssignedTo.TabIndex = 196
        '
        'txtCaseNo
        '
        Me.txtCaseNo.Location = New System.Drawing.Point(124, 3)
        Me.txtCaseNo.MaxLength = 100
        Me.txtCaseNo.Name = "txtCaseNo"
        Me.txtCaseNo.ReadOnly = True
        Me.txtCaseNo.Size = New System.Drawing.Size(142, 22)
        Me.txtCaseNo.TabIndex = 1
        Me.txtCaseNo.TabStop = False
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = True
        Me.btnAdd.Location = New System.Drawing.Point(1097, 255)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 27)
        Me.btnAdd.TabIndex = 196
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvCase
        '
        Me.dgvCase.AllowUserToAddRows = False
        Me.dgvCase.AllowUserToDeleteRows = False
        Me.dgvCase.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCase.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tblid, Me.FlatCode, Me.CaseType, Me.CaseNo, Me.CaseDesc, Me.LogDateTime, Me.CloseDateTime, Me.AssignedTo, Me.ClosureComment, Me.Status, Me.RequestedBy, Me.RequestedVia, Me.LogTimePosition})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCase.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvCase.Location = New System.Drawing.Point(5, 209)
        Me.dgvCase.Name = "dgvCase"
        Me.dgvCase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCase.RowHeadersVisible = False
        Me.dgvCase.RowTemplate.Height = 24
        Me.dgvCase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCase.Size = New System.Drawing.Size(1075, 569)
        Me.dgvCase.TabIndex = 197
        '
        'btnSMS
        '
        Me.btnSMS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSMS.Location = New System.Drawing.Point(1097, 566)
        Me.btnSMS.Name = "btnSMS"
        Me.btnSMS.Size = New System.Drawing.Size(75, 61)
        Me.btnSMS.TabIndex = 198
        Me.btnSMS.Text = "Send Duplicate SMS"
        Me.btnSMS.UseVisualStyleBackColor = True
        '
        'cboSampleCaseDesc
        '
        Me.cboSampleCaseDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSampleCaseDesc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboSampleCaseDesc.FormattingEnabled = True
        Me.cboSampleCaseDesc.Location = New System.Drawing.Point(642, 9)
        Me.cboSampleCaseDesc.Name = "cboSampleCaseDesc"
        Me.cboSampleCaseDesc.Size = New System.Drawing.Size(489, 24)
        Me.cboSampleCaseDesc.TabIndex = 199
        '
        'btnCopyToCaseDesc
        '
        Me.btnCopyToCaseDesc.AutoSize = True
        Me.btnCopyToCaseDesc.Location = New System.Drawing.Point(1140, 8)
        Me.btnCopyToCaseDesc.Name = "btnCopyToCaseDesc"
        Me.btnCopyToCaseDesc.Size = New System.Drawing.Size(91, 27)
        Me.btnCopyToCaseDesc.TabIndex = 207
        Me.btnCopyToCaseDesc.Text = "Copy Below"
        Me.btnCopyToCaseDesc.UseVisualStyleBackColor = True
        '
        'chkNoSMS
        '
        Me.chkNoSMS.AutoSize = True
        Me.chkNoSMS.ForeColor = System.Drawing.Color.Red
        Me.chkNoSMS.Location = New System.Drawing.Point(1097, 212)
        Me.chkNoSMS.Name = "chkNoSMS"
        Me.chkNoSMS.Size = New System.Drawing.Size(82, 21)
        Me.chkNoSMS.TabIndex = 208
        Me.chkNoSMS.Text = "SMS Off"
        Me.chkNoSMS.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FlatCode.DefaultCellStyle = DataGridViewCellStyle1
        Me.FlatCode.HeaderText = "Flat Code"
        Me.FlatCode.Name = "FlatCode"
        Me.FlatCode.ReadOnly = True
        Me.FlatCode.Width = 60
        '
        'CaseType
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CaseType.DefaultCellStyle = DataGridViewCellStyle2
        Me.CaseType.HeaderText = "Case Type"
        Me.CaseType.Name = "CaseType"
        Me.CaseType.ReadOnly = True
        '
        'CaseNo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CaseNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.CaseNo.HeaderText = "Case#"
        Me.CaseNo.Name = "CaseNo"
        Me.CaseNo.ReadOnly = True
        Me.CaseNo.Width = 75
        '
        'CaseDesc
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CaseDesc.DefaultCellStyle = DataGridViewCellStyle4
        Me.CaseDesc.HeaderText = "Case Desc"
        Me.CaseDesc.Name = "CaseDesc"
        Me.CaseDesc.ReadOnly = True
        Me.CaseDesc.Visible = False
        Me.CaseDesc.Width = 150
        '
        'LogDateTime
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LogDateTime.DefaultCellStyle = DataGridViewCellStyle5
        Me.LogDateTime.HeaderText = "Log DateTime"
        Me.LogDateTime.Name = "LogDateTime"
        Me.LogDateTime.ReadOnly = True
        Me.LogDateTime.Width = 110
        '
        'CloseDateTime
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CloseDateTime.DefaultCellStyle = DataGridViewCellStyle6
        Me.CloseDateTime.HeaderText = "Close DateTime"
        Me.CloseDateTime.Name = "CloseDateTime"
        Me.CloseDateTime.ReadOnly = True
        Me.CloseDateTime.Width = 115
        '
        'AssignedTo
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AssignedTo.DefaultCellStyle = DataGridViewCellStyle7
        Me.AssignedTo.HeaderText = "AssignedTo"
        Me.AssignedTo.Name = "AssignedTo"
        Me.AssignedTo.ReadOnly = True
        Me.AssignedTo.Width = 150
        '
        'ClosureComment
        '
        Me.ClosureComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Format = "D"
        DataGridViewCellStyle8.NullValue = Nothing
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ClosureComment.DefaultCellStyle = DataGridViewCellStyle8
        Me.ClosureComment.HeaderText = "Closure Comment"
        Me.ClosureComment.MaxInputLength = 100
        Me.ClosureComment.Name = "ClosureComment"
        Me.ClosureComment.ReadOnly = True
        Me.ClosureComment.Width = 150
        '
        'Status
        '
        Me.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Status.DefaultCellStyle = DataGridViewCellStyle9
        Me.Status.HeaderText = "Status"
        Me.Status.MaxInputLength = 255
        Me.Status.MinimumWidth = 10
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 75
        '
        'RequestedBy
        '
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RequestedBy.DefaultCellStyle = DataGridViewCellStyle10
        Me.RequestedBy.HeaderText = "RequestedBy"
        Me.RequestedBy.Name = "RequestedBy"
        Me.RequestedBy.ReadOnly = True
        Me.RequestedBy.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'RequestedVia
        '
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RequestedVia.DefaultCellStyle = DataGridViewCellStyle11
        Me.RequestedVia.HeaderText = "RequestedVia"
        Me.RequestedVia.Name = "RequestedVia"
        Me.RequestedVia.ReadOnly = True
        Me.RequestedVia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RequestedVia.Width = 125
        '
        'LogTimePosition
        '
        Me.LogTimePosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LogTimePosition.DefaultCellStyle = DataGridViewCellStyle12
        Me.LogTimePosition.HeaderText = "LogTimePosition"
        Me.LogTimePosition.Name = "LogTimePosition"
        Me.LogTimePosition.ReadOnly = True
        Me.LogTimePosition.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LogTimePosition.Visible = False
        Me.LogTimePosition.Width = 95
        '
        'frmAddEditServiceCase
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1240, 786)
        Me.Controls.Add(Me.chkNoSMS)
        Me.Controls.Add(Me.btnCopyToCaseDesc)
        Me.Controls.Add(Me.cboSampleCaseDesc)
        Me.Controls.Add(Me.btnSMS)
        Me.Controls.Add(Me.dgvCase)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddEditServiceCase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvCase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCaseDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLogDate As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtCompleteDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCaseType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnEditFlatOwnerDetails As System.Windows.Forms.Button
    Friend WithEvents lblOwner As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLogTimePosition As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPresentPosition As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cboRequestedVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboAssignedTo As System.Windows.Forms.ComboBox
    Friend WithEvents txtClosureComment As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtRequestedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboCaseStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtFlatCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCaseNo As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblCoOwner As System.Windows.Forms.Label
    Friend WithEvents dgvCase As System.Windows.Forms.DataGridView
    Friend WithEvents btnSMS As System.Windows.Forms.Button
    Friend WithEvents cboSampleCaseDesc As System.Windows.Forms.ComboBox
    Friend WithEvents btnCopyToCaseDesc As System.Windows.Forms.Button
    Friend WithEvents tblid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FlatCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaseType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaseNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaseDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CloseDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssignedTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClosureComment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequestedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequestedVia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogTimePosition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkNoSMS As System.Windows.Forms.CheckBox
End Class
