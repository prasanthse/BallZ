using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Create : MonoBehaviour
{
    private IDbConnection dbcon;

    private IDbCommand dbcmd;
    private IDataReader reader;

    void Start()
    {
        try
        {
            dbcon = getConnection();
            dbcon.Open();
            Debug.Log("Database connected");

            createHighScoreTable();
            createLifeTable();

            dbcon.Close();
            Debug.Log("Database disconnected");
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    public IDbConnection getConnection()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/BallZ.s3db";
        Debug.Log(connection);
        IDbConnection con = new SqliteConnection(connection);
        return con;
    }

    public void createHighScoreTable()
    {
        dbcmd = dbcon.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS high_score (id TEXT PRIMARY KEY, highest INTEGER)";

        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
    }

    public void createLifeTable()
    {
        dbcmd = dbcon.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS life (id TEXT PRIMARY KEY, life_one TIME, life_two TIME, life_three TIME, life_four TIME, life_five TIME)";

        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
    }

}
