<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/OutsideMaster.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="SudarshanSolar.Customer.Cart" %>

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
							<h1 class="highlight bold">Cart</h1>
							<ol class="breadcrumb">
								<li>
									<a href="Default.aspx">
										HomePage
									</a>
								</li>
								<li>
									<a href="ShopProduct.aspx">Shop Porduct</a>
								</li>
								<li class="active">Cart</li>
							</ol>
						</div>
					</div>
				</div>
			</section>

    <section class="ls ms   columns_padding_25">
				<div class="container">

					<div class="row">

						<div class="col-sm-12 col-md-12 col-lg-12">
                            
                   <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
                       </div>
							<div class="table-responsive table">
                                	<asp:SqlDataSource runat="server" ID="SqlDataSourceCart" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>' ></asp:SqlDataSource>

<asp:ListView ID="lstcart" OnItemCommand="lstcart_ItemCommand" runat="server"  >
    

<EmptyDataTemplate>
<table runat="server" style="">
<tr>
<td><div class="alert alert-dismissable alert-info "  style="width:100%" >
						                                                <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
					                                                </div></td>
</tr>
</table>
</EmptyDataTemplate>

<ItemTemplate>
    	<tr class="cart_item">
            <td>
                 <asp:Label ID="lblSRNO" runat="server"  Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
											</td>
											<td class="product-info">
                                                    	<div class="media">
													<div class="media-left">
							
                                                            <asp:HyperLink runat="server"  NavigateUrl='<%#"~/Media/Product/"+ Eval("imgImage") %>' itemprop="image" CssClass="main-image zoom" data-gal="prettyPhoto[product-gallery]">

                                                          <asp:Image CssClass="media-object cart-product-image img-thumbnail" Width="150px"  Height="80px" ImageUrl='<%#"~/Media/Product/"+ Eval("imgImage") %>' runat="server" ID="gallaryImageLabel" />
            
															
														</asp:HyperLink>
													</div>
													<div class="media-body">
														<h4 class="media-heading">
														 <asp:LinkButton   ID="A1" runat="server"  CommandArgument='<%# Eval("intId") %>' CommandName="View">
                                                             <asp:Label Text='<%# Eval("varProductName") %>' runat="server" id="Label1"/>
                                                             </asp:LinkButton>
														</h4>
														<span class="grey">Category:</span> <asp:Label Text='<%# Eval("varTypeName") %>' CssClass="" runat="server" ID="varTypeNameLabel" />
													
													</div>
												</div>
											</td>
											<td class="">
											<i class="fa  fa-rupee"></i><asp:Label Text='<%# Eval("intMRP") %>' runat="server" id="Label2"/>
									
												</td>
											<td class="product-quantity">
												<div class="quantity">
												<asp:Label Text='<%# Eval("cacheValueQty") %>' runat="server" id="Label3"/>
												</div>
											</td>
												<td class="product-quantity">
												<div class="quantity">
												<i class="fa  fa-rupee"></i><asp:Label Text='<%# Eval("Total") %>' runat="server" id="Label4"/>
												</div>
											</td>
											<td  >
                                                <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Deletes" CommandArgument='<%# Eval("intId")  %>'
                                             CssClass="fontsize_24" ToolTip="Remove this item"  >	<i class="rt-icon2-trash"></i></asp:LinkButton>
                       
												
											</td>
										</tr>

</ItemTemplate>
<LayoutTemplate>
 
    <table runat="server" ID="itemPlaceholderContainer" class="table cart-table" >
      <tr>
              <td>SrNo</td>     
        <td>Product Name</td>     
<td>MRP</td>
        <td>Quantity</td>
            <td>Total</td>
     <td >Delete</td>
    
</tr>
<tr runat="server" ID="itemPlaceholder"></tr>
</table>
 
</LayoutTemplate>

</asp:ListView>
							</div>

							<div class="cart-buttons">
 <asp:LinkButton  runat="server" CssClass="theme_button" ID ="btnBack" Text="Countinue Shopping" OnClick="btnBack_Click" />  
  
			<asp:Button ID="btnadd" runat="server" Text="Proceed to Checkout" CssClass="theme_button color1" OnClick="btnAdd_Click"></asp:Button>				
 <%-- <a data-toggle="collapse" href="cart.aspx#registeredForm1" aria-expanded="false" aria-controls="registeredForm1">Click here to proceed</a>--%>
							     
							</div>
						</div>
						<!--eof .col-sm-8 (main content)-->

					
					</div>
				</div>
			</section>
    <%--id="registeredForm1"--%>
    <div class=" ls ms  columns_padding_25" runat="server" id="registeredForm1" visible="false">
        <div class="container">

            <div class="row">

                <div class="col-sm-6 col-md-7 col-lg-7">
                    <div runat="server" id="divloginForm">
                        <div class="shop-info">
                            Returning customer?
								           
                            <a data-toggle="collapse" href="cart.aspx#registeredForm" aria-expanded="false" aria-controls="registeredForm">Click here to login</a>
                        </div>

                        <div class="collapse" id="registeredForm">
                            <div class="checkout with_border with_padding form-horizontal" role="form">
                                <p>If you have shopped with us before, please enter your details in the boxes below. If you are a new customer please proceed to the Billing &amp; Shipping section.</p>

                                <div class="form-group">
                                    <label for="username" class="col-sm-3 control-label">
                                        <span class="grey">Nick or email</span>
                                        <span class="required">*</span>
                                    </label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtuser" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="password" class="col-sm-3 control-label">
                                        <span class="grey">Password</span>
                                        <span class="required">*</span>
                                    </label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtpass" CssClass="form-control" TextMode="Password" data-style="mb:7" runat="server" placeholder="Password"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-9">
                                        <div class="checkbox">
                                            <label for="rememberme" class="control-label">
                                                <input name="rememberme" type="checkbox" id="rememberme" value="forever">
                                                Remember me
											
                                            </label>
                                        </div>
                                        <asp:LinkButton runat="server" class="theme_button color1 topmargin_20" ID="btnlogin" OnClick="btnlogin_Click" data-style="mt:15">
Login</asp:LinkButton>

                                        <div class="lost_password">
                                            <a href="../RetrievePassword.aspx">Lost your password?</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h2>Billing Address</h2>

                    <asp:Panel CssClass="form-horizontal checkout shop-checkout" runat="server" ID="mydetails">

                        <div class="form-group validate-required">
                            <label for="billing_first_name" class="col-sm-3 control-label">
                                <span class="grey">Full Name </span>
                                <span class="required">*</span>
                            </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtFullname" required="required" CssClass="form-control" data-style="mb:7" placeholder="Full Name" runat="server"></asp:TextBox>

                            </div>
                        </div>


                        <div class="form-group">
                            <label for="billing_company" class="col-sm-3 control-label">
                                <span class="grey">Mobile</span>
                                <span class="required">*</span>
                            </label>
                            <div class="col-sm-9">
                                <asp:TextBox required="required" ID="txtMobile" CssClass="form-control" data-style="mb:7" runat="server" placeholder="Mobile Number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="billing_company" class="col-sm-3 control-label">
                                <span class="grey">Company Name</span>
                            </label>
                            <div class="col-sm-9">
                                <asp:TextBox required="required" ID="txtCompanyname" CssClass="form-control" data-style="mb:7" runat="server" placeholder="Company Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group address-field validate-required">
                            <label for="billing_address_1" class="col-sm-3 control-label">
                                <span class="grey">State </span>
                                <span class="required">*</span>
                            </label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="cmbstate" runat="server" required="required"
                                    OnSelectedIndexChanged="state_SelectedIndexChanged" AutoPostBack="True"
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
                        </div>

                        <div class="form-group address-field validate-required">
                            <label for="billing_city" class="col-sm-3 control-label">
                                <span class="grey">Town / City </span>
                                <span class="required">*</span>
                            </label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="cmbcity" runat="server" class="form-control" required="required">
                                    <asp:ListItem>--Select City--</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group address-field validate-state">
                            <label for="billing_state" class="col-sm-3 control-label">
                                <span class="grey">Address</span>
                                <span class="required">*</span>
                            </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtAddress" required="required" CssClass="form-control" data-style="mb:7" runat="server" placeholder="Full Address"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group validate-required validate-email">
                            <label for="billing_email" class="col-sm-3 control-label">
                                <span class="grey">Email/Username </span>
                                <span class="required">*</span>
                            </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtEmail" required="required" CssClass="form-control" data-style="mb:7" placeholder="E-mail/Username" pattern="[a-z0-9!#$%&'*+/=?^_{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group validate-required validate-phone">
                            <label for="billing_phone" class="col-sm-3 control-label">
                                <span class="grey">Password </span>
                                <span class="required">*</span>
                            </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtsPassword" required="required" TextMode="Password" CssClass="form-control" data-style="mb:7" placeholder="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group validate-required validate-phone">
                            <label for="billing_phone" class="col-sm-3 control-label">
                                <span class="grey">Confirm Password </span>
                                <span class="required">*</span>
                            </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtConfirmpassword" required="required" TextMode="Password" CssClass="form-control" data-style="mb:7" runat="server" placeholder="Confirm password"></asp:TextBox>
                            </div>
                        </div>


                    </asp:Panel>

            
                <!--eof .col-sm-8 (main content)-->
                    </div>
                <!-- sidebar -->
                <aside class="col-sm-6 col-md-5 col-lg-5 ">
                            <div style="padding-top:40px">
							<h3 class="widget-title" id="order_review_heading">Your Cart Totals</h3>
							<div class="cart-collaterals ">
								<div class="cart_totals">
									
									<table class="table">
										<tbody>
											<tr class="cart-subtotal">
												<td>Cart Subtotal</td>
												<td>
													<span class="currencies"><i class="fa  fa-rupee "></i></span>
													<span class="amount"><asp:Label ID="lblSubtotal" runat="server" Text=""></asp:Label></span>
												</td>
											</tr>
											<tr class="shipping">
												<td>Shipping and Handling</td>
												<td>
													Free Shipping
												</td>
											</tr>
											<tr class="order-total">
												<td class="grey">Order Total</td>
												<td>
													<strong class="grey">
														<span class="currencies"><i class="fa  fa-rupee "></i></span>
														<span class="amount"><asp:Label ID="lblFinalTotal" runat="server" Text=""></asp:Label></span>
													</strong>
												</td>
											</tr>
										</tbody>
									</table>
                                    <div class="place-order">
                                         <div class="form-group">
                                         <label for="comments" ><span class="required">*</span>Special Requests</label>
          <asp:TextBox ID="txtSpecialRequests" TextMode="MultiLine"  CssClass="form-control"  data-style="mb:7" runat="server" placeholder="Special Requests"></asp:TextBox>
                          
                                    </div>
                                    <div class="form-group">
                                         <label for="comments" ><span class="required">*</span>Payment Options</label>
                                        <asp:RadioButton ID="rdbPayFull" Checked="true" AutoPostBack="true" Text="Full Payment" runat="server" GroupName="payment" OnCheckedChanged="rdbPayFull_CheckedChanged" />
                                        <asp:RadioButton ID="rdbAdvanceayment" AutoPostBack="true" Text="Advance Payment(min. Rs. 5000)" GroupName="payment" runat="server"  OnCheckedChanged="rdbPayFull_CheckedChanged" />                 
                                    </div>
                                     <div class="form-group" id="advAmt" runat="server" visible="false">
                                         <label for="comments" ><span class="required">*</span>Advance Amount</label>
          <asp:TextBox ID="txtAdvancePayment" onkeyup="checkNum(this);" OnTextChanged="txtAdvancePayment_TextChanged" AutoPostBack="true"  CssClass="form-control"  data-style="mb:7" runat="server" placeholder="Advance Amount"></asp:TextBox>
                          
                                    </div>
                                          <div class="form-group" id="divMess1" runat="server">                          
                                     <asp:Label id="lblMess1" runat="server" /> 
                                    </div>
                                          <div>
                                          <strong>Payment Details</strong>
                                          <asp:Localize ID="lblAdvOrFull" runat="server" ></asp:Localize>
                                              <strong> <span class="pull-right">INR <asp:Localize ID="lblAdvance" runat="server" ></asp:Localize></span></strong>
                                        </div>
                                    </div>
                                    	<div class="place-order">
                                          <asp:Button runat="server" CssClass="theme_button color1" ID="Button1" Text="Create Account and Place Order" OnClick="btnAddRegister_Click" />     
                             
									    </div>
								</div>
							</div>
                            </div>
						</aside>
                <!-- eof aside sidebar -->

        </div>
    </div>
    </div>
    
</asp:Content>
