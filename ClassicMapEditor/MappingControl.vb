Imports ClassicMapLib

Public Class MappingControl
    Private Sub MappingControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each value In [Enum].GetValues(GetType(ClassicControllerButton))
            ClassicControllerDropDownList.Items.Add(value)
        Next
    End Sub
End Class
