using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subject_ListSubject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList data = DbConnection.getDbData("SELECT * FROM Subject;");

        foreach (ArrayList row in data)
        {
            foreach(var t in row)
            {
                Debug.WriteLine(t);
            }
        }
    }
}