Public Class Square
    Inherits Drawable

    Private side As Integer

    Public Sub New(ByVal side As Integer)
        Me.side = side
    End Sub

    Public Overrides Sub Draw()
        For y = 1 To side
            For x = 1 To side
                Console.Write("* ")
            Next
            Console.WriteLine()
        Next
    End Sub
End Class
