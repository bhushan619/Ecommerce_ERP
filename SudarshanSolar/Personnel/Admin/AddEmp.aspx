<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddEmp.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.AddEmp" %>
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
                      <h3 class="panel-title">Add Employee</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                               <div class="row">
                                       <div class="col-md-6  col-sm-6">
                                <div class="form-group">
                                           <asp:Label runat="server"> Name</asp:Label>
                                           <asp:TextBox ID="txtEmpName" runat="server" class="form-control" 
                                                  ></asp:TextBox>                                           
                                        </div>                                
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                           <asp:Label runat="server">Mobile</asp:Label>
                                           <asp:TextBox ID="txtMobile" runat="server" class="form-control" 
                                                pattern="[7-9]{1}[0-9]{9}"  ></asp:TextBox>                                          
                                        </div>

                                      <div class="form-group">
                                           <asp:Label runat="server">Date Of Birth</asp:Label>
                                            <asp:TextBox ID="txtDob" runat="server"   class="form-control" ></asp:TextBox>
                                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDob"  
                                    PopupPosition="Right" >
                                </cc1:CalendarExtender>
                                            
                                        </div>                    
                            <div class="form-group">
                                  <asp:Label runat="server">Address</asp:Label>
                                     <asp:TextBox ID="txtADD" runat="server" 
                                       class="form-control"    ></asp:TextBox>
                            </div>
                                 <div class="form-group">
                            <asp:Label runat="server">State </asp:Label>
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
                                  <asp:Label runat="server">City</asp:Label>
                                <asp:DropDownList ID="cmbcity" runat="server"    class="form-control" >
                                <asp:ListItem>--Select City--</asp:ListItem>
                                </asp:DropDownList> 
                                </div>
                                <div class="form-group">
                                  <asp:Label runat="server"> Designation</asp:Label>
                                <asp:DropDownList ID="cmbSubDesig" runat="server"    class="form-control" >
                                <asp:ListItem>--Select Designation--</asp:ListItem>
                                <asp:ListItem>Sub Admin</asp:ListItem>
                                <asp:ListItem>Marketing</asp:ListItem>                                
                                    <asp:ListItem>Clerk</asp:ListItem>
                                 <%--  <asp:ListItem>Marketing Executive</asp:ListItem>   <asp:ListItem>Inventory</asp:ListItem> 
                                    <asp:ListItem>Production</asp:ListItem>--%>
                                </asp:DropDownList> 
                                </div>
                                    <div class="form-group">
                                           <asp:Label runat="server">Email</asp:Label>
                                            <asp:TextBox ID="txtMail"  
                             pattern="[a-z0-9!#$%&'*+/=?^_{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)" 
                             runat="server"  Required  class="form-control" 
                           ></asp:TextBox>
                                          
                                        </div>  
                                   
                            
                            </div>  
                         <div class="col-md-6  col-sm-6">
                       
                   
                                         
                               <div class="form-group">
                                           <asp:Label runat="server">Password</asp:Label>
                            <asp:TextBox ID="txtPasswd" runat="server"  
                             TextMode="Password"  required="required" class="form-control" 
                           ></asp:TextBox>
                           </div> 
                                <div class="form-group">
                                           <asp:Label runat="server">ID Proof</asp:Label>
                                            <asp:TextBox ID="txtIdproof" runat="server" class="form-control" ></asp:TextBox>
                                            
                                        </div>
                                        <div class="form-group">
                                           <asp:Label runat="server">ID Proof No.</asp:Label>
                                                 <%-- <input class="form-control" type="text">--%>
                                            <asp:TextBox ID="txtIdproofNo" runat="server" class="form-control" 
                                                  ></asp:TextBox>
                                           
                                        </div>
                                          <div class="form-group">
                                           <asp:Label runat="server">Pan No.</asp:Label>
                                            <asp:TextBox ID="txtPAN" runat="server" class="form-control" ></asp:TextBox>
                                            
                                        </div>
                                        <div class="form-group">
                      <asp:Label ID="Label7" runat="server" Text="Image Upload"  ></asp:Label>
                        <div class="">
                            <div class="fileupload fileupload-new" data-provides="fileupload"> 
                                <div>
                                    <span class="btn btn-file btn-success">
                                   <%-- <span class="fileupload-new">Select image</span>--%>
                                <input ID="fupProPic" type="file" name="file" onchange="previewFile()"  runat="server" accept='image/*' /></span>
                                    <br /> <br />
                                     <asp:Image ID="ImgProduct" CssClass="fileupload-preview thumbnail" style="width: 200px; height: 150px;float:none"  runat="server" ImageUrl="~/Media/Employee/NoProfile.png" />
                                <script type="text/javascript">
                                    function previewFile() {

                                        var preview = document.querySelector('#<%=ImgProduct.ClientID %>');
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
                              &nbsp;&nbsp;&nbsp; <asp:LinkButton ID="btnAdd"  runat="server" 
                                                    Text="Add" CssClass="btn btn-success" OnClick="btnAdd_Click"  
                                                  />
                                                &nbsp;<asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" 
                                                  CssClass="btn btn-danger " OnClick="btnCancel_Click" />
                                           </div> 
                            </div> 
                               </div> 
                     
                   </div>
              
          </div>
   </div>
</div>          
</asp:Content>
