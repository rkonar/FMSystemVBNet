Public Class frmSearchFlat

    Dim flatQuerySQL As String

    Sub resetForm()
        cboDuplex.Text = "ALL"
        cboNoOfRooms.Text = "ALL"
        cboPortal.Text = "ALL"
        cboSoftBill.Text = "ALL"
        txtAddress.Text = ""
        txtEmail.Text = ""
        txtFlat.Text = ""
        txtOwner.Text = ""
        txtPhone.Text = ""
        cboTower.DataSource = TOWERS
        'cboTower.Items.Add("")
        cboTower.Text = ""
        dgvFlats.Rows.Clear()
        frmMain.sslabel3.Text = ""
    End Sub

    Private Sub btnQuery_Click(sender As System.Object, e As System.EventArgs) Handles btnQuery.Click

        formFlatQuerySql()
        PopulateFlats()
    End Sub


    Sub formFlatQuerySql()

        txtEmail.Text = Trim(txtEmail.Text)


        flatQuerySQL = "select f.FlatCode,f.DuplexFlatCode,fo.* from tblflats f, tblflatowners fo "
        flatQuerySQL = flatQuerySQL & " where fo.FlatCode=f.FlatCode and fo.IsActiveOwner='Y' "

        If cboTower.Text <> "" Then
            flatQuerySQL = flatQuerySQL & " and f.FlatCode like '" & myLeft(cboTower.Text, 3) & "%'"
        End If

        If txtFlat.Text <> "" Then
            flatQuerySQL = flatQuerySQL & " and f.FlatCode like '%" & UCase(txtFlat.Text) & "%'"
        End If
        
        If cboDuplex.Text <> "ALL" Then
            If cboDuplex.Text = "YES" Then
                flatQuerySQL = flatQuerySQL & " and f.DuplexFlatCode is not null "
            Else
                flatQuerySQL = flatQuerySQL & " and f.DuplexFlatCode is null "
            End If
        End If

        If cboNoOfRooms.Text <> "ALL" Then
            flatQuerySQL = flatQuerySQL & " and f.NoOfRooms=" & cboNoOfRooms.Text
        End If

        If txtAddress.Text <> "" Then
            flatQuerySQL = flatQuerySQL & " and ((fo.FullPresentAddress like'%" & Replace(txtAddress.Text, "'", "''") & "%') OR (fo.FullCommunicationAddress like'%" & Replace(txtAddress.Text, "'", "''") & "%'))"
        End If

        If txtOwner.Text <> "" Then
            flatQuerySQL = flatQuerySQL & " and ((fo.OwnerFullName like'%" & Replace(txtOwner.Text, "'", "''") & "%') OR (fo.CoOwnerFullName like'%" & Replace(txtOwner.Text, "'", "''") & "%'))"
        End If

        If txtEmail.Text <> "" Then
            flatQuerySQL = flatQuerySQL & " and ((fo.PrimaryEmail like'%" & Replace(txtEmail.Text, "'", "''") & "%') OR (fo.email1 like'%" & Replace(txtEmail.Text, "'", "''") & "%') OR (fo.email2 like'%" & Replace(txtEmail.Text, "'", "''") & "%') OR (fo.p_email1 like'%" & Replace(txtEmail.Text, "'", "''") & "%') OR (fo.p_email2 like'%" & Replace(txtEmail.Text, "'", "''") & "%'))"
        End If

        If txtPhone.Text <> "" Then
            flatQuerySQL = flatQuerySQL & " and ((fo.PrimaryPhone like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.landline1 like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.landline2 like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.mobile1 like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.mobile2 like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.p_mobile1 like'%" & Replace(txtPhone.Text, "'", "''") & "%') OR (fo.p_mobile2 like'%" & Replace(txtPhone.Text, "'", "''") & "%'))"
        End If

        If cboPortal.Text <> "ALL" Then
            If cboPortal.Text = "YES" Then
                flatQuerySQL = flatQuerySQL & " and fo.usingPortal is not null "
            Else
                flatQuerySQL = flatQuerySQL & " and fo.usingPortal is null "
            End If
        End If

        If cboSoftBill.Text <> "ALL" Then
            If cboSoftBill.Text = "YES" Then
                flatQuerySQL = flatQuerySQL & " and fo.p_softBill is not null "
            Else
                flatQuerySQL = flatQuerySQL & " and fo.p_softBill is null "
            End If
        End If

        flatQuerySQL = flatQuerySQL & " order by f.FlatCode ASC"


    End Sub


    Sub PopulateFlats()
        On Error GoTo errH
        Dim i As Long, rsFlat As ADODB.Recordset


        dgvFlats.Rows.Clear()
        rsFlat = gcon.Execute(flatQuerySQL)


        With dgvFlats

            While rsFlat.EOF = False

                i = .Rows.Add()
                .Rows(i).Cells("FlatCode").Value = rsFlat("FlatCode").Value.ToString
                .Rows(i).Cells("Duplex").Value = rsFlat("DuplexFlatCode").Value.ToString
                .Rows(i).Cells("FlatOwner").Value = rsFlat("OwnerFullName").Value.ToString & " " & rsFlat("CoOwnerFullName").Value.ToString
                .Rows(i).Cells("Email").Value = rsFlat("PrimaryEmail").Value.ToString
                .Rows(i).Cells("Phone").Value = rsFlat("PrimaryPhone").Value.ToString
                .Rows(i).Cells("Address").Value = rsFlat("FullPresentAddress").Value.ToString

                If rsFlat("usingPortal").Value.ToString = "Y" Then .Rows(i).Cells("Portal").Value = True
                If rsFlat("p_softBill").Value.ToString = "Y" Then .Rows(i).Cells("SoftBill").Value = True

                .Rows(i).ReadOnly = True

                rsFlat.MoveNext()

            End While
            frmMain.sslabel3.Text = (i + 1) & " Records"
           
        End With

        rsFlat.Close()

        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub

    Private Sub frmSearchFlat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SetConnection()
        resetForm()

    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        resetForm()
    End Sub

    Private Sub dgvFlats_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFlats.CellContentDoubleClick
        gCurFlatCode = dgvFlats.Rows(dgvFlats.CurrentRow.Index).Cells(0).Value
        'standard entry check code start
        gOldItemCode = gItemCode
        gItemCode = "frmManageFlats"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = gOldItemCode
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end
        frmManageFlats.ShowDialog()
        frmManageFlats.Dispose()
        gItemCode = gOldItemCode
    End Sub
End Class