<%@ Page Title="" Language="C#" MasterPageFile="~/Proyecto.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="Proyecto.usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Menu de Usuarios</h1>
            <asp:GridView ID="UsuariosGrid" runat="server" HorizontalAlign="Center"
                CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                RowStyle-CssClass="rows" AllowPaging="True">
<HeaderStyle CssClass="header" BackColor="#353535" ForeColor="White"></HeaderStyle>

<PagerStyle CssClass="pager"></PagerStyle>

<RowStyle CssClass="rows"></RowStyle>
            </asp:GridView>
        <br />
        ID Usuario:<asp:TextBox ID="TusuarioID" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="LnombreUsuario" runat="server" Text="Nombre Usuario:  "></asp:Label>
        <asp:TextBox ID="Tnombreusuario" runat="server" Width="175px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Lcorreo" runat="server" Text="Correo Electrónico:  "></asp:Label>
        <asp:TextBox ID="Tcorreo" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Lnumero" runat="server" Text="Número Teléfono:  "></asp:Label>
        <asp:TextBox ID="TnumeroTel" runat="server"></asp:TextBox>
        <br />

    </div>

    <br />
    <br />
    <br />

    <div class="container text-center">
        <asp:Button ID="bagregarUsuario" runat="server" Text="Agregar" class="btn btn-primary" OnClick="bagregarUsuario_Click" />
        <asp:Button ID="BborrarUsuario" runat="server" Text="Borrar" class="btn btn-danger" OnClick="BborrarUsuario_Click" />
        <asp:Button ID="BmodificarUsuario" runat="server" Text="Modificar" class="btn btn-success" OnClick="BmodificarUsuario_Click" />
        <asp:Button ID="BconsultarUsuario" runat="server" Text="Consultar" class="btn btn-secondary" OnClick="BconsultarUsuario_Click" />
    </div>
</asp:Content>
