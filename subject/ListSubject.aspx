<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListSubject.aspx.cs" Inherits="subject_ListSubject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Proyecto Ändern - Listado de Materias</title>
    <link href="/css/materialize.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width" initial-scale="1.0" />

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <script src="/js/jquery.min.js"></script>
    <script src="/js/materialize.min.js"></script>
    <script src="/js/init.js"></script>
</head>
<body class="grey lighten-4">

    <nav>
        <div class="nav-wrapper deep-purple darken-1">
            <a href="#!" class="brand-logo">Logo</a>
            <a href="#" data-activates="mobile-demo" class="button-collapse"><i class="material-icons">menu</i></a>
            <ul class="right hide-on-med-and-down">
                <li><a href="/">Inicio <i class="material-icons left">home</i></a></li>
                <li><a href="/subject/AddSubject.aspx">Registro de materias <i class="material-icons left">add</i></a></li>
                <li  class="active"><a href="/subject/ListSubject.aspx">Lista de materias <i class="material-icons left">list</i></a></li>
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
    
    <br />
    <h3 class="center deep-purple-text text-lighten-2">Listado de Materias</h3>


</body>
</html>
