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
    public partial class ViewAccounts : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        DataTable dt = new DataTable();
        static Int16 divid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                ShowAccount();
                myform.Enabled = false;
            }
        }
    
        public void ShowAccount()
        {
            try
            {
                DataTable dt = new DataTable();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varAccountNo as 'Account Code', varAccountName as 'Account  Name', varMobile as 'Mobile No',varPhone as 'Phone No',	varEmail as 'Email',varAddress as 'Address' FROM tblamsaccountpersonnel ", dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                adp.Fill(dt);
                gdvAccount.DataSource = dt;
                gdvAccount.DataBind();
                dbc.con.Close();
            }
            catch (Exception s)
            {
                Response.Write(s.Message);
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        protected void gdvAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvAccount.PageIndex = e.NewPageIndex;
            ShowAccount();
        }

        protected void gdvAccount_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string commandArgs = e.CommandArgument.ToString();

                if (e.CommandName == "Edits")
                {
                    myform.Enabled = true;
                    // Response.Redirect("~/clerk/EditDivision.aspx?param=" + e.CommandArgument.ToString() + "");
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varAccountNo as 'Account Code', varAccountName as 'Account  Name', varMobile as 'Mobile No',varPhone as 'Phone No',	varEmail as 'Email',varAddress as 'Address' FROM tblamsaccountpersonnel  where intId=" + e.CommandArgument.ToString() + "", dbc.con);

                    dbc.dr = cmd.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        divid = Convert.ToInt16(dbc.dr["intId"].ToString());
                        txtacccode.Text = dbc.dr["Account Code"].ToString();
                        txtaccname.Text = dbc.dr["Account  Name"].ToString();
                        txtaccmobile.Text = dbc.dr["Mobile No"].ToString();
                        txtaccphone.Text = dbc.dr["Phone No"].ToString();
                        txtaccEmail.Text = dbc.dr["Email"].ToString();
                        txtaccaddress.Text = dbc.dr["Address"].ToString();

                    }
                    dbc.con.Close();
                }

                else if (e.CommandName == "Deletes")
                {
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamsaccountpersonnel WHERE intId=" + e.CommandArgument.ToString() + "", dbc.con);
                    cmd.ExecuteReader();
                    MessageDisplay("Account Deleted Successfully", "alert dark  alert-success alert-dismissible");
                  
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
                    MessageDisplay("Please Select Account", "alert dark  alert-success alert-dismissible");
                   
                }
                else
                {
                    string[] arry = txtCmpName.Text.Split(new char[] { '_' });

                    DataTable dt = new DataTable();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

                    cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varAccountNo as 'Account Code', varAccountName as 'Account  Name', varMobile as 'Mobile No',varPhone as 'Phone No',	varEmail as 'Email',varAddress as 'Address' FROM tblamsaccountpersonnel WHERE varAccountNo='" + arry[0] + "'  AND  varAccountName='" + arry[1] + "'", dbc.con);
                    MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    gdvAccount.DataSource = dt;
                    gdvAccount.DataBind();
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varAccountNo,'_', varAccountName) as  varAccountName FROM tblamsaccountpersonnel where varAccountName like '%" + prefixText + "%' AND intId between 1 and 500", con);
            //     cmd.Parameters.AddWithValue("@Name", prefixText);
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            MySql.Data.MySqlClient.MySqlConnection con1 = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varAccountNo, '_', varAccountName) as varAccountName FROM tblamsaccountpersonnel where varAccountName like '%" + prefixText + "%' AND intId  between 501 and 1000", con1);
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
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                CompanyName.Add(dt1.Rows[i][0].ToString());
                //  CompanyName[j++] =dt.Rows[i][0].ToString();
            }
            con.Close();
            con1.Close();
            return CompanyName;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            //txtCmpName.Text = "";
            //ShowAccount();
            Response.Redirect("ViewAccounts.aspx", false);
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int insert_ok = dbc.Update_tblamsaccountpersonnel(divid, txtaccname.Text, txtaccmobile.Text, txtaccphone.Text, txtaccEmail.Text, txtaccaddress.Text);

                if (insert_ok == 1)
                {
                    MessageDisplay("Account Updated Successfully!!!", "alert dark  alert-success alert-dismissible");
                   
                }
            }

            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAccounts.aspx", false);
        }
    }
}