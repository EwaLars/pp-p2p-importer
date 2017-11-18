Public Class FileSelectUC

#Region " Declaration "
    Private _Account As PlatformAccounts
#End Region

#Region " Properties "
    Public ReadOnly Property Account As PlatformAccounts
        Get
            Return _Account
        End Get
    End Property
    Public ReadOnly Property Path As String
        Get
            Return Me.TextBoxFilePath.Text
        End Get
    End Property
#End Region

#Region " Constructor "
    Public Sub New(Account As PlatformAccounts)
        InitializeComponent()
        '>>>
        _Account = Account
        Me.GroupBoxFilePath.Text = Account.Name & " (" & Fkt.UppercaseFirstLetter(Account.Plattform.ToString) & ")"
    End Sub
#End Region

#Region " Private Sub ButtonBrowse_Click "
    Private Sub ButtonBrowse_Click(sender As Object, e As EventArgs) Handles ButtonBrowse.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Excel|*.xlsx;*.xls|CSV|*.csv|All files|*.*"
        If ofd.ShowDialog = DialogResult.OK Then
            Me.TextBoxFilePath.Text = ofd.FileName
        End If
    End Sub
#End Region

End Class
