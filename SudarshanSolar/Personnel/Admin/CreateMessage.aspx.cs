using SudarshanSolar.DbCode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SudarshanSolar.Personnel.Admin
{
    public partial class CreateMessage : System.Web.UI.Page
    {
        DatabaseConnection dbc1 = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["LoginId"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
            }
            else  if (!IsPostBack)
            {
                notifications();
                lbldate.Text = System.DateTime.Now.ToShortDateString();
                lblTime.Text = System.DateTime.Now.ToShortTimeString();
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
           // lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32( rex.DecryptString(Request.Cookies["LoginId"].Value)), "Admin").ToString();
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                int empid = 0;
                string desig = string.Empty;
                if (ddlSelectDesig.Text == "-- Select List --")
                {
                    MessageDisplay("Please select an Item", "alert dark  alert-danger alert-dismissible");
                   // Response.Write("<script>alert('');</script>");
                }
                else if (ddlSelectDesig.Text == "Employee")
                {
                    dbc1.con1.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varName, varMobile, varMobileVerify, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varDesignation, varSubDesig, varStatus, varIDProof, varIDProofNo, varPanCardNo, imgImage, dtDateOfBirth FROM tblsupersonnel WHERE varName='" + ddlDesigs.Text + "'", dbc1.con1);

                    dbc1.dr = cmd.ExecuteReader();
                    if (dbc1.dr.Read())
                    {
                        empid = Convert.ToInt32(dbc1.dr["intId"].ToString());
                        desig = dbc1.dr["varSubDesig"].ToString();
                        int insert_ok = dbc1.insert_tblsuenquiry(Convert.ToInt32( rex.DecryptString(Request.Cookies["LoginId"].Value)), dbc1.getEmpNameById(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value))), "Admin", empid, ddlDesigs.Text, desig, txtSubject.Text, txtMsg.Text, lbldate.Text, lblTime.Text);

                        if (insert_ok == 1)
                        {
                            //int ok = notification(empid, desig, pagetosend(desig));
                            //if (ok == 1)
                            //{
                            MessageDisplay("Message Send Successfully", "alert dark  alert-success alert-dismissible");
                          //  Response.Write("<script>alert('');</script>");
                                clear();
                            //}
                        }
                        else
                        {

                            MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");

                        }
                    }
                }
                else
                {
                    string[] arry = ddlDesigs.Text.Split(new char[] { '_' });
                    int custId = 0;
                    dbc1.con1.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varRepresentativeName, varMobile,varState FROM tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "'", dbc1.con1);

                    dbc1.dr = cmd.ExecuteReader();
                    if (dbc1.dr.Read())
                    {
                        custId = Convert.ToInt32(dbc1.dr["intId"].ToString());
                        int insert_ok = dbc1.insert_tblsuenquiry(Convert.ToInt32( rex.DecryptString(Request.Cookies["LoginId"].Value)), dbc1.getEmpNameById(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value))), "Admin", custId, ddlDesigs.Text, "Customer", txtSubject.Text, txtMsg.Text, lbldate.Text, lblTime.Text);

                        if (insert_ok == 1)
                        {
                            //int ok = notification(custId, "Customer", "~/customer/ViewConversation.aspx");
                            //if (ok == 1)
                            //{
                            MessageDisplay("Message Send Successfully", "alert dark  alert-success alert-dismissible");
                            clear();
                            //}
                        }
                        else
                        {

                            MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");

            }
        }
        //public int notification(int idToNotification, string desigToNotification, string pageToView)
        //{
            //try
            //{

            //    int okn = dbc.insert_tblsunotifications("Page", Convert.ToInt32( rex.DecryptString(Request.Cookies["LoginId"].Value)), dbc1.getEmpNameById(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value))), "Admin", idToNotification, desigToNotification, "New Message from Admin", pageToView, "NA", "Unread", "Order");

            //    return okn;
            //}
            //catch (Exception ex)
            //{
            //    return 0;
            //}
        //}
        public string pagetosend(string desig)
        {
            if (desig == "Clerk")
            {
                return "~/Personnel/Clerk/InboxMsg.aspx";
            }
            else if (desig == "Marketing")
            {
                return "~/Personnel/marketing/InboxMsg.aspx";
            }
            //else if (desig == "Sub Admin")
            //{
            //    return "~/Personnel/employee/subadmin/InboxMsg.aspx";
            //}
            else
            {
                return "~/Personnel/Admin/ViewMessages.aspx";
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            txtMsg.Text = "";
            txtSubject.Text = "";
            ddlDesigs.Items.Clear();
            ddlSelectDesig.SelectedIndex = 0;
            ddlDesigs.Items.Add("-- Select --");

        }
        protected void ddlSelectDesig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSelectDesig.Text == "-- Select List --")
            {
                MessageDisplay("Please select an Item", "alert dark  alert-danger alert-dismissible");

               // Response.Write("<script>alert('Please select an Item');</script>");
            }
            else if (ddlSelectDesig.Text == "Employee")
            {
                ddlDesigs.Items.Clear();
                SqlDataSource1.SelectCommand = "SELECT tblsupersonnel.varName FROM tblsupersonnel where varDesignation<> 'admin'";
                ddlDesigs.DataTextField = "varName";
            }
            else
            {
                ddlDesigs.Items.Clear();
                SqlDataSource1.SelectCommand = "SELECT distinct concat(varCompanyName,'_',varCity) as  CompanyName FROM tblsucustomer where varMobile<> '-'";
                ddlDesigs.DataTextField = "CompanyName";
            }
        }
    }
}