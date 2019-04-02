Public Class ShieldWarrior
    Inherits Warrior

    Private ShieldReduction As Decimal = 0.9
    Public Sub New(Name As String)
        MyBase.New(Name, 100)
    End Sub

    Public Sub New(Name As String, MaxHealth As UInteger)
        MyBase.New(Name, MaxHealth)
    End Sub
    Public Overrides Function GetShieldReduction() As Decimal
        Return ShieldReduction
    End Function
End Class
