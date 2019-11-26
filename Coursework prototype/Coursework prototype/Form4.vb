Imports System.Text.RegularExpressions
Public Class Form4
    'no more flickering but need tidy code
    Private GraphScale As Decimal = 1   
    Dim PixelPerPoint As Integer = 15
    Private Points As New List(Of ComplexNumber)
    Public Inequalities As New List(Of String)
    Dim AxisFont As New Font("Arial", 6, FontStyle.Regular)
    Dim PointFont As New Font("Arial", 12, FontStyle.Regular)
    Friend WithEvents ShowLabels As CheckBox = New CheckBox() With {.Text = "Display axis labels", .Checked = True}
    Friend WithEvents ShowLoci As CheckBox = New CheckBox() With {.Text = "Display Loci", .Checked = False}
    Friend WithEvents ShowComplexPoints As CheckBox = New CheckBox() With {.Text = "Display Complex points", .Checked = False}
    Dim PenList() As Pen = {Pens.Black, Pens.Blue, Pens.Green, Pens.Firebrick, Pens.Violet, Pens.Maroon}


    Private Sub Form4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = e.Graphics.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = e.Graphics.TextRenderingHint.AntiAlias
        ShowLabels.Location = New Point(2, Height - 80)
        ShowLoci.Location = New Point(2, Height - 60)
        ShowComplexPoints.Location = New Point(2, Height - 100)
        LociButton.Location = New Point(Width - 75, Height - 70)
        Dim AxisPen As New Pen(Color.FromArgb(255, 255, 0, 0))
        Dim X As Integer = Width \ 2 + 6
        Dim XOffset As Integer = -7
        Dim YOffset As Integer = 3
        Dim loopcount As Integer
        Dim l As Single = 0.1

        e.Graphics.DrawLine(AxisPen, 0, Height \ 2, Width, Height \ 2)
        e.Graphics.DrawLine(AxisPen, Width \ 2, 0, Width \ 2, Height)

        If Width / 7 < Height / 7 Then
            loopcount = Height / 7
        Else
            loopcount = Width / 7
        End If

        If ShowLoci.Checked = True Then
            For f = 0 To Inequalities.Count - 1
                Dim EquationList As List(Of String)() = InequalityToEquation(Inequalities(f))
                Dim Offset As Integer = Width \ 2
                Dim Multiplier As Integer = 50

                For i = 0 To Width Step 5
                    Dim a As Single
                    Dim b As Single
                    Try
                        a = (((i - Offset) / PixelPerPoint) * GraphScale) ^ 4 * EquationList(0)(0) + (((i - Offset) / PixelPerPoint) * GraphScale) ^ 3 * EquationList(0)(1) + (((i - Offset) / PixelPerPoint) * GraphScale) ^ 2 * EquationList(0)(2) + EquationList(0)(3) * (((i - Offset) / PixelPerPoint) * GraphScale) + EquationList(0)(4)
                        b = (((i - Offset) / PixelPerPoint) * GraphScale) ^ 4 * EquationList(1)(0) + (((i - Offset) / PixelPerPoint) * GraphScale) ^ 3 * EquationList(1)(1) + (((i - Offset) / PixelPerPoint) * GraphScale) ^ 2 * EquationList(1)(2) + EquationList(1)(3) * (((i - Offset) / PixelPerPoint) * GraphScale) + EquationList(1)(4)
                    Catch ex As InvalidCastException
                        MsgBox($"One or more of your equations was invalid{vbCrLf}{vbCrLf}{ex.Message}{vbCrLf}{vbCrLf}Please input your equations again")
                        Exit For
                    End Try
                    For j = 0 To Height Step 5
                        If a > b And EquationList(2)(0) = ">" Then
                            Dim aa As Single = j
                            Dim xx As Single = i
                            e.Graphics.DrawEllipse(PenList(f), xx, aa + f * 2, l, l)
                        ElseIf a < b And EquationList(2)(0) = "<" Then
                            Dim aa As Single = j
                            Dim xx As Single = i
                            e.Graphics.DrawEllipse(PenList(f), xx, aa + f * 2, l, l)
                        ElseIf a = b And EquationList(2)(0) = "=" Then
                            Dim aa As Single = j
                            Dim xx As Single = i
                            e.Graphics.DrawEllipse(PenList(f), xx, aa + f * 2, l, l)
                        End If
                    Next
                Next
                    For i = 0 To Width * Multiplier Step 1
                    Dim a As Single
                    Dim b As Single
                    Try
                        a = ((((i / Multiplier) - Offset) / PixelPerPoint) * GraphScale) ^ 4 * EquationList(0)(0) + ((((i / Multiplier) - Offset) / PixelPerPoint) * GraphScale) ^ 3 * EquationList(0)(1) + ((((i / Multiplier) - Offset) / PixelPerPoint) * GraphScale) ^ 2 * EquationList(0)(2) + EquationList(0)(3) * ((((i / Multiplier) - Offset) / PixelPerPoint) * GraphScale) + EquationList(0)(4)
                        b = ((((i / Multiplier) - Offset) / PixelPerPoint) * GraphScale) ^ 4 * EquationList(1)(0) + ((((i / Multiplier) - Offset) / PixelPerPoint) * GraphScale) ^ 3 * EquationList(1)(1) + ((((i / Multiplier) - Offset) / PixelPerPoint) * GraphScale) ^ 2 * EquationList(1)(2) + EquationList(1)(3) * ((((i / Multiplier) - Offset) / PixelPerPoint) * GraphScale) + EquationList(1)(4)
                    Catch ex As InvalidCastException
                        Inequalities.Clear()
                        Exit For
                    End Try
                    Dim aa As Single = (Height / 2) - PixelPerPoint * a * (1 / GraphScale)
                    Dim bb As Single = (Height / 2) - PixelPerPoint * b * (1 / GraphScale)
                    Dim xx As Single = (i / Multiplier)
                    If aa > Height Then
                        aa = Width + 100
                    ElseIf aa < 0 Then
                        aa = -50

                    End If
                    If bb > Height Then
                        bb = Height + 100
                    ElseIf bb < 0 Then
                        bb = -50
                    End If

                    e.Graphics.DrawEllipse(PenList(f), xx, aa, 1, 1)
                    e.Graphics.DrawEllipse(PenList(f), xx, bb, 1, 1)
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
        If ShowComplexPoints.Checked Then
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
                If Modulus >= 1 Then
                    e.Graphics.DrawLine(Pens.Black, Width \ 2, Height \ 2, Xb, yb)
                    e.Graphics.DrawArc(Pens.Black, Width \ 2 - Modulus \ 2, Height \ 2 - Modulus \ 2, Modulus, Modulus, 0, A)
                    e.Graphics.DrawString(Points(i).Real & " " & Points(i).Complex & "i" & vbCrLf & Points(i).ModulusArgument, PointFont, Brushes.Black, NumbersToCoordinate(Points(i))(0), NumbersToCoordinate(Points(i))(1))

                End If
            Next
        End If


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

    Private Function InequalityToEquation(ByVal Inequality As String) As List(Of String)()
        Dim Equation1 As New List(Of String)
        Dim Equation2 As New List(Of String)
        Dim InequalitySign As New List(Of String)
        If InStr(Inequality, "=") > 0 Then
            Equation1 = StringToEquation((Inequality.Substring(0, InStr(Inequality, "=") - 2)))
            InequalitySign.Add("=")
        ElseIf InStr(Inequality, ">") > 0 Then
            Equation1 = StringToEquation((Inequality.Substring(0, InStr(Inequality, ">") - 1)))
            InequalitySign.Add(">")
        ElseIf InStr(Inequality, "<") > 0 Then
            Equation1 = StringToEquation((Inequality.Substring(0, InStr(Inequality, "<") - 1)))
            InequalitySign.Add("<")
        End If
        If InStr(Inequality, "=") > 0 Then
            Equation2 = StringToEquation((Inequality.Substring(InStr(Inequality, "="), Inequality.Length - InStr(Inequality, "="))))
        ElseIf InStr(Inequality, ">") > 0 Then
            Equation2 = StringToEquation((Inequality.Substring(InStr(Inequality, ">"), Inequality.Length - InStr(Inequality, ">"))))
        ElseIf InStr(Inequality, "<") > 0 Then
            Equation2 = StringToEquation((Inequality.Substring(InStr(Inequality, "<"), Inequality.Length - InStr(Inequality, "<"))))
        End If
        Return {Equation1, Equation2, InequalitySign}
    End Function

    Private Sub Mouse_Click(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseClick


        Select Case e.Button
            Case MouseButtons.Left

                If ShowComplexPoints.Checked Then
                    Points.Add(New ComplexNumber(CoordinatesToNumber(e.X, e.Y)(0), CoordinatesToNumber(e.X, e.Y)(1)))
                    Invalidate()
                End If


            Case MouseButtons.Right
                Dim prompt As DialogResult = MessageBox.Show("Are you sure you want to clear the graph?", "Are you sure?", MessageBoxButtons.YesNo)

                If prompt = DialogResult.Yes Then
                    InitializeComponent()
                    Points.Clear()
                    Inequalities.Clear()
                    ShowComplexPoints.Checked = False
                    ShowLoci.Checked = False
                    ShowLabels.Checked = True
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
        'Invalidate()
        Randomize()
        DoubleBuffered = True
        'For i = 0 To 10
        'Points.Add(New ComplexNumber(Int(-10 + Rnd() * 25), Int(-10 + Rnd() * 25)))
        'Next
    End Sub

    Private Sub Form4_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Controls.Add(ShowLabels)
        Controls.Add(ShowLoci)
        Controls.Add(ShowComplexPoints)

    End Sub
    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles ShowComplexPoints.CheckedChanged, ShowLoci.CheckedChanged, ShowLabels.CheckedChanged
        Invalidate()
    End Sub

    Public Sub GraphInequality(Line1 As String, Line2 As String, Inequality As String)

    End Sub

    Private Sub Form4_Close(sender As Object, e As EventArgs) Handles Me.Closed
        Form1.Show()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles LociButton.Click


        StringToEquation("3x^3+7x^2-23x-12")
        Form5.Show()
    End Sub
End Class