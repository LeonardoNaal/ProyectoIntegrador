<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTMLogIn.Master" AutoEventWireup="true" CodeBehind="agregar_pub2.aspx.cs" Inherits="WebUTM.WebUTM2.agregar_pub2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
    <div class="mibanner">
        <div class="container">
           <h2 class="mih2">Agregar Publicación</h2>
                <p><i>#OrgulloUTM</i></p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-md-12" align="center">
            <ul class="breadcrumb">
                <li>
                    <a href="index.aspx">
                        Inicio
                    </a><span class="divider"></span>
                </li>
                <li class="active">
                        Publicaciones
                </li>
            </ul>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-4 jumbotron banner-bottom">
                <h3>Más acciones:</h3>
                <hr />
                <asp:Button ID="Button2" runat="server" Text="Ver las publicaciones" CssClass="btn-success btn-lg" Width="240px" />
                <hr />
                <asp:Button ID="Button3" runat="server" Text="Ver las actividades" CssClass="btn-success btn-lg" Width="240px" />
            </div>
            <div class="col-md-8">
                <div class="row">
                    <div class="col-md-6">
                        <p>Título:</p>
                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" Height="31px" Width="400px"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-md-6">
                        <div align="center">
                        <p>Tipo de publicación</p>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="300px" Height="31px"></asp:DropDownList>
                            </div>
                    </div>
                </div>
                <h3>Agrega una publicación</h3>
                <p>Descripción:</p>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Height="280px"></asp:TextBox>
                <div align="center">
                <asp:Button ID="Button1" runat="server" Text="Publicar" CssClass="btn-success btn-lg" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
