Public Class frmSaveViewItemData
    Dim UpdateOrInsert As String, flExt As String



    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ''Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


    ''Dim filename As String = txtImagePath.Text

    ''Dim FileSize As UInt32


    ''Dim mstream As System.IO.MemoryStream = ConvertImageFiletoMemoryStream(filename)

    ''pbImage.Image.Save(mstream, Drawing.Imaging.ImageFormat.Jpeg)
    ''    Dim arrImage() As Byte = ConvertImageFiletoBytes(filename)

    ''    FileSize = mstream.Length

    ''    mstream.Close()

    ''    'CREATE TABLE `actors` ( `actor_pic` longblob,`filesize` bigint(20) default NULL,`filename` varchar(150) default NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1; 

    ''ssql = "insert into tblreceipt_image (ReceiptNo, ReceiptImage) VALUES('Test'," & arrImage & ")"
    ''gcon.Execute(ssql)




    ''Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter
    ''adapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT actor_pic, filesize, filename FROM actors", Conn)

    ''Dim Data As New DataTable
    ' ''adapter = New MySql.Data.MySqlClient.MySqlDataAdapter("select picture from [yourtable]", Conn) 

    ''Dim commandbuild As New MySql.Data.MySqlClient.MySqlCommandBuilder(adapter)
    ''adapter.Fill(Data)
    ''MsgBox(Data.Rows.Count)


    ''Dim lb() As Byte = Data.Rows(Data.Rows.Count - 1).Item("actor_pic")
    ''Dim lstr As New System.IO.MemoryStream(lb)
    ''PbPicture.Image = Image.FromStream(lstr)
    ''PbPicture.SizeMode = PictureBoxSizeMode.StretchImage
    ''lstr.Close()

    ''End Sub

    'Public Function ConvertImageFiletoBytes(ByVal ImageFilePath As String) As Byte()
    '    Dim _tempByte() As Byte = Nothing
    '    If String.IsNullOrEmpty(ImageFilePath) = True Then
    '        Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
    '        Return Nothing
    '    End If
    '    Try
    '        Dim _fileInfo As New IO.FileInfo(ImageFilePath)
    '        Dim _NumBytes As Long = _fileInfo.Length
    '        Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
    '        Dim _BinaryReader As New IO.BinaryReader(_FStream)
    '        _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))
    '        _fileInfo = Nothing
    '        _NumBytes = 0
    '        _FStream.Close()
    '        _FStream.Dispose()
    '        _BinaryReader.Close()
    '        Return _tempByte
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function

    'Public Function ConvertBytesToMemoryStream(ByVal ImageData As Byte()) As IO.MemoryStream
    '    Try
    '        If IsNothing(ImageData) = True Then
    '            Return Nothing
    '            'Throw New ArgumentNullException("Image Binary Data Cannot be Null or Empty", "ImageData") 
    '        End If
    '        Return New System.IO.MemoryStream(ImageData)
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function

    'Public Function ConvertImageFiletoMemoryStream(ByVal ImageFilePath As String) As IO.MemoryStream
    '    If String.IsNullOrEmpty(ImageFilePath) = True Then
    '        Return Nothing
    '        ' Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath") 
    '    End If
    '    Return ConvertBytesToMemoryStream(ConvertImageFiletoBytes(ImageFilePath))
    'End Function

    Private Sub btnSaveIntoDB_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveIntoDB.Click

        saveItemDataToDB()

    End Sub
    Sub loadItemDataFromDB()
        On Error GoTo errH
        Dim memsrtm As New System.IO.MemoryStream, imageRS As New ADODB.Recordset
        Dim arrImage() As Byte

        pbImage.Image = Nothing

        ssql = "select * from tblbinarydata where ItemType='" & ImageItemType & "' and ItemNo='" & ImageItemNo & "'"
        imageRS = gcon.Execute(ssql)

        If imageRS.EOF = False Then
            lblImageSize.Text = Math.Round(imageRS("DataSize").Value.ToString / 1024, 0) & "KB"
            flExt = imageRS("DataType").Value.ToString
            arrImage = imageRS("ItemData").Value
            memsrtm = New System.IO.MemoryStream(arrImage)

            If flExt = ".jpg" Then
                pbImage.Visible = True
                pdfReader.Visible = False
                pbImage.Image = Image.FromStream(memsrtm)
                pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ElseIf flExt = ".pdf" Then
                pbImage.Visible = False
                pdfReader.Visible = True
                Dim swrt As System.IO.StreamWriter
                swrt = New System.IO.StreamWriter(Application.StartupPath & "\temp1.pdf")
                memsrtm.CopyTo(swrt.BaseStream)
                swrt.Close()
                pdfReader.LoadFile(Application.StartupPath & "\temp1.pdf")
                System.IO.File.Delete(Application.StartupPath & "\temp1.pdf")
            End If


            memsrtm.Close()
            UpdateOrInsert = "U"
            'gFormDataChanged = True
        Else
            UpdateOrInsert = "I"
            'gFormDataChanged = False
            MsgBox("Data does not exist in system")
        End If
        imageRS.Close()
        Exit Sub

errH:
        If Err.Description <> "" Then MsgBox(Err.Description)

    End Sub




    Sub saveItemDataToDB()
        On Error GoTo errH
        Dim adostrm As New ADODB.Stream, imageRS As New ADODB.Recordset

       
        'DON'T USE TRANSACTION MANAGEMENT AS OPENING UPDATE AFTER INSERT WITHOUT COMMIT IS CREATING ISSUE
        If UpdateOrInsert = "U" Then 'Update
            If MsgBox("This will destroy the old image stored in database and can't be restored. Are you sure?", MsgBoxStyle.YesNo) = vbNo Then
                'gcon2.RollbackTrans()
                Exit Sub
            End If

            'gcon2.Execute("delete from tblbinarydata where ItemType='" & ImageItemType & "' and ItemNo='" & ImageItemNo & "'")

        Else 'Insert
            ssql = "insert into tblbinarydata (ItemType,ItemNo,DataType) VALUES('" & ImageItemType & "','" & ImageItemNo & "','" & flExt & "')"
            gcon.Execute(ssql)

        End If


        imageRS.Open("select * from tblbinarydata where ItemType='" & ImageItemType & "' and ItemNo='" & ImageItemNo & "'", gcon, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        If imageRS.EOF = True Then
            MsgBox("Issue with database operation. Operation aborted.")
            Exit Sub
        End If

        adostrm.Type = ADODB.StreamTypeEnum.adTypeBinary
        adostrm.Open()
        adostrm.LoadFromFile(txtImagePath.Text)

        imageRS.Fields("DataSize").Value = adostrm.Size
        imageRS.Fields("ItemData").Value = adostrm.Read
        imageRS.Update()
        imageRS.Close()

        adostrm.Close()

        btnSaveIntoDB.Enabled = False
        gFormDataChanged = True
        MsgBox("Done")
        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        myMsgBox(gErrMsg)
        adostrm.Close()
        'imageRS.Close()
    End Sub

    Private Sub btnSelectImage_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectImage.Click
        If ofdSelectFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim flInfo As New System.IO.FileInfo(ofdSelectFile.FileName)
        If (flInfo.Length / 1024) > MAX_IMAGE_SIZE_KB Then
            MsgBox("File size is " & Math.Round(flInfo.Length / 1024, 0) & "KB. Max allowed size is " & MAX_IMAGE_SIZE_KB & "KB.")
            Exit Sub
        End If
        flExt = flInfo.Extension
        If flExt = ".jpg" Then
            pbImage.Visible = True
            pdfReader.Visible = False
            pbImage.ImageLocation = ofdSelectFile.FileName
        ElseIf flExt = ".pdf" Then
            pbImage.Visible = False
            pdfReader.Visible = True
            pdfReader.LoadFile(ofdSelectFile.FileName)
        End If

        txtImagePath.Text = ofdSelectFile.FileName
        lblImageSize.Text = Math.Round(flInfo.Length / 1024, 0) & "KB"

        btnSaveIntoDB.Enabled = True
    End Sub

    Private Sub frmSaveViewItemData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = gFormTitle
        txtImagePath.Text = ""
        loadItemDataFromDB()
        btnSaveIntoDB.Enabled = False
        lblMaxImageSize.Text = "Max size allowed :" & MAX_IMAGE_SIZE_KB & "KB"
    End Sub
End Class