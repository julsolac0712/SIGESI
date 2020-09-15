<%@ Page Title="Mantenimiento Declaraciones" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Declaraciones.aspx.vb" Inherits="Main.Declaraciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StylesSection" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hdf_Operacion" runat="server" />
    <asp:HiddenField ID="hdf_Usuario" runat="server" />
    <div class="form-header">
        <div class="row">
            <div class="col-md-8">
                <h3>
                    <asp:Localize ID="lcl_Descripcion" runat="server" Text="Maestro de Declaraciones Estratégicas"></asp:Localize>
                </h3>
            </div>
            <div class="col-md-4 alinear-derecha">
                <a class="btn btn-iica-green margin-top-5" href="../../Default.aspx">
                    <asp:Localize ID="lcl_Volver" runat="server" Text="Inicio"></asp:Localize>
                </a>
            </div>
        </div>
    </div>

     <div class="form-body">
        <div class="row">
            <div class="col-md-12">
                    <asp:GridView ID="gv_declaraciones" runat="server" CssClass="table table-bordered table-striped margin-top-10" AutoGenerateColumns="False" DataKeyNames="id_estrategica" DataSourceID="sqlDS_declaraciones" Width="100%">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnk_Guardar" runat="server" ClientIDMode="AutoID" CommandName="Update" ValidationGroup="vgGrid" CssClass="btn btn-default"><span class="glyphicon glyphicon-floppy-saved glyphicons-iica"></span></asp:LinkButton>
                                    <asp:LinkButton ID="lnk_Cancelar" runat="server" ClientIDMode="AutoID" CommandName="Cancel" CssClass="btn btn-default"><span class="glyphicon glyphicon-floppy-remove glyphicons-iica"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk_Editar" runat="server" ClientIDMode="AutoID" CommandName="Edit" ToolTip="Editar" CssClass="btn btn-default info"><span class="glyphicon glyphicon-pencil glyphicons-iica"></span></asp:LinkButton>
                                    <asp:LinkButton ID="lnk_Agregar" runat="server" ClientIDMode="AutoID" CommandName="Edit" ToolTip="Agregar Nuevo" Visible="False" CssClass="btn btn-default"><span class="glyphicon glyphicon-plus glyphicons-iica"></span></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre" SortExpression="nombreCorto_es">
                                <EditItemTemplate>      
                                        <div class="md-col-12">
                                            <asp:Label ID="lbl_txt_nombreCorto_es" runat="server" Text="Nombre Español:" AssociatedControlID="txt_nombreCorto_es"></asp:Label>
                                            <asp:Textbox ID="txt_nombreCorto_es" runat="server" Text='<%# Bind("nombreCorto_es") %>' CssClass="form-control"></asp:Textbox>  
                                        </div>                                                                
                                        <div class="md-col-12">
                                            <asp:Label ID="lbl_txt_nombreCorto_en" runat="server" Text="Nombre Inglés:" AssociatedControlID="txt_nombreCorto_en"></asp:Label>
                                            <asp:Textbox ID="txt_nombreCorto_en" runat="server" Text='<%# Bind("nombreCorto_en") %>' CssClass="form-control"></asp:Textbox>  
                                        </div>                      
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_nombreCorto" runat="server" Text='<%# Eval("nombreCorto_es") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descripción" SortExpression="descripcion_es">
                                <EditItemTemplate>
                                        <div class="md-col-12">
                                            <asp:Label ID="lbl_txt_descripcion_es" runat="server" Text="Descripción Español:" AssociatedControlID="txt_descripcion_es"></asp:Label>
                                            <asp:TextBox ID="txt_descripcion_es" runat="server" Text='<%# Bind("descripcion_es") %>' CssClass="form-control" TextMode="MultiLine" rows="3"></asp:TextBox>
                                        </div>
                                        <div class="md-col-12">
                                            <asp:Label ID="lbl_txt_descripcion_en" runat="server" Text="Descripción Inglés:" AssociatedControlID="txt_descripcion_en"></asp:Label>
                                            <asp:TextBox ID="txt_descripcion_en" runat="server" Text='<%# Bind("descripcion_en") %>' CssClass="form-control" TextMode="MultiLine" rows="3"></asp:TextBox>
                                        </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_descripcion" runat="server" Text='<%# Eval("descripcion_es") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="60%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="sqlDS_declaraciones" runat="server" ConnectionString="<%$ ConnectionStrings:SIGESIConnection %>" SelectCommand="PE_ADM_Get_Lista_Declaraciones" SelectCommandType="StoredProcedure" InsertCommand="PE_ADM_Man_Declaraciones" InsertCommandType="StoredProcedure" UpdateCommand="PE_ADM_Man_Declaraciones" UpdateCommandType="StoredProcedure">
                        <InsertParameters>
                            <asp:ControlParameter ControlID="hdf_Operacion" DefaultValue="1" Name="Operacion" PropertyName="Value" Type="Int32" />
                            <asp:Parameter Name="id_periodo" Type="Int32" />
                            <asp:Parameter Name="nombreCorto_es" Type="String" />
                            <asp:Parameter Name="nombreCorto_en" Type="String" />
                            <asp:Parameter Name="descripcion_es" Type="String" />
                            <asp:Parameter Name="descripcion_en" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="Operacion" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="hdf_Operacion" DefaultValue="2" Name="Operacion" PropertyName="Value" Type="Int32" />
                            <asp:Parameter Name="id_periodo" Type="Int32" />
                            <asp:Parameter Name="nombreCorto_es" Type="String" />
                            <asp:Parameter Name="nombreCorto_en" Type="String" />
                            <asp:Parameter Name="descripcion_es" Type="String" />
                            <asp:Parameter Name="descripcion_en" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
