
#Region " Imports "
Imports System.Xml
#End Region

Public Class SettingsWindow

#Region " Private Sub ButtonPP_Click "
    Private Sub ButtonPP_Click(sender As Object, e As EventArgs) Handles ButtonPP.Click
        Dim open As New OpenFileDialog
        If open.ShowDialog = DialogResult.OK Then
            Me.TextBoxPP.Text = open.FileName
        End If
    End Sub
#End Region

#Region " Private Sub ButtonOk_Click "
    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        '>>> Handle the change of the PP-Config File
        HandleXmlFileChanges()
        '>>> Close Window
        Me.DialogResult = DialogResult.OK
    End Sub
#End Region

#Region " Private Sub SettingsWindow_Load "
    Private Sub SettingsWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        '>>> Set possible platforms in DGV
        Dim platformNodes = GV.SettingsXml.SelectNodes("/Settings/Platforms/Platform")
        For Each node As XmlNode In platformNodes
            Me.AccountP2pPlatform.Items.Add(node.SelectSingleNode("Name").InnerText)
        Next

        Me.TextBoxPP.Text = GV.ppXmlPath
        '>>> Load Accounts

        Dim accountNodes = GV.SettingsXml.SelectNodes("/Settings/Accounts/Account")


        For Each node As XmlNode In accountNodes
            Dim plattform As String = node.SelectSingleNode("Platform").InnerText
            Dim name As String = node.SelectSingleNode("Name").InnerText
            Me.AccountsDGV.Rows.Add({plattform, name})
        Next

    End Sub
#End Region

#Region " Private Sub HandleXmlFileChanges "
    Private Sub HandleXmlFileChanges()
        If GV.ppXmlPath <> Me.TextBoxPP.Text Then
            '>>> Get settings node from own XML File
            Dim ppFileNode As XmlNode = GV.SettingsXml.DocumentElement.SelectSingleNode("/Settings/PortfolioPerformanceXmlFile")
            '>>> Set new XML Path in global variable
            GV.ppXmlPath = Me.TextBoxPP.Text
            '>>> Set new XML Path in XML Node
            ppFileNode.InnerText = GV.ppXmlPath
            '>>> Save Settings.xml
            GV.SettingsXml.Save(GV.SettingsXmlPath)
            '>>> Set status-label of main window
            Fkt.SetPpFileStatus(GV.ppXmlPath)

            GV.ppXml = New XmlDocument
            GV.ppXml.Load(GV.ppXmlPath)
        End If
    End Sub
#End Region

End Class