Public Interface IQueue(Of T)
    Sub Shuffle(start As Integer)
    Sub Enqueue(NewItem As T)
    Function DeQueue() As T
    Function Peek() As T
    Function isEmpty() As Boolean
    Function isFull() As Boolean
End Interface
