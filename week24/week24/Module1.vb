Module Module1
    Dim MyWarrior As New HealingWarrior("Jakub")
    Dim EnemyWarrior As New Warrior("Enemy")
    Sub ShowHealth()
        Console.WriteLine($"{MyWarrior.GetName()}'s health is {MyWarrior.GetHealth()}")
        Console.WriteLine($"{EnemyWarrior.GetName()}'s health is {EnemyWarrior.GetHealth()}")
        Console.WriteLine()
    End Sub
    Sub Main()
        Console.Write("How many sides should the dice have: ")
        Dim Sides As UInteger = Console.ReadLine()
        Dim TheDice As New Dice(Sides)
        ShowHealth()
        While MyWarrior.IsAlive() And EnemyWarrior.IsAlive()
            MyWarrior.Attack(EnemyWarrior, TheDice.Roll())
            ShowHealth()
            Threading.Thread.Sleep(500)
            If Not EnemyWarrior.IsAlive() Then
                Exit While
            End If
            EnemyWarrior.Attack(MyWarrior, TheDice.Roll())
            ShowHealth()
            Threading.Thread.Sleep(500)
            If Not MyWarrior.HasHealed() Then
                Console.WriteLine("Should you heal? ")
                If Console.ReadLine().ToUpper() = "Y" Then
                    MyWarrior.Heal()
                End If
            End If
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
