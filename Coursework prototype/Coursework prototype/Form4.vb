Public Class Form4
    Private Sub DrawCircle(ByVal radius As Integer, ByVal x As Integer, ByVal y As Integer)
        Dim myGraphics As Graphics = Me.CreateGraphics
        Dim myPen As Pen
        myPen = New Pen(Brushes.DarkMagenta, 20)
        myGraphics.DrawLine(myPen, 60, 180, 220, 50)
    End Sub

    Private Sub DrawGrid()
        Dim pen As New Pen(Color.FromArgb(255, 255, 0, 0))
        Dim g As Graphics = CreateGraphics()
        g.DrawLine(pen, 0, Height \ 2, Width, Height \ 2)
        g.DrawLine(pen, Width \ 2, 0, Width \ 2, Height)
        For i = 1 To Width \ 7
            g.DrawLine(pen, Width \ 2, 3 + 15 * i, Width \ 2 + 5, 3 + 15 * i)
            g.DrawLine(pen, -7 + 15 * i, Height \ 2 - 5, -7 + 15 * i, Height \ 2)
            If i Mod 2 = 0 Then
                g.DrawString(((Height \ 30) - i) * 1, New Font("Times New Roman", 6, FontStyle.Regular), Brushes.Black, Width \ 2 + 6, -2 + 15 * i)

                g.DrawString((-(Width \ 30) - 1 + i) * 1, New Font("Times New Roman", 6, FontStyle.Regular), Brushes.Black, -8 + 15 * i, Height \ 2)

            End If

        Next
    End Sub

    Private Sub Form4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        Dim pen As New Pen(Color.FromArgb(255, 255, 0, 0))
        Dim g As Graphics = CreateGraphics()
        g.DrawLine(pen, 0, Height \ 2, Width, Height \ 2)
        g.DrawLine(pen, Width \ 2, 0, Width \ 2, Height)
        For i = 1 To Width \ 7
            g.DrawLine(pen, Width \ 2, 3 + 15 * i, Width \ 2 + 5, 3 + 15 * i)
            g.DrawLine(pen, -7 + 15 * i, Height \ 2 - 5, -7 + 15 * i, Height \ 2)
            If i Mod 2 = 0 Then
                g.DrawString(((Height \ 30) - i) * 1, New Font("Times New Roman", 6, FontStyle.Regular), Brushes.Black, Width \ 2 + 6, -2 + 15 * i)

                g.DrawString((-(Width \ 30) - 1 + i) * 1, New Font("Times New Roman", 6, FontStyle.Regular), Brushes.Black, -8 + 15 * i, Height \ 2)

            End If

        Next
    End Sub

    Private Sub Resized(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        Invalidate()

    End Sub

    Private Function CoordinatesToNumber(ByVal X As Integer, ByVal Y As Integer) As Integer()
        If X > Width / 2 Then
            X = (X - Width / 2) / 15
        ElseIf X < Width / 2 Then
            X = (-X + Width / 2) / 15
            X = -X
        Else
            X = 0
        End If
        If Y > Height / 2 Then
            Y = (Y - Height / 2) / 15
            Y = -Y
        ElseIf X < Height / 2 Then
            Y = (-Y + Height / 2) / 15
        Else
            Y = 0
        End If
        Return {Math.Round(X, 2), Math.Round(Y, 2)}
    End Function
    Private Sub DrawNumber(ByVal x1 As Integer, y1 As Integer)
        Dim X As Integer = x1
        Dim Y As Integer = y1
        Dim Number() As Integer = CoordinatesToNumber(X, Y)
        Dim g As Graphics = Me.CreateGraphics
        Dim mybrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
        g.DrawEllipse(Pens.Blue, X, Y, 5, 5)
        g.DrawString(Number(0) & " " & Number(1) & "i", New Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, X, Y)
    End Sub

    Private Sub Mouse_Click(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseClick
        Select Case e.Button
            Case MouseButtons.Left
                DrawNumber(e.X, e.Y)
            Case MouseButtons.Right
                Dim prompt As  DialogResult = MessageBox.Show("Are you sure you want to clear the graph?", "Are you sure?", MessageBoxButtons.YesNo)
                If prompt = DialogResult.Yes Then
                    CreateGraphics.Clear(Color.FromKnownColor(KnownColor.Control))
                    DrawGrid()
                End If
        End Select

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
        'Dim g As Graphics = Me.CreateGraphics
        'Dim pixelmultiplier As Integer = 15
        'Dim mybrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
        'Dim complex As New ComplexNumber(-13, -9)
        'Dim x As Single = complex.RealPart
        'Dim y As Single = complex.ComplexPart
        'g.DrawLine(Pens.Black, Width \ 2, Height \ 2, (Width \ 2) + x * pixelmultiplier, (Height \ 2) - y * pixelmultiplier)
        'g.DrawEllipse(Pens.Blue, (Width \ 2) + x * pixelmultiplier, (Height \ 2) - y * pixelmultiplier, 5, 5)
        'g.DrawString(complex.Real & " " & complex.Complex & "i", New Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, (Width \ 2) + x * pixelmultiplier, (Height \ 2) - y * pixelmultiplier)


    End Sub


    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles Me.Shown

        DrawGrid()

    End Sub
End Class