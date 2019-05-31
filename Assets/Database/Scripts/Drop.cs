using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class Drop : MonoBehaviour
{
    public void DropHighScoreTable()
    {
        IDbCommand cmnd = Connection.commonConnection.CreateCommand();

        cmnd.CommandText = "DROP TABLE high_score";
        cmnd.ExecuteNonQuery();
    }

    public void DropLifeTable()
    {
        IDbCommand cmnd = Connection.commonConnection.CreateCommand();

        cmnd.CommandText = "DROP TABLE life";
        cmnd.ExecuteNonQuery();
    }
}
