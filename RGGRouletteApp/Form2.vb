Public Class Form2
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        System.Diagnostics.Process.Start("https://github.com/real-squid-kid/game-center-rucx-board")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        My.Computer.Audio.Play(My.Resources.whammy, AudioPlayMode.Background)
    End Sub
End Class