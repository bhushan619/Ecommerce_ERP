﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.ViewProduct" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <div class="page animsition">
   <div class="page-content">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">View List of Product</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                               <div class="row">
                                     <div class="col-md-3  col-sm-3"> 
                                <div class="form-group "> 
                                <label>Search By Product Name</label>
                                </div>
                                </div>
                                     <div class="col-md-6  col-sm-6"> 
                                <div class="form-group "> 
                                           <asp:TextBox ID="txtCmpName" runat="server" class="form-control" 
                                                placeholder="Product Name"  ></asp:TextBox>
                                           
                                           <ajaxToolkit:AutoCompleteExtender ID="txtCmpName_AutoCompleteExtender" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtCmpName" UseContextKey="True">
                                           </ajaxToolkit:AutoCompleteExtender>
                                       
                                        </div>  
                                </div>
                                  <div class="col-md-2  col-sm-2">
                                    <div class="form-group">
                                            <asp:LinkButton ID="btnSearch" runat="server" Text="Search" 
                                                CssClass="btn btn-primary" onclick="btnSearch_Click" />
                                           
                                        </div> 
                                  </div>
                               </div> 
                           <div class="row">
                               <div class="col-md-6 col-md-offset-2 form-group">
                                    <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                   </div> 
                           </div>
                         <div class="row">
                                   <div class="table-responsive">                     
        <asp:ListView ID="listemp" runat="server" DataSourceID="SqlDataSource2" onitemcommand="listproduct_ItemCommand"
                                DataKeyNames="intId" GroupPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
                          <ItemTemplate>
                                    <tr style="">
                                        
                                       <td>
                                            <asp:Label ID="varCompanyNameLabel" runat="server" 
                                                Text='<%# Eval("varProductName") %>' />
                                        </td>
                                       
                                        <td>
                                            <asp:Label ID="varMobileLabel" runat="server" Text='<%# Eval("varTypeName") %>' />
                                        </td>
                                          <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("varSubTypeName") %>' />
                                        </td>
                                         <td>
                                            <asp:Label ID="varRepresentativeNameLabel" runat="server" 
                                                Text='<%# Eval("varproductcode") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varEmailLabel" runat="server" Text='<%# Eval("intPurchasePrice") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varCityLabel" runat="server" Text='<%# Eval("intDealerPrice") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varStatusLabel" runat="server" Text='<%# Eval("intMRP") %>' />
                                        </td>
                                  <td>
<%--                   <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Deletes" CommandArgument='<%# Eval("intId")  %>'
                                             CssClass="btn btn-xs btn-danger"   Text="Delete" />--%>
                                            <asp:LinkButton ID="EditButton" runat="server" CommandName="Edits"  CommandArgument='<%# Eval("intId") %>' CssClass=" icon md-edit btn-xs  btn btn-warning" ToolTip="Edit Product"/>
                                         <asp:LinkButton ID="viewProduct" runat="server" CommandName="View"  CommandArgument='<%# Eval("intId") %>'  CssClass=" icon md-eye btn-xs  btn btn-primary" ToolTip="View Product"/>
                                  
                                        </td>
                                    </tr>
                                </ItemTemplate> 
                                  <EmptyDataTemplate>
                                                         <table id="Table1" runat="server"  style="width:90%" CssClass="table table-bordered ">
                                                             <tr >
                                                               <td  >
                                                                 	<div class="alert alert-dismissable alert-info "  style="width:100%" >
						                                                <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
					                                                </div>
                                                               </td>
                                                              </tr>
                                                         </table>
                                                     </EmptyDataTemplate>
                                <LayoutTemplate>
                                    <table id="Table2" runat="server" >
                                        <tr id="Tr1" runat="server">
                                            <td id="Td1" runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0" 
                                                    class=" table table-striped table-bordered table-hover">
                                                    <tr id="Tr2" runat="server" style="">
                                                        
                                       <th id="Th1" runat="server">
                                                             Name</th>
                                                      
                                                        <th id="Th3" runat="server">
                                                            Type</th>
                                                          <th id="Th8" runat="server">
                                                            SubType</th>
                                                          <th id="Th2" runat="server">
                                                             Code</th>
                                                        <th id="Th4" runat="server">
                                                            PurchasePrice</th>
                                                        <th id="Th5" runat="server">
                                                            DealerPrice</th>
                                                               <th id="Th6" runat="server">MRP</th>
                                                                <th id="Th7" runat="server">
                                                            Operations</th>
                                                    </tr>
                                                    <tr ID="itemPlaceholder" runat="server">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                      <tr id="Tr3" runat="server">
                                            <td id="Td2" runat="server"   style="" colspan = "7">
                                             <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="listemp" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>
          
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                                
                            </asp:ListView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server"  
                                ConnectionString="<%$ ConnectionStrings:solarConnectionString %>"  
                                ProviderName="<%$ ConnectionStrings:solarConnectionString.ProviderName %>"  
                               >
                                
                            </asp:SqlDataSource>
                           
                        </div>  
                               </div> 
                     
                   </div>
              
          </div>
   </div>
</div>          
</asp:Content>
