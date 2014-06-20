Imports System.IO
Imports System.IO.Ports
Imports System.Threading


Public Class Form1
    Shared _continue As Boolean
    Shared _serialPort As SerialPort
    Dim x As Integer = 0
    'Public up, down, lleft, rright As Boolean
  

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Ports As String() = IO.Ports.SerialPort.GetPortNames()
        For Each Port In Ports
            ComboBox1.Items.Add(Port)
            x = x + 1
        Next Port
        ComboBox1.SelectedIndex = x - 1
        SerialPort1.Close()
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        'SerialPort1.PortName = "COM17" 'change com port to match your Arduino port
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default 'very important!

    End Sub


    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim bHandled As Boolean = False
        Select Case e.KeyCode
            Case Keys.NumPad6
                Label3.BackColor = Color.DeepSkyBlue
                SerialPort1.Write("1")
                'do stuff
                e.Handled = True
            Case Keys.NumPad4
                Label2.BackColor = Color.DeepSkyBlue
                SerialPort1.Write("2")
                'do other stuff
                e.Handled = True
            Case Keys.NumPad8
                Label1.BackColor = Color.DeepSkyBlue
                SerialPort1.Write("3")
                'do more stuff
                e.Handled = True
            Case Keys.NumPad5
                Label4.BackColor = Color.DeepSkyBlue
                SerialPort1.Write("4")
                'do more stuff
                e.Handled = True
        End Select
        'SerialPort1.Close()
    End Sub


    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        'SerialPort1.Open()
        Dim bHandled As Boolean = False
        Select Case e.KeyCode
            Case Keys.NumPad6
                Label3.BackColor = Color.White
                SerialPort1.Write("5")
                'do stuff
                e.Handled = True
            Case Keys.NumPad4
                Label2.BackColor = Color.White
                SerialPort1.Write("6")
                'do other stuff
                e.Handled = True
            Case Keys.NumPad8
                Label1.BackColor = Color.White
                SerialPort1.Write("7")
                'do more stuff
                e.Handled = True
            Case Keys.NumPad5
                Label4.BackColor = Color.White
                SerialPort1.Write("8")
                'do more stuff
                e.Handled = True
        End Select
        'SerialPort1.Close()
    End Sub

    
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label6.Text = x
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        SerialPort1.Close()
        ComboBox1.Enabled = True
        'Timer1.Enabled = True
        btnClose.Visible = False
        btnOpen.Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        On Error GoTo ErrorHandler
        btnOpen.Visible = False
        btnClose.Visible = True
        'Timer1.Enabled = False
        SerialPort1.PortName = ComboBox1.SelectedText
        ComboBox1.Enabled = False
        SerialPort1.Open()
        Exit Sub

ErrorHandler:
        MsgBox("This port cannot be opened!")
        'Label6.Visible = True
        'Label6.Text = "Error"
        SerialPort1.Close()
        ComboBox1.Enabled = True
        Timer1.Enabled = True
        btnClose.Visible = False
        btnOpen.Visible = True
        Exit Sub
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        x = 0
        Dim Ports As String() = IO.Ports.SerialPort.GetPortNames()
        ComboBox1.Items.Clear()
        For Each Port In Ports
            ComboBox1.Items.Add(Port)
            x = x + 1
        Next Port
        'ComboBox1.Items Remove Item 0 from items
        'ComboBox1.SelectedIndex = x - 1
    End Sub
End Class