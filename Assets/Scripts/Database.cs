using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;

public class Database : MonoBehaviour
{
    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    private IDataReader reader;

    string DatabaseName = "BallZ_Db.s3db";

    //Updates in High Score
    public static bool changeHighScore;
    public static bool updateScoreConfirm;
    public static string selectHighScore;

    //Updates in Life
    public static string lostTime;
    public static string column;
    public static bool increase;

    void Awake()
    {
        changeHighScore = true;
        updateScoreConfirm = false;
        lostTime = "null";
        column = null;
        selectHighScore = null;
        increase = false;

        //Application database Path android
        string filepath = Application.persistentDataPath + "/" + DatabaseName;

        if (!File.Exists(filepath))
        {
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/BallZ_Db");

            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/BallZ_Db.s3db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);

            CreateTables();
        }

        conn = "URI=file:" + filepath;

        dbconn = new SqliteConnection(conn);
        dbconn.Open();

        SearchHighScore("1");
        SearchLife("1");
    }

    //Create
    private void CreateTables()
    {
        string query;

        query = "CREATE TABLE High_Score (id TEXT PRIMARY KEY, highest TEXT)";
        try
        {
            dbcmd = dbconn.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();

            InsertHighestScore("1", "0");

            Debug.Log("High Score Table Created With Values");
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        query = "CREATE TABLE life (id TEXT PRIMARY KEY, life_One TEXT, life_Two TEXT, life_Three TEXT, life_Four TEXT, life_Five TEXT)";
        try
        {
            dbcmd = dbconn.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();

            InsertLife("1", "null", "null", "null", "null", "null");

            Debug.Log("Life Table Created With Values");
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    //Delete
    public void Delete_button(string db, string id)
    {
        if (string.Equals(db, "highest"))
        {
            DeleteHighScore(id);
        }
        else if (string.Equals(db, "life"))
        {
            DeleteLife(id);
        }
    }

    //Insert To Highest_Score Database
    public void InsertHighestScore(string id, string highest)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into High_Score (id, highest) values (\"{0}\",\"{1}\")", id, highest);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }

        Debug.Log("Insert Done into Highest Score Table!");
    }

    //Insert To Life Database
    public void InsertLife(string id, string life_One, string life_Two, string life_Three, string life_Four, string life_Five)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into life (id, life_One, life_Two, life_Three, life_Four, life_Five) values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\")", id, life_One, life_Two, life_Three, life_Four, life_Five);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }

        Debug.Log("Insert Done into Life Table!");
    }

    //Search on High Score Table by ID
    private void SearchHighScore(string Search_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            IDbCommand dbcmd = dbconn.CreateCommand();

            string sqlQuery = "SELECT * " + "FROM High_Score where id =" + Search_by_id;
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                DatabaseUpdates.highScore = reader.GetString(1);
            }

            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
    }

    //Search on Life Table by ID
    private void SearchLife(string Search_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            IDbCommand dbcmd = dbconn.CreateCommand();

            string sqlQuery = "SELECT * " + "FROM life where id =" + Search_by_id;
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                DatabaseUpdates.life1 = reader.GetString(1);
                DatabaseUpdates.life2 = reader.GetString(2);
                DatabaseUpdates.life3 = reader.GetString(3);
                DatabaseUpdates.life4 = reader.GetString(4);
                DatabaseUpdates.life5 = reader.GetString(5);
            }

            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
    }

    //Update on High Score Table 
    private void UpdateHighScore(string id, string score)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE High_Score set highest = @highest where ID = @id ");

            SqliteParameter P_update_score = new SqliteParameter("@highest", score);
            SqliteParameter P_update_id = new SqliteParameter("@id", id);

            dbcmd.Parameters.Add(P_update_id);
            dbcmd.Parameters.Add(P_update_score);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();

            Debug.Log("Successfully Updated Datas in High Score Table");
        }
    }

    //Update on Life Table Full Datas
    public void UpdateLife(string id, string life_One, string life_Two, string life_Three, string life_Four, string life_Five)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE life set life_One = @life1 ,life_Two = @life2, life_Three = @life3, life_Four = @life4, life_Five = @life5 where ID = @id ");

            SqliteParameter P_update_life1 = new SqliteParameter("@life1", life_One);
            SqliteParameter P_update_life2 = new SqliteParameter("@life2", life_Two);
            SqliteParameter P_update_life3 = new SqliteParameter("@life3", life_Three);
            SqliteParameter P_update_life4 = new SqliteParameter("@life4", life_Four);
            SqliteParameter P_update_life5 = new SqliteParameter("@life5", life_Five);
            SqliteParameter P_update_id = new SqliteParameter("@id", id);

            dbcmd.Parameters.Add(P_update_life1);
            dbcmd.Parameters.Add(P_update_life2);
            dbcmd.Parameters.Add(P_update_life3);
            dbcmd.Parameters.Add(P_update_life4);
            dbcmd.Parameters.Add(P_update_life5);
            dbcmd.Parameters.Add(P_update_id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();

            Debug.Log("Successfully Updated Datas in Life Table");
        }
    }

    //Update on Life Table Single Column
    public void UpdateLifeColumn(string id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE life set (" + column + ") = @life where ID = @id ");

            SqliteParameter P_update_life = new SqliteParameter("@life", lostTime);
            SqliteParameter P_update_id = new SqliteParameter("@id", id);

            dbcmd.Parameters.Add(P_update_life);
            dbcmd.Parameters.Add(P_update_id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();

            Debug.Log("Successfully Updated Data Column in Life Table");
        }
    }

    //Delete in High Score Table
    private void DeleteHighScore(string Delete_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            IDbCommand dbcmd = dbconn.CreateCommand();

            string sqlQuery = "DELETE FROM High_Score where id =" + Delete_by_id;
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();

            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
    }

    //Delete in Life Table
    private void DeleteLife(string Delete_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            IDbCommand dbcmd = dbconn.CreateCommand();

            string sqlQuery = "DELETE FROM life where id =" + Delete_by_id;
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();

            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
    }

    void Update()
    {
        if (!lostTime.Equals("null"))
        {
            UpdateLifeColumn("1");
            SearchLife("1");
            lostTime = "null";
        }
        else
        {
            if (increase)
            {
                UpdateLifeColumn("1");
                SearchLife("1");
                increase = false;
            }
        }

        if (updateScoreConfirm)
        {
            if (selectHighScore.Equals("dead"))
            {
                UpdateHighScore("1", Points.playerPoints.ToString());
            }
            else if (selectHighScore.Equals("win"))
            {
                UpdateHighScore("1", HighScore.playerWinScore.ToString());
            }
            
            changeHighScore = false;
            updateScoreConfirm = false;
            selectHighScore = null;
        }
    }
}
