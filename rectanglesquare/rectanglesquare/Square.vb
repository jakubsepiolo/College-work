Public Class Square
    Inherits Rectangle
    Private SideLength As UInteger
    Public Sub New(ByVal SideLength As UInteger)
        MyBase.New(SideLength, SideLength)
        Me.SideLength = SideLength
    End Sub

End Class
