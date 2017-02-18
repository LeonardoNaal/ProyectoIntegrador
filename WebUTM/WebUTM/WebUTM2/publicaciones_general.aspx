<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTMLogIn.Master" AutoEventWireup="true" CodeBehind="publicaciones_general.aspx.cs" Inherits="WebUTM.WebUTM2.publicaciones_general" %>
<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
      <div class="copy-section">
        <div class="container">
            <h3>Publicaciones</h3>
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
            <div class="col-md-3">
                <%--<div class="jumbotron well banner-bottom">
                <div class="media">
                    <a href="#" class="pull-left">
                        <img src="../Recursos/Images/28.jpg" width="64" height="64" class="media-object" />
                    </a>
                    <div class="media-body">
                        <h4 class="media-heading">Hola</h4>
                        Hola mundo maldito
                    </div>
                </div>
                <div class="media">
                    <a href="#" class="pull-left">
                        <img src="../Recursos/Images/28.jpg" width="64" height="64" class="media-object" />
                    </a>
                    <div class="media-body">
                        <h4 class="media-heading">Hola</h4>
                        Hola mundo maldito
                    </div>
                </div>
                </div>--%>
                <br />
                <div class="jumbotron well banner-bottom">
                <h3 class="title">No te pierdas ninguna publicación</h3>
                    <br />
                <h2 class="title text-center">Descarga nuestra App!</h2>
                <br />
                    <img src="../Recursos/Images/android-7.png" width="150" height="190" />
                    <br />
                    <img src="../Recursos/Images/googleplay.png" width="150" height="100" />
                </div>
                <div class="jumbotron well banner-bottom">
                    <h3 class="title">Recibe publicaciones en tu móvil</h3>
                    <br />
                    <img src="../Recursos/Images/android-phone-color.png" width="140" height="140" />
                </div>
            </div>
            <div class="col-md-9">
                <br />
                <br />
                <h3 class=" text-center">Publicaciones recientes</h3>
                <br />
                  <p><b>Filtrar por:</b></p>
                <asp:DropDownList ID="DDLTipoUsuarios" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoUsuarios_SelectedIndexChanged" Height="27px" Width="217px"></asp:DropDownList>
                <br />
                <br />
                <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="0px" CellPadding="4" RepeatColumns="1" RepeatDirection="Horizontal" ForeColor="Black" CellSpacing="4" Width="800px" Height="151px" DataKeyField="IDPublicacion" OnItemCommand="DataList1_ItemCommand" >
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <ItemTemplate>
                        <div class="jumbotron well">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Titulo") %>' Font-Size="Large" Font-Bold="true" ForeColor="#F58025"></asp:Label><br />
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Fecha") %>' Font-Italic="True" Font-Bold="True"></asp:Label><br />
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Contenido") %>' Font-Size="Large"></asp:Label><br />
                                    <br />
                                </div>
                                <div class="col-md-6">
                                    <asp:Image ID="Image1" runat="server" Width="200px" Height="125px" ImageUrl='<%# "../WebUTM/ImageHandler.ashx?ID="+ Eval("IDPublicacion") %>' ImageAlign="Middle" BorderStyle="Groove" CssClass="img-thumbnail" />
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Recursos/Images/play-icon.png" ImageAlign="Middle" Width="35" Height="35" CommandName="VerVideo"  />
                                </div>
                            </di>
                        </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="700px" Height="70px"> </asp:TextBox>
                                    <br />
                                    <br />
                                    <div align="center">
                                                <asp:Button ID="Button1" runat="server" Text="Comentar" CommandName="AgregarComentario" CssClass="btn btn-warning"  />
                                               <asp:Button ID="Button2" runat="server" CommandName="VerComentarios" CssClass="btn btn-warning" OnClick="Button2_Click" Text="Ver comentarios" />
                                    </div>
                                </div>
                            </div>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                </asp:DataList>
                <div class="modal fade" id="mymodal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    ×</button>
                                <h4 class="modal-title" id="myModalLabel">Comentarios
                                </h4>
                            </div>
                            <div class="modal-body">
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Nombres") %>' Font-Bold="True"></asp:Label>:
                                        <br />
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Contenido") %>'></asp:Label>
                                        <hr />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cerrar</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="mymodal2" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    ×</button>
                                <h4 class="modal-title" id="myModalLabel2">VIDEO
                                </h4>
                            </div>
                            <div class="modal-body">
                                <h5>Haz clic en el centro...</h5>
                                <asp:DataList ID="DataList2" Visible="true" runat="server" AutoGenerateColumns="false"
    RepeatColumns="1" CellSpacing="5">
                                    <ItemTemplate>
                                        <a class="player" style="height: 300px; width: 300px; display: block" href='<%# Eval("IDPublicacion","../WebUTM/VideoHandler.ashx?ID={0}") %>'></a>
                                        <hr />
                                    </ItemTemplate>
                                </asp:DataList>
                                   <script src="FlowPlayer\flowplayer-3.2.12.min.js" type="text/javascript"></script>
                                <script type="text/javascript">
                                    flowplayer("a.player", "FlowPlayer\flowplayer-3.2.16.swf", {
                                        plugins: {
                                            pseudo: { url: "FlowPlayer\flowplayer.pseudostreaming-3.2.12.swf" }
                                        },
                                        clip: { provider: 'pseudo', autoPlay: false},
                                    });
                                </script>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cerrar</button>
                            </div>
                        </div>
                    </div>
                </div>
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
</asp:Content>
