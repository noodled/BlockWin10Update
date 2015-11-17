Public Class Main

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Command Line Arguments handler
        Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        If CommandLineArgs.Count = 0 Then
            GUI.Show()
            Close()
        Else
            If CommandLineArgs.Contains("-log") Then
                GUI.doLog = True
                GUI.Show()
                Close()
            ElseIf CommandLineArgs.Contains("-unblock") Then
                GUI.doUnBlock()
                Application.Exit()
            ElseIf CommandLineArgs.Contains("-block") Then
                GUI.doBlock()
                Application.Exit()
            Else
                GUI.Show()
                Close()

            End If
        End If
    End Sub
End Class