<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WiiRemoteMappingControl
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ClassicControllerDropDownList = New System.Windows.Forms.ComboBox()
        Me.WiiRemoteDropDownList = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(127, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "→"
        '
        'ClassicControllerDropDownList
        '
        Me.ClassicControllerDropDownList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ClassicControllerDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ClassicControllerDropDownList.FormattingEnabled = True
        Me.ClassicControllerDropDownList.Location = New System.Drawing.Point(0, 0)
        Me.ClassicControllerDropDownList.Name = "ClassicControllerDropDownList"
        Me.ClassicControllerDropDownList.Size = New System.Drawing.Size(121, 21)
        Me.ClassicControllerDropDownList.TabIndex = 2
        '
        'WiiRemoteDropDownList
        '
        Me.WiiRemoteDropDownList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.WiiRemoteDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WiiRemoteDropDownList.FormattingEnabled = True
        Me.WiiRemoteDropDownList.Location = New System.Drawing.Point(151, 0)
        Me.WiiRemoteDropDownList.Name = "WiiRemoteDropDownList"
        Me.WiiRemoteDropDownList.Size = New System.Drawing.Size(121, 21)
        Me.WiiRemoteDropDownList.TabIndex = 4
        '
        'WiiRemoteMappingControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.WiiRemoteDropDownList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ClassicControllerDropDownList)
        Me.Name = "WiiRemoteMappingControl"
        Me.Size = New System.Drawing.Size(272, 21)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ClassicControllerDropDownList As ComboBox
    Friend WithEvents WiiRemoteDropDownList As ComboBox
End Class
