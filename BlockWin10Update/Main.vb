Imports Microsoft.Win32

Public Class Main

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


    Public isCommandLine As Boolean = False


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForEULA()
    End Sub

    Private Sub CheckForEULA()
        Try
            If Registry.CurrentUser.OpenSubKey(EULA.RegPath) Is Nothing Then
                EULA.Show()
                Close()
            Else
                Static Key As Object = Registry.CurrentUser.OpenSubKey(EULA.RegPath)
                Static KeyString As String = Key.GetValue("EULA")
                Key.Close()

                'Checks if value is 1
                If Not KeyString = "1" Then
                    EULA.Show()
                    Close()
                Else
                    CheckForArgs()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()

        End Try
    End Sub

    Private Sub CheckForArgs()
        'Command line argument handler
        Dim CommandLineArgs As ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs

        If CommandLineArgs.Count = 0 Then
            GUI.Show()
            Close()
        Else
            If CommandLineArgs.Contains("-log") Then
                GUI.doLog = True
                GUI.Show()
                Close()
            ElseIf CommandLineArgs.Contains("-unblock") Then
                isCommandLine = True
                GUI.doUnBlock()
                Environment.Exit(7)
            ElseIf CommandLineArgs.Contains("-block") Then
                isCommandLine = True
                GUI.doBlock()
                Environment.Exit(7)
            Else
                GUI.Show()
                Close()

            End If
        End If
    End Sub

End Class