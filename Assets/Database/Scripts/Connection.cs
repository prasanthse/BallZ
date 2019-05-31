using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Connection : MonoBehaviour
{
    public static IDbConnection commonConnection = null;
    private Create dbCreate;
    private IDbConnection dbcon;

    void Start()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/BallZ.s3db";
        dbcon = new SqliteConnection(connection);
       
        dbcon.Open();

        commonConnection = dbcon;
    }
}
