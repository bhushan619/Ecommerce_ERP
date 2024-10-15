using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using SudarshanSolar.DbCode;

namespace SudarshanSolar.Personnel.Marketing
{  
    public partial class Collection : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        public static string empdesig = string.Empty;
        static int custId = 0;
        static string custstate = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

               
                getempname();
                notifications();
                get_Collection_data();
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }

        public void get_Collection_data()
        {

            try
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT  tblsucollection.intId,   tblsucustomer.varCompanyName as Party,  tblsupersonnel.varName As 'Emp Name',     tblsupersonnel.varSubDesig as Designation,   tblsucollection.varDate as Date, tblsucollection.varPaymentMode as'Pay Mode', tblsucollection.varCheckno as 'Check No',      tblsucollection.varCheckDate as 'Check Date', tblsucollection.varAmount as Amount, tblsucollection.varOtherPaymentDetails as 'Other Details' FROM    tblsucollection INNER JOIN         tblsucustomer ON tblsucollection.intCustId = tblsucustomer.intId INNER JOIN     tblsupersonnel ON tblsucollection.intEmpId = tblsupersonnel.intId order by  CAST(STR_TO_DATE(varDate,'%d-%m-%Y') AS DATE) desc", dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter ad2 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd2);

                ad2.Fill(dt3);

                grdRaw.DataSource = dt3;
                grdRaw.DataBind();
                dbc.con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void grdRaw_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRaw.PageIndex = e.NewPageIndex;
            get_Collection_data();

        }
      
        DataTable dt = new DataTable();
        DataTable dt3 = new DataTable();
        public void notifications()
        {
           // lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)), empdesig).ToString();
        }
        public void getempname()
        {
            try
            {

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName,varSubDesig FROM anuvaa_solar.tblsupersonnel where intId=" + rex.DecryptString(Request.Cookies["LoginId"].Value) + "", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    lblCustName.Text = dbc.dr["varName"].ToString();
                    empdesig = dbc.dr["varSubDesig"].ToString();
                    dbc.con.Close();
                    dbc.dr.Close();
                }

            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
            }
        }
       

       
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
        {
            String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["solarConnectionString"].ConnectionString;

            MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varCompanyName,'_',varCity) as  varCompanyName FROM anuvaa_solar.tblsucustomer where varCompanyName like '%" + prefixText + "%' AND intId between 1 and 500", con);
            //     cmd.Parameters.AddWithValue("@Name", prefixText);
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            MySql.Data.MySqlClient.MySqlConnection con1 = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varCompanyName,'_',varCity) as  varCompanyName FROM anuvaa_solar.tblsucustomer where varCompanyName like '%" + prefixText + "%' AND intId between 501 and 1000", con1);
            //     cmd.Parameters.AddWithValue("@Name", prefixText);
            MySql.Data.MySqlClient.MySqlDataAdapter da1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            List<string> CompanyName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CompanyName.Add(dt.Rows[i][0].ToString());
                //  CompanyName[j++] =dt.Rows[i][0].ToString();
            }
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                CompanyName.Add(dt1.Rows[i][0].ToString());
                //  CompanyName[j++] =dt.Rows[i][0].ToString();
            }
            con.Close();
            con1.Close();
            return CompanyName;
        }
        protected void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] arry = txtCustomerName.Text.Split(new char[] { '_' });

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varRepresentativeName, varMobile,varState FROM anuvaa_solar.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "'", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    lblRepresentativeName.Text = dbc.dr["varRepresentativeName"].ToString();
                    lblMob.Text = dbc.dr["varMobile"].ToString();
                    custstate = dbc.dr["varState"].ToString();
                    custId = Convert.ToInt32(dbc.dr["intId"].ToString());
                    dbc.con.Close();
                    dbc.dr.Close();
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
                ////string confirmValue = Request.Form["confirm_value"];
                ////if (confirmValue == "Yes")
                ////{

                    int insert_order_ok = dbc.insert_Collection_Marketing(custId, Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)), ddlPayMode.Text, txtCheckNo.Text, txtCheckDate.Text, txtAmount.Text, txtOtherDetails.Text);
                    if (insert_order_ok == 1)
                    {
                    MessageDisplay(Resources.Messages.Added, "alert dark  alert-dismissible  alert-success");

                    clear();
                    }
                //}
                //else
                //{
                //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
                //}
                get_Collection_data();

            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
            }
        }
        public void clear()
        {
            txtAmount.Text = "";
            txtCheckDate.Text = "";
            txtCheckNo.Text = "";
            txtCustomerName.Text = "";
            txtDate.Text = "";
            txtDate.Text = "";
            txtOtherDetails.Text = "";

        }
        protected void GetDatafromDatabase1()
        {

            DataTable dt1 = new DataTable();
            dbc.con.Open();
            string queryStr = "SELECT     tblsucustomer.varCompanyName as Party,  tblsupersonnel.varName As 'Emp Name',     tblsupersonnel.varSubDesig as Designation,   tblsucollection.varDate as Date, tblsucollection.varPaymentMode as'Pay Mode', tblsucollection.varCheckno as 'Check No',      tblsucollection.varCheckDate as 'Check Date', tblsucollection.varAmount as Amount, tblsucollection.varOtherPaymentDetails as 'Other Details' FROM    tblsucollection INNER JOIN         tblsucustomer ON tblsucollection.intCustId = tblsucustomer.intId INNER JOIN     tblsupersonnel ON tblsucollection.intEmpId = tblsupersonnel.intId order by  CAST(STR_TO_DATE(varDate,'%d-%m-%Y') AS DATE) desc";
            MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
            sda.Fill(dt1);
            grdRaw.DataSource = dt1;
            grdRaw.DataBind();
            dbc.con.Close();

        }
        protected void btnExportSale_Click(object sender, EventArgs e)
        {
            try
            {
                GetDatafromDatabase1();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Collection.xls"));
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grdRaw.AllowPaging = false;
                //Change the Header Row back to white color
                // grdReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
                //Applying stlye to gridview header cells


                grdRaw.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Personnel/marketing/Collection.aspx");
        }
        protected void grdReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "edits")
                {
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  tblsucollection.intId,   tblsucustomer.varCompanyName as Party,  tblsupersonnel.varName As 'Emp Name',     tblsupersonnel.varSubDesig as Designation,   tblsucollection.varDate as Date, tblsucollection.varPaymentMode as'Pay Mode', tblsucollection.varCheckno as 'Check No',      tblsucollection.varCheckDate as 'Check Date', tblsucollection.varAmount as Amount, tblsucollection.varOtherPaymentDetails as 'Other Details' FROM    tblsucollection INNER JOIN         tblsucustomer ON tblsucollection.intCustId = tblsucustomer.intId INNER JOIN     tblsupersonnel ON tblsucollection.intEmpId = tblsupersonnel.intId  WHERE tblsucollection.intId='" + e.CommandArgument + "' order by  CAST(STR_TO_DATE(varDate,'%d-%m-%Y') AS DATE) desc", dbc.con);

                    dbc.dr = cmd.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        txtintId.Text = dbc.dr["intId"].ToString();
                        txtDate.Text = dbc.dr["Date"].ToString();
                        txtCustomerName.Text = dbc.dr["Party"].ToString();
                        txtCustomerName.Enabled = false;
                        ddlPayMode.SelectedValue = dbc.dr["Pay Mode"].ToString();
                        txtCheckNo.Text = dbc.dr["Check No"].ToString();
                        txtCheckDate.Text = dbc.dr["Check Date"].ToString();
                        txtAmount.Text = dbc.dr["Amount"].ToString();
                        txtOtherDetails.Text = dbc.dr["Other Details"].ToString();

                    }
                    dbc.con.Close();
                    btnEditUpdate.Visible = true;
                    btnAdd.Visible = false;

                    //Response.Write("<script>alert('Expense Note Updated Successfully');window.location='DispatchExpenseSheet.aspx';</script>");
                }
                else if (e.CommandName == "del")
                {
                    //string confirmValue = Request.Form["confirm_value"];
                    //if (confirmValue == "Yes")
                    //{
                        dbc.con.Close();
                        dbc.con.Open();
                        dbc.cmd = new MySqlCommand("DELETE from tblsucollection WHERE intId='" + e.CommandArgument + "'", dbc.con);
                        dbc.cmd.ExecuteNonQuery();
                        dbc.con.Close();

                    MessageDisplay(Resources.Messages.Deleted, "alert dark  alert-dismissible  alert-success");
                    Response.Redirect("~/Personnel/marketing/Collection.aspx");
                    //}
                    //else
                    //{
                    //}
                }
                get_Collection_data();
              
            }
            catch (Exception es)
            {
            }
        }
        protected void btnEditUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dbc.con.Close();
                dbc.con.Open();
                dbc.cmd = new MySqlCommand("UPDATE tblsucollection SET  varDate='" + txtDate.Text + "',varPaymentMode='" + ddlPayMode.SelectedValue + "',varCheckno='" + txtCheckNo.Text + "',varCheckDate='" + txtCheckDate.Text + "',varAmount='" + txtAmount.Text + "',varOtherPaymentDetails='" + txtOtherDetails.Text + "'  WHERE intId=" + txtintId.Text + "", dbc.con);
                dbc.cmd.ExecuteNonQuery();
                dbc.con.Close();

                MessageDisplay(Resources.Messages.Updated, "alert dark  alert-dismissible  alert-success");

                clear();
                get_Collection_data();
              

            }
            catch (Exception ecc)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
            }
        }
    }
}