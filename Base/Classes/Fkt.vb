
#Region " Imports "
Imports System.Xml
#End Region

Public Class Fkt

#Region " Public Shared Sub SetPpFileStatus "
    Public Shared Sub SetPpFileStatus(Path As String)
        GV.FRM.PathToXml.Text = "PP-File: " & Path
    End Sub
#End Region

#Region " Public Shared Sub InsertTransaction "
    Public Shared Sub InsertTransaction(TransactionsNode As XmlNode, TransactionDate As Date, Currency As String, Amount As Decimal, Type As TransactionType)
        Dim accountTransactionNode As XmlNode = GV.ppXml.CreateElement("account-transaction")
        Dim dateNode As XmlNode = GV.ppXml.CreateElement("date")
        dateNode.InnerText = TransactionDate.ToString("yyyy-MM-dd") '"2017-11-14"
        Dim currencyCodeNode As XmlNode = GV.ppXml.CreateElement("currencyCode")
        currencyCodeNode.InnerText = Currency.ToUpper
        Dim amountNode As XmlNode = GV.ppXml.CreateElement("amount")
        amountNode.InnerText = (Amount * 10).ToString
        Dim sharesNode As XmlNode = GV.ppXml.CreateElement("shares")
        sharesNode.InnerText = "0"
        Dim noteNode As XmlNode = GV.ppXml.CreateElement("note")
        noteNode.InnerText = "Importer"
        Dim typeNode As XmlNode = GV.ppXml.CreateElement("type")
        typeNode.InnerText = Type.ToString
        accountTransactionNode.AppendChild(dateNode)
        accountTransactionNode.AppendChild(currencyCodeNode)
        accountTransactionNode.AppendChild(amountNode)
        accountTransactionNode.AppendChild(sharesNode)
        accountTransactionNode.AppendChild(noteNode)
        accountTransactionNode.AppendChild(typeNode)
        TransactionsNode.AppendChild(accountTransactionNode)
    End Sub
#End Region

#Region " Public Shared Function UppercaseFirstLetter "
    Public Shared Function UppercaseFirstLetter(ByVal val As String) As String
        '>>> Test for nothing or empty.
        If String.IsNullOrEmpty(val) Then
            Return val
        End If
        '>>> Convert to character array.
        Dim array() As Char = val.ToCharArray
        '>>> Uppercase first character.
        array(0) = Char.ToUpper(array(0))
        '>>> Return new string.
        Return New String(array)
    End Function
#End Region

End Class
