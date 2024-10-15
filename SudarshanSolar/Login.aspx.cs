using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SudarshanSolar
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            if (!IsPostBack)
            {
            }
            if (Request.QueryString.Count == 0)
            {

            }
            else if (Request.QueryString[0].ToString() == "no")
            {
                MessageDisplay(Resources.ErrorMessages.IncorrectLogin, " alert dark  alert-danger alert-dismissible");
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
    }
}