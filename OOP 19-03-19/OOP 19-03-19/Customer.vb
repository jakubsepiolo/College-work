Public Class Customer
    Private CustomerName As String
    Private CustomerPremium As Boolean
    Public Sub New(ByVal CustomerName As String, ByVal CustomerPremium As Boolean)
        Me.CustomerName = CustomerName
        Me.CustomerPremium = CustomerPremium
    End Sub
    Public Function GetName() As String
        Return CustomerName
    End Function
    Public Function IsPremium() As Boolean
        Return CustomerPremium
    End Function
End Class
