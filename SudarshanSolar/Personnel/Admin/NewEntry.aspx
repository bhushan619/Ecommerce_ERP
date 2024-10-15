<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="NewEntry.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.NewEntry" %>
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
                      <h3 class="panel-title"> New Entry For <asp:Label ID="lblVibhagName" runat="server" Text=""></asp:Label> </h3>
                     </div>
                  
                    <div class="panel-body container-fluid">
       
    
        <!-- Main content -->
      <section class="content">
          <!-- Info boxes -->
         <div class="row">         <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
            <div class="col-md-5">
               
              <!-- Profile Image -->
              <div class="box box-primary">
                    
                <div class="box-body" >
             
                    <div class="form-group">
                      <div class="input-group">
                    <div class="input-group-btn">
                      <button class="btn btn-warning">
                    <asp:Label ID="lblDateUp" runat="server" Text=""></asp:Label> Initial Balance</button>
                    </div><!-- /btn-group -->
                     <asp:TextBox runat="server" ID="txtDayStartingAmount" Font-Bold="true" Font-Size="Larger" class="form-control" ReadOnly="true"></asp:TextBox>
                  </div></div>
                    <ul class="nav nav-tabs">
  <li class="active"><a data-toggle="tab" href="#jama">Credit</a></li>
  <li><a data-toggle="tab" href="#nave">Debit</a></li> 
</ul>

<div class="tab-content">
  <div id="jama" class="tab-pane fade in active">
      <div class="box-body" >

                    <div class="form-group">
                    <label>Date</label>
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                      </div>
                      <asp:TextBox runat="server" ID="txtDateJ" class="form-control" placeholder="DD-MM-YYYY"  required="required"></asp:TextBox>
                          <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtFromDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDateJ" >
                                </cc1:CalendarExtender>
                    </div><!-- /.input group -->
                  </div> 
                       <div class="form-group">  
            <asp:DropDownList runat="server" ID="txtAccountNameJ" AppendDataBoundItems="true" class="form-control" OnSelectedIndexChanged="txtAccountNameJ_TextChanged" AutoPostBack="true">
                <asp:ListItem Value="">-- Select Account --</asp:ListItem>
            </asp:DropDownList>
                            <%-- <cc1:AutoCompleteExtender ID="txtCmpName_AutoCompleteExtender" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtAccountNameJ" UseContextKey="True">
                                           </cc1:AutoCompleteExtender>--%>
                                           
            <span class="glyphicon form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
            <asp:TextBox runat="server" ID="txtLedgerNoJ" class="form-control" placeholder="Ledger No" ReadOnly="true"></asp:TextBox>
            <span class="glyphicon glyphicon-baby-formula form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
            <asp:TextBox runat="server" ID="txtVoucherNoJ" class="form-control" placeholder="Voucher No"></asp:TextBox>
            <span class="glyphicon glyphicon-file form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
            <asp:TextBox runat="server" ID="txtReasonJ"  class="form-control" placeholder="Details" TextMode="MultiLine"></asp:TextBox>
            <span class="glyphicon glyphicon-th-large form-control-feedback"></span>
          </div>
              <div class="form-group has-feedback"> 
          <asp:TextBox runat="server" ID="txtAmountJ" class="form-control" placeholder="Amount" onkeyup="checkDec(this);" ></asp:TextBox>
            <span class="glyphicon glyphicon-usd form-control-feedback"></span>
          </div>  
                            
                     <div class="form-group has-feedback"> 
            <asp:Button runat="server" ID="btnJama" class="btn btn-primary" Text="Submit"  OnClick="btnJama_Click"/>
           
          </div>
                    </div>
   
  </div>
  <div id="nave" class="tab-pane fade">
    
    <div class="box-body" >
                    <div class="form-group">
                    <label>Date</label>
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                      </div>
                      <asp:TextBox runat="server" ID="txtDateN" class="form-control"  placeholder="DD-MM-YYYY"  required="required"></asp:TextBox>
                          <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtDateN" >
                                </cc1:CalendarExtender>
                    </div><!-- /.input group -->
                  </div> 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>
                          <asp:Panel ID="Panel1" runat="server">
                       <div class="form-group">  
            <asp:DropDownList runat="server" ID="txtAccountNameN" class="form-control" AppendDataBoundItems="true" OnSelectedIndexChanged="txtAccountNameN_TextChanged" AutoPostBack="true">
                       <asp:ListItem Value="">-- Select Account --</asp:ListItem>
            </asp:DropDownList>
                            <%--  <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtAccountNameN" UseContextKey="True">
                                           </cc1:AutoCompleteExtender>--%>
            <span class="glyphicon form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
            <asp:TextBox runat="server" ID="txtLedgerNoN" class="form-control" placeholder="Ledger No" ReadOnly="true"></asp:TextBox>
            <span class="glyphicon glyphicon-baby-formula form-control-feedback"></span>
          </div> 

                          </asp:Panel>
                          </ContentTemplate>
           </asp:UpdatePanel>
                       <div class="form-group has-feedback"> 
            <asp:TextBox runat="server" ID="txtVoucherNoN" class="form-control" placeholder="Voucher No"></asp:TextBox>
            <span class="glyphicon glyphicon-file form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
            <asp:TextBox runat="server" ID="txtReasonN"  class="form-control" placeholder="Details" TextMode="MultiLine"></asp:TextBox>
            <span class="glyphicon glyphicon-th-large form-control-feedback"></span>
          </div>
              <div class="form-group has-feedback"> 
          <asp:TextBox runat="server" ID="txtAmountN" class="form-control" placeholder="Amount" onkeyup="checkDec(this);" ></asp:TextBox>
            <span class="glyphicon glyphicon-usd form-control-feedback"></span>
          </div>  
                            
                     <div class="form-group has-feedback"> 
            <asp:Button runat="server" ID="btnNave" class="btn btn-primary" Text="Submit"  OnClick="btnNave_Click"/>
          </div>
                    </div>
                             
  </div>
   
</div>
                    <!-- /input-group -->
                 <div class="form-group">
                      <div class="input-group">
                    <div class="input-group-btn">
                      <button class="btn btn-success">
                          <asp:Label ID="lblDateDown" runat="server" Text=""></asp:Label>  Closing Balance</button>
                    </div><!-- /btn-group -->
                     <asp:TextBox runat="server" ID="txtDayEndingAmount" Font-Bold="true" Font-Size="Larger"  class="form-control" ReadOnly="true"></asp:TextBox>
                  </div></div>
                       </div>
                  </div>
                </div> 
             <div class="col-md-7">

              <!-- Profile Image -->
              <div class="box box-danger">
                   <h3 class="text-center"> Today Day Book <a href="PrintEntries.aspx" class="btn btn-adn"> Entry Print</a> <a href="PreviousEntries.aspx" class="btn btn-bitbucket">Previous Entry</a></h3> 
                <div class="box-body" >
                <div class="table-responsive">
<asp:GridView ID="grdAccountBook"  CssClass="table table-striped table-bordered table-hover"  PageSize="10"  AllowPaging="True"  runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gdvAccount_PageIndexChanging"  >
                                         <Columns>
                                
           
                                                <%--  <asp:BoundField DataField="intId" HeaderText="ID" SortExpression="intId" />    --%>        
                <%--  <asp:BoundField DataField="Date" HeaderText="Date"  />  --%>  
                                               <asp:BoundField DataField="Account Code" HeaderText="Day Book No"  />       
                         <asp:BoundField DataField="Account  Name" HeaderText="Account  Name"  />    
                                             <%--  <asp:BoundField DataField="Account Code" HeaderText="Account Code"  />    --%>
                  <asp:BoundField DataField="Details" HeaderText="Details"  />   
                                             <asp:BoundField DataField="Voucher No" HeaderText="Voucher No"  />  
                                               <asp:BoundField DataField="Amount" HeaderText="Amount"  />                                              
                                               <asp:BoundField DataField="Credit / Debit" HeaderText="Credit / Debit"  />       
           <%--  <asp:TemplateField>
                   <HeaderTemplate>Work</HeaderTemplate>
                <ItemTemplate>
              <center>  
                  <asp:LinkButton ID="lnkbtndelet" runat="server" ToolTip="Edit" CommandName="Edits" CommandArgument='<%#Eval("intId") %>'  CssClass="fa fa-2x fa-pencil-square"/>
                 
                  <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Account गाळा" CommandName="Deletes" CommandArgument='<%#Eval("intId") %>'  CssClass="fa fa-2x  fa-trash  " forecolor="red" />
              </center>
            

                </ItemTemplate> 
                </asp:TemplateField>  --%>
        </Columns>   <EmptyDataTemplate>

           Day Book Details Not Available!!

        </EmptyDataTemplate> <PagerSettings Mode="Numeric" />
                                    </asp:GridView>
                </div>
                     

                    </div>
                  </div>
                </div>
                </div>
        </section><!-- /.content -->
        </div>
            </div>
       </div>
        </div>
     
</asp:Content>
