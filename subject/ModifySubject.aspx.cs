using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subject_ModifySubject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Verificamos si la url tiene el id
        if (Request.QueryString["idSubject"] != null)
        {
            //Procedemos a obtener la información
            ArrayList data = DbConnection.getDbData("SELECT * FROM Subject WHERE idSubject = '"+ Request.QueryString["idSubject"] + "'");

            //Recorremos la informacion y la agregamos a los campos del formulario
            addPrerequiste(); //Agregamos las materias en cmbPre
            setData(data);
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
            if (cmbPre.Items.FindByValue((string)row[0]) != null)
            {
                cmbPre.Items.FindByValue((string)row[0]).Selected = true; //Seleccionamos el item correspondiente
            }else
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
        if (Page.IsValid && (IsPostBack))
        {
            string idSubject, name, description, prerequisite;
            int uv, course;
            try
            {
                idSubject = Request.QueryString["idSubject"];
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

                //if (!newSubject.VerifySubjet())
                //{//Materia existe
                //    if (newSubject.Update())
                //    {//Materia registrada
                //        result.InnerHtml = "<h1>Materia modificada con exito</h1>";
                //    }
                //}
                //else
                //{//Materia no existe
                //    result.InnerHtml = "<h1>Lo sentimos ha ocurrido un error</h1>";
                //}
                result.InnerHtml = name;
            }
            catch (Exception ERROR)
            {
                result.InnerHtml = "<h1>ERROR</h1>";
            }
        }
    }
}