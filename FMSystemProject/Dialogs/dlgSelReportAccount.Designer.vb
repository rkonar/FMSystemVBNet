<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSelReportAccount
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
        Me.cboBankAccount = New System.Windows.Forms.ComboBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboBankAccount
        '
        Me.cboBankAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBankAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboBankAccount.ForeColor = System.Drawing.Color.Blue
        Me.cboBankAccount.FormattingEnabled = True
        Me.cboBankAccount.Location = New System.Drawing.Point(19, 33)
        Me.cboBankAccount.Margin = New System.Windows.Forms.Padding(2)
        Me.cboBankAccount.Name = "cboBankAccount"
        Me.cboBankAccount.Size = New System.Drawing.Size(290, 21)
        Me.cboBankAccount.TabIndex = 26
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClose.ForeColor = System.Drawing.Color.Blue
        Me.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnClose.Location = New System.Drawing.Point(190, 67)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(50, 23)
        Me.btnClose.TabIndex = 98
        Me.btnClose.Text = "Cancel"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.AutoSize = True
        Me.btnDone.ForeColor = System.Drawing.Color.Blue
        Me.btnDone.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDone.Location = New System.Drawing.Point(130, 67)
        Me.btnDone.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(56, 23)
        Me.btnDone.TabIndex = 97
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'dlgSelReportAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(320, 103)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.cboBankAccount)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSelReportAccount"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Report Account"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboBankAccount As System.Windows.Forms.ComboBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDone As System.Windows.Forms.Button

End Class
