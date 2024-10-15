<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/Admin/Reports/AdminReport.Master" AutoEventWireup="true" CodeBehind="ExpenseSheetReport.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.Reports.ExpenseSheetReport1" %>
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
                      <h3 class="panel-title">View Expense Sheet</h3>
                     </div>
                  
       
                        <div class="panel-body container-fluid">
                        <div class="row">   
                            <div> 
                                  <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                  <div class="col-lg-3 col-sm-3">
                           <div class="form-group">
                                  <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control" 
                                      DataSourceID="SqlDataSourceEmp"  DataTextField="varName" AppendDataBoundItems="true"
                                                 DataValueField="varName" >
                                                 <asp:ListItem>-Select Employee-</asp:ListItem>
                                  </asp:DropDownList>
                                  <asp:SqlDataSource ID="SqlDataSourceEmp" runat="server" 
                                      ConnectionString="<%$ ConnectionStrings:solarConnectionString %>" 
                                      ProviderName="<%$ ConnectionStrings:solarConnectionString.ProviderName %>" 
                                     > 
                                  </asp:SqlDataSource>
                              </div>
                                      </div>
                                         <div class="col-lg-3 col-sm-3">
                           <div class="form-group">
                              
                               <asp:TextBox ID="txtFromDate" placeholder="From Date" runat="server" required CssClass="form-control"></asp:TextBox>
                                  <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtFromDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFromDate" >
                                </cc1:CalendarExtender>
                             </div>   </div>
                                 <div class="col-lg-3 col-sm-3">
                               <div class="form-group">
                              
                            <asp:TextBox ID="txtToDate" placeholder="To Date"  runat="server" required CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtToDate_CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtToDate" >
                                </cc1:CalendarExtender>
                            </div>   </div>
                                <div class="col-lg-3 col-sm-3">
                                   
                            <div class="form-group">
                                <asp:Button ID="btnview" runat="server" Text="View"  OnClick="btnview_Click" CssClass="btn btn-primary"/>
                                <a class="btn btn-danger" href="ExpenseSheetReport.aspx" >Reset</a>
                                <a class="btn btn-warning" href="../Report.aspx" >Back</a>
                            </div></div>
                          </div> 
                          </div>
                          <div class="row">
<div class="col-lg-4 col-sm-4 ">  
                           <asp:LinkButton ID="btnExportSale" runat="server" OnClick="btnExportSale_Click" CssClass=" btn btn-success" Text="Export In Excel"  CausesValidation="False" />   
                       
                      

                               <div class="table table-responsive">
                                  <asp:GridView ID="grdReport" runat="server" 
                                      CssClass="table table-bordered"  AutoGenerateColumns="false" OnRowCommand="grdView_RowCommand"  PageSize="15">
                                       <Columns>
                                     <asp:BoundField HeaderText="intId" DataField="intId" />
                                      <asp:BoundField HeaderText="Start Date" DataField="Start Date" />
                                         <asp:BoundField HeaderText="End Date" DataField="End Date" />
                                         <asp:BoundField HeaderText="Location" DataField="Location" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>Operation</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ToolTip="View"  CssClass=" icon md-eye btn-xs  btn btn-primary" ID="aa" CommandArgument='<%# Eval("intId") %>' CommandName="view" runat="server"></asp:LinkButton>
                                              <asp:LinkButton ToolTip="Edit"  CssClass=" icon md-edit btn-xs  btn btn-warning" ID="LinkButton2" CommandArgument='<%# Eval("intId") %>' CommandName="edits" runat="server"></asp:LinkButton>
                                            <asp:LinkButton ToolTip="Delete"  CssClass=" icon md-delete btn-xs  btn btn-danger" ID="LinkButton1" CommandArgument='<%# Eval("intId") %>'  OnClientClick="return Confirm();"  CommandName="deletes" runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                  <EmptyDataTemplate>No Details Added</EmptyDataTemplate>
                                  </asp:GridView> 
                            </div>
                              
                            <asp:HiddenField ID="hdnMsgAlert" runat="server" Value="Do you want to confirm delete?" />
                        </div>
                              <div class="col-lg-8">
                                  <div class="panel-body">
                
                     
                   <div class="row">
 <div class="col-md-4 col-sm-4">
                        <div class="form-group"> 
                           <asp:TextBox ID="txtFDate" ReadOnly="true" CssClass="form-control" runat="server" required placeholder="Select Date"></asp:TextBox>
                           
                  </div></div>
      <div class="col-md-4 col-sm-4">
                        <div class="form-group"> 
                           <asp:TextBox ID="txtTDate"  ReadOnly="true" CssClass="form-control" runat="server" required placeholder="Select Date"></asp:TextBox>
                            
                  </div></div>
           <div class="col-md-4 col-sm-4">
                   <div class="form-group"> 
                           <asp:TextBox ID="txtLocation"  ReadOnly="true" CssClass="form-control" runat="server" required placeholder="Location"></asp:TextBox>
                           </div>
                            </div> 
                            
                   </div> 
                     <div class="row"> 
                           
                           <div class=" col-lg-12"> 
                              <div style="overflow-y: hidden;">
                                  <asp:GridView ID="grdSheetDetails" AutoGenerateColumns="false"  OnRowDataBound="grdSheetDetails_RowDataBound" ShowFooter="true" runat="server" CssClass="table table-bordered" >
                                     <Columns> 
                                         <asp:BoundField HeaderText="Date" DataField="Date" />
                                         <asp:BoundField HeaderText="Place" DataField="Place" />
                                         <asp:BoundField HeaderText="Details of expenses" DataField="Details" />
                                         <asp:BoundField HeaderText="Transport" DataField="Transport" />
                                         <asp:BoundField HeaderText="Local Exp" DataField="Local" />
                                         <asp:BoundField HeaderText="Lodging" DataField="Lodging" />
                                         <asp:BoundField HeaderText="DA" DataField="DA" />
                                         <asp:BoundField HeaderText="Other" DataField="Other" FooterText="Total:" />
                                         <asp:BoundField HeaderText="Total" DataField="Total" /> 
                                     </Columns>
                                      <EmptyDataTemplate>No Details Added</EmptyDataTemplate>
                                  </asp:GridView>
                                     <asp:GridView ID="GridViewExport"    runat="server" >
                                         </asp:GridView>
                                
                                          </div>
                                <div class="form-group text-right"> 
                               
                                 <asp:LinkButton ID="lbkBack" CssClass="btn btn-danger" runat="server" 
                                    Text="Back" onclick="lbkBack_Click" />
                           </div>
                          </div>
                         
                         </div>
                         </div>
                              </div>
                              </div>
                            
                          </div>
                       
                        </div>
   </div>
</div>      
</asp:Content>



