Public Class SavingsAccount
    Inherits Account
    Private interestRate As Decimal
    Public Sub New(ByVal inOwner As Customer, ByVal startBalance As Double, ByVal interestRate As Decimal)
        MyBase.New(inOwner, startBalance)
        Me.interestRate = interestRate
    End Sub

    Public Sub AddAnnualInterest()
        If balance > 0 Then
            Console.WriteLine($"Added £{balance * interestRate} from interest")
            balance = balance * (1 + interestRate)
        End If
    End Sub
End Class
