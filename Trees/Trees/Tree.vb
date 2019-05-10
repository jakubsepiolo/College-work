Public Class Tree
    Public root As Node
    Sub New(ByVal RootValue As Integer)
        root = GetNode(RootValue)
    End Sub
    Private Function GetNode(ByVal value As Integer) As Node
        Dim Node As New Node
        Node.NodeValue = value
        Return Node
    End Function
    Public Sub AddToTree(ByVal value As Integer)
        Dim ThisNode As Node = root
        Dim NextNode As Node = root
        While ThisNode.NodeValue <> value And Not NextNode Is Nothing
            ThisNode = NextNode
            If NextNode.NodeValue < value Then
                NextNode = NextNode.RightNode
            Else
                NextNode = NextNode.LeftNode
            End If
        End While
        If ThisNode.NodeValue = value Then
            'Console.WriteLine($"Duplicate value: {value}")
        ElseIf ThisNode.NodeValue < value Then
            ThisNode.RightNode = GetNode(value)
        Else
            ThisNode.LeftNode = GetNode(value)
        End If
    End Sub
    Public Sub PreOrder(ByVal node As Node)
        If Not node Is Nothing Then
            Console.WriteLine(node.NodeValue)
            PreOrder(node.LeftNode)
            PreOrder(node.RightNode)
        End If
    End Sub
    Public Sub Inorder(ByVal node As Node)
        If Not node Is Nothing Then
            Inorder(node.LeftNode)
            Console.WriteLine(node.NodeValue)
            Inorder(node.RightNode)
        End If

    End Sub
    Public Sub PostOrder(ByVal node As Node)
        If Not node Is Nothing Then
            PostOrder(node.LeftNode)
            PostOrder(node.RightNode)
            Console.WriteLine(node.NodeValue)
        End If
    End Sub


End Class
