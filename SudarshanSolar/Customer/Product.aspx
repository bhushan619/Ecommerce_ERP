<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/OutsideMaster.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="SudarshanSolar.Customer.Product" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Personnel/Usercontrol/SimilarProduct.ascx" TagPrefix="uc1" TagName="SimilarProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <section class="page_breadcrumbs ds ms parallax section_padding_bottom_30">
				<div class="container">
					<div class="row">
						<div class="col-sm-12 text-center">
							<div class="breadcrumbs_logo">
								<img src="../Content/o/images/logo.png" alt="">
							</div>
							<h1 class="highlight bold">Single Product</h1>
							<ol class="breadcrumb">
								<li>
									<a href="Default.aspx">
										HomePage
									</a>
								</li>
								<li>
									<a href="ShopProduct.aspx">Shop</a>
								</li>
								<li class="active">Single Product</li>
							</ol>
						</div>
					</div>
				</div>
			</section>

    <section class="ls ms  section_padding_bottom_75 columns_padding_25">
				<div class="container">
                        <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
					<div class="row">
                        <asp:ListView ID="lstProduct" OnItemCommand="lstProduct_ItemCommand" DataSourceID="SqlDataSourceProduct" runat="server" DataKeyNames="intId">

                                    <EmptyDataTemplate>
                                        <table id="Table1" runat="server" style="width: 90%" cssclass="table table-bordered table-hover">
                                            <tr>
                                                <td>
                                                    <div class="alert alert-dismissable alert-info " style="width: 100%">
                                                        <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                <ItemTemplate>
						<div class="col-sm-7 col-md-8 col-lg-8">


							<div itemscope=""  class="product type-product row">
                                 
								<div class="images col-sm-6">

 <asp:HyperLink runat="server"  NavigateUrl='<%#"~/Media/Product/"+ Eval("imgImage") %>' itemprop="image" CssClass="main-image zoom" title="" data-gal="prettyPhoto[product-gallery]">

										<span class="onsale">Sale</span>

										<span class="newproduct">New</span>
                                           <asp:Image CssClass="attachment-shop_single wp-post-image" Width="400px"  Height="300px" ImageUrl='<%#"~/Media/Product/"+ Eval("imgImage") %>' runat="server" ID="gallaryImageLabel" />
            
										
									</asp:HyperLink>						
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div id="product-thumbnails" class="owl-carousel thumbnails product-thumbnails" data-loop="true" data-center="true" data-margin="10" data-nav="false" data-dots="true" data-items="3" data-responsive-lg="3" data-responsive-md="3" data-responsive-sm="2"
													data-responsive-xs="2">  
                                <asp:ListView ID="lstGallary" runat="server" DataSourceID="SqlDataSourceGallary" DataKeyNames="id">

                                    <EmptyDataTemplate>
                                        <table id="Table1" runat="server" style="width: 90%" cssclass="table table-bordered table-hover">
                                            <tr>
                                                <td>
                                                    <div class="alert alert-dismissable alert-info " style="width: 100%">
                                                        <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>


                                    <ItemTemplate>		
                                       
                                        	 <asp:HyperLink runat="server" CssClass="icon md-search" NavigateUrl='<%#"~/Media/Product/"+ Eval("file") %>' class="zoom first" title="" data-gal="prettyPhoto[product-gallery]">
										
                                                  <asp:Image class="attachment-shop_thumbnail" ImageUrl='<%#"~/Media/Product/"+ Eval("file") %>' runat="server" ID="gallaryImageLabel" />
            
										</asp:HyperLink>                                    

									
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <div runat="server" id="itemPlaceholder" />

                                    </LayoutTemplate>
                                </asp:ListView>
</div>
                                <asp:SqlDataSource runat="server" ID="SqlDataSourceGallary" 
                                    ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' 
                                    SelectCommand="SELECT        tblproductgallary.file, tblproductgallary.id   FROM tblsuproducts INNER JOIN   tblproductgallary ON tblsuproducts.intId = tblproductgallary.intProductId  WHERE  tblsuproducts.intId  = @ProductId"
                                    ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>'>
                                    <SelectParameters>
                                        <asp:ControlParameter Name="ProductId" ControlID="lblProductId" PropertyName="Text" Type="String" ConvertEmptyStringToNull="true" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                          													
								</div>
								<!-- eof .images -->

								<div class="summary entry-summary col-sm-6">

 
                                
                                        
                                        	<h1 itemprop="name" class="product_title entry-title"> <asp:Label Text='<%# Eval("varProductName") %>' runat="server" ID="varProductNameLabel" />
                                             <asp:Localize Text='<%# Eval("intId") %>' runat="server" ID="lblProductId" Visible="false" />
                                                           </h1>
									<div class="product_meta">
										<span class="posted_in">
											<span class="grey">Categories:</span>
											<span class="categories-links">
												<a rel="category" href="#" class="theme_button small_button color1">  <asp:Label Text='<%# Eval("varTypeName") %>' CssClass="" runat="server" ID="varTypeNameLabel" />
                                                 </a>
												<a rel="category" href="#" class="theme_button small_button color1"> <asp:Label Text='<%# Eval("varSubTypeName") %>' runat="server" ID="varSubTypeNameLabel" />
                                                    </a>
											</span>
										</span>
									</div>

									<div itemprop="offers" itemscope="" itemtype="">

										<div itemprop="description">
										  <asp:Label Text='<%# Eval("varShortDesc") %>' runat="server" ID="varShortDescLabel" /><br />

										</div>

										<ul class="list1 no-bullets">
											<li>
												<p class="price">
														<ins>
														<span class="amount"> <i  class="fa fa-rupee"></i> <asp:Label Text='<%# Eval("intMRP") %>'  runat="server" ID="intMRPLabel" />
                                                            </span>
													</ins>
												</p>

												<meta itemprop="price" content="2">

												<meta itemprop="priceCurrency" content="USD">

                                                </li>
										</ul>

										<div class="cart" >
									
											<span class="product-option-name grey">Additional Comment</span>

											<asp:TextBox runat="server" ID="txtAdditionalComments" CssClass="form-control" TextMode="MultiLine" rows="3"></asp:TextBox>
											<p>Maximum number of characters:
												<span id="char_left">500</span>
											</p>

											<div class="pull-right">
												<asp:LinkButton runat="server" CommandArgument='<%# Eval("intId") %>' CommandName="AddToCart" ID="btnAddToCart" rel="nofollow" CssClass="theme_button color1 add_to_cart_button">
													<i class="rt-icon2-basket"></i>
													Add to cart
												</asp:LinkButton>
											</div>

											<label class="grey" for="product_quantity">Qty:</label>
<asp:DropDownList ID="ddlQty" runat="server" CssClass="quantity form-group">
    <asp:ListItem Value="1">1</asp:ListItem>
     <asp:ListItem Value="2">2</asp:ListItem>
     <asp:ListItem Value="3">3</asp:ListItem>
     <asp:ListItem Value="4">4</asp:ListItem>
     <asp:ListItem Value="5">5</asp:ListItem>
 
</asp:DropDownList>
											
</div>
									</div>

                                  
								</div>
								<!-- .summary.col- -->

							</div>
							<!-- .product.row -->


							<!-- Nav tabs -->
							<ul class="nav nav-tabs" role="tablist">
								<li class="active">
									<a href="product.aspx#details_tab" role="tab" data-toggle="tab">Details</a>
								</li>
								<li>
									<a href="product.aspx#additional_tab" role="tab" data-toggle="tab">Additional </a>
								</li>
								
							</ul>

							<!-- Tab panes -->
							<div class="tab-content top-color-border bottommargin_30">

								<div class="tab-pane fade in active" id="details_tab">

									<h3>Product Description:</h3>								

									<div class="well">
										 <asp:Label Text='<%# Eval("varShortDesc") %>' runat="server" ID="Label1" /><br />

									</div>


								</div>

								<div class="tab-pane fade  " id="additional_tab">
                                    <h3>Product Specification</h3>
                                <asp:ListView ID="lstVariation" runat="server" DataSourceID="SqlDataSourceVariation" DataKeyNames="intId">

                                    <EmptyDataTemplate>
                                        <table id="Table1" runat="server" style="width: 90%" cssclass="table table-bordered table-hover">
                                            <tr>
                                                <td>
                                                    <div class="alert alert-dismissable alert-info " style="width: 100%">
                                                        <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>

                                    <ItemTemplate>
                                        <tr>
											<th class="grey">   <asp:Label Text='<%# Eval("varVariation") %>' runat="server" ID="Label2" />
                                         :</th>
											<td> <asp:Label Text='<%# Eval("varVariationValue") %>' runat="server" ID="Label4" /></td>
                                   <asp:Label Text='<%# Eval("intId") %>' runat="server" ID="intIdLabel" Visible="false" />
                                        </td> 
										</tr>
                                    
                                    </ItemTemplate>
                                    <LayoutTemplate>

                                        <table runat="server" id="itemPlaceholderContainer"  class="table table-striped topmargin_30">
                                          
                                            <tr runat="server" id="itemPlaceholder"></tr>
                                        </table>
                                        
                                    </LayoutTemplate>

                                </asp:ListView>

                                <asp:SqlDataSource runat="server" ID="SqlDataSourceVariation"
                                     ConnectionString='<%$ ConnectionStrings:solarConnectionString %>'
                                     ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>'
                                    SelectCommand = "SELECT        tblsuproducts.intId, tblproductvariation.varVariation, tblvariation.varVariationValue  FROM tblsuproducts INNER JOIN    tblvariation ON tblsuproducts.intId = tblvariation.intProductId INNER JOIN    tblproductvariation ON tblvariation.intVariationId = tblproductvariation.intId     WHERE  tblsuproducts.intId=@ProductId">
                                       <SelectParameters>
                                        <asp:ControlParameter Name="ProductId" ControlID="lblProductId" PropertyName="Text" Type="String" ConvertEmptyStringToNull="true" />
                                    </SelectParameters>
                                </asp:SqlDataSource>

								</div>

							</div>
							<!-- eof .tab-content -->


						</div>
                                      </ItemTemplate>
                                    <LayoutTemplate>
                                        <div runat="server" id="itemPlaceholderContainer" style="">
                                            <div runat="server" id="itemPlaceholder" />
                                        </div>
                                        <div style="">
                                        </div>

                                    </LayoutTemplate>

                                </asp:ListView>
                                <asp:SqlDataSource runat="server" ID="SqlDataSourceProduct" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>'></asp:SqlDataSource>

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
