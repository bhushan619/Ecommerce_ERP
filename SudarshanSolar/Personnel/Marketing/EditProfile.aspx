<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Marketing.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="SudarshanSolar.Personnel.Marketing.EditProfile" %>

<%@ Register Src="~/Personnel/Usercontrol/EmployeeProfilePhoto.ascx" TagPrefix="uc1" TagName="EmployeeProfilePhoto" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script language="javascript" type="text/javascript">

           function openNewWin(url) {

               var x = window.open(url, 'mynewwin', 'width=600,height=400,left=100, resizable=yes,scrollbars=yes ,menubar=yes');

               x.focus();

           }
           function Confirm() {
               var confirm_value = document.createElement("INPUT");
               confirm_value.type = "hidden";
               confirm_value.name = "confirm_value";
               if (confirm("Are you sure.. You want to Add/Update/Delete ?")) {
                   confirm_value.value = "Yes";
               } else {
                   confirm_value.value = "No";
               }
               document.forms[0].appendChild(confirm_value);
           }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- Page -->
  <div class="page animsition">
    <div class="page-content container-fluid">
      <div class="row">
        <div class="col-md-3">
          <!-- Page Widget -->
          <uc1:EmployeeProfilePhoto runat="server" ID="EmployeeProfilePhoto" />
          <!-- End Page Widget -->
        </div>

        <div class="col-md-9">
          <!-- Panel -->
          <div class="panel">
            <div class="panel-body nav-tabs-animate nav-tabs-horizontal">
              <ul class="nav nav-tabs nav-tabs-line" >
                <li class="active" role="presentation"><a  href="MyProfile.aspx" 
                  role="tab">Profile</a></li>
                <li role="presentation"><a  href="KYCDocument.aspx" >KYC Document</a></li>
                <li role="presentation"><a  href="BankDetails.aspx" 
                  role="tab">Bank Details</a></li>
               
              </ul>

              <div class="tab-content">
                <div class="tab-pane active animation-slide-left" id="activities" role="tabpanel">

               <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
            	<div class="panel-body">
                               <div class="col-md-6  col-sm-6">
                                          <asp:Image ID="imgProPic" Visible="false"  CssClass=" img-thumbnail"  runat="server"></asp:Image>

                               <asp:Label ID="lblCustName" Visible="false" CssClass="inner-text" runat="server" Text="lblCustName"></asp:Label>
                               <div class="form-group">
                                            <label> Name</label>
                                           <asp:TextBox ID="txtCmpName" runat="server" class="form-control empty" 
                                                placeholder="Company Name"  ></asp:TextBox>
                                           
                                        </div>
                                
                                        <div class="form-group">
                                            <label>Mobile</label>
                                           <asp:TextBox ID="txtMobile" runat="server" class="form-control empty" 
                                                placeholder="Mobile"  ></asp:TextBox>
                                          
                                        </div>
                                       
                            <div class="form-group">
                                   <label>Address</label>
                                     <asp:TextBox ID="txtADD" runat="server" TextMode="MultiLine" 
                                       class="form-control empty" placeholder="Address"   ></asp:TextBox>
                            </div>   
                       <div class="form-group">
                                            <label>Pan No.</label>
                                            <asp:TextBox ID="txtPAN" runat="server" class="form-control empty" placeholder="Pan No."></asp:TextBox>
                                            
                                        </div>
                                          <div class="form-group">
                                <label>Date Of Birth</label>
                           <asp:TextBox ID="txtDate" CssClass="form-control empty" runat="server" required placeholder="Select Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDate"  > 
                                </cc1:CalendarExtender>
                            
                            </div>  
                            </div>
                         <div class="col-md-6  col-sm-6">
                       
                          <div class="form-group">
                             <label>State </label>
                                <asp:DropDownList ID="cmbstate" runat="server" 
                        onselectedindexchanged="state_SelectedIndexChanged" AutoPostBack="True" 
                         CssClass="form-control empty">
                        <asp:ListItem>--Select State--</asp:ListItem>
                       <asp:ListItem>Andhra Pradesh</asp:ListItem>
                                    <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                    <asp:ListItem>Assam</asp:ListItem>
                                    <asp:ListItem>Bihar</asp:ListItem>
                                    <asp:ListItem>Chattisgardh</asp:ListItem>
                                    <asp:ListItem>Goa</asp:ListItem>
                                    <asp:ListItem>Gujarat</asp:ListItem>
                                    <asp:ListItem>Haryana</asp:ListItem>
                                    <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                    <asp:ListItem>Jammu and Kashmir</asp:ListItem>
                                    <asp:ListItem>Jharkhand</asp:ListItem>
                                    <asp:ListItem>Karnataka</asp:ListItem>
                                    <asp:ListItem>Kerala</asp:ListItem>
                                    <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                    <asp:ListItem>Maharashtra</asp:ListItem>
                                    <asp:ListItem>Manipur</asp:ListItem>
                                    <asp:ListItem>Meghalaya</asp:ListItem>
                                    <asp:ListItem>Mizoram</asp:ListItem>
                                    <asp:ListItem>Nagaland</asp:ListItem>
                                    <asp:ListItem>Orissa</asp:ListItem>
                                    <asp:ListItem>Punjab</asp:ListItem>
                                    <asp:ListItem>Rajastan</asp:ListItem>
                                    <asp:ListItem>Sikkim</asp:ListItem>
                                    <asp:ListItem>Tamil Nadu</asp:ListItem>
                                    <asp:ListItem>Tripura</asp:ListItem>
                                    <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                    <asp:ListItem>Uttarakhand</asp:ListItem>
                                    <asp:ListItem>West Bengal</asp:ListItem>
                    </asp:DropDownList>
                                </div>   
                         
                            <div class="form-group">
                                   <label>City</label>
                                <asp:DropDownList ID="cmbcity" runat="server"    class="form-control empty" >
                                <asp:ListItem>--Select City--</asp:ListItem>
                                </asp:DropDownList> 
                                </div>
                                <div class="form-group">
                                            <label>ID Proof</label>
                                            <asp:TextBox ID="txtIdproof" runat="server" class="form-control empty" placeholder="ID Proof"></asp:TextBox>
                                            
                                        </div>
                                        <div class="form-group">
                                            <label>ID Proof No.</label>
                                                 <%-- <input class="form-control empty" type="text">--%>
                                            <asp:TextBox ID="txtIdproofNo" runat="server" class="form-control empty" 
                                                placeholder="ID Proof No."  ></asp:TextBox>
                                           
                                        </div>
                             
                         	
									<div class="example example-buttons">
            <button ID="btnUpdate" type="submit"   class="btn btn-warning " runat="server"  onserverclick="btnUpdate_Click" >Update</button>
            
                                               <a  ID="btnCancel"     class="btn btn-danger " href="EditProfile.aspx" >Cancel</a>
          </div>
                              <div class=" form-group">
                                    <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                   </div> 
                            </div> 
                                   
                       
                            </div>       
                       
                </div>

              </div>
            </div>
          </div>
          <!-- End Panel -->
        </div>
      </div>
    </div>
  </div>
  <!-- End Page -->
</asp:Content>
