using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using SudarshanSolar.DbCode;


namespace SudarshanSolar
{
    public partial class Register : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection con;
        public MySql.Data.MySqlClient.MySqlDataReader dr;
        DatabaseConnection dbc = new DatabaseConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
             // sendmail();
        }
        private string PopulateBody(string Name, string EmailId, string VerifyLink)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Personnel/admin/emails/register.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{Name}", Name);
            body = body.Replace("{EmailId}", EmailId);
            body = body.Replace("{VerifyLink}", VerifyLink);
            return body;
        }
        protected void sendmail(string verify, string cos)
        {
            try
            {
                string mess = string.Empty;
                string email = string.Empty;
                if (cos == "c")
                {
                    mess = "http://demo.sudarshansolarsystems.com/Personnel/Admin/verify.aspx?cvid=";
                    email = txtMail.Value;
                }
                else
                {
                    mess = "http://demo.sudarshansolarsystems.com/Personnel/Admin/verify.aspx?evid=";
                    email = txtMail.Value;
                }
                using (MailMessage mm = new MailMessage(new MailAddress("solar <info.edmitra@gmail.com>"), new MailAddress(email)))
                {
                    mm.Subject = "solar : Verification Email";

                    mm.Body = PopulateBody(txtName.Value, email, mess + verify);

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
                ScriptManager.RegisterStartupScript(
                             this,
                             this.GetType(),
                             "MessageBox",
                              "alert(' not sent');", true);

            }
        }
        public void clear()
        {
            txtMail.Value = "";
            txtName.Value = "";
            txtMobile.Value = "";
            txtPasswd.Value = "";
            txtConfirmPass.Value = "";

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
            try
            {
                if (rdbEmployee.Checked)
                {
                  
                     if (dbc.check_already_Employee(txtMail.Value) == 1)
                    {
                        MessageDisplay("This Email is already registered. Did You forget password? If yes please retrieve your password.", " alert dark  alert-danger alert-dismissible");
                    }
                    else
                    {
                        string verify = dbc.CreateRandomPassword(8);
                        int insert_ok = dbc.insert_tblEmployeeDetails(txtName.Value, txtMobile.Value, "pending", txtMail.Value, verify, txtPasswd.Value, "", "", "", "", "", "", "", "", "", "", "", "login");

                        if (insert_ok == 1)
                        {
                            sendmail(verify, "e");
                            MessageDisplay("Registration completed please check email for verification...", " alert dark  alert-success alert-dismissible");
                           
                            clear();
                        }
                        else
                        {
                            MessageDisplay(Resources.ErrorMessages.SomeError, " alert dark  alert-danger alert-dismissible");
                        }
                    }
                }
                else
                {
                    if (dbc.check_already_Customer(txtMail.Value) == 1)
                    {
                        MessageDisplay("This Email is already registered. Did You forget password? If yes please retrieve your password.", " alert dark  alert-danger alert-dismissible");
                    }
                  
                    else
                    {
                        string verify = dbc.CreateRandomPassword(8);
                        int insert_ok = dbc.insert_tblCustomerDetails("",txtName.Value, txtMobile.Value,"","", txtMail.Value,  verify, txtPasswd.Value,"","","","","","","","","Noprofile.png","","","");

                        if (insert_ok != 0)
                        {
                            sendmail(verify, "c");
                            MessageDisplay("Registration completed please check email for verification...", " alert dark  alert-success alert-dismissible");

                            clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                       "alert('" + ex.Message + "');", true);
            }

        }


    }
}