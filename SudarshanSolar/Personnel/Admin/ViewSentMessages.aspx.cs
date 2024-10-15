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

namespace SudarshanSolar.Personnel.Admin
{
    public partial class ViewSentMessages : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["LoginId"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
            }
            else if (!IsPostBack)
            {
                
                SqlDataSourceMessages.SelectCommand = "SELECT varMessageByName, varMessageToName, varEnquirySubject, dtDate, tmTime, intId FROM tblsuenquiry WHERE intMessageById=" + rex.DecryptString(Request.Cookies["LoginId"].Value) + "  order by CAST( STR_TO_DATE( dtDate,  '%d-%m-%Y' ) AS DATE )";
                notifications();
            }
        }
        public void notifications()
        {
           // lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)), "Admin").ToString();
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        protected void lstFullMessage_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string id = commandArgs[0];


                if (e.CommandName == "Edits")
                {
                    //Session.Add("Enquirybyadmin", id);
                    Cache["Enquirybyadmin"] = id;
                    //Session.Add("Enquirybyadmin", id);
                    Response.Redirect("~/Personnel/Admin/ReplyMessage.aspx", false);
                }

                else if (e.CommandName == "Deletes")
                {
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuenquiry WHERE intId=" + id + "", dbc.con);
                    cmd.ExecuteReader();
                    dbc.con.Close();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuconversation WHERE intMessageId=" + id + "", dbc.con);
                    cmd1.ExecuteReader();
                    dbc.con.Close();
                    MessageDisplay("Messege Deleted Successfully", "alert dark  alert-success alert-dismissible");
                   // Response.Write("<script>alert('');window.location='ViewSentMessages.aspx';</script>");
                }
                else if (e.CommandName == "Views")
                {
                    lblSubject.Text = commandArgs[1].ToString();
                    SqlDataSourceFull.SelectCommand = "SELECT intId, nvarMsgFrom, nvarMsgTo FROM tblsuconversation where intMessageId=" + id + "";
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void lstMessages_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstMessages.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            SqlDataSourceMessages.SelectCommand = "SELECT varMessageByName, varMessageToName, varEnquirySubject, dtDate, tmTime, intId FROM tblsuenquiry WHERE intMessageById=" + rex.DecryptString(Request.Cookies["LoginId"].Value) + "  order by CAST( STR_TO_DATE( dtDate,  '%d-%m-%Y' ) AS DATE )";
            SqlDataSourceMessages.DataBind();
        }
    }
}