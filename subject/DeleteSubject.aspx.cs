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
        if (Request.QueryString["idSubject"] != null) //Verificamos que el parametro este presente en la url
        {
            Subject newSubject = new Subject(Request.QueryString["idSubject"]);
            if (!newSubject.VerifySubjet()) 
            {//Verificamos que la materia exista
                newSubject.Delete();
            }
        }
        Response.Redirect("ListSubject.aspx");
    }
}