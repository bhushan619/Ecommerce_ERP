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
    public partial class ViewDivisions : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        DataTable dt = new DataTable();
        static Int16 divid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
         if (!IsPostBack)
            {
                
                ShowDivisions();
                myform.Enabled = false;
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        public void ShowDivisions()
        {
            try
            {
                DataTable dt = new DataTable();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varDivisionId as 'Division Code', varDivisionName as 'Division Name', varDivisionWork as 'Division Work' FROM tblamsdivision WHERE 1", dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                adp.Fill(dt);
                gdvDivision.DataSource = dt;
                gdvDivision.DataBind();
                dbc.con.Close();
            }
            catch (Exception s)
            {
                Response.Write(s.Message);
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
        protected void gdvDivision_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvDivision.PageIndex = e.NewPageIndex;
            ShowDivisions();
        }

        protected void gdvDivision_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string commandArgs = e.CommandArgument.ToString();

                if (e.CommandName == "Edits")
                {
                    myform.Enabled = true;
                    // Response.Redirect("~/clerk/EditDivision.aspx?param=" + e.CommandArgument.ToString() + "");
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varDivisionId as 'Division Code', varDivisionName as 'Division Name', varDivisionWork as 'Division Work' FROM tblamsdivision where intId=" + e.CommandArgument.ToString() + "", dbc.con);

                    dbc.dr = cmd.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        divid = Convert.ToInt16(dbc.dr["intId"].ToString());
                        txtdcode.Text = dbc.dr["Division Code"].ToString();
                        txtdname.Text = dbc.dr["Division Name"].ToString();
                        txtdwork.Text = dbc.dr["Division Work"].ToString();

                    }
                    dbc.con.Close();
                }

                else if (e.CommandName == "Deletes")
                {
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamsdivision WHERE intId=" + e.CommandArgument.ToString() + "", dbc.con);
                    cmd.ExecuteReader();
                    MessageDisplay("Division Deleted Successfully", "alert dark  alert-success alert-dismissible");
                  //  Response.Write("<script>alert('');window.location='ViewDivisions.aspx';</script>");
                    dbc.con.Close();
                }
            }
            catch (Exception s)
            {
                Response.Write(s.Message);
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }


        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            try
            {
                if (txtCmpName.Text == "")
                {
                    MessageDisplay("Please Select Division", "alert dark  alert-danger alert-dismissible");
                   
                }
                else
                {
                    string[] arry = txtCmpName.Text.Split(new char[] { '_' });

                    DataTable dt = new DataTable();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

                    cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varDivisionId as 'Division Code', varDivisionName as 'Division Name', varDivisionWork as 'Division Work' FROM tblamsdivision WHERE varDivisionId='" + arry[0] + "'  AND  varDivisionName='" + arry[1] + "'", dbc.con);
                    MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    gdvDivision.DataSource = dt;
                    gdvDivision.DataBind();
                    dbc.con.Close();
                }
            }
            catch (Exception s)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
                txtCmpName.Text = "";
            }
        }


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
        {
            String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["solarConnectionString"].ConnectionString;

            MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varDivisionId,'_',varDivisionName) as  varDivisionName FROM tblamsdivision where varDivisionName like '%" + prefixText + "%' AND intId between 1 and 500", con);
            //     cmd.Parameters.AddWithValue("@Name", prefixText);
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            MySql.Data.MySqlClient.MySqlConnection con1 = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varDivisionId, '_', varDivisionName) as varDivisionName FROM tblamsdivision where varDivisionName like '%" + prefixText + "%' AND intId  between 501 and 1000", con1);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            MySql.Data.MySqlClient.MySqlDataAdapter da1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            List<string> CompanyName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CompanyName.Add(dt.Rows[i][0].ToString());
                //  CompanyName[j++] =dt.Rows[i][0].ToString();
            }
            //for (int i = 0; i < dt1.Rows.Count; i++)
            //{
            //    CompanyName.Add(dt1.Rows[i][0].ToString());
            //    //  CompanyName[j++] =dt.Rows[i][0].ToString();
            //}
            con.Close();
            con1.Close();
            return CompanyName;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            //txtCmpName.Text = "";
            //ShowDivisions();
            Response.Redirect("ViewDivisions.aspx", false);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewDivisions.aspx", false);
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int insert_ok = dbc.Update_tblamsdivision(divid, txtdcode.Text, txtdname.Text, txtdwork.Text);

                if (insert_ok == 1)
                {
                    MessageDisplay("Division Updated Successfully!!!", "alert dark  alert-success alert-dismissible");
                  
                }
            }

            catch (Exception ex)
            {

            }
        }
       
    }
}