using SudarshanSolar.DbCode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SudarshanSolar.Customer
{
    public partial class AddEnquiry : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection con;
        public MySql.Data.MySqlClient.MySqlDataReader dr;
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new MySql.Data.MySqlClient.MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["solarConnectionString"].ConnectionString;
            if (Request.Cookies["custid"] == null)
            {
                Response.Redirect("~/Customer/Default.aspx", false);
            }
            else if (!IsPostBack)
            {
                notifications();
            }
            lbldate.Text = System.DateTime.Now.ToShortDateString();
            lblTime.Text = System.DateTime.Now.ToShortTimeString();
        }
        public void notifications()
        {
            // lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32( rex.DecryptString(Request.Cookies["custid"].Value.ToString()), "Customer").ToString();
        }

        DatabaseConnection dbc = new DatabaseConnection();

       
        public void clear()
        {
            txtMsg.Text = "";
            txtSubject.Text = "";
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                //string confirmValue = Request.Form["confirm_value"];
                //if (confirmValue == "Yes")
                //{
                int okn = 0, insert_ok = 0;
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdn = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varName FROM tblsupersonnel WHERE varSubDesig='Admin'", con);

                MySql.Data.MySqlClient.MySqlDataReader drn;
                drn = cmdn.ExecuteReader();
                while (drn.Read())
                {
                    insert_ok = dbc.insert_tblsuenquiry(Convert.ToInt32(rex.DecryptString(Request.Cookies["custid"].Value.ToString())), dbc.getCustNameById(Convert.ToInt32(rex.DecryptString(Request.Cookies["custid"].Value.ToString()))), "Customer", Convert.ToInt32(drn["intId"].ToString()), drn["varName"].ToString(), "Admin", txtSubject.Text, txtMsg.Text, lbldate.Text, lblTime.Text);
                    //  okn = dbc.insert_tblsunotifications("Page", Convert.ToInt32(Session["custid"].ToString()), lblCustName.Text, "Customer", Convert.ToInt32(drn["intId"].ToString()), "Sub Admin", "New Message from : " + lblCustName.Text + "", "~/Personnel/employee/dispatch/InboxMsg.aspx", "NA", "Unread", "Sub Admin");
                }
                con.Close();
                drn.Close();

                if (insert_ok == 1)
                {
                    //if (okn == 1)
                    //{
                    //    Response.Write("<script>alert('Message Send Successfully');</script>");
                    //   
                    //}
                    //else
                    //{
                    //    Response.Write("<script>alert('Please Try Again');</script>");
                    //}
                    MessageDisplay("Message Send Successfully", " alert dark  alert-success alert-dismissible");
                  
                    clear();
                }
                else
                {

                    MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
                }
                //}
                //else
                //{
                //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
                //}

            }
            catch (Exception ex)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/customer/Dashboard.aspx");
        }
    }
}