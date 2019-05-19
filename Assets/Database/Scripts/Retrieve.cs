using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;

public class Retrieve : MonoBehaviour
{
    private IDbConnection dbcon;
    private Create dbCreate;

    void Start()
    {
        dbCreate = new Create();
        dbcon = dbCreate.getConnection();
        dbcon.Open();
    }
    
    public void getLifeInfo()
    {
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;

        string query = "SELECT * FROM life where id = 'level1'";     
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        while (reader.Read())
        {
            Debug.Log("life1: " + reader[0].ToString());
            Debug.Log("life2: " + reader[1].ToString());
            Debug.Log("life3: " + reader[1].ToString());
            Debug.Log("life4: " + reader[1].ToString());
            Debug.Log("life5: " + reader[1].ToString());
        }

        dbcon.Close();
    }

    public string getHighScore()
    {
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;

        string query = "SELECT highest FROM high_score where id = 'player1'";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        string score = reader[0].ToString();

        dbcon.Close();

        return score;
    }
}
