using SudarshanSolar.DbCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SudarshanSolar.Customer
{
    public partial class Product : System.Web.UI.Page
    {

        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["ProductID"] == null)
            {
                Response.Redirect("~/Customer/ShopProduct.aspx", false);
            }
            if (!IsPostBack)
            {
                getProductData();
            }
        }
        public void getProductData()
        {
            try
            {    //Basic Product Data

                SqlDataSourceProduct.SelectCommand = "SELECT        tblsuproducts.intId, tblsuproducts.varProductName, tblproducttype.varTypeName, tblproductsubtype.varSubTypeName, tblsuproducts.varproductcode, tblsuproducts.varShortDesc, tblsuproducts.varLongDesc, tblsuproducts.imgImage, tblsuproducts.varStatus, tblsuproducts.varWarning,    tblsuproducts.intPurchasePrice, tblsuproducts.intDealerPrice, tblsuproducts.intMRP, tblsuproducts.intProductTypeId, tblsuproducts.intProductSubTypeId   FROM       tblsuproducts INNER JOIN tblproducttype ON tblsuproducts.intProductTypeId = tblproducttype.intProdTypeId INNER JOIN    tblproductsubtype ON tblsuproducts.intProductSubTypeId = tblproductsubtype.intProdSubTypeId   WHERE  tblsuproducts.intId = " + Cache["ProductID"].ToString() + "";
                lstProduct.DataBind();
            }
            catch (Exception ex)
            {


            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        protected void lstProduct_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                string addcomment = string.Empty;
                string addqty = string.Empty;
                if (e.CommandName == "AddToCart")
                {                 

                    TextBox AdditionalComments = (TextBox)e.Item.FindControl("txtAdditionalComments");
                    addcomment = AdditionalComments.Text == string.Empty ? "Purchase Product" : AdditionalComments.Text;
                    //Label myid = (Label)e.Item.FindControl("varShortDescLabel");
                    //addqty = myid.Text;
                    DropDownList qty = (DropDownList)e.Item.FindControl("ddlQty");
                    addqty = qty.Text;
                }
                if (Cache["cartproductid"] != null)
                {

                    string[] cartDataPid = Cache["cartproductid"].ToString().Split(';').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    int flag = 0;
                    for (int i = 0; i < cartDataPid.Count(); i++)
                    {
                        if (cartDataPid[i].ToString() == e.CommandArgument.ToString())
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 1)
                    {
                        MessageDisplay("Item Alredy Added In your Cart...Pls Select Other Item...", "alert alert-danger");
                    
                    }
                    else
                    {
                        Cache["cartproductid"] = Cache["cartproductid"] + ";" + e.CommandArgument.ToString() + ";";
                        Cache["cartrequest"] = Cache["cartrequest"] + ";" + addcomment + ";";
                        Cache["cartqty"] = Cache["cartqty"] + ";" + addqty + ";";
                        Response.Redirect("~/Customer/cart.aspx", false);
                    }

                }
                else
                {
                    Cache["cartproductid"] = Cache["cartproductid"] + ";" + e.CommandArgument.ToString() + ";";
                    Cache["cartrequest"] = Cache["cartrequest"] + ";" + addcomment + ";";
                    Cache["cartqty"] = Cache["cartqty"] + ";" + addqty + ";";
                    Response.Redirect("~/Customer/cart.aspx", false);
                }
            }
            catch (Exception ex)
            {


            }
        }
    }

}