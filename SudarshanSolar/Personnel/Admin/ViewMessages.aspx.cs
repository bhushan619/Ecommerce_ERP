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
    public partial class ViewMessages : System.Web.UI.Page
    {      DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["LoginId"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
            }
            else   if (!IsPostBack)
            {
              
                //   getCustomerList();
                SqlDataSourceMessages.SelectCommand = "SELECT varMessageByName, varMessageToName, varEnquirySubject, dtDate, tmTime, intId FROM tblsuenquiry WHERE intMessageToId=" + rex.DecryptString(Request.Cookies["LoginId"].Value) + "  order by CAST( STR_TO_DATE( dtDate,  '%d-%m-%Y' ) AS DATE )";
                notifications();
            }
        }
        public void notifications()
        {
           // lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
        }
        protected void lstFullMessage_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string id = commandArgs[0];


                if (e.CommandName == "Edits")
                {
                    Cache["Enquirybyadmin"] = id;
                    //Session.Add("Enquirybyadmin", id);
                    Response.Redirect("~/Personnel/Admin/ReplyMessage.aspx",false);
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
                    Response.Write("<script>alert('Messege Deleted Successfully');window.location='ViewMessages.aspx';</script>");
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
            SqlDataSourceMessages.SelectCommand = "SELECT varMessageByName, varMessageToName, varEnquirySubject, dtDate, tmTime, intId FROM tblsuenquiry WHERE intMessageToId=" + rex.DecryptString(Request.Cookies["LoginId"].Value) + "  order by CAST( STR_TO_DATE( dtDate,  '%d-%m-%Y' ) AS DATE )";
            SqlDataSourceMessages.DataBind();
        }
    }
}