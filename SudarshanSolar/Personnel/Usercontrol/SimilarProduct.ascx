<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SimilarProduct.ascx.cs" Inherits="SudarshanSolar.Personnel.Usercontrol.SimilarProduct" %>

								<div class="widget widget_products widget_popular_entries">
                                     <h3 class="widget-title">Products</h3>  
                                        <ul class="media-list">
<asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSourceSimilarProduct" DataKeyNames="intId">
        
        
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
      
										<li class="media">
											<a class="media-left" href="product-right.html">
										   <asp:Image CssClass="media-object" Height="90px" Width="120px" ImageUrl='<%#"~/Media/Product/"+ Eval("imgImage") %>' runat="server" ID="gallaryImageLabel" />
            

											</a>
											<div class="media-body">
												<h3>
													  <asp:Label Text='<%# Bind("varProductName") %>' runat="server" ID="varProductNameTextBox" />
             
												</h3>

												<div class="" >												
													<span class="grey">Availability:</span> In Stock
												</div>

											

												<span class="price">
													<ins>
														<span class="amount"> <i  class="fa fa-rupee"></i> <asp:Label Text='<%# Eval("intMRP") %>'  runat="server" ID="intMRPLabel" /></span>
													</ins>
												</span>
											</div>
										</li>								

									</ul>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server" style="" border="0">
                <tr runat="server" id="itemPlaceholderContainer">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </table>

            <div style="">
            </div>
        </LayoutTemplate>
        
    </asp:ListView>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceSimilarProduct" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>' SelectCommand="SELECT        tblsuproducts.intId, tblsuproducts.varProductName, tblproducttype.varTypeName, tblproductsubtype.varSubTypeName, tblsuproducts.varproductcode, tblsuproducts.varShortDesc, tblsuproducts.varLongDesc, tblsuproducts.imgImage, tblsuproducts.varStatus, tblsuproducts.varWarning,    tblsuproducts.intPurchasePrice, tblsuproducts.intDealerPrice, tblsuproducts.intMRP, tblsuproducts.intProductTypeId, tblsuproducts.intProductSubTypeId   FROM       tblsuproducts INNER JOIN tblproducttype ON tblsuproducts.intProductTypeId = tblproducttype.intProdTypeId INNER JOIN    tblproductsubtype ON tblsuproducts.intProductSubTypeId = tblproductsubtype.intProdSubTypeId  ORDER BY RAND() LIMIT 0,3;"></asp:SqlDataSource>
   </ul>
									
								</div>
				