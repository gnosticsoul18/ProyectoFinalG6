<%@ Page Title="" Language="C#" MasterPageFile="~/Proyecto.Master" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="Proyecto.clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Menú de Clientes</h1>
        <asp:GridView ID="ClientesGrid" runat="server" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True">
            <HeaderStyle CssClass="header" BackColor="#353535" ForeColor="White"></HeaderStyle>
            <PagerStyle CssClass="pager"></PagerStyle>
            <RowStyle CssClass="rows"></RowStyle>
        </asp:GridView>

        <br />
        ID Cliente: <asp:TextBox ID="TclienteID" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="LnombreCliente" runat="server" Text="Nombre Cliente:  "></asp:Label>
        <asp:TextBox ID="TnombreCliente" runat="server" Width="175px"></asp:TextBox>
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
        <asp:Button ID="bagregarCliente" runat="server" Text="Agregar" class="btn btn-primary" OnClick="bagregarCliente_Click" />
        <asp:Button ID="BborrarCliente" runat="server" Text="Borrar" class="btn btn-danger" OnClick="BborrarCliente_Click" />
        <asp:Button ID="BmodificarCliente" runat="server" Text="Modificar" class="btn btn-success" OnClick="BmodificarCliente_Click" />
        <asp:Button ID="BconsultarCliente" runat="server" Text="Consultar" class="btn btn-secondary" OnClick="BconsultarCliente_Click" />
    </div>
</asp:Content>