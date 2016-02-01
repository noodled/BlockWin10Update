Public Class InfoBox

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


    ''' <summary>
    ''' Displays the form with information for the user,
    ''' StandardSound as boolean.
    ''' </summary>
    Public Sub Display(info As String, StandardSound As Boolean)

        Show()
        RichTextBox1.Text = info

        If StandardSound = True Then
            My.Computer.Audio.Play(My.Resources.spy_specialcompleted12, AudioPlayMode.Background)
        End If
    End Sub
End Class