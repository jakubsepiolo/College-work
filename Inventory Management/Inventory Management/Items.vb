

Module Items
    Dim conn As New System.Data.Odbc.OdbcConnection("DRIVER={MySQL ODBC 5.3 ANSI Driver};SERVER=localhost;PORT=3306;DATABASE=itemstuff;USER=root;PASSWORD=password;OPTION=3;")
    Public ItemList As List(Of Item_base) = New List(Of Item_base)()

    Sub GetItems()
        Dim Count As UInteger = 0
        Dim sql As New Odbc.OdbcCommand("select * from items", conn)
        Dim read As Odbc.OdbcDataReader
        read = sql.ExecuteReader
        If read.HasRows Then
            Do While read.Read
                ItemList.Add(New Item_base(read("itemid"), read("itemname"), read("itemdesc"), read("itemcost"), read("itemmax"), read("itemtype")))
            Loop

        End If
    End Sub

    Sub Main()

        conn.Open()
        Dim sql As New Odbc.OdbcCommand("CREATE TABLE IF NOT EXISTS `items` (
  `itemid` int(11) NOT NULL auto_increment,   
  `itemname` varchar(255) NOT NULL default '',       
  `itemdesc` varchar(255)  NOT NULL default '',     
  `itemcost`  int(11) NOT NULL default '0',     
  `itemmax` int(11)  NOT NULL default '0',    
  `itemtype`  varchar(255) NOT NULL default '',
   PRIMARY KEY  (`itemid`)

);", conn)
        sql.ExecuteNonQuery()
        GetItems()
        conn.Close()
    End Sub

End Module
