<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Horario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtHoraInicio = New System.Windows.Forms.TextBox()
        Me.txtHoraFin = New System.Windows.Forms.TextBox()
        Me.CbxDia = New System.Windows.Forms.ComboBox()
        Me.CbxCursos = New System.Windows.Forms.ComboBox()
        Me.CbxAula = New System.Windows.Forms.ComboBox()
        Me.txtDniDocente = New System.Windows.Forms.TextBox()
        Me.txtSeccion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnregistrar = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtHoraInicio)
        Me.GroupBox1.Controls.Add(Me.txtHoraFin)
        Me.GroupBox1.Controls.Add(Me.CbxDia)
        Me.GroupBox1.Controls.Add(Me.CbxCursos)
        Me.GroupBox1.Controls.Add(Me.CbxAula)
        Me.GroupBox1.Controls.Add(Me.txtDniDocente)
        Me.GroupBox1.Controls.Add(Me.txtSeccion)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(460, 157)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Horario de Clases"
        '
        'txtHoraInicio
        '
        Me.txtHoraInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHoraInicio.Enabled = False
        Me.txtHoraInicio.Location = New System.Drawing.Point(275, 117)
        Me.txtHoraInicio.MaxLength = 5
        Me.txtHoraInicio.Name = "txtHoraInicio"
        Me.txtHoraInicio.Size = New System.Drawing.Size(59, 20)
        Me.txtHoraInicio.TabIndex = 13
        '
        'txtHoraFin
        '
        Me.txtHoraFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHoraFin.Enabled = False
        Me.txtHoraFin.Location = New System.Drawing.Point(392, 117)
        Me.txtHoraFin.MaxLength = 5
        Me.txtHoraFin.Name = "txtHoraFin"
        Me.txtHoraFin.Size = New System.Drawing.Size(59, 20)
        Me.txtHoraFin.TabIndex = 13
        '
        'CbxDia
        '
        Me.CbxDia.Enabled = False
        Me.CbxDia.FormattingEnabled = True
        Me.CbxDia.Items.AddRange(New Object() {"Seleccione", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes"})
        Me.CbxDia.Location = New System.Drawing.Point(99, 118)
        Me.CbxDia.Name = "CbxDia"
        Me.CbxDia.Size = New System.Drawing.Size(136, 21)
        Me.CbxDia.TabIndex = 12
        '
        'CbxCursos
        '
        Me.CbxCursos.Enabled = False
        Me.CbxCursos.FormattingEnabled = True
        Me.CbxCursos.Location = New System.Drawing.Point(290, 52)
        Me.CbxCursos.Name = "CbxCursos"
        Me.CbxCursos.Size = New System.Drawing.Size(161, 21)
        Me.CbxCursos.TabIndex = 11
        '
        'CbxAula
        '
        Me.CbxAula.Enabled = False
        Me.CbxAula.FormattingEnabled = True
        Me.CbxAula.Items.AddRange(New Object() {"Seleccione", "1", "2", "3", "4", "5"})
        Me.CbxAula.Location = New System.Drawing.Point(35, 53)
        Me.CbxAula.Name = "CbxAula"
        Me.CbxAula.Size = New System.Drawing.Size(121, 21)
        Me.CbxAula.TabIndex = 10
        '
        'txtDniDocente
        '
        Me.txtDniDocente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDniDocente.Enabled = False
        Me.txtDniDocente.Location = New System.Drawing.Point(171, 53)
        Me.txtDniDocente.MaxLength = 8
        Me.txtDniDocente.Name = "txtDniDocente"
        Me.txtDniDocente.Size = New System.Drawing.Size(85, 20)
        Me.txtDniDocente.TabIndex = 9
        '
        'txtSeccion
        '
        Me.txtSeccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSeccion.Enabled = False
        Me.txtSeccion.Location = New System.Drawing.Point(24, 119)
        Me.txtSeccion.MaxLength = 1
        Me.txtSeccion.Name = "txtSeccion"
        Me.txtSeccion.ReadOnly = True
        Me.txtSeccion.Size = New System.Drawing.Size(43, 20)
        Me.txtSeccion.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(389, 101)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "&Hora de Fin"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(272, 99)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "&Hora de Inicio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(287, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Curso"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(96, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "&Dia"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "&Seccion"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(168, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "&Dni Docente"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "&Aula"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.btnregistrar)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(479, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(107, 156)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Realizar Acciones"
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.Sistema_Colegio.My.Resources.Resources.Salir
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Location = New System.Drawing.Point(11, 104)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(87, 42)
        Me.Button3.TabIndex = 2
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnregistrar
        '
        Me.btnregistrar.BackgroundImage = Global.Sistema_Colegio.My.Resources.Resources.Registrar
        Me.btnregistrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnregistrar.Enabled = False
        Me.btnregistrar.Location = New System.Drawing.Point(11, 52)
        Me.btnregistrar.Name = "btnregistrar"
        Me.btnregistrar.Size = New System.Drawing.Size(87, 42)
        Me.btnregistrar.TabIndex = 1
        Me.btnregistrar.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(19, 33)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(54, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "&Iniciar"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 190)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(574, 182)
        Me.DataGridView1.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.HeaderText = "Día"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Hora Inicio"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 80
        '
        'Column3
        '
        Me.Column3.HeaderText = "Hora Fin"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 80
        '
        'Column4
        '
        Me.Column4.HeaderText = "Sección"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 50
        '
        'Column5
        '
        Me.Column5.HeaderText = "Grado"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 50
        '
        'Column6
        '
        Me.Column6.HeaderText = "Dni Docente"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Código Curso"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 70
        '
        'Horario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(609, 390)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Horario"
        Me.Text = "FrmHorario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSeccion As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnregistrar As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtDniDocente As System.Windows.Forms.TextBox
    Friend WithEvents CbxAula As System.Windows.Forms.ComboBox
    Friend WithEvents CbxCursos As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbxDia As System.Windows.Forms.ComboBox
    Friend WithEvents txtHoraInicio As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraFin As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
