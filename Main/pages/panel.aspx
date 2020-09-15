<%@ Page Title="Panel de instrumentos" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="panel.aspx.vb" Inherits="Main.panel" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StylesSection" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">


        <asp:HiddenField ID="hdf_Idioma" runat="server" />
        <asp:HiddenField ID="hdf_CodigoEmpleado" runat="server" />
        <asp:HiddenField ID="hdf_Operativo" runat="server" />
        <asp:HiddenField ID="hdf_Usuario" runat="server" />

    <div class="form-header">
        <div class="row">
            <div class="col-md-8">
                <h3>
                    <asp:Localize ID="lcl_Descripcion" runat="server" Text="Planeación Estratégica Institucional " meta:resourcekey="lcl_DescripcionResource1"></asp:Localize>
                    <asp:Literal ID="ltl_Annio" runat="server" meta:resourcekey="ltl_AnnioResource1"></asp:Literal>
                </h3>
            </div>
            <div class="col-md-4 alinear-derecha">
                <h3>
                    <asp:Literal ID="ltl_Responsable" runat="server" meta:resourcekey="ltl_ResponsableResource1"></asp:Literal>
                </h3>
            </div>
        </div>
    </div>

    <div class="form-body">

        <asp:GridView ID="gv_Proyectos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" DataKeyNames="CronoICT,subcronoICT" DataSourceID="sqlDS_Proyectos" Width="100%" OnRowCommand="gv_ProyectosDetalle_RowCommand" ShowHeader="False" meta:resourcekey="gv_ProyectosResource1">
            <Columns>
                <asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                    
                 
                        <asp:Panel ID="pnl_Verseguimiento" runat="server" meta:resourcekey="pnl_VerseguimientoResource1">
                            <div class="dropdown">
                                <button class="btn btn-iica-green dropdown-toggle" type="button" id="ddm_VerPlanearSeguimiento" data-toggle="dropdown" aria-expanded="true">
                                    <span class="glyphicon glyphicon-share"></span>
                                    <asp:Localize runat="server" ID="lcl_VerSeguimiento" Text="Ver" meta:resourcekey="lcl_VerSeguimientoResource1"></asp:Localize>
                                    <span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu" role="menu" aria-labelledby="ddm_VerPlanearSeguimiento">
                                    <li>
                                        <asp:LinkButton ID="lnk_VerInstrumentoSeguimiento" runat="server" CommandName="VerInstrumento" CommandArgument='<%# Eval("CronoICT") & "," & Eval("subcronoICT") %>' CssClass="btn btn-iica-green"><span class="glyphicon glyphicon-file" runat="server"></span>
                                                <asp:Localize runat="server" ID="lcl_TxtInstrumentoSeguimiento" Text="Instrumento" meta:resourcekey="lcl_TxtInstrumentoSeguimientoResource1"></asp:Localize>
                                        </asp:LinkButton>

                                        <asp:LinkButton ID="lnk_Btn_Planear" runat="server" CommandName="Planear" CommandArgument='<%# Eval("CronoICT") & "," & Eval("subcronoICT") %>' Visible="False" CssClass="btn btn-iica-blue-light"><span class="glyphicon glyphicon-pencil imagen-miplan" runat="server"></span>
                                                <asp:Localize runat="server" ID="lcl_Revisar" Text="Planear" meta:resourcekey="lcl_RevisarResource1"></asp:Localize>
                                        </asp:LinkButton>
                                    </li>
                                </ul>
                            </div>
                        </asp:Panel>

                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" Width="10%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descripción" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <asp:Literal ID="ltl_CodigoICT" runat="server" Text='<%# Eval("Proyecto") + "-" + Eval("Nombre") %>'></asp:Literal>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" Width="60%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Responsable" meta:resourcekey="TemplateFieldResource3">
                    <ItemTemplate>
                        <span class="glyphicon glyphicon-user imagen-usuario"></span>
                        <asp:Label ID="lbl_Responsable1" runat="server" Text='<%# Eval("NombreResponsable") %>' meta:resourcekey="lbl_Responsable1Resource1"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado" meta:resourcekey="TemplateFieldResource4">
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="alinear-centro label-Estado" Width="10%" />
                    <HeaderStyle CssClass="alinear-centro" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sqlDS_Proyectos" runat="server"
            ConnectionString="<%$ ConnectionStrings:SIGESIConnection %>"
            SelectCommand="PE_ADM_Get_Lista_Instrumentos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="Operacion" Type="Int32" />
                <asp:ControlParameter ControlID="hdf_Idioma" DefaultValue="es" Name="Idioma" PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hdf_Usuario" Name="Usuario" PropertyName="Value" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
      

    </div>



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
