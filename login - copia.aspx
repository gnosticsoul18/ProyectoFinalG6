<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="proyecto.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <style>
        body {
            background-color: #2c3e50; /* Fondo negro */
            color: #ecf0f1; /* Texto blanco */
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .fondo-container {
            background-image: url('/img/fondo1.jpg');
            background-size: cover; /* Cubre completamente el contenedor */
            background-position: center; /* Centra la imagen en el contenedor */
            background-repeat: no-repeat;
            height: 100vh; /* Establece la altura al 100% del viewport */
            margin: 0; /* Elimina el margen predeterminado del body */
            padding: 0; /* Elimina el relleno predeterminado del body */
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .container {
            background-color: #888; /* Cambia a tu color deseado */
            padding: 20px;
            border: 1px solid rgba(0, 0, 0, 0.8);
            border-radius: 10px;
            width: 400px;
        }

        h1 {
            color: #3498db; /* Azul */
        }

        .btn {
            margin-top: 10px;
        }
    </style>
    <title></title>
</head>
<body class="fondo-container">
    <form id="form1" runat="server" class="container">
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Correo Electrónico</label>
            <asp:TextBox ID="Tlogin" class="form-control" aria-describedby="emailHelp" runat="server" Height="25px" Width="303px"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="exampleInputPassword1" class="form-label">Contraseña</label>
            <asp:TextBox ID="Tclave" class="form-control" runat="server" Height="25px" Width="179px" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button ID="Bingresar" class="btn btn-primary" runat="server" Text="Ingresar" OnClick="Bingresar_Click" />
        <p>
            <asp:Label ID="Lmensaje" runat="server" Text=""></asp:Label>
        </p>
    </form>
</body>
</html>
