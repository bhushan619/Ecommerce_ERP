<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Marketing.Master" AutoEventWireup="true" CodeBehind="ViewEmployeeExpenses.aspx.cs" Inherits="SudarshanSolar.Personnel.Marketing.ViewEmployeeExpenses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="page animsition">
                <!-- /. ROW  -->
             <div class="page-content">
      <!-- Panel Form Elements -->
      <div class="panel">
        <div class="panel-heading">
          
              <div class="panel-actions">
                  <asp:LinkButton ID="btnExportSale" runat="server" OnClick="btnExportSale_Click" CssClass=" btn btn-success" Text="Export In Excel"  CausesValidation="False" />
                  <asp:LinkButton ID="lbkBack" CssClass="btn btn-danger" runat="server"        Text="Back" onclick="lbkBack_Click" />        
              </div>
              <h3 class="panel-title">View Expense Sheet</h3>
            </div>
                  
                <div class="panel-body container-fluid">
       
                       
                   <div class="row">
                        <div class="col-md-5 col-sm-5">
  <b>   Employee Name : </b><asp:Localize ID="lblEmpName" runat="server" ></asp:Localize>
 </div>
 <div class="col-md-2 col-sm-4">   
                        <div class="form-group"> 
                   <strong>    From Date : </strong><asp:Localize ID="txtFDate"   runat="server"  ></asp:Localize>                           
                  </div></div>
      <div class="col-md-2 col-sm-4">
                        <div class="form-group"> 
                     <strong>      To Date : </strong><asp:Localize ID="txtTDate"   runat="server" ></asp:Localize>                            
                  </div></div>
           <div class="col-md-3 col-sm-4">
                   <div class="form-group"> 
                          <strong>  Location :</strong> <asp:Localize ID="txtLocation"  runat="server" ></asp:Localize>
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
                                          </div>
                         
                          </div>
                         
                         </div>
                             </div>
              
          </div>
                 </div>
              </div>
</asp:Content>
