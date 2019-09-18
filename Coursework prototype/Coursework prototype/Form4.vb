Public Class Form4
    Private Sub Form4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint

        Dim pen As New Pen(Color.FromArgb(255, 255, 0, 0))
        e.Graphics.DrawLine(pen, 0, Height \ 2, Width, Height \ 2)
        e.Graphics.DrawLine(pen, Width \ 2, 0, Width \ 2, Height)
        For i = 1 To 100
            e.Graphics.DrawLine(pen, Width \ 2, 0 + 15 * i, Width \ 2 + 5, 0 + 15 * i)
            e.Graphics.DrawLine(pen, 0 + 15 * i, Height \ 2 - 5, 0 + 15 * i, Height \ 2)
            e.Graphics.DrawString(i, New Font("Times New Roman", 6, FontStyle.Regular), Brushes.Black, -2 + 15 * i, Height \ 2)
            e.Graphics.DrawString(i, New Font("Times New Roman", 6, FontStyle.Regular), Brushes.Black, Width \ 2 + 2, -2 + 15 * i)
        Next
    End Sub
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class