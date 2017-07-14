Public Class MenuPrincipal

    Private Sub btnalu_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub btnapod_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub btndoc_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub btnau_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub btnnot_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub btnmat_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        btnalumno.BackColor = Color.CadetBlue
    End Sub

    Private Sub btnapod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Me.Text = Mid(Me.Text, 2) + Microsoft.VisualBasic.Left(Me.Text, 1)

    End Sub

    Private Sub btnmat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub btnnot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX.Click
        Dim confirma = MsgBox("Está seguro que Desea Salir?", vbYesNo + vbExclamation, "Atención!!")
        If confirma = vbYes Then
            Me.Close()
            Close()
        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.WindowState = 1
    End Sub

    Private Sub MenuPrincipal_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        cargarimages()
        cargarbuttons()

    End Sub


    Private Sub btnalu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub btndoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub btnau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnalumno.Click
        Dim ra As New RegAl
        ra.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnapoderado.Click
        Dim ra As New Opcion_Apoderado
        ra.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaulas.Click
        Dim au As New Aula
        au.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim nt As New Opcion_Notas
        nt.ShowDialog()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles year.Click
        Dim a As New RegAño
        a.ShowDialog()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndocente.Click
        Dim dc As New Opcion_Docente
        dc.ShowDialog()

    End Sub

    Private Sub Button1_MouseMove_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnalumno.MouseMove
        btnalumno.BackColor = Color.SkyBlue
        btnapoderado.BackColor = Color.LightBlue
        btnaulas.BackColor = Color.LightBlue
        Button4.BackColor = Color.LightBlue
        year.BackColor = Color.LightBlue
        btndocente.BackColor = Color.LightBlue
    End Sub

    Private Sub Button2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnapoderado.MouseMove
        btnapoderado.BackColor = Color.SkyBlue
        btnalumno.BackColor = Color.LightBlue
        btnaulas.BackColor = Color.LightBlue
        Button4.BackColor = Color.LightBlue
        year.BackColor = Color.LightBlue
        btndocente.BackColor = Color.LightBlue
    End Sub

    Private Sub Button3_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnaulas.MouseMove
        btnaulas.BackColor = Color.SkyBlue
        btnapoderado.BackColor = Color.LightBlue
        btnalumno.BackColor = Color.LightBlue
        Button4.BackColor = Color.LightBlue
        year.BackColor = Color.LightBlue
        btndocente.BackColor = Color.LightBlue
    End Sub

    Private Sub Button4_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button4.MouseMove
        Button4.BackColor = Color.SkyBlue
        btnaulas.BackColor = Color.LightBlue
        btnalumno.BackColor = Color.LightBlue
        btnapoderado.BackColor = Color.LightBlue
        year.BackColor = Color.LightBlue
        btndocente.BackColor = Color.LightBlue
    End Sub

    Private Sub Button5_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles year.MouseMove
        year.BackColor = Color.SkyBlue
        Button4.BackColor = Color.LightBlue
        btnaulas.BackColor = Color.LightBlue
        btnalumno.BackColor = Color.LightBlue
        btnapoderado.BackColor = Color.LightBlue
        btndocente.BackColor = Color.LightBlue
    End Sub

    Private Sub Button6_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btndocente.MouseMove
        btndocente.BackColor = Color.SkyBlue
        year.BackColor = Color.LightBlue
        btnaulas.BackColor = Color.LightBlue
        btnalumno.BackColor = Color.LightBlue
        btnapoderado.BackColor = Color.LightBlue
        Button4.BackColor = Color.LightBlue
    End Sub

    Private Sub cargarimages()


    End Sub

    Private Sub cargarbuttons()
        btnalumno.BackColor = Color.LightBlue
        btnapoderado.BackColor = Color.LightBlue
        btnaulas.BackColor = Color.LightBlue
        Button4.BackColor = Color.LightBlue
        year.BackColor = Color.LightBlue
        btndocente.BackColor = Color.LightBlue
    End Sub


    Private Sub MenuPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbuttons()
        cargarimages()
        definirprivilegios()
        centrarmenu()
    End Sub

    Private Sub centrarmenu()
        Dim AnchoForm As Integer = Me.Size.Width()
        Dim AltoForm As Integer = Me.Size.Height()
        'Me.Size.Hei


        ' MsgBox(AltoForm & " O" & posy)

        PictureBox2.Location = New Point((Me.Width / 2) - (PictureBox2.Width / 2), PictureBox2.Location.Y)
    End Sub



    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'cada segundo debemos de mostrar la hora
        lblhora.Text = Now.ToLongTimeString() 'Hora en formato largo
        lblfecha.Text = Now.ToShortDateString() 'fecha en formato corto
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New RegAño
        a.ShowDialog()
    End Sub

    Private Sub definirprivilegios()
        'If usuario = "Alex" Or usuario = "Christopher" Or usuario = "Juan" Then
        '    btnalu.Enabled = False
        '    btnapod.Enabled = False
        '    btnau.Enabled = False
        '    btndoc.Enabled = False
        'End If
        year.Visible = True
        If usuario = "UsuarioA" Or usuario = "USUARIOA" Or usuario = "usuarioa" Or usuario = "UsuarioB" Or usuario = "USUARIOB" Or usuario = "usuariob" Or usuario = "UsuarioC" Or usuario = "USUARIOC" Or usuario = "usuarioc" Then

            btnalumno.Enabled = False

            btnapoderado.Enabled = False

            year.Enabled = False

            btnaulas.Enabled = False

            btndocente.Enabled = False

            year.Visible = False
            year.Image = My.Resources.Horario

            ' ptbinsignia.Image = My.Resources.Insignia_NIXA
        Else
            If usuario = "secretaria" Or usuario = "Secretaria" Or usuario = "SECRETARIA" Then

                year.Enabled = False
                year.Image = My.Resources.Horario

            End If
        End If

    End Sub

    Private Sub ptbinsignia_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pToolsBox_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub btnmatricula_Click(sender As Object, e As EventArgs) Handles btnmatricula.Click
        Dim mt As New Opcion_Matricula
        mt.ShowDialog()
    End Sub
End Class