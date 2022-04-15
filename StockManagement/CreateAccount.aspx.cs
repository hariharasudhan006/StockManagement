using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace StockManagement
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        private const string UserInsertQuery = @"insert into Users values(@name, @password);";

        private const string ConnectionString =
            "User id=Admin;Password=Bore$48abs;Server=.;Initial Catalog=StockManagement;";
        private SqlConnection _connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        protected void btnLoginOnClick(object sender, EventArgs e)
        {
            var username = txt_Username.Text;
            var password = txt_password.Text;
            var command = new SqlCommand(UserInsertQuery, _connection);
            command.Parameters.AddWithValue("@name", username);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
            command = new SqlCommand("select id from Users where name=@name", _connection);
            command.Parameters.AddWithValue("@name", username);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                Application["Uid"] = Int32.Parse(reader[0].ToString());
            }
            reader.Close();
            Response.Redirect("Home.aspx");
        }

        private string _generateHash(string plainText)
        {
            var encoding = new UnicodeEncoding();
            var hasher = new SHA512Managed();
            return encoding.GetString(hasher.ComputeHash(encoding.GetBytes(plainText)));
        }

        protected void GotoLoginPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}