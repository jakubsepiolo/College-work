Public Class Form1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FirstInput As String = TextBox1.Text
        Dim SecondInput As String = TextBox2.Text
        Dim RealOne As String
        Dim ComplexOne As String
        Dim RealTwo As String
        Dim ComplexTwo As String

        For i = 0 To Len(FirstInput) - 2

            If i > InStr(FirstInput, "+") - 1 Then
                'Or i > InStr(FirstInput, "-")' Then
                ComplexOne = ComplexOne & FirstInput(i)
            ElseIf i < InStr(FirstInput, "+") - 1 Then
                'Or i < InStr(FirstInput, "-") Then
                RealOne = RealOne & FirstInput(i)
            End If

        Next
        Dim NumberOne As New ComplexNumber(Convert.ToSingle(RealOne), Convert.ToSingle(ComplexOne))

        For i = 0 To Len(SecondInput) - 2
            If i > InStr(SecondInput, "+") - 1 Then
                'Or i > InStr(SecondInput, "-") Then
                ComplexTwo = ComplexTwo & SecondInput(i)
            ElseIf i < InStr(SecondInput, "+") - 1 Then
                'Or i < InStr(SecondInput, "-") Then
                RealTwo = RealTwo & SecondInput(i)
            End If

        Next
        Dim NumberTwo As New ComplexNumber(Convert.ToSingle(RealTwo), Convert.ToSingle(ComplexTwo))
        Dim Total As ComplexNumber
        Total = NumberOne + NumberTwo
        If Total.Complex > 0 Then
            TextBox3.Text = Total.Real & "+" & Total.Complex & "i"
        ElseIf Total.Complex = 0 Then
            TextBox3.Text = Total.Real
        Else

            TextBox3.Text = Total.Real & Total.Complex & "i"
        End If

    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
