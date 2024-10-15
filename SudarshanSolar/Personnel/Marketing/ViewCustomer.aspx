<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Marketing.Master" AutoEventWireup="true" CodeBehind="ViewCustomer.aspx.cs" Inherits="SudarshanSolar.Personnel.Marketing.ViewCustomer" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">View Customer</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                               
                                                 
                        <div class="row">
                              <div class="col-md-3  col-sm-3"> 
                                <div class="form-group "> 
                                <label>Search By Company Name</label>
                                </div>
                                </div>
                               <div class="col-md-6  col-sm-6"> 
                                <div class="form-group "> 
                                           <asp:TextBox ID="txtCmpName" runat="server" class="form-control" 
                                                placeholder="Company Name"  ></asp:TextBox>
                                           
                                           <cc1:AutoCompleteExtender ID="txtCmpName_AutoCompleteExtender" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtCmpName" UseContextKey="True">
                                           </cc1:AutoCompleteExtender>
                                           
                                        </div>  
                                </div>
                                  <div class="col-md-2  col-sm-2">
                                    <div class="form-group">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" 
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
                             
                            <asp:ListView ID="listcust" runat="server" DataSourceID="SqlDataSource2" 
                                DataKeyNames="intId" GroupPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
                                 <ItemTemplate>
                                    <tr style="">
                                        
                                        <td>
                                            <asp:Label ID="varCompanyNameLabel" runat="server" 
                                                Text='<%# Eval("varCompanyName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varRepresentativeNameLabel" runat="server" 
                                                Text='<%# Eval("varRepresentativeName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varMobileLabel" runat="server" Text='<%# Eval("varMobile") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varEmailLabel" runat="server" Text='<%# Eval("varEmail") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varCityLabel" runat="server" Text='<%# Eval("varCity") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varStatusLabel" runat="server" Text='<%# Eval("varStatus") %>' />
                                        </td>
                                  <%-- <td> 
                                           <asp:LinkButton ID="EditButton" runat="server" CssClass="fa fa-edit  btn btn-danger" CommandName="Edits"  CommandArgument='<%#Eval("intId")+","+ Eval("varStatus")%>' />
                                         </td>--%>
                                    </tr>
                                </ItemTemplate> 
                                 <EmptyDataTemplate>
                                                         <table id="Table1" runat="server"  style="width:90%" CssClass="table table-bordered table-hover">
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
                                    <table runat="server" >
                                        <tr runat="server">
                                            <td runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0" 
                                                    class=" table table-striped table-bordered table-hover">
                                                    <tr runat="server" style="">
                                                        
                                                        <th runat="server">
                                                            Company Name</th>
                                                        <th runat="server">
                                                             Representative Name</th>
                                                        <th runat="server">
                                                            Mobile</th>
                                                        <th runat="server">
                                                            Email</th>
                                                        <th runat="server">
                                                            City</th>
                                                               <th runat="server">Status</th>
                                                              <%--  <th runat="server">
                                                            Operations</th>--%>
                                                    </tr>
                                                    <tr ID="itemPlaceholder" runat="server">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server">
                                            <td runat="server"   style="" colspan = "7">
                                             <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="listcust" PageSize="10">
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
