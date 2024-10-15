using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SudarshanSolar.Customer
{
    public partial class Contact : System.Web.UI.Page
    {
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
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");

                mail.From = new System.Net.Mail.MailAddress("info.edmitra@gmail.com");
                mail.To.Add("info.edmitra@gmail.com");


                mail.Subject = "Enquiry at Sudarshan Saur from Contact";

                // done HTML formatting in the next line to display my logo 

                mail.Body = "Enquiry at Sudarshan Saur  by \n \n Name : " + txtName.Text + "\n\n Mobile : " + txtPhone.Text + "\n\n Email : " + txtEmail.Text + "\n Subject : " + txtsubject.Text + "\n Message : " + txtMessage.Text;

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("info.edmitra@gmail.com", "info@2014");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                MessageDisplay("Message sent successfully..", "alert alert-success");
             
            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.Error, "alert alert-danger");

              
            }
        }
    }
}