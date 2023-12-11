<%@ Page Title="" Language="C#" MasterPageFile="~/Proyecto.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="Proyecto.usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/menu.css" />
    <div class="container text-center">
        <h1>Menú de Usuarios</h1>
        <asp:GridView ID="UsuariosGrid" runat="server" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" OnPageIndexChanging="UsuariosGrid_PageIndexChanging">
            <HeaderStyle CssClass="header" BackColor="#353535" ForeColor="White"></HeaderStyle>
            <PagerStyle CssClass="pager"></PagerStyle>
            <RowStyle CssClass="rows"></RowStyle>
        </asp:GridView>
        <br />
        ID Usuario:<asp:TextBox ID="TusuarioID" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LnombreUsuario" runat="server" Text="Nombre Usuario:  "></asp:Label>
        <asp:TextBox ID="TnombreUsuario" runat="server" Width="175px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Lcorreou" runat="server" Text="Correo Electrónico:  "></asp:Label>
        <asp:TextBox ID="Tcorreou" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Lcontraseña" runat="server" Text="Contraseña:  "></asp:Label>
        <asp:TextBox ID="Tcontraseña" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LtipoUsuario" runat="server" Text="Tipo de Usuario: "></asp:Label>
        <asp:DropDownList ID="DdlTipoUsuario" runat="server">
            <asp:ListItem Text="Admin" Value="Admin" />
            <asp:ListItem Text="Cliente" Value="Cliente" />
            <asp:ListItem Text="Técnico" Value="Tecnico" />
        </asp:DropDownList>
        <br />
        <br />
        <br />

    </div>

    <br />
    <br />
    <br />

    <div class="container text-center">
        <asp:Button ID="BmodificarUsuario" runat="server" Text="Modificar" class="btn btn-success" OnClick="BmodificarUsuario_Click" />
        <asp:Button ID="BconsultarUsuario" runat="server" Text="Consultar" class="btn btn-secondary" OnClick="BconsultarUsuario_Click" />
    </div>
</asp:Content>
