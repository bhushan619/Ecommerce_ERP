using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using SudarshanSolar.DbCode;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class addproductype : System.Web.UI.Page
    {
        static string userid = "";
        string id = "";
        Int32 intId = 0;
        static Int32 intProdTypeId = 0;
        // string editid ="";
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // getCountryData();
                getListViewMasterData();
            }

        }

        public void clear()
        {
            txtproducttypenm.Text = "";
            txtdescription.Text = "";
            chkIsActive.Checked = false;
            ImgProfile.ImageUrl = "~/Media/Product/NoProfile.png";

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int contentLength = fupProPic.PostedFile.ContentLength;//You may need it for validation
                string contentType = fupProPic.PostedFile.ContentType;//You may need it for validation
                                                                      //  string fileName = Request.Cookies["uid"].Value + " " + fupProPic.PostedFile.FileName;//fupProPic.PostedFile.FileName;
                string fileName = "" + " " + fupProPic.PostedFile.FileName;
                if (contentLength != 0)
                {
                    string myStr = ImgProfile.ImageUrl;
                    string[] ssize = myStr.Split('/');
                    fupProPic.PostedFile.SaveAs(Server.MapPath("~/Media/Product/") + fileName);
                    int insert_ok = dbc.insert_tblproducttype(txtproducttypenm.Text, txtdescription.Text, chkIsActive.Checked ? 1 : 0, fileName);
                    if (insert_ok == 1)
                    {

                        MessageDisplay(Resources.Messages.Added, "alert alert-success  fade in");

                        clear();
                    }
                    else
                    {
                        MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
                    }

                }
                //   getempid(dddoc.SelectedIndex);
                getListViewMasterData();
                clear();

            }
            catch (Exception ex)
            {
                string exp = ex.Message;
                dbc.con1.Close();
            }
        }


        protected void btncancle_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {
                string exp = ex.Message;
                dbc.con.Close();

            }
        }

        protected void lstType_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {

                    btnupdate.Visible = true;
                    btnsubmit.Visible = false;
                    dbc.con1.Close();
                    dbc.con1.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intProdTypeId, varTypeName, varDescription, varCreatedDate, varIsActive,varProductImage FROM tblproducttype WHERE intProdTypeId=" + Convert.ToInt32(e.CommandArgument.ToString()) + "", dbc.con1);

                    dbc.dr = cmd.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        intProdTypeId = Convert.ToInt32(dbc.dr["intProdTypeId"]);
                        txtproducttypenm.Text = dbc.dr["varTypeName"].ToString();
                        txtdescription.Text = dbc.dr["varDescription"].ToString();
                        ImgProfile.ImageUrl = "~/Media/Product/" + dbc.dr["varProductImage"].ToString();
                        if (Convert.ToInt32(dbc.dr["varIsActive"].ToString()) == 1)
                        {
                            chkIsActive.Checked = true;
                        }
                        else
                        {
                            chkIsActive.Checked = false;

                        }
                    }
                    dbc.con1.Close();

                }
                else if (e.CommandName == "Delets")
                {
                    dbc.con.Close();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM tblproducttype WHERE intProdTypeId = " + Convert.ToInt32(e.CommandArgument.ToString()) + "", dbc.con);
                    int i = cmd1.ExecuteNonQuery();
                    dbc.con.Close();

                    if (i == 1)
                    {
                        MessageDisplay(Resources.Messages.Deleted, "alert alert-success  fade in");

                    }
                    else
                    {
                        MessageDisplay(Resources.Messages.NotDeleted, "alert alert-block alert-danger fade in");
                    }


                    getListViewMasterData();
                    clear();
                }

            }
            catch (Exception ex)
            {

                string exp = ex.Message;
                dbc.con1.Close();
            }
        }

        protected void Btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                int contentLength = fupProPic.PostedFile.ContentLength;//You may need it for validation
                string contentType = fupProPic.PostedFile.ContentType;//You may need it for validation
                string fileName = intProdTypeId + " " + fupProPic.PostedFile.FileName;//fupProPic.PostedFile.FileName;

                if (contentLength != 0)
                {
                    // userid = dbc.dr["intId"].ToString();
                    fupProPic.PostedFile.SaveAs(Server.MapPath("~/Media/Product/") + fileName);
                    int update_ok = dbc.update_tblproducttype(intProdTypeId, txtproducttypenm.Text, txtdescription.Text, chkIsActive.Checked ? 1 : 0, fileName);

                    if (update_ok == 1)
                    {
                        MessageDisplay(Resources.Messages.Updated, "alert alert-success  fade in");
                        clear();
                    }
                    else
                    {
                        MessageDisplay(Resources.Messages.NotUpdated, "alert alert-block alert-danger fade in");
                    }
                }


                else
                {
                    string[] imgname = ImgProfile.ImageUrl.Split('/');
                    int update_ok = dbc.update_tblproducttype(intProdTypeId, txtproducttypenm.Text, txtdescription.Text, chkIsActive.Checked ? 1 : 0, fileName);

                    if (update_ok == 1)
                    {
                        MessageDisplay(Resources.Messages.Updated, "alert alert-success  fade in");
                        clear();
                    }
                    else
                    {
                        MessageDisplay(Resources.Messages.NotUpdated, "alert alert-block alert-danger fade in");
                    }
                }

                btnsubmit.Visible = true;
                btnupdate.Visible = false;
                intProdTypeId = 0;
                getListViewMasterData();
                clear();

            }
            catch (Exception ex)
            {
                string exp = ex.Message;
                dbc.con1.Close();
            }
        }

        public void getListViewMasterData()
        {
            try
            {
                dbc.con.Open();
                dbc.cmd = new MySqlCommand("  SELECT intProdTypeId, varTypeName, varDescription, varCreatedDate, varIsActive FROM tblproducttype ", dbc.con1);
                // dbc.cmd = new MySqlCommand("SELECT tbl_task.intid, tbl_assigntask.varempid, tbl_task.varsubject, tbl_task.vartaskdescription, tbl_task.varcreateddate, tbl_task.varisactive, tbl_assigntask.varcreateddate AS Expr1, tbl_empdetail.intempid, tbl_empdetail.varempname, tbl_empdetail.varusername FROM tbl_task INNER JOIN tbl_assigntask ON tbl_task.intid = tbl_assigntask.varassigntaskId INNER JOIN tbl_empdetail ON tbl_assigntask.varempid = tbl_empdetail.intempid where  tbl_assigntask.varempid=" + empid + " ", dbc.con1);
                MySqlDataAdapter da = new MySqlDataAdapter(dbc.cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                lstType.DataSource = ds1;
                lstType.DataBind();
                dbc.con.Close();
            }
            catch (Exception ex)
            {
                dbc.con.Close();
            }
        }


        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

            try
            {
                this.DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
                this.getListViewMasterData();
                //  this.getdocname();
                this.clear();

            }
            catch (Exception ex)
            {
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
    }
}