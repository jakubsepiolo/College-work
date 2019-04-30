Public Class CPotion
    Inherits CItem
    Private PotionType As String
    Public Sub New(ByVal PotionType As String)
        MyBase.New(PotionType, "Potion", False)
        Me.PotionType = PotionType
    End Sub
    Public Overrides Sub UseItem()
        If IsReusable() Or Count <> 0 Then
            If PotionType.ToLower() = "mana" Then
                Count = 0

            ElseIf PotionType.ToLower() = "health" Then
                Count = 0
            End If
        End If
    End Sub

End Class
