<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/OutsideMaster.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="SudarshanSolar.Customer.MyProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <section class="page_breadcrumbs ds ms parallax section_padding_bottom_30">
				<div class="container">
					<div class="row">
						<div class="col-sm-12 text-center">
							<div class="breadcrumbs_logo">
								<img src="../Content/o/images/logo.png" alt="">
							</div>
							<h1 class="highlight bold">Profile</h1>
							<ol class="breadcrumb">
								<li>
									<a href="Dashboard.aspx">
										HomePage
									</a>
								</li>
								
								<li class="active">Edit Profile</li>
							</ol>
						</div>
					</div>
				</div>
			</section>

    <section class="ls ms   columns_padding_25">
				<div class="container">
                    <div class="row">
      <div class="col-md-12">          <div class="form-group"> 
                                   
                                   <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                    </div>
                               <div class="col-md-6  col-sm-6">
                                  <div class="form-group">
                                            <label>Full  Name</label>
                                           <asp:TextBox ID="txtRepName" runat="server" class="form-control" 
                                                placeholder="Representative Name"  ></asp:TextBox>
                                          
                                        </div>
                                          <div class="form-group">                       
                                <label >Company Name</label>                         
                                <asp:TextBox required="required" ID="txtCmpName" CssClass="form-control" data-style="mb:7" runat="server" placeholder="Company Name"></asp:TextBox>
                                              </div>
                           
                                                                 <div class="form-group">
            <label for="subject" accesskey="S">E-mail/Username</label>
           <asp:TextBox ID="txtEmail" required="required" CssClass="form-control" data-style="mb:7" Enabled="false"   pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)"  runat="server"></asp:TextBox>
  
          </div>
                                
                                        <div class="form-group">
                                            <label>Mobile</label>
                                           <asp:TextBox ID="txtMobile" runat="server" class="form-control" 
                                                placeholder="Mobile"  ></asp:TextBox>
                                          
                                        </div>
                                    <div class="form-group">
                                            <label>Landline</label>
                                           <asp:TextBox ID="txtLandline" runat="server" class="form-control" 
                                                placeholder="Landline"  onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"   ></asp:TextBox>
                                          
                                        </div>
                                       
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
                     
                             <div class ="form-group ">
                                    <label for="focusedinput" class="col-sm-3   control-label">Profile Photo</label>
                                    	<div class="col-sm-8">
                <input ID="fupProPic" type="file" name="file" onchange="previewFile1()"  runat="server" accept='image/*' />
                                 <br />    <asp:Image ID="ImgCust" CssClass="fileupload-preview thumbnail" style="width: 200px; height: 150px;float:none"  runat="server" ImageUrl="~/admin/media/NoProfile.png" />
                                <script type="text/javascript">
                                    function previewFile1() {

                                        var preview1 = document.querySelector('#<%=ImgCust.ClientID %>');
                                        var file1 = document.querySelector('#<%=fupProPic.ClientID %>').files[0];
                                        var reader1 = new FileReader();

                                        reader1.onloadend = function () {
                                            preview1.src = reader1.result;
                                        }

                                        if (file1) {
                                            reader1.readAsDataURL(file1);
                                        } else {
                                            preview1.src = "";
                                        }
                                    } 
                              </script> 
                                            </div> 
                     </div>
                              
                               
                                            <div class="form-group pull-right">
                              &nbsp;&nbsp;&nbsp; <asp:Button ID="btnUpdate"   runat="server" Text="Update" CssClass="theme_button color1" onclick="btnUpdate_Click" 
                                                  />
                                                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                                  CssClass="theme_button " onclick="btnCancel_Click" />
                                        </div> 
                             </div> 
      </div>
    </div>
                    </div>
        </section>
</asp:Content>
