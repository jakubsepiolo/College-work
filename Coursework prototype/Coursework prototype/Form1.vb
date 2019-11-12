
Imports System.Text.RegularExpressions
Public Class Form1
    'todo: make input of "3+i" detect complex part as 1 (no need for 3+1i to be input)
    '      stuff to do with matricies
    Public Function StringToComplexNumber(ByVal Text As String) As ComplexNumber 'function that searches through input string and breaks number into real and complex parts
        Dim IsNegativeComplex As Boolean = False
        Dim IsNegativeReal As Boolean = False
        Dim ComplexOne As String
        Dim RealOne As String
        Dim reg As New Regex("^([-+]?(\d+\.?\d*|\d*\.?\d+)([Ee][-+]?[0-2]?\d{1,2})?[r]?|[-+]?((\d+\.?\d*|\d*\.?\d+)([Ee][-+]?[0-2]?\d{1,2})?)?[i]|[-+]?(\d+\.?\d*|\d*\.?\d+)([Ee][-+]?[0-2]?\d{1,2})?[r]?[-+]((\d+\.?\d*|\d*\.?\d+)([Ee][-+]?[0-2]?\d{1,2})?)?[i])$")
        For i = 0 To Len(Text) - 2

            If InStr(Text, "+") = 0 Then
                If InStr(Text, "-") <> 1 Then ' if negative symbol in string then follow this
                    If i > InStr(Text, "-") - 1 Then
                        ComplexOne = ComplexOne & Text(i)
                    ElseIf i < InStr(Text, "-") - 1 Then
                        RealOne = RealOne & Text(i)
                    End If
                    IsNegativeComplex = True
                ElseIf InStrRev(Text, "-") <> 1 Then
                    If i > InStrRev(Text, "-") - 1 Then
                        ComplexOne = ComplexOne & Text(i)
                    ElseIf i < InStrRev(Text, "-") - 1 Then
                        RealOne = RealOne & Text(i)
                    End If
                    IsNegativeComplex = True
                Else
                    If i > InStr(Text, "+") - 1 Then
                        ComplexOne = ComplexOne & Text(i)
                    ElseIf i < InStr(Text, "+") - 1 Then
                        RealOne = RealOne & Text(i)
                    End If
                    IsNegativeComplex = False
                End If
            Else
                If InStr(Text, "+") <> 1 Then
                    If i > InStr(Text, "+") - 1 Then
                        ComplexOne = ComplexOne & Text(i)
                    ElseIf i < InStr(Text, "+") - 1 Then
                        RealOne = RealOne & Text(i)
                    End If
                    IsNegativeReal = False
                ElseIf InStrRev(Text, "+") <> 1 Then
                    If i > InStrRev(Text, "+") - 1 Then
                        ComplexOne = ComplexOne & Text(i)
                    ElseIf i < InStrRev(Text, "+") - 1 Then
                        RealOne = RealOne & Text(i)
                    End If
                    IsNegativeReal = False
                Else
                    If i > InStr(Text, "-") - 1 Then
                        ComplexOne = ComplexOne & Text(i)
                    ElseIf i < InStr(Text, "-") - 1 Then
                        RealOne = RealOne & Text(i)
                    End If
                    IsNegativeReal = True
                End If
            End If


        Next
        Try
            Dim FinalNumber As New ComplexNumber(Convert.ToSingle(RealOne), Convert.ToSingle(ComplexOne))
            If IsNegativeComplex Then 'at the end we invert the real or complex parts if they should've been negative
                FinalNumber.Complex = -FinalNumber.Complex
            End If
            If IsNegativeReal Then
                FinalNumber.Real = -FinalNumber.Real
            End If
            Return FinalNumber
        Catch ex As FormatException
            MsgBox("Numbers not input in correct format!")
            Return New ComplexNumber(0, 0)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
            Return New ComplexNumber(0, 0)
        End Try
    End Function

    Private Sub Add_Button(sender As Object, e As EventArgs) Handles AddButton.Click
        Dim FirstInput As String = InputComplex1.Text
        Dim SecondInput As String = InputComplex2.Text
        Dim NumberOne As ComplexNumber = StringToComplexNumber(FirstInput)
        Dim NumberTwo As ComplexNumber = StringToComplexNumber(SecondInput)
        Dim Total As ComplexNumber
        Total = NumberOne + NumberTwo
        If Total.Complex > 0 Then
            OutputComplex.Text = Total.Real & "+" & Total.Complex & "i"
        ElseIf Total.Complex = 0 Then
            OutputComplex.Text = Total.Real
        Else

            OutputComplex.Text = Total.Real & Total.Complex & "i"
        End If

    End Sub


    Private Sub Subtract_Button(sender As Object, e As EventArgs) Handles SubtractButton.Click
        Dim FirstInput As String = InputComplex1.Text
        Dim SecondInput As String = InputComplex2.Text
        Dim NumberOne As ComplexNumber = StringToComplexNumber(FirstInput)
        Dim NumberTwo As ComplexNumber = StringToComplexNumber(SecondInput)
        Dim Total As ComplexNumber
        Total = NumberOne - NumberTwo
        If Total.Complex > 0 Then
            OutputComplex.Text = Total.Real & "+" & Total.Complex & "i"
        ElseIf Total.Complex = 0 Then
            OutputComplex.Text = Total.Real
        Else

            OutputComplex.Text = Total.Real & Total.Complex & "i"
        End If

    End Sub

    Private Sub Multiply_Button(sender As Object, e As EventArgs) Handles ProductButton.Click
        Dim FirstInput As String = InputComplex1.Text
        Dim SecondInput As String = InputComplex2.Text
        Dim NumberOne As ComplexNumber = StringToComplexNumber(FirstInput)
        Dim NumberTwo As ComplexNumber = StringToComplexNumber(SecondInput)
        Dim Total As ComplexNumber
        Total = NumberOne * NumberTwo
        If Total.Complex > 0 Then
            OutputComplex.Text = Total.Real & "+" & Total.Complex & "i"
        ElseIf Total.Complex = 0 Then
            OutputComplex.Text = Total.Real
        Else

            OutputComplex.Text = Total.Real & Total.Complex & "i"
        End If

    End Sub

    Private Sub Divide_Button(sender As Object, e As EventArgs) Handles DivideButton.Click
        Dim FirstInput As String = InputComplex1.Text
        Dim SecondInput As String = InputComplex2.Text
        Dim NumberOne As ComplexNumber = StringToComplexNumber(FirstInput)
        Dim NumberTwo As ComplexNumber = StringToComplexNumber(SecondInput)
        Dim Total As ComplexNumber
        Total = NumberOne / NumberTwo
        If Total.Complex > 0 Then
            OutputComplex.Text = Math.Round(Total.Real, 4) & "+" & Math.Round(Total.Complex, 4) & "i"
        ElseIf Total.Complex = 0 Then
            OutputComplex.Text = Math.Round(Total.Real, 4)
        Else

            OutputComplex.Text = Math.Round(Total.Real, 4) & Math.Round(Total.Complex, 4) & "i"
        End If

    End Sub

    Private Sub MatrixButton(sender As Object, e As EventArgs) Handles OpenMatrix.Click
        Form2.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


End Class
