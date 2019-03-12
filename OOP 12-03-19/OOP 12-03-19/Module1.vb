Module Module1
    Dim BankAccount As New Account() With {.Name = "Jakub",
        .Balance = 1000,
        .OverDraftLimit = 500}


    Sub Main()
        Dim choice As Integer
        Do
            menu()
            choice = Console.ReadLine
            Select Case choice
                Case 1
                    Deposit()
                Case 2
                    Withdrawal()
                Case 3
                    Balance()
                Case 4
                    ChangeName()
            End Select
        Loop Until choice = 9
    End Sub

    Sub ErrorMessage(ByVal Text As String)
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine(Text)
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub
    Sub menu()
        Console.WriteLine($"Welcome to the Gringotts Bank {BankAccount.Name}")
        Console.WriteLine()
        Console.WriteLine("1. Deposit")
        Console.WriteLine("2. Withdrawal")
        Console.WriteLine("3. See Balance")
        Console.WriteLine("4. Change Name")
        Console.WriteLine()
        Console.WriteLine("9. Exit")
        Console.WriteLine()
    End Sub
    Sub Deposit()
        Dim Success As Boolean = False
        Dim DepositAmount As Integer
        Do
            Success = True
            Try
                Console.WriteLine("How much would you like to withdraw? ")
                DepositAmount = Console.ReadLine()
                If DepositAmount <= 0 Then
                    Throw New ArgumentOutOfRangeException(message:="Number is not greater than 1", innerException:=Nothing)
                End If
            Catch ex As ArgumentOutOfRangeException
                ErrorMessage("Number is not greater than 0")
                Success = False
            Catch ex As InvalidCastException
                ErrorMessage("Input was not a number")
                Success = False
            Catch ex As OverflowException
                ErrorMessage("Number is too big")
                Success = False
            End Try
        Loop Until Success = True
        BankAccount.MakeWithdrawal(DepositAmount)
        Console.WriteLine($"Deposit of £{DepositAmount} has been made to {BankAccount.Name}'s account")
        Console.WriteLine()
    End Sub
    Sub Withdrawal()
        Dim Success As Boolean = False
        Dim WithdrawAmount As Integer
        Do
            Success = True
            Try
                Console.WriteLine("How much would you like to withdraw? ")
                WithdrawAmount = Console.ReadLine()
                If WithdrawAmount <= 0 Then
                    Throw New ArgumentOutOfRangeException(message:="Number is not greater than 1", innerException:=Nothing)
                End If
            Catch ex As ArgumentOutOfRangeException
                ErrorMessage("Number is not greater than 0")
                Success = False
            Catch ex As InvalidCastException
                ErrorMessage("Input was not a number")
                Success = False
            Catch ex As OverflowException
                ErrorMessage("Number is too big")
                Success = False
            End Try
        Loop Until Success = True
        BankAccount.MakeWithdrawal(WithdrawAmount)
        Console.WriteLine($"Withdrawal of £{WithdrawAmount} has been made on {BankAccount.Name}'s account")
        Console.WriteLine()
    End Sub
    Sub Balance()
        Console.WriteLine($"Current balance in {BankAccount.Name}'s account is: £{BankAccount.ShowBalance()}")
    End Sub

    Sub CHangeName()
        Console.WriteLine("What would you like to change the name to")
        Dim NewName As String = Console.ReadLine()
        BankAccount.ChangeName(NewName)
    End Sub

End Module
