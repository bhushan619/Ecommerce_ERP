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

namespace SudarshanSolar.Personnel.MasterPages
{
    public partial class AdminReport : System.Web.UI.MasterPage
    {

        RegexUtilities rex = new RegexUtilities();
        DatabaseConnection dbc = new DatabaseConnection();
        static string empdesig = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getempname();
                getImage();
            }
        }
        public void getempname()
        {
            try
            {

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName,varSubDesig FROM anuvaa_solar.tblsupersonnel where intId=" + rex.DecryptString(Request.Cookies["LoginId"].Value) + "", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    lblCustName.Text = dbc.dr["varName"].ToString();
                    empdesig = dbc.dr["varSubDesig"].ToString();
                    dbc.con.Close();
                    dbc.dr.Close();
                }
                dbc.con.Close();
                dbc.dr.Close();
            }
            catch (Exception ex)
            {
                dbc.con.Close();

                Response.Write("<script>alert('Please Try Again');window.location='Default.aspx';</script>");
            }
        }
        public void getImage()
        {
            try
            {

                string ImageUr = dbc.select_empProfilePic(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)));
                if (ImageUr == "")
                {
                    imgProPic.ImageUrl = "~/Media/Employee/NoProfile.png";
                }
                else
                {

                    imgProPic.ImageUrl = "~/Media/Employee/" + ImageUr;
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/login.aspx");
            }
            //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)) + "";
        }
    }
}