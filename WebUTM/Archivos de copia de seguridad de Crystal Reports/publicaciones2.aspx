<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTMLogIn.Master" AutoEventWireup="true" CodeBehind="publicaciones2.aspx.cs" Inherits="WebUTM.WebUTM2.publicaciones2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
    <div class="copy-section">
        <div class="container">
            <h3>Publicaciones</h3>
        </div>
    </div>
    <script type="text/javascript">
        function showimagepreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    document.getElementsByTagName("img2")[0].setAttribute("src", e.target.result);
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
                        Mis publicaciones
                </li>
            </ul>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <br />
                <div class="media">
                    <a href="#" class="pull-left">
                        <img alt="Bootstrap Media Preview" src="../Recursos/Images/calendario.png" class="media-object" width="64" height="64" /></a>
                    <div class="media-body">
                        Las publicaciones son vistas por todos los que visitan el sitio, ¿tienes algo para comentar?.
                        <br />
                        <br />
                        <a href="publicaciones_general.aspx" class="btn btn-warning">Llévame ahí</a>
                    </div>
                </div>
                <hr />
                <div align="center">
                    <img src="../Recursos/Images/app.png" width="300" height="200" />
                </div>
                <h4>Descarga nuestra app!</h4>
                <br />
                <div align="right">
                    <a href="#" class="btn btn-warning">Descargar</a>
                </div>
                <hr />
                <div class="media">
                    <a href="#" class="pull-left">
                        <img alt="Bootstrap Media Preview" src="../Recursos/Images/maps.png" class="media-object" width="64" height="64" /></a>
                    <div class="media-body">
                        Identifica un edificio al que quieras ir, no te pierdas, mira los detalles de cada uno y localiza el aula o auditorio que busques.
                        <br />
                        <br />
                        <a href="#" class="btn btn-warning">Llévame ahí</a>
                    </div>
                </div>
                <hr />
            </div>
            <div class="col-md-8">
                <br />
                <div align="center">
                    <asp:Label ID="Label4" runat="server" Text="Label" Font-Names="Cagliostro" ForeColor="#FF9933" Font-Size="X-Large"></asp:Label>
                </div>
                <br />

                <div class="jumbotron">
                    <h4 class="text-center">Publica para que los demás lo vean</h4>
                    <br />
                    <div class="row">
                        <div class="col-md-8">
                            <h4>Título:</h4>
                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" Height="31px" Width="410px"></asp:TextBox>
                            <br />
                        </div>
                        <h4 class="text-center">Tipo Publicación:</h4>
                        <div class="col-md-4">
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="31px" Width="200px"></asp:DropDownList>
                        </div>
                    </div>
                    <h4>Descripción:</h4>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Height="150px" Width="640px"></asp:TextBox>
                    <br />
                    <div align="center">
                        <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="None" Width="140px" Onchange="showimagepreview(this)" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ErrorMessage="Tipo de archivo no permitido" ControlToValidate="FileUpload1"
                            ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.gif|.GIF|.png|.PNG|.jpeg|.JPEG)$">
                        </asp:RegularExpressionValidator>
                        <br />
                        <asp:Image ID="img2" runat="server" Width="170" Height="100" />
                        <hr />
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-bullhorn"></span>&nbsp;Publicar</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" Enabled="false" runat="server" CssClass="btn btn-warning" Width="150" Height="40" OnClick="LinkButton3_Click"><span class="glyphicon glyphicon-pencil"></span>&nbsp;Editar</asp:LinkButton>
                    </div>
                    <asp:Label ID="lblstringimagen" Visible="false" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lblcod" runat="server" Text="Label" Visible="false"></asp:Label>
                    <div align="right">
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="panel-group" id="panel-328126">
                    <div class="panel panel-default">
                        <div class="panel-heading" align="center">
                            <a class="panel-title" data-toggle="collapse" data-parent="#panel-328126" href="#panel-element-363821">Mis publicaciones</a>
                        </div>
                        <div id="panel-element-363821" class="panel-collapse collapse">
                            <div class="panel-body">
                                <div align="center">
                                    <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="0px" CellPadding="4" RepeatColumns="1" RepeatDirection="Horizontal" ForeColor="Black" CellSpacing="4" DataKeyField="IDPublicacion" OnItemCommand="DataList1_ItemCommand" OnDeleteCommand="DataList1_DeleteCommand" Width="1000px">
                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <ItemTemplate>
                                            <nav class="navbar navbar-default" role="navigation">
                                                <ul class="nav navbar-nav navbar-right">
                                                    <li class="dropdown">
                                                        <a href="#" class="btn btn-warning dropdown-toggle" data-toggle="dropdown"><span class="glyphicon glyphicon-chevron-down"></span></a>
                                                        <ul class="dropdown-menu">
                                                            <div align="center">
                                                                <li>
                                                                    <asp:Button ID="Button5" runat="server" Text="Ver" CssClass="btn btn-warning" Width="100" CommandName="Ver" />
                                                                </li>
                                                                <br />
                                                                <li>
                                                                    <asp:Button ID="Button6" runat="server" Text="Eliminar" CssClass="btn btn-danger" Width="100" CommandName="delete" />
                                                                </li>
                                                            </div>
                                                        </ul>
                                                    </li>
                                                </ul>
                                            </nav>
                                            <div class="well" align="center">
                                                <div align="center">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Titulo") %>' Font-Size="Large" Font-Bold="true" ForeColor="#F58025"></asp:Label><br />
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Fecha") %>' Font-Italic="True" Font-Bold="True"></asp:Label><br />
                                                </div>
                                                <br />
                                                <div align="center">
                                                    <asp:Image ID="Image1" runat="server" Width="150px" Height="75px" ImageUrl='<%# "../WebUtm/ImageHandler.ashx?ID="+ Eval("IDPublicacion") %>' ImageAlign="Middle" BorderStyle="Groove" CssClass="img-thumbnail" />
                                                </div>
                                                <br />
                                                <br />
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Contenido") %>' Font-Size="Large"></asp:Label><br />
                                                <br />
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                        <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    </asp:DataList>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div align="center">
                                                <asp:Button ID="btnfirst" runat="server" CssClass="btn btn-warning" Font-Bold="true" Text="<<" Height="31px" Width="43px" OnClick="btnfirst_Click" />
                                                <asp:Button ID="btnprevious" CssClass="btn btn-warning" runat="server" Font-Bold="true" Height="31px" OnClick="btnprevious_Click" Text="&lt;" Width="43px" />
                                                <asp:Button ID="btnnext" CssClass="btn btn-warning" runat="server" Font-Bold="true" Height="31px" OnClick="btnnext_Click" Text="&gt;" Width="43px" />
                                                <asp:Button ID="btnlast" CssClass="btn btn-warning" runat="server" Font-Bold="true" Height="31px" OnClick="btnlast_Click" Text="&gt;&gt;" Width="43px" />
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
    </div>
</asp:Content>

