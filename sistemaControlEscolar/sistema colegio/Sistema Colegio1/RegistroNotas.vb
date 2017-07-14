Imports System.Data
Imports System.Data.SqlClient

Public Class RegistroNotas
    Dim msj As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarCursos()
        GenerarCodigo()
        CargarTrimestres()
        CbxDescripcion.SelectedIndex = 0
        TxtCodigoAlumno.Focus()
        Me.Location = New Point(212, 72)
    End Sub

    Sub CargarCursos()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("SELECT * FROM CURSO", conexion)
            DA.Fill(DT)
            CbxCurso.DisplayMember = "Nombres"
            CbxCurso.ValueMember = "Cod_Curso"
            CbxCurso.DataSource = DT
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub
    Sub CargarTrimestres()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("SELECT*FROM TRIMESTRES", conexion)
            DA.Fill(DT)
            CbxTrimestre.DisplayMember = "Descripción"
            CbxTrimestre.ValueMember = "Cod_Trimestre"
            CbxTrimestre.DataSource = DT
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub
    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim i, Verficar As Integer
        If TxtNota.Text.Trim <> "" Then
            If CInt(TxtNota.Text) >= 0 And CInt(TxtNota.Text) <= 20 Then
                Verficar = VerficarDescripcion(CbxDescripcion.Text)
                If (Verficar = 0) Then
                    DataGridView1.Rows.Add()
                    i = DataGridView1.Rows.Count
                    DataGridView1.Rows(i - 1).Cells(0).Value = CbxCurso.SelectedValue
                    DataGridView1.Rows(i - 1).Cells(1).Value = CbxTrimestre.SelectedValue
                    DataGridView1.Rows(i - 1).Cells(2).Value = TxtCodigoAlumno.Text
                    DataGridView1.Rows(i - 1).Cells(3).Value = CbxCurso.Text
                    DataGridView1.Rows(i - 1).Cells(4).Value = CbxDescripcion.SelectedItem
                    DataGridView1.Rows(i - 1).Cells(5).Value = CInt(TxtNota.Text)
                Else
                    MsgBox("Tipo de Descripcion Existe")
                End If
            Else
                MsgBox("Nota Incorrecta")
            End If
        Else
            MsgBox("Asegurese de Llenar Todos Los Campos")
        End If
        TxtNota.Clear()
        TxtNota.Focus()
        MostrarPromedio()
    End Sub
    Private Function VerficarDescripcion(ByVal Nombre As String) As Integer
        Dim i, CANTDESCRIP As Integer
        CANTDESCRIP = 0
        For i = 0 To DataGridView1.Rows.Count - 1
            If Nombre = DataGridView1.Rows(i).Cells(4).Value Then
                CANTDESCRIP = CANTDESCRIP + 1
            End If
        Next
        Return CANTDESCRIP
    End Function
    Sub LIMPIAR()
        TxtNota.Clear()
        TxtNota.Focus()
        CbxDescripcion.SelectedIndex = 0
        Call CargarCursos()
        Call CargarTrimestres()
        DataGridView1.Rows.Clear()
        TxtCodigoAlumno.Clear()
        LblPromedio.Text = ""
    End Sub
    Sub MostrarPromedio()
        Dim i As Integer
        Dim Prom As Decimal
        Dim Suma As Decimal
        For i = 0 To DataGridView1.Rows.Count - 1
            Suma = Suma + DataGridView1.Rows(i).Cells(5).Value
            Prom = Math.Round(CDec(Suma / DataGridView1.Rows.Count), 2)
        Next
        LblPromedio.Text = CStr(Prom)
    End Sub
    Private Sub BtnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegistrar.Click
        Dim i As Integer
        Try
            For i = 0 To DataGridView1.Rows.Count - 1
                GuardarNotas(CStr(DataGridView1.Rows(i).Cells(0).Value), CInt(DataGridView1.Rows(i).Cells(1).Value), CInt(DataGridView1.Rows(i).Cells(2).Value), CStr(DataGridView1.Rows(i).Cells(4).Value), CInt(DataGridView1.Rows(i).Cells(5).Value))
            Next
            If msj = "Registrado Ok" Then
                MsgBox("Registrado ok", vbInformation)
            ElseIf msj = "Sólo Puede Registrar 4 Notas Por Curso" Then
                MsgBox("Sólo Puede Registrar 4 Notas Por Curso", vbInformation)
                LIMPIAR()
            End If
        Catch ex As Exception : MsgBox(ex.Message)
        End Try
        DataGridView2.Visible = False
        DataGridView1.Visible = True
        LIMPIAR()
        Call GenerarCodigo()
    End Sub
    Sub GuardarNotas(ByVal Codigo As String, ByVal IdT As Integer, ByVal Dni As Integer, ByVal Descripcion As String, ByVal Nota As Integer)
        Dim cmd As SqlCommand
        Try
            abrir()
            cmd = New SqlCommand("REGISTRAR_NOTAS", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@NOTA", Nota)
                .AddWithValue("@DESCRIPCION", Descripcion)
                .AddWithValue("@ID_CURSO", Codigo)
                .AddWithValue("@DNI_ALUMNO", Dni)
                .AddWithValue("@ID_TRIMESTRE", IdT)
                .Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            msj = cmd.Parameters("@MENSAJE").Value.ToString
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim i As Integer = DataGridView1.CurrentRow.Index
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("seleccione Fila a Eliminar")
        Else
            If i < 0 Then
            End If
            If MessageBox.Show("¿Desea Eliminar La Nota?:  ", "RESPUESTA", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                DataGridView1.Rows.RemoveAt(i)
                Call MostrarPromedio()
            End If
        End If
    End Sub
    Private Sub TxtNota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNota.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtCodigoAlumno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAlumno.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Sub GenerarCodigo()
        Dim Codigo As Integer
        Dim CMD As SqlCommand
        Try
            abrir()
            CMD = New SqlCommand("GENERAR_CODIGO_NOTAS", conexion)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@ID_NTA", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            CMD.ExecuteNonQuery()
            Codigo = CMD.Parameters("@ID_NTA").Value
            LblCodigo.Text = CStr(Codigo)
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim da As SqlDataAdapter
        Dim dt As New DataTable
        If TxtCodigoAlumno.Text <> "" Then
            Try
                abrir()
                da = New SqlDataAdapter("BUSCAR_NOTAS", conexion)
                da.SelectCommand.CommandType = 4
                da.SelectCommand.Parameters.AddWithValue("@DNI_ALUMNO", TxtCodigoAlumno.Text)
                da.SelectCommand.Parameters.AddWithValue("@ID_CURSO ", CbxCurso.SelectedValue)
                da.SelectCommand.Parameters.AddWithValue("@ID_TRIMESTRE", CbxTrimestre.SelectedValue)
                da.Fill(dt)
                DataGridView2.DataSource = dt
            Catch ex As Exception
            End Try

            DataGridView2.Visible = True
            
            LblPromedio.Visible = False
            Label4.Visible = False
            Cerrar()
        Else
            MsgBox("Verificar Datos para Continuar su Busquedad")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Button2.Enabled = True
            BtnAgregar.Enabled = False
            BtnRegistrar.Enabled = False
            BtnEliminar.Enabled = False
            BtnActualizar.Enabled = True
        Else
            BtnAgregar.Enabled = True
            BtnRegistrar.Enabled = True
            BtnActualizar.Enabled = False
            Button2.Enabled = False
            BtnEliminar.Enabled = True
        End If
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Dim cmd As SqlCommand
        Try
            abrir()
            cmd = New SqlCommand("ACTUALIZAR_NOTAS", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@COD_NOTAS", LblCodigo.Text)
                .AddWithValue("@NOTA", TxtNota.Text)
                .AddWithValue("@DESCRIPCION", CbxDescripcion.SelectedItem)
                .AddWithValue("@ID_CURSO", CbxCurso.SelectedValue)
                .AddWithValue("@DNI_ALUMNO", TxtCodigoAlumno.Text)
                .AddWithValue("@ID_TRIMESTRE", CbxTrimestre.SelectedValue)
                .Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            Dim mje As String = cmd.Parameters("@MENSAJE").Value.ToString
            MessageBox.Show(mje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()

    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        LblCodigo.Text = DataGridView2.CurrentRow.Cells(0).Value
        TxtNota.Text = DataGridView2.CurrentRow.Cells(1).Value
        CbxDescripcion.SelectedItem = DataGridView2.CurrentRow.Cells(2).Value
        CbxCurso.SelectedValue = DataGridView2.CurrentRow.Cells(3).Value
        TxtCodigoAlumno.Text = DataGridView2.CurrentRow.Cells(4).Value
        CbxTrimestre.SelectedValue = DataGridView2.CurrentRow.Cells(5).Value
        'CbxCurso.SelectedItem = DataGridView2.CurrentRow.Cells(3).Value

        'CbxTrimestre.SelectedItem = DataGridView2.CurrentRow.Cells(5).Value

    End Sub
End Class