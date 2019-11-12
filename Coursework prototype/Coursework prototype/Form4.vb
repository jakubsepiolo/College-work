Imports System.Text.RegularExpressions
Public Class Form4
    'no more flickering but need tidy code
    Private GraphScale As Decimal = 1
    Dim PixelPerPoint As Integer = 15
    Private Points As New List(Of ComplexNumber)
    Private Equations As New List(Of ComplexNumber)
    Dim AxisFont As New Font("Arial", 6, FontStyle.Regular)
    Dim PointFont As New Font("Arial", 12, FontStyle.Regular)


    Private Sub Form4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        Dim AxisPen As New Pen(Color.FromArgb(255, 255, 0, 0))
        Dim X As Integer = Width \ 2 + 6
        Dim XOffset As Integer = -7
        Dim YOffset As Integer = 3
        Dim loopcount As Integer

        e.Graphics.DrawLine(AxisPen, 0, Height \ 2, Width, Height \ 2)
        e.Graphics.DrawLine(AxisPen, Width \ 2, 0, Width \ 2, Height)

        If Width / 7 < Height / 7 Then
            loopcount = Height / 7
        Else
            loopcount = Width / 7
        End If

        For i = 1 To loopcount

            e.Graphics.DrawLine(AxisPen, Width \ 2, YOffset + PixelPerPoint * i, X, YOffset + PixelPerPoint * i)
            e.Graphics.DrawLine(AxisPen, XOffset + PixelPerPoint * i, Height \ 2 - 5, XOffset + PixelPerPoint * i, Height \ 2)

            If i Mod 2 = 0 Then
                e.Graphics.DrawString((((Height \ (PixelPerPoint * 2)) - i) * GraphScale), AxisFont, Brushes.Black, X, -YOffset + PixelPerPoint * i)
                e.Graphics.DrawString(((-(Width \ (PixelPerPoint * 2)) - 1 + i) * GraphScale), AxisFont, Brushes.Black, XOffset + PixelPerPoint * i, Height \ 2)
            End If
        Next

        For i = 0 To Equations.Count - 1

        Next

        For i = 0 To Points.Count - 1
            Dim Xb As Integer = NumbersToCoordinate(Points(i))(0)
            Dim yb As Integer = NumbersToCoordinate(Points(i))(1)
            Dim Number() As Decimal = CoordinatesToNumber(Xb, yb)
            Dim Complex As New ComplexNumber(Number(0), Number(1))
            Dim Modulus As Single = (Complex.Modulus) * (PixelPerPoint / 2) * (1 / GraphScale)

            Dim mybrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))

            Xb = NumbersToCoordinate(Complex)(0)
            yb = NumbersToCoordinate(Complex)(1)

            e.Graphics.DrawEllipse(Pens.Blue, (Xb - 3), (yb - 4), 5, 5)
            Dim A As Single = -(Complex.Argument * 180 / 3.14)

            e.Graphics.DrawLine(Pens.Black, Width \ 2, Height \ 2, Xb, yb)
            e.Graphics.DrawArc(Pens.Black, Width \ 2 - Modulus \ 2, Height \ 2 - Modulus \ 2, Modulus, Modulus, 0, A)
            e.Graphics.DrawString(Points(i).Real & " " & Points(i).Complex & "i" & vbCrLf & Points(i).ModulusArgument, PointFont, Brushes.Black, NumbersToCoordinate(Points(i))(0), NumbersToCoordinate(Points(i))(1))
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
        ElseIf Y < Height / 2 Then
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

        Return {X, Y}
    End Function

    Private Function StringToEquation(ByVal Text As String) As List(Of String)
        Dim Coefficents As New List(Of String)
        Dim RegPattern As New Regex("[+-]?[^-+]+")
        For Each Match As Match In RegPattern.Matches(Text)
            Coefficents.Add(Match.Value)
        Next
    End Function


    Private Sub Mouse_Click(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseClick


        Select Case e.Button
            Case MouseButtons.Left


                Points.Add(New ComplexNumber(CoordinatesToNumber(e.X, e.Y)(0), CoordinatesToNumber(e.X, e.Y)(1)))
                Invalidate()
            Case MouseButtons.Right
                Dim prompt As DialogResult = MessageBox.Show("Are you sure you want to clear the graph?", "Are you sure?", MessageBoxButtons.YesNo)

                If prompt = DialogResult.Yes Then
                    CreateGraphics.Clear(Color.FromKnownColor(KnownColor.Control))
                    Points.Clear()
                    Equations.Clear()
                    GraphScale = 1
                    Invalidate()
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
        Invalidate()
        Randomize()
        DoubleBuffered = True
        'For i = 0 To 10
        'Points.Add(New ComplexNumber(Int(-10 + Rnd() * 25), Int(-10 + Rnd() * 25)))
        'Next
    End Sub

    Private Sub Form4_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles LociButton.Click
        Dim Z As Integer = -1
        Dim L As Integer = 13
        Dim M As Integer = 7
        Dim C As Integer = 0

        Dim Offset As Integer = Width \ 2
        Dim G As Graphics = CreateGraphics()
        Dim Multiplier As Integer = 20

        For i = 0 To Width Step 3
            Dim a As Single = ((i - Offset) / PixelPerPoint) ^ 3 * Z + ((i - Offset) / PixelPerPoint) ^ 2 * L + M * ((i - Offset) / PixelPerPoint) + C
            For j = Height / 2 To -Height / 2 Step -3
                Dim y As Single = j
                If y > Height / 2 Then
                    y = (y - Height / 2) / PixelPerPoint
                    y = -y
                ElseIf y < Height / 2 Then
                    y = (-y + Height / 2) / PixelPerPoint
                Else
                    y = 0
                End If
                If a - y * GraphScale > 0 Then
                    Dim aa As Single = j
                    Dim x As Single = i
                    G.DrawEllipse(Pens.Blue, x, aa, 1, 2)
                End If
            Next


        Next
        For i = 0 To Width * Multiplier Step 1
            Dim a As Single = (((i / Multiplier) - Offset) / PixelPerPoint) ^ 3 * Z + (((i / Multiplier) - Offset) / PixelPerPoint) ^ 2 * L + M * (((i / Multiplier) - Offset) / PixelPerPoint) + C



            Dim aa As Single = (Height / 2) - PixelPerPoint * a * (1 / GraphScale)
            Dim x As Single = (i / Multiplier)
            G.DrawEllipse(Pens.Black, x, aa, 1, 2)




        Next
        StringToEquation("3x^3+7x^2-23x-12")
    End Sub
End Class