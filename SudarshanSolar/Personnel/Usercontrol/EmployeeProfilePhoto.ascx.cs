using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SudarshanSolar.DbCode;
using System.Data;


namespace SudarshanSolar.Personnel.Usercontrol
{
    public partial class EmployeeProfilePhoto : System.Web.UI.UserControl
    {
       
        DatabaseConnection dbc = new DatabaseConnection(); RegexUtilities rex = new RegexUtilities();

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
                    lbldesignation.Text = dbc.dr["varSubDesig"].ToString();
                    dbc.con.Close();
                    dbc.dr.Close();
                }
                dbc.con.Close();
                dbc.dr.Close();
            }
            catch (Exception ex)
            {
                dbc.con.Close();

                Response.Write("<script>alert('Please Try Again');window.location='ExpenseSheet.aspx';</script>");
            }
        }
        public void getImage()
        {
            try
            {

                string ImageUr = dbc.select_empProfilePic(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)));
                if (ImageUr == "")
                {
                    ImgProfile.ImageUrl = "~/Media/Employee/NoProfile.png";
                }
                else
                {

                    ImgProfile.ImageUrl = "~/Media/Employee/" + ImageUr;
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/login.aspx");
            }
            //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)) + "";
        }
        protected void btnUploadPro_Click(object sender, EventArgs e)
        {
            string filename = string.Empty;
            try
            {
                int contentLength = fupProPic.PostedFile.ContentLength;
                if (contentLength == 0)
                {
                    ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                       "alert('Please select a picture');", true);

                    return;
                }
                else
                {
                    string ffileExt = System.IO.Path.GetExtension(fupProPic.PostedFile.FileName);
                    if ((ffileExt == ".JPG") || (ffileExt == ".jpg") || (ffileExt == ".JPEG") || (ffileExt == ".jpeg") || (ffileExt == ".PNG") || (ffileExt == ".png"))
                    {
                        filename = rex.DecryptString(Request.Cookies["LoginId"].Value) + fupProPic.PostedFile.FileName.ToString();
                        int update_insp = dbc.Update_ProfilePicemp(Convert.ToInt32(rex.DecryptString(Request.Cookies["LoginId"].Value)), filename);

                        if (update_insp == 1)
                        {
                            fupProPic.PostedFile.SaveAs(Server.MapPath("~/media/employee/") + filename);
                            //string js = string.Empty;
                            //js += "window.opener.location.href='EditProfile.aspx';";
                            //js += "window.close();";
                            //ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", js, true);
                            Response.Write("<script>alert('Photo Uploaded Successfully....');window.location='EditProfile.aspx';</script>");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                            "alert('Data Not Inserted');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(
                      this,
                      this.GetType(),
                      "MessageBox",
                      "alert('Please select proper image as .jpg or .png');", true);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "MessageBox",
                    "alert('Some error please try again');", true);
                return;
            }
        }
    }
}