using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Connection : MonoBehaviour
{
    public static IDbConnection commonConnection = null;
    private Create dbCreate;
    private IDbConnection dbcon;

    private UpdateTables updateTables;

    void Start()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/BallZ.s3db";

        dbcon = new SqliteConnection(connection);
        dbcon.Open();

        commonConnection = dbcon;

        //updateTables = new UpdateTables();

        //updateTables.updateLife("1", "2", DateTime.Now.ToString(), "4", "5");
        //Debug.Log("updated");      
    }
}
