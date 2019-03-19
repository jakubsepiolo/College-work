Module Module1

    Sub Main()

        Dim myAccount As New Account(100, New Customer("Me", True))
        Dim yourAccount As New Account(100, New Customer("You", False))

        Console.WriteLine("My balance: " & myAccount.GetBalance())
        Console.WriteLine("Your balance: " & myAccount.GetBalance())
        Console.ReadKey()

        myAccount.MakeWithdrawal(100)
        Console.WriteLine("My balance: " & myAccount.GetBalance())
        Console.ReadKey()

        yourAccount.MakeWithdrawal(100)
        Console.WriteLine("Your balance: " & myAccount.GetBalance())
        Console.ReadKey()

        myAccount.MakeWithdrawal(100)
        Console.WriteLine("My balance: " & myAccount.GetBalance())
        Console.ReadKey()

        yourAccount.MakeWithdrawal(100)
        Console.WriteLine("Your balance: " & myAccount.GetBalance())
        Console.ReadKey()

    End Sub

End Module
