Public Class AccountWithdrawalException
    Inherits Exception
    Private AccountOwner As String
    Public Sub New(ByVal AccountOwner As String)
        MyBase.New("Withdrawal would go over limit")
        Me.AccountOwner = AccountOwner
        Console.WriteLine($"Error in {GetOwnerName()}'s account")
    End Sub
    Public Function GetOwnerName() As String
        Return AccountOwner
    End Function

End Class
