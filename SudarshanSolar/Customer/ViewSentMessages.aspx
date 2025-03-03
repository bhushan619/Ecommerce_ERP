﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/OutsideMaster.Master" AutoEventWireup="true" CodeBehind="ViewSentMessages.aspx.cs" Inherits="SudarshanSolar.Customer.ViewSentMessages" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <section class="page_breadcrumbs ds ms parallax section_padding_bottom_30">
				<div class="container">
					<div class="row">
						<div class="col-sm-12 text-center">
							<div class="breadcrumbs_logo">
								<img src="../Content/o/images/logo.png" alt="">
							</div>
							<h1 class="highlight bold">Enquiry</h1>
							<ol class="breadcrumb">
								<li>
									<a href="Dashboard.aspx">
										HomePage
									</a>
								</li>
								
								<li class="active">View Sent Enquiry</li>
							</ol>
						</div>
					</div>
				</div>
			</section>

    <section class="ls ms   columns_padding_25">
				<div class="container">
                    <div class="row">
             <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="col-md-6 col-sm-6">
                 <div class="panel panel-info">

   <div class="panel-heading">
                          <i class="fa fa-envelope"></i> View & Reply Messages
                        </div>                      
                        <div class="panel-body">   
                        <div class="table-responsive">
                            <asp:ListView ID="lstMessages" runat="server"    onitemcommand="lstFullMessage_ItemCommand"
                                DataSourceID="SqlDataSourceMessages" DataKeyNames="intId" 
                                onpagepropertieschanging="lstMessages_PagePropertiesChanging"> 
                                 
                                <EmptyDataTemplate>
                                    <table id="Table1" runat="server" style="">
                                        <tr>
                                            <td>
                                                  <div class="alert alert-dismissable alert-info "  style="width:100%" >
	 <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
 </div></td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate> 
                                <ItemTemplate>
                                    <tr style=""> 
                                       <td>
                                            <asp:Label ID="dtDateLabel" runat="server" Text='<%# Eval("dtDate") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="tmTimeLabel" runat="server" Text='<%# Eval("tmTime") %>' />
                                        </td>
                                          <td>
                                            <asp:Label ID="Label1" runat="server" 
                                                Text='<%# Eval("varMessageToName") %>' />
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="varEnquirySubjectLabel" runat="server"  CommandName="Views" CommandArgument='<%#Eval("intId")+","+Eval("varEnquirySubject")%>'
                                                Text='<%# Eval("varEnquirySubject") %>' />
                                        </td>
                                       
                                      <td>
                                           <asp:LinkButton ID="DeleteButton" Text="Delete"   CssClass="label label-danger" runat="server" CommandName="Deletes" CommandArgument='<%#Eval("intId")%>'
                                                ToolTip="Delete" /> 
                                </td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table id="Table2" runat="server">
                                        <tr id="Tr1" runat="server">
                                            <td id="Td1" runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0"    class=" table table-striped table-bordered table-hover">
                                                    <tr id="Tr2" runat="server" style=""> 
                                                        <th id="Th1" runat="server">
                                                            Date</th>
                                                        <th id="Th2" runat="server">
                                                            Time</th> 
                                                           
                                                                <th id="Th3" runat="server">
                                                            Message To</th>
                                                        <th id="Th4" runat="server">
                                                            Subject</th>
                                                         <th id="Th5" runat="server">   
                                                             Delete
                                                        </th>
                                                    </tr>
                                                    <tr ID="itemPlaceholder" runat="server">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="Tr3" runat="server">
                                            <td id="Td2" runat="server" style="">
                                                <asp:DataPager ID="DataPager1" runat="server">
                                                    <Fields>
                                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                        <asp:NumericPagerField />
                                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                    </Fields>
                                                </asp:DataPager>
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                                 
                            </asp:ListView>
                           
                            <asp:SqlDataSource ID="SqlDataSourceMessages" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:solarConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:solarConnectionString.ProviderName %>"   >
                               
                            </asp:SqlDataSource>
                           
                            </div> 
                       
                        </div>
                        </div>
                    </div>
                       <div class="col-md-6 col-sm-6">
                     <div class="panel panel-warning"> 
   <div class="panel-heading">
                          <i class="fa fa-eye"></i>    View Full Message
                        </div>  
                          <div class="panel-body">   
                        <div class="table-responsive">
                        <div  >
                        <label> Subject:</label>  <asp:Label ID="lblSubject" runat="server" Text="Message Subject"></asp:Label>
                        
                        </div>
     <asp:ListView ID="lstFullMessage" runat="server" 
                                DataSourceID="SqlDataSourceFull" DataKeyNames="intId" 
                             > 
                                <AlternatingItemTemplate>
                                    <tr style="">
                                        
                                        <td align="left">
                                            <asp:Label ID="nvarMsgFromLabel" runat="server" 
                                                Text='<%# Eval("nvarMsgFrom") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="nvarMsgToLabel" runat="server" Text='<%# Eval("nvarMsgTo") %>' />
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                 
                                <EmptyDataTemplate>
                                    <table id="Table3" runat="server" style="">
                                        <tr>
                                            <td>
                                                Please Click Message Subject To View</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate> 
                                <ItemTemplate>
                                    <tr style="">
                                         
                                        <td align="left">
                                            <asp:Label ID="nvarMsgFromLabel" runat="server" 
                                                Text='<%# Eval("nvarMsgFrom") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="nvarMsgToLabel" runat="server" Text='<%# Eval("nvarMsgTo") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate> 
                                <LayoutTemplate>
                                    <table id="Table4" runat="server">
                                        <tr id="Tr4" runat="server">
                                            <td id="Td3" runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0"  class=" table table-striped table-bordered table-hover">
                                                    <tr id="Tr5" runat="server" style="">
                                                        
                                                        <th id="Th6" runat="server">
                                                            Sent</th>
                                                        <th id="Th7" runat="server">
                                                            Recieved</th>
                                                    </tr>
                                                    <tr ID="itemPlaceholder" runat="server">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="Tr6" runat="server">
                                            <td id="Td4" runat="server" style="">
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                                 
                                 
                                 
                            </asp:ListView> 
                            <asp:SqlDataSource ID="SqlDataSourceFull" runat="server" 
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
                    </div>
        </section>
    
</asp:Content>
