<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/Menu.ascx" TagPrefix="uc" TagName="Menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Proyecto Andern</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width" initial-scale="1.0" />

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <script src="js/jquery.min.js"></script>
    <script src="js/materialize.min.js"></script>
    <script src="js/init.js"></script>
</head>
<body class="grey lighten-4">

    <uc:Menu ActualPage="1" runat="server" ID="Menu" />
    
    <div class="slider">
        <ul class="slides">
            <li>
                <img src="img/default/1.jpg" />
                <!-- random image -->
                <div class="caption center-align">
                    <h3>This is our big Tagline!</h3>
                    <h5 class="light grey-text text-lighten-3">Here's our small slogan.</h5>
                </div>
            </li>
            <li>
                <img src="img/default/2.jpg"/>
                <!-- random image -->
                <div class="caption left-align">
                    <h3>Left Aligned Caption</h3>
                    <h5 class="light grey-text text-lighten-3">Here's our small slogan.</h5>
                </div>
            </li>
            <li>
                <img src="img/default/4.jpg"/>
                <!-- random image -->
                <div class="caption right-align">
                    <h3>Right Aligned Caption</h3>
                    <h5 class="light grey-text text-lighten-3">Here's our small slogan.</h5>
                </div>
            </li>
            <%--<li>
                <img src="img/default/5.jpg"/>
                <!-- random image -->
                <div class="caption center-align">
                    <h3>This is our big Tagline!</h3>
                    <h5 class="light grey-text text-lighten-3">Here's our small slogan.</h5>
                </div>
            </li>--%>
        </ul>
  </div>

   <main class="container">
       <div class="row">
           <div class="col l10 offset-l1 m10 offset-m1 s10 offset-s1">
               <h3 class="center deep-purple-text text-lighten-2">¿PILET?</h3>
               <p class="flow-text ">El Programa de Integración Lineal de Estudios Técnicos (PILET) responde a las necesidades de mayor articulación entre la educación media técnica, los estudios técnicos superiores y la educación superior de ingeniería. Se pretende con él, desarrollar una modalidad de currículum continuo entre estos niveles para garantizar la calidad profesional y competitividad de los estudiantes.</p>
           </div>
           <div class="col l10 offset-l1 m10 offset-m1 s10 offset-s1">
               <h3 class="center deep-purple-text text-lighten-2">Cambio de PENSUM</h3>
               <p class="flow-text ">Con el plan 2015 muchos cambios sucediero. De objetivos a competencias, de escoger una rama (Programación o Redes) a ser una sola. Ante tal problemática nace Andern, un sistema donde se puede crear el nuevo PENSUM.</p>
           </div>
       </div>
   </main>
</body>
</html>
