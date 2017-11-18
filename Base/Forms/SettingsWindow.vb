
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
        For Each platform As P2pPlatfrom In [Enum].GetValues(GetType(P2pPlatfrom))
            Me.AccountP2pPlatform.Items.Add(platform.ToString)
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

#Region " Private Sub HandlePlatformAccountChanges "
    Private Sub HandlePlatformAccountChanges()
        '>>> If the row count differs there must be a mismatch between the cached account list and the DGV account list
        If Me.AccountsDGV.RowCount = GV.AccountLIS.Count Then
            '>>> Loop through the cached account list and the DGV account list and check each entry
            Dim fehlerFLAG As Boolean = False
            For Each row As DataGridViewRow In Me.AccountsDGV.Rows
                Dim tmpP2p As New PlatformAccounts With {.Name = row.Cells(Me.AccountName.Name).Value.ToString,
                                                         .Plattform = CType(row.Cells(Me.AccountP2pPlatform.Name).Value.ToString.ToLower, P2pPlatfrom)}
                fehlerFLAG = True
                For Each account In GV.AccountLIS
                    '>>> If name AND platform are equal this entry matches. Leave loop and check next entry.
                    If account.Name.ToLower.Trim = tmpP2p.Name.ToLower.Trim AndAlso account.Plattform = tmpP2p.Plattform Then
                        fehlerFLAG = False
                        Exit For
                    End If
                Next
                '>>> If no match could be found for the current entry, exit for
                If fehlerFLAG = True Then
                    Exit For
                End If
            Next
            '>>> Cached account list is the same as the DGV account list - nothing to do
            If fehlerFLAG = False Then Exit Sub
        End If
        '>>> If this section is reached there is a mismatch between the cached account list and the DGV account list
        '>>> The account list within the settings.xml and the cached account list must be recreated
        '>>>
        '>>> Clear all old accounts
        GV.AccountLIS.Clear()
        Dim accountsNode As XmlNode = GV.SettingsXml.DocumentElement.SelectSingleNode("/Settings/Accounts")
        accountsNode.RemoveAll()
        '>>> Add new accounts
        For Each row As DataGridViewRow In Me.AccountsDGV.Rows
            Dim tmpP2p As New PlatformAccounts With {.Name = row.Cells(Me.AccountName.Name).Value.ToString,
                                                     .Plattform = CType(row.Cells(Me.AccountP2pPlatform.Name).Value.ToString.ToLower, P2pPlatfrom)}
            '>>> Generate new account node
            Dim singleAccountNode As XmlNode = GV.SettingsXml.CreateElement("Account")
            '>>> Add new platform node under the new created account node
            Dim platformNode As XmlNode = GV.SettingsXml.CreateElement("Platform")
            platformNode.InnerText = tmpP2p.Plattform.ToString.ToLower
            singleAccountNode.AppendChild(platformNode)
            '>>> Add new name node under the new created account node
            Dim nameNode As XmlNode = GV.SettingsXml.CreateElement("Name")
            nameNode.InnerText = tmpP2p.Name
            singleAccountNode.AppendChild(nameNode)
            '>>> Add new account node to accounts node
            accountsNode.AppendChild(singleAccountNode)
            '>>>
            '>>> Add new account to cached account list
            GV.AccountLIS.Add(tmpP2p)
        Next
        '>>> Save Settings.xml
        GV.SettingsXml.Save(GV.SettingsXmlPath)
    End Sub
#End Region

End Class