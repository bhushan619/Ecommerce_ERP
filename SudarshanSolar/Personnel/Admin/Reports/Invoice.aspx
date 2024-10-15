<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/Admin/Reports/AdminReport.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.Reports.Invoice" %>
  <%--for printing only invoice part on page--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script language="javascript" type="text/javascript">
        function printDiv(divID) {
            //Get the HTML of div
            var divElements = document.getElementById(divID).innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;
            //Reset the page's HTML with div's HTML only
            document.body.innerHTML = 
              "<html><head><title></title></head><body>" + 
              divElements + "</body>";
            //Print Page
            window.print();
            //Restore orignal HTML
            document.body.innerHTML = oldPage;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page animsition">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <div class="page-content">
     

				<div class="container">
					<div class="row">
    <div class="content-body">
					<!-- start: page -->

					<section class="panel">
						<div class="panel-body">
							<div class="invoice"  id="printablediv">   <%--for printing only invoice part on page--%>
							<asp:ListView ID="lstCartAndCustomerDetails" runat="server" DataSourceID="SqlDataSourceCartAndCustomerDetails" DataKeyNames="custid,cartid,id">
                   
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

<div class="row">
										<div class="col-sm-7 mt-md">
											<h2 class="h2 mt-none mb-sm text-dark text-bold">INVOICE</h2>
											<h4 class="h4 m-none text-dark text-bold">###<asp:Label Text='<%# Eval("cartid") %>' runat="server" id="lblCartid"/></h4>
										</div>
										<div class="col-sm-5 ">
											<div class="media-left">
												  5, Tarak Colony,   Opp. Ramakrishna 
												<br/>
												  Mission Ashrama,	Beed bypass,
												<br/>
										 Aurangabad - 431 005. (MH),
												<br/> 
											 India.
											</div>
											<div class="media-right">
												<img src="../../../Content/o/images/logo.png" alt="" />
											</div>
										</div>
									</div>
							
								<div class="bill-info">
									<div class="row">
										<div class="col-md-6">
											<div class="bill-to">
												<p class="h5 mb-xs text-dark text-semibold">To:</p>
												<address>
                                                    <asp:Label Text='<%# Eval("varRepresentativeName") %>' runat="server" id="NameLabel"/>
                                                    <br />
													<asp:Label Text='<%# Eval("varAddress") %>' runat="server" id="varAddressLabel"/>
                                                    <br />
                                                    <asp:Label Text='<%# Eval("varMobile") %>' runat="server" id="varMobileLabel"/>
												</address>
											</div>
										</div>
										<div class="col-md-6">
											<div class="bill-data text-right">
												<p class="mb-none">
													<span class="text-dark">Invoice Date:</span>
													<span class="value"><asp:Label Text='<%# Eval("bookingdate") %>' runat="server" id="bookingdateLabel"/></span>
												</p>
												
											</div>
										</div>
									</div>
								</div>
    <div class="table-responsive">
							<asp:ListView ID="lstInvoice" runat="server" DataSourceID="SqlDataSourceInvoice" DataKeyNames="id">
                           
<EmptyDataTemplate>
<table runat="server" style="">
<tr>
<td>
    <div class="alert alert-dismissable alert-info "  style="width:100%" >
	 <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
 </div>
</td>
</tr>
</table>
</EmptyDataTemplate>

<ItemTemplate>
    <tr>
												<td><asp:Label Text='<%#Container.DataItemIndex+1 %>' runat="server" id="Label1"/></td>
												<td class="text-semibold text-dark"><asp:Label Text='<%# Eval("varProductName") %>' runat="server" id="Label2"/></td>
												<td><asp:Label Text='<%# Eval("varShortDesc") %>' runat="server" id="Label3"/></td>
												<td class="text-center"><i class="fa  fa-rupee"></i> <asp:Label Text='<%# Eval("intMRP") %>' runat="server" id="Label4"/></td>
												<td class="text-center"><asp:Label Text='<%# Eval("quantity") %>' runat="server" id="Label5"/></td>
												<td class="text-center"><i class="fa  fa-rupee"></i> <asp:Label Text='<%# Eval("TotalAmount") %>' runat="server" id="Label6"/></td>
											</tr>

</ItemTemplate>
<LayoutTemplate>
<table runat="server" ID="itemPlaceholderContainer" class=" table-bordered table invoice-items">
    	<thead>
    		<tr class="h4 text-dark">
												<th   class="text-semibold">#</th>
												<th   class="text-semibold">Item</th>
												<th   class="text-semibold">Description</th>
												<th  class="text-center text-semibold">Price</th>
												<th   class="text-center text-semibold">Quantity</th>
												<th  class="text-center text-semibold">Total</th>
											</tr>
            </thead>
    	<tbody>
<tr runat="server" ID="itemPlaceholder"></tr>
            </tbody>
</table>

</LayoutTemplate>
</asp:ListView>
								<asp:SqlDataSource runat="server" ID="SqlDataSourceInvoice" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>' SelectCommand="SELECT        cart.id , tblsuproducts.varProductName, tblsuproducts.varShortDesc, tblsuproducts.intProductTypeId, tblsuproducts.intProductSubTypeId,  tblsuproducts.varproductcode, tblsuproducts.imgImage, tblsuproducts.intMRP, cart_products.quantity, tblsuproducts.intMRP * cart_products.quantity AS TotalAmount,   DATE_FORMAT(cart.bookingdate,'%e %b %Y') as bookingdate, tblsucustomer.varCompanyName, tblsucustomer.varRepresentativeName, tblsucustomer.varAddress, tblsucustomer.varMobile  FROM            cart INNER JOIN   cart_products ON cart.id = cart_products.cartid INNER JOIN      tblsuproducts ON cart_products.productid = tblsuproducts.intId INNER JOIN     tblsucustomer ON cart.personnel_id = tblsucustomer.intId WHERE   cart.id =@Cartid" >
  <SelectParameters>
                                        <asp:ControlParameter Name="Cartid" ControlID="lblCartid" PropertyName="Text" Type="String" ConvertEmptyStringToNull="true" />
                                    </SelectParameters>

								</asp:SqlDataSource>
        </div>
<div class="">
								
								<div class="invoice-summary ">
									<div class="row">
										<div class="col-sm-4 col-sm-offset-8">
											<table class="table h5 text-dark">
												<tbody>
													<tr class="b-top-none">
														<td colspan="2">Subtotal</td>
														<td class="text-left"><asp:Label Text='<%# Eval("total") %>' runat="server" id="Label7"/></td>
													</tr>
													<tr>
														<td colspan="2">Shipping</td>
														<td class="text-left">00.00</td>
													</tr>
													<tr class="h4">
														<td colspan="2">Grand Total</td>
														<td class="text-left"><asp:Label Text='<%# Eval("total") %>' runat="server" id="totalLabel"/></td>
													</tr>
												</tbody>
											</table>
										</div>
									</div>
								</div>
						</div>	</div>

							<div class="text-right mr-lg">
								<asp:LinkButton ID="btnprint" runat="server"  OnClientClick="javascript:printDiv('printablediv');" CssClass="btn btn-warning" ><i class="fa fa-print"></i> Print</asp:LinkButton>
								<a href="Order.aspx" class="btn btn-danger">Cancel</a>
							</div>
    
</ItemTemplate>
<LayoutTemplate>
<div runat="server" ID="itemPlaceholder"></div>
</LayoutTemplate>

</asp:ListView>
									<asp:SqlDataSource runat="server" ID="SqlDataSourceCartAndCustomerDetails" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>' ></asp:SqlDataSource>
						</div>
                            </div>
					</section>

					<!-- end: page -->
				</div>
                        </div>
                    </div>
       </div>
        </div>
    
</asp:Content>
