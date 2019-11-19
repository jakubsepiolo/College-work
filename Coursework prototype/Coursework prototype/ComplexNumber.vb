Public Class ComplexNumber
    'Complex number class containing functions and operators
    Public Real As Single
    Public Complex As Single
    Public Sub New(ByVal RealPart As Single, ByVal ComplexPart As Single)
        Real = RealPart
        Complex = ComplexPart
    End Sub

    Public Shared Operator +(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As ComplexNumber
        Return New ComplexNumber(ComplexNumber1.Real + ComplexNumber2.Real, ComplexNumber1.Complex + ComplexNumber2.Complex)
    End Operator
    Public Shared Operator -(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As ComplexNumber
        Return New ComplexNumber(ComplexNumber1.Real - ComplexNumber2.Real, ComplexNumber1.Complex - ComplexNumber2.Complex)
    End Operator
    Public Shared Operator *(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As ComplexNumber
        Return New ComplexNumber(ComplexNumber1.Real * ComplexNumber2.Real - ComplexNumber1.Complex * ComplexNumber2.Complex, ComplexNumber1.Real * ComplexNumber2.Complex + ComplexNumber2.Real * ComplexNumber1.Complex)
    End Operator
    Public Shared Operator /(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As ComplexNumber
        Return New ComplexNumber((ComplexNumber1.Real * ComplexNumber2.Real + ComplexNumber1.Complex * ComplexNumber2.Complex) / (ComplexNumber2.Real * ComplexNumber2.Real + ComplexNumber2.Complex * ComplexNumber2.Complex), (ComplexNumber1.Complex * ComplexNumber2.Real - ComplexNumber1.Real * ComplexNumber2.Complex) / (ComplexNumber2.Real * ComplexNumber2.Real + ComplexNumber2.Complex * ComplexNumber2.Complex))
    End Operator
    Public Shared Operator =(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As Boolean
        Return ComplexNumber1.Real = ComplexNumber2.Real And ComplexNumber1.Complex = ComplexNumber2.Complex
    End Operator

    Public Shared Operator <>(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As Boolean
        Return ComplexNumber1.Real <> ComplexNumber2.Real And ComplexNumber1.Complex <> ComplexNumber2.Complex
    End Operator
    Public Shared Operator >(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As Boolean
        Return ComplexNumber1.Modulus > ComplexNumber2.Modulus
    End Operator
    Public Shared Operator <(ByVal ComplexNumber1 As ComplexNumber, ByVal ComplexNumber2 As ComplexNumber) As Boolean
        Return ComplexNumber1.Modulus < ComplexNumber2.Modulus
    End Operator
    Public Function Modulus() As Single
        Return Math.Sqrt(Me.Real ^ 2 + Me.Complex ^ 2)
    End Function
    Public Function Argument() As Single
        Return Math.Atan2(Me.Complex, Me.Real)
    End Function
    Public Function RealPart() As Single
        Return Real
    End Function
    Public Function ComplexPart() As Single
        Return Complex
    End Function
    Public Function ModulusArgument() As String
        Return $"{LSet(Modulus(), 5)}, θ = {LSet(Argument(), 4)}"
    End Function
End Class