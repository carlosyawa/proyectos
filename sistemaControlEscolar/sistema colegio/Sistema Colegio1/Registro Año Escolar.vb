Imports System.Data
Imports System.Data.SqlClient

Public Class RegAño

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
            txtAescolar.Text = Date.Now.Year
            txtAescolar.Enabled = True
            ' txtAescolar.Focus()
        Else
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            txtAescolar.Text = ""
            txtAescolar.Enabled = False
        End If
    End Sub

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listar()
        Me.Location = New Point(212, 72)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        Dim cmd As SqlCommand
        If txtAescolar.Text <> "" Then
            Try
                abrir()
                cmd = New SqlCommand("REGISTRAR_AÑOESCOLAR", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@NUM_AÑO", txtAescolar.Text)
                cmd.Parameters.AddWithValue("@FECHA_INICIO", DateTimePicker1.Value)
                cmd.Parameters.AddWithValue("@FECHA_TERMINO", DateTimePicker2.Value)
                cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()
                Dim MENSAJE As String = cmd.Parameters("@MENSAJE").Value.ToString
                MessageBox.Show(MENSAJE, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DataGridView1.Rows.Clear()
                listar()
                limpiar()
            Catch ex As Exception : MsgBox(ex.Message)
            End Try
            Cerrar()

        Else
            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAescolar.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Sub limpiar()
        'txtAescolar.Clear()
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
        'txtAescolar.Focus()
    End Sub

    Sub listar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("SELECT * FROM AÑO_ESCOLAR ", conexion)
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                DataGridView1.Rows.Add(dt.Rows(i).Item(0))
                DataGridView1.Rows(i).Cells(0).Value = dt.Rows(i)(0) & ""
                DataGridView1.Rows(i).Cells(1).Value = dt.Rows(i)(1) & ""
                DataGridView1.Rows(i).Cells(2).Value = dt.Rows(i)(2) & ""
            Next
            'DataGridView1.DataSource = dt
        Catch ex As Exception : MsgBox(ex.Message)
        End Try
        Cerrar()
    End Sub
End Class