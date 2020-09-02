Imports Xunit

Public Class Fkt_Test

    <Theory>
    <InlineData("welt", "Welt")>
    <InlineData("WELT", "WELT")>
    <InlineData("", "")>
    <InlineData("a", "A")>
    <InlineData("b", "B")>
    <InlineData(Nothing, Nothing)>
    Public Sub Fkt_UpperCaseFirstLetter(Input As String, Expected As String)
        Dim result = Fkt.UppercaseFirstLetter(Input)
        Assert.Equal(Expected, result)
    End Sub
End Class