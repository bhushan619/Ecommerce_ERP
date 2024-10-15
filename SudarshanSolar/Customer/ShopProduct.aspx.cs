using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SudarshanSolar.Customer
{
    public partial class ShopProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.BindListView();
            }
        }
        public void BindListView()
        {
            SqlDataSource1.SelectCommand = "SELECT        tblsuproducts.intId, tblsuproducts.varProductName, tblproducttype.varTypeName, tblproductsubtype.varSubTypeName, tblsuproducts.varproductcode, tblsuproducts.varShortDesc, tblsuproducts.varLongDesc, tblsuproducts.imgImage, tblsuproducts.varStatus, tblsuproducts.varWarning,    tblsuproducts.intPurchasePrice, tblsuproducts.intDealerPrice, tblsuproducts.intMRP, tblsuproducts.intProductTypeId, tblsuproducts.intProductSubTypeId   FROM       tblsuproducts INNER JOIN tblproducttype ON tblsuproducts.intProductTypeId = tblproducttype.intProdTypeId INNER JOIN    tblproductsubtype ON tblsuproducts.intProductSubTypeId = tblproductsubtype.intProdSubTypeId  ";
            lstProduct.DataBind();
        }
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstProduct.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView();
            
        }

        protected void ddlsortby_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(ddlsortby.SelectedIndex==0)
                {
                    BindListView();
                }
                else if (ddlsortby.SelectedIndex == 1)
                {
                    SqlDataSource1.SelectCommand = "SELECT        tblsuproducts.intId, tblsuproducts.varProductName, tblproducttype.varTypeName, tblproductsubtype.varSubTypeName, tblsuproducts.varproductcode, tblsuproducts.varShortDesc, tblsuproducts.varLongDesc, tblsuproducts.imgImage, tblsuproducts.varStatus, tblsuproducts.varWarning,    tblsuproducts.intPurchasePrice, tblsuproducts.intDealerPrice, tblsuproducts.intMRP, tblsuproducts.intProductTypeId, tblsuproducts.intProductSubTypeId   FROM       tblsuproducts INNER JOIN tblproducttype ON tblsuproducts.intProductTypeId = tblproducttype.intProdTypeId INNER JOIN    tblproductsubtype ON tblsuproducts.intProductSubTypeId = tblproductsubtype.intProdSubTypeId   order by intId desc";
                    lstProduct.DataBind();
                }
                else if (ddlsortby.SelectedIndex == 2)
                {
                    SqlDataSource1.SelectCommand = "SELECT        tblsuproducts.intId, tblsuproducts.varProductName, tblproducttype.varTypeName, tblproductsubtype.varSubTypeName, tblsuproducts.varproductcode, tblsuproducts.varShortDesc, tblsuproducts.varLongDesc, tblsuproducts.imgImage, tblsuproducts.varStatus, tblsuproducts.varWarning,    tblsuproducts.intPurchasePrice, tblsuproducts.intDealerPrice, tblsuproducts.intMRP, tblsuproducts.intProductTypeId, tblsuproducts.intProductSubTypeId   FROM       tblsuproducts INNER JOIN tblproducttype ON tblsuproducts.intProductTypeId = tblproducttype.intProdTypeId INNER JOIN    tblproductsubtype ON tblsuproducts.intProductSubTypeId = tblproductsubtype.intProdSubTypeId  order by intMRP ASC ";
                    lstProduct.DataBind();
                }
                else if (ddlsortby.SelectedIndex == 3)
                {
                    SqlDataSource1.SelectCommand = "SELECT        tblsuproducts.intId, tblsuproducts.varProductName, tblproducttype.varTypeName, tblproductsubtype.varSubTypeName, tblsuproducts.varproductcode, tblsuproducts.varShortDesc, tblsuproducts.varLongDesc, tblsuproducts.imgImage, tblsuproducts.varStatus, tblsuproducts.varWarning,    tblsuproducts.intPurchasePrice, tblsuproducts.intDealerPrice, tblsuproducts.intMRP, tblsuproducts.intProductTypeId, tblsuproducts.intProductSubTypeId   FROM       tblsuproducts INNER JOIN tblproducttype ON tblsuproducts.intProductTypeId = tblproducttype.intProdTypeId INNER JOIN    tblproductsubtype ON tblsuproducts.intProductSubTypeId = tblproductsubtype.intProdSubTypeId  order by intMRP DESC ";
                    lstProduct.DataBind();

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void lstProduct_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if(e.CommandName=="View")
                {
                    Cache["ProductID"] = e.CommandArgument.ToString();
                    Response.Redirect("~/Customer/Product.aspx", false);
                }

            }
            catch(Exception ex)
            {

            }
        }
    }
}