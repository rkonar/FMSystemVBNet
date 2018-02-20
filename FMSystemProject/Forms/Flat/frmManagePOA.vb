'Imports System.Drawing.Imaging
'Imports System.IO
Public Class frmManagePOA

    Dim UpdateOrInsert As String = "I"
    Dim mTblID As String

    Sub setFieldsForAdd()
        txtEmail.Text = ""
        txtEndDate.Text = ""
        txtPhone.Text = ""
        txtPOAHolderName.Text = ""
        txtRemarks.Text = ""
        txtStartdate.Text = ""

        txtEmail.ReadOnly = False
        txtPhone.ReadOnly = False
        txtPOAHolderName.ReadOnly = False
        txtRemarks.ReadOnly = False


        btnEndDate.Enabled = True
        btnStartDate.Enabled = True
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnCancel.Enabled = True
        btnClose.Enabled = True

    End Sub
    Sub setFieldsForView()
        txtEmail.ReadOnly = True
        txtPhone.ReadOnly = True
        txtPOAHolderName.ReadOnly = True
        txtRemarks.ReadOnly = True


        btnEndDate.Enabled = False
        btnStartDate.Enabled = False
        btnSave.Enabled = False
        btnEdit.Enabled = True
        btnCancel.Enabled = False
        btnClose.Enabled = True

    End Sub
    Sub setFieldsForEdit()

        txtEmail.ReadOnly = False
        txtPhone.ReadOnly = False
        txtPOAHolderName.ReadOnly = False
        txtRemarks.ReadOnly = False

        btnEndDate.Enabled = True
        btnStartDate.Enabled = True
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnCancel.Enabled = True
        btnClose.Enabled = True

    End Sub

    Sub PopulateAll()
        On Error GoTo errH

        Dim tmpSql As String

        tmpSql = "select * from tblPOA where Status is null and FlatCode='" & gCurFlatCode & "'"
        tmpRS = gcon.Execute(tmpSql)
        If tmpRS.EOF = True Then
            MsgBox("No active POA record present for Flat : " & gCurFlatCode)
            setFieldsForAdd()
            Exit Sub
        End If
        UpdateOrInsert = "U"
        mTblID = tmpRS("tblid").Value.ToString
        txtFlatCode.Text = tmpRS("FlatCode").Value.ToString
        txtPOAHolderName.Text = tmpRS("POAHolderName").Value.ToString
        txtEmail.Text = tmpRS("POAHolderEmail").Value.ToString
        txtPhone.Text = tmpRS("POAHolderPhone").Value.ToString
        txtRemarks.Text = tmpRS("Remarks").Value.ToString
        txtStartdate.Text = formatInt2Date(tmpRS("POAStartDate").Value.ToString)
        txtEndDate.Text = formatInt2Date(tmpRS("POAEndDate").Value.ToString)

        setFieldsForView()

        Exit Sub

errH:

        MsgBox(Err.Description)
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        setFieldsForEdit()

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        PopulateAll()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        On Error GoTo errH

        Dim tmpSql As String


        If validateDetails() = False Then Exit Sub

        If UpdateOrInsert = "U" Then

            tmpSql = "update tblpoa set "
            tmpSql = tmpSql & "POAHolderName='" & Replace(txtPOAHolderName.Text, "'", "''") & "',"
            tmpSql = tmpSql & "POAHolderEmail='" & txtEmail.Text & "',"
            tmpSql = tmpSql & "POAHolderPhone='" & txtPhone.Text & "',Remarks='" & Replace(txtRemarks.Text, "'", "''") & "'"
            If txtStartdate.Text <> "" Then
                tmpSql = tmpSql & ",POAStartDate=" & DateTime.Parse(txtStartdate.Text).ToString(DB_DATEFORMAT)
            End If
            If txtEndDate.Text <> "" Then
                tmpSql = tmpSql & ",POAEndDate=" & DateTime.Parse(txtEndDate.Text).ToString(DB_DATEFORMAT)
            End If

            tmpSql = tmpSql & " where tblid=" & mTblID

            gItemAction = "Update POA Details"
        Else

            tmpSql = "Insert into tblpoa (FlatCode,POAHolderName,POAHolderEmail,POAHolderPhone,Remarks,POAStartDate,POAEndDate) values ( "
            tmpSql = tmpSql & "'" & txtFlatCode.Text & "',"
            tmpSql = tmpSql & "'" & Replace(txtPOAHolderName.Text, "'", "''") & "',"
            tmpSql = tmpSql & "'" & txtEmail.Text & "',"
            tmpSql = tmpSql & "'" & txtPhone.Text & "',"
            tmpSql = tmpSql & "'" & Replace(txtRemarks.Text, "'", "''") & "',"

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

            gItemAction = "Add POA Details"
        End If

        gcon.Execute(tmpSql)

        gItemID = "FlatCode=" & gCurFlatCode

        MsgBox("Save successful")

        If logUserActivity() = False Then Exit Sub

        
        PopulateAll()


        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub

    Function validateDetails() As Boolean
        validateDetails = False

        If Trim(txtPOAHolderName.Text) = "" Then
            MsgBox("Missing POA Holder Name")
            Exit Function
        End If

        If Trim(txtPhone.Text) = "" Then
            MsgBox("Missing phone number")
            Exit Function
        End If

        validateDetails = True
    End Function

    Private Sub btnStartDate_Click(sender As System.Object, e As System.EventArgs) Handles btnStartDate.Click
        dtpDateSelected = txtStartdate.Text
        dlgDtpDialog.ShowDialog()
        dlgDtpDialog.Dispose()
        txtStartdate.Text = dtpDateSelected
    End Sub


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmManagePOA_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        txtFlatCode.Text = gCurFlatCode

        'If gCurFlatCode = "" Then
        '    Me.Text = "Add New POA"
        '    btnEdit.PerformClick()
        '    btnCancel.Enabled = False

        'Else
        '    Me.Text = "Edit POA Details"
        '    PopulateAll()
        'End If
        PopulateAll()
        fetchFlatOwner()
    End Sub


    Sub fetchFlatOwner()
        Dim tmpRS As ADODB.Recordset
        tmpRS = gcon.Execute("select * from tblflatowners where FlatCode='" & txtFlatCode.Text & "' and IsActiveOwner='Y'")
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




    Private Sub cboFlatCode_SelectedValueChanged(sender As Object, e As EventArgs)
        fetchFlatOwner()
        'gCurFlatCode = cboFlatCode.Text
    End Sub

End Class