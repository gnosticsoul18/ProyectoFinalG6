<%@ Page Title="" Language="C#" MasterPageFile="~/Proyecto.Master" AutoEventWireup="true" CodeBehind="asignaciones.aspx.cs" Inherits="Proyecto.asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Menú de Asignaciones</h1>
        <asp:GridView ID="AsignacionesGrid" runat="server" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True">
            <HeaderStyle CssClass="header" BackColor="#353535" ForeColor="White"></HeaderStyle>
            <PagerStyle CssClass="pager"></PagerStyle>
            <RowStyle CssClass="rows"></RowStyle>
        </asp:GridView>

        <br />
        ID Asignación: <asp:TextBox ID="TasignacionID" runat="server"></asp:TextBox>
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
        <asp:Button ID="bagregarAsignacion" runat="server" Text="Agregar" class="btn btn-primary" OnClick="bagregarAsignacion_Click" />
        <asp:Button ID="BborrarAsignacion" runat="server" Text="Borrar" class="btn btn-danger" OnClick="BborrarAsignacion_Click" />
        <asp:Button ID="BmodificarAsignacion" runat="server" Text="Modificar" class="btn btn-success" OnClick="BmodificarAsignacion_Click" />
        <asp:Button ID="BconsultarAsignacion" runat="server" Text="Consultar" class="btn btn-secondary" OnClick="BconsultarAsignacion_Click" />
    </div>
</asp:Content>