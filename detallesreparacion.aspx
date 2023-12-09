<%@ Page Title="" Language="C#" MasterPageFile="~/Proyecto.Master" AutoEventWireup="true" CodeBehind="detallesreparacion.aspx.cs" Inherits="Proyecto.detallesreparacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Detalles de Reparación</h1>
        <asp:GridView ID="DetallesReparacionGrid" runat="server" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True">
            <HeaderStyle CssClass="header" BackColor="#353535" ForeColor="White"></HeaderStyle>
            <PagerStyle CssClass="pager"></PagerStyle>
            <RowStyle CssClass="rows"></RowStyle>
        </asp:GridView>

        <br />
        ID Reparación: <asp:TextBox ID="TreparacionID" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="Ldescripcion" runat="server" Text="Descripción:  "></asp:Label>
        <asp:TextBox ID="Tdescripcion" runat="server" Width="175px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Lfecha" runat="server" Text="Fecha:  "></asp:Label>
        <asp:TextBox ID="Tfecha" runat="server" Width="175px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LtecnicoID" runat="server" Text="ID Técnico:  "></asp:Label>
        <asp:TextBox ID="TtecnicoID" runat="server"></asp:TextBox>
        <br />
    </div>

    <br />
    <br />
    <br />

    <div class="container text-center">
        <asp:Button ID="bagregarReparacion" runat="server" Text="Agregar" class="btn btn-primary" OnClick="bagregarReparacion_Click" />
        <asp:Button ID="BborrarReparacion" runat="server" Text="Borrar" class="btn btn-danger" OnClick="BborrarReparacion_Click" />
        <asp:Button ID="BmodificarReparacion" runat="server" Text="Modificar" class="btn btn-success" OnClick="BmodificarReparacion_Click" />
        <asp:Button ID="BconsultarReparacion" runat="server" Text="Consultar" class="btn btn-secondary" OnClick="BconsultarReparacion_Click" />
    </div>
</asp:Content>