Public Class InfoBox

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