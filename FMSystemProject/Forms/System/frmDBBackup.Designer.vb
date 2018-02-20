<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBBackup
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
        Me.lstTableFrom = New System.Windows.Forms.ListBox()
        Me.lstTableTo = New System.Windows.Forms.ListBox()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.btnSingleMove = New System.Windows.Forms.Button()
        Me.btnAllMove = New System.Windows.Forms.Button()
        Me.btnAllReverseMove = New System.Windows.Forms.Button()
        Me.btnSingleReverseMove = New System.Windows.Forms.Button()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.txtBackupPath = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSelectBackupPath = New System.Windows.Forms.Button()
        Me.ofdSelectFile = New System.Windows.Forms.OpenFileDialog()
        Me.txtRestoreFile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSelectRestorePath = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optBackupSelective = New System.Windows.Forms.RadioButton()
        Me.optRestore = New System.Windows.Forms.RadioButton()
        Me.optBackupFull = New System.Windows.Forms.RadioButton()
        Me.fbdSelectFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstTableFrom
        '
        Me.lstTableFrom.FormattingEnabled = True
        Me.lstTableFrom.ItemHeight = 16
        Me.lstTableFrom.Location = New System.Drawing.Point(37, 136)
        Me.lstTableFrom.Name = "lstTableFrom"
        Me.lstTableFrom.Size = New System.Drawing.Size(233, 388)
        Me.lstTableFrom.TabIndex = 0
        Me.lstTableFrom.Visible = False
        '
        'lstTableTo
        '
        Me.lstTableTo.FormattingEnabled = True
        Me.lstTableTo.ItemHeight = 16
        Me.lstTableTo.Location = New System.Drawing.Point(360, 136)
        Me.lstTableTo.Name = "lstTableTo"
        Me.lstTableTo.Size = New System.Drawing.Size(233, 388)
        Me.lstTableTo.TabIndex = 1
        Me.lstTableTo.Visible = False
        '
        'btnBackup
        '
        Me.btnBackup.AutoSize = True
        Me.btnBackup.Location = New System.Drawing.Point(397, 24)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(75, 27)
        Me.btnBackup.TabIndex = 2
        Me.btnBackup.Text = "Backup"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'btnSingleMove
        '
        Me.btnSingleMove.AutoSize = True
        Me.btnSingleMove.Location = New System.Drawing.Point(276, 214)
        Me.btnSingleMove.Name = "btnSingleMove"
        Me.btnSingleMove.Size = New System.Drawing.Size(75, 27)
        Me.btnSingleMove.TabIndex = 3
        Me.btnSingleMove.Text = ">"
        Me.btnSingleMove.UseVisualStyleBackColor = True
        Me.btnSingleMove.Visible = False
        '
        'btnAllMove
        '
        Me.btnAllMove.AutoSize = True
        Me.btnAllMove.Location = New System.Drawing.Point(276, 243)
        Me.btnAllMove.Name = "btnAllMove"
        Me.btnAllMove.Size = New System.Drawing.Size(75, 27)
        Me.btnAllMove.TabIndex = 4
        Me.btnAllMove.Text = ">>"
        Me.btnAllMove.UseVisualStyleBackColor = True
        Me.btnAllMove.Visible = False
        '
        'btnAllReverseMove
        '
        Me.btnAllReverseMove.AutoSize = True
        Me.btnAllReverseMove.Location = New System.Drawing.Point(276, 318)
        Me.btnAllReverseMove.Name = "btnAllReverseMove"
        Me.btnAllReverseMove.Size = New System.Drawing.Size(75, 27)
        Me.btnAllReverseMove.TabIndex = 6
        Me.btnAllReverseMove.Text = "<<"
        Me.btnAllReverseMove.UseVisualStyleBackColor = True
        Me.btnAllReverseMove.Visible = False
        '
        'btnSingleReverseMove
        '
        Me.btnSingleReverseMove.AutoSize = True
        Me.btnSingleReverseMove.Location = New System.Drawing.Point(276, 289)
        Me.btnSingleReverseMove.Name = "btnSingleReverseMove"
        Me.btnSingleReverseMove.Size = New System.Drawing.Size(75, 27)
        Me.btnSingleReverseMove.TabIndex = 5
        Me.btnSingleReverseMove.Text = "<"
        Me.btnSingleReverseMove.UseVisualStyleBackColor = True
        Me.btnSingleReverseMove.Visible = False
        '
        'btnRestore
        '
        Me.btnRestore.AutoSize = True
        Me.btnRestore.Location = New System.Drawing.Point(514, 24)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(75, 27)
        Me.btnRestore.TabIndex = 7
        Me.btnRestore.Text = "Restore"
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'txtBackupPath
        '
        Me.txtBackupPath.Location = New System.Drawing.Point(107, 71)
        Me.txtBackupPath.Name = "txtBackupPath"
        Me.txtBackupPath.ReadOnly = True
        Me.txtBackupPath.Size = New System.Drawing.Size(486, 22)
        Me.txtBackupPath.TabIndex = 125
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(3, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 19)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "Backup To"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSelectBackupPath
        '
        Me.btnSelectBackupPath.AutoSize = True
        Me.btnSelectBackupPath.Location = New System.Drawing.Point(599, 70)
        Me.btnSelectBackupPath.Name = "btnSelectBackupPath"
        Me.btnSelectBackupPath.Size = New System.Drawing.Size(64, 27)
        Me.btnSelectBackupPath.TabIndex = 123
        Me.btnSelectBackupPath.Text = "Browse"
        Me.btnSelectBackupPath.UseVisualStyleBackColor = True
        '
        'ofdSelectFile
        '
        Me.ofdSelectFile.DefaultExt = "*.jpeg"
        Me.ofdSelectFile.FileName = "OpenFileDialog1"
        Me.ofdSelectFile.InitialDirectory = "d:\"
        '
        'txtRestoreFile
        '
        Me.txtRestoreFile.Location = New System.Drawing.Point(107, 99)
        Me.txtRestoreFile.Name = "txtRestoreFile"
        Me.txtRestoreFile.ReadOnly = True
        Me.txtRestoreFile.Size = New System.Drawing.Size(486, 22)
        Me.txtRestoreFile.TabIndex = 128
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 19)
        Me.Label1.TabIndex = 127
        Me.Label1.Text = "Restore From"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSelectRestorePath
        '
        Me.btnSelectRestorePath.AutoSize = True
        Me.btnSelectRestorePath.Location = New System.Drawing.Point(599, 98)
        Me.btnSelectRestorePath.Name = "btnSelectRestorePath"
        Me.btnSelectRestorePath.Size = New System.Drawing.Size(64, 27)
        Me.btnSelectRestorePath.TabIndex = 126
        Me.btnSelectRestorePath.Text = "Browse"
        Me.btnSelectRestorePath.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.optBackupSelective)
        Me.GroupBox2.Controls.Add(Me.optRestore)
        Me.GroupBox2.Controls.Add(Me.optBackupFull)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(37, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(354, 63)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'optBackupSelective
        '
        Me.optBackupSelective.AutoSize = True
        Me.optBackupSelective.Enabled = False
        Me.optBackupSelective.Location = New System.Drawing.Point(116, 21)
        Me.optBackupSelective.Name = "optBackupSelective"
        Me.optBackupSelective.Size = New System.Drawing.Size(137, 21)
        Me.optBackupSelective.TabIndex = 2
        Me.optBackupSelective.Text = "Backup Selective"
        Me.optBackupSelective.UseVisualStyleBackColor = True
        '
        'optRestore
        '
        Me.optRestore.AutoSize = True
        Me.optRestore.Location = New System.Drawing.Point(265, 21)
        Me.optRestore.Name = "optRestore"
        Me.optRestore.Size = New System.Drawing.Size(79, 21)
        Me.optRestore.TabIndex = 1
        Me.optRestore.Text = "Restore"
        Me.optRestore.UseVisualStyleBackColor = True
        '
        'optBackupFull
        '
        Me.optBackupFull.AutoSize = True
        Me.optBackupFull.Checked = True
        Me.optBackupFull.Location = New System.Drawing.Point(6, 21)
        Me.optBackupFull.Name = "optBackupFull"
        Me.optBackupFull.Size = New System.Drawing.Size(102, 21)
        Me.optBackupFull.TabIndex = 0
        Me.optBackupFull.TabStop = True
        Me.optBackupFull.Text = "Backup Full"
        Me.optBackupFull.UseVisualStyleBackColor = True
        '
        'frmDBBackup
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(677, 130)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtRestoreFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSelectRestorePath)
        Me.Controls.Add(Me.txtBackupPath)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnSelectBackupPath)
        Me.Controls.Add(Me.btnRestore)
        Me.Controls.Add(Me.btnAllReverseMove)
        Me.Controls.Add(Me.btnSingleReverseMove)
        Me.Controls.Add(Me.btnAllMove)
        Me.Controls.Add(Me.btnSingleMove)
        Me.Controls.Add(Me.btnBackup)
        Me.Controls.Add(Me.lstTableTo)
        Me.Controls.Add(Me.lstTableFrom)
        Me.Name = "frmDBBackup"
        Me.Text = "Perform DB Backup & Restore"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstTableFrom As System.Windows.Forms.ListBox
    Friend WithEvents lstTableTo As System.Windows.Forms.ListBox
    Friend WithEvents btnBackup As System.Windows.Forms.Button
    Friend WithEvents btnSingleMove As System.Windows.Forms.Button
    Friend WithEvents btnAllMove As System.Windows.Forms.Button
    Friend WithEvents btnAllReverseMove As System.Windows.Forms.Button
    Friend WithEvents btnSingleReverseMove As System.Windows.Forms.Button
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents txtBackupPath As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSelectBackupPath As System.Windows.Forms.Button
    Friend WithEvents ofdSelectFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtRestoreFile As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSelectRestorePath As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optRestore As System.Windows.Forms.RadioButton
    Friend WithEvents optBackupFull As System.Windows.Forms.RadioButton
    Friend WithEvents fbdSelectFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents optBackupSelective As System.Windows.Forms.RadioButton
End Class
