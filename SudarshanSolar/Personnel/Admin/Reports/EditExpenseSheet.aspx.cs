using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using SudarshanSolar.DbCode;
namespace SudarshanSolar.Personnel.Admin.Reports
{
    public partial class EditExpenseSheet : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        static string empdesig = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                notifications();
                //MakeDataTable();
                getExpenseSheets();
            }
            else
            {
                dt = (DataTable)ViewState["DataTable"];
            }
            ViewState["DataTable"] = dt;
        }
        public void notifications()
        {
            //lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
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
        public void getExpenseSheets()
        {
            try
            {
                dbc.con.Close();

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,dtStartDate, nvarAdvance, nvarLocation, nvarBalance, nvarTotalExpense, dtEndDate, imgSignature, nvarRemark FROM tblsuexpenses where intId=" + Request.QueryString[0].ToString() + "", dbc.con);

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
                dbc.dataAdapter = new MySqlDataAdapter("SELECT dtDate AS Date, nvarPlace AS Place, nvarExpenseDetail AS 'Details of expenses', nvarModeOfTransport AS Transport, nvarLocal AS 'Local Exp', nvarLodging AS Lodging, nvarDA AS DA, nvarOther AS Other, nvarTotal AS Total FROM tblsuexpensesdetails where intExpensesId=" + Request.QueryString[0].ToString() + "", dbc.con);
                dbc.dataAdapter.Fill(dt);

                grdSheetDetails.DataSource = dt;
                grdSheetDetails.DataBind();
                btnEditUpdate.Visible = true;
                btnSubmitSheet.Visible = false;
            }
            catch (Exception ex)
            {
                Response.Redirect("EditExpenseSheet.aspx");
            }
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
            Response.Redirect("~/Personnel/admin/Reports/ExpenseSheetReport.aspx", false);
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
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
                    MessageDisplay("Please add details to sheet..!!", "alert dark  alert-danger alert-dismissible");
                  //  Response.Write("<script>alert('Please add details to sheet..!!');window.location='EditExpenseSheet.aspx';</script>");
                }
                else
                {
                    if (txtFDate.Text == "")
                    {
                        MessageDisplay("Please enter from date in sheet..!!", "alert dark  alert-danger alert-dismissible");
                       
                    }
                    else if (txtTDate.Text == "")
                    {
                        MessageDisplay("Please enter to date in sheet..!!", "alert dark  alert-danger alert-dismissible");
                       

                    }
                    else if (txtLocation.Text == "")
                    {
                        MessageDisplay("Please add location to sheet..!!", "alert dark  alert-danger alert-dismissible");
                  
                    }
                    else
                    {
                        int expd = 0;
                        GridViewRow frow = grdSheetDetails.FooterRow;
                        Int64 insert_ok = dbc.insert_tblsuexpenses(Convert.ToInt32(Session["empid"].ToString()), txtFDate.Text, "", txtLocation.Text, "", frow.Cells[9].Text.ToString(), txtTDate.Text, "", "");


                        foreach (DataRow grow in dt.Rows)
                        {
                            expd = dbc.insert_tblsuexpensesdetails(insert_ok, grow[0].ToString(), grow[1].ToString(), grow[2].ToString(), grow[3].ToString(), grow[4].ToString(), grow[5].ToString(), grow[6].ToString(), grow[7].ToString(), grow[8].ToString());
                        }
                        if (expd == 0)
                        {

                            MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
                        }
                        else
                        {
                            MessageDisplay("Sheet added successfully ..!!", "alert dark  alert-success alert-dismissible");
                           
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

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
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

                    MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
                }
                else
                {
                    MessageDisplay("Sheet added successfully ..!!", "alert dark  alert-success alert-dismissible");
                }
                MessageDisplay("Expense Entry Updated Successfully ..!!", "alert dark  alert-success alert-dismissible");
              
                clear();

            }
            catch (Exception ecc)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
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
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}