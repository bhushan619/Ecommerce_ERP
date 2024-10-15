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
using SudarshanSolar.DbCode;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class PrintEntries : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                try
                {
                 
                    lblVibhagName.Text = dbc.getVibhagName(Session["vibhag"].ToString());
                    txtFromDate.Text = DateTime.UtcNow.ToString("dd-MM-yyyy");
                    txtToDate.Text = DateTime.UtcNow.ToString("dd-MM-yyyy");
                }
                catch (Exception ex)
                {

                }
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        static Int64 totaljama = 0, totalnave = 0;
        MySqlDataReader rdr, rdr1, rdr2;

        string CDates = string.Empty;
        string CAccCode = string.Empty;
        string CVoucher = string.Empty;
        string CAccName = string.Empty;
        string CDetails = string.Empty;
        string CAmts = string.Empty;


        string DAccCode = string.Empty;
        string DVoucher = string.Empty;
        string DAccName = string.Empty;
        string DDetails = string.Empty;
        string DAmts = string.Empty;
        static string jamastr, navestr;
        public void DataBind(string fdate, string tdate)
        {
            try
            {
                DateTime datef, datet;
                datef = DateTime.ParseExact(fdate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                datet = DateTime.ParseExact(tdate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
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
                    string divisionname = dbc.getVibhagName(Session["vibhag"].ToString());
                    string divid = Session["vibhag"].ToString();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("CDates");
                    dt.Columns.Add("CAccCode");
                    dt.Columns.Add("CVoucher");
                    dt.Columns.Add("CAccName");
                    dt.Columns.Add("CDetails");
                    dt.Columns.Add("CAmts");


                    dt.Columns.Add("DAccCode");
                    dt.Columns.Add("DVoucher");
                    dt.Columns.Add("DAccName");
                    dt.Columns.Add("DDetails");
                    dt.Columns.Add("DAmts");

                    MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT  substring(DATE_FORMAT(varDate, '%d-%m-%Y'),1,10) as SearchDate FROM tblamsaccountbook WHERE varDivisionId='" + Session["vibhag"].ToString() + "' and  varAccountNo!=0 and varDate between '" + DateTime.ParseExact(fdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' and '" + DateTime.ParseExact(tdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' order by varDate,intId asc", dbc.con2);
                    cmd.CommandType = CommandType.Text;

                    using (dbc.con2)
                    {
                        dbc.con2.Open();

                        rdr1 = cmd.ExecuteReader();
                        //jama

                        while (rdr1.Read())
                        {

                            totaljama = Convert.ToInt64(dbc.getFirstAmountTerij(DateTime.ParseExact(rdr1["SearchDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"), "asc", Session["vibhag"].ToString()));
                            int countjama = 0, countnave = 0, count = 0;

                            MySqlCommand cmdd = new MySqlCommand("SELECT  count(intId) as nos FROM tblamsaccountbook WHERE varDivisionId='" + Session["vibhag"].ToString() + "' and varAccountEntryType='Credit' and varAccountNo!=0 and varDate= '" + DateTime.ParseExact(rdr1["SearchDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' order by intId asc", dbc.con1);
                            cmdd.CommandType = CommandType.Text;

                            using (dbc.con1)
                            {
                                dbc.con1.Open();

                                rdr2 = cmdd.ExecuteReader();

                                while (rdr2.Read())
                                {
                                    countjama = Convert.ToInt32(rdr2["nos"].ToString());
                                }
                            }
                            cmdd = new MySqlCommand("SELECT  count(intId) as nos FROM tblamsaccountbook WHERE varDivisionId='" + Session["vibhag"].ToString() + "' and varAccountEntryType='Debit' and varAccountNo!=0 and varDate= '" + DateTime.ParseExact(rdr1["SearchDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' order by intId asc", dbc.con1);
                            cmdd.CommandType = CommandType.Text;

                            using (dbc.con1)
                            {
                                dbc.con1.Open();

                                rdr2 = cmdd.ExecuteReader();

                                while (rdr2.Read())
                                {
                                    countnave = Convert.ToInt32(rdr2["nos"].ToString());
                                }
                            }
                            if (countjama > countnave)
                            {
                                count = countjama;
                            }
                            else
                            {
                                count = countnave;
                            }
                            dt.Rows.Add(rdr1["SearchDate"].ToString(), "", "", "Initial Balance", "", totaljama, "", "", "", "", "");
                            for (int x = 0; x < count; x++)
                            {

                                CDates = "";
                                CAccCode = "";
                                CVoucher = "";
                                CAccName = "";
                                CDetails = "";
                                CAmts = "";


                                DAccCode = "";
                                DVoucher = "";
                                DAccName = "";
                                DDetails = "";
                                DAmts = "";

                                jamastr = jamas("SELECT intId, varAccountBookEntry as 'Day Book No', substring(DATE_FORMAT(varDate, '%d-%m-%Y'),1,10) as 'CDates', varAccountName as 'CAccount  Name', varAccountNo as 'CAccount Code', varVoucher as 'CVoucher No', varReason as 'CDetails', varAmount as 'CAmount', varAccountEntryType as 'CCredit / Debit' FROM tblamsaccountbook WHERE varDivisionId='" + Session["vibhag"].ToString() + "' and varAccountEntryType='Credit' and varAccountNo!=0 and varDate= '" + DateTime.ParseExact(rdr1["SearchDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' order by intId asc LIMIT " + x + ",1");
                                navestr = naves("SELECT intId, varAccountBookEntry as 'DDay Book No', substring(DATE_FORMAT(varDate, '%d-%m-%Y'),1,10) as 'DDates', varAccountName as 'DAccount  Name', varAccountNo as 'DAccount Code', varVoucher as 'DVoucher No', varReason as 'DDetails', varAmount as 'DAmount', varAccountEntryType as 'DCredit / Debit' FROM tblamsaccountbook WHERE varDivisionId='" + Session["vibhag"].ToString() + "' and varAccountEntryType='Debit' and varAccountNo!=0  and varDate = '" + DateTime.ParseExact(rdr1["SearchDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' order by intId asc LIMIT " + x + ",1");

                                totaljama = totaljama + Convert.ToInt64(jamastr.Split(';')[5] == "" ? "0" : jamastr.Split(';')[5]);
                                totalnave = totalnave + Convert.ToInt64(navestr.Split(';')[4] == "" ? "0" : navestr.Split(';')[4]);
                                dt.Rows.Add(jamastr.Split(';')[0], jamastr.Split(';')[1], jamastr.Split(';')[2], jamastr.Split(';')[3], jamastr.Split(';')[4], jamastr.Split(';')[5], navestr.Split(';')[0], navestr.Split(';')[1], navestr.Split(';')[2], navestr.Split(';')[3], navestr.Split(';')[4]);

                            }
                            dt.Rows.Add(rdr1["SearchDate"].ToString(), "", "", "", "", "", "", "", "Closing Balance", "", dbc.getAmount(DateTime.ParseExact(rdr1["SearchDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"), "desc", Session["vibhag"].ToString()));
                            dt.Rows.Add(rdr1["SearchDate"].ToString(), "", "", "", "Total : ", totaljama, "", "", "", "Total : ", totalnave + Convert.ToInt64(dbc.getAmount(DateTime.ParseExact(rdr1["SearchDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"), "desc", Session["vibhag"].ToString())));
                            dt.Rows.Add("", "", "", "", "", "", "", "", "", "", "");
                            jamastr = ""; navestr = "";
                            totaljama = 0;
                            totalnave = 0;
                        }

                    }
                    gdvAccount.DataSource = dt;
                    gdvAccount.DataBind();

                }

            }
            catch (Exception s)
            {
                Response.Write(s.Message);
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }

        protected void gdvAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvAccount.PageIndex = e.NewPageIndex;
            //Showjamatoday();
        }
        public string jamas(string query)
        {

            MySqlCommand cmdd = new MySqlCommand(query, dbc.con);
            cmdd.CommandType = CommandType.Text;

            using (dbc.con)
            {
                dbc.con.Open();

                rdr = cmdd.ExecuteReader();

                if (rdr.Read())
                {
                    CDates = rdr["CDates"].ToString();
                    CAccName = rdr["CAccount  Name"].ToString();
                    CAccCode = rdr["CAccount Code"].ToString();
                    CVoucher = rdr["CVoucher No"].ToString();
                    CDetails = rdr["CDetails"].ToString();
                    CAmts = rdr["CAmount"].ToString();

                    //totaljama += Convert.ToInt64(CAmts);
                }

            }

            return CDates + ";" + CAccCode + ";" + CVoucher + ";" + CAccName + ";" + CDetails + ";" + CAmts + ";";
        }

        public string naves(string query)
        {


            MySqlCommand cmdnn = new MySqlCommand(query, dbc.con);
            cmdnn.CommandType = CommandType.Text;

            using (dbc.con)
            {
                dbc.con.Open();

                rdr = cmdnn.ExecuteReader();

                if (rdr.Read())
                {
                    DAccName = rdr["DAccount  Name"].ToString();
                    DAccCode = rdr["DAccount Code"].ToString();
                    DVoucher = rdr["DVoucher No"].ToString();
                    DDetails = rdr["DDetails"].ToString();
                    DAmts = rdr["DAmount"].ToString();

                    //totalnave += Convert.ToInt64(DAmts);

                }
            }
            return DAccCode + ";" + DVoucher + ";" + DAccName + ";" + DDetails + ";" + DAmts + ";";

        }
        protected void gdvAccount_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header) // If header created
            {
                GridView ProductGrid = (GridView)sender;

                // Creating a Row
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 1; // For merging first, second row cells to one
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding Revenue Column
                HeaderCell = new TableCell();
                HeaderCell.Text = "Credit";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 5; // For merging three columns (Direct, Referral, Total)
                HeaderCell.BackColor = System.Drawing.Color.SlateGray;
                HeaderCell.Font.Bold = true;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Debit";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 5; // For merging three columns (Direct, Referral, Total)
                HeaderCell.BackColor = System.Drawing.Color.SlateGray;
                HeaderCell.Font.Bold = true;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderRow.Cells.Add(HeaderCell);

                //Adding the Row at the 0th position (first row) in the Grid
                gdvAccount.Controls[0].Controls.AddAt(0, HeaderRow);
            }
        }
        
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DataBind(txtFromDate.Text, txtToDate.Text);
        }
        protected void gdvAccount_DataBound(object sender, EventArgs e)
        {

            for (int i = gdvAccount.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gdvAccount.Rows[i];
                GridViewRow previousRow = gdvAccount.Rows[i - 1];
                for (int j = 0; j < 1; j++)
                {
                    if (row.Cells[j].Text == previousRow.Cells[j].Text)
                    {
                        if (previousRow.Cells[j].RowSpan == 0)
                        {
                            if (row.Cells[j].RowSpan == 0)
                            {
                                previousRow.Cells[j].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                            }

                            row.Cells[j].Visible = false;
                        }
                    }
                }

            }
        }

    }
}