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
        Dim Numbers() As Integer = {1, 5, 32, 2, 17, 21, 67, 54, 32, 19, 3, 4, 7}
        HeapSort(Numbers)
        For i = 0 To Numbers.Length - 1
            Console.WriteLine(Numbers(i))
        Next
        Console.ReadKey()
    End Sub

End Module
