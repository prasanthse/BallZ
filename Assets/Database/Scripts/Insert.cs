using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class Insert : MonoBehaviour
{
    public void insertHighScore(int score)
    {
        IDbCommand cmnd = Connection.commonConnection.CreateCommand();

        cmnd.CommandText = "INSERT INTO high_score (id, highest) VALUES ('level1', 0)";        
        cmnd.ExecuteNonQuery();
    }

    public void insertLifeInfo(string life1, string life2, string life3, string life4, string life5)
    {
        IDbCommand cmnd = Connection.commonConnection.CreateCommand();

        cmnd.CommandText = "INSERT INTO life (id, life_one, life_two, life_three, life_four, life_five) VALUES ('level1', @value1, @value2, @value3, @value4, @value5)";
        cmnd.CommandType = CommandType.Text;

        cmnd.Parameters.Add(new SqliteParameter("@value1", life1));
        cmnd.Parameters.Add(new SqliteParameter("@value2", life2));
        cmnd.Parameters.Add(new SqliteParameter("@value3", life3));
        cmnd.Parameters.Add(new SqliteParameter("@value4", life4));
        cmnd.Parameters.Add(new SqliteParameter("@value5", life5));

        cmnd.ExecuteNonQuery();
    }
}
