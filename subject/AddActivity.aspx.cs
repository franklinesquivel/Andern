using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subject_AddActivity : System.Web.UI.Page
{
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
        String path = Server.MapPath("~/archivos/");
        //fucFile.PostedFile.SaveAs(path + fucFile.FileName);
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
        double auxDbl = 0, auxDbl2 = 0;
        String auxStr = txtPercentage.Text;
        Double.TryParse(auxStr, out auxDbl);
        auxStr = hfPercentage.Value;
        Double.TryParse(auxStr, out auxDbl2);

        args.IsValid = auxDbl + auxDbl2 > 100;
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}