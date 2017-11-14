
Imports System.Xml
Imports Microsoft.VisualBasic

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


        If nodeLIS.Count > 0 Then


            Dim accountTransactionNode As XmlNode = pp.CreateElement("account-transaction")

            Dim dateNode As XmlNode = pp.CreateElement("date")
            dateNode.InnerText = "2017-11-14"
            Dim currencyCodeNode As XmlNode = pp.CreateElement("currencyCode")
            currencyCodeNode.InnerText = "EUR"
            Dim amountNode As XmlNode = pp.CreateElement("amount")
            amountNode.InnerText = "50"
            Dim sharesNode As XmlNode = pp.CreateElement("shares")
            sharesNode.InnerText = "0"
            Dim noteNode As XmlNode = pp.CreateElement("note")
            noteNode.InnerText = "Importer"
            Dim typeNode As XmlNode = pp.CreateElement("type")
            typeNode.InnerText = "DEPOSIT"



            accountTransactionNode.AppendChild(dateNode)
            accountTransactionNode.AppendChild(currencyCodeNode)
            accountTransactionNode.AppendChild(amountNode)
            accountTransactionNode.AppendChild(sharesNode)
            accountTransactionNode.AppendChild(noteNode)
            accountTransactionNode.AppendChild(typeNode)


            nodeLIS(0).SelectSingleNode("transactions").AppendChild(accountTransactionNode)
        End If

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
    End Sub

#End Region



#Region " SettingsToolStripMenuItem_Click "
    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim settings As New SettingsWindow
        settings.ShowDialog()
    End Sub
#End Region


End Class
