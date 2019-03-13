Public Class Circle
    Private Radius As Decimal

    Public Function GetRadius() As Decimal
        Return Radius
    End Function
    Public Function GetArea() As Decimal
        Return Math.Round(Math.PI * (Radius ^ 2), 2)
    End Function
    Public Function GetCircumference() As Decimal
        Return Math.Round(Math.PI * Radius * 2, 2)
    End Function
    Public Sub SetRadius(ByVal NewRadius As Decimal)
        Radius = NewRadius
    End Sub
End Class
