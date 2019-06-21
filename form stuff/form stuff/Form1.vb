Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        For i = 0 To (Size.Width / 50)
            For j = 0 To (Size.Height / 50)
                Dim g As Graphics = Me.CreateGraphics
                Dim mybrush = New SolidBrush(Color.FromArgb(255, Int(Rnd() * 255), Int(Rnd() * 255) Mod 4, Int(Rnd() * 255) Mod 150))
                Dim x As Single = i * 50
                Dim y As Single = j * 50
                g.FillRectangle(mybrush, x, y, 50, 50)
            Next
        Next
        If e.Button And MouseButtons.Left Then
            Dim g As Graphics = Me.CreateGraphics
            Dim mybrush = New SolidBrush(Color.FromArgb(255, Int(Rnd() * 255), Int(Rnd() * 255), Int(Rnd() * 255)))

            g.FillEllipse(mybrush, e.X, e.Y, 20, 20)
        End If
    End Sub
End Class
