<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="EditCustomerTaxDetails.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.EditCustomerTaxDetails" %>
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
                      <h3 class="panel-title">Edit Customer TAX Details</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                               <div class="row">
                                      <ul class="nav nav-tabs">
                                <li class=""><a href="EditCustomer.aspx"  >Update Main Details</a>
                                </li>
                                <li class=""><a href="EditCustomerOther.aspx"  >Update Other Details</a>
                                </li> 
                                  <li class="active"><a href="EditCustomerTaxDetails.aspx"  >Update Transaction Details</a>
                                </li> 
                            </ul>
 <br />
                              <div class="tab-content">
                                <div class="tab-pane fade active in" > 
                                          <br /> 
                                <div class="col-md-4  col-sm-4">
                                     <asp:Label ID="lblCmpName" runat="server" Text="lblAdminName" Visible="false"></asp:Label>
                           
                                <div class="form-group">
                                    <label>Taxable</label>
                                    <asp:TextBox ID="txtTaxable" runat="server"  class="form-control" required placeholder="Taxable" ></asp:TextBox>
                                    </div>
                                     <div class="form-group">
                                    <label>Taxt Type</label>
                                    <asp:TextBox ID="txtType" runat="server"  class="form-control" required placeholder="Tax Type" ></asp:TextBox>
                                    </div>
                                     <div class="form-group">
                                    <label>CST Number</label>
                                    <asp:TextBox ID="txtCST" runat="server"  class="form-control" required placeholder="CST Number" ></asp:TextBox>
                                    </div>
                                     <div class="form-group">
                                    <label>Tax Group</label>
                                    <asp:TextBox ID="txtTaxgroup" runat="server"  class="form-control" required placeholder="Tax Group" ></asp:TextBox>
                                    </div>
                                
                                    
                                       <div class="form-group ">
                                    <label>Tax Discount In %</label>
                                    <asp:TextBox ID="txtTaxDiscount" runat="server"  class="form-control" required placeholder="Tax Discount"  onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                                <%--   <span class="form-group input-group-btn "><br /><p class="btn btn-default" >%</p> </span>--%>
                                               
                                     </div> 
                                   <div class="form-group">
                                    <label>Credit Bills</label>
                                    <asp:TextBox ID="txtCrBills" runat="server"  class="form-control"  required placeholder="Credit Bills"  onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" ></asp:TextBox>
                                     </div>

                                     <div class="form-group">
                                    <label>Credit Limit</label>
                                    <asp:TextBox ID="txtCrLimit" runat="server"  class="form-control" required placeholder="Credit Limit"  onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" ></asp:TextBox>
                                  
                                </div>
                                     <div class="form-group">
                                    <label>Credit Days</label>
                                    <asp:TextBox ID="txtCrDays" runat="server"  class="form-control" required placeholder="Credit Days" ></asp:TextBox>
                                    </div>
                                     <div class=" form-group">
                                    <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                   </div> 
                                    <asp:Button ID="btnAdd" runat="server" Text="Insert"  CssClass="btn btn-success" OnClick="btnAdd_Click" OnClientClick="return Confirm();" />
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="btnUpdate_Click" />
                                    <asp:LinkButton ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="btnReset_Click" />
                                  </div>

                                      <div class="col-md-8 col-sm-8">
                            <div class="table-responsive">
                                <br />
                                    <asp:GridView ID="grdCustomerTaxDetails" runat="server" 
                                    CssClass=" table table-striped table-bordered table-hover" 
                                    AllowPaging="True" 
                                    AutoGenerateColumns="False" OnRowCommand="grdCustomerTaxDetails_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="varTaxable" HeaderText="Taxable" 
                                            SortExpression="varTaxable" />
                                        <asp:BoundField DataField="varTaxType" HeaderText="Tax Type" 
                                            SortExpression="varTaxType" />
                                        <asp:BoundField DataField="varCSTnumber" HeaderText="CST Number" 
                                            SortExpression="varCSTnumber" />
                                        <asp:BoundField DataField="varTaxGroup" HeaderText="Tax Group" 
                                            SortExpression="varTaxGroup" />
                                         <asp:BoundField DataField="varTaxDiscount" HeaderText="Tax Discount" 
                                            SortExpression="varTaxDiscount" />
                                     <asp:TemplateField>
                                                 <ItemTemplate>
                                                     <asp:LinkButton ID="Button2" runat="server" Text="Remove" CommandName="removes" 
                                                        CommandArgument='<%# Eval("intId") %>'  CssClass=" icon md-delete btn-xs  btn btn-danger"" />
                                                 </ItemTemplate>
                                     </asp:TemplateField>
                                           
                                    </Columns>
                                </asp:GridView>
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
