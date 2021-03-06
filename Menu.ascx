﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Menu" %>

<script runat="server">
    private int actualPage;
    public int ActualPage
    {
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
</ul>

<nav>
    <div class="nav-wrapper deep-purple darken-1" style="position: relative;">
        <a href="#!" class="brand-logo">
            <nav class="deep-purple darken-1" style="box-shadow: none;">
                <img src="/img/logo.png" height="100%" style="margin-left: 100%;"/>
            </nav>
        </a>
        <ul class="right">
            <li id="liMenu" runat="server"><a href="/">Inicio <i class="material-icons left">home</i></a></li>
            <li id="liSubject" runat="server"><a class="dropdown-button" data-activates="dpdSubject">Materias <i class="material-icons left">library_books</i></a></li>
            <li id="liAddActivity" runat="server"><a href="/subject/AddActivity.aspx">Registro de actividades <i class="material-icons left">timeline</i></a></li>
        </ul>
    </div>
</nav>
