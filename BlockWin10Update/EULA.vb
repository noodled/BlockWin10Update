Imports Microsoft.Win32

Public Class EULA

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

#Region "Setup Stuff"
    ''' <summary>
    ''' The registry path for controling the value
    ''' </summary>
    Public RegPath As String = "SOFTWARE\HiF\BlockWin10Update"
#End Region

    Private Sub EULACB_CheckedChanged() Handles EULACB.CheckedChanged
        Select Case EULACB.CheckState
            Case CheckState.Unchecked
                accept.Enabled = False
            Case CheckState.Checked
                accept.Enabled = True
        End Select
    End Sub

    Private Sub decline_Click(sender As Object, e As EventArgs) Handles decline.Click
        Application.Exit()
    End Sub

    Private Sub accept_Click(sender As Object, e As EventArgs) Handles accept.Click
        Try
            'Create the sub key
            Registry.CurrentUser.CreateSubKey(RegPath)

            Static Key As Object = Registry.CurrentUser.OpenSubKey(RegPath, True)
            Key.SetValue("EULA", "1", RegistryValueKind.String)
            Key.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()

        End Try
        Main.Show()
        Close()
    End Sub
End Class