using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagement.db;

namespace StockManagement
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session["uid"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
            ShowGridView();
        }

        protected bool ShowNothingLabel()
        {
            return false;
        }

        private void ShowGridView()
        {
            var reader = DBHelper.Helper.GetHomePageTable(Session["uid"].ToString());
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
            if (e.Row.RowType != DataControlRowType.Header) return;
            e.Row.Cells[0].Text = "Stock ID";
            e.Row.Cells[1].Text = "Product ID";
            e.Row.Cells[2].Text = "Product name";
            e.Row.Cells[3].Text = "Price per product";
            e.Row.Cells[4].Text = "stock price";
            e.Row.Cells[5].Text = "Manufacturer name";
        }
    }
}