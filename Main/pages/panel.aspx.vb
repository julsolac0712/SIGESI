Imports System.Threading
Imports System.Data.SqlClient
Imports System.Globalization

Public Class panel
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If (Not Request.QueryString("User") Is Nothing) Then
                hdf_Idioma.Value = Request.QueryString("lang")
                hdf_Usuario.Value = Request.QueryString("User")
                hdf_Operativo.Value = Request.QueryString("Per")

                Session("Idioma") = Request.QueryString("lang")
                Session("Usuario") = Request.QueryString("User")
                Session("lang") = Request.QueryString("lang")
                Session("NumOperativo") = Request.QueryString("Per")
            Else

                hdf_Idioma.Value = Session("Idioma")
                hdf_Usuario.Value = Session("Usuario")
                hdf_Operativo.Value = Session("NumOperativo")
            End If

            Dim dr As SqlDataReader
            dr = AccesoDatosAPPS.Get_SIOR_Usuario(Session("Usuario"))
            If (dr.HasRows) Then
                While dr.Read()
                    Session("Email") = dr.GetString(dr.GetOrdinal("Email"))
                End While
            End If
            ' cargar suma de porcentajes General
            hdf_CodigoEmpleado.Value = AccesoDatosAPPS.Get_ID_Funcionario(Session("Email"))
            If hdf_CodigoEmpleado.Value <> "*" Then
                Session("CodEmpleado") = hdf_CodigoEmpleado.Value

                Try
                    'Cargo el nombre del usuario
                    CargarDatosUsuario()

                Catch ex As ThreadAbortException
                Catch ex As Exception
                    Gestor_Errores.Escribir_Log(ex, "Error al cargar la página")
                End Try

            Else
                If hdf_Idioma.Value = "en" Then
                    Session("MensajeErr") = "Couldn't save the Information of the header of this Form."
                Else
                    Session("MensajeErr") = "El usuario no tiene los permisos requeridos"
                End If
                Response.Redirect("../Error/ErrorGeneral.aspx")
            End If
        End If


    End Sub

#Region "Generales"
    Private Sub CargarDatosUsuario()
        Try
            Dim datosFuncionario As String
            Dim arrValues() As String
            datosFuncionario = AccesoDatosAPPS.Get_Nombre_Funcionario(hdf_CodigoEmpleado.Value)
            If datosFuncionario IsNot Nothing Then
                arrValues = Split(datosFuncionario, ",")
                ltl_Responsable.Text = arrValues(0)
            End If
        Catch ex As Exception
            Gestor_Errores.Escribir_Log(ex, "Error al cargar los datos de usuario")
        End Try
    End Sub
#End Region


#Region "AccionesGrid"

    Protected Sub gv_ProyectosDetalle_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        Dim arrValues() As String
        arrValues = Split(CType(e.CommandArgument, String), ",")

        Session("CronoICTP01") = arrValues(0)
        Session("SubcronoICTP01") = arrValues(1)

        Try

            If e.CommandName.Equals("VerInstrumento") Then
                If e.CommandArgument IsNot Nothing And e.CommandArgument <> "" Then

                    Response.Redirect("Reporte_Indicadores.aspx?=" & Encryptor.Encrypt("OPER=planear&CronoICT=" & arrValues(0) & "&SubCronoICT=" & arrValues(1) & "&lang=" & hdf_Idioma.Value & "&User=" & hdf_Usuario.Value))

                End If
            End If


        Catch ex As Exception
            Gestor_Errores.Escribir_Log(ex, "Error al cargar formularios")
        End Try

    End Sub

#End Region


End Class