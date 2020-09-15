Imports System.Data.SqlClient

Public Class Common : Inherits Acceso_Datos

    Public Sub New(ByVal connectionString As String)
        MyBase.New(connectionString)
    End Sub

    Public Function Get_Funcionarios_Activos() As SqlDataReader
        Dim cmd As New SqlCommand("SIOR_get_Funcionarios_Activos", Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        Return Ejecutar_Consulta_DR(cmd)
    End Function

    Public Function Get_Paises(ByVal Idioma As String) As SqlDataReader
        Dim cmd As New SqlCommand("UTIL_Get_Lista_Paises", Conexion)
        cmd.Parameters.AddWithValue("@Idioma", SqlDbType.VarChar).Value = Idioma
        Return Ejecutar_Consulta_DR(cmd)
    End Function

    Public Function Get_Unidad_Oficinas_Activas()
        Dim cmd As New SqlCommand("SIOR_get_Unidades_Oficinas_Activas", Conexion)
        Return Ejecutar_Consulta_DR(cmd)
    End Function

    Public Function Get_SIOR_Usuario(ByVal idIntranet As Integer) As SqlDataReader
        Dim cmd As SqlCommand = New SqlCommand("SIOR_ObtenerUsuario", Conexion)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@usuario", idIntranet)

        Return Ejecutar_Consulta_DR(cmd)
    End Function

    Public Function Get_SIOR_ID_Email(ByVal email As String) As SqlDataReader
        Dim cmd As SqlCommand = New SqlCommand("SIOR_get_ID_Funcionario_Email", Conexion)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Email", email)

        Return Ejecutar_Consulta_DR(cmd)
    End Function

    Public Function GetUsuarioIntranetInfo(ByVal correo As String) As SqlDataReader
        Dim cmd As SqlCommand = New SqlCommand("gen_get_InfoUsuario2", Conexion)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@ID", correo)

        Return Ejecutar_Consulta_DR(cmd)
    End Function

    Public Function Get_Periodo() As SqlDataReader
        Dim cmd As SqlCommand = New SqlCommand("PE_ADM_Get_ObtienePeriodo", Conexion)

        cmd.CommandType = CommandType.StoredProcedure

        Return Ejecutar_Consulta_DR(cmd)
    End Function

End Class
