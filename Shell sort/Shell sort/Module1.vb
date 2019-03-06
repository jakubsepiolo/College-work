Module Module1
    Sub ShellSort(ByRef Numbers() As Integer)
        Dim Interval As Integer
        While Interval < Numbers.Length \ 3
            Interval = Interval * 3 + 1
        End While
        While Interval > 0
            For outer = Interval To Numbers.Length - 1
                Dim valueToInsert = Numbers(outer)
                Dim Inner = outer
                While Inner > Interval - 1 And Numbers(Inner - Interval) >= valueToInsert
                    Numbers(Inner) = Numbers(Inner - Interval)

                    If Inner - 2 * Interval < 0 Then
                        Inner = Numbers.Length - (1 + Interval)
                    Else
                        Inner = Inner - Interval
                    End If
                End While
                Numbers(Inner) = valueToInsert
            Next
            Interval = (Interval - 1) \ 3
        End While
    End Sub

    Sub Main()
        Dim Numbers() As Integer = {1, 5, 32, 2, 17, 21, 67, 54, 32, 19, 3, 4, 7}
        ShellSort(Numbers)
        For i = 0 To Numbers.Length - 1
            Console.WriteLine(Numbers(i))
        Next
        Console.ReadLine()
    End Sub

End Module
