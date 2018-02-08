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
            switch(actualPage)
            {
                case 1:
                    liMenu.Attributes.Add("class", "active");
                    break;
                case 2:
                    liAddSubject.Attributes.Add("class", "active");
                    break;
                case 3:
                    liListSubject.Attributes.Add("class", "active");
                    break;
                case 4:
                    liAddActivity.Attributes.Add("class", "active");
                    break;
            }
        }
    }
</script>

<nav>
    <div class="nav-wrapper deep-purple darken-1">
        <a href="#!" class="brand-logo">Logo</a>
        <a href="#" data-activates="mobile-demo" class="button-collapse"><i class="material-icons">menu</i></a>
        <ul class="right hide-on-med-and-down">
            <li id="liMenu" runat="server"><a href="/">Inicio <i class="material-icons left">home</i></a></li>
            <li id="liAddSubject" runat="server"><a href="/subject/AddSubject.aspx">Registro de materias <i class="material-icons left">add</i></a></li>
            <li id="liListSubject" runat="server"><a href="/subject/ListSubject.aspx">Lista de materias <i class="material-icons left">list</i></a></li>
            <li id="liAddActivity" runat="server"><a href="/subject/AddActivity.aspx">Registro de actividades <i class="material-icons left">schedule</i></a></li>
        </ul>
        <ul class="side-nav" id="mobile-demo">
            <li class="active"><a href="/">Inicio <i class="material-icons">home</i></a></li>
            <li><a href="/subject/AddSubject.aspx">Registro de materias <i class="material-icons">add</i></a></li>
            <li><a href="/subject/ListSubject.aspx">Lista de materias <i class="material-icons">list</i></a></li>
            <li><a href="/subject/AddActivity.aspx">Registro de actividades <i class="material-icons">schedule</i></a></li>
        </ul>
    </div>
</nav>
