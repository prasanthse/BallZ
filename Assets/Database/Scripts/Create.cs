using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Create : MonoBehaviour
{
    public void createHighScoreTable()
    {
        IDbCommand dbcmd = Connection.commonConnection.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS high_score (id TEXT PRIMARY KEY, highest INTEGER)";

        dbcmd.CommandText = q_createTable;
        IDataReader reader = dbcmd.ExecuteReader();
    }

    public void createLifeTable()
    {
        IDbCommand dbcmd = Connection.commonConnection.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS life (id TEXT PRIMARY KEY, life_one TEXT, life_two TEXT, life_three TEXT, life_four TEXT, life_five TEXT)";

        dbcmd.CommandText = q_createTable;
        IDataReader reader = dbcmd.ExecuteReader();
    }

}
