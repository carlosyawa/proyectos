Imports System.Data
Imports System.Data.SqlClient

Public Class DetalleNotas

    Private Sub Form14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarCursos()
        CargarTrimestre()
        Me.Location = New Point(212, 72)
     
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CbxCurso.Enabled = True
            TxtCodigoAlumno.Enabled = True
            BtnConsultar.Enabled = True
            CbxTrimestre.Enabled = True
            TxtCodigoAlumno.Focus()

        Else
            CbxCurso.Enabled = False
            'TxtCodigoAlumno.Enabled = False
            BtnConsultar.Enabled = False
            CbxTrimestre.Enabled = False
        End If

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

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        If TxtCodigoAlumno.Text.Trim <> "" Then
            Try
                abrir()
                DA = New SqlDataAdapter("CONSULTA_NOTAS_CURSO_TRIMESTRE", conexion)
                DA.SelectCommand.CommandType = 4
                DA.SelectCommand.Parameters.AddWithValue("@DNI", TxtCodigoAlumno.Text)
                DA.SelectCommand.Parameters.AddWithValue("@COD_CURSO", CbxCurso.SelectedValue)
                DA.SelectCommand.Parameters.AddWithValue("@COD_TRI", CbxTrimestre.SelectedValue)
                DA.Fill(DT)
                DataGridView1.DataSource = DT

            Catch ex As Exception : MessageBox.Show(ex.Message)
            End Try
            Cerrar()
        Else
            MessageBox.Show("Por Favor Digite Codigo ...!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            TxtCodigoAlumno.Focus()
        End If
        Dim suma As Integer = 0
        Dim Prom As Double = 0
        Dim cont As Integer = DataGridView1.Rows.Count()
        For a = 0 To cont - 1
            suma = suma + DataGridView1.Item(1, a).Value.ToString
        Next
        Prom = suma / cont
        LblPrpmedio.Text = Prom.ToString
        If LblPrpmedio.Text = "NeuN" Then
            LblPrpmedio.Text = 0
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

    Sub CargarTrimestre()

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


    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

   
End Class