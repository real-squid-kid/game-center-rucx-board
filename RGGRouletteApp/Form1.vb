Module Module1

    Public Panels As Label() = {Form1.Panel1Lbl, Form1.Panel2Lbl, Form1.Panel3Lbl, Form1.Panel4Lbl, Form1.Panel5Lbl, Form1.Panel6Lbl, Form1.Panel7Lbl, Form1.Panel8Lbl, Form1.Panel9Lbl, Form1.Panel10Lbl, Form1.Panel11Lbl, Form1.Panel12Lbl, Form1.Panel13Lbl, Form1.Panel14Lbl, Form1.Panel15Lbl, Form1.Panel16Lbl, Form1.Panel17Lbl, Form1.Panel18Lbl}
End Module

Public Class Form1

    Dim GamesList As String()
    Dim CurrentFlash As Byte = 0
    Dim Reveal As Byte = 18
    Dim PanelColor As Integer() = {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}
    Dim PanelTextShown As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    Dim isPlaying As Boolean = False

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        'For a = 0 To 16 Step 1
        'PanelColor(a) = Int(Rnd() * 6) * 2
        'Next
        UpdateBoard()
        FlashTimer.Interval = TextBox1.Text
        FlashTimer.Enabled = True
        ChangeTimer.Enabled = True
        If CheckBox3.Checked = True Then My.Computer.Audio.Play(My.Resources.board, AudioPlayMode.Background)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentFlash = 0
        Randomize()
        UpdateBoard()
        Dim linecount As Long = TextBox2.Lines.Length - 1
        GamesList = TextBox2.Lines
    End Sub

    Private Sub FlashTimer_Tick(sender As Object, e As EventArgs) Handles FlashTimer.Tick
        UpdateBoard()
        Dim rand As Byte
        '<костыль>
        rand = Int(Rnd() * 17)
        If rand = CurrentFlash Then
            rand = rand + 1
            If rand = 17 Then rand = 0
        End If
        '</костыль>
        CurrentFlash = rand
        Console.Write(CurrentFlash)
        UpdateBoard()
        If CheckBox2.Checked = True Then
            If Reveal < 18 Then
                PanelTextShown(Reveal) = True
                Reveal = Reveal + 1
            Else
                ChangeTimer.Enabled = True
                CheckBox1.Checked = True
            End If
        End If

    End Sub
    Sub UpdateBoard()
        'это крайне херовый кусок кода извините
        For a = 0 To 17 Step 1

            Select Case PanelColor(a)
                Case 1
                    Panels(a).BackColor = Color.DarkSlateGray
                Case 2
                    Panels(a).BackColor = Color.Brown
                Case 3
                    Panels(a).BackColor = Color.OrangeRed
                Case 4
                    Panels(a).BackColor = Color.DarkOliveGreen
                Case 5
                    Panels(a).BackColor = Color.Navy
                Case 6
                    Panels(a).BackColor = Color.MediumOrchid
                Case Else
                    Panels(a).BackColor = Color.Indigo
            End Select
            If PanelTextShown(a) = True Then
                Panels(a).ForeColor = Color.White
            Else
                Panels(a).ForeColor = Panels(a).BackColor
            End If
        Next
        Panels(CurrentFlash).BackColor = Color.Yellow
        If PanelTextShown(CurrentFlash) = True Then Panels(CurrentFlash).ForeColor = Color.Black Else Panels(CurrentFlash).ForeColor = Color.Yellow
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        My.Computer.Audio.Stop()
        FlashTimer.Enabled = False
        ChangeTimer.Enabled = False
        isPlaying = False
    End Sub

    Private Sub ChangeTimer_Tick(sender As Object, e As EventArgs) Handles ChangeTimer.Tick
        For a = 0 To 17 Step 1
            PanelColor(a) = Int(Rnd() * 6) + 1
            Panels(a).Text = GamesList(Int(Rnd() * GamesList.Length))
            If a <> 0 Then
                While PanelColor(a) = PanelColor(a - 1)
                    PanelColor(a) = Int(Rnd() * 6)
                End While
            Else
                While PanelColor(a) = PanelColor(17)
                    PanelColor(a) = Int(Rnd() * 6)
                End While
            End If
        Next
        UpdateBoard()
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            For a = 0 To 17 Step 1
                PanelTextShown(a) = True
            Next
        Else
            For a = 0 To 17 Step 1
                PanelTextShown(a) = False
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For a = 0 To 17 Step 1
            PanelColor(a) = Int(Rnd() * 6) + 1
            Panels(a).Text = GamesList(Int(Rnd() * GamesList.Length))
            If a <> 0 Then
                While PanelColor(a) = PanelColor(a - 1)
                    PanelColor(a) = Int(Rnd() * 6)
                End While
            Else
                While PanelColor(a) = PanelColor(17)
                    PanelColor(a) = Int(Rnd() * 6)
                End While
            End If
        Next
        UpdateBoard()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CheckBox3.Checked = True Then My.Computer.Audio.Play(My.Resources.revealandboard, AudioPlayMode.Background)
        'For a = 0 To 16 Step 1
        'PanelColor(a) = Int(Rnd() * 6) * 2
        'Next
        UpdateBoard()
        Reveal = 0
        FlashTimer.Interval = TextBox1.Text
        FlashTimer.Enabled = True
        ChangeTimer.Enabled = False
        CheckBox2.Checked = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GamesList = TextBox2.Lines
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        My.Computer.Audio.Play(My.Resources.opening, AudioPlayMode.Background)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        My.Computer.Audio.Play(My.Resources.theme, AudioPlayMode.Background)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form2.Show()
    End Sub
End Class
