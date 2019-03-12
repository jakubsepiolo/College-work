Public Class Account
    Public Name As String
    Public Balance As Integer
    Public OverDraftLimit As Integer

    Public Sub MakeDeposit(ByVal Amount As Integer)
        Balance += Amount
    End Sub

    Public Sub MakeWithdrawal(ByVal Amount As Integer)
        Balance -= Amount
    End Sub

    Public Sub ChangeName(ByVal NewName As String)
        Name = NewName
    End Sub

    Public Function ShowBalance()
        Return Balance
    End Function

End Class
