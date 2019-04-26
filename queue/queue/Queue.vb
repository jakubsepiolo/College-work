

Public Class Queue(Of T)
    Implements IQueue(Of T)
    Private Rear As Integer
    Private QueueArray() As QueueItems
    Private MaxSize As Integer
    Private CurrentSize As Integer
    Private Structure QueueItems
        Friend Data As T
        Friend Priority As Integer
    End Structure
    Public Sub New(size As Integer)
        MaxSize = size
        CurrentSize = 0
        Rear = 0
        ReDim QueueArray(size)
    End Sub

    Private Sub Shuffle(start As Integer) Implements IQueue(Of T).Shuffle
        For i = start To CurrentSize
            QueueArray(i) = QueueArray(i + 1)
        Next
    End Sub

    Private Function FindElement() As Integer
        Dim HighestPriority = 0
        Dim ElementLocation = 0
        For i = 0 To CurrentSize
            If QueueArray(i).Priority > HighestPriority Then
                HighestPriority = QueueArray(i).Priority
                ElementLocation = i
            End If
        Next
        Return ElementLocation
    End Function


    Public Sub Enqueue(NewItem As T) Implements IQueue(Of T).Enqueue
        Randomize()
        Dim ThisEntry As New QueueItems
        ThisEntry.Data = NewItem
        ThisEntry.Priority = Int(Rnd() * 5)
        If isFull() Then
            Console.WriteLine("Queue is full")
        Else
            QueueArray(Rear) = ThisEntry
            Rear += 1
            CurrentSize += 1
        End If
    End Sub

    Public Function DeQueue() As T Implements IQueue(Of T).DeQueue
        If isEmpty() Then
            Console.WriteLine("Queue is empty")
        Else
            Dim item As T = QueueArray(FindElement()).Data
            Rear -= 1
            CurrentSize -= 1
            Shuffle(FindElement())
            Return item
        End If
    End Function

    Public Function Peek() As T Implements IQueue(Of T).Peek
        Return QueueArray(FindElement()).Data
    End Function

    Public Function isEmpty() As Boolean Implements IQueue(Of T).isEmpty
        Return Rear = 0
    End Function

    Public Function isFull() As Boolean Implements IQueue(Of T).isFull
        Return Rear = MaxSize
    End Function

End Class
