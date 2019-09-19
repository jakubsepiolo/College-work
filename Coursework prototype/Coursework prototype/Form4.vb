Public Class Form4
    Private Sub DrawCircle(ByVal radius As Integer, ByVal x As Integer, ByVal y As Integer)
        Dim myGraphics As Graphics = Me.CreateGraphics
        Dim myPen As Pen
        myPen = New Pen(Brushes.DarkMagenta, 20)
        myGraphics.DrawLine(myPen, 60, 180, 220, 50)
    End Sub

    Private Sub Form4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint

        Dim pen As New Pen(Color.FromArgb(255, 255, 0, 0))
        e.Graphics.DrawLine(pen, 0, Height \ 2, Width, Height \ 2)
        e.Graphics.DrawLine(pen, Width \ 2, 0, Width \ 2, Height)
        For i = 1 To 100
            e.Graphics.DrawLine(pen, Width \ 2, 3 + 15 * i, Width \ 2 + 5, 3 + 15 * i)
            e.Graphics.DrawLine(pen, 0 + 15 * i, Height \ 2 - 5, 0 + 15 * i, Height \ 2)
            If i Mod 2 = 0 Then
                e.Graphics.DrawString((24 - i) * 1, New Font("Times New Roman", 6, FontStyle.Regular), Brushes.Black, Width \ 2 + 6, -2 + 15 * i)

                e.Graphics.DrawString((-42 + i) * 1, New Font("Times New Roman", 6, FontStyle.Regular), Brushes.Black, -4 + 15 * i, Height \ 2)

            End If

        Next
        e.Graphics.DrawLine(pen, 0, Height, Width, 0)

    End Sub
    Private Sub Resized(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        Invalidate()

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' DrawCircle(5, 5, 5)
        'ResizeRedraw = True


    End Sub
End Class