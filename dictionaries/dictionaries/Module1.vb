Module Module1

    Sub Main()
        Dim myDictionary As New Dictionary(Of String, Integer)
        Dim UserInput As String
        UserInput = Console.ReadLine()
        Dim SplitInput() As String = UserInput.Split(" ")
        For Each k As String In SplitInput
            If myDictionary.ContainsKey(k) Then
                myDictionary(k) += 1
            Else
                myDictionary.Add(k, 1)
            End If
        Next
        For Each item In myDictionary.Keys
            Console.WriteLine($"{item} | {myDictionary(item)}")
        Next
        Console.ReadKey()
    End Sub

End Module
