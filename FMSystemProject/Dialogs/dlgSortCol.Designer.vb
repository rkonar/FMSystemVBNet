<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSortCol
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboDirection = New System.Windows.Forms.ComboBox()
        Me.cboOrderBy = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(277, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 17)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Direction"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDirection
        '
        Me.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDirection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboDirection.ForeColor = System.Drawing.Color.Blue
        Me.cboDirection.FormattingEnabled = True
        Me.cboDirection.Location = New System.Drawing.Point(280, 41)
        Me.cboDirection.Name = "cboDirection"
        Me.cboDirection.Size = New System.Drawing.Size(127, 24)
        Me.cboDirection.TabIndex = 27
        '
        'cboOrderBy
        '
        Me.cboOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrderBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboOrderBy.ForeColor = System.Drawing.Color.Blue
        Me.cboOrderBy.FormattingEnabled = True
        Me.cboOrderBy.Location = New System.Drawing.Point(25, 41)
        Me.cboOrderBy.Name = "cboOrderBy"
        Me.cboOrderBy.Size = New System.Drawing.Size(226, 24)
        Me.cboOrderBy.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(22, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Sort BY"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClose.ForeColor = System.Drawing.Color.Blue
        Me.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnClose.Location = New System.Drawing.Point(254, 82)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(61, 27)
        Me.btnClose.TabIndex = 98
        Me.btnClose.Text = "Cancel"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.AutoSize = True
        Me.btnDone.ForeColor = System.Drawing.Color.Blue
        Me.btnDone.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDone.Location = New System.Drawing.Point(174, 82)
        Me.btnDone.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(75, 28)
        Me.btnDone.TabIndex = 97
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'dlgSortCol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(426, 127)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboDirection)
        Me.Controls.Add(Me.cboOrderBy)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSortCol"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choose Sorting Order"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboDirection As System.Windows.Forms.ComboBox
    Friend WithEvents cboOrderBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDone As System.Windows.Forms.Button

End Class
