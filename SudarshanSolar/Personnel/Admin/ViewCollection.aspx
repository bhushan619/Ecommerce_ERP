<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ViewCollection.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.ViewCollection" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">

<div class="row">
          <div class="col-md-12 col-sm-6 ">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title"><i class="icon md-case" aria-hidden="true"></i>View & Approve Collection </h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                                 <div class=" form-group">
                                   <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                   </div> 
                          <div class="table-responsive">
                        <asp:ListView ID="lstCollection" runat="server" OnItemCommand="lstCollection_ItemCommand" DataSourceID="SqlDataSourceCollection" DataKeyNames="intId">
                           
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
                                <tr style="">
                                    <td>
                                        <asp:Label Text='<%#Container.DataItemIndex+1 %>' runat="server" ID="intIdLabel" /></td>
                                       <td>
                                        <asp:Label Text='<%# Eval("EmployeeName") %>' runat="server" ID="varNameLabel" /></td>
                                      <td>
                                        <asp:Label Text='<%# Eval("varDate") %>' runat="server" ID="varDateLabel" /></td>
                                    <td>
                                        <asp:Label Text='<%# Eval("varPaymentMode") %>' runat="server" ID="varPaymentModeLabel" /></td>
                                    <td>
                                        <asp:Label Text='<%# Eval("varAmount") %>' runat="server" ID="varAmountLabel" /></td>
                                      <td>
                                        <asp:Label Text='<%# Eval("varRepresentativeName") %>' runat="server" ID="varRepresentativeNameLabel" /></td>
                                <td>
                                        <asp:Label Text='<%# Eval("varCompanyName") %>' runat="server" ID="varCompanyNameLabel" /></td>
                                    <td>
                                        <asp:Label Text='<%# Eval("custmb") %>' runat="server" ID="Expr1Label" /></td>
                                     <td>

                                        <asp:Label Text='<%# Eval("ex1").ToString() == "0" ? "NotApproved":"Approved" %>' CssClass='<%# Eval("ex1").ToString() == "0" ? "label label-warning":"label label-success" %>' runat="server" ID="ex1Label" /></td>
                                  
                                     <td>  <asp:LinkButton ID="EditButton" runat="server" CommandName="Collect" Text='<%# Eval("ex1").ToString() == "0" ? "Collect":"Collected" %>' CssClass='<%# Eval("ex1").ToString() == "0" ? " btn-xs btn btn-danger ":" btn-xs btn btn-success disabled" %>' ToolTip="Collect Collection" CommandArgument='<%#Eval("intId")+","+Eval("varAmount")%>' />
                                        </td>
                                </tr>
                            </ItemTemplate>
                            <LayoutTemplate>
                               
                                            <table runat="server" id="itemPlaceholderContainer" class="table-bordered table">
                                                <tr runat="server" style="">
                                                    <th >SrNo</th>
                                                     <th >Employee Name</th>                                                 
                                                  
                                                    <th >Collection Date</th>
                                                    <th >PayMode</th>
                                                    <th >Amount</th>                                               
                                                        <th >Customer Name</th>
                                                    <th >Company Name</th>                                            
                                                    <th >Cust Mobile</th> 
                                                      <th >Status</th>
                                                     <th >Operation</th>
                                                </tr>
                                                <tr runat="server" id="itemPlaceholder"></tr>
                                            </table>
                           
                            </LayoutTemplate>
                            
                        </asp:ListView>

                        <asp:SqlDataSource runat="server" ID="SqlDataSourceCollection" ConnectionString='<%$ ConnectionStrings:solarConnectionString %>' ProviderName='<%$ ConnectionStrings:solarConnectionString.ProviderName %>' ></asp:SqlDataSource>
                              </div>
                    </div>
              
          </div>
            </div>
   
   </div>
</div>    
        </div>
</asp:Content>