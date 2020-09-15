Public Class _Default
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Get_Cookie_Intranet()
        Session("UsuarioIntranet") = IDIntranet
    End Sub

End Class