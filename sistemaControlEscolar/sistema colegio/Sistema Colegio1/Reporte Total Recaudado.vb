Imports System.Data
Imports System.Data.SqlClient

Public Class Reporte_Total_Recaudado

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            DateTimePicker1.Enabled = True
            Button1.Visible = True
            txtTotal.Clear()
            DataGridView1.Rows.Clear()

        Else
            DateTimePicker1.Enabled = False
            Button1.Visible = False
            DateTimePicker1.Value = Now
            
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            txtTotal.Enabled = True
            txtTotal.Focus()
            Button2.Visible = True
            txtTotal.Clear()
            DataGridView1.Rows.Clear()
        Else
            txtTotal.Enabled = False
            Button2.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("CONSULTA_RECAUDADO_MATRICULAS_DIA", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@DIA", DateTimePicker1.Value)
            da.Fill(dt)
            'DataGridView1.DataSource = dt
            DataGridView1.Rows.Clear()
            For i = 0 To dt.Rows.Count - 1
                DataGridView1.Rows.Add(dt.Rows(i).Item(0))
                DataGridView1.Rows(i).Cells(0).Value = dt.Rows(i)(0) & ""
                DataGridView1.Rows(i).Cells(1).Value = FormatNumber(dt.Rows(i)(1) & "", 2)
            Next
        Catch ex As Exception : MsgBox(ex.Message)
        End Try
        Cerrar()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtTotal.Text = "" Then
            MsgBox("Ingrese Año a Consultar", vbInformation)
            txtTotal.Focus()
        Else
            Dim dt As New DataTable
            Dim da As SqlDataAdapter

            Try
                abrir()
                abrir()
                da = New SqlDataAdapter("CONSULTA_RECAUDADO_MATRICULAS_AÑO", conexion)
                da.SelectCommand.CommandType = 4
                da.SelectCommand.Parameters.AddWithValue("@FECH", txtTotal.Text)
                da.Fill(dt)
                ' DataGridView1.DataSource = dt
                DataGridView1.Rows.Clear()
                For i = 0 To dt.Rows.Count - 1
                    DataGridView1.Rows.Add(dt.Rows(i).Item(0))
                    DataGridView1.Rows(i).Cells(0).Value = dt.Rows(i)(0) & ""
                    DataGridView1.Rows(i).Cells(1).Value = FormatNumber(dt.Rows(i)(1) & "", 2)
                Next
            Catch ex As Exception : MsgBox(ex.Message)
            End Try
            Cerrar()
        End If
    End Sub

    Private Sub txtTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotal.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Reporte_Total_Recaudado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(212, 72)
    End Sub
End Class