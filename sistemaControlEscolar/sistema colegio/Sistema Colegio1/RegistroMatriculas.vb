Imports System.Data
Imports System.Data.SqlClient
Public Class RegMatr
    Dim MENSAJE As String
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TxtMonto.Text = 25
            lblañoes.Text = Date.Now.Year
            lblañoes.Enabled = True
            DateTimePicker1.Enabled = True
            TxtCodAlumno.Enabled = True
            TxtMonto.Enabled = True
            TxtSeccion.Enabled = True
            btnRegistrar.Enabled = True
            'BtnActualizar.Enabled = True
            btnBuscar.Enabled = True
            cbxgrado.Enabled = True
            TxtCodAlumno.Focus()
        Else
            DateTimePicker1.Enabled = False
            lblañoes.Text = ""
            cbxgrado.Text = "Seleccione"
            TxtSeccion.Clear()
            lblCapacidad.Text = ""
            TxtMonto.Clear()
            lblañoes.Enabled = False
            TxtCodAlumno.Enabled = False
            TxtMonto.Enabled = False
            TxtMonto.Enabled = False
            TxtSeccion.Enabled = False
            btnRegistrar.Enabled = False
            BtnActualizar.Enabled = False
            btnBuscar.Enabled = False
            cbxgrado.Enabled = False
        End If
    End Sub



    Private Sub btnreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        Dim cmd As New SqlCommand
        If TxtMonto.Text <> "" And TxtSeccion.Text <> "" And TxtCodAlumno.Text <> "" Then

            Try
                abrir()
                cmd = New SqlCommand("REGISTRAR_MATRICULA", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@FECHA", DateTimePicker1.Value)
                cmd.Parameters.AddWithValue("@MONTO", TxtMonto.Text)
                cmd.Parameters.AddWithValue("@GRADO", cbxgrado.SelectedItem)
                'Dim b As Integer
                'If (TxtGrado.Text) >= 1 And (TxtGrado.Text) <= 5 Then
                '    cmd.Parameters.AddWithValue("@GRADO", b)
                'Else
                '    MsgBox("No Existe Un Grado" & TxtGrado.Text)
                'End If
                cmd.Parameters.AddWithValue("@SECCION", TxtSeccion.Text)
                cmd.Parameters.AddWithValue("@NUM_AÑO", lblañoes.Text)
                cmd.Parameters.AddWithValue("@COD_AULA", cbxgrado.SelectedItem)
                cmd.Parameters.AddWithValue("@DNI_ALUMNO", TxtCodAlumno.Text)
                cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()
                MENSAJE = cmd.Parameters("@MENSAJE").Value.ToString
                MessageBox.Show(MENSAJE, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DataGridView1.Rows.Clear()
                LISTAR()

            Catch ex As Exception : MessageBox.Show(ex.Message)
                Cerrar()
            End Try
        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Procedimiento para Registrar Documentacion
        If MENSAJE = "Matrícula Registrada" Then
            Try
                abrir()
                cmd = New SqlCommand("RegistrarDoc", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@Partida", If(ckbpart.Checked = True, "S", "N"))
                cmd.Parameters.AddWithValue("@Certificado", If(ckbcert.Checked = True, "S", "N"))
                cmd.Parameters.AddWithValue("@Dni_Alumno", TxtCodAlumno.Text)
                cmd.ExecuteNonQuery()
            Catch ex As Exception : MsgBox(ex.Message, vbInformation)
                Cerrar()
            End Try
        End If
        

        LIMPIAR()
    End Sub

    Private Sub LISTAR()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("SELECT * FROM MATRICULA", conexion)
            da.Fill(dt)
            '  DataGridView1.DataSource = dt
            For i = 0 To dt.Rows.Count - 1
                DataGridView1.Rows.Add(dt.Rows(i).Item(0))
                DataGridView1.Rows(i).Cells(0).Value = dt.Rows(i)(0) & ""
                DataGridView1.Rows(i).Cells(1).Value = dt.Rows(i)(1) & ""
                DataGridView1.Rows(i).Cells(2).Value = FormatNumber(dt.Rows(i)(2) & "", 2)
                DataGridView1.Rows(i).Cells(3).Value = dt.Rows(i)(3) & ""
                DataGridView1.Rows(i).Cells(4).Value = dt.Rows(i)(4) & ""
                DataGridView1.Rows(i).Cells(5).Value = dt.Rows(i)(5) & ""
                DataGridView1.Rows(i).Cells(6).Value = dt.Rows(i)(6) & ""
                DataGridView1.Rows(i).Cells(7).Value = dt.Rows(i)(7) & ""
            Next
        Catch ex As Exception : MsgBox(ex.Message)
        End Try
        Cerrar()
        Dim x As Integer = DataGridView1.Rows.Count
        lblTotal.Text = x
    End Sub

    Private Sub LIMPIAR()
        TxtCodAlumno.Clear()
        DateTimePicker1.Value = Now
        TxtSeccion.Clear()
        cbxgrado.Text = "Seleccione"
        Label2.Text = ""
        ckbcert.Checked = False
        ckbpart.Checked = False
        TxtCodAlumno.Focus()
        cbxgrado.SelectedIndex = 0
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Dim cmd As New SqlCommand
        If TxtMonto.Text <> "" And TxtSeccion.Text <> "" And TxtCodAlumno.Text <> "" Then
            Try
                abrir()
                cmd = New SqlCommand("ACTUALIZAR_MATRICULA", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@FECHA", DateTimePicker1.Value)
                cmd.Parameters.AddWithValue("@MONTO", TxtMonto.Text)
                cmd.Parameters.AddWithValue("@GRADO", cbxgrado.SelectedItem)
                cmd.Parameters.AddWithValue("@SECCION", TxtSeccion.Text)
                cmd.Parameters.AddWithValue("@COD_AULA", cbxgrado.SelectedItem)
                cmd.Parameters.AddWithValue("@DNI_ALUMNO", TxtCodAlumno.Text)
                cmd.Parameters.AddWithValue("@NUM_AÑO", lblañoes.Text)
                cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()
                Dim MENSAJE As String = cmd.Parameters("@MENSAJE").Value.ToString
                MessageBox.Show(MENSAJE, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LISTAR()
                LIMPIAR()
            Catch ex As Exception : MessageBox.Show(ex.Message)
                Cerrar()
            End Try
        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub CargarAulas()
        Dim DA As SqlDataAdapter
        Dim DT As New DataTable

        Try
            abrir()
            DA = New SqlDataAdapter("SELECT * FROM AULAS", conexion)
            DA.Fill(DT)
            cbxgrado.DisplayMember = "Descripción"
            cbxgrado.ValueMember = "Cod_Aula"
            cbxgrado.DataSource = DT
        Catch ex As Exception : MsgBox(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub RegMatr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LISTAR()
        Me.Location = New Point(212, 72)
        'Call CargarAulas()
        TxtSeccion.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim dt As New DataTable
        Dim row As DataRow
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("BUSCAR_MATRICULA", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@DNI_ALUMNO", TxtCodAlumno.Text)
            da.SelectCommand.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
            da.Fill(dt)

            If dt.Rows.Count = 1 Then
                row = dt.Rows(0)
                Label2.Text = row(0).ToString
                DateTimePicker1.Value = row(1).ToString
                TxtMonto.Text = FormatNumber(row(2).ToString, 2)
                cbxgrado.SelectedItem = row(3).ToString
                TxtSeccion.Text = row(4).ToString
                lblañoes.Text = row(7).ToString
                cbxgrado.SelectedValue = row(5).ToString
                Dim MENSAJE As String = da.SelectCommand.Parameters("@MENSAJE").Value.ToString
                MessageBox.Show(MENSAJE, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                BtnActualizar.Enabled = True
                btnRegistrar.Enabled = False
            Else
                MessageBox.Show("Codigo no Registrado", "Aviso")
                Call LIMPIAR()
                BtnActualizar.Enabled = False
                btnRegistrar.Enabled = True

            End If
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try

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

    Private Sub TxtGrado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar < "1" Or e.KeyChar > "5" Then
            If e.KeyChar <> Chr(8) And e.KeyChar <> Chr(32) Then
                e.KeyChar = Chr(1)
            End If
        End If
        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
    End Sub

    Private Sub TxtAEscolar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TxtSeccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSeccion.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TxtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cbxgrado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxgrado.SelectedIndexChanged
        Dim cmd As New SqlCommand("BuscaVacLi", conexion)
        Try
            abrir()
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@codaula", cbxgrado.SelectedItem)
            cmd.Parameters.Add("@vaclib", SqlDbType.Int).Direction = 2
            cmd.ExecuteNonQuery()
            Dim vacli As Integer = cmd.Parameters("@vaclib").Value
            lblCapacidad.Text = CStr(vacli)
            TxtSeccion.Text = "A"
        Catch ex As Exception
        End Try
        Cerrar()
        'BuscaVacLi()
    End Sub
End Class