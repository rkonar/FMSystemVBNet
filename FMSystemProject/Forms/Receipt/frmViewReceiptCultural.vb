Public Class frmViewReceiptCultural
    Dim lFinYear As New clsFinYear
    Dim thisReceipt As New clsReceipt_Cult
    Dim thisJournal As New clsJournal_Cult
    Sub loadAllReceipts()
        cboReceiptNo.Items.Clear()
        tmpRS = gcon.Execute("select ReceiptNo from tblreceipt_cult where ReceiptDate >= '" & lFinYear.startDate & "' and ReceiptDate <= '" & lFinYear.endDate & "' order by ReceiptNo desc")
        While tmpRS.EOF = False
            cboReceiptNo.Items.Add(tmpRS("ReceiptNo").Value.ToString)
            tmpRS.MoveNext()
        End While
    End Sub
    Sub resetAll()
        txtAccountNo.Text = ""
        txtAmount.Text = ""
        txtDocRef.Text = ""
        txtInstrumentNo.Text = ""
        txtNarration.Text = ""
        txtNarration2.Text = ""
        txtReceiptAmount.Text = ""
        txtReceiptID.Text = ""
        txtReceiptNo.Text = ""
        txtTxnDate.Text = ""
        txtTxnType.Text = ""
        txtgid.Text = ""
        txtgid2.Text = ""
        txtrefgid.Text = ""
        cboBankName.SelectedIndex = -1
        cboInstrumentType.SelectedIndex = -1
    End Sub

    Sub ShowReceipt()
        Dim tmprefgid As String
        If thisReceipt.ReceiptNo = "" Then Exit Sub

        resetAll()

        controlFieldStatus(False)
        btnEdit.Enabled = True

        With thisReceipt
            txtReceiptID.Text = .tblid
            txtReceiptNo.Text = .ReceiptNo
            dtpReceiptDate.Text = .ReceiptDate
            dtpJournalDate.Text = .JournalDate
            txtReceiptAmount.Text = .ReceiptAmount
            cboInstrumentType.Text = .InstrumentType
            If .InstrumentType = "CASH" Then
                'dtpInstrumentDate.Enabled = False
            Else
                'dtpInstrumentDate.Enabled = True
                dtpInstrumentDate.Text = .InstrumentDate
            End If

            txtInstrumentNo.Text = .InstrumentNo
            cboBankName.Text = .InstrumentBank
            txtNarration.Text = .Remarks
            txtFlatCode.Text = .FlatCode

            txtgid.Text = .gid

            If .ReceiptStatus = "C" Then
                chkCancelled.Checked = True
                btnEdit.Enabled = False
            Else
                chkCancelled.Checked = False
            End If

        End With

        If cboInstrumentType.Text <> "CASH" Then
            thisJournal.loadDrTransactionFromGID(thisReceipt.gid)
            tmprefgid = thisJournal.refgid
            If tmprefgid <> "" Then
                With thisJournal
                    .loadDrTransactionFromGID(tmprefgid)
                    txtAccountNo.Text = .DrAccountNo
                    txtAmount.Text = .Amount
                    txtTxnDate.Text = formatInt2Date(.TxnDate)
                    txtTxnType.Text = .TxnType
                    txtNarration2.Text = .Narration
                    txtDocRef.Text = .DocRef
                    txtgid2.Text = .gid
                    txtrefgid.Text = .refgid

                End With

                btnEdit.Enabled = False

                If (txtAmount.Text <> txtReceiptAmount.Text) Then MsgBox("The reconciliation for this receipt is incorrect. Amounts does not match!!!")

            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        gCurReceiptNo = ""
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo errH

        getRolePermission()
        If gCanEdit <> "Y" Then
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If

        If validateReceiptUpdate() = False Then GoTo errH
        'Journalise Bill
        gcon.BeginTrans()
        With thisReceipt
            .FlatCode = txtFlatCode.Text
            .InstrumentBank = cboBankName.Text
            .InstrumentDate = dtpInstrumentDate.Text
            .InstrumentNo = txtInstrumentNo.Text
            .InstrumentType = cboInstrumentType.Text
            .ReceiptDate = dtpReceiptDate.Text
            .Remarks = txtNarration.Text
            .ReceiptNo = txtReceiptNo.Text
            .ReceiptAmount = txtReceiptAmount.Text
            .JournalDate = dtpJournalDate.Text

            .UpdateReceipt()

            If .Status = False Then GoTo errH

        End With

        gcon.CommitTrans()

        'Log user activity
        gItemID = "Receipt No:" & txtReceiptNo.Text
        gItemAction = "Update"
        If logUserActivity() = False Then GoTo errH

        MsgBox("Receipt updated successfully")
        frmMain.sslabel3.Text = "Receipt updated successfully"

        loadAllReceipts()

        gCurReceiptNo = txtReceiptNo.Text
        thisReceipt.loadSingleReceipt("", gCurReceiptNo, "")
        If thisReceipt.Status = False Then Exit Sub
        ShowReceipt()

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)

    End Sub


    Function validateReceiptUpdate() As Boolean
        validateReceiptUpdate = False


        'If Not IsNumeric(txtReceiptAmount.Text) Then
        '    MsgBox("Invalid receipt amount")
        '    Exit Function
        'End If

        'If txtReceiptAmount.Text <= 0 Then
        '    MsgBox("Invalid receipt amount")
        '    Exit Function
        'End If

        If DateTime.Parse(dtpReceiptDate.Text).ToString(DB_DATEFORMAT) > DateTime.Now.ToString(DB_DATEFORMAT) Then
            MsgBox("Receipt date can't be in future")
            Exit Function
        End If

        'If Trim(txtReceiptNo.Text) = "" Then
        '    MsgBox("Provide receipt no")
        '    Exit Function
        'End If

        If Trim(txtNarration.Text) = "" Then
            MsgBox("Provide narration")
            Exit Function
        End If

        If cboInstrumentType.Text = "CASH" Then

        ElseIf cboInstrumentType.Text = "CHEQUE" Then
            If Trim(txtInstrumentNo.Text) = "" Then
                MsgBox("Provide cheque no")
                Exit Function
            End If
            If Trim(cboBankName.Text) = "" Then
                MsgBox("Provide bank name")
                Exit Function
            End If
            If DateTime.Parse(dtpJournalDate.Text).ToString(DB_DATEFORMAT) < DateTime.Parse(dtpInstrumentDate.Text).ToString(DB_DATEFORMAT) Then
                MsgBox("Journal date can't be prior to Cheque Date")
                Exit Function
            End If
        ElseIf cboInstrumentType.Text = "ONLINE" Then
            If Trim(txtInstrumentNo.Text) = "" Then
                MsgBox("Provide transaction reference no")
                Exit Function
            End If
            If Trim(cboBankName.Text) = "" Then
                MsgBox("Provide bank name")
                Exit Function
            End If
            If DateTime.Parse(dtpInstrumentDate.Text).ToString(DB_DATEFORMAT) > DateTime.Now.ToString(DB_DATEFORMAT) Then
                MsgBox("Transfer date can't be in future")
                Exit Function
            End If
            If DateTime.Parse(dtpJournalDate.Text).ToString(DB_DATEFORMAT) < DateTime.Parse(dtpInstrumentDate.Text).ToString(DB_DATEFORMAT) Then
                MsgBox("Journal date can't be prior to Online Transfer Date")
                Exit Function
            End If
        End If

        'ssql = "select * from tblreceipt_cult where ReceiptNo='" & Trim(txtReceiptNo.Text) & "'"
        'tmpRS = gcon.Execute(ssql)
        'If tmpRS.EOF = False Then
        '    MsgBox("This receipt no is already issued to " & tmpRS("FlatCode").Value.ToString & " on " & formatInt2Date(tmpRS("ReceiptDate").Value.ToString))
        '    Exit Function
        'End If

        validateReceiptUpdate = True
    End Function


    Private Sub cboInstrumentType_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboInstrumentType.SelectedValueChanged
        If cboInstrumentType.Text = "CASH" Then
            'dtpInstrumentDate.Enabled = False
            'txtInstrumentNo.Enabled = False
            'cboBankName.Enabled = False

            dtpInstrumentDate.Text = ""
            txtInstrumentNo.Text = ""
            cboBankName.Text = ""

        ElseIf cboInstrumentType.Text = "CHEQUE" Then
            'dtpInstrumentDate.Enabled = True
            'txtInstrumentNo.Enabled = True
            'cboBankName.Enabled = True

            lblInstrumentDate.Text = "Cheque Date"
            lblInstrumentNo.Text = "Cheque No"

        ElseIf cboInstrumentType.Text = "ONLINE" Then
            'dtpInstrumentDate.Enabled = True
            'txtInstrumentNo.Enabled = True
            'cboBankName.Enabled = True

            lblInstrumentDate.Text = "Transfer Date"
            lblInstrumentNo.Text = "Transaction Ref. No"
        End If
    End Sub

    Private Sub btnSaveViewReceiptImage_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveViewReceiptImage.Click
        getRolePermission()
        If gCanEdit <> "Y" Then
            MsgBox("Sorry. You do not have sufficient permission to perform this action. Contact System Administrator.")
            Exit Sub
        End If
        ImageItemType = "RECEIPT-CULTURAL"
        ImageItemNo = gCurReceiptNo
        frmSaveViewItemData.ShowDialog()
        frmSaveViewItemData.Dispose()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        getRolePermission()
        If gCanEdit <> "Y" Then
            MsgBox("Sorry. You do not have sufficient permission to perform this action. Contact System Administrator.")
            Exit Sub
        End If
        controlFieldStatus(True)
    End Sub
    Sub controlFieldStatus(makeEditable As Boolean)

        txtFlatCode.Enabled = False


        If makeEditable = False Then
            txtNarration.Enabled = False
            cboBankName.Enabled = False

            dtpInstrumentDate.Enabled = False
            txtInstrumentNo.Enabled = False
            'cboInstrumentType.Enabled = False
            dtpReceiptDate.Enabled = False
            dtpJournalDate.Enabled = False
            txtReceiptNo.Enabled = False
            txtReceiptAmount.Enabled = False

            btnSave.Enabled = False
            btnLoadOriginal.Enabled = False
            'btnEdit.Enabled = True

        Else
            txtNarration.Enabled = True
            dtpReceiptDate.Enabled = True
            dtpJournalDate.Enabled = True
            'txtReceiptNo.Enabled = True
            'txtReceiptAmount.Enabled = True

            btnSave.Enabled = True
            btnLoadOriginal.Enabled = True
            btnEdit.Enabled = False


            'cboInstrumentType.Enabled = True ' instrument type chnage is not allowed at present

            If cboInstrumentType.Text = "CASH" Then
                dtpInstrumentDate.Enabled = False
                txtInstrumentNo.Enabled = False
                cboBankName.Enabled = False

                txtReceiptAmount.Enabled = False 'Cash receipt amount can't be altered
            Else
                dtpInstrumentDate.Enabled = True
                txtInstrumentNo.Enabled = True
                cboBankName.Enabled = True
            End If


        End If

        btnContraReceipt.Enabled = Not chkCancelled.Checked

    End Sub

    Private Sub btnLoadOriginal_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadOriginal.Click
        ShowReceipt()
        'controlFieldStatus(False)
    End Sub

    Private Sub frmViewReceiptCultural_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'gItemCode = "Receipts"
        lblReceiptID.Text = "Receipt ID" & vbNewLine & "Write in Paper Receipt"

        'txtFlatCode.DataSource = FLATS
        cboInstrumentType.Items.AddRange(INSTRUMENT_TYPES)
        'txtFlatCode.SelectedIndex = 0
        getBankNames()
        cboBankName.Items.Clear()
        For x = 1 To UBound(BankNames)
            cboBankName.Items.Add(BankNames(x))
        Next
        If gCurReceiptNo <> "" Then
            thisReceipt.loadSingleReceipt("", gCurReceiptNo, "")
            If thisReceipt.Status = False Then Exit Sub
            ShowReceipt()
            cboReceiptNo.Enabled = False
            cboFinYear.SelectedIndex = -1
            btnSaveViewReceiptImage.Enabled = True

        Else
            cboFinYear.Items.Clear()
            Dim toYear As Integer
            If Month(DateTime.Now) > 3 Then
                toYear = Year(DateTime.Now)
            Else
                toYear = Year(DateTime.Now) - 1
            End If
            For x = 2012 To toYear
                cboFinYear.Items.Add(x & "-" & x + 1)
            Next

            lFinYear.SetToCurFinYear()
            cboFinYear.Text = lFinYear.startYear & "-" & lFinYear.endYear

            loadAllReceipts()
            btnSaveViewReceiptImage.Enabled = False
            btnEdit.Enabled = False
            controlFieldStatus(False)
        End If

        grpCancel.Enabled = False
        '******************

    End Sub

    Private Sub btnContraReceipt_Click(sender As System.Object, e As System.EventArgs) Handles btnContraReceipt.Click
        On Error GoTo errH

        getRolePermission()
        If gCanEdit <> "Y" Then
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If


        grpCancel.Enabled = True

        btnSave.Enabled = False
        txtNarration.Enabled = False

        ''If validateReceiptUpdate() = False Then GoTo errH
        'Journalise Bill

        ''With thisReceipt
        ''    '.FlatCode = txtFlatCode.Text
        ''    '.InstrumentBank = cboBankName.Text
        ''    '.InstrumentDate = dtpInstrumentDate.Text
        ''    '.InstrumentNo = txtInstrumentNo.Text
        ''    '.InstrumentType = cboInstrumentType.Text
        ''    '.ReceiptDate = dtpReceiptDate.Text
        ''    .Remarks = txtNarration.Text

        ''    gcon.BeginTrans()
        ''    .ContraReceipt()
        ''    gcon.CommitTrans()
        ''    If .Status = False Then GoTo errH

        ''End With

        ' ''Log user activity
        ''gItemID = "Receipt No:" & txtReceiptNo.Text
        ''gItemAction = "Cancel"
        ''If logUserActivity() = False Then GoTo errH

        ''MsgBox("Receipt cancelled successfully")
        ''frmMain.sslabel3.Text = "Receipt cancelled successfully"
        ''btnClose.PerformClick()
        ''controlFieldStatus(False)

        'gCurReceiptNo = cboReceiptNo.Text
        'thisReceipt.loadSingleReceipt("", gCurReceiptNo, "")
        'ShowReceipt()

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)

    End Sub


    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        'Only for Admin
        If gLoginID <> "sa" Then Exit Sub
        If btnEdit.Enabled = False Then
            btnEdit.Enabled = True
        End If

    End Sub


    Private Sub cboReceiptNo_TextChanged(sender As Object, e As EventArgs) Handles cboReceiptNo.TextChanged
        If cboReceiptNo.Text = "" Then Exit Sub
        gCurReceiptNo = cboReceiptNo.Text
        thisReceipt.loadSingleReceipt("", gCurReceiptNo, "")
        If thisReceipt.Status = False Then Exit Sub
        ShowReceipt()
    End Sub



    Private Sub cboFinYear_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFinYear.SelectedValueChanged
        lFinYear.SetToFinYear(cboFinYear.Text)
        lblFinYear.Text = lFinYear.startDateDisplay & " - " & lFinYear.endDateDisplay
        loadAllReceipts()
        resetAll()
        cboReceiptNo.SelectedIndex = -1
        cboReceiptNo.Text = ""
    End Sub


    Private Sub btnSubmitContraRcpt_Click(sender As Object, e As EventArgs) Handles btnSubmitContraRcpt.Click
        If DateTime.Parse(dtpContraDate.Text).ToString(DB_DATEFORMAT) > DateTime.Now.ToString(DB_DATEFORMAT) Then
            MsgBox("Contra date can't be in future")
            Exit Sub
        End If
        If DateTime.Parse(dtpContraDate.Text).ToString(DB_DATEFORMAT) < DateTime.Parse(dtpReceiptDate.Text).ToString(DB_DATEFORMAT) Then
            MsgBox("Contra date can't be earlier than Receipt date")
            Exit Sub
        End If

        If Trim(txtContraReason.Text) = "" Then
            MsgBox("Provide Reason for contra")
            Exit Sub
        End If

        If MsgBox("This will create a contra entry for the receipt " & txtReceiptNo.Text & ". Are you sure?", MsgBoxStyle.OkCancel, "Confirmation") = vbCancel Then
            Exit Sub
        End If


        With thisReceipt

            .Remarks = txtContraReason.Text
            .CancelDate = dtpContraDate.Value

            gcon.BeginTrans()
            .ContraReceipt()
            If .Status = False Then GoTo errH
            gcon.CommitTrans()


        End With

        'Log user activity
        gItemID = "Receipt No:" & txtReceiptNo.Text
        gItemAction = "Contra-Receipt"
        If logUserActivity() = False Then GoTo errH

        MsgBox("Contra creation successful")
        frmMain.sslabel3.Text = "Contra creation successful"
        btnClose.PerformClick()

        Exit Sub

errH:
        gErrMsg = gErrMsg & " " & Err.Description
        gcon.RollbackTrans()
        myMsgBox(gErrMsg)

    End Sub



End Class