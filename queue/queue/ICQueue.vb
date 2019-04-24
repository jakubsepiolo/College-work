Public Interface ICQueue(Of T)
    Sub Enqueue(NewItem As T)
    Function DeQueue() As T
    Function Peek() As T
    Function isEmpty() As Boolean
    Function isFull() As Boolean
End Interface
