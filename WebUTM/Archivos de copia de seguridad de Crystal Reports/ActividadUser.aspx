<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTMLogIn.Master" AutoEventWireup="true" CodeBehind="ActividadUser.aspx.cs" Inherits="WebUTM.WebUTM2.ActividadUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
    <div class="copy-section">
        <div class="container">
            <h3>Actividades</h3>
        </div>
    </div>
    <style type="text/css">

    #Background
    {
        position: fixed; 
        top: 0px; 
        bottom: 0px; 
        left: 0px; 
        right: 0px; 
        overflow: hidden; 
        padding: 0; 
        margin: 0; 
        background-color: #F0F0F0; 
        filter: alpha(opacity=80); 
        opacity: 0.8; 
        z-index: 100000;
    }
        
    #Progress
    {
        position: fixed;
        top: 40%; 
        left: 40%; 
        height:20%; 
        width:20%; 
        z-index: 100001;  
        background-color: #FFFFFF; 
        border:1px solid Gray; 
        background-image: url('../Recursos/Images/loading.gif'); 
        background-repeat: no-repeat; 
        background-position:center;
    }

    </style>
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
    <br />
    <br />
    <div class="container">
        <div class="row">
          <div class="col-md-3">
                <div class="alert alert-dismissable alert-info">
                    <h4 class="text-center"><span class="glyphicon glyphicon-star"></span> ¿Te interesa una actividad?</h4>
                </div>
                <div class="alert alert-dismissable alert-info">
                    <h4>Haciendo click en el botón le haces saber a las personas que asistirás</h4>
                </div>
                <div class="thumbnail">
                    <div class="caption">
                        <h4 class="text-center">¡No te pierdas de ninguna actividad!</h4>
                        <div align="center">
                        <img src="../Recursos/Images/Android-Logo.png" width="85" height="80" />
                        </div>
                        <h4>Usa la app para estar siempre al día</h4>
                    </div>
                </div>
                <div class="alert alert-dismissable alert-warning">
                   <h4 class="text-center">Personas que asistirán</h4>
                    <br /> 
                    <div align="center">
                    <img src="../Recursos/Images/groups.png" width="95" height="90" />
                    </div>
                    <br />
                    <h4 class="text-center">¿Están tus amigos?</h4>
                </div>
                <div class="thumbnail">
                    <div class="caption">
                        <h4 class="text-center">Revisa las fechas</h4>
                        <div align="center">
                        <img src="../Recursos/Images/horario.png" width="90" height="90" />
                        </div>
                        <h4 class="text-center">Consulta las fechas, no te las pierdas</h4>
                    </div>
                </div>
                <div class="alert alert-dismissable alert-info">
                   <h4 class="text-center">¿Tienes algo que decir?</h4>
                    <br />
                    <div align="center">
                    <img src="../Recursos/Images/publicar.png" width="85" height="80" />
                        <br />
                        <br />
                        <a href="#" class="btn btn-warning">Publicar</a>
                    </div>
                    
                </div>
            </div>

            <div class="col-md-9">
                <br />
                <h3 class="text-center">Actividades</h3>
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <%--A partir de aquí va el DataList--%>
                <asp:DataList ID="DataList1" runat="server" DataKeyField="IDActividad" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <div class="thumbnail">
                            <div class="caption">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3 class="text-center"><span class="glyphicon glyphicon-calendar"></span><asp:Label ID="Label4" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label></h3>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="alert alert-dismissable alert-info">
                                            <h4 class="text-center" ><span class="glyphicon glyphicon-time"></span> Empieza:</h4>
                                            <div align="center">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("FechaIni") %>' Font-Bold="true"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="alert alert-dismissable alert-danger">
                                            <h4 class="text-center"><span class="glyphicon glyphicon-time"></span> Termina:</h4>
                                            <div align="center">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("FechaFin") %>' Font-Bold="true"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Descripcion") %>' Font-Size="X-Large" Font-Names="Cagliostro"></asp:Label>
                                    </div>
                                </div>
                                <div align="right">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Button id="Button1" runat="server"  CssClass="btn btn-warning" CommandName="Asistire" Text="Asistiré" OnClick="Button1_Click" />
                                         </ContentTemplate>
                                    </asp:UpdatePanel>
                                     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                 <ProgressTemplate>
                                                    <div id="Background"></div>
                                                        <div id="Progress">
                                                    <h6> <p style="text-align:center"> <b>Espere por favor... <br /></b> </p> </h6>
                                                    </div>
                                                  </ProgressTemplate>
                                      </asp:UpdateProgress>
                                <br />
                                </div>
                                <div align="left">
                                    <asp:Button ID="Button2" runat="server" CommandName="VerAsistencia" Text="Personas que asistirán" OnClick="Button2_Click" CssClass="btn btn-info btn-sm" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div class="row">
                    <div class="col-md-12">
                        <div align="center">
                            <asp:Button ID="btnfirst" runat="server" CssClass="btn btn-warning" Font-Bold="true" Text="<<" Height="31px" Width="43px" OnClick="btnfirst_Click" />
                            <asp:Button ID="btnprevious" CssClass="btn btn-warning" runat="server" Font-Bold="true" Height="31px" OnClick="btnprevious_Click" Text="&lt;" Width="43px" />
                            <asp:Button ID="btnnext" CssClass="btn btn-warning" runat="server" Font-Bold="true" Height="31px" OnClick="btnnext_Click" Text="&gt;" Width="43px" />
                            <asp:Button ID="btnlast" CssClass="btn btn-warning" runat="server" Font-Bold="true" Height="31px" OnClick="btnlast_Click" Text="&gt;&gt;" Width="43px" />
                            <br />
                        </div>
                    </div>
                    <br />
                </div>
                <hr />
                 </div>
            <div class="modal fade" id="mymodal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                        ×</button>
                                                    <h4 class="modal-title" id="myModalLabel">Personas que asistirán
                                                    </h4>
                                                </div>
                                                <div class="modal-body">
                                                    <asp:Repeater ID="Repeater1" runat="server">
                                                        <ItemTemplate>
                                                            -<b><asp:Label ID="Label6" runat="server" Text='<%# Eval("Nombres ") %>'> &nbsp; </asp:Label></b>   <b><asp:Label ID="Label5" runat="server" Text='<%# Eval("ApePat") %>'></asp:Label></b>
                                                          <hr />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                 
                                                </div>
                                                <div class="modal-footer">
                                                    
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                                        Cerrar
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
           
    </div>
        </div>
</asp:Content>
