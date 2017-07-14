'Option Explicit On
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Public conexion As New SqlConnection("Data Source=DESKTOP-JFQ35K6\CARLOS23;Initial Catalog=COLEGIO;Integrated Security=True")


    Sub abrir()
        If conexion.State = 0 Then
            conexion.Open()
        End If
    End Sub
    Public codal As String
    Public codap As String
    Public usuario As String
    Sub Cerrar()
        If conexion.State = 1 Then
            conexion.Close()
        End If
    End Sub
End Module
