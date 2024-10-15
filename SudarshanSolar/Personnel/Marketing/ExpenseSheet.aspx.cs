using System;
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
    public partial class ExpenseSheet : System.Web.UI.Page
    {
        RegexUtilities rex = new RegexUtilities();
        DatabaseConnection dbc = new DatabaseConnection();
        static string empdesig = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

           
            if (!IsPostBack)
            {

                      notifications();
                getExpenseSheets();
                MakeDataTable();
            }
            else
            {
                dt = (DataTable)ViewState["DataTable"];
            }
            ViewState["DataTable"] = dt;
        }
        DataTable dt = new DataTable();
        private void MakeDataTable()
        {

            dt.Columns.Add("Date");
            dt.Columns.Add("Place");
            dt.Columns.Add("Details of expenses");
            dt.Columns.Add("Transport");
            dt.Columns.Add("Local Exp");
            dt.Columns.Add("Lodging");
            dt.Columns.Add("DA");
            dt.Columns.Add("Other");
            dt.Columns.Add("Total");

            grdSheetDetails.DataSource = dt;
            grdSheetDetails.DataBind();
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        public void getExpenseSheets()
        {
            try
            {
                dbc.con.Open();
                DataTable view = new DataTable();
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySqlDataAdapter("SELECT intId,  dtStartDate as 'Start Date', dtEndDate as 'End Date', nvarLocation as 'Location', nvarTotalExpense as 'Total Expenses' FROM tblsuexpenses WHERE intEmpId=" + rex.DecryptString(Request.Cookies["LoginId"].Value) + "", dbc.con);
                adp.Fill(view);
                grdView.DataSource = view;
                grdView.DataBind();
                grdView.Columns[0].Visible = false;
                dbc.con.Close();
            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
            }
        }
        public void notifications()
        {
//lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)), empdesig).ToString();
        }
        
       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();

            dr["Date"] = txtDate.Text;
            dr["Place"] = txtPlace.Text;
            dr["Details of expenses"] = txtDetails.Text;
            dr["Transport"] = txtModeOfTransport.Text;
            dr["Local Exp"] = txtLocalExp.Text;
            dr["Lodging"] = txtLodging.Text;
            dr["DA"] = txtDA.Text;
            dr["Other"] = txtOther.Text;
            dr["Total"] = txtTotal.Text;

            dt.Rows.Add(dr);

            grdSheetDetails.DataSource = dt;
            grdSheetDetails.DataBind();

            addClear();
        }

        public void addClear()
        {
            txtDA.Text = "";
            txtDate.Text = "";
            txtDetails.Text = "";
            txtLocalExp.Text = "";
            txtLodging.Text = "";
            txtModeOfTransport.Text = "";
            txtOther.Text = "";
            txtPlace.Text = "";
            txtTotal.Text = "";
        }
        public void clear()
        {
            txtDA.Text = "";
            txtDate.Text = "";
            txtDetails.Text = "";
            txtLocalExp.Text = "";
            txtLodging.Text = "";
            txtModeOfTransport.Text = "";
            txtOther.Text = "";
            txtPlace.Text = "";
            txtTotal.Text = "";

            txtLocation.Text = "";
            txtFDate.Text = "";
            txtTDate.Text = "";

            dt.Rows.Clear();
            dt.Dispose();

            grdSheetDetails.DataSource = null;
            grdSheetDetails.DataBind();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Personnel/marketing/ExpenseSheet.aspx", false);
        }

        protected void btnSubmitSheet_Click(object sender, EventArgs e)
        {
            try
            {
                //string confirmValue = Request.Form["confirm_value"];
                //if (confirmValue == "Yes")
                //{
                    if (grdSheetDetails.Rows.Count <= 0)
                    {
                        Response.Write("<script>alert('Please add details to sheet..!!');window.location='ExpenseSheet.aspx';</script>");
                    }
                    else
                    {
                        if (txtFDate.Text == "")
                        {
                        MessageDisplay(Resources.Common.Date, "alert dark  alert-dismissible  alert-danger");
                    }
                    else if (txtTDate.Text == "")
                        {
                        MessageDisplay(Resources.Common.Date, "alert dark  alert-dismissible  alert-danger");

                    }
                    else if (txtLocation.Text == "")
                        {
                        MessageDisplay(Resources.Common.location, "alert dark  alert-dismissible  alert-danger");
                    }
                    else
                        {
                            int expd = 0;
                            GridViewRow frow = grdSheetDetails.FooterRow;
                            Int64 insert_ok = dbc.insert_tblsuexpenses(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)), txtFDate.Text, "", txtLocation.Text, "", frow.Cells[9].Text.ToString(), txtTDate.Text, "", "");


                            foreach (DataRow grow in dt.Rows)
                            {
                                expd = dbc.insert_tblsuexpensesdetails(insert_ok, grow[0].ToString(), grow[1].ToString(), grow[2].ToString(), grow[3].ToString(), grow[4].ToString(), grow[5].ToString(), grow[6].ToString(), grow[7].ToString(), grow[8].ToString());
                            }
                            if (expd == 0)
                            {
                            MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
                            Response.Redirect("~/Personnel/marketing/ExpenseSheet.aspx", false);

                        }
                        else
                            {
                            MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
                            Response.Redirect("~/Personnel/marketing/ExpenseSheet.aspx", false);

                        }
                    }
                    }
                //}
                //else
                //{
                //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
                //}


            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");

            }
        }
        private decimal TotalPrice = (decimal)0.0;
        protected void grdSheetDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // check row type
            if (e.Row.RowType == DataControlRowType.DataRow)
                // if row type is DataRow, add ProductSales value to TotalSales
                TotalPrice += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));
            else if (e.Row.RowType == DataControlRowType.Footer)
            // If row type is footer, show calculated total value
            // Since this example uses sales in dollars, I formatted output as currency
            {
                e.Row.Cells[9].Text = TotalPrice.ToString();
            }
        }

        protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "views")
                {
                    int expenseId = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("~/Personnel/marketing/ViewEmployeeExpenses.aspx?expenseId=" + expenseId + "", false);
                }
                else if (e.CommandName == "edits")
                {
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,dtStartDate, nvarAdvance, nvarLocation, nvarBalance, nvarTotalExpense, dtEndDate, imgSignature, nvarRemark FROM tblsuexpenses where intId=" + e.CommandArgument + "", dbc.con);

                    dbc.dr = cmd.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        txtintId.Text = dbc.dr["intId"].ToString();
                        txtFDate.Text = dbc.dr["dtStartDate"].ToString();
                        txtTDate.Text = dbc.dr["dtEndDate"].ToString();
                        txtLocation.Text = dbc.dr["nvarLocation"].ToString();

                    }
                    dbc.con.Close();


                    dbc.con.Open();
                    dbc.dataAdapter = new MySqlDataAdapter("SELECT dtDate AS Date, nvarPlace AS Place, nvarExpenseDetail AS 'Details of expenses', nvarModeOfTransport AS Transport, nvarLocal AS 'Local Exp', nvarLodging AS Lodging, nvarDA AS DA, nvarOther AS Other, nvarTotal AS Total FROM tblsuexpensesdetails where intExpensesId=" + e.CommandArgument + "", dbc.con);
                    dbc.dataAdapter.Fill(dt);

                    grdSheetDetails.DataSource = dt;
                    grdSheetDetails.DataBind();
                    btnEditUpdate.Visible = true;
                    btnSubmitSheet.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");

            }
        }
        protected void btnEditUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow frow = grdSheetDetails.FooterRow;

                dbc.con.Close();
                dbc.con.Open();
                dbc.cmd = new MySqlCommand("UPDATE tblsuexpenses SET nvarTotalExpense='" + frow.Cells[9].Text.ToString() + "', dtStartDate='" + txtFDate.Text + "', nvarLocation='" + txtLocation.Text + "',dtEndDate='" + txtTDate.Text + "' WHERE intId=" + txtintId.Text + "", dbc.con);
                dbc.cmd.ExecuteNonQuery();
                dbc.con.Close();

                dbc.con.Close();
                dbc.con.Open();
                dbc.cmd = new MySqlCommand("DELETE FROM tblsuexpensesdetails WHERE intExpensesId=" + txtintId.Text + "", dbc.con);
                dbc.cmd.ExecuteNonQuery();
                dbc.con.Close();

                int expd = 0;

                foreach (DataRow grow in dt.Rows)
                {
                    expd = dbc.insert_tblsuexpensesdetails(Convert.ToInt64(txtintId.Text), grow[0].ToString(), grow[1].ToString(), grow[2].ToString(), grow[3].ToString(), grow[4].ToString(), grow[5].ToString(), grow[6].ToString(), grow[7].ToString(), grow[8].ToString());
                }
                if (expd == 0)
                {
                    MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
                    Response.Redirect("~/Personnel/marketing/ExpenseSheet.aspx", false);
                }
                else
                {
                    MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
                    Response.Redirect("~/Personnel/marketing/ExpenseSheet.aspx", false);
                }
                MessageDisplay(Resources.Messages.Updated, "alert dark  alert-dismissible  alert-success");

 
                clear();

            }
            catch (Exception ecc)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");

            }
        }
        protected void grdSheetDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "remove")
                {
                    GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    int RemoveAt = gvr.RowIndex;
                    dt = (DataTable)ViewState["DataTable"];
                    dt.Rows.RemoveAt(RemoveAt);
                    dt.AcceptChanges();

                    ViewState["DataTable"] = dt;
                    grdSheetDetails.DataSource = dt;
                    grdSheetDetails.DataBind();
                    MessageDisplay(Resources.Messages.Deleted, "alert dark  alert-dismissible  alert-success");
                    Response.Redirect("~/Personnel/marketing/ExpenseSheet.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    //public void getempname()
    //{
    //    try
    //    {

    //        dbc.con.Open();
    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName,varSubDesig FROM anuvaa_solar.tblsupersonnel where intId=" + rex.DecryptString(Request.Cookies["LoginId"].Value) + "", dbc.con);

    //        dbc.dr = cmd.ExecuteReader();
    //        if (dbc.dr.Read())
    //        {
    //            lblCustName.Text = dbc.dr["varName"].ToString();
    //            empdesig = dbc.dr["varSubDesig"].ToString();
    //            dbc.con.Close();
    //            dbc.dr.Close();
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write("<script>alert('Please Try Again');window.location='ExpenseSheet.aspx';</script>");
    //    }
    //}
    //public void getImage()
    //{
    //    try
    //    {

    //        string ImageUr = dbc.select_empProfilePic(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)));
    //        if (ImageUr == "")
    //        {
    //            imgProPic.ImageUrl = "~/Media/Employee/NoProfile.png";
    //        }
    //        else
    //        {

    //            imgProPic.ImageUrl = "~/Media/Employee/" + ImageUr;
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        Response.Redirect("~/login.aspx");
    //    }
    //    //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)) + "";
    //}
}