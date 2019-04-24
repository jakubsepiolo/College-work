
Public Class CircularQueue(Of T)
    Implements ICQueue(Of T)
    Private front As Integer
    Private rear As Integer
    Private size As Integer
    Private CurrentSize As Integer
    Private QueueArray() As T

    Public Sub New(ByVal Size As Integer)
        Me.size = Size
        rear = 0
        front = 0
        CurrentSize = 0
        ReDim QueueArray(Me.size)
    End Sub


    Public Sub Enqueue(NewItem As T) Implements ICQueue(Of T).Enqueue
        If isFull() Then
            Console.WriteLine("Queue is full")
        Else
            QueueArray(rear) = NewItem
            rear += 1
            CurrentSize += 1
        End If
    End Sub

    Public Function DeQueue() As T Implements ICQueue(Of T).DeQueue
        If isEmpty() Then
            Console.WriteLine("Queue is empty")
        Else
            Dim item As T = QueueArray(front)
            QueueArray(front) = Nothing
            front += 1
            CurrentSize -= 1
            Return item
        End If
    End Function

    Public Function Peek() As T Implements ICQueue(Of T).Peek
        Return QueueArray(front)
    End Function

    Public Function isEmpty() As Boolean Implements ICQueue(Of T).isEmpty#
        Return CurrentSize = 0
    End Function

    Public Function isFull() As Boolean Implements ICQueue(Of T).isFull
        Return (CurrentSize + 1) = size
    End Function
End Class
