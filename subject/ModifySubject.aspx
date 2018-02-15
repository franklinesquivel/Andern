<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifySubject.aspx.cs" Inherits="subject_ModifySubject" %>

<%@ Register Src="~/Menu.ascx" TagPrefix="uc" TagName="Menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Proyecto Andern</title>
    <link href="/css/materialize.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width" initial-scale="1.0" />
    <link rel="shortcut icon" type="image/png" href="/img/favicon.ico"/>

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <script src="/js/jquery.min.js"></script>
    <script src="/js/materialize.min.js"></script>
    <script src="/js/init.js"></script>
</head>
<body class="grey lighten-4">
    
    <uc:Menu runat="server" ID="Menu" />

    <br />
    <div class="container">
        <div class="row">
            <form id="form1" runat="server">
                <div class="col l6 m8 s10 offset-l3 offset-m2 offset-s1">
                    <div class="row s12 center-align">
                        <h3 class="center deep-purple-text text-lighten-2">Modificar materia</h3>
                    </div>
                    <div class="row input-field">
                        <label for="txtName">Nombre de la materia</label>
                        <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                            runat="server" 
                            CssClass="error-tag"
                            Display="Dynamic"
                            ControlToValidate="txtName"
                            ErrorMessage="Ingrese un nombre"></asp:RequiredFieldValidator>
                    </div>
                    <div class="row input-field">
                        <label for="txtSemester">Nº Ciclo</label>
                        <asp:TextBox runat="server" ID="txtSemester" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" 
                            runat="server" 
                            CssClass="error-tag"
                            Display="Dynamic"
                            ControlToValidate="txtSemester"
                            ErrorMessage="Ingrese un ciclo"></asp:RequiredFieldValidator>
                    </div>
                    <div class="row input-field">
                        <label for="txtUV">Unidades Valorativas (UV)</label>
                        <asp:TextBox runat="server" ID="txtUV" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                            runat="server" 
                            CssClass="error-tag"
                            Display="Dynamic"
                            ControlToValidate="txtUV"
                            ErrorMessage="Ingrese la cantidad de UV"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" 
                            runat="server" ErrorMessage="Según el tipo de materia las UV no son válidas" CssClass="error-tag"
                            Display="Dynamic" Text="Según el tipo de materia las UV no son válidas"
                           OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="txtUV"></asp:CustomValidator>
                    </div>
                    <div class="row input-field">
                        <asp:ListBox ID="cmbPre" runat="server">
                            
                        </asp:ListBox>
                        <label>Prerrequisitos</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                            runat="server" 
                            CssClass="error-tag"
                            Display="Dynamic"
                            ControlToValidate="cmbPre"
                            ErrorMessage="Escoga uno o más prerrequisitos"></asp:RequiredFieldValidator>
                    </div>
                    <div class="row input-field">
                        <textarea runat="server" id="txtDescription" 
                            class="materialize-textarea">
                        </textarea>
                        <label for="txtDescription">Descripcion</label>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidator6" 
                            runat="server" 
                            CssClass="error-tag"
                            Display="Dynamic"
                            ControlToValidate="txtDescription"
                            ErrorMessage="Ingrese una descripción"></asp:RequiredFieldValidator>
                    </div>
                    <div class="row center-align">
                        <asp:CheckBox id="chkLab" runat="server" cheked="flase" Text="¿Materia de Laboratorio?"/>
                        <label for="filled-in-box"></label>
                    </div>
                    <div class="row center-align">
                        <asp:Button ID="btnSend" onclick="btnSend_Click" CssClass="waves-effect waves-light btn" runat="server"  Text="Registrar" />
                    </div>
                </div>
            </form>
        </div>
        <div runat="server" class="result" id="result">

        </div>
    </div>
</body>
</html>
