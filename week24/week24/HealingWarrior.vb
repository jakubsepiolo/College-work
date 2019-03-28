Imports week24

Public Class HealingWarrior
    Inherits Warrior
    Private haveHealed As Boolean
    Public Sub New(ByVal Name As String)
        MyBase.New(Name, 150)
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
        MyBase.Attack(Enemy, diceroll, AttackDamage)

    End Sub
End Class
