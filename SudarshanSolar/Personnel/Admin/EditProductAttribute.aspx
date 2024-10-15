<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="EditProductAttribute.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.EditProductAttribute" %>

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
                      <h3 class="panel-title">Edit Attributes of : <asp:Label ID="lblProductName" runat="server" CssClass="label label-outline label-primary" Text=""></asp:Label>  </h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                               <div class="row">
                                   <div class="col-md-6"  >
                                             <div class="form-group">
                                      <label class="control-label">Attributes</label>
                                        <asp:DropDownList ID="ddproductVariations" CssClass="form-control" runat="server">
                                              <asp:ListItem Value="0">:: Attributes ::</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>
                                  <div class="form-group">
                                       <asp:Label runat="server">Value</asp:Label>
                                     <asp:TextBox ID="txtAttributeValue"  runat="server" class="form-control" ></asp:TextBox>
                                           
                                    </div>
                                              
                                               <div class="form-group"> 
                                                 <asp:Button ID="btnupdate" CssClass="btn btn-warning" OnClick="Btnupdate_Click" Enabled="false" runat="server" Text="Update" />
                                              <a ID="btncancle" class="btn btn-danger" href="Default.aspx" runat="server" Text="Cancel" >Cancel</a>
      
                                        </div>   
                                      <div class=" form-group">
                                               <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                                       </div>   
                     
                                   </div>
                                       <div class="col-md-6"  >
                                           <div class="  table-responsive">
                                                     
                                                      <asp:ListView ID="lstType" runat="server" OnPagePropertiesChanging="OnPagePropertiesChanging" OnItemCommand="lstType_ItemCommand" >
                                                 
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
                                                     
                                                     <ItemTemplate>
                                                         <tr style="">
                                                            
                                                           <td>  <asp:Label ID="lblSRNO" runat="server"  Text='<%#Container.DataItemIndex+1 %>'></asp:Label></td>
                                          
                                                               <td>   <asp:Label Text='<%# Eval("varVariation") %>' runat="server" ID="Label1" /></td>

                                                               <td>   <asp:Label Text='<%# Eval("varVariationValue") %>' runat="server" ID="Label3" /></td>
                                                              
                                                           

                                                           <td><asp:LinkButton  ID="lnkListEdit" CommandArgument='<%# Eval("variationId") %>' CommandName="Edits"  runat="server"  CssClass="icon md-edit btn-xs  btn btn-warning" ToolTip="Edit Attribute" /></td>
                                                                <td><asp:LinkButton  ID="lnkListDelete" CommandArgument='<%# Eval("variationId") %>' CommandName="Delets"  runat="server" CssClass="icon md-delete btn-xs  btn btn-danger" ToolTip="Delete Attribute" /></td>
                                                             
                                                         </tr>
                                                     </ItemTemplate>
                                                     <LayoutTemplate>
                                                       
                                                                     <table runat="server" id="itemPlaceholderContainer" cellpadding="1" class="table table-bordered table-hover" >
                                                                         <tr id="Tr1" runat="server" class="">
                                                                            
                                                                             <th id="Th2" runat="server">SrNo</th>
                                                                        
                                                                              <th id="Th3" runat="server">Attribute</th>
                                                                              <th id="Th5" runat="server"> Value</th>
                                                                               
                                                                              <th id="Th1" runat="server" colspan="2">Operation</th>                                                                       
                                                                         </tr>
                                                                         <tr runat="server" id="itemPlaceholder"></tr>
                                                                     </table>
                                                     </LayoutTemplate>
                                                     
                                                 </asp:ListView>   
                                            </div>
                                         <div class="panel-footer">
                                              <div class="text-right">
                                                   
                                                     <asp:DataPager ID="DataPager1" runat="server"  PagedControlID="lstType" PageSize="10">
                                                          <Fields  >
                                                           <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-primary btn-xs" ShowFirstPageButton="True" ShowPreviousPageButton="False"   FirstPageText="< First "   ShowNextPageButton="false" />
                                                              <asp:NumericPagerField ButtonType="Link"  />
                                                             <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-primary btn-xs" ShowNextPageButton="False" ShowLastPageButton="True" ShowPreviousPageButton = "false"  LastPageText=" Last >"/>
                                                      </Fields>
                                                          </asp:DataPager>
                                                     </div>
                                 </div>
                      </div>
                               </div> 
                     
                   </div>
              
          </div>
   </div>
</div>          
</asp:Content>
