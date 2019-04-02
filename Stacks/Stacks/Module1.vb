Module Module1

    Sub Main()
        Dim MyStack As New Stack(10)
        Console.WriteLine(MyStack.IsEmpty)
        MyStack.Push(5)
        Console.WriteLine(MyStack.Peek)
        MyStack.Push(2)
        Console.WriteLine(MyStack.Pop)
        MyStack.Push(MyStack.Peek + 5)
        Console.WriteLine(MyStack.Peek)
        Console.WriteLine(MyStack.IsEmpty)
        MyStack.Push(MyStack.Peek + 5)
        MyStack.Push(MyStack.Peek + 5)
        MyStack.Push(MyStack.Peek + 5)
        MyStack.Push(MyStack.Peek + 5)
        MyStack.Push(MyStack.Peek + 5)
        MyStack.Push(MyStack.Peek + 5)
        MyStack.Push(MyStack.Peek + 5)
        MyStack.Push(MyStack.Peek + 5)
        MyStack.Push(MyStack.Peek + 5)
        MyStack.Push(MyStack.Peek + 5)
        Console.WriteLine(MyStack.IsFull)
        Console.ReadKey()
    End Sub

End Module
