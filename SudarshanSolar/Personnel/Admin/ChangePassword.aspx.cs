using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SudarshanSolar.DbCode;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        static string UserEmailid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            getOldPass();
        }
        public void getOldPass()
        {
            try
            {
                dbc.con.Close();
                dbc.con.Open();
                dbc.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varName, varMobile, varMobileVerify, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varDesignation, varSubDesig, varStatus, varIDProof, varIDProofNo, varPanCardNo, imgImage, dtDateOfBirth FROM tblsupersonnel WHERE intId="+ rex.DecryptString(Request.Cookies["LoginId"].Value) + "", dbc.con);
              dbc.dr= dbc.cmd.ExecuteReader();
               if(dbc.dr.Read())
                {
                    UserEmailid = dbc.dr["varEmail"].ToString();
                    if (txtOld.Text == dbc.dr["varPassword"].ToString())
                    {
                        getNewpass();
                    }
                    else
                    {
                        MessageDisplay(Resources.ErrorMessages.OldPassword, "alert dark  alert-dismissible  alert-danger");
                    }
                }
                dbc.con.Close();
            }
            catch (Exception ex)
            {
                dbc.con.Close();
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
            }
        }
        public void getNewpass()
        {
            try
            {
                if (txtNewCon.Text == txtNew.Text)
                {
                    dbc.con.Close();
                    dbc.con.Open();
                    dbc.cmd = new MySql.Data.MySqlClient.MySqlCommand("update tblsupersonnel set varPassword='" + txtNew.Text + "' where intId=" + rex.DecryptString(Request.Cookies["LoginId"].Value) + " ", dbc.con);
                    int res = dbc.cmd.ExecuteNonQuery();
                    if (res>0)
                    {
                        sendmail(txtNew.Text, UserEmailid);
                        MessageDisplay(Resources.ErrorMessages.OkPassword, "alert dark  alert-dismissible  alert-success");

                    }
                    else
                    {
                        MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");

                    }

                }
                else
                {
                    MessageDisplay(Resources.ErrorMessages.SamePasswords, "alert dark  alert-dismissible  alert-danger");
                }
              
            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
            }
        }
        private string PopulateBody(string EmailId, string pass)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Personnel/admin/emails/changepass.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{EmailId}", EmailId);

            body = body.Replace("{Password}", pass);
            return body;
        }
        protected void sendmail(string pass, string email)
        {
            try
            {

                using (MailMessage mm = new MailMessage(new MailAddress("Solar <info.edmitra@gmail.com>"), new MailAddress(email)))
                {
                    mm.Subject = "Solar  : Password Changed";

                    mm.Body = PopulateBody(email, pass);

                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    NetworkCredential NetworkCred = new NetworkCredential("info.edmitra@gmail.com", "info@2014");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);

                }
            }
            catch (Exception rx)
            {
                MessageDisplay(Resources.ErrorMessages.EmailNotSend, "alert dark  alert-dismissible  alert-danger");

            }
        }
    }
}