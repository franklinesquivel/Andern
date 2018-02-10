<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Menu" %>

<script runat="server">
    private int actualPage;
    public int ActualPage
    {
        get
        {
            return actualPage;
        }
        set
        {
            actualPage = value;
        }
    }

    protected void Page_Load(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            switch (actualPage)
            {
                case 1:
                    liMenu.Attributes.Add("class", "active");
                    break;
                case 2:
                    liSubject.Attributes.Add("class", "active");
                    break;
                case 4:
                    liAddActivity.Attributes.Add("class", "active");
                    break;
            }
        }
    }
</script>

<ul id="dpdSubject" class="dropdown-content">
    <li><a href="/subject/AddSubject.aspx">Registrar <i class="material-icons left">add</i></a></li>
    <li><a href="/subject/ListSubject.aspx">Listar <i class="material-icons left">remove_red_eye</i></a></li>
    <li><a href="/subject/UpdateSubject.aspx">Modificar <i class="material-icons left">edit</i></a></li>
</ul>
<nav>
    <div class="nav-wrapper deep-purple darken-1">
        <a href="#!" class="brand-logo">Logo</a>
        <a href="#" data-activates="mobile-demo" class="button-collapse"><i class="material-icons">menu</i></a>
        <ul class="right hide-on-med-and-down">
            <li id="liMenu" runat="server"><a href="/">Inicio <i class="material-icons left">home</i></a></li>
            <li id="liSubject" runat="server"><a class="dropdown-button" data-activates="dpdSubject">Materias <i class="material-icons left">library_books</i></a></li>
            <li id="liAddActivity" runat="server"><a href="/subject/AddActivity.aspx">Registro de actividades <i class="material-icons left">timeline</i></a></li>
        </ul>
        <ul class="side-nav" id="mobile-demo">
            <li class="active"><a href="/">Inicio <i class="material-icons">home</i></a></li>
            <li><a href="/subject/AddSubject.aspx">Registro de materias <i class="material-icons">add</i></a></li>
            <li><a href="/subject/ListSubject.aspx">Lista de materias <i class="material-icons">list</i></a></li>
            <li><a href="/subject/AddActivity.aspx">Registro de actividades <i class="material-icons">schedule</i></a></li>
            <li><%--<a class="dropdown-button" href="#!" data-activates="dropdown1">dropdown<i class="material-icons right">arrow_drop_down</i></a>--%></li>
            
        </ul>
    </div>
</nav>
