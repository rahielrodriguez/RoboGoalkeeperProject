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

    '--------------------------------------SERIAL COM---------------------------------------------------------------------------
    Sub SerialConnect1(portName As String)
        SerialPort1.Close()
        SerialPort1.PortName = portName
        SerialPort1.BaudRate = 115200
        SerialPort1.Open()
    End Sub
    Sub SerialConnect2(portName As String)
        SerialPort2.Close()
        SerialPort2.PortName = portName
        SerialPort2.BaudRate = 115200
        SerialPort2.Open()
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
    Private Sub SerialPort2_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived
        'Dim steps_H As Integer
        'Dim steps_L As Integer
        Try
            Dim data(SerialPort2.BytesToRead) As Byte
            SerialPort2.Read(data, 0, SerialPort2.BytesToRead)
            If data(2) = &H55 And data(3) = &HAA And data(4) = &H55 And data(5) = &HAA And data.Length >= 18 Then
                For i = 0 To UBound(data)

                    Console.Write($"{Hex(data(i))} ")
                Next
                Console.WriteLine()
                Draw_PixyPosition(data(11), data(12), data(10))
            End If

            SerialPort2.Read(data, 0, SerialPort2.BytesToRead)
        Catch ex As Exception

        End Try
    End Sub
    Sub Draw_PixyPosition(highByte#, newY#, lowByte#)

        Dim g As Graphics = PositionPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Black)
        Static oldX#, oldY#
        Dim newX#
        newX = ((highByte * 256) + lowByte)
        g.FillRectangle(Brushes.Green, CInt(oldX), CInt(oldY), 20, 20)
        g.DrawImage(image, CInt(newX), CInt(newY), 20, 20)
        oldX = newX
        oldY = newY

        'XLabel.Text = $"{newX}"
        pen.Dispose()
        g.Dispose()

    End Sub
    '-------------------------------------------PIC16F1788 COM------------------------------------------------------------------
    Function lowByte_Steps_Conversion() As Integer
        Dim lowByte = (CInt(StepsTextBox.Text) Mod 256)
        Return lowByte
    End Function
    Function highByte_Steps_Conversion() As Integer
        Dim highByte = CInt(StepsTextBox.Text) / 256
        Return highByte
    End Function
    '---------------------------------------------BUTTONS AND FUNCTIONS---------------------------------------------------------
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        PositionPictureBox.Refresh()
    End Sub
    Private Sub ComButton_Click(sender As Object, e As EventArgs) Handles ComButton.Click
        GetPorts1()
    End Sub
    Private Sub Port1ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Port1ComboBox.SelectedIndexChanged
        SerialConnect1(Port1ComboBox.SelectedItem)
    End Sub
    Private Sub Port2ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Port2ComboBox.SelectedIndexChanged
        SerialConnect2(Port2ComboBox.SelectedItem)
    End Sub
    Private Sub SerialComExample_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPorts1()
        GetPorts2()
        Dim data(SerialPort2.BytesToRead) As Byte
        SerialPort2.Read(data, 0, SerialPort2.BytesToRead)
        image = ResizeImage(image, 20, 20)
        PositionPictureBox.BackColor = Color.Green
        XLabel.Text = ""
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
    Private Sub HomeButton_Click(sender As Object, e As EventArgs) Handles HomeButton.Click
        Dim tx_Data(0) As Byte
        tx_Data(0) = &H24
        SerialPort1.Write(tx_Data, 0, 1)
        Sleep(5)
        Dim rx_Data(SerialPort1.BytesToRead) As Byte
        SerialPort1.Read(rx_Data, 0, SerialPort1.BytesToRead)
        Console.WriteLine($"{Hex(rx_Data(0))}")
    End Sub
    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click

        Dim tx_Data(0) As Byte
        Dim tx_steps_Data(1) As Byte
        Dim rx_Data(500) As Byte
        Dim steps_H As Integer = highByte_Steps_Conversion()
        Dim steps_L As Integer = lowByte_Steps_Conversion()
        tx_Data(0) = &H5E
        'SerialPort.Read(rx_Data, 0, SerialPort.)
        SerialPort1.DiscardInBuffer()
        SerialPort1.Write(tx_Data, 0, 1)
        Console.WriteLine($"Transmitted data to the PIC = {Hex(tx_Data(0))}")
        Sleep(5)
        'Console.WriteLine($"{(steps_H * 256) + steps_L}")
        ReDim rx_Data(SerialPort1.BytesToRead)
        SerialPort1.Read(rx_Data, 0, SerialPort1.BytesToRead)
        'Console.WriteLine($"Received handshake = {Hex(rx_Data(0))}")
        Console.WriteLine($"Handshake data =")

        For i = 0 To UBound(rx_Data)
            Console.WriteLine($"{i} = {ChrW(rx_Data(i))}, {Hex(rx_Data(i))}")
        Next
        'Console.WriteLine($"{(ChrW(rx_Data(1)))}")

        If rx_Data(0) = &H5E Then
            tx_steps_Data(0) = steps_H
            tx_steps_Data(1) = steps_L

            Console.WriteLine($"transmit data =")
            For i = 0 To UBound(tx_steps_Data)
                Console.WriteLine($"{i} = {ChrW(tx_steps_Data(i))}, {Hex(tx_steps_Data(i))}, {tx_steps_Data(i)}")
            Next

            SerialPort1.DiscardInBuffer()
            SerialPort1.Write(tx_steps_Data, 0, 2)
            Sleep(5000)
            ReDim rx_Data(SerialPort1.BytesToRead)
            SerialPort1.Read(rx_Data, 0, SerialPort1.BytesToRead)
            Console.WriteLine($"received data =")

            For i = 0 To UBound(rx_Data)
                Console.WriteLine($"{i} = {ChrW(rx_Data(i))}, {Hex(rx_Data(i))}, {rx_Data(i)}")
            Next

        End If
    End Sub

End Class
