Public Class frmCharting

    Private Sub frmCharting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtCutOffAmount.Text = 6000
        gFlats.updateBalance()
        gFlats.combineDuplexAmounts()
        loadAllCharts()
    End Sub


    Sub loadAllCharts()
        loadChart("SAP", Chart_SAP)
        loadChart("SAN", Chart_SAN)
        loadChart("SHR", Chart_SHR)
        loadChart("SUK", Chart_SUK)
    End Sub

    Sub loadChart(towerName As String, chrt As DataVisualization.Charting.Chart)
        Dim y1 As Integer ', y2 As Integer
        Dim sr As DataVisualization.Charting.Series
        Dim ca As DataVisualization.Charting.ChartArea
        Dim dpc As DataVisualization.Charting.DataPointCollection

        With chrt
            ' ''s3 = .Series.FindByName("Series1")
            ' ''.Series.Remove(s3)

            .ChartAreas.Clear()
            .Series.Clear()

            ca = .ChartAreas.Add(towerName)
            'sr = .Series.FindByName("Series1")
            sr = .Series.Add(towerName & " Dues")
            'sr.Name = towerName & " Dues"
            ' ''s1 = .Series.Add("Association Dues")
            's2 = .Series.Add("BGF Dues")
            sr.ChartType = DataVisualization.Charting.SeriesChartType.Column
            's2.ChartType = DataVisualization.Charting.SeriesChartType.Column

            sr.ChartArea = ca.Name
            's2.ChartArea = ca2.Name

            dpc = sr.Points

            'dpc2 = s2.Points

            y1 = 0
            'y2 = 0
            For x = 1 To UBound(gFlats.allFlats)
                If (gFlats.allFlats(x).AssocBalance > txtCutOffAmount.Text) Then
                    If myLeft(gFlats.allFlats(x).FlatCode, 3) = towerName Then
                        y1 = y1 + 1
                        dpc.AddXY(gFlats.allFlats(x).FlatCode, gFlats.allFlats(x).AssocBalance)

                    End If
                End If

                'If gFlats.allFlats(x).BGFBalance > 0 Then
                '    y2 = y2 + 1
                '    dpc2.AddXY(y2, gFlats.allFlats(x).BGFBalance)
                'End If
                ' ''If gFlats.allFlats(x).BGFBalance < 0 Then MsgBox(gFlats.allFlats(x).FlatCode & " : " & gFlats.allFlats(x).BGFBalance)
            Next x


            ' ''ca1.AxisX.LineColor = Color.Transparent
            ' ''ca1.AxisX.LineWidth = 0
            ca.AxisX.MinorGrid.Enabled = False
            ca.AxisX.MajorGrid.Enabled = False

            'ca2.AxisX.MinorGrid.Enabled = False
            'ca2.AxisX.MajorGrid.Enabled = False

        End With
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        If IsNumeric(txtCutOffAmount.Text) = False Then
            MsgBox("Cutoff amount is not valid")
            txtCutOffAmount.Text = 0
        End If
        loadAllCharts()
    End Sub
End Class