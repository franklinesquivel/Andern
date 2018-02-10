<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListSubject.aspx.cs" Inherits="subject_ListSubject" %>

<%@ Register Src="~/Menu.ascx" TagPrefix="uc" TagName="Menu" %>


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

    <uc:Menu ActualPage="2" runat="server" ID="Menu" />
    
    <br />
    <h3 class="center deep-purple-text text-lighten-2">Listado de Materias</h3>
    <br />
    <main id="mainCont" class="" runat="server">
        <form id="frmData" class="row" runat="server">

        </form>
    </main>

</body>
</html>
