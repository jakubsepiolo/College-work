Public Class Player

    Private playerID As UInteger
    Private playerName As String
    Private playerLevel As UInteger
    Private playerStorage As UInteger
    Private playerRank As String


    Public Sub New(ByVal playerID As UInteger, ByVal playerName As String, ByVal playerLevel As UInteger, ByVal playerStorage As UInteger, ByVal playerRank As String)
        Me.playerID = playerID
        Me.playerName = playerName
        Me.playerLevel = playerLevel
        Me.playerStorage = playerStorage
        Me.playerRank = playerRank
    End Sub

    Public Function GetName() As String
        Return playerName
    End Function

    Public Function GetID() As UInteger
        Return playerID
    End Function

    Public Function GetLevel() As UInteger
        Return playerLevel
    End Function

    Public Function GetStorageID() As UInteger
        Return playerStorage
    End Function

    Public Function GetRank() As String
        Return playerRank
    End Function

    '' add ability to update values on SQL database and re-sync
    '' create new class, for player's inventory
    '' create new class, for "enemies"

End Class

