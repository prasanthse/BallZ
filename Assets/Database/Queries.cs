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
            string connection = "URI=file:" + Application.persistentDataPath + "/BallZ.s3db";
            dbcon = new SqliteConnection(connection);
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
            string connection = "URI=file:" + Application.persistentDataPath + "/BallZ.s3db";
            dbcon = new SqliteConnection(connection); 
            dbcon.Open();

            createHighScoreTable();
            createLifeTable();   
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
    
   
    //Create Tables
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
        string q_createTable = "CREATE TABLE IF NOT EXISTS life (id TEXT PRIMARY KEY, life_one TEXT, life_two TEXT, life_three TEXT, life_four TEXT, life_five TEXT)";

        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
    }


    //Drop Tables
    public void DropHighScoreTable()
    {
        IDbCommand cmnd = dbcon.CreateCommand();

        cmnd.CommandText = "DROP TABLE high_score";
        cmnd.ExecuteNonQuery();
    }

    public void DropLifeTable()
    {
        IDbCommand cmnd = dbcon.CreateCommand();

        cmnd.CommandText = "DROP TABLE life";
        cmnd.ExecuteNonQuery();
    }


    //Insert into Tables
    public void insertHighScore(int score)
    {
        IDbCommand cmnd = dbcon.CreateCommand();

        cmnd.CommandText = "INSERT INTO high_score (id, highest) VALUES ('level1', 0)";
        cmnd.ExecuteNonQuery();
    }

    public void insertLifeInfo(DateTime dateTime)
    {
        IDbCommand cmnd = dbcon.CreateCommand();

        cmnd.CommandText = "INSERT INTO life (id, life_one, life_two, life_three, life_four, life_five) VALUES ('level1'," + dateTime.ToString() + ", null, null, null, null)";
        cmnd.ExecuteNonQuery();
    }


    //Retrieve Tables
    public void getLifeInfo()
    {
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;

        string query = "SELECT * FROM life where id = 'level1'";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        while (reader.Read())
        {
            Debug.Log("life1: " + reader[1].ToString());
            Debug.Log("life2: " + reader[2].ToString());
            Debug.Log("life3: " + reader[3].ToString());
            Debug.Log("life4: " + reader[4].ToString());
            Debug.Log("life5: " + reader[5].ToString());
        }
    }

    public string getHighScore()
    {
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;

        string query = "SELECT highest FROM high_score where id = 'level1'";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        string score = reader[0].ToString();

        return score;
    }


    //Update Tables
    public void updateHighScore(int number)
    {
        IDbCommand cmnd = dbcon.CreateCommand();

        cmnd.CommandText = "UPDATE high_score set highest = " + number + " WHERE id = 'level1'";
        cmnd.ExecuteNonQuery();
    }


    //Close Connection
    public void close()
    {
        dbcon.Close();
    }
}
