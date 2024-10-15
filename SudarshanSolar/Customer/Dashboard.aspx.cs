using SudarshanSolar.DbCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SudarshanSolar.Customer
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["custid"] == null)
                {
                    Response.Redirect("~/Customer/Default.aspx", false);
                }
                else
                {
                    SqlDataSourceCartAndCustomerDetails.SelectCommand = "SELECT        tblsucustomer.intId AS custid, tblsucustomer.varRepresentativeName, tblsucustomer.varMobile, tblsucustomer.varAddress, cart.id AS cartid, DATE_FORMAT(cart.bookingdate,'%e %b %Y') as bookingdate,    cart.status,  cart_transaction.total, cart.id FROM tblsucustomer INNER JOIN cart ON tblsucustomer.intId = cart.personnel_id  INNER JOIN  cart_transaction ON cart.id = cart_transaction.cart_id WHERE (tblsucustomer.intId = " + rex.DecryptString(Request.Cookies["custid"].Value.ToString()) + ") ";
                    lstCartAndCustomerDetails.DataBind();
                }
            }
        }

        protected void lstCartAndCustomerDetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ViewInvoice")
                {
                    //Cache["custid"] = rex.DecryptString(Request.Cookies["custid"].Value.ToString());
                    Cache["cartid"] = e.CommandArgument.ToString();
                    Response.Redirect("~/Customer/Invoice.aspx", false);
                }
            }
            catch (Exception ex)
            {
                dbc.con.Close();
            }
        }
    }
}