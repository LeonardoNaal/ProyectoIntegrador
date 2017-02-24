<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage/WebUtmAdmin.Master" AutoEventWireup="true" CodeBehind="admin_pub.aspx.cs" Inherits="WebUTM.WebUtmAdmin.admin_pub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
    <div class="copy-section">
        <div class="container">
            <h3>Gestión de Publicaciones</h3>
        </div>
    </div>
    <!--Script JS-->
    <script type="text/javascript">
        function showImage(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    document.getElementsByTagName("imagen1")[1].setAttribute("ImageUrl", e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
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
            </div>
            <asp:Label ID="lblcod" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="lblcoduser" runat="server" Text="Label" Visible="False"></asp:Label>
            <div class="col-md-1"></div>
            <div class="col-md-8 thumbnail">
                <div align="center">
                <div class="row">
                    <div class="col-md-4">
                        <p><b>Título:</b></p>
                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <p><b>Fecha:</b></p>
                        <asp:TextBox  ID="txtFecha" runat="server" CssClass="form-control" Enabled="False" ></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <p><b>Tipo de publicación:</b></p>
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="149px" AppendDataBoundItems="True"></asp:DropDownList>
                    </div>
                </div>
                <br />
                    <p><b>Descripción:</b></p>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Height="180px" Width="871px"></asp:TextBox>
                </div>
                <br />
                <div align="center">
                <div class="row">
                    <div class="col-md-6">
                        <p><b>Imagen:</b></p>
                        <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="None" Width="140px" onchange="showImage(this)"/>
                       
                        <br /> 
                        <asp:Image ID="image1" runat="server" Width="170"  Height="100" />
                    </div>
                    <div class="col-md-6">
                        <p><b>Video:</b></p>
                        <asp:FileUpload ID="FileUpload2" runat="server" />
                    </div>
                </div>
                    </div>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
            <div class="col-md-1"></div>
        </div>
        <div class="container">
            <br />
            <div align="center">
                <div class="panel-group" id="panel-328126">
				<div class="panel panel-default">
					<div class="panel-heading">
						 <a class="panel-title" data-toggle="collapse" data-parent="#panel-328126" href="#panel-element-363821">Ver publicaciones</a>
					</div>
					<div id="panel-element-363821" class="panel-collapse collapse in">
						<div class="panel-body">
							<%--aquí va datalist--%>
                            <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="0px" CellPadding="4" RepeatColumns="1" RepeatDirection="Horizontal" ForeColor="Black" CellSpacing="4" Width="900px" Height="151px" DataKeyField="IDPublicacion" OnDeleteCommand="DataList1_DeleteCommand" OnItemCommand="DataList1_ItemCommand">
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                <ItemTemplate>
                                    <div class="well">
                                        <asp:Label ID="lbltitulo" runat="server" Font-Size="Large"><strong>Título:</strong> </asp:Label><asp:Label ID="Label1" runat="server" Text='<%# Eval("Titulo") %>' Font-Size="Large" Font-Bold="true" ForeColor="#3A6B25"></asp:Label></strong><br />
                                        <asp:Label ID="Label5" runat="server"><strong>Descripción:</strong> </asp:Label><asp:Label ID="Label3" runat="server" Text='<%# Eval("Contenido") %>' Font-Size="Large"></asp:Label><br />
                                        <asp:Label ID="Label6" runat="server"><strong>Fecha:</strong> </asp:Label><asp:Label ID="Label2" runat="server" Text='<%# Eval("Fecha") %>' Font-Italic="True" Font-Bold="True"></asp:Label><br />
                                        <br />
                                        <asp:Button ID="btnVer" runat="server" Text="Ver" CommandName="update" CssClass="btn btn-primary" Width="90" Height="30"   />
                                        <asp:Button ID="btnEliminar" runat="server" onclientclick="return confirm('¿Desea Eliminar este registro?');"  Text="Eliminar" CommandName="delete" CssClass="btn btn-danger" Width="90" Height="30" />
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
                        <br />
                    </div>
                    <br />
                </div>
						</div>
					</div>
				</div>
			</div>
            </div>
        </div>
    </div>
</asp:Content>
