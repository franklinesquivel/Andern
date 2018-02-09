using System;
using System.Collections.Generic;
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

    public bool Insert(string idSubject, string name, int uv, int prerequisite, string description, int course, char type)
    {
        string sql = "";
        if (prerequisite == 0)
        {
            sql = "INSERT INTO Subject(idSubject, name, uv, description, course, type) VALUES('" + idSubject + "', '" + name + "', " + uv + ", '" + description + "', " + course + ", '" + type + "')";
        }
        else
        {
            sql = "INSERT INTO Subject(idSubject, name, uv, prerequisite, description, course, type) VALUES('" + idSubject + "', '" + name + "', " + uv + ", '" + prerequisite + "', '" + description + "', " + course + ", " + type + ")";
        }
        return DbConnection.MakeQuery(sql); 
    }

    public bool Verify(string idSubject)
    {
        string sql = "SELECT COUNT(*) FROM Subject WHERE idSubject ='"+ idSubject +"'";
        return (int.Parse(DbConnection.MakeScalar(sql)) > 0) ? false : true;
    }
}