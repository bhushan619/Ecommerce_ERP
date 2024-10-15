using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SudarshanSolar.DbCode;

namespace SudarshanSolar
{
    public partial class ChkLogin : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();

        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["uname"] == null)
            {
                Response.Write("<script>alert('Please Try Again');window.location='login.aspx';</script>");
            }
            else if (Request["pass"] == null)
            {
                Response.Write("<script>alert('Please Try Again');window.location='login.aspx';</script>");
            }
            else
            {
                loginmethod();
            }
        }

        public void loginmethod()
        {
            try
            {
                string uname = Request["uname"].ToString();
                string pass = Request["pass"].ToString();
                MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select intId,varEmail,varPassword,varDesignation,varSubDesig from anuvaa_solar.tblsupersonnel where varEmail='" + uname + "' and varStatus='true'", dbc.con);
                dbc.con.Open();
                dbc.dr = cmde.ExecuteReader();
                if (dbc.dr.Read())
                {
                    if (dbc.dr["varPassword"].ToString() == pass)
                    {
                        HttpCookie adminid = new HttpCookie("LoginId");
                        adminid.Value = rex.EncryptString(dbc.dr["intId"].ToString());
                        Response.Cookies.Add(adminid);

                        HttpCookie LoggedRoleId = new HttpCookie("LoggedRoleId");
                        LoggedRoleId.Value = rex.EncryptString(dbc.dr["varDesignation"].ToString());
                        Response.Cookies.Add(LoggedRoleId);

                        if (dbc.dr["varDesignation"].ToString() == "admin")
                        { 
                            Response.Redirect("~/Personnel/admin/", false); 
                        }
                        else if (dbc.dr["varDesignation"].ToString() == "employee")
                        { 
                            if (dbc.dr["varSubDesig"].ToString() == "Clerk")
                            {
                                Response.Redirect("~/Personnel/Clerk/", false);
                            }
                            else if (dbc.dr["varSubDesig"].ToString() == "Marketing")
                            {
                                Response.Redirect("~/Personnel/marketing/", false);
                            } 
                        }
                        else
                        {
                            Response.Redirect("~/login.aspx?err=no", false);
                        }
                        dbc.dr.Close();
                    }
                    else
                    {
                        Response.Redirect("~/login.aspx?err=no", false);
                    }
                }
                else
                {
                    dbc.con.Close();
                    MySql.Data.MySqlClient.MySqlCommand cmdc = new MySql.Data.MySqlClient.MySqlCommand("select intId,varEmail,varPassword from anuvaa_solar.tblsucustomer where varEmail='" + uname + "' and varStatus='Whitelist'", dbc.con);
                    dbc.con.Open();
                    dbc.dr = cmdc.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        if (dbc.dr["varPassword"].ToString() == pass)
                        {
                            HttpCookie custid = new HttpCookie("custid");
                            custid.Value = rex.EncryptString((dbc.dr["intId"].ToString()));
                            Response.Cookies.Add(custid);
                            //int data = Convert.ToInt32(dbc.dr["intId"].ToString());
                            //Session.Add("custid", data);
                            Response.Redirect("~/Customer/Dashboard.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("~/login.aspx?err=no", false);
                        }
                    }
                    else
                    {
                        Response.Redirect("~/login.aspx?err=no", false);
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