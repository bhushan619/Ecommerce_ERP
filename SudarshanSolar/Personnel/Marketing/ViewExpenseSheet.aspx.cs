using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using SudarshanSolar.DbCode;

namespace SudarshanSolar.Personnel.Marketing
{
    public partial class ViewExpenseSheet : System.Web.UI.Page
    {
        RegexUtilities rex = new RegexUtilities();
        DatabaseConnection dbc = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                notifications();
                getExpenseSheets();

            }
        }
        public void notifications()
        {
           // lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["empid"].ToString()), empdesig).ToString();
        }
        public void getExpenseSheets()
        {
            try
            {
                dbc.con.Open();
                DataTable view = new DataTable();
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySqlDataAdapter("SELECT intId,  dtStartDate as 'Start Date', dtEndDate as 'End Date', nvarLocation as 'Location', nvarTotalExpense as 'Total Expenses' FROM tblsuexpenses WHERE intEmpId=" + rex.DecryptString(Request.Cookies["LoginId"].Value) + "", dbc.con);
                adp.Fill(view);
                grdView.DataSource = view;
                grdView.DataBind();
                grdView.Columns[0].Visible = false;
                dbc.con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please Try Again');</script>");
            }
        }
        protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "edits")
                {
                    int expenseId = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("~/Personnel/marketing/ViewEmployeeExpenses.aspx?expenseId=" + expenseId + "", false);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some error please try again ..!!');window.location='ExpenseSheet.aspx';</script>");
            }
        }
    }
}