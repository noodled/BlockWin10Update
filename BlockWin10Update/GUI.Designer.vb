<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GUI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GUI))
        Me.ExitBtn = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ApplyBtn = New System.Windows.Forms.Button()
        Me.unRadio = New System.Windows.Forms.RadioButton()
        Me.uRadio = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExitBtn
        '
        Me.ExitBtn.Location = New System.Drawing.Point(6, 115)
        Me.ExitBtn.Name = "ExitBtn"
        Me.ExitBtn.Size = New System.Drawing.Size(65, 28)
        Me.ExitBtn.TabIndex = 2
        Me.ExitBtn.Text = "Exit"
        Me.ExitBtn.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(308, 229)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ApplyBtn)
        Me.TabPage1.Controls.Add(Me.ExitBtn)
        Me.TabPage1.Controls.Add(Me.unRadio)
        Me.TabPage1.Controls.Add(Me.uRadio)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(300, 200)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ApplyBtn
        '
        Me.ApplyBtn.Location = New System.Drawing.Point(6, 81)
        Me.ApplyBtn.Name = "ApplyBtn"
        Me.ApplyBtn.Size = New System.Drawing.Size(65, 28)
        Me.ApplyBtn.TabIndex = 4
        Me.ApplyBtn.Text = "Apply"
        Me.ApplyBtn.UseVisualStyleBackColor = True
        '
        'unRadio
        '
        Me.unRadio.AutoSize = True
        Me.unRadio.Location = New System.Drawing.Point(6, 6)
        Me.unRadio.Name = "unRadio"
        Me.unRadio.Size = New System.Drawing.Size(80, 21)
        Me.unRadio.TabIndex = 1
        Me.unRadio.Text = "Unblock"
        Me.unRadio.UseVisualStyleBackColor = True
        '
        'uRadio
        '
        Me.uRadio.AutoSize = True
        Me.uRadio.Checked = True
        Me.uRadio.Location = New System.Drawing.Point(6, 33)
        Me.uRadio.Name = "uRadio"
        Me.uRadio.Size = New System.Drawing.Size(63, 21)
        Me.uRadio.TabIndex = 0
        Me.uRadio.TabStop = True
        Me.uRadio.Text = "Block"
        Me.uRadio.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(300, 200)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "About"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(297, 204)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "Developed by Hawaii Beach (aka ElPumpo)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sound assets by Valve Corperation." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Of" &
    "ficial page:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "https://github.com/ElPumpo/BlockWin10Update" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Licensed under GPLv" &
    "3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "v1.1.0.2"
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 253)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(350, 300)
        Me.Name = "GUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BlockWin10Update"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExitBtn As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ApplyBtn As Button
    Friend WithEvents unRadio As RadioButton
    Friend WithEvents uRadio As RadioButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
End Class
