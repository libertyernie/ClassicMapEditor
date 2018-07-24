Imports ClassicMapLib

Public Class MappingControl
    Private ReadOnly _mapping As ButtonMappingHeader

    Public Event ClassicControllerButtonChanged As EventHandler

    Sub New(mapping As ButtonMappingHeader)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For Each value In [Enum].GetValues(GetType(ClassicControllerButton))
            ClassicControllerDropDownList.Items.Add(value)
        Next

        _mapping = mapping

        ClassicControllerDropDownList.SelectedItem = _mapping.ClassicControllerButton
        Label2.Text = _mapping.GetAdditionalDataAsHexString

    End Sub

    Private Sub ClassicControllerDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClassicControllerDropDownList.SelectedIndexChanged
        _mapping.ClassicControllerButton = CType(ClassicControllerDropDownList.SelectedItem, ClassicControllerButton)
        RaiseEvent ClassicControllerButtonChanged(Me, New EventArgs)
    End Sub
End Class
