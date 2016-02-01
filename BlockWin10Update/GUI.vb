Imports System.IO
Imports System.Net
Imports System.Threading
Imports Microsoft.Win32

Public Class GUI

    'BlockWin10Update - Blocks the Windows 10 Update tray icon.
    'Copyright (C) 2016 Hawaii_Beach

    'This program Is free software: you can redistribute it And/Or modify
    'it under the terms Of the GNU General Public License As published by
    'the Free Software Foundation, either version 3 Of the License, Or
    '(at your option) any later version.

    'This program Is distributed In the hope that it will be useful,
    'but WITHOUT ANY WARRANTY; without even the implied warranty Of
    'MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE.  See the
    'GNU General Public License For more details.

    'You should have received a copy Of the GNU General Public License
    'along with this program.  If Not, see <http://www.gnu.org/licenses/>.


    'Application Name: BlockWin10Update
    'Description: Prevent "Get Windows 10" icon in tray from launching.
    'Release Date (YYYY-MM-DD): 2015-11-11

    'NOTES:
    'possible errorlevels:
    '1:  Error adding to registry
    '2: other error, retry without launch args
    '0: sucessful


#Region "Setup Stuff"
    ''' <summary>
    ''' URI to fetch update data from 
    ''' </summary>
    Public UpdateURI As String = "http://raw.githubusercontent.com/ElPumpo/BlockWin10Update/master/BlockWin10Update/Resources/version"

    ''' <summary>
    ''' Decides which radio is enabled
    ''' </summary>
    Public isBlocked As Boolean

    ''' <summary>
    ''' The registry path for controling the value
    ''' </summary>
    Protected RegPath As String = "SOFTWARE\Policies\Microsoft\Windows\GWX"

    ''' <summary>
    ''' Reads from UpdateURI, switched to integer
    ''' </summary>
    Private OnlineVer As Integer

    ''' <summary>
    ''' current verison, switched to integer
    ''' </summary>
    Private OfflineVer As Integer = 1102

    ''' <summary>
    ''' Boolean if UpdateURI couldn't be reached
    ''' </summary>
    Private ErrorExists As Boolean = False

    ''' <summary>
    ''' Current WinVer
    ''' </summary>
    Private WinVer As String

    ''' <summary>
    ''' Is it a recommended WinVer?
    ''' </summary>
    Private isRecommendedWinVer As Boolean

    ''' <summary>
    ''' Logs to log.txt?
    ''' </summary>
    Public doLog As Boolean

    ''' <summary>
    ''' Name of log file
    ''' </summary>
    Private LogFileName As String

    ''' <summary>
    ''' Is it the first time the logger logs?
    ''' </summary>
    Private isFirstTime As Boolean = True

#End Region

    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click
        Application.Exit()
    End Sub 'Exit

    Private Sub GUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opacity = 0.0
        My.Computer.Audio.Play(My.Resources.spy_uncloak_feigndeath, AudioPlayMode.Background)

        'fade in animation
        For i = 0.0 To 10.0 Step 0.01
            If Opacity < 1.0 Then
                Opacity += 0.01
                Thread.Sleep(10)
            End If
        Next


        'Debug
        Log("BlockWin10Update Booting . . .", True, True)

        CheckWinVer()

        Try
            Dim keyTest As RegistryKey
            keyTest = Registry.LocalMachine.OpenSubKey(RegPath, True)
            If keyTest Is Nothing Then

                If isRecommendedWinVer = True Then
                    'is kb installed
                    My.Computer.Audio.Play(My.Resources.spy_taunts13, AudioPlayMode.Background)
                    InfoBox.Display("Insure that KB3035583 is installed! If you haven't seen the white Windows icon in your traybar, then this application isn't for you. I just may solved your issue, try blocking and it should work.", False)
                    Log("Tried to create required subkey, issue may be solved.", True, True)

                    'Try to solve the issue
                    Try
                        My.Computer.Registry.LocalMachine.CreateSubKey(RegPath)

                    Catch ex As Exception
                        My.Computer.Audio.Play(My.Resources.spy_jeers02, AudioPlayMode.Background)
                        MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK)
                        Environment.Exit(2)

                    End Try
                End If
            End If

        Catch ex As Exception
            'ignore

        End Try

        Try

            Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey(RegPath)
            Dim TheValue As Object = key.GetValue("DisableGWX")
            key.Close()

            'Convert to boolean
            If TheValue = 1 Then
                isBlocked = True
            Else
                isBlocked = False
            End If

        Catch ex As NullReferenceException
            'If registry doesn't found the key/s
            isBlocked = False

        Catch ex As Exception
            My.Computer.Audio.Play(My.Resources.spy_jeers02, AudioPlayMode.Background)
            MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK)
            Environment.Exit(2)

        End Try

        If isBlocked = True Then
            uRadio.Enabled = False
        Else unRadio.Enabled = False
        End If

        CheckForUpdate()

    End Sub 'Fade In

    Private Sub ApplyBtn_Click(sender As Object, e As EventArgs) Handles ApplyBtn.Click
        ApplyBtn.Enabled = False
        ExitBtn.Enabled = False

        'Unblock
        If unRadio.Checked = True Then

            doUnBlock()

            isBlocked = False
            ExitBtn.Enabled = True
            unRadio.Enabled = False
            uRadio.Enabled = False
            My.Computer.Audio.Play(My.Resources.spy_cheers01, AudioPlayMode.Background)
            InfoBox.Display("Done! Reboot to take effect.", False)
            Log("Done!", True, True)

            'Block
        ElseIf uRadio.Checked = True Then
            doBlock()

            isBlocked = True
            ExitBtn.Enabled = True
            unRadio.Enabled = False
            uRadio.Enabled = False
            My.Computer.Audio.Play(My.Resources.spy_cheers01, AudioPlayMode.Background)
            InfoBox.Display("Done! Reboot to take effect.", False)
            Log("Done!", True, True)

        Else
            My.Computer.Audio.Play(My.Resources.spy_Revenge03, AudioPlayMode.Background)
            InfoBox.Display("You must select a radio!", False)
            ApplyBtn.Enabled = True
            ExitBtn.Enabled = True
        End If

    End Sub 'Apply

    Private Sub Home_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Close InfoBox.vb
        Log("Shutting down", True, True)
        InfoBox.Close()

        My.Computer.Audio.Play(My.Resources.spy_uncloak, AudioPlayMode.Background)

        'fade out animation
        e.Cancel = True
        Timer2.Enabled = True
        For i = 0.0 To 10.0 Step 0.01
            If Opacity > 0.0 Then
                Opacity -= 0.01
                Thread.Sleep(10)
            End If
        Next

    End Sub 'Fade Out

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Opacity < 1.0 Then
            Opacity += 0.01
        Else
            Timer1.Enabled = False
        End If
    End Sub 'Fade in timer

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Opacity > 0.0 Then
            Opacity -= 0.01
        Else Timer2.Enabled = False
            End
        End If
    End Sub 'Fade out timer

    Private Sub CheckForUpdate()
        Try
            'Debug
            Log("-----UPDATE CHECKER-----", False, True)
            Log(Nothing, True, False)
            Log("Checking for Updates . . .", True, True)

            'Start request
            Dim theRequest As HttpWebRequest = HttpWebRequest.Create(UpdateURI)
            theRequest.Timeout = 10000 '10sec timeout
            Dim theResponce As HttpWebResponse = theRequest.GetResponse()
            Dim readFile As StreamReader = New StreamReader(theResponce.GetResponseStream())
            OnlineVer = readFile.ReadToEnd.Trim()
            readFile.Close()
            theResponce.Close()

        Catch ex As Exception
            'Letting itself know that it cannot reach to the server
            Log("Could not search for updates!", True, True)
            OnlineVer = Nothing
            ErrorExists = True

        End Try

        'IF start
        If ErrorExists = False Then
            If OnlineVer = OfflineVer Then
                Log("Client is up to date", True, True)

            Else

                If OfflineVer > OnlineVer Then
                    Log("OfflineVer is greater than OnlineVer!", True, True)
                End If

                If OnlineVer < OfflineVer Then
                    Log("Client is up to date", True, True)
                Else

                    Log("Update available", True, True)
                    My.Computer.Audio.Play(My.Resources.spy_specialcompleted12, AudioPlayMode.Background)

                    Dim result As Integer = MessageBox.Show("A update is available, update now?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        'User pressed YES
                        My.Computer.Audio.Play(My.Resources.spy_battlecry03, AudioPlayMode.Background)
                        Process.Start("https://github.com/ElPumpo/BlockWin10Update/releases")
                    Else
                        My.Computer.Audio.Play(My.Resources.spy_cheers04, AudioPlayMode.Background)

                    End If
                End If
            End If
            'IF end
        End If
        Log("OnlineVer: " + OnlineVer.ToString, True, True)
        Log("OfflineVer: " + OfflineVer.ToString, True, True)
        Log("----UPDATE CHECKER END--", False, True)
        Log(Nothing, True, False)

    End Sub 'Check for Update

    Private Sub CheckWinVer()

        Dim WinVerOriginal As String = My.Computer.Info.OSFullName

        'Windows 10
        If WinVerOriginal.Contains("10") Then
            WinVer = "10"
            isRecommendedWinVer = False

            'Windows 8.1
        ElseIf WinVerOriginal.Contains("8.1") Then
            WinVer = "8.1"
            isRecommendedWinVer = True

            'Windows 8
        ElseIf WinVerOriginal.Contains("8") Then
            WinVer = "8"
            isRecommendedWinVer = False

            'Windows 7
        ElseIf WinVerOriginal.Contains("7") Then
            WinVer = "7"
            isRecommendedWinVer = True

            'Windows Vista
        ElseIf WinVerOriginal.Contains("Vista") Then
            WinVer = "Vista"
            isRecommendedWinVer = False

        Else
            WinVer = "Unknown"
            isRecommendedWinVer = False
        End If

        If isRecommendedWinVer = False Then

            InfoBox.Display("You're running a non-recommended version of Windows; the application may not work as expected, use at your own risk!", True)

        End If

        If WinVerOriginal.Contains("Enterprise") Then
            InfoBox.Display("You're running a Enterprise build! You cannot upgrade to Windows 10, please contact your IT-administrator.", True)
            WinVer = WinVer + " Enterprise"
            isRecommendedWinVer = False
        End If

        Log("WinVer: " + WinVer, True, True)

    End Sub 'Checks the Windows version

    Public Sub Log(Information As String, WriteToConsole As Boolean, WriteToFile As Boolean)

        If WriteToFile = True Then
            If doLog = True Then

                'If log file already exists
                If isFirstTime = True Then
                    LogFileName = "BlockWin10Update " + Date.Now.ToString("yyyy/MM/dd") + ".log"
                    If File.Exists(LogFileName) Then
                        LogFileName = "BlockWin10Update " + Date.Now.ToString("yyyy/MM/dd HH-mm-ss") + ".log"
                    End If
                    isFirstTime = False
                End If

                Try

                    My.Computer.FileSystem.WriteAllText(LogFileName, Information, True)
                    My.Computer.FileSystem.WriteAllText(LogFileName, Environment.NewLine, True)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Environment.Exit(2)

                End Try
            End If
        End If

        If WriteToConsole = True Then
            Console.WriteLine(Information)
        End If
    End Sub 'Log, to console and/ or log file

    Public Sub doBlock()
        Try
            Dim key = My.Computer.Registry.LocalMachine.OpenSubKey(RegPath, True)
            key.SetValue("DisableGWX", "1", RegistryValueKind.DWord)
            key.Close()

        Catch ex As Exception
            My.Computer.Audio.Play(My.Resources.spy_jeers02, AudioPlayMode.Background)
            MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            If Main.isCommandLine = 1 Then
                Environment.Exit(1)
            Else Application.Exit()
            End If

        End Try
    End Sub 'Blocks update

    Public Sub doUnBlock()
        Try
            Dim key = My.Computer.Registry.LocalMachine.OpenSubKey(RegPath, True)
            key.DeleteValue("DisableGWX")
            key.Close()

        Catch ex As Exception
            My.Computer.Audio.Play(My.Resources.spy_jeers02, AudioPlayMode.Background)
            MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            If Main.isCommandLine = 1 Then
                Environment.Exit(1)
            Else Application.Exit()
            End If

        End Try
    End Sub 'Unblocks update

End Class
