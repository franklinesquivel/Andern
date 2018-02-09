using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Subject
/// </summary>
public class Subject
{
    //INICIO DE ATRIBUTOS
    private string idSubject; //Codigo
    private string name; //Nombre
    private int uv; //Unidades Valorativas
    private int prerequisite; //Prerrequisito
    private string description; //Descripcion
    private int course; //Ciclo
    private char type; //Tipo
    public string IdSubject
    {
        get
        {
            return idSubject;
        }

        set
        {
            idSubject = value;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
    public int Prerequisite
    {
        get
        {
            return prerequisite;
        }

        set
        {
            prerequisite = value;
        }
    }
    public int Uv
    {
        get
        {
            return uv;
        }

        set
        {
            uv = value;
        }
    }
    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }
    public int Course
    {
        get
        {
            return course;
        }

        set
        {
            course = value;
        }
    }
    public char Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }
    //FIN ATRIBUTOS

    public Subject(string idSubject, string name, int uv, int prerequisite, string description, int course, char type)
    { //CONSTRUCTOR
        this.idSubject = idSubject;
        this.name = name;
        this.uv = uv;
        this.prerequisite = prerequisite;
        this.description = description;
        this.course = course;
        this.type = type;
    }


    //INICIO DE MÉTODOS
    public bool Insert()
    {
        SubjectModel nuevoModelo = new SubjectModel();
        return nuevoModelo.Insert(this.idSubject, this.name, this.uv, this.prerequisite, this.description, this.course, this.type);
    }

    public bool VerifySubjet() //Verifica que la nueva materia a ingresar no este registrada
    {
        SubjectModel nuevoModelo = new SubjectModel();
        return nuevoModelo.Verify(this.idSubject);
    }

    //FIN MÉTODOS
} //Fin clase