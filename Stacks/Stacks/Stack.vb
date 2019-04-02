Public Class Stack
    Private Top As Integer
    Private Numbers() As Integer


    Sub New(ByVal Length As Integer)
        ReDim Numbers(Length)
        Top = -1
    End Sub
    Public Function Peek() As Integer
        Return Numbers(Top)
    End Function
    Public Function Pop() As Integer
        Dim PopNum As Integer = Numbers(Top)
        Top -= 1
        Return PopNum
    End Function
    Public Sub Push(ByVal num As Integer)
        Top += 1
        If IsFull() Then
            Exit Sub
        End If
        Numbers(Top) = num
    End Sub
    Public Function IsEmpty() As Boolean
        Return Top = -1
    End Function
    Public Function IsFull() As Boolean
        Return Numbers.Length = Top
    End Function
End Class
