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
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.ComButton = New System.Windows.Forms.Button()
        Me.PositionPictureBox = New System.Windows.Forms.PictureBox()
        Me.ClearButton = New System.Windows.Forms.Button()
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
        Me.ComButton.Location = New System.Drawing.Point(682, 355)
        Me.ComButton.Name = "ComButton"
        Me.ComButton.Size = New System.Drawing.Size(143, 83)
        Me.ComButton.TabIndex = 2
        Me.ComButton.Text = "Com"
        Me.ComButton.UseVisualStyleBackColor = True
        '
        'PositionPictureBox
        '
        Me.PositionPictureBox.Location = New System.Drawing.Point(12, 109)
        Me.PositionPictureBox.Name = "PositionPictureBox"
        Me.PositionPictureBox.Size = New System.Drawing.Size(640, 240)
        Me.PositionPictureBox.TabIndex = 3
        Me.PositionPictureBox.TabStop = False
        '
        'ClearButton
        '
        Me.ClearButton.Location = New System.Drawing.Point(682, 266)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(143, 83)
        Me.ClearButton.TabIndex = 4
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'RoboGoalkeeperProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 450)
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
End Class
