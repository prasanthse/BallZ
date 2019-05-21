using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class UpdateScore : MonoBehaviour
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
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    public void updateHighScore(int number)
    {
        IDbCommand cmnd = dbcon.CreateCommand();

        cmnd.CommandText = "UPDATE high_score set highest = " + number + " WHERE id = 'level1'";
        cmnd.ExecuteNonQuery();

        dbcon.Close();
    }
}
