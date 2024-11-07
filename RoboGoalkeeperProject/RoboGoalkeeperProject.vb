Imports System.IO.Ports
Imports System.Threading.Thread
Imports System.Windows.Forms.ComponentModel.Com2Interop
Imports System.Runtime.InteropServices

Public Class RoboGoalkeeperProject
    Sub WritePixyData()
        Dim Data(3) As Byte
        Data(0) = &HC1
        Data(1) = &HAE
        Data(2) = &HE
        Data(3) = &H0
        'Data(4) = &HFF
        'Data(5) = &H0
        'Data(6) = &H0
        SerialPort.Write(Data, 0, 4)

        Sleep(50)
    End Sub
    ''' <summary>
    ''' Read the analog input A1 of the Qy_ board. 
    ''' <br/>
    ''' A01 = 01010001
    ''' </summary>
    ''' <returns>Byte Array</returns>'
    Function Qy_ReadAnalogInPutA1() As Byte()
        Dim data(0) As Byte
        data(0) = &B1010001
        SerialPort.Write(data, 0, 1)
        Return data
    End Function

    Sub SerialConnect(portName As String)
        SerialPort.Close()
        SerialPort.PortName = portName
        SerialPort.BaudRate = 115200
        SerialPort.Open()

    End Sub
    Sub GetPorts()
        'add all available ports to the port combobox
        PortComboBox.Items.Clear()
        For Each s As String In SerialPort.GetPortNames()
            PortComboBox.Items.Add($"{s}")
        Next

        PortComboBox.SelectedIndex = 0
    End Sub

    Private Sub ComButton_Click(sender As Object, e As EventArgs) Handles ComButton.Click
        GetPorts()
    End Sub
    Private Sub PortComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PortComboBox.SelectedIndexChanged
        SerialConnect(PortComboBox.SelectedItem)
    End Sub

    Private Sub SerialComExample_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPorts()
        Dim data(SerialPort.BytesToRead) As Byte
        SerialPort.Read(Data, 0, SerialPort.BytesToRead)
    End Sub

    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort.DataReceived

        Try
            Dim data(SerialPort.BytesToRead) As Byte
            SerialPort.Read(data, 0, SerialPort.BytesToRead)
            If data(2) = &H55 And data(3) = &HAA And data(4) = &H55 And data(5) = &HAA And data.Length >= 18 Then
                For i = 0 To UBound(data)

                    Console.Write($"{Hex(data(i))} ")
                Next
                Console.WriteLine()
                Draw_PixyPosition(data(11), data(12), data(10))
            End If

            SerialPort.Read(data, 0, SerialPort.BytesToRead)
        Catch ex As Exception

        End Try
    End Sub
    Sub Draw_PixyPosition(highByte#, newY#, lowByte#)

        Dim g As Graphics = PositionPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Black)
        Static oldX#, oldY#
        Dim newX#
        'g.TranslateTransform(0, 255 * -1)

        newX = ((highByte * 256) + lowByte)

        g.DrawLine(pen, CInt(oldX), CInt(oldY), CInt(newX), CInt(newY))

        Try
            If newX > 0 Then
                Console.WriteLine()
            End If
        Catch ex As Exception
        End Try
        'Console.Write($"{newX} , {newY}")
        'store values for start of next line segment
        oldX = newX
        oldY = newY

        pen.Dispose()
        g.Dispose()

    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        PositionPictureBox.Refresh()
    End Sub
End Class
