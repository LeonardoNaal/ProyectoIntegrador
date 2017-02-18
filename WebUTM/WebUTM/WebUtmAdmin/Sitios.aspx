<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUtmAdmin.Master" AutoEventWireup="true" CodeBehind="Sitios.aspx.cs" Inherits="WebUTM.WebUtmAdmin.Horario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
    <div class="copy-section">
        <div class="container">
            <h3>Horario</h3>
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
                        Sitios
                </li>
            </ul>
        </div>
    </div>
    <br />
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2 thumbnail">
                <br />
                <div align="center">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Agregar</asp:LinkButton>
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton2_Click"><span class="glyphicon glyphicon-search"></span>&nbsp;Buscar</asp:LinkButton>
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton3" Enabled="false" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton3_Click"><span class="glyphicon glyphicon-pencil"></span>&nbsp;Editar</asp:LinkButton>
                    <br />
                    <br />
                    <br />
                </div>
            </div>
            <asp:Label ID="lblcod" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="lblcoduser" runat="server" Text="Label" Visible="False"></asp:Label>
            <div class="col-md-1"></div>
            <div class="col-md-8 thumbnail">
                <div align="center">
                    <div class="row">
                        <br />
                        <div class="col-md-4">
                            <p><b>Nombre Sitio:</b></p>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <p><b>Planta:</b></p>
                            <asp:RadioButtonList ID="rdbplanta" runat="server">
                                <asp:ListItem Text="Alta" Value="Alta" />
                                <asp:ListItem Text="Baja" Value="Baja" />
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-md-4">
                            <p><b>Sitio:</b></p>
                            <asp:DropDownList ID="DDLSitio" runat="server" Height="35px" Width="149px" AppendDataBoundItems="True"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                </div>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
            <div class="col-md-1"></div>
        </div>
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-8">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" Width="875px" DataKeyNames="IDSitio" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre sitio" />
                        <asp:BoundField DataField="planta" HeaderText="Planta" />
                        <asp:BoundField DataField="NombreTipo" HeaderText="Tipo Sitio" />
                        <asp:ButtonField CommandName="Ver" ImageUrl="Ver" Text="Ver" />
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" />
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
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
            <div class="col-md-1"></div>
        </div>
    </div>
</asp:Content>
