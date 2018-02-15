using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subject_DeleteSubjectt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["idSubject"] != "") //Verificamos que el parametro este presente en la url
        {
            //Subject newSubject = new Subject(Request.QueryString["idSubject"]);
            //if (!newSubject.VerifySubjet())
            //{//Verificamos que la materia exista
            //    if (newSubject.VerifyActivities() && newSubject.verifyPrerequisite())
            //    {//Se verifica que la materia no posea actividades asignadas
            //        if (newSubject.Delete())
            //        {
            //            ScriptManager.RegisterStartupScript(this, typeof(Page), "errorMessage", "Materialize.toast('Materia eliminada con exito', 1000, '', function(){location.href = '/subject/ListSubject.aspx'});", true);
            //        }
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "errorMessage", "Materialize.toast('La materia posee actividades o es un prerrequisto. No se puede eliminar', 1000, '', function(){location.href = '/subject/ListSubject.aspx'});", true);
            //    }
            //}
            Form.InnerHtml = Request.Form["idSubject"];
        }
        else
        {
            //Response.Redirect("ListSubject.aspx");
        }

        
    }
}