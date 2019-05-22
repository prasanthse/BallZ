using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Queries : MonoBehaviour
{
    private IDbConnection dbcon;
    private IDbCommand dbcmd;
    private IDataReader reader;

    public Queries()
    {
        try
        {
            dbcon = getConnection();
            dbcon.Open();

            createHighScoreTable();
            createLifeTable();
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    void Start()
    {
        try
        {
            dbcon = getConnection();
            dbcon.Open();

            createHighScoreTable();
            createLifeTable();
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    //get Database URL
    public IDbConnection getConnection()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/BallZ.s3db";
        Debug.Log(connection);
        IDbConnection con = new SqliteConnection(connection);
        return con;
    }

    //create HighScore table
    public void createHighScoreTable()
    {
        dbcmd = dbcon.CreateCommand();

        string q_createTable = "CREATE TABLE IF NOT EXISTS high_score (id TEXT PRIMARY KEY, highest INTEGER)";

        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
    }

    //Create LifeTable
    public void createLifeTable()
    {
        dbcmd = dbcon.CreateCommand();

        string q_createTable = "CREATE TABLE IF NOT EXISTS life (id TEXT PRIMARY KEY, life_one TIME, life_two TIME, life_three TIME, life_four TIME, life_five TIME)";

        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
    }

    //Insert HighScore
    public void insertHighScore(int score)
    {
        dbcmd = dbcon.CreateCommand();

        dbcmd.CommandText = "INSERT INTO high_score (id, highest) VALUES ('level1', 0)";
        dbcmd.ExecuteNonQuery();
    }

    //Insert Life
    public void insertLifeInfo()
    {
        dbcmd = dbcon.CreateCommand();

        dbcmd.CommandText = "INSERT INTO life (id, life_one, life_two, life_three, life_four, life_five) VALUES ('level1', null, null, null, null, null)";
        dbcmd.ExecuteNonQuery();
    }

    //Retrieve Life
    public void getLifeInfo()
    {
        dbcmd = dbcon.CreateCommand();

        string query = "SELECT * FROM life where id = 'level1'";
        dbcmd.CommandText = query;
        reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            Debug.Log("life1: " + reader[0].ToString());
            Debug.Log("life2: " + reader[1].ToString());
            Debug.Log("life3: " + reader[1].ToString());
            Debug.Log("life4: " + reader[1].ToString());
            Debug.Log("life5: " + reader[1].ToString());
        }
    }

    //Retrieve HighScore
    public string getHighScore()
    {
        dbcmd = dbcon.CreateCommand();

        string query = "SELECT highest FROM high_score where id = 'level1'";
        dbcmd.CommandText = query;
        reader = dbcmd.ExecuteReader();

        string score = reader[0].ToString();

        return score;
    }

    //Update HighScore
    public void updateHighScore(int number)
    {
        dbcmd = dbcon.CreateCommand();

        dbcmd.CommandText = "UPDATE high_score set highest = " + number + " WHERE id = 'level1'";
        dbcmd.ExecuteNonQuery();
    }
}
