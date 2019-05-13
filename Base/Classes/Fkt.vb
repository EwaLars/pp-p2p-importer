
#Region " Imports "
Imports System.Data.OleDb
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
    Public Shared Sub InsertTransaction(TransactionsNode As XmlNode, TransactionDate As Date, Currency As String, Amount As Decimal, Type As TransactionType, NoteHash As Long)
        Dim accountTransactionNode As XmlNode = GV.ppXml.CreateElement("account-transaction")
        Dim dateNode As XmlNode = GV.ppXml.CreateElement("date")
        dateNode.InnerText = TransactionDate.ToString("yyyy-MM-dd") '"2017-11-14"
        Dim currencyCodeNode As XmlNode = GV.ppXml.CreateElement("currencyCode")
        currencyCodeNode.InnerText = Currency.ToUpper
        Dim amountNode As XmlNode = GV.ppXml.CreateElement("amount")
        amountNode.InnerText = CInt(Math.Round(Amount * 100, 0, MidpointRounding.AwayFromZero)).ToString
        Dim sharesNode As XmlNode = GV.ppXml.CreateElement("shares")
        sharesNode.InnerText = "0"
        Dim noteNode As XmlNode = GV.ppXml.CreateElement("note")
        noteNode.InnerText = NoteHash.ToString
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
                    For Each cell As IXLCell In row.Cells()
                        dt.Rows(dt.Rows.Count - 1)(cell.Address.ColumnNumber - 1) = cell.Value.ToString()
                    Next
                End If
            Next
        End Using
        Return dt
    End Function
#End Region

#Region " Public Shared Function ReadXlsToDatatable () "
    Public Shared Function ReadXlsToDatatable(FilePath As String, SheetName As String) As DataTable
        '>>> Check if Access Runtime 2013 is installed
        If Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("Microsoft.ACE.OLEDB.15.0") Is Nothing Then
            MsgBox("Microsoft Access Runtime 2016 is not installed!", MsgBoxStyle.Critical)
            Return Nothing
        End If
        Dim myConnection = $"Provider=Microsoft.ACE.OLEDB.15.0;Data Source={FilePath};Extended Properties=""Excel 12.0 Xml;HDR=YES"""
        Dim conn = New OleDbConnection(myConnection)
        Dim strSQL = $"SELECT * FROM [{SheetName}]"
        Dim cmd = New OleDbCommand(strSQL, conn)
        Dim DataSet = New DataSet()
        Dim adapter = New OleDbDataAdapter(cmd)
        adapter.Fill(DataSet)
        Return DataSet.Tables(0)
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

#Region " Public Shared Function CreateNoteHash () "
    Public Shared Function CreateNoteHash(TransferDate As Date, Currency As String, Amount As Decimal, Type As TransactionType, Optional Balance As Decimal = 0, Optional LoanID As String = "") As Long
        Const prime As Integer = 31
        Dim resultHash As Long = 1
        resultHash = resultHash * prime + TransferDate.GetHashCode
        resultHash = resultHash * prime + Currency.GetHashCode
        resultHash = resultHash * prime + Amount.GetHashCode
        resultHash = resultHash * prime + Type.ToString.GetHashCode
        resultHash = resultHash * prime + Balance.ToString.GetHashCode
        resultHash = resultHash * prime + LoanID.GetHashCode
        Return resultHash
    End Function
#End Region

End Class
