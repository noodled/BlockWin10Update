Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports Microsoft.Win32

Public Class Main

#Region "Setup Stuff"
    ''' <summary>
    ''' URI to fetch update data from 
    ''' </summary>
    Public UpdateURI As String = "http://raw.githubusercontent.com/ElPumpo/BlockWin10Update/master/BlockWin10Update/Resources/version"

    ''' <summary>
    ''' Value of DisableGWX in registry
    ''' </summary>
    Private TheValue As Object

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
    Private OfflineVer As Integer = 1004

    ''' <summary>
    ''' Boolean if UpdateURI couldn't be reached
    ''' </summary>
    Private ErrorExists As Boolean = False

    ''' <summary>
    ''' Current WinVer
    ''' </summary>
    Private WinVer As Integer

    ''' <summary>
    ''' Is it a recommended WinVer?
    ''' </summary>
    Private RecommendedWinVer As Boolean

#End Region

    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click
        Application.Exit()
    End Sub 'Exit

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0.0
        My.Computer.Audio.Play(My.Resources.spy_uncloak_feigndeath, AudioPlayMode.Background)

        'fade in animation
        For i = 0.0 To 10.0 Step 0.01
            If Me.Opacity < 1.0 Then
                Me.Opacity += 0.01
                Threading.Thread.Sleep(10)
            End If
        Next

        'Debug
        Console.WriteLine("BlockWin10Update Booting..")

        CheckWinVer()

        Try
            Dim keyTest As RegistryKey
            keyTest = Registry.LocalMachine.OpenSubKey(RegPath, True)
            If keyTest Is Nothing Then

                If RecommendedWinVer = True Then
                    'is kb installed
                    My.Computer.Audio.Play(My.Resources.spy_taunts13, AudioPlayMode.Background)
                    InfoBox.Display("Insure that KB3035583 is installed! If you haven't seen the white Windows icon in your traybar, then google your issue, and please let the developer know.", False)
                End If
            End If

        Catch ex As Exception
            'shh

        End Try

        Try
            Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey(RegPath)
            TheValue = key.GetValue("DisableGWX")
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
            Application.Exit()

        End Try

        If isBlocked = True Then
            uRadio.Enabled = False
        Else
            unRadio.Enabled = False
        End If

        CheckForUpdate()

    End Sub 'Fade In

    Private Sub ApplyBtn_Click(sender As Object, e As EventArgs) Handles ApplyBtn.Click
        ApplyBtn.Enabled = False
        ExitBtn.Enabled = False

        'Unblock
        If unRadio.Checked = True Then
            Try
                Dim key2 = My.Computer.Registry.LocalMachine.OpenSubKey(RegPath, True)
                key2.SetValue("DisableGWX", "0", RegistryValueKind.DWord)
                key2.Close()

            Catch ex As Exception
                My.Computer.Audio.Play(My.Resources.spy_jeers02, AudioPlayMode.Background)
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()

            End Try
            isBlocked = False
            ExitBtn.Enabled = True
            unRadio.Enabled = False
            uRadio.Enabled = False
            My.Computer.Audio.Play(My.Resources.spy_cheers01, AudioPlayMode.Background)
            InfoBox.Display("Done! Reboot to take effect.", False)

            'Block
        ElseIf uRadio.Checked = True
            Try
                Dim key3 = My.Computer.Registry.LocalMachine.OpenSubKey(RegPath, True)
                key3.SetValue("DisableGWX", "1", RegistryValueKind.DWord)
                key3.Close()

            Catch ex As Exception
                My.Computer.Audio.Play(My.Resources.spy_jeers02, AudioPlayMode.Background)
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()

            End Try
            isBlocked = True
            ExitBtn.Enabled = True
            unRadio.Enabled = False
            uRadio.Enabled = False
            My.Computer.Audio.Play(My.Resources.spy_cheers01, AudioPlayMode.Background)
            InfoBox.Display("Done! Reboot to take effect.", False)

        Else
            My.Computer.Audio.Play(My.Resources.spy_Revenge03, AudioPlayMode.Background)
            InfoBox.Display("You must select a radio!", False)
            ApplyBtn.Enabled = True
            ExitBtn.Enabled = True
        End If

    End Sub 'Apply

    Private Sub Home_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Close InfoBox.vb
        InfoBox.Close()

        My.Computer.Audio.Play(My.Resources.spy_uncloak, AudioPlayMode.Background)

        'fade out animation
        e.Cancel = True
        Timer2.Enabled = True
        For i = 0.0 To 10.0 Step 0.01
            If Me.Opacity > 0.0 Then
                Me.Opacity -= 0.01
                Threading.Thread.Sleep(10)
            End If
        Next

    End Sub 'Fade Out

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Me.Opacity < 1.0 Then
            Me.Opacity += 0.01
        Else
            Timer1.Enabled = False
        End If
    End Sub 'Fade in timer

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If Me.Opacity > 0.0 Then
            Me.Opacity -= 0.01
        Else
            Timer2.Enabled = False
            End
        End If
    End Sub 'Fade out timer

    Private Sub CheckForUpdate()
        Try
            'Debug
            Console.WriteLine()
            Console.WriteLine("Checking for Updates..")
            Dim Request As HttpWebRequest = HttpWebRequest.Create(UpdateURI)
            Request.Timeout = 10000
            Dim responce As HttpWebResponse = Request.GetResponse()
            Dim ReadText As StreamReader = New StreamReader(responce.GetResponseStream())
            OnlineVer = ReadText.ReadToEnd.Trim()
            ReadText.Close()
            responce.Close()

        Catch ex As Exception
            'Letting itself know that it cannot reach to the server
            Console.WriteLine("Could not search for updates")
            OnlineVer = Nothing
            ErrorExists = True

        End Try

        'IF start
        If ErrorExists = False Then
            If OnlineVer = OfflineVer Then
                Console.WriteLine("Client is up to date")

            Else

                If OfflineVer > OnlineVer Then
                    Console.WriteLine("OfflineVer is greater than OnlineVer!")
                End If

                If OnlineVer < OfflineVer Then
                    Console.WriteLine("Client is up to date")
                Else

                    Console.WriteLine("Update available")
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
        'debug
        Console.WriteLine("OnlineVer: " + OnlineVer.ToString)
        Console.WriteLine("OfflineVer: " + OfflineVer.ToString)
    End Sub 'Check for Update

    Private Sub CheckWinVer()
        'Problems with this approach: Windows Vista nor XP cannot be identified as we remove all chars

        'Setup Stuff
        Dim WinVerTrimmed As String
        Dim WinVerOriginal As String = My.Computer.Info.OSFullName
        Dim rgx = New Regex("[a-zA-Z .]")

        'Remove all chars and only keep number
        WinVerTrimmed = rgx.Replace(WinVerOriginal, "")
        WinVerTrimmed.Trim()
        WinVer = Convert.ToInt32(WinVerTrimmed)

        Console.WriteLine("WinVer: " + WinVer.ToString)

        If WinVer = 10 Then
            RecommendedWinVer = False
            InfoBox.Display("You're running Windows 10, do not expect the application to work!", True)

        ElseIf WinVer = 81 Then
            RecommendedWinVer = True

        ElseIf WinVer = 8 Then
            RecommendedWinVer = False
            InfoBox.Display("You're running Windows 8, do not expect the application to work!", True)

        ElseIf WinVer = 7 Then
            RecommendedWinVer = True
        Else
            RecommendedWinVer = False
            InfoBox.Display("You're running a unknown Windows version: " + WinVer.ToString + "! If you belive this is a mistake, please contact the developer! Do not expect the application to work!", True)

        End If
    End Sub

End Class
