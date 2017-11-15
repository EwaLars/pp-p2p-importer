
Imports System.Xml
Public Class GV
    Public Shared AccountLIS As New List(Of PlatformAccounts)
    Public Shared SettingsXml As New XmlDocument
    Public Shared SettingsXmlPath As String

    Public Shared ppXml As New XmlDocument
    Public Shared ppXmlPath As String

    Public Shared FRM As MainWindow


End Class

Public Enum TransactionType
    DEPOSIT
    INTEREST
End Enum

Public Enum P2pPlatfrom
    mintos
    bondora
    viainvest
End Enum

Public Structure PlatformAccounts
    Public Plattform As P2pPlatfrom
    Public Name As String
End Structure
