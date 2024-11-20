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
        Me.PortComboBox = New System.Windows.Forms.ComboBox()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.ComButton = New System.Windows.Forms.Button()
        Me.PositionPictureBox = New System.Windows.Forms.PictureBox()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.ShowImageButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.SendButton = New System.Windows.Forms.Button()
        Me.HomeButton = New System.Windows.Forms.Button()
        CType(Me.PositionPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'SerialPort
        '
        Me.SerialPort.BaudRate = 15200
        Me.SerialPort.ReceivedBytesThreshold = 18
        '
        'ComButton
        '
        Me.ComButton.Location = New System.Drawing.Point(12, 355)
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
        Me.PositionPictureBox.Size = New System.Drawing.Size(640, 240)
        Me.PositionPictureBox.TabIndex = 3
        Me.PositionPictureBox.TabStop = False
        '
        'ClearButton
        '
        Me.ClearButton.Location = New System.Drawing.Point(161, 355)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(143, 83)
        Me.ClearButton.TabIndex = 4
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'ShowImageButton
        '
        Me.ShowImageButton.Location = New System.Drawing.Point(310, 355)
        Me.ShowImageButton.Name = "ShowImageButton"
        Me.ShowImageButton.Size = New System.Drawing.Size(143, 83)
        Me.ShowImageButton.TabIndex = 5
        Me.ShowImageButton.Text = "Display"
        Me.ShowImageButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(459, 355)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(143, 83)
        Me.ExitButton.TabIndex = 6
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'SendButton
        '
        Me.SendButton.Location = New System.Drawing.Point(608, 355)
        Me.SendButton.Name = "SendButton"
        Me.SendButton.Size = New System.Drawing.Size(143, 83)
        Me.SendButton.TabIndex = 7
        Me.SendButton.Text = "Set Position"
        Me.SendButton.UseVisualStyleBackColor = True
        '
        'HomeButton
        '
        Me.HomeButton.Location = New System.Drawing.Point(757, 355)
        Me.HomeButton.Name = "HomeButton"
        Me.HomeButton.Size = New System.Drawing.Size(143, 83)
        Me.HomeButton.TabIndex = 8
        Me.HomeButton.Text = "Go Home"
        Me.HomeButton.UseVisualStyleBackColor = True
        '
        'RoboGoalkeeperProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 450)
        Me.Controls.Add(Me.HomeButton)
        Me.Controls.Add(Me.SendButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.ShowImageButton)
        Me.Controls.Add(Me.ClearButton)
        Me.Controls.Add(Me.PositionPictureBox)
        Me.Controls.Add(Me.ComButton)
        Me.Controls.Add(Me.PortComboBox)
        Me.Name = "RoboGoalkeeperProject"
        Me.Text = "RoboGoalkeeper"
        CType(Me.PositionPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PortComboBox As ComboBox
    Friend WithEvents SerialPort As IO.Ports.SerialPort
    Friend WithEvents ComButton As Button
    Friend WithEvents PositionPictureBox As PictureBox
    Friend WithEvents ClearButton As Button
    Friend WithEvents ShowImageButton As Button
    Friend WithEvents ExitButton As Button
    Friend WithEvents SendButton As Button
    Friend WithEvents HomeButton As Button
End Class
