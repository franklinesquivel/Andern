<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddActivity.aspx.cs" Inherits="subject_AddActivity" %>

<%@ Register Src="~/Menu.ascx" TagPrefix="uc" TagName="Menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Proyecto Ändern</title>
    <link href="/css/materialize.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width" initial-scale="1.0" />

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <script src="/js/jquery.min.js"></script>
    <script src="/js/materialize.min.js"></script>
    <script src="/js/init.js"></script>
</head>
<body class="grey lighten-4">

    <uc:Menu ActualPage="4" runat="server" ID="Menu" />

    <br />
    <h3 class="center deep-purple-text text-lighten-2">Registrar Actividad de una Materia</h3>

    <div class="container">
        <form class="row" id="frmData" runat="server">

            <asp:HiddenField ID="hfPercentage" runat="server"/>
            <asp:HiddenField ID="hfSubjectType" runat="server"/>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:DropDownList ID="ddlSubject" runat="server" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged">
                    <asp:ListItem value="0" disabled="true" selected="True">[Materia]</asp:ListItem>
                </asp:DropDownList>
                <asp:Label AssociatedControlID="ddlSubject" Text="Selecciona una materia" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="customDdlValue" runat="server"
                    InitialValue = "0"
                    ControlToValidate="ddlSubject"
                    ErrorMessage="Debes seleccionar una materia!"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:Label Text="La actividad será asignada al grupo de: " runat="server"></asp:Label><br />
                <asp:RadioButton ID="rdbT" Text="Teoría" Value="T" GroupName="subjectType" runat="server" /><br />
                <asp:RadioButton ID="rdbL" Text="Laboratorio" Value="L" GroupName="subjectType" runat="server" />
                <br /><br />
            </div>
            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtName" Text="Nombre de la actividad" runat="server"></asp:Label>
                <asp:RequiredFieldValidator
                    CssClass="error-tag"
                    ErrorMessage="Debes ingresar un valor"
                    Display="Dynamic"
                    ControlToValidate="txtName"
                    runat="server">
                </asp:RequiredFieldValidator>
            </div>

            <div class="input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <asp:TextBox ID="txtPercentage" TextMode="Number" runat="server"></asp:TextBox>
                <asp:Label AssociatedControlID="txtPercentage" Text="Porcentaje de la actividad" runat="server"></asp:Label>
                <asp:RequiredFieldValidator
                    CssClass="error-tag"
                    ErrorMessage="Debes ingresar un valor"
                    Display="Dynamic"
                    ControlToValidate="txtPercentage"
                    runat="server">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator ID="customPositive" runat="server"
                    OnServerValidate="positiveValidate"
                    ControlToValidate="txtPercentage"
                    Display="Dynamic"
                    ErrorMessage="Ingresa un porcentaje válido!.">
                </asp:CustomValidator>
                <asp:CustomValidator ID="customPercentage" runat="server"
                    OnServerValidate="percentageValidate"
                    ControlToValidate="txtPercentage"
                    Display="Dynamic"
                    ErrorMessage="Ingresa una cantidad que no pase el 100%.">
                </asp:CustomValidator>
            </div>

            <div class="file-field input-field col s10 m6 l6 offset-s1 offset-m3 offset-l3">
                <div class="btn waves-effect waves-light">
                    <span>Rúbrica<i class="material-icons right">attach_file</i></span>
                    <asp:FileUpload id="fucFile" runat="server" />
                </div>
                <div class="file-path-wrapper">
                    <input class="file-path" type="text" />
                </div>
                <asp:RequiredFieldValidator
                    CssClass="error-tag"
                    ErrorMessage="Debes ingresar un archivo"
                    Display="Dynamic"
                    ControlToValidate="fucFile"
                    runat="server">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator ID="customFileType" runat="server"
                    OnServerValidate="fileTypeValidate"
                    ControlToValidate="fucFile"
                    Display="Dynamic"
                    ErrorMessage="Debes ingresar un archivo válido! [.pdf].">
                </asp:CustomValidator>
            </div>
            
            <div class="input-field col s12">
                <center>
                    <asp:button text="Registrar" ID="btnRegisterData" CssClass="btn waves-effect waves-light" OnClick="btnRegisterData_Click" runat="server" />
                </center>
            </div>
        </form>
    </div>
</body>
</html>
