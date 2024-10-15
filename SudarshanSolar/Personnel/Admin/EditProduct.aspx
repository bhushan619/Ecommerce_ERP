<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.EditProduct" %>
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
    <div class="col-md-12 col-sm-4">
      <div class="panel">
           
                     <div class="panel-heading">

                      <h3 class="panel-title"><i class="icon md-star" aria-hidden="true"></i>Edit Product</h3>
                      <div class="panel-actions">
                    <a href="EditProductGallary.aspx" class="btn btn-warning waves-effect waves-light"><i class="icon md-upload" aria-hidden="true"></i>Edit Gallary</a>
                    <a href="EditProductAttribute.aspx" class="btn btn-primary waves-effect waves-light"><i class="icon md-edit" aria-hidden="true"></i> Edit Attributes</a>
    
              </div></div>
                  
                    <div class="panel-body container-fluid">  
                                 <div class="row">
                      <div class="col-md-4 col-sm-4">

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
                           <div class="form-group  ">
                                                
                                                     <asp:Label runat="server">Product Code</asp:Label>
                                                               <asp:TextBox ID="txtProdCode" runat="server"  class="form-control" ></asp:TextBox>                                          
                                                           </div> 
                       
                         <div class="form-group">
                                           <asp:Label runat="server">Product Short Description</asp:Label>
                                           <asp:TextBox ID="txtShortDesc" runat="server" Height="80px" class="form-control" TextMode="MultiLine"  ></asp:TextBox>                                          
                                        </div>
                          </div>
                                       <div class="col-md-4 col-sm-4">
                                       <div class="form-group"> 
                                                 <asp:Label runat="server">Purchase Price</asp:Label>
                                           <asp:TextBox ID="txtPurchasePrice" runat="server" class="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" ></asp:TextBox>                                          
                                             </div>
                           <div class="form-group  ">
                                              <asp:Label runat="server">Dealer Price</asp:Label>
                                           <asp:TextBox ID="txtDealerPrice" runat="server" class="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" ></asp:TextBox>                                          
                                      
                                               </div>
                                          <div class="form-group">
                                            <asp:Label runat="server">MRP</asp:Label>
                                                <asp:TextBox ID="txtMRP" runat="server" class="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" ></asp:TextBox>                                          
                                            </div>
                                      <div class="form-group">
                                           <asp:Label runat="server">Product Long Description</asp:Label>
                                           <asp:TextBox ID="txtLongDesc" runat="server" Height="160px" class="form-control"  TextMode="MultiLine"></asp:TextBox>                                          
                                        </div>
                            
                                     </div>
                                     <div class="col-md-4 col-sm-4">  
                                           
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
                                             <asp:Image ID="ImgCust" CssClass="fileupload-preview thumbnail" style="width: 220px; height: 200px;float:none"  runat="server" ImageUrl="~/media/Product/NoProfile.png" />
                               
                                         </div>
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
                                                      <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="btn btn-warning"  OnClick="btnupdate_Click"/>
                                                      <a ID="btncancle" class="btn btn-danger" href="ViewProduct.aspx" runat="server" Text="Cancel" >Cancel</a>
                                                       </div>

                                         <div class="form-group">
                                       
                                         </div>
                                    </div>

                   </div>              
          </div>
            </div>
    
          </div>
       </div>
        </div>
   </asp:Content>
