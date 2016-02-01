<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EULA
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EULA))
        Me.decline = New System.Windows.Forms.Button()
        Me.accept = New System.Windows.Forms.Button()
        Me.EULACB = New System.Windows.Forms.CheckBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'decline
        '
        Me.decline.Location = New System.Drawing.Point(12, 296)
        Me.decline.Name = "decline"
        Me.decline.Size = New System.Drawing.Size(75, 23)
        Me.decline.TabIndex = 0
        Me.decline.Text = "Decline"
        Me.decline.UseVisualStyleBackColor = True
        '
        'accept
        '
        Me.accept.Enabled = False
        Me.accept.Location = New System.Drawing.Point(93, 296)
        Me.accept.Name = "accept"
        Me.accept.Size = New System.Drawing.Size(75, 23)
        Me.accept.TabIndex = 1
        Me.accept.Text = "Proceed"
        Me.accept.UseVisualStyleBackColor = True
        '
        'EULACB
        '
        Me.EULACB.AutoSize = True
        Me.EULACB.Location = New System.Drawing.Point(12, 251)
        Me.EULACB.Name = "EULACB"
        Me.EULACB.Size = New System.Drawing.Size(231, 21)
        Me.EULACB.TabIndex = 2
        Me.EULACB.Text = "I accept this License Agreement"
        Me.EULACB.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 12)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(622, 233)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'EULA
        '
        Me.AcceptButton = Me.decline
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 331)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.EULACB)
        Me.Controls.Add(Me.accept)
        Me.Controls.Add(Me.decline)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EULA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HiF - EULA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents decline As Button
    Friend WithEvents accept As Button
    Friend WithEvents EULACB As CheckBox
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
