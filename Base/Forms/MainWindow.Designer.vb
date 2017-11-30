<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.ButtonProcess = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.PathToXml = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StripStatusLabelVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.LabelNoAccount = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonFairrCSV = New System.Windows.Forms.ToolStripButton()
        Me.ButtonSettings = New System.Windows.Forms.ToolStripButton()
        Me.ButtonExit = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonProcess
        '
        Me.ButtonProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonProcess.Location = New System.Drawing.Point(437, 150)
        Me.ButtonProcess.Name = "ButtonProcess"
        Me.ButtonProcess.Size = New System.Drawing.Size(75, 23)
        Me.ButtonProcess.TabIndex = 0
        Me.ButtonProcess.Text = "Process"
        Me.ButtonProcess.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PathToXml, Me.StripStatusLabelVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 178)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(541, 24)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'PathToXml
        '
        Me.PathToXml.AutoSize = False
        Me.PathToXml.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.PathToXml.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.PathToXml.Name = "PathToXml"
        Me.PathToXml.Size = New System.Drawing.Size(169, 19)
        Me.PathToXml.Text = "PathToXML"
        Me.PathToXml.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StripStatusLabelVersion
        '
        Me.StripStatusLabelVersion.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.StripStatusLabelVersion.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.StripStatusLabelVersion.Name = "StripStatusLabelVersion"
        Me.StripStatusLabelVersion.Size = New System.Drawing.Size(89, 19)
        Me.StripStatusLabelVersion.Text = "v 1.0.1234.1234"
        '
        'ButtonClose
        '
        Me.ButtonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClose.Location = New System.Drawing.Point(356, 150)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 0
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'MainPanel
        '
        Me.MainPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainPanel.AutoScroll = True
        Me.MainPanel.Controls.Add(Me.LabelNoAccount)
        Me.MainPanel.Location = New System.Drawing.Point(12, 43)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(517, 105)
        Me.MainPanel.TabIndex = 3
        '
        'LabelNoAccount
        '
        Me.LabelNoAccount.BackColor = System.Drawing.SystemColors.Control
        Me.LabelNoAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNoAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNoAccount.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.LabelNoAccount.Location = New System.Drawing.Point(0, 0)
        Me.LabelNoAccount.Name = "LabelNoAccount"
        Me.LabelNoAccount.Size = New System.Drawing.Size(517, 105)
        Me.LabelNoAccount.TabIndex = 0
        Me.LabelNoAccount.Text = "No account configured" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Plaese configure accounts"
        Me.LabelNoAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(200, 30)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonFairrCSV, Me.ButtonSettings, Me.ButtonExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(541, 40)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonFairrCSV
        '
        Me.ButtonFairrCSV.AutoSize = False
        Me.ButtonFairrCSV.Image = Global.Base.My.Resources.Resources.Logo_fairr_de_CMYK
        Me.ButtonFairrCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonFairrCSV.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonFairrCSV.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonFairrCSV.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.ButtonFairrCSV.Name = "ButtonFairrCSV"
        Me.ButtonFairrCSV.Size = New System.Drawing.Size(129, 37)
        Me.ButtonFairrCSV.Text = "Create Fairr CSV"
        Me.ButtonFairrCSV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonSettings
        '
        Me.ButtonSettings.Image = Global.Base.My.Resources.Resources.Settings
        Me.ButtonSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSettings.Name = "ButtonSettings"
        Me.ButtonSettings.Size = New System.Drawing.Size(83, 37)
        Me.ButtonSettings.Text = "Settings"
        '
        'ButtonExit
        '
        Me.ButtonExit.Image = Global.Base.My.Resources.Resources._Exit
        Me.ButtonExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(59, 37)
        Me.ButtonExit.Text = "Exit"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.Base.My.Resources.Resources.btn_donate_SM
        Me.PictureBox1.Location = New System.Drawing.Point(454, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(87, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 202)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.ButtonProcess)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(557, 440)
        Me.MinimumSize = New System.Drawing.Size(557, 190)
        Me.Name = "MainWindow"
        Me.Text = "PPI - Portfolio Performance Importer"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MainPanel.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonProcess As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents PathToXml As ToolStripStatusLabel
    Friend WithEvents ButtonClose As Button
    Friend WithEvents MainPanel As Panel
    Friend WithEvents LabelNoAccount As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonFairrCSV As ToolStripButton
    Friend WithEvents ButtonSettings As ToolStripButton
    Friend WithEvents ButtonExit As ToolStripButton
    Friend WithEvents StripStatusLabelVersion As ToolStripStatusLabel
    Friend WithEvents PictureBox1 As PictureBox
End Class
