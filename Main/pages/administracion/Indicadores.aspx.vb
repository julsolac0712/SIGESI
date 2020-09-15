Public Class Indicadores
    Inherits BasePage

    Dim DCT As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim arrValues() As String

        ' hdf_Usuario.Value = 2802

        Try



            If Not IsPostBack Then
                Get_Cookie_Intranet()
                hdf_Usuario.Value = IDIntranet

                ' Se carga el periodo estrategico activo
                hdf_PeriodoEstrategico.Value = Get_PeriodoEstrategico_ID()
            Else
                If ddl_Instrumentos.SelectedIndex > 0 Then
                    arrValues = Split(CType(ddl_Instrumentos.SelectedValue, String), "-")
                    If AccesoDatos.ValidaFormulario(hdf_PeriodoEstrategico.Value, arrValues(0), arrValues(1), hdf_Usuario.Value) Then
                        pnl_Indicadores_Estrategicos.Visible = True
                        hdf_CronoICT.Value = arrValues(0)
                        hdf_SubCronoICT.Value = arrValues(1)
                    End If
                Else
                    pnl_Indicadores_Estrategicos.Visible = False
                End If

            End If
        Catch ex As Exception
            Gestor_Errores.Escribir_Log(ex, "Error al cargar datos del Formulario")
        End Try

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