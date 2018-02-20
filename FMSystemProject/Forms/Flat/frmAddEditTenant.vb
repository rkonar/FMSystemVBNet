'Imports System.Drawing.Imaging
'Imports System.IO
Public Class frmAddEditTenant

    Dim myCam As New clsWebCam
    Dim ImageUpdateOrInsert As String = "I"

    Sub PopulateAll()
        On Error GoTo errH

        Dim tmpSql As String

        tmpSql = "select * from tbltenants where tblid='" & gCurTblID & "'"
        tmpRS = gcon.Execute(tmpSql)
        If tmpRS.EOF = True Then
            MsgBox("tblid not present in tbltenants table : " & gCurTblID)
            Exit Sub
        End If

        cboFlatCode.Text = tmpRS("FlatCode").Value.ToString
        cboGender.Text = tmpRS("Gender").Value.ToString
        txtTenantName.Text = tmpRS("TenantName").Value.ToString
        txtEmail1.Text = tmpRS("email").Value.ToString
        txtMobile1.Text = tmpRS("mobile").Value.ToString
        txtAddress.Text = tmpRS("FullPermanentAddress").Value.ToString
        txtStartdate.Text = formatInt2Date(tmpRS("TenancyStartDate").Value.ToString)
        txtEndDate.Text = formatInt2Date(tmpRS("TenancyEndDate").Value.ToString)
        txtAdultCount.Text = tmpRS("AdultCount").Value.ToString
        txtChildCount.Text = tmpRS("ChildCount").Value.ToString
        cboTenantType.SelectedIndex = CInt(tmpRS("TenantType").Value.ToString) - 1

        cboReceiptNo.Items.Add(tmpRS("ReceiptNo").Value.ToString)
        cboReceiptNo.Text = tmpRS("ReceiptNo").Value.ToString

        If tmpRS("FeePaid").Value.ToString = "Y" Then
            chkFeePaid.Checked = True
            'chkFeePaid.Enabled = False
        Else
            chkFeePaid.Checked = False
            'chkFeePaid.Enabled = True
        End If
        'If cboReceiptNo.Text = "" Then
        '    cboReceiptNo.Enabled = True
        '    loadReceipts()
        'Else
        '    cboReceiptNo.Enabled = False
        'End If
        cboReceiptNo.Enabled = False

        cboGender.Enabled = False
        cboFlatCode.Enabled = False
        txtEmail1.ReadOnly = True
        txtMobile1.ReadOnly = True
        txtAddress.ReadOnly = True
        txtTenantName.ReadOnly = True
        cboTenantType.Enabled = False
        txtAdultCount.Enabled = False
        txtChildCount.Enabled = False
        chkFeePaid.Enabled = False

        btnEdit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False

        btnStartDate.Enabled = False
        btnEndDate.Enabled = False
        btnActivateCamera.Enabled = True

        loadTenantImageFromDB()

        If (tmpRS("PhotoTaken").Value.ToString = "Y") And (tmpRS("TenancyAgreementSubmitted").Value.ToString = "Y") And (tmpRS("PhotoIDProofSubmitted").Value.ToString = "Y") And (tmpRS("PoliceFormSubmitted").Value.ToString = "Y") And (tmpRS("ApplicationFormSubmitted").Value.ToString = "Y") Then
            btnPrintIDCard.Enabled = True
        Else
            btnPrintIDCard.Enabled = False
        End If


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
            lblImageSize.Text = Math.Round(imageRS("DataSize").Value.ToString / 1024, 0) & "KB"
            flExt = imageRS("DataType").Value.ToString
            arrImage = imageRS("ItemData").Value
            memsrtm = New System.IO.MemoryStream(arrImage)

            If flExt = ".jpg" Then
                picBoxTenant.Image = Image.FromStream(memsrtm)
                picBoxTenant.SizeMode = PictureBoxSizeMode.StretchImage
                ImageUpdateOrInsert = "U"
            Else 'not supported for photo

            End If


            memsrtm.Close()
            'UpdateOrInsert = "U"
            'gFormDataChanged = True
        Else
            'UpdateOrInsert = "I"
            'gFormDataChanged = False
            'MsgBox("Data does not exist in system")
        End If
        imageRS.Close()
        Exit Sub

errH:
        If Err.Description <> "" Then MsgBox(Err.Description)

    End Sub
    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True


        cboGender.Enabled = True
        cboFlatCode.Enabled = True
        txtEmail1.ReadOnly = False
        txtMobile1.ReadOnly = False
        txtAddress.ReadOnly = False
        txtTenantName.ReadOnly = False
        cboTenantType.Enabled = True
        txtAdultCount.Enabled = True
        txtChildCount.Enabled = True

        btnStartDate.Enabled = True
        btnEndDate.Enabled = True

        chkFeePaid.Enabled = Not chkFeePaid.Checked

        If cboReceiptNo.Text = "" Then
            cboReceiptNo.Enabled = True
            loadReceipts()
        Else
            cboReceiptNo.Enabled = False
        End If

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        PopulateAll()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        On Error GoTo errH

        Dim tmpSql As String


        If validateDetails() = False Then Exit Sub

        If gCurTblID <> "" Then

            tmpSql = "update tbltenants set "
            tmpSql = tmpSql & "FlatCode='" & cboFlatCode.Text & "',"
            tmpSql = tmpSql & "TenantName='" & Replace(txtTenantName.Text, "'", "''") & "',"
            tmpSql = tmpSql & "Gender='" & cboGender.Text & "',"
            tmpSql = tmpSql & "email='" & txtEmail1.Text & "',"
            tmpSql = tmpSql & "mobile='" & txtMobile1.Text & "',FullPermanentAddress='" & Replace(txtAddress.Text, "'", "''") & "'"
            If txtStartdate.Text <> "" Then
                tmpSql = tmpSql & ",TenancyStartDate='" & DateTime.Parse(txtStartdate.Text).ToString(DB_DATEFORMAT) & "'"
            End If
            If txtEndDate.Text <> "" Then
                tmpSql = tmpSql & ",TenancyEndDate='" & DateTime.Parse(txtEndDate.Text).ToString(DB_DATEFORMAT) & "'"
            End If
            tmpSql = tmpSql & ", TenantType=" & (cboTenantType.SelectedIndex + 1)
            
            tmpSql = tmpSql & ", AdultCount=" & txtAdultCount.Text
            tmpSql = tmpSql & ", ChildCount=" & txtChildCount.Text

            If chkFeePaid.Checked = True Then
                tmpSql = tmpSql & ", FeePaid='Y'"
            Else
                tmpSql = tmpSql & ", FeePaid='N'"
            End If
            If cboReceiptNo.Enabled = True Then
                tmpSql = tmpSql & ", ReceiptNo='" & cboReceiptNo.Text & "'"
            End If

            tmpSql = tmpSql & " where tblid=" & gCurTblID

            gItemAction = "Update Tenant Details"
        Else

            tmpSql = "Insert into tbltenants (FlatCode,TenantName,Gender,Email,Mobile,FullPermanentAddress,TenantType,AdultCount,ChildCount,TenancyStartDate,TenancyEndDate) values ( "
            tmpSql = tmpSql & "'" & cboFlatCode.Text & "',"
            tmpSql = tmpSql & "'" & Replace(txtTenantName.Text, "'", "''") & "',"
            tmpSql = tmpSql & "'" & cboGender.Text & "',"
            tmpSql = tmpSql & "'" & txtEmail1.Text & "',"
            tmpSql = tmpSql & "'" & txtMobile1.Text & "',"
            tmpSql = tmpSql & "'" & Replace(txtAddress.Text, "'", "''") & "',"
            tmpSql = tmpSql & (cboTenantType.SelectedIndex + 1) & "," & txtAdultCount.Text & "," & txtChildCount.Text & ","


            If txtStartdate.Text <> "" Then
                tmpSql = tmpSql & "'" & DateTime.Parse(txtStartdate.Text).ToString(DB_DATEFORMAT) & "',"
            Else
                tmpSql = tmpSql & "null,"
            End If
            If txtEndDate.Text <> "" Then
                tmpSql = tmpSql & "'" & DateTime.Parse(txtEndDate.Text).ToString(DB_DATEFORMAT) & "'"
            Else
                tmpSql = tmpSql & "null"
            End If

            tmpSql = tmpSql & ")"

            gItemAction = "Add Tenant Details"
        End If

        gcon.Execute(tmpSql)

        gItemID = "tblid=" & gCurTblID

        MsgBox("Save successful")

        If logUserActivity() = False Then Exit Sub

        If gCurTblID = "" Then
            btnClose.PerformClick()
        Else
            PopulateAll()
        End If



        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub

    Function validateDetails() As Boolean
        validateDetails = False

        If Trim(txtTenantName.Text) = "" Then
            MsgBox("Missing Tenant Name")
            Exit Function
        End If
        If Trim(txtAddress.Text) = "" Then
            MsgBox("Missing Address")
            Exit Function
        End If
        If Trim(txtMobile1.Text) = "" Then
            MsgBox("Missing mobile number")
            Exit Function
        End If

        If Trim(cboGender.Text) = "" Then
            MsgBox("Missing Gender")
            Exit Function
        End If

        If IsNumeric(txtAdultCount.Text) = False Then
            MsgBox("Invalid Adult Count")
            Exit Function
        End If
        If IsNumeric(txtChildCount.Text) = False Then
            MsgBox("Invalid Child Count")
            Exit Function
        End If

        If cboTenantType.SelectedIndex = 1 Then 'Family
            If txtAdultCount.Text < 1 Then
                MsgBox("Invalid Adult Count")
                Exit Function
            End If
            If txtAdultCount.Text = 1 And txtChildCount.Text = 0 Then
                MsgBox("Invalid Child Count")
                Exit Function
            End If
        ElseIf cboTenantType.SelectedIndex = 0 Then 'Individual
            If txtAdultCount.Text <> 1 Then
                MsgBox("Invalid Adult Count")
                Exit Function
            End If
            If txtChildCount.Text <> 0 Then
                MsgBox("Invalid Child Count")
                Exit Function
            End If
        ElseIf cboTenantType.SelectedIndex = 2 Then 'Company
            If txtAdultCount.Text < 1 Then
                MsgBox("Invalid Adult Count")
                Exit Function
            End If
            If txtChildCount.Text <> 0 Then
                MsgBox("Invalid Child Count")
                Exit Function
            End If
        End If

        If chkFeePaid.Checked = True And cboReceiptNo.Text = "" Then
            MsgBox("Provide Receipt No")
            Exit Function
        End If
        If chkFeePaid.Checked = False And cboReceiptNo.Text <> "" Then
            MsgBox("Mark fee paid")
            Exit Function
        End If

        validateDetails = True
    End Function

    Private Sub btnOwnerSince_Click(sender As System.Object, e As System.EventArgs) Handles btnStartDate.Click
        dtpDateSelected = txtStartdate.Text
        dlgDtpDialog.ShowDialog()
        dlgDtpDialog.Dispose()
        txtStartdate.Text = dtpDateSelected
    End Sub


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmAddEditTenant_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cboFlatCode.DataSource = FLATS

        cboGender.Items.Add("M")
        cboGender.Items.Add("F")
        cboGender.Items.Add("-")

        'Do not change the ordering below as index position has been used in code
        cboTenantType.Items.Add("Individual")
        cboTenantType.Items.Add("Family")
        cboTenantType.Items.Add("Company")

        lblImageSize.Text = ""

        If gCurTblID = "" Then
            Me.Text = "Add New Tenant"
            btnEdit.PerformClick()
            btnActivateCamera.Enabled = False
            btnPrintIDCard.Enabled = False

            txtAdultCount.Text = 1
            txtChildCount.Text = 0

            btnCancel.Enabled = False
            cboReceiptNo.Enabled = False
            chkFeePaid.Enabled = False

        Else
            Me.Text = "Edit Tenant Details"
            PopulateAll()
        End If
    End Sub

    Sub loadReceipts()
        Dim tmpRS As ADODB.Recordset, mydocref As New clsDocRef, thisReceiptNo As String
        cboReceiptNo.Items.Clear()
        tmpRS = gcon.Execute("select DocRef from tbljournal where Status is null and CrAmount>0 and TxnType='TENANCY-REGISTRATION-FEE-RECEIPT' and DocRef like '%Payee:" & cboFlatCode.Text & ")'")
        While tmpRS.EOF = False

            thisReceiptNo = mydocref.getReceiptNo(tmpRS("DocRef").Value.ToString)
            cboReceiptNo.Items.Add(thisReceiptNo)
            tmpRS.MoveNext()

        End While
        tmpRS.Close()
        cboReceiptNo.SelectedIndex = -1
    End Sub

    Sub fetchFlatOwner()
        Dim tmpRS As ADODB.Recordset
        tmpRS = gcon.Execute("select * from tblflatowners where FlatCode='" & cboFlatCode.Text & "' and IsActiveOwner='Y'")
        If tmpRS.EOF = False Then
            lblOwnerDetails.Text = tmpRS("OwnerFullName").Value.ToString & Chr(10) & tmpRS("CoOwnerFullName").Value.ToString
        Else
            lblOwnerDetails.Text = ""
        End If
        tmpRS.Close()
    End Sub
    Private Sub btnEndDate_Click(sender As Object, e As EventArgs) Handles btnEndDate.Click
        dtpDateSelected = txtEndDate.Text
        dlgDtpDialog.ShowDialog()
        dlgDtpDialog.Dispose()
        txtEndDate.Text = dtpDateSelected
    End Sub

    Private Sub btnEditFlatOwnerDetails_Click(sender As Object, e As EventArgs) Handles btnEditFlatOwnerDetails.Click
        gCurFlatCode = cboFlatCode.Text
        frmManageFlats.ShowDialog()
        frmManageFlats.Dispose()
    End Sub


    Private Sub cboFlatCode_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFlatCode.SelectedValueChanged
        fetchFlatOwner()
        gCurFlatCode = cboFlatCode.Text
    End Sub

    Private Sub btnActivateCamera_Click(sender As Object, e As EventArgs) Handles btnActivateCamera.Click
        myCam.LoadDeviceList()
        myCam.curImageDeviceID = 0 'take the first camera device
        myCam.OpenPreviewWindow(picBoxPreview)

        btnTakeSnap.Enabled = True
    End Sub

    Private Sub btnTakeSnap_Click(sender As Object, e As EventArgs) Handles btnTakeSnap.Click
        myCam.TakeSnapToPicBox(picBoxTenant)
        btnSavePicture.Enabled = True
    End Sub

    Private Sub btnSavePicture_Click(sender As Object, e As EventArgs) Handles btnSavePicture.Click
        On Error GoTo errH
        Dim adostrm As New ADODB.Stream, imageRS As New ADODB.Recordset

        gcon.BeginTrans()

        If ImageUpdateOrInsert = "U" Then
            If MsgBox("This will destroy the old image stored in database and can't be restored. Are you sure?", MsgBoxStyle.YesNo) = vbNo Then
                gcon.RollbackTrans()
                Exit Sub
            End If

            gcon.Execute("delete from tblbinarydata where ItemType='TENANT-PHOTO' and ItemNo='" & gCurTblID & "'")
        End If

        ssql = "insert into tblbinarydata (ItemType,ItemNo,DataType) VALUES('TENANT-PHOTO','" & gCurTblID & "','.jpg')"
        gcon.Execute(ssql)

        adostrm.Type = ADODB.StreamTypeEnum.adTypeBinary
        adostrm.Open()
        picBoxTenant.Image.Save(getSysParamValue("PATH_TEMP") & gCurTblID & ".jpg")
        adostrm.LoadFromFile(getSysParamValue("PATH_TEMP") & gCurTblID & ".jpg")

        'Dim ms As MemoryStream = New MemoryStream()
        'picBoxTenant.Image.Save(ms, ImageFormat.Jpeg)
        'Dim bytBLOBData(ms.Length - 1) As Byte
        'ms.Position = 0
        'ms.Read(bytBLOBData, 0, ms.Length)

        imageRS.Open("select * from tblbinarydata where ItemType='TENANT-PHOTO' and ItemNo='" & gCurTblID & "'", gcon, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        imageRS.Fields("DataSize").Value = adostrm.Size
        imageRS.Fields("ItemData").Value = adostrm.Read
        imageRS.Update()
        imageRS.Close()

        adostrm.Close()

        'Update tenant table
        gcon.Execute("Update tbltenants set PhotoTaken='Y' where tblid=" & gCurTblID)

        System.IO.File.Delete(getSysParamValue("PATH_TEMP") & gCurTblID & ".jpg")

        gcon.CommitTrans()
        btnSavePicture.Enabled = False
        gFormDataChanged = True
        MsgBox("Done")
        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)

    End Sub


    Private Sub btnPrintIDCard_Click(sender As Object, e As EventArgs) Handles btnPrintIDCard.Click
        dlgTenantIDCard.ShowDialog()
        dlgTenantIDCard.Dispose()
    End Sub

    Private Sub txtAddress_Click(sender As Object, e As EventArgs) Handles txtAddress.Click
        btnPrintIDCard.Enabled = True
    End Sub

End Class