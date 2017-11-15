
#Region " Imports "
Imports System.Xml
Imports Microsoft.VisualBasic
#End Region

Public Class MainWindow
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim pp As New XmlDocument()
        pp.Load(GV.ppXmlPath)
        Dim nodes As XmlNodeList = pp.DocumentElement.SelectNodes("/client/accounts/account")

        Dim nodeLIS As New List(Of XmlNode)

        For Each node As XmlNode In nodes
            Dim name As String = ""
            Try
                name = node.SelectSingleNode("name").InnerText
            Catch ex As Exception
                Continue For
            End Try
            If GV.AccountLIS.Contains(name) Then
                nodeLIS.Add(node)
            End If
        Next




        pp.Save(GV.ppXmlPath)




        Stop


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetSettings()
    End Sub


#Region " Private Sub: GetSettings () "
    Private Sub GetSettings()
        GV.FRM = Me
        GV.SettingsXmlPath = My.Application.Info.DirectoryPath & "\..\..\Settings.xml"
        GV.SettingsXml.Load(GV.SettingsXmlPath)
        GV.ppXmlPath = GV.SettingsXml.DocumentElement.SelectSingleNode("/Settings/PortfolioPerformanceXmlFile").InnerText
        Dim nodes As XmlNodeList = GV.SettingsXml.DocumentElement.SelectNodes("/Settings/Accounts/Account")
        GV.AccountLIS = nodes.Cast(Of XmlNode).Select(Function(x) x.SelectSingleNode("Name").InnerText).ToList
        Fkt.SetPpFileStatus(GV.ppXmlPath)
        GV.ppXml.Load(GV.ppXmlPath)
    End Sub

#End Region



#Region " SettingsToolStripMenuItem_Click "
    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim settings As New SettingsWindow
        settings.ShowDialog()
    End Sub
#End Region


End Class
