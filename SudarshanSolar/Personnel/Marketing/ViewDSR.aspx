<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Marketing.Master" AutoEventWireup="true" CodeBehind="ViewDSR.aspx.cs" Inherits="SudarshanSolar.Personnel.Marketing.ViewDSR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
          <div class="page animsition">
                <!-- /. ROW  -->
             <div class="page-content">
      <!-- Panel Form Elements -->
      <div class="panel">
        <div class="panel-heading">
          <h3 class="panel-title">
                        View Daily Expense Sheet</h3>
                        </div>
                <div class="panel-body container-fluid">
       <div class="row ">   <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                        <div class="table-responsive">
                                     
              <div>     
                                       <div class="col-lg-4 col-sm-4">
                                           
                                <div class="form-group "> 
                                           <asp:TextBox ID="txtCmpName" runat="server"  class="form-control" CausesValidation="false"
                                                placeholder="-- Select Customer --"  ></asp:TextBox>
                                           
                                           <cc1:AutoCompleteExtender ID="txtCmpName_AutoCompleteExtender" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtCmpName"  UseContextKey="True">
                                           </cc1:AutoCompleteExtender>
                                           
                                        </div>
                             </div>
                                         <div class="col-lg-2 col-sm-2">
                           <div class="form-group">
                              
                               <asp:TextBox ID="txtFromDate"   placeholder="From Date" runat="server" CssClass="form-control"></asp:TextBox>
                                  <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtFromDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFromDate" >
                                </cc1:CalendarExtender>
                             </div>   </div>
                                 <div class="col-lg-2 col-sm-2">
                               <div class="form-group">
                              
                            <asp:TextBox ID="txtToDate"  placeholder="To Date"  runat="server"  CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtToDate_CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtToDate" >
                                </cc1:CalendarExtender>
                            </div>   </div>
                                <div class="col-lg-4 col-sm-4">
                                   
                            <div class="form-group">
                                <asp:LinkButton ID="btnview" runat="server" Text="View"  OnClick="btnview_Click" CssClass="btn btn-primary"/>                              
                                <a class="btn btn-danger" href="CreateDSR.aspx" >Reset</a>
                                   <asp:LinkButton ID="btnExport" runat="server" Text="Export"  OnClick="btnExport_Click" CssClass="btn btn-warning"/>
                            </div></div>
                          </div> 
                        <div class="table table-responsive">
                         <asp:GridView ID="grdDSR" runat="server"    
                                CssClass="table table-striped table-bordered table-responsive" 
                                DataSourceID="SqlDataSourceDSR" AutoGenerateColumns="False" 
                                DataKeyNames="intId" >
                             <Columns>
                                <asp:BoundField DataField="varDate" HeaderText="Date" 
                                     SortExpression="varDate" />
                                 <asp:BoundField DataField="varLocation" HeaderText="Location" 
                                     SortExpression="varLocation" />
                                 <asp:BoundField DataField="varCallType" HeaderText="CallType" 
                                     SortExpression="varCallType" />
                                 <asp:BoundField DataField="varCustName" HeaderText="CustomerName" 
                                     SortExpression="varCustName" />
                                 <asp:BoundField DataField="varRepersentName" HeaderText="ContactPerson" 
                                     SortExpression="varRepersentName" />
                                 <asp:BoundField DataField="varLandline" HeaderText="Landline" 
                                     SortExpression="varLandline" />
                                 <asp:BoundField DataField="varMobile" HeaderText="Mobile" 
                                     SortExpression="varMobile" />
                                 <asp:BoundField DataField="varRemark" HeaderText="Remark" 
                                     SortExpression="varRemark" />
                                 <asp:BoundField DataField="varNextDate" HeaderText="NextCallDate" 
                                     SortExpression="varNextDate" />  
                             </Columns>
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
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceDSR" runat="server" 
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

</asp:Content>
