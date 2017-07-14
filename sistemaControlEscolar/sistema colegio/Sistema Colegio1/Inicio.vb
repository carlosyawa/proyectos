Public Class Inicio

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Cada segundo la barra de progreso debe aumentar en 20
        If ProgressBar1.Value < 100 Then
            'vamos aclarando la opacidad del formulario
            Me.Opacity = Me.Opacity + 0.1
            ProgressBar1.Value = ProgressBar1.Value + 10
            lblmensaje.Text = "CARGANDO EL SISTEMA " & ProgressBar1.Value & "%"
        Else
            Timer1.Enabled = False
            Dim f As New Login
            Me.Hide()
            f.ShowDialog()
            End
        End If
    End Sub

   
    Private Sub Inicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub
End Class