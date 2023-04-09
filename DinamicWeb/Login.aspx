﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DinamicWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Dinamic-Web</title>
    <%-- Referencias CSS --%>
    <link href="asset/bootstrap-5.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="asset/Fontawesome/css/all.min.css" rel="stylesheet" />
    <link href="asset/SweeAlert/sweetalert.min.css" rel="stylesheet" />
    <link href="asset/CSS/Login.css" rel="stylesheet" />
     <%-- Referencias JS --%>
    <script src="asset/SweeAlert/sweetalert.all.min.js"></script>
    <script src="asset/SweeAlert/sweetAlertStyle.js"></script>
</head>
<body>
    <form id="frmLogin" runat="server">

        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>



                <div class="Contenedor">



                    <div class="card" style="background-color: #F2F2F2; border-radius: 15px">
                        <div class="card-body">


                            <div class="ImagenTop">
                                <img src="asset/image/1523210170727.png" width="350" />
                            </div>
                            <div class="tituloLogin">
                                <h1>Dinamic-Web</h1>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" class="form-control" ID="txtUsuario" placeholder="Usuario"></asp:TextBox>
                                <label for="floatingInput">Usuario</label>
                            </div>
                            <div class="form-floating">
                                <asp:TextBox runat="server" TextMode="Password" class="form-control" ID="txtPassword" placeholder="Constraseña"></asp:TextBox>
                                <label for="floatingPassword">Constraseña</label>
                            </div>

                            <div class="row col-12 btnLogin">
                                <asp:Button runat="server" ID="btnIngresar" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnIngresar_Click" />
                            </div>

                        </div>
                    </div>



                </div>



            </ContentTemplate>
        </asp:UpdatePanel>






    </form>
   
</body>
</html>
