Module Module1
    Dim Width As Integer = 32
    Dim Height As Integer = 32
    Dim Graph(Width, Height) As Integer
    Sub AddRelation(a, b)
        Graph(a, b) = 1
    End Sub

    Function HasRelation(a, b) As Boolean
        Return Graph(a, b) = 1
    End Function

    Sub FindMutualRelation(a, b)
        For i = 0 To Width
            If Graph(i, a) = 1 And Graph(i, b) = 1 And (i <> a Or i <> b) Then
                Console.WriteLine($"{a} and {b} Mutual relation with {i}")
            End If
        Next
    End Sub

    Sub Main()
        Randomize()
        For x = 0 To Width
            For y = 0 To Height
                If x = y Then
                    Graph(x, y) = 0
                Else
                    Graph(x, y) = Int(Rnd() * 2)
                End If

            Next
        Next
        Console.ForegroundColor = ConsoleColor.Magenta
        Console.Write("  ")
        For i = 0 To Width
            Console.Write(" ")
            Console.Write(LSet(i, 2))
        Next
        Console.Write(" ")
        Console.WriteLine()
        For x = 0 To Width
            Console.Write(LSet(x, 2))
            Console.Write("|")

            For y = 0 To Height
                Console.ForegroundColor = ConsoleColor.Green
                If Graph(x, y) = 0 Then
                    Console.Write("   ")
                Else
                    Console.Write(LSet(Graph(x, y), 2))
                    Console.Write(" ")
                End If

            Next
            Console.ForegroundColor = ConsoleColor.Magenta
            Console.WriteLine()
        Next
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine(HasRelation(3, 4))
            FindMutualRelation(2, 1)
            Console.ReadKey()
    End Sub

End Module
