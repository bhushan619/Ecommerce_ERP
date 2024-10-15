<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ViewExpenseSheet.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.ViewExpenseSheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page animsition">
                <!-- /. ROW  -->
             <div class="page-content">
      <!-- Panel Form Elements -->
      <div class="panel">
        <div class="panel-heading">
          <h3 class="panel-title">
                        View Expense Sheet</h3>
                        </div>
                <div class="panel-body container-fluid">
          <div class="row row-lg">
            <div class="col-md-10 ">
                         <div class="panel-body"> 
                        <div class="table-responsive">
                            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="false" OnRowCommand="grdView_RowCommand" CssClass="table table-bordered" >
                                <Columns>
                                     <asp:BoundField HeaderText="intId" DataField="intId" />
                                     <asp:BoundField HeaderText="Employee Name" DataField="Name" />
                                      <asp:BoundField HeaderText="Start Date" DataField="Start Date" />
                                         <asp:BoundField HeaderText="End Date" DataField="End Date" />
                                         <asp:BoundField HeaderText="Location" DataField="Location" />
                                      <asp:BoundField HeaderText="Total Expenses" DataField="Total Expenses" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>View</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ToolTip="View"  CssClass=" icon md-eye btn-xs  btn btn-primary" ID="aa" CommandArgument='<%# Eval("intId") %>' CommandName="edits" runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
          </div>
</asp:Content>
