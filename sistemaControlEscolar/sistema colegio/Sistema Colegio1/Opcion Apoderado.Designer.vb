<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Opcion_Apoderado
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbnreg = New System.Windows.Forms.RadioButton()
        Me.rbncons = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(279, 32)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "SELECCIONE ACCION A REALIZAR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbnreg)
        Me.GroupBox1.Controls.Add(Me.rbncons)
        Me.GroupBox1.Location = New System.Drawing.Point(45, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(113, 66)
        Me.GroupBox1.TabIndex = 33
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
        'btnir
        '
        Me.btnir.BackgroundImage = Global.Sistema_Colegio.My.Resources.Resources.flecha_derecha
        Me.btnir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnir.FlatAppearance.BorderSize = 0
        Me.btnir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnir.Location = New System.Drawing.Point(173, 54)
        Me.btnir.Name = "btnir"
        Me.btnir.Size = New System.Drawing.Size(65, 47)
        Me.btnir.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnir, "Ir")
        Me.btnir.UseVisualStyleBackColor = True
        '
        'Opcion_Apoderado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(279, 131)
        Me.Controls.Add(Me.btnir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Opcion_Apoderado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbnreg As System.Windows.Forms.RadioButton
    Friend WithEvents rbncons As System.Windows.Forms.RadioButton
    Friend WithEvents btnir As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
