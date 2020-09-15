<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="logon.aspx.vb" Inherits="Main.logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txt_CorreoUsuario" runat="server" Width="179px" placeholder="Correo @iica.int"></asp:TextBox>
    <asp:Button ID="btn_Login" runat="server" Text="Ingresar" OnClick="btn_Login_Click"/>
</asp:Content>
