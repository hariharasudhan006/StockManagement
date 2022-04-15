using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class Home : System.Web.UI.Page
    {
        private const string ConnectionString =
            "User id=Admin;Password=Bore$48abs;Server=.;Initial Catalog=StockManagement;";

        private const string SelectQuery = @"select Stock.id, Product.id, Product.Name, Product.pricePerUnit, Stock.price, Manufacturer.name 
from ((Stock INNER JOIN Product on Stock.id = Product.stockId and Stock.userId = @uid) INNER JOIN Manufacturer on Stock.manufactorerId = Manufacturer.id);";

        private SqlConnection _connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Application["Uid"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
            ShowGridView();
        }

        protected bool ShowNothingLabel()
        {
            return false;
        }

        protected void ShowGridView()
        {
            var command = new SqlCommand(SelectQuery, _connection);
            command.Parameters.AddWithValue("@uid", Application["Uid"]);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                ContentGrid.DataSource = reader;
                ContentGrid.DataBind();
            }
            else
            {
                NothingLabel.Text = "Nothing Here.";
            }
            reader.Close();
        }

        protected void ContentGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Stock ID";
                e.Row.Cells[1].Text = "Product ID";
                e.Row.Cells[2].Text = "Product name";
                e.Row.Cells[3].Text = "Price per product";
                e.Row.Cells[4].Text = "stock price";
                e.Row.Cells[5].Text = "Manufacturer name";
            }
        }
    }
}