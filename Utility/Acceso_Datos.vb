Imports System.Data.SqlClient

Public Class Acceso_Datos

    Protected Conexion As SqlConnection

    Public Sub New(ByVal connectionString As String)
        Conexion = New SqlConnection(connectionString)
    End Sub
#Region "Generales"
    'Ejecuto una funcion escalar.
    Protected Function Ejecutar_Consulta_Escalar(ByVal consulta As SqlCommand) As Object
        Dim datos As Object = Nothing
        Try
            If (Conexion.State = ConnectionState.Closed) Then
                Conexion.Open()
            End If
            datos = consulta.ExecuteScalar()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            Conexion.Close()
        End Try
        Return datos
    End Function
    'Ejecuta la consulta como un DataSet
    Protected Function Ejecutar_Consulta_DS(ByVal consulta As SqlCommand) As Data.DataSet
        Dim DS As New Data.DataSet
        Dim datos As New SqlDataAdapter(consulta)
        Try
            If (Conexion.State = ConnectionState.Closed) Then
                consulta.Connection.Open()

            End If
            datos.Fill(DS)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            consulta.Connection.Close()
        End Try
        Return DS
    End Function
    'Ejecuto la consulta como un DataReader
    Protected Function Ejecutar_Consulta_DR(ByVal Consulta As SqlCommand) As SqlDataReader
        Dim datos As SqlDataReader = Nothing
        Try
            If (Conexion.State = ConnectionState.Closed) Then
                Conexion.Open()
            End If
            datos = Consulta.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Return datos
    End Function
    'Ejecuto la consulta escalar
    Protected Function Ejecutar_Consulta_NQ(ByVal Consulta As SqlCommand) As Integer
        Dim retorno As Integer = 0
        Try
            If (Conexion.State = ConnectionState.Closed) Then
                Conexion.Open()
            End If
            retorno = Consulta.ExecuteNonQuery()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            Consulta.Connection.Close()
        End Try
        Return retorno
    End Function
    Protected Function Ejecutar_Consulta_TF(ByVal Consulta As SqlCommand) As Boolean
        Dim valor As Boolean = False
        Dim datos As SqlDataReader = Nothing
        Try
            If (Conexion.State = ConnectionState.Closed) Then
                Conexion.Open()
            End If
            valor = Consulta.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Return valor
    End Function

#End Region

End Class

