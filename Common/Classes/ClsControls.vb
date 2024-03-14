Public Class ClsControls

    Public Sub ClearControls(ByRef colForm As Collection)
        Try
            Dim objControl As Control
            Dim objCheckBox As CheckBox
            Dim objDateTimePicker As DateTimePicker
            Dim objRadioButton As RadioButton
            Dim objListView As ListView

            For Each objControl In colForm
                If TypeOf (objControl) Is CheckBox Then
                    objCheckBox = objControl
                    objCheckBox.CheckState = CInt(objCheckBox.Tag)
                ElseIf TypeOf (objControl) Is RadioButton Then
                    objRadioButton = objControl
                    objRadioButton.Checked = False
                ElseIf TypeOf (objControl) Is DateTimePicker Then
                    objDateTimePicker = objControl
                    objDateTimePicker.Value = Now()
                    If objDateTimePicker.ShowCheckBox = True Then
                        If CInt(objDateTimePicker.Tag) = 0 Then
                            objDateTimePicker.Checked = False
                        Else
                            objDateTimePicker.Checked = True
                        End If
                    End If
                ElseIf TypeOf (objControl) Is ListView Then
                    objListView = objControl
                    objListView.Items.Clear()
                Else
                    objControl.Text = ""
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class
