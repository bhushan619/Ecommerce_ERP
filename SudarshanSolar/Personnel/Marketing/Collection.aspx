<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Marketing.Master" AutoEventWireup="true" CodeBehind="Collection.aspx.cs" Inherits="SudarshanSolar.Personnel.Marketing.Collection" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">

<div class="row">
          <div class="col-md-4 col-sm-4 ">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title"><i class="icon md-case" aria-hidden="true"></i>Add Collection From Customers</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                                
                     <div class="table-responsive">
                     
                                   <asp:Label ID="lblCustName" runat="server" Text="" Visible="false"></asp:Label>
                       
                                      <div class="form-group">    <asp:TextBox ID="txtintId" Visible="false"  runat="server"   ></asp:TextBox>
                           <asp:TextBox Visible="false" ID="txtDate" CssClass="form-control" runat="server" required placeholder="Select Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDate"  > 
                                </cc1:CalendarExtender>
                           </div>
                                  <div class="form-group">
                                        <asp:TextBox ID="txtCustomerName" runat="server" 
                                                    placeholder="Company/Customer Name" class="form-control" AutoPostBack="True" 
                                                    ontextchanged="txtCustomerName_TextChanged" ></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtCustomerName" UseContextKey="True">
                                                </cc1:AutoCompleteExtender>
                                  </div>
                                  <div class="form-group">
                                       <asp:Label ID="lblRepriName" runat="server" Text="Contact person :"  ></asp:Label>
                                  
                                                <asp:Label ID="lblRepresentativeName" runat="server"   ></asp:Label>     <br />  <asp:Label ID="lblMobNo" runat="server" Text="Mobile  Number :"  ></asp:Label>
                                                   <asp:Label ID="lblMob" runat="server"   >                                      </asp:Label>     
                                     
                                  </div>
 <div class="form-group">
                       <asp:DropDownList ID="ddlPayMode" CssClass="form-control" runat="server" > 
                        <asp:ListItem>--Select Payment Mode --</asp:ListItem>
                     <asp:ListItem Value="Cash">Cash</asp:ListItem>
                       <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                           <asp:ListItem Value="DD">DD</asp:ListItem>
                   </asp:DropDownList>
 </div>
  <div class="form-group">
     <asp:TextBox ID="txtCheckNo" CssClass="form-control" placeholder="Cheque Number" runat="server"></asp:TextBox>
 </div>
        <div class="form-group">
                           <asp:TextBox ID="txtCheckDate" CssClass="form-control" runat="server" required placeholder="Select Cheque Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtCheckDate"  > 
                                </cc1:CalendarExtender>
                           </div>
         <div class="form-group">
     <asp:TextBox ID="txtAmount" CssClass="form-control" placeholder="Amount" runat="server"></asp:TextBox>
 </div>
                                     <div class="form-group">
     <asp:TextBox ID="txtOtherDetails" CssClass="form-control" placeholder="Other Payment Details" runat="server"></asp:TextBox>
 </div>
         <div class="form-group">
  <asp:LinkButton ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success"   onclick="btnAdd_Click"  OnClientClick="return Confirm();"/>&nbsp;
             <asp:LinkButton ID="btnEditUpdate" runat="server" Text="Update" OnClientClick="return Confirm();" CssClass="btn btn-success" Visible="false"
                                                         onclick="btnEditUpdate_Click" />&nbsp;
             <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel"     class="btn btn-danger " onclick="btnCancel_Click" /> 
 </div>
                             <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
</div>
                   
                   </div>
              
          </div>
            </div>
    <div class="col-md-8 col-sm-8">
       <div class="panel">
            <div class="panel-heading">
              <h3 class="panel-title"><i class="icon md-eye" aria-hidden="true"></i>Collection From Customers</h3>
            </div>
            <div class="panel-body">
            <div class="table-responsive">
                            <div style="overflow-x:auto">
                                <asp:LinkButton ID="btnExportSale" runat="server" OnClick="btnExportSale_Click" CssClass=" btn btn-success" Text="Export In Excel"  CausesValidation="False" />   
                            <asp:GridView ID="grdRaw" runat="server" OnRowCommand="grdReport_RowCommand"
                                CssClass="table table-striped table-bordered " AllowPaging="True"
                                OnPageIndexChanging="grdRaw_PageIndexChanging" AutoGenerateColumns="False"  >
                                <Columns><asp:TemplateField>
                                     <HeaderTemplate>Operation</HeaderTemplate>
                                     <ItemTemplate>
                                         <asp:LinkButton ID="aa" runat="server"   CssClass=" icon md-edit btn-xs  btn btn-warning" CommandName="edits" CommandArgument='<%# Eval("intId") %>' ToolTip="Edit"><%--<i class="icon md-edit"></i> --%>Edit</asp:LinkButton>
                                         <asp:LinkButton ID="LinkButton1" runat="server" CssClass=" icon md-delete btn-xs  btn btn-danger"  CommandName="del"  CommandArgument='<%# Eval("intId") %>' ToolTip="Delete"><%--<i class="icon md-close"></i>--%> Delete</asp:LinkButton>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                    <asp:BoundField DataField="Party" HeaderText="Party" SortExpression="Party"></asp:BoundField>
                                    <asp:BoundField DataField="Emp Name" HeaderText="Emp Name" SortExpression="Emp Name"></asp:BoundField>
                                    <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="Designation"></asp:BoundField>
                                   <%-- <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"></asp:BoundField>--%>
                                    <asp:BoundField DataField="Pay Mode" HeaderText="Pay Mode" SortExpression="Pay Mode"></asp:BoundField>
                                    <asp:BoundField DataField="Check No" HeaderText="Check No" SortExpression="Check No"></asp:BoundField>
                                    <asp:BoundField DataField="Check Date" HeaderText="Check Date" SortExpression="Check Date"></asp:BoundField>
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"></asp:BoundField>
                                    <asp:BoundField DataField="Other Details" HeaderText="Other Details" SortExpression="Other Details"></asp:BoundField>
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
