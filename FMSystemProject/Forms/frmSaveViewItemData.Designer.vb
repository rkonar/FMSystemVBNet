<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaveViewItemData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaveViewItemData))
        Me.pbImage = New System.Windows.Forms.PictureBox()
        Me.ofdSelectFile = New System.Windows.Forms.OpenFileDialog()
        Me.btnSelectImage = New System.Windows.Forms.Button()
        Me.txtImagePath = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnSaveIntoDB = New System.Windows.Forms.Button()
        Me.lblMaxImageSize = New System.Windows.Forms.Label()
        Me.lblImageSize = New System.Windows.Forms.Label()
        Me.pdfReader = New AxAcroPDFLib.AxAcroPDF()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pdfReader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbImage
        '
        Me.pbImage.Location = New System.Drawing.Point(2, 37)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(962, 668)
        Me.pbImage.TabIndex = 0
        Me.pbImage.TabStop = False
        '
        'ofdSelectFile
        '
        Me.ofdSelectFile.DefaultExt = "*.pdf"
        Me.ofdSelectFile.InitialDirectory = "d:\"
        '
        'btnSelectImage
        '
        Me.btnSelectImage.AutoSize = True
        Me.btnSelectImage.Location = New System.Drawing.Point(789, 5)
        Me.btnSelectImage.Name = "btnSelectImage"
        Me.btnSelectImage.Size = New System.Drawing.Size(151, 27)
        Me.btnSelectImage.TabIndex = 120
        Me.btnSelectImage.Text = "Select New Image"
        Me.btnSelectImage.UseVisualStyleBackColor = True
        '
        'txtImagePath
        '
        Me.txtImagePath.Location = New System.Drawing.Point(91, 7)
        Me.txtImagePath.Name = "txtImagePath"
        Me.txtImagePath.Size = New System.Drawing.Size(679, 22)
        Me.txtImagePath.TabIndex = 122
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 17)
        Me.Label7.TabIndex = 121
        Me.Label7.Text = "Image Path"
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClose.Location = New System.Drawing.Point(1083, 67)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(53, 27)
        Me.btnClose.TabIndex = 123
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(2, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(904, 454)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnSaveIntoDB
        '
        Me.btnSaveIntoDB.AutoSize = True
        Me.btnSaveIntoDB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSaveIntoDB.Location = New System.Drawing.Point(971, 67)
        Me.btnSaveIntoDB.Name = "btnSaveIntoDB"
        Me.btnSaveIntoDB.Size = New System.Drawing.Size(100, 27)
        Me.btnSaveIntoDB.TabIndex = 124
        Me.btnSaveIntoDB.Text = "Save Into DB"
        Me.btnSaveIntoDB.UseVisualStyleBackColor = True
        '
        'lblMaxImageSize
        '
        Me.lblMaxImageSize.AutoSize = True
        Me.lblMaxImageSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaxImageSize.ForeColor = System.Drawing.Color.Red
        Me.lblMaxImageSize.Location = New System.Drawing.Point(961, 8)
        Me.lblMaxImageSize.Name = "lblMaxImageSize"
        Me.lblMaxImageSize.Size = New System.Drawing.Size(184, 17)
        Me.lblMaxImageSize.TabIndex = 125
        Me.lblMaxImageSize.Text = "Max image size: 1500KB"
        '
        'lblImageSize
        '
        Me.lblImageSize.AutoSize = True
        Me.lblImageSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageSize.ForeColor = System.Drawing.Color.Black
        Me.lblImageSize.Location = New System.Drawing.Point(978, 29)
        Me.lblImageSize.Name = "lblImageSize"
        Me.lblImageSize.Size = New System.Drawing.Size(105, 17)
        Me.lblImageSize.TabIndex = 126
        Me.lblImageSize.Text = "<Image Size>"
        '
        'pdfReader
        '
        Me.pdfReader.Enabled = True
        Me.pdfReader.Location = New System.Drawing.Point(2, 37)
        Me.pdfReader.Name = "pdfReader"
        Me.pdfReader.OcxState = CType(resources.GetObject("pdfReader.OcxState"), System.Windows.Forms.AxHost.State)
        Me.pdfReader.Size = New System.Drawing.Size(952, 657)
        Me.pdfReader.TabIndex = 127
        '
        'frmSaveViewItemData
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1200, 715)
        Me.Controls.Add(Me.pdfReader)
        Me.Controls.Add(Me.lblImageSize)
        Me.Controls.Add(Me.lblMaxImageSize)
        Me.Controls.Add(Me.btnSaveIntoDB)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtImagePath)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnSelectImage)
        Me.Controls.Add(Me.pbImage)
        Me.Name = "frmSaveViewItemData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Save / View Item"
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pdfReader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents ofdSelectFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSelectImage As System.Windows.Forms.Button
    Friend WithEvents txtImagePath As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSaveIntoDB As System.Windows.Forms.Button
    Friend WithEvents lblMaxImageSize As System.Windows.Forms.Label
    Friend WithEvents lblImageSize As System.Windows.Forms.Label
    Friend WithEvents pdfReader As AxAcroPDFLib.AxAcroPDF
End Class
