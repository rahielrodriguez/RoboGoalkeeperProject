Imports System.IO.Ports
Imports System.Threading.Thread
Imports System.Windows.Forms.ComponentModel.Com2Interop
Imports System.Runtime.InteropServices

Public Class RoboGoalkeeperProject
    Sub WriteDigital()
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

    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        WriteDigital()
        'Console.WriteLine(SerialPort.BytesToRead)
        'Dim data(SerialPort.BytesToRead) As Byte
        'SerialPort.Read(data, 0, SerialPort.BytesToRead)

        'Console.WriteLine($"Bytes to read: {SerialPort.BytesToRead}")
        'Console.WriteLine($"Byte 0: {Hex(data(0))}")
        'Console.WriteLine($"Byte 1: {Hex(data(1))}")
        'Console.WriteLine($"Byte 2: {Hex(data(2))}")
        'Console.WriteLine($"Byte 3: {Hex(data(3))}")
        'Console.WriteLine($"Byte 4: {Hex(data(4))}")
        'Console.WriteLine($"Byte 5: {Hex(data(5))}")
        'Console.WriteLine($"Byte 6: {Hex(data(6))}")
        'Console.WriteLine($"Byte 7: {Hex(data(7))}")
        'Console.WriteLine($"Byte 8: {Hex(data(8))}")
        'Console.WriteLine($"Byte 9: {Hex(data(9))}")
        'Console.WriteLine($"Byte 10: {Hex(data(10))}")
        'Console.WriteLine($"Byte 11: {Hex(data(11))}")
        'Console.WriteLine($"Byte 12: {Hex(data(12))}")

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
        'Sleep(10)
        Dim data(SerialPort.BytesToRead) As Byte
        'Console.WriteLine(SerialPort.BytesToRead)
        SerialPort.Read(data, 0, SerialPort.BytesToRead)

        If data(0) = &H0 And data(1) = &H0 And data(2) = &H55 And data(3) = &HAA Then
            For i = 0 To UBound(data)
                'Console.Write($"Byte {i}: {Hex(data(i))}")
                Console.Write($"{Hex(data(i))} ")
            Next
            Console.WriteLine()
        End If
        'Console.WriteLine(SerialPort.BytesToRead)
        SerialPort.Read(data, 0, SerialPort.BytesToRead)
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        WriteDigital()

    End Sub
End Class
