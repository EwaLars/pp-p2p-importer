<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsWindow
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBoxPP = New System.Windows.Forms.GroupBox()
        Me.ButtonPP = New System.Windows.Forms.Button()
        Me.TextBoxPP = New System.Windows.Forms.TextBox()
        Me.LabelPP = New System.Windows.Forms.Label()
        Me.GroupBoxAccounts = New System.Windows.Forms.GroupBox()
        Me.AccountsDGV = New System.Windows.Forms.DataGridView()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.AccountP2pPlatform = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.AccountName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBoxPP.SuspendLayout()
        Me.GroupBoxAccounts.SuspendLayout()
        CType(Me.AccountsDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxPP
        '
        Me.GroupBoxPP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxPP.Controls.Add(Me.ButtonPP)
        Me.GroupBoxPP.Controls.Add(Me.TextBoxPP)
        Me.GroupBoxPP.Controls.Add(Me.LabelPP)
        Me.GroupBoxPP.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxPP.Name = "GroupBoxPP"
        Me.GroupBoxPP.Size = New System.Drawing.Size(308, 100)
        Me.GroupBoxPP.TabIndex = 0
        Me.GroupBoxPP.TabStop = False
        Me.GroupBoxPP.Text = "Portfolio Performance"
        '
        'ButtonPP
        '
        Me.ButtonPP.Location = New System.Drawing.Point(10, 62)
        Me.ButtonPP.Name = "ButtonPP"
        Me.ButtonPP.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPP.TabIndex = 2
        Me.ButtonPP.Text = "Browse..."
        Me.ButtonPP.UseVisualStyleBackColor = True
        '
        'TextBoxPP
        '
        Me.TextBoxPP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxPP.Location = New System.Drawing.Point(10, 36)
        Me.TextBoxPP.Name = "TextBoxPP"
        Me.TextBoxPP.ReadOnly = True
        Me.TextBoxPP.Size = New System.Drawing.Size(292, 20)
        Me.TextBoxPP.TabIndex = 1
        '
        'LabelPP
        '
        Me.LabelPP.AutoSize = True
        Me.LabelPP.Location = New System.Drawing.Point(7, 20)
        Me.LabelPP.Name = "LabelPP"
        Me.LabelPP.Size = New System.Drawing.Size(192, 13)
        Me.LabelPP.TabIndex = 0
        Me.LabelPP.Text = "Path to Portfolio-Performance XML-File:"
        '
        'GroupBoxAccounts
        '
        Me.GroupBoxAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxAccounts.Controls.Add(Me.AccountsDGV)
        Me.GroupBoxAccounts.Location = New System.Drawing.Point(12, 118)
        Me.GroupBoxAccounts.Name = "GroupBoxAccounts"
        Me.GroupBoxAccounts.Size = New System.Drawing.Size(308, 245)
        Me.GroupBoxAccounts.TabIndex = 0
        Me.GroupBoxAccounts.TabStop = False
        Me.GroupBoxAccounts.Text = "P2P-Accounts"
        '
        'AccountsDGV
        '
        Me.AccountsDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AccountsDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AccountP2pPlatform, Me.AccountName})
        Me.AccountsDGV.Location = New System.Drawing.Point(6, 20)
        Me.AccountsDGV.Name = "AccountsDGV"
        Me.AccountsDGV.RowHeadersVisible = False
        Me.AccountsDGV.Size = New System.Drawing.Size(296, 219)
        Me.AccountsDGV.TabIndex = 0
        '
        'ButtonOk
        '
        Me.ButtonOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOk.Location = New System.Drawing.Point(245, 374)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOk.TabIndex = 1
        Me.ButtonOk.Text = "Ok"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(164, 374)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'AccountP2pPlatform
        '
        Me.AccountP2pPlatform.HeaderText = "P2P-Platform"
        Me.AccountP2pPlatform.Name = "AccountP2pPlatform"
        '
        'AccountName
        '
        Me.AccountName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.AccountName.HeaderText = "Name in PP"
        Me.AccountName.Name = "AccountName"
        '
        'SettingsWindow
        '
        Me.AcceptButton = Me.ButtonOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(332, 409)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOk)
        Me.Controls.Add(Me.GroupBoxAccounts)
        Me.Controls.Add(Me.GroupBoxPP)
        Me.Name = "SettingsWindow"
        Me.Text = "Settings"
        Me.GroupBoxPP.ResumeLayout(False)
        Me.GroupBoxPP.PerformLayout()
        Me.GroupBoxAccounts.ResumeLayout(False)
        CType(Me.AccountsDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBoxPP As GroupBox
    Friend WithEvents GroupBoxAccounts As GroupBox
    Friend WithEvents ButtonOk As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonPP As Button
    Friend WithEvents TextBoxPP As TextBox
    Friend WithEvents LabelPP As Label
    Friend WithEvents AccountsDGV As DataGridView
    Friend WithEvents AccountP2pPlatform As DataGridViewComboBoxColumn
    Friend WithEvents AccountName As DataGridViewTextBoxColumn
End Class
