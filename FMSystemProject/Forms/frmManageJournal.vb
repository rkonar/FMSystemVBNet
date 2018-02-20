Public Class frmManageJournal

    Dim journalQuerySQL As String

    Private Sub frmManageJournal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        resetForm()
    End Sub

    Sub resetForm()
        loadTxnType()

    End Sub

    Sub loadTxnType()
        Dim tmpRS As ADODB.Recordset

        cboTxnType.Items.Clear()
        tmpRS = gcon.Execute("select distinct TxnType from tbljournal order by TxnType ASC")
        While tmpRS.EOF = False
            cboTxnType.Items.Add(tmpRS("TxnType").Value.ToString)
            tmpRS.MoveNext()
        End While
        tmpRS.Close()
    End Sub


    Private Sub btnQuery_Click(sender As System.Object, e As System.EventArgs) Handles btnQuery.Click
        formJournalQuerySql()
        PopulateJournal()
    End Sub

    Sub formJournalQuerySql()
        journalQuerySQL = "select * from tbljournal where "
        journalQuerySQL = journalQuerySQL & " TxnDate >='" & DateTime.Parse(dtpFromDate.Text).ToString(DB_DATEFORMAT) & "'"
        journalQuerySQL = journalQuerySQL & " and TxnDate <='" & DateTime.Parse(dtpToDate.Text).ToString(DB_DATEFORMAT) & "'"
        If cboTxnType.Text <> "" Then
            journalQuerySQL = journalQuerySQL & " and TxnType='" & cboTxnType.Text & "'"
        End If
        If txtFromAmount.Text <> "" Then
            journalQuerySQL = journalQuerySQL & " and ((DrAmount >=" & txtFromAmount.Text & " and CrAmount=0) OR (CrAmount >=" & txtFromAmount.Text & " and DrAmount=0))"
        End If
        If txtToAmount.Text <> "" Then
            journalQuerySQL = journalQuerySQL & " and ((DrAmount <=" & txtToAmount.Text & " and CrAmount=0) OR (CrAmount <=" & txtToAmount.Text & " and DrAmount=0))"
        End If
        If txtNarrationLike.Text <> "" Then
            journalQuerySQL = journalQuerySQL & " and Narration like'%" & txtNarrationLike.Text & "%'"
        End If
        If txtDocRefLike.Text <> "" Then
            journalQuerySQL = journalQuerySQL & " and DocRef like'%" & txtDocRefLike.Text & "%'"
        End If

        journalQuerySQL = journalQuerySQL & " order by TxnDate ASC"


    End Sub


    Sub PopulateJournal()
        On Error GoTo errH
        Dim i As Long, netDrAmt As Double, netCrAmt As Double, rsJournal As ADODB.Recordset

        netDrAmt = 0
        netCrAmt = 0

        dgvJournal.Rows.Clear()
        rsJournal = gcon.Execute(journalQuerySQL)


        With dgvJournal

            While rsJournal.EOF = False

                i = .Rows.Add()
                .Rows(i).Cells("tblid").Value = rsJournal("tblid").Value.ToString
                .Rows(i).Cells("gid").Value = rsJournal("gid").Value.ToString
                .Rows(i).Cells("TxnType").Value = rsJournal("TxnType").Value.ToString
                .Rows(i).Cells("TxnDate").Value = formatInt2Date(rsJournal("TxnDate").Value.ToString)
                .Rows(i).Cells("Narration").Value = rsJournal("Narration").Value.ToString
                .Rows(i).Cells("DocRef").Value = rsJournal("DocRef").Value.ToString
                .Rows(i).Cells("AccountNo").Value = rsJournal("AccountNo").Value.ToString
                .Rows(i).Cells("DrAmount").Value = rsJournal("DrAmount").Value.ToString
                .Rows(i).Cells("CrAmount").Value = rsJournal("CrAmount").Value.ToString

                netDrAmt = netDrAmt + rsJournal("DrAmount").Value.ToString
                netCrAmt = netCrAmt + rsJournal("CrAmount").Value.ToString

                .Rows(i).ReadOnly = True

                rsJournal.MoveNext()

            End While

            i = .Rows.Add()
            .Rows(i).Cells("AccountNo").Value = "Total (Rs.)"
            .Rows(i).Cells("DrAmount").Value = addThousandSeparator(netDrAmt)
            .Rows(i).Cells("CrAmount").Value = addThousandSeparator(netCrAmt)

            .Rows(i).ReadOnly = True
            NetLineStyle.Font = New Font(DataGridView.DefaultFont, FontStyle.Bold)
            .Rows(i).DefaultCellStyle = NetLineStyle
            .Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Rows(i).DefaultCellStyle.ForeColor = Color.Blue

            '.Rows(0).Cells("TxnDate").Selected = False
            '.Rows(i).Cells("TxnAmt").Selected = True
        End With

        rsJournal.Close()

        Exit Sub

errH:
        On Error Resume Next
        frmMain.sslabel3.Text = Err.Description
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

End Class