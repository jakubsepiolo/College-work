Public Class Account
    Public Name As String
    Private Balance As Integer
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

    Public Function ShowBalance() As Integer
        Return Balance
    End Function

End Class
