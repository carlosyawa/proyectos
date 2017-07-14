Imports System.Data
Imports System.Data.SqlClient

Public Class Horario

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtSeccion.Enabled = True
            txtDniDocente.Enabled = True
            CbxCursos.Enabled = True
            CbxDia.Enabled = True
            btnregistrar.Enabled = True
            CbxAula.Enabled = True
            txtHoraInicio.Enabled = True
            txtHoraFin.Enabled = True
        Else
            txtSeccion.Enabled = False
            CbxDia.Enabled = False
            txtDniDocente.Enabled = False
            btnregistrar.Enabled = False
            CbxCursos.Enabled = False
            CbxAula.Enabled = False
            txtHoraInicio.Enabled = False
            txtHoraFin.Enabled = False
        End If
    End Sub

    Private Sub Horario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSeccion.CharacterCasing = CharacterCasing.Upper
        'CargarAulas()
        CargarCursos()
        CbxDia.SelectedIndex = 0
        CbxAula.SelectedIndex = 0
        Listar()
        Me.Location = New Point(212, 72)
    End Sub

    Private Sub btnregistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnregistrar.Click
        Dim cmd As SqlCommand
        Try
            abrir()
            cmd = New SqlCommand("REGISTRAR_HORARIO", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@DIA", CbxDia.SelectedItem)
            cmd.Parameters.AddWithValue("@HORA_INICIO", txtHoraInicio.Text)
            cmd.Parameters.AddWithValue("@HORA_FIN", txtHoraFin.Text)
            cmd.Parameters.AddWithValue("@SECCION", txtSeccion.Text)
            cmd.Parameters.AddWithValue("@ID_AULA", CbxAula.SelectedIndex)
            cmd.Parameters.AddWithValue("@DNI_DOCENTE", txtDniDocente.Text)
            cmd.Parameters.AddWithValue("@ID_CURSO", CbxCursos.SelectedValue)
            cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
            cmd.ExecuteNonQuery()
            Dim MENSAJE As String = cmd.Parameters("@MENSAJE").Value.ToString
            MessageBox.Show(MENSAJE, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            DataGridView1.Rows.Clear()
            Listar()
            Limpiar()
        Catch ex As Exception : MsgBox(ex.Message)
        End Try
        Cerrar()
    End Sub

    Sub CargarCursos()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("SELECT * FROM CURSO", conexion)
            DA.Fill(DT)
            CbxCursos.DisplayMember = "Nombres"
            CbxCursos.ValueMember = "Cod_Curso"
            CbxCursos.DataSource = DT
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub

    Sub Listar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("SELECT * FROM HORARIO", conexion)
            da.Fill(dt)
            ' DataGridView1.DataSource = dt
            For i = 0 To dt.Rows.Count - 1
                DataGridView1.Rows.Add(dt.Rows(i).Item(0))
                DataGridView1.Rows(i).Cells(0).Value = dt.Rows(i)(0) & ""
                DataGridView1.Rows(i).Cells(1).Value = dt.Rows(i)(1)
                DataGridView1.Rows(i).Cells(2).Value = dt.Rows(i)(2)
                DataGridView1.Rows(i).Cells(3).Value = dt.Rows(i)(3) & ""
                DataGridView1.Rows(i).Cells(4).Value = dt.Rows(i)(4) & ""
                DataGridView1.Rows(i).Cells(5).Value = dt.Rows(i)(5) & ""
                DataGridView1.Rows(i).Cells(6).Value = dt.Rows(i)(6) & ""
                ', DateFormat.ShortTime
            Next
        Catch ex As Exception : MsgBox(ex.Message)
            Cerrar()
            End Try
    End Sub

    Sub Limpiar()
        txtDniDocente.Clear()
        txtSeccion.Clear()
        'Call CargarAulas()
        Call CargarCursos()
        CbxDia.SelectedIndex = 0
        txtHoraInicio.Clear()
        txtHoraFin.Clear()
        CbxAula.SelectedIndex = 0
        txtDniDocente.Focus()
    End Sub

    Private Sub txtDniDocente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDniDocente.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled -= False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub CbxAula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxAula.SelectedIndexChanged
        If CbxAula.SelectedIndex = 0 Then
            txtSeccion.Text = ""
        Else
            txtSeccion.Text = "A"
        End If
    End Sub
End Class