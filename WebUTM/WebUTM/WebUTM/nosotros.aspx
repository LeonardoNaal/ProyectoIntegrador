<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTM.Master" AutoEventWireup="true" CodeBehind="nosotros.aspx.cs" Inherits="WebUTM.WebUTM.nosotros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
      <div class="copy-section">
        <div class="container">
            <h3 class="text-center title">Nosotros</h3>
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
            <a href="#" class="btn btn-primary">Nosotros</a>
        </div>
        </div>
    </div>
    <br />
    <div class="about-w3">
        <div class="container">
            <div class="about-grids">
                <div class="col-md-6 about-grid">
                    <h4>La información en un mismo lugar</h4>
                    <p>
                        Tratamos de mantener toda la información en un mismo lugar para ti, conjuntamos todos los servicios de la institución
                                 para poder mostrarte de manera mas clara y sencilla con todos los eventos, actividades y demás que
                                 puedes encontrar en las diversas páginas de la Universidad
                    </p>
                    <ul class="grid-part">
                        <li><i class="glyphicon glyphicon-ok-sign"></i>Toda la información en un mismo lugar</li>
                        <li><i class="glyphicon glyphicon-ok-sign"></i>Eventos, actividades</li>
                        <li><i class="glyphicon glyphicon-ok-sign"></i>Publicaciones tuyas y de tus amigos</li>
                    </ul>
                </div>
                <div class="col-md-6">
                    <iframe width="560" height="315" src="https://www.youtube.com/embed/jo2DzuV8RxE" frameborder="0" allowfullscreen></iframe>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <div class="container">
        <h3 class="tittle">Nosotros</h3>
        <div class="row">
            <div class="col-md-6 what-grid">
                <div class="mask">
                    <img src="/Recursos/Images/mision.jpg" class="img-responsive zoom-img" width="480" height="280" />
                </div>
                <div class="what-bottom">
                    <h4>Misión</h4>
                    <p>Nuestra misión es lograr conjuntar la información en un mismo lugar; haciendo esto, podemos consultar datos desde un mismo sitio, además de gestionar desde el mismo sitio, cualquier publicación que se desee; hacer llegar la información a todas las personas que de alguna manera estén involucrados con la Universidad.</p>
                </div>
            </div>
            <div class="col-md-6 what-grid">
                <div class="what-bottom1">
                    <h4>Visión</h4>
                    <p>Nuestra visión es contar con un sitio unificado con todos los detalles, desde los mínimos hasta los mas grandes, de la Universidad, teniendo esto, el consumo de información por parte de las personas interesadas, se verá beneficiada en gran medida y llegará a todos.</p>
                </div>
                <div class="mask">
                    <img src="/Recursos/Images/mision1.jpg" class="img-responsive zoom-img img-rounded" width="480" height="280" />
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <h3 class="tittle">Objetivos</h3>
        <div class="row">
            <div class="col-md-6 statistics-grid">
                <ul class="grid-part">
                    <li><i class="glyphicon glyphicon-ok-sign"></i>Conjuntar toda la información de la Universidad</li>
                    <li><i class="glyphicon glyphicon-ok-sign"></i>Informar en el menor tiempo posible de eventos o actividades</li>
                    <li><i class="glyphicon glyphicon-ok-sign"></i>Digitalizar cualquier tipo de publicaciones de alumnos y/o profesores</li>
                </ul>
                <div class="statistics-w3">
                    <div class="container">
                        <div class="statistics-grids">
                            <div class="row">
                                <div class="col-md-3 statistics-grid">
                                    <div class="statistic">
                                        <h4>Avisos</h4>
                                        <h5>Comparte tus avisos</h5>
                                        <p>La manera más fácil para que todos vean un aviso que publiques .</p>
                                    </div>
                                </div>
                                <div class="col-md-3 statistics-grid">
                                    <div class="statistic">
                                        <h4>Eventos</h4>
                                        <h5>Participa</h5>
                                        <p>No te pierdas de actividades, navega por todas las que se encuentran disponibles</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div align="center" class="mask">
                    <img src="/Recursos/Images/valores.png" class="img-responsive zoom-img" width="380" height="140" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
