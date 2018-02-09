﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DbConnection
/// </summary>
public class DbConnection
{
    private static string connectionString = "Data Source=DESKTOP-JI5137H;Initial Catalog=Andern;Integrated Security=True";
    private static SqlConnection connection;
    private static SqlCommand cmd;
    private static SqlDataReader dr;

    public DbConnection()
    {
        
    }

    //ExecuteNonQuery, ExecuteReader, Execute Scalar

    public static bool MakeQuery(string query) { //UPDATE, INSERT AND DELETE
        bool response = false;
        try {
            connection = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, connection);
            cmd.Connection.Open();
            response = (cmd.ExecuteNonQuery() > 0) ? true : false;
            cmd.Connection.Close();
            return response;
        }
        catch(Exception e)
        {
            return response;
        }
    }

    public string MakeScalar(string query) //Devuelve la primera columna de la primera fila de una consulta
    {
        string response = "";
        try
        {
            connection = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, connection);
            cmd.Connection.Open();
            response = (string) cmd.ExecuteScalar();
            cmd.Connection.Close();
        }
        catch (Exception e)
        {
            response = "";
        }
        return response;
    }

    public static ArrayList getDbData(String sql)
    {
        ArrayList data = new ArrayList();

        try
        {
            connection = new SqlConnection(connectionString);
            cmd = new SqlCommand(sql, connection);
            cmd.Connection.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ArrayList auxData = new ArrayList();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        auxData.Add(dr[i].ToString());
                    }

                    data.Add(auxData);
                }

                return data;
            }
            else
                data = new ArrayList();
            {

            }
            cmd.Connection.Close();
            return data;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return new ArrayList();
        }
    }
}