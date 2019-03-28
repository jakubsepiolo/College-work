﻿Public MustInherit Class Warrior
    Protected Name As String
    Protected CurrentHealth As Integer
    Protected MaxHealth As UInteger
    Protected AttackDamage As UInteger

    Public Sub New(ByVal Name As String)
        Me.Name = Name
        Me.MaxHealth = 100
        CurrentHealth = MaxHealth
        AttackDamage = 10
    End Sub
    Public Sub New(ByVal Name As String, ByVal MaxHealth As UInteger)
        Me.Name = Name
        Me.MaxHealth = MaxHealth
        CurrentHealth = MaxHealth
        AttackDamage = 10
    End Sub
    Public Function GetHealth() As Integer
        Return CurrentHealth
    End Function
    Public Function GetName() As String
        Return Name
    End Function
    Public Function IsAlive() As Boolean
        Return GetHealth() > 0
    End Function

    Public Overridable Function GetDamage() As Integer
        Return AttackDamage
    End Function
    Public Overridable Sub Attack(ByVal Enemy As Warrior, ByVal diceroll As UInteger, ByVal Damage As Integer)
        If Enemy.CurrentHealth - diceroll * Damage < 0 Then
            Enemy.CurrentHealth = 0
        Else
            Enemy.CurrentHealth -= diceroll * Damage
        End If
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine($"{GetName()} hit {Enemy.GetName} for {diceroll * Damage}")
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub
End Class
