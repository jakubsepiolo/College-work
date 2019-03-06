Module Module1
    Sub ShiftDown(ByRef Numbers() As Integer, ByVal start As Integer, ByVal endd As Integer)
        Dim root As Integer = start
        Dim lb As Integer = LBound(Numbers)
        Dim Temp As Integer

        While root * 2 + 1 <= endd
            Dim child As Integer = root * 2 + 1
            If child + 1 <= endd Then
                If Numbers(lb + child) < Numbers(lb + child + 1) Then
                    child += 1
                End If
            End If
            If Numbers(lb + root) < Numbers(lb + child) Then
                Temp = Numbers(lb + root)
                Numbers(lb + root) = Numbers(lb + child)
                Numbers(lb + child) = Temp
                root = child
            Else
                Exit Sub
            End If
        End While
        '' For i = 0 To Numbers.Length - 1
        'Console.Write($"{Numbers(i)}, ")
        'Next
    End Sub
    Sub HeapSort(ByRef Numbers() As Integer)
        Dim lb As Integer = LBound(Numbers)
        Dim count As Integer = UBound(Numbers) - lb + 1
        Dim start As Integer = (count - 2) \ 2
        Dim endd As Integer = count - 1
        While start >= 0
            ShiftDown(Numbers, start, endd)
            start -= 1
        End While
        Dim Temp As Integer
        While endd > 0
            Temp = Numbers(lb + endd)
            Numbers(lb + endd) = Numbers(lb)
            Numbers(lb) = Temp

            endd -= 1
            ShiftDown(Numbers, 0, endd)
        End While

    End Sub
    Sub Main()
        Randomize()
        Dim Numbers() As Integer = {96, 94, 60, 26, 98, 65, 36, 52, 88, 17, 39, 91, 47, 38, 10, 8, 36, 75, 11, 93, 43, 98, 39, 37, 49, 89, 57, 33, 31, 54, 52, 5, 76, 65, 14, 57, 25, 22, 51, 51, 52, 41, 17, 7, 50, 73, 69, 32, 56, 37, 54, 70, 96, 89, 12, 77, 53, 8, 14, 27, 65, 10, 14, 33, 46, 89, 38, 5, 27, 80, 85, 21, 30, 49, 68, 29, 63, 5, 63, 78, 38, 41, 99, 65, 18, 97, 61, 14, 90, 50, 26, 77, 54, 26, 19, 59, 48, 42, 96, 73, 94}
        Dim TimeTaken As Stopwatch = Stopwatch.StartNew()
        TimeTaken.Start()
        HeapSort(Numbers)
        TimeTaken.Stop()
        Console.Write("{")
        For i = 0 To Numbers.Length - 1
            Console.Write($"{Numbers(i)}, ")

        Next
        Console.WriteLine("}")
        Console.Write($"Sorted, it took {TimeTaken.ElapsedMilliseconds}ms")
        Console.ReadKey()
    End Sub

End Module
