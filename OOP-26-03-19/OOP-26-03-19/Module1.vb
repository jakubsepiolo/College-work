﻿Module Module1
    Sub Main()

        Dim shapes As New List(Of Drawable)


        shapes.Add(New Square(3))
        shapes.Add(New Square(9))
        shapes.Add(New VerticalLine(3))
        shapes.Add(New VerticalLine(5))
        shapes.Add(New Pyramid(5))
        shapes.Add(New Pyramid(2))
        shapes.Add(New HorizontalLine(2))
        shapes.Add(New HorizontalLine(7))
        shapes.Add(New Circle(24))
        For Each s In shapes
            s.Draw()
            Console.WriteLine()
        Next

        Console.ReadKey()
    End Sub

End Module
