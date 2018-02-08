<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifySubject.aspx.cs" Inherits="subject_ModifySubject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Proyecto Andern</title>
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
                <li><a href="/subject/ListSubject.aspx">Lista de materias <i class="material-icons left">list</i></a></li>
                <li><a href="/subject/AddActivity.aspx">Registro de actividades <i class="material-icons left">schedule</i></a></li>
                <li  class="active"><a href="/subject/ModifySubject.aspx">Modificar Materia <i class="material-icons left">update</i></a></li>
            </ul>
            <ul class="side-nav" id="mobile-demo">
                <li><a href="/">Inicio <i class="material-icons">home</i></a></li>
                <li><a href="subject/AddSubject.aspx">Registro de materias <i class="material-icons">add</i></a></li>
                <li><a href="subject/ListSubject.aspx">Lista de materias <i class="material-icons">list</i></a></li>
                <li><a href="subject/AddActivity.aspx">Registro de actividades <i class="material-icons">schedule</i></a></li>
                <li  class="active"><a href="/subject/ModifySubject.aspx">Modificar Materia <i class="material-icons left">update</i></a></li>
            </ul>
        </div>
    </nav>
    <br />
    <div class="container">
        <div class="row">
            <form id="form1" runat="server">
                <div class="col l6 m8 s10 offset-l3 offset-m2 offset-s1">
                    <div class="row s12 center-align">
                        <blockquote> <h4>Modificar Materia.</h4> </blockquote>
                    </div>
                    <div class="row s12  red accent-4">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ForeColor="white"/>
                    </div>
                    <div class="row input-field">
                        <asp:ListBox ID="cmbCode" runat="server">
                            <asp:ListItem value="1" Selected="True">AAA222</asp:ListItem>
                        </asp:ListBox>
                        <label>Código de Materia</label>
                        <asp:RequiredFieldValidator  Display="None" ID="RequiredFieldValidator1" 
                            runat="server" 
                            ControlToValidate="cmbCode"
                            ErrorMessage="Escoga uno materia"></asp:RequiredFieldValidator>
                    </div>
                    <div class="row input-field">
                        <label for="txtName">Nombre de la materia</label>
                        <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                        <asp:RequiredFieldValidator  Display="None" ID="RequiredFieldValidator2" 
                            runat="server" 
                            ControlToValidate="txtName"
                            ErrorMessage="Ingrese un nombre"></asp:RequiredFieldValidator>
                    </div>
                    <div class="row input-field">
                        <label for="txtSemester">Nº Ciclo</label>
                        <asp:TextBox runat="server" ID="txtSemester" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator  Display="None" ID="RequiredFieldValidator3" 
                            runat="server" 
                            ControlToValidate="txtSemester"
                            ErrorMessage="Ingrese un ciclo"></asp:RequiredFieldValidator>
                    </div>
                    <div class="row input-field">
                        <label for="txtUV">Unidades Valorativas (UV)</label>
                        <asp:TextBox runat="server" ID="txtUV" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator  Display="None" ID="RequiredFieldValidator4" 
                            runat="server" 
                            ControlToValidate="txtUV"
                            ErrorMessage="Ingrese la cantidad de UV"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" 
                            runat="server" ErrorMessage="Según el tipo de materia las UV no son válidas" Display="None" Text="Según el tipo de materia las UV no son válidas"
                           OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="txtUV"></asp:CustomValidator>
                    </div>
                    <div class="row input-field">
                        <asp:ListBox ID="cmbPre" runat="server" multiple="" SelectionMode="Multiple">
                            <asp:ListItem value="1" Selected="True">Hola,</asp:ListItem>
                            <asp:ListItem value="2">Como</asp:ListItem>
                            <asp:ListItem value="3">Estas?</asp:ListItem>
                        </asp:ListBox>
                        <label>Prerrequisitos</label>
                        <asp:RequiredFieldValidator  Display="None" ID="RequiredFieldValidator5" 
                            runat="server" 
                            ControlToValidate="cmbPre"
                            ErrorMessage="Escoga uno o más prerrequisitos"></asp:RequiredFieldValidator>
                    </div>
                    <div class="row input-field">
                        <textarea runat="server" id="txtDescription" 
                            class="materialize-textarea">
                        </textarea>
                        <label for="txtDescription">Descripcion</label>
                        <asp:RequiredFieldValidator  Display="None" ID="RequiredFieldValidator6" 
                            runat="server" 
                            ControlToValidate="txtDescription"
                            ErrorMessage="Ingrese una descripción"></asp:RequiredFieldValidator>
                    </div>
                    <div class="row center-align">
                        <asp:CheckBox id="chkLab" runat="server" cheked="flase" Text="¿Materia de Laboratorio?"/>
                        <label for="filled-in-box"></label>
                    </div>
                    <div class="row center-align">
                        <asp:Button ID="btnSend" CssClass="waves-effect waves-light btn" runat="server"  Text="Registrar" />
                    </div>
                </div>
                
            </form>
        </div>
    </div>
</body>
</html>
