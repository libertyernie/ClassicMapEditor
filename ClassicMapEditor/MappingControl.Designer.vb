<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MappingControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ClassicControllerDropDownList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ClassicControllerDropDownList
        '
        Me.ClassicControllerDropDownList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ClassicControllerDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ClassicControllerDropDownList.FormattingEnabled = True
        Me.ClassicControllerDropDownList.Location = New System.Drawing.Point(0, 0)
        Me.ClassicControllerDropDownList.Name = "ClassicControllerDropDownList"
        Me.ClassicControllerDropDownList.Size = New System.Drawing.Size(121, 21)
        Me.ClassicControllerDropDownList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(127, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "→"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoEllipsis = True
        Me.Label2.Location = New System.Drawing.Point(151, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MappingControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ClassicControllerDropDownList)
        Me.Name = "MappingControl"
        Me.Size = New System.Drawing.Size(272, 21)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ClassicControllerDropDownList As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
