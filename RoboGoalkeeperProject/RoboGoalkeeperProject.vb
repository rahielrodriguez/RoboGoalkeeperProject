Imports System.IO.Ports
Imports System.Threading.Thread
Imports System.Windows.Forms.ComponentModel.Com2Interop
Imports System.Runtime.InteropServices
Imports System.Reflection

Public Class RoboGoalkeeperProject
    ''' <summary>
    ''' Read the analog input A1 of the Qy_ board. 
    ''' <br/>
    ''' A01 = 01010001
    ''' </summary>
    ''' <returns>Byte Array</returns>'
    Dim image As New Bitmap("C:\Users\Rahi\OneDrive\Desktop\ISU\Robotics\5th Semester\Final Project\RoboGoalkeeperProject\RoboGoalkeeperProject\Resources\Soccer Ball.png")
    Dim cameraX As Integer
    Dim cameraWidth As Integer
    Dim motorX As Integer
    Dim cameraXHighByte As Integer
    Dim cameraXLowByte As Integer
    Dim cameraWidthHighByte As Integer
    Dim cameraWidthLowByte As Integer
    Dim scaled_Pixy_X As Integer

    '--------------------------------------SERIAL COM---------------------------------------------------------------------------
    Sub SerialConnect1(portName As String)
        PixySerialPort.Close()
        PixySerialPort.PortName = portName
        PixySerialPort.BaudRate = 115200
        PixySerialPort.Open()
    End Sub
    Sub SerialConnect2(portName As String)
        PICSerialPort.Close()
        PICSerialPort.PortName = portName
        PICSerialPort.BaudRate = 115200
        PICSerialPort.Open()
    End Sub
    Sub GetPorts1()
        'add all available ports to the port combobox
        Port1ComboBox.Items.Clear()
        For Each s As String In SerialPort.GetPortNames()
            Port1ComboBox.Items.Add($"{s}")
        Next

        Port1ComboBox.SelectedIndex = 0
    End Sub
    Sub GetPorts2()
        Port2ComboBox.Items.Clear()
        For Each s As String In SerialPort.GetPortNames()
            Port2ComboBox.Items.Add($"{s}")
        Next

        Port2ComboBox.SelectedIndex = 1
    End Sub
    '-----------------------------------------PIXY FUNCTION---------------------------------------------------------------------
    Public Shared Function ResizeImage(ByVal InputBitmap As Bitmap, width As Integer, height As Integer) As Bitmap
        Return New Bitmap(InputBitmap, New Size(width, height))
    End Function
    Private Sub PixySerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles PixySerialPort.DataReceived
        Try
            Dim data(PixySerialPort.BytesToRead) As Byte
            PixySerialPort.Read(data, 0, PixySerialPort.BytesToRead)
            If data(2) = &H55 And data(3) = &HAA And data(4) = &H55 And data(5) = &HAA And data.Length >= 18 Then
                'Console.Write("Pixy Received Data: ")
                'For i = 0 To UBound(data)
                '    Console.Write($"{Hex(data(i))} ")
                'Next
                'Console.WriteLine()
                Draw_PixyPosition(data(11), data(12), data(10))
                'Console.WriteLine($"Camera Pixels Position Pixels{((CInt(data(11))) * 256) + (CInt(data(10)))}")
                'Console.WriteLine($"Steps = {transform_XPixy(cameraXHighByte, cameraXLowByte)}")
                cameraXHighByte = CInt(data(11))
                cameraXLowByte = CInt(data(10))
                cameraWidthHighByte = CInt(data(15))
                cameraWidthLowByte = CInt(data(14))
                cameraX = (cameraXHighByte * 256) + cameraXLowByte
                cameraWidth = (cameraWidthHighByte * 256) + cameraWidthLowByte
                CameraXToolStripStatusLabel.Text = $"Pixy Received Data in Steps:{scaled_Pixy_X}"
                Console.Write($"Pixy Cam Data Scaled = {Hex(transform_XPixy_HB(scaled_Pixy_X))} {Hex(transform_XPixy_LB(scaled_Pixy_X))}, ")
                Console.WriteLine()
                Console.Write($"Pixy Cam Original Data = {Hex(cameraXHighByte)} {Hex(cameraXLowByte)}")
                Console.WriteLine()
            End If
            PixySerialPort.DiscardInBuffer()
        Catch ex As Exception

        End Try
    End Sub
    Sub Draw_PixyPosition(highByte#, newY#, lowByte#)

        Dim g As Graphics = PositionPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Black)
        Static oldX#, oldY#
        Dim newX#
        newX = ((highByte * 255) + lowByte)
        g.FillRectangle(Brushes.Green, CInt(oldX), CInt(oldY), 20, 20)
        g.DrawImage(image, CInt(newX), CInt(newY), 20, 20)
        oldX = newX
        oldY = newY
        'XLabel.Text = $"{newX}"
        pen.Dispose()
        g.Dispose()

        If position_Comp() Then
            Me.Text = "True!"
        Else
            Me.Text = "False :("
        End If

    End Sub
    Function scale_PixyX(xHighByte#, xLowByte#) As Integer
        Try
            Dim org_LowByte = CInt(xLowByte)
            Dim org_HighByte = CInt(xHighByte)
            Dim scaled_X = (((org_HighByte * 255) * 204) + (org_LowByte * 204))
            Return scaled_X

        Catch ex As Exception

        End Try
    End Function
    Function transform_XPixy_LB(xLowByte#) As Integer
        Try
            Dim org_LowByte = xLowByte
            Dim scaled_X_LB = org_LowByte Mod 255
            Return scaled_X_LB

        Catch ex As Exception

        End Try
    End Function
    Function transform_XPixy_HB(xHighByte#) As Integer
        Try
            Dim org_HighByte = xHighByte
            Dim scaled_X_HB = org_HighByte / 255
            Return scaled_X_HB

        Catch ex As Exception

        End Try
    End Function
    '-------------------------------------------PIC16F1788 COM------------------------------------------------------------------
    Function lowByte_Steps_Conversion() As Integer
        Try
            Dim lowByte = (CInt(StepsTextBox.Text) Mod 255)
            Return lowByte
        Catch ex As Exception
            MsgBox("Please, place a valid value for number of steps.", MsgBoxStyle.Critical, "Steps# Error!")
        End Try
    End Function
    Function highByte_Steps_Conversion() As Integer
        Try
            Dim highByte = CInt(StepsTextBox.Text) / 255
            Return highByte
        Catch ex As Exception
            MsgBox("Please, place a valid value for number of steps.", MsgBoxStyle.Critical, "Steps# Error!")
        End Try
    End Function
    Private Sub PICSerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles PICSerialPort.DataReceived
        Try
            'Console.WriteLine(PICSerialPort.BytesToRead)
            Dim port_Data As Integer = PICSerialPort.BytesToRead
            Dim data(port_Data) As Byte
            PICSerialPort.Read(data, 0, port_Data)
            Console.Write("PIC Received Data: ")
            For i = 0 To UBound(data)
                Console.Write($"{Hex(data(i))} ")
            Next
            Console.WriteLine()
            If data(0) = &H77 And data.Length >= 4 Then
                Draw_MotorPosition(data(1), data(2))
                MotorXToolStripStatusLabel.Text = $"PIC Received Data in Steps: {(data(1) * 255) + data(2)}"
            End If
            PICSerialPort.DiscardInBuffer()

        Catch ex As Exception

        End Try
    End Sub
    Sub Draw_MotorPosition(highByte#, lowByte#)
        Try
            Dim g As Graphics = PositionPictureBox.CreateGraphics
            Dim pen1 As New Pen(Color.Red)
            Dim pen2 As New Pen(Color.Green)
            pen2.Width = 5
            Static oldX#
            Dim newX#
            newX = ((highByte * 255) + lowByte) / 204
            'Console.WriteLine($"Motor Position in Pixels = {newX}")
            g.DrawEllipse(pen2, CInt(oldX), 85, 20, 22)
            g.DrawEllipse(pen1, CInt(newX), 85, 20, 20)
            oldX = newX
            motorX = newX
            pen1.Dispose()
            pen2.Dispose()
            g.Dispose()
        Catch ex As Exception

        End Try

        If position_Comp() Then
            Me.Text = "True!"
        Else
            Me.Text = "False :("
        End If

    End Sub
    Function position_Comp() As Boolean
        If motorX > (cameraX - (cameraWidth / 2)) And motorX < (cameraX + (cameraWidth / 2)) Then
            Return True
        Else
            Return False
        End If
    End Function

    '---------------------------------------------BUTTONS AND FORM----------------------------------------------------------------
    Private Sub ComButton_Click(sender As Object, e As EventArgs) Handles ComButton.Click
        GetPorts1()
    End Sub
    Private Sub Port1ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Port1ComboBox.SelectedIndexChanged
        SerialConnect1(Port1ComboBox.SelectedItem)
    End Sub
    Private Sub Port2ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Port2ComboBox.SelectedIndexChanged
        SerialConnect2(Port2ComboBox.SelectedItem)
    End Sub
    Private Sub RoboGoalkeeperProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPorts1()
        GetPorts2()
        PixySerialPort.DiscardInBuffer()
        PICSerialPort.DiscardInBuffer()
        image = ResizeImage(image, 20, 20)
        PositionPictureBox.BackColor = Color.Green
        Control.CheckForIllegalCrossThreadCalls = False

    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        PixySerialPort.Close()
        PICSerialPort.Close()
        Me.Close()
    End Sub
    Private Sub HomeButton_Click(sender As Object, e As EventArgs) Handles HomeButton.Click
        Dim tx_Data(0) As Byte
        tx_Data(0) = &H24
        PICSerialPort.Write(tx_Data, 0, 1)
        Sleep(5)
        Dim rx_Data(PICSerialPort.BytesToRead) As Byte
        PICSerialPort.Read(rx_Data, 0, PICSerialPort.BytesToRead)
        'Console.WriteLine($"Homing Handshake = {Hex(rx_Data(0))}")
    End Sub
    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        HomeButton.Enabled = False
        Dim tx_Data(2) As Byte
        Dim rx_Data(500) As Byte
        Dim steps_H As Integer = highByte_Steps_Conversion()
        Dim steps_L As Integer = lowByte_Steps_Conversion()

        tx_Data(0) = &H5E
        tx_Data(1) = steps_H
        tx_Data(2) = steps_L

        PICSerialPort.DiscardInBuffer()
        Sleep(5)
        PICSerialPort.Write(tx_Data, 0, 3)
        Sleep(500)
        ReDim rx_Data(PICSerialPort.BytesToRead)
        PICSerialPort.Read(rx_Data, 0, PICSerialPort.BytesToRead)
        HomeButton.Enabled = True
    End Sub

    Private Sub CommunicationTimer_Tick(sender As Object, e As EventArgs) Handles CommunicationTimer.Tick
        If position_Comp() = False Then
            scaled_Pixy_X = 0
            Try
                MotorXToolStripStatusLabel.Text = ""
                CameraXToolStripStatusLabel.Text = ""
                scaled_Pixy_X = scale_PixyX(cameraXHighByte, cameraXLowByte)
                If scaled_Pixy_X < 64500 Then

                    Dim pixy_Scaled_HB = transform_XPixy_HB(scaled_Pixy_X)
                    Dim pixy_Scaled_LB = transform_XPixy_LB(scaled_Pixy_X)
                    Dim tx_Data(2) As Byte
                    tx_Data(0) = &H5E
                    tx_Data(1) = pixy_Scaled_HB
                    tx_Data(2) = pixy_Scaled_LB
                    PICSerialPort.Write(tx_Data, 0, 3)
                Else
                    Console.WriteLine()
                    'MsgBox("Issue with camera data transformation", MsgBoxStyle.Critical, "error")
                End If
            Catch ex As Exception

            End Try
        Else

        End If
    End Sub

    Private Sub TrackingCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles TrackingCheckBox.CheckedChanged
        If TrackingCheckBox.Checked Then
            CommunicationTimer.Start()
            SendButton.Enabled = False
        Else
            SendButton.Enabled = True
            CommunicationTimer.Stop()
        End If
    End Sub
End Class
