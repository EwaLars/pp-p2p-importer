
#Region " Imports "
Imports System.Globalization
Imports System.Xml
Imports Base
#End Region

Public Class Viainvest
    Implements IP2pProcessor

#Region " Porperties "
    Private Property ImportDT As DataTable Implements IP2pProcessor.ImportDT
#End Region

#Region " Declarations "
    Private FilePath As String
    Private AccountName As String
    Private ViainvestDIC As New Dictionary(Of String, TransactionType)
#End Region

#Region " Contructor "
    Public Sub New(FilePath As String, AccountName As String)
        Me.AccountName = AccountName
        Me.FilePath = FilePath
        BuildViainvestDIC()
        ReadFile()
    End Sub
#End Region

#Region " Private Sub BuildViainvestDIC () "
    Private Sub BuildViainvestDIC()
        ViainvestDIC.Add("Betrag der eingezahlten Mittel", TransactionType.DEPOSIT)
        ViainvestDIC.Add("Zahlung für den Zinsbetrag erhaltenen", TransactionType.INTEREST)
    End Sub
#End Region

#Region " Private Sub ReadFile "
    Private Sub ReadFile() Implements IP2pProcessor.ReadFile
        Me.ImportDT = Fkt.ReadXlsToDatatable(Me.FilePath, "Transactions$")
    End Sub
#End Region

#Region " Public Sub Process "
    Public Sub Process() Implements IP2pProcessor.Process
        '>>> Exit if datatalbe is nothing
        If Me.ImportDT Is Nothing Then Exit Sub
        Dim accountNode As XmlNode = Fkt.FindXmlNodeByAccountName(Me.AccountName)
        '>>> Build hashlist
        Dim hashLIS As New List(Of Long)
        If accountNode.ChildNodes.Count <> 0 Then
            Dim transactionNodes = accountNode.SelectNodes("account-transaction")
            For Each node As XmlNode In transactionNodes
                Dim tmpLong As Long
                Dim noteNode As XmlNode = node.SelectSingleNode("note")
                If noteNode IsNot Nothing AndAlso Long.TryParse(noteNode.InnerText, tmpLong) Then
                    hashLIS.Add(tmpLong)
                End If
            Next
        End If
        For Each row As DataRow In Me.ImportDT.Rows
            Dim description As String = row(2).ToString.Trim
            Dim transferDate As Date
            Dim testdate As String = row(1).ToString
            If Date.TryParseExact(testdate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, transferDate) = False Then
                Continue For
            End If
            Dim currency As String = "EUR"
            Dim amount As Decimal
            If Decimal.TryParse(row(6).ToString, amount) = False Then
                amount = 0
            End If
            Dim loanID As String = row(4).ToString
            Dim noteHash As Long
            If Me.ViainvestDIC.Keys.Contains(description) Then
                noteHash = Fkt.CreateNoteHash(transferDate, currency, amount, Me.ViainvestDIC(description),, loanID)
                If hashLIS.Contains(noteHash) = False Then
                    Fkt.InsertTransaction(accountNode, transferDate, currency, amount, Me.ViainvestDIC(description), noteHash)
                End If
            End If
        Next
    End Sub
#End Region

End Class