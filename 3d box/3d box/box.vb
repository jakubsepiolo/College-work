Public Class box
    Private Height As Double
    Private Width As Double
    Private Length As Double

    Public Sub New(ByVal Height As Double, ByVal Width As Double, ByVal Length As Double)
        Me.Height = Height
        Me.Width = Width
        Me.Length = Length
    End Sub

    Public Function GetHeight() As Double
        Return Height
    End Function
    Public Function GetWidth() As Double
        Return Width
    End Function
    Public Function GetLength() As Double
        Return Length
    End Function
    Public Function CalculateVolume() As Double
        Return Length * Width * Height
    End Function
    Public Function CalculateSurfaceArea() As Double
        Return 2 * Length * Height + 2 * Width * Height + 2 * Length * Width
    End Function


End Class
