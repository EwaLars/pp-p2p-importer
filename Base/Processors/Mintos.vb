
#Region " Imports "
Imports System.Xml
Imports Base
#End Region

Public Class Mintos
    Implements IP2pProcessor

#Region " Porperties "
    Private Property ImportDT As DataTable Implements IP2pProcessor.ImportDT
#End Region

#Region " Declarations "
    Private FilePath As String
    Private AccountName As String
    Private MintosDIC As New Dictionary(Of String, TransactionType)
    Private Const InterestString As String = "Interest income Loan ID"
#End Region

#Region " Contructor "
    Public Sub New(FilePath As String, AccountName As String)
        Me.AccountName = AccountName
        Me.FilePath = FilePath
        Me.BuildMintosDIC()
        ReadFile()
    End Sub
#End Region

#Region " Private Sub BuildMintosDIC () "
    Private Sub BuildMintosDIC()
        MintosDIC.Add("Incoming client payment", TransactionType.DEPOSIT)
        MintosDIC.Add("Affiliate bonus", TransactionType.DEPOSIT)
    End Sub
#End Region


#Region " Private Sub ReadFile "
    Private Sub ReadFile() Implements IP2pProcessor.ReadFile
        Me.ImportDT = Fkt.ReadXlsxToDatatable(Me.FilePath)
    End Sub
#End Region

#Region " Public Sub Process "
    Public Sub Process() Implements IP2pProcessor.Process
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
            Dim description As String = row(2).ToString
            Dim transferDate As Date = CDate(row(1))
            Dim currency As String = row(5).ToString
            Dim amount As Decimal = CDec(row(3))
            Dim balance As Decimal = CDec(row(4))
            Dim noteHash As Long
            If description.Contains(InterestString) Then
                noteHash = Fkt.CreateNoteHash(transferDate, currency, amount, TransactionType.INTEREST, balance)
                If hashLIS.Contains(noteHash) = False Then
                    Fkt.InsertTransaction(accountNode, transferDate, currency, amount, TransactionType.INTEREST, noteHash)
                End If
            ElseIf Me.MintosDIC.Keys.Contains(description) Then
                noteHash = Fkt.CreateNoteHash(transferDate, currency, amount, Me.MintosDIC(description), balance)
                If hashLIS.Contains(noteHash) = False Then
                    Fkt.InsertTransaction(accountNode, transferDate, currency, amount, Me.MintosDIC(description), noteHash)
                End If
            End If
        Next
    End Sub
#End Region

End Class