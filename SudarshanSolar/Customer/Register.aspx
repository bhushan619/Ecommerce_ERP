<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/OutsideMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SudarshanSolar.Customer.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    	<section class="page_breadcrumbs ds ms parallax section_padding_bottom_30">
				<div class="container">
					<div class="row">
						<div class="col-sm-12 text-center">
							<div class="breadcrumbs_logo">
								<img src="../Content/o/images/logo.png" alt="">
							</div>
							<h1 class="highlight bold">Registration</h1>
							<ol class="breadcrumb">
								<li>
									<a href="Default.aspx">
										HomePage
									</a>
								</li>
								
								<li class="active">Registration</li>
							</ol>
						</div>
					</div>
				</div>
			</section>


			<section class="ls ms section_padding_top_100 section_padding_bottom_100">
				<div class="container">

					<div class="row">

						<div class="shop-register" >
                              <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
							<div class="col-sm-6">
								<div class="form-group validate-required" id="billing_first_name_field">
									<label for="billing_first_name" class="control-label">
										<span class="grey">Full Name </span>
										<span class="required">*</span>
									</label>
  <asp:TextBox ID="txtFullname" required="required" CssClass="form-control" data-style="mb:7" placeholder="Full Name" runat="server"></asp:TextBox>
  	</div>
<div class="form-group validate-required validate-email" id="billing_email_field">
									<label for="billing_email" class="control-label">
										<span class="grey">Email Address/Username </span>
										<span class="required">*</span>
									</label>
 <asp:TextBox ID="txtEmail" required="required" CssClass="form-control" data-style="mb:7" placeholder="E-mail/Username"   pattern="[a-z0-9!#$%&'*+/=?^_{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)"  runat="server"></asp:TextBox>
  
								</div>
							
							</div>

							<div class="col-sm-6">
								<div class="form-group validate-required" id="billing_last_name_field">
									<label for="billing_last_name" class="control-label">
										<span class="grey">Mobile </span>
										<span class="required">*</span>
									</label>
    <asp:TextBox required="required" ID="txtMobile"  CssClass="form-control"  data-style="mb:7" runat="server" placeholder="Mobile"></asp:TextBox>
       
								</div>

								<div class="form-group address-field validate-required" id="billing_address_fields">
									<label for="billing_address_1" class="control-label">
										<span class="grey">Address </span>
										<span class="required">*</span>
									</label>
   <asp:TextBox ID="txtAddress" required="required"  CssClass="form-control"  data-style="mb:7" runat="server" placeholder="Address"></asp:TextBox>
       
								</div>

							</div>

	

							<div class="col-sm-6">
                                	<div class="form-group">
									<label for="billing_state" class="control-label">
										<span class="grey">State/Province </span>
										<span class="required">*</span>
									</label>

									<asp:DropDownList ID="cmbstate" runat="server" required="required"
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
							


								<div class="form-group" id="billing_password_field">
									<label for="billing_password" class="control-label">
										<span class="grey">Password</span>
										<span class="required">*</span>
									</label>
 <asp:TextBox ID="txtsPassword" required="required" TextMode="Password"  CssClass="form-control" data-style="mb:7" placeholder="Password" runat="server"></asp:TextBox>
  
								</div>


						
							</div>

							<div class="col-sm-6">

							<div class="form-group address-field validate-required" id="billing_city_field">
									<label for="billing_city" class="control-label">
										<span class="grey">Town / City </span>
										<span class="required">*</span>
									</label>

									    <asp:DropDownList ID="cmbcity" runat="server"    class="form-control"  required="required">
                                <asp:ListItem>--Select City--</asp:ListItem>
                                </asp:DropDownList>    
								</div>

                             

								<div class="form-group" id="billing_password2_field">
									<label for="billing_password2" class="control-label">
										<span class="grey">Confirm Password</span>
										<span class="required">*</span>
									</label>  <asp:TextBox ID="txtConfirmpassword" required="required" TextMode="Password"  CssClass="form-control"  data-style="mb:7" runat="server" placeholder="Confirm password"></asp:TextBox>
        
								</div>


							</div>

							<div class="col-sm-12">
                                 <a href="Register.aspx" class="theme_button wide_button" ID ="btnBack" >     Clear Form</a>

                                        <asp:Button runat="server" CssClass="theme_button wide_button color1" ID="btnAdd" Text="Register Now" OnClick="btnAdd_Click" />     
                                


							</div>

						</div>


					</div>
				</div>
			</section>

</asp:Content>
