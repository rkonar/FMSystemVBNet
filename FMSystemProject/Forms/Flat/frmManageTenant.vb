Public Class frmManageTenant

    Dim flatQuerySQL As String

    Sub resetForm()
        'cboDuplex.Text = "ALL"
        'cboNoOfRooms.Text = "ALL"
        'cboPortal.Text = "ALL"
        'cboSoftBill.Text = "ALL"
        'txtAddress.Text = ""
        'txtEmail.Text = ""
        'txtFlat.Text = ""
        'txtOwner.Text = ""
        'txtPhone.Text = ""
        'cboTower.DataSource = TOWERS
        'cboTower.Items.Add("")
        'cboTower.Text = ""
        dgvTenants.Rows.Clear()
        frmMain.sslabel3.Text = ""
        cboFlatCode.DataSource = FLATS
    End Sub

    Private Sub btnQuery_Click(sender As System.Object, e As System.EventArgs) Handles btnQuery.Click
        If chkOnlyExpiringInNDays.Checked = True Then
            If IsNumeric(txtExpiringInDays.Text) = False Then
                MsgBox("Invalid Days")
                Exit Sub
            End If
        End If
        formFlatQuerySql()
        PopulateTenants()
    End Sub


    Sub formFlatQuerySql()
        flatQuerySQL = "select * from tbltenants where 1=1 "
        If cboFlatCode.Text <> "" Then flatQuerySQL = flatQuerySQL & " and FlatCode like '" & cboFlatCode.Text & "%' "

        If chkOnlyActive.Checked = True Then
            flatQuerySQL = flatQuerySQL & " and (TenancyEndDate >=" & DateTime.Now.ToString(DB_DATEFORMAT) & ") "
        End If
        If chkOnlyExpiringInNDays.Checked = True Then
            flatQuerySQL = flatQuerySQL & " and (TenancyEndDate <=" & DateAdd(DateInterval.Day, CDbl(txtExpiringInDays.Text), DateTime.Now).ToString(DB_DATEFORMAT) & ") "
        End If
        flatQuerySQL = flatQuerySQL & " order by FlatCode"

        'flatQuerySQL = "select f.FlatCode,f.DuplexFlatCode,fo.* from tblflats f, tblflatowners fo "
        'flatQuerySQL = flatQuerySQL & " where fo.FlatCode=f.FlatCode and fo.IsActiveOwner='Y' "

        'If cboTower.Text <> "" Then
        '    flatQuerySQL = flatQuerySQL & " and f.FlatCode like '" & myLeft(cboTower.Text, 3) & "%'"
        'End If

        'If txtFlat.Text <> "" Then
        '    flatQuerySQL = flatQuerySQL & " and f.FlatCode like '%" & UCase(txtFlat.Text) & "%'"
        'End If

        'If cboDuplex.Text <> "ALL" Then
        '    If cboDuplex.Text = "YES" Then
        '        flatQuerySQL = flatQuerySQL & " and f.DuplexFlatCode is not null "
        '    Else
        '        flatQuerySQL = flatQuerySQL & " and f.DuplexFlatCode is null "
        '    End If
        'End If

        'If cboNoOfRooms.Text <> "ALL" Then
        '    flatQuerySQL = flatQuerySQL & " and f.NoOfRooms=" & cboNoOfRooms.Text
        'End If

        'If txtAddress.Text <> "" Then
        '    flatQuerySQL = flatQuerySQL & " and ((fo.FullPresentAddress like'%" & Replace(txtAddress.Text, "'", "''") & "%') OR (fo.FullCommunicationAddress like'%" & Replace(txtAddress.Text, "'", "''") & "%'))"
        'End If

        'If txtOwner.Text <> "" Then
        '    flatQuerySQL = flatQuerySQL & " and ((fo.OwnerFullName like'%" & Replace(txtOwner.Text, "'", "''") & "%') OR (fo.CoOwnerFullName like'%" & Replace(txtOwner.Text, "'", "''") & "%'))"
        'End If

        'If txtEmail.Text <> "" Then
        '    flatQuerySQL = flatQuerySQL & " and ((fo.PrimaryEmail like'%" & Replace(txtEmail.Text, "'", "''") & "%') OR (fo.email1 like'%" & Replace(txtEmail.Text, "'", "''") & "%') OR (fo.email2 like'%" & Replace(txtEmail.Text, "'", "''") & "%') OR (fo.p_email1 like'%" & Replace(txtEmail.Text, "'", "''") & "%') OR (fo.p_email2 like'%" & Replace(txtEmail.Text, "'", "''") & "%'))"
        'End If

        'If txtPhone.Text <> "" Then
        '    flatQuerySQL = flatQuerySQL & " and ((fo.PrimaryPhone like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.landline1 like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.landline2 like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.mobile1 like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.mobile2 like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.p_mobile1 like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.p_mobile2 like'%" & Replace(txtPhone.Text, "'", "''") & "%'))"
        'End If

        'If cboPortal.Text <> "ALL" Then
        '    If cboPortal.Text = "YES" Then
        '        flatQuerySQL = flatQuerySQL & " and fo.usingPortal is not null "
        '    Else
        '        flatQuerySQL = flatQuerySQL & " and fo.usingPortal is null "
        '    End If
        'End If

        'If cboSoftBill.Text <> "ALL" Then
        '    If cboSoftBill.Text = "YES" Then
        '        flatQuerySQL = flatQuerySQL & " and fo.p_softBill is not null "
        '    Else
        '        flatQuerySQL = flatQuerySQL & " and fo.p_softBill is null "
        '    End If
        'End If

        'flatQuerySQL = flatQuerySQL & " order by f.FlatCode ASC"


    End Sub


    Sub PopulateTenants()
        On Error GoTo errH
        Dim i As Long, rsFlat As ADODB.Recordset


        dgvTenants.Rows.Clear()
        rsFlat = gcon.Execute(flatQuerySQL)


        With dgvTenants

            While rsFlat.EOF = False

                i = .Rows.Add()
                .Rows(i).Cells("tblid").Value = rsFlat("tblid").Value.ToString
                .Rows(i).Cells("FlatCode").Value = rsFlat("FlatCode").Value.ToString
                .Rows(i).Cells("Gender").Value = rsFlat("Gender").Value.ToString
                .Rows(i).Cells("TenantName").Value = rsFlat("TenantName").Value.ToString

                If rsFlat("TenantType").Value.ToString = 1 Then
                    .Rows(i).Cells("TenantType").Value = "Individual"
                ElseIf rsFlat("TenantType").Value.ToString = 2 Then
                    .Rows(i).Cells("TenantType").Value = "Family (" & rsFlat("AdultCount").Value.ToString & "|" & rsFlat("ChildCount").Value.ToString & ")"
                ElseIf rsFlat("TenantType").Value.ToString = 3 Then
                    .Rows(i).Cells("TenantType").Value = "Company (" & rsFlat("AdultCount").Value.ToString & ")"
                End If

                .Rows(i).Cells("StartDate").Value = formatInt2Date(rsFlat("TenancyStartDate").Value.ToString)
                .Rows(i).Cells("EndDate").Value = formatInt2Date(rsFlat("TenancyEndDate").Value.ToString)
                .Rows(i).Cells("Email").Value = rsFlat("Email").Value.ToString
                .Rows(i).Cells("Phone").Value = rsFlat("Mobile").Value.ToString
                .Rows(i).Cells("Address").Value = rsFlat("FullPermanentAddress").Value.ToString

                If rsFlat("PhotoTaken").Value.ToString = "Y" Then .Rows(i).Cells("Photo").Value = True
                If rsFlat("TenancyAgreementSubmitted").Value.ToString = "Y" Then .Rows(i).Cells("TenancyAgreement").Value = True
                If rsFlat("PhotoIDProofSubmitted").Value.ToString = "Y" Then .Rows(i).Cells("IDProof").Value = True
                If rsFlat("PoliceFormSubmitted").Value.ToString = "Y" Then .Rows(i).Cells("PoliceForm").Value = True
                If rsFlat("ApplicationFormSubmitted").Value.ToString = "Y" Then .Rows(i).Cells("ApplicationForm").Value = True
                If rsFlat("FeePaid").Value.ToString = "Y" Then .Rows(i).Cells("FeePaid").Value = True

                .Rows(i).ReadOnly = True

                If rsFlat("TenancyEndDate").Value.ToString < DateTime.Now.ToString(DB_DATEFORMAT) Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gray
                Else
                    If (.Rows(i).Cells("FeePaid").Value = True) And (.Rows(i).Cells("Photo").Value = True) And (.Rows(i).Cells("TenancyAgreement").Value = True) And (.Rows(i).Cells("IDProof").Value = True) And (.Rows(i).Cells("ApplicationForm").Value = True) And (.Rows(i).Cells("PoliceForm").Value = True) Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    Else
                        .Rows(i).DefaultCellStyle.BackColor = Color.Red
                    End If
                End If
                rsFlat.MoveNext()

            End While
            frmMain.sslabel3.Text = (i + 1) & " Records"

        End With

        rsFlat.Close()

        lblCnt.Text = dgvTenants.Rows.Count

        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub


    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        resetForm()
    End Sub

    Private Sub dgvFlats_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTenants.CellContentDoubleClick
        On Error GoTo errH

        Dim ri As Integer, ci As Integer, tmpSql As String = ""


        ri = dgvTenants.CurrentCell.RowIndex
        ci = dgvTenants.CurrentCell.ColumnIndex
        gCurTblID = dgvTenants.Rows(ri).Cells(0).Value 'tblid

        If ci = 11 Then 'Tenancy Agreement
            ImageItemType = "TENANCY-APPLICATION"
            tmpSql = " ApplicationFormSubmitted='Y'"
        ElseIf ci = 12 Then 'Tenancy Agreement
            ImageItemType = "TENANCY-AGREEMENT"
            tmpSql = " TenancyAgreementSubmitted='Y'"
        ElseIf ci = 13 Then 'ID Proof
            ImageItemType = "TENANT-ID-PROOF"
            tmpSql = " PhotoIDProofSubmitted='Y'"
        ElseIf ci = 14 Then 'Employer Letter
            ImageItemType = "TENANT-POLICE-FORM"
            tmpSql = " PoliceFormSubmitted='Y'"
        Else
            gFormDataChanged = False
            frmAddEditTenant.ShowDialog()
            frmAddEditTenant.Dispose()
            If gFormDataChanged = True Then btnQuery.PerformClick()
            gFormDataChanged = False
            Exit Sub
        End If
        ImageItemNo = gCurTblID 'tblid   

        gFormTitle = ImageItemType
        gFormDataChanged = False
        frmSaveViewItemData.ShowDialog()
        frmSaveViewItemData.Dispose()

        If dgvTenants.Rows(ri).Cells(ci).Value = False And gFormDataChanged = True Then
            dgvTenants.Rows(ri).Cells(ci).Value = True

            ssql = "Update tbltenants set "
            ssql = ssql & tmpSql
            ssql = ssql & " where tblid=" & dgvTenants.Rows(ri).Cells(0).Value

            gcon.Execute(ssql)

        End If
        If gFormDataChanged = True Then btnQuery.PerformClick()
        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub


    Private Sub frmManageTenant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SetConnection()
        resetForm()
        cboFlatCode.Text = gCurFlatCode
        btnQuery.PerformClick()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        gCurTblID = ""
        frmAddEditTenant.ShowDialog()
        frmAddEditTenant.Dispose()
        btnQuery.PerformClick()
    End Sub

   
    Private Sub dgvTenants_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTenants.CellContentClick

    End Sub

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        ExportGridToExcelSheet(dgvTenants, False)
    End Sub

    Private Sub chkOnlyExpiringInNDays_CheckedChanged(sender As Object, e As EventArgs) Handles chkOnlyExpiringInNDays.CheckedChanged
        txtExpiringInDays.Enabled = chkOnlyExpiringInNDays.Checked
    End Sub
End Class