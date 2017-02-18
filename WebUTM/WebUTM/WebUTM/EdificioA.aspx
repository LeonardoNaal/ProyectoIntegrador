<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTM.Master" AutoEventWireup="true" CodeBehind="EdificioA.aspx.cs" Inherits="WebUTM.WebUTM.EdificioA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
    <div class="copy-section">
        <div class="container">
            <h3>Edificio A</h3>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div class="container jumbotron well">
        <div class="row">
            <div class="col-md-3">
                <h3 class="text-center">Edificio A</h3>
                <img src="../Recursos/Images/edificioA.jpg" width="240" height="200" />
                <h4>Centro de información</h4>
                <br />
                <h4>Tipo: Biblioteca</h4>
                <br />
                <h4>Sala Interactiva | TIC</h4>
                <br />
                <h4>Aula Magna</h4>
                <br />
                <h4>Abierto de 8:00am-8:00pm</h4>
                <br /> 
            </div>
            <div class="col-md-9">
                <img src="../Recursos/Images/edificioAcover.png" width="900" class="img-thumbnail" />
                <br />
                <br />
                <h4>Universidad Tecnológica Metropolitana | Centro de Información</h4>
                <hr />
                <div class="row">
                    <div class="col-md-6">
                        <h4>Estás aquí</h4>
                        <br />
                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d675.0981030096526!2d-89.61737458483654!3d20.938585105283714!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x0!2zMjDCsDU2JzE5LjEiTiA4OcKwMzcnMDAuOSJX!5e1!3m2!1ses-419!2smx!4v1479089605182" width="400" height="300" frameborder="0" style="border: 0" allowfullscreen></iframe>
                    </div>
                    <div class="col-md-6">
                        <p class="text-justify">El Centro de Información de la Universidad Tecnológica Metropolitana cuenta con una gran calidad para el alumnado, ya que, entre sus instalaciones se encuentran mobiliarios aptos para el desempeño acdémico de calidad, así como salas interactivas y magnas que frecuentemente se usan para la exposición de proyectos y presentación de productos o servicios de la Universidad</p>
                </div>
            </div>
        </div>
        <hr />
    </div>
    </div>
</asp:Content>
