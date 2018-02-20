Public Class frmManageFlats
    Dim curFlatOwnerID As String, bAddNewOwner As Boolean = False
    Private Sub frmManageFlats_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        gItemCode = Me.Text
        PopulateAll()
    End Sub

    Sub populatePOA()
        On Error GoTo errH

        Dim tmpSql As String

        tmpSql = "select count(*) as cnt from tblpoa where Status is null and FlatCode='" & gCurFlatCode & "'"
        tmpRS = gcon.Execute(tmpSql)
        If tmpRS("cnt").Value > 0 Then
            chkPOAExist.Checked = True
        Else
            chkPOAExist.Checked = False
        End If
        tmpRS.Close()
        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        myMsgBox(gErrMsg)
    End Sub

    Sub PopulateAll()
        On Error GoTo errH

        Dim tmpSql As String

        tmpSql = "select * from tblflats where FlatCode='" & gCurFlatCode & "'"
        tmpRS = gcon.Execute(tmpSql)
        If tmpRS.EOF = True Then
            MsgBox("Invalid Flat Code : " & gCurFlatCode)
            Exit Sub
        End If

        txtTower.Text = tmpRS("TowerName").Value.ToString
        gCurTowerName = tmpRS("TowerName").Value.ToString
        txtFlat.Text = myRight(gCurFlatCode, 3)
        cboNoOfRooms.Text = tmpRS("NoOfRooms").Value.ToString
        cboDuplex.Text = tmpRS("IsPartOfDuplex").Value.ToString
        txtSBUArea.Text = tmpRS("SBUSqFtArea").Value.ToString
        txtTerraceArea.Text = tmpRS("TerraceSqFtArea").Value.ToString

        tmpSql = "select * from tblflatowners where FlatCode='" & gCurFlatCode & "' and IsActiveOwner='Y'"
        tmpRS = gcon.Execute(tmpSql)
        If tmpRS.EOF = True Then
            MsgBox("Invalid Flat Code : " & gCurFlatCode)
            Exit Sub
        End If

        curFlatOwnerID = tmpRS("tblid").Value.ToString
        txtOwner.Text = tmpRS("OwnerFullName").Value.ToString
        txtCoOwner.Text = tmpRS("CoOwnerFullName").Value.ToString
        txtOwnerSince.Text = formatInt2Date(tmpRS("StartDate").Value.ToString)

        txtPrimaryEmail.Text = tmpRS("PrimaryEmail").Value.ToString
        txtEmail1.Text = tmpRS("email1").Value.ToString
        txtEmail2.Text = tmpRS("email2").Value.ToString

        txtPrimaryPhone.Text = tmpRS("PrimaryPhone").Value.ToString
        txtLandline1.Text = tmpRS("landline1").Value.ToString
        txtLandline2.Text = tmpRS("landline2").Value.ToString

        txtMobile1_SMS.Text = tmpRS("mobile1").Value.ToString
        txtMobile2.Text = tmpRS("mobile2").Value.ToString

        txtPresentAddress.Text = tmpRS("FullPresentAddress").Value.ToString
        txtCommAddress.Text = tmpRS("FullCommunicationAddress").Value.ToString

        'Portal fields
        txtPortalEmail1.Text = tmpRS("p_email1").Value.ToString
        txtPortalEmail2.Text = tmpRS("p_email2").Value.ToString
        txtPortalMobile1.Text = tmpRS("p_mobile1").Value.ToString
        txtPortalMobile2.Text = tmpRS("p_mobile2").Value.ToString
        txtPortalLandline1.Text = tmpRS("p_landline1").Value.ToString

        txtEVotingEmailId.Text = tmpRS("evoting_mailid").Value.ToString


        txtEmailBlockReason.Text = tmpRS("emailblockreason").Value.ToString
        txtBlockedEmails.Text = tmpRS("blockedemails").Value.ToString


        btnEdit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False

        txtCommAddress.ReadOnly = True
        txtEmail1.ReadOnly = True
        txtEmail2.ReadOnly = True
        txtLandline1.ReadOnly = True
        txtLandline2.ReadOnly = True
        txtMobile1_SMS.ReadOnly = True
        txtMobile2.ReadOnly = True
        txtPresentAddress.ReadOnly = True
        txtPrimaryEmail.ReadOnly = True
        txtPrimaryPhone.ReadOnly = True

        txtOwner.ReadOnly = True
        txtCoOwner.ReadOnly = True
        btnOwnerSince.Enabled = False

        txtBlockedEmails.ReadOnly = True
        txtEmailBlockReason.ReadOnly = True

        grpPortal.Visible = True

        populatePOA()

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        myMsgBox(gErrMsg)
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True

        txtCommAddress.ReadOnly = False
        txtEmail1.ReadOnly = False
        txtEmail2.ReadOnly = False
        txtLandline1.ReadOnly = False
        txtLandline2.ReadOnly = False
        txtMobile1_SMS.ReadOnly = False
        txtMobile2.ReadOnly = False
        txtPresentAddress.ReadOnly = False
        txtPrimaryEmail.ReadOnly = False
        txtPrimaryPhone.ReadOnly = False
        txtOwner.ReadOnly = False
        txtCoOwner.ReadOnly = False
        btnOwnerSince.Enabled = True
        txtBlockedEmails.ReadOnly = False
        txtEmailBlockReason.ReadOnly = False

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        PopulateAll()
    End Sub

    Function validateNewOwnerAdd() As Boolean
        validateNewOwnerAdd = False

        If txtOwnerSince.Text = "" Then
            If MsgBox("Owner since date is not entered. This should be set as per sale deed. Till Sale Deed is submitted, Is it OK to proceed with today's date?", MsgBoxStyle.YesNo) = vbNo Then Exit Function
            txtOwnerSince.Text = DateTime.Now.ToString(SCREEN_DATEFORMAT)
        Else
            If DateTime.Parse(txtOwnerSince.Text) > DateTime.Now.Date Then
                MsgBox("Owner since date can't be future date")
                Exit Function
            End If
        End If


        If Trim(txtOwner.Text) = "" Then
            MsgBox("Enter Owner Name")
            Exit Function
        End If

        If validateSMSMobileNumber() = False Then Exit Function

        validateNewOwnerAdd = True
    End Function

    Function validateSMSMobileNumber() As Boolean
        validateSMSMobileNumber = False
        If txtMobile1_SMS.Text = "" Then
            validateSMSMobileNumber = True
            Exit Function
        Else
            If IsNumeric(txtMobile1_SMS.Text) = False Then
                MsgBox("Mobile 1 should be numeric")
                Exit Function
            End If
            If Len(txtMobile1_SMS.Text) < 10 Or Len(txtMobile1_SMS.Text) > 11 Then
                MsgBox("No of digits in Mobile 1 is not correct")
                Exit Function
            End If
            If myLeft(txtMobile1_SMS.Text, 1) = "0" Then
                If txtMobile1_SMS.TextLength <> 11 Then
                    MsgBox("No of digits in Mobile 1 is not correct")
                    Exit Function
                End If
            End If
        End If

        validateSMSMobileNumber = True
    End Function

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo errH

        Dim tmpSql As String, tmpSql2 As String

        txtMobile1_SMS.Text = Trim(txtMobile1_SMS.Text)
        If validateSMSMobileNumber() = False Then Exit Sub

        If bAddNewOwner = False Then
            tmpSql = "update tblflatowners set "
            tmpSql = tmpSql & "OwnerFullName='" & txtOwner.Text & "', CoOwnerFullName='" & txtCoOwner.Text & "',PrimaryEmail='" & txtPrimaryEmail.Text & "',PrimaryPhone='" & txtPrimaryPhone.Text & "',"
            tmpSql = tmpSql & "email1='" & txtEmail1.Text & "', email2='" & txtEmail2.Text & "',landline1='" & txtLandline1.Text & "',landline2='" & txtLandline2.Text & "',"
            tmpSql = tmpSql & "mobile1='" & txtMobile1_SMS.Text & "', mobile2='" & txtMobile2.Text & "',FullPresentAddress='" & Replace(txtPresentAddress.Text, "'", "''") & "',FullCommunicationAddress='" & Replace(txtCommAddress.Text, "'", "''") & "'"
            If txtOwnerSince.Text <> "" Then
                tmpSql = tmpSql & ",StartDate='" & DateTime.Parse(txtOwnerSince.Text).ToString(DB_DATEFORMAT) & "'"
            End If
            tmpSql = tmpSql & " ,blockedemails='" & txtBlockedEmails.Text & "'"
            tmpSql = tmpSql & " ,emailblockreason='" & Replace(txtEmailBlockReason.Text, "'", "''") & "'"
            tmpSql = tmpSql & " where tblid=" & curFlatOwnerID

            gcon.Execute(tmpSql)


            gItemAction = "Update Owner Details"

        Else
            If validateNewOwnerAdd() = False Then Exit Sub


            tmpSql = "INSERT INTO tblflatowners (FlatCode,OwnerFullName,CoOwnerFullName,PrimaryEmail,PrimaryPhone,email1,email2,landline1,landline2,mobile1,mobile2,FullPresentAddress,FullCommunicationAddress,StartDate,IsActiveOwner) Values ( "
            tmpSql = tmpSql & "'" & gCurFlatCode & "'"
            tmpSql = tmpSql & ",'" & Replace(txtOwner.Text, "'", "''") & "'"
            tmpSql = tmpSql & ",'" & Replace(txtCoOwner.Text, "'", "''") & "'"
            tmpSql = tmpSql & ",'" & txtPrimaryEmail.Text & "'"
            tmpSql = tmpSql & ",'" & txtPrimaryPhone.Text & "'"
            tmpSql = tmpSql & ",'" & txtEmail1.Text & "'"
            tmpSql = tmpSql & ",'" & txtEmail2.Text & "'"
            tmpSql = tmpSql & ",'" & txtLandline1.Text & "'"
            tmpSql = tmpSql & ",'" & txtLandline2.Text & "'"
            tmpSql = tmpSql & ",'" & txtMobile1_SMS.Text & "'"
            tmpSql = tmpSql & ",'" & txtMobile2.Text & "'"
            tmpSql = tmpSql & ",'" & Replace(txtPresentAddress.Text, "'", "''") & "'"
            tmpSql = tmpSql & ",'" & Replace(txtCommAddress.Text, "'", "''") & "'"
            tmpSql = tmpSql & ",'" & DateTime.Parse(txtOwnerSince.Text).ToString(DB_DATEFORMAT) & "'"
            tmpSql = tmpSql & ",'Y')"


            tmpSql2 = "update tblflatowners set IsActiveOwner='N', EndDate='" & DateTime.Parse(txtOwnerSince.Text).ToString(DB_DATEFORMAT) & "'"
            tmpSql2 = tmpSql2 & " where tblid=" & curFlatOwnerID

            gcon.BeginTrans()
            gcon.Execute(tmpSql)
            gcon.Execute(tmpSql2)
            gcon.CommitTrans()

            gItemAction = "Add New Owner"

        End If

        gFlats.loadAll()

        gItemID = "flat=" & gCurFlatCode
        If logUserActivity() = False Then Exit Sub

        PopulateAll()
        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)

    End Sub

    Private Sub btnOwnerSince_Click(sender As System.Object, e As System.EventArgs) Handles btnOwnerSince.Click
        dtpDateSelected = txtOwnerSince.Text
        dlgDtpDialog.ShowDialog()
        dlgDtpDialog.Dispose()
        txtOwnerSince.Text = dtpDateSelected
    End Sub

    Private Sub txtOwnerSince_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOwnerSince.TextChanged

    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAddNewOwner_Click(sender As Object, e As EventArgs) Handles btnAddNewOwner.Click
        bAddNewOwner = True
        btnEdit.PerformClick()

        txtOwner.Text = ""
        txtCoOwner.Text = ""
        txtOwnerSince.Text = ""

        txtPrimaryEmail.Text = ""
        txtEmail1.Text = ""
        txtEmail2.Text = ""

        txtPrimaryPhone.Text = ""
        txtLandline1.Text = ""
        txtLandline2.Text = ""

        txtMobile1_SMS.Text = ""
        txtMobile2.Text = ""

        txtPresentAddress.Text = ""
        txtCommAddress.Text = ""

        grpPortal.Visible = False
        txtPortalEmail1.Text = ""
        txtPortalEmail2.Text = ""
        txtPortalLandline1.Text = ""
        txtPortalMobile1.Text = ""
        txtPortalMobile2.Text = ""

        txtEVotingEmailId.Text = ""


        txtBlockedEmails.Text = ""
        txtEmailBlockReason.Text = ""
    End Sub

    Private Sub btnAddEditPOA_Click(sender As Object, e As EventArgs) Handles btnAddEditPOA.Click

        frmManagePOA.ShowDialog()
        frmManagePOA.Dispose()
        PopulateAll()
    End Sub

    
End Class