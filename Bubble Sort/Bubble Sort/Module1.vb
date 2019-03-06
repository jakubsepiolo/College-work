Module Module1

    Sub Swap(ByRef Numbers() As Integer, ByVal int1 As Integer, ByVal int2 As Integer)
        Dim Temp As Integer = Numbers(int1)
        Numbers(int1) = Numbers(int2)
        Numbers(int2) = Temp
    End Sub

    Sub Main()
        Dim Numbers() As Integer = {1, 5, 32, 2, 17, 21, 67, 54, 32, 19, 3, 4, 7}
        For i = 0 To (Numbers.Count() - 2)
            Dim Swapped As Boolean = False
            For j = 0 To (Numbers.Count() - 2)
                If Numbers(j) > Numbers(j + 1) Then
                    Swap(Numbers, j, j + 1)
                    Swapped = True
                End If
            Next
            If Not Swapped Then
                Exit For
            End If
        Next
        For i = 0 To (Numbers.Count() - 1)
            Console.WriteLine(Numbers(i))
        Next
        Console.ReadKey()
    End Sub
End Module
