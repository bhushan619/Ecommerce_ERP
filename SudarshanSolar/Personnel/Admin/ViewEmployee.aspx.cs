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
using SudarshanSolar.DbCode;

using System.Data.SqlClient;
using System.Web.Services;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class ViewEmployee : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //notifications();
            }
            getemployeedata();

        }

        public void getemployeedata()
        {
   SqlDataSource2.SelectCommand = "SELECT varName, varMobile, varEmail, varAddress, varCity,varSubDesig,intId FROM anuvaa_solar.tblsupersonnel where varDesignation='employee' and varStatus!='-' ORDER BY intId";
            listemp.DataBind();
        }
        public void notifications()
        {
            // lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
        }


        public void BindListView()
        {
            SqlDataSource2.SelectCommand = "SELECT varName, varMobile, varEmail, varAddress, varCity,varSubDesig,intId FROM anuvaa_solar.tblsupersonnel where varDesignation='employee' and varStatus!='-' ORDER BY intId";
            listemp.DataBind();
        }
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (listemp.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView();
        }

        protected void listproduct_ItemCommand(object sender, ListViewCommandEventArgs e)
        {


            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string id = commandArgs[0];

            if (e.CommandName == "Edits")
            {
                Cache["EmployeeProfile"] = id;// e.CommandArgument.ToString();
                Response.Redirect("~/Personnel/admin/EditEmp.aspx", false);

                //Session.Add("empbyadmin", id);
                //Response.Redirect("EditEmp.aspx");
            }

            else if (e.CommandName == "Deletes")
            {
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from anuvaa_solar.tblsupersonnel WHERE intId=" + id + "", dbc.con);
                cmd.ExecuteReader();
                dbc.con.Close();
                cmd.Dispose();

                MessageDisplay(Resources.Messages.Deleted, "alert dark  alert-dismissible  alert-success");

                //dbc.con.Open();
                //cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblsuorder SET intEmpId = 4 WHERE tblsuorder.intEmpId  = " + id + "", dbc.con);
                //cmd.ExecuteReader();
                //dbc.con.Close();
            }
            getemployeedata();
         
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
        {
            String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["solarConnectionString"].ConnectionString;

            MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT Distinct varName FROM anuvaa_solar.tblsupersonnel where varDesignation='employee' and varName like '%" + prefixText + "%'", con);
            //     cmd.Parameters.AddWithValue("@Name", prefixText);
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int j = 0;
            List<string> CompanyName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CompanyName.Add(dt.Rows[i][0].ToString());
                //  CompanyName[j++] =dt.Rows[i][0].ToString();
            }
            con.Close();
            return CompanyName;
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //dbc.con.Open();
                //MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName, varMobile, varEmail, varAddress, varCity,varSubDesig, intId FROM anuvaa_solar.tblsupersonnel where varDesignation='employee' and varName like '%" + txtCmpName.Text + "%'", dbc.con);
                //MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                //ad.Fill(dt);
                //listemp.DataSource = dt;
                //listemp.DataBind();
                //dbc.con.Close();
                if (txtCmpName.Text == "")
                {
                    MessageDisplay(Resources.Common.Select, "alert dark  alert-dismissible  alert-danger");

                }
                else
                {
                    SqlDataSource2.SelectCommand = "SELECT varName, varMobile, varEmail, varAddress, varCity,varSubDesig,intId FROM anuvaa_solar.tblsupersonnel where varDesignation='employee' and varStatus!='-' and varName like '%" + txtCmpName.Text + "%'";
                    listemp.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}