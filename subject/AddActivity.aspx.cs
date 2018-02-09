using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subject_AddActivity : System.Web.UI.Page
{
    ActivityModel auxObj = new ActivityModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if((!IsPostBack))
        {
            rdbT.Checked = true;
            rdbL.Enabled = false;
            rdbT.Enabled = false;
        }
    }

    protected void btnRegisterData_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String path = Server.MapPath("~/archivos/");
            //fucFile.PostedFile.SaveAs(path + fucFile.FileName);

            
        }
    }

    protected void fileTypeValidate(object source, ServerValidateEventArgs args)
    {
        String path = Server.MapPath("~/archivos/");
        String fileExtension = Path.GetExtension(fucFile.PostedFile.FileName).Substring(1);
        bool aux = true;

        //Validación del tipo de archivo
        if (fileExtension.ToLower() != "pdf")
        {
            aux = false;
        }

        ////Validación del tamaño del archivo
        //if (fucFile.PostedFile.ContentLength > 2097152) //Mayor a 2MB -> ContentLength retorna en Bytes
        //{
        //    aux = false;
        //}

        args.IsValid = aux;
    }


    protected void ddlValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = ddlSubject.SelectedIndex == 0;
    }

    protected void positiveValidate(object source, ServerValidateEventArgs args)
    {
        double auxDbl = 0;
        String auxStr = txtPercentage.Text;
        Double.TryParse(auxStr, out auxDbl);

        args.IsValid = auxDbl <= 0;
    }

    protected void percentageValidate(object source, ServerValidateEventArgs args)
    {
        double auxDbl = 0;
        String auxStr = txtPercentage.Text;
        Double.TryParse(auxStr, out auxDbl);

        args.IsValid = ActivityModel.valPercentage(ddlSubject.SelectedValue, auxDbl);
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlSubject.SelectedIndex != 0)
        {
            if(SubjectModel.subjectType(ddlSubject.SelectedValue) == "L")
            {
                ArrayList auxPA = DbConnection.getDbData("SELECT SUM(percentage) FROM Activity WHERE idSubject = '" + ddlSubject.SelectedValue + "';");
                double auxP = 0;
                double.TryParse((String) auxPA[0], out auxP);
                rdbL.Enabled = true;
                rdbT.Enabled = true;

                customPercentage.ErrorMessage = "Ingresa una cantidad que no pase el 100%. Disponible: " + (auxP * 100) + "%.";
            }
        }
    }
}