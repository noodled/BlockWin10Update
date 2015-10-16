Public Class InfoBox
    Private Sub InfoBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub Display(info As String)
        Show()
        RichTextBox1.Text = info
    End Sub
End Class