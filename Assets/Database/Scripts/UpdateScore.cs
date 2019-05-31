using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class UpdateScore : MonoBehaviour
{
    public void updateHighScore(int number)
    {
        IDbCommand cmnd = Connection.commonConnection.CreateCommand();

        cmnd.CommandText = "UPDATE high_score set highest = " + number + " WHERE id = 'level1'";
        cmnd.ExecuteNonQuery();
    }
}
