Imports System.Data
Imports Generic
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Globalization

Public Class BasePage
    Inherits System.Web.UI.Page

    Protected AccesoDatos As New BaseUtility(ConfigurationManager.ConnectionStrings("SIGESIConnection").ToString())
    Protected AccesoDatosAPPS As New BaseUtility(ConfigurationManager.ConnectionStrings("IICA_APPSConnection").ToString)
    Protected gestorCorreos As New Generic.Mailing(ConfigurationManager.AppSettings("AdminMail"), "SIGESI", ConfigurationManager.AppSettings("ServerMail"), CType(ConfigurationManager.AppSettings.Get("ServerMailPort"), Integer))
    Protected Encryptor As New Encryptor.Encryptor()
    Protected Cookies As New Cookies()
    Protected Gestor_Errores As New Error_Handling.Error_Handling(ConfigurationManager.AppSettings("LogPath"))
    Protected IDIntranet As Integer?
    Protected IDSIOR As Integer?

    Protected Overrides Sub InitializeCulture()
        MyBase.InitializeCulture()
        'If (Not String.IsNullOrEmpty(Request("lang"))) Then
        '    Session("lang") = Request("lang")
        'End If

        If (String.IsNullOrEmpty(Session("lang"))) Then
            Session("lang") = "es"
        End If

        Dim lang As String = Convert.ToString(Session("lang"))
        Dim culture As String = String.Empty

        If (lang.ToLower().CompareTo("es") = 0 Or String.IsNullOrEmpty(lang)) Then
            culture = "es-CR"
        Else
            If (lang.ToLower().CompareTo("en") = 0) Then
                culture = "en-US"
            End If
        End If

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
    End Sub

#Region "Autenticaciones"
    Protected Sub Get_Cookie_Intranet()
        Dim cookieIntranet = Cookies.getCookie(Request.Cookies, "UsrIntranet")
        If Not String.IsNullOrEmpty(cookieIntranet) Then
            IDIntranet = CType(cookieIntranet, Integer)
        End If
    End Sub

    Protected Function Get_SIOR_ID(ByVal idIntranet As Integer) As String
        Dim SIORID As String = String.Empty
        Dim lector As SqlDataReader = AccesoDatos.Get_SIOR_Usuario(idIntranet)
        If lector.HasRows Then
            While lector.Read()
                SIORID = lector.GetInt32(lector.GetOrdinal("ID_Funcionario")).ToString()
            End While
        End If
        Return SIORID
    End Function

    Protected Function Get_PeriodoEstrategico_ID() As Integer
        Dim ID As String = String.Empty
        Dim lector As SqlDataReader = AccesoDatos.Get_Periodo()
        If lector.HasRows Then
            While lector.Read()
                ID = lector.GetInt32(lector.GetOrdinal("id_periodo"))
            End While
        End If
        Return ID
    End Function
#End Region

#Region "File Helpers"

    Protected Overloads Function DescargarArchivo(ByVal path As String, ByVal nombreArchivo As String, Optional borrarArchivo As Boolean = False) As Boolean
        Dim objFileInfo As System.IO.FileInfo
        Try
            If (Not (System.IO.File.Exists(path))) Then
                Session("StatusError") = "<p>El archivo a generar no existe. Favor comuníquese con su Administrador</p>"
                Return False
            End If

            objFileInfo = New System.IO.FileInfo(path)
            Response.Clear()
            If (nombreArchivo Is Nothing) Then
                Response.AddHeader("Content-Disposition", "attachment; filename=" + objFileInfo.Name)
            Else
                Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivo & objFileInfo.Extension)
            End If
            Response.AddHeader("Content-Length", Convert.ToString(objFileInfo.Length))

            Response.ContentType = "application/octet-stream"
            Response.WriteFile(objFileInfo.FullName)
            Response.Flush()
            If (borrarArchivo) Then
                System.IO.File.Delete(path)
            End If
            Response.End()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function


#End Region

End Class
