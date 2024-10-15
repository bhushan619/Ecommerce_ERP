using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SudarshanSolar.DbCode;
using System.Data;


namespace SudarshanSolar.Personnel.Admin
{
    public partial class ViewFullProduct : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["ProductID"] == null)
            {
                Response.Redirect("~/Personnel/admin/ViewProduct.aspx", false);
            }
            else  if (!IsPostBack)
            {
                getProductData();
            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        public void getProductData()
        {
            try
            {    //Basic Product Data

                SqlDataSourceProduct.SelectCommand = "SELECT        tblsuproducts.intId, tblsuproducts.varProductName, tblproducttype.varTypeName, tblproductsubtype.varSubTypeName, tblsuproducts.varproductcode, tblsuproducts.varShortDesc, tblsuproducts.varLongDesc, tblsuproducts.imgImage, tblsuproducts.varStatus, tblsuproducts.varWarning,    tblsuproducts.intPurchasePrice, tblsuproducts.intDealerPrice, tblsuproducts.intMRP, tblsuproducts.intProductTypeId, tblsuproducts.intProductSubTypeId   FROM       tblsuproducts INNER JOIN tblproducttype ON tblsuproducts.intProductTypeId = tblproducttype.intProdTypeId INNER JOIN    tblproductsubtype ON tblsuproducts.intProductSubTypeId = tblproductsubtype.intProdSubTypeId   WHERE  tblsuproducts.intId = " + Cache["ProductID"].ToString() + "";
                lstProduct.DataBind();

                //Product Gallary 

                SqlDataSourceGallary.SelectCommand = "SELECT        tblproductgallary.file, tblproductgallary.id   FROM tblsuproducts INNER JOIN   tblproductgallary ON tblsuproducts.intId = tblproductgallary.intProductId  WHERE  tblsuproducts.intId  = " + Cache["ProductID"].ToString() + "";
                lstGallary.DataBind();

                //Product Variations

                SqlDataSourceVariation.SelectCommand = "SELECT        tblsuproducts.intId, tblproductvariation.varVariation, tblvariation.varVariationValue  FROM tblsuproducts INNER JOIN    tblvariation ON tblsuproducts.intId = tblvariation.intProductId INNER JOIN    tblproductvariation ON tblvariation.intVariationId = tblproductvariation.intId     WHERE  tblsuproducts.intId = " + Cache["ProductID"].ToString() + "";
                lstVariation.DataBind();
            }
            catch (Exception ex)
            {


            }
        }
    }
}