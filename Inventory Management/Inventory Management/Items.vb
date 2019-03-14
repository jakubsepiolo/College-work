

Module Items
    Dim conn As New System.Data.Odbc.OdbcConnection("DRIVER={MySQL ODBC 5.3 ANSI Driver};SERVER=localhost;PORT=3306;DATABASE=itemstuff;USER=root;PASSWORD=password;OPTION=3;")
    Public ItemList As List(Of Item_base) = New List(Of Item_base)()

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

);")
        sql.ExecuteNonQuery()



        ItemList.Add(New Item_base(0, "Paper", "This is a piece of paper", 0.5, 500, "Normal"))
        ItemList.Add(New Item_base(1, "Sword", "This is sword", 100, 5, "Weapon"))
        'ItemList.Add(New Item_base(0, "Paper", "This is a piece of paper", 0.5, 500, "Normal"))
        'ItemList.Add(New Item_base(0, "Paper", "This is a piece of paper", 0.5, 500, "Normal"))
        'ItemList.Add(New Item_base(0, "Paper", "This is a piece of paper", 0.5, 500, "Normal"))
        'ItemList.Add(New Item_base(0, "Paper", "This is a piece of paper", 0.5, 500, "Normal"))
        'ItemList.Add(New Item_base(0, "Paper", "This is a piece of paper", 0.5, 500, "Normal"))
    End Sub

End Module
