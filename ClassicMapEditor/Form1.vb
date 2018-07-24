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

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        If _code Is Nothing Then
            Return
        End If

        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim data = _code.ExportToGCT()
            File.WriteAllBytes(SaveFileDialog1.FileName, data)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Classic Controller Code Button Mapping Editor
(C) 2018 libertyernie
https://github.com/libertyernie/MappingCodeEditor

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.")
    End Sub

    Private GCTLine As New Regex("^[0-9A-Fa-f]{8} [0-9A-Fa-f]{8}$")

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If _code Is Nothing OrElse _code.ToString <> TextBox1.Text Then
            Dim lines = TextBox1.Text.TrimEnd.Split(New String() {vbCrLf}, StringSplitOptions.None)

            Dim name = lines.First
            Dim code As New StringBuilder
            For Each line In lines.Skip(1)
                If Not GCTLine.IsMatch(line) Then
                    SetCode(Nothing)
                    Return
                End If
                code.AppendLine(line)
            Next

            Dim newCode = New ButtonMappingCode(name, code.ToString)
            SetCode(newCode)
        End If
    End Sub
End Class
