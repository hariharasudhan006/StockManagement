using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class Manufacturer : System.Web.UI.Page
    {
        private const string ConnectionString =
         "User id=Admin;Password=Bore$48abs;Server=.;Initial Catalog=StockManagement;";
        private SqlConnection _connection;
        private const string InsertQuery = @"insert into Manufacturer values(@id, @name, @address);";
        private bool isNameValidated = false;
        private bool isIdValidated = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Application["Uid"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        protected void ManufacturerId_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var query = @"select id from Manufacturer where id=@id";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", args.Value);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
                isIdValidated = true;
            }
            reader.Close();
        }

        protected void ManfacturerNameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var query = @"select id from Manufacturer where name=@name";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", args.Value);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
                isNameValidated = true;
            }
            reader.Close();
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (isIdValidated && isNameValidated)
            {
                var command = new SqlCommand(InsertQuery, _connection);
                var id = Int32.Parse(ManufacturerID.Text);
                var name = ManufacturerName.Text;
                var address = Address.Text;
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@address", address);
                command.ExecuteNonQuery();
                Response.Redirect("Home.aspx");
            }
        }
    }
}