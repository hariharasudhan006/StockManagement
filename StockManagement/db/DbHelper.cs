using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockManagement.db
{
    public class DBHelper
    {
        public static DBHelper Helper = null;

        public static void StartDb()
        {
            Helper = new DBHelper();
        }

        private const string ConnectionString = "User id=Admin;Password=Bore$48abs;Server=.;Initial Catalog=StockManagement;";
        private readonly SqlConnection _connection;
        private DBHelper()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        public bool IsUsernameExists(string username)
        {
            var command = new SqlCommand(Queries.PasswordSelectionQuery, _connection);
            command.Parameters.AddWithValue("@Name", username);
            var reader = command.ExecuteReader();
            var res = reader.HasRows;
            reader.Close();
            return res;
        }

        public int? GetUserId(string username)
        {
            var command = new SqlCommand(Queries.UserIdSelectionQuery, _connection);
            command.Parameters.AddWithValue("@Name", username);
            var reader = command.ExecuteReader();
            if (!reader.HasRows || !reader.Read())
            {
                reader.Close();
                return null;
            }
            var res = int.Parse(reader["id"].ToString());
            reader.Close();
            return res;
        }

        public string GetPassword(string username)
        {
            var pass = "";
            var command = new SqlCommand(Queries.PasswordSelectionQuery, _connection);
            command.Parameters.AddWithValue("@Name", username);
            var reader = command.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                pass = reader["password"].ToString();
            }
            reader.Close();
            return pass;
        }

        public SqlDataReader GetHomePageTable(string userId)
        {
            var command = new SqlCommand(Queries.SelectHomeTable, _connection);
            command.Parameters.AddWithValue("@uid", userId);
            return command.ExecuteReader();
        }

        public void CloseDb()
        {
            _connection.Close();
        }
    }
}