using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DbConnection
/// </summary>
public class DbConnection
{
    private static string connectionString = "Server=;Database=Ander;Trusted_Connection=True";
    private static SqlConnection connection;
    private static SqlCommand cmd;

    public DbConnection()
    {
        
    }

    //ExecuteNonQuery, ExecuteReader, Execurte Scalar

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
}