Public Class ConsultaHorariosDocentes

    Private Sub FrmConsultaHorariosDocentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        Me.Location = New Point(212, 72)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 1 Then
            Dim m As New Manuel
            m.ShowDialog()
        ElseIf ComboBox1.SelectedIndex = 2 Then
            Dim m As New Maria
            m.ShowDialog()
        ElseIf ComboBox1.SelectedIndex = 3 Then
            Dim m As New Carlos
            m.ShowDialog()
        ElseIf ComboBox1.SelectedIndex = 4 Then
            Dim m As New Gerardo
            m.ShowDialog()
        ElseIf ComboBox1.SelectedIndex = 5 Then
            Dim m As New Alex
            m.ShowDialog()
        ElseIf ComboBox1.SelectedIndex = 6 Then
            Dim m As New Martha
            m.ShowDialog()
        ElseIf ComboBox1.SelectedIndex = 7 Then
            Dim m As New Walter
            m.ShowDialog()
        End If
    End Sub
End Class