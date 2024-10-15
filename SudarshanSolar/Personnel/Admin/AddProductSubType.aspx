<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddProductSubType.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.AddProductSubType" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <div class="page animsition">
   <div class="page-content">
       <div class="row">
          <div class="col-md-4 col-sm-4 ">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title"><i class="icon md-case" aria-hidden="true"></i>Add Product SubType</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                          <div class="row">
                                 <div class="form-group">

                      <label class="control-label">Product-Type </label>
                        <asp:DropDownList ID="ddproducttypeid" AutoPostBack="true" CssClass="form-control" runat="server">
                              <asp:ListItem Value="0">:: Product Type ::</asp:ListItem>
                        </asp:DropDownList>

               
                </div>
                                     
                    <div class="form-group">

                      <label class="control-label ">Product-SubType</label>
                      
<asp:TextBox ID="txtproducttypenm" CssClass="form-control" runat="server"></asp:TextBox>
                   </div>
                  
                    <div class="form-group">

                      <label class="control-label">Description</label>
                    
         <asp:TextBox ID="txtdescription" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>           
                           
                  </div> 
                     <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                  <div class="checkbox checkbox-success">
                                  <asp:CheckBox ID="chkIsActive" runat="server" />
                 
                    <label for="checkbox33">Is Active </label>
                  </div>
                </div>
              </div>
              <div class="form-group">
 
<asp:Button ID="btnsubmit" class="btn btn-success" runat="server" OnClick="btnsubmit_Click" Text="Submit" />
                  <asp:Button ID="btnupdate" class="btn btn-warning" OnClick="Btnupdate_Click" Visible="false" runat="server" Text="Update" />
                  <asp:LinkButton ID="btncancle" class="btn btn-danger" OnClick="btncancle_Click" runat="server" Text="Cancel" />
               <%-- <button type="submit" class="btn btn-success"> <i class="fa fa-check"></i> Save</button>
                <button type="button" class="btn btn-default">Cancel</button>--%>
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
              <h3 class="panel-title"><i class="icon md-eye" aria-hidden="true"></i>View Product SubType</h3>
            </div>
            <div class="panel-body">
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

                                                              <td>   <asp:Label Text='<%# Eval("varTypeName") %>' runat="server" ID="Label5" /></td>
                                                               <td>   <asp:Label Text='<%# Eval("varSubTypeName") %>' runat="server" ID="Label1" /></td>

                                                               <td>   <asp:Label Text='<%# Eval("varDescription") %>' runat="server" ID="Label3" /></td>
                                                                <td>   <asp:Label Text='<%# Eval("varIsActive") %>' runat="server" ID="Label4" /></td>
                                                            
                            <%--   	  <td>   <asp:Label Text='<%# Eval("varcreateddate") %>' runat="server" ID="Label2" /></td>--%>
                                                              	 
                                                           

                                                           <td><asp:LinkButton  ID="lnkListEdit" CommandArgument='<%# Eval("intProdSubTypeId") %>' CommandName="Edits"  runat="server"  ToolTip="Edit"  CssClass=" icon md-edit btn-xs  btn btn-warning"/></td>
                                                              <td><asp:LinkButton  ID="lnkListDelete" CommandArgument='<%# Eval("intProdSubTypeId") %>' CommandName="Delets"  runat="server" ToolTip="Delete"  CssClass=" icon md-delete btn-xs  btn btn-danger"/></td>
                                                              
                                                         </tr>
                                                     </ItemTemplate>
                                                     <LayoutTemplate>
                                                       
                                                                     <table runat="server" id="itemPlaceholderContainer" cellpadding="1" class="table table-bordered table-hover" >
                                                                         <tr id="Tr1" runat="server" class="">
                                                                            
                                                                             <th id="Th2" runat="server">SrNo</th>
                                                                             <th id="Th3" runat="server">Product Type</th>
                                                                              <th id="Th32" runat="server">Product SubType</th>
                                                                              <th id="Th5" runat="server"> Description</th>
                                                                                 <th id="Th6" runat="server">Is Active</th>
                                                                              <%--   <th id="Th4" runat="server">Created date</th>--%>
                                                                          
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

