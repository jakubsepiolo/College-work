Public Interface IStack
    Function Peek() As Double
    Function Pop() As Double
    Sub Clear()
    Sub Push(num As Double)
    Function IsFull() As Boolean
    Function IsEmpty() As Boolean
End Interface
