Public Class Warrior
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
    Public Sub Attack(ByVal Enemy As Warrior, ByVal diceroll As UInteger)
        If Enemy.CurrentHealth - diceroll * AttackDamage < 0 Then
            Enemy.CurrentHealth = 0
        Else
            Enemy.CurrentHealth -= diceroll * AttackDamage
        End If
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine($"{GetName()} hit {Enemy.GetName} for {diceroll * AttackDamage}")
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub
End Class
