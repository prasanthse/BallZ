using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Connection : MonoBehaviour
{
    public static IDbConnection dbcon;
    private Create create;

    void Start()
    {
        dbcon = create.getConnection();
        dbcon.Open();
    }
}
