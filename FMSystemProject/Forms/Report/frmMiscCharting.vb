Public Class frmMiscCharting
    Dim tmpRS As ADODB.Recordset

    Private Sub frmCharting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboReportType.Items.Add("TXN TYPE WISE AMOUNT")
        cboReportType.Items.Add("DAY WISE TXN TYPE COUNT")
        cboReportType.Items.Add("DAY WISE RECEIPT COUNT")
        cboReportType.Items.Add("DAY WISE RECEIPT AMOUNT")
        cboReportType.Items.Add("DAY WISE CASES")
        cboReportType.Items.Add("RESOURCE WISE CASES")


        dtpFromDateSelected = DateAdd(DateInterval.Month, -1, DateTime.Now).ToString(SCREEN_DATEFORMAT)
        dtpToDateSelected = DateTime.Now.ToString(SCREEN_DATEFORMAT)

        txtFromDate.Text = dtpFromDateSelected
        txtToDate.Text = dtpToDateSelected

    End Sub


    Sub loadChart(ChartTitle As String, chrt As DataVisualization.Charting.Chart)
        Dim y1 As Integer ', y2 As Integer
        Dim sr As DataVisualization.Charting.Series
        Dim ca As DataVisualization.Charting.ChartArea
        Dim dpc As DataVisualization.Charting.DataPointCollection

        With chrt
            .ChartAreas.Clear()
            .Series.Clear()

            ca = .ChartAreas.Add(ChartTitle)
            sr = .Series.Add(ChartTitle)
            sr.ChartType = DataVisualization.Charting.SeriesChartType.Bar

            sr.ChartArea = ca.Name

            dpc = sr.Points

            y1 = 0

            While tmpRS.EOF = False

                dpc.AddXY(tmpRS("XVal").Value.ToString, tmpRS("YVal").Value.ToString)

                tmpRS.MoveNext()
            End While


            ' ''ca1.AxisX.LineColor = Color.Transparent
            ' ''ca1.AxisX.LineWidth = 0

            'ca.AxisX.TitleForeColor = Color.Blue
            'ca.AxisY.TitleForeColor = Color.Blue

            'ca.AxisX.LineWidth = 5
            'ca.AxisY.LineWidth = 5


            ca.AxisX.MinorGrid.Enabled = False
            ca.AxisX.MajorGrid.Enabled = False

            'ca.AxisX.LabelAutoFitMaxFontSize = 8
            'ca.AxisX.LabelAutoFitMinFontSize = 8
            'ca.AxisY.LabelAutoFitMaxFontSize = 8
            'ca.AxisY.LabelAutoFitMinFontSize = 8
            'ca.AxisY.LabelAutoFitStyle = DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90
            'ca.AxisX.LabelAutoFitStyle = DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90

            'ca.AxisX.IsLabelAutoFit = True
            'ca.AxisY.IsLabelAutoFit = True

            'ca.AxisX.TextOrientation = DataVisualization.Charting.TextOrientation.Rotated90
            'ca.AxisY.TextOrientation = DataVisualization.Charting.TextOrientation.Rotated90

            ca.AxisX.Interval = 1
            'ca.AxisX.LabelStyle.Angle = -90

            'ca.BackColor = Color.Black
            'sr.Font = New Font("Arial Narrow", 8, FontStyle.Regular)
            '.ForeColor = Color.Red
            sr.IsValueShownAsLabel = True
            'sr.Color = Color.Red

            'c.Label.TextBlock.Appearance.TextProperties.Color = Color.Red;

        End With
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        If dtpFromDateSelected = "" Then
            dtpFromDateSelected = DateAdd(DateInterval.Month, -1, DateTime.Now).ToString
            dtpToDateSelected = DateTime.Now.ToString
        End If

        Select Case cboReportType.Text
            Case "TXN TYPE WISE AMOUNT"

                ssql = "select TxnType as XVal,sum(DrAmount-CrAmount+0) as YVal from tbljournal where Status is null and DrAmount > 0 "
                ssql = ssql & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
                ssql = ssql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"

                ssql = ssql & " and TxnType in (''"
                For x = 0 To lvwExclude.Items.Count - 1
                    If lvwExclude.Items(x).Checked = True Then ssql = ssql & ",'" & lvwExclude.Items(x).Text & "'"
                Next
                ssql = ssql & ")"

                ssql = ssql & " group by TxnType"
                tmpRS = gcon.Execute(ssql)

                loadChart("TXN TYPE WISE AMOUNT", Chart_1)

                tmpRS.Close()

            Case "DAY WISE TXN TYPE COUNT"

                ssql = "select date_format(TxnDate,'%d%b%y') as XVal,Count(*) as YVal from tbljournal where Status is null and DrAmount > 0 "
                ssql = ssql & " and TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
                ssql = ssql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"

                ssql = ssql & " and TxnType in (''"
                For x = 0 To lvwExclude.Items.Count - 1
                    If lvwExclude.Items(x).Checked = True Then ssql = ssql & ",'" & lvwExclude.Items(x).Text & "'"
                Next
                ssql = ssql & ")"

                ssql = ssql & " group by TxnDate"
                tmpRS = gcon.Execute(ssql)

                loadChart("DAY WISE TXN TYPE COUNT", Chart_1)

                tmpRS.Close()

            Case "DAY WISE RECEIPT COUNT"
                ssql = "select date_format(ReceiptDate,'%d%b%y') as XVal, count(*) as YVal from tblreceipt"
                ssql = ssql & " where status is null"
                ssql = ssql & " and ReceiptDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
                ssql = ssql & " and ReceiptDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
                ssql = ssql & " group by ReceiptDate ORDER BY ReceiptDate DESC"
                tmpRS = gcon.Execute(ssql)
                loadChart("DAY WISE RECEIPT COUNT", Chart_1)

                tmpRS.Close()

            Case "DAY WISE RECEIPT AMOUNT"
                ssql = "select date_format(ReceiptDate,'%d%b%y') as XVal, SUM(ReceiptAmt) as YVal from tblreceipt"
                ssql = ssql & " where status is null"
                ssql = ssql & " and ReceiptDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
                ssql = ssql & " and ReceiptDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
                ssql = ssql & " group by ReceiptDate ORDER BY ReceiptDate DESC"
                tmpRS = gcon.Execute(ssql)
                loadChart("DAY WISE RECEIPT AMOUNT", Chart_1)

                tmpRS.Close()

            Case "DAY WISE CASES"
                ssql = "select date_format(CaseLogDate,'%d%b%y') as XVal, count(*) as YVal from tblservicerequest"
                ssql = ssql & " where status <> 'TERMINATED'"
                ssql = ssql & " and CaseLogDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
                ssql = ssql & " and CaseLogDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"

                ssql = ssql & " and CaseType in (''"
                For x = 0 To lvwExclude.Items.Count - 1
                    If lvwExclude.Items(x).Checked = True Then ssql = ssql & ",'" & lvwExclude.Items(x).Text & "'"
                Next
                ssql = ssql & ")"

                ssql = ssql & " group by CaseLogDate"
                tmpRS = gcon.Execute(ssql)
                loadChart("DAY WISE CASES", Chart_1)

                tmpRS.Close()

            Case "RESOURCE WISE CASES"
                ssql = "select CaseAssignedTo as XVal, count(*) as YVal from tblservicerequest"
                ssql = ssql & " where status <> 'TERMINATED'"
                ssql = ssql & " and CaseLogDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
                ssql = ssql & " and CaseLogDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"

                ssql = ssql & " and CaseType in (''"
                For x = 0 To lvwExclude.Items.Count - 1
                    If lvwExclude.Items(x).Checked = True Then ssql = ssql & ",'" & lvwExclude.Items(x).Text & "'"
                Next
                ssql = ssql & ")"

                ssql = ssql & " group by CaseAssignedTo"
                tmpRS = gcon.Execute(ssql)
                loadChart("RESOURCE WISE CASES", Chart_1)

                tmpRS.Close()
            Case Else

        End Select


    End Sub
    Sub loadTxnTypes()
        Dim tmpSql As String, tmpRS As ADODB.Recordset
        lvwExclude.Items.Clear()
        tmpSql = "select distinct TxnType from tbljournal where "
        tmpSql = tmpSql & " TxnDate >='" & DateTime.Parse(dtpFromDateSelected).ToString(DB_DATEFORMAT) & "'"
        tmpSql = tmpSql & " and TxnDate <='" & DateTime.Parse(dtpToDateSelected).ToString(DB_DATEFORMAT) & "'"
        tmpRS = gcon.Execute(tmpSql)
        While tmpRS.EOF = False
            lvwExclude.Items.Add(tmpRS("TxnType").Value.ToString)
            tmpRS.MoveNext()
        End While
    End Sub
    Sub handleTxnTypePopulation()
        Select Case cboReportType.Text

            Case "TXN TYPE WISE AMOUNT"
                loadTxnTypes()

            Case Else

        End Select
    End Sub
    Private Sub cboReportType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboReportType.SelectedValueChanged
        lvwExclude.Items.Clear()
        Select Case cboReportType.Text

            Case "TXN TYPE WISE AMOUNT", "DAY WISE TXN TYPE COUNT"
                loadTxnTypes()

                'Case "DAY WISE RECEIPT COUNT"
                '    tmpRS = gcon.Execute("select distinct TxnType from tbljournal")
                '    While tmpRS.EOF = False
                '        lvwExclude.Items.Add(tmpRS("TxnType").Value.ToString)
                '        tmpRS.MoveNext()
                '    End While

            Case "DAY WISE CASES", "RESOURCE WISE CASES"
                tmpRS = gcon.Execute("select distinct CaseType from tblservicerequest where Status <>'TERMINATED'")
                While tmpRS.EOF = False
                    lvwExclude.Items.Add(tmpRS("CaseType").Value.ToString)
                    tmpRS.MoveNext()
                End While

            Case Else

        End Select
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        For x = 0 To lvwExclude.Items.Count - 1
            lvwExclude.Items(x).Checked = True
        Next
    End Sub

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        For x = 0 To lvwExclude.Items.Count - 1
            lvwExclude.Items(x).Checked = False
        Next
    End Sub

    Private Sub btnSetDates_Click(sender As Object, e As EventArgs) Handles btnSetDates.Click
        dlgReportPeriod.ShowDialog()
        dlgReportPeriod.Dispose()

        txtFromDate.Text = dtpFromDateSelected
        txtToDate.Text = dtpToDateSelected
    End Sub

    Private Sub cboReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReportType.SelectedIndexChanged

    End Sub

    Private Sub txtFromDate_TextChanged(sender As Object, e As EventArgs) Handles txtFromDate.TextChanged
        handleTxnTypePopulation()
    End Sub

    Private Sub txtToDate_TextChanged(sender As Object, e As EventArgs) Handles txtToDate.TextChanged
        handleTxnTypePopulation()
    End Sub
End Class