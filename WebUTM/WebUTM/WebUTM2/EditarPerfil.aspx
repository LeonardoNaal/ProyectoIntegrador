<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTMLogIn.Master" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="WebUTM.WebUTM2.EditarPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
        <div class="copy-section">
        <div class="container">
            <h3>Perfil</h3>
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
                       Editar perfil
                </li>
            </ul>
        </div>
    </div>
    <br />
    <div class="row">
            <div class="col-md-2">

            </div>
            <div class="col-md-8 thumbnail well">
                <h3 class="text-center">Bienvenido <asp:label ID="lbl" runat="server" text="Label"></asp:label> | Edita tus datos</h3>
                <br />
                <div class="row">
                    <div class="col-md-4">
                        <h4 class="text-center">No te olvides de seguir:</h4>
                        <br />
                        <br />
                        <div align="center">
                        <h4>Publicaciones</h4>
                        <br />
                        <img src="../Recursos/Images/publicaciones.png" width="60" height="70" />
                        <hr />
                        <h4>Actividades</h4>
                        <br />
                        <img src="../Recursos/Images/horario1.png" width="70" height="70" />
                        <hr />
                        <h4>Sitios</h4>
                        <br />
                        <img src="../Recursos/Images/marca.png" width="70" height="70" />
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div align="center">
                            <p><b>Matrícula:</b></p>
                            <asp:textbox id="txtMatricula" runat="server" cssclass="form-control" width="200px" tooltip="Campo obligatorio" enabled="false"></asp:textbox>
                            <br />
                            <p><b>Nombre:</b></p>
                            <asp:textbox id="txtNombre" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                            <br />
                            <p><b>Apellido paterno:</b></p>
                            <asp:textbox id="txtApellidoPaterno" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                            <br />
                            <p><b>Apellido materno:</b></p>
                            <asp:textbox id="txtApellidoMaterno" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                            <br />
                            <p><b>Escribe una nueva contraseña:</b></p>
                            <asp:textbox id="txtContraseña" runat="server" cssclass="form-control" textmode="Password" width="200px"></asp:textbox>
                            <br />
                            <p><b>Confirmar contraseña:</b></p>
                            <asp:textbox id="txtContraseña2" runat="server" cssclass="form-control" textmode="Password" width="200px"></asp:textbox>
                            <br />
                            <asp:button id="Button1" runat="server" text="Guardar" cssclass="btn btn-warning" tooltip="Al registrarte aceptas las políticas de uso de datos." width="141" height="46" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
             </div>
            <div class="col-md-2">

            </div>
        </div>
</asp:Content>