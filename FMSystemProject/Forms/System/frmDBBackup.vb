Public Class frmDBBackup
    Private Sub frmDBBackup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ofdSelectFile.InitialDirectory = getSysParamValue("PATH_DB_BACKUP")
        fbdSelectFolder.RootFolder = Environment.SpecialFolder.MyComputer

        controlFieldStatus()
        txtBackupPath.Text = "D:\GFHPortal\Backup\db"

    End Sub

    Sub loadTables()
        lstTableFrom.Items.Clear()
        tmpRS = gcon.Execute("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA= 'gfhdb'")
        While tmpRS.EOF = False
            lstTableFrom.Items.Add(tmpRS("TABLE_NAME").Value.ToString)
            tmpRS.MoveNext()
        End While
    End Sub


    Private Sub btnSingleMove_Click(sender As System.Object, e As System.EventArgs) Handles btnSingleMove.Click
        If lstTableFrom.Items.Count = 0 Then Exit Sub
        If lstTableFrom.SelectedIndex < 0 Then lstTableFrom.SelectedIndex = 0

        lstTableTo.Items.Add(lstTableFrom.SelectedItem.ToString)
        lstTableFrom.Items.Remove(lstTableFrom.SelectedItem)
        lstTableTo.Sorted = True
    End Sub

    Private Sub btnSingleReverseMove_Click(sender As System.Object, e As System.EventArgs) Handles btnSingleReverseMove.Click
        If lstTableTo.Items.Count = 0 Then Exit Sub
        If lstTableTo.SelectedIndex < 0 Then lstTableTo.SelectedIndex = 0

        lstTableFrom.Items.Add(lstTableTo.SelectedItem.ToString)
        lstTableTo.Items.Remove(lstTableTo.SelectedItem)
        lstTableFrom.Sorted = True
    End Sub

    Private Sub btnAllMove_Click(sender As System.Object, e As System.EventArgs) Handles btnAllMove.Click
        Dim x As Integer
        For x = 1 To lstTableFrom.Items.Count
            lstTableTo.Items.Add(lstTableFrom.Items(x - 1))
        Next
        lstTableFrom.Items.Clear()
        lstTableTo.Sorted = True
    End Sub

    Private Sub btnAllReverseMove_Click(sender As System.Object, e As System.EventArgs) Handles btnAllReverseMove.Click
        Dim x As Integer
        For x = 1 To lstTableTo.Items.Count
            lstTableFrom.Items.Add(lstTableTo.Items(x - 1))
        Next
        lstTableTo.Items.Clear()
        lstTableFrom.Sorted = True
    End Sub

    Private Sub btnBackup_Click(sender As System.Object, e As System.EventArgs) Handles btnBackup.Click
        If optBackupSelective.Checked = True Then
            If lstTableTo.Items.Count = 0 Then
                MsgBox("No table selected")
                Exit Sub
            End If
        End If

        If txtBackupPath.Text = "" Then
            MsgBox("No backup path selected")
            Exit Sub
        End If
        performBackup()
    End Sub


    Sub performBackup()
        On Error GoTo errH

        Dim x As Integer, strTableList As String = ""
        For x = 1 To lstTableTo.Items.Count
            strTableList = strTableList & " " & lstTableTo.Items(x - 1).ToString
        Next

        Dim myBackup As New clsBackupRestore
        myBackup.BackupDir = txtBackupPath.Text

        If optBackupFull.Checked = True Then
            myBackup.FullDBBackup()
        ElseIf optBackupSelective.Checked = True Then
            myBackup.TableList = strTableList
            myBackup.SelectiveTableBackup()
        End If

        MsgBox("done")
        Exit Sub
errH:
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Private Sub btnRestore_Click(sender As System.Object, e As System.EventArgs) Handles btnRestore.Click
        If txtRestoreFile.Text = "" Then
            MsgBox("No restore file selected")
            Exit Sub
        End If
        performRestore()
    End Sub

    Sub performRestore()
        On Error GoTo errH

        Dim myRestore As New clsBackupRestore
        myRestore.RestoreFileName = txtRestoreFile.Text
        myRestore.Restore()

        MsgBox("done")
        Exit Sub
errH:
        If Err.Description <> "" Then MsgBox(Err.Description)
    End Sub

    Private Sub btnSelectRestorePath_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectRestorePath.Click
        If ofdSelectFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim flInfo As New System.IO.FileInfo(ofdSelectFile.FileName)
        If flInfo.Length = 0 Then
            MsgBox("File size is zero")
            Exit Sub
        End If
        If flInfo.Extension <> ".sql" Then
            MsgBox("Invalid file extension. Should be .sql")
            Exit Sub
        End If

        txtRestoreFile.Text = ofdSelectFile.FileName

    End Sub

    Private Sub btnSelectBackupPath_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectBackupPath.Click
        If fbdSelectFolder.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        txtBackupPath.Text = fbdSelectFolder.SelectedPath
    End Sub

    Private Sub optBackup_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optBackupFull.CheckedChanged
        controlFieldStatus()
    End Sub

    Private Sub optRestore_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optRestore.CheckedChanged
        controlFieldStatus()
    End Sub

    Sub controlFieldStatus()
        If optBackupFull.Checked = True Then
            btnBackup.Enabled = True
            btnRestore.Enabled = False

            btnSelectBackupPath.Enabled = True
            btnSelectRestorePath.Enabled = False

            lstTableFrom.Enabled = False
            lstTableTo.Enabled = False
            lstTableFrom.Items.Clear()
            lstTableTo.Items.Clear()

            btnAllMove.Enabled = False
            btnAllReverseMove.Enabled = False
            btnSingleMove.Enabled = False
            btnSingleReverseMove.Enabled = False

        ElseIf optBackupSelective.Checked = True Then
            btnBackup.Enabled = True
            btnRestore.Enabled = False

            btnSelectBackupPath.Enabled = True
            btnSelectRestorePath.Enabled = False

            lstTableFrom.Enabled = True
            lstTableTo.Enabled = True

            btnAllMove.Enabled = True
            btnAllReverseMove.Enabled = True
            btnSingleMove.Enabled = True
            btnSingleReverseMove.Enabled = True

            loadTables()

        ElseIf optRestore.Checked = True Then
            btnBackup.Enabled = False
            btnRestore.Enabled = True

            btnSelectBackupPath.Enabled = False
            btnSelectRestorePath.Enabled = True

            lstTableFrom.Enabled = False
            lstTableTo.Enabled = False
            lstTableFrom.Items.Clear()
            lstTableTo.Items.Clear()

            btnAllMove.Enabled = False
            btnAllReverseMove.Enabled = False
            btnSingleMove.Enabled = False
            btnSingleReverseMove.Enabled = False

        End If
    End Sub

End Class