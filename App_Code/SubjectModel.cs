using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de SubjectModel
/// </summary>
public class SubjectModel
{
    public SubjectModel()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public bool Insert(Subject subject)
    {
        string query = "";
        if (subject.Prerequisite == "0")
        {
            query = "INSERT INTO Subject(idSubject, name, uv, description, course, type) VALUES(@idSubject, @name, @uv, @description, @course, @type)";
        }
        else
        {
            query = "INSERT INTO Subject(idSubject, name, uv, prerequisite, description, course, type) VALUES(@idSubject, @name, @uv, @prerequisite, @description, @course, @type)";
        } 

        SqlCommand cmd = DbConnection.getCommand(query); //Ingresamos la query
        if (subject.Prerequisite != "0")
        {
            cmd.Parameters.Add("@prerequisite", SqlDbType.VarChar);
            cmd.Parameters["@prerequisite"].Value = subject.Prerequisite;
        }
        cmd.Parameters.Add("@idSubject", SqlDbType.VarChar);
        cmd.Parameters.Add("@uv", SqlDbType.Int);
        cmd.Parameters.Add("@name", SqlDbType.VarChar);
        cmd.Parameters.Add("@description", SqlDbType.VarChar);
        cmd.Parameters.Add("@course", SqlDbType.Int);
        cmd.Parameters.Add("@type", SqlDbType.VarChar);

        cmd.Parameters["@idSubject"].Value = subject.IdSubject;
        cmd.Parameters["@uv"].Value = subject.Uv;
        cmd.Parameters["@name"].Value = subject.Name;
        cmd.Parameters["@description"].Value = subject.Description;
        cmd.Parameters["@course"].Value = subject.Course;
        cmd.Parameters["@type"].Value = subject.Type;

        return DbConnection.executeCmdIUD(cmd); 
    }

    public bool Verify(string idSubject)
    {
        string sql = "SELECT COUNT(*) FROM Subject WHERE idSubject ='"+ idSubject +"'";
        return (int.Parse(DbConnection.MakeScalar(sql)) > 0) ? false : true;
    }

    public static String subjectType(String _idSubject)
    {
        ArrayList aux = DbConnection.getDbData("SELECT type FROM Subject WHERE idSubject = '" + _idSubject + "'");
        return (String)aux[0];
    }

    public bool Update(Subject subject)
    {
        SqlCommand cmd = DbConnection.getCommand("UPDATE Subject SET name=@name, uv=@uv, prerequisite=@prerequisite, description=@description, course=@course, type=@type WHERE idSubject = @idSubject");
        
        cmd.Parameters.Add("@prerequisite", SqlDbType.VarChar);
        cmd.Parameters.Add("@idSubject", SqlDbType.VarChar);
        cmd.Parameters.Add("@uv", SqlDbType.Int);
        cmd.Parameters.Add("@name", SqlDbType.VarChar);
        cmd.Parameters.Add("@description", SqlDbType.VarChar);
        cmd.Parameters.Add("@course", SqlDbType.Int);
        cmd.Parameters.Add("@type", SqlDbType.VarChar);

        if (subject.Prerequisite == "0")
        {
            cmd.Parameters["@prerequisite"].Value = DBNull.Value;
        }else {
            cmd.Parameters["@prerequisite"].Value = subject.Prerequisite;
        }
        cmd.Parameters["@idSubject"].Value = subject.IdSubject;
        cmd.Parameters["@uv"].Value = subject.Uv;
        cmd.Parameters["@name"].Value = subject.Name;
        cmd.Parameters["@description"].Value = subject.Description;
        cmd.Parameters["@course"].Value = subject.Course;
        cmd.Parameters["@type"].Value = subject.Type;
        return DbConnection.executeCmdIUD(cmd);
    }

    public bool Delete(string idSubject)
    {
        string query = "DELETE FROM Subject WHERE idSubject=@idSubject";
        SqlCommand cmd = DbConnection.getCommand(query);
        cmd.Parameters.Add("@idSubject", SqlDbType.VarChar);
        cmd.Parameters["@idSubject"].Value = idSubject;
        return DbConnection.executeCmdIUD(cmd);
    }
}