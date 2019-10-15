Public Class Form4
    Private GraphScale As Decimal = 1
    Dim PixelPerPoint As Integer = 15
    Private Points As New List(Of ComplexNumber)
    Dim AxisFont As New Font("Arial", 6, FontStyle.Regular)
    Dim PointFont As New Font("Arial", 12, FontStyle.Regular)
    Private Sub DrawGrid()

        Dim AxisPen As New Pen(Color.FromArgb(255, 255, 0, 0))
        Dim g As Graphics = CreateGraphics()
        Dim X As Integer = Width \ 2 + 6
        Dim XOffset As Integer = -7
        Dim YOffset As Integer = 3
        Dim loopcount As Integer

        g.DrawLine(AxisPen, 0, Height \ 2, Width, Height \ 2)
        g.DrawLine(AxisPen, Width \ 2, 0, Width \ 2, Height)


        If Width / 7 < Height / 7 Then
            loopcount = Height / 7
        Else
            loopcount = Width / 7
        End If

        For i = 1 To loopcount

            g.DrawLine(AxisPen, Width \ 2, YOffset + PixelPerPoint * i, X, YOffset + PixelPerPoint * i)
            g.DrawLine(AxisPen, XOffset + PixelPerPoint * i, Height \ 2 - 5, XOffset + PixelPerPoint * i, Height \ 2)

            If i Mod 2 = 0 Then
                g.DrawString((((Height \ (PixelPerPoint * 2)) - i) * GraphScale), AxisFont, Brushes.Black, X, -YOffset + PixelPerPoint * i)
                g.DrawString(((-(Width \ (PixelPerPoint * 2)) - 1 + i) * GraphScale), AxisFont, Brushes.Black, XOffset + PixelPerPoint * i, Height \ 2)
            End If
        Next
    End Sub

    Private Sub Form4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        Dim AxisPen As New Pen(Color.FromArgb(255, 255, 0, 0))
        Dim g As Graphics = CreateGraphics()
        Dim X As Integer = Width \ 2 + 6
        Dim XOffset As Integer = -7
        Dim YOffset As Integer = 3
        Dim loopcount As Integer

        g.DrawLine(AxisPen, 0, Height \ 2, Width, Height \ 2)
        g.DrawLine(AxisPen, Width \ 2, 0, Width \ 2, Height)

        If Width / 7 < Height / 7 Then
            loopcount = Height / 7
        Else
            loopcount = Width / 7
        End If

        For i = 1 To loopcount

            g.DrawLine(AxisPen, Width \ 2, YOffset + PixelPerPoint * i, X, YOffset + PixelPerPoint * i)
            g.DrawLine(AxisPen, XOffset + PixelPerPoint * i, Height \ 2 - 5, XOffset + PixelPerPoint * i, Height \ 2)

            If i Mod 2 = 0 Then
                g.DrawString((((Height \ (PixelPerPoint * 2)) - i) * GraphScale), AxisFont, Brushes.Black, X, -YOffset + PixelPerPoint * i)
                g.DrawString(((-(Width \ (PixelPerPoint * 2)) - 1 + i) * GraphScale), AxisFont, Brushes.Black, XOffset + PixelPerPoint * i, Height \ 2)
            End If
        Next

        For i = 0 To Points.Count - 1
            DrawNumber(NumbersToCoordinate(Points(i))(0), NumbersToCoordinate(Points(i))(1))
            g.DrawString(Points(i).Real & " " & Points(i).Complex & "i", PointFont, Brushes.Black, NumbersToCoordinate(Points(i))(0), NumbersToCoordinate(Points(i))(1))
        Next
    End Sub

    Private Sub Resized(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        Invalidate()
    End Sub

    Private Function CoordinatesToNumber(ByVal X As Integer, ByVal Y As Integer) As Decimal()

        If X > Width / 2 Then
            X = (X - Width / 2) / PixelPerPoint
        ElseIf X < Width / 2 Then
            X = (-X + Width / 2) / PixelPerPoint
            X = -X
        Else
            X = 0
        End If

        If Y > Height / 2 Then
            Y = (Y - Height / 2) / PixelPerPoint
            Y = -Y
        ElseIf X < Height / 2 Then
            Y = (-Y + Height / 2) / PixelPerPoint
        Else
            Y = 0
        End If

        Return {Math.Round(X, 5) * GraphScale, Math.Round(Y, 5) * GraphScale}
    End Function

    Public Function NumbersToCoordinate(ByVal Number As ComplexNumber) As Integer()
        Dim X, Y As Integer

        If Number.Real <> 0 Then
            X = (Width / 2) + PixelPerPoint * Number.Real * (1 / GraphScale)
        Else
            X = Width / 2
        End If

        If Number.Complex <> 0 Then
            Y = (Height / 2) - PixelPerPoint * Number.Complex * (1 / GraphScale)

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
        Dim Modulus As Single = (Complex.Modulus) * (PixelPerPoint / 2)
        Dim g As Graphics = Me.CreateGraphics
        Dim mybrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))

        X = NumbersToCoordinate(Complex)(0)
        Y = NumbersToCoordinate(Complex)(1)

        g.DrawEllipse(Pens.Blue, (X - 3), (Y - 4), 5, 5)
        Dim A As Single = -(Complex.Argument * 180 / 3.14)

        g.DrawLine(Pens.Black, Width \ 2, Height \ 2, X, Y)
        g.DrawArc(Pens.Black, Width \ 2 - Modulus \ 2, Height \ 2 - Modulus \ 2, Modulus, Modulus, 0, A)
    End Sub

    Private Sub Mouse_Click(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseClick
        Dim g As Graphics = Me.CreateGraphics

        Select Case e.Button
            Case MouseButtons.Left

                DrawNumber(e.X, e.Y)
                Points.Add(New ComplexNumber(CoordinatesToNumber(e.X, e.Y)(0), CoordinatesToNumber(e.X, e.Y)(1)))
                g.DrawString(Points(Points.Count - 1).Real & " " & Points(Points.Count - 1).Complex & "i", PointFont, Brushes.Black, NumbersToCoordinate(Points(Points.Count - 1))(0), NumbersToCoordinate(Points(Points.Count - 1))(1))

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

        If e.Delta < 0 Then
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