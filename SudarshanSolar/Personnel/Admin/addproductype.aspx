<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="addproductype.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.addproductype" %>

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
                      <h3 class="panel-title"><i class="icon md-case" aria-hidden="true"></i>Add Product Type</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                          <div class="row">
                                     
                    <div class="form-group">

                      <label class="control-label ">Product-Type</label>
                      
<asp:TextBox ID="txtproducttypenm" CssClass="form-control" runat="server"></asp:TextBox>
                   </div>
                  
                    <div class="form-group">

                      <label class="control-label">Description</label>
                    
         <asp:TextBox ID="txtdescription" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>           
                           
                  </div> 
                            <div class="form-group ">
                                         <label for="lblage" class=" control-label">Upload Image</label>
                                     
                                  <input id="fupProPic" type="file" name="file" class="fileinput-new"  onchange="previewFile()"  runat="server" accept='image/*' />
                                
                                      </div>
                      
                                    <div class="form-group ">
                                         <label for="lblage" class=" control-label"></label>
                                      
                                 <asp:Image ID="ImgProfile" CssClass="fileupload-preview circle" style="width: 150px; height: 150px;float:none"  runat="server" ImageUrl="~/Media/Product/NoProfile.png" />
                                        
                                      </div>
                                
                         <script type="text/javascript">
                              function previewFile() {

                                  var preview = document.querySelector('#<%=ImgProfile.ClientID %>');
                                  var file = document.querySelector('#<%=fupProPic.ClientID %>').files[0];
                                  var reader = new FileReader();

                                  reader.onloadend = function () {
                                      preview.src = reader.result;
                                  }

                                  if (file) {
                                      reader.readAsDataURL(file);
                                  } else {
                                      preview.src = "";
                                  }
                              }
                              </script>

               
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
              <h3 class="panel-title"><i class="icon md-eye" aria-hidden="true"></i>View Product Type</h3>
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
                                              <%--  <asp:Label Text='<%# Eval("intid") %>' runat="server" ID="lblTaskId" Visible="false"  />--%>
                                                            <%-- <td> <asp:Label Text='<%# Eval("vardocnm") %>' runat="server" ID="varAccountHolderName" /></td--%>
                                                             <%--  <td> <asp:Label Text='<%# Eval("vardocnm") %>' runat="server" ID="Label1" /></td>--%>
                                                            
                                                               <td>   <asp:Label Text='<%# Eval("varTypeName") %>' runat="server" ID="Label1" /></td>

                                                               <td>   <asp:Label Text='<%# Eval("varDescription") %>' runat="server" ID="Label3" /></td>
                                                                <td>   <asp:Label Text='<%# Eval("varIsActive") %>' runat="server" ID="Label4" /></td>
                                                            
<%--                                                              <img src='<%#Eval("~/Document/") %>' alt=""  runat="server" />--%>

                                                            <%--  <td>   <asp:Image ImageUrl='"~/Document/"+ <%# Eval("vardocimg")%>' runat="server" ID="varAccountNo" /></td>--%>
                                                              	  <td>   <asp:Label Text='<%# Eval("varcreateddate") %>' runat="server" ID="Label2" /></td>
                                                              	 
                                                           

                                                           <td><asp:LinkButton  ID="lnkListEdit" CommandArgument='<%# Eval("intProdTypeId") %>' CommandName="Edits"  runat="server" ToolTip="Edit"  CssClass=" icon md-edit btn-xs  btn btn-warning"/></td>
                                                              <td><asp:LinkButton  ID="lnkListDelete" CommandArgument='<%# Eval("intProdTypeId") %>' CommandName="Delets"  runat="server" ToolTip="Delete"  CssClass=" icon md-delete btn-xs  btn btn-danger"/></td>
                                                              
                                                         </tr>
                                                     </ItemTemplate>
                                                     <LayoutTemplate>
                                                       
                                                                     <table runat="server" id="itemPlaceholderContainer" cellpadding="1" class="table table-bordered table-hover" >
                                                                         <tr id="Tr1" runat="server" class="">
                                                                            
                                                                             <th id="Th2" runat="server">SrNo</th>
                                                                            <%-- <th id="Th3" runat="server">Document ID</th>--%>
                                                                              <th id="Th3" runat="server">Product Type</th>
                                                                              <th id="Th5" runat="server"> Description</th>
                                                                                 <th id="Th6" runat="server">Is Active</th>
                                                                                 <th id="Th4" runat="server">Created date</th>
                                                                          
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
