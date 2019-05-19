using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class Insert : MonoBehaviour
{
    private IDbConnection dbcon;
    private Create dbCreate;

    void Start()
    {
        try
        {
            dbCreate = new Create();
            dbcon = dbCreate.getConnection();
            dbcon.Open();
        }
        catch(Exception ex)
        {
            Debug.Log(ex);
        }
    }

    public void insertHighScore(int score)
    {
        IDbCommand cmnd = dbcon.CreateCommand();

        cmnd.CommandText = "INSERT INTO high_score (id, highest) VALUES ('player3', 15)";        
        cmnd.ExecuteNonQuery();
        Debug.Log("added");

        dbcon.Close();
        Debug.Log("closed");
    }

    public void insertLifeInfo()
    {
        IDbCommand cmnd = dbcon.CreateCommand();

        cmnd.CommandText = "INSERT INTO life (id, life_one, life_two, life_three, life_four, life_five) VALUES ('player1', 5, 5, 5, 5, 5)";
        cmnd.ExecuteNonQuery();
        Debug.Log("added");

        dbcon.Close();
        Debug.Log("closed");
    }
}
