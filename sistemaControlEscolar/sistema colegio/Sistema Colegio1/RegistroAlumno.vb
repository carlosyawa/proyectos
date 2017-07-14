Imports System.Data
Imports System.Data.SqlClient

Public Class RegAl

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Me.Width = 1003
        If RadioButton7.Checked = True Then
            TxtDni.Text = TextBox6.Text
            TextBox6.Text = ""
            TxtNombres.Text = ""
            TxtNombres.Focus()
        Else
            TxtNombres.Text = TextBox7.Text
            TextBox7.Text = ""
            TxtDni.Text = ""
            TxtDni.Focus()
        End If
        BtnActualizar.Visible = False
        BtnRegis.Visible = True

        'dESCOMENTAR BtnRegistrar.Visible = True
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        Dim DT As New DataTable
        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("BUSCAR_DN_ALUMNO", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@DNI", TextBox6.Text)
            da.Fill(DT)
            DataGridView1.DataSource = DT
            Dim x As Integer
            x = DataGridView1.Rows.Count
            Label9.Text = CStr(x)
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar <> Chr(32) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        Dim DT As New DataTable
        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("BUSCAR_NOMBRES_ALUMNO", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@NOMBRES", TextBox7.Text)
            da.Fill(DT)
            DataGridView1.DataSource = DT
            Dim x As Integer
            x = DataGridView1.Rows.Count
            Label9.Text = CStr(x)
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Width = 1003
        TxtDni.Text = TextBox6.Text
        TextBox6.Text = ""
        'BtnBuscar.Visible = True
        BtnActualizar.Visible = True
    End Sub

    Private Sub LISTAR()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("SELECT * FROM ALUMNO", conexion)
            DA.Fill(DT)
            DataGridView1.DataSource = DT
            Dim x As Integer = DataGridView1.Rows.Count
            Label9.Text = CInt(x)
        Catch ex As Exception
        End Try
        Cerrar()
    End Sub

    Private Sub LIMPIAR()
        TxtDni.Clear()
        TxtNombres.Clear()
        TxtApPaterno.Clear()
        TxtApMaterno.Clear()
        TxtDireccion.Clear()
        TxtEdad.Clear()
        RbnMasculino.Checked = True
        DateTimePicker1.Value = "01/01/1998"
        TxtDni.Focus()
    End Sub

    
    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Dim CMD As SqlCommand

        If TxtDni.Text <> "" And TxtNombres.Text <> "" And TxtApPaterno.Text <> "" And TxtApMaterno.Text <> "" And TxtEdad.Text <> "" And TxtDireccion.Text <> "" Then
            Try
                abrir()
                CMD = New SqlCommand("ACTUALIZAR_ALUMNO", conexion)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.AddWithValue("@DNI", TxtDni.Text)
                CMD.Parameters.AddWithValue("@NOMBRES", TxtNombres.Text)
                CMD.Parameters.AddWithValue("@APE_PATERNO", TxtApPaterno.Text)
                CMD.Parameters.AddWithValue("@APE_MATERNO", TxtApMaterno.Text)
                CMD.Parameters.AddWithValue("@EDAD", TxtEdad.Text)
                CMD.Parameters.AddWithValue("@SEXO", If(RbnMasculino.Checked = True, "M", "F"))
                CMD.Parameters.AddWithValue("@DIRECCION", TxtDireccion.Text)
                CMD.Parameters.AddWithValue("@FECHA_NACIMIENTO", DateTimePicker1.Value)
                CMD.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
                CMD.ExecuteNonQuery()

                Dim MENSAJE As String = CMD.Parameters("@MENSAJE").Value.ToString
                MessageBox.Show(MENSAJE, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LISTAR()
                LIMPIAR()
                Me.Width = 528
            Catch ex As Exception : MessageBox.Show(ex.Message)
                Cerrar()
            End Try
        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
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

    Private Sub TxtEdad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEdad.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub RegAl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LISTAR()
        Me.Location = New Point(212, 72)

    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        If RadioButton7.Checked = True Then
            Label1.Visible = True
            TextBox6.Visible = True
            TextBox6.Focus()
        Else
            Label1.Visible = False
            TextBox6.Visible = False
        End If
        LISTAR()
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then
            Label7.Visible = True
            TextBox7.Visible = True
            TextBox7.Focus()
        Else
            Label7.Visible = False
            TextBox7.Visible = False
        End If
        LISTAR()
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim FECHANAC As Date
        Dim EDAD As Integer

        FECHANAC = DateTimePicker1.Value
        EDAD = Now.Year - FECHANAC.Year

        If FECHANAC <= "01/01/1991" Or FECHANAC >= "01/12/2001" Then
            MsgBox("Edad No Permitida Para Realizar Una Matrícula")
            TxtEdad.Clear()
            DateTimePicker1.Value = "01/02/2000"
        Else
            TxtEdad.Text = CStr(EDAD)
        End If
        'DateTimePicker1.Value = Now
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'En el evento "DoubleClick" del DataGridView(dgvServicio), esta el Siguiente Código:
        Me.Width = 1003
        TxtDni.Text = DataGridView1.CurrentRow.Cells(0).Value
        TxtNombres.Text = DataGridView1.CurrentRow.Cells(1).Value
        TxtApPaterno.Text = DataGridView1.CurrentRow.Cells(2).Value
        TxtApMaterno.Text = DataGridView1.CurrentRow.Cells(3).Value
        TxtEdad.Text = DataGridView1.CurrentRow.Cells(4).Value
        Dim sexo As Char = DataGridView1.CurrentRow.Cells(5).Value
        If sexo = "M" Then
            RbnMasculino.Checked = True

        Else
            RbnFemenino.Checked = True
        End If
        'rbnMasculino.Checked = DataGridView1.CurrentRow.Cells(4).Value
        TxtDireccion.Text = DataGridView1.CurrentRow.Cells(6).Value
        DateTimePicker1.Value = (DataGridView1.CurrentRow.Cells(7).Value)
        'DESCOMENTAR  BtnRegistrar.Visible = False
        BtnActualizar.Visible = True
        BtnRegis.Visible = False
    End Sub

   
    Private Sub BtnNuevo_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnNuevo.MouseMove
        BtnNuevo.BackgroundImage = My.Resources.boton_agregar2

    End Sub

    Private Sub RegAl_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        BtnNuevo.BackgroundImage = My.Resources.boton_agregar
    End Sub

    Private Sub BtnRegis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegis.Click
        Dim CMD As SqlCommand
        'Asignar valor al codal
        codal = TxtDni.Text
        If TxtDni.Text <> "" And TxtNombres.Text <> "" And TxtApPaterno.Text <> "" And TxtApMaterno.Text <> "" And TxtEdad.Text <> "" And TxtDireccion.Text <> "" Then
                Try
                    abrir()
                    CMD = New SqlCommand("REGISTRAR_ALUMNO", conexion)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.AddWithValue("@DNI", TxtDni.Text)
                    CMD.Parameters.AddWithValue("@NOMBRES", TxtNombres.Text)
                    CMD.Parameters.AddWithValue("@APE_PATERNO", TxtApPaterno.Text)
                CMD.Parameters.AddWithValue("@APE_MATERNO", TxtApMaterno.Text)
                    CMD.Parameters.AddWithValue("@EDAD", TxtEdad.Text)
                CMD.Parameters.AddWithValue("@SEXO", If(RbnMasculino.Checked = True, "M", "F"))
                CMD.Parameters.AddWithValue("@DIRECCION", TxtDireccion.Text)
                CMD.Parameters.AddWithValue("@FECHA_NACIMIENTO", DateTimePicker1.Value)
                CMD.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
                CMD.ExecuteNonQuery()

                Dim MENSAJE As String = CMD.Parameters("@MENSAJE").Value.ToString
                MessageBox.Show(MENSAJE, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LISTAR()
                LIMPIAR()
                Me.Width = 528
            Catch ex As Exception : MessageBox.Show(ex.Message)
                Cerrar()
            End Try
        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnActualizar.Visible = False
        End If
        'BtnBuscar.Visible = True
        'BtnActualizar.Visible = True
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
    Private Sub TxtApPaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtApPaterno.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtApMaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtApMaterno.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        codal = TxtDni.Text
    End Sub
End Class