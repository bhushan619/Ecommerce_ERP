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
    public partial class AddProduct : System.Web.UI.Page
    {  // string editid ="";
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        DataTable dt ;
        static int orderrow = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getproductVariations();
                getproducttype();
                dt = new DataTable();
                MakeDataTable();
                orderrow = 0;
            }
            else
            {
                dt = (DataTable)ViewState["DataTable"];
            }
            ViewState["DataTable"] = dt;

        }
        private void MakeDataTable()
        {
            //dt.Columns.Add("SrNo");
            dt.Columns.Add("AttributeID");
            dt.Columns.Add("Attribute");
            dt.Columns.Add("Value");   
            
                   
        }
        private void AddToDataTable()
        {
            DataRow dr = dt.NewRow();
            //orderrow = orderrow + 1;
            //dr["SrNo"] = orderrow;
            dr["AttributeID"] = ddproductVariations.SelectedValue;
            dr["Attribute"] = ddproductVariations.SelectedItem.ToString();
            dr["Value"] = txtAttributeValue.Text.Replace("'","\\'");        

            dt.Rows.Add(dr);
        }

        private void BindGrid()
        {
            grdOrderDetails.DataSource = dt;
            grdOrderDetails.DataBind();


        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddproductVariations.SelectedIndex == 0)
            {
                MessageDisplay("Please Select Attribute", "alert dark  alert-dismissible  alert-danger");

            }
            else if (txtAttributeValue.Text == "0")
            {
                MessageDisplay("Please Add Attribute Value", "alert dark  alert-dismissible  alert-danger");

            }
            else
            {
                AddToDataTable();
                BindGrid();
                ddproductVariations.SelectedIndex = 0;
                txtAttributeValue.Text = "";
            }

        }
        protected void grdOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                  string id = e.CommandArgument.ToString();
                             
                if (e.CommandName == "remove")
                {
                    GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    int RemoveAt = gvr.RowIndex;
                    dt = (DataTable)ViewState["DataTable"];
                    dt.Rows.RemoveAt(RemoveAt);
                    dt.AcceptChanges();

                    //orderrow = orderrow - 1;
                    ViewState["DataTable"] = dt;
                    BindGrid();
                    ddproductVariations.SelectedIndex = 0;
                    txtAttributeValue.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw;
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
        protected void ddproducttypeid_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddproducttypeid.SelectedItem.Text == ":: Product Type ::")
            //{
            //    ddproductsubtype.Items.Insert(0, new ListItem(":: Product SubType ::", ""));
            //}
            //else
            //{
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
            //}

        }

        protected void grdOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }
        public void clear()
        {
            txtAttributeValue.Text = "";
            txtDealerPrice.Text = "";
            txtLongDesc.Text = "";
            txtMRP.Text = "";
            txtProdCode.Text = "";
            txtProductName.Text = "";
            txtPurchasePrice.Text = "";
            txtShortDesc.Text = "";
            ddproductsubtype.SelectedIndex = 0;
            ddproducttypeid.SelectedIndex = 0;            
            ddproductVariations.SelectedIndex = 0;
            txtAttributeValue.Text = "";
            ImgCust.ImageUrl = "~/media/Product/NoProfile.png";
            dt.Rows.Clear();
            lblImgMessage.Text = "";
            BindGrid();
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int contentLength = fupProPic.PostedFile.ContentLength;//You may need it for validation
            string contentType = fupProPic.PostedFile.ContentType;//You may need it for validation
            string fileName = fupProPic.PostedFile.FileName;
            if (contentLength != 0)
            {
                Int64 Productlastinsrtid = dbc.insert_tblsuproducts(txtProductName.Text.Replace("'", "\\'"), Convert.ToInt32(ddproducttypeid.SelectedValue.ToString()), Convert.ToInt32(ddproductsubtype.SelectedValue.ToString()), txtProdCode.Text.Replace("'", "\\'"), txtShortDesc.Text.Replace("'", "\\'"), txtLongDesc.Text.Replace("'", "\\'"), fileName, "1", "", Convert.ToInt64(txtPurchasePrice.Text.Replace("'", "\\'")), Convert.ToInt64(txtDealerPrice.Text.Replace("'", "\\'")), Convert.ToInt64(txtMRP.Text.Replace("'", "\\'")));

                                HttpFileCollection imageCollection = Request.Files;
                string photos = string.Empty;
                if (imageCollection == null)
                {
                    photos = "";
                }
                else
                {
                    for (int i = 1; i < imageCollection.Count; i++)
                    {
                        HttpPostedFile uploadImages = imageCollection[i];

                        string fileNameg = dbc.CreateRandomPassword(5) + Path.GetFileName(uploadImages.FileName);

                            dbc.con2.Close();
                            dbc.con2.Open();
                            MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand();// room_Category_Id, string title, string subtitle, string alias,string descr, string Floor, string facilities, double price, int check
                            cmd2 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblproductgallary( intProductId, file)  VALUES(" + Productlastinsrtid + ",'" + fileNameg + "')", dbc.con2);

                            cmd2.ExecuteNonQuery();
                            dbc.con2.Close();
                            cmd2.Dispose();                       
                            uploadImages.SaveAs(Server.MapPath("~/media/Product/") + fileNameg);

                        lblImgMessage.Text = "Images Uploaded";
                       // photos += fileNameg + ",";
                    }
                }
                 
                if (Productlastinsrtid != 0)
                {
                    fupProPic.PostedFile.SaveAs(Server.MapPath("~/media/Product/") + fileName);//Or code to save in the DataBase.

                    foreach (DataRow r in dt.Rows)
                    {
                        int i = dbc.insert_tblvariation(Productlastinsrtid,Convert.ToInt32( r["AttributeID"].ToString()), r["Value"].ToString());
                    }

                    clear();
                    MessageDisplay(Resources.Messages.Added, "alert alert-success");
                 
                }
                else
                {
                    MessageDisplay(Resources.Messages.FileUpload, "alert alert-success");
                }
            }
        }
    }
}