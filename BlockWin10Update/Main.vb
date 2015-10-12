Imports System.IO
Imports System.Net
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
    Private OfflineVer As Integer = 1002

    ''' <summary>
    ''' Boolean if UpdateURI couldn't be reached
    ''' </summary>
    Private ErrorExists As Boolean = False

#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub 'Exit

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0.0
        My.Computer.Audio.Play(My.Resources.spy_uncloak_feigndeath, AudioPlayMode.Background)


        For i = 0.0 To 10.0 Step 0.01
            If Me.Opacity < 1.0 Then
                Me.Opacity += 0.01
                Threading.Thread.Sleep(10)
            End If
        Next


        Try
            Dim keyTest As RegistryKey
            keyTest = Registry.LocalMachine.OpenSubKey(RegPath, True)
            If keyTest Is Nothing Then

                My.Computer.Audio.Play(My.Resources.spy_taunts13, AudioPlayMode.Background)
                MessageBox.Show("You're not running Windows 7 or 8.1, if you are then insure that KB3035583 is installed.", "INFO", MessageBoxButtons.OK)
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

        'debug
        Console.WriteLine("OnlineVer: " + OnlineVer.ToString)
        Console.WriteLine("OfflineVer: " + OfflineVer.ToString)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Enabled = False
        Button1.Enabled = False

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
            Button1.Enabled = True
            unRadio.Enabled = False
            uRadio.Enabled = False
            My.Computer.Audio.Play(My.Resources.spy_cheers01, AudioPlayMode.Background)
            MessageBox.Show("Done! Reboot to take effect.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
            Button1.Enabled = True
            unRadio.Enabled = False
            uRadio.Enabled = False
            My.Computer.Audio.Play(My.Resources.spy_cheers01, AudioPlayMode.Background)
            MessageBox.Show("Done! Reboot to take effect.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            My.Computer.Audio.Play(My.Resources.spy_Revenge03, AudioPlayMode.Background)
            MessageBox.Show("You must select a radio!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Button2.Enabled = True
            Button1.Enabled = True
        End If

    End Sub 'Apply

    Private Sub Home_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Computer.Audio.Play(My.Resources.spy_uncloak, AudioPlayMode.Background)
        e.Cancel = True
        Timer2.Enabled = True

        For i = 0.0 To 10.0 Step 0.01
            If Me.Opacity > 0.0 Then
                Me.Opacity -= 0.01
                Threading.Thread.Sleep(10)
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Me.Opacity < 1.0 Then
            Me.Opacity += 0.01
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If Me.Opacity > 0.0 Then
            Me.Opacity -= 0.01
        Else
            Timer2.Enabled = False
            End
        End If
    End Sub

    Private Sub CheckForUpdate()
        Try
            Dim Request As HttpWebRequest = HttpWebRequest.Create(UpdateURI)
            Request.Timeout = 10000
            Dim responce As HttpWebResponse = Request.GetResponse()
            Dim ReadText As StreamReader = New StreamReader(responce.GetResponseStream())
            OnlineVer = ReadText.ReadToEnd()
            ReadText.Close()
            responce.Close()

        Catch ex As Exception
            'Letting itself know that it cannot reach to the server
            Console.WriteLine("Could not search for update")
            ErrorExists = True

        End Try

        If ErrorExists = False Then
            If OnlineVer = OfflineVer Then
                Console.WriteLine("Client is up to date")

            Else

                'Starts here
                If OnlineVer < OfflineVer Then
                    Console.WriteLine("Client is up to date")
                Else

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
            'Ends here
        End If
    End Sub 'Check for Update

End Class
