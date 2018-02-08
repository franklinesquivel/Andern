using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subject_ModifySubject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
}