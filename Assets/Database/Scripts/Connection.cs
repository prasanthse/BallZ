using UnityEngine;
using System;
//using System.Data;
//using Mono.Data.Sqlite;

public class Connection : MonoBehaviour
{
    //IDbConnection dbcon;
    //IDbCommand dbcmd;
    //IDataReader reader;

    //void Start()
    //{
    //    string connection = "URI=file:" + Application.persistentDataPath + "/Database/BallZ_Database.s3db";
    //    //dbcon = new SqliteConnection(connection);
    //    using (dbcon = new SqliteConnection(connection))
    //    {
    //        dbcon.Open();
    //        Debug.Log("Database Connected");

    //        createHighScoreTable();
    //        createLifeTable();
    //    }
            
    //}

    ////Create Tables
    //public void createHighScoreTable()
    //{
    //    dbcmd = dbcon.CreateCommand();
    //    string q_createTable = "CREATE TABLE IF NOT EXISTS high_score (id TEXT PRIMARY KEY, highest INTEGER)";

    //    dbcmd.CommandText = q_createTable;
    //    reader = dbcmd.ExecuteReader();
    //}

    //public void createLifeTable()
    //{
    //    dbcmd = dbcon.CreateCommand();
    //    string q_createTable = "CREATE TABLE IF NOT EXISTS life (id TEXT PRIMARY KEY, life_one TEXT, life_two TEXT, life_three TEXT, life_four TEXT, life_five TEXT)";

    //    dbcmd.CommandText = q_createTable;
    //    reader = dbcmd.ExecuteReader();
    //}

    ////Drop Tables
    //public void DropHighScoreTable()
    //{
    //    dbcmd = dbcon.CreateCommand();

    //    dbcmd.CommandText = "DROP TABLE high_score";
    //    dbcmd.ExecuteNonQuery();
    //}

    //public void DropLifeTable()
    //{
    //    dbcmd = dbcon.CreateCommand();

    //    dbcmd.CommandText = "DROP TABLE life";
    //    dbcmd.ExecuteNonQuery();
    //}

    ////Insert Datas
    //public void insertHighScore(int score)
    //{
    //    dbcmd = dbcon.CreateCommand();

    //    dbcmd.CommandText = "INSERT INTO high_score (id, highest) VALUES ('level1', 0)";
    //    dbcmd.ExecuteNonQuery();
    //}

    //public void insertLifeInfo(string life1, string life2, string life3, string life4, string life5)
    //{
    //    dbcmd = dbcon.CreateCommand();

    //    dbcmd.CommandText = "INSERT INTO life (id, life_one, life_two, life_three, life_four, life_five) VALUES ('level1', @value1, @value2, @value3, @value4, @value5)";
    //    dbcmd.CommandType = CommandType.Text;

    //    //cmnd.Parameters.Add(new SqliteParameter("@value1", life1));
    //    //cmnd.Parameters.Add(new SqliteParameter("@value2", life2));
    //    //cmnd.Parameters.Add(new SqliteParameter("@value3", life3));
    //    //cmnd.Parameters.Add(new SqliteParameter("@value4", life4));
    //    //cmnd.Parameters.Add(new SqliteParameter("@value5", life5));

    //    dbcmd.ExecuteNonQuery();
    //}

    ////Retrieve Datas
    //public void getLifeInfo()
    //{
    //    dbcmd = dbcon.CreateCommand();

    //    string query = "SELECT * FROM life where id = 'level1'";
    //    dbcmd.CommandText = query;
    //    reader = dbcmd.ExecuteReader();

    //    while (reader.Read())
    //    {
    //        Debug.Log("life1: " + reader[1].ToString());
    //        Debug.Log("life2: " + reader[2].ToString());
    //        Debug.Log("life3: " + reader[3].ToString());
    //        Debug.Log("life4: " + reader[4].ToString());
    //        Debug.Log("life5: " + reader[5].ToString());
    //    }
    //}

    //public string getHighScore()
    //{
    //    dbcmd = dbcon.CreateCommand();

    //    string query = "SELECT highest FROM high_score where id = 'level1'";
    //    dbcmd.CommandText = query;
    //    reader = dbcmd.ExecuteReader();

    //    string score = reader[0].ToString();

    //    return score;
    //}

    ////Update Tables
    //public void updateHighScore(int number)
    //{
    //    dbcmd = dbcon.CreateCommand();

    //    dbcmd.CommandText = "UPDATE high_score set highest = " + number + " WHERE id = 'level1'";
    //    dbcmd.ExecuteNonQuery();
    //}

    //public void updateLife(string life1, string life2, string life3, string life4, string life5)
    //{
    //    dbcmd = dbcon.CreateCommand();

    //    dbcmd.CommandText = "UPDATE life set life_one = @value1 WHERE id = 'level1'";
    //    dbcmd.CommandType = CommandType.Text;
    //    //cmnd.Parameters.Add(new SqliteParameter("@value1", life1));
    //    dbcmd.ExecuteNonQuery();

    //    //cmnd.CommandText = "UPDATE life set life_two = " + life2 + " WHERE id = 'level1'";
    //    //cmnd.ExecuteNonQuery();

    //    //cmnd.CommandText = "UPDATE life set life_three = " + life3 + " WHERE id = 'level1'";
    //    //cmnd.ExecuteNonQuery();

    //    //cmnd.CommandText = "UPDATE life set life_four = " + life4 + " WHERE id = 'level1'";
    //    //cmnd.ExecuteNonQuery();

    //    //cmnd.CommandText = "UPDATE life set life_five = " + life5 + " WHERE id = 'level1'";
    //    //cmnd.ExecuteNonQuery();
    //}
}
