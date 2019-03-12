Module Module1

    Function IsInteger(ByVal Number As Decimal) As Boolean
        If Number = Int(Number) Then
            Return True
        Else
            Return False
        End If
    End Function
    Function IsPrime(ByVal Number As Integer) As Boolean
        For i = 2 To Number - 1
            If IsInteger(Number / i) Then
                Return False
            End If
        Next
        Return True
    End Function

    Sub ErrorMessage(ByVal Text As String)
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine(Text)
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub
    Sub Main()
        Dim Success As Boolean = False
        Dim Number As Integer
        While True
            Do
            Success = True
                Try
                    Console.Write("Enter a number greater than 1 to check if it is prime: ")
                    Number = Console.ReadLine()
                    If Number <= 1 Then
                        Throw New ArgumentOutOfRangeException(message:="Number is not greater than 1", innerException:=Nothing)
                    End If
                Catch ex As ArgumentOutOfRangeException
                    ErrorMessage("Number is not greater than 1")
                    Success = False
                Catch ex As InvalidCastException
                    ErrorMessage("Input was not a number")
                    Success = False
                Catch ex As OverflowException
                    ErrorMessage("Number is too big")
                    Success = False
                End Try
        Loop Until Success = True
            If IsPrime(Number) Then
                Console.WriteLine($"{Number} is a prime number")
            Else
                Console.WriteLine($"{Number} is not a prime number")
            End If
            Console.Write("Input another number?(Y/N)")
            If Console.ReadLine().ToLower <> "y" Then
                Exit While
            End If
        End While
        Console.ReadKey()
    End Sub

End Module
