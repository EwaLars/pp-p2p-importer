
#Region " Imports "
Imports System.Xml
#End Region

#Region " Public Class GV "
Public Class GV
    Public Shared AccountLIS As New List(Of PlatformAccounts)
    Public Shared SettingsXml As New XmlDocument
    Public Shared SettingsXmlPath As String
    Public Shared ppXml As New XmlDocument
    Public Shared ppXmlPath As String
    Public Shared FRM As MainWindow
End Class
#End Region

#Region " Public Enum TransactionType "
Public Enum TransactionType
    DEPOSIT
    INTEREST
End Enum
#End Region

#Region " Public Enum P2pPlatfrom "
Public Enum P2pPlatfrom
    mintos
    bondora
    viainvest
End Enum
#End Region

#Region " Public Structure PlatformAccounts "
Public Structure PlatformAccounts
    Public Plattform As P2pPlatfrom
    Public Name As String
End Structure
#End Region