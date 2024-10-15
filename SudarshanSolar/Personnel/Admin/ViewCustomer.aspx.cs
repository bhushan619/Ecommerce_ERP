using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SudarshanSolar.DbCode;
using System.Data;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class ViewCustomer : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                BindListView();
                notifications();
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        public void notifications()
        {
          //  lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
        }
        public void BindListView()
        {
            SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM anuvaa_solar.tblsucustomer where varStatus!='-' ORDER BY intId";
            //if (Cache["pageno"].ToString() != null) /// set datapager to page 2
            //{
                int pages = Convert.ToInt32(Cache["pageno"]);
                DataPager1.SetPageProperties(pages * DataPager1.PageSize, DataPager1.MaximumRows, false);
            //}
        }
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            int pages = e.StartRowIndex / e.MaximumRows;
           // Session.Add("pageno", pages);

            Cache["pageno"] = pages;

            this.BindListView();
        }
        protected void listproduct_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string id = commandArgs[0];
            string stat = commandArgs[1];

            if (e.CommandName == "Edits")
            {
                Cache["custbyadmin"] = id;// e.CommandArgument.ToString();
                Response.Redirect("~/Personnel/admin/EditCustomer.aspx", false);
                // Cache["pageno"] = e.MaximumRows;
                //Session.Add("custbyadmin", id);
                ////Session["pageno"] = e.MaximumRows;
                //Response.Redirect("EditCustomer.aspx");
            }
            else
            if (e.CommandName == "Updates")
            {
                if (stat == "Whitelist")
                {
                    dbc.Update_CustomerStatus(Convert.ToInt32(id), "Blacklist");

                }
                else
                {
                    dbc.Update_CustomerStatus(Convert.ToInt32(id), "Whitelist");
                }
            }
            //else if (e.CommandName == "Deletes")
            //{
            //    dbc.con.Open();
            //    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("update  anuvaa_solar.tblsucustomer set varStatus='Deleted' WHERE intId=" + id + "", dbc.con);
            //    cmd.ExecuteReader();
            //    dbc.con.Close();
            //}
            SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM anuvaa_solar.tblsucustomer  where varStatus!='-' ORDER BY intId";
            listcust.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCmpName.Text == "")
                {
                    MessageDisplay(Resources.Common.Select, "alert dark  alert-dismissible  alert-danger");

                  //  Response.Write("<script>alert('Please select company Name');window.location='ViewCustomer.aspx';</script>");
                }
                else
                {
                    string[] arry = txtCmpName.Text.Split(new char[] { '_' });

                    SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM anuvaa_solar.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "' and varStatus!='-'";

                    listcust.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
        {
            String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["solarConnectionString"].ConnectionString;

            MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varCompanyName,'_',varCity) as  varCompanyName FROM anuvaa_solar.tblsucustomer where varCompanyName like '%" + prefixText + "%' AND intId between 1 and 500", con);
            //     cmd.Parameters.AddWithValue("@Name", prefixText);
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            MySql.Data.MySqlClient.MySqlConnection con1 = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varCompanyName,'_',varCity) as  varCompanyName FROM anuvaa_solar.tblsucustomer where varCompanyName like '%" + prefixText + "%'  AND intId between 501 and 1000", con1);
            //     cmd.Parameters.AddWithValue("@Name", prefixText);
            MySql.Data.MySqlClient.MySqlDataAdapter da1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            List<string> CompanyName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CompanyName.Add(dt.Rows[i][0].ToString());
                //  CompanyName[j++] =dt.Rows[i][0].ToString();
            }
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                CompanyName.Add(dt1.Rows[i][0].ToString());
                //  CompanyName[j++] =dt.Rows[i][0].ToString();
            }
            con.Close();
            con1.Close();
            return CompanyName;
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSort.Text == "- Sort By-")
            {
                Response.Write("<script>alert('Please Select a list');window.location='ViewCustomer.aspx';</script>");
            }
            else if (ddlSort.Text == "Blacklist")
            {
                SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM anuvaa_solar.tblsucustomer where varStatus!='-' ORDER BY varStatus ASC";

                listcust.DataBind();
            }
            else if (ddlSort.Text == "Whitelist")
            {
                SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM anuvaa_solar.tblsucustomer where varStatus!='-' ORDER BY varStatus DESC";

                listcust.DataBind();
            }
        }
    }
}