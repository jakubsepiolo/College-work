Module Module1
    Dim conn As New System.Data.Odbc.OdbcConnection("DRIVER={MySQL ODBC 5.3 ANSI Driver};SERVER=localhost;PORT=3306;DATABASE=itemstuff;USER=root;PASSWORD=password;OPTION=3;")

    Structure LogInDetails
        Dim username As String
        Dim password As String
    End Structure
    Sub getUsernameInput(ByRef UsernameInput As String)
        Console.Write("Username: ")
        Dim key As ConsoleKeyInfo
        Do
            key = Console.ReadKey(True)
            If (key.Key <> ConsoleKey.Backspace And key.Key <> ConsoleKey.Enter) Then
                UsernameInput += key.KeyChar
                Console.Write(key.KeyChar)
            ElseIf key.Key = ConsoleKey.Backspace And Console.CursorLeft > 10 Then
                If key.Key = ConsoleKey.Backspace And UsernameInput.Length > 0 Then
                    UsernameInput = UsernameInput.Substring(0, UsernameInput.Length - 1)
                End If
                Console.Write(vbBack)
                Console.Write(" ")
                Console.Write(vbBack)
            End If
        Loop Until key.Key = ConsoleKey.Enter
    End Sub

    Sub Main()
        conn.Open() 'starts connection with database
        Dim getrows As Odbc.OdbcDataReader
        Dim sqlgetrows As New Odbc.OdbcCommand("SELECT COUNT(*) FROM users", conn)
        getrows = sqlgetrows.ExecuteReader
        getrows.Read()
        Dim Rows As Integer = getrows("COUNT(*)") - 1
        Dim LogInStuff(Rows) As LogInDetails
        Dim getpassword As Odbc.OdbcDataReader
        Dim count As Integer = 0
        Dim sql As New Odbc.OdbcCommand("SELECT username, password FROM users", conn)
        getpassword = sql.ExecuteReader
        If getpassword.HasRows Then
            Do While getpassword.Read()
                LogInStuff(count).username = getpassword("username")
                LogInStuff(count).password = getpassword("password")
                count += 1
            Loop
        End If
        While True
            Dim UsernameInput As String = ""
            getUsernameInput(UsernameInput)
            Console.WriteLine()
            Console.Write("Password: ")
            Dim key As ConsoleKeyInfo
            Dim PasswordInput As String = ""
            Do
                key = Console.ReadKey(True)
                If (key.Key <> ConsoleKey.Backspace And key.Key <> ConsoleKey.Enter) Then
                    PasswordInput += key.KeyChar
                    Console.Write("*")
                ElseIf key.Key = ConsoleKey.Backspace And Console.CursorLeft > 10 Then
                    If key.Key = ConsoleKey.Backspace And PasswordInput.Length > 0 Then
                        PasswordInput = PasswordInput.Substring(0, PasswordInput.Length - 1)
                    End If
                    Console.Write(vbBack)
                    Console.Write(" ")
                    Console.Write(vbBack)
                End If
            Loop Until key.Key = ConsoleKey.Enter
            For i = 0 To LogInStuff.Length - 1
                If LogInStuff(i).username = UsernameInput Then
                    If LogInStuff(i).password = PasswordInput Then
                        Exit While
                    End If
                End If
            Next
            Console.WriteLine()
            Console.WriteLine("Invalid username or password!")
        End While
        Console.Clear()
        Console.WriteLine("Success...")
        Threading.Thread.Sleep(3000)
        conn.Close()
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
