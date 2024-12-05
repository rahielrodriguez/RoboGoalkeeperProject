<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RoboGoalkeeperProject
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
        Me.Port1ComboBox = New System.Windows.Forms.ComboBox()
        Me.PixySerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.ComButton = New System.Windows.Forms.Button()
        Me.PositionPictureBox = New System.Windows.Forms.PictureBox()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.SendButton = New System.Windows.Forms.Button()
        Me.HomeButton = New System.Windows.Forms.Button()
        Me.StepsTextBox = New System.Windows.Forms.TextBox()
        Me.Port2ComboBox = New System.Windows.Forms.ComboBox()
        Me.PICSerialPort = New System.IO.Ports.SerialPort(Me.components)
        CType(Me.PositionPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Port1ComboBox
        '
        Me.Port1ComboBox.FormattingEnabled = True
        Me.Port1ComboBox.Location = New System.Drawing.Point(12, 12)
        Me.Port1ComboBox.Name = "Port1ComboBox"
        Me.Port1ComboBox.Size = New System.Drawing.Size(212, 24)
        Me.Port1ComboBox.TabIndex = 0
        '
        'PixySerialPort
        '
        Me.PixySerialPort.BaudRate = 115200
        Me.PixySerialPort.ReceivedBytesThreshold = 18
        '
        'ComButton
        '
        Me.ComButton.Location = New System.Drawing.Point(12, 316)
        Me.ComButton.Name = "ComButton"
        Me.ComButton.Size = New System.Drawing.Size(143, 83)
        Me.ComButton.TabIndex = 2
        Me.ComButton.Text = "Com"
        Me.ComButton.UseVisualStyleBackColor = True
        '
        'PositionPictureBox
        '
        Me.PositionPictureBox.Location = New System.Drawing.Point(12, 42)
        Me.PositionPictureBox.Name = "PositionPictureBox"
        Me.PositionPictureBox.Size = New System.Drawing.Size(450, 240)
        Me.PositionPictureBox.TabIndex = 3
        Me.PositionPictureBox.TabStop = False
        '
        'ClearButton
        '
        Me.ClearButton.Location = New System.Drawing.Point(459, 316)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(143, 83)
        Me.ClearButton.TabIndex = 4
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(608, 316)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(143, 83)
        Me.ExitButton.TabIndex = 6
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'SendButton
        '
        Me.SendButton.Location = New System.Drawing.Point(161, 316)
        Me.SendButton.Name = "SendButton"
        Me.SendButton.Size = New System.Drawing.Size(143, 83)
        Me.SendButton.TabIndex = 7
        Me.SendButton.Text = "Set Position"
        Me.SendButton.UseVisualStyleBackColor = True
        '
        'HomeButton
        '
        Me.HomeButton.Location = New System.Drawing.Point(310, 316)
        Me.HomeButton.Name = "HomeButton"
        Me.HomeButton.Size = New System.Drawing.Size(143, 83)
        Me.HomeButton.TabIndex = 8
        Me.HomeButton.Text = "Go Home"
        Me.HomeButton.UseVisualStyleBackColor = True
        '
        'StepsTextBox
        '
        Me.StepsTextBox.Location = New System.Drawing.Point(12, 288)
        Me.StepsTextBox.Name = "StepsTextBox"
        Me.StepsTextBox.Size = New System.Drawing.Size(143, 22)
        Me.StepsTextBox.TabIndex = 9
        '
        'Port2ComboBox
        '
        Me.Port2ComboBox.FormattingEnabled = True
        Me.Port2ComboBox.Location = New System.Drawing.Point(230, 12)
        Me.Port2ComboBox.Name = "Port2ComboBox"
        Me.Port2ComboBox.Size = New System.Drawing.Size(212, 24)
        Me.Port2ComboBox.TabIndex = 10
        '
        'PICSerialPort
        '
        Me.PICSerialPort.BaudRate = 115200
        Me.PICSerialPort.ReceivedBytesThreshold = 4
        '
        'RoboGoalkeeperProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 410)
        Me.Controls.Add(Me.Port2ComboBox)
        Me.Controls.Add(Me.StepsTextBox)
        Me.Controls.Add(Me.HomeButton)
        Me.Controls.Add(Me.SendButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.ClearButton)
        Me.Controls.Add(Me.PositionPictureBox)
        Me.Controls.Add(Me.ComButton)
        Me.Controls.Add(Me.Port1ComboBox)
        Me.Name = "RoboGoalkeeperProject"
        Me.Text = "RoboGoalkeeper"
        CType(Me.PositionPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Port1ComboBox As ComboBox
    Friend WithEvents PixySerialPort As IO.Ports.SerialPort
    Friend WithEvents ComButton As Button
    Friend WithEvents PositionPictureBox As PictureBox
    Friend WithEvents ClearButton As Button
    Friend WithEvents ExitButton As Button
    Friend WithEvents SendButton As Button
    Friend WithEvents HomeButton As Button
    Friend WithEvents StepsTextBox As TextBox
    Friend WithEvents Port2ComboBox As ComboBox
    Friend WithEvents PICSerialPort As IO.Ports.SerialPort
End Class
