Imports System.Data
Imports System.Data.SqlClient

Public Class Aula
    Private Sub Aula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(212, 72)
    End Sub

    Private Sub lkbmostr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        listarau()
    End Sub
    Private Sub listarau()
        ' Procedimiento Para Listar Alumnos
        Dim dt As New DataTable
        abrir()
        Dim da As New SqlDataAdapter("Buscal", conexion)
        da.SelectCommand.CommandType = 4
        da.SelectCommand.Parameters.AddWithValue("@grado", cmbgrado.SelectedItem)
        da.Fill(dt)
        dtgalum.DataSource = dt
        Cerrar()
    End Sub

    Private Sub cmbgrado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgrado.SelectedIndexChanged
        Dim Capacidad As Integer
        Dim CMD As SqlCommand
        Try
            abrir()
            CMD = New SqlCommand("BuscVacLi", conexion)
            CMD.CommandType = 4
            CMD.Parameters.AddWithValue("@codaula", CInt(cmbgrado.SelectedItem))
            CMD.Parameters.Add("@vaclib", SqlDbType.Int).Direction = 2
            Capacidad = CMD.ExecuteScalar()
            lblcapacidad.Text = CStr(Capacidad)
            Dim vaclib As Integer = CMD.Parameters("@vaclib").Value
            lblvaclib.Text = vaclib
            listarau()
            Dim j As Integer = dtgalum.Rows.Count
            Label5.Text = CStr(j)
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        Cerrar()
    End Sub

    'Sub CargarAulas()
    '    Dim DA As SqlDataAdapter
    '    Dim DT As New DataTable
    '    Try
    '        abrir()
    '        DA = New SqlDataAdapter("SELECT * FROM AULAS", conexion)
    '        DA.Fill(DT)
    '        cmbgrado.DisplayMember = "Cod_Aula"
    '        cmbgrado.ValueMember = "Cod_Aula"
    '        cmbgrado.DataSource = DT
    '    Catch ex As Exception : MsgBox(ex.Message)
    '    End Try
    '    Cerrar()
    'End Sub

End Class