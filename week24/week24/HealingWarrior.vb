Imports week24

Public Class HealingWarrior
    Inherits Warrior
    Private haveHealed As Boolean

    Public Sub New(ByVal Name As String)
        MyBase.New(Name, "healing", 150)
        Inventory.Add(New CPotion("health"))
    End Sub
    Public Function HasHealed() As Boolean
        Return haveHealed
    End Function
    Public Sub SetHaveHealed()
        haveHealed = True
    End Sub
    Public Sub Heal()
        If HasHealed() Then
            Exit Sub
        End If
        CurrentHealth = MaxHealth
        SetHaveHealed()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine($"{GetName()} has healed back to {GetHealth()}")
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub

    Public Overrides Sub Attack(Enemy As Warrior, diceroll As UInteger, ByVal Damage As Integer)
        Console.WriteLine("Do you want to use your health potion?")
        If Console.ReadLine().ToLower() = "y" Then
            Inventory(0).UseItem()
            Console.WriteLine($"Potion used, health set to {MaxHealth}")
            CurrentHealth = MaxHealth
            Inventory.RemoveAt(0)
            For i = 1 To Inventory.Count - 1
                If Inventory.Count > 1 Then
                    Inventory(i - 1) = Inventory(i)
                End If
            Next
        End If
        Randomize()
        If Int(Rnd() * 20) = 1 Then
            Inventory.Add(New CPotion("health"))
        End If
        MyBase.Attack(Enemy, diceroll, AttackDamage)

    End Sub
    Public Overrides Function IsHealingWarrior() As Boolean
        Return True
    End Function
End Class
