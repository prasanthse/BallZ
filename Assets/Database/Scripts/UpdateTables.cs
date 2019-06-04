using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class UpdateTables : MonoBehaviour
{
    public void updateHighScore(int number)
    {
        IDbCommand cmnd = Connection.commonConnection.CreateCommand();

        cmnd.CommandText = "UPDATE high_score set highest = " + number + " WHERE id = 'level1'";
        cmnd.ExecuteNonQuery();
    }

    public void updateLife(string life1, string life2, string life3, string life4, string life5)
    {
        IDbCommand cmnd = Connection.commonConnection.CreateCommand();

        cmnd.CommandText = "UPDATE life set life_one = @value1 WHERE id = 'level1'";
        cmnd.CommandType = CommandType.Text;
        cmnd.Parameters.Add(new SqliteParameter("@value1", life1));
        cmnd.ExecuteNonQuery();

        //cmnd.CommandText = "UPDATE life set life_two = " + life2 + " WHERE id = 'level1'";
        //cmnd.ExecuteNonQuery();

        //cmnd.CommandText = "UPDATE life set life_three = " + life3 + " WHERE id = 'level1'";
        //cmnd.ExecuteNonQuery();

        //cmnd.CommandText = "UPDATE life set life_four = " + life4 + " WHERE id = 'level1'";
        //cmnd.ExecuteNonQuery();

        //cmnd.CommandText = "UPDATE life set life_five = " + life5 + " WHERE id = 'level1'";
        //cmnd.ExecuteNonQuery();
    }
}
