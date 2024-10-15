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
    public partial class EditCustomerTaxDetails : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        static int custid = 0;
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
                getCustomerdata();
                bindDataToGridView();
                notifications();
            }

        }
        public void notifications()
        {
           // lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
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

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        public void getCustomerdata()
        {
            try
            {
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varTaxable, varTaxType, varCSTnumber, varTaxGroup, varTaxDiscount, varCrBills, varCrLimit, varCrdays FROM anuvaa_solar.tblsucustomertaxdetails WHERE intCompanyId=" + Cache["custbyadmin"].ToString() + " ", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    //lblCustName.Text = dbc.dr["varCompanyName"].ToString();
                    txtTaxable.Text = dbc.dr["varTaxable"].ToString();
                    txtType.Text = dbc.dr["varTaxType"].ToString();
                    txtCST.Text = dbc.dr["varCSTnumber"].ToString();
                    txtTaxgroup.Text = dbc.dr["varTaxGroup"].ToString();
                    txtTaxDiscount.Text = dbc.dr["varTaxDiscount"].ToString();
                    txtCrBills.Text = dbc.dr["varCrBills"].ToString();
                    txtCrLimit.Text = dbc.dr["varCrLimit"].ToString();
                    txtCrDays.Text = dbc.dr["varCrdays"].ToString();
                    dbc.con.Close();
                    dbc.dr.Close();
                }
                dbc.con.Close();
            }
            catch (Exception ex)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
                Response.Redirect("ViewCustomer.aspx");
            }
        }
        public void clear()
        {

            txtTaxable.Text = "";
            txtType.Text = "";
            txtTaxgroup.Text = "";
            txtCST.Text = "";
            txtTaxDiscount.Text = "";
            txtCrBills.Text = "";
            txtCrLimit.Text = "";
            txtCrDays.Text = "";

        }
        public void bindDataToGridView()
        {
            try
            {
                DataSet ds = new DataSet();
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT intId, varTaxable, varTaxType, varCSTnumber, varTaxGroup,varTaxDiscount FROM tblsucustomertaxdetails WHERE intCompanyId=" + Cache["custbyadmin"].ToString() + " ", dbc.con);
                adp.Fill(ds);
                dbc.con.Close();
                grdCustomerTaxDetails.DataSource = ds;
                grdCustomerTaxDetails.DataBind();

            }
            catch (Exception ex)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
                Response.Redirect("ViewCustomer.aspx");
            }


        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int update_ok = dbc.update_tblsucustomertaxdetails(Convert.ToInt32(Cache["custbyadmin"].ToString()), txtTaxable.Text, txtType.Text, txtTaxgroup.Text, txtCST.Text, txtTaxDiscount.Text, txtCrBills.Text, txtCrLimit.Text, txtCrDays.Text);
                if (update_ok == 1)
                {

                    MessageDisplay(Resources.Messages.Updated, "alert dark  alert-dismissible  alert-success");
                    bindDataToGridView();

                    //  clear();
                }
            }
            catch (Exception ex)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //string confirmValue = Request.Form["confirm_value"];
                //if (confirmValue == "Yes")
                //{
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  intCompanyId FROM tblsucustomertaxdetails WHERE intCompanyId=" + Cache["custbyadmin"].ToString() + " ", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    custid = Convert.ToInt32(dbc.dr["intCompanyId"].ToString());
                }
                if (dbc.check_already_CustomerTaxDetails(custid) != 1)
                {
                    int insert_ok = dbc.insert_tblsucustomertaxdetails(Convert.ToInt32(Cache["custbyadmin"].ToString()), lblCmpName.Text, txtTaxable.Text, txtType.Text, txtTaxgroup.Text, txtCST.Text, txtTaxDiscount.Text, txtCrBills.Text, txtCrLimit.Text, txtCrDays.Text);

                    MessageDisplay(Resources.Messages.Added, "alert dark  alert-dismissible  alert-success");
                    bindDataToGridView();

                    clear();
                }
                else
                {
                    MessageDisplay(Resources.ErrorMessages.Detailsalredyexit, "alert dark  alert-dismissible  alert-success");
                }


                dbc.con.Close();
                //}
                //else
                //{
                //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
                //}
            }
            catch (Exception ex)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
                clear();
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCustomerTaxDetails.aspx");
        }
        protected void grdCustomerTaxDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "removes")
                {
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("DELETE from tblsucustomertaxdetails WHERE intId = " + Convert.ToInt32(e.CommandArgument) + "", dbc.con);
                    cmd.ExecuteNonQuery();
                    dbc.con.Close();
                    MessageDisplay(Resources.Messages.Deleted, "alert dark  alert-dismissible  alert-success");
                }
                bindDataToGridView(); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}