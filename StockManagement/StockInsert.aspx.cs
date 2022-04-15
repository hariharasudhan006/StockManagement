using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const string ConnectionString =
           "User id=Admin;Password=Bore$48abs;Server=.;Initial Catalog=StockManagement;";
        private SqlConnection _connection;
        private const string InsertQuery = @"insert into Stock values(@id, @price, @date, @uid, @mid);";
        private int _manId;
        private bool isManValidated = false;
        private bool isStockValidates = false;
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
            isManValidated = false ;
            isStockValidates = false ;
        }

        protected void ManufacturerNameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var query = @"select id from Manufacturer where name=@name";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", args.Value);
            var reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                args.IsValid = false;
            }
            else
            {
                reader.Read();
                args.IsValid = true;
                _manId = Int32.Parse(reader[0].ToString());
                isManValidated = true;
            }
            reader.Close();
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (isManValidated && isStockValidates)
            {
                var id = Int32.Parse(StockId.Text);
                var price = Int32.Parse(Price.Text);
                var date = DateOfBought.Text;
                var command = new SqlCommand(InsertQuery, _connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@uid", Application["Uid"]);
                command.Parameters.AddWithValue("mid", _manId);
                command.ExecuteNonQuery();
                Application["lastUsedStockId"] = id;
                Response.Redirect("ProductInsert.aspx");
            }
        }

        protected void StockIdValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var command = new SqlCommand(@"select price from Stock where id=@id", _connection);
            command.Parameters.AddWithValue("@id", args.Value);
            var reader = command.ExecuteReader();
            Console.WriteLine("Hello");
            args.IsValid = !reader.HasRows;
            isStockValidates = !reader.HasRows;  
            reader.Close();
        }
    }
}