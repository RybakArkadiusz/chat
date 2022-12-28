using System.Data;
using MySql.Data.MySqlClient;

namespace server;

public class DbManager
{
    private static DbManager instance;
    
    private static string server = "localhost";
    private static string database = "testdb";
    private static string user = "root";
    private static string password = "";//I ain't leaking my password lol
    private static string costring;
    private static MySqlConnection sqlConnection;

    private DbManager()
    {
        costring = "SERVER="+server+";"+"DATABASE="+database+";"+"UID="+user+";"+"PASSWORD="+password+";";
        sqlConnection = new MySqlConnection(costring);
    }

    public static DbManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DbManager();
            }

            return instance;
        }
    }

    public DataSet Select(string query)
    {
        var dataSet = new DataSet();
        sqlConnection.Open();
        using (var adapter = new MySqlDataAdapter(query, sqlConnection))
        {
            adapter.Fill(dataSet);
        }

        sqlConnection.Close();

        return dataSet;
    }
    public void Insert(string query)
    {
        sqlConnection.Open();
        
        using (var command = new MySqlCommand(query, sqlConnection))
        {
            command.ExecuteNonQuery();
        }

        sqlConnection.Close();
    }
}