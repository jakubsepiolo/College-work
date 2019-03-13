Module Module1

    Sub Main()
        Dim MyCircle As New Circle()
        Dim UserRadius As Decimal
        Console.Write("Set Area: ")
        UserRadius = Console.ReadLine()
        MyCircle.SetRadius(UserRadius)
        Console.WriteLine($"Radius: {MyCircle.GetRadius()}")
        Console.WriteLine($"Area: {MyCircle.GetArea()}")
        Console.WriteLine($"Circumference: {MyCircle.GetCircumference()}")
        Console.ReadKey()
    End Sub

End Module
