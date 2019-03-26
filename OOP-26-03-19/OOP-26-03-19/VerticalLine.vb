Public Class VerticalLine
    Inherits Drawable

    Private length As Integer

    Public Sub New(ByVal l As Integer)
        length = l
    End Sub

    Public Overrides Sub Draw()
        For i = 1 To length
            Console.Write("*")
        Next
        Console.WriteLine()
    End Sub
End Class
