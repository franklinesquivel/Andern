<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSubject.aspx.cs" Inherits="subject_AddSubject" %>

<%@ Register Src="~/Menu.ascx" TagPrefix="uc" TagName="Menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Proyecto Ändern</title>
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
    <div class="container">
        <div class="row">
            <form id="form1" runat="server">
                <div class="col l6 m8 s10 offset-l3 offset-m2 offset-s1">
                    <div class="row s12 center-align">
                        <blockquote> <h4>Registrar Materia.</h4> </blockquote>
                    </div>
                    <div class="row s12  red accent-4">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ForeColor="white"/>
                    </div>
                    <div class="row input-field">
                        <label for="txtCode">Código de la materia</label>
                        <asp:TextBox runat="server" ID="txtCode"></asp:TextBox>
                        <asp:RequiredFieldValidator  Display="None" ID="RequiredFieldValidator1" 
                            runat="server" 
                            ControlToValidate="txtCode"
                            ErrorMessage="Ingrese un código"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ErrorMessage="El formato del código ingresado es incorrecto" ControlToValidate="txtCode"
                            ValidationExpression="^([A-Z]|[a-z]){3}[0-9]{3}$" Display="None">
                        </asp:RegularExpressionValidator>
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
                            OnServerValidate="CustomValidator1_ServerValidate1" ControlToValidate="txtUV"></asp:CustomValidator>
                    </div>
                    <div class="row input-field">
                        <asp:ListBox ID="cmbPre" runat="server">
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
                        <asp:Button ID="btnSend" OnClick="btnSend_Click" CssClass="waves-effect waves-light btn" runat="server"  Text="Registrar" />
                    </div>
                </div>
                
            </form>
        </div>
        <div class="row" id="result" runat="server">   

            </div>
    </div>
</body>
</html>
