Imports System.Data
Imports System.Data.SqlClient

Public Class Reporte_De_Apoderados

    Private Sub Reporte_De_Apoderados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarApoderados()
        Me.Location = New Point(212, 72)
    End Sub

    Sub CargarApoderados()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("CONSULTA_PARENTESCO_ALUMNO", conexion)
            DA.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub txtDni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDni.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtDni.Enabled = True
            Button1.Enabled = True
            txtDni.Focus()
        Else
            txtDni.Enabled = False
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        If txtDni.Text.Trim <> "" Then
            Try
                abrir()
                da = New SqlDataAdapter("CONSULTA_PARENTESCO_ALUMNO2", conexion)
                da.SelectCommand.CommandType = 4
                da.SelectCommand.Parameters.AddWithValue("@DNI", txtDni.Text)
                da.Fill(dt)
                DataGridView1.DataSource = dt
            Catch ex As Exception : MsgBox(ex.Message)
            End Try
            Cerrar()
            txtDni.Clear()
            txtDni.Focus()
        Else
            MessageBox.Show("Por Favor Digite Codigo ...!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDni.Focus()
        End If
    End Sub
End Class