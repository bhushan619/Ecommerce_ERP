using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using SudarshanSolar.DbCode;

namespace SudarshanSolar.Personnel.Marketing
{
    public partial class KYCDocument : System.Web.UI.Page
    {
        RegexUtilities rex = new RegexUtilities();
        public static string empdesig = string.Empty;
        DatabaseConnection dbc = new DatabaseConnection();

        static int EditTypeId = 0;
        static string EditPersonalId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["LoginId"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
            }
            else  if (!IsPostBack)
            {
                getListViewMasterData();
                getempname();

            }
        }
        public void getempname()
        {
            //try
            //{

            //    dbc.con.Open();
            //    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName,varSubDesig FROM anuvaa_solar.tblsupersonnel where intId=" + rex.DecryptString(Request.Cookies["LoginId"].Value) + "", dbc.con);

            //    dbc.dr = cmd.ExecuteReader();
            //    if (dbc.dr.Read())
            //    {
            //      //  lblCustName.Text = dbc.dr["varName"].ToString();
            //        empdesig = dbc.dr["varSubDesig"].ToString();
            //        dbc.con.Close();
            //        dbc.dr.Close();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('Please Try Again');</script>");
            //}
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int contentLength = fupProPic.PostedFile.ContentLength;//You may need it for validation
                string contentType = fupProPic.PostedFile.ContentType;//You may need it for validation
                string fileName = rex.DecryptString(Request.Cookies["LoginId"].Value) + " " + fupProPic.PostedFile.FileName;//fupProPic.PostedFile.FileName;
                if (contentLength != 0)
                {
                    string myStr = ImgProfile.ImageUrl;
                    string[] ssize = myStr.Split('/');
                    fupProPic.PostedFile.SaveAs(Server.MapPath("~/Media/Documents/") + fileName);
                }
                else
                {
                    fileName = "NoProfile.png";
                }
                int insert_ok = 0;
                  insert_ok = dbc.insert_tbldocuments( rex.DecryptString(Request.Cookies["LoginId"].Value), txtDescription.Text.Replace("'", "\\'"), fileName, DateTime.UtcNow.AddMinutes(330).ToString("yyyy-MM-dd"), rex.DecryptString(Request.Cookies["LoginId"].Value), 0, "Pending");
                  //  dbc.insert_tblnotifications(rex.DecryptString(Request.Cookies["CookieSocietyId"].Value), "text", rex.DecryptString(Request.Cookies["CookiePropertyId"].Value), rex.DecryptString(Request.Cookies["LoggedRoleId"].Value), dbc.select_tblassignnotifications(rex.DecryptString(Request.Cookies["CookieSocietyId"].Value)).Split('-')[0], dbc.select_tblassignnotifications(rex.DecryptString(Request.Cookies["CookieSocietyId"].Value)).Split('-')[1], "New Document Uploaded by " + dbc.get_PropertyOwnerName(rex.DecryptString(Request.Cookies["CookieSocietyId"].Value), rex.DecryptString(Request.Cookies["CookiePropertyId"].Value)), "", "", "Unread", "");
              
               
                if (insert_ok == 1)
                {
                    MessageDisplay(Resources.ErrorMessages.DocumentApproval, "alert alert-success  dark alert-dismissible");
                    clear();
                }
                else
                {
                    MessageDisplay(Resources.ErrorMessages.IncorrectValues, "alert dark  alert-dismissible alert-danger");
                }

                getListViewMasterData();
            }
            catch (Exception ex)
            {
                 MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
                string exp = ex.Message;
            }
        }

        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int contentLength = fupProPic.PostedFile.ContentLength;//You may need it for validation
                string contentType = fupProPic.PostedFile.ContentType;//You may need it for validation
                string fileName = rex.DecryptString(Request.Cookies["LoginId"].Value) + " " + fupProPic.PostedFile.FileName;//fupProPic.PostedFile.FileName;

                if (contentLength != 0)
                {
                    string myStr = ImgProfile.ImageUrl;
                    string[] ssize = myStr.Split('/');
                    fupProPic.PostedFile.SaveAs(Server.MapPath("~/Media/Documents/") + fileName);
                    int Update_ok = dbc.update_tbldocuments(Convert.ToInt32(EditTypeId), txtDescription.Text.Replace("'", "\\'"), fileName, 0);
                    //  dbc.insert_tblnotifications(rex.DecryptString(Request.Cookies["CookieSocietyId"].Value), "text", EditPersonalId, rex.DecryptString(Request.Cookies["LoggedRoleId"].Value), dbc.select_tblassignnotifications(rex.DecryptString(Request.Cookies["CookieSocietyId"].Value)).Split('-')[0], dbc.select_tblassignnotifications(rex.DecryptString(Request.Cookies["CookieSocietyId"].Value)).Split('-')[1], "New Document Uploaded by ", "", "", "Unread", "");

                    if (Update_ok == 1)
                    {
                        MessageDisplay(Resources.Messages.Updated, "alert dark  alert-success alert-dismissible");
                        clear();
                    }
                    else
                    {
                        MessageDisplay(Resources.Messages.NotUpdated, "alert dark  alert-danger alert-dismissible");
                    }


                }
                else
                {
                    string[] imgname = ImgProfile.ImageUrl.Split('/');
                    int Update_ok = dbc.update_tbldocuments(Convert.ToInt32(EditTypeId), txtDescription.Text.Replace("'", "\\'"), imgname[3], 0);
                    // dbc.insert_tblnotifications(rex.DecryptString(Request.Cookies["CookieSocietyId"].Value), "text", EditPersonalId, rex.DecryptString(Request.Cookies["LoggedRoleId"].Value), dbc.select_tblassignnotifications(rex.DecryptString(Request.Cookies["CookieSocietyId"].Value)).Split('-')[0], dbc.select_tblassignnotifications(rex.DecryptString(Request.Cookies["CookieSocietyId"].Value)).Split('-')[1], "New Document Uploaded by ", "", "", "Unread", "");

                    if (Update_ok == 1)
                    {
                        MessageDisplay(Resources.Messages.Updated, "alert alert-success");
                        clear();
                    }
                    else
                    {
                        MessageDisplay(Resources.Messages.NotUpdated, "alert dark  alert-danger alert-dismissible");
                    }
                    

                }

                btnSubmit.Visible = true;
                btnUpdate.Visible = false;

                EditTypeId = 0;
               getListViewMasterData();
            }
            catch (Exception ex)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }

        public void clear()
        {
            txtDescription.Text = "";
          
            ImgProfile.ImageUrl = "~/Media/Documents/NoProfile.png";
        }
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            try
            {
                this.DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

                this.getListViewMasterData();
            }
            catch (Exception ex)
            {
                string exp = ex.Message;
            }
        }
        protected void lstType_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {

                    btnUpdate.Visible = true;
                    btnSubmit.Visible = false;
                    dbc.con.Close();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,  varPersonnelId,  varDescription, varDocument,intIsActive FROM tbldocuments WHERE intId=" + Convert.ToInt32(e.CommandArgument.ToString()) + " ", dbc.con);

                    dbc.dr = cmd.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        EditTypeId = Convert.ToInt32(dbc.dr["intId"].ToString());
                        EditPersonalId = (dbc.dr["varPersonnelId"].ToString());
                        txtDescription.Text = dbc.dr["varDescription"].ToString();

                        ImgProfile.ImageUrl = "~/Media/Documents/" + dbc.dr["varDocument"].ToString();
                        

                    }
                    dbc.con.Close();
                }
                else if (e.CommandName == "Delets")
                {
                    dbc.con.Close();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM tbldocuments WHERE intId = " + Convert.ToInt32(e.CommandArgument.ToString()) + "", dbc.con);
                    int i = cmd1.ExecuteNonQuery();
                    dbc.con.Close();

                    if (i == 1)
                    {
                        MessageDisplay(Resources.Messages.Deleted, "alert alert-success  dark alert-dismissible");

                    }
                    else
                    {
                        MessageDisplay(Resources.Messages.NotDeleted, "alert   alert-danger dark alert-dismissible");
                    }
                    getListViewMasterData();
                }

            }
            catch (Exception ex)
            {
                dbc.con.Close();
            }
        }
        public void getListViewMasterData()
        {
            try
            {
                    dbc.con.Close();
                    DataTable dt = new DataTable();
                    dbc.con.Open();
                    EditPersonalId = rex.DecryptString(Request.Cookies["LoginId"].Value);
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,  varPersonnelId, varDescription, varDocument,intIsActive,varStatus FROM tbldocuments WHERE varPersonnelId='" + rex.DecryptString(Request.Cookies["LoginId"].Value) + "' ", dbc.con);
                    MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                    adp.Fill(dt);

                    lstType.DataSource = dt;
                    lstType.DataBind();
                    dbc.con.Close();
              

            }
            catch (Exception ex)
            {
                //MessageDisplay(Resources.ErrorMessages.IncorrectValues, "alert alert-danger");
            }
        }
    }
}