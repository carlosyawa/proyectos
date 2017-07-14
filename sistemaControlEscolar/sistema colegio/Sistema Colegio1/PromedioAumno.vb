Imports System.Data.SqlClient
Imports System.Data
Public Class PromedioAumno

    Private Sub btnmostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmostrar.Click
        If TextBox1.Text = "" Then
            MsgBox("Debe Ingresar el DNI del Alumno")
            TextBox1.Focus()
        Else
            DataGridView1.Rows.Clear()
            Dim DT As New DataTable
            Dim da As SqlDataAdapter
            Try
                abrir()
                da = New SqlDataAdapter("CONSULTA_PROMEDIO_CURSO_TODOSLOSTRIMESTRES", conexion)
                da.SelectCommand.CommandType = 4
                da.SelectCommand.Parameters.AddWithValue("@DNI_ALU", TextBox1.Text)
                da.SelectCommand.Parameters.Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                da.Fill(DT)
                For i = 0 To DT.Rows.Count - 1
                    DataGridView1.Rows.Add(DT.Rows(i).Item(0))
                    DataGridView1.Rows(i).Cells(0).Value = DT.Rows(i)(0)
                    DataGridView1.Rows(i).Cells(1).Value = FormatNumber(DT.Rows(i)(1), 0)
                    DataGridView1.Rows(i).Cells(2).Value = FormatNumber(DT.Rows(i)(2), 0)
                    DataGridView1.Rows(i).Cells(3).Value = FormatNumber(DT.Rows(i)(3), 0)
                    DataGridView1.Rows(i).Cells(4).Value = FormatNumber(DT.Rows(i)(4), 0)
                Next
                Dim msj As String = da.SelectCommand.Parameters("@msj").Value
                MsgBox(msj, vbInformation)

                TextBox1.Clear()
                TextBox1.Focus()

            Catch ex As Exception ': MsgBox(ex.Message)
            End Try
            Cerrar()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub PromedioAumno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(212, 72)
    End Sub
End Class