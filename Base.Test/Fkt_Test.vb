Imports Xunit

Public Class Fkt_Test



    <Fact>
    Public Sub Fkt_UpperCaseFirstLetter()
        Dim expected As String = "Welt"
        Dim input As String = "welt"

        Dim result = Fkt.UppercaseFirstLetter(input)

        Assert.Equal(expected, result)
    End Sub

End Class
