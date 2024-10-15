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
    public partial class AddVariation : System.Web.UI.Page
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
            txtvariation.Text = "";
            txtdescription.Text = "";
       

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
               
                    int insert_ok = dbc.insert_tblproductvariation(txtvariation.Text, txtdescription.Text);
                    if (insert_ok == 1)
                    {

                        MessageDisplay(Resources.Messages.Added, "alert alert-success  fade in");

                        clear();
                    }
                    else
                    {
                        MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
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
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varVariation, varDescription, ex1 FROM tblproductvariation where intId=" + Convert.ToInt32(e.CommandArgument.ToString()) + "", dbc.con1);

                    dbc.dr = cmd.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        intProdTypeId = Convert.ToInt32(dbc.dr["intId"]);
                        txtvariation.Text = dbc.dr["varVariation"].ToString();
                        txtdescription.Text = dbc.dr["varDescription"].ToString();
                      
                    }
                    dbc.con1.Close();

                }
                //else if (e.CommandName == "Delets")
                //{
                //    dbc.con.Close();
                //    dbc.con.Open();
                //    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM tblproductvariation WHERE intId = " + Convert.ToInt32(e.CommandArgument.ToString()) + "", dbc.con);
                //    int i = cmd1.ExecuteNonQuery();
                //    dbc.con.Close();

                //    if (i == 1)
                //    {
                //        MessageDisplay(Resources.Messages.Deleted, "alert alert-success  fade in");

                //    }
                //    else
                //    {
                //        MessageDisplay(Resources.Messages.NotDeleted, "alert alert-block alert-danger fade in");
                //    }


                //    getListViewMasterData();
                //    clear();
                //}

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
                 int update_ok = dbc.update_tblproductvariation(intProdTypeId, txtvariation.Text, txtdescription.Text);

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
                dbc.cmd = new MySqlCommand("  SELECT intId, varVariation, varDescription, ex1 FROM tblproductvariation ", dbc.con1);
               
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