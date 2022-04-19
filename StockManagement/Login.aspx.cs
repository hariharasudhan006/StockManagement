using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagement.db;

namespace StockManagement
{
    public partial class Login1 : System.Web.UI.Page
    {
        private const string UserSelectQuery = @"select password, id from Users where name=@Name";

        private const string ConnectionString =
            "User id=Admin;Password=Bore$48abs;Server=.;Initial Catalog=StockManagement;";

        private SqlConnection _connection;
        private bool _isCorrectUserName = false;
        private bool _isCorrectPassword = false;
        private string _password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
            _isCorrectPassword = false;
            _isCorrectUserName = false;
            Session["username"] = null;
            Session["uid"] = null;
        }

        protected void btnCreateAccountOnClick(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (!_isCorrectUserName || !_isCorrectPassword) return;
            Session["uid"] = DBHelper.Helper.GetUserId(txt_Username.Text);
            Session["username"] = txt_Username.Text;
            Response.Redirect("Home.aspx");
        }

        protected void UserNameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DBHelper.Helper.IsUsernameExists(txt_Username.Text))
            {
                _isCorrectUserName = true;
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void PasswordValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            _password = DBHelper.Helper.GetPassword(txt_Username.Text);
            if (_password.Equals(txt_password.Text))
            {
                args.IsValid=true;
                _isCorrectPassword = true;
            }
            else
            {
                args.IsValid=false;
            }
        }
    }
}