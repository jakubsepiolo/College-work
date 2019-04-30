Module Module1
    Dim twoArray(32, 32) As Char
    Function Recursion(Top As Integer, Left As Integer, Width As Integer, Height As Integer) As Integer
        If Height = 0 Then
            twoArray(Top, Left) = "X"
        Else
            Recursion(Top, Left + Width, Width / 2, Height - 1)
            Recursion(Top + Width, Left, Width / 2, Height - 1)
            Recursion(Top + Width * 2, Left + Width, Width / 2, Height - 1)
        End If
    End Function
    Sub Main()
        Recursion(1, 1, 32, 32)
        Console.ReadKey()

    End Sub

End Module
