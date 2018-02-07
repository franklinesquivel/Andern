<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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

    <nav>
        <div class="nav-wrapper deep-purple darken-1">
            <a href="#!" class="brand-logo">Logo</a>
            <a href="#" data-activates="mobile-demo" class="button-collapse"><i class="material-icons">menu</i></a>
            <ul class="right hide-on-med-and-down">
                <li class="active"><a href="/">Inicio <i class="material-icons left">home</i></a></li>
                <li><a href="/subject/AddSubject.aspx">Registro de materias <i class="material-icons left">add</i></a></li>
                <li><a href="/subject/ListSubject.aspx">Lista de materias <i class="material-icons left">list</i></a></li>
                <li><a href="/subject/AddActivity.aspx">Registro de actividades <i class="material-icons left">schedule</i></a></li>
            </ul>
            <ul class="side-nav" id="mobile-demo">
                <li class="active"><a href="/">Inicio <i class="material-icons">home</i></a></li>
                <li><a href="subject/AddSubject.aspx">Registro de materias <i class="material-icons">add</i></a></li>
                <li><a href="subject/ListSubject.aspx">Lista de materias <i class="material-icons">list</i></a></li>
                <li><a href="subject/AddActivity.aspx">Registro de actividades <i class="material-icons">schedule</i></a></li>
            </ul>
        </div>
    </nav>
    
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

</body>
</html>
