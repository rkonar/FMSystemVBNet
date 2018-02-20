

Public Class frmMain
    Dim comingFromMeClose As Boolean = False
    Private Function isFormAlreadyLoaded(ByVal formName As String) As Boolean

        isFormAlreadyLoaded = False

        If Me.MdiChildren.Length = 0 Then Exit Function

        For Each tmpform In Me.MdiChildren
            If formName = tmpform.Name Then
                isFormAlreadyLoaded = True
                Exit Function
            End If
        Next

    End Function
    Private Function showMDIChildFormIfAlreadyLoaded(ByVal formName As String) As Boolean

        showMDIChildFormIfAlreadyLoaded = False
        For Each tmpform In Me.MdiChildren
            If formName = tmpform.Name Then
                showMDIChildFormIfAlreadyLoaded = True
                tmpform.Show()
                Exit Function
            End If
        Next

    End Function
    Public Sub hideAllMDIChildren()
        Dim tmpform As Form

        If Me.MdiChildren.Length = 0 Then Exit Sub

        For Each tmpform In Me.MdiChildren
            tmpform.Hide()
        Next

    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        frmLogin.Hide()
        sslabel1.Text = "User : " & gUserName
        sslabel2.Text = "Role : " & gRoleCode
        sslabel3.Text = "Login at : " & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")


        'hide restriced menu items
        gItemCode = "frmAccessManager"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiAccessManager.Visible = False
        End If

        gItemCode = "frmManagePayment"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiManagePayment.Visible = False
        End If

        gItemCode = "frmCOA"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiCOA.Visible = False
        End If

        gItemCode = "frmCOAReport"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiCOAReports.Visible = False
        End If

        gItemCode = "frmDBBackup"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiDBBackup.Visible = False
        End If

        gItemCode = "frmGeneratePassword"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiGeneratePWD.Visible = False
        End If

        gItemCode = "frmBillMailer"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiBillMailer.Visible = False
        End If

        gItemCode = "frmManageFlatAndOwnerDetails"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiManageFlatAndOwnerDetails.Visible = False
        End If

        gItemCode = "frmPerformBilling"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiPerformBilling.Visible = False
        End If

        gItemCode = "frmBankReconcile"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiReconcileBankStatement.Visible = False
        End If

        gItemCode = "frmBookReceipt"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiBookReceipt.Visible = False
        End If

        gItemCode = "frmViewReceipt"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiViewReceipt.Visible = False
        End If

        gItemCode = "tsmiSyncOwnerDetailsFromPortal"
        getRolePermission()
        If gCanView <> "Y" Then
            tsmiSyncOwnerDetailsFromPortal.Visible = False
        End If

        '===============
        gFlats.loadAll()
        'gFlats.updateBalance()
        '===============
        ShowOpenCaseCountInNotificationTray()

        'tsmiManageFlatAndOwnerDetails.PerformClick() 'disabling it as it makes first time load appear very slow


    End Sub

    

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles tsmiExit.Click
        LogoffFromSystem(True)
    End Sub

    Private Sub tsmiLogOff_Click(sender As System.Object, e As System.EventArgs) Handles tsmiLogOff.Click
        LogoffFromSystem(False)
    End Sub
    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If comingFromMeClose = True Then
            e.Cancel = False
            Exit Sub
        End If

        If MsgBox("OK to log off and close?", MsgBoxStyle.OkCancel) = vbOK Then
            'Set user activity params

            gItemAction = "Logoff"
            gItemCode = "System Logoff"
            gItemID = gLoginID
            If logUserActivity() = False Then Exit Sub
            frmLogin.Close()
            frmLogin.Dispose()
        End If
        e.Cancel = True
    End Sub

    Sub LogoffFromSystem(ByVal alsoClose As Boolean)
        Dim QtoAsk As String

        If alsoClose = True Then
            QtoAsk = "OK to log off and close?"
        Else
            QtoAsk = "OK to log off?"
        End If

        If MsgBox(QtoAsk, MsgBoxStyle.OkCancel) = vbOK Then
            'Set user activity params
            gItemAction = "Logoff"
            gItemCode = "System Logoff"
            gItemID = gLoginID
            If logUserActivity() = False Then Exit Sub

            If alsoClose = True Then
                frmLogin.Close()
                frmLogin.Dispose()
                Exit Sub 'this step will never execute
            End If

            frmLogin.resetForm()
            frmLogin.Show()
            comingFromMeClose = True
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub cmsChangeUserPassword_Click(sender As System.Object, e As System.EventArgs) Handles cmsChangeUserPassword.Click
        frmChangePWD.ShowDialog()
        frmChangePWD.Dispose()
    End Sub

    Private Sub tsmiReceiveBillPayment_Click(sender As System.Object, e As System.EventArgs)
        If isAllowedToViewModule("frmManageMaintBillReceipts") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmManageMaintBillReceipts
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If

    End Sub

    Sub showfrmManageFlatAndOwnerDetails()
        If isAllowedToViewModule("frmManageFlatAndOwnerDetails") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmManageFlatAndOwnerDetails
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If

    End Sub

    

    Private Sub tsmiCOA_Click(sender As System.Object, e As System.EventArgs) Handles tsmiCOA.Click
        If isAllowedToViewModule("frmCOA") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmCOA
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If

    End Sub

    Function createNewForm(formName As String) As Boolean
        createNewForm = False
        If Me.MdiChildren.Length > 0 Then
            If Me.MdiChildren(0).Name <> formName Then
                If MsgBox("Are you sure to navigate away from '" & Me.MdiChildren(0).Text & "' screen?", MsgBoxStyle.OkCancel) = vbOK Then
                    Me.MdiChildren(0).Close()
                    createNewForm = True
                End If
            End If
        Else
            createNewForm = True
        End If
    End Function

    Private Sub tsmiManageFlatAndOwnerDetails_Click(sender As System.Object, e As System.EventArgs) Handles tsmiManageFlatAndOwnerDetails.Click
        showfrmManageFlatAndOwnerDetails()
    End Sub

    'Private Sub tsmiRecordMaintenanceReceipt_Click(sender As System.Object, e As System.EventArgs)
    '    'standard entry check code start
    '    gItemCode = "frmBookReceipt"
    '    getRolePermission()
    '    If gCanView <> "Y" Then
    '        gItemCode = "frmBookReceipt"
    '        MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
    '        Exit Sub
    '    End If
    '    'standard entry check code end

    '    'launch form
    '    If createNewForm(gItemCode) = True Then
    '        Dim frm As New frmBookReceipt
    '        frm.MdiParent = Me
    '        frm.Show()
    '        frm.WindowState = FormWindowState.Minimized
    '        frm.WindowState = FormWindowState.Maximized
    '    End If
    'End Sub

    Private Sub sslabel1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles sslabel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            statusbarContextMenu.Show()
            statusbarContextMenu.Left = Cursor.Position.X
            statusbarContextMenu.Top = Cursor.Position.Y
        End If
    End Sub


    

    
    'Private Sub tsmiManageBankTransactions_Click(sender As System.Object, e As System.EventArgs) Handles tsmiManageBankTransactions.Click

    '    'standard entry check code start
    '    gItemCode = "frmBankTxn"
    '    getRolePermission()
    '    If gCanView <> "Y" Then
    '        gItemCode = "frmBankTxn"
    '        MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
    '        Exit Sub
    '    End If
    '    'standard entry check code end

    '    'launch form
    '    If createNewForm(gItemCode) = True Then
    '        Dim frm As New frmBankTxn
    '        frm.MdiParent = Me
    '        frm.Show()
    '        frm.WindowState = FormWindowState.Minimized
    '        frm.WindowState = FormWindowState.Maximized
    '    End If
    'End Sub


    Private Sub tsmiDBBackup_Click(sender As System.Object, e As System.EventArgs) Handles tsmiDBBackup.Click
        If isAllowedToViewModule("frmDBBackup") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmDBBackup
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiMarkEndOfDay_Click(sender As System.Object, e As System.EventArgs) Handles tsmiMarkEndOfDay.Click
        On Error GoTo errH

        Dim tmpStr As String = ""
        tmpStr = InputBox("Enter Password ", "End Of Day Housekeeping")
        If getSysParamValue("ENDOFDAY_PWD") <> tmpStr Then
            MsgBox("Incorrect password")
            Exit Sub
        End If


        'Take end of day backup
        Dim myBackup As New clsBackupRestore
        myBackup.BackupDir = getSysParamValue("PATH_DB_BACKUP")
        myBackup.FullDBBackup()


        Dim myReporter As New clsReport
        myReporter.FromDate = DateTime.Now.ToString("dd-MMM-yyyy")
        myReporter.genEODReport()

        Dim myMailer As New clsSendMail

        With myMailer
            .mailSubject = "Greenfield Heights(HIG) Facility Management System - CASH/BANK/CHEQUE Update for " & DateTime.Now.ToString("dd-MMM-yyyy")
            tmpStr = "1) EOD Status Report attached."
            tmpStr = tmpStr & "<br>2) Full database backup done and kept at :" & myBackup.outBackupFileName
            .mailBody = tmpStr
            .IsBodyHtml = True
            .Attachments = New String() {myReporter.ReportFileName}

            .SendMail_EOD()
        End With

        'If System.IO.File.Exists(myReporter.ReportFileName) = True Then System.IO.File.Delete(myReporter.ReportFileName)

        MsgBox("done")
        Exit Sub

errH:
        If Err.Description <> "" Then MsgBox(Err.Description)

    End Sub

    
    

    Private Sub tsmiManageJournal_Click(sender As System.Object, e As System.EventArgs) Handles tsmiManageJournal.Click
        If isAllowedToViewModule("frmManageJournal") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmManageJournal
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    'Private Sub GidToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GidToolStripMenuItem.Click
    '    Dim gidRS As ADODB.Recordset, x As Integer

    '    For x = 1 To 70
    '        ssql = "select * from tbljournal where gid is null order by tblid asc"
    '        gidRS = gcon.Execute(ssql)

    '        If gidRS.EOF = True Then
    '            MsgBox("all done")
    '            Exit Sub
    '        End If

    '        gidRS.Close()
    '        setGid3()
    '    Next x
    '    MsgBox("done")
    'End Sub

    
    'Sub setGid2()
    '    Dim gidRS As ADODB.Recordset, tblid1 As String, damt1 As String, camt1 As String, tblid2 As String, damt2 As String, camt2 As String, thisGID As String, thisDate As String

    '    ssql = "select * from tbljournal where gid is null and tblid >= 2564 and tblid <= 2814 order by tblid asc"
    '    gidRS = gcon.Execute(ssql)

    '    tblid1 = gidRS("tblid").Value.ToString
    '    damt1 = gidRS("DrAmount").Value.ToString
    '    camt1 = gidRS("CrAmount").Value.ToString
    '    thisDate = gidRS("TxnDate").Value.ToString

    '    gidRS.Close()

    '    ssql = "select * from tbljournal where tblid = " & (CInt(tblid1) + 502)
    '    gidRS = gcon.Execute(ssql)

    '    tblid2 = gidRS("tblid").Value.ToString
    '    damt2 = gidRS("DrAmount").Value.ToString
    '    camt2 = gidRS("CrAmount").Value.ToString
    '    gidRS.Close()

    '    thisGID = thisDate & DateTime.Now.ToString("hhmmssffff") & "system"

    '    If (((damt1 = camt2) And (damt1 <> 0)) Or ((damt2 = camt1) And (damt2 <> 0))) Then
    '        ssql = "update tbljournal set gid='" & thisGID & "' where (tblid=" & tblid1 & " OR tblid=" & tblid2 & ")"
    '        gcon.Execute(ssql)
    '    End If

    'End Sub
    'Sub setGid3()
    '    Dim gidRS As ADODB.Recordset, tblid1 As String, damt1 As String, camt1 As String, tblid2 As String, damt2 As String, camt2 As String, thisGID As String, thisDate As String, netAmt As Double

    '    ssql = "select * from tbljournal where gid is null order by tblid asc"
    '    gidRS = gcon.Execute(ssql)

    '    tblid1 = gidRS("tblid").Value.ToString
    '    damt1 = gidRS("DrAmount").Value.ToString
    '    camt1 = CDbl(gidRS("CrAmount").Value.ToString)
    '    thisDate = gidRS("TxnDate").Value.ToString

    '    gidRS.MoveNext()

    '    tblid2 = gidRS("tblid").Value.ToString
    '    damt2 = gidRS("DrAmount").Value.ToString
    '    camt2 = CDbl(gidRS("CrAmount").Value.ToString)
    '    gidRS.Close()

    '    thisGID = thisDate & DateTime.Now.ToString("hhmmssffff") & "system"
    '    netAmt = CDbl(camt1) + CDbl(camt2)
    '    If ((netAmt = 0) And (camt1 <> 0) And (camt2 <> 0)) Then
    '        ssql = "update tbljournal set gid='" & thisGID & "' where (tblid=" & tblid1 & " OR tblid=" & tblid2 & ")"
    '        gcon.Execute(ssql)
    '    End If

    'End Sub

    
    'Private Sub GidToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GidToolStripMenuItem.Click
    '    Dim gidRS As ADODB.Recordset, x As Integer, thisDocRef As String, pos1 As Integer, pos2 As Integer, rcpt_no As String, chq_no As String, thisNarration As String

    '    ssql = "select * from tbljournal where TxnType='CHEQUE-2-BANK' order by tblid asc"
    '    gidRS = gcon.Execute(ssql)

    '    Dim thisRcpt As New clsReceipt

    '    While gidRS.EOF = False
    '        rcpt_no = ""
    '        chq_no = ""
    '        thisDocRef = Trim(gidRS("DocRef").Value.ToString)
    '        thisNarration = Trim(gidRS("Narration").Value.ToString)
    '        '======
    '        rcpt_no = myRight(thisNarration, 3)
    '        If IsNumeric(rcpt_no) = True Then

    '            pos1 = InStr(1, thisDocRef, "Cheque No=")
    '            If pos1 <> 0 Then
    '                chq_no = myRight(thisDocRef, Len(thisDocRef) - pos1 - 10 + 1)
    '                thisRcpt.ReconcileInstrument(rcpt_no, chq_no)
    '            End If
    '        End If
    '        gidRS.MoveNext()
    '    End While

    '    gidRS.Close()
    '    MsgBox("done")
    'End Sub

    'Private Sub TmpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TmpToolStripMenuItem.Click
    '    Dim gidRS As ADODB.Recordset

    '    ssql = "select * from tblReceipt where InstrumentType='ONLINE' and ReceiptDate<>InstrumentDate"
    '    gidRS = gcon.Execute(ssql)

    '    While gidRS.EOF = False

    '        gcon.Execute("update tbljournal set TxnDate='" & gidRS("InstrumentDate").Value.ToString & "' where gid='" & gidRS("gid").Value.ToString & "'")


    '        gidRS.MoveNext()
    '    End While

    '    gidRS.Close()
    '    MsgBox("done")
    'End Sub

    'Private Sub StripZeroToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StripZeroToolStripMenuItem.Click
    '    Dim gidRS As ADODB.Recordset, x As Integer, thisDocRef As String, pos1 As Integer, pos2 As Integer, rcpt_no As String, chq_no As String, new_chq_no As String, newDocRef As String

    '    ssql = "select * from tbljournal where DocRef like '%Cheque No=0%'"
    '    gidRS = gcon.Execute(ssql)

    '    While gidRS.EOF = False
    '        chq_no = ""
    '        thisDocRef = Trim(gidRS("DocRef").Value.ToString)
    '        '======
    '        pos1 = InStr(1, thisDocRef, "Cheque No=")
    '        If pos1 <> 0 Then
    '            chq_no = myRight(thisDocRef, Len(thisDocRef) - pos1 - 10 + 1)
    '            new_chq_no = stripLeadingZero(chq_no)
    '            newDocRef = Replace(thisDocRef, chq_no, new_chq_no)
    '            gcon.Execute("update tbljournal set DocRef='" & newDocRef & "' where gid='" & gidRS("gid").Value.ToString & "'")
    '        End If
    '        gidRS.MoveNext()
    '    End While

    '    gidRS.Close()
    '    MsgBox("done")
    'End Sub

    'Private Sub AsasaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AsasaToolStripMenuItem.Click
    '    Dim aa As New clsDocRef
    '    Dim kk As String
    '    kk = aa.getFlatCode("(Receipt No:102, Cheque No: 052442, Cheque Date: 25-Feb-2012, Payee:SAP07D)")
    'End Sub


    Private Sub tsmiSyncOwnerDetailsFromPortal_Click(sender As System.Object, e As System.EventArgs) Handles tsmiSyncOwnerDetailsFromPortal.Click
        Dim pSql As String = "", fmSql As String = "", pRS As ADODB.Recordset
        Dim commAddress As String, fl1 As String, fl2 As String, fl3 As String, fl4 As String, fl5 As String, fl6 As String, em1 As String, em2 As String, mb1 As String, mb2 As String, land1 As String, stayInComplex As String, billPref As String


        'standard entry check code start
        gItemCode = "tsmiSyncOwnerDetailsFromPortal"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = "frmMain"
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end

        pSql = "select c.cb_apartment1 ,c.cb_apartment2 ,c.cb_apartment3 ,c.cb_apartment4 ,c.cb_apartment5 ,c.cb_apartment6"
        pSql = pSql & ",c.cb_stayingincomplex,c.cb_communicationaddress,c.cb_billpref,u.email,c.cb_secondaryemail ,c.cb_landline,c.cb_mobile1,c.cb_mobile2"
        pSql = pSql & "  from joomla25schema.j25_users u, joomla25schema.j25_comprofiler c "
        pSql = pSql & " where u.id = c.user_id and u.block=0 and c.confirmed=1"

        pRS = gcon.Execute(pSql)

        While pRS.EOF = False

            fl1 = pRS("cb_apartment1").Value.ToString
            fl2 = pRS("cb_apartment2").Value.ToString
            fl3 = pRS("cb_apartment3").Value.ToString
            fl4 = pRS("cb_apartment4").Value.ToString
            fl5 = pRS("cb_apartment5").Value.ToString
            fl6 = pRS("cb_apartment6").Value.ToString
            billPref = pRS("cb_billpref").Value.ToString
            stayInComplex = pRS("cb_stayingincomplex").Value.ToString
            commAddress = pRS("cb_communicationaddress").Value.ToString
            em1 = pRS("email").Value.ToString
            em2 = pRS("cb_secondaryemail").Value.ToString
            mb1 = pRS("cb_mobile1").Value.ToString
            mb2 = pRS("cb_mobile2").Value.ToString
            land1 = pRS("cb_landline").Value.ToString


            fmSql = " Update tblflatowners set usingPortal='Y'"
            If InStr(billPref, "Soft") > 0 Then
                fmSql = fmSql & ",p_softBill='Y'"
            Else
                fmSql = fmSql & ",p_softBill=NULL"
            End If
            If UCase(stayInComplex) = "YES" Then
                fmSql = fmSql & ",p_stayingInComplex='Y'"
            Else
                fmSql = fmSql & ",p_stayingInComplex=NULL"
            End If
            If commAddress <> "" Then
                fmSql = fmSql & ",FullCommunicationAddress='" & Replace(commAddress, "'", "''") & "'"
            End If
            If em1 <> "" Then
                fmSql = fmSql & ",p_email1='" & em1 & "'"
            End If
            If em2 <> "" Then
                fmSql = fmSql & ",p_email2='" & em2 & "'"
            End If
            If mb1 <> "" Then
                fmSql = fmSql & ",p_mobile1='" & mb1 & "'"
            End If
            If mb2 <> "" Then
                fmSql = fmSql & ",p_mobile2='" & mb2 & "'"
            End If
            If land1 <> "" Then
                fmSql = fmSql & ",p_landline1='" & land1 & "'"
            End If

            fmSql = fmSql & " where IsActiveOwner='Y' and ("
            fmSql = fmSql & " FlatCode='" & fl1 & "'"
            If fl2 <> "" Then
                fmSql = fmSql & " OR FlatCode='" & fl2 & "'"
            End If
            If fl3 <> "" Then
                fmSql = fmSql & " OR FlatCode='" & fl3 & "'"
            End If
            If fl4 <> "" Then
                fmSql = fmSql & " OR FlatCode='" & fl4 & "'"
            End If
            If fl5 <> "" Then
                fmSql = fmSql & " OR FlatCode='" & fl5 & "'"
            End If
            If fl6 <> "" Then
                fmSql = fmSql & " OR FlatCode='" & fl6 & "'"
            End If
            fmSql = fmSql & ")"

            gcon.Execute(fmSql)
            fmSql = ""

            pRS.MoveNext()
        End While

        MsgBox("Synchronisation complete")
    End Sub

   

    
   
    Private Sub tsmiShowTemporaryReceipts_Click(sender As System.Object, e As System.EventArgs) Handles tsmiShowTemporaryReceipts.Click
        dlgShowTempReceipts.ShowDialog()
    End Sub

    
    Private Sub tsmiPerformBilling_Click(sender As System.Object, e As System.EventArgs) Handles tsmiPerformBilling.Click
        If isAllowedToViewModule("frmPerformBilling") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmPerformBilling
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub
   
    Private Sub tsmiAccessManager_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAccessManager.Click

        If isAllowedToViewModule("frmAccessManager") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmAccessManager
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiGeneratePWD_Click(sender As System.Object, e As System.EventArgs) Handles tsmiGeneratePWD.Click
        frmGeneratePassword.ShowDialog()
        frmGeneratePassword.Dispose()
    End Sub

    Private Sub tsmiReconcileBankStatement_Click(sender As System.Object, e As System.EventArgs) Handles tsmiReconcileBankStatement.Click
        If isAllowedToViewModule("frmBankReconcile") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmBankReconcile
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiJournalBankStatement_Click(sender As System.Object, e As System.EventArgs) Handles tsmiJournalBankStatement.Click
        If isAllowedToViewModule("frmJournalBankStatement") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmJournalBankStatement
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    

    

    Private Sub tsmiBillMailer_Click(sender As System.Object, e As System.EventArgs) Handles tsmiBillMailer.Click
        If isAllowedToViewModule("frmBillMailer") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmBillMailer
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiBookReceipt_Click(sender As System.Object, e As System.EventArgs) Handles tsmiBookReceipt.Click
        If isAllowedToViewModule("frmBookReceipt") = False Then Exit Sub

        'reset flatcode
        gCurFlatCode = ""

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmBookReceipt
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiViewReceipt_Click(sender As System.Object, e As System.EventArgs) Handles tsmiViewReceipt.Click
        If isAllowedToViewModule("frmViewReceipt") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmViewReceipt
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiSearchFlatOwner_Click(sender As System.Object, e As System.EventArgs) Handles tsmiSearchFlatOwner.Click
        If isAllowedToViewModule("frmSearchFlat") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmSearchFlat
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
        gItemCode = gOldItemCode
    End Sub

    Private Sub tsmiCOAReports_Click(sender As System.Object, e As System.EventArgs) Handles tsmiCOAReports.Click
        If isAllowedToViewModule("frmCOAReport") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmCOAReport
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
        gItemCode = gOldItemCode
    End Sub

    Private Sub tsmiDefaulterListBGF_Click(sender As System.Object, e As System.EventArgs) Handles tsmiDefaulterListBGF.Click
        'standard entry check code start
        gOldItemCode = gItemCode
        gItemCode = "tsmiDefaulterList"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = gOldItemCode
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end

        Dim myReport As New clsReport

        myReport.genDefaulterReport(0, "BGF")
    End Sub

    Private Sub tsmiDefaulterListAssociation_Click(sender As System.Object, e As System.EventArgs) Handles tsmiDefaulterListAssociation.Click
        'standard entry check code start
        gOldItemCode = gItemCode
        gItemCode = "tsmiDefaulterList"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = gOldItemCode
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end

        Dim myReport As New clsReport

        myReport.genDefaulterReport(0, "ASSOCIATION")
    End Sub

    

    Private Sub tsmiParking_Click(sender As System.Object, e As System.EventArgs) Handles tsmiParking.Click
        If isAllowedToViewModule("frmParking") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmParking
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
        gItemCode = gOldItemCode
    End Sub

    Private Sub tsmiCharting_Click(sender As System.Object, e As System.EventArgs) Handles tsmiCharting.Click
        If isAllowedToViewModule("frmCharting") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmCharting
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
        gItemCode = gOldItemCode
    End Sub

    Private Sub tsmiBackDateEntry_Click(sender As Object, e As EventArgs) Handles tsmiBackDateEntry.Click
        If gLoginID <> "sa" Then Exit Sub
        If gAllowBackDateEntry = False Then
            gAllowBackDateEntry = True
            tsmiBackDateEntry.Text = "Disable Back Date Entry"
        Else
            gAllowBackDateEntry = False
            tsmiBackDateEntry.Text = "Enable Back Date Entry"
        End If
    End Sub
    Private Sub tsmiFutureDateEntry_Click(sender As Object, e As EventArgs) Handles tsmiFutureDateEntry.Click
        'If gLoginID <> "sa" Then Exit Sub
        If gAllowFutureDateEntry = False Then
            gAllowFutureDateEntry = True
            tsmiFutureDateEntry.Text = "Disable Future Date Entry"
        Else
            gAllowFutureDateEntry = False
            tsmiFutureDateEntry.Text = "Enable Future Date Entry"
        End If
    End Sub
    Private Sub tsmiManageReceiptBook_Click(sender As Object, e As EventArgs) Handles tsmiManageReceiptBook.Click
        If isAllowedToViewModule("frmManageReceiptBook") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmManageReceiptBook
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
        gItemCode = gOldItemCode
    End Sub

    Private Sub tsmiManageChequeBook_Click(sender As Object, e As EventArgs) Handles tsmiManageChequeBook.Click
        If isAllowedToViewModule("frmManageChequeBook") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmManageChequeBook
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
        gItemCode = gOldItemCode
    End Sub

  
    Private Sub tsmiManagePayment_Click(sender As Object, e As EventArgs) Handles tsmiManagePayment.Click
        If isAllowedToViewModule("frmManagePayment") = False Then Exit Sub
        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmManagePayment
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiCashBook_WithSummary_Click(sender As Object, e As EventArgs) Handles tsmiCashBook_WithSummary.Click

        If isAllowedToViewModule("tsmiCashBook") = False Then Exit Sub
        Dim myReport As New clsReport
        myReport.genCASHBANKBOOKReport("CASHBOX", True)

    End Sub

    Private Sub tsmiCashBook_WithoutSummary_Click(sender As Object, e As EventArgs) Handles tsmiCashBook_WithoutSummary.Click

        If isAllowedToViewModule("tsmiCashBook") = False Then Exit Sub
        Dim myReport As New clsReport
        myReport.genCASHBANKBOOKReport("CASHBOX", True)

    End Sub

    Function isAllowedToViewModule(moduleName As String) As Boolean
        'standard entry check code start
        isAllowedToViewModule = False
        gItemCode = moduleName
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = "frmMain"
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Function
        End If
        isAllowedToViewModule = True
        'standard entry check code end
    End Function


    Private Sub tsmiBankBook_Sav_WithSummary_Click(sender As Object, e As EventArgs) Handles tsmiBankBook_Sav_WithSummary.Click
        If isAllowedToViewModule("tsmiBankBook") = False Then Exit Sub
        Dim myReport As New clsReport
        myReport.genCASHBANKBOOKReport("BANK-SIBL0000656053000002552", True)
    End Sub

    Private Sub tsmiBankBook_Sav_WithoutSummary_Click(sender As Object, e As EventArgs) Handles tsmiBankBook_Sav_WithoutSummary.Click
        If isAllowedToViewModule("tsmiBankBook") = False Then Exit Sub
        Dim myReport As New clsReport
        myReport.genCASHBANKBOOKReport("BANK-SIBL0000656053000002552", False)
    End Sub

    Private Sub tsmiBankBook_Cur_WithSummary_Click(sender As Object, e As EventArgs) Handles tsmiBankBook_Cur_WithSummary.Click
        If isAllowedToViewModule("tsmiBankBook") = False Then Exit Sub
        Dim myReport As New clsReport
        myReport.genCASHBANKBOOKReport("BANK-SIBL0000656073000000009", True)
    End Sub

    Private Sub tsmiBankBook_Cur_WithoutSummary_Click(sender As Object, e As EventArgs) Handles tsmiBankBook_Cur_WithoutSummary.Click
        If isAllowedToViewModule("tsmiBankBook") = False Then Exit Sub
        Dim myReport As New clsReport
        myReport.genCASHBANKBOOKReport("BANK-SIBL0000656073000000009", False)
    End Sub

    Private Sub tsmiManageTenants_Click(sender As Object, e As EventArgs) Handles tsmiManageTenants.Click
        If isAllowedToViewModule("frmManageTenant") = False Then Exit Sub
        'launch form
        If createNewForm("frmManageTenant") = True Then
            Dim frm As New frmManageTenant
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub


    Private Sub tsmiExpenseReport_WithSummary_Click(sender As Object, e As EventArgs) Handles tsmiExpenseReport_WithSummary.Click
        If isAllowedToViewModule("tsmiExpenseReport") = False Then Exit Sub
        Dim myReport As New clsReport
        myReport.genExpenseReport(True)
    End Sub

    Private Sub tsmiExpenseReport_WithoutSummary_Click(sender As Object, e As EventArgs) Handles tsmiExpenseReport_WithoutSummary.Click
        If isAllowedToViewModule("tsmiExpenseReport") = False Then Exit Sub
        Dim myReport As New clsReport
        myReport.genExpenseReport(False)
    End Sub

    Private Sub tsmiManageInventory_Click(sender As Object, e As EventArgs) Handles tsmiManageInventory.Click
        If isAllowedToViewModule("frmManageInventory") = False Then Exit Sub
        'launch form
        If createNewForm("frmManageInventory") = True Then
            Dim frm As New frmManageInventory
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiMiscCharting_Click(sender As Object, e As EventArgs) Handles tsmiMiscCharting.Click

        If isAllowedToViewModule("frmMiscCharting") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmMiscCharting
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
        gItemCode = gOldItemCode
    End Sub

    Private Sub tsmiManageServiceCase_Click(sender As Object, e As EventArgs) Handles tsmiManageServiceCase.Click
        If isAllowedToViewModule("frmManageServiceCase") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmManageServiceCase
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
        gItemCode = gOldItemCode
    End Sub

    Sub ShowOpenCaseCountInNotificationTray()
        Dim tmpRS As ADODB.Recordset, cnt As Integer
        tmpRS = gcon.Execute("select count(*) as cnt from tblservicerequest where (Status='NEW' or Status='OPEN')")
        cnt = CInt("0" & tmpRS("cnt").Value.ToString)
        tmpRS.Close()

        NotifyIcon4OpenCases.Text = "Open Cases: " & cnt
        NotifyIcon4OpenCases.BalloonTipText = "Open Cases: " & cnt
        NotifyIcon4OpenCases.Visible = True
    End Sub

    Private Sub Timer4OpenCases_Tick(sender As Object, e As EventArgs) Handles Timer4OpenCases.Tick
        ShowOpenCaseCountInNotificationTray()
    End Sub

    Private Sub tsmiManageVoucherBook_Click(sender As Object, e As EventArgs) Handles tsmiManageVoucherBook.Click
        If isAllowedToViewModule("frmManageVoucherBook") = False Then Exit Sub
        'launch form
        If createNewForm("frmManageVoucherBook") = True Then
            Dim frm As New frmManageVoucherBook
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub


    Private Sub tsmiManageSystemParameter_Click(sender As Object, e As EventArgs) Handles tsmiManageSystemParameter.Click
        If isAllowedToViewModule("frmManageSysParams") = False Then Exit Sub
        'launch form
        If createNewForm("frmManageSysParams") = True Then
            Dim frm As New frmManageSysParams
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

   
    Private Sub tsmiReceiptsPaymentsReport_Click(sender As Object, e As EventArgs) Handles tsmiReceiptsPaymentsReport.Click
        Dim myReport As New clsAuditReports
        myReport.genRPReport()
    End Sub

    Private Sub tsmiIncomeExpenseReport_Click(sender As Object, e As EventArgs) Handles tsmiIncomeExpenseReport.Click
        Dim myReport As New clsAuditReports
        myReport.genIEReport()
    End Sub

    Private Sub tsmiBalanceSheet_Click(sender As Object, e As EventArgs) Handles tsmiBalanceSheet.Click
        Dim myReport As New clsAuditReports
        myReport.genBSReport()
    End Sub

    Private Sub tsmiNewBankBook_Click(sender As Object, e As EventArgs) Handles tsmiNewBankBook.Click
        If isAllowedToViewModule("tsmiBankBook") = False Then Exit Sub
        gParentReportAccount = "CASH-AT-BANK"
        dlgSelReportAccount.ShowDialog()
        dlgSelReportAccount.Dispose()
        Dim myReport As New clsReport
        gOrgCaption = Me.Text
        myReport.genCASHBANKBOOKReportNew(Me, gSelectedReportAccount, "BANKBOOK", "MAINTENANCE")
        Me.Text = gOrgCaption
    End Sub

    Private Sub tsmiNewCashBook_Click(sender As Object, e As EventArgs) Handles tsmiNewCashBook.Click
        If isAllowedToViewModule("tsmiCashBook") = False Then Exit Sub
        gParentReportAccount = "CASH-IN-HAND"
        dlgSelReportAccount.ShowDialog()
        dlgSelReportAccount.Dispose()
        Dim myReport As New clsReport
        gOrgCaption = Me.Text
        myReport.genCASHBANKBOOKReportNew(Me, gSelectedReportAccount, "CASHBOOK", "MAINTENANCE")
        Me.Text = gOrgCaption
    End Sub

    Private Sub tsmiBookReceiptCultural_Click(sender As Object, e As EventArgs) Handles tsmiBookReceiptCultural.Click
        If isAllowedToViewModule("frmBookReceiptCultural") = False Then Exit Sub

        'reset flatcode
        gCurFlatCode = ""

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmBookReceiptCultural
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiViewReceiptCultural_Click(sender As Object, e As EventArgs) Handles tsmiViewReceiptCultural.Click
        If isAllowedToViewModule("frmViewReceiptCultural") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmViewReceiptCultural
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiSpecialTransactions_Click(sender As Object, e As EventArgs) Handles tsmiSpecialTransactions.Click
        If isAllowedToViewModule("frmJournalSpecialTxns") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmJournalSpecialTxns
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiManagePaymentCultural_Click(sender As Object, e As EventArgs) Handles tsmiManagePaymentCultural.Click
        If isAllowedToViewModule("frmManagePaymentCultural") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmManagePaymentCultural
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    

    Private Sub tsmiReconcileBankStatementCultural_Click(sender As Object, e As EventArgs) Handles tsmiReconcileBankStatementCultural.Click
        If isAllowedToViewModule("frmBankReconcileCultural") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmBankReconcileCultural
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiJournalBankStatementCultural_Click(sender As Object, e As EventArgs) Handles tsmiJournalBankStatementCultural.Click
        If isAllowedToViewModule("frmJournalBankStatementCultural") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmJournalBankStatementCultural
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiShowFlatDetails_Click(sender As Object, e As EventArgs) Handles tsmiShowFlatDetails.Click

        If isAllowedToViewModule("frmShowFlatDetails") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmShowFlatDetails
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub tsmiCashBookCultural_Click(sender As Object, e As EventArgs) Handles tsmiCashBookCultural.Click
        If isAllowedToViewModule("tsmiCashBookCultural") = False Then Exit Sub
        gParentReportAccount = "CASH-IN-HAND-CULT"
        dlgSelReportAccount.ShowDialog()
        dlgSelReportAccount.Dispose()
        Dim myReport As New clsReport
        gOrgCaption = Me.Text
        myReport.genCASHBANKBOOKReportNew(Me, gSelectedReportAccount, "CASHBOOK", "CULTURAL")
        Me.Text = gOrgCaption
    End Sub

    Private Sub tsmiBankBookCultural_Click(sender As Object, e As EventArgs) Handles tsmiBankBookCultural.Click
        If isAllowedToViewModule("tsmiBankBookCultural") = False Then Exit Sub
        gParentReportAccount = "CASH-AT-BANK-CULT"
        dlgSelReportAccount.ShowDialog()
        dlgSelReportAccount.Dispose()
        Dim myReport As New clsReport
        gOrgCaption = Me.Text
        myReport.genCASHBANKBOOKReportNew(Me, gSelectedReportAccount, "BANKBOOK", "CULTURAL")
        Me.Text = gOrgCaption
    End Sub

    Private Sub tsmiBalanceSheetCultural_Click(sender As Object, e As EventArgs) Handles tsmiBalanceSheetCultural.Click
        Dim myReport As New clsAuditReportsCultural
        myReport.genBSReport()
    End Sub

    Private Sub tsmiIncomeExpenseReportCultural_Click(sender As Object, e As EventArgs) Handles tsmiIncomeExpenseReportCultural.Click
        Dim myReport As New clsAuditReportsCultural
        myReport.genIEReport()
    End Sub

    Private Sub tsmiReceiptsPaymentsReportCultural_Click(sender As Object, e As EventArgs) Handles tsmiReceiptsPaymentsReportCultural.Click
        Dim myReport As New clsAuditReportsCultural
        myReport.genRPReport()
    End Sub

    Private Sub tsmiSpecialTransactionsCultural_Click(sender As Object, e As EventArgs) Handles tsmiSpecialTransactionsCultural.Click
        If isAllowedToViewModule("frmJournalSpecialTxnsCultural") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmJournalSpecialTxnsCultural
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub TransactionDrillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransactionDrillToolStripMenuItem.Click
        'If isAllowedToViewModule("frmTxnDrill") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmTxnDrill
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub BalanceSheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BalanceSheetToolStripMenuItem.Click
        'If isAllowedToViewModule("frmBalanceSheet") = False Then Exit Sub

        'launch form
        If createNewForm(gItemCode) = True Then
            Dim frm As New frmBalanceSheet
            frm.MdiParent = Me
            frm.Show()
            frm.WindowState = FormWindowState.Minimized
            frm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    
    Private Sub tsmiExpenseReportCult_WithSummary_Click(sender As Object, e As EventArgs) Handles tsmiExpenseReportCult_WithSummary.Click
        'If isAllowedToViewModule("tsmiExpenseReportCult") = False Then Exit Sub
        Dim myReport As New clsReport_Cult
        myReport.genExpenseReportCult(True)
    End Sub

    Private Sub tsmiExpenseReportCult_WithoutSummary_Click(sender As Object, e As EventArgs) Handles tsmiExpenseReportCult_WithoutSummary.Click
        'If isAllowedToViewModule("tsmiExpenseReportCult") = False Then Exit Sub
        Dim myReport As New clsReport_Cult
        myReport.genExpenseReportCult(False)
    End Sub
End Class
