<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTMLogIn.Master" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="WebUTM.WebUTM2.index2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">

    <div class="banner">
        <div id="kb" class="carousel kb_elastic animate_text kb_wrapper" data-ride="carousel" data-interval="6000" data-pause="hover">

            <!-- wraper para el slider -->
            <div class="carousel-inner" role="listbox">

                <!-- Primera imagen -->
                <div class="item active">
                    <img src="/Recursos/Images/banner1.jpg" alt="" class="img-responsive" />
                    <div class="carousel-caption kb_caption">
                        <h3 data-animation="animated flipInX">Descarga nuestra App!</h3>
                        <h4 data-animation="animated flipInX">No te pierdas ninguna publicación</h4>
                    </div>
                </div>

                <!-- Segunda imagen -->
                <div class="item">
                    <img src="/Recursos/Images/carousel2.jpg" alt="" class="img-responsive" />
                    <div class="carousel-caption kb_caption kb_caption_right">
                        <h3 data-animation="animated flipInX">Mira publicaciones</</h3>
                        <h4 data-animation="animated flipInX">Agrega la tuya también</h4>
                    </div>
                </div>

                <!-- Tercera imagen -->
                <div class="item">
                    <img src="/Recursos/Images/carousel3.jpg" alt="" class="img-responsive" />
                    <div class="carousel-caption kb_caption kb_caption_center">
                        <h3 data-animation="animated flipInX">¿Quieres hacer alguna actividad?</</h3>
                        <h4 data-animation="animated flipInX">Puedes ver todas las que hay</h4>
                    </div>
                </div>

            </div>

            <!-- Botón izquierdo -->
            <a class="left carousel-control kb_control_left" href="#kb" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-menu-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>

            <!-- Botón derecho -->
            <a class="right carousel-control kb_control_right" href="#kb" role="button" data-slide="next">
                <span class="glyphicon glyphicon-menu-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>

        </div>
        <script src="/Recursos/Bootstrap/js/custom.js"></script>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="banner-bottom">
        <div class="col-md-3 ban-grid">
            <div class="ban-left">
                <h4>Ingresa al sitio</h4>
                <p><a href="registro.aspx">Regístrate o inicia sesión</a> </p>
            </div>
            <div class="ban-right">
                <i class="glyphicon glyphicon-user"></i>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="col-md-3 ban-grid">
            <div class="ban-left">
                <h4>Publicaciones</h4>
                <p><a href="publicaciones.aspx">Mira las tuyas o las de tus amigos</a></p>
            </div>
            <div class="ban-right">
                <i class="glyphicon glyphicon-pencil"></i>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="col-md-3 ban-grid">
            <div class="ban-left">
                <h4>Edificios</h4>
                <p><a href="#">Búscalo aquí</a> </p>
            </div>
            <div class="ban-right">
                <i class="glyphicon glyphicon-map-marker"></i>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="col-md-3 ban-grid">
            <div class="ban-left">
                <h4>Actividades</h4>
                <p><a href="#">Mira las que se encuentran disponibles</a> </p>
            </div>
            <div class="ban-right">
                <i class="glyphicon glyphicon-calendar"></i>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="clearfix"></div>
    </div>
    <br />
    <div align="center">
        <h3>También en tu Android!</h3>
        <br />
        <img src="../Recursos/Images/android.png" class="zoom-img" />
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <h3 class="text-center"><span class="glyphicon glyphicon-calendar"></span> Últimas 3 actividades</h3>
                <hr />
                <asp:DataList ID="DataList2" runat="server" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="0px" CellPadding="4" RepeatColumns="1" RepeatDirection="Horizontal" ForeColor="Black" CellSpacing="4" DataKeyField="IDActividad">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <ItemTemplate>
                        <div class="jumbotron well">
                            <span class="glyphicon glyphicon-calendar"></span> <asp:Label ID="Label1" runat="server" Text='<%# Eval("Nombre") %>' Font-Size="Large" Font-Bold="true" ForeColor="#3A6B25"></asp:Label></strong><br />
                            <br />
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Descripcion") %>' Font-Size="Large"></asp:Label><br />
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <h4>Empieza:</h4>
                                    <span class="glyphicon glyphicon-time"></span> 
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("FechaIni") %>' Font-Italic="True" Font-Bold="True"></asp:Label><br />
                                    <br />
                                    <h4>Termina:</h4>
                                    <span class="glyphicon glyphicon-time"></span> 
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("FechaFin") %>' Font-Italic="True" Font-Bold="True"></asp:Label><br />
                                </div>
                                <div class="col-md-6">
                                    <div align="right">
                                    <img src="../Recursos/Images/horario.png" width="90" height="90" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                </asp:DataList>
            </div>
            <%--<div class="col-md-2">
                <div align="center">
                    <img src="../Recursos/Images/android-phone-color.png" width="200" height="200" />
                </div>
            </div>--%>
            <div class="col-md-6">
                <h3 class="text-center"><span class="glyphicon glyphicon-pencil"></span> Últimas 3 publicaciones</h3>
                <hr />
                <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="0px" CellPadding="4" RepeatColumns="1" RepeatDirection="Horizontal" ForeColor="Black" CellSpacing="4" DataKeyField="IDPublicacion">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <ItemTemplate>
                        <div class="jumbotron well">
                            <div align="center">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Titulo") %>' Font-Size="Large" Font-Bold="true" ForeColor="#F58025"></asp:Label><br />
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Fecha") %>' Font-Italic="True" Font-Bold="True"></asp:Label><br />
                                <br />
                            </div>
                            <div align="center">
                                <asp:Image ID="Image1" runat="server" Width="150px" Height="75px" ImageUrl='<%# "../WebUtm/ImageHandler.ashx?ID="+ Eval("IDPublicacion") %>' ImageAlign="Middle" BorderStyle="Groove" CssClass="img-thumbnail" />
                            </div>
                            <br />
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Contenido") %>' Font-Size="Large"></asp:Label><br />
                            <br />
                        </div>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                </asp:DataList>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-4 new-left">
                <h3>¿Te los perdiste?</h3>
                <div class="media">
                    <a href="http://www.utmetropolitana.edu.mx/Publicaciones/utm2457_CBFC9CD6-AD88-4815-918B-337F368F6969.html" class="pull-left">
                        <img alt="Bootstrap Media Preview" src="/Recursos/Images/media1.jpg" class="media-object" width="64" height="64" /></a>
                    <div class="media-body">
                        <h4 class="media-heading">Reto
                        </h4>
                        La aplicación de la información mediante redes inalámbricas, una plática que se llevó a cabo esta semana en las instalaciones de la UTM.
                    </div>
                </div>
                <div class="media">
                    <a href="http://www.utmetropolitana.edu.mx/Publicaciones/utm456_8D95B192-BAD4-4FA7-AFF6-4F836FE65459.html" class="pull-left">
                        <img alt="Bootstrap Media Preview" src="/Recursos/Images/media2.jpg" class="media-object" width="64" height="64" /></a>
                    <div class="media-body">
                        <h4 class="media-heading">Firma
                        </h4>
                        Se llevó a cabo la firma de un convenio con la fundación Tócate, todo esto con respecto al apoyo de la autoexploración en las mujeres.
                    </div>
                </div>
                <div class="media">
                    <a href="http://www.utmetropolitana.edu.mx/Publicaciones/utm443_288F2C05-E520-4E1D-8C67-8DB3C90BB878.html" class="pull-left">
                        <img alt="Bootstrap Media Preview" src="/Recursos/Images/media3.jpg" class="media-object" width="64" height="64" /></a>
                    <div class="media-body">
                        <h4 class="media-heading">Emprendedores
                        </h4>
                        En un evento que se llevó a cabo, se trataron temas de índole emprendedora, como emprender para no depender, hay mucho qué saber de esto.
                    </div>
                </div>
                <br />
                <br />
                <h3>No te vayas sin nuestra App para tu móvil</h3>
                <br />
                <img src="../Recursos/Images/android-phone-color.png" width="300" height="340" />
                <br />
            </div>
            <div class="col-md-8">
                <div class="jumbotron banner-bottom">
                    <h2>¿Cómo agrego una publicación?
                    </h2>
                    <p>
                        La manera es muy sencilla, simplemente ingresa a tu cuenta, o regístrate si todavía no tienes una, posteriormente dirígite a la sección de publicaciones, en esa sección podrás seguir los pasos para agregar tu publicación y que todos la vean.
                    </p>
                    <p>
                        <a class="btn btn-primary btn-success" href="#">Llévame ahí</a>
                    </p>
                </div>
                <br />
                <div class="media">
                    <a href="#" class="pull-left">
                        <img alt="Bootstrap Media Preview" src="../Recursos/Images/calendario.png" class="media-object" width="64" height="64" /></a>
                    <div class="media-body">
                        Una actividad es publicada por profesores de cada área para reunir a las personas, son una forma de organizar eventos.
                        <br />
                        <br />
                        <a href="#" class="btn btn-success">Llévame ahí</a>
                    </div>
                    <hr />
                    <div class="media">
                        <a href="#" class="pull-left">
                            <img alt="Bootstrap Media Preview" src="../Recursos/Images/maps.png" class="media-object" width="64" height="64" /></a>
                        <div class="media-body">
                            Identifica un edificio al que quieras ir, no te pierdas, mira los detalles de cada uno y localiza el aula o auditorio que busques.
                        <br />
                            <br />
                            <a href="#" class="btn btn-success">Llévame ahí</a>
                        </div>
                    </div>
                    <hr />
                    <div align="center">
                        <img src="../Recursos/Images/app.png" width="400" height="300" />
                        <h4>Las publicaciones te llegan a tu móvil!</h4>
                    </div>
                    <hr />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="student-w3ls">
        <div class="container">
            <h3 class="tittle">Mapas</h3>
            <div class="student-grids">
                <div class="col-md-6 student-grid">
                    <h4>Busca por sitios para que no te pierdas</h4>
                    <p>Muchas veces, la mayoría cuando no visitamos un lugar por primera vez, no sabemos en qué lugar se encuentra cierto sitio, es por eso, que en la Universidad implementamos esta sección que nos ayudará a ubicar los lugares que se encuentren en la isntitución para poder llegar con mas facilidad</p>
                    <p>Simplemente tienes que dirigirte a la sección de sitios, en donde encontrarás una manera mejor de ubicar esos lugares a los que quieres llegar.</p>
                    <ul class="grid-part">
                        <li><i class="glyphicon glyphicon-ok-sign"></i>Mapas específicos</li>
                        <li><i class="glyphicon glyphicon-ok-sign"></i>Busca un aula</li>
                        <li><i class="glyphicon glyphicon-ok-sign"></i>Mira entre todos los lugares de la Universidad</li>
                        <li><i class="glyphicon glyphicon-ok-sign"></i>Llega mas rápido</li>
                        <li><i class="glyphicon glyphicon-ok-sign"></i>Fácil y simple</li>
                    </ul>

                </div>
                <div class="col-md-6 student-grid">
                    <img src="/Recursos/Images/edificio.jpg" class="img-responsive img-rounded" alt="Image-2" />
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div align="center">
                    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/Recursos/Images/maps.png" />
                </div>
                <h4>Mira las instalaciones</h4>
                <br />
                <div align="left">
                    <ul class="grid-part">
                        <li><i class="glyphicon glyphicon-ok-sign"></i>Detalles de los edificios</li>
                        <li><i class="glyphicon glyphicon-ok-sign"></i>Tipo de edificio</li>
                        <li><i class="glyphicon glyphicon-ok-sign"></i>¿Qué hacen en ese edificio?</li>
                        <li><i class="glyphicon glyphicon-ok-sign"></i>¿Quién está en ese edificio?</li>
                        <li><i class="glyphicon glyphicon-ok-sign"></i>Fácil y simple</li>
                    </ul>
                </div>
                <%--<img src="../Recursos/Images/maps.png" />--%>
            </div>
            <div class="col-md-6">
                <div align="center">
                    <h4>Prueba nuestros mapas</h4>
                    <br />
                    <img src="../Recursos/Images/mapa.png" width="550" height="370" />
                </div>
            </div>
        </div>
    </div>
    <hr />
</asp:Content>