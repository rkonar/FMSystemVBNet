<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowTxnForFlat
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cboFlatCode = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvJournalBilled = New System.Windows.Forms.DataGridView()
        Me.JournalID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Narration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvJournalPaid = New System.Windows.Forms.DataGridView()
        Me.JournalIDPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnTypePaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnDatePaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NarrationPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxnAmtPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblOwnerDetails = New System.Windows.Forms.Label()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.btnEditFlatOwnerDetails = New System.Windows.Forms.Button()
        Me.lblDiff = New System.Windows.Forms.Label()
        Me.txtDuplexFlatCode = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.dgvJournalBilled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvJournalPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboFlatCode
        '
        Me.cboFlatCode.Enabled = False
        Me.cboFlatCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboFlatCode.FormattingEnabled = True
        Me.cboFlatCode.Location = New System.Drawing.Point(84, 7)
        Me.cboFlatCode.Name = "cboFlatCode"
        Me.cboFlatCode.Size = New System.Drawing.Size(121, 24)
        Me.cboFlatCode.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Apartment"
        '
        'dgvJournalBilled
        '
        Me.dgvJournalBilled.AllowUserToAddRows = False
        Me.dgvJournalBilled.AllowUserToDeleteRows = False
        Me.dgvJournalBilled.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvJournalBilled.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalBilled.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvJournalBilled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvJournalBilled.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JournalID, Me.TxnType, Me.TxnDate, Me.Narration, Me.TxnAmt})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournalBilled.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvJournalBilled.Location = New System.Drawing.Point(2, 87)
        Me.dgvJournalBilled.Name = "dgvJournalBilled"
        Me.dgvJournalBilled.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalBilled.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvJournalBilled.RowHeadersVisible = False
        Me.dgvJournalBilled.RowTemplate.Height = 24
        Me.dgvJournalBilled.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvJournalBilled.Size = New System.Drawing.Size(610, 714)
        Me.dgvJournalBilled.TabIndex = 30
        '
        'JournalID
        '
        Me.JournalID.HeaderText = "JournalID"
        Me.JournalID.Name = "JournalID"
        Me.JournalID.Visible = False
        '
        'TxnType
        '
        Me.TxnType.HeaderText = "TxnType"
        Me.TxnType.MaxInputLength = 1
        Me.TxnType.Name = "TxnType"
        Me.TxnType.Visible = False
        '
        'TxnDate
        '
        Me.TxnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "D"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.TxnDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.TxnDate.HeaderText = "Date"
        Me.TxnDate.MaxInputLength = 11
        Me.TxnDate.Name = "TxnDate"
        Me.TxnDate.ReadOnly = True
        '
        'Narration
        '
        Me.Narration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Narration.DefaultCellStyle = DataGridViewCellStyle3
        Me.Narration.HeaderText = "Narration"
        Me.Narration.MaxInputLength = 255
        Me.Narration.MinimumWidth = 10
        Me.Narration.Name = "Narration"
        Me.Narration.ReadOnly = True
        Me.Narration.Width = 400
        '
        'TxnAmt
        '
        Me.TxnAmt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TxnAmt.DefaultCellStyle = DataGridViewCellStyle4
        Me.TxnAmt.HeaderText = "Amount"
        Me.TxnAmt.MaxInputLength = 13
        Me.TxnAmt.Name = "TxnAmt"
        '
        'dgvJournalPaid
        '
        Me.dgvJournalPaid.AllowUserToAddRows = False
        Me.dgvJournalPaid.AllowUserToDeleteRows = False
        Me.dgvJournalPaid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvJournalPaid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalPaid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvJournalPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvJournalPaid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JournalIDPaid, Me.TxnTypePaid, Me.TxnDatePaid, Me.NarrationPaid, Me.TxnAmtPaid})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournalPaid.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvJournalPaid.Location = New System.Drawing.Point(619, 87)
        Me.dgvJournalPaid.Name = "dgvJournalPaid"
        Me.dgvJournalPaid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalPaid.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvJournalPaid.RowHeadersVisible = False
        Me.dgvJournalPaid.RowTemplate.Height = 24
        Me.dgvJournalPaid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvJournalPaid.Size = New System.Drawing.Size(610, 714)
        Me.dgvJournalPaid.TabIndex = 31
        '
        'JournalIDPaid
        '
        Me.JournalIDPaid.HeaderText = "JournalID"
        Me.JournalIDPaid.Name = "JournalIDPaid"
        Me.JournalIDPaid.Visible = False
        '
        'TxnTypePaid
        '
        Me.TxnTypePaid.HeaderText = "TxnType"
        Me.TxnTypePaid.MaxInputLength = 1
        Me.TxnTypePaid.Name = "TxnTypePaid"
        Me.TxnTypePaid.Visible = False
        '
        'TxnDatePaid
        '
        Me.TxnDatePaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Format = "D"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.TxnDatePaid.DefaultCellStyle = DataGridViewCellStyle8
        Me.TxnDatePaid.HeaderText = "Date"
        Me.TxnDatePaid.MaxInputLength = 11
        Me.TxnDatePaid.Name = "TxnDatePaid"
        Me.TxnDatePaid.ReadOnly = True
        '
        'NarrationPaid
        '
        Me.NarrationPaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NarrationPaid.DefaultCellStyle = DataGridViewCellStyle9
        Me.NarrationPaid.HeaderText = "Narration"
        Me.NarrationPaid.MaxInputLength = 255
        Me.NarrationPaid.MinimumWidth = 10
        Me.NarrationPaid.Name = "NarrationPaid"
        Me.NarrationPaid.ReadOnly = True
        Me.NarrationPaid.Width = 400
        '
        'TxnAmtPaid
        '
        Me.TxnAmtPaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TxnAmtPaid.DefaultCellStyle = DataGridViewCellStyle10
        Me.TxnAmtPaid.HeaderText = "Amount"
        Me.TxnAmtPaid.MaxInputLength = 13
        Me.TxnAmtPaid.Name = "TxnAmtPaid"
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.Location = New System.Drawing.Point(770, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 27)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(234, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 19)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "Bills Raised"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(780, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(162, 19)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Payments Received"
        '
        'lblOwnerDetails
        '
        Me.lblOwnerDetails.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblOwnerDetails.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOwnerDetails.Location = New System.Drawing.Point(453, 8)
        Me.lblOwnerDetails.Name = "lblOwnerDetails"
        Me.lblOwnerDetails.Size = New System.Drawing.Size(225, 42)
        Me.lblOwnerDetails.TabIndex = 70
        '
        'lblBalance
        '
        Me.lblBalance.BackColor = System.Drawing.Color.Black
        Me.lblBalance.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalance.ForeColor = System.Drawing.Color.White
        Me.lblBalance.Location = New System.Drawing.Point(258, 8)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(186, 22)
        Me.lblBalance.TabIndex = 71
        '
        'btnEditFlatOwnerDetails
        '
        Me.btnEditFlatOwnerDetails.AutoSize = True
        Me.btnEditFlatOwnerDetails.Location = New System.Drawing.Point(679, 7)
        Me.btnEditFlatOwnerDetails.Name = "btnEditFlatOwnerDetails"
        Me.btnEditFlatOwnerDetails.Size = New System.Drawing.Size(30, 27)
        Me.btnEditFlatOwnerDetails.TabIndex = 13
        Me.btnEditFlatOwnerDetails.Text = "..."
        Me.btnEditFlatOwnerDetails.UseVisualStyleBackColor = True
        '
        'lblDiff
        '
        Me.lblDiff.BackColor = System.Drawing.Color.Black
        Me.lblDiff.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiff.ForeColor = System.Drawing.Color.White
        Me.lblDiff.Location = New System.Drawing.Point(258, 32)
        Me.lblDiff.Name = "lblDiff"
        Me.lblDiff.Size = New System.Drawing.Size(186, 22)
        Me.lblDiff.TabIndex = 124
        Me.lblDiff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDuplexFlatCode
        '
        Me.txtDuplexFlatCode.Enabled = False
        Me.txtDuplexFlatCode.Location = New System.Drawing.Point(84, 37)
        Me.txtDuplexFlatCode.MaxLength = 20
        Me.txtDuplexFlatCode.Name = "txtDuplexFlatCode"
        Me.txtDuplexFlatCode.Size = New System.Drawing.Size(73, 22)
        Me.txtDuplexFlatCode.TabIndex = 129
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1156, 804)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 13)
        Me.Label12.TabIndex = 134
        Me.Label12.Text = "Non Banking Txn"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(889, 804)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(208, 13)
        Me.Label11.TabIndex = 133
        Me.Label11.Text = "Not Reconciled with bank statement"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Green
        Me.Label10.Location = New System.Drawing.Point(648, 804)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(185, 13)
        Me.Label10.TabIndex = 132
        Me.Label10.Text = "Reconciled with bank statement"
        '
        'frmShowTxnForFlat
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1242, 837)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDuplexFlatCode)
        Me.Controls.Add(Me.lblDiff)
        Me.Controls.Add(Me.btnEditFlatOwnerDetails)
        Me.Controls.Add(Me.lblBalance)
        Me.Controls.Add(Me.lblOwnerDetails)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvJournalPaid)
        Me.Controls.Add(Me.dgvJournalBilled)
        Me.Controls.Add(Me.cboFlatCode)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmShowTxnForFlat"
        Me.Text = "Transactions for Flat"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvJournalBilled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvJournalPaid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFlatCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvJournalBilled As System.Windows.Forms.DataGridView
    Friend WithEvents dgvJournalPaid As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblOwnerDetails As System.Windows.Forms.Label
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents btnEditFlatOwnerDetails As System.Windows.Forms.Button
    Friend WithEvents lblDiff As System.Windows.Forms.Label
    Friend WithEvents txtDuplexFlatCode As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents JournalID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Narration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JournalIDPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnTypePaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnDatePaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NarrationPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxnAmtPaid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
