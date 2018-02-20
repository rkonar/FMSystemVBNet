<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChequeDetails
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
        Me.lblInstrumentNo = New System.Windows.Forms.Label()
        Me.cboChequeNo = New System.Windows.Forms.ComboBox()
        Me.btnShowChequeDetails = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblInstrumentNo
        '
        Me.lblInstrumentNo.AutoSize = True
        Me.lblInstrumentNo.Location = New System.Drawing.Point(13, 15)
        Me.lblInstrumentNo.Name = "lblInstrumentNo"
        Me.lblInstrumentNo.Size = New System.Drawing.Size(79, 17)
        Me.lblInstrumentNo.TabIndex = 61
        Me.lblInstrumentNo.Text = "Cheque No"
        '
        'cboChequeNo
        '
        Me.cboChequeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboChequeNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboChequeNo.FormattingEnabled = True
        Me.cboChequeNo.Location = New System.Drawing.Point(124, 12)
        Me.cboChequeNo.Name = "cboChequeNo"
        Me.cboChequeNo.Size = New System.Drawing.Size(195, 24)
        Me.cboChequeNo.TabIndex = 60
        '
        'btnShowChequeDetails
        '
        Me.btnShowChequeDetails.AutoSize = True
        Me.btnShowChequeDetails.Location = New System.Drawing.Point(349, 15)
        Me.btnShowChequeDetails.Name = "btnShowChequeDetails"
        Me.btnShowChequeDetails.Size = New System.Drawing.Size(99, 27)
        Me.btnShowChequeDetails.TabIndex = 62
        Me.btnShowChequeDetails.Text = "Show Details"
        Me.btnShowChequeDetails.UseVisualStyleBackColor = True
        '
        'frmChequeDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 52)
        Me.Controls.Add(Me.btnShowChequeDetails)
        Me.Controls.Add(Me.lblInstrumentNo)
        Me.Controls.Add(Me.cboChequeNo)
        Me.Name = "frmChequeDetails"
        Me.Text = "Cheque Details"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblInstrumentNo As System.Windows.Forms.Label
    Friend WithEvents cboChequeNo As System.Windows.Forms.ComboBox
    Friend WithEvents btnShowChequeDetails As System.Windows.Forms.Button
End Class
