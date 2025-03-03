﻿using System;
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

namespace SudarshanSolar.Personnel.Marketing
{
    public partial class CreateDSR : System.Web.UI.Page
    {
        RegexUtilities rex = new RegexUtilities();
        public static string empdesig = string.Empty;
        MySql.Data.MySqlClient.MySqlConnection con;
        public MySql.Data.MySqlClient.MySqlDataReader dr;
        DatabaseConnection dbc = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getempname();
                getDSR();

            }
        }
        public void getDSR()
        {
            SqlDataSourceDSR.SelectCommand = "SELECT intId, varEmpName, varDate, varLocation, varCallType, varCustName, varRepersentName, varLandline, varMobile, varRemark, varNextDate FROM tblsudsrdetails WHERE (intEmpId = " + rex.DecryptString(Request.Cookies["loginid"].Value.ToString()) + ") order by CAST(STR_TO_DATE(varDate,'%d-%m-%Y') AS DATE)";
            grdDSR.DataBind();

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
                  //  empdesig = dbc.dr["varSubDesig"].ToString();
                    dbc.con.Close();
                    dbc.dr.Close();
                }

            }
            catch (Exception ex)
            {

                MessageDisplay(Resources.ErrorMessages.Error, "alert dark  alert-dismissible  alert-danger");

            }
        }
        public void notifications()
        {
           // lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)), empdesig).ToString();
        }
        protected void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtContactPerson.Text = "";
                txtMobile.Text = "";
                string[] arry = txtCustomerName.Text.Split(new char[] { '_' });

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varRepresentativeName, varMobile,varState FROM anuvaa_solar.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "'", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    txtContactPerson.Text = dbc.dr["varRepresentativeName"].ToString();
                    txtMobile.Text = dbc.dr["varMobile"].ToString();
                    dbc.con.Close();
                    dbc.dr.Close();
                }

            }
            catch (Exception ex)
            {

                MessageDisplay(Resources.ErrorMessages.Error, "alert dark  alert-dismissible  alert-danger");

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




        public void clear()
        {
            txtDate.Text = "";
            txtContactPerson.Text = "";
            txtCustomerName.Text = "";
            txtLandLine.Text = "";
            txtLocation.Text = "";
            txtMobile.Text = "";
            txtNextCall.Text = "";
            txtRemark.Text = "";
            txtTime.Text = "";

        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            clear();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                //string confirmValue = Request.Form["confirm_value"];
                //if (confirmValue == "Yes")
                //{
                    int insert_ok = dbc.insert_tblDSRDetails(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)), lblCustName.Text, txtDate.Text, txtTime.Text, txtLocation.Text, call(), txtCustomerName.Text, txtContactPerson.Text, txtLandLine.Text, txtMobile.Text, txtRemark.Text, txtNextCall.Text, "NA",ddlStatus.SelectedValue);
                    if (insert_ok == 1)
                    {
                    MessageDisplay(Resources.Messages.Added, "alert dark  alert-dismissible  alert-success");

                    clear();
                    }
                else
                {
                    MessageDisplay(Resources.ErrorMessages.Error, "alert dark  alert-dismissible  alert-danger");

                }
                getDSR();

               // }
                //else
                //{
                //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
                //}
            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.Error, "alert dark  alert-dismissible  alert-danger");


            }
        }
        public string call()
        {
            if (rdbFollowUp.Checked == true)
            {
                return "Follow Up Call";
            }
            else if (rdbNewCall.Checked == true)
            {
                return "New Call";
            }
            else
            {
                return "Visit";
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        protected void btnview_Click(object sender, EventArgs e)
        {
            getdsrdata();
        }

        public void getdsrdata()
        {
            string temp = string.Empty, where = string.Empty;
            if (txtFromDate.Text == "")
            {
                MessageDisplay(Resources.Common.Date, "alert dark  alert-dismissible  alert-danger");

            }
            else if (txtToDate.Text == "")
            {
                MessageDisplay(Resources.Common.Date, "alert dark  alert-dismissible  alert-danger");

            }
            else if (txtCmpName.Text != "-- Select Customer --")
            {
                SqlDataSourceDSR.SelectCommand = "SELECT intId, varEmpName, varDate, varLocation, varCallType, varCustName, varRepersentName, varLandline, varMobile, varRemark, varNextDate FROM tblsudsrdetails WHERE (intEmpId =" + rex.DecryptString(Request.Cookies["LoginId"].Value) + ")  AND (varCustName like '%" + txtCmpName.Text + "%') and CAST(STR_TO_DATE(varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)";
                grdDSR.DataBind();

            }
            else
            {
                MessageDisplay(Resources.Common.Select, "alert dark  alert-dismissible  alert-danger");


            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                getdsrdata();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DSR.xls"));
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grdDSR.AllowPaging = false;
                //Change the Header Row back to white color
                // grdReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
                //Applying stlye to gridview header cells


                grdDSR.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.IncorrectValues, "alert dark  alert-dismissible  alert-danger");


            }
        }
    }
}