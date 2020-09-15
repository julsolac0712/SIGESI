Imports System.Web

Public Class Cookies
    Public Function getCookie(ByVal MyCookies As HttpCookieCollection, ByVal cookie As String) As String
        Dim MyCookie As HttpCookie
        MyCookie = MyCookies(cookie)

        If MyCookie Is Nothing Then
            Return ""
        Else
            Return MyCookie.Value
        End If
    End Function
End Class
