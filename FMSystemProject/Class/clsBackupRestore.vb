Public Class clsBackupRestore

    Dim CommandString As String
    Public BackupDir As String
    Public RestoreFileName As String
    Public TableList As String
    Public outBackupFileName As String

    Public Sub New()
        CommandString = ""
        BackupDir = ""
        RestoreFileName = ""
        TableList = ""
    End Sub

    Public Sub FullDBBackup()
        On Error GoTo errH
        Dim cmdStr As String, db_tbl_str As String = "", uidpwdStr As String = ""

        If System.IO.Directory.Exists(BackupDir) = False Then System.IO.Directory.CreateDirectory(BackupDir)

        'Take FM DB backup
        db_tbl_str = " --databases " & getSysParamValue("DB_NAME_FM")
        outBackupFileName = BackupDir & "\" & DateTime.Now.ToString("dd-MMM-yy_HH-mm") & "_" & Application.ProductName & "_fulldb_backup.sql"

        uidpwdStr = "-u " & getSysParamValue("RESU") & " -p" & getSysParamValue("DWP")
        CommandString = "mysqldump --max_allowed_packet=1G --host=" & getSysParamValue("DB_HOST") & " " & uidpwdStr & " --lock-tables=FALSE --add-locks=FALSE --port=" & getSysParamValue("DB_PORT") & " --default-character-set=utf8" & db_tbl_str & " > " & outBackupFileName

        ExecuteMySqlCommand()

        'Take Portal DB backup
        db_tbl_str = " --databases " & getSysParamValue("DB_NAME_PORTAL")
        outBackupFileName = BackupDir & "\" & DateTime.Now.ToString("dd-MMM-yy_HH-mm") & "_" & "Portal" & "_fulldb_backup.sql"

        uidpwdStr = "-u " & getSysParamValue("RESU") & " -p" & getSysParamValue("DWP")
        CommandString = "mysqldump --max_allowed_packet=1G --host=" & getSysParamValue("DB_HOST") & " " & uidpwdStr & " --lock-tables=FALSE --add-locks=FALSE --port=" & getSysParamValue("DB_PORT") & " --default-character-set=utf8" & db_tbl_str & " > " & outBackupFileName

        ExecuteMySqlCommand()

        Exit Sub
errH:
        If Err.Description <> "" Then MsgBox(Err.Description)

    End Sub

    Public Sub SelectiveTableBackup()
        On Error GoTo errH
        Dim cmdStr As String, db_tbl_str As String = "", uidpwdStr As String = ""

        If System.IO.Directory.Exists(BackupDir) = False Then System.IO.Directory.CreateDirectory(BackupDir)
        db_tbl_str = " " & getSysParamValue("DB_NAME_FM") & " " & Trim(TableList)
        outBackupFileName = BackupDir & "\" & DateTime.Now.ToString("dd-MMM-yy_HH-mm") & "_" & Application.ProductName & "_selectivetable_backup.sql"

        uidpwdStr = "--user=" & getSysParamValue("RESU") & " -p" & getSysParamValue("DWP")
        CommandString = "mysqldump --max_allowed_packet=1G --host=" & getSysParamValue("DB_HOST") & " " & uidpwdStr & " --lock-tables=FALSE --add-locks=FALSE --port=" & getSysParamValue("DB_PORT") & " --default-character-set=utf8" & db_tbl_str & " > " & outBackupFileName

        ExecuteMySqlCommand()

        Exit Sub
errH:
        If Err.Description <> "" Then MsgBox(Err.Description)

    End Sub

    Public Sub Restore()
        On Error GoTo errH
        Dim uidpwdStr As String = ""

        uidpwdStr = "-u " & getSysParamValue("RESU") & " -p" & getSysParamValue("DWP")
        CommandString = "mysql --max_allowed_packet=1G -h " & getSysParamValue("DB_HOST") & " " & uidpwdStr & " -P " & getSysParamValue("DB_PORT") & " --default-character-set=utf8 -D " & getSysParamValue("DB_NAME_FM") & " < " & RestoreFileName

        ExecuteMySqlCommand()

        Exit Sub
errH:
        If Err.Description <> "" Then MsgBox(Err.Description)

    End Sub

    Private Sub ExecuteMySqlCommand()
        On Error GoTo errH

        Dim strm As System.IO.Stream
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = "cmd.exe"
        myProcess.StartInfo.UseShellExecute = False
        myProcess.StartInfo.WorkingDirectory = getSysParamValue("PATH_MYSQL")
        myProcess.StartInfo.RedirectStandardInput = True
        myProcess.StartInfo.RedirectStandardOutput = True
        myProcess.Start()
        Dim myStreamWriter As System.IO.StreamWriter = myProcess.StandardInput
        Dim mystreamreader As System.IO.StreamReader = myProcess.StandardOutput

        myStreamWriter.WriteLine(CommandString)
        myStreamWriter.Close()
        myProcess.WaitForExit()
        myProcess.Close()

        Exit Sub
errH:
        If Err.Description <> "" Then MsgBox(Err.Description)
        myProcess.Close()
    End Sub
End Class
