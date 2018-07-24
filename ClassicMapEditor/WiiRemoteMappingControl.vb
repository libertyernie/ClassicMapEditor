Imports ClassicMapLib

Public Class WiiRemoteMappingControl
    Private ReadOnly _mapping As WiiRemoteButtonMapping

    Public Event ClassicControllerButtonChanged As EventHandler
    Public Event WiiRemoteButtonChanged As EventHandler

    Sub New(mapping As WiiRemoteButtonMapping)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For Each value In [Enum].GetValues(GetType(ClassicControllerButton))
            ClassicControllerDropDownList.Items.Add(value)
        Next
        For Each value In [Enum].GetValues(GetType(WiiRemoteButton))
            WiiRemoteDropDownList.Items.Add(value)
        Next

        _mapping = mapping

        ClassicControllerDropDownList.SelectedItem = _mapping.ClassicControllerButton
        WiiRemoteDropDownList.SelectedItem = _mapping.WiiRemoteButton

    End Sub

    Private Sub ClassicControllerDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClassicControllerDropDownList.SelectedIndexChanged
        _mapping.ClassicControllerButton = CType(ClassicControllerDropDownList.SelectedItem, ClassicControllerButton)
        RaiseEvent ClassicControllerButtonChanged(Me, New EventArgs)
    End Sub

    Private Sub WiiRemoteDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WiiRemoteDropDownList.SelectedIndexChanged
        _mapping.WiiRemoteButton = CType(WiiRemoteDropDownList.SelectedItem, WiiRemoteButton)
        RaiseEvent WiiRemoteButtonChanged(Me, New EventArgs)
    End Sub
End Class
