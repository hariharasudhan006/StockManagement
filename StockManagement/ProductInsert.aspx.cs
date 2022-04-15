using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private const string ConnectionString =
          "User id=Admin;Password=Bore$48abs;Server=.;Initial Catalog=StockManagement;";
        private SqlConnection _connection;
        private const string InsertQuery = @"insert into Product values(@id, @name, @price, @sid);";
        private bool isProductIdValidated = false;
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
            try
            {
                if (Application["lastUsedStockId"] == null)
                {
                    Response.Redirect("StockInsert.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("StockInsert.aspx");
            }
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
            isProductIdValidated = false;
        }

        protected void ProductIdValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var command = new SqlCommand(@"select id from Product where id=@id;", _connection);
            command.Parameters.AddWithValue("@id", args.Value);
            var reader = command.ExecuteReader();
            args.IsValid = !reader.HasRows;
            isProductIdValidated = !reader.HasRows;
            reader.Close();
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (isProductIdValidated)
            {
                var id = Int32.Parse(ProductId.Text);
                var name = NameOfTheProduct.Text;
                var price = Int32.Parse(PricePerProduct.Text);
                var n = Int32.Parse(NoOfThisProduct.Text);
                for (var i = 0; i < n; i++)
                {
                    var command = new SqlCommand(InsertQuery, _connection);
                    command.Parameters.AddWithValue("@id", id++);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@sid", Application["lastUsedStockId"]);
                    command.ExecuteNonQuery();
                }
                Application["lastUsedStockId"] = null;
                Response.Redirect("Home.aspx");
            }
        }
    }
}