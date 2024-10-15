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
    public partial class ViewSentMessages : System.Web.UI.Page
    {
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["custid"] == null)
            {
                Response.Redirect("~/Customer/Default.aspx", false);
            }
            else if (!IsPostBack)
            {

                notifications();
                SqlDataSourceMessages.SelectCommand = "SELECT varMessageByName, varMessageToName, varEnquirySubject, dtDate, tmTime, intId FROM tblsuenquiry WHERE intMessageById= " + rex.DecryptString(Request.Cookies["custid"].Value.ToString()) + " order by CAST( STR_TO_DATE( dtDate,  '%d-%m-%Y' ) AS DATE  )";
            }
        }
        public void notifications()
        {
            //   lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(rex.DecryptString(Request.Cookies["custid"].Value.ToString())), "Customer").ToString();
        }


        DatabaseConnection dbc = new DatabaseConnection();
     
        protected void lstFullMessage_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string id = commandArgs[0];


                //if (e.CommandName == "Edits")
                //{
                //    Cache["Enquirybyadmin"] = id;
                //    //Session.Add("Enquirybyadmin", id);
                //    Response.Redirect("ReplyMessage.aspx");
                //}

                //else
                if (e.CommandName == "Deletes")
                {
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuenquiry WHERE intId=" + id + "", dbc.con);
                    cmd.ExecuteReader();
                    dbc.con.Close();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuconversation WHERE intMessageId=" + id + "", dbc.con);
                    cmd1.ExecuteReader();
                    dbc.con.Close();
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
            SqlDataSourceMessages.SelectCommand = "SELECT varMessageByName, varMessageToName, varEnquirySubject, dtDate, tmTime, intId FROM tblsuenquiry WHERE intMessageById= " + rex.DecryptString(Request.Cookies["custid"].Value.ToString()) + " order by CAST( STR_TO_DATE( dtDate,  '%d-%m-%Y' ) AS DATE )";
            SqlDataSourceMessages.DataBind();
        }
        //protected void listproduct_ItemCommand(object sender, ListViewCommandEventArgs e)
        //{
        //    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        //    string id = commandArgs[0];

        //    if (e.CommandName == "Deletes")
        //    {
        //        dbc.con.Open();
        //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuenquiry WHERE intId=" + id + "", dbc.con);
        //        cmd.ExecuteReader();
        //        dbc.con.Close();
        //        dbc.con.Open();
        //        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuconversation WHERE intId=" + id + "", dbc.con);
        //        cmd1.ExecuteReader();
        //        dbc.con.Close();

        //    }
        //    SqlDataSource2.SelectCommand = "SELECT tblsuenquiry.intId, tblsuenquiry.intTicketNo,  tblsuenquiry.nvarEnquiryBy, tblsuenquiry.nvarEnquirySubject, tblsuenquiry.dtDate, tblsuconversation.nvarMsgFromEnquirer,tblsuconversation.nvarMsgFromAdmin FROM tblsuenquiry INNER JOIN tblsuconversation ON tblsuenquiry.intTicketNo = tblsuconversation.intTicketNo  ORDER BY intId";
        //    listenquiry.DataBind();
        //}
    }
}