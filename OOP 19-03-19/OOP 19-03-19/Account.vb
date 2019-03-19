Public Class Account
    Private Balance As Integer
    Private OverDraftLimit As Integer
    Private AccountOwner As Customer



    Public Sub New()
        Balance = 0
        OverDraftLimit = 0
    End Sub

    Public Sub New(ByVal startBalance As Integer, ByVal AccountOwner As Customer)
        Balance = startBalance
        If AccountOwner.IsPremium() Then
            OverDraftLimit = 1500
        Else
            OverDraftLimit = 0
        End If
        Me.AccountOwner = AccountOwner
    End Sub

    Public Sub MakeDeposit(ByVal Amount As Integer)
        Balance += Amount
    End Sub

    Public Function GetBalance() As Integer
        Return Balance
    End Function

    Public Sub MakeWithdrawal(ByVal Amount As Integer)
        If Balance + OverDraftLimit >= Amount Then
            Balance -= Amount
        Else
            Throw New ArgumentException("Insufficient funds.")
        End If
    End Sub
End Class
