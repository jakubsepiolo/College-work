Public Class Form4
    Private GraphScale As Decimal = 1
    Private Points As New List(Of ComplexNumber)
    Private Sub DrawGrid()
        Dim pen As New Pen(Color.FromArgb(255, 255, 0, 0))
        Dim g As Graphics = CreateGraphics()
        g.DrawLine(pen, 0, Height \ 2, Width, Height \ 2)
        g.DrawLine(pen, Width \ 2, 0, Width \ 2, Height)
        Dim loopn As Integer
        If Width / 7 < Height / 7 Then
            loopn = Height / 7
        Else
            loopn = Width / 7
        End If
        For i = 1 To loopn
            g.DrawLine(pen, Width \ 2, 3 + 15 * i, Width \ 2 + 5, 3 + 15 * i)
            g.DrawLine(pen, -7 + 15 * i, Height \ 2 - 5, -7 + 15 * i, Height \ 2)
            If i Mod 2 = 0 Then
                g.DrawString((((Height \ 30) - i) * GraphScale), New Font("Arial", 6, FontStyle.Regular), Brushes.Black, Width \ 2 + 6, -2 + 15 * i)

                g.DrawString(((-(Width \ 30) - 1 + i) * GraphScale), New Font("Arial", 6, FontStyle.Regular), Brushes.Black, -8 + 15 * i, Height \ 2)

            End If

        Next
    End Sub

    Private Sub Form4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        Dim pen As New Pen(Color.FromArgb(255, 255, 0, 0))
        Dim g As Graphics = CreateGraphics()
        g.DrawLine(pen, 0, Height \ 2, Width, Height \ 2)
        g.DrawLine(pen, Width \ 2, 0, Width \ 2, Height)
        Dim loopn As Integer
        If Width / 7 < Height / 7 Then
            loopn = Height / 7
        Else
            loopn = Width / 7
        End If
        For i = 1 To loopn
            g.DrawLine(pen, Width \ 2, 3 + 15 * i, Width \ 2 + 5, 3 + 15 * i)
            g.DrawLine(pen, -7 + 15 * i, Height \ 2 - 5, -7 + 15 * i, Height \ 2)
            If i Mod 2 = 0 Then
                g.DrawString((((Height \ 30) - i) * GraphScale), New Font("Arial", 6, FontStyle.Regular), Brushes.Black, Width \ 2 + 6, -2 + 15 * i)

                g.DrawString(((-(Width \ 30) - 1 + i) * GraphScale), New Font("Arial", 6, FontStyle.Regular), Brushes.Black, -8 + 15 * i, Height \ 2)

            End If

        Next
        For i = 0 To Points.Count - 1
            DrawNumber(NumbersToCoordinate(Points(i))(0), NumbersToCoordinate(Points(i))(1))
            g.DrawString(Points(i).Real & " " & Points(i).Complex & "i", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, NumbersToCoordinate(Points(i))(0), NumbersToCoordinate(Points(i))(1))
        Next
    End Sub

    Private Sub Resized(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        Invalidate()

    End Sub

    Private Function CoordinatesToNumber(ByVal X As Integer, ByVal Y As Integer) As Decimal()
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
        Return {Math.Round(X, 5) * GraphScale, Math.Round(Y, 5) * GraphScale}

    End Function

    Public Function NumbersToCoordinate(ByVal Number As ComplexNumber) As Integer()
        Dim X, Y As Integer
        If Number.Real <> 0 Then
            X = (Width / 2) + 15 * Number.Real * (1 / GraphScale)
        Else
            X = Width / 2
        End If
        If Number.Complex <> 0 Then
            Y = (Height / 2) - 15 * Number.Complex * (1 / GraphScale)

        Else
            Y = Height / 2 
        End If
        Return {X , Y}
    End Function
    Private Sub DrawNumber(ByVal x1 As Integer, y1 As Integer)
        Dim X As Integer = x1
        Dim Y As Integer = y1
        Dim Number() As Decimal = CoordinatesToNumber(X, Y)
        Dim Complex As New ComplexNumber(Number(0), Number(1))
        X = NumbersToCoordinate(Complex)(0)
        Y = NumbersToCoordinate(Complex)(1)
        Dim g As Graphics = Me.CreateGraphics
        Dim mybrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
        g.DrawEllipse(Pens.Blue, (X - 3), (Y - 4), 5, 5)

        Dim a As Single = (Complex.Modulus) * 8
        g.DrawLine(Pens.Black, Width \ 2, Height \ 2, X, Y)
        g.DrawArc(Pens.Black, Width \ 2 - a \ 2, Height \ 2 - a \ 2, a, a, 0, -Int(Complex.Argument * 180 \ 3.14))
    End Sub

    Private Sub Mouse_Click(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseClick
        Dim g As Graphics = Me.CreateGraphics
        Select Case e.Button
            Case MouseButtons.Left
                DrawNumber(e.X, e.Y)
                Points.Add(New ComplexNumber(CoordinatesToNumber(e.X, e.Y)(0), CoordinatesToNumber(e.X, e.Y)(1)))
                g.DrawString(Points(Points.Count - 1).Real & " " & Points(Points.Count - 1).Complex & "i", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, NumbersToCoordinate(Points(Points.Count - 1))(0), NumbersToCoordinate(Points(Points.Count - 1))(1))
            Case MouseButtons.Right
                Dim prompt As DialogResult = MessageBox.Show("Are you sure you want to clear the graph?", "Are you sure?", MessageBoxButtons.YesNo)
                If prompt = DialogResult.Yes Then
                    CreateGraphics.Clear(Color.FromKnownColor(KnownColor.Control))
                    Points.Clear()
                    DrawGrid()
                End If
        End Select

    End Sub

    Private Sub ScrollWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel

        If e.Delta > 0 Then
            If GraphScale + 0.1 = 0 Then
                GraphScale = 0.1
            Else

                GraphScale += 0.1
            End If
        Else
            If GraphScale - 0.1 = 0 Then
                GraphScale = 0.1
            Else
                GraphScale -= 0.1
            End If
        End If
        Invalidate()
    End Sub


    Private Sub Form4_Displayed(sender As Object, e As EventArgs) Handles Me.Shown

        DrawGrid()
        Randomize()
        'For i = 0 To 10
        'Points.Add(New ComplexNumber(Int(-10 + Rnd() * 25), Int(-10 + Rnd() * 25)))
        'Next
    End Sub

    Private Sub Form4_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class