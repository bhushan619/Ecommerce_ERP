using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.IO;
using MySql.Data.MySqlClient;
using System.Globalization;
using SudarshanSolar.DbCode;

namespace SudarshanSolar.Customer
{
    public partial class PaymentStatus : System.Web.UI.Page
    {
        DatabaseConnection dbc = new DatabaseConnection();
        RegexUtilities rex = new RegexUtilities();
        static Int32 invoicecartid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;
                string order_id = string.Empty;
                string transactionid = string.Empty;
                string productinfo = string.Empty;
                string orderid = string.Empty;
                string amt = string.Empty;
                string cartid = string.Empty;
                string ProductId = string.Empty;
                string totalamt = string.Empty;

                string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";

                if (Request.Form["status"] == "success")
                {

                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    merc_hash_string = ConfigurationManager.AppSettings["SALT"] + "|" + Request.Form["status"];


                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (Request.Form[merc_hash_var] != null ? Request.Form[merc_hash_var] : "");


                    }
                    //Response.Write(merc_hash_string);//exit;
                    merc_hash = Generatehash512(merc_hash_string).ToLower();

                    if (merc_hash != Request.Form["hash"])
                    {
                        //Response.Write("Hash value did not matched");

                    }
                    else
                    {
                        order_id = Request.Form["txnid"];

                        string[] arry = merc_hash_string.Split(new char[] { '|' });

                        transactionid = arry[16].ToString();
                        productinfo = arry[14].ToString();
                        orderid = arry[11].ToString();
                        amt = arry[15].ToString();
                        cartid = arry[11].ToString();
                        ProductId = arry[10].ToString();
                        totalamt = arry[9].ToString();
                        //OK Done 

                        invoicecartid =Convert.ToInt32(orderid);

                   
                        
                        dbc.con.Open();
                        dbc.cmd = new MySqlCommand("UPDATE cart set status=1 WHERE id = " + orderid + "", dbc.con);
                        dbc.cmd.ExecuteNonQuery();
                        dbc.con.Close();

                        dbc.con.Open();
                        dbc.cmd = new MySqlCommand("INSERT INTO cart_transaction_history( cart_transaction_id, payment_date, comment, amount, tax, discount, recieved, returned, outstanding, total, trans, payment_mode) VALUES  (" + cartid + ", '" + DateTime.UtcNow.ToString("yyyy-MM-dd") + "','Order Confirm payment' ," + totalamt + ", 0, 0, 0, 0," + (Convert.ToDouble(totalamt) - Convert.ToDouble(amt)).ToString() + ", " + totalamt + ", 'NA', 'NA')", dbc.con);
                        dbc.cmd.ExecuteNonQuery();
                        dbc.con.Close();

                        string[] arryAccDetails = dbc.getInsertAccountDetails().Split('_');
                        dbc.insert_tblamsaccountbookJama(DateTime.UtcNow.ToString("yyyy-MM-dd"), arryAccDetails[3].ToString(), arryAccDetails[2].ToString(), "NA", "New Purchase Payment", amt, "Credit", arryAccDetails[0].ToString(), (Convert.ToDouble(dbc.getAmount(DateTime.UtcNow.ToString("yyyy-MM-dd"), "desc", arryAccDetails[0].ToString())) + Convert.ToDouble(amt)).ToString(), arryAccDetails[1].ToString());
                        
                        getCustomerData();

                        SqlDataSourceOrder.SelectCommand = "SELECT        cart.id, cart.comments, DATE_FORMAT(cart.bookingdate,'%e %b %Y') as bookingdate, cart.status, cart.personnel_id, cart_products.comments AS Expr1, cart_products.quantity, tblsuproducts.varProductName,  tblsuproducts.imgImage, tblsuproducts.intMRP FROM            cart INNER JOIN     cart_products ON cart.id = cart_products.cartid INNER JOIN      tblsuproducts ON cart_products.productid = tblsuproducts.intId WHERE cart.id  = " + orderid + " ";
                        lstOrderDetails.DataBind();

                        sendmail(rex.DecryptString(Request.Cookies["custid"].Value.ToString()), txtFullname.Text, txtEmail.Text, transactionid, orderid,  amt);

                    }

                }
                else
                {
                    Response.Redirect("~/Customer/Dashboard.aspx", false);
                }
            }
        }
        protected void lnkViewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                //Cache["custid"] = rex.DecryptString(Request.Cookies["custid"].Value.ToString());
                Cache["cartid"] = invoicecartid;
                Response.Redirect("~/Customer/Invoice.aspx", false);
            }
            catch (Exception ex)
            {
                dbc.con.Close();
            }
        }
        public void getCustomerData()
        {
            try
            {
                dbc.con.Close();
                dbc.con.Open();
                dbc.cmd = new MySqlCommand("SELECT intId, varCompanyName, varRepresentativeName, varMobile, varMobileVerify, varLandline, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varStatus, varPanCardNo, varVatNo, varTinNo, varCustomerType, imgImage, dtDateOfEstd, varNotify, varCallDate FROM tblsucustomer WHERE intId=" + rex.DecryptString(Request.Cookies["custid"].Value.ToString()) + "", dbc.con);
                dbc.dr = dbc.cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    txtFullname.Text = dbc.dr["varRepresentativeName"].ToString();
                    txtCompanyname.Text = dbc.dr["varCompanyName"].ToString();
                    txtMobile.Text = dbc.dr["varMobile"].ToString();
                    cmbstate.Text = dbc.dr["varState"].ToString();

                    cmbcity.Text = dbc.dr["varCity"].ToString();
                    txtAddress.Text = dbc.dr["varAddress"].ToString();
                    txtEmail.Text = dbc.dr["varEmail"].ToString();
                }
                else
                {
                    Response.Redirect("~/customer/Logout.aspx", false);
                }
                dbc.con.Close();
            }
            catch (Exception ex)
            {
                dbc.con.Close();
            }

           
        }
        public string Generatehash512(string text)
        {

            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;

        }

        private string PopulateBody(string memid, string Name, string EmailId, string trans, string order,  string amt)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Personnel/admin/emails/Upgrade.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{memid}", memid);
            body = body.Replace("{Name}", Name);
            body = body.Replace("{EmailId}", EmailId);
            body = body.Replace("{date}", DateTime.UtcNow.ToString("yyyy-MM-dd"));
            body = body.Replace("{trans}", trans);
            body = body.Replace("{order}", order);
          
            body = body.Replace("{amt}", amt);
          
            return body;
        }
        protected void sendmail(string memid, string name, string email, string trans, string order,  string amt)
        {
            try
            {
                using (MailMessage mm = new MailMessage(new MailAddress("Solar <info.edmitra@gmail.com>"), new MailAddress(email)))
                {
                    mm.Subject = "Solar : Order Confirmation !!!";
                    string datenow = DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString();
                    mm.Body = PopulateBody(memid, name, email, trans, order,  amt);

                    mm.IsBodyHtml = true;

                    System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient();
                    // for server

                    SmtpServer.Host = "relay-hosting.secureserver.net";
                    SmtpServer.EnableSsl = false;
                    //for server
                    SmtpServer.Port = 25;


                    //for local 

                    //SmtpServer.Host = "smtp.gmail.com";
                    //SmtpServer.EnableSsl = true;

                    //SmtpServer.Port = 587;


                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    NetworkCredential NetworkCred = new NetworkCredential("info.edmitra@gmail.com", "info@2014");
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = NetworkCred;

                    SmtpServer.Send(mm);


                }
            }
            catch (Exception rx)
            {
                 
            }
        }


    }
}