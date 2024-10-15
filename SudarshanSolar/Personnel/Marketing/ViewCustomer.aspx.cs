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

namespace SudarshanSolar.Personnel.Marketing
{
    public partial class ViewCustomer : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        public static string empdesig = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
              
             
                notifications();
                //   getCustomerList();
                SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM anuvaa_solar.tblsucustomer where varStatus!='-' ORDER BY intId";
                listcust.DataBind();
            }
        }
        public void notifications()
        {
           // lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["empid"].ToString()), empdesig).ToString();
        }
       
        public void BindListView()
        {
            SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM anuvaa_solar.tblsucustomer where varStatus!='-' ORDER BY intId";
            listcust.DataBind();
        }
        DatabaseConnection dbc = new DatabaseConnection();

       
       
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (listcust.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView();
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
                if (txtCmpName.Text == "")
                {
                    MessageDisplay(Resources.Common.Select, "alert dark  alert-dismissible  alert-danger");

                    //  Response.Write("<script>alert('Please select company Name');window.location='ViewCustomer.aspx';</script>");
                }
                else
                {
                    string[] arry = txtCmpName.Text.Split(new char[] { '_' });
                    SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM anuvaa_solar.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "'";

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
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varCompanyName,'_',varCity) as  varCompanyName FROM anuvaa_solar.tblsucustomer where varCompanyName like '%" + prefixText + "%' AND intId between 501 and 1000", con1);
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

    }
}