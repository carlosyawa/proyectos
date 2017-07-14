Public Class Opcion_Notas

    Private Sub rbncons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbncons.CheckedChanged, rbnrg.CheckedChanged
        GroupBox2.Visible = True
        rbncons.Checked = False
        Me.Height = 229
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If rbnreg.Checked = True Then
            Dim r As New RegistroNotas
            r.ShowDialog()
        ElseIf rbntr.Checked = True Then
            Dim r As New Reporte_de_Detalle_de_Notas
            r.ShowDialog()
        ElseIf rbnrg.Checked = True Then
            Dim r As New PromedioAumno
            r.ShowDialog()

        End If
    End Sub

    Private Sub Opcion_Notas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(212, 72)
    End Sub

    Private Sub rbnreg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnreg.CheckedChanged
        GroupBox2.Visible = False
        Me.Height = 141

    End Sub
End Class