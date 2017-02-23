<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTM.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="WebUTM.WebUTM.registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
    <div class="copy-section">
        <div class="container">
            <h3 class="text-center title">Registro</h3>
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
            <a href="#" class="btn btn-primary">Registrarse</a>
        </div>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="well">
                    <div class="row">
                        <div class="col-md-2">
                            <br />
                            <div align="center">
                                <img src="../Recursos/Images/userFin.png" width="250" height="300" class="zoom-img" />
                            </div>
                        </div>
                        <div class="col-md-10">
                            <h3 class="text-center">Ingresa tus datos</h3>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div align="center">
                                        <p><b>*Matrícula:</b></p>
                                        <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" Width="200px" ToolTip="Campo obligatorio"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2">

                                </div>
                                <div class="col-md-4">
                                    <div align="center">
                                        <p><b>Nombre:</b></p>
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                                        <br />
                                        <p><b>Apellido paterno:</b></p>
                                        <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                                        <br />
                                        <p><b>Apellido materno:</b></p>
                                        <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div align="center">
                                        <p><b>Escribe una contraseña:</b></p>
                                        <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" TextMode="Password" Width="200px"></asp:TextBox>
                                        <br />
                                        <p><b>Confirmar contraseña:</b></p>
                                        <asp:TextBox ID="txtContraseña2" runat="server" CssClass="form-control" TextMode="Password" Width="200px"></asp:TextBox>
                                        <br />
                                        <p><b>Tipo de usuario:</b></p>
                                        <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" Height="34px" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2">

                                </div>
                            </div>
                            <br />
                            <div align="center">
                                   <asp:LinkButton ID="LinkButton1" CssClass="btn btn-warning" runat="server" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-pencil"></span>&nbsp;Registrarse</asp:LinkButton>
                                   <asp:LinkButton ID="LinkButton2" ToolTip="Al registrarte aceptas las políticas de uso de datos." CssClass="btn btn-warning" runat="server" href="Iniciar.aspx"><span class="glyphicon glyphicon-user"></span>&nbsp;Ya tengo una cuenta</asp:LinkButton>                                   </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="alert alert-dismissable alert-info">
            <h4>No dejes campos vacíos!
            </h4>
            <strong>Antes de guardar!</strong> Recuerda revisar que todos tus datos sean corretos y que todos los campos estén llenos!
        </div>
        <div class="alert alert-dismissable alert-info">
            <h4>Aviso de privacidad!
            </h4>
            <strong>Datos seguros!</strong> Todos tus datos se encuentran seguros y protegidos por el aviso de privacidad!
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
