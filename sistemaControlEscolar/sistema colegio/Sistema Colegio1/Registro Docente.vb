Imports System.Data
Imports System.Data.SqlClient

Public Class RegDoce

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            Label5.Visible = True
            TextBox10.Visible = True
            TextBox10.Text = ""
            TextBox10.Focus()
        Else
            Label5.Visible = False
            TextBox10.Visible = False
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            Label6.Visible = True
            TextBox9.Visible = True
            TextBox9.Text = ""
            TextBox9.Focus()
        Else
            Label6.Visible = False
            TextBox9.Visible = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Button1.Enabled = True
            Button2.Enabled = True
            txtDni.Enabled = True
            txtNombres.Enabled = True
            txtApellidos.Enabled = True
            TxtTelefono.Enabled = True
            TxtEdd.Enabled = True
            txtEmail.Enabled = True
            rbnFemenino.Enabled = True
            rbnMasculino.Enabled = True
            DateTimePicker1.Enabled = True
            txtEspecialidad.Enabled = True
            txtDireccion.Enabled = True
            txtDni.Focus()
        Else
            Button1.Enabled = False
            Button2.Enabled = False
            txtDni.Enabled = False
            txtNombres.Enabled = False
            txtApellidos.Enabled = False
            TxtTelefono.Enabled = False
            TxtEdd.Enabled = False
            txtEmail.Enabled = False
            rbnFemenino.Enabled = False
            rbnMasculino.Enabled = False
            DateTimePicker1.Enabled = False
            txtEspecialidad.Enabled = False
            txtDireccion.Enabled = False
        End If
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Dim i As New Especialidad
        i.ShowDialog()
    End Sub

    Private Sub RegDoce_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LISTARDOCENTE()
        Me.Location = New Point(212, 72)
    End Sub

    Sub LISTARDOCENTE()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("SELECT*FROM DOCENTE", conexion)
            DA.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception : MsgBox(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged
        Dim DT As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("BUSCAR_DNI_DOCENTE", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@DNI", TextBox10.Text)
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar <> Chr(32) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        Dim DT As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("BUSCAR_NOMBRES_DOCENTE", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@NOMBRES", TextBox9.Text)
            da.Fill(DT)
            DataGridView1.DataSource = DT
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cmd As New SqlCommand
        If txtDni.Text <> "" And txtNombres.Text <> "" And txtApellidos.Text <> "" And txtDireccion.Text <> "" And txtEmail.Text <> "" And TxtTelefono.Text <> "" And txtEspecialidad.Text <> "" Then
            Try
                abrir()
                cmd = New SqlCommand("REGISTRO_DOCENTE", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@DNI", txtDni.Text)
                cmd.Parameters.AddWithValue("@NOMBRES", txtNombres.Text)
                cmd.Parameters.AddWithValue("@APELLIDOS", txtApellidos.Text)
                cmd.Parameters.AddWithValue("@EDAD", TxtEdd.Text)
                cmd.Parameters.AddWithValue("@SEXO", If(rbnMasculino.Checked = True, "M", "F"))
                cmd.Parameters.AddWithValue("@DIRECCION", txtDireccion.Text)
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text)
                cmd.Parameters.AddWithValue("@TELEFONO", TxtTelefono.Text)
                cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", DateTimePicker1.Value)
                cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", txtEspecialidad.Text)
                cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()
                Dim MENSAJE As String = cmd.Parameters("@MENSAJE").Value.ToString
                MessageBox.Show(MENSAJE, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LISTARDOCENTE()
                limpiar()
            Catch ex As Exception : MsgBox(ex.Message)
            End Try
            Cerrar()
        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub limpiar()
        txtDni.Clear()
        txtApellidos.Clear()
        TxtEdd.Clear()
        txtEmail.Clear()
        txtEspecialidad.Clear()
        txtNombres.Clear()
        TxtTelefono.Clear()
        rbnMasculino.Checked = True
        DateTimePicker1.Value = Now
        txtDireccion.Clear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cmd As New SqlCommand
        If txtDni.Text <> "" And txtNombres.Text <> "" And txtApellidos.Text <> "" And txtDireccion.Text <> "" And txtEmail.Text <> "" And TxtTelefono.Text <> "" And txtEspecialidad.Text <> "" Then
            Try
                abrir()
                cmd = New SqlCommand("ACTUALIZAR_DOCENTE", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@DNI", txtDni.Text)
                cmd.Parameters.AddWithValue("@NOMBRES", txtNombres.Text)
                cmd.Parameters.AddWithValue("@APELLIDOS", txtApellidos.Text)
                cmd.Parameters.AddWithValue("@EDAD", TxtEdd.Text)
                cmd.Parameters.AddWithValue("@SEXO", If(rbnMasculino.Checked = True, "M", "F"))
                cmd.Parameters.AddWithValue("@DIRECCION", txtDireccion.Text)
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text)
                cmd.Parameters.AddWithValue("@TELEFONO", TxtTelefono.Text)
                cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", DateTimePicker1.Value)
                cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", txtEspecialidad.Text)
                cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()
                Dim MENSAJE As String = cmd.Parameters("@MENSAJE").Value.ToString
                MessageBox.Show(MENSAJE, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LISTARDOCENTE()
                limpiar()
            Catch ex As Exception : MsgBox(ex.Message)
            End Try
            Cerrar()
        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'En el evento "DoubleClick" del DataGridView(dgvServicio), esta el Siguiente Código:

        txtDni.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtNombres.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtApellidos.Text = DataGridView1.CurrentRow.Cells(2).Value
        TxtEdd.Text = DataGridView1.CurrentRow.Cells(3).Value
        Dim sexo As Char = DataGridView1.CurrentRow.Cells(4).Value
        If sexo = "M" Then
            rbnMasculino.Checked = True

        Else
            rbnFemenino.Checked = True
        End If
        'rbnMasculino.Checked = DataGridView1.CurrentRow.Cells(4).Value
        txtDireccion.Text = DataGridView1.CurrentRow.Cells(5).Value
        txtEmail.Text = DataGridView1.CurrentRow.Cells(6).Value
        TxtTelefono.Text = DataGridView1.CurrentRow.Cells(7).Value
        DateTimePicker1.Value = (DataGridView1.CurrentRow.Cells(8).Value)
        txtEspecialidad.Text = DataGridView1.CurrentRow.Cells(9).Value
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

    Private Sub txtNombres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombres.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar <> Chr(32) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtApellidos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellidos.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar <> Chr(32) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelefono.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtEspecialidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEspecialidad.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim FECHANAC As Date
        Dim EDAD As Integer

        FECHANAC = DateTimePicker1.Value
        EDAD = Now.Year - FECHANAC.Year
        TxtEdd.Text = CStr(EDAD)
    End Sub
End Class