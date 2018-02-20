Public Class frmManageServiceCase
    Dim tmpSum As Double
    Function getOpenCaseCount(tmpFlatCode) As String
        Dim tmpRS As ADODB.Recordset
        tmpRS = gcon.Execute("select count(*) as cnt from tblservicerequest where FlatCode='" & tmpFlatCode & "' and Status<>'CLOSED'")
        getOpenCaseCount = tmpRS("cnt").Value.ToString
        tmpRS.Close()

    End Function


    Sub loadAllTowers(todate As String)

        loadTower(dgvSAP, "SAP")
        loadTower(dgvSAN, "SAN")
        loadTower(dgvSHR, "SHR")
        loadTower(dgvSUK, "SUK")

        ShowCaseStatForFMOffice()
        
    End Sub
    Function D2A(abcd As String) As Integer
        D2A = -1
        If abcd = "A" Then D2A = 0
        If abcd = "B" Then D2A = 1
        If abcd = "C" Then D2A = 2
        If abcd = "D" Then D2A = 3
    End Function

    Sub loadTower(ByRef dgvControl As DataGridView, towerCode As String)
        On Error GoTo errH

        Dim tmpR As Integer, tmpC As Integer, curR As Integer, tmpFlatNo As String = "", tmpPrevFlatNo As String = "", tmpIndx As Integer, tmpDupIndx As Integer, tmpDupFlatCode As String
        Dim A2D() As String = {"A", "B", "C", "D"}
        Dim tmpCnt As String, hvOpen As Boolean = False

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
                    'tmpCnt = getOpenCaseCount(gCurFlatCode)

                    'If tmpCnt <> "" And tmpCnt <> 0 Then
                    '    .Rows(curR).Cells(tmpC).Style.BackColor = Color.Red
                    'End If

                    If gFlats.allFlats(tmpIndx).DuplexFlatCode <> "" Then 'This is a duplex flat
                        .Rows(curR).Cells(tmpC).Style.ForeColor = Color.Blue
                    End If
                Next
            Next tmpR

            'populate flat wise stats
            Dim tmpRS As ADODB.Recordset, tmpStatusStr As String = "", thisStatus As String, thisCnt As String
            tmpRS = gcon.Execute("select count(*) as cnt, Status,FlatCode from tblservicerequest where FlatCode like '" & towerCode & "%' group by FlatCode, Status having cnt>0")

            If tmpRS.EOF = False Then
                tmpPrevFlatNo = tmpRS("FlatCode").Value.ToString
                While tmpRS.EOF = False
                    tmpFlatNo = tmpRS("FlatCode").Value.ToString
                    thisStatus = myLeft(tmpRS("Status").Value.ToString, 1)
                    thisCnt = tmpRS("cnt").Value.ToString
                    curR = 17 - Mid(tmpPrevFlatNo, 4, 2)
                    tmpC = D2A(myRight(tmpPrevFlatNo, 1))

                    If tmpFlatNo = tmpPrevFlatNo Then
                        tmpStatusStr = tmpStatusStr & vbCr & thisStatus & ":" & thisCnt
                        If thisStatus <> "C" And thisStatus <> "T" Then hvOpen = True
                    Else
                        .Rows(curR).Cells(tmpC).Value = .Rows(curR).Cells(tmpC).Value & tmpStatusStr

                        If hvOpen = True Then .Rows(curR).Cells(tmpC).Style.BackColor = Color.Red
                        hvOpen = False

                        tmpStatusStr = vbCrLf & thisStatus & ":" & thisCnt
                        If thisStatus <> "C" And thisStatus <> "T" Then hvOpen = True
                    End If

                    tmpPrevFlatNo = tmpFlatNo
                    tmpRS.MoveNext()
                End While
            End If
            tmpRS.Close()

            If tmpStatusStr <> "" Then
                'print last flat
                curR = 17 - Mid(tmpFlatNo, 4, 2)
                tmpC = D2A(myRight(tmpFlatNo, 1))
                .Rows(curR).Cells(tmpC).Value = .Rows(curR).Cells(tmpC).Value & tmpStatusStr
                If hvOpen = True Then .Rows(curR).Cells(tmpC).Style.BackColor = Color.Red
            End If


        End With
        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub

    Sub ShowCaseStatForFMOffice()
        'Dim tmpR As Integer, tmpC As Integer, curR As Integer, tmpFlatNo As String = "", tmpPrevFlatNo As String = "", tmpIndx As Integer, tmpDupIndx As Integer, tmpDupFlatCode As String
        'Dim A2D() As String = {"A", "B", "C", "D"}
        Dim hvOpen As Boolean = False

        'populate flat wise stats
        Dim tmpRS As ADODB.Recordset, tmpStatusStr As String = "", thisStatus As String, thisCnt As String
        tmpRS = gcon.Execute("select count(*) as cnt, Status from tblservicerequest where FlatCode = 'FMOffice' group by Status having cnt>0")

        If tmpRS.EOF = False Then
            'tmpPrevFlatNo = tmpRS("FlatCode").Value.ToString
            While tmpRS.EOF = False
                'tmpFlatNo = tmpRS("FlatCode").Value.ToString
                thisStatus = myLeft(tmpRS("Status").Value.ToString, 1)
                thisCnt = tmpRS("cnt").Value.ToString
                'curR = 17 - Mid(tmpPrevFlatNo, 4, 2)
                'tmpC = D2A(myRight(tmpPrevFlatNo, 1))

                'If tmpFlatNo = tmpPrevFlatNo Then
                tmpStatusStr = tmpStatusStr & vbCr & thisStatus & ":" & thisCnt
                If thisStatus <> "C" And thisStatus <> "T" Then hvOpen = True
                'Else
                '.Rows(curR).Cells(tmpC).Value = .Rows(curR).Cells(tmpC).Value & tmpStatusStr

                'If hvOpen = True Then .Rows(curR).Cells(tmpC).Style.BackColor = Color.Red
                'hvOpen = False

                'tmpStatusStr = vbCrLf & thisStatus & ":" & thisCnt
                'If thisStatus <> "C" And thisStatus <> "T" Then hvOpen = True
                'End If

                'tmpPrevFlatNo = tmpFlatNo
                tmpRS.MoveNext()
            End While
        End If
        tmpRS.Close()

        If tmpStatusStr <> "" Then
            'print last flat
            'curR = 17 - Mid(tmpFlatNo, 4, 2)
            'tmpC = D2A(myRight(tmpFlatNo, 1))
            btnFMOffice.Text = btnFMOffice.Text & tmpStatusStr
            If hvOpen = True Then btnFMOffice.BackColor = Color.Red
        End If
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

    Sub ShowFlatCaseDetails()
        Dim thisFlatCode As String


        'standard entry check code start

        gItemCode = "frmAddEditServiceCase"
        'standard entry check code end
        gCurFlatCode = myLeft(gCurFlatCode, 6)
        thisFlatCode = gCurFlatCode
        frmAddEditServiceCase.ShowDialog()
        frmAddEditServiceCase.Dispose()
        gItemCode = "frmManageServiceCase"
        gCurFlatCode = thisFlatCode
        loadAllTowers("")
    End Sub

    Private Sub dgvSAP_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSAP.CellContentClick
        ShowFlatCaseDetails()
    End Sub

    Private Sub dgvSAN_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSAN.CellContentClick
        ShowFlatCaseDetails()
    End Sub

    Private Sub dgvSHR_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSHR.CellContentClick
        ShowFlatCaseDetails()
    End Sub

    Private Sub dgvSUK_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSUK.CellContentClick
        ShowFlatCaseDetails()
    End Sub

    Private Sub frmManageServiceCase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadAllTowers("")

    End Sub

    Private Sub btnFMOffice_Click(sender As Object, e As EventArgs) Handles btnFMOffice.Click
        Dim thisFlatCode As String
        'standard entry check code start

        gItemCode = "frmAddEditServiceCase"
        'standard entry check code end
        thisFlatCode = gCurFlatCode
        gCurFlatCode = "FMOFFC"
        frmAddEditServiceCase.ShowDialog()
        frmAddEditServiceCase.Dispose()
        gItemCode = "frmManageServiceCase"
        gCurFlatCode = thisFlatCode

        ShowCaseStatForFMOffice()
    End Sub
End Class