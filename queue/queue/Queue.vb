

Public Class Queue(Of T)
    Implements IQueue(Of T)
    Private Rear As Integer
    Private QueueArray() As T
    Private MaxSize As Integer
    Private CurrentSize As Integer
    Public Sub New()
        MaxSize = 10
        CurrentSize = 0
        Rear = 0
        ReDim QueueArray(10)
    End Sub
    Private Sub Shuffle() Implements IQueue(Of T).Shuffle
        For i = 1 To CurrentSize
            QueueArray(i - 1) = QueueArray(i)
        Next
    End Sub

    Public Sub Enqueue(NewItem As T) Implements IQueue(Of T).Enqueue
        If isFull() Then
            Console.WriteLine("Queue is full")
        Else
            QueueArray(Rear) = NewItem
            Rear += 1
            CurrentSize += 1
        End If
    End Sub

    Public Function DeQueue() As T Implements IQueue(Of T).DeQueue
        If isEmpty() Then
            Console.WriteLine("Queue is empty")
        Else
            Dim item As T = QueueArray(0)
            Rear -= 1
            CurrentSize -= 1
            Shuffle()
            Return item
        End If
    End Function

    Public Function Peek() As T Implements IQueue(Of T).Peek
        Return QueueArray(0)
    End Function

    Public Function isEmpty() As Boolean Implements IQueue(Of T).isEmpty
        Return Rear = 0
    End Function

    Public Function isFull() As Boolean Implements IQueue(Of T).isFull
        Return Rear = MaxSize
    End Function

End Class
