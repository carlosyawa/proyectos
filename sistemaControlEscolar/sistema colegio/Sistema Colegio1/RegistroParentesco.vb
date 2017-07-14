Imports System.Data
Imports System.Data.SqlClient
Public Class Parentesco

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Button1.Enabled = True
            CbxParentesco.Enabled = True
            TxtCodAlumno.Enabled = True
            TxtCodApoderado.Enabled = True
            TxtCodAlumno.Focus()
        Else
            TxtCodAlumno.Enabled = False
            TxtCodApoderado.Enabled = False
            CbxParentesco.Enabled = False
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Parentesco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListarParentesco()
        CbxParentesco.SelectedIndex = 0
        Me.Location = New Point(212, 72)
        TxtCodAlumno.Text = codal
        TxtCodApoderado.Text = codap
    End Sub

    Sub ListarParentesco()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("SELECT * FROM PARENTESCO", conexion)
            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception : MsgBox(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cmd As SqlCommand
        If TxtCodAlumno.Text <> "" And TxtCodApoderado.Text <> "" Then
            Try
                abrir()
                cmd = New SqlCommand("REGISTRAR_PARENTESCO", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@PARENTESCO", CbxParentesco.SelectedItem)
                cmd.Parameters.AddWithValue("@DNI_ALUMNO", TxtCodAlumno.Text)
                cmd.Parameters.AddWithValue("@DNI_APODERADO", TxtCodApoderado.Text)
                cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()

                Dim MENSAJE As String = cmd.Parameters("@MENSAJE").Value.ToString
                MessageBox.Show(MENSAJE, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ListarParentesco()
                LIMPIAR()
            Catch ex As Exception : MsgBox(ex.Message)
            End Try
            Cerrar()
        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub LIMPIAR()
        TxtCodAlumno.Clear()
        TxtCodApoderado.Clear()
        CbxParentesco.SelectedIndex = 0
        TxtCodAlumno.Focus()
    End Sub

    Private Sub TxtCodAlumno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodAlumno.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TxtCodApoderado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodApoderado.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class