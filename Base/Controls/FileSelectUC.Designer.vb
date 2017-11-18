<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileSelectUC
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.GroupBoxFilePath = New System.Windows.Forms.GroupBox()
        Me.ButtonBrowse = New System.Windows.Forms.Button()
        Me.TextBoxFilePath = New System.Windows.Forms.TextBox()
        Me.LabelFilePath = New System.Windows.Forms.Label()
        Me.GroupBoxFilePath.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxFilePath
        '
        Me.GroupBoxFilePath.Controls.Add(Me.ButtonBrowse)
        Me.GroupBoxFilePath.Controls.Add(Me.TextBoxFilePath)
        Me.GroupBoxFilePath.Controls.Add(Me.LabelFilePath)
        Me.GroupBoxFilePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxFilePath.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxFilePath.Name = "GroupBoxFilePath"
        Me.GroupBoxFilePath.Size = New System.Drawing.Size(500, 50)
        Me.GroupBoxFilePath.TabIndex = 0
        Me.GroupBoxFilePath.TabStop = False
        Me.GroupBoxFilePath.Text = "Name ( Platform)"
        '
        'ButtonBrowse
        '
        Me.ButtonBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonBrowse.Location = New System.Drawing.Point(416, 17)
        Me.ButtonBrowse.Name = "ButtonBrowse"
        Me.ButtonBrowse.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBrowse.TabIndex = 2
        Me.ButtonBrowse.Text = "Browse"
        Me.ButtonBrowse.UseVisualStyleBackColor = True
        '
        'TextBoxFilePath
        '
        Me.TextBoxFilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxFilePath.Location = New System.Drawing.Point(59, 19)
        Me.TextBoxFilePath.Name = "TextBoxFilePath"
        Me.TextBoxFilePath.ReadOnly = True
        Me.TextBoxFilePath.Size = New System.Drawing.Size(351, 20)
        Me.TextBoxFilePath.TabIndex = 1
        '
        'LabelFilePath
        '
        Me.LabelFilePath.AutoSize = True
        Me.LabelFilePath.Location = New System.Drawing.Point(6, 22)
        Me.LabelFilePath.Name = "LabelFilePath"
        Me.LabelFilePath.Size = New System.Drawing.Size(47, 13)
        Me.LabelFilePath.TabIndex = 0
        Me.LabelFilePath.Text = "Filepath:"
        '
        'FileSelectUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBoxFilePath)
        Me.Name = "FileSelectUC"
        Me.Size = New System.Drawing.Size(500, 50)
        Me.GroupBoxFilePath.ResumeLayout(False)
        Me.GroupBoxFilePath.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBoxFilePath As GroupBox
    Friend WithEvents ButtonBrowse As Button
    Friend WithEvents TextBoxFilePath As TextBox
    Friend WithEvents LabelFilePath As Label
End Class
