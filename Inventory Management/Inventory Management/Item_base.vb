Public Class Item_base

    Private itemID As UInteger
    Private itemName As String
    Private itemDescription As String
    Private itemCost As Decimal
    Private itemMax As UInteger
    Private itemType As String


    Public Sub New(ByVal itemID As UInteger, ByVal itemName As String, ByVal itemDescription As String, ByVal itemCost As Decimal, ByVal itemMax As UInteger, ByVal itemType As String)
        Me.itemID = itemID
        Me.itemName = itemName
        Me.itemDescription = itemDescription
        Me.itemCost = itemCost
        Me.itemMax = itemMax
        Me.itemType = itemType
    End Sub

    Public Function GetName() As String
        Return itemName
    End Function

    Public Function GetID() As UInteger
        Return itemID
    End Function

    Public Function GetCost() As Decimal
        Return itemCost
    End Function

    Public Function GetDescription() As String
        Return itemDescription
    End Function

    Public Function GetMax() As UInteger
        Return itemMax
    End Function

    Public Function GetItemType() As String
        Return itemType
    End Function
    '' add ability to update values on SQL database and re-sync
    '' create new class, for player's inventory
    '' create new class, for "enemies"

End Class
