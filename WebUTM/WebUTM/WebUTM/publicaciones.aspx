<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTM.Master" EnableEventValidation="false" CodeBehind="publicaciones.aspx.cs"  AutoEventWireup="true" Inherits="WebUTM.WebUTM.publicaciones" %>

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
        <div class="container">
            <br />
        <h4>Estás en:</h4>
            <br />
        <div class="btn-group btn-breadcrumb">
            <a href="index.aspx" class="btn btn-primary"><i class="glyphicon glyphicon-home"></i></a>
            <a href="#" class="btn btn-primary">Publicaciones</a>
        </div>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <div class="media">
                    <a href="#" class="pull-left">
                        <img alt="Bootstrap Media Preview" src="../Recursos/Images/calendario.png" class="media-object" width="64" height="64" /></a>
                    <div class="media-body">
                        Una actividad es publicada por profesores de cada área para reunir a las personas, son una forma de organizar eventos.
                        <br />
                        <br />
                        <a href="#" class="btn btn-warning">Llévame ahí</a>
                    </div>
                </div>
                <hr />
                <div class="media">
                    <a href="#" class="pull-left">
                        <img alt="Bootstrap Media Preview" src="../Recursos/Images/paint.png" class="media-object" width="64" height="64" /></a>
                    <div class="media-body">
                        ¿No tienes una imagen o foto? Créala tú mismo.
                        <br />
                        <br />
                        <a href="../Paint/index.html" class="btn btn-warning">Llévame ahí</a>
                    </div>
                </div>
                <hr />
                <div align="center">
                    <img src="../Recursos/Images/app.png" width="180" height="120" />
                </div>
                <h4>Descarga nuestra app!</h4>
                <br />
                <div align="center">
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
                <br />
                <hr />
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="col-md-9">
                <h3 class="text-center">Publicaciones destacadas</h3>
                <br />
                <!-- Start WOWSlider.com BODY section --> <!-- add to the <body> of your page -->
               
                        <div id="wowslider-container1">
                            <div class="ws_images">
                                <ul>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Repeater ID="Repeater3" runat="server" >
                                                <ItemTemplate>
                                                    <li>
                                                        <img title="" src='<%# "ImageHandler.ashx?ID="+ Eval("IDPublicacion") %>' runat="server" />
                                                        <h4>
                                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Titulo") %>'></asp:Label></h4>
                                                        <h3 align="center">
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Contenido") %>'></asp:Label></h3>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ul>
                            </div>
                            <div class="ws_script" style="position: absolute; left: -99%"></div>
                            <div class="ws_shadow"></div>
                        </div>
                   
                <!-- End WOWSlider.com BODY section -->
                <!--start-->
               
                <div class="row">
                    <div align="center">
                        <div class="col-md-12">
                            <hr />
<asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="0px" CellPadding="4" RepeatColumns="1" RepeatDirection="Horizontal" ForeColor="Black" CellSpacing="4" Width="750px" Height="100px" DataKeyField="IDPublicacion" OnItemCommand="DataList1_ItemCommand">
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
                                    <asp:Image ID="Image1" runat="server" Width="200px" Height="120px" ImageUrl='<%# "ImageHandler.ashx?ID="+ Eval("IDPublicacion") %>' ImageAlign="Middle" BorderStyle="Groove" CssClass="img-thumbnail" />
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Recursos/Images/play-icon.png" ImageAlign="Middle" Width="35" Height="35" CommandName="VerVideo"  />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:TextBox ID="TextBox1" runat="server" Enabled="false" TextMode="MultiLine" Width="700px" Height="70px"></asp:TextBox>
                                    <br />
                                    <a href="Iniciar.aspx">Ingresa para dejar un comentario</a>
                                    <br />
                                    <div align="right">
                                        <asp:Button ID="Button1" data-toggle="modal" runat="server" Text="Ver comentarios" CommandName="VerComentarios" OnClick="Button1_Click" CssClass="btn btn-warning" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                </asp:DataList>
                        </div>
                    </div>
                </div>
                <!--end-->
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
                                <asp:DataList ID="DataList2" Visible="true" runat="server" AutoGenerateColumns="false" RepeatColumns="1" CellSpacing="5">
                                    <ItemTemplate>
                                        <a class="player" style="height: 300px; width: 300px; display: block" href='<%# Eval("IDPublicacion", "VideoHandler.ashx?ID={0}") %>'></a>
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
    <%--<div class="row">
        <div id="rondellPages" class="hidden">
            <asp:Repeater ID="Repeater3" runat="server">
                <ItemTemplate>
                    <div>
                        <img src='<%# "ImageHandler.ashx?ID="+ Eval("IDPublicacion") %>' runat="server" />
                        <h2>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Titulo") %>'></asp:Label></h2>
                        <h3 align="center">
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Contenido") %>'></asp:Label></h3>
                        <div align="center">
                            <asp:Button ID="Button1" runat="server" Text="Comentarios" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="Repeater4" runat="server">
                <ItemTemplate>
                    <div>
                        <img src='<%# "ImageHandler.ashx?ID="+ Eval("IDPublicacion") %>' runat="server" />
                        <h2>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Titulo") %>'></asp:Label></h2>
                        <h3 align="center">
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Contenido") %>'></asp:Label></h3>
                        <div align="center">
                            <asp:Button ID="Button1" runat="server" Text="Comentarios" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="Repeater5" runat="server">
                <ItemTemplate>
                    <div>
                        <img src='<%# "ImageHandler.ashx?ID="+ Eval("IDPublicacion") %>' runat="server" />
                        <h2>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Titulo") %>'></asp:Label></h2>
                        <h3 align="center">
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Contenido") %>'></asp:Label></h3>
                        <div align="center">
                            <asp:Button ID="Button1" runat="server" Text="Comentarios" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>--%>
</asp:Content>
