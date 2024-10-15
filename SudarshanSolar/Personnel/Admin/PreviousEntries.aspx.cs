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
    public partial class PreviousEntries : System.Web.UI.Page
    {

        DatabaseConnection dbc = new DatabaseConnection();
        static int kirdid = 0;
        DateTime datef, datet;
        static string myaccnoj = string.Empty;
        static string myaccnon = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["vibhag"] == null)
            {
                Response.Redirect("SelectDivision.aspx", false);
            }
            else if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.UtcNow.ToString("dd-MM-yyyy");
                txtToDate.Text = DateTime.UtcNow.ToString("dd-MM-yyyy");
            
                lblVibhagName.Text = dbc.getVibhagName(Session["vibhag"].ToString());
                getAccount();
                ShowKirda();
            }

        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }

        public void ShowKirda()
        {
            try
            {
                DataTable dt = new DataTable();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varAccountBookEntry as 'Day Book No', substring(DATE_FORMAT(varDate, '%d-%m-%Y'),1,10) as 'Date', varAccountName as 'Account  Name', varAccountNo as 'Account Code', varVoucher as 'Voucher No', varReason as 'Details', varAmount as 'Amount', varAccountEntryType as 'Credit / Debit' FROM tblamsaccountbook WHERE varDivisionId='" + Session["vibhag"].ToString() + "'  and varAccountNo!=0  order by varDate desc, intId desc", dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                adp.Fill(dt);
                grdAccountBook.DataSource = dt;
                grdAccountBook.DataBind();
                dbc.con.Close();

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdj = new MySql.Data.MySqlClient.MySqlCommand();
                cmdj = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUM(varAmount) as 'Amount' FROM tblamsaccountbook WHERE varDivisionId='" + Session["vibhag"].ToString() + "'  and varAccountEntryType='Credit' order by varDate desc, intId desc", dbc.con);
                MySql.Data.MySqlClient.MySqlDataReader adpj = cmdj.ExecuteReader();
                if (adpj.Read())
                {
                    hdnTotalJama.Value = adpj["Amount"].ToString();
                }
                dbc.con.Close();

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdn = new MySql.Data.MySqlClient.MySqlCommand();
                cmdn = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUM(varAmount) as 'Amount' FROM tblamsaccountbook WHERE varDivisionId='" + Session["vibhag"].ToString() + "'  and varAccountEntryType='Debit' order by varDate desc, intId desc", dbc.con);
                MySql.Data.MySqlClient.MySqlDataReader adpn = cmdn.ExecuteReader();
                if (adpn.Read())
                {
                    hdnTotalNave.Value = adpn["Amount"].ToString();
                }
                dbc.con.Close();

            }
            catch (Exception s)
            {
                Response.Write(s.Message);

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlAccount.SelectedValue == "0")
                {
                    MessageDisplay("Please Select Account Name", "alert dark  alert-danger alert-dismissible");
                  //  Response.Write("<script>alert('');window.location='PreviousEntries.aspx';</script>");
                }
                else
                {
                    datef = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    datet = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    DataTable dt = new DataTable();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varAccountBookEntry as 'Day Book No', substring(DATE_FORMAT(varDate, '%d-%m-%Y'),1,10) as 'Date', varAccountName as 'Account  Name', varAccountNo as 'Account Code', varVoucher as 'Voucher No', varReason as 'Details', varAmount as 'Amount', varAccountEntryType as 'Credit / Debit' FROM tblamsaccountbook WHERE varDivisionId = '" + Session["vibhag"].ToString() + "'  and varAccountNo!=0 and varAccountName='" + ddlAccount.Text + "' and varDate BETWEEN '" + datef.ToString("yyyy-MM-dd") + "' and '" + datet.ToString("yyyy-MM-dd") + "' ORDER BY varDate desc", dbc.con);
                    MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    grdAccountBook.DataSource = dt;
                    grdAccountBook.DataBind();
                    dbc.con.Close();
                }
            }
            catch (Exception s)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");

            }
        }
        protected void gdvAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAccountBook.PageIndex = e.NewPageIndex;
            ShowKirda();
        }
        protected void gdvAccount_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                string commandArgs = e.CommandArgument.ToString();
                if (commandArgs == "")
                {
                    Response.Write("<script>alert('Account Change Not Possible or entry will be Incorrect');window.location='PreviousEntries.aspx';</script>");
                }
                else
                {
                    if (e.CommandName == "Edits")
                    {
                        dbc.con.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT PreviousBalance,intId, varAccountBookEntry as 'Day Book No', varDate as 'Date', varAccountName as 'Account  Name', varAccountNo as 'Account Code', varVoucher as 'Voucher No', varReason as 'Details', varAmount as 'Amount', varAccountEntryType as 'Credit / Debit',varBalance FROM tblamsaccountbook where intId=" + e.CommandArgument.ToString() + "", dbc.con);

                        dbc.dr = cmd.ExecuteReader();
                        if (dbc.dr.Read())
                        {
                            kirdid = Convert.ToInt16(dbc.dr["intId"].ToString());
                            //   DateTime.ParseExact(dbc.dr["Date"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                            txtDateJ.Text = dbc.dr["Date"].ToString();
                            txtAccountNameJ.Text = dbc.dr["Account Code"].ToString() + "_" + dbc.dr["Account  Name"].ToString();
                            txtVoucherNoJ.Text = dbc.dr["Voucher No"].ToString();
                            txtReasonJ.Text = dbc.dr["Details"].ToString();
                            txtAmountJ.Text = dbc.dr["Amount"].ToString();
                            hdnTransactionType.Value = dbc.dr["Credit / Debit"].ToString();
                            hdnPreviousAmount.Value = dbc.dr["Amount"].ToString();
                            hdnPreviousBalance.Value = dbc.dr["PreviousBalance"].ToString();
                        }
                        dbc.con.Close();
                    }
                    else if (e.CommandName == "Deletes")
                    {
                        dbc.con.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varAccountBookEntry as 'Day Book No', varDate as 'Date', varAccountName as 'Account  Name', varAccountNo as 'Account Code', varVoucher as 'Voucher No', varReason as 'Details', varAmount as 'Amount', varAccountEntryType as 'Credit / Debit',varBalance FROM tblamsaccountbook where intId=" + e.CommandArgument.ToString() + "", dbc.con);

                        dbc.dr = cmd.ExecuteReader();
                        if (dbc.dr.Read())
                        {
                            int insert_ok = dbc.delete_tblamsaccountbook(Convert.ToInt32(e.CommandArgument.ToString()), dbc.dr["Amount"].ToString(), dbc.dr["Date"].ToString(), dbc.dr["Account  Name"].ToString(), dbc.dr["Account Code"].ToString(), dbc.dr["Voucher No"].ToString(), dbc.dr["Details"].ToString(), dbc.dr["Credit / Debit"].ToString(), Session["vibhag"].ToString(), dbc.dr["varBalance"].ToString(), dbc.dr["Amount"].ToString());

                            if (insert_ok == 1)
                            {
                                ScriptManager.RegisterStartupScript(
                                   this,
                                   this.GetType(),
                                   "MessageBox",
                                   "alert('Entry Deleted Successfully !!!');window.location='PreviousEntries.aspx';", true);
                            }
                        }
                    }
                    dbc.con.Close();
                }
            }
            catch (Exception s)
            {
                Response.Write(s.Message);
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
        public void getAccount()
        {
            try
            {
                DataTable dtc = new DataTable();
                dbc.con2.Close();
                MySql.Data.MySqlClient.MySqlCommand cmdp = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varAccountName FROM tblamsaccountpersonnel", dbc.con2);
                dbc.con2.Open();
                MySqlDataAdapter adpc = new MySqlDataAdapter(cmdp);
                adpc.Fill(dtc);
                ddlAccount.DataSource = dtc;
                ddlAccount.DataTextField = "varAccountName";
                ddlAccount.DataValueField = "varAccountName";
                ddlAccount.DataBind();
                dbc.con2.Close();
                dtc.Dispose();
            }
            catch (Exception s)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
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
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAmountJ.Text == "0")
                {
                    MessageDisplay("Amount must not be Zero", "alert dark  alert-danger alert-dismissible");
                    //Response.Write("<script>alert('');window.location='PreviousEntries.aspx';</script>");
                }
                else
                {
                    if (hdnTransactionType.Value == "Credit")
                    {
                        double valueCheck = (Convert.ToDouble(hdnTotalJama.Value) - Convert.ToDouble(hdnPreviousAmount.Value) + Convert.ToDouble(txtAmountJ.Text)) - Convert.ToDouble(hdnTotalNave.Value);
                        if (valueCheck >= 0)
                        {

                            string[] arry = txtAccountNameJ.Text.Split(new char[] { '_' });
                            int insert_ok = dbc.Update_tblamsaccountbook(kirdid, txtAmountJ.Text, DateTime.ParseExact(txtDateJ.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"), arry[1].ToString(), arry[0].ToString(), txtVoucherNoJ.Text, txtReasonJ.Text, hdnTransactionType.Value.ToString(), Session["vibhag"].ToString(), hdnPreviousBalance.Value.ToString(), hdnPreviousAmount.Value.ToString());

                            if (insert_ok == 1)
                            {
                                MessageDisplay("Updated Successfully!!!", "alert dark  alert-success alert-dismissible");
                               
                            }
                        }
                        else
                        {
                            MessageDisplay("Account Change Not Possible or entry will be Incorrect !!!", "alert dark  alert-danger alert-dismissible");
                        }
                    }
                    else
                    {
                        double valueCheck = Convert.ToDouble(hdnTotalJama.Value) - (Convert.ToDouble(hdnTotalNave.Value) - Convert.ToDouble(hdnPreviousAmount.Value) + Convert.ToDouble(txtAmountJ.Text));
                        if (valueCheck >= 0)
                        {
                            string[] arry = txtAccountNameJ.Text.Split(new char[] { '_' });
                            int insert_ok = dbc.Update_tblamsaccountbook(kirdid, txtAmountJ.Text, DateTime.ParseExact(txtDateJ.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"), arry[1].ToString(), arry[0].ToString(), txtVoucherNoJ.Text, txtReasonJ.Text, hdnTransactionType.Value.ToString(), Session["vibhag"].ToString(), hdnPreviousBalance.Value.ToString(), hdnPreviousAmount.Value.ToString());

                            if (insert_ok == 1)
                            {
                                MessageDisplay("Updated Successfully!!!", "alert dark  alert-success alert-dismissible");
                               
                            }
                        }
                        else
                        {
                            MessageDisplay("Account Change Not Possible or entry will be Incorrect !!!", "alert dark  alert-danger alert-dismissible");
                        }
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