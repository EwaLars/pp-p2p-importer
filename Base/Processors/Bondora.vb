
#Region " Imports "
Imports System.Xml
Imports Base
#End Region

Public Class Bondora
    Implements IP2pProcessor

#Region " Porperties "
    Private Property ImportDT As DataTable Implements IP2pProcessor.ImportDT
#End Region

#Region " Declarations "
    Private FilePath As String
    Private AccountName As String
    Private BondoraDIC As New Dictionary(Of String, TransactionType)
    Private Const DepositString As String = "TransferDeposit"
#End Region

#Region " Contructor "
    Public Sub New(FilePath As String, AccountName As String)
        Me.AccountName = AccountName
        Me.FilePath = FilePath
        Me.BuildBondoraDIC()
        ReadFile()
    End Sub
#End Region

#Region " Private Sub BuildBondoraDIC () "
    Private Sub BuildBondoraDIC()
        BondoraDIC.Add("TransferTrialFunds", TransactionType.DEPOSIT)
        BondoraDIC.Add("TransferInterestRepaiment", TransactionType.INTEREST)
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
            Dim description As String = row(4).ToString
            Dim transferDate As Date = CDate(row(0))
            Dim currency As String = row(1).ToString
            Dim amount As Decimal = CDec(row(2))
            Dim balance As Decimal = CDec(row(7))
            Dim noteHash As Long
            If description.Contains(DepositString) Then
                noteHash = Fkt.CreateNoteHash(transferDate, currency, amount, TransactionType.DEPOSIT, balance)
                If hashLIS.Contains(noteHash) = False Then
                    Fkt.InsertTransaction(accountNode, transferDate, currency, amount, TransactionType.DEPOSIT, noteHash)
                End If
            ElseIf Me.BondoraDIC.Keys.Contains(description) Then
                noteHash = Fkt.CreateNoteHash(transferDate, currency, amount, Me.BondoraDIC(description), balance)
                If hashLIS.Contains(noteHash) = False Then
                    Fkt.InsertTransaction(accountNode, transferDate, currency, amount, Me.BondoraDIC(description), noteHash)
                End If
            End If
        Next
    End Sub
#End Region

End Class