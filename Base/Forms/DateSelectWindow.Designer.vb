<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DateSelectWindow
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
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.Label = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'DateTimePicker
        '
        Me.DateTimePicker.Location = New System.Drawing.Point(17, 47)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker.TabIndex = 0
        '
        'ButtonOk
        '
        Me.ButtonOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOk.Location = New System.Drawing.Point(139, 80)
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
        Me.ButtonCancel.Location = New System.Drawing.Point(58, 80)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label.Location = New System.Drawing.Point(13, 13)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(208, 20)
        Me.Label.TabIndex = 2
        Me.Label.Text = "Export statements since:"
        '
        'DateSelectWindow
        '
        Me.AcceptButton = Me.ButtonOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(226, 115)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOk)
        Me.Controls.Add(Me.DateTimePicker)
        Me.Name = "DateSelectWindow"
        Me.Text = "DateSelectWindow"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonOk As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents Label As Label
    Public WithEvents DateTimePicker As DateTimePicker
End Class
