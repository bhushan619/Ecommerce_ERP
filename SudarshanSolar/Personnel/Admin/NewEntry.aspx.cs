using SudarshanSolar.DbCode;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class NewEntry : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["vibhag"] == null)
            {
                Response.Redirect("SelectDivision.aspx", false);
            }
            else if (!IsPostBack)
            {
               
                lblVibhagName.Text = dbc.getVibhagName(Session["vibhag"].ToString());
                // txtTotalAmount.Text= dbc.getAmountFromLedger(Session["vibhag"].ToString());


                lblDateUp.Text = DateTime.Now.ToString("dd-MM-yyyy");
                lblDateDown.Text = DateTime.Now.ToString("dd-MM-yyyy");

                txtDateJ.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtDateN.Text = DateTime.Now.ToString("dd-MM-yyyy");

                txtDayStartingAmount.Text = dbc.getFirstAmountTerij(DateTime.ParseExact(txtDateJ.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"), "asc", Session["vibhag"].ToString());
                txtDayEndingAmount.Text = dbc.getAmount(DateTime.ParseExact(txtDateJ.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"), "desc", Session["vibhag"].ToString());

                ShowKirda();
            }

        }

        public void ShowKirda()
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("intId");
                dt.Columns.Add("Day Book No");
                dt.Columns.Add("Date");
                dt.Columns.Add("Account  Name");
                dt.Columns.Add("Account Code");
                dt.Columns.Add("Voucher No");
                dt.Columns.Add("Details");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Credit / Debit");

                dbc.con.Open();
                dbc.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varAccountBookEntry as 'Day Book No', varDate as 'Date', varAccountName as 'Account  Name', varAccountNo as 'Account Code', varVoucher as 'Voucher No', varReason as 'Details', varAmount as 'Amount', varAccountEntryType as 'Credit / Debit' FROM tblamsaccountbook WHERE varDivisionId='" + Session["vibhag"].ToString() + "'  and varAccountNo!=0 and  varDate='" + DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' order by intId asc", dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(dbc.cmd);
                dt.Rows.Add(null, null, lblDateUp.Text, "Initial Balance", "", "", "", txtDayStartingAmount.Text, "");
                adp.Fill(dt);
                dt.Rows.Add(null, null, lblDateUp.Text, "Closing Balance", "", "", "", txtDayEndingAmount.Text, "");
                grdAccountBook.DataSource = dt;
                grdAccountBook.DataBind();
                dbc.con.Close();


                dbc.con.Open();
                dbc.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varAccountNo,'_', varAccountName) as  varAccountName FROM tblamsaccountpersonnel", dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(dbc.cmd);
                DataTable dtc = new DataTable();
                da.Fill(dtc);
                txtAccountNameJ.DataSource = dtc;
                txtAccountNameJ.DataTextField = "varAccountName";
                txtAccountNameJ.DataValueField = "varAccountName";
                txtAccountNameJ.DataBind();
                dbc.con.Close();

                dbc.con.Open();
                dbc.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varAccountNo,'_', varAccountName) as  varAccountName FROM tblamsaccountpersonnel", dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter das = new MySql.Data.MySqlClient.MySqlDataAdapter(dbc.cmd);
                DataTable dts = new DataTable();
                das.Fill(dts);
                txtAccountNameN.DataSource = dtc;
                txtAccountNameN.DataTextField = "varAccountName";
                txtAccountNameN.DataValueField = "varAccountName";
                txtAccountNameN.DataBind();
                dbc.con.Close();

            }
            catch (Exception s)
            {
                Response.Write(s.Message);

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        protected void gdvAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAccountBook.PageIndex = e.NewPageIndex;
            ShowKirda();
        }

     
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
        {
            String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["solarConnectionString"].ConnectionString;

            MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varAccountNo,'_', varAccountName) as  varAccountName FROM tblamsaccountpersonnel where varAccountName like '%" + prefixText + "%' AND intId between 1 and 500", con);
            //     cmd.Parameters.AddWithValue("@Name", prefixText);
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            MySql.Data.MySqlClient.MySqlConnection con1 = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varAccountNo, '_', varAccountName) as varAccountName FROM tblamsaccountpersonnel where varAccountName like '%" + prefixText + "%' AND intId  between 501 and 1000", con1);
            cmd.Parameters.AddWithValue("@Name", prefixText);
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


        protected void txtAccountNameJ_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] arry = txtAccountNameJ.Text.Split(new char[] { '_' });

                DataTable dt = new DataTable();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

                cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varAccountNo as 'Account Code', varAccountName as 'Account  Name', varMobile as 'Mobile No',varPhone as 'Phone No',	varEmail as 'Email',varAddress as 'Address' FROM tblamsaccountpersonnel WHERE varAccountNo='" + arry[0] + "'  AND  varAccountName='" + arry[1] + "'", dbc.con);
                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    txtLedgerNoJ.Text = dbc.dr["Account Code"].ToString();
                }

                dbc.con.Close();
            }
            catch (Exception ex)
            {

            }

        }

        protected void txtAccountNameN_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string[] arry = txtAccountNameN.Text.Split(new char[] { '_' });

                DataTable dt = new DataTable();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

                cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varAccountNo as 'Account Code', varAccountName as 'Account  Name', varMobile as 'Mobile No',varPhone as 'Phone No',	varEmail as 'Email',varAddress as 'Address' FROM tblamsaccountpersonnel WHERE varAccountNo='" + arry[0] + "'  AND  varAccountName='" + arry[1] + "'", dbc.con);
                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    txtLedgerNoN.Text = dbc.dr["Account Code"].ToString();
                }

                dbc.con.Close();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnJama_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(txtDateJ.Text) > Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy")))
                {
                    MessageDisplay("Please Select Proper Date !!!", "alert dark  alert-danger alert-dismissible");
                    
                }
                else
                {
                    string[] arry = txtAccountNameJ.Text.Split(new char[] { '_' });
                    int insert_ok = dbc.insert_tblamsaccountbookJama(DateTime.ParseExact(txtDateJ.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"), arry[1].ToString(), txtLedgerNoJ.Text, txtVoucherNoJ.Text, txtReasonJ.Text, txtAmountJ.Text, "Credit", Session["vibhag"].ToString(), (Convert.ToInt64(dbc.getAmount(DateTime.ParseExact(txtDateJ.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"), "desc", Session["vibhag"].ToString())) + Convert.ToInt64(txtAmountJ.Text)).ToString(), lblVibhagName.Text);

                    if (insert_ok == 1)
                    {
                        MessageDisplay("Entry Successfully Added ", "alert dark  alert-success alert-dismissible");
                       
                    }
                }
            }

            catch (Exception ex)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }

        protected void btnNave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(txtDateN.Text) > Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy")))
                {
                    MessageDisplay("Please Select Proper Date !!!", "alert dark  alert-danger alert-dismissible");
                   
                }
                else
                {
                    if (txtDayEndingAmount.Text != "0")
                    {
                        Int64 oldNave = Convert.ToInt64(dbc.getAmount(DateTime.ParseExact(txtDateN.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"), "desc", Session["vibhag"].ToString()));
                        if (oldNave == 0)
                        {
                            MessageDisplay("Account Change Not Possible or entry will be Incorrect !!!", "alert dark  alert-danger alert-dismissible");
                          
                        }
                        else if (oldNave < Convert.ToInt64(txtAmountN.Text))
                        {
                            MessageDisplay("Account Change Not Possible or entry will be Incorrect !!!", "alert dark  alert-danger alert-dismissible");
                         
                        }
                        else
                        {
                            string[] arry = txtAccountNameN.Text.Split(new char[] { '_' });
                            int insert_ok = dbc.insert_tblamsaccountbookNave(DateTime.ParseExact(txtDateN.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"), arry[1].ToString(), txtLedgerNoN.Text, txtVoucherNoN.Text, txtReasonN.Text, txtAmountN.Text, "Debit", Session["vibhag"].ToString(), (oldNave).ToString());

                            if (insert_ok == 1)
                            {
                                MessageDisplay("Entry Successfully Added  !!!", "alert dark  alert-success alert-dismissible");
                              
                            }
                        }
                    }
                    else
                    {
                        MessageDisplay("Account Change Not Possible or entry will be Incorrect !!!", "alert dark  alert-danger alert-dismissible");
                       
                    }
                }
            }

            catch (Exception ex)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
    }
}