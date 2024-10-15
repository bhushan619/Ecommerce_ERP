using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace SudarshanSolar.DbCode
{
    public class DatabaseConnection
    {
        public MySql.Data.MySqlClient.MySqlConnection con, con1, con2, con3;
        public MySql.Data.MySqlClient.MySqlCommand cmd, cmd1;
        public MySql.Data.MySqlClient.MySqlDataReader dr, dr1;

        public MySql.Data.MySqlClient.MySqlDataAdapter dataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
        public DataTable oDt, oDt1;
        public DataRow oDr;

        string tdt = string.Empty;

        public string begindate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1).ToShortDateString();
        public string enddate = DateTime.UtcNow.ToShortDateString();

        public DatabaseConnection()
        {
            //
            con = new MySql.Data.MySqlClient.MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["solarConnectionString"].ConnectionString;
            con1 = new MySql.Data.MySqlClient.MySqlConnection();
            con1.ConnectionString = ConfigurationManager.ConnectionStrings["solarConnectionString"].ConnectionString;
            con2 = new MySql.Data.MySqlClient.MySqlConnection();
            con2.ConnectionString = ConfigurationManager.ConnectionStrings["solarConnectionString"].ConnectionString;
            con3 = new MySql.Data.MySqlClient.MySqlConnection();
            con3.ConnectionString = ConfigurationManager.ConnectionStrings["solarConnectionString"].ConnectionString;
            //
        }
        public string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "123456789";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        public int max_eventId()
        {
            int chk = 0;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from tblhhigallery", con2);
                con2.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
                con2.Close();
                return chk;
            }
            catch (Exception ex)
            {
                con2.Close();
                return chk;
            }
        }
        public int max_PhotoId()
        {
            int chk = 0;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intGalleryId) as newid from tblhhiphotoupload", con2);
                con2.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
                con2.Close();
                return chk;
            }
            catch (Exception ex)
            {
                con2.Close();
                return chk;
            }
        }
        public int insert_tblEventAndPhotoDetails1(int eid, string ecaption, string epath)
        {
            try
            {
                int pid = max_PhotoId();
                pid = pid + 1;
                con.Close();
                con.Open();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblhhiphotoupload VALUES(" + pid + ",'" + eid + "','" + ecaption + "','" + epath + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }

        public int insert_tblEventAndPhotoDetails(string ename, string edate)
        {
            try
            {
                con.Close();
                int eid = max_eventId();
                eid = eid + 1;
                con.Open();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblhhigallery VALUES(" + eid + ",'" + ename + "','" + enddate + "','yes')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return eid;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }

        public Int64 insert_tblEmployeeDetails(string name, string mob, string gen, string mverify, string email, string everify, string pass, string address, string city, string state, string desig, string subdes, string status, string idproof, string idproofno, string pan, string image, string dob, string page)
        {
            try
            {
                con.Close();
                con.Open();
             
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsupersonnel ( varName, varMobile,  varMobileVerify, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varDesignation, varSubDesig, varStatus, varIDProof, varIDProofNo, varPanCardNo, imgImage, dtDateOfBirth) VALUES('" + name + "','" + mob + "','" + mverify + "','" + email + "','" + everify + "','" + pass + "','" + address + "','" + city + "','" + state + "','Customer','" + subdes + "','" + status + "','" + idproof + "','" + idproofno + "','" + pan + "','" + image + "','" + dob + "')", con);
             
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return Convert.ToInt64(cmd.LastInsertedId);
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }

        }
        public int Update_tblsuEnquiryReplySendAdmin(string mid, string replymsg)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("insert into tblsuconversation (intMessageId, nvarMsgFrom, nvarMsgTo) values( " + mid + ",'','" + replymsg + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int insert_tblsuenquiry(int msgbyid, string msgbyname, string fromdesig, int msgtoid, string msgtoname, string todesig, string enqsub, string enqmsg, string date, string time)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdb = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsuenquiry ( intMessageById, varMessageByName, varFromDesig, intMessageToId, varMessageToName, varMessageToDesig, varEnquirySubject, dtDate, tmTime, varStatus)  VALUES(" + msgbyid + ",'" + msgbyname + "','" + fromdesig + "'," + msgtoid + ",'" + msgtoname + "','" + todesig + "','" + enqsub + "','" + date + "','" + time + "','Unread')", con);
                cmdb.ExecuteNonQuery();
                Int32 id =Convert.ToInt32( cmdb.LastInsertedId);
                con.Close();
                cmdb.Dispose();

                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsuconversation ( intMessageId,nvarMsgFrom, nvarMsgTo) VALUES(" + id + ",'" + enqmsg + "','')", con);
                cmda.ExecuteNonQuery();
                con.Close();
                cmda.Dispose();

               
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int update_tblsupersonnel(string id, string cname, string mob, string address, string city, string state, string idProof, string idProofno, string pan, string dob)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_solar.tblsupersonnel SET varName = '" + cname + "',varMobile = '" + mob + "', varAddress= '" + address + "',varCity = '" + city + "',varState = '" + state + "',varIDProof = '" + idProof + "',varIDProofNo = '" + idProofno + "',varPanCardNo = '" + pan + "',dtDateOfBirth='" + dob + "' WHERE intId = " + id + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int check_already_CustomerTaxDetails(int Companyid)
        {
            try
            {
                int schId = 0;
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intCompanyId FROM anuvaa_solar.tblsucustomertaxdetails WHERE intCompanyId ='" + Companyid + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    schId = 1;
                }
                else
                {
                    schId = 0;
                }
                con.Close();
                return schId;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }

        }
        public int insert_tblproducttype(string varTypeName, string varDescription, int varIsActive, string varProductImage)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblproducttype( varTypeName, varDescription, varCreatedDate, varIsActive, 	varProductImage, ex2, ex3, ex4) VALUES (  '" + varTypeName + "', '" + varDescription + "', '" + DateTime.UtcNow.ToString("yyyy-MM-dd") + "', " + varIsActive + ", '" + varProductImage + "','','','')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }

        }
        public Int64 insert_tblsuproducts(string varProductName,int intProductTypeId,int intProductSubTypeId,string varproductcode, string varShortDesc, string varLongDesc, string imgImage, string varStatus, string varWarning,Int64 intPurchasePrice,Int64 intDealerPrice,Int64 intMRP)
        {
            try
            {
                // int id = max_service();
                //id = id + 1;
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();// room_Category_Id, string title, string subtitle, string alias,string descr, string Floor, string facilities, double price, int check
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsuproducts( varProductName, intProductTypeId, intProductSubTypeId, varproductcode, varShortDesc, varLongDesc, imgImage, varStatus, varWarning, intPurchasePrice, intDealerPrice, intMRP, ex1, ex2) VALUES ('"+varProductName+"',"+intProductTypeId+","+ intProductSubTypeId + ",'"+ varproductcode + "','"+ varShortDesc + "','"+ varLongDesc + "','"+ imgImage + "','"+ varStatus + "','"+ varWarning + "',"+intPurchasePrice+","+intDealerPrice+","+intMRP+",'','')", con);

                cmd.ExecuteNonQuery();
                Int64 lastid = cmd.LastInsertedId;
                con.Close();
                cmd.Dispose();

                con.Close();

              
                return lastid;

            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }

        }
        public int Update_tblsuproducts(int ProductId,string varProductName, int intProductTypeId, int intProductSubTypeId, string varproductcode, string varShortDesc, string varLongDesc, string imgImage, Int64 intPurchasePrice, Int64 intDealerPrice, Int64 intMRP)
        {
            try
            {
                // int id = max_service();
                //id = id + 1;
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();// room_Category_Id, string title, string subtitle, string alias,string descr, string Floor, string facilities, double price, int check
                cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblsuproducts set varProductName='" + varProductName + "', intProductTypeId=" + intProductTypeId + ", intProductSubTypeId=" + intProductSubTypeId + ", varproductcode='" + varproductcode + "', varShortDesc='" + varShortDesc + "', varLongDesc='" + varLongDesc + "', imgImage='" + imgImage + "',  intPurchasePrice=" + intPurchasePrice + ", intDealerPrice=" + intDealerPrice + ", intMRP=" + intMRP + " where intId=" + ProductId + "", con);

                 cmd.ExecuteNonQuery();              
                con.Close();
                cmd.Dispose();          
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }

        }
        public int insert_tblvariation( Int64 intProductId,Int32 intVariationId,string varVariationValue)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblvariation(intProductId, intVariationId, varVariationValue) VALUES (  " + intProductId + ", " + intVariationId + ", '" + varVariationValue + "')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }

        }

        public int insert_tblproductvariation(string varTypeName, string varDescription)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblproductvariation( varVariation, varDescription,ex1) VALUES (  '" + varTypeName + "', '" + varDescription + "','')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }

        }
        public int insert_tblbankaccountforsolar(string divid,string divisionName,int accid, string Accname)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblbankaccountforsolar VALUES ('"+divid+"', '" + divisionName + "',"+accid+",'" + Accname + "','')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }

        }
        public int update_tblbankaccountforsolar(int myintid,string divid, string divisionName, int accid, string Accname)
        {
            try
            {

                con.Close();
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd = new MySqlCommand("UPDATE tblbankaccountforsolar SET varDivisionId='" + divid + "',varDivisionName='" + divisionName + "', varAccountNo="+accid+ ",varAccountName='"+Accname+"' WHERE id=" + myintid + " ", con);
          
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }
        }
        public int insert_tblproductsubtype(int prodtypeid,string varTypeName, string varDescription, int varIsActive)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblproductsubtype( intProdTypeId,varSubTypeName, varDescription, varCreatedDate, varIsActive, 	 ex2, ex3, ex4) VALUES ( "+prodtypeid+", '" + varTypeName + "', '" + varDescription + "', '" + DateTime.UtcNow.ToString("yyyy-MM-dd") + "', " + varIsActive + ",'','','')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }

        }
        public int update_tblproducttype(int intProdTypeId, string varTypeName, string varDescription, int varIsActive, string varProductImage)
        {
            try
            {

                con.Close();
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd = new MySqlCommand("UPDATE tblproducttype SET varTypeName='" + varTypeName + "',varDescription='" + varDescription + "',varCreateddate='" + DateTime.UtcNow.ToString("yyyy-MM-dd") + "',varIsActive=" + varIsActive + ", 	varProductImage= '" + varProductImage + "' WHERE intProdTypeId=" + intProdTypeId + " ", con);
                // UPDATE tbl_task SET intid=[value - 1],varsubject=[value - 2],vartaskdescription=[value - 3],varfremark=[value - 4],vartremark=[value - 5],varstatus=[value - 6],varisactive=[value - 7],varcreateddate=[value - 8] WHERE intid
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }
        }
        public int update_tblproductvariation(int intId, string varVariation, string varDescription)
        {
            try
            {

                con.Close();
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd = new MySqlCommand("UPDATE tblproductvariation SET varVariation='" + varVariation + "',varDescription='" + varDescription + "' WHERE intId=" + intId + " ", con);
                // UPDATE tbl_task SET intid=[value - 1],varsubject=[value - 2],vartaskdescription=[value - 3],varfremark=[value - 4],vartremark=[value - 5],varstatus=[value - 6],varisactive=[value - 7],varcreateddate=[value - 8] WHERE intid
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }
        }
        public int update_tblvariation(int VariationIntId, int intvariationId, string values)
        {
            try
            {

                con.Close();
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd = new MySqlCommand("UPDATE tblvariation  SET intVariationId=" + intvariationId + ",varVariationValue='" + values + "' WHERE intId=" + VariationIntId + " ", con);
                // UPDATE tbl_task SET intid=[value - 1],varsubject=[value - 2],vartaskdescription=[value - 3],varfremark=[value - 4],vartremark=[value - 5],varstatus=[value - 6],varisactive=[value - 7],varcreateddate=[value - 8] WHERE intid
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }
        }
        public int update_tblproductsubtype(int intProdsubTypeId, int intProdTypeId, string varTypeName, string varDescription, int varIsActive)
        {
            try
            {

                con.Close();
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd = new MySqlCommand("UPDATE tblproductsubtype SET  intProdTypeId ="+ intProdTypeId + ",varSubTypeName='" + varTypeName + "',varDescription='" + varDescription + "',varCreateddate='" + DateTime.UtcNow.ToString("yyyy-MM-dd") + "',varIsActive=" + varIsActive + " WHERE intProdSubTypeId=" + intProdsubTypeId + " ", con);
                // UPDATE tbl_task SET intid=[value - 1],varsubject=[value - 2],vartaskdescription=[value - 3],varfremark=[value - 4],vartremark=[value - 5],varstatus=[value - 6],varisactive=[value - 7],varcreateddate=[value - 8] WHERE intid
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }
        }
        public int max_tblsucollection()
        {
            int chk = 0;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_solar.tblsucollection", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return chk;
        }
        public int insert_Collection_Marketing(int custid, int empid, string paymode, string Checkno, string CheckDate, string varAmount, string OtherPaymentDetails)
        {
            try
            {
                int id = max_tblsucollection();
                id = id + 1;
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_solar.tblsucollection VALUES (" + id + "," + id + "," + custid + "," + empid + ",'" + DateTime.UtcNow.ToShortDateString() + "','" + paymode + "','" + Checkno + "','" + CheckDate + "','" + varAmount + "','" + OtherPaymentDetails + "','0','')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();

                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }

        public int max_tblsucustomertaxdetails()
        {
            int chk = 0;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_solar.tblsucustomertaxdetails", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return chk;
        }
        public int insert_tblsucustomertaxdetails(int Cid, string cname, string ctaxable, string ctaxtype, string ctaxgroup, string ccstNumber, string ctaxdiscount, string ccrbills, string ccrlimit, string ccrdays)
        {
            con.Close();
            int id = max_tblsucustomertaxdetails();
            id = id + 1;

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_solar.tblsucustomertaxdetails VALUES(" + id + "," + Cid + ",'" + cname + "','" + ctaxable + "', '" + ctaxtype + "', '" + ctaxgroup + "', '" + ccstNumber + "','" + ctaxdiscount + "','" + ccrbills + "','" + ccrlimit + "','" + ccrdays + "','','')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        public int update_tblsucustomertaxdetails(int Cid, string ctaxable, string ctaxtype, string ctaxgroup, string ccstNumber, string ctaxdiscount, string ccrbills, string ccrlimit, string ccrdays)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_solar.tblsucustomertaxdetails SET varTaxable ='" + ctaxable + "',varTaxType='" + ctaxtype + "',varCSTnumber='" + ccstNumber + "',varTaxGroup='" + ctaxgroup + "',varTaxDiscount='" + ctaxdiscount + "',varCrBills='" + ccrbills + "', varCrLimit='" + ccrlimit + "',varCrdays='" + ccrdays + "' WHERE intCompanyId = '" + Cid + "'", con);
                cmd1.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int Update_CustomerStatus(int custid, string status)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_solar.tblsucustomer SET varStatus='" + status + "' WHERE intId=" + custid + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }

        }
        public int update_tblsucustomeradmin(string id, string cname, string rname, string mob, string landlne, string address, string city, string state, string status, string pan, string vat, string tin, string img, string doet)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_solar.tblsucustomer SET varCompanyName = '" + cname + "',varRepresentativeName = '" + rname + "',varMobile = '" + mob + "',varLandline = '" + landlne + "', varAddress= '" + address + "',varCity = '" + city + "',varState = '" + state + "',varStatus='Whitelist',varPanCardNo = '" + pan + "',varVatNo = '" + vat + "',varTinNo = '" + tin + "',imgImage='" + img + "',dtDateOfEstd = '" + doet + "' WHERE intId = " + id + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int Update_ProfilePicemp(int empid, string fname)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_solar.tblsupersonnel SET imgImage='" + fname + "' WHERE intId=" + empid + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }

        }
        public String select_empProfilePic(int id)
        {
            String name = String.Empty;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select imgImage from anuvaa_solar.tblsupersonnel where intId =" + id + " ", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    name = dr["imgImage"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return name;
        }
        public int max_tblsucustomeradminother()
        {
            int chk = 0;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_solar.tblsucustomerotherdetails", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return chk;
        }
        public int Insert_tblsucustomeradminother(string custid, string rname, string desres, string contact, string dob, string remark)
        {
            try
            {
                con.Close();
                int id = max_tblsucustomeradminother();
                id = id + 1;
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdb = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_solar.tblsucustomerotherdetails VALUES(" + id + ",'" + custid + "','" + rname + "','" + desres + "','" + contact + "','" + dob + "','" + remark + "','')", con);
                cmdb.ExecuteNonQuery();
                con.Close();
                cmdb.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }

  
        public int check_already_Employee(string email)
        {
            try
            {
                con.Close();
                int schId = 0;
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varEmail FROM anuvaa_Solar.tblsupersonnel WHERE varEmail= '" + email + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    schId = 1;
                }
                else
                {
                    schId = 0;
                }
                con.Close();
                return schId;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int check_already_Customer(string email)
        {
            try
            {
                con.Close();
                int schId = 0;
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varCompanyName, varRepresentativeName, varMobile, varMobileVerify, varLandline, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varStatus, varPanCardNo, varVatNo, varTinNo, varCustomerType, imgImage, dtDateOfEstd, varNotify, varCallDate FROM tblsucustomer WHERE varEmail= '" + email + "' ", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    schId = 1;
                }
                else
                {
                    schId = 0;
                }
                con.Close();
                return schId;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public string getCustNameById(Int32 custid)
        {
            string pname = string.Empty;

            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varCompanyName, varRepresentativeName, varMobile, varMobileVerify, varLandline, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varStatus, varPanCardNo, varVatNo, varTinNo, varCustomerType, imgImage, dtDateOfEstd, varNotify, varCallDate FROM tblsucustomer WHERE intId=" + custid + "", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    pname =(dr["varRepresentativeName"].ToString());
                }
                con.Close();
            return pname;
            }
            catch (Exception ex)
            {
                con.Close();
                return pname;
            }
           
        }
        public string getEmpNameById(Int32 empid)
        {
            string pname = string.Empty;

            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varName, varMobile, varMobileVerify, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varDesignation, varSubDesig, varStatus, varIDProof, varIDProofNo, varPanCardNo, imgImage, dtDateOfBirth FROM tblsupersonnel WHERE intId=" + empid + "", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    pname = (dr["varName"].ToString());
                }
                con.Close();
                return pname;
            }
            catch (Exception ex)
            {
                con.Close();
                return pname;
            }

        }
        public string getProductNameById(Int32 prodId)
        {
            string pname = string.Empty;
            try
            {
                con.Close();
                con.Open();
                cmd = new MySqlCommand("SELECT intId, varProductName, intProductTypeId, intProductSubTypeId, varproductcode, varShortDesc, varLongDesc, imgImage, varStatus, varWarning, intPurchasePrice, intDealerPrice, intMRP, ex1, ex2 FROM tblsuproducts WHERE intId=" + prodId + "", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    pname = dr["varProductName"].ToString();
                }
                con.Close();
                return pname;
            }
            catch (Exception ex)
            {
                con.Close();
                return pname;
            }
        }
        public string getpass(string email, string cos)
        {
            string schId = string.Empty;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                con.Open();
                if (cos == "c")
                {
                    cmd = new MySql.Data.MySqlClient.MySqlCommand("select varPassword FROM anuvaa_Solar.tblsucustomer WHERE varEmail= '" + email + "'", con);
                }
                else if (cos == "e")
                {
                    cmd = new MySql.Data.MySqlClient.MySqlCommand("select varPassword FROM anuvaa_Solar.tblsupersonnel WHERE varEmail= '" + email + "'", con);
                }
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    schId = dr["varPassword"].ToString();
                }
                else
                {

                }
                con.Close();
                return schId;
            }
            catch (Exception s)
            {
                con.Close();
                return schId;
            }
        }
        public int max_tblsuexpenses()
        {
            int chk = 0;
            try
            {
                con2.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_solar.tblsuexpenses", con2);
                con2.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
                con2.Close();
                return chk;
            }
            catch (Exception ex)
            {
                con2.Close();
                return chk;
            }
        }
        public int max_tblsuexpensesdetails()
        {
            int chk = 0;
            try
            {
                con2.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_solar.tblsuexpensesdetails", con2);
                con2.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
                con2.Close();
                return chk;
            }
            catch (Exception ex)
            {
                con2.Close();
                return chk;
            }
        }
        public int insert_tblsuexpensesdetails(Int64 ExpensesId, string Date, string Place, string ExpenseDetail, string ModeOfTransport, string Local, string Lodging, string DA, string Other, string Total)
        {
            try
            {
                int id = max_tblsuexpensesdetails();
                id = id + 1;
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsuexpensesdetails VALUES (" + id + "," + ExpensesId + ",'" + Date + "','" + DateTime.UtcNow.ToShortTimeString() + "','" + Place + "','" + ExpenseDetail + "','" + ModeOfTransport + "','" + Local + "','" + Lodging + "','" + DA + "','" + Other + "','" + Total + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();

                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int insert_tblsuexpenses(int EmpId, string StartDate, string Advance, string Location, string Balance, string TotalExpense, string EndDate, string imgSignature, string Remark)
        {
            try
            {
                int id = max_tblsuexpenses();
                id = id + 1;
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsuexpenses VALUES (" + id + "," + EmpId + ",'" + StartDate + "','" + Advance + "','" + Location + "','" + Balance + "','" + TotalExpense + "','" + EndDate + "','" + imgSignature + "','" + Remark + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();

                return id;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int max_DSR()
        {
            int chk = 0;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_solar.tblsudsrdetails", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return chk;
        }
        public int insert_tblDSRDetails(int empid, string empName, string date, string time, string location, string calltype, string custname, string repname, string landline, string mobile, string remark, string nextdate, string status,string dllstatus)
        {
            try
            {
                con.Close();
                int id = max_DSR();
                id = id + 1;
                con.Open();

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_solar.tblsudsrdetails VALUES(" + id + "," + empid + ",'" + empName + "','" + date + "','" + time + "','" + location + "','" + calltype + "','" + custname + "','" + repname + "','" + landline + "','" + mobile + "','" + remark + "','" + nextdate + "','" + status + "','" + dllstatus + "')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }

        public int insert_tblEmployeeDetails(string name, string mob, string mverify, string email, string everify, string pass, string address, string city, string state, string desig, string subdes, string status, string idproof, string idproofno, string pan, string image, string dob, string page)
        {
            try
            {
                con.Close();
                int id = max_tblEmployeeDetails();
                id = id + 1;
                con.Open();
                string design = "employee";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                if (page == "login")
                {
                    cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_Solar.tblsupersonnel VALUES(" + id + ",N'" + name + "',N'" + mob + "',N'',N'" + email + "',N'" + everify + "',N'" + pass + "',N'',N'',N'',N'" + design + "',N'Pending',N'',N'',N'',N'',N'NoProfile.png',N'')", con);
                }
                else if (page == "adminemp")
                {
                    cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_Solar.tblsupersonnel VALUES(" + id + ",N'" + name + "',N'" + mob + "',N'" + mverify + "',N'" + email + "',N'" + everify + "',N'" + pass + "',N'" + address + "',N'" + city + "',N'" + state + "',N'" + design + "',N'" + subdes + "',N'" + status + "',N'" + idproof + "',N'" + idproofno + "',N'" + pan + "',N'" + image + "',N'" + dob + "')", con);
                }
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }

        }
        public int update_tblsupersonnelEmp(string id, string name, string mob, string address, string city, string state, string subdes, string idproof, string idproofno, string pan, string image, string dob)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_Solar.tblsupersonnel SET varName = '" + name + "',varMobile = '" + mob + "', varAddress= '" + address + "',varCity = '" + city + "',varState = '" + state + "',varSubDesig='" + subdes + "',varIDProof = '" + idproof + "',varIDProofNo = '" + idproofno + "',varPanCardNo = '" + pan + "',imgImage='" + image + "',dtDateOfBirth='" + dob + "' WHERE intId = " + id + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int insert_tblCustomerDetails(string varCompanyName, string varRepresentativeName, string varMobile, string varMobileVerify, string varLandline, string varEmail, string varEmailVerify, string varPassword, string varAddress, string varCity, string varState, string varStatus, string varPanCardNo, string varVatNo, string varTinNo, string varCustomerType, string imgImage, string dtDateOfEstd, string varNotify, string varCallDate)
        {
            try
            {
                int id = max_tblCustomerDetails();
                id = id + 1;
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_Solar.tblsucustomer (intId, varCompanyName, varRepresentativeName, varMobile, varMobileVerify, varLandline, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varStatus, varPanCardNo, varVatNo, varTinNo, varCustomerType, imgImage, dtDateOfEstd, varNotify, varCallDate) VALUES("+id+", '"+varCompanyName+"', '"+ varRepresentativeName+"', '"+ varMobile+"', '"+ varMobileVerify+"', '"+ varLandline+"', '"+ varEmail+"', '"+ varEmailVerify+"', '"+ varPassword+"', '"+ varAddress+"', '"+ varCity+"', '"+ varState+"', '"+ varStatus+"', '"+ varPanCardNo+"', '"+ varVatNo+"', '"+ varTinNo+"', '"+ varCustomerType+"', '"+ imgImage+"', '"+ dtDateOfEstd+"', '"+ varNotify+"', '"+ varCallDate+"')", con);
                cmd.ExecuteNonQuery();

                con.Close();
                cmd.Dispose();


                con.Open();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_Solar.tblamsaccountbook (intCustomerId,varReason,varAccountEntryType,varAmount,PreviousBalance,varBalance) VALUES(" + id + ",'Account Opening','Credit','0','0','0')", con);
                cmd.ExecuteNonQuery();
              Int64 legerid=  cmd.LastInsertedId;
                con.Close();
                cmd.Dispose();

                con.Open();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_Solar.tblamsledger (intCustomerId,varAccountBookEntry,varDebitAmount,varCreditAmount,varAccountEntryType) VALUES(" + id + "," + legerid + ",'0','0','Credit')", con);
                cmd.ExecuteNonQuery();
               
                con.Close();
                cmd.Dispose();


                return id;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }

        public int insert_CustomerDetail(string cname, string rname, string mob, string mverify, string landline, string email, string everify, string pass, string address, string city, string state, string status, string pan, string vat, string tin, string custtype, string image, string doet)
        {
            try
            {
                con.Close();
                int id = max_tblCustomerDetails();
                id = id + 1;
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_Solar.tblsucustomer VALUES(" + id + ",N'" + cname + "',N'" + rname + "',N'" + mob + "',N'" + mverify + "',N'" + landline + "',N'" + email + "',N'" + everify + "',N'" + pass + "',N'" + address + "',N'" + city + "',N'" + state + "',N'Whitelist',N'" + pan + "',N'" + vat + "',N'" + tin + "',N'',N'" + image + "',N'" + doet + "','NA','NA')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }

        }
        public int max_tblCustomerDetails()
        {
            int chk = 0;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_Solar.tblsucustomer", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return chk;
        }
        public int max_tblEmployeeDetails()
        {
            int chk = 0;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_Solar.tblsupersonnel", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return chk;
        }
        public int update_tbldocuments(int Id,  string varDescription, string varDocument, int intIsActive)
        {
            try
            {
                con.Close();
                con.Open();

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

                cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tbldocuments  SET  varDescription ='" + varDescription + "', varDocument ='" + varDocument + "', intIsActive =" + intIsActive + " WHERE intId =" + Id + "", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {

                string strr = s.Message;
                con.Close();
                return 0;
            }
        }
        public int insert_tblbankdetails( string varPersonnelId, string varAccountHolderName, string varAccountNo, string varBankName, int intAccountType, string varIFSCCode, string varMCIRCode, string varBranchAddress, string varBranchName, string varCreatedDate, string varCreatedBy, int intIsActive)
        {
            try
            {
                //int id = max_tblbankdetails();
                //id = id + 1;
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblbankdetails ( varPersonnelId,  varAccountHolderName, varAccountNo, varBankName, intAccountType, varIFSCCode, varMCIRCode, varBranchAddress, varBranchName, varCreatedDate, varCreatedBy, intIsActive, ex1, ex2, ex3, ex4, ex5) VALUES('" + varPersonnelId + "','" + varAccountHolderName + "','" + varAccountNo + "','" + varBankName + "'," + intAccountType + ",'" + varIFSCCode + "','" + varMCIRCode + "','" + varBranchAddress + "','" + varBranchName + "','" + varCreatedDate + "','" + varCreatedBy + "'," + intIsActive + ",'','','','','')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }

        }
        public int update_tblbankdetails(int Id, string varAccountHolderName, string varAccountNo, string varBankName, int intAccountType, string varIFSCCode, string varMCIRCode, string varBranchAddress, string varBranchName, int intIsActive)
        {
            try
            {
                con.Close();
                con.Open();

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

                cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblbankdetails  SET varBankName='" + varBankName + "' , varAccountHolderName ='" + varAccountHolderName + "', varAccountNo ='" + varAccountNo + "', varIFSCCode ='" + varIFSCCode + "', varMCIRCode ='" + varMCIRCode + "', varBranchAddress ='" + varBranchAddress + "', varBranchName ='" + varBranchName + "', intAccountType =" + intAccountType + ", intIsActive =" + intIsActive + " WHERE intId =" + Id + "", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {

                string strr = s.Message;
                con.Close();
                return 0;
            }
        }

        public int insert_tbldocuments( string varPersonnelId,  string varDescription, string varDocument, string varCreatedDate, string varCreatedBy, int intIsActive, string status)
        {
            try
            {
                //int id = max_tbldocuments();
                //id = id + 1;
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tbldocuments (  varPersonnelId,   varDescription, varDocument, varCreatedDate, varCreatedBy, varStatus, intIsActive, ex1, ex2, ex3, ex4, ex5) VALUES('" + varPersonnelId + "','" + varDescription + "','" + varDocument + "','" + varCreatedDate + "','" + varCreatedBy + "','" + status + "'," + intIsActive + ",'','','','','')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                string exp = s.Message;
                con.Close();
                return 0;
            }

        }
        //account all code 
        public int max_tblamspersonnel()
        {
            int chk = 0;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from tblamspersonnel", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return chk;
        }
        public int max_tblamsdivision()
        {
            int chk = 0;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from tblamsdivision", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return chk;
        }
        public int max_tblamsaccountpersonnel()
        {
            int chk = 0;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from tblamsaccountpersonnel", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return chk;
        }
        public int max_tblamsaccountbook()
        {
            int chk = 0;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from tblamsaccountbook", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return chk;
        }
        public int max_tblamsledger()
        {
            int chk = 0;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from tblamsledger", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chk = Convert.ToInt32(dr["newid"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return chk;
        }


        //...................................Upadate
        public String select_ProfilePic(int id)
        {
            String name = String.Empty;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varPhoto from tblamspersonnel where intId =" + id + " ", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    name = dr["varPhoto"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return name;
        }

        public int update_tblamspersonnel(string id, string rname, string mob, string landline, string address, string email, string pass, string file)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamspersonnel SET varName = '" + rname + "',varMobile = '" + mob + "', varAddress= '" + address + "', varPhone='" + landline + "', varEmail='" + email + "',varPassword='" + pass + "', varPhoto='" + file + "' WHERE intId = " + id + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int Update_tblamsdivision(int id, string dId, string dname, string dwork)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsdivision SET varDivisionId = '" + dId + "',varDivisionName = '" + dname + "', varDivisionWork= '" + dwork + "' WHERE intId = " + id + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int Update_tblamsaccountpersonnel(int id, string name, string mb, string ph, string email, string address)
        {
            try
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsaccountpersonnel SET varAccountName = '" + name + "',varMobile = '" + mb + "', varPhone= '" + ph + "' ,varEmail ='" + email + "' ,varAddress ='" + address + "' WHERE intId = " + id + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        // txtDateJ.Text, arry[1].ToString(), arry[0].ToString(), txtVoucherNoJ.Text, txtReasonJ.Text, txtAmountJ.Text, "Credit", Session["vibhag"].ToString());
        public int Update_tblamsaccountbook(int kirdid, string amount, string date, string aname, string aid, string voucher, string reason, string transactionType, string divId, string previousBalance, string previousmount)
        {
            try
            {
                double difference = 0;
                double newbalance = 0;

                string entries = string.Empty;
                string changeEntries = string.Empty;

                if (transactionType == "Credit")
                {
                    difference = Convert.ToDouble(amount) - Convert.ToDouble(previousmount);
                    newbalance = Convert.ToDouble(previousBalance) + Convert.ToDouble(amount);


                    con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsaccountbook SET varAmount='" + amount + "', varBalance=" + newbalance + ",varAccountName = '" + aname + "',varDate = '" + date + "', varAccountNo= '" + aid + "' ,varVoucher ='" + voucher + "' ,varReason ='" + reason + "' WHERE varAccountBookEntry = " + kirdid + "", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsledger SET varDebitAmount=" + amount + " , varAccountName = '" + aname + "',varDate = '" + date + "', varAccountNo= '" + aid + "'   WHERE varAccountBookEntry = " + kirdid + "", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    con.Close();
                    MySql.Data.MySqlClient.MySqlCommand cmdkk = new MySql.Data.MySqlClient.MySqlCommand("SELECT varAccountBookEntry FROM tblamsaccountbook WHERE varDate>='" + date + "' and  varDivisionId='" + divId + "' ORDER BY tblamsaccountbook.varDate ASC", con);
                    con.Open();
                    dr = cmdkk.ExecuteReader();
                    while (dr.Read())
                    {
                        entries = entries + dr["varAccountBookEntry"].ToString() + ";";
                    }
                    con.Close();
                    int ss = 0;
                    string[] Kird = entries.Split(';');
                    for (int i = 0; i < Kird.Length - 1; i++)
                    {
                        if (Convert.ToInt32(Kird[i].ToString()) == kirdid)
                        {
                            ss = 1;
                        }
                        if (ss == 1)
                        {
                            if (Convert.ToInt32(Kird[i].ToString()) == kirdid)
                            { }
                            else
                            {
                                changeEntries = changeEntries + Kird[i].ToString() + ";";
                            }
                        }
                    }
                    Array.Clear(Kird, 0, Kird.Length);
                    Kird = changeEntries.Split(';');
                    for (int i = 0; i < Kird.Length - 1; i++)
                    {

                        con2.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmdccj = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsaccountbook SET varBalance= varBalance+" + difference + ",PreviousBalance=PreviousBalance+" + difference + "  WHERE  varAccountBookEntry=" + Convert.ToInt32(Kird[i].ToString()) + "", con2);
                        cmdccj.ExecuteNonQuery();
                        con2.Close();

                    }
                }
                else
                {
                    difference = Convert.ToDouble(amount) - Convert.ToDouble(previousmount);
                    newbalance = Convert.ToDouble(previousBalance) - Convert.ToDouble(amount);


                    con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsaccountbook SET varAmount='" + amount + "',  varBalance=" + newbalance + ", varAccountName = '" + aname + "',varDate = '" + date + "', varAccountNo= '" + aid + "' ,varVoucher ='" + voucher + "' ,varReason ='" + reason + "' WHERE varAccountBookEntry = " + kirdid + "", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsledger SET varCreditAmount=" + amount + " , varAccountName = '" + aname + "',varDate = '" + date + "', varAccountNo= '" + aid + "'   WHERE varAccountBookEntry = " + kirdid + "", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();



                    con.Close();
                    MySql.Data.MySqlClient.MySqlCommand cmdkk = new MySql.Data.MySqlClient.MySqlCommand("SELECT varAccountBookEntry FROM tblamsaccountbook WHERE varDate>='" + date + "' and  varDivisionId='" + divId + "' ORDER BY tblamsaccountbook.varDate ASC", con);
                    con.Open();
                    dr = cmdkk.ExecuteReader();
                    while (dr.Read())
                    {
                        entries = entries + dr["varAccountBookEntry"].ToString() + ";";
                    }
                    con.Close();
                    int ss = 0;
                    string[] Kird = entries.Split(';');
                    for (int i = 0; i < Kird.Length - 1; i++)
                    {
                        if (Convert.ToInt32(Kird[i].ToString()) == kirdid)
                        {
                            ss = 1;
                        }
                        if (ss == 1)
                        {
                            if (Convert.ToInt32(Kird[i].ToString()) == kirdid)
                            { }
                            else
                            {
                                changeEntries = changeEntries + Kird[i].ToString() + ";";
                            }
                        }
                    }
                    Array.Clear(Kird, 0, Kird.Length);
                    Kird = changeEntries.Split(';');
                    for (int i = 0; i < Kird.Length - 1; i++)
                    {
                        con2.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmdccj = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsaccountbook SET varBalance= varBalance-" + difference + ",PreviousBalance=PreviousBalance-" + difference + " WHERE  varAccountBookEntry=" + Convert.ToInt32(Kird[i].ToString()) + "", con2);
                        cmdccj.ExecuteNonQuery();
                        con2.Close();
                    }

                }

                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int delete_tblamsaccountbook(int kirdid, string amount, string date, string aname, string aid, string voucher, string reason, string transactionType, string divId, string previousBalance, string previousmount)
        {
            try
            {

                string entries = string.Empty;
                string changeEntries = string.Empty;

                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmdkk = new MySql.Data.MySqlClient.MySqlCommand("SELECT varAccountBookEntry FROM tblamsaccountbook WHERE varDate>='" + date + "' and  varDivisionId='" + divId + "' ORDER BY tblamsaccountbook.varDate ASC", con);
                con.Open();
                dr = cmdkk.ExecuteReader();
                while (dr.Read())
                {
                    entries = entries + dr["varAccountBookEntry"].ToString() + ";";
                }
                con.Close();
                int ss = 0;
                string[] Kird = entries.Split(';');
                for (int i = 0; i < Kird.Length - 1; i++)
                {
                    if (Convert.ToInt32(Kird[i].ToString()) == kirdid)
                    {
                        ss = 1;
                    }
                    if (ss == 1)
                    {
                        if (Convert.ToInt32(Kird[i].ToString()) == kirdid)
                        { }
                        else
                        {
                            changeEntries = changeEntries + Kird[i].ToString() + ";";
                        }
                    }
                }
                Array.Clear(Kird, 0, Kird.Length);
                Kird = changeEntries.Split(';');
                for (int i = 0; i < Kird.Length - 1; i++)
                {
                    if (transactionType == "Credit")
                    {
                        con2.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmdccj = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsaccountbook SET varBalance= varBalance-" + amount + ",PreviousBalance=PreviousBalance-" + amount + " WHERE  varAccountBookEntry=" + Convert.ToInt32(Kird[i].ToString()) + "", con2);
                        cmdccj.ExecuteNonQuery();
                        con2.Close();
                    }
                    else
                    {
                        con2.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmdccj = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsaccountbook SET varBalance= varBalance+" + amount + ",PreviousBalance=PreviousBalance+" + amount + " WHERE  varAccountBookEntry=" + Convert.ToInt32(Kird[i].ToString()) + "", con2);
                        cmdccj.ExecuteNonQuery();
                        con2.Close();
                    }
                }
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("DELETE from tblamsaccountbook WHERE varAccountBookEntry = " + kirdid + "", con);
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("DELETE from tblamsledger WHERE varAccountBookEntry = " + kirdid + "", con);
                cmd1.ExecuteNonQuery();
                con.Close();

                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }

        ///.................................Insert ......................
        public int insert_tblamsdivision(string dId, string dname, string dwork, string amount)
        {
            try
            {
                int id = max_tblamsdivision();
                id = id + 1;
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamsdivision VALUES(" + id + ",N'" + dId + "',N'" + dname + "',N'" + dwork + "',N'',N'',N'')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();


                int ida = max_tblamsaccountbook();
                ida = ida + 1;
                int accentryId = max_tblamsaccountbook();
                accentryId = accentryId + 1;
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamsaccountbook VALUES(" + ida + ",N'" + Convert.ToString(accentryId) + "',N'0001-01-01',N'" + dId + "',N'" + dname + "',N'0',N'NA',N'New Division Added',N'Credit',N'" + amount + "',N'0',N'" + amount + "',N'',N'')", con);

                cmda.ExecuteNonQuery();
                con.Close();


                int lid = max_tblamsledger();
                lid = lid + 1;

                con.Open();
                MySql.Data.MySqlClient.MySqlCommand lcmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamsledger VALUES(" + lid + ",N'0001-01-01',N'" + dname + "',N'" + 0 + "',N'New Division Added',N'" + Convert.ToString(accentryId) + "',N'" + amount + "',N'0',N'Credit',N'" + dId + "',N'',N'',N'')", con);

                lcmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();

                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }

        // txtDateJ.Text, txtAccountNameJ.Text, txtLedgerNoJ.Text, txtVoucherNoJ.Text, txtReasonJ.Text, txtAmountJ.Text);
        public int insert_tblamsaccountbookJama(string datej, string namej, string LedgerNoJ, string VoucherNoJ, string ReasonJ, string AmountJ, string type, string did, string balance, string divname)
        {
            try
            {
                string pAmt = string.Empty;
                if (Convert.ToDateTime(datej) < Convert.ToDateTime(DateTime.UtcNow.ToString("yyyy-MM-dd")))
                {
                    con1.Close();
                    MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT varDate FROM tblamsaccountbook WHERE varDivisionId='" + did + "' and varDate<='" + datej + "' order by varDate desc LIMIT 1", con1);
                    con1.Open();
                    dr = cmds.ExecuteReader();
                    if (dr.Read())
                    {

                        con2.Close();
                        MySql.Data.MySqlClient.MySqlCommand cmdss = new MySql.Data.MySqlClient.MySqlCommand("SELECT varBalance as amount FROM tblamsaccountbook WHERE varDate='" + Convert.ToDateTime(dr["varDate"].ToString()).ToString("yyyy-MM-dd") + "' and   varDivisionId='" + did + "' order by intId desc LIMIT 1", con2);
                        con2.Open();
                        dr1 = cmdss.ExecuteReader();
                        if (dr1.Read())
                        {
                            pAmt = dr1["amount"].ToString();
                        }
                        con2.Close();
                    }
                }
                else
                {
                    con1.Close();
                    MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT varDate FROM tblamsaccountbook WHERE varDivisionId='" + did + "' order by varDate desc LIMIT 1", con1);
                    con1.Open();
                    dr = cmds.ExecuteReader();
                    if (dr.Read())
                    {

                        con2.Close();
                        MySql.Data.MySqlClient.MySqlCommand cmdss = new MySql.Data.MySqlClient.MySqlCommand("SELECT varBalance as amount FROM tblamsaccountbook WHERE varDate='" + Convert.ToDateTime(dr["varDate"].ToString()).ToString("yyyy-MM-dd") + "' and   varDivisionId='" + did + "' order by intId desc LIMIT 1", con2);
                        con2.Open();
                        dr1 = cmdss.ExecuteReader();
                        if (dr1.Read())
                        {
                            pAmt = dr1["amount"].ToString();
                        }
                        con2.Close();
                    }

                    con1.Close();
                }
                int id = max_tblamsaccountbook();
                id = id + 1;
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamsaccountbook VALUES(" + id + ",N'" + Convert.ToString(id) + "',N'" + datej + "',N'" + did + "',N'" + namej + "',N'" + LedgerNoJ + "',N'" + VoucherNoJ + "',N'" + ReasonJ + "',N'" + type + "',N'" + AmountJ + "',N'" + pAmt + "',N'" + balance + "',N'',N'')", con);

                cmd.ExecuteNonQuery();
                con.Close();


                int lid = max_tblamsledger();
                lid = lid + 1;

                con.Open();
                MySql.Data.MySqlClient.MySqlCommand lcmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamsledger VALUES(" + lid + ",N'" + datej + "',N'" + namej + "',N'" + LedgerNoJ + "',N'" + ReasonJ + "',N'" + Convert.ToString(id) + "',N'" + AmountJ + "',N'0',N'" + type + "',N'" + did + "',N'',N'',N'')", con);

                lcmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();

                if (Convert.ToDateTime(datej) < Convert.ToDateTime(DateTime.UtcNow.ToString("yyyy-MM-dd")))
                {
                    string entries = string.Empty;
                    MySql.Data.MySqlClient.MySqlCommand cmdkk = new MySql.Data.MySqlClient.MySqlCommand(" SELECT varAccountBookEntry FROM tblamsaccountbook WHERE  varDate>'" + datej + "'  and  varDivisionId='" + did + "' and varAccountName!='" + divname + "'", con);
                    con.Open();
                    dr = cmdkk.ExecuteReader();
                    while (dr.Read())
                    {
                        entries = entries + dr["varAccountBookEntry"].ToString() + ";";
                    }
                    con.Close();

                    string[] Kird = entries.Split(';');
                    for (int i = 0; i < Kird.Length - 1; i++)
                    {   // for jama
                        con2.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmdccj = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsaccountbook SET varBalance= varBalance+" + AmountJ + ",PreviousBalance= PreviousBalance+" + AmountJ + " WHERE  varAccountBookEntry=" + Convert.ToInt32(Kird[i].ToString()) + "", con2);
                        cmdccj.ExecuteNonQuery();
                        con2.Close();
                    }
                }
                return 1;
            }
            catch (Exception s)
            {
                con2.Close();
                con.Close();
                return 0;
            }
        }
        public int insert_tblamsaccountbookNave(string daten, string namen, string LedgerNon, string VoucherNon, string Reasonn, string Amountn, string typen, string didn, string balance)
        {
            try
            {
                string pAmt = string.Empty;
                if (Convert.ToDateTime(daten) < Convert.ToDateTime(DateTime.UtcNow.ToString("yyyy-MM-dd")))
                {
                    con1.Close();
                    MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT varDate FROM tblamsaccountbook WHERE varDivisionId='" + didn + "' and varDate<='" + daten + "' order by varDate desc LIMIT 1", con1);
                    con1.Open();
                    dr = cmds.ExecuteReader();
                    if (dr.Read())
                    {

                        con2.Close();
                        MySql.Data.MySqlClient.MySqlCommand cmdss = new MySql.Data.MySqlClient.MySqlCommand("SELECT varBalance as amount FROM tblamsaccountbook WHERE varDate='" + Convert.ToDateTime(dr["varDate"].ToString()).ToString("yyyy-MM-dd") + "' and   varDivisionId='" + didn + "' order by intId desc LIMIT 1", con2);
                        con2.Open();
                        dr1 = cmdss.ExecuteReader();
                        if (dr1.Read())
                        {
                            pAmt = dr1["amount"].ToString();
                        }
                        con2.Close();
                    }
                }
                else
                {
                    con1.Close();
                    MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT varDate FROM tblamsaccountbook WHERE varDivisionId='" + didn + "' order by varDate desc LIMIT 1", con1);
                    con1.Open();
                    dr = cmds.ExecuteReader();
                    if (dr.Read())
                    {

                        con2.Close();
                        MySql.Data.MySqlClient.MySqlCommand cmdss = new MySql.Data.MySqlClient.MySqlCommand("SELECT varBalance as amount FROM tblamsaccountbook WHERE varDate='" + Convert.ToDateTime(dr["varDate"].ToString()).ToString("yyyy-MM-dd") + "' and   varDivisionId='" + didn + "' order by intId desc LIMIT 1", con2);
                        con2.Open();
                        dr1 = cmdss.ExecuteReader();
                        if (dr1.Read())
                        {
                            pAmt = dr1["amount"].ToString();
                        }
                        con2.Close();
                    }

                    con1.Close();
                }

                int id = max_tblamsaccountbook();
                id = id + 1;
                int accentryId = max_tblamsaccountbook();
                accentryId = accentryId + 1;
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamsaccountbook VALUES(" + id + ",N'" + Convert.ToString(accentryId) + "',N'" + daten + "',N'" + didn + "',N'" + namen + "',N'" + LedgerNon + "',N'" + VoucherNon + "',N'" + Reasonn + "',N'" + typen + "',N'" + Amountn + "',N'" + pAmt + "',N'" + (Convert.ToDouble(balance) - Convert.ToDouble(Amountn)).ToString() + "',N'',N'')", con);

                cmd.ExecuteNonQuery();
                con.Close();

                int lid = max_tblamsledger();
                lid = lid + 1;

                con.Open();
                MySql.Data.MySqlClient.MySqlCommand lcmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamsledger VALUES(" + id + ",N'" + daten + "',N'" + namen + "',N'" + LedgerNon + "',N'" + Reasonn + "',N'" + Convert.ToString(accentryId) + "',N'0',N'" + Amountn + "',N'" + typen + "',N'" + didn + "',N'',N'',N'')", con);

                lcmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();

                if (Convert.ToDateTime(daten) < Convert.ToDateTime(DateTime.UtcNow.ToString("yyyy-MM-dd")))
                {
                    string entries = string.Empty;
                    MySql.Data.MySqlClient.MySqlCommand cmdkk = new MySql.Data.MySqlClient.MySqlCommand(" SELECT varAccountBookEntry FROM tblamsaccountbook WHERE  varDate>'" + daten + "'  and  varDivisionId='" + didn + "'", con);
                    con.Open();
                    dr = cmdkk.ExecuteReader();
                    while (dr.Read())
                    {
                        entries = entries + dr["varAccountBookEntry"].ToString() + ";";
                    }
                    con.Close();

                    string[] Kird = entries.Split(';');
                    for (int i = 0; i < Kird.Length - 1; i++)
                    {   // for jama
                        con2.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmdccj = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamsaccountbook SET varBalance= varBalance-" + Amountn + ",PreviousBalance= PreviousBalance-" + Amountn + " WHERE  varAccountBookEntry=" + Convert.ToInt32(Kird[i].ToString()) + "", con2);
                        cmdccj.ExecuteNonQuery();
                        con2.Close();
                    }
                }

                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }
        public int insert_tblamsaccountpersonnel(string accId, string aname, string amb, string aphone, string aemail, string address)
        {
            try
            {
                con.Close();
                int id = max_tblamsaccountpersonnel();
                id = id + 1;
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamsaccountpersonnel VALUES(" + id + ",N'" + accId + "',N'" + aname + "',N'" + amb + "',N'" + aphone + "',N'" + aemail + "',N'" + address + "',N'',N'',N'',N'')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception s)
            {
                con.Close();
                return 0;
            }
        }

        public string getVibhagName(string id)
        {

            string vname = string.Empty;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select  varDivisionName as newid from tblamsdivision where varDivisionId='" + id + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    vname = dr["newid"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return vname;

        }
        public string getVibhagid(string name)
        {

            string id = string.Empty;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varDivisionId  as newid from tblamsdivision where varDivisionName='" + name + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id = (dr["newid"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return id;

        }
        public string getAccoutID(string name)
        {

            string id = string.Empty;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intId  as newid from tblamsaccountpersonnel where varAccountName='" + name + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id = (dr["newid"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return id;

        }
        public string getAmountFromLedger(string id)
        {

            string amt = string.Empty;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT(SUM(varDebitAmount)-SUM(varCreditAmount)) as amount FROM tblamsledger WHERE varDivisionId='" + id + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["amount"].ToString() == "")
                    {
                        amt = 0.ToString();
                    }
                    else
                    {
                        amt = dr["amount"].ToString();
                    }
                }
                else
                {
                    amt = 0.ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return amt;

        }
        public string getTotalDebitAmountFromLedger(string datetoday)
        {

            string amt = string.Empty;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT(SUM(varDebitAmount)) as amount FROM tblamsledger where varDate='" + datetoday + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["amount"].ToString() == "")
                    {
                        amt = 0.ToString();
                    }
                    else
                    {
                        amt = dr["amount"].ToString();
                    }
                }
                else
                {
                    amt = 0.ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return amt;

        }
        public string getTotalCreditAmountFromLedger(string datetoday)
        {

            string amt = string.Empty;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUM(varCreditAmount) as amount FROM tblamsledger where varDate='" + datetoday + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["amount"].ToString() == "")
                    {
                        amt = 0.ToString();
                    }
                    else
                    {
                        amt = dr["amount"].ToString();
                    }
                }
                else
                {
                    amt = 0.ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return amt;

        }
        public string getTotalDebitAmountFromLedgerRemaining()
        {

            string amt = string.Empty;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT(SUM(varDebitAmount)-SUM(varCreditAmount)) as amount FROM tblamsledger ", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["amount"].ToString() == "")
                    {
                        amt = 0.ToString();
                    }
                    else
                    {
                        amt = dr["amount"].ToString();
                    }
                }
                else
                {
                    amt = 0.ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return amt;

        }

        public string getAmount(string dates, string where, string divId)
        {

            string amt = string.Empty;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varBalance as amount FROM tblamsaccountbook WHERE varDate='" + dates + "' and varDivisionId='" + divId + "' order by intId  " + where + " LIMIT 1", con1);
                con1.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["amount"].ToString() == "")
                    {
                        amt = 0.ToString();
                    }
                    else
                    {
                        amt = dr["amount"].ToString();
                    }
                }
                else
                {
                    // amt = 0.ToString();
                    if (where == "asc")
                    {
                        where = "desc";
                        con1.Close();
                        MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT varBalance as amount FROM tblamsaccountbook WHERE  varDivisionId='" + divId + "' and varDate<='" + dates + "' order by varDate desc,intId " + where + " LIMIT 1", con1);
                        con1.Open();
                        dr = cmds.ExecuteReader();
                        if (dr.Read())
                        {
                            if (dr["amount"].ToString() == "")
                            {
                                amt = 0.ToString();
                            }
                            else
                            {
                                amt = dr["amount"].ToString();
                            }
                        }

                        con1.Close();
                    }
                    else
                    {
                        where = "desc";
                        con1.Close();
                        MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT varBalance as amount FROM tblamsaccountbook WHERE  varDivisionId='" + divId + "' and varDate<='" + dates + "' order by varDate desc,intId  " + where + " LIMIT 1", con1);
                        con1.Open();
                        dr = cmds.ExecuteReader();
                        if (dr.Read())
                        {
                            if (dr["amount"].ToString() == "")
                            {
                                amt = 0.ToString();
                            }
                            else
                            {
                                amt = dr["amount"].ToString();
                            }
                        }

                        con1.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            con1.Close();
            return amt;

        }

        public string getFirstAmount(string dates, string where, string divId)
        {
            string amt = string.Empty;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT PreviousBalance as amount FROM tblamsaccountbook WHERE varDate='" + dates + "' and varDivisionId='" + divId + "' order by intId " + where + " LIMIT 1", con1);
                con1.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["amount"].ToString() == "")
                    {
                        amt = 0.ToString();
                    }
                    else
                    {
                        amt = dr["amount"].ToString();
                    }
                }
                else
                {
                    if (Convert.ToDateTime(dates) < Convert.ToDateTime(DateTime.UtcNow.ToString("yyyy-MM-dd")))
                    {
                        if (where == "asc")
                        {
                            where = "desc";
                            con1.Close();
                            MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT PreviousBalance as amount FROM tblamsaccountbook WHERE  varDivisionId='" + divId + "' and varDate<'" + dates + "' order by intId " + where + " LIMIT 1", con1);
                            con1.Open();
                            dr = cmds.ExecuteReader();
                            if (dr.Read())
                            {
                                if (dr["amount"].ToString() == "")
                                {
                                    amt = 0.ToString();
                                }
                                else
                                {
                                    amt = dr["amount"].ToString();
                                }
                            }

                            con1.Close();
                        }
                        else
                        {
                            where = "desc";
                            con1.Close();
                            MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT PreviousBalance as amount FROM tblamsaccountbook WHERE  varDivisionId='" + divId + "' and varDate<'" + dates + "' order by intId " + where + " LIMIT 1", con1);
                            con1.Open();
                            dr = cmds.ExecuteReader();
                            if (dr.Read())
                            {
                                if (dr["amount"].ToString() == "")
                                {
                                    amt = 0.ToString();
                                }
                                else
                                {
                                    amt = dr["amount"].ToString();
                                }
                            }

                            con1.Close();
                        }
                    }
                    else
                    {
                        if (where == "asc")
                        {
                            where = "desc";
                            con1.Close();
                            MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT varBalance as amount FROM tblamsaccountbook WHERE  varDivisionId='" + divId + "' and varDate<'" + dates + "' order by intId " + where + " LIMIT 1", con1);
                            con1.Open();
                            dr = cmds.ExecuteReader();
                            if (dr.Read())
                            {
                                if (dr["amount"].ToString() == "")
                                {
                                    amt = 0.ToString();
                                }
                                else
                                {
                                    amt = dr["amount"].ToString();
                                }
                            }

                            con1.Close();
                        }
                        else
                        {
                            where = "desc";
                            con1.Close();
                            MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT varBalance as amount FROM tblamsaccountbook WHERE  varDivisionId='" + divId + "' and varDate<'" + dates + "' order by intId " + where + " LIMIT 1", con1);
                            con1.Open();
                            dr = cmds.ExecuteReader();
                            if (dr.Read())
                            {
                                if (dr["amount"].ToString() == "")
                                {
                                    amt = 0.ToString();
                                }
                                else
                                {
                                    amt = dr["amount"].ToString();
                                }
                            }

                            con1.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            con1.Close();
            return amt;

        }
        public string getFirstAmountTerij(string dates, string where, string divId)
        {
            string amt = string.Empty;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT PreviousBalance as amount FROM tblamsaccountbook WHERE varDate='" + dates + "' and varDivisionId='" + divId + "' order by varDate  " + where + " LIMIT 1", con1);
                con1.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["amount"].ToString() == "")
                    {
                        amt = 0.ToString();
                    }
                    else
                    {
                        amt = dr["amount"].ToString();
                    }
                }
                else
                {

                    if (where == "asc")
                    {
                        where = "desc";
                        con1.Close();
                        MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT varBalance as amount FROM tblamsaccountbook WHERE  varDivisionId='" + divId + "' and varDate<'" + dates + "' order by varDate desc,intId " + where + " LIMIT 1", con1);
                        con1.Open();
                        dr = cmds.ExecuteReader();
                        if (dr.Read())
                        {
                            if (dr["amount"].ToString() == "")
                            {
                                amt = 0.ToString();
                            }
                            else
                            {
                                amt = dr["amount"].ToString();
                            }
                        }

                        con1.Close();
                    }
                    else
                    {
                        where = "desc";
                        con1.Close();
                        MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT varBalance as amount FROM tblamsaccountbook WHERE  varDivisionId='" + divId + "' and varDate<'" + dates + "' order by varDate desc,intId " + where + " LIMIT 1", con1);
                        con1.Open();
                        dr = cmds.ExecuteReader();
                        if (dr.Read())
                        {
                            if (dr["amount"].ToString() == "")
                            {
                                amt = 0.ToString();
                            }
                            else
                            {
                                amt = dr["amount"].ToString();
                            }
                        }

                        con1.Close();
                    }

                }
            }
            catch (Exception ex)
            {

            }
            con1.Close();
            return amt;
        }
        public string getInsertAccountDetails()
        {

            string amt = string.Empty;
            try
            {
                con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varDivisionName, varDivisionId, varAccountNo, varAccountName FROM tblbankaccountforsolar WHERE 1", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    amt = dr["varDivisionId"].ToString() + "_" + dr["varDivisionName"].ToString() + "_" + dr["varAccountNo"].ToString() + "_" + dr["varAccountName"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                amt = string.Empty;
            }
            con.Close();
            return amt;
        }

    }

}