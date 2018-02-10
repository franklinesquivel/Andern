using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ActivityModel
/// </summary>
public class ActivityModel
{
    public ActivityModel()
    {
        
    }

    public static bool valPercentage(String _idSubject, String _idType, double _addP)
    {
        double auxP = 0, totalP = 0;
        ArrayList auxData = SubjectActivities(_idSubject, _idType);

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

        return ((totalP * 100) + _addP) <= 100;
    }

    public static Activity getData(int _idActivity)
    {
        Activity auxObj;
        ArrayList auxData = DbConnection.getDbData("SELECT * FROM Activity WHERE idActivity WHERE idActivity = " + _idActivity + ";");

        auxData = (ArrayList) auxData[0];

        double auxP = 0;
        Double.TryParse((String)auxData[2], out auxP);
        auxObj = new Activity((String)auxData[1], auxP, (String)auxData[0], (String)auxData[3], (String)auxData[1]);
        auxObj.IdActivity = _idActivity;

        return auxObj;
    }

    public static ArrayList SubjectActivities(String _idSubject, String idType)
    {
        return DbConnection.getDbData("SELECT * FROM Activity WHERE idSubject = '" + _idSubject + "' AND idType ='" + idType + "';");
    }

    public static bool insertActivity(Activity act)
    {
        SqlCommand cmd = DbConnection.getCommand("INSERT INTO Activity(rubricFile, name, percentage, idType, idSubject) VALUES(@file, @name, @perc, @type, @sub);");
        cmd.Parameters.Add("@file", SqlDbType.VarChar);
        cmd.Parameters.Add("@name", SqlDbType.VarChar);
        cmd.Parameters.Add("@perc", SqlDbType.Decimal);
        cmd.Parameters.Add("@type", SqlDbType.VarChar);
        cmd.Parameters.Add("@sub", SqlDbType.VarChar);

        cmd.Parameters["@file"].Value = act.File;
        cmd.Parameters["@name"].Value = act.Name;
        cmd.Parameters["@perc"].Value = (act.Percentage / 100);
        cmd.Parameters["@type"].Value = act.IdType;
        cmd.Parameters["@sub"].Value = act.IdSubject;

        return DbConnection.executeCmdIUD(cmd);
    }

    public static bool updateActivity(Activity act)
    {
        SqlCommand cmd = DbConnection.getCommand("UPDATE Activity SET rubricFile = @file, name = @name, percentage = @perc, idType = @type WHERE idActivity = @id;");
        cmd.Parameters.Add("@file", SqlDbType.VarChar);
        cmd.Parameters.Add("@name", SqlDbType.VarChar);
        cmd.Parameters.Add("@perc", SqlDbType.Decimal);
        cmd.Parameters.Add("@type", SqlDbType.VarChar);
        cmd.Parameters.Add("@id", SqlDbType.Int);

        cmd.Parameters["@file"].Value = act.File;
        cmd.Parameters["@name"].Value = act.Name;
        cmd.Parameters["@perc"].Value = (act.Percentage / 100);
        cmd.Parameters["@type"].Value = act.IdType;
        cmd.Parameters["@id"].Value = act.IdActivity;

        return DbConnection.executeCmdIUD(cmd);
    }

    public static bool deleteActivity(Activity act)
    {
        SqlCommand cmd = DbConnection.getCommand("DELETE FROM Activity WHERE idActivity = @id;");
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = act.IdActivity;

        return DbConnection.executeCmdIUD(cmd);
    }
}