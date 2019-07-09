Public Class Form2

    Public MatrixSlot1(,) As Single
    Public MatrixSlot2(,) As Single
    Public MatrixSlot3(,) As Single
    Public MatrixSlot4(,) As Single
    Public MatrixSlot5(,) As Single

    Public Function GridToMatrix() As Single(,)
        Dim TheMatrix(DataGridView1.DisplayedColumnCount(True) - 1, DataGridView1.DisplayedRowCount(True) - 1) As Single
        For i = 0 To DataGridView1.DisplayedColumnCount(True) - 1
            For j = 0 To DataGridView1.DisplayedRowCount(True) - 1
                TheMatrix(i, j) = DataGridView1.Rows(j).Cells(i).Value
            Next
        Next
        Return TheMatrix
    End Function
    Private Sub Loaded() Handles Me.Load
        DataGridView1.AllowUserToAddRows = False
    End Sub

    Private Sub selection(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        DataGridView1.ClearSelection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If DataGridView1.DisplayedRowCount(True) < 4 Then
                DataGridView1.Rows.Add()
            End If

        Catch ex As InvalidOperationException
            MsgBox("You must add a column before adding rows")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.DisplayedColumnCount(True) < 4 Then
            DataGridView1.Columns.Add(Str(DataGridView1.DisplayedColumnCount(True)), " ")
            DataGridView1.Columns(DataGridView1.DisplayedColumnCount(True) - 1).SortMode = DataGridViewColumnSortMode.NotSortable
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
        For x = 0 To 2
            For y = 0 To 2
                InverseMatrix(y, x) = Matrix(x, y)
            Next
        Next

        InverseMatrix(0, 0) = Matrix(1, 1) * Matrix(2, 2) - Matrix(2, 1) * Matrix(1, 2)

        InverseMatrix(1, 0) = -(Matrix(0, 1) * Matrix(2, 2) - Matrix(0, 2) * Matrix(2, 1))

        InverseMatrix(2, 0) = Matrix(0, 1) * Matrix(1, 2) - Matrix(0, 2) * Matrix(1, 1)

        InverseMatrix(0, 1) = -(Matrix(1, 0) * Matrix(2, 2) - Matrix(1, 2) * Matrix(2, 0))

        InverseMatrix(1, 1) = Matrix(0, 0) * Matrix(2, 2) - Matrix(2, 0) * Matrix(0, 2)

        InverseMatrix(2, 1) = -(Matrix(0, 0) * Matrix(1, 2) - Matrix(0, 2) * Matrix(1, 0))

        InverseMatrix(0, 2) = Matrix(1, 0) * Matrix(2, 1) - Matrix(1, 1) * Matrix(2, 0)

        InverseMatrix(1, 2) = -(Matrix(0, 0) * Matrix(2, 1) - Matrix(0, 1) * Matrix(2, 0))

        InverseMatrix(2, 2) = Matrix(0, 0) * Matrix(1, 1) - Matrix(1, 0) * Matrix(0, 1)

        For x = 0 To 2
            For y = 0 To 2
                InverseMatrix(x, y) = (1 / Determinant) * InverseMatrix(x, y)
            Next
        Next

        Return InverseMatrix
    End Function


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label1.Visible = False
        Dim TheMatrix(,) As Single = GridToMatrix()
        If DataGridView1.DisplayedColumnCount(True) = DataGridView1.DisplayedRowCount(True) Then
            If DataGridView1.DisplayedColumnCount(True) = 2 Then
                Label1.Text = Nothing
                Dim InverseMatrix(,) As Single = Invert2xMatrix(TheMatrix)
                For x = 0 To 1
                    For y = 0 To 1
                        Label1.Text = Label1.Text & " " & InverseMatrix(x, y)
                    Next
                    Label1.Text = Label1.Text & vbCrLf
                Next
            ElseIf DataGridView1.DisplayedColumnCount(True) = 3 Then
                Label1.Text = Nothing
                Dim InverseMatrix(,) As Single = Invert3xMatrix(TheMatrix)
                For x = 0 To 2
                    For y = 0 To 2
                        Label1.Text = Label1.Text & " " & LSet(InverseMatrix(x, y), 7)
                    Next
                    Label1.Text = Label1.Text & vbCrLf
                Next
            End If
        End If
        MsgBox(Label1.Text, vbInformation, "Matrix inverse returned:")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.DisplayedRowCount(True) > 1 Then
            DataGridView1.Rows.RemoveAt(DataGridView1.DisplayedRowCount(True) - 1)
        Else
            MsgBox("You cannot have 0 rows!")
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If DataGridView1.DisplayedColumnCount(True) > 1 Then
            DataGridView1.Columns.RemoveAt(DataGridView1.DisplayedColumnCount(True) - 1)
        Else
            MsgBox("You cannot have 0 columns!")
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form3.OpenThisForm(Button6, e)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form3.OpenThisForm(Button7, e)
    End Sub
End Class