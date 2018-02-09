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

    public int IdActivity
    {
        get
        {
            return idActivity;
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

    public Activity(int _idActivity)
    {

    }

    public Activity()
    {
        idActivity = 0;
    }

    public void setData(String _name, double _percentage, String _file, String _idType, String _idSubject)
    {
        if (idActivity != 0)
        {
            Name = _name;
            Percentage = _percentage;
            File = _file;
            IdType = _idType;
            IdSubject = _idSubject;
        }
    }
}