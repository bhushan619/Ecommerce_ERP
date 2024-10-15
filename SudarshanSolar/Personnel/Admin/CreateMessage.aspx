<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="CreateMessage.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.CreateMessage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page animsition">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <div class="page-content">
    
                      <div class="row">
                  <div class="col-md-6">                     
         <div class="panel ">
                        <div class="panel-heading">
                 <h3 class="panel-title"><i class="icon md-email" ></i> Create Message</h3>
                        </div>
                      
                      <div class="panel-body"> 
                          <div class="form-group" align="right"> 
                          
                               <asp:Label ID="Label1" runat="server" Text="Date:"></asp:Label> <asp:Label ID="lbldate" runat="server"  ></asp:Label>&nbsp;&nbsp;
                               <asp:Label ID="Label2" runat="server" Text="Time:"></asp:Label> <asp:Label ID="lblTime" runat="server"  ></asp:Label>
                               </div>
                                <div class="form-group">
                                 <asp:Label ID="Label3" runat="server" Text="Select list"></asp:Label>
                          <asp:DropDownList ID="ddlSelectDesig" runat="server"  class="form-control"
                                
                                        onselectedindexchanged="ddlSelectDesig_SelectedIndexChanged" 
                                        AutoPostBack="True">
                                   <asp:ListItem Text="-- Select List --" />
                                   <asp:ListItem Text="Employee" />
                                   <asp:ListItem Text="Customer" />
             </asp:DropDownList>
                      <div class="form-group">
                       <asp:Label ID="Label4" runat="server" Text="Select Member"></asp:Label>
                          <asp:DropDownList ID="ddlDesigs" runat="server"  class="form-control" 
                                  DataSourceID="SqlDataSource1"  AppendDataBoundItems="true" 
                             >
                                   <asp:ListItem Text="-- Select --" />
             </asp:DropDownList>
                              <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                  ConnectionString="<%$ ConnectionStrings:solarConnectionString %>" 
                                  ProviderName="<%$ ConnectionStrings:solarConnectionString.ProviderName %>" 
                                  ></asp:SqlDataSource>
                                  </div>
                           
<div class="form-group">
    <asp:Label ID="lblEnqSub" runat="server" Text="Enquiry Subject"></asp:Label>
                <asp:TextBox ID="txtSubject" runat="server" class="form-control" 
                 placeholder="Enter Subject"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject"
                                ErrorMessage="*"  SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>

 <div class="form-group">
                            <asp:Label ID="lblEnqDesc" runat="server" Text="Enquiry Description"></asp:Label>
                  <asp:TextBox ID="txtMsg" runat="server" class="form-control" 
                                        placeholder="Enter Message" TextMode="MultiLine" ></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMsg"
                                ErrorMessage="*"  SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </div>

<div class="form-group">
  <asp:Button ID="btnSend" runat="server" Text="SEND" class="btn btn-success" onclick="btnSend_Click"></asp:Button>
                               &nbsp;&nbsp; &nbsp;&nbsp;
                                     <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                class="btn btn-danger" onclick="btnCancel_Click" CausesValidation="False"></asp:Button>
                        </div>  
                                      <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                </div>
                        </div>
                    </div>
                 </div>
             
             <div class="col-md-6">                     
         <div class="panel">
                <div class="panel-heading">
                  <h3 class="panel-title"><i class="icon md-card-giftcard" ></i> Today's Birthdays</h3>
                </div> 
                      <div class="panel-body"> 
                      <div class="table-responsive">
                          <asp:ListView ID="lstBirthdays" runat="server" 
                              DataSourceID="SqlDataSourceBirthdays"> 
                              <EmptyDataTemplate>
                                  <table runat="server" style="">
                                      <tr>
                                          <td>
                                              No data was returned.</td>
                                      </tr>
                                  </table>
                              </EmptyDataTemplate>
                                
                              <ItemTemplate>
                                  <tr style="">
                                      <td>
                                          <asp:Label ID="Company_NameLabel" runat="server" 
                                              Text='<%# Eval("[Company Name]") %>' />
                                      </td>
                                      <td>
                                          <asp:Label ID="Representative_NameLabel" runat="server" 
                                              Text='<%# Eval("[Representative Name]") %>' />
                                      </td>
                                      <td>
                                          <asp:Label ID="DesignationLabel" runat="server" 
                                              Text='<%# Eval("Designation") %>' />
                                      </td>
                                      <td>
                                          <asp:Label ID="ContactLabel" runat="server" Text='<%# Eval("Contact") %>' />
                                      </td>
                                     
                                  </tr>
                              </ItemTemplate>
                              <LayoutTemplate>
                                  <table runat="server">
                                      <tr runat="server">
                                          <td runat="server">
                                              <table ID="itemPlaceholderContainer" runat="server" border="0" class="table table-striped table-bordered table-hover">
                                                  <tr runat="server" style="">
                                                      <th runat="server">
                                                          Company Name</th>
                                                      <th runat="server">
                                                          Representative Name</th>
                                                      <th runat="server">
                                                          Designation</th>
                                                      <th runat="server">
                                                          Contact</th>                                                     
                                                  </tr>
                                                  <tr ID="itemPlaceholder" runat="server">
                                                  </tr>
                                              </table>
                                          </td>
                                      </tr>
                                      <tr runat="server">
                                          <td runat="server" style="">
                                              <asp:DataPager ID="DataPager1" runat="server">
                                                  <Fields>
                                                      <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                                          ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                      <asp:NumericPagerField />
                                                      <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                                          ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                  </Fields>
                                              </asp:DataPager>
                                          </td>
                                      </tr>
                                  </table>
                              </LayoutTemplate>
                               
                          </asp:ListView>
                          <asp:SqlDataSource ID="SqlDataSourceBirthdays" runat="server" 
                              ConnectionString="<%$ ConnectionStrings:solarConnectionString %>" 
                              ProviderName="<%$ ConnectionStrings:solarConnectionString.ProviderName %>" 
                              SelectCommand="SELECT tblsucustomer.varCompanyName AS `Company Name`, tblsucustomerotherdetails.varRepName AS `Representative Name`, tblsucustomerotherdetails.varDesignation AS Designation, tblsucustomerotherdetails.varContact AS Contact, tblsucustomerotherdetails.varDOB FROM tblsucustomer INNER JOIN tblsucustomerotherdetails ON tblsucustomer.intId = tblsucustomerotherdetails.intCustId  WHERE SUBSTRING(tblsucustomerotherdetails.varDOB,1,5) = SUBSTRING(DATE_FORMAT(CURRENT_DATE(),'%d-%m-%Y'),1,5)">
                          </asp:SqlDataSource>
                      </div>
                      </div>
                </div></div>
             <!--/.ROW-->
             

            </div>
                            </div>
          </div>
     
</asp:Content>
