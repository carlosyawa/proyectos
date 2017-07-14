Imports System.Data
Imports System.Data.SqlClient

Public Class FrmDocumentacón
    Private Sub FrmDocumentacón_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargadoucmentos()
    End Sub

    Sub cargadoucmentos()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("BUSCAR_DOCUMENTO", conexion)
            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception : MsgBox(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TxtDni.Text = DataGridView1.CurrentRow.Cells(0).Value
        Dim P As Char = DataGridView1.CurrentRow.Cells(3).Value
        If P = "N" Then
            CheckBox1.Checked = False
        Else
            CheckBox1.Checked = True
        End If

        Dim C As Char = DataGridView1.CurrentRow.Cells(4).Value
        If C = "N" Then
            CheckBox2.Checked = False
        Else
            CheckBox2.Checked = True
        End If
     
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cmd As SqlCommand
        Try
            abrir()
            cmd = New SqlCommand("ACTUALIZAR_DOCUMENTOS", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Partida", If(CheckBox1.Checked = True, "S", "N"))
            cmd.Parameters.AddWithValue("@Certificado", If(CheckBox2.Checked = True, "S", "N"))
            cmd.Parameters.AddWithValue("@Dni_Alumno", TxtDni.Text)
            cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
            cmd.ExecuteNonQuery()
            Dim s As String = cmd.Parameters("@MENSAJE").Value.ToString
            MessageBox.Show(s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        End Try
        Cerrar()
        cargadoucmentos()
        limpiar()

    End Sub

    Private Sub limpiar()
        TxtDni.Clear()
        CheckBox1.Checked = False
        CheckBox2.Checked = False

    End Sub

    Private Sub TxtDni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDni.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class