<%@ Page Title="" Language="C#" MasterPageFile="~/Proyecto.Master" AutoEventWireup="true" CodeBehind="equipos.aspx.cs" Inherits="Proyecto.equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Menú de Equipos</h1>
        <asp:GridView ID="EquiposGrid" runat="server" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True">
            <HeaderStyle CssClass="header" BackColor="#353535" ForeColor="White"></HeaderStyle>
            <PagerStyle CssClass="pager"></PagerStyle>
            <RowStyle CssClass="rows"></RowStyle>
        </asp:GridView>

        <br />
        ID Equipo: <asp:TextBox ID="TequipoID" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="LtipoEquipo" runat="server" Text="Tipo de Equipo:  "></asp:Label>
        <asp:TextBox ID="TtipoEquipo" runat="server" Width="175px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Lmodelo" runat="server" Text="Modelo:  "></asp:Label>
        <asp:TextBox ID="Tmodelo" runat="server" Width="175px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LusuarioID" runat="server" Text="ID Usuario:  "></asp:Label>
        <asp:TextBox ID="TusuarioID" runat="server"></asp:TextBox>
        <br />
    </div>

    <br />
    <br />
    <br />

    <div class="container text-center">
        <asp:Button ID="bagregarEquipo" runat="server" Text="Agregar" class="btn btn-primary" OnClick="bagregarEquipo_Click" />
        <asp:Button ID="BborrarEquipo" runat="server" Text="Borrar" class="btn btn-danger" OnClick="BborrarEquipo_Click" />
        <asp:Button ID="BmodificarEquipo" runat="server" Text="Modificar" class="btn btn-success" OnClick="BmodificarEquipo_Click" />
        <asp:Button ID="BconsultarEquipo" runat="server" Text="Consultar" class="btn btn-secondary" OnClick="BconsultarEquipo_Click" />
    </div>
</asp:Content>
