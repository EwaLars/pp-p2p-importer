
#Region " Imports "
Imports System.Xml
Imports ClosedXML.Excel
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
        amountNode.InnerText = CInt(Amount * 100).ToString
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

#Region " Public Shared Function ReadXlsxToDatatable () "
    Public Shared Function ReadXlsxToDatatable(XlsxFilePath As String) As DataTable
        Dim dt As New DataTable
        'Open the Excel file using ClosedXML.
        Using workBook As New XLWorkbook(XlsxFilePath)
            'Read the first Sheet from Excel file.
            Dim workSheet As IXLWorksheet = workBook.Worksheet(1)
            'Loop through the Worksheet rows.
            Dim firstRow As Boolean = True
            For Each row As IXLRow In workSheet.Rows()
                'Use the first row to add columns to DataTable.
                If firstRow Then
                    For Each cell As IXLCell In row.Cells()
                        dt.Columns.Add(cell.Value.ToString())
                    Next
                    firstRow = False
                Else
                    'Add rows to DataTable.
                    dt.Rows.Add()
                    Dim i As Integer = 0
                    For Each cell As IXLCell In row.Cells()
                        dt.Rows(dt.Rows.Count - 1)(i) = cell.Value.ToString()
                        i += 1
                    Next
                End If
            Next
        End Using
        Return dt
    End Function
#End Region

#Region " Public Shared Function FindXmlNodeByAccountName () "
    Public Shared Function FindXmlNodeByAccountName(AccountName As String) As XmlNode
        Dim accountNodes = GV.ppXml.SelectNodes("/client/accounts/account")
        Dim returnNode As XmlNode = Nothing
        For Each node As XmlNode In accountNodes
            Dim nameNode = node.SelectSingleNode("name")
            If nameNode IsNot Nothing AndAlso nameNode.InnerText.ToLower = AccountName.ToLower Then
                returnNode = node.SelectSingleNode("transactions")
                Exit For
            End If
        Next
        Return returnNode
    End Function
#End Region

End Class
