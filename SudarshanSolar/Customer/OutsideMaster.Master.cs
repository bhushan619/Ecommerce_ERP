using SudarshanSolar.DbCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SudarshanSolar.Customer
{
    public partial class OutsideMaster : System.Web.UI.MasterPage
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {            
            setTopNames();
            setSlider();
        }
        public void setSlider()
        {
            if (Request.RawUrl.Contains("efault.aspx"))            
                sliderMainPage.Visible = true;            
            else
                sliderMainPage.Visible = false;
        }

        public void setTopNames()
        {
            if (Request.Cookies["CustName"] == null)
            {
                topdivLogin.Visible = true;
                topDiv.Visible = false;
            }
            else
            {
                topdivLogin.Visible = false;
                topDiv.Visible = true;
               // topName.Text = rex.DecryptString(Request.Cookies["CustName"].Value.ToString());
            }
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtuser.Text == "")
                {
                    Response.Write("<script>alert('Please Enter Username')</script>");
                }
                else if (txtpass.Text == "")
                {
                    Response.Write("<script>alert('Please Enter Password')</script>");
                }
                else
                {
                    string uname = txtuser.Text;
                    string pass = txtpass.Text;
                    MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varCompanyName, varRepresentativeName, varMobile, varMobileVerify, varLandline, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varStatus, varPanCardNo, varVatNo, varTinNo, varCustomerType, imgImage, dtDateOfEstd, varNotify, varCallDate FROM tblsucustomer where varEmail='" + uname + "' and  varStatus='Whitelist'", dbc.con);
                    dbc.con.Open();
                    dbc.dr = cmde.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        if (dbc.dr["varPassword"].ToString() == pass)
                        {
                            HttpCookie custid = new HttpCookie("custid");
                            custid.Value = rex.EncryptString(dbc.dr["intId"].ToString());
                            Response.Cookies.Add(custid);

                          
                            HttpCookie CustName = new HttpCookie("CustName");
                            CustName.Value = rex.EncryptString(dbc.dr["varRepresentativeName"].ToString());
                            Response.Cookies.Add(CustName);

                            Response.Redirect("~/Customer/ShopProduct.aspx", false);

                            dbc.dr.Close();
                        }
                        else
                        {
                            Response.Write("<script>alert('Please Enter Correct Password...')</script>");
                        }
                    }
                    else
                    {
             
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}