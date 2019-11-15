Imports System.Text.RegularExpressions
Public Class Form4
    'no more flickering but need tidy code
    Private GraphScale As Decimal = 20
    Dim PixelPerPoint As Integer = 15
    Private Points As New List(Of ComplexNumber)
    Public Inequalities As New List(Of String)
    Dim AxisFont As New Font("Arial", 6, FontStyle.Regular)
    Dim PointFont As New Font("Arial", 12, FontStyle.Regular)
    Dim ShowLabels As CheckBox = New CheckBox() With {.Text = "Display axis labels", .Checked = True}
    Dim ShowLoci As CheckBox = New CheckBox() With {.Text = "Display Loci", .Checked = False}
    Dim ColorList As New List(Of Color)


    Private Sub Form4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        ShowLabels.Location = New Point(2, Height - 80)
        ShowLoci.Location = New Point(2, Height - 60)
        LociButton.Location = New Point(Width - 75, Height - 70)
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

        If ShowLoci.Checked = True Then
            For f = 0 To Inequalities.Count - 1
                Dim One_A, One_B, One_C, One_D, One_E, Two_A, Two_B, Two_C, Two_D, Two_E As Integer
                Dim Equation1 As List(Of String)
                Dim Equation2 As List(Of String)
                If InStr(Inequalities(f), "=") > 0 Then
                    Equation1 = StringToEquation((Inequalities(f).Substring(0, InStr(Inequalities(f), "=") - 2)))
                ElseIf InStr(Inequalities(f), ">") > 0 Then
                    Equation1 = StringToEquation((Inequalities(f).Substring(0, InStr(Inequalities(f), ">") - 1)))
                ElseIf InStr(Inequalities(f), "<") > 0 Then
                    Equation1 = StringToEquation((Inequalities(f).Substring(0, InStr(Inequalities(f), "<") - 1)))
                End If
                If InStr(Inequalities(f), "=") > 0 Then
                    Equation2 = StringToEquation((Inequalities(f).Substring(InStr(Inequalities(f), "="), -InStr(Inequalities(f), "=") + Inequalities(f).Length)))
                ElseIf InStr(Inequalities(f), ">") > 0 Then
                    Equation2 = StringToEquation((Inequalities(f).Substring(InStr(Inequalities(f), ">"), -InStr(Inequalities(f), ">") + Inequalities(f).Length)))
                ElseIf InStr(Inequalities(f), "<") > 0 Then
                    Equation2 = StringToEquation((Inequalities(f).Substring(InStr(Inequalities(f), "<"), -InStr(Inequalities(f), "<") + Inequalities(f).Length)))
                End If
                One_A = Equation1(0)
                One_B = Equation1(1)
                One_C = Equation1(2)
                One_D = Equation1(3)
                One_E = Equation1(4)
                Two_A = Equation2(0)
                Two_B = Equation2(1)
                Two_C = Equation2(2)
                Two_D = Equation2(3)
                Two_E = Equation2(4)

                Dim Offset As Integer = Width \ 2
                Dim G As Graphics = CreateGraphics()
                Dim Multiplier As Integer = 200

                For i = 0 To Width Step 5
                    Dim a As Single = ((i - Offset) / PixelPerPoint) ^ 4 * One_A + ((i - Offset) / PixelPerPoint) ^ 3 * One_B + ((i - Offset) / PixelPerPoint) ^ 2 * One_C + One_D * ((i - Offset) / PixelPerPoint) + One_E
                    Dim b As Single = ((i - Offset) / PixelPerPoint) ^ 4 * Two_A + ((i - Offset) / PixelPerPoint) ^ 3 * Two_B + ((i - Offset) / PixelPerPoint) ^ 2 * Two_C + Two_D * ((i - Offset) / PixelPerPoint) + Two_E
                    For j = 0 To Height Step 5
                        If a > b Then
                            Dim aa As Single = j
                            Dim xx As Single = i
                            G.DrawEllipse(Pens.Blue, xx, aa, 1, 1)
                        End If
                    Next
                Next
                For i = 0 To Width * Multiplier Step 1
                    Dim a As Single = (((i / Multiplier) - Offset) / PixelPerPoint) ^ 4 * One_A + (((i / Multiplier) - Offset) / PixelPerPoint) ^ 3 * One_B + (((i / Multiplier) - Offset) / PixelPerPoint) ^ 2 * One_C + One_D * (((i / Multiplier) - Offset) / PixelPerPoint) + One_E
                    Dim b As Single = (((i / Multiplier) - Offset) / PixelPerPoint) ^ 4 * Two_A + (((i / Multiplier) - Offset) / PixelPerPoint) ^ 3 * Two_B + (((i / Multiplier) - Offset) / PixelPerPoint) ^ 2 * Two_C + Two_D * (((i / Multiplier) - Offset) / PixelPerPoint) + Two_E



                    Dim aa As Single = (Height / 2) - PixelPerPoint * a * (1 / GraphScale)
                    Dim bb As Single = (Height / 2) - PixelPerPoint * b * (1 / GraphScale)
                    Dim xx As Single = (i / Multiplier)
                    G.DrawEllipse(Pens.Black, xx, aa, 1, 2)
                    G.DrawEllipse(Pens.Green, xx, bb, 1, 2)




                Next
            Next

        End If
        For i = 1 To loopcount

            e.Graphics.DrawLine(AxisPen, Width \ 2, YOffset + PixelPerPoint * i, X, YOffset + PixelPerPoint * i)
            e.Graphics.DrawLine(AxisPen, XOffset + PixelPerPoint * i, Height \ 2 - 5, XOffset + PixelPerPoint * i, Height \ 2)

            If i Mod 2 = 0 And ShowLabels.Checked Then
                e.Graphics.DrawString((((Height \ (PixelPerPoint * 2)) - i) * GraphScale), AxisFont, Brushes.Black, X, -YOffset + PixelPerPoint * i)
                e.Graphics.DrawString(((-(Width \ (PixelPerPoint * 2)) - 1 + i) * GraphScale), AxisFont, Brushes.Black, XOffset + PixelPerPoint * i, Height \ 2)
            End If
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
            If InStr(Match.Value, "x") > 0 Then
                Coefficents.Add(Match.Value.Substring(0, InStr(Match.Value, "x") - 1))
            Else
                Coefficents.Add(Match.Value)
            End If

        Next
        For i = 0 To Coefficents.Count - 1
            If InStr(Coefficents(i), "+") <> Nothing Then
                Coefficents(i) = Coefficents(i).Substring(InStr(Coefficents(i), "+"), Coefficents(i).Length - 1)
            Else
                Continue For
            End If
        Next
        Return Coefficents
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
                    Inequalities.Clear()
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
        Controls.Add(ShowLabels)
        Controls.Add(ShowLoci)
        ColorList.Add(Color.Black)
        ColorList.Add(Color.Green)
        ColorList.Add(Color.Blue)
        ColorList.Add(Color.Firebrick)
        ColorList.Add(Color.Violet)
        ColorList.Add(Color.Moccasin)
    End Sub

    Public Sub GraphInequality(Line1 As String, Line2 As String, Inequality As String)

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles LociButton.Click


        StringToEquation("3x^3+7x^2-23x-12")
        Form5.Show()
    End Sub
End Class