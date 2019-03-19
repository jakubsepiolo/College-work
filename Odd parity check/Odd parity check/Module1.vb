Module Module1

    Function CheckByte(ByVal Pattern As String) As Boolean
        Dim OneCount As Integer = 0
        Dim ZeroCount As Integer = 0
        For Each x As Char In Pattern
            If x = "0" Then
                ZeroCount += 1
            ElseIf x = "1" Then
                OneCount += 1
            Else
                Continue For
            End If
        Next
        If OneCount Mod 2 <> 1 Then
            Console.WriteLine("Parity bit was incorrect")
            Return False
        ElseIf OneCount Mod 2 <> 0 Then
            Console.WriteLine("Parity bit was correct")
            Return True
        End If
        Return True
    End Function

    Function CorrectByte(ByVal Pattern As String) As String
        Dim index As Integer = 0
        Dim LastZero As Integer = 0
        Dim Construct1 As String
        Dim Construct2 As String
        For Each X As Char In Pattern
            index += 1
            If X = "0" Then
                LastZero = index
            End If
        Next
        Construct1 = Pattern.Substring(0, LastZero - 1) & "1"
        Construct2 = Pattern.Substring(LastZero, 8 - LastZero)
        Return Construct1 & Construct2
    End Function


    Sub Main()
        Dim Pattern As String
        Dim NewPattern As String
        Console.Write("Pattern: ")
        Pattern = Console.ReadLine()
        If CheckByte(Pattern) Then
            Console.WriteLine($"{Pattern} Validated.")
        Else
            NewPattern = CorrectByte(Pattern)
            Console.WriteLine($"{Pattern} corrected to {NewPattern}")
        End If
        Console.ReadLine()
    End Sub

End Module
