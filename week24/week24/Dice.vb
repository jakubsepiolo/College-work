Public Class Dice
    Private Random As UInteger
    Private sidesCount As UInteger

    Public Sub New()
        sidesCount = 6
    End Sub
    Public Sub New(ByVal sidesCount As Integer)
        Me.sidesCount = sidesCount
    End Sub
    Public Function GetSidesCount() As UInteger
        Return sidesCount
    End Function
    Public Function Roll() As UInteger
        Randomize()
        Random = Int(1 + Rnd() * GetSidesCount())
        Return Random
    End Function
End Class
