Module Module1

    Function Divide(ByVal a As Single, ByVal b As Single) As Single
        Try
            If b = 0 Then
                Throw New DivisionException
            End If
        Catch ex As DivisionException
            Console.WriteLine(ex.Message)
            Return Nothing
        End Try
        Return a / b
    End Function
    Sub Main()
        Dim Input1 As Single
        Dim Input2 As Single
        While Input2 = 0
            Console.Write("1: ")
            Input1 = Console.ReadLine()
            Console.Write("2: ")
            Input2 = Console.ReadLine()
            Console.WriteLine(Divide(Input1, Input2))
        End While
        Console.ReadKey()
    End Sub

End Module
