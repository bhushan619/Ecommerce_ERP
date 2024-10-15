using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SudarshanSolar.DbCode;
using System.Data;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class EditCustomerOther : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["custbyadmin"] == null)
            {
                Response.Redirect("~/Personnel/admin/ViewCustomer.aspx", false);
            }
            else
              if (!IsPostBack)
            {              
                getcustdata();
                getcustomerotherdata();
                notifications();
               
            }
          
        }

        public void getcustomerotherdata()
        {  SqlDataSourceCustOther.SelectCommand = " SELECT intId, varRepName, varDesignation, varContact, varDOB FROM tblsucustomerotherdetails WHERE(intCustId=" + Cache["custbyadmin"].ToString() + ")";
                grdCustomerOtherDetails.DataBind();

        }
        public void notifications()
        {
          //  lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
        }
        public void getcustdata()
        {
            try
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCompanyName,varRepresentativeName ,varMobile , varAddress,varCity ,varState ,varPanCardNo,varVatNo ,varTinNo,imgImage,dtDateOfEstd FROM anuvaa_solar.tblsucustomer   WHERE intId=" + Cache["custbyadmin"].ToString() + "", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {

                    lblCmpName.Text = dbc.dr["varCompanyName"].ToString();
                    dbc.con.Close();
                    dbc.dr.Close();
                }
                dbc.con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please Try Again');</script>");
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //string confirmValue = Request.Form["confirm_value"];
            //if (confirmValue == "Yes")
            //{
                int insert_ok = dbc.Insert_tblsucustomeradminother(Cache["custbyadmin"].ToString(), txtRepName.Text, txtDesig.Text, txtContact.Text, txtDOB.Text, txtRemark.Text);
            if (insert_ok == 1)
            {
                MessageDisplay(Resources.Messages.Added, "alert dark  alert-dismissible  alert-success");

              
            }
            //}
            //else
            //{
            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            //}

        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        public void clear()
        {
            txtContact.Text = "";
            txtDesig.Text = "";
            txtDOB.Text = "";
            txtRemark.Text = "";
            txtRepName.Text = "";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Personnel/admin/ViewCustomer.aspx");
        }
        protected void grdOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "remove")
                {
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("DELETE from tblsucustomerotherdetails WHERE intId = " + Convert.ToInt32(e.CommandArgument) + "", dbc.con);
                    cmd.ExecuteNonQuery();
                    dbc.con.Close();
                    MessageDisplay(Resources.Messages.Deleted, "alert dark  alert-dismissible  alert-success");
                    
                }getcustomerotherdata();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}