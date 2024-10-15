<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="PreviousEntries.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.PreviousEntries" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content"> <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title"> <asp:Label ID="lblVibhagName" runat="server" Text="" Font-Bold="true"></asp:Label> 
       Entry Search</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">
       
       

        <!-- Main content -->
      <section class="content">
          <!-- Info boxes -->
          <div class="row">
                         <div class="col-lg-12">
                                <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                               <div class="col-md-3"> 
                                            <div class="form-group "> 
                                       
                                                 <asp:DropDownList ID="ddlAccount" runat="server" class="form-control" 
                                                autoPostBack="false"    AppendDataBoundItems="true" >
                                               <asp:ListItem Value="0">Please Select Account Name</asp:ListItem>
                                          </asp:DropDownList>
                                        </div>
                                   </div>
                                <div class="col-md-3">
                <div class="form-group">
                  
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                      </div>
                    <asp:TextBox ID="txtFromDate" placeholder="From Date" runat="server" required CssClass="form-control"></asp:TextBox>
                                  <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtFromDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFromDate" >
                                </cc1:CalendarExtender>
                        
                    </div><!-- /.input group -->
                  </div> 
                                </div>
                                <div class="col-md-3">
               <div class="form-group">
                  
                    <div class="input-group">
                  <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                      </div>
                    
                 
                          <asp:TextBox ID="txtToDate" placeholder="To Date"  runat="server" required CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtToDate_CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtToDate" >
                                </cc1:CalendarExtender>
                    </div><!-- /.input group -->
                  </div> 
                                </div>

                               <div class="col-md-3"> 
                                     <div class="input-group input-group-sm">
                                         <span class="input-group-btn">
                                          <asp:Button CssClass="btn btn-info" id="btnsearch" Text="Search" runat="server"  OnClick="btnSearch_Click"></asp:Button>
                                             <a href="PreviousEntries.aspx" class="btn btn-foursquare">Reset</a>
                                              <a href="NewEntry.aspx" class="btn btn-adn"> New Entry</a> 
                        <a href="PrintEntries.aspx" class="btn btn-bitbucket">Entry Print</a> 
                                          </span>
                  </div>
                                   </div>
                         </div>
                    </div>
         <div class="row">
         <div class="col-md-8"> 
              <!-- Profile Image -->
              <div class="box box-danger">
                 
                <div class="box-body" >
                  <div class="table-responsive" >
                     <asp:GridView ID="grdAccountBook"  CssClass="table table-striped table-bordered table-hover"  PageSize="10"  AllowPaging="True"  runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gdvAccount_PageIndexChanging" OnRowCommand="gdvAccount_RowCommand" >
                                         <Columns>
                                
           
                                                <%--  <asp:BoundField DataField="intId" HeaderText="ID" SortExpression="intId" />    --%>        
                  <asp:BoundField DataField="Date" HeaderText="Date"  />    
                                               <asp:BoundField DataField="Account Code" HeaderText="Day Book No"  />       
                         <asp:BoundField DataField="Account  Name" HeaderText="Account  Name"  />    
                                    <%--           <asp:BoundField DataField="Account Code" HeaderText="Account Code"  />    --%>
                  <asp:BoundField DataField="Details" HeaderText="Details"  />   
                                             <asp:BoundField DataField="Voucher No" HeaderText="Voucher No"  />  
                                               <asp:BoundField DataField="Amount" HeaderText="Amount"  />                                              
                                               <asp:BoundField DataField="Credit / Debit" HeaderText="Credit / Debit"  />       
            <asp:TemplateField>
                   <HeaderTemplate>Edit</HeaderTemplate>
                <ItemTemplate> 
                  <asp:LinkButton ID="lnkbtndelet" runat="server" ToolTip="Edit"  CommandName="Edits" CommandArgument='<%#Eval("Day Book No") %>'  CssClass="icon md-edit btn-xs  btn btn-warning" />
                 </ItemTemplate> 
                </asp:TemplateField> 
                 <asp:TemplateField> 
                   <HeaderTemplate>Delete</HeaderTemplate>
                <ItemTemplate> 
                      <asp:LinkButton ID="lnkDelete" runat="server"  ToolTip="Account Delete" CommandName="Deletes" CommandArgument='<%#Eval("Day Book No") %>'  CssClass="icon md-delete btn-xs  btn btn-danger" forecolor="red" />
               </ItemTemplate> 
                </asp:TemplateField> 
        </Columns>   <EmptyDataTemplate>

         Day Book Details Not Available

        </EmptyDataTemplate> <PagerSettings Mode="Numeric" />
                                    </asp:GridView>
                      
                  </div>

                    </div>
                  </div>
                 </div>
              
               <div class="col-md-4">
                  <!-- Profile Image -->
              <div class="box box-primary">
                    
             
                   
                  <div class="box-body" >
         <h4>Credit / Debit  Updation</h4>
                    <div class="form-group">
                    <label>Date</label>
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                      </div>
                      <asp:TextBox runat="server" ID="txtDateJ" class="form-control" data-inputmask="'alias': 'dd-mm-yyyy'" data-mask></asp:TextBox>
                    </div><!-- /.input group -->
                  </div> 
                       <div class="form-group has-feedback">  
            <asp:TextBox runat="server" ID="txtAccountNameJ" class="form-control" placeholder="Select Account  Name"  AutoPostBack="true"></asp:TextBox>
                             <cc1:AutoCompleteExtender ID="txtCmpName_AutoCompleteExtender" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtAccountNameJ" UseContextKey="True">
                                           </cc1:AutoCompleteExtender>
                                           
            <span class="glyphicon glyphicon-user form-control-feedback"></span>
          </div>
<%--                       <div class="form-group has-feedback"> 
            <asp:TextBox runat="server" ID="txtLedgerNoJ" class="form-control" placeholder="Ledger क्रमांक" ReadOnly="true"></asp:TextBox>
            <span class="glyphicon glyphicon-baby-formula form-control-feedback"></span>
          </div>--%>
                       <div class="form-group has-feedback"> 
            <asp:TextBox runat="server" ID="txtVoucherNoJ" class="form-control" placeholder="Voucher No"></asp:TextBox>
            <span class="glyphicon glyphicon-file form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
            <asp:TextBox runat="server" ID="txtReasonJ"  class="form-control" placeholder="Details" TextMode="MultiLine"></asp:TextBox>
            <span class="glyphicon glyphicon-th-large form-control-feedback"></span>
          </div>
              <div class="form-group has-feedback"> 
          <asp:TextBox runat="server" ID="txtAmountJ" class="form-control"  placeholder="Amount" onkeyup="checkDec(this);" ></asp:TextBox>
            <span class="glyphicon glyphicon-usd form-control-feedback"></span>
          </div>  
                            
                     <div class="form-group has-feedback"> 
            <asp:Button runat="server" ID="btnEdit" class="btn btn-primary" Text=" Update"  OnClick="btnEdit_Click"/>
                        
                         <asp:HiddenField ID="hdnTransactionType" runat="server" Value="" />
                         <asp:HiddenField ID="hdnPreviousBalance" runat="server" Value="" />
                         <asp:HiddenField ID="hdnPreviousAmount" runat="server" Value="" />

                          <asp:HiddenField ID="hdnTotalJama" runat="server"  Value="" ></asp:HiddenField>
                  <asp:HiddenField ID="hdnTotalNave" runat="server"  Value=""></asp:HiddenField> 
          </div>
                    </div>
                    <!-- /input-group -->
                   
                  </div>
                </div> 
             
                </div>
        </section><!-- /.content -->
        </div>
        </div>
       </div>
      </div>
</asp:Content>
