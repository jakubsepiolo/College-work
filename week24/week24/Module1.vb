Module Module1
    Dim MyWarrior As New HealingWarrior("Jakub")
    Dim EnemyWarrior As New Mage("Enemy", 200, 20)

    Function Clamp(ByRef myNum As Integer, min As Integer, max As Integer) As Integer
        If myNum < min Then
            myNum = min
            Return myNum
        End If
        If myNum > max Then
            myNum = max
            Return myNum
        End If
        Return myNum
    End Function
    Sub ShowHealth(Warrior As Warrior)
        Dim HealthRatio As Integer = Warrior.GetMaxHealth() / 100
        Dim FakeMaxHealth As Integer = Warrior.GetMaxHealth / HealthRatio
        Dim FakeHealth As Integer = Clamp(Warrior.GetHealth / HealthRatio, 0, 100)
        Dim EmptyBarCount As Integer = Clamp((FakeMaxHealth - FakeHealth), 0, 100)
        Console.WriteLine($"{Warrior.GetName()}'s health is {Warrior.GetHealth()}")
        Console.Write("[")
        If Not Warrior.IsAlive() Then
            EmptyBarCount = 100
        End If
        For i = 1 To (100 - EmptyBarCount)
            Console.Write("█")
        Next
        If EmptyBarCount = 0 Then
            Console.WriteLine("]")
            Exit Sub
        End If
        For i = (100 - EmptyBarCount) To 99 Step 1
            Console.Write(" ")
        Next
        Console.WriteLine("]")
    End Sub
    Sub Main()
        Console.Write("How many sides should the dice have: ")
        Dim Sides As UInteger = Console.ReadLine()
        Dim TheDice As New Dice(Sides)
        ShowHealth(MyWarrior)
        ShowHealth(EnemyWarrior)
        While MyWarrior.IsAlive() And EnemyWarrior.IsAlive()
            MyWarrior.Attack(EnemyWarrior, TheDice.Roll(), MyWarrior.GetDamage())
            ShowHealth(MyWarrior)
            ShowHealth(EnemyWarrior)
            Threading.Thread.Sleep(500)
            If Not EnemyWarrior.IsAlive() Then
                Exit While
            End If
            EnemyWarrior.Attack(MyWarrior, TheDice.Roll(), EnemyWarrior.GetDamage())
            ShowHealth(MyWarrior)
            ShowHealth(EnemyWarrior)
            Threading.Thread.Sleep(500)
            'If Not MyWarrior.HasHealed() Then
            '    Console.WriteLine("Should you heal? ")
            '    If Console.ReadLine().ToUpper() = "Y" Then
            '        MyWarrior.Heal()
            '    End If
            'End If
        End While
        If MyWarrior.IsAlive() Then
            Console.WriteLine($"{MyWarrior.GetName()} has won!")
        ElseIf EnemyWarrior.IsAlive() Then
            Console.WriteLine($"{EnemyWarrior.GetName()} has won!")
        Else
            Console.WriteLine("Somehow you both died")
        End If
        Console.ReadKey()
    End Sub

End Module
