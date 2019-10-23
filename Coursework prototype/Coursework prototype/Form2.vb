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
        For i = 0 To MatrixGrid.DisplayedRowCount(True) - 1
            For j = 0 To MatrixGrid.DisplayedColumnCount(True) - 1
                TheMatrix(i, j) = MatrixGrid.Rows(i).Cells(j).Value
            Next
        Next
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
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles InvertMatrix.Click
        Label1.Visible = False
        Dim TheMatrix(,) As Single = GridToMatrix()
        If MatrixGrid.DisplayedColumnCount(True) = MatrixGrid.DisplayedRowCount(True) Then
            If MatrixGrid.DisplayedColumnCount(True) = 2 Then
                Label1.Text = Nothing
                Dim InverseMatrix(,) As Single = Invert2xMatrix(TheMatrix)
                Label1.Text &= "┌                             ┐"
                Label1.Text &= vbCrLf
                For x = 0 To 1
                    Label1.Text &= "│ "
                    For y = 0 To 1
                        Label1.Text = Label1.Text & " " & LSet(InverseMatrix(x, y), 9)
                    Next
                    Label1.Text = Label1.Text & " │" & vbCrLf
                Next
                Label1.Text &= "└                             ┘"
            ElseIf MatrixGrid.DisplayedColumnCount(True) = 3 Then
                Label1.Text = Nothing
                Dim InverseMatrix(,) As Single = Invert3xMatrix(TheMatrix)
                Label1.Text &= "┌                                       ┐"
                Label1.Text &= vbCrLf
                For x = 0 To 2
                    Label1.Text &= "│ "
                    For y = 0 To 2
                        Label1.Text = Label1.Text & " " & LSet(InverseMatrix(x, y), 9)
                    Next
                    Label1.Text = Label1.Text & " │" & vbCrLf
                Next
                Label1.Text &= "└                                       ┘"
            ElseIf MatrixGrid.DisplayedColumnCount(True) = 4 Then
                Label1.Text = Nothing
                Dim InverseMatrix(,) As Single = Invert4xMatrix(TheMatrix)
                Label1.Text &= "┌                                                   ┐"
                Label1.Text &= vbCrLf
                For x = 0 To 3
                    Label1.Text &= "│ "
                    For y = 0 To 3
                        Label1.Text = Label1.Text & " " & LSet(InverseMatrix(x, y), 9)
                    Next
                    Label1.Text = Label1.Text & " │" & vbCrLf
                Next
                Label1.Text &= "└                                                   ┘"
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
        Try
            If FirstMatrix.GetLength(0) = SecondMatrix.GetLength(0) And FirstMatrix.GetLength(1) = SecondMatrix.GetLength(1) Then
                MatrixSlot3 = AddMatrices(FirstMatrix, SecondMatrix) 'tempstoring
            End If
        Catch ex As NullReferenceException
            MsgBox("One of the matrix slots has no matrix stored...")
        End Try
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
        Try
            If FirstMatrix.GetLength(0) = SecondMatrix.GetLength(0) And FirstMatrix.GetLength(1) = SecondMatrix.GetLength(1) Then
                MatrixSlot3 = SubtractMatrices(FirstMatrix, SecondMatrix) 'tempstoring
            End If
        Catch ex As NullReferenceException
            MsgBox("One of the matrix slots has no matrix stored...")
        End Try
    End Sub

    Private Sub MultiplyMatrix_Click(sender As Object, e As EventArgs) Handles MultiplyMatrix.Click
        Dim FirstMatrix(,) As Single = MatrixFromComboBox(SelectMatrix1)
        Dim SecondMatrix(,) As Single = MatrixFromComboBox(SelectMatrix2)
        Try
            'If FirstMatrix.GetLength(0) = SecondMatrix.GetLength(0) And FirstMatrix.GetLength(1) = SecondMatrix.GetLength(1) Then
            MatrixSlot3 = SquareMultiplyMatrices(FirstMatrix, SecondMatrix) 'tempstoring
            'End If
        Catch ex As NullReferenceException
            MsgBox("One of the matrix slots has no matrix stored...")
        End Try
    End Sub
End Class