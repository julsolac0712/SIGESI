<%@ Page Title="Inicio" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Main._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">   
        <h2><asp:Literal ID="ltl_tituloPrincipal" runat="server" Text="SISTEMA ÚNICO DE GESTIÓN INSTITUCION (SUGI 2.0)"></asp:Literal></h2>
        <p class="lead">El Sistema Único de Gestión Institucional (SUGI) es una herramienta para gestionar los planes estratégicos, tácticos y operativos de todos los equipos de trabajo del IICA, así como los resultados y productos de las iniciativas de cooperación técnica. Es un sistema único de gestión que, vinculado a los sistemas financieros, de proyectos y de servicios existentes permiten fortalecer el accionar institucional y ubicar al Instituto como un referente de la cooperación internacional del Siglo XXI.</p>
    </div>
    <br />

    <div class="row margin-30">
        <div class="col-md-3">
            <p>
                <a class="boton4 btn-primary" href="pages\administracion\Indicadores.aspx"><span class="glyphicon glyphicon-king label-espacio">
                </span>Planeación Estratégica</a>
            </p>
        </div>
        <div class="col-md-3">
            <p>
                <a class="boton4 btn-success" href="http://sugi.iica.int/pages/PLAN/Default.aspx"><span class="glyphicon glyphicon-calendar label-espacio">
                </span>Programación Anual</a>
            </p>
        </div>
        <div class="col-md-3">
            <p>
                <a class="boton4 btn-danger" href="http://sugi2.iica.int/monitoreo/pages/monitoreo/PanelFuncionario?Lang=es&User=2802&per=24"><span class="glyphicon glyphicon-blackboard label-espacio">
                </span>Monitoreo Institucional</a>
            </p>
        </div>
        <div class="col-md-3">
            <p>
                <a class="boton4 btn-warning" href="http://sugi2.iica.int/Evaluacion/pages/Evaluacion/PanelEvaluacion?Lang=es&User=2802&per=24"><span class="glyphicon glyphicon-th-list label-espacio">
                </span>Evaluación Institucional</a>
            </p>
        </div>
    </div>
  

</asp:Content>
