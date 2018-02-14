using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subject_ModifySubject : System.Web.UI.Page
{
    private Subject newSubject;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //Verificamos que dicho id exista en la BDD y si existe en la URL
        if (Request.QueryString["idSubject"] != null && (!Page.IsPostBack))
        {
            newSubject = new Subject(Request.QueryString["idSubject"]); //Inicializamos el objeto
            if (!newSubject.VerifySubjet())
            {
                //Procedemos a obtener la información
                ArrayList data = DbConnection.getDbData("SELECT * FROM Subject WHERE idSubject = '" + newSubject.IdSubject + "'");

                //Recorremos la informacion y la agregamos a los campos del formulario
                addPrerequiste(); //Agregamos las materias en cmbPre
                setData(data);
                //Refrescamos los select para cargue la materia de prerrequisto
                ScriptManager.RegisterStartupScript(this, typeof(Page), "refreshSelect", "$('select').material_select()", true);
            } else {
                Response.Redirect("ListSubject.aspx"); //Redireccionamos al listar materia
            }
        }else {
            if (Request.QueryString["idSubject"] == null)
            {
                Response.Redirect("ListSubject.aspx"); //Redireccionamos al listar materia
            }
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
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

    protected void setData(ArrayList data)
    {
        cmbPre.ClearSelection(); //Quitamos el selccionado por default
        foreach (ArrayList row in data)
        {//Establecemos la información en los respectivos campos
            txtName.Text = (string)row[3];
            txtSemester.Text = (string)row[5];
            txtUV.Text = (string)row[1];
            txtDescription.InnerText = (string)row[4];
            chkLab.Checked = (((string)row[6]).Equals("T") ? false : true);

            //Buscamos y seleccionamos el prerequisite de dicha materia
            if (cmbPre.Items.FindByValue((string)row[2]) != null)
            {
                cmbPre.Items.FindByValue((string)row[2]).Selected = true; //Seleccionamos el item correspondiente
            }
            else
            {
                cmbPre.Items.FindByValue("0").Selected = true; //Seleccionamos bachillerato
            }
        }
    }

    protected void addPrerequiste()
    {//Añade las materias al listBox
        ArrayList subjects = DbConnection.getDbData("SELECT name, idSubject FROM Subject WHERE idSubject != '" + Request.QueryString["idSubject"] +"'");
        cmbPre.Items.Add(new ListItem("Bachillerato", "0"));//Agregamos Bachillerato como primer Item
        foreach (ArrayList row in subjects)
        {//Agregamos los item al listBox
            cmbPre.Items.Add(new ListItem((string)row[0], (string)row[1]));
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        //Se guardan los valores del form y se aplican ciertos métodos para evitar errores
        if (Page.IsValid)
        {
            string name, description, prerequisite;
            int uv, course;
            try
            {
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

                newSubject = new Subject(Request.QueryString["idSubject"], name, uv, prerequisite, description, course, type);
                String toast = "";

                if (newSubject.Update())
                {//Materia Actualizada
                    toast = "Materialize.toast('Actualización exitosa', 1000, '', function(){location.href = '/subject/ListSubject.aspx'});";
                }else {
                    toast = "Materialize.toast('Update falla', 2000);";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "cofirmUpdate", toast, true);
            }
            catch (Exception ERROR)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "errorMessage", "Materialize.toast('Ha ocurrido un error :(', 2000);", true);
            }
        }
    }
}