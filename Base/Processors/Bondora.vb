﻿
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
#End Region

#Region " Contructor "
    Public Sub New(FilePath As String)
        Me.FilePath = FilePath
        ReadFile()
    End Sub
#End Region

#Region " Private Sub ReadFile "
    Private Sub ReadFile() Implements IP2pProcessor.ReadFile

    End Sub
#End Region

#Region " Public Sub Process "
    Public Sub Process() Implements IP2pProcessor.Process

    End Sub
#End Region

End Class