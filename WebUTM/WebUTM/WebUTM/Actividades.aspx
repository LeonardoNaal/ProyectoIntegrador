<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/WebUTM.Master" AutoEventWireup="true" CodeBehind="Actividades.aspx.cs" Inherits="WebUTM.WebUTM.Actividades" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="server">
    <div class="copy-section">
        <div class="container">
            <h3>Actividades</h3>
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
            <a href="#" class="btn btn-primary">Actividades</a>
        </div>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <h4 class="text-center">Hoy es:</h4>
                <br />
                <div align="center">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" CellPadding="4" DayNameFormat="Shortest">
                        <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#00927F" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#00927F" ForeColor="White" Font-Bold="True" />
                        <SelectorStyle BackColor="#00927F" />
                        <TitleStyle BackColor="#00927F" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#00927F" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#00927F" />
                    </asp:Calendar>
                </div>
                <hr />
                <div class="media">
                    <a href="#" class="pull-left">
                        <img alt="Bootstrap Media Preview" src="../Recursos/Images/calendario.png" class="media-object" width="64" height="64" /></a>
                    <div class="media-body">
                        Una actividad es publicada por profesores de cada área para reunir a las personas, son una forma de organizar eventos.
                    </div>
                </div>
                <hr />
                <div class="media">
                    <a href="#" class="pull-left">
                        <img alt="Bootstrap Media Preview" src="../Recursos/Images/Android-Logo.png" class="media-object" width="60" height="60" /></a>
                    <div class="media-body">
                        No olvides que puedes seguir viendo estas actividades en tu celular.
                    </div>
                </div>
                <br />
                <h3 class="text-center">Sitios:</h3>
                <br />
                <div class="panel-group" id="panel-861972">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <a class="panel-title" data-toggle="collapse" data-parent="#panel-861972" href="#panel-element-66576">Edificios administrativos</a>
                        </div>
                        <div id="panel-element-66576" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <a href="edificioA.aspx">Edificio A</a>
                                <br />
                                <a href="edificioB.aspx">Edificio B</a>
                                <br />
                                <a href="edificioB.aspx">Edificio Q</a>
                                <br />
                                <a href="edificioB.aspx">Edificio K</a>
                                <br />
                                <a href="edificioB.aspx">Edificio R</a>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <a class="panel-title" data-toggle="collapse" data-parent="#panel-861972" href="#panel-element-181111">Edificios académicos</a>
                        </div>
                        <div id="panel-element-181111" class="panel-collapse collapse">
                            <div class="panel-body">
                                <a href="edificioA.aspx">Edificio C</a>
                                <br />
                                <a href="edificioB.aspx">Edificio G</a>
                                <br />
                                <a href="edificioB.aspx">Edificio H</a>
                                <br />
                                <a href="edificioB.aspx">Edificio M</a>
                                <br />
                                <a href="edificioB.aspx">Edificio T</a>
                                <br />
                                <a href="edificioB.aspx">Edificio N</a>
                                <br />
                                <a href="edificioB.aspx">Edificio F</a>
                                <br />
                                <a href="edificioB.aspx">Edificio J</a>
                                <br />
                                <a href="edificioB.aspx">Edificio I</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-9">
                <br />
                <br />
                    <%--A partir de aquí va el DataList--%>
                    <asp:DataList ID="DataList1" runat="server" DataKeyField="IDActividad" OnItemCommand="DataList1_ItemCommand">
                        <ItemTemplate>
                            <div class="thumbnail">
                                <div class="caption">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <h3 class="text-center"><span class="glyphicon glyphicon-calendar"></span>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label></h3>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-1"></div>
                                        <div class="col-md-5">
                                            <div class="alert alert-dismissable alert-info">
                                                <h4 class="text-center"><span class="glyphicon glyphicon-time"></span> Empieza:</h4>
                                                <div align="center">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("FechaIni") %>' Font-Bold="true"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="alert alert-dismissable alert-danger">
                                                <h4 class="text-center"><span class="glyphicon glyphicon-time"></span> Termina:</h4>
                                                <div align="center">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("FechaFin") %>' Font-Bold="true"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                    </div>
                                        </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Descripcion") %>' Font-Size="Large" Font-Names="Cagliostro"></asp:Label>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-md-12">
                                        <div align="right">
                                            <asp:Button ID="Button2" runat="server" Text="Personas que asistiran" data-toggle="modal" OnClick="Button2_Click" CommandName="VerAsistencia" CssClass="btn btn-warning" />
                                        </div>
                                        <%--                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Recursos/Images/tilde.png"/> Asistiré--%>
                                        <div align="right">
                                            <a href="Iniciar.aspx">Ingresa para registrar tu asistencia</a>
                                        </div>
                                        </div>
                                    </div>
                                    </div>
                                </div>
                            </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                     <div class="row">
                     <div class="col-md-12">
                         <div align="center">
                                                <asp:Button ID="btnfirst" runat="server" CssClass="btn btn-warning" Font-Bold="true" Text="<<" Height="31px" Width="43px" OnClick="btnfirst_Click" />
                                                <asp:Button ID="btnprevious" CssClass="btn btn-warning" runat="server" Font-Bold="true" Height="31px" OnClick="btnprevious_Click" Text="&lt;" Width="43px" />
                                                <asp:Button ID="btnnext" CssClass="btn btn-warning" runat="server" Font-Bold="true" Height="31px" OnClick="btnnext_Click" Text="&gt;" Width="43px" />
                                                <asp:Button ID="btnlast" CssClass="btn btn-warning" runat="server" Font-Bold="true" Height="31px" OnClick="btnlast_Click" Text="&gt;&gt;" Width="43px" />
                             </div>
                    </div>
                </div>
                <br/>
            </div>
            <div class="col-md-1"></div>
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
                                   <b>-</b><b><asp:Label ID="Label5" runat="server" Text='<%# Eval("Nombres") %>'></asp:Label></b>  <b><asp:Label ID="Label6" runat="server" Text='<%# Eval("ApePat") %>'></asp:Label></b>
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


