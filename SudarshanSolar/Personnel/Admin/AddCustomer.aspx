<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.AddCustomer" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">Add Customer</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                               <div class="row">
                                      <div class="col-md-6  col-sm-6">
                                <div class="form-group">
                                           <asp:Label runat="server">Company  Name</asp:Label>
                                           <asp:TextBox ID="txtCmpName" runat="server" class="form-control" 
                                                 ></asp:TextBox>
                                           
                                        </div>
                                <div class="form-group">
                                           <asp:Label runat="server">Representative  Name</asp:Label>
                                           <asp:TextBox ID="txtRepName" runat="server" class="form-control" 
                                                  ></asp:TextBox>
                                          
                                        </div>
                                        <div class="form-group">
                                           <asp:Label runat="server">Mobile</asp:Label>
                                           <asp:TextBox ID="txtMobile" runat="server" class="form-control" 
                                              pattern="[7-9]{1}[0-9]{9}"   ></asp:TextBox>
                                          
                                        </div>
                                        <div class="form-group"> 
                                    <asp:TextBox ID="txtLandline" runat="server" class="form-control" 
                                        placeholder="Landline"  pattern="[7-9]{1}[0-9]{9}"   ></asp:TextBox>
                                          
                                </div>
                            <div class="form-group">
                                  <asp:Label runat="server">Address</asp:Label>
                                     <asp:TextBox ID="txtADD" runat="server" 
                                       class="form-control"    ></asp:TextBox>
                            </div>   
                       <div class="form-group">
                            <asp:Label ID="Label1" runat="server">State </asp:Label>
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
                                  <asp:Label ID="Label2" runat="server">City</asp:Label>
                                <asp:DropDownList ID="cmbcity" runat="server"    class="form-control" >
                                <asp:ListItem>--Select City--</asp:ListItem>
                                </asp:DropDownList>
                            </div> 
                            <div class="form-group">
                                          <asp:Label ID="Label5" runat="server">Date of Establishment</asp:Label>                            
                                <asp:TextBox ID="txtDOET" runat="server"  class="form-control" ></asp:TextBox>
                                        <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOET_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDOET"  
                                    PopupPosition="Right" >
                                </cc1:CalendarExtender>                                         
                                    </div>
                            </div>  
                         <div class="col-md-6  col-sm-6">
                           <div class="form-group">
                                           <asp:Label ID="Label3" runat="server">Email</asp:Label>
                                            <asp:TextBox ID="txtMail"  
                             pattern="[a-z0-9!#$%&'*+/=?^_{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)" 
                             runat="server"  Required  class="form-control" 
                           ></asp:TextBox>   
                             
                                        </div> 
                                         
                               <div class="form-group">
                                           <asp:Label ID="Label4" runat="server">Password</asp:Label>
                            <asp:TextBox ID="txtPasswd" runat="server"  
                             TextMode="Password"  required="required" class="form-control" 
                           ></asp:TextBox>
                           </div>
                      <div class="form-group">
                                           <asp:Label runat="server">Pan No.</asp:Label>
                                            <asp:TextBox ID="txtPAN" runat="server" class="form-control" ></asp:TextBox>
                                            
                                        </div>             
                                <div class="form-group">
                                           <asp:Label runat="server">VAT No.</asp:Label>
                                            <asp:TextBox ID="txtVat" runat="server" class="form-control" ></asp:TextBox>
                                            
                                        </div>
                                        <div class="form-group">
                                           <asp:Label runat="server">TIN No.</asp:Label>
                                                 <%-- <input class="form-control" type="text">--%>
                                            <asp:TextBox ID="txtTincard" runat="server" class="form-control" 
                                               ></asp:TextBox>
                                           
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
                                                  <asp:Label ID="lblError" runat="server" Text="Email Already Registered, Please choose another." Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>                                       
                               <asp:LinkButton ID="btnUpdate"  runat="server" Text="Add" class="btn btn-success" onclick="btnUpdate_Click"   OnClientClick="return Confirm();"
                                                  />
                                                &nbsp;<asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                                  class="btn btn-danger " onclick="btnCancel_Click" />
                                        </div> 
                                   
                        </div>
                               </div> 
                     
                   </div>
              
          </div>
   </div>
</div>          
</asp:Content>
