using SudarshanSolar.DbCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SudarshanSolar.Personnel.Admin.Reports
{
    public partial class Invoice : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["cartid"] == null)
            {
                Response.Redirect("~/Personnel/Admin/Reports/Order.aspx", false);
            }
           
            else if (!IsPostBack)
            {

                SqlDataSourceCartAndCustomerDetails.SelectCommand = "SELECT        tblsucustomer.intId AS custid, tblsucustomer.varRepresentativeName, tblsucustomer.varMobile, tblsucustomer.varAddress, cart.id AS cartid, DATE_FORMAT(cart.bookingdate,'%e %b %Y') as bookingdate,    cart.status,  cart_transaction.total, cart.id FROM tblsucustomer INNER JOIN cart ON tblsucustomer.intId = cart.personnel_id  INNER JOIN  cart_transaction ON cart.id = cart_transaction.cart_id WHERE   cart.id=" + Convert.ToInt32(Cache["cartid"].ToString()) + "";
                lstCartAndCustomerDetails.DataBind();


            }
        }
    }
}