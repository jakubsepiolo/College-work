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

    End Sub
    Private Sub Resized(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        Invalidate()

    End Sub

    Private Function CoordinatesToNumber(ByVal X As Single, ByVal Y As Single) As Integer()
        If X > Width / 2 Then
            X = (X - Width / 2) \ 15
        ElseIf X < Width / 2 Then
            X = (-X + Width / 2) \ 15
        Else
            X = Width \ 30
        End If
        If Y > Height / 2 Then
            Y = (Y - Height / 2) \ 15
        ElseIf X < Height / 2 Then
            Y = (-Y + Height / 2) \ 15
        Else
            Y = Height \ 30
        End If
        Return {X, Y}
    End Function
    Private Sub DrawNumber(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseClick
        Dim X As Integer = e.X
        Dim Y As Integer = e.Y
        Dim Number() As Integer = CoordinatesToNumber(X, Y)
        Dim g As Graphics = Me.CreateGraphics
        Dim mybrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
        g.DrawEllipse(Pens.Blue, X, Y, 5, 5)
        g.DrawString(Number(0) & " " & Number(1) & "i", New Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, X, Y)
    End Sub
    Private Sub Form4_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        'Dim gradientscale As Single = Height / Width
        'For i = 0 To (Width / 1)


        '    Dim g As Graphics = Me.CreateGraphics
        '    Dim mybrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
        '    Dim x As Single = i * 1
        '    Dim y As Single = i * 1 * gradientscale
        '    g.FillRectangle(mybrush, x, Height - y, 3, 3)
        '    Threading.Thread.Sleep(1)
        'Next
        'For i = 0 To (Width / 1)


        '    Dim g As Graphics = Me.CreateGraphics
        '    Dim mybrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
        '    Dim x As Single = i * 1
        '    Dim y As Single = (i * 5 * gradientscale)
        '    g.FillRectangle(mybrush, x, Height - y, 3, 3)
        '    Threading.Thread.Sleep(1)
        'Next
        Dim g As Graphics = Me.CreateGraphics
        Dim pixelmultiplier As Integer = 15
        Dim mybrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
        Dim complex As New ComplexNumber(-13, -9)
        Dim x As Single = complex.RealPart
        Dim y As Single = complex.ComplexPart
        g.DrawLine(Pens.Black, Width \ 2, Height \ 2, (Width \ 2) + x * pixelmultiplier, (Height \ 2) - y * pixelmultiplier)
        g.DrawEllipse(Pens.Blue, (Width \ 2) + x * pixelmultiplier, (Height \ 2) - y * pixelmultiplier, 5, 5)
        g.DrawString(complex.Real & " " & complex.Complex & "i", New Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, (Width \ 2) + x * pixelmultiplier, (Height \ 2) - y * pixelmultiplier)


    End Sub


    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' DrawCircle(5, 5, 5)
        'ResizeRedraw = True


    End Sub
End Class