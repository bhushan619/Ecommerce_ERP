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
    public partial class AccountForSolar : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        static Int32 intAccSrId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDivision();
                getAccount();
                getListViewMasterData();
            }

        }
        public void getDivision()
        {
            try
            {
                DataTable dtc = new DataTable();
                dbc.con2.Close();
                MySql.Data.MySqlClient.MySqlCommand cmdp = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varDivisionId, varDivisionName FROM tblamsdivision", dbc.con2);
                dbc.con2.Open();
                MySqlDataAdapter adpc = new MySqlDataAdapter(cmdp);
                adpc.Fill(dtc);
                ddldivision.DataSource = dtc;
                ddldivision.DataTextField = "varDivisionName";
                ddldivision.DataValueField = "varDivisionId";

                ddldivision.DataBind();
                dbc.con2.Close();
                dtc.Dispose();
            }
            catch (Exception s)
            {
                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");


            }
        }
        public void getAccount()
        {
            try
            {
                DataTable dtc = new DataTable();
                dbc.con2.Close();
                MySql.Data.MySqlClient.MySqlCommand cmdp = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varAccountNo, varAccountName FROM tblamsaccountpersonnel", dbc.con2);
                dbc.con2.Open();
                MySqlDataAdapter adpc = new MySqlDataAdapter(cmdp);
                adpc.Fill(dtc);
                ddlAccount.DataSource = dtc;
                ddlAccount.DataTextField = "varAccountName";
                ddlAccount.DataValueField = "varAccountNo";
                ddlAccount.DataBind();
                dbc.con2.Close();
                dtc.Dispose();
            }
            catch (Exception s)
            {

                MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");


            }
        }
        void MessageDisplay(string message, string cssClass)
        {
            divMessage.Visible = true;
            divMessage.Attributes.Add("class", cssClass);
            string script = @"document.getElementById('" + divMessage.ClientID + "').innerHTML='" + message + "' ;setTimeout(function(){document.getElementById('" + divMessage.ClientID + "').style.display='none';},5000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
        //protected void btnsubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        int insert_ok= dbc.insert_tblbankaccountforsolar(ddldivision.SelectedValue,ddldivision.SelectedItem.ToString(),Convert.ToInt32( ddlAccount.SelectedValue),ddlAccount.SelectedItem.ToString());
        //        if (insert_ok == 1)
        //        {

        //            MessageDisplay(Resources.Messages.Added, "alert alert-success  fade in");

        //        }
        //        else
        //        {
        //            MessageDisplay(Resources.ErrorMessages.SomeError, "alert dark  alert-dismissible  alert-danger");
        //        }
        //        getListViewMasterData();


        //    }
        //    catch (Exception ex)
        //    {
        //        string exp = ex.Message;
        //        dbc.con1.Close();
        //    }
        //}
        public void getListViewMasterData()
        {
            try
            {
                dbc.con.Open();
                dbc.cmd = new MySqlCommand(" SELECT id, varDivisionId, varDivisionName, varAccountNo, varAccountName FROM tblbankaccountforsolar", dbc.con1);

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
          
            }
            catch (Exception ex)
            {
                string exp = ex.Message;
            }

        }


        protected void lstType_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {

                    btnupdate.Visible = true;
                    //btnsubmit.Visible = false;
                    dbc.con1.Close();
                    dbc.con1.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT id, varDivisionId, varDivisionName, varAccountNo, varAccountName FROM tblbankaccountforsolar where id=" + Convert.ToInt32(e.CommandArgument.ToString()) + "", dbc.con1);

                    dbc.dr = cmd.ExecuteReader();
                    if (dbc.dr.Read())
                    {
                        intAccSrId = Convert.ToInt32(dbc.dr["id"]);
                        ddldivision.SelectedValue = (dbc.dr["varDivisionId"].ToString());
                        ddlAccount.SelectedValue = (dbc.dr["varAccountNo"].ToString());

                    }
                    dbc.con1.Close();

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
                int update_ok= dbc.update_tblbankaccountforsolar(intAccSrId, ddldivision.SelectedValue, ddldivision.SelectedItem.ToString(), Convert.ToInt32(ddlAccount.SelectedValue), ddlAccount.SelectedItem.ToString());

                if (update_ok == 1)
                {
                    MessageDisplay(Resources.Messages.Updated, "alert alert-success  fade in");
                  
                }
                else
                {
                    MessageDisplay(Resources.Messages.NotUpdated, "alert alert-block alert-danger fade in");
                }


                //btnsubmit.Visible = true;
                btnupdate.Visible = false;
              
                getListViewMasterData();
             

            }
            catch (Exception ex)
            {
                string exp = ex.Message;
                dbc.con1.Close();
            }
        }
    }
}