Module Module1




    Sub Main()
        Items.Main()

        For i = 0 To ItemList.Count() - 1
            Console.WriteLine($"ID: {ItemList(i).GetID()}
Name: {ItemList(i).GetName()},
Description: {ItemList(i).GetDescription()}
Cost: {ItemList(i).GetCost()}g
Max: {ItemList(i).GetMax()}
Type: {ItemList(i).GetItemType()}")
        Next
        Console.ReadKey()
    End Sub

End Module
