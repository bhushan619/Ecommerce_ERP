<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/Admin/Reports/AdminReport.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.Reports.Order" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page animsition">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <div class="page-content">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">View Order</h3>
                     </div>
                  
       
                        <div class="panel-body container-fluid">
                        <div class="row">   
                                  <div class="form-group form-material floating">
                                       <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
                                       </div>
                                       </div>
                              
                            </div>
                               <div class="row">   
                                   <div class="col-lg-12 "> 
                                          <div class="table table-responsive">
                                              
<asp:ListView ID="lstCartAndCustomerDetails" OnItemCommand="lstCartAndCustomerDetails_ItemCommand" runat="server" DataSourceID="SqlDataSourceCartAndCustomerDetails" DataKeyNames="custid,cartid">
    

<EmptyDataTemplate>
<div runat="server" style="">
<div class="alert alert-dismissable alert-info "  style="width:100%" >
						                                                <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
					                                                </div>

</div>
</EmptyDataTemplate>

<ItemTemplate>

  <div class="panel panel-success">
      <div class="panel-heading ">
          <table  class="table table-responsive">
              <tr>
                  <th>ORDER PLACED</th>          
                  <th>ORDER ID</th> 
                  <th>TOTAL</th> 
                 <th>CUSTOMER NAME</th>
                  <th>SHIP TO</th>
                  
              </tr>
              <tr> 
<td><asp:Label Text='<%# Eval("bookingdate") %>' runat="server" id="bookingdateLabel"/></td>
     <%--  cartid   use for order Product Table as control parameter--%>
                          <td><asp:Label Text='<%# Eval("cartid") %>' runat="server" ID="lblCartid"/></td>
 <td><i class="fa  fa-rupee"></i> <asp:Label Text='<%# Eval("total") %>' runat="server" id="Label2"/></td>
                    <td><asp:Label Text='<%# Eval("varRepresentativeName") %>' runat="server" id="varRepresentativeNameLabel"/></td>
                  
    <td><asp:Label Text='<%# Eval("varAddress") %>' runat="server" id="varAddressLabel"/></td>  
                  

              </tr>
          </table>
      </div>
      <div class="panel-body">
          <div class="col-md-8 ">
              <div class="table-responsive">
                            <asp:ListView ID="lstOrderProduct" runat="server" DataSourceID="SqlDataSourceOrderProduct" DataKeyNames="id">
    

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
                                <tr class="">
         	                            <td class="product-info">
                                                    	                            <div class="media">
													                            <div class="media-left">							
                                                                                        <asp:HyperLink runat="server"  NavigateUrl='<%#"~/Media/Product/"+ Eval("imgImage") %>' itemprop="image" CssClass="main-image zoom" data-gal="prettyPhoto[product-gallery]">

                                                                                      <asp:Image CssClass="media-object cart-product-image img-thumbnail" Width="130px"  Height="105px" ImageUrl='<%#"~/Media/Product/"+ Eval("imgImage") %>' runat="server" ID="gallaryImageLabel" />
            
															
														                            </asp:HyperLink>
													                            </div>
													                            <div class="media-body">
                                                       
														                            <h4 class="">														
                                                                                         <asp:Label Text='<%# Eval("varProductName") %>' runat="server" id="Label1"/>                                                          
														                            </h4>
                            <span class="grey">MRP : <i class="fa  fa-rupee"></i> <asp:Label Text='<%# Eval("intMRP") %>' runat="server" id="Label2"/></span>
									
                            <br />		<span class="grey">Quantity : <asp:Label Text='<%# Eval("quantity") %>' runat="server" id="Label3"/></span>
                            <br />	
                            <span class="grey">Total : <i class="fa  fa-rupee"></i> <asp:Label Text='<%# Eval("TotalAmount") %>' runat="server" id="Label4"/></span>
														
                                                                                </div>
                                                             
												                            </div>
											                            </td>
										                            </tr>

                            </ItemTemplate>
                            <LayoutTemplate>
                                    <table runat="server" ID="itemPlaceholderContainer"  >

                            <tr runat="server" ID="itemPlaceholder"></tr>
                            </table>


                            </LayoutTemplate>

                            </asp:ListView>

                                <asp:SqlDataSource runat="server" ID="SqlDataSourceOrderProduct" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>' 
                                    SelectCommand="SELECT        cart.id, tblsuproducts.varProductName, tblsuproducts.varShortDesc, tblsuproducts.intProductTypeId, tblsuproducts.intProductSubTypeId,   tblsuproducts.varproductcode, tblsuproducts.imgImage, tblsuproducts.intMRP, cart_products.quantity,( tblsuproducts.intMRP * cart_products.quantity) as TotalAmount, cart.personnel_id FROM            cart INNER JOIN   cart_products ON cart.id = cart_products.cartid INNER JOIN      tblsuproducts ON cart_products.productid = tblsuproducts.intId   WHERE        cart.id =@Cartid" >
                              <SelectParameters>
                              <asp:ControlParameter Name="Cartid" ControlID="lblCartid" PropertyName="Text" Type="String" ConvertEmptyStringToNull="true" />
                              </SelectParameters>
                                </asp:SqlDataSource>
              </div>
              </div>
           <div class="col-md-4"> 
               <div class="text-right">
           	<asp:LinkButton runat="server" ID="lnkViewInvoice" CommandArgument='<%# Eval("cartid") %>'   CommandName="ViewInvoice" CssClass=" btn btn-sm btn-success " style="text-decoration:none"><i class="icon md-file-text"></i> View Invoice</asp:LinkButton>
            </div>
               </div>
</div>
     <%-- <div class="panel-footer">
         

      </div>--%>
    </div>
  
</ItemTemplate>
<LayoutTemplate>
 
    <div runat="server" ID="itemPlaceholder">

</div>

</LayoutTemplate>

</asp:ListView>
					                <asp:SqlDataSource runat="server" ID="SqlDataSourceCartAndCustomerDetails" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>' ></asp:SqlDataSource>

                                              </div>
                                       </div>
                                   </div>
                            </div>
          </div>
       </div>
        </div>
</asp:Content>
