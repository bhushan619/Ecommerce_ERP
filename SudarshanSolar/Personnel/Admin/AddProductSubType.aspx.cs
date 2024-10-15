using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SudarshanSolar.DbCode;
using MySql.Data.MySqlClient;
using System.Data;

namespace SudarshanSolar.Personnel.Admin
{
    public partial class AddProductSubType : System.Web.UI.Page
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
                getproducttype();
                getListViewMasterData();
            }

        }
        protected void getproducttype()
        {
            dbc.con1.Close();
            dbc.con1.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT intProdTypeId, varTypeName, varDescription, varCreatedDate, varIsActive, varProductImage, ex2, ex3, ex4 FROM tblproducttype WHERE varIsActive=1", dbc.con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            System.Data.DataTable dt = ds.Tables[0];

            ddproducttypeid.DataValueField = "intProdTypeId";
            ddproducttypeid.DataTextField = "varTypeName";
            ddproducttypeid.DataSource = dt;
            ddproducttypeid.DataBind();
            ddproducttypeid.Items.Insert(0, new ListItem(":: Product Type ::", ""));
            dbc.con1.Close();

        }
        public void clear()
        {
            txtproducttypenm.Text = "";
            txtdescription.Text = "";
            chkIsActive.Checked = false;
            ddproducttypeid.SelectedIndex = 0;

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                  int insert_ok = dbc.insert_tblproductsubtype(Convert.ToInt32(ddproducttypeid.SelectedValue),txtproducttypenm.Text, txtdescription.Text, chkIsActive.Checked ? 1 : 0);
                    if (insert_ok == 1)
                    {

                        MessageDisplay(Resources.Messages.Added, "alert alert-success  fade in");

                        clear();
                    }
                    else
                    {
                        MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
                    }

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
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intProdSubTypeId, intProdTypeId, varSubTypeName, varDescription, varCreatedDate, varIsActive, ex2, ex3, ex4 FROM tblproductsubtype WHERE intProdSubTypeId=" + Convert.ToInt32(e.CommandArgument.ToString()) + "", dbc.con1);

                    dbc.dr = cmd.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        ddproducttypeid.SelectedValue = dbc.dr["intProdTypeId"].ToString();
                        intProdTypeId = Convert.ToInt32(dbc.dr["intProdSubTypeId"]);
                        txtproducttypenm.Text = dbc.dr["varSubTypeName"].ToString();
                        txtdescription.Text = dbc.dr["varDescription"].ToString();
                      //  ImgProfile.ImageUrl = "~/Media/Product/" + dbc.dr["varProductImage"].ToString();
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
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM tblproductsubtype WHERE intProdSubTypeId = " + Convert.ToInt32(e.CommandArgument.ToString()) + "", dbc.con);
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
                 int update_ok = dbc.update_tblproductsubtype(intProdTypeId, Convert.ToInt32(ddproducttypeid.SelectedValue), txtproducttypenm.Text, txtdescription.Text, chkIsActive.Checked ? 1 : 0);

                    if (update_ok == 1)
                    {
                        MessageDisplay(Resources.Messages.Updated, "alert alert-success  fade in");
                        clear();
                    }
                    else
                    {
                        MessageDisplay(Resources.Messages.NotUpdated, "alert alert-block alert-danger fade in");
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
                dbc.cmd = new MySqlCommand(" SELECT        tblproducttype.varTypeName as varTypeName, tblproductsubtype.intProdSubTypeId as intProdSubTypeId,  tblproductsubtype.varSubTypeName as varSubTypeName,              tblproductsubtype.varDescription as varDescription, tblproductsubtype.varCreatedDate as varCreatedDate, tblproductsubtype.varIsActive as varIsActive FROM            tblproductsubtype INNER JOIN                   tblproducttype ON tblproductsubtype.intProdTypeId = tblproducttype.intProdTypeId", dbc.con1);
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