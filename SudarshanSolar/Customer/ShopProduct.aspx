<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/OutsideMaster.Master" AutoEventWireup="true" CodeBehind="ShopProduct.aspx.cs" Inherits="SudarshanSolar.Customer.ShopProduct" %>

<%@ Register Src="~/Personnel/Usercontrol/SimilarProduct.ascx" TagPrefix="uc1" TagName="SimilarProduct" %>


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
							<h1 class="highlight bold">Shop Product</h1>
							<ol class="breadcrumb">
								<li>
									<a href="Default.aspx">
										HomePage
									</a>
								</li>
								
								<li class="active">Shop</li>
							</ol>
						</div>
					</div>
				</div>
			</section>

    <section class="ls ms  section_padding_bottom_75 columns_padding_25">
				<div class="container">
					<div class="row">

						<div class="col-sm-7 col-md-8 col-lg-8">

							<div class="storefront-sorting muted_background bottommargin_60 clearfix">

								<div class="form-inline">

									<div class="form-group">
										<label class="grey" for="orderby">Sort By:</label>
                                        <asp:DropDownList ID="ddlsortby" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlsortby_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Default</asp:ListItem>
                                            <asp:ListItem Value="1">New</asp:ListItem>
                                            <asp:ListItem Value="2">Low To High</asp:ListItem>
											<asp:ListItem value="3">High To Low</asp:ListItem>
                                        </asp:DropDownList>
										
									</div>

					<div class="form-group">
										

										<a href="shop-right.html#" id="toggle_shop_view" class=""></a>
									</div>

								<%--	<div class="form-group pull-right">

										<label class="grey" for="showcount">Show:</label>


									</div>--%>

								</div>

							</div>


							<div class="columns-2">

								<ul id="products" class="products list-unstyled grid-view">
							<asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>'
                                                     ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>' 
                                                   >

												</asp:SqlDataSource>
                                    <asp:ListView ID="lstProduct" OnItemCommand="lstProduct_ItemCommand"  OnPagePropertiesChanging="OnPagePropertiesChanging" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="intId">



<EmptyDataTemplate>
<table runat="server" style="">
<tr>
<td>   <div class="alert alert-dismissable alert-info "  style="width:100%" >
	 <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
 </div></td>
</tr>
</table>
</EmptyDataTemplate>

<ItemTemplate>
    			
    		<li class="product type-product">
               	
										<div class="side-item">
											<div class="row">
                                               
												<div class="col-md-6">

													<div class="item-media">
														  <asp:LinkButton  ID="lnkProduct" runat="server"  CommandArgument='<%# Eval("intId") %>' CommandName="View">
	
													 	 <asp:Image Width="350px" Height="280px"  ImageUrl='<%#"~/Media/Product/"+ Eval("imgImage") %>' runat="server" ID="gallaryImageLabel" /><br />
															<span class="newproduct">New</span>
														</asp:LinkButton>
														<div class="product-buttons">
															<a href="shop-right.html#" rel="nofollow" class="favorite_button">
																<i class="rt-icon2-heart"></i>
															</a>
															<a href="shop-right.html#" rel="nofollow" class="add_to_cart_button">
																<i class="rt-icon2-basket"></i>
															</a>
														</div>
													</div>
													<h3>
														 <asp:LinkButton   ID="A1" runat="server"  CommandArgument='<%# Eval("intId") %>' CommandName="View">
	             <asp:Localize Text='<%# Eval("varProductName") %>' runat="server" id="varProductNameLabel"/></asp:LinkButton> 
													</h3>

												</div>
                                                   
												<div class="col-md-6">
                                                
													<div class="item-content">
                                                     
														<h3>
														 <asp:LinkButton   ID="LinkButton1" runat="server"  CommandArgument='<%# Eval("intId") %>' CommandName="View">
                             <asp:Localize Text='<%# Eval("varProductName") %>' runat="server" id="Label1"/></asp:LinkButton>
														</h3>

														<h4>Product Description</h4>
														<p class="product-description">
															 <asp:Localize Text='<%# Eval("varShortDesc") %>' runat="server" id="Label2"/>
														</p>

														<h4>Other Details</h4>
														<p class="product-description">
															 <asp:Localize Text='<%# Eval("varLongDesc") %>' runat="server" id="Localize1"/>
														</p>

														<span class="price">
															<span>
																<span class="amount">INR <asp:Localize Text='<%# Eval("intMRP") %>' runat="server" id="intMRPLabel"/></span>
															</span>
														</span>


													</div>

                                            
												</div>

											</div>
										</div>
							</li>
      
                                    </ItemTemplate>
                                <LayoutTemplate>
                                  <div runat="server" id="itemPlaceholder" />
                                     	</ul>
                                          	<div class="row">
								<div class="col-sm-12 text-center">
									<div class="muted_background padding_20">
                                             <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstProduct" PageSize="6" >
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="btn btn-default" ShowFirstPageButton="True" ShowPreviousPageButton="False"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Button"  NumericButtonCssClass="btn btn-default" CurrentPageLabelCssClass="btn btn-warning" />
                        <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="False" ButtonCssClass="btn btn-default" ShowLastPageButton="True" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>
          </div>
                                    </div>
                                                  </div>
                                           
                                    
                                        
                                </LayoutTemplate>

                                </asp:ListView>
								 
							

							</div>
							<!-- eof .columns-* -->


							 


						</div>
						<!--eof .col-sm-8 (main content)-->


						<!-- sidebar -->
						<aside class="col-sm-5 col-md-4 col-lg-4">
                            <div class="with_background with_padding">
                                <uc1:SimilarProduct runat="server" id="SimilarProduct" />
							</div>

						</aside>
						<!-- eof aside sidebar -->


					</div>
				</div>
			</section>
</asp:Content>
