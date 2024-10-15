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

namespace SudarshanSolar.Personnel.Admin
{
    public partial class ViewEmployeeExpenses : System.Web.UI.Page
    {
        RegexUtilities rex = new RegexUtilities();
        DatabaseConnection dbc = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                notifications();
                getExpenseSheets();

            }
        }
        public void notifications()
        {
            //  lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["empid"].ToString()), empdesig).ToString();
        }
        public void getExpenseSheets()
        {
            try
            {
                dbc.con.Open();
                DataTable view = new DataTable();
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySqlDataAdapter("SELECT   dtDate as Date,  nvarPlace as Place , nvarExpenseDetail as Details,  nvarModeOfTransport as Transport, nvarLocal as Local, nvarLodging as Lodging, nvarDA as DA, nvarOther as Other, nvarTotal as Total FROM tblsuexpensesdetails WHERE intExpensesId=" + Request.QueryString["expenseId"] + "", dbc.con);
                adp.Fill(view);
                grdSheetDetails.DataSource = view;
                grdSheetDetails.DataBind();
                dbc.con.Close();

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySqlCommand("SELECT intId, (SELECT varName FROM tblsupersonnel WHERE intId=intEmpId) as EmpID, dtStartDate, nvarAdvance, nvarLocation, nvarBalance, nvarTotalExpense, dtEndDate, imgSignature, nvarRemark FROM tblsuexpenses WHERE intId=" + Request.QueryString["expenseId"] + "", dbc.con);
                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    txtFDate.Text = dbc.dr["dtStartDate"].ToString();
                    txtTDate.Text = dbc.dr["dtEndDate"].ToString();
                    txtLocation.Text = dbc.dr["nvarLocation"].ToString();
                    lblEmpName.Text = dbc.dr["EmpID"].ToString();
                }
                dbc.con.Close();
            }
            catch (Exception ex)
            {
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
                e.Row.Cells[8].Text = TotalPrice.ToString();
            }
        }

        protected void lbkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Personnel/Admin/viewExpenseSheet.aspx", false);
        }


        protected void GetDatafromDatabase1()
        {

            DataTable dt1 = new DataTable();
            dbc.con.Open();
            string queryStr = "SELECT   dtDate as Date,  nvarPlace as Place , nvarExpenseDetail as Details,  nvarModeOfTransport as Transport, nvarLocal as Local, nvarLodging as Lodging, nvarDA as DA, nvarOther as Other, nvarTotal as Total FROM tblsuexpensesdetails WHERE intExpensesId=" + Request.QueryString["expenseId"] + "";
            MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
            sda.Fill(dt1);
            grdSheetDetails.DataSource = dt1;
            grdSheetDetails.DataBind();
            dbc.con.Close();

        }
        protected void btnExportSale_Click(object sender, EventArgs e)
        {
            try
            {
                GetDatafromDatabase1();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ViewExpenseSheet.xls"));
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grdSheetDetails.AllowPaging = false;
                //Change the Header Row back to white color
                // grdReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
                //Applying stlye to gridview header cells


                grdSheetDetails.RenderControl(htw);

                Response.Write(" Expense Sheet For Employee :" + lblEmpName.Text + "\n\n");
                Response.Write(" From Date :" + txtFDate.Text + "\n");
                Response.Write(" To Date :" + txtTDate.Text + "\n");
                Response.Write(" For Location :" + txtLocation.Text + "\n");
                //Response.Write("Excel Generated on " + DateTime.Now.ToShortDateString() + "\n\n");

                Response.Write(sw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }
    }
}