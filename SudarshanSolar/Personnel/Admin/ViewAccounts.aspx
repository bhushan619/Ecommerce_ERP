<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ViewAccounts.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.ViewAccounts" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">
        <!-- Content Header (Page header) -->
        <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">  View Account  </h3>
                     </div>
                  
                    <div class="panel-body container-fluid">
       
     
      <section class="content"> 
                    <!-- Small boxes (Stat box) --> 
                    <div class="row"> 
                         <div class="col-lg-12">
                           <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                             <div class="box  box-info"> 
                                <div class="box-body">  
                                   
                                       <div class="row form-group ">
                                            <div class="col-md-2  col-sm-2"> </div>
                                             
                                                <div class="col-md-6  col-sm-6"> 
                                <div class="form-group "> 
                                           <asp:TextBox ID="txtCmpName" runat="server" class="form-control" 
                                                placeholder="Account Search"  ></asp:TextBox>
                                           
                                        <ajaxToolkit:AutoCompleteExtender ID="txtCmpName_AutoCompleteExtender" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtCmpName" UseContextKey="True">
                                           </ajaxToolkit:AutoCompleteExtender>
                                           
                                        </div>  
                                </div> 
                                                   <div class="col-md-3  col-sm-3">
                                    <div class="form-group">
                                            <asp:LinkButton ID="btnSearch" runat="server" Text="Search" 
                                                CssClass="btn btn-primary " OnClick="btnSearch_Click1"  />
                                          <asp:LinkButton ID="btnReset" runat="server" Text="New  Search" 
                                                CssClass="btn btn-warning " OnClick="btnReset_Click"   />
                                                </div>
                                                
                                                </div>
                                           </div>

                                    <div class="row ">
                   <%--     <h3>Employee List</h3>--%>
 
    
                        
                                  <div class="col-md-8 table-responsive">
                                       <div class="box box-warning">
                <div class="box-body" >
                    <div class="table-responsive">
                                    <asp:GridView ID="gdvAccount"  CssClass="table table-striped table-bordered table-hover"  PageSize="10"  AllowPaging="True"  runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gdvAccount_PageIndexChanging" OnRowCommand="gdvAccount_RowCommand" >
                                         <Columns>
                                
           
                                                <%--  <asp:BoundField DataField="intId" HeaderText="ID" SortExpression="intId" />    --%>        
                  <asp:BoundField DataField="Account Code" HeaderText="Account Code"  />      
                         <asp:BoundField DataField="Account  Name" HeaderText="Account  Name"  />    
                  <asp:BoundField DataField="Mobile No" HeaderText="Mobile No"  />   
                                               <asp:BoundField DataField="Phone No" HeaderText="Phone No"  />  
                                               <asp:BoundField DataField="Email" HeaderText="Email"  />  
                                               <asp:BoundField DataField="Address" HeaderText="Address"  />           
          
                     

            <asp:TemplateField>
                   <HeaderTemplate>Work</HeaderTemplate>
                <ItemTemplate>
           
                  <asp:LinkButton ID="lnkbtndelet" runat="server"  ToolTip="Edit" CommandName="Edits" CommandArgument='<%#Eval("intId") %>'  CssClass="icon md-edit btn-xs  btn btn-warning"/>
                 
                   <asp:LinkButton ID="lnkDelete" runat="server"  ToolTip="Account Delet" CommandName="Deletes" CommandArgument='<%#Eval("intId") %>'  CssClass="icon md-delete btn-xs  btn btn-danger"  />
             
            

                </ItemTemplate> 
                </asp:TemplateField>  
        </Columns>   <EmptyDataTemplate>
         <div class="alert alert-dismissable alert-info "  style="width:100%" >
						                                                <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
			</div>

        </EmptyDataTemplate> <PagerSettings Mode="Numeric" />
                                    </asp:GridView></div>
                                 </div>
                                           </div></div>
      <div class="col-md-4">

              <!-- Profile Image -->
              <div class="box box-primary">
                <asp:Panel class="box-body" id="myform" runat="server"  >
                    <div class="form-group has-feedback"> 
            Account Code : &nbsp;<asp:Label id="txtacccode"  runat="server" Font-Bold="true" ></asp:Label>
          
          </div>
                       <div class="form-group has-feedback"> 
            <asp:TextBox id="txtaccname"    class="form-control" placeholder="Account  Name"   required="required"  oninvalid="this.setCustomValidity('Accountची माहिती टाका.')" onchange="this.setCustomValidity('')" runat="server"></asp:TextBox>
            <span class="glyphicon glyphicon-user form-control-feedback"></span>
          </div>  
                      <div class="form-group has-feedback"> 
               <asp:TextBox id="txtaccmobile"  class="form-control" placeholder="Mobile No"  required="required" pattern="[7-9]{1}[0-9]{9}"  oninvalid="this.setCustomValidity('Mobile No टाका.')" onchange="this.setCustomValidity('')" runat="server"></asp:TextBox> 
            <span class="glyphicon glyphicon-phone form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
               <asp:TextBox id="txtaccphone"  class="form-control" placeholder="Phone No" runat="server" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" ></asp:TextBox>
            <span class="glyphicon glyphicon-phone form-control-feedback"></span>
          </div>
                
                            <div class="form-group has-feedback"> 
               <asp:TextBox id="txtaccEmail"  class="form-control" placeholder="Email" runat="server"  pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum|in|co.in)"></asp:TextBox>
            <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
                <asp:TextBox id="txtaccaddress"  class="form-control" placeholder="Address" TextMode="MultiLine" runat="server"></asp:TextBox>
            <span class="glyphicon glyphicon-home form-control-feedback"></span>
          </div>
                  
                     <div class="form-group has-feedback"> 
     <asp:Button ID="btnsubmit" class="btn btn-success" runat="server" Text="Submit" OnClick="btnsubmit_Click"/>
                           <asp:Button ID="btncancel" class="btn btn-danger" runat="server" Text="Cancel" OnClick="btncancel_Click"/>
          </div>
                    </asp:Panel>
                  </div>
                </div>
                                
                 </div>                     
                                </div><!-- /.box-body -->
                           </div>
              </div>
                    </div><!-- /.row -->
                    <!-- top row -->
                   
                </section><!-- /.content -->
        </div>
            </div>
       </div>
      </div><!-- /.content-wrapper -->
</asp:Content>
