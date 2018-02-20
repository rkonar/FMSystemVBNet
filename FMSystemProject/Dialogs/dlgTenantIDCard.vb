Imports System.Windows.Forms

Public Class dlgTenantIDCard

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgTenantIDCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PopulateAll()
    End Sub
    
    
    Sub fetchFlatOwner()
        Dim tmpRS As ADODB.Recordset
        tmpRS = gcon.Execute("select * from tblflatowners where FlatCode='" & lblFlatCode.Text & "' and IsActiveOwner='Y'")
        If tmpRS.EOF = False Then
            lblOwnerName.Text = tmpRS("OwnerFullName").Value.ToString & vbNewLine & tmpRS("CoOwnerFullName").Value.ToString
            lblOwnerContact.Text = tmpRS("mobile1").Value.ToString
        Else
            lblOwnerName.Text = ""
            lblOwnerContact.Text = ""
        End If
        tmpRS.Close()
    End Sub
    Sub PopulateAll()
        On Error GoTo errH

        Dim tmpSql As String

        tmpSql = "select * from tbltenants where tblid='" & gCurTblID & "'"
        tmpRS = gcon.Execute(tmpSql)
        If tmpRS.EOF = True Then
            MsgBox("tblid not present in tbltenants table : " & gCurTblID)
            Exit Sub
        End If

        lblFlatCode.Text = tmpRS("FlatCode").Value.ToString
        If tmpRS("Gender").Value.ToString = "M" Then
            lblTenantName.Text = "Mr. " & tmpRS("TenantName").Value.ToString
        ElseIf tmpRS("Gender").Value.ToString = "Female" Then
            lblTenantName.Text = "Ms. " & tmpRS("TenantName").Value.ToString
        Else
            lblTenantName.Text = tmpRS("TenantName").Value.ToString
        End If

        lblEmail1.Text = tmpRS("email").Value.ToString
        lblMobile1.Text = tmpRS("mobile").Value.ToString
        lblAddress.Text = tmpRS("FullPermanentAddress").Value.ToString
        lblStartdate.Text = formatInt2Date(tmpRS("TenancyStartDate").Value.ToString)
        lblEndDate.Text = formatInt2Date(tmpRS("TenancyEndDate").Value.ToString)

        If tmpRS("TenantType").Value.ToString = 1 Then
            chkIndividual.Checked = True
            chkIndividual.Enabled = True
            lblFamilyAdultCount.Text = 1
            chkIndividual.ForeColor = Color.Blue
        ElseIf tmpRS("TenantType").Value.ToString = 2 Then
            chkFamily.Checked = True
            chkFamily.Enabled = True
            chkFamily.ForeColor = Color.Blue
            lblFamilyAdultCount.Text = tmpRS("AdultCount").Value.ToString
            lblFamilyChildCount.Text = tmpRS("ChildCount").Value.ToString
        ElseIf tmpRS("TenantType").Value.ToString = 3 Then
            chkCompany.Checked = True
            chkCompany.Enabled = True
            chkCompany.ForeColor = Color.Blue
            lblFamilyAdultCount.Text = tmpRS("AdultCount").Value.ToString
        End If

        loadTenantImageFromDB()

        fetchFlatOwner()

        lblPage1H1.Text = "TENANT IDENTITY CARD" & vbNewLine & "CARD Number : " & gCurTblID

        Exit Sub

errH:

        MsgBox(Err.Description)
    End Sub

    Sub loadTenantImageFromDB()
        On Error GoTo errH
        Dim memsrtm As New System.IO.MemoryStream, imageRS As New ADODB.Recordset
        Dim arrImage() As Byte, flExt As String

        picBoxTenant.Image = Nothing

        ssql = "select * from tblbinarydata where ItemType='TENANT-PHOTO' and ItemNo='" & gCurTblID & "'"
        imageRS = gcon.Execute(ssql)

        If imageRS.EOF = False Then
            'lblImageSize.Text = Math.Round(imageRS("DataSize").Value.ToString / 1024, 0) & "KB"
            flExt = imageRS("DataType").Value.ToString
            arrImage = imageRS("ItemData").Value
            memsrtm = New System.IO.MemoryStream(arrImage)

            If flExt = ".jpg" Then
                picBoxTenant.Image = Image.FromStream(memsrtm)
                picBoxTenant.SizeMode = PictureBoxSizeMode.StretchImage

            Else 'not supported for photo

            End If


            memsrtm.Close()

        Else

        End If
        imageRS.Close()
        Exit Sub

errH:
        If Err.Description <> "" Then MsgBox(Err.Description)

    End Sub



    Private Sub btnPrintIDCard_Click(sender As Object, e As EventArgs) Handles btnPrintIDCard.Click
        'Me.Width = 1402
        'Me.Height = 1102
        'PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        'PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)

        'Exit Sub
        btnPrintIDCard.Visible = False
        btnClose.Visible = False
        Me.Refresh()
        'Me.WindowState = FormWindowState.Maximized
        captureFormAsImageInFile()
        'Me.WindowState = FormWindowState.Normal
        'myPrintForm()
        btnPrintIDCard.Visible = True
        btnClose.Visible = True

    End Sub
    Sub captureFormAsImageInFile()
        Dim graph As Graphics = Nothing, fileName As String

        Try
            fileName = Replace(getSysParamValue("PATH_TEMP") & lblTenantName.Text & ".jpg", " ", "")
            Dim bmp As New Bitmap(Me.Width, Me.Height)
            graph = Graphics.FromImage(bmp)
            graph.CopyFromScreen(Me.Location.X, Me.Location.Y, 0, 0, bmp.Size)
            bmp.Save(fileName)

            Dim psi As New System.Diagnostics.ProcessStartInfo
            With psi
                .WindowStyle = ProcessWindowStyle.Normal
                .FileName = "C:\windows\system32\mspaint.exe"
                .Arguments = fileName
                System.Diagnostics.Process.Start(psi)
            End With


        Catch ex As Exception
        End Try
    End Sub
    Private Sub myPrintForm()
        'On Error GoTo errH

        '        'Dim psd As New PageSetupDialog

        '        'psd.PrinterSettings = New System.Drawing.Printing.PrinterSettings

        '        'psd.PageSettings = New System.Drawing.Printing.PageSettings



        '        'If psd.ShowDialog = Windows.Forms.DialogResult.OK Then

        '        '    If psd.PrinterSettings.IsValid Then

        '        'PrintForm1.PrinterSettings = psd.PrinterSettings
        '        Dim xCustomSize As New System.Drawing.Printing.PaperSize("A4", 857, 1169)
        '        PrintForm1.PrinterSettings.DefaultPageSettings.PaperSize = xCustomSize
        '        PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = True
        '        PrintForm1.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)

        '        '        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(psd.PageSettings.Margins.Left, psd.PageSettings.Margins.Right, psd.PageSettings.Margins.Top, psd.PageSettings.Margins.Bottom)


        '        '    End If

        '        'End If

        '        PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview


        '        PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.FullWindow)


        '        'psd.Dispose()
        '        Exit Sub

        'errH:
        '        MsgBox(Err.Description)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class
