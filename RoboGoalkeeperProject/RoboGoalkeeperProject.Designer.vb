<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RoboGoalkeeperProject
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
        Me.components = New System.ComponentModel.Container()
        Me.PortComboBox = New System.Windows.Forms.ComboBox()
        Me.SendButton = New System.Windows.Forms.Button()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.ComButton = New System.Windows.Forms.Button()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'PortComboBox
        '
        Me.PortComboBox.FormattingEnabled = True
        Me.PortComboBox.Location = New System.Drawing.Point(12, 12)
        Me.PortComboBox.Name = "PortComboBox"
        Me.PortComboBox.Size = New System.Drawing.Size(212, 24)
        Me.PortComboBox.TabIndex = 0
        '
        'SendButton
        '
        Me.SendButton.Location = New System.Drawing.Point(645, 355)
        Me.SendButton.Name = "SendButton"
        Me.SendButton.Size = New System.Drawing.Size(143, 83)
        Me.SendButton.TabIndex = 1
        Me.SendButton.Text = "Send"
        Me.SendButton.UseVisualStyleBackColor = True
        '
        'SerialPort
        '
        Me.SerialPort.BaudRate = 15200
        Me.SerialPort.ReceivedBytesThreshold = 18
        '
        'ComButton
        '
        Me.ComButton.Location = New System.Drawing.Point(645, 266)
        Me.ComButton.Name = "ComButton"
        Me.ComButton.Size = New System.Drawing.Size(143, 83)
        Me.ComButton.TabIndex = 2
        Me.ComButton.Text = "Com"
        Me.ComButton.UseVisualStyleBackColor = True
        '
        'Timer
        '
        Me.Timer.Interval = 250
        '
        'RoboGoalkeeperProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ComButton)
        Me.Controls.Add(Me.SendButton)
        Me.Controls.Add(Me.PortComboBox)
        Me.Name = "RoboGoalkeeperProject"
        Me.Text = "RoboGoalkeeper"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PortComboBox As ComboBox
    Friend WithEvents SendButton As Button
    Friend WithEvents SerialPort As IO.Ports.SerialPort
    Friend WithEvents ComButton As Button
    Friend WithEvents Timer As Timer
End Class
