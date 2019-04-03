Module Module1

    Sub Main()
        Dim Success As Boolean
        Dim input As String

        Dim OperandCount As Integer
        Dim OperationCount As Integer
        Do
            Success = True
            OperandCount = 0
            OperationCount = 0
            Try
                Console.Write("Input: ")
                input = Console.ReadLine()
                Dim TempExpression() As String = input.Split(" ")
                For i = 0 To TempExpression.Length - 1
                    If IsNumeric(TempExpression(i)) Then
                        OperandCount += 1
                    Else
                        OperationCount += 1
                    End If
                Next
                If Not OperationCount + 1 = OperandCount Then
                    Throw New ArgumentException
                End If
            Catch ex As ArgumentException
                Console.WriteLine("Invalid input!")
                Success = False
            End Try
        Loop Until Success = True
        Dim Expression() As String = input.Split(" ")
        Dim NumberSTack As New Stack(Expression.Length - 1)
        For i = 0 To Expression.Length - 1
            If IsNumeric(Expression(i)) Then
                NumberStack.Push(Expression(i))
            Else
                If Expression(i) = "+" Then
                    NumberStack.Push(NumberStack.Pop + NumberStack.Pop)
                ElseIf Expression(i) = "*" Then
                    NumberStack.Push(NumberStack.Pop * NumberStack.Pop)
                ElseIf Expression(i) = "-" Then
                    NumberStack.Push(-(NumberStack.Pop - NumberStack.Pop))
                ElseIf Expression(i) = "/" Then
                    NumberSTack.Push((NumberSTack.Pop / NumberSTack.Pop) ^ -1)
                Else
                    Throw New InvalidCastException
                End If
            End If
        Next
        Console.WriteLine(NumberStack.Pop)
        Console.ReadKey()
    End Sub

End Module
