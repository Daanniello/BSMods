using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace BSMods
{
    class DBConnection
    {
        public MySqlConnection _connection;

        public DBConnection()
        {
            var connectionString = ConfigurationManager.DBConnectionString;
            _connection = new MySqlConnection(connectionString);
            

            //InsertTest();
        }

        private void InsertTest()
        {
            _connection.Open();
            MySqlCommand comm = _connection.CreateCommand();
            comm.CommandText = "INSERT INTO Mods(Mod_Name,Mod_URL,User_ID) VALUES(@person, @address, @id)";
            comm.Parameters.AddWithValue("@person", "Myname");
            comm.Parameters.AddWithValue("@address", "Myaddress");
            comm.Parameters.AddWithValue("@id", "4");
            comm.ExecuteNonQuery();
            _connection.Close();
        }

        public bool Login(string username, string password)
        {
            _connection.Open();

            MySqlCommand comm = _connection.CreateCommand();
            comm.CommandText = "SELECT * FROM Mods(Mod_Name,Mod_URL,User_ID) VALUES(@person, @address, @id)";
            comm.Parameters.AddWithValue("@person", "Myname");
            comm.Parameters.AddWithValue("@address", "Myaddress");
            comm.Parameters.AddWithValue("@id", "4");
            comm.ExecuteNonQuery();
            _connection.Close();

            return false;
        }
    }
}
