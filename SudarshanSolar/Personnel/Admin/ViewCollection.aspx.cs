using MySql.Data.MySqlClient;
using SudarshanSolar.DbCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class ViewCollection : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListView();
            }
        }
        public void BindListView()
        {
            SqlDataSourceCollection.SelectCommand = "SELECT        tblsucollection.intId, tblsucollection.intCustId, tblsucollection.intEmpId, tblsucollection.intCollectionId, tblsucollection.varDate, tblsucollection.varPaymentMode, tblsucollection.varAmount, tblsucollection.ex1,CONCAT(tblsupersonnel.varName, ' ', tblsupersonnel.varSubDesig) as EmployeeName, tblsucustomer.varCompanyName, tblsucustomer.varRepresentativeName, tblsucustomer.varMobile AS custmb, tblsucustomer.varAddress AS custaddress, tblsupersonnel.varMobile FROM            tblsucollection INNER JOIN   tblsucustomer ON tblsucollection.intCustId = tblsucustomer.intId INNER JOIN  tblsupersonnel ON tblsucollection.intEmpId = tblsupersonnel.intId ";
            lstCollection.DataBind();
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        protected void lstCollection_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            try
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string id = commandArgs[0];
                string amt = commandArgs[1];
                if (e.CommandName == "Collect")
                {
                    dbc.con3.Close();
                    dbc.con3.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblsucollection SET ex1='1' WHERE intId=" + Convert.ToInt32(id) + "", dbc.con3);

                    int update_ok = cmd.ExecuteNonQuery();

                    if (update_ok == 1)
                    {
                        string[] arryAccDetails = dbc.getInsertAccountDetails().Split('_');
                        dbc.insert_tblamsaccountbookJama(DateTime.UtcNow.ToString("yyyy-MM-dd"), arryAccDetails[3].ToString(), arryAccDetails[2].ToString(), "NA", "New Purchase Payment", amt, "Credit", arryAccDetails[0].ToString(), (Convert.ToDouble(dbc.getAmount(DateTime.UtcNow.ToString("yyyy-MM-dd"), "desc", arryAccDetails[0].ToString())) + Convert.ToDouble(amt)).ToString(), arryAccDetails[1].ToString());

                        MessageDisplay(Resources.Messages.Updated, "alert alert-success  fade in");

                    }
                    else
                    {
                        MessageDisplay(Resources.Messages.NotUpdated, "alert alert-block alert-danger fade in");
                    }
                    dbc.con3.Close();

                    BindListView();
                }
               
            }
            catch (Exception ex)
            {
                dbc.con1.Close();

            }
        }
    }
}