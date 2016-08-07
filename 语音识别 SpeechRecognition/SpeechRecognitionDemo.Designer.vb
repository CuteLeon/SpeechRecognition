<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SpeechRecognitionDemo
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ResultLabel = New System.Windows.Forms.Label()
        Me.VoiceLevelBar = New System.Windows.Forms.ProgressBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ResultLabel
        '
        Me.ResultLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResultLabel.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ResultLabel.Location = New System.Drawing.Point(0, 24)
        Me.ResultLabel.Name = "ResultLabel"
        Me.ResultLabel.Size = New System.Drawing.Size(378, 143)
        Me.ResultLabel.TabIndex = 3
        Me.ResultLabel.Text = "— —"
        Me.ResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VoiceLevelBar
        '
        Me.VoiceLevelBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.VoiceLevelBar.Location = New System.Drawing.Point(0, 0)
        Me.VoiceLevelBar.Name = "VoiceLevelBar"
        Me.VoiceLevelBar.Size = New System.Drawing.Size(378, 24)
        Me.VoiceLevelBar.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(303, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 40)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "激活"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(303, 76)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 40)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "关闭"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'SpeechRecognitionDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 167)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ResultLabel)
        Me.Controls.Add(Me.VoiceLevelBar)
        Me.Name = "SpeechRecognitionDemo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Speech Recognition Demo"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ResultLabel As Label
    Friend WithEvents VoiceLevelBar As ProgressBar
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
