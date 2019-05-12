Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Base

<TestClass()> Public Class BaseTest

    <TestMethod()>
    Public Sub Fkt_UpperCaseFirstLetter_Working()



        Dim expected As String = "Welt"
        Dim input As String = "welt"

        Dim result = Fkt.UppercaseFirstLetter(input)

        Assert.AreEqual(expected, result)
    End Sub

End Class