Imports System.Text.RegularExpressions
Imports System.IO

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
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


End Class

Public Class Form2

    Public MatrixSlot1(,) As Single
    Public MatrixSlot2(,) As Single
    Public MatrixSlot3(,) As Single
    Public MatrixSlot4(,) As Single
    Public MatrixSlot5(,) As Single

    Public Function MatrixFromComboBox(ComboBox As Object) As Single(,)
        If ComboBox.Text = "Matrix slot 1 " Then
            Return MatrixSlot1
        ElseIf ComboBox.Text = "Matrix slot 2 " Then
            Return MatrixSlot2
        ElseIf ComboBox.Text = "Matrix slot 3 " Then
            Return MatrixSlot3
        ElseIf ComboBox.Text = "Matrix slot 4 " Then
            Return MatrixSlot4
        ElseIf ComboBox.Text = "Matrix slot 5 " Then
            Return MatrixSlot5
        Else
            Return {{0}}
        End If
    End Function

    Private Function SquareMultiplyMatrices(Matrix1(,) As Single, Matrix2(,) As Single) As Single(,)
        Dim Temp As Single = 0
        Dim ReturnMatrix(Matrix1.GetLength(0) - 1, Matrix2.GetLength(1) - 1) As Single
        For i = 0 To Matrix1.GetLength(1) - 1
            For j = 0 To Matrix2.GetLength(0) - 1
                For k = 0 To Matrix2.GetLength(1) - 1
                    Temp = Temp + Matrix1(i, k) * Matrix2(k, j)
                Next
                ReturnMatrix(i, j) = Temp
                Temp = 0
            Next
        Next
        Return ReturnMatrix
    End Function

    Private Function AddMatrices(Matrix1(,) As Single, Matrix2(,) As Single) As Single(,)
        Dim TempMatrix(Matrix1.GetLength(1) - 1, Matrix1.GetLength(0) - 1) As Single
        For x = 0 To Matrix1.GetLength(0) - 1
            For y = 0 To Matrix1.GetLength(1) - 1
                TempMatrix(x, y) = Matrix1(x, y) + Matrix2(x, y)
            Next
        Next
        Return TempMatrix
    End Function
    Private Function SubtractMatrices(Matrix1(,) As Single, Matrix2(,) As Single) As Single(,)
        Dim TempMatrix(Matrix1.GetLength(0) - 1, Matrix1.GetLength(1) - 1) As Single
        For x = 0 To Matrix1.GetLength(0) - 1
            For y = 0 To Matrix1.GetLength(1) - 1
                TempMatrix(x, y) = Matrix1(x, y) - Matrix2(x, y)
            Next
        Next
        Return TempMatrix
    End Function
    Public Function GridToMatrix() As Single(,)
        Dim TheMatrix(MatrixGrid.DisplayedRowCount(True) - 1, MatrixGrid.DisplayedColumnCount(True) - 1) As Single
        Try
            For i = 0 To MatrixGrid.DisplayedRowCount(True) - 1
                For j = 0 To MatrixGrid.DisplayedColumnCount(True) - 1
                    TheMatrix(i, j) = MatrixGrid.Rows(i).Cells(j).Value
                Next
            Next
        Catch ex As InvalidCastException
            MsgBox("Invalid entry in one of the matrix fields (Ensure all inputs are numbers)")
        Catch ex As OverflowException
            MsgBox("Invalid entry in one of the matrix fields (One or more numbers too large)")
        End Try

        Return TheMatrix
    End Function
    Private Sub Loaded() Handles Me.Load
        MatrixGrid.AllowUserToAddRows = False
    End Sub

    Private Sub selection(sender As Object, e As EventArgs) Handles MatrixGrid.SelectionChanged
        MatrixGrid.ClearSelection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddRow.Click
        Try
            If MatrixGrid.DisplayedRowCount(True) < 4 Then
                MatrixGrid.Rows.Add()
            End If

        Catch ex As InvalidOperationException
            MsgBox("You must add a column before adding rows")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles AddColumn.Click
        If MatrixGrid.DisplayedColumnCount(True) < 4 Then
            MatrixGrid.Columns.Add(Str(MatrixGrid.DisplayedColumnCount(True)), " ")
            MatrixGrid.Columns(MatrixGrid.DisplayedColumnCount(True) - 1).SortMode = DataGridViewColumnSortMode.NotSortable
        End If

    End Sub


    Public Function Invert2xMatrix(Matrix(,) As Single) As Single(,)
        Dim InverseMatrix(1, 1) As Single
        InverseMatrix(0, 0) = Matrix(1, 1)
        InverseMatrix(0, 1) = -Matrix(0, 1)
        InverseMatrix(1, 0) = -Matrix(1, 0)
        InverseMatrix(1, 1) = Matrix(0, 0)
        Dim Multiplier As Single
        Multiplier = 1 / (Matrix(0, 0) * Matrix(1, 1) - Matrix(1, 0) * Matrix(0, 1))
        For x = 0 To 1
            For y = 0 To 1
                InverseMatrix(x, y) = InverseMatrix(x, y) * Multiplier
            Next
        Next
        Return InverseMatrix
    End Function

    Public Function CreateTempMatrix(Matrix(,) As Single, ByVal x1 As Integer, ByVal x2 As Integer) As Single(,)
        Dim ReturnMatrix(x2, x2) As Single
        If x1 = 0 Then
            ReturnMatrix(0, 0) = Matrix(1, 1)
            ReturnMatrix(0, 1) = Matrix(1, 2)
            ReturnMatrix(1, 0) = Matrix(2, 1)
            ReturnMatrix(1, 1) = Matrix(2, 2)

        ElseIf x1 = 1 Then
            ReturnMatrix(0, 0) = Matrix(0, 1)
            ReturnMatrix(0, 1) = Matrix(0, 2)
            ReturnMatrix(1, 0) = Matrix(2, 1)
            ReturnMatrix(1, 1) = Matrix(2, 2)
        ElseIf x1 = 2 Then
            ReturnMatrix(0, 0) = Matrix(0, 1)
            ReturnMatrix(0, 1) = Matrix(0, 2)
            ReturnMatrix(1, 0) = Matrix(1, 1)
            ReturnMatrix(1, 1) = Matrix(1, 2)
        End If
        Return ReturnMatrix
    End Function
    Public Function aaaaaaa(Matrix(,) As Single) As Single
        Dim Determinant As Single
        For x = 0 To 2
            Dim TempMatrix(,) As Single = CreateTempMatrix(Matrix, x, 1)
            If x = 0 Then
                Determinant += Matrix(0, 0) * (TempMatrix(0, 0) * TempMatrix(1, 1) - TempMatrix(1, 0) * TempMatrix(0, 1))
            ElseIf x = 1 Then
                Determinant += -Matrix(1, 0) * (TempMatrix(0, 0) * TempMatrix(1, 1) - TempMatrix(1, 0) * TempMatrix(0, 1))
            ElseIf x = 2 Then
                Determinant += Matrix(2, 0) * (TempMatrix(0, 0) * TempMatrix(1, 1) - TempMatrix(1, 0) * TempMatrix(0, 1))
            End If
        Next
        Return Determinant
    End Function
    Public Function Invert3xMatrix(Matrix(,) As Single) As Single(,)
        Dim Determinant As Single
        Dim InverseMatrix(2, 2) As Single
        For x = 0 To 2
            Dim TempMatrix(,) As Single = CreateTempMatrix(Matrix, x, 1)
            If x = 0 Then
                Determinant += Matrix(0, 0) * (TempMatrix(0, 0) * TempMatrix(1, 1) - TempMatrix(1, 0) * TempMatrix(0, 1))
            ElseIf x = 1 Then
                Determinant += -Matrix(1, 0) * (TempMatrix(0, 0) * TempMatrix(1, 1) - TempMatrix(1, 0) * TempMatrix(0, 1))
            ElseIf x = 2 Then
                Determinant += Matrix(2, 0) * (TempMatrix(0, 0) * TempMatrix(1, 1) - TempMatrix(1, 0) * TempMatrix(0, 1))
            End If
        Next

        InverseMatrix(0, 0) = Matrix(1, 1) * Matrix(2, 2) - Matrix(2, 1) * Matrix(1, 2)

        InverseMatrix(0, 1) = -(Matrix(0, 1) * Matrix(2, 2) - Matrix(0, 2) * Matrix(2, 1))

        InverseMatrix(0, 2) = Matrix(0, 1) * Matrix(1, 2) - Matrix(0, 2) * Matrix(1, 1)

        InverseMatrix(1, 0) = -(Matrix(1, 0) * Matrix(2, 2) - Matrix(1, 2) * Matrix(2, 0))

        InverseMatrix(1, 1) = Matrix(0, 0) * Matrix(2, 2) - Matrix(2, 0) * Matrix(0, 2)

        InverseMatrix(1, 2) = -(Matrix(0, 0) * Matrix(1, 2) - Matrix(0, 2) * Matrix(1, 0))

        InverseMatrix(2, 0) = Matrix(1, 0) * Matrix(2, 1) - Matrix(1, 1) * Matrix(2, 0)

        InverseMatrix(2, 1) = -(Matrix(0, 0) * Matrix(2, 1) - Matrix(0, 1) * Matrix(2, 0))

        InverseMatrix(2, 2) = Matrix(0, 0) * Matrix(1, 1) - Matrix(1, 0) * Matrix(0, 1)

        For x = 0 To 2
            For y = 0 To 2
                InverseMatrix(x, y) = (1 / Determinant) * InverseMatrix(x, y)
            Next
        Next

        Return InverseMatrix
    End Function

    Public Function Invert4xMatrix(Matrix(,) As Single) As Single(,)
        Dim Determinant As Single = 0
#Region "Determinant calculation"
        Determinant += Matrix(0, 0) * Matrix(1, 1) * Matrix(2, 2) * Matrix(3, 3)
        Determinant += Matrix(0, 0) * Matrix(1, 2) * Matrix(2, 3) * Matrix(3, 1)
        Determinant += Matrix(0, 0) * Matrix(1, 3) * Matrix(2, 1) * Matrix(3, 2)
        Determinant += -Matrix(0, 0) * Matrix(1, 3) * Matrix(2, 2) * Matrix(3, 1)
        Determinant += -Matrix(0, 0) * Matrix(1, 2) * Matrix(2, 1) * Matrix(3, 3)
        Determinant += -Matrix(0, 0) * Matrix(1, 1) * Matrix(2, 3) * Matrix(3, 2)
        Determinant += -Matrix(0, 1) * Matrix(1, 0) * Matrix(2, 2) * Matrix(3, 3)
        Determinant += -Matrix(0, 2) * Matrix(1, 0) * Matrix(2, 3) * Matrix(3, 1)
        Determinant += -Matrix(0, 3) * Matrix(1, 0) * Matrix(2, 1) * Matrix(3, 2)
        Determinant += Matrix(0, 3) * Matrix(1, 0) * Matrix(2, 2) * Matrix(3, 1)
        Determinant += Matrix(0, 2) * Matrix(1, 0) * Matrix(2, 1) * Matrix(3, 3)
        Determinant += Matrix(0, 1) * Matrix(1, 0) * Matrix(2, 3) * Matrix(3, 2)
        Determinant += Matrix(0, 1) * Matrix(1, 2) * Matrix(2, 0) * Matrix(3, 3)
        Determinant += Matrix(0, 2) * Matrix(1, 3) * Matrix(2, 0) * Matrix(3, 1)
        Determinant += Matrix(0, 3) * Matrix(1, 1) * Matrix(2, 0) * Matrix(3, 2)
        Determinant += -Matrix(0, 3) * Matrix(1, 2) * Matrix(2, 0) * Matrix(3, 1)
        Determinant += -Matrix(0, 2) * Matrix(1, 1) * Matrix(2, 0) * Matrix(3, 3)
        Determinant += -Matrix(0, 1) * Matrix(1, 3) * Matrix(2, 0) * Matrix(3, 2)
        Determinant += -Matrix(0, 1) * Matrix(1, 2) * Matrix(2, 3) * Matrix(3, 0)
        Determinant += -Matrix(0, 2) * Matrix(1, 3) * Matrix(2, 1) * Matrix(3, 0)
        Determinant += -Matrix(0, 3) * Matrix(1, 1) * Matrix(2, 2) * Matrix(3, 0)
        Determinant += Matrix(0, 3) * Matrix(1, 2) * Matrix(2, 1) * Matrix(3, 0)
        Determinant += Matrix(0, 2) * Matrix(1, 1) * Matrix(2, 3) * Matrix(3, 0)
        Determinant += Matrix(0, 1) * Matrix(1, 3) * Matrix(2, 2) * Matrix(3, 0)
#End Region
        Dim TempMatrix(2, 2) As Single
        Dim SuperMatrix(3, 3) As Single
        TempMatrix = {{Matrix(1, 1), Matrix(2, 1), Matrix(3, 1)}, {Matrix(1, 2), Matrix(2, 2), Matrix(3, 2)}, {Matrix(1, 3), Matrix(2, 3), Matrix(3, 3)}}
        SuperMatrix(0, 0) = aaaaaaa(TempMatrix) * (1 / Determinant)
        TempMatrix = {{Matrix(0, 1), Matrix(2, 1), Matrix(3, 1)}, {Matrix(0, 2), Matrix(2, 2), Matrix(3, 2)}, {Matrix(0, 3), Matrix(2, 3), Matrix(3, 3)}}
        SuperMatrix(0, 1) = aaaaaaa(TempMatrix) * (-1 / Determinant)
        TempMatrix = {{Matrix(0, 1), Matrix(1, 1), Matrix(3, 1)}, {Matrix(0, 2), Matrix(1, 2), Matrix(3, 2)}, {Matrix(0, 3), Matrix(1, 3), Matrix(3, 3)}}
        SuperMatrix(0, 2) = aaaaaaa(TempMatrix) * (1 / Determinant)
        TempMatrix = {{Matrix(0, 1), Matrix(1, 1), Matrix(2, 1)}, {Matrix(0, 2), Matrix(1, 2), Matrix(2, 2)}, {Matrix(0, 3), Matrix(1, 3), Matrix(2, 3)}}
        SuperMatrix(0, 3) = aaaaaaa(TempMatrix) * (-1 / Determinant)
        TempMatrix = {{Matrix(1, 0), Matrix(2, 0), Matrix(3, 0)}, {Matrix(1, 2), Matrix(2, 2), Matrix(3, 2)}, {Matrix(1, 3), Matrix(2, 3), Matrix(3, 3)}}
        SuperMatrix(1, 0) = aaaaaaa(TempMatrix) * (-1 / Determinant)
        TempMatrix = {{Matrix(0, 0), Matrix(2, 0), Matrix(3, 0)}, {Matrix(0, 2), Matrix(2, 2), Matrix(3, 2)}, {Matrix(0, 3), Matrix(2, 3), Matrix(3, 3)}}
        SuperMatrix(1, 1) = aaaaaaa(TempMatrix) * (1 / Determinant)
        TempMatrix = {{Matrix(0, 0), Matrix(1, 0), Matrix(3, 0)}, {Matrix(0, 2), Matrix(1, 2), Matrix(3, 2)}, {Matrix(0, 3), Matrix(1, 3), Matrix(3, 3)}}
        SuperMatrix(1, 2) = aaaaaaa(TempMatrix) * (-1 / Determinant)
        TempMatrix = {{Matrix(0, 0), Matrix(1, 0), Matrix(2, 0)}, {Matrix(0, 2), Matrix(1, 2), Matrix(2, 2)}, {Matrix(0, 3), Matrix(1, 3), Matrix(2, 3)}}
        SuperMatrix(1, 3) = aaaaaaa(TempMatrix) * (1 / Determinant)
        TempMatrix = {{Matrix(1, 0), Matrix(2, 0), Matrix(3, 0)}, {Matrix(1, 1), Matrix(2, 1), Matrix(3, 1)}, {Matrix(1, 3), Matrix(2, 3), Matrix(3, 3)}}
        SuperMatrix(2, 0) = aaaaaaa(TempMatrix) * (1 / Determinant)
        TempMatrix = {{Matrix(0, 0), Matrix(2, 0), Matrix(3, 0)}, {Matrix(0, 1), Matrix(2, 1), Matrix(3, 1)}, {Matrix(0, 3), Matrix(2, 3), Matrix(3, 3)}}
        SuperMatrix(2, 1) = aaaaaaa(TempMatrix) * (-1 / Determinant)
        TempMatrix = {{Matrix(0, 0), Matrix(1, 0), Matrix(3, 0)}, {Matrix(0, 1), Matrix(1, 1), Matrix(3, 1)}, {Matrix(0, 3), Matrix(1, 3), Matrix(3, 3)}}
        SuperMatrix(2, 2) = aaaaaaa(TempMatrix) * (1 / Determinant)
        TempMatrix = {{Matrix(0, 0), Matrix(1, 0), Matrix(2, 0)}, {Matrix(0, 1), Matrix(1, 1), Matrix(2, 1)}, {Matrix(0, 3), Matrix(1, 3), Matrix(2, 3)}}
        SuperMatrix(2, 3) = aaaaaaa(TempMatrix) * (-1 / Determinant)
        TempMatrix = {{Matrix(1, 0), Matrix(2, 0), Matrix(3, 0)}, {Matrix(1, 1), Matrix(2, 1), Matrix(3, 1)}, {Matrix(1, 2), Matrix(2, 2), Matrix(3, 2)}}
        SuperMatrix(3, 0) = aaaaaaa(TempMatrix) * (-1 / Determinant)
        TempMatrix = {{Matrix(0, 0), Matrix(2, 0), Matrix(3, 0)}, {Matrix(0, 1), Matrix(2, 1), Matrix(3, 1)}, {Matrix(0, 2), Matrix(2, 2), Matrix(3, 2)}}
        SuperMatrix(3, 1) = aaaaaaa(TempMatrix) * (1 / Determinant)
        TempMatrix = {{Matrix(0, 0), Matrix(1, 0), Matrix(3, 0)}, {Matrix(0, 1), Matrix(1, 1), Matrix(3, 1)}, {Matrix(0, 2), Matrix(1, 2), Matrix(3, 2)}}
        SuperMatrix(3, 2) = aaaaaaa(TempMatrix) * (-1 / Determinant)
        TempMatrix = {{Matrix(0, 0), Matrix(1, 0), Matrix(2, 0)}, {Matrix(0, 1), Matrix(1, 1), Matrix(2, 1)}, {Matrix(0, 2), Matrix(1, 2), Matrix(2, 2)}}
        SuperMatrix(3, 3) = aaaaaaa(TempMatrix) * (1 / Determinant)

        Return SuperMatrix



    End Function

    Private Sub CopyText(sender As Object, e As EventArgs) Handles Label1.Click
        Clipboard.SetText(Label1.Text)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles InvertMatrix.Click
        Label1.Visible = False
        Dim TheMatrix(,) As Single = GridToMatrix()
        If MatrixGrid.DisplayedColumnCount(True) = MatrixGrid.DisplayedRowCount(True) Then
            If MatrixGrid.DisplayedColumnCount(True) = 2 Then
                Label1.Text = Nothing
                Dim InverseMatrix(,) As Single = Invert2xMatrix(TheMatrix)
                Label1.Text &= "┌                ┐"
                Label1.Text &= vbCrLf
                For x = 0 To 1
                    Label1.Text &= "│"
                    For y = 0 To 1
                        Label1.Text = Label1.Text & " " & LSet(Math.Round(InverseMatrix(x, y), 4), 7)
                    Next
                    Label1.Text = Label1.Text & "│" & vbCrLf
                Next
                Label1.Text &= "└                ┘"
            ElseIf MatrixGrid.DisplayedColumnCount(True) = 3 Then
                Label1.Text = Nothing
                Dim InverseMatrix(,) As Single = Invert3xMatrix(TheMatrix)
                Label1.Text &= "┌                         ┐"
                Label1.Text &= vbCrLf
                For x = 0 To 2
                    Label1.Text &= "│ "
                    For y = 0 To 2
                        Label1.Text = Label1.Text & " " & LSet(Math.Round(InverseMatrix(x, y), 4), 7)
                    Next
                    Label1.Text = Label1.Text & "│" & vbCrLf
                Next
                Label1.Text &= "└                         ┘"
            ElseIf MatrixGrid.DisplayedColumnCount(True) = 4 Then
                Label1.Text = Nothing
                Dim InverseMatrix(,) As Single = Invert4xMatrix(TheMatrix)
                Label1.Text &= "┌                                 ┐"
                Label1.Text &= vbCrLf
                For x = 0 To 3
                    Label1.Text &= "│ "
                    For y = 0 To 3
                        Label1.Text = Label1.Text & " " & LSet(Math.Round(InverseMatrix(x, y), 4), 7)
                    Next
                    Label1.Text = Label1.Text & "│" & vbCrLf
                Next
                Label1.Text &= "└                                 ┘"
            End If
        End If
        Label1.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles RemoveRow.Click
        If MatrixGrid.DisplayedRowCount(True) > 1 Then
            MatrixGrid.Rows.RemoveAt(MatrixGrid.DisplayedRowCount(True) - 1)
        Else
            MsgBox("You cannot have 0 rows!")
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles RemoveColumn.Click
        If MatrixGrid.DisplayedColumnCount(True) > 1 Then
            MatrixGrid.Columns.RemoveAt(MatrixGrid.DisplayedColumnCount(True) - 1)
        Else
            MsgBox("You cannot have 0 columns!")
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles SaveMatrix.Click
        Form3.OpenThisForm(SaveMatrix, e)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles LoadMatrix.Click
        Form3.OpenThisForm(LoadMatrix, e)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectMatrix1.SelectedIndexChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles AddMatrix.Click
        Dim FirstMatrix(,) As Single = MatrixFromComboBox(SelectMatrix1)
        Dim SecondMatrix(,) As Single = MatrixFromComboBox(SelectMatrix2)
        Dim SavedLocation As String
        Try
            If FirstMatrix.GetLength(0) = SecondMatrix.GetLength(0) And FirstMatrix.GetLength(1) = SecondMatrix.GetLength(1) Then
                If MatrixSlot1 Is Nothing Then
                    MatrixSlot1 = AddMatrices(FirstMatrix, SecondMatrix) 'tempstoring
                    SavedLocation = "Matrix slot 1"
                ElseIf MatrixSlot2 Is Nothing Then
                    MatrixSlot2 = AddMatrices(FirstMatrix, SecondMatrix)
                    SavedLocation = "Matrix slot 2"
                ElseIf MatrixSlot3 Is Nothing Then
                    MatrixSlot3 = AddMatrices(FirstMatrix, SecondMatrix)
                    SavedLocation = "Matrix slot 3"
                ElseIf MatrixSlot4 Is Nothing Then
                    MatrixSlot4 = AddMatrices(FirstMatrix, SecondMatrix)
                    SavedLocation = "Matrix slot 4"
                ElseIf MatrixSlot5 Is Nothing Then
                    MatrixSlot5 = AddMatrices(FirstMatrix, SecondMatrix)
                    SavedLocation = "Matrix slot 5"
                End If
                MsgBox($"Saved result in {SavedLocation}")
            End If
        Catch ex As NullReferenceException
            MsgBox("One of the matrix slots has no matrix stored...")
        End Try
    End Sub

    Private Sub FormCloses(sender As Object, e As EventArgs) Handles Me.Closed
        Form1.Show()
    End Sub
    Public Sub test() Handles SelectMatrix1.MouseHover
        Dim ToolTip As New ToolTip
        If SelectMatrix1.SelectedItem IsNot Nothing Then
            ToolTip.SetToolTip(SelectMatrix1, SelectMatrix1.SelectedItem.ToString())
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles SubtractMatrix.Click
        Dim FirstMatrix(,) As Single = MatrixFromComboBox(SelectMatrix1)
        Dim SecondMatrix(,) As Single = MatrixFromComboBox(SelectMatrix2)
        Dim SavedLocation As String
        Try

            If FirstMatrix.GetLength(0) = SecondMatrix.GetLength(0) And FirstMatrix.GetLength(1) = SecondMatrix.GetLength(1) Then

                If MatrixSlot1 Is Nothing Then
                    MatrixSlot1 = SubtractMatrices(FirstMatrix, SecondMatrix)
                    SavedLocation = "Matrix slot 1"
                ElseIf MatrixSlot2 Is Nothing Then
                    MatrixSlot2 = SubtractMatrices(FirstMatrix, SecondMatrix)
                    SavedLocation = "Matrix slot 2"
                ElseIf MatrixSlot3 Is Nothing Then
                    MatrixSlot3 = SubtractMatrices(FirstMatrix, SecondMatrix) 'tempstoring
                    SavedLocation = "Matrix slot 3"
                ElseIf MatrixSlot4 Is Nothing Then
                    MatrixSlot4 = SubtractMatrices(FirstMatrix, SecondMatrix)
                    SavedLocation = "Matrix slot 4"
                ElseIf MatrixSlot5 Is Nothing Then
                    MatrixSlot5 = SubtractMatrices(FirstMatrix, SecondMatrix)
                    SavedLocation = "Matrix slot 5"
                End If
                MsgBox($"Saved result in {SavedLocation}")
            End If
        Catch ex As NullReferenceException
            MsgBox("One of the matrix slots has no matrix stored...")
        End Try
    End Sub

    Private Sub MultiplyMatrix_Click(sender As Object, e As EventArgs) Handles MultiplyMatrix.Click
        Dim FirstMatrix(,) As Single = MatrixFromComboBox(SelectMatrix1)
        Dim SecondMatrix(,) As Single = MatrixFromComboBox(SelectMatrix2)
        Dim SavedLocation As String
        Try
            'If FirstMatrix.GetLength(0) = SecondMatrix.GetLength(0) And FirstMatrix.GetLength(1) = SecondMatrix.GetLength(1) Then
            If MatrixSlot1 Is Nothing Then
                MatrixSlot1 = SquareMultiplyMatrices(FirstMatrix, SecondMatrix)
                SavedLocation = "Matrix slot 1"
            ElseIf MatrixSlot2 Is Nothing Then
                MatrixSlot2 = SquareMultiplyMatrices(FirstMatrix, SecondMatrix)
                SavedLocation = "Matrix slot 2"
            ElseIf MatrixSlot3 Is Nothing Then
                MatrixSlot3 = SquareMultiplyMatrices(FirstMatrix, SecondMatrix) 'tempstoring
                SavedLocation = "Matrix slot 3"
            ElseIf MatrixSlot4 Is Nothing Then
                MatrixSlot4 = SquareMultiplyMatrices(FirstMatrix, SecondMatrix)
                SavedLocation = "Matrix slot 4"
            ElseIf MatrixSlot5 Is Nothing Then
                MatrixSlot5 = SquareMultiplyMatrices(FirstMatrix, SecondMatrix)
                SavedLocation = "Matrix slot 5"
            End If
            MsgBox($"Saved result in {SavedLocation}")
            'End If
        Catch ex As NullReferenceException
            MsgBox("One of the matrix slots has no matrix stored...")
        End Try
    End Sub
End Class
Public Class Form3

    Dim WhatWeAreDoing As String
    Dim WorkingMatrix(,) As Single
    Dim WhoSentUs As Object
    Dim FilePath As String = "H:\matrix.bin"
    Private Sub Loaded() Handles Me.Load
        MatrixOutput.Text = Nothing
    End Sub

    Public Sub OpenThisForm(sender As Object, e As EventArgs)
        Show()
        WhoSentUs = sender
    End Sub

    Private Sub UpdateLabel(ByVal Matrix(,) As Single)
        MatrixOutput.Text = Nothing
        Try
            For x = 0 To Matrix.GetLength(0) - 1
                For y = 0 To Matrix.GetLength(1) - 1
                    MatrixOutput.Text = $"{MatrixOutput.Text} {LSet(Matrix(x, y), 7)}"
                Next
                MatrixOutput.Text &= vbCrLf
            Next
        Catch ex As NullReferenceException
            MatrixOutput.Text = "No matrix stored in this position"
        End Try

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectMatrix.SelectedIndexChanged
        If WhoSentUs Is Form2.LoadMatrix Then
            WhatWeAreDoing = "Load"
        ElseIf WhoSentUs Is Form2.SaveMatrix Then
            WhatWeAreDoing = "Save"
        End If
        If SelectMatrix.Text = "Matrix slot 1 " Then
            UpdateLabel(Form2.MatrixSlot1)
            WorkingMatrix = Form2.MatrixSlot1
        ElseIf SelectMatrix.Text = "Matrix slot 2 " Then
            UpdateLabel(Form2.MatrixSlot2)
            WorkingMatrix = Form2.MatrixSlot2
        ElseIf SelectMatrix.Text = "Matrix slot 3 " Then
            UpdateLabel(Form2.MatrixSlot3)
            WorkingMatrix = Form2.MatrixSlot3
        ElseIf SelectMatrix.Text = "Matrix slot 4 " Then
            UpdateLabel(Form2.MatrixSlot4)
            WorkingMatrix = Form2.MatrixSlot4
        ElseIf SelectMatrix.Text = "Matrix slot 5 " Then
            UpdateLabel(Form2.MatrixSlot5)
            WorkingMatrix = Form2.MatrixSlot4
        ElseIf SelectMatrix.Text = "To/From File" Then
            If WhatWeAreDoing = "Load" Then
                Dim fd As OpenFileDialog = New OpenFileDialog
                fd.Title = "Open File Directory"
                fd.InitialDirectory = "H:\"
                fd.Filter = "BIN Files (*.bin)|*.bin"
                fd.FilterIndex = 2
                fd.RestoreDirectory = True
                If fd.ShowDialog() = DialogResult.OK Then
                    FilePath = fd.FileName
                End If
            ElseIf WhatWeAreDoing = "Save" Then
                Dim fd As SaveFileDialog = New SaveFileDialog

                fd.Title = "Save File Directory"
                fd.InitialDirectory = "H:\"
                fd.Filter = "BIN Files (*.bin)|*.bin"
                fd.FilterIndex = 0
                fd.RestoreDirectory = True
                If fd.ShowDialog() = DialogResult.OK Then
                    FilePath = fd.FileName
                End If
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click
        'setup try catch for file loading
        If WhatWeAreDoing = "Load" Then 'And WorkingMatrix IsNot Nothing Then
            If SelectMatrix.Text = "To/From File" Then
                Using reader As BinaryReader = New BinaryReader(File.OpenRead(FilePath))
                    Try
                        Dim x As Integer = reader.ReadInt32
                        Dim y As Integer = reader.ReadInt32
                        Dim NewMatrix(x, y) As Single
                        For i = 0 To x
                            For j = 0 To y
                                NewMatrix(i, j) = reader.ReadString

                            Next
                        Next
                        WorkingMatrix = NewMatrix
                        MsgBox($"Matrix loaded from {SelectMatrix.Text} ")
                    Catch ex As OutOfMemoryException
                        MsgBox("Invalid file loaded")
                        reader.Close()
                        WorkingMatrix = {{0}}
                    End Try

                End Using

            End If

            While Form2.MatrixGrid.DisplayedColumnCount(True) <> WorkingMatrix.GetLength(1)
                If Form2.MatrixGrid.DisplayedColumnCount(True) > WorkingMatrix.GetLength(1) Then
                    Form2.MatrixGrid.Columns.RemoveAt(Form2.MatrixGrid.DisplayedColumnCount(True) - 1)
                ElseIf Form2.MatrixGrid.DisplayedColumnCount(True) < WorkingMatrix.GetLength(1) Then
                    Form2.MatrixGrid.Columns.Add(Str(Form2.MatrixGrid.DisplayedColumnCount(True)), " ")
                    Form2.MatrixGrid.Columns(Form2.MatrixGrid.DisplayedColumnCount(True) - 1).SortMode = DataGridViewColumnSortMode.NotSortable
                End If
            End While

            While Form2.MatrixGrid.DisplayedRowCount(True) <> WorkingMatrix.GetLength(0)
                If Form2.MatrixGrid.DisplayedRowCount(True) > WorkingMatrix.GetLength(0) Then
                    Form2.MatrixGrid.Rows.RemoveAt(Form2.MatrixGrid.DisplayedRowCount(True) - 1)
                ElseIf Form2.MatrixGrid.DisplayedRowCount(True) < WorkingMatrix.GetLength(0) Then
                    Form2.MatrixGrid.Rows.Add()
                End If

            End While
            For x = 0 To WorkingMatrix.GetLength(0) - 1
                For y = 0 To WorkingMatrix.GetLength(1) - 1
                    Form2.MatrixGrid.Rows(x).Cells(y).Value = WorkingMatrix(x, y)
                Next
            Next

            Close()

        ElseIf WhatWeAreDoing = "Save" Then
            If Form2.GridToMatrix().GetLength(0) < 1 Then
                MsgBox("Cannot save an empty matrix")
            Else
                If SelectMatrix.Text = "Matrix slot 1 " Then
                    Form2.MatrixSlot1 = Form2.GridToMatrix()
                ElseIf SelectMatrix.Text = "Matrix slot 2 " Then
                    Form2.MatrixSlot2 = Form2.GridToMatrix()
                ElseIf SelectMatrix.Text = "Matrix slot 3 " Then
                    Form2.MatrixSlot3 = Form2.GridToMatrix()
                ElseIf SelectMatrix.Text = "Matrix slot 4 " Then
                    Form2.MatrixSlot4 = Form2.GridToMatrix()
                ElseIf SelectMatrix.Text = "Matrix slot 5 " Then
                    Form2.MatrixSlot5 = Form2.GridToMatrix()
                ElseIf SelectMatrix.Text = "To/From File" Then
                    Using writer As BinaryWriter = New BinaryWriter(File.Open(FilePath, FileMode.OpenOrCreate))
                        writer.Write(Int(Form2.MatrixGrid.DisplayedRowCount(True) - 1))
                        writer.Write(Int(Form2.MatrixGrid.DisplayedColumnCount(True) - 1))
                        For i = 0 To Form2.MatrixGrid.DisplayedRowCount(True) - 1
                            For j = 0 To Form2.MatrixGrid.DisplayedColumnCount(True) - 1
                                writer.Write(Str(Form2.MatrixGrid.Rows(i).Cells(j).Value))
                            Next
                        Next


                    End Using
                End If
                MsgBox($"Matrix saved to {SelectMatrix.Text} ")
                Close()
            End If
        End If
    End Sub



    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles MatrixOutput.Click
        My.Computer.Clipboard.SetText(MatrixOutput.Text)
    End Sub
End Class

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
    Dim PenList() As Pen = {Pens.Black, Pens.Blue, Pens.Green, Pens.Firebrick, Pens.Violet, Pens.Moccasin}


    Private Sub Form4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        ShowLabels.Location = New Point(2, Height - 80)
        ShowLoci.Location = New Point(2, Height - 60)
        ShowComplexPoints.Location = New Point(2, Height - 100)
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
                Dim EquationList As List(Of String)() = InequalityToEquation(Inequalities(f))
                Dim Offset As Integer = Width \ 2
                Dim Multiplier As Integer = 200

                For i = 0 To Width Step 5
                    Dim a As Single
                    Dim b As Single
                    Try
                        a = (((i - Offset) / PixelPerPoint) * GraphScale) ^ 4 * EquationList(0)(0) + (((i - Offset) / PixelPerPoint) * GraphScale) ^ 3 * EquationList(0)(1) + (((i - Offset) / PixelPerPoint) * GraphScale) ^ 2 * EquationList(0)(2) + EquationList(0)(3) * (((i - Offset) / PixelPerPoint) * GraphScale) + EquationList(0)(4)
                        b = (((i - Offset) / PixelPerPoint) * GraphScale) ^ 4 * EquationList(1)(0) + (((i - Offset) / PixelPerPoint) * GraphScale) ^ 3 * EquationList(1)(1) + (((i - Offset) / PixelPerPoint) * GraphScale) ^ 2 * EquationList(1)(2) + EquationList(1)(3) * (((i - Offset) / PixelPerPoint) * GraphScale) + EquationList(1)(4)
                    Catch ex As InvalidCastException
                        MsgBox($"One or more of your equations was invalid {vbCrLf}{vbCrLf}{ex.Message}{vbCrLf}{vbCrLf}Please input your equations again")
                        Exit For
                    End Try
                    For j = 0 To Height Step 5
                        If a > b And EquationList(2)(0) = ">" Then
                            Dim aa As Single = j
                            Dim xx As Single = i
                            e.Graphics.DrawEllipse(PenList(f), xx, aa + f * 3, 1, 1)
                        ElseIf a < b And EquationList(2)(0) = "<" Then
                            Dim aa As Single = j
                            Dim xx As Single = i
                            e.Graphics.DrawEllipse(PenList(f), xx, aa + f * 3, 1, 1)
                        ElseIf a = b And EquationList(2)(0) = "=" Then
                            Dim aa As Single = j
                            Dim xx As Single = i
                            e.Graphics.DrawEllipse(PenList(f), xx, aa + f * 3, 1, 1)
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
                    e.Graphics.DrawEllipse(PenList(f), xx, aa, 1, 2)
                    e.Graphics.DrawEllipse(PenList(f), xx, bb, 1, 2)
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
        For i = 0 To 10
            Points.Add(New ComplexNumber(Int(-10 + Rnd() * 25), Int(-10 + Rnd() * 25)))
        Next
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
        Form5.Show()
    End Sub
End Class

Public Class ComplexNumber
    'Complex number class containing functions and operators
    Public Real As Single
    Public Complex As Single
    Public Sub New(ByVal RealPart As Single, ByVal ComplexPart As Single)
        Real = RealPart
        Complex = ComplexPart
    End Sub

    Public Shared Operator +(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As ComplexNumber
        Return New ComplexNumber(ComplexNumber1.Real + ComplexNumber2.Real, ComplexNumber1.Complex + ComplexNumber2.Complex)
    End Operator
    Public Shared Operator -(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As ComplexNumber
        Return New ComplexNumber(ComplexNumber1.Real - ComplexNumber2.Real, ComplexNumber1.Complex - ComplexNumber2.Complex)
    End Operator
    Public Shared Operator *(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As ComplexNumber
        Return New ComplexNumber(ComplexNumber1.Real * ComplexNumber2.Real - ComplexNumber1.Complex * ComplexNumber2.Complex, ComplexNumber1.Real * ComplexNumber2.Complex + ComplexNumber2.Real * ComplexNumber1.Complex)
    End Operator
    Public Shared Operator /(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As ComplexNumber
        Return New ComplexNumber((ComplexNumber1.Real * ComplexNumber2.Real + ComplexNumber1.Complex * ComplexNumber2.Complex) / (ComplexNumber2.Real * ComplexNumber2.Real + ComplexNumber2.Complex * ComplexNumber2.Complex), (ComplexNumber1.Complex * ComplexNumber2.Real - ComplexNumber1.Real * ComplexNumber2.Complex) / (ComplexNumber2.Real * ComplexNumber2.Real + ComplexNumber2.Complex * ComplexNumber2.Complex))
    End Operator
    Public Shared Operator =(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As Boolean
        Return ComplexNumber1.Real = ComplexNumber2.Real And ComplexNumber1.Complex = ComplexNumber2.Complex
    End Operator

    Public Shared Operator <>(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As Boolean
        Return ComplexNumber1.Real <> ComplexNumber2.Real And ComplexNumber1.Complex <> ComplexNumber2.Complex
    End Operator
    Public Shared Operator >(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As Boolean
        Return ComplexNumber1.Modulus > ComplexNumber2.Modulus
    End Operator
    Public Shared Operator <(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As Boolean
        Return ComplexNumber1.Modulus < ComplexNumber2.Modulus
    End Operator
    Public Function Modulus() As Single
        Return Math.Sqrt(Me.Real ^ 2 + Me.Complex ^ 2)
    End Function
    Public Function Argument() As Single
        Return Math.Atan2(Me.Complex, Me.Real)
    End Function
    Public Function RealPart() As Single
        Return Real
    End Function
    Public Function ComplexPart() As Single
        Return Complex
    End Function
    Public Function ModulusArgument() As String
        Return $"{LSet(Modulus(), 5)}, θ = {LSet(Argument(), 4)}"
    End Function
End Class