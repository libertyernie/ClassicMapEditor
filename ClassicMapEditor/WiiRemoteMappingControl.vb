Imports ClassicMapLib

Public Class WiiRemoteMappingControl
    Private Sub WiiRemoteMappingControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each value In [Enum].GetValues(GetType(ClassicControllerButton))
            ClassicControllerDropDownList.Items.Add(value)
        Next
        For Each value In [Enum].GetValues(GetType(WiiRemoteButton))
            WiiRemoteDropDownList.Items.Add(value)
        Next
    End Sub
End Class
