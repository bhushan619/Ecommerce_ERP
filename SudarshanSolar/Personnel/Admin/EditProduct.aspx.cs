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
    public partial class EditProduct : System.Web.UI.Page
    {         //  static int editproductid ="";
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["ProductID"] == null)
            {
                Response.Redirect("~/Personnel/admin/ViewProduct.aspx", false);
            }
            else
              if (!IsPostBack)
            { getproducttype();
                getProductData();
               
            }

        }
        public void getProductData()
        {
            try
            {
                dbc.con.Close();
                dbc.con.Open();
                dbc.cmd = new MySqlCommand("SELECT        tblsuproducts.intId, tblsuproducts.varProductName, tblproducttype.varTypeName, tblproductsubtype.varSubTypeName, tblsuproducts.varproductcode, tblsuproducts.varShortDesc, tblsuproducts.varLongDesc, tblsuproducts.imgImage, tblsuproducts.varStatus, tblsuproducts.varWarning,    tblsuproducts.intPurchasePrice, tblsuproducts.intDealerPrice, tblsuproducts.intMRP, tblsuproducts.intProductTypeId, tblsuproducts.intProductSubTypeId   FROM       tblsuproducts INNER JOIN tblproducttype ON tblsuproducts.intProductTypeId = tblproducttype.intProdTypeId INNER JOIN    tblproductsubtype ON tblsuproducts.intProductSubTypeId = tblproductsubtype.intProdSubTypeId   WHERE  tblsuproducts.intId = " + Cache["ProductID"].ToString() + "", dbc.con);
                dbc.dr = dbc.cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    txtProductName.Text = dbc.dr["varProductName"].ToString();
                    txtProdCode.Text = dbc.dr["varproductcode"].ToString();
                    txtShortDesc.Text = dbc.dr["varShortDesc"].ToString();
                    txtLongDesc.Text = dbc.dr["varLongDesc"].ToString();
                    txtDealerPrice.Text = dbc.dr["intDealerPrice"].ToString();
                    txtPurchasePrice.Text = dbc.dr["intPurchasePrice"].ToString();
                    txtMRP.Text = dbc.dr["intMRP"].ToString();

                    ddproducttypeid.SelectedValue = dbc.dr["intProductTypeId"].ToString();
                    getSubtype(Convert.ToInt32(dbc.dr["intProductTypeId"].ToString()));
                    ddproductsubtype.SelectedValue = (dbc.dr["intProductSubTypeId"].ToString());

                    ImgCust.ImageUrl = "~/media/Product/" + dbc.dr["imgImage"].ToString();
                    dbc.con.Close();
                    dbc.dr.Close();
                }
                else
                {

                }
                dbc.con.Close();

            }
            catch (Exception ex)
            {
                dbc.con.Close();
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
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
        public void getSubtype(int typeid)
        {
            dbc.con1.Close();
            dbc.con1.Open();
            MySqlDataAdapter md = new MySqlDataAdapter("SELECT intProdSubTypeId, intProdTypeId, varSubTypeName, varDescription, varCreatedDate, varIsActive, ex2, ex3, ex4 FROM tblproductsubtype WHERE intProdTypeId=" + Convert.ToInt64(typeid) + "", dbc.con1);
            DataSet ds1 = new DataSet();
            md.Fill(ds1);
            System.Data.DataTable dt1 = ds1.Tables[0];
            ddproductsubtype.DataValueField = "intProdSubTypeId";
            ddproductsubtype.DataTextField = "varSubTypeName";
            ddproductsubtype.DataSource = dt1;
            ddproductsubtype.DataBind();
        }
        protected void ddproducttypeid_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            dbc.con1.Close();
            dbc.con1.Open();
            MySqlDataAdapter md = new MySqlDataAdapter("SELECT intProdSubTypeId, intProdTypeId, varSubTypeName, varDescription, varCreatedDate, varIsActive, ex2, ex3, ex4 FROM tblproductsubtype WHERE intProdTypeId=" + Convert.ToInt64(ddproducttypeid.SelectedValue.ToString()) + "", dbc.con1);
            DataSet ds1 = new DataSet();
            md.Fill(ds1);
            System.Data.DataTable dt1 = ds1.Tables[0];
            ddproductsubtype.DataValueField = "intProdSubTypeId";
            ddproductsubtype.DataTextField = "varSubTypeName";
            ddproductsubtype.DataSource = dt1;
            ddproductsubtype.DataBind();
            ddproductsubtype.Items.Insert(0, new ListItem(":: Product SubType ::", ""));
            dbc.con1.Close();
           

        }



        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                int contentLength = fupProPic.PostedFile.ContentLength;//You may need it for validation
                string contentType = fupProPic.PostedFile.ContentType;//You may need it for validation
                string fileName = fupProPic.PostedFile.FileName;
                if (ImgCust.ImageUrl == "~/media/customer/NoProfile.png" && contentLength == 0)
                {
                    MessageDisplay(Resources.Messages.FileUpload, "alert dark  alert-dismissible  alert-danger");
                }
                else
                {
                    if (contentLength != 0)
                    {
                         fupProPic.PostedFile.SaveAs(Server.MapPath("~/media/Product/") + fileName);//Or code to save in the DataBase.
                       
                    }
                    else
                    {
                        fileName = ImgCust.ImageUrl.ToString().Split('/')[3];

                      //  MessageDisplay(Resources.Messages.FileUpload, "alert dark  alert-dismissible  alert-danger");

                    }
                    int Productlastinsrtid = dbc.Update_tblsuproducts(Convert.ToInt32(Cache["ProductID"].ToString()), txtProductName.Text.Replace("'", "\\'"), Convert.ToInt32(ddproducttypeid.SelectedValue.ToString()), Convert.ToInt32(ddproductsubtype.SelectedValue.ToString()), txtProdCode.Text.Replace("'", "\\'"), txtShortDesc.Text.Replace("'", "\\'"), txtLongDesc.Text.Replace("'", "\\'"), fileName, Convert.ToInt64(txtPurchasePrice.Text.Replace("'", "\\'")), Convert.ToInt64(txtDealerPrice.Text.Replace("'", "\\'")), Convert.ToInt64(txtMRP.Text.Replace("'", "\\'")));
                       MessageDisplay(Resources.Messages.Updated, "alert dark  alert-dismissible  alert-success");


                }
                getProductData();
            }
            catch (Exception ex)
            {

            }

        }
    }
}