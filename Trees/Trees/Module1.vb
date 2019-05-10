Module Module1

    Sub Main()
        Randomize()
        Dim MyTree As New Tree(5)
        For i = 0 To 500000
            MyTree.AddToTree(Int(Rnd() * 50000))
        Next
        MyTree.Inorder(MyTree.root)
        Console.ReadKey()
    End Sub

End Module
