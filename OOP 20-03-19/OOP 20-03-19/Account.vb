
Public Class Account
    Protected balance As Double
    Protected overDraftLimit As Double
    Protected owner As Customer

    Public Sub New(ByVal inOwner As Customer)
            balance = 0
            overDraftLimit = 0
            owner = inOwner
        End Sub

        Public Sub New(ByVal inOwner As Customer, ByVal startBalance As Double)
            balance = startBalance
            owner = inOwner

            If owner.IsPremium() Then
                overDraftLimit = 1500
            Else
                overDraftLimit = 0
            End If
        End Sub

        Public Sub MakeDeposit(ByVal Amount As Double)
            balance += Amount
        End Sub

        Public Function GetBalance() As Double
            Return balance
        End Function

        Public Sub MakeWithdrawal(ByVal Amount As Double)
            If balance + overDraftLimit >= Amount Then
                balance -= Amount
            Else
            Throw New AccountWithdrawalException(owner.GetName())
        End If
        End Sub
End Class