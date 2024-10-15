using SudarshanSolar.DbCode;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class SelectDivision : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                               ShowDivisions();

            }

        }

        public void ShowDivisions()
        {
            try
            {
                DataTable dt = new DataTable();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varDivisionId as 'Division Code', varDivisionName as 'Division Name', varDivisionWork as 'Division Work' FROM tblamsdivision WHERE 1", dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                adp.Fill(dt);
                lstDivisions.DataSource = dt;
                lstDivisions.DataBind();
                dbc.con.Close();
            }
            catch (Exception s)
            {
                Response.Write(s.Message);
                Response.Write("<script>alert('Please Try Again');</script>");
            }
        }

        protected void lstDivisions_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                string commandArgs = e.CommandArgument.ToString();
                Session.Add("vibhag", commandArgs);
                if (e.CommandName == "newEntry")
                {
                    Response.Redirect("NewEntry.aspx", false);
                }
                else if (e.CommandName == "previousEntry")
                {
                    Response.Redirect("PreviousEntries.aspx", false);
                }
                else if (e.CommandName == "printEntry")
                {
                    Response.Redirect("PrintEntries.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}