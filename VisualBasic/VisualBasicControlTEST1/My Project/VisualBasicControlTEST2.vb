Imports System.IO
Imports System.IO.Ports
Imports System.Threading


Public Class Form1
    Shared _continue As Boolean
    Shared _serialPort As SerialPort
    Dim x As Integer = 0
    Dim z As Integer = 0 ' For refreshing. .. ...
    'Dim y As Integer = 0


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Refresh2()
        WifiCamView.Size = New Size(Me.Size.Width / 1.3, Me.Size.Height / 1.3)
        SerialPort1.Close()
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.PortName = "COM17" 'change com port to match your Arduino port
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default 'very important!
        WifiCamView.Document.Body.ScrollLeft = False

    End Sub


    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim bHandled As Boolean = False
        On Error GoTo ErrorHandler
        Select Case e.KeyCode
            Case Keys.Right
                Label3.BackColor = Color.DeepSkyBlue
                SerialPort1.Write("1")
                'do stuff
                e.Handled = True
            Case Keys.Left
                Label2.BackColor = Color.DeepSkyBlue
                SerialPort1.Write("2")
                'do other stuff
                e.Handled = True
            Case Keys.Up
                Label1.BackColor = Color.DeepSkyBlue
                SerialPort1.Write("3")
                'do more stuff
                e.Handled = True
            Case Keys.Down
                Label4.BackColor = Color.DeepSkyBlue
                SerialPort1.Write("4")
                'do more stuff
                e.Handled = True
        End Select
        Exit Sub
ErrorHandler:
        MsgBox("Port is not Open!")
        Label1.BackColor = Color.White
        Label2.BackColor = Color.White
        Label3.BackColor = Color.White
        Label4.BackColor = Color.White
        Exit Sub
    End Sub


    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim bHandled As Boolean = False
        On Error GoTo ErrorHandler 'Handles errors
        Select Case e.KeyCode
            Case Keys.Right
                Label3.BackColor = Color.White
                SerialPort1.Write("5")
                'do stuff
                e.Handled = True
            Case Keys.Left
                Label2.BackColor = Color.White
                SerialPort1.Write("6")
                'do other stuff
                e.Handled = True
            Case Keys.Up
                Label1.BackColor = Color.White
                SerialPort1.Write("7")
                'do more stuff
                e.Handled = True
            Case Keys.Down
                Label4.BackColor = Color.White
                SerialPort1.Write("8")
                'do more stuff
                e.Handled = True
        End Select
ErrorHandler:
        MsgBox("Port is not Open!")
        Label1.BackColor = Color.White
        Label2.BackColor = Color.White
        Label3.BackColor = Color.White
        Label4.BackColor = Color.White
        Exit Sub
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Label6.Text = SerialPortToolStripMenuItem.DropDown.Items(1)
        'SerialPort1.PortName = ComboBox1.SelectedItem
        'Label7.Text = y
        
        If z = 0 Then
            Label8.Text() = "Refreshing."
        End If

        If z = 1 Then
            Label8.Text() = "Refreshing.."
        End If

        If z = 2 Then
            Label8.Text() = "Refreshing..."
        End If

        If z = 3 Then
            ProgressBar1.Visible = False
            Timer2.Enabled() = False
            Label8.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        SerialPort1.Close()
        'ComboBox1.Enabled = True
        'Timer1.Enabled = True
        btnClose.Visible = False
        btnOpen.Visible = True
        'btnRefresh.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        On Error GoTo ErrorHandler
        'SerialPort1.PortName = ComboBox1.SelectedText
        SerialPort1.PortName = ToolStripComboBox1.SelectedItem
        btnOpen.Visible = False
        btnClose.Visible = True
        'btnRefresh.Enabled = False
        'Timer1.Enabled = False
        'ComboBox1.Enabled = False
        SerialPort1.Open()
        Exit Sub

ErrorHandler:
        MsgBox("This port cannot be opened!")
        'Label6.Visible = True
        'Label6.Text = "Error"
        SerialPort1.Close()
        'ComboBox1.Enabled = True
        Timer1.Enabled = True
        btnClose.Visible = False
        btnOpen.Visible = True
        'btnRefresh.Enabled = True
        Exit Sub
    End Sub

    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
    '    ProgressBar1.Value() = 0
    '    z = 0
    '    ProgressBar1.Visible = True
    '    Label8.Visible = True
    '    Timer2.Enabled = True
    '    Dim y As Integer = 0
    '    Dim Ports As String() = IO.Ports.SerialPort.GetPortNames()
    '    ComboBox1.Items.Clear()
    '    SerialPortToolStripMenuItem.DropDownItems.Clear()
    '    For Each Port In Ports
    '        ComboBox1.Items.Add(Port)
    '        SerialPortToolStripMenuItem.DropDownItems.Add(Port)
    '        y = y + 1
    '        ProgressBar1.Value() = y
    '    Next Port
    '    ProgressBar1.Maximum() = y
    '    If y > 0 Then
    '        ComboBox1.Items.RemoveAt(0) 'Remove Item 0 from items
    '        ComboBox1.SelectedIndex = y - 2
    '    End If
    '    If y < 1 Then
    '        MsgBox("No Ports Found!")
    '    End If
    'End Sub

    Declare Sub Sleep Lib "kernel32" Alias "Sleep" (ByVal dwMilliSeconds As Long)
    Sub Sleep()
        Sleep(1000) ' Delay for ProgressBar to have time to view after it finishes
        ProgressBar1.Visible = False
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        z = z + 1 'refreshing.. .. .. .

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End 'Exits Program
    End Sub

    Private Sub Refresh1()
        ProgressBar1.Value() = 0
        z = 0
        ProgressBar1.Visible = True
        Label8.Visible = True 'Refreshing.... Label
        Timer2.Enabled = True 'Refreshing... Timer
        'Deletes Refresh and all COM's to add new but not refresh
        Dim y As Integer = 0 'Orginally was just for this sub but timer3 also uses it
        Dim Ports As String() = IO.Ports.SerialPort.GetPortNames()
        ToolStripComboBox1.Items.Clear() 'Deletes all previous COM ports to ADD the current COM ports connected to computer
        'SerialPortToolStripMenuItem.DropDownItems.Clear()
        For Each Port In Ports
            ToolStripComboBox1.Items.Add(Port) 'Adds COM Ports to ComboBox
            'SerialPortToolStripMenuItem.DropDownItems.Add(Port) 'Adds COM Ports to Serial Port Menu
            y = y + 1
            ProgressBar1.Value() = y
        Next Port

        ProgressBar1.Maximum() = y
        If y > 0 Then
            '    ComboBox1.Items.RemoveAt(0) 'Remove Item 0 from items
            ToolStripComboBox1.SelectedIndex = 0
        End If
        If y < 1 Then
            MsgBox("No Ports Found!")
        End If
    End Sub
    Private Sub Refresh2()
        ProgressBar1.Value() = 0
        z = 0
        ProgressBar1.Visible = True
        Label8.Visible = True 'Refreshing.... Label
        Timer2.Enabled = True 'Refreshing... Timer
        'Deletes Refresh and all COM's to add new but not refresh
        Dim y As Integer = 0 'Orginally was just for this sub but timer3 also uses it
        Dim Ports As String() = IO.Ports.SerialPort.GetPortNames()
        ToolStripComboBox1.Items.Clear() 'Deletes all previous COM ports to ADD the current COM ports connected to computer
        'SerialPortToolStripMenuItem.DropDownItems.Clear()
        For Each Port In Ports
            ToolStripComboBox1.Items.Add(Port) 'Adds COM Ports to ComboBox
            'SerialPortToolStripMenuItem.DropDownItems.Add(Port) 'Adds COM Ports to Serial Port Menu
            y = y + 1
            ProgressBar1.Value() = y
        Next Port

        ProgressBar1.Maximum() = y
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        SerialPort1.Close()
        Refresh2()
    End Sub

    Private Sub Check()
        'SerialPortToolStripMenuItem.DropDownItems.
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Refresh1()
        Me.Refresh()
    End Sub

    Private Sub RefreshPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshPageToolStripMenuItem.Click
        WifiCamView.Refresh()
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Dim BX As Integer = Me.Size.Height - 87 'Backward X coordinate label1
        Dim FX As Integer = 45 'Foreward X coordinate label4
        'Label1.Location.X.Equals(FX)
        'Label4.Location.X.Equals(BX)
        Label9.Text = Me.Size.Height
        Label7.Text = WifiCamView.Size.Width
        Label6.Text = WifiCamView.Size.Height
        Label4.Location = New Point((Me.Size.Width / 2) - (Label4.Width / 2), Me.Size.Height - 82)
        Label1.Location = New Point((Me.Size.Width / 2) - (Label1.Width / 2), 45)
        Label2.Location = New Point(12, (Me.Size.Height / 2) - (Label2.Height / 2))
        Label3.Location = New Point(Me.Size.Width - 128, (Me.Size.Height / 2) - (Label3.Height / 2))
        ProgressBar1.Location = New Point(Me.Size.Width - 140, 27)
        Label8.Location = New Point(Me.Size.Width - 113, 53)
        btnOpen.Location = New Point(Me.Size.Width - 99, 293)
        btnClose.Location = New Point(Me.Size.Width - 99, 293)
        ComboBox1.Location = New Point(Me.Size.Width - 99, 322)
        Label5.Location = New Point(Me.Size.Width - 143, 325)
        'WifiCamView.Size = New Size(Me.Size.Width / 1.3, Me.Size.Height / 1.3)
        'WifiCamView.Location = New Point((Me.Size.Width / 2) - (WifiCamView.Size.Width / 2), (Me.Size.Height / 2) - (WifiCamView.Size.Height / 2))



    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.BackColor = Color.Black

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.BackColor = Color.White
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If Timer4.Enabled = False Then
            Timer4.Enabled = True
        ElseIf Timer4.Enabled = True Or Timer5.Enabled = True Then
            Timer4.Enabled = False
            Timer5.Enabled = False
        End If
    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        Timer4.Interval = TextBox1.Text
        Me.BackColor = Color.Black
        Timer4.Enabled = False
        Timer5.Enabled = True
    End Sub

    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        Timer5.Interval = TextBox1.Text
        Me.BackColor = Color.White
        Timer5.Enabled = False
        Timer4.Enabled = True
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        WifiCamView.Size = New Point(WifiCamView.Size.Width + 1, WifiCamView.Size.Height)
    End Sub

    Private Sub CamViewSizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CamViewSizeToolStripMenuItem.Click
        WifiCamView.Size = New Size(661, 506)
        WifiCamView.Location = New Point(317, WifiCamView.Location.Y)
    End Sub


    Private Sub WebPageViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebPageViewToolStripMenuItem.Click
        WifiCamView.Size = New Size(Me.Size.Width / 1.3, Me.Size.Height / 1.3)
        WifiCamView.Location = New Point(137, 90)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        WifiCamView.Size = New Point(WifiCamView.Size.Width, WifiCamView.Size.Height + 1)
    End Sub
End Class