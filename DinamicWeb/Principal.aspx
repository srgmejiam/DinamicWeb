<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="DinamicWeb.Principal" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link href="asset/CSS/Principal.css" rel="stylesheet" />

    <div class="row">

        <asp:Panel runat="server" ID="panelFormulario_1" CssClass="col-md-3 CardMenuPrincipal" Visible="true">
            <asp:LinkButton runat="server" ID="lnkFormulario_1" OnClick="lnkFormulario_1_Click">
            <div class="card flex-column" style="background-color:rgb(234 98 0 /0.6);">
                <div class="card-body">
                    <div class="d-inline-flex">
                        <div class="col-sm-4">
                            <i class="fas fa-cube icono" ></i>
                        </div>
                        <div class="col-sm-8 tituloCard">
                            <h4>Primer <br /> Formulario</h4>
                        </div>
                    </div>
                </div>
            </div>
            </asp:LinkButton>
        </asp:Panel>

        <asp:Panel runat="server" ID="panelFormulario_2" CssClass="col-md-3 CardMenuPrincipal" Visible="true">
            <asp:LinkButton runat="server" ID="lnkFormulario_2" OnClick="lnkFormulario_2_Click">
            <div class="card flex-column" style="background-color:rgb(98 84 243);">
                <div class="card-body">
                    <div class="d-inline-flex">
                        <div class="col-sm-4">
                            <i class="fas fa-city icono" ></i>
                        </div>
                        <div class="col-sm-8 tituloCard">
                            <h4>Segundo <br /> Formulario</h4>
                        </div>
                    </div>
                </div>
            </div>
            </asp:LinkButton>
        </asp:Panel>

        <asp:Panel runat="server" ID="panelFormulario_3" CssClass="col-md-3 CardMenuPrincipal" Visible="true">
            <asp:LinkButton runat="server" ID="lnkFormulario_3" OnClick="lnkFormulario_3_Click">
            <div class="card flex-column" style="background-color:rgb(128 128 128);">
                <div class="card-body">
                    <div class="d-inline-flex">
                        <div class="col-sm-4">
                            <i class="fas fa-user icono" ></i>
                        </div>
                        <div class="col-sm-8 tituloCard">
                            <h4>Tercer <br /> Formulario</h4>
                        </div>
                    </div>
                </div>
            </div>
            </asp:LinkButton>
        </asp:Panel>

        <asp:Panel runat="server" ID="panelFormulario_4" CssClass="col-md-3 CardMenuPrincipal" Visible="true">
            <asp:LinkButton runat="server" ID="lnkFormulario_4" OnClick="lnkFormulario_4_Click">
            <div class="card flex-column" style="background-color:rgb(1 145 188);">
                <div class="card-body">
                    <div class="d-inline-flex">
                        <div class="col-sm-4">
                            <i class="fas fa-user icono" ></i>
                        </div>
                        <div class="col-sm-8 tituloCard">
                            <h4>Cuarto <br /> Formulario</h4>
                        </div>
                    </div>
                </div>
            </div>
            </asp:LinkButton>
        </asp:Panel>

    </div>

</asp:Content>
