using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class Login1 : System.Web.UI.Page
    {
        private const string UserSelectQuery = @"select password, id from Users where name=@Name";

        private const string ConnectionString =
            "User id=Admin;Password=Bore$48abs;Server=.;Initial Catalog=StockManagement;";

        private SqlConnection _connection;
        private bool isCorrectUserName = false;
        private bool isCorrectPassword = false;
        private string password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
            isCorrectPassword = false;
            isCorrectUserName = false;
        }

        protected void btnCreateAccountOnClick(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if(isCorrectUserName && isCorrectPassword)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void UserNameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var command = new SqlCommand(UserSelectQuery, _connection);
            command.Parameters.AddWithValue("@Name", txt_Username.Text);
            var reader = command.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                isCorrectUserName = true;
                password = reader[0].ToString();
                Application["Uid"] = Int32.Parse(reader[1].ToString());
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
            reader.Close();
        }

        protected void PasswordValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (password.Equals(txt_password.Text))
            {
                args.IsValid=true;
                isCorrectPassword = true;
            }
            else
            {
                args.IsValid=false;
            }
        }
    }
}