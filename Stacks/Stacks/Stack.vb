Imports Stacks

Public Class Stack
    Implements IStack
    Private Top As Double
    Private Numbers() As Double


    Sub New(ByVal Length As Double)
        ReDim Numbers(Length)
        Top = -1
    End Sub
    Public Function Peek() As Double Implements IStack.Peek
        Return Numbers(Top)
    End Function
    Public Function Pop() As Double Implements IStack.Pop
        Dim PopNum As Double = Numbers(Top)
        Top -= 1
        Return PopNum
    End Function
    Public Sub Push(ByVal num As Double) Implements IStack.Push
        Top += 1
        If IsFull() Then
            Exit Sub
        End If
        Numbers(Top) = num
    End Sub
    Public Function IsEmpty() As Boolean Implements IStack.IsEmpty
        Return Top = -1
    End Function
    Public Function IsFull() As Boolean Implements IStack.IsFull
        Return Numbers.Length = Top
    End Function
    Public Sub Clear() Implements IStack.Clear
        For i = 0 To Top - 1
            Numbers(i) = 0
        Next
        Top = -1
    End Sub
End Class
