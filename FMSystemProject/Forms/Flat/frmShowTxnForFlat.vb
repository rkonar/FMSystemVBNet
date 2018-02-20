Public Class frmShowTxnForFlat
    Dim NetLineStyle As New DataGridViewCellStyle, NetDrAmt As Double, NetCrAmt As Double, NetBGF As Double
    Private Sub frmBookReceipt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Text & " - " & gCurFlatCode
        cboFlatCode.Text = gCurFlatCode
        fetchFlatOwner()
        fetchDuplexFlat()
        PopulateJournalBilled()
        PopulateJournalPaid()
        lblBalance.Text = "Asc. Outstanding:" & addThousandSeparator((NetDrAmt - NetCrAmt), True)
        lblDiff.Text = "BGF Outstanding:" & addThousandSeparator(NetBGF, True)

        'If gLoginID <> "sa" Then
        '    lblBalance.Visible = False
        'End If
    End Sub
    Sub fetchDuplexFlat()
        tmpRS = gcon.Execute("select DuplexFlatCode from tblflats where FlatCode='" & cboFlatCode.Text & "'")
        If tmpRS.EOF = False Then
            txtDuplexFlatCode.Text = tmpRS("DuplexFlatCode").Value.ToString
        Else
            txtDuplexFlatCode.Text = ""
        End If
        tmpRS.Close()
    End Sub

    Sub PopulateJournalBilled()
        On Error GoTo errH
        Dim i As Long, netAmt As Double

        NetBGF = 0
        NetDrAmt = 0
        dgvJournalBilled.Rows.Clear()

        '1:if duplex, print selected flat code
        'If txtDuplexFlatCode.Text <> "" Then
        '    i = dgvJournalBilled.Rows.Add()
        '    dgvJournalBilled.Rows(i).Cells("Narration").Value = cboFlatCode.Text '& " - BGF"
        '    dgvJournalBilled.Rows(i).ReadOnly = True
        '    dgvJournalBilled.Rows(i).DefaultCellStyle.BackColor = Color.Brown
        'End If

        '2:===========Print BGF Bills for selected flat code==================
        'ssql = "select * from tbljournal where Status is null and DrAmount = 0 and AccountNo='CORPUS-FUND-" & cboFlatCode.Text & "'  order by TxnDate"
        ssql = "select * from tbljournal where Status is null and AccountNo='CORPUS-FUND-" & cboFlatCode.Text & "' order by TxnDate"
        rsJournalBilled = gcon.Execute(ssql)

        With dgvJournalBilled
            While rsJournalBilled.EOF = False
                i = .Rows.Add()
                .Rows(i).Cells("TxnType").Value = rsJournalBilled("TxnType").Value.ToString
                .Rows(i).Cells("JournalID").Value = rsJournalBilled("tblid").Value.ToString
                .Rows(i).Cells("TxnDate").Value = formatInt2Date(rsJournalBilled("TxnDate").Value.ToString)
                .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("CrAmount").Value.ToString - rsJournalBilled("DrAmount").Value.ToString
                .Rows(i).Cells("Narration").Value = rsJournalBilled("Narration").Value.ToString & " " & rsJournalBilled("DocRef").Value.ToString
                NetDrAmt = NetDrAmt + rsJournalBilled("CrAmount").Value.ToString - rsJournalBilled("DrAmount").Value.ToString
                NetBGF = NetBGF + rsJournalBilled("CrAmount").Value.ToString - rsJournalBilled("DrAmount").Value.ToString
                .Rows(i).ReadOnly = True
                .Rows(i).DefaultCellStyle.BackColor = Color.Cyan

                rsJournalBilled.MoveNext()
            End While
        End With
        rsJournalBilled.Close()

        '3:if duplex, print duplex flat code
        If txtDuplexFlatCode.Text <> "" Then
            'i = dgvJournalBilled.Rows.Add()
            'dgvJournalBilled.Rows(i).Cells("Narration").Value = txtDuplexFlatCode.Text '& " - BGF"
            'dgvJournalBilled.Rows(i).ReadOnly = True
            'dgvJournalBilled.Rows(i).DefaultCellStyle.BackColor = Color.Brown


            '4:===========Print BGF Bills for duplex flat code==================
            ssql = "select * from tbljournal where Status is null and AccountNo='CORPUS-FUND-" & txtDuplexFlatCode.Text & "' order by TxnDate"
            rsJournalBilled = gcon.Execute(ssql)

            With dgvJournalBilled
                While rsJournalBilled.EOF = False
                    i = .Rows.Add()
                    .Rows(i).Cells("JournalID").Value = rsJournalBilled("tblid").Value.ToString
                    .Rows(i).Cells("TxnType").Value = rsJournalBilled("TxnType").Value.ToString
                    .Rows(i).Cells("TxnDate").Value = formatInt2Date(rsJournalBilled("TxnDate").Value.ToString)
                    .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("CrAmount").Value.ToString
                    .Rows(i).Cells("Narration").Value = rsJournalBilled("Narration").Value.ToString & " " & rsJournalBilled("DocRef").Value.ToString
                    NetDrAmt = NetDrAmt + rsJournalBilled("CrAmount").Value.ToString
                    NetBGF = NetBGF + rsJournalBilled("CrAmount").Value.ToString
                    .Rows(i).ReadOnly = True
                    .Rows(i).DefaultCellStyle.BackColor = Color.Cyan

                    rsJournalBilled.MoveNext()
                End While
            End With
            rsJournalBilled.Close()
        End If


        '5:if duplex, print selected flat code
        If txtDuplexFlatCode.Text <> "" Then
            i = dgvJournalBilled.Rows.Add()
            dgvJournalBilled.Rows(i).Cells("Narration").Value = cboFlatCode.Text '& " - HIG Association"
            dgvJournalBilled.Rows(i).ReadOnly = True
            dgvJournalBilled.Rows(i).DefaultCellStyle.BackColor = Color.Brown
        End If


        '6:===========Print HIG Association Bills for selected flat code==================
        ssql = "select * from tbljournal where Status is null and DrAmount = 0 and (AccountNo='REV-MAINT-FLAT-" & cboFlatCode.Text & "' OR AccountNo='REV-MAINT-OTHER-CHARGES-" & cboFlatCode.Text & "')  order by TxnDate"
        rsJournalBilled = gcon.Execute(ssql)

        With dgvJournalBilled
            While rsJournalBilled.EOF = False
                i = .Rows.Add()
                .Rows(i).Cells("JournalID").Value = rsJournalBilled("tblid").Value.ToString
                .Rows(i).Cells("TxnType").Value = rsJournalBilled("TxnType").Value.ToString
                .Rows(i).Cells("TxnDate").Value = formatInt2Date(rsJournalBilled("TxnDate").Value.ToString)
                .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("CrAmount").Value.ToString
                .Rows(i).Cells("Narration").Value = rsJournalBilled("Narration").Value.ToString & " " & rsJournalBilled("DocRef").Value.ToString
                NetDrAmt = NetDrAmt + rsJournalBilled("CrAmount").Value.ToString
                .Rows(i).ReadOnly = True
                rsJournalBilled.MoveNext()
            End While
            rsJournalBilled.Close()
        End With

        '7:if duplex, print duplex flat code
        If txtDuplexFlatCode.Text <> "" Then
            i = dgvJournalBilled.Rows.Add()
            dgvJournalBilled.Rows(i).Cells("Narration").Value = txtDuplexFlatCode.Text '& " - HIG Association"
            dgvJournalBilled.Rows(i).ReadOnly = True
            dgvJournalBilled.Rows(i).DefaultCellStyle.BackColor = Color.Brown


            '8:===========Print HIG Association Bills for duplex flat code==================
            ssql = "select * from tbljournal where Status is null and DrAmount = 0 and (AccountNo='REV-MAINT-FLAT-" & txtDuplexFlatCode.Text & "' OR AccountNo='REV-MAINT-OTHER-CHARGES-" & txtDuplexFlatCode.Text & "')  order by TxnDate"
            rsJournalBilled = gcon.Execute(ssql)

            With dgvJournalBilled
                While rsJournalBilled.EOF = False
                    i = .Rows.Add()
                    .Rows(i).Cells("JournalID").Value = rsJournalBilled("tblid").Value.ToString
                    .Rows(i).Cells("TxnType").Value = rsJournalBilled("TxnType").Value.ToString
                    .Rows(i).Cells("TxnDate").Value = formatInt2Date(rsJournalBilled("TxnDate").Value.ToString)
                    .Rows(i).Cells("TxnAmt").Value = rsJournalBilled("CrAmount").Value.ToString
                    .Rows(i).Cells("Narration").Value = rsJournalBilled("Narration").Value.ToString & " " & rsJournalBilled("DocRef").Value.ToString
                    NetDrAmt = NetDrAmt + rsJournalBilled("CrAmount").Value.ToString
                    .Rows(i).ReadOnly = True
                    rsJournalBilled.MoveNext()
                End While
                rsJournalBilled.Close()
            End With
        End If

        '9:Print final total line
        With dgvJournalBilled
            i = .Rows.Add()
            .Rows(i).Cells("Narration").Value = "Total (Rs.)"
            .Rows(i).Cells("TxnAmt").Value = addThousandSeparator(NetDrAmt)

            .Rows(i).ReadOnly = True
            NetLineStyle.Font = New Font(DataGridView.DefaultFont, FontStyle.Bold)
            .Rows(i).DefaultCellStyle = NetLineStyle
            .Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Rows(i).DefaultCellStyle.ForeColor = Color.Blue

            .Rows(0).Cells("TxnDate").Selected = False
            .Rows(i).Cells("TxnAmt").Selected = True
        End With

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Sub PopulateJournalPaid()
        On Error GoTo errH
        Dim i As Long, netAmt As Double, myReceipt As New clsReceipt, myDocRef As New clsDocRef

        NetCrAmt = 0
        dgvJournalPaid.Rows.Clear()


        '1:if duplex, print selected flat code
        'If txtDuplexFlatCode.Text <> "" Then
        '    i = dgvJournalPaid.Rows.Add()
        '    dgvJournalPaid.Rows(i).Cells("NarrationPaid").Value = cboFlatCode.Text '& " - BGF"
        '    dgvJournalPaid.Rows(i).ReadOnly = True
        '    dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Brown
        'End If

        '2:===========Print BGF payments for selected flat code==================
        ssql = "select * from tbljournal where DrAmount = 0 and AccountNo='DEBTOR-CORPUS-FUND-" & cboFlatCode.Text & "' order by TxnDate"
        rsJournalPaid = gcon.Execute(ssql)

        With dgvJournalPaid
            While rsJournalPaid.EOF = False
                i = .Rows.Add()
                .Rows(i).Cells("JournalIDPaid").Value = rsJournalPaid("tblid").Value.ToString
                .Rows(i).Cells("TxnTypePaid").Value = rsJournalPaid("TxnType").Value.ToString
                .Rows(i).Cells("TxnDatePaid").Value = formatInt2Date(rsJournalPaid("TxnDate").Value.ToString)
                .Rows(i).Cells("NarrationPaid").Value = rsJournalPaid("Narration").Value.ToString & " " & rsJournalPaid("DocRef").Value.ToString
                If rsJournalPaid("Status").Value.ToString = "" Then
                    .Rows(i).Cells("TxnAmtPaid").Value = rsJournalPaid("CrAmount").Value.ToString
                    NetCrAmt = NetCrAmt + rsJournalPaid("CrAmount").Value.ToString
                    NetBGF = NetBGF - rsJournalPaid("CrAmount").Value.ToString
                Else
                    .Rows(i).Cells("TxnAmtPaid").Value = 0
                End If
                .Rows(i).ReadOnly = True
                .Rows(i).DefaultCellStyle.BackColor = Color.Cyan

                'if not reconciled with bank, then set forecolor to red, else green.
                myReceipt.loadSingleReceipt("", myDocRef.getReceiptNo(rsJournalPaid("DocRef").Value.ToString), "")
                If myReceipt.Status = False Then Exit Sub
                If (myReceipt.InstrumentType = "CHEQUE" Or myReceipt.InstrumentType = "ONLINE") Then
                    If rsJournalPaid("refgid").Value.ToString = "" Then
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    Else
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                    End If
                Else
                    .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
                rsJournalPaid.MoveNext()
            End While
        End With
        rsJournalPaid.Close()

        '3:if duplex, print duplex flat code
        If txtDuplexFlatCode.Text <> "" Then
            'i = dgvJournalPaid.Rows.Add()
            'dgvJournalPaid.Rows(i).Cells("NarrationPaid").Value = txtDuplexFlatCode.Text '& " - BGF"
            'dgvJournalPaid.Rows(i).ReadOnly = True
            'dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Brown


            '4:===========Print BGF payments for duplex flat code==================
            ssql = "select * from tbljournal where DrAmount = 0 and AccountNo='DEBTOR-CORPUS-FUND-" & txtDuplexFlatCode.Text & "' order by TxnDate"
            rsJournalPaid = gcon.Execute(ssql)

            With dgvJournalPaid
                While rsJournalPaid.EOF = False
                    i = .Rows.Add()
                    .Rows(i).Cells("JournalIDPaid").Value = rsJournalPaid("tblid").Value.ToString
                    .Rows(i).Cells("TxnTypePaid").Value = rsJournalPaid("TxnType").Value.ToString
                    .Rows(i).Cells("TxnDatePaid").Value = formatInt2Date(rsJournalPaid("TxnDate").Value.ToString)
                    .Rows(i).Cells("NarrationPaid").Value = rsJournalPaid("Narration").Value.ToString & " " & rsJournalPaid("DocRef").Value.ToString
                    If rsJournalPaid("Status").Value.ToString = "" Then
                        .Rows(i).Cells("TxnAmtPaid").Value = rsJournalPaid("CrAmount").Value.ToString
                        NetCrAmt = NetCrAmt + rsJournalPaid("CrAmount").Value.ToString
                        NetBGF = NetBGF - rsJournalPaid("CrAmount").Value.ToString
                    Else
                        .Rows(i).Cells("TxnAmtPaid").Value = 0
                    End If
                    .Rows(i).ReadOnly = True
                    .Rows(i).DefaultCellStyle.BackColor = Color.Cyan
                    'if not reconciled with bank, then set forecolor to red, else green.
                    myReceipt.loadSingleReceipt("", myDocRef.getReceiptNo(rsJournalPaid("DocRef").Value.ToString), "")
                    If myReceipt.Status = False Then Exit Sub
                    If (myReceipt.InstrumentType = "CHEQUE" Or myReceipt.InstrumentType = "ONLINE") Then
                        If rsJournalPaid("refgid").Value.ToString = "" Then
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                        Else
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                        End If
                    Else
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    End If

                    rsJournalPaid.MoveNext()
                End While
            End With
            rsJournalPaid.Close()

        End If

        '5:if duplex, print selected flat code
        If txtDuplexFlatCode.Text <> "" Then
            i = dgvJournalPaid.Rows.Add()
            dgvJournalPaid.Rows(i).Cells("NarrationPaid").Value = cboFlatCode.Text '& " - HIG Association"
            dgvJournalPaid.Rows(i).ReadOnly = True
            dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Brown
        End If


        '6:===========Print HIG Association payments for selected flat code==================
        ssql = "select * from tbljournal where DrAmount = 0 and AccountNo='DEBTOR-FLAT-" & cboFlatCode.Text & "' order by TxnDate"
        rsJournalPaid = gcon.Execute(ssql)
        With dgvJournalPaid
            While rsJournalPaid.EOF = False
                i = .Rows.Add()
                .Rows(i).Cells("JournalIDPaid").Value = rsJournalPaid("tblid").Value.ToString
                .Rows(i).Cells("TxnTypePaid").Value = rsJournalPaid("TxnType").Value.ToString
                .Rows(i).Cells("TxnDatePaid").Value = formatInt2Date(rsJournalPaid("TxnDate").Value.ToString)
                .Rows(i).Cells("NarrationPaid").Value = rsJournalPaid("Narration").Value.ToString & " " & rsJournalPaid("DocRef").Value.ToString
                If rsJournalPaid("Status").Value.ToString = "" Then
                    .Rows(i).Cells("TxnAmtPaid").Value = rsJournalPaid("CrAmount").Value.ToString
                    NetCrAmt = NetCrAmt + rsJournalPaid("CrAmount").Value.ToString
                Else
                    .Rows(i).Cells("TxnAmtPaid").Value = 0
                End If
                .Rows(i).ReadOnly = True
                'if not reconciled with bank, then set forecolor to red, else green.
                myReceipt.loadSingleReceipt("", myDocRef.getReceiptNo(rsJournalPaid("DocRef").Value.ToString), "")
                If myReceipt.Status = False Then Exit Sub
                If (myReceipt.InstrumentType = "CHEQUE" Or myReceipt.InstrumentType = "ONLINE") Then
                    If rsJournalPaid("refgid").Value.ToString = "" Then
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    Else
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                    End If
                Else
                    .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
                rsJournalPaid.MoveNext()
            End While
        End With

        '7:if duplex, print duplex flat code
        If txtDuplexFlatCode.Text <> "" Then
            i = dgvJournalPaid.Rows.Add()
            dgvJournalPaid.Rows(i).Cells("NarrationPaid").Value = txtDuplexFlatCode.Text '& " - HIG Association"
            dgvJournalPaid.Rows(i).ReadOnly = True
            dgvJournalPaid.Rows(i).DefaultCellStyle.BackColor = Color.Brown


            '8:===========Print HIG Association payments for duplex flat code==================
            ssql = "select * from tbljournal where DrAmount = 0 and AccountNo='DEBTOR-FLAT-" & txtDuplexFlatCode.Text & "' order by TxnDate"
            rsJournalPaid = gcon.Execute(ssql)
            With dgvJournalPaid
                While rsJournalPaid.EOF = False
                    i = .Rows.Add()
                    .Rows(i).Cells("JournalIDPaid").Value = rsJournalPaid("tblid").Value.ToString
                    .Rows(i).Cells("TxnTypePaid").Value = rsJournalPaid("TxnType").Value.ToString
                    .Rows(i).Cells("TxnDatePaid").Value = formatInt2Date(rsJournalPaid("TxnDate").Value.ToString)
                    .Rows(i).Cells("NarrationPaid").Value = rsJournalPaid("Narration").Value.ToString & " " & rsJournalPaid("DocRef").Value.ToString
                    If rsJournalPaid("Status").Value.ToString = "" Then
                        .Rows(i).Cells("TxnAmtPaid").Value = rsJournalPaid("CrAmount").Value.ToString
                        NetCrAmt = NetCrAmt + rsJournalPaid("CrAmount").Value.ToString
                    Else
                        .Rows(i).Cells("TxnAmtPaid").Value = 0
                    End If
                    .Rows(i).ReadOnly = True
                    'if not reconciled with bank, then set forecolor to red, else green.
                    myReceipt.loadSingleReceipt("", myDocRef.getReceiptNo(rsJournalPaid("DocRef").Value.ToString), "")
                    If myReceipt.Status = False Then Exit Sub
                    If (myReceipt.InstrumentType = "CHEQUE" Or myReceipt.InstrumentType = "ONLINE") Then
                        If rsJournalPaid("refgid").Value.ToString = "" Then
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                        Else
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Green
                        End If
                    Else
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    End If
                    rsJournalPaid.MoveNext()
                End While
            End With
        End If

        '9:Print final total line
        With dgvJournalPaid
            i = .Rows.Add()
            .Rows(i).Cells("NarrationPaid").Value = "Total (Rs.)"
            .Rows(i).Cells("TxnAmtPaid").Value = addThousandSeparator(NetCrAmt)

            .Rows(i).ReadOnly = True
            NetLineStyle.Font = New Font(DataGridView.DefaultFont, FontStyle.Bold)
            .Rows(i).DefaultCellStyle = NetLineStyle
            .Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Rows(i).DefaultCellStyle.ForeColor = Color.Blue

            .Rows(0).Cells("TxnDatePaid").Selected = False
            .Rows(i).Cells("TxnAmtPaid").Selected = True

        End With

        rsJournalPaid.Close()

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub fetchFlatOwner()
        tmpRS = gcon.Execute("select * from tblflatowners where FlatCode='" & gCurFlatCode & "' and IsActiveOwner='Y'")
        If tmpRS.EOF = False Then
            lblOwnerDetails.Text = tmpRS("OwnerFullName").Value.ToString & Chr(10) & tmpRS("CoOwnerFullName").Value.ToString
        Else
            lblOwnerDetails.Text = ""
        End If
        tmpRS.Close()
    End Sub

    Private Sub btnEditFlatOwnerDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnEditFlatOwnerDetails.Click
        'standard entry check code start
        gItemCode = "frmManageFlats"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = "frmManageFlatAndOwnerDetails"
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end
        frmManageFlats.ShowDialog()
        frmManageFlats.Dispose()
    End Sub



    Private Sub dgvJournalBilled_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJournalBilled.CellContentDoubleClick
        Dim pos1 As Integer, pos2 As Integer, thisNarration As String

        'If dgvJournalBilled.CurrentRow.Index = Nothing Then Exit Sub
        If dgvJournalBilled.CurrentCell.ColumnIndex <> 3 Then Exit Sub

        thisNarration = dgvJournalBilled.Rows(dgvJournalBilled.CurrentRow.Index).Cells(dgvJournalBilled.CurrentCell.ColumnIndex).Value
        pos1 = InStr(1, thisNarration, "Bill No:")
        If pos1 = 0 Then Exit Sub
        pos2 = InStr(pos1 + 8 + 1, thisNarration, ",")
        gCurBillNo = Trim(Mid(thisNarration, pos1 + 8, pos2 - pos1 - 8))
        frmShowBill.ShowDialog()
        frmShowBill.Dispose()
    End Sub



    Private Sub dgvJournalPaid_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJournalPaid.CellContentDoubleClick
        Dim pos1 As Integer, pos2 As Integer, thisNarration As String

        'If dgvJournalPaid.CurrentRow.Index = Nothing Then Exit Sub
        If dgvJournalPaid.CurrentCell.ColumnIndex <> 3 Then Exit Sub

        thisNarration = dgvJournalPaid.Rows(dgvJournalPaid.CurrentRow.Index).Cells(dgvJournalPaid.CurrentCell.ColumnIndex).Value
        pos1 = InStr(1, thisNarration, "Receipt No:")
        If pos1 = 0 Then Exit Sub
        pos2 = InStr(pos1 + 11 + 1, thisNarration, ",")
        gCurReceiptNo = Trim(Mid(thisNarration, pos1 + 11, pos2 - pos1 - 11))
        gItemCode = "frmViewReceipt"
        frmViewReceipt.ShowDialog()
        frmViewReceipt.Dispose()
        gItemCode = "frmBookReceipt"
    End Sub




End Class