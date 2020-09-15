Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports System.Globalization
Imports System.Net.Mail
Imports System.IO
Public Class BaseUtility : Inherits Utility.Common

#Region "Generales"

    Public Shared lang As String
    Private Shared CulturaActual As System.Globalization.CultureInfo

    Public Sub New(ByVal connectionString As String)
        MyBase.New(connectionString)
    End Sub

    Public Shared Function getConnStringSUGI() As String
        Dim connString As String
        connString = ConfigurationManager.AppSettings.Get("connStringSUGI")
        Return connString
    End Function

#End Region

    Public Shared Function getLanguage() As String
        Return lang
    End Function

    Public Shared Sub setLanguage(ByVal MyCookies As HttpCookieCollection)

        Dim valorCookie As String = String.Empty
        valorCookie = getCookie(MyCookies, "Lang")
        If valorCookie = "es" Or valorCookie = "en" Then
            lang = valorCookie
        Else
            lang = "es"
        End If
    End Sub

    Public Shared Function getCookie(ByVal MyCookies As HttpCookieCollection, ByVal cookie As String) As String
        Dim MyCookie As HttpCookie
        MyCookie = MyCookies(cookie)
        If MyCookie Is Nothing Then
            Return Nothing
        Else
            Return MyCookie.Value
        End If
    End Function

    Public Shared Function getInfoUser(ByVal us As Integer) As String

        Dim informacion As String
        Dim conn As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim sqlDA As SqlDataAdapter
        Dim sqlDS As New DataSet
        Dim dr As DataRow

        conn = New SqlConnection(getConnStringSUGI)

        sqlCmd = New SqlCommand("cps2_seg_get_infoUsuario", conn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.Parameters.AddWithValue("@iduser", us)
        sqlDA = New SqlDataAdapter(sqlCmd)

        informacion = String.Empty
        Try
            conn.Open()
            sqlDA.Fill(sqlDS)

            If sqlDS.Tables(0).Rows.Count <> 0 Then
                For Each dr In sqlDS.Tables(0).Rows

                    If Not IsDBNull(dr.Item("Nombre")) Then
                        informacion = CType(dr.Item("Nombre"), String)
                    End If

                    If Not IsDBNull(dr.Item("correo")) Then
                        informacion = informacion + "," + CType(dr.Item("correo"), String)
                    End If

                    If Not IsDBNull(dr.Item("Rol")) Then
                        informacion = informacion + "," + CType(dr.Item("Rol"), String)
                    End If

                Next
            Else
                'NO existe como usuario CPS
                informacion = Nothing
            End If


        Catch ex As Exception
            conn.Close()
        Finally
            conn.Close()
        End Try
        getInfoUser = informacion
    End Function



#Region "Formulario Indicadores"
    Public Function ValidaFormulario(ByVal Periodo As Integer, ByVal CronoICT As Integer, ByVal SubCronoICT As String, ByVal Usuario As Integer) As Boolean
        Dim cmd As New SqlCommand("PE_ADM_Valida_Formulario", Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("Periodo", Periodo)
        cmd.Parameters.AddWithValue("CronoICT", CronoICT)
        cmd.Parameters.AddWithValue("SubCronoICT", SubCronoICT)
        cmd.Parameters.AddWithValue("Operacion", 1)
        cmd.Parameters.AddWithValue("Usuario", Usuario)
        Return Ejecutar_Consulta_TF(cmd)
    End Function

    Public Function InfoIndicadores(ByVal Periodo As Integer, ByVal CronoICT As Integer, ByVal SubCronoICT As String, ByVal Usuario As Integer) As Boolean
        Dim cmd As New SqlCommand("PE_ADM_Info_Indicadores", Conexion)
        cmd.Parameters.AddWithValue("Operacion", 1)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("Periodo", Periodo)
        cmd.Parameters.AddWithValue("CronoICT", CronoICT)
        cmd.Parameters.AddWithValue("SubCronoICT", SubCronoICT)
        Return Ejecutar_Consulta_TF(cmd)
    End Function

    Public Function Get_ID_Funcionario(ByVal CorreoUsuario As String) As String

        Dim conn As SqlClient.SqlConnection
        Dim sqlCmd As SqlClient.SqlCommand
        Dim sqlDA As SqlClient.SqlDataAdapter
        Dim sqlDS As New DataSet
        Dim dt_dtInfoUsuario As DataTable
        Dim ID_Funcionario As String = String.Empty
        conn = New SqlClient.SqlConnection(ConfigurationManager.AppSettings.Get("IICA_APPSConnection"))
        sqlCmd = New SqlClient.SqlCommand("SIOR_get_ID_Funcionario_Email", conn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.Parameters.AddWithValue("@Email", CorreoUsuario)
        sqlDA = New SqlClient.SqlDataAdapter(sqlCmd)
        Try
            conn.Open()
            sqlDA.Fill(sqlDS)
            If sqlDS IsNot Nothing Then
                If (sqlDS.Tables("Table").Rows.Count() > 0) Then
                    dt_dtInfoUsuario = sqlDS.Tables("Table")
                    ID_Funcionario = dt_dtInfoUsuario.Rows(0).Item("Cod_Empleado").ToString()
                End If
            End If
        Catch ex As Exception
            conn.Close()
        Finally
            'retorna el contenido 
            conn.Close()
        End Try
        Return ID_Funcionario

    End Function

    Public Function Get_Nombre_Funcionario(ByVal Codigo As String) As String
        Dim conn As SqlClient.SqlConnection
        Dim sqlCmd As SqlClient.SqlCommand
        Dim sqlDA As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim ID_Funcionario As String = String.Empty
        Dim dt_dtInfoUsuario As DataTable

        conn = New SqlClient.SqlConnection(ConfigurationManager.AppSettings.Get("IICA_APPSConnection"))

        sqlCmd = New SqlClient.SqlCommand("SIOR_get_Funcionario_x_Codigo", conn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.Parameters.AddWithValue("@Cod_Empleado", Codigo)
        sqlDA = New SqlClient.SqlDataAdapter(sqlCmd)
        Try
            conn.Open()
            sqlDA.Fill(ds)
            If ds IsNot Nothing Then
                If (ds.Tables("Table").Rows.Count() > 0) Then
                    dt_dtInfoUsuario = ds.Tables("Table")
                    ID_Funcionario = dt_dtInfoUsuario.Rows(0).Item("Nombre").ToString() + " " + dt_dtInfoUsuario.Rows(0).Item("Primer_Apellido").ToString()
                    ID_Funcionario = CType((ID_Funcionario + "," + dt_dtInfoUsuario.Rows(0).Item("Email")), String)
                    ID_Funcionario = ID_Funcionario + "," + CType(dt_dtInfoUsuario.Rows(0).Item("ID_Funcionario"), String)
                    ID_Funcionario = ID_Funcionario + "," + CType(dt_dtInfoUsuario.Rows(0).Item("Email"), String)
                End If
            End If
        Catch ex As Exception
            ds = Nothing
            conn.Close()
        Finally
            conn.Close()
        End Try

        Return ID_Funcionario

    End Function

#End Region

End Class
