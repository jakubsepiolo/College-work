Public Class Rectangle
    Private Width As UInteger
    Private Height As UInteger
    Public Sub New(ByVal Width As UInteger, ByVal Height As UInteger)
        Me.Width = Width
        Me.Height = Height
    End Sub
    Public Function CalculateArea() As UInteger
        Return Width * Height
    End Function

End Class
