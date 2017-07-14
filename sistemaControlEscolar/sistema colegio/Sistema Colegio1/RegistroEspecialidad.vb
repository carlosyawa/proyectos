Imports System.Data
Imports System.Data.SqlClient

Public Class Especialidad

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Listar()
        Me.Location = New Point(212, 72)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtEspecialidad.Enabled = True
            btnRegistrar.Enabled = True
            'Button2.Enabled = True
            txtEspecialidad.Focus()
        Else
            txtEspecialidad.Enabled = False
            btnRegistrar.Enabled = False
            'Button2.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        Dim cmd As SqlCommand
        If txtEspecialidad.Text <> "" Then
            Try
                abrir()
                cmd = New SqlCommand("REGISTRAR_ESPECIALIDAD", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@ESPECIALIDAD", txtEspecialidad.Text)
                cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()
                Dim MENSAJE As String = cmd.Parameters("@MENSAJE").Value.ToString
                MessageBox.Show(MENSAJE, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Listar()
                LIMPIAR()
            Catch ex As Exception : MsgBox(ex.Message)
            End Try
            Cerrar()
        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub Listar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("SELECT * FROM ESPECIALIDAD", conexion)
            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub txtEspecialidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEspecialidad.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar <> Chr(32) Then
            e.Handled = True
        End If
    End Sub

    Sub LIMPIAR()
        txtEspecialidad.Clear()
        txtEspecialidad.Focus()
    End Sub

    Private Sub txtEspecialidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEspecialidad.TextChanged
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter("BuscarEspec", conexion)
        Try
            abrir()
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@letra", txtEspecialidad.Text)
            da.Fill(dt)
            DataGridView1.DataSource = dt

        Catch ex As Exception

        End Try
    End Sub

End Class