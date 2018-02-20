Public Class frmManageFlatAndOwnerDetails
    Dim tmpSum As Double
    Private Sub frmManageFlatAndOwnerDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tbarOutstandingFrom.Value = tbarOutstandingFrom.Minimum
        tbarOutstandingTo.Value = tbarOutstandingTo.Maximum
        loadAllTowers("")

        'btnFilter.Visible = False
        'tbarOutstandingFrom.Visible = False
        'tbarOutstandingTo.Visible = False
        'lblFrom.Visible = False
        'lblTo.Visible = False

        'Me.PerformAutoScale()
    End Sub

    Sub loadAllTowers(todate As String)
        Dim netSum As Double

        If todate <> "" Then
            gFlats.updateBalanceUptoThisDate(todate)
        Else
            gFlats.updateBalance()
        End If

        If chkCombineDuplexAmounts.Checked = True Then gFlats.combineDuplexAmounts()

        loadTower(dgvSAP, "SAP")
        lblSap.Text = addThousandSeparator(tmpSum, False)
        netSum = netSum + tmpSum

        loadTower(dgvSAN, "SAN")
        lblSan.Text = addThousandSeparator(tmpSum, False)
        netSum = netSum + tmpSum

        loadTower(dgvSHR, "SHR")
        lblShr.Text = addThousandSeparator(tmpSum, False)
        netSum = netSum + tmpSum

        loadTower(dgvSUK, "SUK")
        lblSuk.Text = addThousandSeparator(tmpSum, False)
        netSum = netSum + tmpSum

        lblNet.Text = addThousandSeparator(netSum, False)

    End Sub

    Sub loadTower(ByRef dgvControl As DataGridView, towerCode As String)
        On Error GoTo errH

        Dim tmpR As Integer, tmpC As Integer, curR As Integer, tmpFlatNo As String, tmpOutstanding As Double, tmpIndx As Integer, tmpDupIndx As Integer, tmpDupFlatCode As String, tmpDupOutstanding As Double
        Dim A2D() As String = {"A", "B", "C", "D"}

        tmpSum = 0

        With dgvControl
            .Rows.Clear()
            For tmpR = 17 To 1 Step -1
                curR = .Rows.Add()
                For tmpC = 0 To 3
                    tmpFlatNo = "0" & tmpR
                    If tmpR < 10 Then
                        tmpFlatNo = "0" & tmpR
                    Else
                        tmpFlatNo = tmpR
                    End If
                    gCurFlatCode = towerCode & tmpFlatNo & A2D(tmpC)

                    .Rows(curR).Cells(tmpC).Value = gCurFlatCode
                    tmpIndx = gFlats.getArrayIndex(gCurFlatCode)
                    'tmpDupFlatCode = gFlats.allFlats(tmpIndx).DuplexFlatCode

                    If optAssociation.Checked = True Then
                        tmpOutstanding = gFlats.allFlats(tmpIndx).AssocBalance
                    ElseIf optBoth.Checked = True Then
                        tmpOutstanding = gFlats.allFlats(tmpIndx).balance
                    ElseIf optBGF.Checked = True Then
                        tmpOutstanding = gFlats.allFlats(tmpIndx).BGFBalance
                    End If

                    'tmpDupOutstanding = 0


                    If gFlats.allFlats(tmpIndx).DuplexFlatCode <> "" Then 'This is a duplex flat

                        'If chkCombineDuplexAmounts.Checked = True Then

                        '    tmpDupIndx = gFlats.getArrayIndex(tmpDupFlatCode)

                        '    'If CInt(Mid(gCurFlatCode, 4, 2)) < CInt(Mid(tmpDupFlatCode, 4, 2)) Then
                        '    '    'show the entire outstanding against the lower duplex flat number
                        '    '    If optAssociation.Checked = True Then
                        '    '        tmpDupOutstanding = gFlats.allFlats(tmpDupIndx).AssocBalance
                        '    '    ElseIf optBoth.Checked = True Then
                        '    '        tmpDupOutstanding = gFlats.allFlats(tmpDupIndx).balance
                        '    '    ElseIf optBGF.Checked = True Then
                        '    '        tmpDupOutstanding = gFlats.allFlats(tmpDupIndx).BGFBalance
                        '    '    End If

                        '    '    tmpOutstanding = tmpOutstanding + tmpDupOutstanding
                        '    'Else
                        '    '    'show the outstanding as zero for higher duplex flat number as the entire amount has been shown against the lower duplex flat number
                        '    '    tmpOutstanding = 0
                        '    'End If

                        'End If

                        .Rows(curR).Cells(tmpC).Style.BackColor = Color.Yellow

                    End If

                    If Not ((tmpOutstanding >= tbarOutstandingFrom.Value) And (tmpOutstanding <= tbarOutstandingTo.Value)) Then
                        .Rows(curR).Cells(tmpC).Value = ""
                    Else
                        .Rows(curR).Cells(tmpC).Value = gCurFlatCode & vbCrLf & addThousandSeparator(tmpOutstanding, True)
                        tmpSum = tmpSum + CDbl(tmpOutstanding)
                    End If

                    Select Case tmpOutstanding
                        Case Is > 0
                            .Rows(curR).Cells(tmpC).Style.ForeColor = Color.Red
                        Case Else
                            .Rows(curR).Cells(tmpC).Style.ForeColor = Color.Green
                    End Select

                Next
            Next tmpR
        End With
        Exit Sub

errH:
        MsgBox(Err.Description)
        lblNet.Text = ""
    End Sub

    Private Sub dgvSAP_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSAP.CellMouseEnter
        On Error Resume Next
        dgvSAP.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
        gCurFlatCode = dgvSAP.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
        gCurTowerName = "SAPTARSHI"
        dgvSAN.ClearSelection()
        dgvSHR.ClearSelection()
        dgvSUK.ClearSelection()
    End Sub

    Private Sub dgvSAN_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSAN.CellMouseEnter
        On Error Resume Next
        dgvSAN.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
        gCurFlatCode = dgvSAN.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
        gCurTowerName = "SANDHYATARA"
        dgvSAP.ClearSelection()
        dgvSHR.ClearSelection()
        dgvSUK.ClearSelection()
    End Sub

    Private Sub dgvSHR_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSHR.CellMouseEnter
        On Error Resume Next
        dgvSHR.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
        gCurFlatCode = dgvSHR.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
        gCurTowerName = "SHROBONA"
        dgvSAP.ClearSelection()
        dgvSAN.ClearSelection()
        dgvSUK.ClearSelection()
    End Sub

    Private Sub dgvSUK_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSUK.CellMouseEnter
        On Error Resume Next
        dgvSUK.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
        gCurFlatCode = dgvSUK.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
        gCurTowerName = "SUKTARA"
        dgvSAP.ClearSelection()
        dgvSAN.ClearSelection()
        dgvSHR.ClearSelection()
    End Sub

    Sub ShowFlatTxnDetails()
        'standard entry check code start
        gItemCode = "frmBookReceipt"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = "frmBookReceipt"
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end
        gCurFlatCode = myLeft(gCurFlatCode, 6)
        frmBookReceipt.ShowDialog()
        frmBookReceipt.Dispose()
        gCurFlatCode = ""
    End Sub

    Private Sub dgvSAP_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSAP.CellContentClick
        ShowFlatTxnDetails()
    End Sub

    Private Sub dgvSAN_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSAN.CellContentClick
        ShowFlatTxnDetails()
    End Sub

    Private Sub dgvSHR_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSHR.CellContentClick
        ShowFlatTxnDetails()
    End Sub

    Private Sub dgvSUK_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSUK.CellContentClick
        ShowFlatTxnDetails()
    End Sub

    Private Sub tbarOutstandingFrom_ValueChanged(sender As Object, e As System.EventArgs) Handles tbarOutstandingFrom.ValueChanged
        lblFrom.Text = "From " & addThousandSeparator(tbarOutstandingFrom.Value, True)
    End Sub

    Private Sub tbarOutstandingTo_ValueChanged(sender As Object, e As System.EventArgs) Handles tbarOutstandingTo.ValueChanged
        lblTo.Text = "To " & addThousandSeparator(tbarOutstandingTo.Value, True)
    End Sub

    Private Sub btnFilter_Click(sender As System.Object, e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Enabled = False
        loadAllTowers("")
        btnFilter.Enabled = True
    End Sub

    Private Sub lblFrom_DoubleClick(sender As Object, e As System.EventArgs) Handles lblFrom.DoubleClick
        If tbarOutstandingFrom.Value = 0 Then
            tbarOutstandingFrom.Value = 1
        Else
            tbarOutstandingFrom.Value = 0
        End If
    End Sub

    Private Sub lblTo_DoubleClick(sender As Object, e As System.EventArgs) Handles lblTo.DoubleClick
        If tbarOutstandingTo.Value = 0 Then
            tbarOutstandingTo.Value = -1
        Else
            tbarOutstandingTo.Value = 0
        End If
    End Sub

    

    Private Sub btnFilterToADate_Click(sender As Object, e As EventArgs) Handles btnFilterToADate.Click
        dlgDtpDialog.ShowDialog()
        dlgDtpDialog.Dispose()
        If dtpDateSelected = "" Then Exit Sub

        btnFilterToADate.Enabled = False
        loadAllTowers(dtpDateSelected)
        btnFilterToADate.Enabled = True
    End Sub

End Class