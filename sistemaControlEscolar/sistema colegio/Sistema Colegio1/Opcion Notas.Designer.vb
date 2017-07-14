<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Opcion_Notas
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbnreg = New System.Windows.Forms.RadioButton()
        Me.rbncons = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbntr = New System.Windows.Forms.RadioButton()
        Me.rbnrg = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlText
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkCyan
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(299, 32)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "SELECCIONE ACCION A REALIZAR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbnreg)
        Me.GroupBox1.Controls.Add(Me.rbncons)
        Me.GroupBox1.Location = New System.Drawing.Point(58, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(129, 68)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione"
        '
        'rbnreg
        '
        Me.rbnreg.AutoSize = True
        Me.rbnreg.Location = New System.Drawing.Point(18, 19)
        Me.rbnreg.Name = "rbnreg"
        Me.rbnreg.Size = New System.Drawing.Size(67, 17)
        Me.rbnreg.TabIndex = 0
        Me.rbnreg.Text = "Registrar"
        Me.rbnreg.UseVisualStyleBackColor = True
        '
        'rbncons
        '
        Me.rbncons.AutoSize = True
        Me.rbncons.Location = New System.Drawing.Point(18, 40)
        Me.rbncons.Name = "rbncons"
        Me.rbncons.Size = New System.Drawing.Size(69, 17)
        Me.rbncons.TabIndex = 1
        Me.rbncons.Text = "Consultar"
        Me.rbncons.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Sistema_Colegio.My.Resources.Resources.flecha_derecha
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(208, 49)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 47)
        Me.Button1.TabIndex = 44
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbntr)
        Me.GroupBox2.Controls.Add(Me.rbnrg)
        Me.GroupBox2.Location = New System.Drawing.Point(58, 125)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(129, 68)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'rbntr
        '
        Me.rbntr.AutoSize = True
        Me.rbntr.Location = New System.Drawing.Point(18, 19)
        Me.rbntr.Name = "rbntr"
        Me.rbntr.Size = New System.Drawing.Size(87, 17)
        Me.rbntr.TabIndex = 0
        Me.rbntr.Text = "Por Trimestre"
        Me.rbntr.UseVisualStyleBackColor = True
        '
        'rbnrg
        '
        Me.rbnrg.AutoSize = True
        Me.rbnrg.Location = New System.Drawing.Point(18, 40)
        Me.rbnrg.Name = "rbnrg"
        Me.rbnrg.Size = New System.Drawing.Size(103, 17)
        Me.rbnrg.TabIndex = 1
        Me.rbnrg.Text = "Reporte General"
        Me.rbnrg.UseVisualStyleBackColor = True
        '
        'Opcion_Notas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(299, 120)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Opcion_Notas"
        Me.Text = "Opcion_Notas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbnreg As System.Windows.Forms.RadioButton
    Friend WithEvents rbncons As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbntr As System.Windows.Forms.RadioButton
    Friend WithEvents rbnrg As System.Windows.Forms.RadioButton
End Class
