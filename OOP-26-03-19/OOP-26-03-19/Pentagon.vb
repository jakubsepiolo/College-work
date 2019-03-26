Public Class Pentagon
    Inherits Drawable
    Private SideLength As Integer

    Public Sub New(ByVal SideLength As Integer)
        Me.SideLength = SideLength
    End Sub

    Public Overrides Sub Draw()
        For i = 1 To SideLength
            For j = 1 To SideLength - i
                Console.Write(" ")
            Next
            For j = 1 To ((i - 1) * 2 + 1)
                Console.Write("*")
            Next
            Console.WriteLine()
        Next
    End Sub

    Private Function Pythagoras(ByVal X As Integer, ByVal Y As Integer) As Integer
        Return Math.Truncate(Math.Sqrt(X ^ 2 + Y ^ 2))
    End Function
End Class
