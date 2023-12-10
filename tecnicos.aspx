<%@ Page Title="" Language="C#" MasterPageFile="~/Proyecto.Master" AutoEventWireup="true" CodeBehind="tecnicos.aspx.cs" Inherits="Proyecto.tecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Menu de Técnicos</h1>
        <asp:GridView ID="TecnicosGrid" runat="server" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True">
            <HeaderStyle CssClass="header" BackColor="#353535" ForeColor="White"></HeaderStyle>
            <PagerStyle CssClass="pager"></PagerStyle>
            <RowStyle CssClass="rows"></RowStyle>
        </asp:GridView>
        <br />
        ID Técnico:<asp:TextBox ID="TtecnicoID" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LnombreTecnico" runat="server" Text="Nombre Técnico:  "></asp:Label>
        <asp:TextBox ID="TnombreTecnico" runat="server" Width="175px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Lcorreot" runat="server" Text="Correo Electrónico:  "></asp:Label>
        <asp:TextBox ID="Tcorreot" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Lespecialidad" runat="server" Text="Especialidad:  "></asp:Label>
        <asp:TextBox ID="Tespecialidad" runat="server"></asp:TextBox>
        <br />

    </div>

    <br />
    <br />
    <br />

    <div class="container text-center">
        <asp:Button ID="bagregarTecnico" runat="server" Text="Agregar" class="btn btn-primary" OnClick="bagregarTecnico_Click" />
        <asp:Button ID="BborrarTecnico" runat="server" Text="Borrar" class="btn btn-danger" OnClick="BborrarTecnico_Click" />
        <asp:Button ID="BmodificarTecnico" runat="server" Text="Modificar" class="btn btn-success" OnClick="BmodificarTecnico_Click" />
        <asp:Button ID="BconsultarTecnico" runat="server" Text="Consultar" class="btn btn-secondary" OnClick="BconsultarTecnico_Click" />
    </div>
</asp:Content>
