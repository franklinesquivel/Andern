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
            rdbSubjectType.SelectedIndex = 0;
            rdbL.Enabled = false;
            rdbT.Enabled = false;

            if (Request.QueryString["idSubject"] != null)
            {
                if (SubjectModel.subjectType(Request.QueryString["idSubject"]) == "L")
                {
                    ddlSubject.SelectedValue = Request.QueryString["idSubject"];
                    rdbL.Enabled = true;
                    rdbT.Enabled = true;
                }
                else if (SubjectModel.subjectType(Request.QueryString["idSubject"]) == null)
                {

                }
            }
        }
    }

    protected void btnRegisterData_Click(object sender, EventArgs e)
    {
        
        if (Page.IsValid)
        {
            String path = Server.MapPath("~/files/");
            String scriptstring = "";
            String auxStr = txtPercentage.Text;
            double auxP = 0;
            Double.TryParse(auxStr, out auxP);
            Activity newAc = new Activity(txtName.Text, auxP, fucFile.PostedFile.FileName, rdbSubjectType.SelectedValue, ddlSubject.SelectedValue);

            if (newAc.Insert())
            {
                scriptstring = "Materialize.toast('La actividad ha sido registrada éxitosamente', 2000, '', function(){location.href = '/subject/AddActivity.aspx'});";
                fucFile.PostedFile.SaveAs(path + fucFile.FileName);
            }
            else
            {
                scriptstring = "Materialize.toast(Ha ocurrido un error :(', 2000);";

            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", scriptstring, true);

        }
    }

    protected void fileTypeValidate(object source, ServerValidateEventArgs args)
    {
        String fileExtension = Path.GetExtension(fucFile.PostedFile.FileName).Substring(1);
        bool aux = true;

        //Validación del tipo de archivo
        if (fileExtension.ToLower() != "pdf")
        {
            aux = false;
        }
        
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

        args.IsValid = (auxDbl > 0);
    }

    protected void percentageValidate(object source, ServerValidateEventArgs args)
    {
        double auxDbl = 0;
        String auxStr = txtPercentage.Text;
        Double.TryParse(auxStr, out auxDbl);

        args.IsValid = ActivityModel.valPercentage(ddlSubject.SelectedValue, rdbSubjectType.SelectedValue, auxDbl);
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlSubject.SelectedIndex != 0)
        {
            if (SubjectModel.subjectType(ddlSubject.SelectedValue) == "L")
            {
                rdbL.Enabled = true;
                rdbT.Enabled = true;
            }
            else
            {
                rdbSubjectType.SelectedIndex = 0;
                rdbL.Enabled = false;
                rdbT.Enabled = false;
            }

            ArrayList auxPA = DbConnection.getDbData("SELECT SUM(percentage) FROM Activity WHERE idSubject = '" + ddlSubject.SelectedValue + "' AND idType = '" + rdbSubjectType.SelectedValue + "';");
            double auxP = 0;
            double.TryParse((String)auxPA[0], out auxP);
            lblPercentage.Text = "Porcentaje de la actividad [Disponible: " + (100 - (auxP * 100)) + "%].";
        }
        else
        {
            rdbSubjectType.SelectedIndex = 0;
            rdbL.Enabled = false;
            rdbT.Enabled = false;
        }
    }

    protected void rdbSubjectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ArrayList auxPA = DbConnection.getDbData("SELECT SUM(percentage) FROM Activity WHERE idSubject = '" + ddlSubject.SelectedValue + "' AND idType = '" + rdbSubjectType.SelectedValue + "';");
        double auxP = 0;
        double.TryParse((String)auxPA[0], out auxP);
        lblPercentage.Text = "Porcentaje de la actividad [Disponible: " + (100 - (auxP * 100)) + "%].";
    }
}