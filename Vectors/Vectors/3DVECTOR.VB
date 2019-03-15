Public Class _3DVECTOR
    Private X As Double
    Private Y As Double
    Private Z As Double
    Public Sub New()

    End Sub
    Public Sub New(ByVal X As Double, ByVal Y As Double, ByVal Z As Double)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
    End Sub
    Public Shared Operator +(ByVal Vector1 As _3DVECTOR, ByVal Vector2 As _3DVECTOR) As _3DVECTOR
        Return New _3DVECTOR(Vector1.X + Vector2.X, Vector1.Y + Vector2.Y, Vector1.Z + Vector2.Z)
    End Operator
    Public Shared Operator *(ByVal Vector1 As _3DVECTOR, ByVal Vector2 As _3DVECTOR) As Integer
        Return (Vector1.X * Vector2.X + Vector1.Y + Vector2.Y + Vector1.Z * Vector2.Z)
    End Operator
    Public Shared Operator -(ByVal Vector1 As _3DVECTOR, ByVal Vector2 As _3DVECTOR) As _3DVECTOR
        Return New _3DVECTOR(Vector1.X - Vector2.X, Vector1.Y - Vector2.Y, Vector1.Z - Vector2.Z)
    End Operator
    Public Shared Operator <(ByVal Vector1 As _3DVECTOR, ByVal Vector2 As _3DVECTOR) As Boolean
        If Vector1.GetMagnitude() < Vector2.GetMagnitude Then
            Return True
        Else
            Return False
        End If
    End Operator
    Public Shared Operator >(ByVal Vector1 As _3DVECTOR, ByVal Vector2 As _3DVECTOR) As Boolean
        If Vector1.GetMagnitude() > Vector2.GetMagnitude Then
            Return True
        Else
            Return False
        End If
    End Operator
    Public Shared Operator =(ByVal Vector1 As _3DVECTOR, ByVal Vector2 As _3DVECTOR) As Boolean
        If Vector1.X = Vector2.X Then
            If Vector1.Y = Vector2.Y Then
                If Vector1.Z = Vector2.Z Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Operator
    Public Shared Operator <>(ByVal Vector1 As _3DVECTOR, ByVal Vector2 As _3DVECTOR) As Boolean
        If Vector1.X = Vector2.X Then
            If Vector1.Y = Vector2.Y Then
                If Vector1.Z = Vector2.Z Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Operator
    Public Function GetMagnitude() As Double
        Return Math.Round(Math.Sqrt(X ^ 2 + Y ^ 2 + X ^ 2), 2)
    End Function
    Public Function GetX() As String
        Return X
    End Function
    Public Function GetY() As String
        Return Y
    End Function
    Public Function GetZ() As String
        Return X
    End Function
    Public Function GetVector() As String
        Return X & Y & Z
    End Function
End Class
