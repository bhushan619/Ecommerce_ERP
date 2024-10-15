<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.AddProduct" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">

<div class="row">
             <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
    <div class="col-md-4 col-sm-4 ">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title"><i class="icon md-star" aria-hidden="true"></i>Add Product</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                                 <div class="row">
                      

                    <div class="form-group">
                      <label class="control-label">Product-Type</label>
                        <asp:DropDownList ID="ddproducttypeid" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddproducttypeid_SelectedIndexChanged">
                              <asp:ListItem Value="0">:: Product Type ::</asp:ListItem>
                        </asp:DropDownList>               
                      </div>

                       <div class="form-group">
                      <label class="control-label">Product-SubType</label>
                        <asp:DropDownList ID="ddproductsubtype" AutoPostBack="true" CssClass="form-control" runat="server">
                              <asp:ListItem Value="0">:: Product SubType ::</asp:ListItem>
                        </asp:DropDownList>               
                      </div>
                                          <div class="form-group">
                                           <asp:Label runat="server">Product Name</asp:Label>
                                           <asp:TextBox ID="txtProductName" runat="server"  class="form-control" ></asp:TextBox>
                                           
                                 </div> 
                                       <div class="form-group  row">
                                                 <div class="col-sm-6">
                                                     <asp:Label runat="server">Product Code</asp:Label>
                                                               <asp:TextBox ID="txtProdCode" runat="server" class="form-control" ></asp:TextBox>                                          
                                                           </div>
                                            <div class="col-sm-6"> 
                                                 <asp:Label runat="server">Purchase Price</asp:Label>
                                           <asp:TextBox ID="txtPurchasePrice" runat="server" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"  class="form-control"></asp:TextBox>                                          
                                             </div>
                                           </div>
                                     <div class="form-group  row">
                                          <div class="col-sm-6"> 
                                              <asp:Label runat="server">Dealer Price</asp:Label>
                                           <asp:TextBox ID="txtDealerPrice" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"  runat="server" class="form-control"></asp:TextBox>                                          
                                      
                                               </div>
                                          <div class="col-sm-6">
                                            <asp:Label runat="server">MRP</asp:Label>
                                                <asp:TextBox ID="txtMRP" runat="server" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"  class="form-control"></asp:TextBox>                                          
                                            </div>
                                     </div>
                                      <div class="form-group">
                                           <asp:Label runat="server">Product Short Description</asp:Label>
                                           <asp:TextBox ID="txtShortDesc" runat="server"  class="form-control" ></asp:TextBox>                                          
                                        </div>
                                    
                                 <div class="form-group">
                                           <asp:Label runat="server">Product Long Description</asp:Label>
                                           <asp:TextBox ID="txtLongDesc" runat="server"  class="form-control" TextMode="MultiLine"></asp:TextBox>                                          
                                        </div>
                                     </div>
                   </div>              
          </div>
            </div>
    
          
    
     <div class="col-md-4 col-sm-4">
       <div class="panel">
            <div class="panel-heading">
              <h3 class="panel-title">Attributes</h3>
            </div>
            <div class="panel-body">
             <%--   <div class="row">
                    <div class="col-md-5 col-lg-5">--%>
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
                                       <asp:LinkButton ID="btnAdd"  runat="server"    Text="Add" CssClass="btn btn-primary"  OnClick="btnAdd_Click" />
                                  </div>

                  <%--  </div>
                       <div class="col-md-7 col-lg-7">--%>
                               <div class="table-responsive">
                           
                            <asp:GridView ID="grdOrderDetails" runat="server"  
                                CssClass="table table-striped table-bordered " 
                                onrowcommand="grdOrderDetails_RowCommand"  OnRowDataBound="grdOrderDetails_RowDataBound"  >  
                                <Columns>
                                       <asp:TemplateField>
                                       <ItemTemplate>
                                       <asp:LinkButton ID="lnkreomve" runat="server" Text="" ToolTip="Remone" CommandName="remove" 
                                       CommandArgument='<%#Container.DataItemIndex%>' CssClass="icon md-delete" />
                                       </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField>
                                           <HeaderTemplate>SrNo</HeaderTemplate>
                                       <ItemTemplate>
                                       <asp:Label ID="lnkreomveddf" runat="server" 
                                       Text='<%#Container.DataItemIndex+1%>' />
                                       </ItemTemplate>
                                       </asp:TemplateField>
        
                                   <%--    <asp:BoundField  HeaderText="Id" Visible="false" DataField="AttributeID" ConvertEmptyStringToNull="true" />
                                       <asp:BoundField  HeaderText="Attribute"  DataField="Attribute" ConvertEmptyStringToNull="true" />
                                       <asp:BoundField  HeaderText="Value"  DataField="Value" ConvertEmptyStringToNull="true" />--%>
                                  </Columns>
                                
                            </asp:GridView>
                         </div>
                           </div>
                    </div>
                </div>
          
     <div class="col-md-4 col-sm-4">
   <div class="panel">
            <div class="panel-heading">
              <h3 class="panel-title">Product Image Gallary</h3>
            </div>
            <div class="panel-body">
                 <%-- <div class="row">
                     
                                          <div class="col-md-5 col-lg-5">
                        --%>
                                        <div class="form-group">
                                                  <asp:Label ID="Label7" runat="server" Text="Product Primary Image"  ></asp:Label>
                                                    <div class="">
                                                        <div class="fileupload fileupload-new" data-provides="fileupload"> 
                                                            <div>
                                                            <input ID="fupProPic" type="file" name="file" onchange="previewFile()"  runat="server" accept='image/*' />
                                                                        
                                                            </div>
                                                        </div>
                                                    </div>
                                         </div>
                                                <div class="form-group">
                            	                        Room Gallary
                                                     <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
                                                 <asp:Label ID="lblImgMessage" runat="server" ForeColor="#FF3300" Text=""></asp:Label>
                                                </div>
                                                     
                                          <%-- </div>
                         <div class="col-md-6 col-lg-6">--%>
                                 
                                       <asp:Image ID="ImgCust" CssClass="fileupload-preview thumbnail" style="width: 200px; height: 180px;float:none"  runat="server" ImageUrl="~/media/Product/NoProfile.png" />
                                <script type="text/javascript">
                                    function previewFile() {

                                        var preview = document.querySelector('#<%=ImgCust.ClientID %>');
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
                                                      <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-success"  OnClick="btnsubmit_Click"/>
                                                         <a ID="btncancle" class="btn btn-danger" href="Default.aspx" runat="server" Text="Cancel" >Cancel</a>
                                             </div>
                             </div>
							
                       
                      </div>
            </div>
   </div>

                  
        </div>
   </div>    
</asp:Content>
