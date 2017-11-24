
#Region " Imports "
Imports System.Xml
Imports Microsoft.VisualBasic
#End Region

Public Class MainWindow

#Region " Form-Events "

#Region " Private Sub MainWindow_Load "
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetSettings()
        '>>>
        LoadPanel()
        '>>> Configure status strip
        Me.StripStatusLabelVersion.Text = "v" & ProductVersion
        Me.PathToXml.Width = Me.StatusStrip1.Width - Me.StripStatusLabelVersion.Width - 2
    End Sub
#End Region

#End Region

#Region " Control-Events "

#Region " Private Sub ButtonProcess_Click "
    Private Sub ButtonProcess_Click(sender As Object, e As EventArgs) Handles ButtonProcess.Click
        Dim saveFLAG As Boolean = False
        For Each ctrl As Control In Me.MainPanel.Controls
            If TypeOf ctrl Is FileSelectUC Then
                Dim tmpUC As FileSelectUC = CType(ctrl, FileSelectUC)
                If tmpUC.Path <> "" Then
                    saveFLAG = True
                    Dim tmpProcessor As IP2pProcessor = Nothing
                    Select Case tmpUC.Account.Plattform
                        Case P2pPlatfrom.bondora
                            tmpProcessor = New Bondora(tmpUC.Path)
                        Case P2pPlatfrom.mintos
                            tmpProcessor = New Mintos(tmpUC.Path)
                        Case P2pPlatfrom.viainvest
                            tmpProcessor = New Viainvest(tmpUC.Path)
                    End Select
                    tmpProcessor.Process()
                End If
            End If
        Next
        '>>> Save the formated XML file
        If saveFLAG Then GV.ppXml.Save(GV.ppXmlPath)
    End Sub
#End Region

#Region " Private Sub ButtonClose_Click "
    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click, ButtonExit.Click
        Me.Close()
    End Sub
#End Region

#Region " Private Sub ButtonSettings_Click "
    Private Sub ButtonSettings_Click(sender As Object, e As EventArgs) Handles ButtonSettings.Click
        Dim settings As New SettingsWindow
        settings.ShowDialog()
    End Sub
#End Region

#Region " Private Sub ButtonFairrCSV_Click () "
    Private Sub ButtonFairrCSV_Click(sender As Object, e As EventArgs) Handles ButtonFairrCSV.Click
        Dim tmpOpen As New OpenFileDialog
        tmpOpen.Filter = "Excel|*.xlsx;*.xls|CSV|*.csv|All files|*.*"
        If tmpOpen.ShowDialog = DialogResult.OK Then
            Dim tmpFairr As New Fairr(tmpOpen.FileName)

            tmpFairr.Process()
        End If
    End Sub
#End Region

#End Region

#Region " Subs & Functions "

#Region " Private Sub: GetSettings () "
    Private Sub GetSettings()
        GV.FRM = Me
        GV.SettingsXmlPath = My.Application.Info.DirectoryPath & "\..\..\Settings.xml"
        GV.SettingsXml.Load(GV.SettingsXmlPath)
        GV.ppXmlPath = GV.SettingsXml.DocumentElement.SelectSingleNode("/Settings/PortfolioPerformanceXmlFile").InnerText
        Dim nodes As XmlNodeList = GV.SettingsXml.DocumentElement.SelectNodes("/Settings/Accounts/Account")
        Try
            GV.AccountLIS = nodes.Cast(Of XmlNode).Select(Function(x) New PlatformAccounts With {.Name = x.SelectSingleNode("Name").InnerText,
                                                                                             .Plattform = DirectCast([Enum].Parse(GetType(P2pPlatfrom), x.SelectSingleNode("Platform").InnerText), P2pPlatfrom)}).ToList

        Catch ex As Exception
            Throw ex
        End Try
        Fkt.SetPpFileStatus(GV.ppXmlPath)
        GV.ppXml.Load(GV.ppXmlPath)
    End Sub
#End Region

#Region " Private Sub LoadPanel "
    Private Sub LoadPanel()
        '>>> Choose wether the 'no-account' label should be visible or not and resize main window 
        If GV.AccountLIS.Count > 0 Then
            Me.LabelNoAccount.Visible = False
            If GV.AccountLIS.Count <= 5 Then
                Me.Height = 136 + (GV.AccountLIS.Count * 50)
            Else
                Me.Height = 136 + (6 * 50)
            End If
        Else
            Me.LabelNoAccount.Visible = True
            Me.Height = 236
        End If
        '>>> Initialize controls and add controls to main window
        For Each account In GV.AccountLIS
            Dim tmpUC As New FileSelectUC(account)
            tmpUC.Top = 50 * GV.AccountLIS.IndexOf(account)
            tmpUC.Parent = Me.MainPanel
        Next
    End Sub
#End Region

#End Region

End Class