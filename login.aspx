<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="proyecto.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Correo Electronico</label>
                <asp:TextBox ID="Tlogin" class="form-control" aria-describedby="emailHelp" runat="server" Height="25px" Width="303px"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                <asp:TextBox ID="Tclave" class="form-check-input" runat="server" Height="25px" Width="179px" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="Bingresar" class="btn btn-primary" runat="server" Text="Ingresar" OnClick="Bingresar_Click" />
        </div>
        <p>
            <asp:Label ID="Lmensaje" runat="server" Text=""></asp:Label>
            </p>
    </form>
</body>
</html>
