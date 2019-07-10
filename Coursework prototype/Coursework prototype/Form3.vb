Public Class Form3

    Dim WhatWeAreDoing As String
    Dim WorkingMatrix(,) As Single
    Dim WhoSentUs As Object

    Private Sub Loaded() Handles Me.Load
        Label1.Text = Nothing
    End Sub

    Public Sub OpenThisForm(sender As Object, e As EventArgs)
        Show()
        WhoSentUs = sender
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If WhoSentUs Is Form2.Button7 Then
            If ComboBox1.Text = "Matrix slot 1 " Then
                For x = 0 To Form2.MatrixSlot1.GetLength(0) - 1
                    For y = 0 To Form2.MatrixSlot1.GetLength(1) - 1
                        Label1.Text = Label1.Text & " " & LSet(Form2.MatrixSlot1(x, y), 7)
                    Next
                    Label1.Text = Label1.Text & vbCrLf
                Next
                WorkingMatrix = Form2.MatrixSlot1
            ElseIf ComboBox1.Text = "Matrix slot 2 " Then
                For x = 0 To Form2.MatrixSlot2.GetLength(0) - 1
                    For y = 0 To Form2.MatrixSlot2.GetLength(1) - 1
                        Label1.Text = Label1.Text & " " & LSet(Form2.MatrixSlot2(x, y), 7)
                    Next
                    Label1.Text = Label1.Text & vbCrLf
                Next
                WorkingMatrix = Form2.MatrixSlot2
            ElseIf ComboBox1.Text = "Matrix slot 3 " Then
                For x = 0 To Form2.MatrixSlot3.GetLength(0) - 1
                    For y = 0 To Form2.MatrixSlot3.GetLength(1) - 1
                        Label1.Text = Label1.Text & " " & LSet(Form2.MatrixSlot3(x, y), 7)
                    Next
                    Label1.Text = Label1.Text & vbCrLf
                Next
                WorkingMatrix = Form2.MatrixSlot3
            ElseIf ComboBox1.Text = "Matrix slot 4 " Then
                For x = 0 To Form2.MatrixSlot4.GetLength(0) - 1
                    For y = 0 To Form2.MatrixSlot4.GetLength(1) - 1
                        Label1.Text = Label1.Text & " " & LSet(Form2.MatrixSlot4(x, y), 7)
                    Next
                    Label1.Text = Label1.Text & vbCrLf
                Next
                WorkingMatrix = Form2.MatrixSlot4
            ElseIf ComboBox1.Text = "Matrix slot 5 " Then
                For x = 0 To Form2.MatrixSlot4.GetLength(0) - 1
                    For y = 0 To Form2.MatrixSlot4.GetLength(1) - 1
                        Label1.Text = Label1.Text & " " & LSet(Form2.MatrixSlot4(x, y), 7)
                    Next
                    Label1.Text = Label1.Text & vbCrLf
                Next
                WorkingMatrix = Form2.MatrixSlot4
            End If
            WhatWeAreDoing = "Load"
        ElseIf WhoSentUs Is Form2.Button6 Then
            WhatWeAreDoing = "Save"
        Else
            MsgBox("How?")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If WhatWeAreDoing = "Load" Then
            While Form2.DataGridView1.DisplayedRowCount(True) <> WorkingMatrix.GetLength(0)
                If Form2.DataGridView1.DisplayedRowCount(True) > WorkingMatrix.GetLength(0) Then
                    Form2.DataGridView1.Rows.RemoveAt(Form2.DataGridView1.DisplayedRowCount(True) - 1)
                ElseIf Form2.DataGridView1.DisplayedRowCount(True) < WorkingMatrix.GetLength(0) Then
                    Form2.DataGridView1.Rows.Add()
                End If

            End While
            While Form2.DataGridView1.DisplayedColumnCount(True) <> WorkingMatrix.GetLength(1)
                If Form2.DataGridView1.DisplayedColumnCount(True) > WorkingMatrix.GetLength(1) Then
                    Form2.DataGridView1.Columns.RemoveAt(Form2.DataGridView1.DisplayedColumnCount(True) - 1)
                ElseIf Form2.DataGridView1.DisplayedColumnCount(True) < WorkingMatrix.GetLength(1) Then
                    Form2.DataGridView1.Columns.Add(Str(Form2.DataGridView1.DisplayedColumnCount(True)), " ")
                    Form2.DataGridView1.Columns(Form2.DataGridView1.DisplayedColumnCount(True) - 1).SortMode = DataGridViewColumnSortMode.NotSortable
                End If
            End While
            For x = 0 To WorkingMatrix.GetLength(0) - 1
                For y = 0 To WorkingMatrix.GetLength(1) - 1
                    Form2.DataGridView1.Rows(x).Cells(y).Value = WorkingMatrix(x, y)
                Next
            Next

        ElseIf WhatWeAreDoing = "Save" Then

            If ComboBox1.Text = "Matrix slot 1 " Then
                Form2.MatrixSlot1 = Form2.GridToMatrix()
            ElseIf ComboBox1.Text = "Matrix slot 2 " Then
                Form2.MatrixSlot2 = Form2.GridToMatrix()
            ElseIf ComboBox1.Text = "Matrix slot 3 " Then
                Form2.MatrixSlot3 = Form2.GridToMatrix()
            ElseIf ComboBox1.Text = "Matrix slot 4 " Then
                Form2.MatrixSlot4 = Form2.GridToMatrix()
            ElseIf ComboBox1.Text = "Matrix slot 5 " Then
                Form2.MatrixSlot5 = Form2.GridToMatrix()
            End If

        End If
    End Sub
End Class
