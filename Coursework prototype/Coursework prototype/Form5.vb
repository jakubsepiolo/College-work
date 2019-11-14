Public Class Form5
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = ">" Then
            Form4.Inequalities.Add($"{T1.Text}x^4+{T2.Text}x^3+{T3.Text}x^2+{T4.Text}x+{T5.Text}>{T6.Text}x^4+{T7.Text}x^3+{T8.Text}x^2+{T9.Text}x+{T10.Text}")
        ElseIf ComboBox1.Text = "<" Then
            Form4.Inequalities.Add($"{T1.Text}x^4+{T2.Text}x^3+{T3.Text}x^2+{T4.Text}x+{T5.Text}<{T6.Text}x^4+{T7.Text}x^3+{T8.Text}x^2+{T9.Text}x+{T10.Text}")
        ElseIf ComboBox1.Text = "<=" Then
            Form4.Inequalities.Add($"{T1.Text}x^4+{T2.Text}x^3+{T3.Text}x^2+{T4.Text}x+{T5.Text}<={T6.Text}x^4+{T7.Text}x^3+{T8.Text}x^2+{T9.Text}x+{T10.Text}")
        ElseIf ComboBox1.Text = ">=" Then
            Form4.Inequalities.Add($"{T1.Text}x^4+{T2.Text}x^3+{T3.Text}x^2+{T4.Text}x+{T5.Text}>={T6.Text}x^4+{T7.Text}x^3+{T8.Text}x^2+{T9.Text}x+{T10.Text}")
        End If
        Close()
    End Sub
End Class