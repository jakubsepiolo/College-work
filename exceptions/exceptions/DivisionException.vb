Public Class DivisionException
    Inherits Exception
    Public Sub New()
        MyBase.New("Cannot divide by zero")
    End Sub
End Class
