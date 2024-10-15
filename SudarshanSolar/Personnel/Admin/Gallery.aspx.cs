using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SudarshanSolar.DbCode;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class Gallery : System.Web.UI.Page
    {
        static int eventId = 0;
        DatabaseConnection dbc = new DatabaseConnection();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                txtEventdate.Visible = false;
                txtNewEvent.Visible = false;
                btnEventCancel.Visible = false;
                btnEventSubmit.Visible = false;

                load();
                getAlbumData();
            }


        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        public void load()
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT concat(intID,')', varAlbum) as album FROM tblhhigallery ", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlEvent.DataSource = ds;
            ddlEvent.DataTextField = "album";
            ddlEvent.DataValueField = "album";
            ddlEvent.DataBind();
            dbc.con.Close();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEvent.Text != "-- Select Gallery --")
                {
                    string[] arry = ddlEvent.Text.Split(new char[] { ')' });
                    //eventId = Convert.ToInt32(ddlEvent.SelectedValue = dbc.dr["intId"].ToString());
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblhhigallery where varAlbum='" + arry[1].ToString() + "'", dbc.con);
                    dbc.dr = cmd.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        eventId = Convert.ToInt32(dbc.dr["intId"].ToString());
                    }
                    dbc.con.Close();
                    dbc.con.Dispose();
                    int contentLength = fupProPic.PostedFile.ContentLength;//You may need it for validation
                    string contentType = fupProPic.PostedFile.ContentType;//You may need it for validation
                    string fileName = fupProPic.PostedFile.FileName;
                    if (contentLength == 0)
                    {
                        int insert_ok = dbc.insert_tblEventAndPhotoDetails1(eventId, txtImageCaption.Text, "NoProfile.png");
                        if (insert_ok != 0)
                        {
                            MessageDisplay("Gallary Photo Added Successfully", "alert dark  alert-success alert-dismissible");
                          

                        }
                    }

                    else
                    {

                        int insert_ok = dbc.insert_tblEventAndPhotoDetails1(eventId, txtImageCaption.Text, fileName);

                        if (insert_ok != 0)
                        {
                            fupProPic.PostedFile.SaveAs(Server.MapPath("~/media/galleryimages/") + fileName);//Or code to save in the DataBase.
                            MessageDisplay("Gallary Photo Added Successfully", "alert dark  alert-success alert-dismissible");


                        }
                    }
                }
                else
                {
                    MessageDisplay("Please select Gallery", "alert dark  alert-danger alert-dismissible");

                }
            }
            catch (Exception ex)
            {


                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");

            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Personnel/Admin/gallery.aspx");
        }

        protected void btnEvent_Click(object sender, EventArgs e)
        {
            ImgProduct.Visible = false;
            btnEvent.Visible = false;
            btnSubmit.Visible = false;
            btnCancel.Visible = false;
            fupProPic.Visible = false;
            txtImageCaption.Visible = false;
            ddlEvent.Visible = false;
            txtNewEvent.Visible = true;
            txtEventdate.Visible = true;
            btnEventCancel.Visible = true;
            btnEventSubmit.Visible = true;
        }

        protected void btnEventSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int insert_ok = dbc.insert_tblEventAndPhotoDetails(txtNewEvent.Text, txtEventdate.Text);

                if (insert_ok != 0)
                {

                    MessageDisplay("Data Inserted Successfully", "alert dark  alert-success alert-dismissible");

                }
            }
            catch (Exception ex)
            {


                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
        protected void btnEventCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Personnel/Admin/gallery.aspx");
        }
        protected void grdPackage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Selects")
                {
                    dbc.con.Open();
                    int id = Convert.ToInt32(e.CommandArgument);
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblhhiphotoupload WHERE intGalleryId = " + id + " ", dbc.con);
                    cmd.ExecuteNonQuery();
                    dbc.con.Close();
                    MessageDisplay("Record Deleted", "alert dark  alert-danger alert-dismissible");

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void grdPackage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPackage.PageIndex = e.NewPageIndex;
            getAlbumData();
        }
        public void getAlbumData()
        {
            try
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intGalleryId, (SELECT varAlbum FROM tblhhigallery WHERE intID=intEventId) as album, VarCaption, varImagePath FROM tblhhiphotoupload  order by intGalleryId desc", dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                ad.Fill(dt);
                grdPackage.DataSource = dt;
                grdPackage.DataBind();
                dbc.con.Close();
            }
            catch (Exception ex)
            {


                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-danger alert-dismissible");
            }
        }
    }
}