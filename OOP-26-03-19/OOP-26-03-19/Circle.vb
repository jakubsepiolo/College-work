Public Class Circle
    Inherits Drawable
    Private Radius As Integer
    Public Sub New(ByVal Radius As Integer)
        Me.Radius = Radius
    End Sub
    Public Overrides Sub Draw()
        Dim test As Boolean = True
        For i = -Radius To Radius Step 1
            For j = -Radius To Radius Step 1
                If test Then
                    Console.ForegroundColor = ConsoleColor.Cyan
                    test = Not test
                Else
                    Console.ForegroundColor = ConsoleColor.Blue
                    test = Not test
                End If
                If (i) ^ 2 + (j) ^ 2 <= Radius ^ 2 Then
                    Console.Write("*")
                Else
                    Console.Write(" ")

                End If


            Next
        Console.WriteLine()
            Next
    End Sub
End Class
