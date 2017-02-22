<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUtmAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="WebUTM.WebUtmAdmin.usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
    <div class="copy-section">
        <div class="container">
            <h3>Gestión de usuarios</h3>
        </div>
    </div>
    
    <style type="text/css">

    #Background
    {
        position: fixed; 
        top: 0px; 
        bottom: 0px; 
        left: 0px; 
        right: 0px; 
        overflow: hidden; 
        padding: 0; 
        margin: 0; 
        background-color: #F0F0F0; 
        filter: alpha(opacity=80); 
        opacity: 0.8; 
        z-index: 100000;
    }
        
    #Progress
    {
        position: fixed;
        top: 40%; 
        left: 40%; 
        height:20%; 
        width:20%; 
        z-index: 100001;  
        background-color: #FFFFFF; 
        border:1px solid Gray; 
        background-image: url('../Recursos/Images/loading.gif'); 
        background-repeat: no-repeat; 
        background-position:center;
    }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="row">
        <div class="col-md-12" align="left">
            <ul class="breadcrumb">
                <p class="mia2">Estás en:</p>
                <li>
                    <a href="index.aspx" class="mia2">
                        <b>Inicio</b>
                    </a><span class="divider"></span>
                </li>
                <li class="active mili1">
                        <b>Usuarios</b>
                </li>
            </ul>
        </div>
    </div>
    <br />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2 thumbnail">
                <div align="center">
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Agregar</asp:LinkButton>
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton2_Click"><span class="glyphicon glyphicon-search"></span>&nbsp;Buscar</asp:LinkButton>
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton3" Enabled="False" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton3_Click"><span class="glyphicon glyphicon-pencil"></span>&nbsp;Editar</asp:LinkButton>
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton4_Click"><span class="glyphicon glyphicon-print"></span>&nbsp;Imprimir</asp:LinkButton>
                    <br />
                    <br />
                </div>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-8 thumbnail">
                <br />
                <h3 class="text-center">Datos de los usuarios</h3>
                <br />
                <br />
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-5">
                        <div align="center">
                            <p class="text-center"><b>Matrícula:</b></p>
                            <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <br />
                        <div align="center">
                            <p class="text-center"><b>Nombre:</b></p>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <br />
                        <div align="center">
                            <p class="text-center"><b>Apellido Paterno:</b></p>
                            <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <br />
                        <div align="center">
                            <p><b>Apellido Materno:</b></p>
                            <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <div align="center">
                            <p><b>Escribe una contraseña:</b></p>
                            <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                        <br />
                        <div align="center">
                            <p><b>Confirmar contraseña:</b></p>
                            <asp:TextBox ID="txtContraseña2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                        <br />
                        <div align="center">
                            <p><b>Tipo de usuario:</b></p>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Height="35px" Width="153px" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-1"></div>
                </div>
                <br />
                <br />
            </div>
            <div class="col-md-1"></div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div align="center">
                    <asp:GridView ID="GridView1" runat="server" Width="1100px" AutoGenerateColumns="False" CellPadding="4" GridLines="None" DataKeyNames="Matricula" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno" />
                            <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno" />
                            <asp:BoundField DataField="Tipo_Usuario" HeaderText="Tipo de usuario" />
                          <%--  <asp:ButtonField CommandName="Ver" Text="Ver" ControlStyle-CssClass="btn btn-info" ControlStyle-ForeColor="White">
                                <ControlStyle CssClass="btn btn-info" ForeColor="White"></ControlStyle>
                            </asp:ButtonField>
                            <asp:ButtonField CommandName="Eliminar"   Text="Eliminar" ControlStyle-CssClass="btn btn-danger" ControlStyle-ForeColor="White" >
                                <ControlStyle CssClass="btn btn-danger" ForeColor="White"></ControlStyle>
                            </asp:ButtonField>--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Ver" CssClass="btn btn-warning" ControlStyle-CssClass="btn btn-info"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  >Ver</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton5" onclientclick="return confirm('¿Desea Eliminar este registro?');" runat="server" CommandName="Eliminar" CssClass="btn btn-danger"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"> Eliminar</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
