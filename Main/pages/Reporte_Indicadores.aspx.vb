Public Class Reporte_Indicadores
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim QueryString As New Hashtable()
            QueryString = Encryptor.ConvertStringToHashtable(Encryptor.Decrypt(Request.QueryString(0)))
            If (Not QueryString("OPER") Is Nothing) Then

                hdf_Idioma.Value = QueryString("lang")
                hdf_Usuario.Value = QueryString("User")

                hdf_CronoICT.Value = QueryString("CronoICT")
                hdf_SubCronoICT.Value = QueryString("SubCronoICT")
                hdf_PeriodoEstrategico.Value = 1


                Session("Idioma") = QueryString("lang")
                Session("Usuario") = QueryString("User")
                Session("lang") = QueryString("lang")

                gv_declaraciones.DataBind()

            End If


        End If

    End Sub

#Region "Indicadores Estratégicos"

    Protected Sub gv_Indicadores_RowCreated(sender As Object, e As GridViewRowEventArgs)
        Try
            If e.Row.RowIndex <> -1 Then

                If CType(sender, GridView).DataKeys(e.Row.RowIndex).Values(1) = 5 And CType(sender, GridView).DataKeys(e.Row.RowIndex).Values(0) > 0 Then

                    Dim btn As LinkButton

                    btn = CType(e.Row.FindControl("lnk_DCT"), LinkButton)

                    If Not btn Is Nothing Then
                        btn.Visible = True
                    End If

                End If

            End If
        Catch ex As Exception
            Gestor_Errores.Escribir_Log(ex, "Error al crear el grid")
        End Try
    End Sub
    Protected Sub gv_Indicadores_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs)
        If e.Exception IsNot Nothing Then
            e.ExceptionHandled = True
            Gestor_Errores.Escribir_Log(e.Exception, "Error de Registro de Indicador - Update")
        End If
    End Sub

    Protected Sub gv_Indicadores_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        If (e.Keys(0) = 0) Then
            hdf_Operacion.Value = 1
        Else
            hdf_Operacion.Value = 2
        End If
    End Sub


#End Region

#Region "Metricas"
    Protected Sub gv_Metricas_RowCreated(sender As Object, e As GridViewRowEventArgs)

        Dim lbl As Label

        Try
            If e.Row.RowIndex <> -1 Then

                If CType(sender, GridView).DataKeys(e.Row.RowIndex).Values(1) = 0 Then

                    Dim btn As LinkButton

                    btn = CType(e.Row.FindControl("lnk_Eliminar_Metrica"), LinkButton)
                    If Not btn Is Nothing Then
                        btn.Visible = False
                    End If

                    btn = CType(e.Row.FindControl("lnk_Editar_Metrica"), LinkButton)
                    If Not btn Is Nothing Then
                        btn.Visible = False
                    End If

                    btn = CType(e.Row.FindControl("lnk_Agregar_Metrica"), LinkButton)
                    If Not btn Is Nothing Then
                        btn.Visible = True
                    End If

                    lbl = CType(e.Row.FindControl("lbl_Meta2022_Metrica"), Label)
                    If Not lbl Is Nothing Then
                        lbl.Visible = False
                    End If

                    lbl = CType(e.Row.FindControl("lbl_Meta2020_Metrica"), Label)
                    If Not lbl Is Nothing Then
                        lbl.Visible = False
                    End If

                End If

            End If
        Catch ex As Exception
            Gestor_Errores.Escribir_Log(ex, "Error de Registro de Enlace - Created")
        End Try
    End Sub
    Protected Sub gv_Metricas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        If (e.Keys(0) = 0) Then
            hdf_Operacion_Metrica.Value = 1
        Else
            hdf_Operacion_Metrica.Value = 2
        End If
    End Sub
    Protected Sub gv_Metricas_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs)
        If e.Exception IsNot Nothing Then
            e.ExceptionHandled = True
            Gestor_Errores.Escribir_Log(e.Exception, "Error de Registro al Modificar Enlaces - Updated")
        End If
    End Sub
    Protected Sub gv_Metricas_RowDeleted(sender As Object, e As GridViewDeletedEventArgs)
        If e.Exception IsNot Nothing Then
            e.ExceptionHandled = True
            Gestor_Errores.Escribir_Log(e.Exception, "Error de Registro al Modificar Enlaces - Updated")
        End If
    End Sub

#End Region

End Class