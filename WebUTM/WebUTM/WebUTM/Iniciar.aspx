<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTM.Master" AutoEventWireup="true" CodeBehind="Iniciar.aspx.cs" Inherits="WebUTM.WebUTM.Iniciar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
     <div class="copy-section">
        <div class="container">
            <h3>Ingresa al sitio</h3>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="container">
            <br />
        <h4>Estás en:</h4>
            <br />
        <div class="btn-group btn-breadcrumb">
            <a href="index.aspx" class="btn btn-primary"><i class="glyphicon glyphicon-home"></i></a>
            <a href="#" class="btn btn-primary">Iniciar sesión</a>
        </div>
        </div>
    </div>
    <br />
    <div class="container">
      <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <div align="center" class="thumbnail">
                    <div class="caption">
                        <img src="../Recursos/Images/LoguinFin.png" width="150" height="140"/>
                        <br />
                        <br />
                        <h4><span class="glyphicon glyphicon-user"></span>Matrícula:</h4>
                        <br />
                        <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" Width="160" Height="25" ForeColor="Black"></asp:TextBox>
                        <br />
                        <h4><span class="glyphicon glyphicon-lock"></span>Contraseña:</h4>
                        <br />
                        <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="form-control" Width="160" Height="25" ForeColor="Black"></asp:TextBox>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Entrar" CssClass="btn btn-warning" OnClick="Button1_Click" />
                        <br />
                        <br />
                        <h4>Ingresa para publicar avisos, anuncios o lo que desees.</h4>
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
