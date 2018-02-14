using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subject_AddSubject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            addPrerequiste();//Agregamos items al listbox
        }
    }

    protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
    {
        bool response = false;
        if (chkLab.Checked)
        {
            if (args.Value.ToString().Trim() == "4")
            {
                response = true;
            }
        }
        else
        {
            if (args.Value.ToString().Trim() == "4" || args.Value.ToString().Trim() == "2" || args.Value.ToString().Trim() == "3")
            {
                response = true;
            }
        }
        
        args.IsValid = response;
    }

    protected void btnSend_Click(object sender, EventArgs e) {
        //Se guardan los valores del form y se aplican ciertos métodos para evitar errores
        if (Page.IsValid)
        {
            string idSubject, name, description, prerequisite;
            int uv, course;
            try
            {
                idSubject = txtCode.Text.Trim().ToUpper();
                name = txtName.Text.Trim();
                description = txtDescription.Value.Trim();
                uv = int.Parse(txtUV.Text);
                course = int.Parse(txtSemester.Text);
                prerequisite = cmbPre.SelectedValue;

                char type = 'T';
                if (chkLab.Checked)
                {
                    type = 'L';
                } //Con las líneas anteriores decimos que tipo de materia registraremos
                Subject newSubject = new Subject(idSubject, name, uv, prerequisite, description, course, type);
                string toast = "";
                if (newSubject.VerifySubjet())
                {//Materia no existe
                    if (newSubject.Insert())
                    {//Materia registrada
                        toast = "Materialize.toast('Materia registrada con exito', 1000,'', function(){location.href = '/subject/AddSubject.aspx'});";
                    }
                }
                else
                {//Materia ya existe
                    toast = "Materialize.toast('Dicho código de ya existe :(', 2000);";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "cofirmUpdate", toast, true);
            }
            catch (Exception ERROR)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "cofirmUpdate", "Materialize.toast('Error, intentalo más tarde :(', 2000);", true);
            }
        }
        
    }//Fin método btnSend_Click

    protected void addPrerequiste()
    {//Añade las materias al listBox
        ArrayList subjects = DbConnection.getDbData("SELECT name, idSubject FROM Subject");
        cmbPre.Items.Add(new ListItem("Bachillerato", "0"));//Agregamos Bachillerato como primer Item

        foreach (ArrayList row in subjects)
        {//Agregamos los item al listBox
            cmbPre.Items.Add(new ListItem((string)row[0], (string)row[1]));
        }
        cmbPre.Items.FindByValue("0").Selected = true; //Seleccionamos bachillerato
    }

}