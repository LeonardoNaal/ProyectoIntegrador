<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUtmAdmin.Master" AutoEventWireup="True" CodeBehind="admin_actividad.aspx.cs" Inherits="WebUTM.WebUtmAdmin.admin_actividad" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
    <div class="copy-section">
        <div class="container">
            <h3>Gestión de actividades</h3>
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
                        Actividades
                </li>
            </ul>
        </div>
    </div>
    <hr />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2 thumbnail">
                <br />
                <div align="center">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton1_Click" ><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Agregar</asp:LinkButton>
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton2_Click" ><span class="glyphicon glyphicon-search"></span>&nbsp;Buscar</asp:LinkButton>
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton3" Enabled="false" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton3_Click" ><span class="glyphicon glyphicon-pencil"></span>&nbsp;Editar</asp:LinkButton>
                    <br />
                    <br />
                    <br />
                </div>
                <asp:Label ID="lblcodAct" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="lblcodUser" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-8 thumbnail">
                <div align="center">
                <div class="row">
                    <div class="col-md-4">
                        <p><b>Nombre:</b></p>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <p><b>Fecha de inicio:</b></p>
                        <input id="txtFecha" type="date"/>
                        <asp:TextBox ID="txtFecha1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <p><b>Fecha de término:</b></p>
                        <asp:TextBox ID="txtFecha2" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br />
                 <p><b>Descripción:</b></p>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Height="180px" Width="871px"></asp:TextBox>
                <br />
                <div class="row">
                    <div class="col-md-4">
                        <p><b>Hora Inicio:</b></p>
                <asp:TextBox ID="txtHoraIni" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <p><b>Hora Fin:</b></p>
                <asp:TextBox ID="txtHoraFin" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                         <p><b>Sitio:</b></p>
                        <asp:DropDownList ID="DDLTipoSitio" runat="server" CssClass="form-control" AppendDataBoundItems="True" Height="35px" Width="187px"></asp:DropDownList>
                    </div>
                </div>
                <br />
            </div>
                </div>
            <div class="col-md-1">

            </div>
            <hr />
        </div>
        <div class="container">
            <div align="center">
                <br />
                <div class="panel-group" id="panel-328126">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <a class="panel-title" data-toggle="collapse" data-parent="#panel-328126" href="#panel-element-363821">Ver actividades</a>
                        </div>
                        <div id="panel-element-363821" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="0px" CellPadding="4" RepeatColumns="1" RepeatDirection="Horizontal" ForeColor="Black" CellSpacing="4" Width="900px" Height="151px" DataKeyField="IDActividad" DeleteCommand="DataList1_DeleteCommand" OnItemCommand="DataList1_ItemCommand">
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <ItemTemplate>
                                        <div class="jumbotron well">
                                            <asp:Label ID="lbltitulo" runat="server" Font-Size="Large"><strong>Nombre:</strong> </asp:Label><asp:Label ID="Label1" runat="server" Text='<%# Eval("Nombre") %>' Font-Size="Large" Font-Bold="true" ForeColor="#3A6B25"></asp:Label></strong><br />
                                            <asp:Label ID="Label5" runat="server"><strong>Descripción:</strong> </asp:Label><asp:Label ID="Label3" runat="server" Text='<%# Eval("Descripcion") %>' Font-Size="Large"></asp:Label><br />
                                            <asp:Label ID="Label6" runat="server"><strong>Fecha Inicio:</strong> </asp:Label><asp:Label ID="Label2" runat="server" Text='<%# Eval("FechaIni") %>' Font-Italic="True" Font-Bold="True"></asp:Label><br />
                                            <asp:Label ID="Label4" runat="server"><strong>Fecha Final:</strong> </asp:Label><asp:Label ID="Label7" runat="server" Text='<%# Eval("FechaFin") %>' Font-Italic="True" Font-Bold="True"></asp:Label><br />
                                            <br />
                                            <asp:Button ID="btnVer" runat="server" Text="Ver" CommandName="update" CssClass="btn btn-primary" Width="90" Height="30" />
                                            <asp:Button ID="btnEliminar" runat="server" onclientclick="return confirm('¿Desea Eliminar este registro?');" Text="Eliminar" CommandName="delete" CssClass="btn btn-danger" Width="90" Height="30" />
                                            <br />
                                        </div>
                                    </ItemTemplate>
                                    <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                </asp:DataList>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div align="center">
                                                    <asp:Button ID="btnfirst" runat="server" CssClass="btn btn-primary btn-success" Font-Bold="true" Text="<<" Height="31px" Width="43px" OnClick="btnfirst_Click" />
                                            <asp:Button ID="btnprevious" CssClass="btn btn-primary btn-success" runat="server" Font-Bold="true" Height="31px" OnClick="btnprevious_Click" Text="&lt;" Width="43px" />
                                            <asp:Button ID="btnnext" CssClass="btn btn-primary btn-success" runat="server" Font-Bold="true" Height="31px" OnClick="btnnext_Click" Text="&gt;" Width="43px" />
                                            <asp:Button ID="btnlast" CssClass="btn btn-primary btn-success" runat="server" Font-Bold="true" Height="31px" OnClick="btnlast_Click" Text="&gt;&gt;" Width="43px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

