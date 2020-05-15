Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class frmMain

    Dim NewUpdateAvailable As Boolean = False
    Dim NewUpdateVersion As String = ""
    Dim DownloadLink As String = ""

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'lblStatus.Text = "Checking for update ..." : lblStatus.ForeColor = Color.Gray
            CheckForIllegalCrossThreadCalls = False

            If File.Exists(Environment.CurrentDirectory + "\OBU_Settings.txt") Then Call LoadSettings()
            If txtOBLocation.Text <> "" Then
                Me.Height = 360
                lblStatus.Text = "Checking for update ..." : lblStatus.ForeColor = Color.Gray
                Dim login As New Thread(AddressOf CheckForUpdate)
                login.Start()
            Else
                Me.Height = 525
                lblStatus.Text = "------" : lblStatus.ForeColor = Color.Gray
                gpSettings.Enabled = True
                btnExeLocation.Select()
            End If
        Catch ex As Exception
            Me.Height = 525
            txtLog.Text = ""
            lblStatus.Text = "------" : lblStatus.ForeColor = Color.Gray
            btnUpdate.Text = "Check for Update" : btnUpdate.Enabled = False
            gpSettings.Enabled = True
            btnExeLocation.Select()
        End Try
    End Sub





    Private Sub mnuSettings_Click(sender As Object, e As EventArgs) Handles mnuSettings.Click
        Me.Height = 525
        gpSettings.Enabled = True
        btnExeLocation.Select()
    End Sub

    Private Sub mnuSkipUpdate_Click(sender As Object, e As EventArgs) Handles mnuSkipUpdate.Click
        If txtOBLocation.Text <> "" Then
            If File.Exists(txtOBLocation.Text) Then
                Call RunOpenBullet()
                Application.Exit()
            End If
        End If
    End Sub

    Friend WithEvents downloader As WebClient
    Private Sub downloader_DownloadProgressChanged(sender As Object, e As System.Net.DownloadProgressChangedEventArgs) Handles downloader.DownloadProgressChanged
        PBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub downloader_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles downloader.DownloadFileCompleted
        Call UpdateOB_2()
    End Sub

    Private Sub btnExeLocation_Click(sender As Object, e As EventArgs) Handles btnExeLocation.Click
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.DefaultExt = "exe"
        ofd.FileName = "OpenBullet.exe"
        ofd.Filter = "Exe file|*.exe"
        ofd.Title = "Select OpenBullet.exe file"
        While True
            If ofd.ShowDialog() <> DialogResult.Cancel Then
                Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(ofd.FileName)
                If myFileVersionInfo.ProductName = "OpenBullet" Then 'Check if correct OpenBullet exe selected
                    txtOBLocation.Text = ofd.FileName
                    txtOBLocation.Select()
                    txtOBLocation.SelectionStart = txtOBLocation.Text.Length()
                    'save in OBU_Settings.txt
                    Exit While
                Else
                    MessageBox.Show("Wrong OpenBullet exe file !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    btnExeLocation.Select()
                End If
            Else
                Exit While
            End If
        End While
    End Sub

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        If txtOBLocation.Text <> "" Then
            Call SaveSettings()
            btnUpdate.Enabled = True
            btnUpdate.Text = "Check for Update"
            lblStatus.Text = "------" : lblStatus.ForeColor = Color.Gray
            gpSettings.Enabled = False
            txtLog.Text = ""
            Me.Height = 360
        Else
            MessageBox.Show("Please identify OpenBullet's file location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnExeLocation.Select()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        btnUpdate.Enabled = False
        If txtOBLocation.Text = "" Then
            Me.Height = 525
            lblStatus.Text = "------" : lblStatus.ForeColor = Color.Gray
            gpSettings.Enabled = True
            btnExeLocation.Select()
        End If
        If btnUpdate.Text = "Check for Update" Then
            Me.Height = 360
            lblStatus.Text = "Checking for update ..." : lblStatus.ForeColor = Color.Gray
            Dim login As New Thread(AddressOf CheckForUpdate)
            login.Start()
        Else
            PBar1.Visible = True
            Dim login As New Thread(AddressOf UpdateOB_1)
            login.Start()
        End If
    End Sub

    Sub CheckForUpdate()
        Try
            btnUpdate.Enabled = False
            DownloadLink = ""
            txtLog.Text = ""

            ' Sending a GET request for github
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As HttpWebRequest = HttpWebRequest.Create("https://github.com/openbullet/openbullet/releases")
            Dim response As HttpWebResponse = request.GetResponse()
            Dim sReader As StreamReader = New StreamReader(response.GetResponseStream)
            Dim result As String = sReader.ReadToEnd()

            Dim matchHS_DownloadLink As Match = Regex.Match(result, ">Latest release<\/a>\s+<\/span>\s+<\/div>\s+<ul class="".*"">\s+<li class="".*"">\s+<a href=""\/.*\/tree\/(.*)"" class="".*"" title=""(.*)"">", RegexOptions.IgnoreCase)
            If txtCurrentVersion.Text = matchHS_DownloadLink.Groups(2).Value Then
                Call RunOpenBullet()
                Application.Exit()
                Exit Sub
            End If
            If matchHS_DownloadLink.Groups(1).Value <> "" Then
                NewUpdateVersion = matchHS_DownloadLink.Groups(2).Value
                If matchHS_DownloadLink.Groups(2).Value <> txtCurrentVersion.Text Then
                    DownloadLink = "https://github.com/openbullet/openbullet/releases/download/" + matchHS_DownloadLink.Groups(1).Value + "/OpenBullet.zip"
                Else
                    txtLog.Text = "You have the latest version of OB"
                    Exit Sub
                End If
            Else
                btnUpdate.Enabled = True
                btnUpdate.Text = "Check for Update"
                lblStatus.Text = "Unable to retrieve info from github !!" : lblStatus.ForeColor = Color.Gray
                Exit Sub
            End If
            Dim matchHS1 As Match = Regex.Match(result, "<li class=""d-block mb-1"">\s+<a href="".*\/tree\/(.*)"" class=""muted-link css-truncate"" title=""(.*)"">", RegexOptions.IgnoreCase) '((.*?|\n)*?)
            Dim matchHS2 As Match = Regex.Match(result, "<relative-time datetime="".*"" class=""no-wrap"">(.*)<\/relative-time>\s+<\/p>\s+<\/div>\s+<div class=""commit-desc"">\s+<pre class=""text-small text-gray"">([\s|\S]*?)<\/pre>\s+<\/div>", RegexOptions.IgnoreCase)
            While matchHS1.Success
                If matchHS1.Groups(2).Value <> txtCurrentVersion.Text Then

                    txtLog.Text += "============================" + vbNewLine
                    txtLog.Text += "v" + matchHS1.Groups(2).Value + "  (" + matchHS2.Groups(1).Value + "):" + vbNewLine
                    txtLog.Text += vbNewLine

                    'Seperate update logs that are more than one line with single line ones
                    Dim matchHS3 As Match = Regex.Match(matchHS2.Groups(2).Value, "^(.*)?", RegexOptions.Multiline)
                    While matchHS3.Success
                        If matchHS3.Groups(1).Value <> "" Then
                            txtLog.Text += "   - " + matchHS3.Groups(1).Value + vbNewLine
                        End If
                        matchHS3 = matchHS3.NextMatch
                    End While
                    txtLog.Text += vbNewLine

                    NewUpdateAvailable = True
                    mnuSkipUpdate.Enabled = True
                    lblStatus.Text = "New Update Available" : lblStatus.ForeColor = Color.Green
                    btnUpdate.Enabled = True : btnUpdate.Text = "Update" : btnUpdate.Select()

                Else : Exit While : End If
                matchHS1 = matchHS1.NextMatch
                matchHS2 = matchHS2.NextMatch
            End While
        Catch ex As Exception
            If txtOBLocation.Text <> "" Then
                If File.Exists(txtOBLocation.Text) Then
                    MessageBox.Show("An error occured, trying to run OpenBullet ...", "Error")
                    Call RunOpenBullet()
                    Application.Exit()
                Else
                    MessageBox.Show("An error occured:" + vbNewLine + vbNewLine + ex.Message, "Error")
                End If
            End If
        End Try
    End Sub

    Sub UpdateOB_1()
        lblStatus.ForeColor = Color.RoyalBlue
        lblStatus.Text = "Downloading update ..."
        downloader = New WebClient
        downloader.DownloadFileAsync(New Uri(DownloadLink), "OBU_update.zip")
    End Sub

    Sub UpdateOB_2()
        Try
            If File.Exists("OBU_update.zip") Then
                Dim OBDirectory As New IO.FileInfo(txtOBLocation.Text) ' Getting OB path

                ' Extracting
                lblStatus.Text = "Extracting ..."
                If Directory.Exists("OBU_update") Then Directory.Delete("OBU_update", True)
                ZipFile.ExtractToDirectory("OBU_update.zip", "OBU_update")
                Thread.Sleep(1500)

                ' Closing OB
                lblStatus.Text = "Closing OpenBullet ..."
                Dim pProcess() As Process = Process.GetProcessesByName(Path.GetFileNameWithoutExtension("OpenBullet"))
                For Each p As Process In pProcess
                    If p.MainWindowTitle.Contains("Anomaly") = False Then 'Avoid closing anomaly version of OB
                        p.Kill()
                    End If
                Next
                Thread.Sleep(500)


                ' Keeping Environment.ini _1
                Dim EnvironmentContent As String = ""
                If chkNotUpdateEnviromentINI.Checked Then
                    If File.Exists(OBDirectory.DirectoryName + "\Settings\Environment.ini") Then
                        EnvironmentContent = IO.File.ReadAllText(OBDirectory.DirectoryName + "\Settings\Environment.ini")
                    End If
                End If
                Thread.Sleep(500)

                ' Moving update files
                lblStatus.Text = "Updating files ..."
                Dim cm As String = "ROBOCOPY " + Chr(34) + Environment.CurrentDirectory + "\OBU_update\Release" + Chr(34) + " " + Chr(34) + OBDirectory.DirectoryName + Chr(34) + " /E /IS /MOVE"
                Call RunCommandCom(cm, "", True) 'Running CMD command for copying update files

                ' Removing additional Files
                lblStatus.Text = "Clearing temp items ..."
                For i = 1 To 10 ' 10 tries to remove the files
                    If Directory.Exists(Environment.CurrentDirectory + "\OBU_update\Release") Then : Thread.Sleep(500)
                    Else : Exit For : End If
                Next
                Directory.Delete(Environment.CurrentDirectory + "\OBU_update", True)
                File.Delete(Environment.CurrentDirectory + "\OBU_update.zip")
                Thread.Sleep(500)

                ' Keeping Environment.ini _2
                If chkNotUpdateEnviromentINI.Checked Then
                    If EnvironmentContent <> "" Then IO.File.WriteAllText(OBDirectory.DirectoryName + "\Settings\Environment.ini", EnvironmentContent)
                End If
                Thread.Sleep(500)

                ' Saving Settings
                If NewUpdateVersion <> "" Then txtCurrentVersion.Text = NewUpdateVersion
                Thread.Sleep(200)
                Call SaveSettings()

                ' Running OpenBullet
                lblStatus.Text = "Running OpenBullet ..."
                Call RunOpenBullet()

                Application.Exit()
            End If

            btnUpdate.Enabled = True
            lblStatus.Text = "New update available" : lblStatus.ForeColor = Color.Green
            PBar1.Visible = False
        Catch ex As Exception
            btnUpdate.Enabled = True
            mnuSkipUpdate.Enabled = True
            lblStatus.Text = "New update available" : lblStatus.ForeColor = Color.Green
            PBar1.Visible = False
        End Try
    End Sub

    Sub RunCommandCom(command As String, arguments As String, permanent As Boolean)
        ' Run CMD Commands (Using this for copying update files)
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = " " + If(permanent = True, "/K", "/C") + " " + command + " " + arguments
        pi.FileName = "cmd.exe"
        pi.WindowStyle = ProcessWindowStyle.Hidden 'hidden mode
        p.StartInfo = pi
        p.Start()
    End Sub

    Sub SaveSettings()
        Dim MySettings As String = ""
        If txtOBLocation.Text <> "" Then
            MySettings += "OpenBullet_Location=" + txtOBLocation.Text + vbNewLine
            MySettings += "Current_Version=" + txtCurrentVersion.Text + vbNewLine
            MySettings += "Keep_My_Environment.ini=" + chkNotUpdateEnviromentINI.Checked.ToString
            IO.File.WriteAllText(Environment.CurrentDirectory + "\OBU_Settings.txt", MySettings)
        End If
    End Sub

    Sub LoadSettings()
        If File.Exists(Environment.CurrentDirectory + "\OBU_Settings.txt") Then
            For Each line As String In IO.File.ReadAllLines(Environment.CurrentDirectory + "\OBU_Settings.txt")
                Dim txt() As String = line.Split("=")
                Select Case txt(0)
                    Case "OpenBullet_Location"
                        txtOBLocation.Text = txt(1)
                    Case "Current_Version"
                        txtCurrentVersion.Text = txt(1)
                    Case "Keep_My_Environment.ini"
                        chkNotUpdateEnviromentINI.Checked = Convert.ToBoolean(txt(1))
                End Select
            Next
            Thread.Sleep(200)
        End If
    End Sub

    Sub RunOpenBullet()
        If File.Exists(txtOBLocation.Text) Then
            Dim OBDirectory As New IO.FileInfo(txtOBLocation.Text) ' Getting OB path
            Dim procStartInfo As New ProcessStartInfo
            Dim procExecuting As New Process
            With procStartInfo
                .UseShellExecute = True
                .FileName = txtOBLocation.Text
                .WindowStyle = ProcessWindowStyle.Normal
                .WorkingDirectory = OBDirectory.DirectoryName ' Avoiding this line will cause OB to throw an error when trying to run (because it tries to find it's executable's dependencies in your updater directory, In case you don't have your Updater in OB directory)
            End With
            procExecuting = Process.Start(procStartInfo)
        End If
        Thread.Sleep(200)
    End Sub


End Class
