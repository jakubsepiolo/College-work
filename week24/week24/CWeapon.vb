Public Class CWeapon
    Inherits CItem
    Public Sub New(ByVal WeaponName As String)
        MyBase.New(WeaponName, "Weapon", True)
    End Sub
End Class
