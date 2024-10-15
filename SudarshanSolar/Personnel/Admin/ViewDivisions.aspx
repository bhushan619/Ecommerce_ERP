<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ViewDivisions.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.ViewDivisions" %>
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
                      <h3 class="panel-title">View Division</h3>
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
                                                placeholder="Search Division"  ></asp:TextBox>
                                           
                                           <cc1:AutoCompleteExtender ID="txtCmpName_AutoCompleteExtender" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtCmpName" UseContextKey="True">
                                           </cc1:AutoCompleteExtender>
                                           
                                        </div>  
                                </div> 
                                                   <div class="col-md-3  col-sm-3">
                                    <div class="form-group">
                                            <asp:LinkButton ID="btnSearch" runat="server" Text="Search" 
                                                CssClass="btn btn-primary " OnClick="btnSearch_Click1"  />
                                          <asp:LinkButton ID="btnReset" runat="server" Text="Reset" 
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
                                    <asp:GridView ID="gdvDivision"  CssClass="table table-striped table-bordered table-hover"  PageSize="10"  AllowPaging="True"  runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gdvDivision_PageIndexChanging" OnRowCommand="gdvDivision_RowCommand" >
                                         <Columns>
                                
           
                                                <%--  <asp:BoundField DataField="intId" HeaderText="ID" SortExpression="intId" />    --%>        
                  <asp:BoundField DataField="Division Code" HeaderText="Division Code"  />      
                         <asp:BoundField DataField="Division Name" HeaderText="Division Name"  />    
                  <asp:BoundField DataField="Division Work" HeaderText="Division Work"  />            
          
                     

            <asp:TemplateField>
                   <HeaderTemplate>Work</HeaderTemplate>
                <ItemTemplate>
             
                  <asp:LinkButton ID="lnkbtndelet" runat="server" ToolTip="Edit Division"  CommandName="Edits" CommandArgument='<%#Eval("intId") %>'  CssClass=" icon md-edit btn-xs  btn btn-warning"/>
                 
                   <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete Division"  CommandName="Deletes" CommandArgument='<%#Eval("intId") %>'  CssClass="icon md-delete btn-xs  btn btn-danger" />
           
            

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
            <asp:TextBox  id="txtdcode" class="form-control" runat="server" placeholder="Division Code" required="required"  oninvalid="this.setCustomValidity('विभागाची माहिती टाका.')" onchange="this.setCustomValidity('')"></asp:TextBox>
            <span class="glyphicon glyphicon-th form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
              <asp:TextBox runat="server" id="txtdname" class="form-control" placeholder="Division Name" required="required" oninvalid="this.setCustomValidity('विभागाची माहिती टाका.')" onchange="this.setCustomValidity('')"></asp:TextBox>
            <span class="glyphicon glyphicon-user form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
               <asp:TextBox runat="server" id="txtdwork" class="form-control" placeholder="Division Work" TextMode="MultiLine" required="required" oninvalid="this.setCustomValidity('विभागाची माहिती टाका.')" onchange="this.setCustomValidity('')"></asp:TextBox>
            <span class="glyphicon glyphicon-file form-control-feedback"></span>
          </div>
                      
                     <div class="form-group has-feedback"> 
                         <asp:Button ID="btnsubmit" runat="server" Text="Update"   OnClick="btnsubmit_Click" class="btn btn-success"/>  
                          <asp:Button ID="btncancel" class="btn btn-danger" runat="server" Text="Cancel" OnClick="btncancel_Click"/>
          </div>
                     </asp:Panel>
                    </div>
                  </
                </div>
                                
                 </div>                     
                                </div><!-- /.box-body -->
                           </div>
              </div>
                    </div><!-- /.row -->
                    <!-- top row -->
                   
                </section>
                        </div>
            </div>
       </div>
        </div>
<!-- /.content -->
        
</asp:Content>
