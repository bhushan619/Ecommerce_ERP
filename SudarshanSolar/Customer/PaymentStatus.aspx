<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/OutsideMaster.Master" AutoEventWireup="true" CodeBehind="PaymentStatus.aspx.cs" Inherits="SudarshanSolar.Customer.PaymentStatus" %>
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
							<h1 class="highlight bold">Order Status</h1>
							<ol class="breadcrumb">
								<li>
									<a href="Default.aspx">
										HomePage
									</a>
								</li>
								<li>
									<a href="ShopProduct.aspx">Shop Porduct</a>
								</li>
								<li class="active">Order</li>
							</ol>
						</div>
					</div>
				</div>
			</section>
      <section class="ls ms   columns_padding_25">
          			<div class="container ">
				

                		<div class="row">
                             <section  id="contact-form" class="mt50">
					<div class="col-md-12">				
		  
	                        <div class="col-md-4">		
                                 
                              
 <h3 class="lined-heading  "><span> Customer Details</span></h3> 
                       <table class="table table-responsive table-hover table-bordered"> 
                           <tr>
                               <td> <strong> Full Name</strong></td>
                                <td> <asp:Localize ID="txtFullname"  runat="server"></asp:Localize>
  </td>
                           </tr>       
                           <tr>
                               <td><strong>Mobile</strong></td>
                                <td>  <asp:Localize   ID="txtMobile" runat="server"  ></asp:Localize>
        </td>
                           </tr>     
                                            <tr>
                               <td><strong>Company Name</strong></td>
                                <td>  <asp:Localize   ID="txtCompanyname" runat="server"  ></asp:Localize>
        </td>
                           </tr>   
                           <tr>
                               <td><strong>State</strong></td>
                                <td>
                                     <asp:Localize ID="cmbstate"       runat="server"  ></asp:Localize></td>
                           </tr>       
                           <tr>
                               <td><strong>City</strong></td>
                                <td><asp:Localize ID="cmbcity"     runat="server"  ></asp:Localize></td>
                           </tr>       
                           <tr>
                               <td><strong>Address</strong></td>
                                <td> <asp:Localize ID="txtAddress"      runat="server"  ></asp:Localize>
         </td>
                           </tr>    
                           <tr>
                               <td><strong>E-Mail</strong></td>
                                <td> <asp:Localize ID="txtEmail"      runat="server"  ></asp:Localize>
         </td>
                           </tr>    
                          <%--  <tr>
                               <td><strong>Special Requests</strong></td>
                                <td> <asp:Localize ID="lblSpRequest"      runat="server"  ></asp:Localize>
         </td>
                           </tr> --%>         
                           </table>
                                </div>
                                <div class="col-md-8">
                                   
                                    <h3 class="lined-heading"><span> Order Details</span></h3>  
                                 
                                <div class="row">
                                     <asp:ListView ID="lstOrderDetails" runat="server" DataSourceID="SqlDataSourceOrder" DataKeyNames="id">
                                         

<EmptyDataTemplate>
<table runat="server" style="">
<tr>
<td>No data was returned.</td>
</tr>
</table>
</EmptyDataTemplate>

<ItemTemplate>
<tr style="">
<td><asp:Label Text='<%#Container.DataItemIndex+1 %>' runat="server" id="idLabel"/></td>
<td><asp:Label Text='<%# Eval("bookingdate") %>' runat="server" id="bookingdateLabel"/></td>
<td><asp:Label Text='<%# Eval("varProductName") %>' runat="server" id="varProductNameLabel"/></td>
<td><asp:Label Text='<%# Eval("quantity") %>' runat="server" id="quantityLabel"/></td>

<td><i class="fa  fa-rupee"></i> <asp:Label Text='<%# Eval("intMRP") %>' runat="server" id="intMRPLabel"/></td>


</tr>
</ItemTemplate>
<LayoutTemplate>
<table runat="server" ID="itemPlaceholderContainer" class="table-bordered table-responsive">
    <tr runat="server" style="">
        <th runat="server">Id</th>

<th runat="server">Order Date</th>
        <th runat="server">Product Name</th>

<th runat="server">Quantity</th>

<th runat="server">MRP</th>
</tr>
<tr runat="server" ID="itemPlaceholder"></tr>
</table>

</LayoutTemplate>

</asp:ListView>
					           <asp:SqlDataSource runat="server" ID="SqlDataSourceOrder" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>'></asp:SqlDataSource>
</div>
                                      <div class="row col-md-offset-1">
                                          	<asp:LinkButton runat="server" ID="lnkViewInvoice" OnClick="lnkViewInvoice_Click" class="theme_button wide_button color1">View Invoice</asp:LinkButton>
                                      </div>
                                   
                                    </div>
					</div>
                                 </section>
					</div>
                	<div class="row">
                       
                        </div>
			</div>

          </section>
</asp:Content>
