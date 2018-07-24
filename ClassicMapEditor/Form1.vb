Imports System.IO
Imports ClassicMapLib

Public Class Form1
    Private _code As ButtonMappingCode

    Private Sub SetCode(code As ButtonMappingCode)
        _code = code

        UpdateTextBox()

        FlowLayoutPanel1.Controls.Clear()

        For Each mapping In _code.GetButtonMappings
            Dim control = New MappingControl(mapping)
            AddHandler control.ClassicControllerButtonChanged, AddressOf UpdateTextBox
            FlowLayoutPanel1.Controls.Add(control)
        Next
    End Sub

    Private Sub UpdateTextBox()
        TextBox1.Text = _code.ToString
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim data = File.ReadAllBytes(OpenFileDialog1.FileName)
            SetCode(New ButtonMappingCode("Imported from GCT", data))
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If _code Is Nothing OrElse _code.ToString <> TextBox1.Text Then
            If TextBox1.Text.Contains(vbCrLf) Then
                Dim name = TextBox1.Text.Substring(0, TextBox1.Text.IndexOf(vbCrLf)).Trim
                Dim code = TextBox1.Text.Substring(TextBox1.Text.IndexOf(vbCrLf)).Trim
                Dim newCode = New ButtonMappingCode(name, code)
                If newCode.ToString.Trim = TextBox1.Text.Trim Then
                    SetCode(newCode)
                End If
            End If
        End If
    End Sub
End Class
