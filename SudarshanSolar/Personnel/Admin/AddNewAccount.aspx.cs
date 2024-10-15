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
    public partial class AddNewAccount : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
              
                ShowDivisions();
                txtacccode.Text = (dbc.max_tblamsaccountpersonnel() + 1).ToString();
            }

        }
    
        public void ShowDivisions()
        {
            try
            {
                DataTable dt = new DataTable();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT 	varAccountNo as 'Account Code', varAccountName	 as 'Account  Name', varMobile as 'Mobile No',varAddress as 'Address' FROM tblamsaccountpersonnel", dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                adp.Fill(dt);
                lstDivisions.DataSource = dt;
                lstDivisions.DataBind();
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dbc.getAccoutID(txtaccname.Text) == "")
                {

                    int insert_ok = dbc.insert_tblamsaccountpersonnel(txtacccode.Text, txtaccname.Text, txtaccmobile.Text, txtaccphone.Text, txtaccEmail.Text, txtaccaddress.Text);

                    if (insert_ok == 1)
                    {
                        MessageDisplay("New Account Created Successfully!!!", "alert dark  alert-success alert-dismissible");
                       
                    }
                }
                else
                {
                    MessageDisplay("Account Already Added!!!", "alert dark  alert-success alert-dismissible");

                   
                }
                ShowDivisions();

            }
            catch (Exception ex)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
    }
}