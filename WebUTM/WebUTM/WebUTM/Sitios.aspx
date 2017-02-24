<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTM.Master" AutoEventWireup="true" CodeBehind="Sitios.aspx.cs" Inherits="WebUTM.WebUTM.Sitios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
    <div class="copy-section">
        <div class="container">
            <h3 class="tittle2">Sitios</h3>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="container">
            <br />
        <h4>Estás en:</h4>
            <br />
        <div class="btn-group btn-breadcrumb">
            <a href="index.aspx" class="btn btn-primary"><i class="glyphicon glyphicon-home"></i></a>
            <a href="#" class="btn btn-primary">Sitios</a>
        </div>
        </div>
    </div>
    <br />
    <h3 class="text-center">Sitios</h3>
    <map name="mimapa">
        <area shape="rect" coords="222,415,300,470" href="edificioB.aspx" alt="Hola" />
        <area shape="rect" coords="204,509,279,586" href="edificioA.aspx" alt="edificioA" />
        <area shape="rect" coords="159,335,305,400" href="edificioC.aspx" alt="edificioC" />
        <area shape="rect" coords="333,252,469,302" href="edificioG.aspx" alt="edificioG" />
        <area shape="rect" coords="254,172,383,230" href="#" alt="edificioH" />
        <area shape="rect" coords="328,105,455,151" href="#" alt="edificioN" />
        <area shape="rect" coords="466,161,600,200" href="#" alt="edificioM" />
        <area shape="rect" coords="634,94,756,146" href="#" alt="edificoT" />
        <area shape="rect" coords="533,251,620,340" href="#" alt="edificioK" />
        <area shape="rect" coords="380,411,494,469" href="edificioF.aspx" alt="edificioF" />
        <area shape="rect" coords="504,411,628,469" href="edificioJ.aspx" alt="edificioJ" />
        <area shape="rect" coords="647,334,720,462" href="#" alt="edificioR" />
        <area shape="rect" coords="407,511,488,565" href="#" alt="edificioE" />
        <area shape="rect" coords="527,504,627,560" href="#" alt="edificioI" />
        <area shape="rect" coords="629,480,687,525" href="#" alt="edificioQ" />
    </map>
    <br />
    <br />
    <div id="sliderFrame">
        <div id="slider">
            <a href="http://www.menucool.com/jquery-slider" target="_blank">
                <img src="../Recursos/Images/sliderp1.jpg" />
            </a>
            <a class="lazyImage" href="../Recursos/Images/sliderp2.jpg" >Pure JavaScript</a>
            <a href="http://www.menucool.com/javascript-image-slider"><b data-src="../Recursos/Images/sliderp3.jpg">Image Slider</b></a>
            <a class="lazyImage" href="../Recursos/Images/sliderp4.jpg" title="">Obtén información específica de cada sitio</a>
        </div>
        <!--thumbnails-->
        <div id="thumbs">
            <div class="thumb">
                <div class="frame">
                    <img src="../Recursos/Images/thumbp1.jpg" /></div>
                <div class="thumb-content">
                    <p>Edificios académicos</p>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div class="thumb">
                <div class="frame">
                    <img src="../Recursos/Images/thump2.jpg" /></div>
                <div class="thumb-content">
                    <p>Información de cada uno</p>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div class="thumb">
                <div class="frame">
                    <img src="../Recursos/Images/thumbp3.jpg" /></div>
                <div class="thumb-content">
                    <p>¿Qué hacen en este edificio?</p>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div class="thumb">
                <div class="frame">
                    <img src="../Recursos/Images/thumbp4.jpg" /></div>
                <div class="thumb-content">
                    <p>Ubica tus aulas</p>
                </div>
                <div style="clear: both;"></div>
            </div>
        </div>
        <!--clear above float:left elements. It is required if above #slider is styled as float:left. -->
        <div style="clear: both; height: 0;"></div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="thumbnail">
                    <img src="../Recursos/Images/calendario.png" width="140" height="140" class="zoom-img" />
                    <div class="caption">
                        <h4 class="text-center">Descubre lo que está pasando en la Universidad, visita las publicaciones
                        </h4>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="thumbnail">
                    <img src="../Recursos/Images/horario.png" width="140" height="140" class="zoom-img" />
                    <div class="caption">
                        <h4 class="text-center">Entérate de las actividades que se celebran en la Universidad
                        </h4>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="thumbnail">
                    <img src="../Recursos/Images/maps.png" width="140" height="140" class="zoom-img" />
                    <div class="caption">
                        <h4 class="text-center">Ubica tu aula o el edificio al que quieras ir en el mapa interactivo
                        </h4>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="carousel slide kb_elastic animate_text kb_wrapper" id="carousel-162023" data-ride="carousel" data-interval="6000" data-pause="hover">
        <div class="carousel-inner">
            <div class="item active">
                <img src="../Recursos/Images/bannere.png" class="img-responsive zoom-img" />
                <div class="carousel-caption kb_caption">
                    <h3 data-animation="animated flipInX">
                        Visita cada sitio
                    </h3>
                    <h4 data-animation="animated flipInX">
                        Obtén información específica de cada uno
                    </h4>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="mapa_imagen">
        <h3 class="text-center">Navega por el mapa | Haz clic sobre el edificio que desees</h3>
        <div align="center">
            <img src="../Recursos/Images/mapa.png" width="960" height="620" usemap="#mimapa" />
        </div>
    </div>
    <br />
</asp:Content>
