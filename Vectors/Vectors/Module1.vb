Module Module1

    Sub Main()
        Randomize()
        Dim MyVector1 As New _3DVECTOR(Int(1 + Rnd() * 15), Int(1 + Rnd() * 15), Int(1 + Rnd() * 15))
        Dim MyVector2 As New _3DVECTOR(Int(1 + Rnd() * 15), Int(1 + Rnd() * 15), Int(1 + Rnd() * 15))
        Dim MyVector3 As New _3DVECTOR()
        MyVector3 = MyVector1 + MyVector2
        Console.WriteLine($"Vector1 X: {MyVector1.GetX}")
        Console.WriteLine($"Vector1 Y: {MyVector1.GetY}")
        Console.WriteLine($"Vector1 Z: {MyVector1.GetZ}")
        Console.WriteLine($"Vector1 X: {MyVector2.GetX}")
        Console.WriteLine($"Vector2 Y: {MyVector2.GetY}")
        Console.WriteLine($"Vector2 Z: {MyVector2.GetZ}")
        Dim DotProduct As Integer = MyVector1 * MyVector2
        Console.WriteLine($"Vector 1 is not equal to vector 2: {MyVector1 <> MyVector2}")
        Console.WriteLine($"Dot product of vector 1 and 2: {DotProduct}")
        Console.WriteLine()
        Console.WriteLine($"Vector3 X: {MyVector3.GetX}")
        Console.WriteLine($"Vector3 Y: {MyVector3.GetY}")
        Console.WriteLine($"Vector3 Z: {MyVector3.GetZ}")
        Console.WriteLine($"Vector3 Magnitude: {MyVector3.GetMagnitude()}")
        Console.ReadKey()
    End Sub

End Module
