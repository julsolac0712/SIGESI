Public Class SiteMaster
    Inherits MasterPage
    Private Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Private Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Private _antiXsrfTokenValue As String

    Protected Sub Page_Init(sender As Object, e As EventArgs)
        ' The code below helps to protect against XSRF attacks
        Dim requestCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If requestCookie IsNot Nothing AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue) Then
            ' Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie = New HttpCookie(AntiXsrfTokenKey) With {
                 .HttpOnly = True,
                 .Value = _antiXsrfTokenValue
            }
            If FormsAuthentication.RequireSSL AndAlso Request.IsSecureConnection Then
                responseCookie.Secure = True
            End If
            Response.Cookies.[Set](responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Protected Sub master_Page_PreLoad(sender As Object, e As EventArgs)
        If Not IsPostBack Then
            ' Set Anti-XSRF token
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, [String].Empty)
        Else
            ' Validate the Anti-XSRF token
            If DirectCast(ViewState(AntiXsrfTokenKey), String) <> _antiXsrfTokenValue OrElse DirectCast(ViewState(AntiXsrfUserNameKey), String) <> (If(Context.User.Identity.Name, [String].Empty)) Then
                Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Procesar_Status()
    End Sub

    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
        Context.GetOwinContext().Authentication.SignOut()
    End Sub

    Private Sub Procesar_Status()
        'Procesa mensajes de estado
        If (Not Session("Status") Is Nothing) Then
            If (Not String.IsNullOrEmpty(Session("Status").ToString())) Then
                pnl_Status.Visible = True
                lit_Status_Message.Text = Session("Status").ToString()
            Else
                pnl_Status.Visible = False
            End If
            Session.Remove("Status")
        End If
        'Procesa mensajes de error
        If (Not Session("StatusError") Is Nothing) Then
            If (Not String.IsNullOrEmpty(Session("StatusError").ToString())) Then
                pnl_Errores.Visible = True
                lit_Error_Message.Text = Session("StatusError").ToString()
            Else
                pnl_Errores.Visible = False
            End If
            Session.Remove("StatusError")
        End If
    End Sub

    Protected Sub lnk_Espanol_Click(sender As Object, e As EventArgs)
        Session("lang") = "es"
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub lnk_Ingles_Click(sender As Object, e As EventArgs)
        Session("lang") = "en"
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub lnk_Portugues_Click(sender As Object, e As EventArgs)
        Session("lang") = "pt"
        Response.Redirect(Request.RawUrl)
    End Sub
End Class