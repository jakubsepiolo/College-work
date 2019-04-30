Public Class ShieldWarrior
    Inherits Warrior
    Private ShieldReduction As Decimal = 0.9
    Public Sub New(Name As String)
        MyBase.New(Name, "shield", 100)
        Inventory.Add(New CWeapon("shield"))
    End Sub

    Public Sub New(Name As String, MaxHealth As UInteger)
        MyBase.New(Name, MaxHealth)

    End Sub
    Public Overrides Function GetShieldReduction() As Decimal
        For i = 0 To Inventory.Count - 1
            If Inventory(i).GetName() = "shield" Then
                Return ShieldReduction
            End If
        Next
        Return 1
    End Function
End Class
