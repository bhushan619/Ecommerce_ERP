using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SudarshanSolar.DbCode;

using System.Data;
using System.Configuration;
using System.Collections;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace SudarshanSolar
{
    public partial class RetrievePassword : System.Web.UI.Page
    {

        MySql.Data.MySqlClient.MySqlConnection con;
        public MySql.Data.MySqlClient.MySqlDataReader dr;
        DatabaseConnection dbc = new DatabaseConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            location();
        }
        public void location()
        {
            //  lblLocation.Text = "At " + "<script type='text/javascript'>locate();</script>";

        }

        private string PopulateBody(string pass,string Name)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Personnel/admin/emails/forget.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{Password}", pass);
            body = body.Replace("{Name}", Name);
            return body;
        }
        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                string pass = string.Empty;
                if (Customer.Checked == true)
                {
                    pass = dbc.getpass(txtEmail.Text, "c");
                }
                else
                {
                    pass = dbc.getpass(txtEmail.Text, "e");
                }
                if (pass == "")
                {
                    ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                             "alert('Please Check Email');", true);
                }
                else
                {
                    using (MailMessage mm = new MailMessage(new MailAddress("solar<info.edmitra@gmail.com>"), new MailAddress(txtEmail.Text)))
                    {
                        mm.Subject = "Sudarshan Solar : Password Retrieve Email";

                        mm.Body = PopulateBody(pass, txtEmail.Text);

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
                        txtEmail.Text = "";
                        ScriptManager.RegisterStartupScript(
                                this,
                                this.GetType(),
                                "MessageBox",
                                 "alert('Email sent please check your Inbox');", true);
                    }
                }
                txtEmail.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(
                             this,
                             this.GetType(),
                             "MessageBox",
                              "alert('Email not sent');", true);

            }
        }
    }
}