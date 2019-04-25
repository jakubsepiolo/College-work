Public Class CItem
    Protected Type As String
    Protected Name As String
    Protected Reusable As Boolean
    Protected Count As Integer
    Public Sub New(ByVal Name As String, ByVal Type As String, ByVal Reusable As Boolean)
        Me.Type = Type
        Me.Name = Name
        Me.Reusable = Reusable
        Count = 1
    End Sub
    Public Overridable Sub UseItem()
    End Sub
    Public Function IsReusable() As Boolean
        Return Reusable
    End Function
End Class
