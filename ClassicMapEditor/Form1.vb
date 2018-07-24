Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports ClassicMapLib

Public Class Form1
    Private _code As ButtonMappingCode

    Private Sub SetCode(code As ButtonMappingCode)
        _code = code


        FlowLayoutPanel1.Controls.Clear()

        If _code IsNot Nothing Then
            UpdateTextBox()

            For Each mapping In _code.GetButtonMappings
                If TypeOf mapping Is WiiRemoteButtonMapping Then
                    Dim control = New WiiRemoteMappingControl(mapping)
                    AddHandler control.ClassicControllerButtonChanged, AddressOf UpdateTextBox
                    AddHandler control.WiiRemoteButtonChanged, AddressOf UpdateTextBox
                    FlowLayoutPanel1.Controls.Add(control)
                Else
                    Dim control = New MappingControl(mapping)
                    AddHandler control.ClassicControllerButtonChanged, AddressOf UpdateTextBox
                    FlowLayoutPanel1.Controls.Add(control)
                End If
            Next
        End If
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

    Private GCTLine As New Regex("^[0-9A-Fa-f]{8} [0-9A-Fa-f]{8}$")

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If _code Is Nothing OrElse _code.ToString <> TextBox1.Text Then
            If TextBox1.Text.Contains(vbCrLf) Then
                Dim lines = TextBox1.Text.TrimEnd.Split(New String() {vbCrLf}, StringSplitOptions.None)

                Dim name = lines.First
                Dim code As New StringBuilder
                For Each line In lines.Skip(1)
                    If Not GCTLine.IsMatch(line) Then
                        SetCode(Nothing)
                        Exit Sub
                    End If
                    code.AppendLine(line)
                Next

                Dim newCode = New ButtonMappingCode(name, code.ToString)
                SetCode(newCode)
            End If
        End If
    End Sub
End Class
