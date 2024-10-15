<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="EditCustomerOther.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.EditCustomerOther" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">Edit Customer Other Details</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                               <div class="row">
                                         <ul class="nav nav-tabs">
                                <li class=""><a href="EditCustomer.aspx" >Update Main Details</a>
                                </li>
                                <li class="active"><a href="#">Update Other Details of <label><asp:Label ID="lblCmpName" runat="server" Text=""></asp:Label> </label></a>
                                </li> 
                                  <li class=""><a href="EditCustomerTaxDetails.aspx"  >Update Transaction Details</a>
                                </li> 
                            </ul>
       <br />
                              <div class="tab-content">
                                <div class="tab-pane fade" > 
                                      
                                </div>
                                <div class="tab-pane fade active in" >
                                     <div class="col-md-4  col-sm-4">
                                     <asp:Label ID="lblCustName" runat="server" Text="lblAdminName" Visible="false"></asp:Label>
                     
                                <div class="form-group">
                                            <label>Representative  Name</label>
                                           <asp:TextBox ID="txtRepName" runat="server" class="form-control" 
                                           required     placeholder="Representative Name"  ></asp:TextBox>
                                          
                                        </div> 
                                         <div class="form-group">
                                            <label>Designation/Relation</label>
                                           <asp:TextBox ID="txtDesig" runat="server" class="form-control" 
                                             required   placeholder="Designation/Relation"  ></asp:TextBox>
                                           
                                        </div>
                                        <div class="form-group">
                                            <label>Contact</label>
                                           <asp:TextBox ID="txtContact" runat="server" class="form-control" 
                                              required  placeholder="Contact"  onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"  ></asp:TextBox>
                                          
                                        </div>
                                         <div class="form-group">
                                          <label>Date of Birth</label>
                                           <asp:TextBox ID="txtDOB" runat="server"  class="form-control" placeholder="Date of Birth"></asp:TextBox>
                                        <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOET_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDOB"  
                                    PopupPosition="Right" >
                                </cc1:CalendarExtender>
                                        </div>
                                         <div class="form-group">
                                            <label>Remark</label>
                                           <asp:TextBox ID="txtRemark" runat="server" class="form-control" 
                                              required  placeholder="Remark"   ></asp:TextBox>
                                          
                                        </div>
                                          <div class=" form-group">
                                  <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                   </div> 
                                          <div class="form-group">
                               <asp:Button ID="btnUpdate"  runat="server" Text="Submit" class="btn btn-success" OnClientClick="return Confirm();"  onclick="btnUpdate_Click" 
                                                  />
                                                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                                  class="btn btn-danger " onclick="btnCancel_Click" />
                                        </div> 
                                                                 </div>
                           <div class="col-md-8 col-sm-8">
                            <div class="table-responsive">

                                <asp:GridView ID="grdCustomerOtherDetails" runat="server" 
                                    CssClass=" table table-striped table-bordered table-hover" 
                                    DataSourceID="SqlDataSourceCustOther" AllowPaging="True"  onrowcommand="grdOrderDetails_RowCommand" 
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="varRepName" HeaderText="Name" 
                                            SortExpression="varRepName" />
                                        <asp:BoundField DataField="varDesignation" HeaderText="Designation/Relation" 
                                            SortExpression="varDesignation" />
                                        <asp:BoundField DataField="varContact" HeaderText="Contact" 
                                            SortExpression="varContact" />
                                        <asp:BoundField DataField="varDOB" HeaderText="DOB" 
                                            SortExpression="varDOB" />
                                     <asp:TemplateField>
   <ItemTemplate>
   <asp:LinkButton ID="Button2" runat="server"  CommandName="remove" 
   CommandArgument='<%# Eval("intId") %>' ToolTip="Remove"  CssClass=" icon md-delete btn-xs  btn btn-danger" />
   </ItemTemplate>
   </asp:TemplateField>
                                      
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceCustOther" runat="server" 
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
   </div>
</div>          
</asp:Content>
