<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/Admin/Reports/AdminReport.Master" AutoEventWireup="true" CodeBehind="EditExpenseSheet.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.Reports.EditExpenseSheet" %>
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
                      <h3 class="panel-title">Edit Expense Sheet</h3>
                     </div>
                  
       
                        <div class="panel-body container-fluid">
                          <div class="row">
                                <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
 <div class="col-md-4 col-sm-4">
                        <div class="form-group"> 
                           <asp:TextBox ID="txtFDate" CssClass="form-control" runat="server" required placeholder="Select Start Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFDate"  > 
                                </cc1:CalendarExtender> 
                  </div></div>
      <div class="col-md-4 col-sm-4">
                        <div class="form-group"> 
                           <asp:TextBox ID="txtTDate" CssClass="form-control" runat="server" required placeholder="Select End Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtTDate"  > 
                                </cc1:CalendarExtender> 
                  </div></div>
           <div class="col-md-4 col-sm-4">
                   <div class="form-group"> 
                           <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server" required placeholder="Location"></asp:TextBox>
                           </div>
                            </div> 
                            
                   </div> 
                     <div class="row">
                           
                         <div class="col-md-4 col-sm-4">
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
                                <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" 
                                    Text="Add to sheet" onclick="btnSubmit_Click" />
                                  
                                 <asp:LinkButton ID="btnReset" CssClass="btn btn-warning" runat="server" 
                                    Text="Cancel" onclick="btnReset_Click" />
                           </div>
                         </div> 
                           <div class=" col-lg-8">
                          
                              <div style="overflow-y: hidden;">
                                  <asp:GridView ID="grdSheetDetails" AutoGenerateColumns="false" OnRowCommand="grdSheetDetails_RowCommand" OnRowDataBound="grdSheetDetails_RowDataBound" ShowFooter="true" runat="server" CssClass="table table-bordered" >
                                     <Columns>
                                          <asp:TemplateField>
                                        <HeaderTemplate>Edit</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ToolTip="Delete"  CssClass=" icon md-delete   btn-xs btn btn-danger" ID="aa" CommandArgument='<%# Container.DataItemIndex %>' CommandName="remove" runat="server"></asp:LinkButton>
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
                                      <EmptyDataTemplate>No Details Added</EmptyDataTemplate>
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
       </div>
        </div>
</asp:Content>

