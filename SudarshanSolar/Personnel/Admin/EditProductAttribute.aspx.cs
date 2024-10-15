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
    public partial class EditProductAttribute : System.Web.UI.Page
    {
        static Int32 intvariationId = 0;
    
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["ProductID"] == null)
            {
                Response.Redirect("~/Personnel/admin/ViewProduct.aspx", false);
            }
            else
             if (!IsPostBack)
            {
                getproductVariations();
                getListViewMasterData();
                lblProductName.Text = dbc.getProductNameById(Convert.ToInt32(Cache["ProductID"].ToString()));
            }
        }
        public void clear()
        {
            ddproductVariations.SelectedIndex = 0;
            txtAttributeValue.Text = "";
        }
        protected void lstType_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {

                    btnupdate.Enabled = true;                
                    dbc.con1.Close();
                    dbc.con1.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(" SELECT     tblvariation.intId AS variationId, tblproductvariation.intId as pvintid,  tblsuproducts.intId, tblproductvariation.varVariation, tblvariation.varVariationValue  FROM tblsuproducts INNER JOIN    tblvariation ON tblsuproducts.intId = tblvariation.intProductId INNER JOIN    tblproductvariation ON tblvariation.intVariationId = tblproductvariation.intId     WHERE tblvariation.intId=" + Convert.ToInt32(e.CommandArgument.ToString()) + "", dbc.con1);

                    dbc.dr = cmd.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        intvariationId = Convert.ToInt32(dbc.dr["variationId"]);
                        txtAttributeValue.Text = dbc.dr["varVariationValue"].ToString();
                        ddproductVariations.SelectedValue = dbc.dr["pvintid"].ToString();

                    }
                    dbc.con1.Close();

                }
                else if (e.CommandName == "Delets")
                {
                    dbc.con.Close();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM tblvariation WHERE intId = " + Convert.ToInt32(e.CommandArgument.ToString()) + "", dbc.con);
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
                    btnupdate.Enabled = false;
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
                int update_ok = dbc.update_tblvariation(intvariationId,Convert.ToInt32(ddproductVariations.SelectedValue), txtAttributeValue.Text.Replace("'","\\'"));

                if (update_ok == 1)
                {
                    MessageDisplay(Resources.Messages.Updated, "alert alert-success  fade in");
                    clear();
                }
                else
                {
                    MessageDisplay(Resources.Messages.NotUpdated, "alert alert-block alert-danger fade in");
                }
               
                intvariationId = 0;
                getListViewMasterData();
                clear();
                btnupdate.Enabled = false;

            }
            catch (Exception ex)
            {
                string exp = ex.Message;
                dbc.con1.Close();
            }
        }
        protected void getproductVariations()
        {
            dbc.con1.Close();
            dbc.con1.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT intId, varVariation, varDescription, ex1 FROM tblproductvariation", dbc.con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            System.Data.DataTable dt = ds.Tables[0];

            ddproductVariations.DataValueField = "intId";
            ddproductVariations.DataTextField = "varVariation";
            ddproductVariations.DataSource = dt;
            ddproductVariations.DataBind();
            ddproductVariations.Items.Insert(0, new ListItem(":: Attributes ::", ""));
            dbc.con1.Close();

        }
        public void getListViewMasterData()
        {
            try
            {
                dbc.con.Open();
                dbc.cmd = new MySqlCommand(" SELECT     tblvariation.intId AS variationId,   tblsuproducts.intId, tblproductvariation.varVariation, tblvariation.varVariationValue  FROM tblsuproducts INNER JOIN    tblvariation ON tblsuproducts.intId = tblvariation.intProductId INNER JOIN    tblproductvariation ON tblvariation.intVariationId = tblproductvariation.intId     WHERE  tblsuproducts.intId = " + Cache["ProductID"].ToString() + " ", dbc.con1);

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