<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="EditEmp.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.EditEmp" %>
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
                      <h3 class="panel-title">Edit Employee Information</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                               <div class="row">
                                  <div class="col-md-6  col-sm-6">
                                <div class="form-group">
                                            <label> Name</label>
                                           <asp:TextBox ID="txtCmpName" runat="server" class="form-control" 
                                                placeholder="Company Name"  ></asp:TextBox>
                                           
                                        </div>
                                
                                        <div class="form-group">
                                            <label>Mobile</label>
                                           <asp:TextBox ID="txtMobile" runat="server" class="form-control" 
                                                placeholder="Mobile"  ></asp:TextBox>
                                          
                                        </div>
                                       
                            <div class="form-group">
                                   <label>Address</label>
                                     <asp:TextBox ID="txtADD" runat="server"  
                                       class="form-control" placeholder="Address"   ></asp:TextBox>
                            </div>      <div class="form-group">
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
                                   <div class="form-group">
                                   <label> Designation</label>
                                <asp:DropDownList ID="cmbSubDesig" runat="server"    class="form-control" >
                               
                                  <asp:ListItem>--Select Designation--</asp:ListItem>
                                <asp:ListItem>Sub Admin</asp:ListItem>
                                <asp:ListItem>Marketing</asp:ListItem>
                                 <asp:ListItem>clerk</asp:ListItem>
                                    <%--  <asp:ListItem>Account</asp:ListItem>
                                  <asp:ListItem>Dispatch</asp:ListItem>
                                    <asp:ListItem>Inventory</asp:ListItem>
                                    <asp:ListItem>Production</asp:ListItem>--%>
                                </asp:DropDownList> 
                                </div>
                                        <div class="form-group">
                                            <label>Date Of Birth</label>
                                            <asp:TextBox ID="txtDob"   runat="server" class="form-control" placeholder="Date Of Birth"></asp:TextBox>
                                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDob"  
                                    PopupPosition="Right" >
                                </cc1:CalendarExtender>
                                            
                                        </div> 
                       
                                <div class="form-group">
                                            <label>ID Proof</label>
                                            <asp:TextBox ID="txtIdproof" runat="server" class="form-control" placeholder="ID Proof"></asp:TextBox>
                                            
                                        </div>
                            </div>  
                       <div class="col-md-6  col-sm-6"> 
                       
                                        <div class="form-group">
                                            <label>ID Proof No.</label>
                                                 <%-- <input class="form-control" type="text">--%>
                                            <asp:TextBox ID="txtIdproofNo" runat="server" class="form-control" 
                                                placeholder="ID Proof No."  ></asp:TextBox>
                                           
                                        </div>
                                          <div class="form-group">
                                            <label>Pan No.</label>
                                            <asp:TextBox ID="txtPAN" runat="server" class="form-control" placeholder="Pan No."></asp:TextBox>
                                            
                                        </div>  
                                    <div class="form-group">
                                            <label>Status</label>
                                          <asp:DropDownList ID="cmbStatus" runat="server"    class="form-control" >
                                <asp:ListItem >--Select Status--</asp:ListItem>
                                 <asp:ListItem >Active</asp:ListItem>
                                              
                                  <asp:ListItem >Inactive</asp:ListItem>
                                </asp:DropDownList> 
                                        </div> 
                                         <div class="form-group">
                      <asp:Label ID="Label7" runat="server" Text="Image Upload"  ></asp:Label>
                        <div class="">
                            <div class="fileupload fileupload-new" data-provides="fileupload"> 
                                <div>
                                    <span class="btn btn-file btn-success">
                                    <%--<span class="fileupload-new">Select image</span>--%>
                                      
                                <input ID="fupProPic" type="file" name="file" onchange="previewFile()"  runat="server" accept='image/*' /></span>
                                     <br /><br />  <asp:Image ID="ImgempPic" CssClass="fileupload-preview thumbnail" style="width: 200px; height: 150px;float:none"  runat="server" ImageUrl="~/Media/Employee/NoProfile.png" />
                                <script type="text/javascript">
                                    function previewFile() {

                                        var preview = document.querySelector('#<%=ImgempPic.ClientID %>');
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
                              
                               <div class="form-group">
                              &nbsp;&nbsp;&nbsp; <asp:LinkButton ID="btnUpdate"  runat="server" Text="Update" class="btn btn-warning" onclick="btnUpdate_Click"  OnClientClick="return Confirm();"
                                                  />
                                                &nbsp;<asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" 
                                                  class="btn btn-danger " onclick="btnCancel_Click" />
                                        </div>
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
</asp:Content>
