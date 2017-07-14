Imports System.Data.SqlClient
Imports System.Data
Public Class Login

    Private Sub btnentrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnentrar.Click
        Dim usu As String = TXTUSUARIO.Text
        Dim cont As String = TXTCLAVE.Text
        If usu = "" Or cont = "" Then
            MsgBox("Asegúrese de llenar sus Datos Correctamente")
        Else
            Dim cmd As New SqlCommand("InicioSesion", conexion)
            Try
                abrir()
                cmd.CommandType = 4
                With cmd.Parameters
                    .AddWithValue("@Usu", usu)
                    .AddWithValue("@Contra", cont)
                    .Add("@msj", SqlDbType.VarChar, 60).Direction = 2
                    cmd.ExecuteNonQuery()
                End With
                usuario = TXTUSUARIO.Text
                Dim msj As String = cmd.Parameters("@msj").Value
                MsgBox(msj, vbInformation)

                If msj = "Datos Incorrectos" Then
                    TXTCLAVE.Clear()
                    TXTUSUARIO.Focus()
                Else
                    Dim f As New MenuPrincipal
                    Me.Hide()
                    f.ShowDialog()
                End If
               
            Catch ex As Exception : MsgBox(ex.Message)
            End Try
            conexion.Close()
        End If

    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Dim confirma = MsgBox("Está seguro que Desea Salir?", vbYesNo + vbExclamation, "Atención!!")
        If confirma = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub TXTCLAVE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLAVE.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TXTUSUARIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTUSUARIO.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class
