Imports System.Data
Imports System.Data.SqlClient

Public Class Reporte_de_Detalle_de_Notas

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            abrir()
            da = New SqlDataAdapter("CONSULTA_DETALLE_TRIMESTRE", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@DNI_ALU", txtCodigo.Text)
            da.SelectCommand.Parameters.AddWithValue("@TRIME", CbxTrimestre.SelectedValue)
            da.Fill(dt)

            DataGridView1.Rows.Clear()
            For i = 0 To dt.Rows.Count - 1
                DataGridView1.Rows.Add(dt.Rows(i).Item(0))
                DataGridView1.Rows(i).Cells(0).Value = dt.Rows(i)(0) & ""
                DataGridView1.Rows(i).Cells(1).Value = FormatNumber(dt.Rows(i)(1) & "", 2)
                DataGridView1.Rows(i).Cells(2).Value = dt.Rows(i)(2) & ""
            Next

            'DataGridView1.DataSource = dt
            'Limpiar()
        Catch ex As Exception : MsgBox(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Reporte_de_Detalle_de_Notas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarTrimestre()
        Me.Location = New Point(212, 72)

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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtCodigo.Enabled = True
            CbxTrimestre.Enabled = True
            BtnConsultar.Enabled = True
            txtCodigo.Focus()
        Else
            txtCodigo.Enabled = False
            CbxTrimestre.Enabled = False
            BtnConsultar.Enabled = False
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim x As New DetalleNotas
        x.ShowDialog()

    End Sub
End Class