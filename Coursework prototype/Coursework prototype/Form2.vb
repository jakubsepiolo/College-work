Public Class Form2
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


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim TheMatrix(,) As Single = GridToMatrix()
        If DataGridView1.DisplayedColumnCount(True) = DataGridView1.DisplayedRowCount(True) And DataGridView1.DisplayedColumnCount(True) = 2 Then
            Dim InverseMatrix(DataGridView1.DisplayedColumnCount(True) - 1, DataGridView1.DisplayedRowCount(True) - 1) As Single
            Label1.Text = Nothing
            InverseMatrix(0, 0) = TheMatrix(1, 1)
            InverseMatrix(0, 1) = -TheMatrix(0, 1)
            InverseMatrix(1, 0) = -TheMatrix(1, 0)
            InverseMatrix(1, 1) = TheMatrix(0, 0)
            Dim Determinant As Single
            Determinant = 1 / (TheMatrix(0, 0) * TheMatrix(1, 1) - TheMatrix(1, 0) * TheMatrix(0, 1))
            For x = 0 To 1
                For y = 0 To 1
                    InverseMatrix(x, y) = InverseMatrix(x, y) * Determinant
                    Label1.Text = Label1.Text & " " & InverseMatrix(x, y)
                Next
                Label1.Text = Label1.Text & vbCrLf
            Next
        End If

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
End Class