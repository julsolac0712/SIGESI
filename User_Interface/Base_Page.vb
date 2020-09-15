Imports System.Threading
Imports System.Globalization
Imports System.Web.UI.WebControls

Public Class Base_Page
    Inherits System.Web.UI.Page

    Protected IDIntranet As Integer?
    Protected IDSIOR As Integer?

    'Inicializa las culturas
    Protected Overrides Sub InitializeCulture()
        MyBase.InitializeCulture()

        If (Request.QueryString().Count > 0) Then
            If (Not String.IsNullOrEmpty(Request.QueryString("LG"))) Then
                Session("lang") = Request.QueryString("LG")
            End If
        End If 'Si el lenguaje viene en el QueryString

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
            Else 'Si no es un lenguaje conocido
                culture = "es-CR"
            End If
        End If

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
    End Sub

#Region "Helpers"
    'Imprime un checkbox con un check si la opción está seleccionada, sino imprime el checkbox con una X
    Protected Function Print_Selected(ByVal opcion As Boolean) As String
        If (opcion) Then
            Return "<span class='glyphicon glyphicon-ok glyphicon-checkbox'></span>"
        Else
            Return "<span class='glyphicon glyphicon-remove glyphicon-checkbox'></span>"
        End If
    End Function

    Protected Sub ChangeFormViewMode(ByRef FormView As FormView, ByVal Operacion As String)
        If (Operacion = "agregar") Then
            FormView.ChangeMode(FormViewMode.Insert)
        ElseIf (Operacion = "editar") Then
            FormView.ChangeMode(FormViewMode.Edit)
        Else
            FormView.ChangeMode(FormViewMode.ReadOnly)
        End If
    End Sub

    Protected Sub FormViewButtonFunctionality(ByRef button As Button, ByVal fv_Mode As FormViewMode)
        If (fv_Mode = FormViewMode.Insert) Then
            button.CommandName = "Insert"
        ElseIf (fv_Mode = FormViewMode.Edit) Then
            button.CommandName = "Update"
        End If
    End Sub
    'Renderiza si o no segun el parametro ingresado
    Protected Function RenderBooleanSimple(ByVal value As Boolean) As String
        If (value) Then
            If (Session("lang") = "es") Then
                Return "Sí"
            Else
                Return "Yes"
            End If
        Else
            Return "No"
        End If
    End Function

    Protected Function GetDateFormat(Optional opcion As Integer = 1) As String
        If (opcion = 1) Then 'Estándar para eval en español e inglés
            If (Session("lang") = "en") Then
                Return "{0:MM/dd/yyyy}"
            Else
                Return "{0:dd/MM/yyyy}"
            End If
        ElseIf (opcion = 2) Then 'Estándar de ISO.
            Return "{0:yyyy/MM/dd}"
        ElseIf (opcion = 3) Then 'Estándar en español e inglés para cuando no es en eval
            If (Session("lang") = "en") Then
                Return "MM/dd/yyyy"
            Else
                Return "dd/MM/yyyy"
            End If
        End If
        Return "{0:MM/dd/yyyy}"
    End Function

    Protected Function GetDateTimeFormat() As String
        If (Session("lang") = "en") Then
            Return "{0:MM/dd/yyyy hh:mm tt}"
        Else
            Return "{0:dd/MM/yyyy hh:mm tt}"
        End If
    End Function

    Protected Function RenderURL(ByVal url As String) As String
        Return Server.UrlEncode(url)
    End Function

    Protected Function DescargarArchivo(ByVal path As String, Optional borrarArchivo As Boolean = False) As Boolean
        Dim objFileInfo As System.IO.FileInfo
        Try
            If (Not (System.IO.File.Exists(path))) Then
                Session("StatusError") = "<p>El archivo a generar no existe. Favor comuníquese con su Administrador</p>"
                Return False
            End If

            objFileInfo = New System.IO.FileInfo(path)
            Response.Clear()

            Response.AddHeader("Content-Disposition", "attachment; filename=" + objFileInfo.Name)
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
    Protected Sub SetStatusMessage(mensaje As String)
        Session("Status") = mensaje
    End Sub
    Protected Sub SetErrorMessage(mensaje As String)
        Session("StatusError") = mensaje
    End Sub
#End Region

#Region "Grid View Helpers"

    Protected Sub GridView_Row_Created_Setup(ByRef sender As Object, ByRef e As GridViewRowEventArgs)
        Try
            If e.Row.RowIndex <> -1 Then

                If CType(sender, GridView).DataKeys(e.Row.RowIndex).Values(0) = 0 Then

                    Dim btn As LinkButton

                    btn = CType(e.Row.FindControl("lnk_Delete"), LinkButton)

                    If Not btn Is Nothing Then
                        btn.Visible = False
                    End If

                    btn = CType(e.Row.FindControl("lnk_Edit"), LinkButton)

                    If Not btn Is Nothing Then
                        btn.Visible = False
                    End If

                    btn = CType(e.Row.FindControl("lnk_Add"), LinkButton)

                    If Not btn Is Nothing Then
                        btn.Visible = True
                    End If

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
