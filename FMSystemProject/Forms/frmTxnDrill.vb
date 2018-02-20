Public Class frmTxnDrill

    Dim journalQuerySQL As String
    Public pAccountNo As String, pFromDate As String, pToDate As String, pDROrCROrNET As String

    Private Sub frmTxnDrill_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        resetForm()
        btnQuery.PerformClick()
    End Sub

    Sub resetForm()
        loadTxnType()
        lblAccountNo.Text = pAccountNo
        dtpFromDate.Value = pFromDate
        dtpToDate.Value = pToDate
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
        PopulateJournal()
    End Sub


    Sub PopulateJournal()
        On Error GoTo errH
        Dim i As Long, netAmt As Double, rsJournal As ADODB.Recordset

        '======================================
        Dim amtCol As String = "", partSql As String = " 1 = 1 "
        If pDROrCROrNET = "DR" Then
            amtCol = "DrAmount"
            partSql = " DrAmount <> 0"
        ElseIf pDROrCROrNET = "CR" Then
            amtCol = "CrAmount"
            partSql = " CrAmount <> 0"
        ElseIf pDROrCROrNET = "NET" Then
            amtCol = "(DrAmount-CrAmount)"
        End If

        journalQuerySQL = "select *," & amtCol & " thisAmt from tbljournal where " & partSql
        journalQuerySQL = journalQuerySQL & " and TxnDate >='" & DateTime.Parse(dtpFromDate.Value).ToString(DB_DATEFORMAT) & "'"
        journalQuerySQL = journalQuerySQL & " and TxnDate <='" & DateTime.Parse(dtpToDate.Value).ToString(DB_DATEFORMAT) & "'"
        journalQuerySQL = journalQuerySQL & " and AccountNo='" & pAccountNo & "'"
        journalQuerySQL = journalQuerySQL & " order by TxnDate ASC"

        '==============================
        netAmt = 0
        'netCrAmt = 0

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
                .Rows(i).Cells("Amount").Value = rsJournal("thisAmt").Value.ToString
                '.Rows(i).Cells("CrAmount").Value = rsJournal("CrAmount").Value.ToString

                netAmt = netAmt + rsJournal("thisAmt").Value.ToString
                'netCrAmt = netCrAmt + rsJournal("CrAmount").Value.ToString

                .Rows(i).ReadOnly = True

                rsJournal.MoveNext()

            End While

            i = .Rows.Add()
            .Rows(i).Cells("AccountNo").Value = "Total (Rs.)"
            .Rows(i).Cells("Amount").Value = addThousandSeparator(netAmt)
            '.Rows(i).Cells("CrAmount").Value = addThousandSeparator(netCrAmt)

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