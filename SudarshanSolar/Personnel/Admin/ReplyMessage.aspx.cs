using SudarshanSolar.DbCode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SudarshanSolar.Personnel.Admin
{
    public partial class ReplyMessage : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        static int empReplyToId = 0;
        // string desig = string.Empty;
        static string empdesig = string.Empty;
        static string empReplyTodesig = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["LoginId"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
            }
            else  if (Cache["Enquirybyadmin"] == null)
            {
                Response.Redirect("~/Personnel/Admin/ViewMessages.aspx", false);
            }
            else if(!IsPostBack)
            {
                getEnquirymsg();
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
           // lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
        }

   
        public void getEnquirymsg()
        {
            try
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEnquirySubject, dtDate, tmTime, intId FROM tblsuenquiry  where intId=" + Convert.ToInt32(Cache["Enquirybyadmin"].ToString()) + "", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    lblSubject.Text = dbc.dr["varEnquirySubject"].ToString();
                    // txtMobile.Text = dbc.dr["varMobile"].ToString();  
                    dbc.con.Close();
                    dbc.dr.Close();
                }
                SqlDataSourceFull.SelectCommand = "SELECT intId, nvarMsgFrom, nvarMsgTo FROM tblsuconversation where intMessageId=" + Convert.ToInt32(Cache["Enquirybyadmin"].ToString()) + "";
            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string adminreply = txtreplyadminmsg.Text;
                int insert_ok =  dbc.Update_tblsuEnquiryReplySendAdmin((Cache["Enquirybyadmin"].ToString()), adminreply);

                if (insert_ok == 1)
                {
                    //int ok = notification(empReplyToId, empReplyTodesig, pagetosend(empReplyTodesig));
                    //if (ok == 1)
                    //{
                    MessageDisplay("Reply Send Successfully", "alert dark  alert-success alert-dismissible");
                  
                    //}
                }
                else
                {
                    MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
                }

            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
        //public int notification(int idToNotification, string desigToNotification, string pageToView)
        //{
        //    try
        //    {

        //        int okn = dbc.insert_tblsunotifications("Page", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, idToNotification, desigToNotification, "Reply from Sub Admin", pageToView, "NA", "Unread", "Order");

        //        return okn;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}
        public string pagetosend(string desig)
        {
            if (desig == "Clerk")
            {
                return "~/Personnel/Clerk/ViewSentMessages.aspx";
            }
            else if (desig == "Marketing")
            {
                return "~/Personnel/marketing/ViewSentMessages.aspx";
            }
            //else if (desig == "Sub Admin")
            //{
            //    return "~/Personnel/employee/subadmin/ViewSentMessages.aspx";
            //}
            else if (desig == "Admin")
            {
                return "~/Personnel/Admin/ViewSentMessages.aspx";
            }
            else
            {
                return "~/customer/ViewSentMessages.aspx";
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Personnel/admin/ViewMessages.aspx");
        }
    }
}