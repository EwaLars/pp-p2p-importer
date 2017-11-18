
#Region " Imports "
Imports Base
#End Region

Public Class Viainvest
    Implements P2pProcessor

#Region " Declarations "
    Private importDT As DataTable
    Private FilePath As String
#End Region

#Region " Contructor "
    Public Sub New(FilePath As String)
        Me.FilePath = FilePath
        ReadFile()
    End Sub
#End Region

#Region " Private Sub ReadFile "
    Private Sub ReadFile() Implements P2pProcessor.ReadFile

    End Sub
#End Region

#Region " Public Sub Process "
    Public Sub Process() Implements P2pProcessor.Process

    End Sub
#End Region

End Class