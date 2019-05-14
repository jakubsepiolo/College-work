Module Module1

    Sub Main()
        Dim myDictionary As New Dictionary(Of String, Integer)
        Dim UserInput As String
        UserInput = Console.ReadLine()
        Dim SplitInput() As String = UserInput.Split(" ")
        For Each k As String In SplitInput
            If k.Contains(",") Or k.Contains(".") Or k.Contains("!") Or k.Contains("?") Then
                k = k.Substring(0, k.Length - 1)
            End If
            If myDictionary.ContainsKey(k) Then
                myDictionary(k) += 1
            Else
                myDictionary.Add(k, 1)
            End If
        Next
        For Each item In myDictionary.Keys
            Console.WriteLine($"{LSet(item, 20)} | {myDictionary(item)}")
        Next
        Console.ReadKey()
    End Sub

End Module
