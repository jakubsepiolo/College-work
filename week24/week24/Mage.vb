Imports week24

Public Class Mage
    Inherits Warrior
    Private Mana As Integer
    Private MaxMana As Integer
    Private MagicDamage As Integer
    Public Sub New(ByVal Name As String, ByVal MaxMana As Integer, ByVal MagicDamage As Integer)
        MyBase.New(Name, "mage", 800)
        AttackDamage = 5
        Me.MaxMana = MaxMana
        Me.MagicDamage = MagicDamage
        Mana = Me.MaxMana
        Inventory.Add(New CPotion("mana"))
    End Sub
    Public Function GetMana() As Integer
        Return Mana
    End Function

    Public Overrides Function GetDamage() As Integer
        Return MagicDamage
    End Function
    Public Overrides Sub Attack(Enemy As Warrior, diceroll As UInteger, ByVal Damage As Integer)
        If GetMana() < MaxMana Then
            Console.ForegroundColor = ConsoleColor.Cyan
            Console.Write($"Changed {GetName()}'s mana from {GetMana()} to ")
            If Mana + 10 > MaxMana Then
                Mana = MaxMana
            Else
                Mana += 10
            End If
            Console.WriteLine($"{GetMana()}")
        Else
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine($"{GetName()} Casted a spell!")
            MyBase.Attack(Enemy, diceroll, Damage)
            Console.ForegroundColor = ConsoleColor.Cyan
            Console.WriteLine($"Changed {GetName()}'s mana from {GetMana()} to 0")
            Mana = 0
        End If
        Console.WriteLine($"{Name} Do you want to use your mana potion?")
        If Inventory.Count > 0 Then
            If Console.ReadLine().ToLower() = "y" Then
                Inventory(0).UseItem()
                Console.WriteLine($"Potion used, mana set to {MaxMana}")
                Mana = MaxMana
                Inventory.RemoveAt(0)
                For i = 1 To Inventory.Count - 1
                    If Inventory.Count > 1 Then
                        Inventory(i - 1) = Inventory(i)
                    End If
                Next
            End If
        End If
        Randomize()
        If Int(Rnd() * 20) = 1 Then
            Inventory.Add(New CPotion("mana"))
        End If
        Console.ForegroundColor = ConsoleColor.Gray

    End Sub

End Class
