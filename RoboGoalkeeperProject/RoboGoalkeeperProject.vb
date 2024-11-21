﻿Imports System.IO.Ports
Imports System.Threading.Thread
Imports System.Windows.Forms.ComponentModel.Com2Interop
Imports System.Runtime.InteropServices

Public Class RoboGoalkeeperProject
    ''' <summary>
    ''' Read the analog input A1 of the Qy_ board. 
    ''' <br/>
    ''' A01 = 01010001
    ''' </summary>
    ''' <returns>Byte Array</returns>'
    Dim image As New Bitmap("C:\Users\Rahi\OneDrive\Desktop\ISU\Robotics\5th Semester\Final Project\RoboGoalkeeperProject\RoboGoalkeeperProject\Resources\Soccer Ball.png")
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

    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        'Dim steps_H As Integer
        'Dim steps_L As Integer
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
        newX = ((highByte * 256) + lowByte)
        g.FillRectangle(Brushes.Green, CInt(oldX), CInt(oldY), 20, 20)
        g.DrawImage(image, CInt(newX), CInt(newY), 20, 20)
        oldX = newX
        oldY = newY

        pen.Dispose()
        g.Dispose()

    End Sub
    Public Shared Function ResizeImage(ByVal InputBitmap As Bitmap, width As Integer, height As Integer) As Bitmap
        Return New Bitmap(InputBitmap, New Size(width, height))
    End Function

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        PositionPictureBox.Refresh()
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
        SerialPort.Read(data, 0, SerialPort.BytesToRead)
        image = ResizeImage(image, 20, 20)
        PositionPictureBox.BackColor = Color.Green
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ShowImageButton_Click(sender As Object, e As EventArgs) Handles ShowImageButton.Click
        PositionPictureBox.Image = image
    End Sub

    Private Sub HomeButton_Click(sender As Object, e As EventArgs) Handles HomeButton.Click
        Dim tx_Data(0) As Byte
        tx_Data(0) = &H24
        SerialPort.Write(tx_Data, 0, 1)
        Sleep(5)
        Dim rx_Data(SerialPort.BytesToRead) As Byte
        SerialPort.Read(rx_Data, 0, SerialPort.BytesToRead)
        Console.WriteLine($"{Hex(rx_Data(0))}")
    End Sub

    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        Try
            Dim tx_Data(0) As Byte
            Dim tx_steps_Data(0) As Byte
            Dim steps As Integer = CInt(StepsTextBox.Text)
            tx_Data(0) = &H5E
            SerialPort.Write(tx_Data, 0, 1)
            Sleep(5)
            Dim rx_Data(SerialPort.BytesToRead) As Byte
            SerialPort.Read(rx_Data, 0, SerialPort.BytesToRead)
            Console.WriteLine($"{Hex(rx_Data(0))}")
            If rx_Data(0) = &H5E Then
                tx_steps_Data(0) = steps
                SerialPort.Write(tx_steps_Data, 0, 1)
                Console.WriteLine($"{Hex(tx_steps_Data(0))}")
                Sleep(5)
                SerialPort.Read(rx_Data, 1, SerialPort.BytesToRead)
                Console.WriteLine($"{Hex(rx_Data(0))}")
                If rx_Data(1) = &H5F Then
                    MsgBox($"{steps} steps done!")
                End If
            End If
        Catch ex As Exception
            MsgBox("Place a value in steps textbox")
        End Try
    End Sub
End Class
