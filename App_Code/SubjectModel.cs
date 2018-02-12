using System;
using System.Collections;
using System.Collections.Generic;
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

    public bool Insert(string idSubject, string name, int uv, string prerequisite, string description, int course, char type)
    {
        string sql = "";
        if (prerequisite == "0")
        {
            sql = "INSERT INTO Subject(idSubject, name, uv, description, course, type) VALUES('" + idSubject + "', '" + name + "', " + uv + ", '" + description + "', " + course + ", '" + type + "')";
        }
        else
        {
            sql = "INSERT INTO Subject(idSubject, name, uv, prerequisite, description, course, type) VALUES('" + idSubject + "', '" + name + "', " + uv + ", '" + prerequisite + "', '" + description + "', " + course + ", '" + type + "')";
        }
        return DbConnection.MakeQuery(sql); 
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

    public bool Update(string idSubject, string name, int uv, string prerequisite, string description, int course, char type)
    {
        string sql = "";
        if (prerequisite == "0")
        {
            sql = "UPDATE Subject SET name='"+name+"', uv ="+ uv +", prerequisite='NULL', description='"+description+"', course="+course+", type='"+type+"' WHERE idSubject = '"+ idSubject +"'";
        }
        else
        {
            sql = "UPDATE Subject SET name='" + name + "', uv =" + uv + ", prerequisite='"+prerequisite+"' , description='" + description + "', course=" + course + ", type='" + type + "' WHERE idSubject = '" + idSubject + "'";
        }
        return DbConnection.MakeQuery(sql);
    }

    public bool Delete(string idSubject)
    {
        string sql = "DELETE FROM Subject WHERE idSubject ='"+ idSubject +"'";
        return DbConnection.MakeQuery(sql);
    }
}