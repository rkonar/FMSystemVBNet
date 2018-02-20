<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerformBilling
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
        Me.cboFromMonth = New System.Windows.Forms.ComboBox()
        Me.cboToMonth = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboFromYear = New System.Windows.Forms.ComboBox()
        Me.dtpBillDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPerformBilling = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBillRate = New System.Windows.Forms.TextBox()
        Me.txtTemplateExcelPath = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLineItemText = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBillOutputPath = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSimulate = New System.Windows.Forms.Button()
        Me.pbarBilling = New System.Windows.Forms.ProgressBar()
        Me.lblFlatCode = New System.Windows.Forms.Label()
        Me.chkIndividualReBilling = New System.Windows.Forms.CheckBox()
        Me.cboFlatCode = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkAddLine2 = New System.Windows.Forms.CheckBox()
        Me.txtLineItem2Desc = New System.Windows.Forms.TextBox()
        Me.txtLineAmt2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboFromMonth
        '
        Me.cboFromMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboFromMonth.FormattingEnabled = True
        Me.cboFromMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboFromMonth.Location = New System.Drawing.Point(108, 10)
        Me.cboFromMonth.Name = "cboFromMonth"
        Me.cboFromMonth.Size = New System.Drawing.Size(123, 24)
        Me.cboFromMonth.TabIndex = 12
        Me.cboFromMonth.TabStop = False
        '
        'cboToMonth
        '
        Me.cboToMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboToMonth.FormattingEnabled = True
        Me.cboToMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboToMonth.Location = New System.Drawing.Point(329, 11)
        Me.cboToMonth.Name = "cboToMonth"
        Me.cboToMonth.Size = New System.Drawing.Size(123, 24)
        Me.cboToMonth.TabIndex = 13
        Me.cboToMonth.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "From Month"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(246, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "To Month"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(467, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "From Year"
        '
        'cboFromYear
        '
        Me.cboFromYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboFromYear.FormattingEnabled = True
        Me.cboFromYear.Location = New System.Drawing.Point(550, 10)
        Me.cboFromYear.Name = "cboFromYear"
        Me.cboFromYear.Size = New System.Drawing.Size(123, 24)
        Me.cboFromYear.TabIndex = 16
        Me.cboFromYear.TabStop = False
        '
        'dtpBillDate
        '
        Me.dtpBillDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBillDate.Location = New System.Drawing.Point(107, 41)
        Me.dtpBillDate.Name = "dtpBillDate"
        Me.dtpBillDate.Size = New System.Drawing.Size(123, 22)
        Me.dtpBillDate.TabIndex = 53
        '
        'dtpDueDate
        '
        Me.dtpDueDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDueDate.Location = New System.Drawing.Point(329, 41)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(123, 22)
        Me.dtpDueDate.TabIndex = 54
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Bill Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(246, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 17)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Due Date"
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Location = New System.Drawing.Point(69, 303)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 27)
        Me.btnCancel.TabIndex = 58
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnPerformBilling
        '
        Me.btnPerformBilling.AutoSize = True
        Me.btnPerformBilling.Location = New System.Drawing.Point(167, 320)
        Me.btnPerformBilling.Name = "btnPerformBilling"
        Me.btnPerformBilling.Size = New System.Drawing.Size(107, 27)
        Me.btnPerformBilling.TabIndex = 57
        Me.btnPerformBilling.Text = "Generate Bills"
        Me.btnPerformBilling.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(467, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 17)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Bill Rate per Sq. Ft."
        '
        'txtBillRate
        '
        Me.txtBillRate.Location = New System.Drawing.Point(603, 41)
        Me.txtBillRate.Name = "txtBillRate"
        Me.txtBillRate.Size = New System.Drawing.Size(70, 22)
        Me.txtBillRate.TabIndex = 61
        '
        'txtTemplateExcelPath
        '
        Me.txtTemplateExcelPath.Location = New System.Drawing.Point(167, 142)
        Me.txtTemplateExcelPath.Name = "txtTemplateExcelPath"
        Me.txtTemplateExcelPath.Size = New System.Drawing.Size(847, 22)
        Me.txtTemplateExcelPath.TabIndex = 63
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 17)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Template Excel Path"
        '
        'txtLineItemText
        '
        Me.txtLineItemText.Location = New System.Drawing.Point(167, 77)
        Me.txtLineItemText.Name = "txtLineItemText"
        Me.txtLineItemText.Size = New System.Drawing.Size(847, 22)
        Me.txtLineItemText.TabIndex = 65
        Me.txtLineItemText.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 17)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Line Item Text"
        Me.Label8.Visible = False
        '
        'txtBillOutputPath
        '
        Me.txtBillOutputPath.Location = New System.Drawing.Point(167, 105)
        Me.txtBillOutputPath.Name = "txtBillOutputPath"
        Me.txtBillOutputPath.Size = New System.Drawing.Size(847, 22)
        Me.txtBillOutputPath.TabIndex = 67
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 17)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Bill Output Path"
        '
        'btnSimulate
        '
        Me.btnSimulate.AutoSize = True
        Me.btnSimulate.Location = New System.Drawing.Point(167, 289)
        Me.btnSimulate.Name = "btnSimulate"
        Me.btnSimulate.Size = New System.Drawing.Size(107, 27)
        Me.btnSimulate.TabIndex = 68
        Me.btnSimulate.Text = "Simulate"
        Me.btnSimulate.UseVisualStyleBackColor = True
        '
        'pbarBilling
        '
        Me.pbarBilling.BackColor = System.Drawing.Color.Yellow
        Me.pbarBilling.Location = New System.Drawing.Point(289, 307)
        Me.pbarBilling.Name = "pbarBilling"
        Me.pbarBilling.Size = New System.Drawing.Size(725, 35)
        Me.pbarBilling.TabIndex = 69
        '
        'lblFlatCode
        '
        Me.lblFlatCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblFlatCode.ForeColor = System.Drawing.Color.Red
        Me.lblFlatCode.Location = New System.Drawing.Point(579, 317)
        Me.lblFlatCode.Name = "lblFlatCode"
        Me.lblFlatCode.Size = New System.Drawing.Size(83, 17)
        Me.lblFlatCode.TabIndex = 70
        Me.lblFlatCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkIndividualReBilling
        '
        Me.chkIndividualReBilling.AutoSize = True
        Me.chkIndividualReBilling.Location = New System.Drawing.Point(698, 12)
        Me.chkIndividualReBilling.Name = "chkIndividualReBilling"
        Me.chkIndividualReBilling.Size = New System.Drawing.Size(185, 21)
        Me.chkIndividualReBilling.TabIndex = 148
        Me.chkIndividualReBilling.Text = "Individual Revised Billing"
        Me.chkIndividualReBilling.UseVisualStyleBackColor = True
        '
        'cboFlatCode
        '
        Me.cboFlatCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlatCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboFlatCode.FormattingEnabled = True
        Me.cboFlatCode.Location = New System.Drawing.Point(775, 37)
        Me.cboFlatCode.Name = "cboFlatCode"
        Me.cboFlatCode.Size = New System.Drawing.Size(121, 24)
        Me.cboFlatCode.TabIndex = 149
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(698, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 17)
        Me.Label10.TabIndex = 150
        Me.Label10.Text = "Apartment"
        '
        'chkAddLine2
        '
        Me.chkAddLine2.AutoSize = True
        Me.chkAddLine2.Location = New System.Drawing.Point(27, 186)
        Me.chkAddLine2.Name = "chkAddLine2"
        Me.chkAddLine2.Size = New System.Drawing.Size(182, 21)
        Me.chkAddLine2.TabIndex = 151
        Me.chkAddLine2.Text = "Add Additional Line Item"
        Me.chkAddLine2.UseVisualStyleBackColor = True
        '
        'txtLineItem2Desc
        '
        Me.txtLineItem2Desc.Enabled = False
        Me.txtLineItem2Desc.Location = New System.Drawing.Point(27, 213)
        Me.txtLineItem2Desc.Multiline = True
        Me.txtLineItem2Desc.Name = "txtLineItem2Desc"
        Me.txtLineItem2Desc.Size = New System.Drawing.Size(646, 59)
        Me.txtLineItem2Desc.TabIndex = 152
        '
        'txtLineAmt2
        '
        Me.txtLineAmt2.Enabled = False
        Me.txtLineAmt2.Location = New System.Drawing.Point(764, 235)
        Me.txtLineAmt2.Name = "txtLineAmt2"
        Me.txtLineAmt2.Size = New System.Drawing.Size(107, 22)
        Me.txtLineAmt2.TabIndex = 154
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(690, 235)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 17)
        Me.Label11.TabIndex = 153
        Me.Label11.Text = "Amount"
        '
        'frmPerformBilling
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1044, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtLineAmt2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtLineItem2Desc)
        Me.Controls.Add(Me.chkAddLine2)
        Me.Controls.Add(Me.cboFlatCode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.chkIndividualReBilling)
        Me.Controls.Add(Me.lblFlatCode)
        Me.Controls.Add(Me.pbarBilling)
        Me.Controls.Add(Me.btnSimulate)
        Me.Controls.Add(Me.txtBillOutputPath)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtLineItemText)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTemplateExcelPath)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtBillRate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnPerformBilling)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpDueDate)
        Me.Controls.Add(Me.dtpBillDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboFromYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboToMonth)
        Me.Controls.Add(Me.cboFromMonth)
        Me.Name = "frmPerformBilling"
        Me.ShowInTaskbar = False
        Me.Text = "Perform Billing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFromMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboToMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFromYear As System.Windows.Forms.ComboBox
    Friend WithEvents dtpBillDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPerformBilling As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBillRate As System.Windows.Forms.TextBox
    Friend WithEvents txtTemplateExcelPath As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLineItemText As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBillOutputPath As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSimulate As System.Windows.Forms.Button
    Friend WithEvents pbarBilling As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFlatCode As System.Windows.Forms.Label
    Friend WithEvents chkIndividualReBilling As System.Windows.Forms.CheckBox
    Friend WithEvents cboFlatCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkAddLine2 As System.Windows.Forms.CheckBox
    Friend WithEvents txtLineItem2Desc As System.Windows.Forms.TextBox
    Friend WithEvents txtLineAmt2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
