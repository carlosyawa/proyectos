Imports System.Data
Imports System.Data.SqlClient

Public Class RegApod
    Dim MENSAJE As String
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            Label17.Visible = True
            TextBox10.Visible = True
            TextBox10.Focus()
        Else
            Label17.Visible = False
            TextBox10.Visible = False
        End If
        LISTAR()
        TextBox10.Text = ""
        TextBox9.Text = ""
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            Label16.Visible = True
            TextBox9.Visible = True
            TextBox9.Focus()
        Else
            Label16.Visible = False
            TextBox9.Visible = False
        End If
        LISTAR()
        TextBox10.Text = ""
        TextBox9.Text = ""
    End Sub

    Private Sub BtnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegistrar.Click
        Dim CMD As SqlCommand
        'Asignar valor al Codap
        codap = TxtDni.Text
        If TxtDni.Text <> "" And TxtNombres.Text <> "" And TxtApellidos.Text <> "" And TxtEdad.Text <> "" And TxtOcupacion.Text <> "" And TxtGrado.Text <> "" And TxtTelefono.Text <> "" And TxtDireccion.Text <> "" Then
            Try
                abrir()
                CMD = New SqlCommand("REGISTRAR_APODERADO", conexion)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.AddWithValue("@DNI", TxtDni.Text)
                CMD.Parameters.AddWithValue("@NOMBRES", TxtNombres.Text)
                CMD.Parameters.AddWithValue("@APELLIDOS", TxtApellidos.Text)
                CMD.Parameters.AddWithValue("@EDAD", TxtEdad.Text)
                CMD.Parameters.AddWithValue("@SEXO", If(RbnMasculino.Checked = True, "M", "F"))
                CMD.Parameters.AddWithValue("@OCUPACION", TxtOcupacion.Text)
                CMD.Parameters.AddWithValue("@ESTADO_CIVIL", CbxEstado.SelectedItem)
                CMD.Parameters.AddWithValue("@GRADO_INSTRUCCION", TxtGrado.Text)
                CMD.Parameters.AddWithValue("@TELEFONO", TxtTelefono.Text)
                CMD.Parameters.AddWithValue("@DIRECCION", TxtDireccion.Text)
                CMD.Parameters.AddWithValue("@FECHA_NACIMIENTO", DateTimePicker1.Value)
                CMD.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
                CMD.ExecuteNonQuery()
                MENSAJE = CMD.Parameters("@MENSAJE").Value.ToString
                If MENSAJE = "Registrado Ok" Then
                    LinkLabel1.Visible = True
                Else
                    LinkLabel1.Visible = False
                End If

                MessageBox.Show(MENSAJE, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                LISTAR()
                LIMPIAR()
                Me.Width = 527


            Catch ex As Exception : MessageBox.Show(ex.Message)
                Cerrar()
            End Try
        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'BtnBuscar.Visible = True
        BtnRegistrar.Visible = True
        BtnActualizar.Visible = False
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDni.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEdad.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelefono.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
    '    If Char.IsLetter(e.KeyChar) Then
    '        e.Handled = False
    '    ElseIf Char.IsControl(e.KeyChar) Then
    '        e.Handled = False
    '    Else
    '        e.Handled = True
    '    End If
    ''End Sub

    Private Sub LIMPIAR()
        TxtDni.Clear()
        TxtNombres.Clear()
        TxtApellidos.Clear()
        TxtDireccion.Clear()
        TxtEdad.Clear()
        TxtGrado.Clear()
        TxtOcupacion.Clear()
        TxtTelefono.Clear()
        CbxEstado.SelectedIndex = 0
        DateTimePicker1.Value = Now
        RbnMasculino.Checked = True
        TxtDni.Focus()
    End Sub

    Private Sub LISTAR()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter

        Try
            abrir()
            DA = New SqlDataAdapter("SELECT * FROM APODERADO", conexion)
            DA.Fill(DT)
            DataGridView1.DataSource = DT
            Dim x As Integer = DataGridView1.Rows.Count
            Label7.Text = CInt(x)
        Catch ex As Exception

        End Try
        Cerrar()
    End Sub

    Private Sub RegApod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CbxEstado.SelectedIndex = 0
        LISTAR()
        Me.Location = New Point(212, 72)
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
            da = New SqlDataAdapter("BUSCAR_DNI_APODERADO", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@DNI", TextBox10.Text)
            da.Fill(DT)
            DataGridView1.DataSource = DT
            Dim X As Integer
            X = DataGridView1.Rows.Count
            Label7.Text = CStr(X)


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
            da = New SqlDataAdapter("BUSCAR_NOMBRECOMPLETO_APODERADO", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@NOMBRES", TextBox9.Text)
            da.Fill(DT)
            DataGridView1.DataSource = DT
            Dim X As Integer
            X = DataGridView1.Rows.Count
            Label7.Text = CStr(X)

        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Me.Width = 998
        If RadioButton4.Checked = True Then
            TxtDni.Text = TextBox10.Text
            TextBox10.Text = ""
            TxtNombres.Text = ""
            TxtNombres.Focus()
        Else
            TxtNombres.Text = TextBox9.Text
            TextBox9.Text = ""
            TxtDni.Text = ""
            TxtDni.Focus()

        End If
        BtnActualizar.Visible = False
        BtnRegistrar.Visible = True
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Dim CMD As SqlCommand

        If TxtDni.Text <> "" And TxtNombres.Text <> "" And TxtApellidos.Text <> "" And TxtEdad.Text <> "" And TxtOcupacion.Text <> "" And TxtGrado.Text <> "" And TxtTelefono.Text <> "" And TxtDireccion.Text <> "" Then
            Try
                abrir()
                CMD = New SqlCommand("ACTUALIZAR_APODERADO", conexion)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.AddWithValue("@DNI", TxtDni.Text)
                CMD.Parameters.AddWithValue("@NOMBRES", TxtNombres.Text)
                CMD.Parameters.AddWithValue("@APELLIDOS", TxtApellidos.Text)
                CMD.Parameters.AddWithValue("@EDAD", TxtEdad.Text)
                CMD.Parameters.AddWithValue("@SEXO", If(RbnMasculino.Checked = True, "M", "F"))
                CMD.Parameters.AddWithValue("@OCUPACION", TxtOcupacion.Text)
                CMD.Parameters.AddWithValue("@ESTADO_CIVIL", CbxEstado.SelectedItem)
                CMD.Parameters.AddWithValue("@GRADO_INSTRUCCION", TxtGrado.Text)
                CMD.Parameters.AddWithValue("@TELEFONO", TxtTelefono.Text)
                CMD.Parameters.AddWithValue("@DIRECCION", TxtDireccion.Text)
                CMD.Parameters.AddWithValue("@FECHA_NACIMIENTO", DateTimePicker1.Value)
                CMD.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
                CMD.ExecuteNonQuery()

                Dim MENSAJE As String = CMD.Parameters("@MENSAJE").Value.ToString
                MessageBox.Show(MENSAJE, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LISTAR()
                LIMPIAR()
                Me.Width = 527
            Catch ex As Exception : MessageBox.Show(ex.Message)
                Cerrar()
            End Try
        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        BtnRegistrar.Visible = False
        BtnActualizar.Visible = True
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Width = 1032
        TxtDni.Text = TextBox10.Text
        TextBox10.Text = ""
        'BtnBuscar.Visible = True
        BtnActualizar.Visible = True
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim FECHANAC As Date
        Dim EDAD As Integer
        FECHANAC = DateTimePicker1.Value
        EDAD = Now.Year - FECHANAC.Year
        TxtEdad.Text = CStr(EDAD)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Me.Width = 1032
        TxtDni.Text = DataGridView1.CurrentRow.Cells(0).Value
        TxtNombres.Text = DataGridView1.CurrentRow.Cells(1).Value
        TxtApellidos.Text = DataGridView1.CurrentRow.Cells(2).Value
        TxtEdad.Text = DataGridView1.CurrentRow.Cells(3).Value

        Dim sexo As Char = DataGridView1.CurrentRow.Cells(4).Value
        If sexo = "M" Then
            RbnMasculino.Checked = True

        Else
            RbnFemenino.Checked = True
        End If
        TxtOcupacion.Text = DataGridView1.CurrentRow.Cells(5).Value
        CbxEstado.SelectedItem = DataGridView1.CurrentRow.Cells(6).Value
        TxtGrado.Text = DataGridView1.CurrentRow.Cells(7).Value
        TxtTelefono.Text = DataGridView1.CurrentRow.Cells(8).Value
        TxtDireccion.Text = DataGridView1.CurrentRow.Cells(9).Value
        DateTimePicker1.Value = (DataGridView1.CurrentRow.Cells(10).Value)
        BtnActualizar.Visible = True
        BtnRegistrar.Visible = False
    End Sub

    Private Sub TxtNombres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombres.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar <> Chr(32) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtApellidos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtApellidos.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar <> Chr(32) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtOcupacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOcupacion.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar <> Chr(32) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtGrado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGrado.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar <> Chr(32) Then
            e.Handled = True
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim pa As New Parentesco
        pa.ShowDialog()

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        codap = TxtDni.Text
    End Sub
End Class