Module Module1

    Sub Main()
        Randomize()
        Dim MyBox As New box(Math.Round(5 + Rnd() * 100, 2), Math.Round(5 + Rnd() * 100, 2), Math.Round(5 + Rnd() * 100, 2))
        Console.WriteLine($"Height: {MyBox.GetHeight()}cm")
        Console.WriteLine($"Width: {MyBox.GetWidth()}cm")
        Console.WriteLine($"Length: {MyBox.GetLength()}cm")
        Console.WriteLine($"Surface Area: {Math.Round(MyBox.CalculateSurfaceArea(), 3)}cm^2")
        Console.WriteLine($"Volume: {Math.Round(MyBox.CalculateVolume(), 3)}cm^3")
        Console.ReadLine()
    End Sub

End Module
