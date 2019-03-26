Public Class Circle
    Inherits Drawable
    Private Radius As Integer
    Public Sub New(ByVal Radius As Integer)
        Me.Radius = Radius
    End Sub
    Public Overrides Sub Draw()
        For i = 1 To Radius
            For j = 1 To Radius
                If j > 3 And 4 < j And i = Radius - 7 Then
                    Console.Write("* ")
                ElseIf j > 2 And 3 < j And i = Radius - 6 Then
                    Console.Write("* ")
                ElseIf j > 1 And 2 < j And i = Radius - 5 Then
                    Console.Write("* ")
                ElseIf j > 0 And 1 < j And i = Radius - 4 Then
                    Console.Write("* ")
                ElseIf j > 0 And 1 < j And i = Radius - 3 Then
                    Console.Write("* ")
                ElseIf j > 1 And 2 < j And i = Radius - 2 Then
                    Console.Write("* ")
                ElseIf j > 2 And 3 < j And i = Radius - 1 Then
                    Console.Write("* ")
                ElseIf j > 3 And 4 < j And i = Radius Then
                    Console.Write("* ")
                Else
                    Console.Write(" ")

                End If
            Next
            Console.WriteLine()
        Next
    End Sub
End Class
