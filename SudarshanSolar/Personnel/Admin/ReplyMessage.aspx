<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ReplyMessage.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.ReplyMessage" %>
        
        <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page animsition">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <div class="page-content">
       <div class="row">
                 <div class="col-md-6 col-sm-6">
                     <div class="panel panel">

   <div class="panel-heading">
                        <h3 class="panel-title"><i class="icon md-email-open" ></i>   Conversation</h3>
                        </div>  
                          <div class="panel-body">   
                        <div class="table-responsive">
                        <div  >
                        <label> Subject:</label>  <asp:Label ID="lblSubject" runat="server" Text="Message Subject"></asp:Label>
                       <br />
                       <label> Content:</label> 
                        </div>
      <asp:ListView ID="lstFullMessage" runat="server" 
                                DataSourceID="SqlDataSourceFull" DataKeyNames="intId" 
                             > 
                                <AlternatingItemTemplate>
                                    <tr style="">
                                        
                                        <td align="left">
                                            <asp:Label ID="nvarMsgFromLabel" runat="server" 
                                                Text='<%# Eval("nvarMsgFrom") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="nvarMsgToLabel" runat="server" Text='<%# Eval("nvarMsgTo") %>' />
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                 
                                <EmptyDataTemplate>
                                    <table id="Table1" runat="server" style="">
                                        <tr>
                                            <td>
                                                Please Click Message Subject To View</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate> 
                                <ItemTemplate>
                                    <tr style="">
                                         
                                        <td align="left">
                                            <asp:Label ID="nvarMsgFromLabel" runat="server" 
                                                Text='<%# Eval("nvarMsgFrom") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="nvarMsgToLabel" runat="server" Text='<%# Eval("nvarMsgTo") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate> 
                                <LayoutTemplate>
                                    <table id="Table2" runat="server">
                                        <tr id="Tr1" runat="server">
                                            <td id="Td1" runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0"  class=" table table-striped table-bordered table-hover">
                                                    <tr id="Tr2" runat="server" style="">
                                                        
                                                        <th id="Th1" runat="server">
                                                         Recieved   </th>
                                                        <th id="Th2" runat="server">
                                                         Sent   </th>
                                                    </tr>
                                                    <tr ID="itemPlaceholder" runat="server">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="Tr3" runat="server">
                                            <td id="Td2" runat="server" style="">
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                                 
                                 
                                 
                            </asp:ListView> 
                            <asp:SqlDataSource ID="SqlDataSourceFull" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:solarConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:solarConnectionString.ProviderName %>" 
                             >
                            </asp:SqlDataSource>
                        </div>
                        </div>
                                          
                          </div>
                        
                      </div>
                  <div class="col-md-6">                     
         <div class="panel panel">
                        <div class="panel-heading">
             <h3 class="panel-title"><i class="icon md-mail-reply" ></i>   Reply Message</h3>
                        </div>
                        <div class="panel-body"> 
                                                <div class="form-group "> 
                                                    <asp:TextBox ID="txtreplyadminmsg" runat="server" class="form-control"  TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                                 <div class="form-group">
                               <asp:Button ID="btnreply"  runat="server" Text="Send" class="btn btn-success" onclick="btnUpdate_Click" 
                                                  />
                                                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                                  class="btn btn-danger " onclick="btnCancel_Click" />
                                        </div> 
                              <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                        </div>
                        </div>
                    </div>
                
                 </div>
        </div>
        </div>
</asp:Content>
