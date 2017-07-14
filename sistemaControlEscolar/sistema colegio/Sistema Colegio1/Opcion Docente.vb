Public Class Opcion_Docente

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If rbnreg.Checked = True Then
            Dim r As New RegDoce
            r.ShowDialog()
        ElseIf rbnhorario.Checked = True Then
            Dim r As New ConsultaHorariosDocentes
            r.ShowDialog()
        End If
    End Sub

    Private Sub Opcion_Docente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(212, 72)
    End Sub
End Class