Module Module1

    Sub Main()
        Dim MySquare As New Square(23)
        Dim SquareArea As UInteger = MySquare.CalculateArea()
        Console.WriteLine($"Square Area: {SquareArea}")
        Dim MyRectangle As New Rectangle(23, 5)
        Dim RectangleArea As UInteger = MyRectangle.CalculateArea()
        Console.WriteLine($"Rectangle Area: {RectangleArea}")
        Console.ReadLine()
    End Sub

End Module
