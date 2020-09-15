Imports System.Data.SqlClient

Public Class logon
    Inherits System.Web.UI.Page

    Dim AccesoDatos As New BaseUtility(ConfigurationManager.ConnectionStrings("Intranet").ToString())

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_Login_Click(sender As Object, e As EventArgs)
        Dim lector As SqlDataReader = AccesoDatos.GetUsuarioIntranetInfo(txt_CorreoUsuario.Text.Trim)
        Dim authTicket As FormsAuthenticationTicket
        Dim authCookie As HttpCookie
        Dim idIntranet As Integer = 0
        Dim correo As String = String.Empty
        If (lector.HasRows) Then
            While lector.Read()
                idIntranet = lector.GetInt32(lector.GetOrdinal("ID"))
                correo = lector.GetString(lector.GetOrdinal("usuario"))
            End While
        End If
        authTicket = New FormsAuthenticationTicket(1, correo, DateTime.Now, DateTime.Now.AddHours(1), True, 1)
        authCookie = New HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket))
        authCookie.Path = FormsAuthentication.FormsCookiePath

        Response.Cookies.Add(authCookie)
        Response.Cookies.Add(New HttpCookie("UsrIntranet", idIntranet))

        Response.Redirect(FormsAuthentication.GetRedirectUrl(correo, False))
    End Sub

End Class