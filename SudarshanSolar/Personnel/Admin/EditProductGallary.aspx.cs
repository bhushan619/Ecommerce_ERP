using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SudarshanSolar.DbCode;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class EditProductGallary : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["ProductID"] == null)
            {
                Response.Redirect("~/Personnel/admin/ViewProduct.aspx", false);
            }
            else if (!IsPostBack)
            {
                lblProductName.Text = dbc.getProductNameById(Convert.ToInt32(Cache["ProductID"].ToString()));
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

        public void getAlbumData()
        {
            try
            {
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT        tblproductgallary.file, tblproductgallary.id   FROM tblsuproducts INNER JOIN   tblproductgallary ON tblsuproducts.intId = tblproductgallary.intProductId  WHERE  tblsuproducts.intId  = " + Cache["ProductID"].ToString() + "", dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                ad.Fill(dt);
                lstGallary.DataSource = dt;
                lstGallary.DataBind();
                dbc.con.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                HttpFileCollection imageCollection = Request.Files;
                string photos = string.Empty;
                if (imageCollection == null)
                {
                    photos = "";
                }
                else
                {
                    for (int i = 0; i < imageCollection.Count; i++)
                    {
                        HttpPostedFile uploadImages = imageCollection[i];

                        string fileNameg = dbc.CreateRandomPassword(5) + Path.GetFileName(uploadImages.FileName);

                        dbc.con2.Close();
                        dbc.con2.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand();// room_Category_Id, string title, string subtitle, string alias,string descr, string Floor, string facilities, double price, int check
                        cmd2 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblproductgallary( intProductId, file)  VALUES(" + Convert.ToInt32(Cache["ProductID"].ToString()) + ",'" + fileNameg + "')", dbc.con2);

                        cmd2.ExecuteNonQuery();
                        dbc.con2.Close();
                        cmd2.Dispose();
                        uploadImages.SaveAs(Server.MapPath("~/media/Product/") + fileNameg);

                        MessageDisplay(Resources.Messages.Added, "alert alert-success");
                        // photos += fileNameg + ",";
                    }
                }
                getAlbumData();

            }
            catch(Exception ex)
            {

            }
        }

        protected void lstGallary_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstGallary.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.getAlbumData();
        }

        protected void lstGallary_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletes")
                {
                    dbc.con.Open();
                    int id = Convert.ToInt32(e.CommandArgument);
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblproductgallary WHERE id = " + id + " ", dbc.con);
                    int i = cmd.ExecuteNonQuery();
                    dbc.con.Close();
                    if (i == 1)
                    {
                        MessageDisplay(Resources.Messages.Deleted, "alert alert-success  fade in");

                    }
                    else
                    {
                        MessageDisplay(Resources.Messages.NotDeleted, "alert alert-block alert-danger fade in");
                    }

                    getAlbumData();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}