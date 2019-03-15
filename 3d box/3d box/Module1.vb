Module Module1

    Sub Main()
        Dim MyBox As New box(10, 5, 30)
        Console.WriteLine(MyBox.GetHeight())
        Console.WriteLine(MyBox.GetWidth())
        Console.WriteLine(MyBox.GetLength())
        Console.WriteLine(MyBox.CalculateSurfaceArea())
        Console.WriteLine(MyBox.CalculateVolume())
        Console.ReadLine()
    End Sub

End Module
