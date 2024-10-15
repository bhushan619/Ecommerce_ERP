<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ViewFullProduct.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.ViewFullProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
        <div class="page-content">

            <div class="row table-responsive">
                <div class="col-md-8">
                    <div class="panel">
                        <div class="panel-heading">
                            <h3 class="panel-title">View Product Full Specifications</h3>
                        </div>

                        <div class="panel-body container-fluid">
                            <div class="row">
                                  <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                <asp:ListView ID="lstProduct" DataSourceID="SqlDataSourceProduct" runat="server" DataKeyNames="intId">

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
                                        <div class="col-md-6 col-md-6">
                                            <div class="widget widget-shadow">
                                                <div class="widget-header cover overlay" style="height: calc(100% - 100px);">
                                                    <asp:Image Height="350px" Width="680px" ImageUrl='<%#"~/Media/Product/"+ Eval("imgImage") %>' runat="server" ID="Image1" /><br />


                                                    <div class="overlay-panel overlay-background overlay-top">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="font-size-20 white">
                                                                    <asp:Label Text='<%# Eval("varProductName") %>' runat="server" ID="varProductNameLabel" /><br />
                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="widget-footer padding-horizontal-30 padding-vertical-20 height-160">
                                                    <div class="row no-space">
                                                        <div class="col-md-4">
                                                            <div class="counter">
                                                                <span class="counter-number">
                                                                    <asp:Label Text='<%# Eval("intPurchasePrice") %>' CssClass="label label-outline label-success" runat="server" ID="intPurchasePriceLabel" /><br />
                                                                </span>
                                                                <div class="counter-label font-weight-900">PurchasePrice</div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="counter">
                                                                <span class="counter-number">
                                                                    <asp:Label Text='<%# Eval("intDealerPrice") %>' runat="server" CssClass="label label-outline label-warning" ID="intDealerPriceLabel" /><br />
                                                                </span>
                                                                <div class="counter-label font-weight-900">DealerPrice</div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="counter">
                                                                <span class="counter-number">
                                                                    <asp:Label Text='<%# Eval("intMRP") %>' CssClass="label label-outline label-info" runat="server" ID="intMRPLabel" /><br />
                                                                </span>
                                                                <div class="counter-label font-weight-900">MRP</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-md-6">
                                            <div class="row no-space">
                                                <h4>Product Specification</h4>
                                                <div class="form-group">
                                                    <label class="font-weight-900">Code  :</label>
                                                    <asp:Label Text='<%# Eval("varproductcode") %>' runat="server" ID="varproductcodeLabel" /><br />

                                                </div>
                                                <div class="form-group">
                                                    <label class="font-weight-900">Product Name  :</label>
                                                    <asp:Label Text='<%# Eval("varProductName") %>' runat="server" ID="Label1" /><br />

                                                </div>

                                                <div class="form-group">
                                                    <label class="font-weight-900">Type Name  :</label>
                                                    <asp:Label Text='<%# Eval("varTypeName") %>' CssClass="" runat="server" ID="varTypeNameLabel" /><br />
                                                    <asp:Label Text='<%# Eval("intId") %>' Visible="false" runat="server" ID="intIdLabel" />

                                                </div>
                                                <div class="form-group">
                                                    <label class="font-weight-900">Sub Type Name  :</label>
                                                    <asp:Label Text='<%# Eval("varSubTypeName") %>' runat="server" ID="varSubTypeNameLabel" /><br />

                                                </div>

                                                <div class="form-group">
                                                    <label class="font-weight-900">Short Description  :</label>
                                                    <asp:Label Text='<%# Eval("varShortDesc") %>' runat="server" ID="varShortDescLabel" /><br />

                                                </div>
                                                <div class="form-group">
                                                    <label class="font-weight-900">Long Description  :</label>
                                                    <asp:Label Text='<%# Eval("varLongDesc") %>' runat="server" ID="varLongDescLabel" /><br />

                                                </div>
                                            </div>
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



                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">

                    <div class="row">
                        <div class="panel">
                            <div class="panel-heading">
                                <h3 class="panel-title">Product Attributes</h3>
                            </div>

                            <div class="panel-body container-fluid">

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
                                        <tr style="">

                                            <asp:Label Text='<%# Eval("intId") %>' runat="server" ID="intIdLabel" Visible="false" />
                                            <td>
                                                <span class="badge badge-success">
                                                    <asp:Label Text='<%# Eval("varVariation") %>' runat="server" ID="varVariationLabel" />
                                                </span></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("varVariationValue") %>' runat="server" ID="varVariationValueLabel" /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>

                                        <table runat="server" id="itemPlaceholderContainer" style="" border="0" width="100%" class="table table-bordered">
                                            <tr runat="server" style="">

                                                <th runat="server">Attributes</th>
                                                <th runat="server">Value</th>
                                            </tr>
                                            <tr runat="server" id="itemPlaceholder"></tr>
                                        </table>

                                    </LayoutTemplate>

                                </asp:ListView>

                                <asp:SqlDataSource runat="server" ID="SqlDataSourceVariation" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>'></asp:SqlDataSource>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="panel">
                            <div class="panel-heading">
                                <h3 class="panel-title">Product Gallary</h3>
                            </div>

                            <div class="panel-body container-fluid">

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
                                        <div class="col-md-4">
                                            <div class="widget widget-shadow">
                                                <figure class="widget-header overlay-hover overlay">
                                   <asp:Image class="overlay-figure overlay-scale" ImageUrl='<%#"~/Media/Product/"+ Eval("file") %>' runat="server" ID="gallaryImageLabel" /><br />
            
                              <figcaption class="overlay-panel overlay-background overlay-fade overlay-icon">
             
                               <asp:HyperLink runat="server" CssClass="icon md-search" NavigateUrl='<%#"~/Media/Product/"+ Eval("file") %>' ID="j"></asp:HyperLink>
                               </figcaption>
                            </figure>

                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <div runat="server" id="itemPlaceholder" />

                                    </LayoutTemplate>
                                </asp:ListView>

                                <asp:SqlDataSource runat="server" ID="SqlDataSourceGallary" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>'></asp:SqlDataSource>
                            </div>

                        </div>
                    </div>
                </div>

            </div>


        </div>
    </div>
</asp:Content>
