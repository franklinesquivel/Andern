using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ActivityModel
/// </summary>
public class ActivityModel
{
    private ArrayList tableData;
    public ActivityModel()
    {
        tableData = DbConnection.getDbData("SELECT * FROM Activity;");
    }

    public static bool valPercentage(String _idSubject, double _addP)
    {
        double auxP = 0, totalP = 0;
        ArrayList auxData = SubjectActivities(_idSubject);

        try
        {
            foreach (ArrayList r in auxData)
            {
                Double.TryParse((String)r[3], out auxP);
                totalP += auxP;
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }

        return totalP + _addP > 100;
    }

    public static Activity getData(int _idActivity)
    {
        Activity auxObj = new Activity(_idActivity);
        ArrayList auxData = DbConnection.getDbData("SELECT * FROM Activity WHERE idActivity WHERE idActivity = " + _idActivity + ";");

        foreach (ArrayList r in auxData)
        {
            double auxP = 0;
            Double.TryParse((String)r[2], out auxP);
            auxObj.setData((String)r[1], auxP, (String)r[0], (String)r[3], (String)r[1]);
        }

        return auxObj;
    }

    public static ArrayList SubjectActivities(String _idSubject)
    {
        return DbConnection.getDbData("SELECT * FROM Activity WHERE idSubject = '" + _idSubject + "'");
    }
}