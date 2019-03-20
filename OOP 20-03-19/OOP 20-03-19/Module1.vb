Module Module1

    Sub Main()
        Dim myself As New Customer("Me", True)
        Dim mySavings As New SavingsAccount(myself, 1000, 0.015)

        Console.WriteLine("Balance: £" & mySavings.GetBalance())
        Console.ReadKey()

        mySavings.MakeDeposit(100)
        Console.WriteLine("Balance: £" & mySavings.GetBalance())
        Console.ReadKey()

        mySavings.AddAnnualInterest()
        Console.WriteLine("Balance: £" & mySavings.GetBalance())
        Console.ReadKey()

        mySavings.AddAnnualInterest()
        Console.WriteLine("Balance: £" & mySavings.GetBalance())
        Console.ReadKey()

        mySavings.MakeWithdrawal(10000)



    End Sub

End Module
