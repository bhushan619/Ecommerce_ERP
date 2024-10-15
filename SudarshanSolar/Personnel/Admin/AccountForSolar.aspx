<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AccountForSolar.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.AccountForSolar" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">

<div class="row">
          <div class="col-md-6 col-sm-6 ">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title"><i class="icon md-case" aria-hidden="true"></i>Select Account For Solar</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                                
                      <div class="row">
                                <div class="form-group "> 
                                           <asp:DropDownList ID="ddldivision" runat="server" class="form-control" 
                                                autoPostBack="false"     required="required" AppendDataBoundItems="true" >
                                               <asp:ListItem Value="0">Please Select Division</asp:ListItem>
                                           </asp:DropDownList>
                           
                                          </div>
                                 <div class="form-group">

             <%--         <label class="control-label">Select Account Name</label>--%>
                     <asp:DropDownList ID="ddlAccount" runat="server" class="form-control" 
                                                autoPostBack="false"    AppendDataBoundItems="true" >
                                               <asp:ListItem Value="0">Please Select Account Name</asp:ListItem>
                                          </asp:DropDownList>
                            </div>
                                  <div class="form-group">
 
<%--<asp:Button ID="btnsubmit" class="btn btn-success" runat="server" Visible="false" OnClick="btnsubmit_Click" Text="Submit" />--%>
                  <asp:Button ID="btnupdate" class="btn btn-warning" OnClick="Btnupdate_Click" Visible="false" runat="server" Text="Update" />
                
              </div>
         
                 
                     <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                   
                   </div>
              
          </div>
            </div>
              </div>
    <div class="col-md-6 col-sm-6">
       <div class="panel">
            <div class="panel-heading">
              <h3 class="panel-title"><i class="icon md-eye" aria-hidden="true"></i>view</h3>
            </div>
            <div class="panel-body">
                              <div class="  table-responsive">

                                <asp:ListView ID="lstType" runat="server" OnPagePropertiesChanging="OnPagePropertiesChanging" OnItemCommand="lstType_ItemCommand">

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

                                            <td>
                                                <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label></td>

                                            <td>
                                                <asp:Label Text='<%# Eval("varDivisionName") %>' runat="server" ID="Label1" /></td>

                                            <td>
                                                <asp:Label Text='<%# Eval("varAccountName") %>' runat="server" ID="Label3" /></td>



                                            <td>
                                                <asp:LinkButton ID="lnkListEdit" CommandArgument='<%# Eval("id") %>' CommandName="Edits" runat="server"  CssClass=" icon md-edit btn-xs  btn btn-warning" ToolTip="Edit Account"  /></td>
                                          
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>

                                        <table runat="server" id="itemPlaceholderContainer" cellpadding="1" class="table table-bordered table-hover">
                                            <tr id="Tr1" runat="server" class="">

                                                <th id="Th2" runat="server">SrNo</th>

                                                <th id="Th3" runat="server">Division Name</th>
                                                <th id="Th5" runat="server">Account Name</th>

                                                <th id="Th1" runat="server" >Operation</th>
                                            </tr>
                                            <tr runat="server" id="itemPlaceholder"></tr>
                                        </table>
                                    </LayoutTemplate>

                                </asp:ListView>
                            </div>
                            <div class="panel-footer">
                                <div class="text-right">

                                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstType" PageSize="10">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-primary btn-xs" ShowFirstPageButton="True" ShowPreviousPageButton="False" FirstPageText="< First " ShowNextPageButton="false" />
                                            <asp:NumericPagerField ButtonType="Link" />
                                            <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-primary btn-xs" ShowNextPageButton="False" ShowLastPageButton="True" ShowPreviousPageButton="false" LastPageText=" Last >" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </div>
            </div>
          </div>
        </div>
   </div>
</div>   
        </div>      
</asp:Content>


