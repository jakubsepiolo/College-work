Module Players
    Dim conn As New System.Data.Odbc.OdbcConnection("DRIVER={MySQL ODBC 5.3 ANSI Driver};SERVER=localhost;PORT=3306;DATABASE=itemstuff;USER=root;PASSWORD=password;OPTION=3;")
    Public PlayerList As List(Of Player) = New List(Of Player)()

    Sub GetPlayers()
        Dim Count As UInteger = 0
        Dim sql As New Odbc.OdbcCommand("select * from players", conn)
        Dim read As Odbc.OdbcDataReader
        read = sql.ExecuteReader
        If read.HasRows Then
            Do While read.Read
                PlayerList.Add(New Player(read("playerid"), read("playername"), read("playerlevel"), read("storageid"), read("playerrank")))
            Loop

        End If
    End Sub

    Sub Main()

        conn.Open()
        Dim sql As New Odbc.OdbcCommand("CREATE TABLE IF NOT EXISTS `players` (
  `playerid` int(11) NOT NULL auto_increment,   
  `playername` varchar(255) NOT NULL default '',           
  `playerlevel`  int(11) NOT NULL default '0',     
  `storageid` int(11)  NOT NULL default '0', 
  `playerrank` varchar(255) NOT NULL default '',
   PRIMARY KEY  (`playerid`)

);", conn)
        sql.ExecuteNonQuery()
        GetPlayers()
        conn.Close()
    End Sub

End Module
