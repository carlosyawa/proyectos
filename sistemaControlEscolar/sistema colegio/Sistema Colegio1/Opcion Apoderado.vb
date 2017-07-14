Public Class Opcion_Apoderado
    Private Sub btnir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnir.Click
        If rbnreg.Checked = True Then
            Dim r As New RegApod
            r.ShowDialog()
        ElseIf rbncons.Checked = True Then
            Dim r As New Reporte_De_Apoderados
            r.ShowDialog()

        End If
    End Sub

    Private Sub Opcion_Apoderado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(212, 72)
    End Sub

End Class