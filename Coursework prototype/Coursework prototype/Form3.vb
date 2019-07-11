Public Class Form3

    Dim WhatWeAreDoing As String
    Dim WorkingMatrix(,) As Single
    Dim WhoSentUs As Object
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
            End If
            WhatWeAreDoing = "Load"
        ElseIf WhoSentUs Is Form2.SaveMatrix Then
            WhatWeAreDoing = "Save"
        Else
            MsgBox("How?")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click
        If WhatWeAreDoing = "Load" And WorkingMatrix IsNot Nothing Then
            While Form2.MatrixGrid.DisplayedRowCount(True) <> WorkingMatrix.GetLength(0)
                If Form2.MatrixGrid.DisplayedRowCount(True) > WorkingMatrix.GetLength(0) Then
                    Form2.MatrixGrid.Rows.RemoveAt(Form2.MatrixGrid.DisplayedRowCount(True) - 1)
                ElseIf Form2.MatrixGrid.DisplayedRowCount(True) < WorkingMatrix.GetLength(0) Then
                    Form2.MatrixGrid.Rows.Add()
                End If

            End While
            While Form2.MatrixGrid.DisplayedColumnCount(True) <> WorkingMatrix.GetLength(1)
                If Form2.MatrixGrid.DisplayedColumnCount(True) > WorkingMatrix.GetLength(1) Then
                    Form2.MatrixGrid.Columns.RemoveAt(Form2.MatrixGrid.DisplayedColumnCount(True) - 1)
                ElseIf Form2.MatrixGrid.DisplayedColumnCount(True) < WorkingMatrix.GetLength(1) Then
                    Form2.MatrixGrid.Columns.Add(Str(Form2.MatrixGrid.DisplayedColumnCount(True)), " ")
                    Form2.MatrixGrid.Columns(Form2.MatrixGrid.DisplayedColumnCount(True) - 1).SortMode = DataGridViewColumnSortMode.NotSortable
                End If
            End While
            For x = 0 To WorkingMatrix.GetLength(0) - 1
                For y = 0 To WorkingMatrix.GetLength(1) - 1
                    Form2.MatrixGrid.Rows(x).Cells(y).Value = WorkingMatrix(x, y)
                Next
            Next
            MsgBox($"Matrix loaded from {SelectMatrix.Text} ")
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
