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
    public partial class GeneralLedger : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        DataTable dt = new DataTable();
        static Int16 mydivid = 0;
        DateTime datef, datet;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.UtcNow.ToString("dd-MM-yyyy");
                txtToDate.Text = DateTime.UtcNow.ToString("dd-MM-yyyy");
             
                getDivision();
                getAccount();
                ShowLedger();

            }
        }
      
      
        protected void gdvAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvAccount.PageIndex = e.NewPageIndex;
            ShowLedger();
        }
        public void ShowLedger()
        {
            try
            {
                DataTable dt = new DataTable();
                dbc.con.Open();
                //string divid = dbc.getVibhagName(ddldivision.Text).ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,substring(DATE_FORMAT(varDate, '%d-%m-%Y'),1,10) as 'Date',varAccountNo as 'Account Code' ,varAccountName as 'Account  Name',varParticulers as 'Details',varAccountBookEntry as 'Day Book No', varDebitAmount as 'Credit Amount',varCreditAmount as 'Debit Amount',varAccountEntryType as 'Credit / Debit' FROM tblamsledger WHERE varAccountNo!=0 ORDER BY varDate asc , intId asc", dbc.con);//WHERE   varDivisionId='"+ divid + "'
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                adp.Fill(dt);
                gdvAccount.DataSource = dt;
                gdvAccount.DataBind();
                dbc.con.Close();
            }
            catch (Exception s)
            {
                Response.Write(s.Message);
                Response.Write("<script>alert('Please Try Again');</script>");
            }
        }
        public void getDivision()
        {
            try
            {
                DataTable dtc = new DataTable();
                dbc.con2.Close();
                MySql.Data.MySqlClient.MySqlCommand cmdp = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varDivisionName FROM tblamsdivision", dbc.con2);
                dbc.con2.Open();
                MySqlDataAdapter adpc = new MySqlDataAdapter(cmdp);
                adpc.Fill(dtc);
                ddldivision.DataSource = dtc;
                ddldivision.DataTextField = "varDivisionName";
                ddldivision.DataValueField = "varDivisionName";
                ddldivision.DataBind();
                dbc.con2.Close();
                dtc.Dispose();
            }
            catch (Exception s)
            {

                Response.Write("<script>alert('Please Try Again');</script>");

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

                Response.Write("<script>alert('Please Try Again');</script>");

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddldivision.SelectedValue == "0")
                {
                    Response.Write("<script>alert('Please Select Division');window.location='GeneralLedger.aspx';</script>");
                }

                else if (ddlAccount.SelectedValue == "0")
                {
                    string divid = dbc.getVibhagid(ddldivision.Text).ToString();
                    datef = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    datet = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                    divmyheader.Visible = true;
                    lblDept.Text = ddldivision.Text;
                    lblmyacc.Text = "";
                    lbldatefrom.Text = Convert.ToString(txtFromDate.Text);
                    lbldateto.Text = Convert.ToString(txtToDate.Text);
                    lblAccNo.Text = dbc.getAccoutID(ddlAccount.Text);
                    DataTable dt = new DataTable();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

                    cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, substring(DATE_FORMAT(varDate, '%d-%m-%Y'),1,10) as 'Date', varAccountNo as 'Account Code' ,varAccountName as 'Account  Name', varParticulers as 'Details', varAccountBookEntry as 'Day Book No', varDebitAmount as 'Credit Amount', varCreditAmount as 'Debit Amount', varAccountEntryType as 'Credit / Debit' FROM tblamsledger WHERE varDivisionId = '" + divid + "' and  varAccountNo!=0 and  varDate BETWEEN '" + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + "' ORDER BY varDate  asc , intId asc", dbc.con);
                    MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    gdvAccount.DataSource = dt;
                    gdvAccount.DataBind();
                    dbc.con.Close();
                    //Response.Write("<script>alert('Please Slect Account Name');window.location='GeneralLedger.aspx';</script>");
                }
                else
                {
                    string divisionname = ddldivision.Text;
                    string divid = dbc.getVibhagid(ddldivision.Text).ToString();
                    datef = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    datet = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    divmyheader.Visible = true;
                    lblDept.Text = ddldivision.Text;
                    lblmyacc.Text = ddlAccount.Text;
                    lbldatefrom.Text = Convert.ToString(txtFromDate.Text);
                    lbldateto.Text = Convert.ToString(txtToDate.Text);
                    lblAccNo.Text = dbc.getAccoutID(ddlAccount.Text);
                    DataTable dt = new DataTable();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

                    cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, substring(DATE_FORMAT(varDate, '%d-%m-%Y'),1,10) as 'Date',varAccountNo as 'Account Code' , varAccountName as 'Account  Name', varParticulers as 'Details', varAccountBookEntry as 'Day Book No', varDebitAmount as 'Credit Amount', varCreditAmount as 'Debit Amount', varAccountEntryType as 'Credit / Debit' FROM tblamsledger WHERE varDivisionId = '" + divid + "' and  varAccountNo!=0 and  varAccountName = '" + ddlAccount.Text + "' and  varDate BETWEEN '" + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + "' ORDER BY varDate  asc , intId asc", dbc.con);
                    MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    gdvAccount.DataSource = dt;
                    gdvAccount.DataBind();
                    dbc.con.Close();
                }
            }
            catch (Exception s)
            {

                Response.Write("<script>alert('Please Try Again');</script>");

            }
        }

        private decimal TotalPriceJ = (decimal)0.0;
        private decimal TotalPriceN = (decimal)0.0;
        protected void gdvAccount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                // if row type is DataRow, add ProductSales value to TotalSales
                TotalPriceJ += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Credit Amount"));
            else if (e.Row.RowType == DataControlRowType.Footer)
            // If row type is footer, show calculated total value
            // Since this example uses sales in dollars, I formatted output as currency
            {
                e.Row.Cells[4].Text = TotalPriceJ.ToString();
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
                // if row type is DataRow, add ProductSales value to TotalSales
                TotalPriceN += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Debit Amount"));
            else if (e.Row.RowType == DataControlRowType.Footer)
            // If row type is footer, show calculated total value
            // Since this example uses sales in dollars, I formatted output as currency
            {
                e.Row.Cells[5].Text = TotalPriceN.ToString();
            }
        }
    }
}