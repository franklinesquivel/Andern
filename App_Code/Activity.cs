using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Activity
/// </summary>
public class Activity
{
    private int idActivity;
    private String name;
    private double percentage;
    private String file;
    private String idType;
    private String idSubject;

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

    public double Percentage
    {
        get
        {
            return percentage;
        }

        set
        {
            percentage = value;
        }
    }

    public string File
    {
        get
        {
            return file;
        }

        set
        {
            file = value;
        }
    }

    public string IdType
    {
        get
        {
            return idType;
        }

        set
        {
            idType = value;
        }
    }

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

    public Activity()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}