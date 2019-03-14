a
Module Module1
    Dim conn As New System.Data.Odbc.OdbcConnection("DRIVER={MySQL ODBC 5.3 ANSI Driver};SERVER=localhost;PORT=3306;DATABASE=hogwarts;USER=root;PASSWORD=password;OPTION=3;")
    'Structures used to temporaily hold the data taken from the database
    Dim Mode As Integer = 0

    Sub ToggleErrorColor()
        If Mode = 0 Then
            Console.ForegroundColor = ConsoleColor.Red
            Mode = 1
        ElseIf Mode = 1 Then
            Console.ForegroundColor = ConsoleColor.Gray
            Mode = 0
        End If
    End Sub
    Structure pupil
        Dim id As Integer
        Dim forename As String
        Dim surname As String
        Dim house As String
        Dim age As Integer
    End Structure
    Structure Classes
        Dim name As String
        Dim teacher As String
        Dim id As Integer
    End Structure

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
        Dim choice As Char
        Do
            Do
                mainmenu()
                choice = Console.ReadLine
            Loop Until choice = "1" Or choice = "2" Or choice = "3" Or choice = "9"
            Select Case choice
                Case "1"
                    pupilsection()
                Case "2"
                    classsection()
                Case "3"
                    enrolsection()
            End Select
        Loop Until choice = "9"
        Console.WriteLine("Goodbye!")
        Console.ReadKey()
    End Sub
    'The findpupil function has been used in viewpupil and deletepupil
    'HINT: It will be useful in enrolpupil and removeenrolment
    Function findpupil(ByRef pupils() As pupil, ByVal surname As String, ByRef count As Integer) As Boolean
        'This function will find all pupils with surname given.  
        'If more then than one pupil with same surname then allows user to choose one and adjusts variable count accordingly
        'Function returns true if pupil found, false if no pupil found with given surname
        'Pupil(s) found will be saved in the pupils structure which has been passed by reference
        Dim choice As String
        Dim rspupils As Odbc.OdbcDataReader
        Dim sql As New Odbc.OdbcCommand("select * from pupils where surname = '" & surname & "' ", conn)
        rspupils = sql.ExecuteReader
        If rspupils.HasRows Then
            If rspupils.RecordsAffected > 1 Then
                Do While rspupils.Read
                    Console.WriteLine("Pupil " & count)
                    pupils(count).id = rspupils("id")
                    pupils(count).forename = rspupils("forename")
                    pupils(count).surname = rspupils("surname")
                    pupils(count).house = rspupils("house")
                    pupils(count).age = rspupils("age")
                    Console.WriteLine("Name: " & pupils(count).forename & " " & pupils(count).surname)
                    Console.WriteLine()
                    count += 1
                Loop
                Console.WriteLine("Select pupil")
                choice = Console.ReadLine
                count = CInt(choice)
            Else
                pupils(count).id = rspupils("id")
                pupils(count).forename = rspupils("forename")
                pupils(count).surname = rspupils("surname")
                pupils(count).house = rspupils("house")
                pupils(count).age = rspupils("age")
            End If
            Return True
        Else
            Console.WriteLine("No pupil with that name found")
            Return False
        End If
    End Function

    Function findclass(ByRef classes() As Classes, ByVal name As String, ByRef count As Integer) As Boolean
        Dim choice As String
        Dim rsclass As Odbc.OdbcDataReader
        Dim sql As New Odbc.OdbcCommand("select * from classes where name = '" & name & "' ", conn)
        rsclass = sql.ExecuteReader
        If rsclass.HasRows Then
            If rsclass.RecordsAffected > 1 Then
                Do While rsclass.Read
                    Console.WriteLine("Pupil " & count)
                    classes(count).id = rsclass("id")
                    classes(count).name = rsclass("name")
                    classes(count).teacher = rsclass("teacher")
                    Console.WriteLine("Name: " & classes(count).name & " " & classes(count).teacher)
                    Console.WriteLine()
                    count += 1
                Loop
                Console.WriteLine("Select pupil")
                choice = Console.ReadLine
                count = CInt(choice)
            Else
                classes(count).id = rsclass("id")
                classes(count).name = rsclass("name")
                classes(count).teacher = rsclass("teacher")
            End If
            Return True
        Else
            Console.WriteLine("No class with that name found")
            Return False
        End If
    End Function
    'This findclassesForPupil function is used in viewpupil
    Function findclassesForPupil(ByVal pupilId As Integer, ByRef tempclass() As Classes, ByRef count As Integer) As Boolean
        'This function finds all the classes for a particular pupil
        'Returns true if classes found, otherwise returns false
        'If class(es) found they will be put into tempclass struture that is passed by reference
        Dim sql As New Odbc.OdbcCommand("SELECT NAME, teacher FROM classes, enrolment WHERE enrolment.pupilsId = '" & pupilId & "' AND classes.id = enrolment.classesId", conn)
        Dim rsclass As Odbc.OdbcDataReader
        rsclass = sql.ExecuteReader
        If rsclass.HasRows Then
            Do While rsclass.Read
                count += 1
                tempclass(count).name = rsclass("name")
                tempclass(count).teacher = rsclass("teacher")
            Loop
            Return True
        Else
            Return False
        End If
    End Function

    'The following four subs have been coded. Use them to help you with your code
    Sub Viewpupil()
        Dim surname As String
        Dim count As Integer = 0
        Dim pupils(10) As pupil
        Dim tempclass(10) As Classes
        Dim numofclasses As Integer = -1
        Dim found As Boolean = False
        Console.WriteLine("View Pupil Information")
        Console.WriteLine()
        Console.WriteLine("Enter pupil surname:")
        surname = Console.ReadLine
        found = findpupil(pupils, surname, count)
        If found = True Then
            Console.WriteLine()
            Console.WriteLine("Name:  " & pupils(count).forename & " " & pupils(count).surname)
            Console.WriteLine("House: " & pupils(count).house)
            Console.WriteLine("Age:   " & pupils(count).age)
            Console.WriteLine()
            If findclassesForPupil(pupils(count).id, tempclass, numofclasses) Then
                For i = 0 To numofclasses
                    Console.WriteLine("Class name:   " & tempclass(i).name)
                    Console.WriteLine("Teacher name: " & tempclass(i).teacher)
                    Console.WriteLine()
                Next
            Else
                Console.WriteLine("This pupil does not have any classes")
            End If
        End If
        Console.ReadKey()
    End Sub
    Sub addpupil()
        Dim surname, forename, house As String
        Dim age As Integer
        Dim Success As Boolean
        Console.WriteLine("Add New Pupil")
        Console.WriteLine()
        Console.WriteLine("Enter pupil surname:")
        surname = Console.ReadLine
        Console.WriteLine("Enter pupil forename:")
        forename = Console.ReadLine
        Do
            Success = True
            Try
                Console.WriteLine("Enter pupil age:")
                age = Console.ReadLine
                If age < 0 Or age > 100 Then
                    Throw New ArgumentOutOfRangeException(message:="Age is out of bounds", innerException:=Nothing)
                End If
            Catch ex As OverflowException
                ToggleErrorColor()
                Console.WriteLine("Pupil age is not a valid number!")
                ToggleErrorColor()
                Success = False
            Catch ex As ArgumentOutOfRangeException
                ToggleErrorColor()
                Console.WriteLine("Age is out of bounds!")
                ToggleErrorColor()
                Success = False
            Catch ex As InvalidCastException
                ToggleErrorColor()
                Console.WriteLine("Input should be an integer!")
                ToggleErrorColor()
                Success = False
            End Try
        Loop Until Success = True
        Do
            Success = True
            Try
                Console.WriteLine("Enter pupil house:")
                house = Console.ReadLine
                If house.ToLower() <> "gryffindor" And house.ToLower() <> "hufflepuff" And house.ToLower() <> "ravenclaw" And house.ToLower() <> "slytherin" Then
                    Throw New NullReferenceException(message:="House does not exist", innerException:=Nothing)
                End If
            Catch ex As NullReferenceException
                ToggleErrorColor()
                Console.WriteLine("House does not exist!")
                ToggleErrorColor()
                Success = False
            End Try
        Loop Until Success = True
        Dim sql As New Odbc.OdbcCommand("INSERT INTO pupils(forename,surname,house,age) VALUES ('" & forename & "', '" & surname & "', '" & house & "', '" & age & "')", conn)
        sql.ExecuteNonQuery()
        Console.WriteLine()
        Console.WriteLine("New pupil " & forename & " " & surname & " added.")
        Console.WriteLine("Press enter to return to menu")
        Console.ReadKey()
    End Sub
    Sub deletepupil()
        Dim surname, choice As String
        Dim pupils(10) As pupil
        Dim found As Boolean
        Dim id, count As Integer
        Dim rsid As Odbc.OdbcDataReader
        count = 0
        Console.WriteLine("Delete Pupil")
        Console.WriteLine()
        Console.WriteLine("The pupil and any enrolments associated with this pupil will be deleted.")
        Console.WriteLine()
        Console.WriteLine("Enter pupil's surname:")
        surname = Console.ReadLine
        Console.WriteLine()
        found = findpupil(pupils, surname, count)
        If found Then
            Console.WriteLine("Are you sure you want to delete " & pupils(count).forename & " " & pupils(count).surname & "? (Y/N)")
            choice = Console.ReadLine.ToUpper
            If choice = "Y" Then
                Dim sqlid As New Odbc.OdbcCommand("SELECT id FROM pupils WHERE surname = '" & surname & "'", conn)
                rsid = sqlid.ExecuteReader
                If rsid.Read Then
                    id = rsid("id")
                End If
                Dim sqldeleteenrolment As New Odbc.OdbcCommand("DELETE FROM enrolment WHERE pupilsId = '" & id & "'", conn)
                sqldeleteenrolment.ExecuteNonQuery()
                Dim sqldeleteclass As New Odbc.OdbcCommand("DELETE FROM pupils WHERE id = '" & id & "'", conn)
                sqldeleteclass.ExecuteNonQuery()
                Console.WriteLine()
                Console.WriteLine("Pupil " & pupils(count).forename & " " & pupils(count).surname & " has been deleted.")
            End If
        End If
        Console.WriteLine("Press enter to return to menu")
        Console.ReadKey()
    End Sub
    Sub pupilsall()
        Dim rspupils As Odbc.OdbcDataReader
        Console.WriteLine("List of all pupils")
        Console.WriteLine()
        Dim sql As New Odbc.OdbcCommand("select * from pupils order by house", conn)
        rspupils = sql.ExecuteReader
        Console.WriteLine()
        Do While rspupils.Read
            Console.WriteLine(rspupils("house") & " " & rspupils("forename") & " " & rspupils("surname") & " " & rspupils("age"))
        Loop
        Console.WriteLine()
        Console.WriteLine("Press enter to return to menu")
        Console.ReadKey()
    End Sub

    Sub viewclass()
        'In this sub the user enters in a class name.  
        'If the class exists then the teacher of the class is displayed  (SQL required for this)
        'also a list of the pupils in the class is displayed (SQL required for this)
        Dim name As String
        Dim class_(10) As Classes
        Dim Success As Boolean
        Console.WriteLine("View Class Information")
        Console.WriteLine()
        Do
            Success = True
            Try
                Console.WriteLine("Enter class name:")
                name = Console.ReadLine
                If findclass(class_, name, 0) = False Then
                    Throw New NullReferenceException(message:="Class does not exist", innerException:=Nothing)
                End If
            Catch ex As NullReferenceException
                ToggleErrorColor()
                Console.WriteLine("Class does not exist!")
                ToggleErrorColor()
                Success = False
            End Try
        Loop Until Success = True
        Console.WriteLine()
        Dim classview As Odbc.OdbcDataReader
        Console.WriteLine("Class information:")
        Console.WriteLine()
        Dim sql As New Odbc.OdbcCommand("select * from classes where name ='" & name & "'", conn)
        classview = sql.ExecuteReader
        Console.WriteLine()
        Do While classview.Read
            Console.WriteLine("Class: " & classview("name") & " Teacher: " & classview("teacher"))
        Loop
        Console.WriteLine()
        Console.ReadKey()
    End Sub
    Sub addclass()
        'In this sub the user enters in a new class  
        'The user enters a class name and a teacher which is put into the database (SQL required for this)
        Dim name, teacher As String
        Console.WriteLine("Add New Class")
        Console.WriteLine()
        Console.WriteLine("Enter class name:")
        name = Console.ReadLine
        Console.WriteLine("Enter class teacher:")
        teacher = Console.ReadLine
        Dim sql As New Odbc.OdbcCommand("INSERT INTO classes(name, teacher) VALUES ('" & name & "', '" & teacher & "')", conn)
        sql.ExecuteNonQuery()
        Console.WriteLine()
        Console.WriteLine("New class " & name & " teacher: " & teacher & " added.")
        Console.WriteLine("Press enter to return to menu")
        Console.ReadKey()
    End Sub
    Sub deleteclass()
        'In this sub the user deltes a class  
        'The user enters a class name 
        'Firstly the id of the class will need to be retieved(SQL required for this)
        'Then any enrolments with this class need to be deleted (SQL required for this)
        'Finally the class needs to be deleted from the classes table (SQL required for this)
        Dim name, choice As String
        Dim class_(10) As Classes
        Dim found As Boolean
        Dim id, count As Integer
        Dim rsid As Odbc.OdbcDataReader
        count = 0
        Console.WriteLine("Delete class")
        Console.WriteLine()
        Console.WriteLine("The class and any enrolments associated with this class will be deleted.")
        Console.WriteLine()
        Console.WriteLine("Enter class name:")
        name = Console.ReadLine
        Console.WriteLine()
        found = findclass(class_, name, count)
        If found Then
            Console.WriteLine("Are you sure you want to delete " & class_(count).name & " " & class_(count).teacher & "? (Y/N)")
            choice = Console.ReadLine.ToUpper
            If choice = "Y" Then
                Dim sqlid As New Odbc.OdbcCommand("SELECT id FROM classes WHERE name = '" & name & "'", conn)
                rsid = sqlid.ExecuteReader
                If rsid.Read Then
                    id = rsid("id")
                End If
                Dim sqldeleteenrolment As New Odbc.OdbcCommand("DELETE FROM enrolment WHERE classesId = '" & id & "'", conn)
                sqldeleteenrolment.ExecuteNonQuery()
                Dim sqldeleteclass As New Odbc.OdbcCommand("DELETE FROM classes WHERE id = '" & id & "'", conn)
                sqldeleteclass.ExecuteNonQuery()
                Console.WriteLine()
                Console.WriteLine("Class: " & class_(count).name & " Teacher: " & class_(count).teacher & " has been deleted.")
            End If
        End If
        Console.WriteLine("Press enter to return to menu")
        Console.ReadKey()
    End Sub
    Sub viewallclasses()
        'This sub displays all the classes and the teachers (SQL required for this)
        Dim allclasses As Odbc.OdbcDataReader
        Console.WriteLine("List of all classes")
        Console.WriteLine()
        Dim sql As New Odbc.OdbcCommand("select * from classes order by name", conn)
        allclasses = sql.ExecuteReader
        Console.WriteLine()
        Do While allclasses.Read
            Console.WriteLine("Class: " & allclasses("name") & " Teacher: " & allclasses("teacher"))
        Loop
        Console.WriteLine()
        Console.WriteLine("Press enter to return to menu")
        Console.ReadKey()
    End Sub
    Sub enrolpupil()
        'This sub enrols a particular pupil onto a particular class
        'User enters a pupil surname. Use the findpupil function here to help choose the pupil as maybe more than one with same surname
        'Then user enters class name. Need to get class details from database (SQL required for this)
        'Then insert a new enrolment into the enrolment table using the pupil id and class id found before (SQL required for this)
        Dim surname, name As String
        Dim pupilsId, classesId As Integer
        Dim count As Integer = 0
        Dim Pupils(10) As pupil
        Dim PupilExist, ClassExist As Boolean
        Dim class_(10) As Classes
        Console.WriteLine("Add Enrolment for pupil")
        Console.WriteLine()
        Console.WriteLine("Enter pupil surname:")
        surname = Console.ReadLine
        PupilExist = findpupil(Pupils, surname, count)
        If PupilExist Then
            Console.WriteLine("Enter class to enroll in: ")
            name = Console.ReadLine()
            pupilsId = Pupils(count).id
            Dim forename As String = Pupils(count).forename & " "
            count = 0
            ClassExist = findclass(class_, name, count)
            If ClassExist Then
                classesId = class_(count).id
                Dim sql As New Odbc.OdbcCommand("INSERT INTO enrolment(pupilsId,classesId) VALUES ('" & pupilsId & "', '" & classesId & "')", conn)
                sql.ExecuteNonQuery()
                Console.WriteLine()
                Console.WriteLine("New enrolment for " & forename & surname & " for " & name & " entered.")
                Console.WriteLine("Press enter to return to menu")
            End If
        End If
        Console.ReadKey()
    End Sub
    Sub removeenrolment()
        'This sub removes a pupil from a class
        'User enters a class. Need to get class details from database (SQL required for this)
        'User enters a pupil surname. Use the findpupil function here to help choose the pupil as maybe more than one with same surname
        'Then delete the enrolment from the enrolment table using the pupil id and class id found before (SQL required for this)
        Dim surname, name As String
        Dim pupilsId, classesId As Integer
        Dim count As Integer = 0
        Dim Pupils(11) As pupil
        Dim PupilExist, ClassExist, IsStudentInClass As Boolean
        Dim class_(10) As Classes
        Console.WriteLine("Remove Enrolment for pupil")
        Console.WriteLine()
        Console.WriteLine("Enter pupil surname:")
        surname = Console.ReadLine
        PupilExist = findpupil(Pupils, surname, count)
        If PupilExist Then
            Console.WriteLine("Enter class to remove from enrolment: ")
            name = Console.ReadLine()
            pupilsId = Pupils(count).id
            Dim forename As String = Pupils(count).forename & " "
            ClassExist = findclass(class_, name, count)
            count = 0
            If ClassExist Then
                classesId = class_(count).id
                count = 0
                IsStudentInClass = findclassesForPupil(pupilsId, class_, count)
                If IsStudentInClass Then
                    Dim sql As New Odbc.OdbcCommand("DELETE FROM enrolment WHERE pupilsId = '" & pupilsId & "'" & "AND classesID = '" & classesId & "'", conn)
                    sql.ExecuteNonQuery()
                    Console.WriteLine()
                    Console.WriteLine("Enrolment for " & forename & surname & " in " & name & " removed.")
                    Console.WriteLine("Press enter to return to menu")
                End If
            End If
        End If
        Console.ReadKey()
    End Sub
    'Menus all coded for you
    Sub mainmenu()
        Console.Clear()
        Console.WriteLine("Welcome to HogStudio")
        Console.WriteLine()
        Console.WriteLine("1. Pupil information")
        Console.WriteLine("2. Class information")
        Console.WriteLine("3. Enroling and removing pupils from classes")
        Console.WriteLine()
        Console.WriteLine("9. Exit")
        Console.WriteLine()
    End Sub
    Sub pupilmenu()
        Console.Clear()
        Console.WriteLine("HogStudio - Pupil Section")
        Console.WriteLine()
        Console.WriteLine("1. View a pupil's information")
        Console.WriteLine("2. Add a new pupil")
        Console.WriteLine("3. Delete a pupil")
        Console.WriteLine("4. View all pupils")
        Console.WriteLine()
        Console.WriteLine("9. Return to Main Menu")
        Console.WriteLine()
    End Sub
    Sub classmenu()
        Console.Clear()
        Console.WriteLine("HogStudio - Class Section")
        Console.WriteLine()
        Console.WriteLine("1. View class information")
        Console.WriteLine("2. Add a new class")
        Console.WriteLine("3. Delete a class")
        Console.WriteLine("4. View a list of all classes")
        Console.WriteLine()
        Console.WriteLine("9. Return to Main Menu")
        Console.WriteLine()
    End Sub
    Sub enrolmenu()
        Console.Clear()
        Console.WriteLine("HogStudio - Enrolment Section")
        Console.WriteLine()
        Console.WriteLine("1. Enrol a pupil onto a class")
        Console.WriteLine("2. Remove a pupil from a class")
        Console.WriteLine()
        Console.WriteLine("9. Return to Main Menu")
        Console.WriteLine()
    End Sub
    Sub pupilsection()
        Dim choice As Char
        Do
            Do
                pupilmenu()
                choice = Console.ReadLine
            Loop Until choice = "1" Or choice = "2" Or choice = "3" Or choice = "4" Or choice = "9"
            Select Case choice
                Case "1"
                    Viewpupil()
                Case "2"
                    addpupil()
                Case "3"
                    deletepupil()
                Case "4"
                    pupilsall()
            End Select
        Loop Until choice = "9"
    End Sub
    Sub classsection()
        Dim choice As Char
        Do
            Do
                classmenu()
                choice = Console.ReadLine
            Loop Until choice = "1" Or choice = "2" Or choice = "3" Or choice = "4" Or choice = "9"
            Select Case choice
                Case "1"
                    viewclass()
                Case "2"
                    addclass()
                Case "3"
                    deleteclass()
                Case "4"
                    viewallclasses()
            End Select
        Loop Until choice = "9"
    End Sub
    Sub enrolsection()
        Dim choice As Char
        Do
            Do
                enrolmenu()
                choice = Console.ReadLine
            Loop Until choice = "1" Or choice = "2" Or choice = "9"
            Select Case choice
                Case "1"
                    enrolpupil()
                Case "2"
                    removeenrolment()
            End Select
        Loop Until choice = "9"
    End Sub
End Module

