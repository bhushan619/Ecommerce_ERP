<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Marketing.Master" AutoEventWireup="true" CodeBehind="ExpenseSheet.aspx.cs" Inherits="SudarshanSolar.Personnel.Marketing.ExpenseSheet" %>
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
                        New Expense Sheet</h3>
                        </div>
                <div class="panel-body container-fluid">
          <div class="row row-lg">
            <div class="col-sm-6 col-md-4">
              <!-- Example Rounded Input -->

                        <div class="form-group"> 

                           <asp:TextBox ID="txtFDate" CssClass="form-control" runat="server"  required placeholder="Select Start Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFDate"  > 
                                </cc1:CalendarExtender> 
                  </div></div>
      <div class="col-sm-6 col-md-4">
                        <div class="form-group"> 
                           <asp:TextBox ID="txtTDate" CssClass="form-control"  runat="server" required placeholder="Select End Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtTDate"  > 
                                </cc1:CalendarExtender> 
                  </div></div>
           <div class="col-sm-6 col-md-4">
                   <div class="form-group"> 
                           <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server" required placeholder="Location"></asp:TextBox>
                           </div>
                            </div> 
                           
                         <div class="col-sm-6 col-md-4">
                           <div class="form-group"> <asp:TextBox ID="txtintId" Visible="false"  runat="server"   ></asp:TextBox>
                           <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" required placeholder="Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="CalendarExtender2" runat="server" 
                                    Enabled="True" TargetControlID="txtDate"  > 
                                </cc1:CalendarExtender> </div>
                                <div class="form-group"> 
                           <asp:TextBox ID="txtPlace" CssClass="form-control" runat="server" required placeholder="Place"></asp:TextBox>
                           </div>
                                <div class="form-group"> 
                           <asp:TextBox ID="txtDetails" TextMode="MultiLine" CssClass="form-control" runat="server"  placeholder="Details of expenses"></asp:TextBox>
                           </div>
                                <div class="form-group"> 
                           <asp:TextBox ID="txtModeOfTransport" CssClass="form-control" runat="server"  placeholder="Train or Bus or Travel"></asp:TextBox>
                           </div>
                                <div class="form-group"> 
                           <asp:TextBox ID="txtLocalExp" onkeyup="checkDec(this);" CssClass="form-control" runat="server"  placeholder="Local Exp.(Auto/other)"></asp:TextBox>
                           </div>
                              <div class="form-group"> 
                           <asp:TextBox ID="txtLodging" onkeyup="checkDec(this);" CssClass="form-control" runat="server"  placeholder="Lodging"></asp:TextBox>
                           </div>
                                  <div class="form-group"> 
                           <asp:TextBox ID="txtDA" onkeyup="checkDec(this);" CssClass="form-control" runat="server"  placeholder="D.A"></asp:TextBox>
                           </div>
                                  <div class="form-group"> 
                           <asp:TextBox ID="txtOther" onkeyup="checkDec(this);" CssClass="form-control" runat="server"  placeholder="Other"></asp:TextBox>
                           </div>
                                  <div class="form-group"> 
                           <asp:TextBox ID="txtTotal" onkeyup="checkDec(this);" CssClass="form-control" runat="server" required placeholder="Total"></asp:TextBox>
                           </div>
                              <div class="form-group"> 
                                <asp:LinkButton ID="btnSubmit" CssClass="btn btn-success" runat="server" 
                                    Text="Add to sheet" onclick="btnSubmit_Click" />
                                  
                                 <asp:LinkButton ID="btnReset" CssClass="btn btn-danger" runat="server" 
                                    Text="Cancel" onclick="btnReset_Click" />
                           </div>
                                     <div class=" form-group">
                                 <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                   </div>
                         </div> 
                           <div class=" col-lg-8">
                          
                              <div style="overflow-y: hidden;">
                                  <asp:GridView ID="grdSheetDetails" AutoGenerateColumns="false" OnRowCommand="grdSheetDetails_RowCommand" OnRowDataBound="grdSheetDetails_RowDataBound" ShowFooter="true" runat="server" CssClass="table table-bordered" >
                                     <Columns>
                                          <asp:TemplateField>
                                        <HeaderTemplate>Remove</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ToolTip="Remove"  CssClass=" icon md-delete btn-xs  btn btn-danger" ID="aa" CommandArgument='<%# Container.DataItemIndex %>' CommandName="remove" runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                         <asp:BoundField HeaderText="Date" DataField="Date" />
                                         <asp:BoundField HeaderText="Place" DataField="Place" />
                                         <asp:BoundField HeaderText="Details of expenses" DataField="Details of expenses" />
                                         <asp:BoundField HeaderText="Transport" DataField="Transport" />
                                         <asp:BoundField HeaderText="Local Exp" DataField="Local Exp" />
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
                                <div class="form-group text-right"> 
                                <asp:LinkButton ID="btnSubmitSheet" CssClass="btn btn-primary" runat="server"  OnClientClick="return Confirm();"
                                    Text="Submit" onclick="btnSubmitSheet_Click" />
                                    <asp:LinkButton ID="btnEditUpdate" runat="server" Text="Update" OnClientClick="return Confirm();" CssClass="btn btn-success" Visible="false"
                                                         onclick="btnEditUpdate_Click" /> 
                                 <asp:LinkButton ID="LinkButton1" CssClass="btn btn-danger" runat="server" 
                                    Text="Cancel" onclick="btnReset_Click" />
                           </div>
                          </div>
                         
                         </div>
                         </div>
                        </div>
                   

                   <div class="panel">
        <div class="panel-heading">
          <h3 class="panel-title">
                          View/Update Expense Sheet</h3>
                        </div>
                        <div class="panel-body container-fluid">
                              <div class="row row-lg">
                                     <div class="col-sm-10 col-lg-6">
                        <div class="table-responsive">
                            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="false" OnRowCommand="grdView_RowCommand" CssClass="table table-bordered" >
                                <Columns>
                                     <asp:BoundField HeaderText="intId" DataField="intId" />
                                      <asp:BoundField HeaderText="Start Date" DataField="Start Date" />
                                         <asp:BoundField HeaderText="End Date" DataField="End Date" />
                                         <asp:BoundField HeaderText="Location" DataField="Location" />
                                      <asp:BoundField HeaderText="Total Expenses" DataField="Total Expenses" />
                                   <%-- <asp:TemplateField>
                                        <HeaderTemplate>View</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass=" fa fa-eye btn btn-danger" ID="aa" CommandArgument='<%# Eval("intId") %>' CommandName="views" runat="server"></asp:LinkButton>
                                            <asp:LinkButton CssClass=" fa fa-edit btn btn-warning" ID="LinkButton2" CommandArgument='<%# Eval("intId") %>' CommandName="edits" runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
