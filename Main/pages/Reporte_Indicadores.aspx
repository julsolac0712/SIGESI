<%@ Page Title="Reporte de Planeación Estratégica" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Reporte_Indicadores.aspx.vb" Inherits="Main.Reporte_Indicadores" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StylesSection" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="hdf_Usuario" runat="server" />
    <asp:HiddenField ID="hdf_Idioma" runat="server" />
    <asp:HiddenField ID="hdf_Operacion" runat="server" />
    <asp:HiddenField ID="hdf_Operacion_Metrica" runat="server" />
    <asp:HiddenField ID="hdf_formulario" runat="server" />
    <asp:HiddenField ID="hdf_PeriodoEstrategico" runat="server" />
    <asp:HiddenField ID="hdf_CronoICT" runat="server" />
    <asp:HiddenField ID="hdf_SubCronoICT" runat="server" />

     <div class="form-header">
        <div class="row">
            <div class="col-md-8">
                <h3>
                    <asp:Localize ID="lcl_Descripcion" runat="server" Text="Planeación Estratégica 2020-2022" meta:resourcekey="lcl_DescripcionResource1"></asp:Localize>
                </h3>
            </div>
            <div class="col-md-4 alinear-derecha">
                <a class="btn btn-iica-green margin-top-10" href="Panel.aspx">
                    <asp:Localize ID="lcl_Volver" runat="server" Text="Inicio" meta:resourcekey="lcl_VolverResource1"></asp:Localize>
                </a>
            </div>
        </div>
    </div>



    <div class="form-body">


            <asp:Panel ID="pnl_Indicadores_Estrategicos" runat="server" meta:resourcekey="pnl_Indicadores_EstrategicosResource1">

                <asp:GridView ID="gv_declaraciones" runat="server" CssClass="table table-bordered table-hover margin-botton-0" DataSourceID="sqlDS_Estrategias" AutoGenerateColumns="False" ShowHeader="False" DataKeyNames="id_estrategica" meta:resourcekey="gv_declaracionesResource1">
                    <Columns>
                        <asp:TemplateField HeaderText="Declaraciones" meta:resourcekey="TemplateFieldResource16">
                            <ItemTemplate>
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <a data-toggle="collapse" href='<%# "#Estrategica" + Eval("numero") %>' style="text-decoration: none">
                                                    <asp:Literal ID="ltl_ParteUno" runat="server" Text='<%# Eval("descripcion_es") %>'></asp:Literal>
                                                </a>
                                            </div>
                                        </div>

                                    </h4>
                                </div>
                                <asp:HiddenField ID="hdf_Estrategia" runat="server" Value='<%# Eval("id_estrategica") %>' />
                                <div id='<%# "Estrategica" + Eval("numero") %>' class="panel-collapse collapse">

                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gv_Indicadores" runat="server" CssClass="table table-bordered table-hover margin-botton-0" AutoGenerateColumns="False" DataKeyNames="id_formulario,id_indicador" DataSourceID="sqlDS_Indicadores" OnRowUpdated="gv_Indicadores_RowUpdated" OnRowUpdating="gv_Indicadores_RowUpdating" OnRowCreated="gv_Indicadores_RowCreated" meta:resourcekey="gv_IndicadoresResource1">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No." SortExpression="numero" meta:resourcekey="TemplateFieldResource1">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_numero" runat="server" Text='<%# Eval("numero") %>' meta:resourcekey="lbl_numeroResource1"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Indicador Estratégico" SortExpression="Descripcion" meta:resourcekey="TemplateFieldResource2">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Descripcion" runat="server" Text='<%# Eval("Descripcion") %>' meta:resourcekey="lbl_DescripcionResource1"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="40%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Línea Base" SortExpression="Meta" meta:resourcekey="TemplateFieldResource3">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Meta" runat="server" Text='<%# Eval("LineaBase") %>' meta:resourcekey="lbl_MetaResource1"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Meta 2022" SortExpression="Meta2022" meta:resourcekey="TemplateFieldResource4">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Meta22" runat="server" Text='<%# Eval("Meta2022") %>' meta:resourcekey="lbl_Meta22Resource1"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Meta 2020" SortExpression="Meta2020" meta:resourcekey="TemplateFieldResource5">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Meta20" runat="server" Text='<%# Eval("Meta2020") %>' meta:resourcekey="lbl_Meta20Resource1"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cumplimiento y Responsable" SortExpression="fechalogro" meta:resourcekey="TemplateFieldResource6">
                                                        <ItemTemplate>
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <asp:Label ID="lbl_fecha" runat="server" Text='<%# Eval("fechalogro", "{0:dd/MM/yyyy}") %>' meta:resourcekey="lbl_fechaResource1"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <asp:Literal ID="ltl_ImagenResponsable" runat="server" Mode="PassThrough" Text="<span class='glyphicon glyphicon-user imagen-usuario'></span>" meta:resourcekey="ltl_ImagenResponsableResource1"></asp:Literal>
                                                                    <asp:Literal ID="ltl_ResponsableResultado" runat="server" Text='<%# Eval("NombreResponsable") %>'></asp:Literal>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="15%" />
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="sqlDS_Indicadores" runat="server" ConnectionString="<%$ ConnectionStrings:SIGESIConnection %>" SelectCommand="PE_ADM_Get_Lista_Indicadores" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="1" Name="Operacion" Type="Int32" />
                                                    <asp:ControlParameter ControlID="hdf_PeriodoEstrategico" Name="id_periodo" PropertyName="Value" Type="Int32" />
                                                    <asp:ControlParameter ControlID="hdf_Estrategia" DefaultValue="0" Name="id_estrategica" PropertyName="Value" Type="Int32" />
                                                    <asp:ControlParameter ControlID="hdf_Idioma" DefaultValue="es" Name="Idioma" PropertyName="Value" Type="String" />
                                                    <asp:ControlParameter ControlID="hdf_Usuario" DefaultValue="0" Name="Usuario" PropertyName="Value" Type="Int32" />
                                                    <asp:ControlParameter ControlID="hdf_CronoICT" DefaultValue="0" Name="CronoICT" PropertyName="Value" Type="Int32" />
                                                    <asp:ControlParameter ControlID="hdf_SubCronoICT" DefaultValue="0" Name="SubCronoICT" PropertyName="Value" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div id="myModal" class="modal fade" role="dialog">
                                        <div class="modal-lg-custom">

                                            <!-- Modal content-->
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    <h4 class="modal-title">Programas de Cooperación Técnica</h4>
                                                </div>
                                                <div class="modal-body">
                                                    <asp:GridView ID="gv_programas" runat="server" CssClass="table table-bordered" Width="100%" AutoGenerateColumns="False" DataKeyNames="id_programa" DataSourceID="sqlDS_programas" meta:resourcekey="gv_programasResource1">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Declaración Estratégica 1 del IICA (Cooperación Técnica de Excelencia)" SortExpression="nombre" meta:resourcekey="TemplateFieldResource15">
                                                                <ItemTemplate>
                                                                    <div class="panel-heading">
                                                                        <h4 class="panel-title">
                                                                            <a data-toggle="collapse" href='<%# "#Programa" + Eval("id_programa") %>' style="text-decoration: none">
                                                                                <asp:Literal ID="ltl_ParteUno" runat="server" Text='<%# Eval("nombre") %>'></asp:Literal>
                                                                            </a>
                                                                        </h4>
                                                                    </div>
                                                                    <asp:HiddenField ID="hdf_Programa" runat="server" Value='<%# Eval("id_programa") %>' />
                                                                    <div id='<%# "Programa" + Eval("id_programa") %>' class="panel-collapse collapse">
                                                                        <div class="panel-body">
                                                                            <div class="alinear-centro margin-top-8">
                                                                                <asp:GridView ID="gv_Efectos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover margin-botton-0" DataKeyNames="id_Efecto" DataSourceID="sqlDS_Efectos" Width="100%" meta:resourcekey="gv_EfectosResource1">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="No." SortExpression="numero" meta:resourcekey="TemplateFieldResource7">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_numero_efecto" runat="server" Text='<%# Bind("numero") %>' meta:resourcekey="lbl_numero_efectoResource1"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="background-entregables" />
                                                                                            <ItemStyle VerticalAlign="Top" Width="5%" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Efectos esperados de la Cooperación en desarrollo territorial" SortExpression="descripcion_efecto" meta:resourcekey="TemplateFieldResource14">
                                                                                            <ItemTemplate>

                                                                                                <div class="panel-heading">
                                                                                                    <h4 class="panel-title">
                                                                                                        <div class="row">
                                                                                                            <div class="col-md-12">
                                                                                                                <a data-toggle="collapse" href='<%# "#Efecto" + Eval("id_Efecto") %>' style="text-decoration: none">
                                                                                                                    <asp:Literal ID="ltl_descripcion_efecto" runat="server" Text='<%# Eval("descripcion_efecto") %>'></asp:Literal>
                                                                                                                </a>
                                                                                                            </div>
                                                                                                        </div>

                                                                                                    </h4>
                                                                                                </div>
                                                                                                <asp:HiddenField ID="hdf_Efecto" runat="server" Value='<%# Eval("id_Efecto") %>' />
                                                                                                <div id='<%# "Efecto" + Eval("id_Efecto") %>' class="panel-collapse collapse">
                                                                                                    <asp:UpdatePanel runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:GridView ID="gv_Metricas" runat="server" CssClass="table table-bordered table-hover margin-botton-0" AutoGenerateColumns="False" DataKeyNames="id_formulario,id_Metrica,id_Efecto" DataSourceID="sqlDS_Metricas" Width="100%" OnRowCreated="gv_Metricas_RowCreated" OnRowUpdating="gv_Metricas_RowUpdating" OnRowUpdated="gv_Metricas_RowUpdated" OnRowDeleted="gv_Metricas_RowDeleted" meta:resourcekey="gv_MetricasResource1">
                                                                                                                <Columns>
                                                                                                                    <asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource8">
                                                                                                                        <EditItemTemplate>
                                                                                                                            <asp:LinkButton ID="lnk_Guardar_Metrica" runat="server" ClientIDMode="AutoID" CommandName="Update" ValidationGroup="registrom" CssClass="btn btn-default" meta:resourcekey="lnk_Guardar_MetricaResource1"><span class="glyphicon glyphicon-ok glyphicons-iica"></span></asp:LinkButton>
                                                                                                                            <asp:LinkButton ID="lnk_Cancelar_Metrica" runat="server" ClientIDMode="AutoID" CommandName="Cancel" CssClass="btn btn-default" meta:resourcekey="lnk_Cancelar_MetricaResource1"><span class="glyphicon glyphicon-remove glyphicons-iica"></asp:LinkButton>
                                                                                                                        </EditItemTemplate>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="lnk_Editar_Metrica" runat="server" ClientIDMode="AutoID" CommandName="Edit" ToolTip="Editar" CssClass="btn btn-default info" meta:resourcekey="lnk_Editar_MetricaResource1"><span class="glyphicon glyphicon-pencil glyphicons-iica"></span></asp:LinkButton>
                                                                                                                            <asp:LinkButton ID="lnk_Agregar_Metrica" runat="server" ClientIDMode="AutoID" CommandName="Edit" ToolTip="Editar" CssClass="btn btn-default info" Visible="False" meta:resourcekey="lnk_Agregar_MetricaResource1"><span class="glyphicon glyphicon-plus glyphicons-iica"></span></asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle CssClass="background-aportes" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="No." SortExpression="numero" meta:resourcekey="TemplateFieldResource9">
                                                                                                                        <EditItemTemplate>
                                                                                                                            <asp:TextBox ID="txt_numero_metrica" runat="server" Text='<%# Bind("numero") %>' CssClass="form-control" Width="100%" meta:resourcekey="txt_numero_metricaResource1"></asp:TextBox>
                                                                                                                        </EditItemTemplate>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lbl_numero_metrica" runat="server" Text='<%# Eval("numero") %>' meta:resourcekey="lbl_numero_metricaResource1"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle CssClass="background-aportes" />
                                                                                                                        <ItemStyle VerticalAlign="Top" Width="5%" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Métrica clave de éxito" SortExpression="Descripcion" meta:resourcekey="TemplateFieldResource10">
                                                                                                                        <EditItemTemplate>
                                                                                                                            <asp:TextBox ID="txt_Descripcion_Metrica" runat="server" Text='<%# Bind("Descripcion") %>' CssClass="form-control" Width="100%" Rows="5" TextMode="MultiLine" meta:resourcekey="txt_Descripcion_MetricaResource1"></asp:TextBox>
                                                                                                                        </EditItemTemplate>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lbl_Descripcion_Metrica" runat="server" Text='<%# Eval("Descripcion") %>' meta:resourcekey="lbl_Descripcion_MetricaResource1"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle CssClass="background-aportes" />
                                                                                                                        <ItemStyle VerticalAlign="Top" Width="20%" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Meta 2022" SortExpression="Meta2022" meta:resourcekey="TemplateFieldResource11">
                                                                                                                        <EditItemTemplate>
                                                                                                                            <asp:TextBox ID="txt_Meta2022_metrica" runat="server" Text='<%# Bind("Meta2022") %>' Width="100%" CssClass="form-control" onkeypress="javascript:return solonumeros(event)" meta:resourcekey="txt_Meta2022_metricaResource1"></asp:TextBox>
                                                                                                                        </EditItemTemplate>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lbl_Meta2022_Metrica" runat="server" Text='<%# Eval("Meta2022") %>' meta:resourcekey="lbl_Meta2022_MetricaResource1"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle CssClass="background-aportes" />
                                                                                                                        <ItemStyle VerticalAlign="Top" Width="10%" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Meta 2020" SortExpression="Meta2020" meta:resourcekey="TemplateFieldResource12">
                                                                                                                        <EditItemTemplate>
                                                                                                                            <asp:TextBox ID="txt_Meta2020_metrica" runat="server" Text='<%# Bind("Meta2020") %>' Width="100%" CssClass="form-control" onkeypress="javascript:return solonumeros(event)" meta:resourcekey="txt_Meta2020_metricaResource1"></asp:TextBox>
                                                                                                                        </EditItemTemplate>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lbl_Meta2020_metrica" runat="server" Text='<%# Eval("Meta2020") %>' meta:resourcekey="lbl_Meta2020_metricaResource1"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle CssClass="background-aportes" />
                                                                                                                        <ItemStyle VerticalAlign="Top" Width="10%" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Logro" SortExpression="fechalogro" meta:resourcekey="TemplateFieldResource13">
                                                                                                                        <EditItemTemplate>
                                                                                                                            <div class="row">
                                                                                                                                <div class="col-md-12">
                                                                                                                                    <asp:TextBox ID="txt_fecha_metrica" runat="server" Text='<%# Bind("fechalogro", "{0:d}") %>' Width="100%" CssClass="form-control date-picker" meta:resourcekey="txt_fecha_metricaResource1"></asp:TextBox>
                                                                                                                                    <asp:RequiredFieldValidator ID="rfv_fecha" ControlToValidate="txt_fecha_metrica" runat="server" ErrorMessage="Requerido" Display="Dynamic" Text="*" ForeColor="Red" ValidationGroup="registrom" meta:resourcekey="rfv_fechaResource1"></asp:RequiredFieldValidator>
                                                                                                                                </div>
                                                                                                                            </div>
                                                                                                                        </EditItemTemplate>
                                                                                                                        <ItemTemplate>

                                                                                                                            <div class="row">
                                                                                                                                <div class="col-md-12">
                                                                                                                                    <asp:Label ID="lbl_fecha_metrica" runat="server" Text='<%# Eval("fechalogro", "{0:dd/MM/yyyy}") %>' meta:resourcekey="lbl_fecha_metricaResource1"></asp:Label>
                                                                                                                                </div>
                                                                                                                            </div>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle CssClass="background-aportes" />
                                                                                                                        <ItemStyle VerticalAlign="Top" Width="15%" />
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                            <asp:SqlDataSource ID="sqlDS_Metricas" runat="server" ConnectionString="<%$ ConnectionStrings:SIGESIConnection %>" SelectCommand="PE_ADM_Get_Lista_Indicadores_Metricas_DCT" SelectCommandType="StoredProcedure" UpdateCommand="PE_ADM_Man_Indicadores_Metricas_DCT" UpdateCommandType="StoredProcedure" InsertCommand="PE_ADM_Man_Indicadores_Metricas_DCT" InsertCommandType="StoredProcedure">
                                                                                                                <InsertParameters>
                                                                                                                    <asp:ControlParameter ControlID="hdf_Operacion_Metrica" DefaultValue="1" Name="Operacion" PropertyName="Value" Type="Int32" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_PeriodoEstrategico" DefaultValue="1" Name="id_periodo" PropertyName="Value" Type="Int32" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_Usuario" DefaultValue="1" Name="usuario" PropertyName="Value" Type="Int32" />
                                                                                                                    <asp:Parameter Name="fechalogro" Type="DateTime" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_CronoICT" DefaultValue="0" Name="CronoICT" PropertyName="Value" Type="Int32" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_SubCronoICT" DefaultValue="0" Name="SubCronoICT" PropertyName="Value" Type="String" />
                                                                                                                </InsertParameters>
                                                                                                                <SelectParameters>
                                                                                                                    <asp:Parameter DefaultValue="1" Name="Operacion" Type="Int32" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_Efecto" DefaultValue="1" Name="id_Efecto" PropertyName="Value" Type="Int32" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_PeriodoEstrategico" DefaultValue="1" Name="id_periodo" PropertyName="Value" Type="Int32" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_Idioma" DefaultValue="es" Name="Idioma" PropertyName="Value" Type="String" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_CronoICT" DefaultValue="0" Name="CronoICT" PropertyName="Value" Type="Int32" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_SubCronoICT" DefaultValue="0" Name="SubCronoICT" PropertyName="Value" Type="String" />
                                                                                                                </SelectParameters>
                                                                                                                <UpdateParameters>
                                                                                                                    <asp:ControlParameter ControlID="hdf_Operacion_Metrica" DefaultValue="2" Name="Operacion" PropertyName="Value" Type="Int32" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_PeriodoEstrategico" DefaultValue="1" Name="id_periodo" PropertyName="Value" Type="Int32" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_Usuario" DefaultValue="0" Name="usuario" PropertyName="Value" Type="Int32" />
                                                                                                                    <asp:Parameter Name="fechalogro" Type="DateTime" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_CronoICT" DefaultValue="0" Name="CronoICT" PropertyName="Value" Type="Int32" />
                                                                                                                    <asp:ControlParameter ControlID="hdf_SubCronoICT" DefaultValue="0" Name="SubCronoICT" PropertyName="Value" Type="String" />
                                                                                                                </UpdateParameters>
                                                                                                            </asp:SqlDataSource>



                                                                                                        </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>

                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="background-entregables" />
                                                                                            <ItemStyle VerticalAlign="Top" Width="90%" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                                <asp:SqlDataSource ID="sqlDS_Efectos" runat="server" ConnectionString="<%$ ConnectionStrings:SIGESIConnection %>" SelectCommand="PE_ADM_Get_Lista_Programas_Efectos" SelectCommandType="StoredProcedure">
                                                                                    <SelectParameters>
                                                                                        <asp:Parameter DefaultValue="1" Name="Operacion" Type="Int32" />
                                                                                        <asp:ControlParameter ControlID="hdf_Programa" DefaultValue="" Name="id_programa" PropertyName="Value" Type="Int32" />
                                                                                        <asp:ControlParameter ControlID="hdf_Idioma" DefaultValue="es" Name="Idioma" PropertyName="Value" Type="String" />
                                                                                    </SelectParameters>
                                                                                </asp:SqlDataSource>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="background-resultados" ForeColor="White" />

                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:SqlDataSource ID="sqlDS_programas" runat="server" ConnectionString="<%$ ConnectionStrings:SIGESIConnection %>" SelectCommand="PE_ADM_Get_Lista_Programas" SelectCommandType="StoredProcedure">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="1" Name="Operacion" Type="Int32" />
                                                            <asp:ControlParameter ControlID="hdf_Idioma" DefaultValue="es" Name="Idioma" PropertyName="Value" Type="String" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                    <asp:Panel ID="pnl_Programas" runat="server" Visible='<%# Eval("Visible") %>' meta:resourcekey="pnl_ProgramasResource1">
                                    </asp:Panel>

                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="alinear-centro" />
                            <ItemStyle Width="12%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="sqlDS_Estrategias" runat="server" ConnectionString="<%$ ConnectionStrings:SIGESIConnection %>" SelectCommand="PE_ADM_Get_Lista_Declaraciones" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="2" Name="Operacion" Type="Int32" />
                        <asp:ControlParameter ControlID="hdf_CronoICT" Name="CronoICT" DefaultValue="0" PropertyName="Value" Type="Int32" />
                        <asp:ControlParameter ControlID="hdf_SubCronoICT" Name="subCronoICT" DefaultValue="0" PropertyName="Value" Type="String" />
                        <asp:ControlParameter ControlID="hdf_PeriodoEstrategico" Name="Periodo" DefaultValue="1" PropertyName="Value" Type="Int32" />

                        <asp:ControlParameter ControlID="hdf_Idioma" DefaultValue="es" Name="Idioma" PropertyName="Value" Type="String" />

                    </SelectParameters>
                </asp:SqlDataSource>

    </asp:Panel>

    </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
