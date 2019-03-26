Public Class HorizontalLine
    Inherits Drawable

    Private height As Integer

    Public Sub New(ByVal h As Integer)
        height = h
    End Sub

    Public Overrides Sub Draw()
        For i = 1 To height
            Console.WriteLine()
            Console.Write("*")
        Next
        Console.WriteLine()
    End Sub
End Class
