<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.EditCustomer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       <div class="page animsition">
   <div class="page-content">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">Edit Customer</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                               <div class="row">
                                      <ul class="nav nav-tabs">
                                <li class="active"><a href="EditCustomer.aspx"  >Update Main Details</a>
                                </li>
                                <li class=""><a href="EditCustomerOther.aspx"  >Update Other Details</a>
                                </li> 
                                  <li class=""><a href="EditCustomerTaxDetails.aspx"  >Update Transaction Details</a>
                                </li> 
                            </ul>
  <br />
                              <div class="tab-content">
                                <div class="tab-pane fade active in" > 
                                       <div class="col-md-6  col-sm-6">
                                         
                                <div class="form-group">
                                            <label>Company  Name</label>
                                           <asp:TextBox ID="txtCmpName" runat="server" class="form-control" 
                                                placeholder="Company Name"  ></asp:TextBox>
                                           
                                        </div>
                                <div class="form-group">
                                            <label>Representative  Name</label>
                                           <asp:TextBox ID="txtRepName" runat="server" class="form-control" 
                                                placeholder="Representative Name"  ></asp:TextBox>
                                          
                                        </div>
                                        <div class="form-group">
                                            <label>Mobile</label>
                                           <asp:TextBox ID="txtMobile" runat="server" class="form-control" 
                                                placeholder="Mobile"  pattern="[7-9]{1}[0-9]{9}"   ></asp:TextBox>
                                          
                                        </div>
                                         <div class="form-group">
                                            <label>Landline</label>
                                           <asp:TextBox ID="txtLandline" runat="server" class="form-control" 
                                                placeholder="Landline"  onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"   ></asp:TextBox>
                                          
                                        </div>
                                         <%--     <div class="form-group">
                                            <label>Email</label>
                                            <asp:TextBox ID="txtMail"  
                             pattern="[a-z0-9!#$%&'*+/=?^_{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)" 
                             runat="server" placeholder="Email Address" Required  class="form-control" 
                           ></asp:TextBox>
                                          
                                        </div>  
                                         
                               <div class="form-group">
                                            <label>Password</label>
                            <asp:TextBox ID="txtPasswd" runat="server"  placeholder="Password" 
                             TextMode="Password"  required="required" class="form-control" 
                           ></asp:TextBox>
                           </div> --%>                
                                       
                            <div class="form-group">
                                   <label>Address</label>
                                     <asp:TextBox ID="txtADD" runat="server" TextMode="MultiLine" 
                                       class="form-control" placeholder="Address"   ></asp:TextBox>
                            </div>   
                         
                          <div class="form-group">
                             <label>State </label>
                                <asp:DropDownList ID="cmbstate" runat="server" 
                        onselectedindexchanged="state_SelectedIndexChanged" AutoPostBack="True" 
                         CssClass="form-control">
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
                                <asp:DropDownList ID="cmbcity" runat="server"    class="form-control" >
                                <asp:ListItem>--Select City--</asp:ListItem>
                                </asp:DropDownList>
                            </div> 
                       
                            </div>  
                         <div class="col-md-6  col-sm-6">
                     <div class="form-group">
                                           <label>Date of Establishment</label>                            
                                <asp:TextBox ID="txtDOET" runat="server"  class="form-control" placeholder="Date of Establishment"></asp:TextBox>
                                        <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOET_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDOET"  
                                    PopupPosition="Right" >
                                </cc1:CalendarExtender>
                                         
                                    </div>
                      <div class="form-group">
                                            <label>Pan No.</label>
                                            <asp:TextBox ID="txtPAN" runat="server" class="form-control" placeholder="Pan No."></asp:TextBox>
                                            
                                        </div>             
                                <div class="form-group">
                                            <label>VAT No.</label>
                                            <asp:TextBox ID="txtVat" runat="server" class="form-control" placeholder="VAT No."></asp:TextBox>
                                            
                                        </div>
                                        <div class="form-group">
                                            <label>TIN No.</label>
                                                 <%-- <input class="form-control" type="text">--%>
                                            <asp:TextBox ID="txtTincard" runat="server" class="form-control" 
                                                placeholder="Tin Card No."  ></asp:TextBox>
                                           
                                        </div>
                                   <div class="form-group">
                      <asp:Label ID="Label7" runat="server" Text="Image Upload"  ></asp:Label>
                        <div class="">
                            <div class="fileupload fileupload-new" data-provides="fileupload"> 
                                <div>
                                    <span class="btn btn-file btn-success">
                                  
                                <input ID="fupProPic" type="file" name="file" onchange="previewFile()"  runat="server" accept='image/*' /></span>
                                   <br />  <br />
                                      <asp:Image ID="ImgCust" CssClass="fileupload-preview thumbnail" style="width: 200px; height: 150px;float:none"  runat="server" ImageUrl="~/media/Customer/NoProfile.png" />
                                <script type="text/javascript">
                                    function previewFile() {

                                        var preview = document.querySelector('#<%=ImgCust.ClientID %>');
                                        var file = document.querySelector('#<%=fupProPic.ClientID %>').files[0];
                                        var reader = new FileReader();

                                        reader.onloadend = function () {
                                            preview.src = reader.result;
                                        }

                                        if (file) {
                                            reader.readAsDataURL(file);
                                        } else {
                                            preview.src = "";
                                        }
                                    } 
                              </script>  
                                </div>
                            </div>
                        </div>
                    </div>
                                             <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                            <div class="form-group">
                               <asp:Button ID="btnUpdate"  runat="server" Text="Update" class="btn btn-warning" OnClientClick="return Confirm();"  onclick="btnUpdate_Click" 
                                                  />
                                                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                                  class="btn btn-danger " onclick="btnCancel_Click" />
                                        </div> 
                                   
                        </div>
                                </div>
                                <div class="tab-pane fade" >
                            </div>
                                </div> 
                               </div> 
                     
                   </div>
              
          </div>
   </div>
</div>          
</asp:Content>


