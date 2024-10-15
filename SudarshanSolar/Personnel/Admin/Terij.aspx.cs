using MySql.Data.MySqlClient;
using SudarshanSolar.DbCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class Terij : System.Web.UI.Page
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
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
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
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddldivision.SelectedValue == "0")
                {
                    Response.Write("<script>alert('Please Select Division');window.location='Terij.aspx';</script>");
                }
                else
                {
                    datef = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    datet = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    if (datef > DateTime.UtcNow)
                    {

                        MessageDisplay("Please Select Proper Date", "alert dark  alert-danger alert-dismissible");

                    }
                    else if (datet > DateTime.UtcNow)
                    {

                        MessageDisplay("Please Select Proper Date", "alert dark  alert-danger alert-dismissible");

                    }
                    else if (datef > datet)
                    {

                        MessageDisplay("Please Select Proper Date", "alert dark  alert-danger alert-dismissible");

                    }
                    else
                    {
                        string divisionname = ddldivision.Text;
                        string divid = dbc.getVibhagid(ddldivision.Text).ToString();

                        divmyheader.Visible = true;
                        lblDept.Text = ddldivision.Text;
                        lbldatefrom.Text = Convert.ToString(txtFromDate.Text);
                        lbldateto.Text = Convert.ToString(txtToDate.Text);
                        //jama

                        DataTable dt = new DataTable();

                        dt.Columns.Add("Account  Name");
                        dt.Columns.Add("Amount");

                        dt.Rows.Add("Initial Balance", dbc.getFirstAmountTerij(datef.ToString("yyyy-MM-dd"), "asc", divid));

                        dbc.con.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                        cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varAccountName as 'Account  Name', SUM(varAmount) AS 'Amount' FROM tblamsaccountbook where varAccountEntryType='Credit' AND (varAccountName !='" + ddldivision.Text + "') and varDivisionId='" + divid + "' and varDate BETWEEN '" + datef.ToString("yyyy-MM-dd") + "' and '" + datet.ToString("yyyy-MM-dd") + "' GROUP BY varAccountName ORDER BY varDate asc , intId asc", dbc.con);
                        MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                        adp.Fill(dt);

                        dbc.con.Close();

                        //nave 

                        DataTable dta = new DataTable();
                        dbc.con.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand();
                        cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT varAccountName as 'Account  Name', SUM(varAmount) AS 'Amount' FROM tblamsaccountbook where varAccountEntryType='Debit' AND (varAccountName !='" + ddldivision.Text + "') and varDivisionId='" + divid + "' and varDate BETWEEN '" + datef.ToString("yyyy-MM-dd") + "' and '" + datet.ToString("yyyy-MM-dd") + "' GROUP BY varAccountName ORDER BY varDate asc , intId asc", dbc.con);
                        MySql.Data.MySqlClient.MySqlDataAdapter adpa = new MySql.Data.MySqlClient.MySqlDataAdapter(cmda);
                        adpa.Fill(dta);
                        dta.Rows.Add("Closing Balance", dbc.getAmount(datet.ToString("yyyy-MM-dd"), "desc", divid));

                        dbc.con.Close();


                        if (dt.Rows.Count > dta.Rows.Count)
                        {
                            int cc = dt.Rows.Count - dta.Rows.Count;
                            for (int i = 0; i < cc; i++)
                            {
                                dta.Rows.Add(new object[] { null, null });
                            }
                            grdAccountNave.DataSource = dta;
                            grdAccountNave.DataBind();
                            gdvAccount.DataSource = dt;
                            gdvAccount.DataBind();
                        }
                        else
                        {
                            int cc1 = dta.Rows.Count - dt.Rows.Count;
                            for (int i = 0; i < cc1; i++)
                            {
                                dt.Rows.Add(new object[] { null, null });
                            }
                            grdAccountNave.DataSource = dta;
                            grdAccountNave.DataBind();
                            gdvAccount.DataSource = dt;
                            gdvAccount.DataBind();
                        }

                    }
                }
            }
            catch (Exception s)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
        private DataTable RemoveDuplicatesRecords(DataTable dt)
        {
            //Returns just 5 unique rows
            var UniqueRows = dt.AsEnumerable().Distinct(DataRowComparer.Default);
            DataTable dt2 = UniqueRows.CopyToDataTable();
            return dt2;
        }
        private decimal TotalPrice = (decimal)0.0;
        protected void gdvAccount_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            // check row type
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // if row type is DataRow, add ProductSales value to TotalSales
                if (DBNull.Value.Equals(DataBinder.Eval(e.Row.DataItem, "Amount")))
                { }
                else
                    TotalPrice += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            // If row type is footer, show calculated total value
            // Since this example uses sales in dollars, I formatted output as currency
            {
                e.Row.Cells[1].Text = TotalPrice.ToString();
            }
        }

        private decimal TotalPricenave = (decimal)0.0;
        protected void grdAccountNave_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // check row type
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // if row type is DataRow, add ProductSales value to TotalSales
                if (DBNull.Value.Equals(DataBinder.Eval(e.Row.DataItem, "Amount")))
                { }
                else
                    TotalPricenave += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
            }
            // if row type is DataRow, add ProductSales value to TotalSales

            else if (e.Row.RowType == DataControlRowType.Footer)
            // If row type is footer, show calculated total value
            // Since this example uses sales in dollars, I formatted output as currency
            {
                e.Row.Cells[1].Text = TotalPricenave.ToString();
            }
        }
    }
}