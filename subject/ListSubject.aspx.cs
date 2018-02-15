using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subject_ListSubject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder htmlTable = new StringBuilder();
        htmlTable.AppendLine("<table class='centered bordered col s10 offset-s1'>");
        htmlTable.AppendLine("<thead class='deep-purple lighten-1 white-text'>");
        htmlTable.AppendLine("<th>Código</th>");
        htmlTable.AppendLine("<th>Nombre</th>");
        htmlTable.AppendLine("<th>Descripción</th>");
        htmlTable.AppendLine("<th>Ciclo</th>");
        htmlTable.AppendLine("<th>Tipo</th>");
        htmlTable.AppendLine("<th>UV's</th>");
        htmlTable.AppendLine("<th>Prerequisito</th>");
        htmlTable.AppendLine("<th colspan='3'>Acciones</th>");
        htmlTable.AppendLine("</thead>");
        htmlTable.AppendLine("<tbody>");
        ArrayList data = DbConnection.getDbData("SELECT * FROM Subject;");

        foreach (ArrayList row in data)
        {
            htmlTable.AppendLine("<tr>");
            htmlTable.AppendLine("<td><b>" + (String) row[0] + "</b></td>");
            htmlTable.AppendLine("<td>" + (String) row[3] + "</td>");
            htmlTable.AppendLine("<td>" + (String) row[4] + "</td>");
            htmlTable.AppendLine("<td>N° " + (String) row[5] + "</td>");
            htmlTable.AppendLine("<td>" + (((String)row[6]).Equals("T") ? "Teórica" : "Práctica") + "</td>");
            htmlTable.AppendLine("<td>" + (String) row[1] + "</td>");
            htmlTable.AppendLine("<td>" + (((String)row[2]).Equals("") ? "BACH" : (String)row[2]) + "</td>");
            htmlTable.AppendLine("<td><a href='/subject/ModifySubject.aspx?idSubject=" + (String)row[0] + "'>Modificar</a></td>");
            htmlTable.AppendLine("<td><a href='/subject/addActivity.aspx?idSubject=" + (String)row[0] + "'>Añadir Actividad</a></td>");
            htmlTable.AppendLine("<td><a id='linkDelete' idSubject='"+ (String)row[0] + "'>Eliminar</a></td>");
            htmlTable.AppendLine("</tr>");
        }
        htmlTable.AppendLine("</tbody>");
        htmlTable.AppendLine("</table>");

        frmData.InnerHtml = htmlTable.ToString();
    }

    protected void btnAcceptDelete_Click1(object sender, EventArgs e)
    {

    }
}