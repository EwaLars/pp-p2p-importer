
#Region " Imports "
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
        For Each row As DataRow In Me.ImportDT.Rows
            Dim description As String = row(4).ToString
            Dim transferDate As Date = CDate(row(0))
            Dim currency As String = row(1).ToString
            Dim amount As Decimal = CDec(row(2))
            If description.Contains(DepositString) Then
                Fkt.InsertTransaction(Fkt.FindXmlNodeByAccountName(Me.AccountName), transferDate, currency, amount, TransactionType.DEPOSIT)
            ElseIf Me.BondoraDIC.Keys.Contains(description) Then
                Fkt.InsertTransaction(Fkt.FindXmlNodeByAccountName(Me.AccountName), transferDate, currency, amount, Me.BondoraDIC(description))
            End If
        Next
    End Sub
#End Region

End Class