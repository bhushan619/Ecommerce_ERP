<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.Gallery" %>
   <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page animsition">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <div class="page-content">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">Create Gallary</h3>
                     </div>
                  
       
                        <div class="panel-body container-fluid">
                       <div class="row">
              <div class="col-md-5 col-sm-5 "> 
       
              <div class="form-group" > 
              <asp:TextBox ID="txtNewEvent" required runat="server" placeholder="Add New Gallery Name"  CssClass="form-control" ></asp:TextBox>
                                               
              </div>  
                  
                 <div class=" form-group input-group">
     <asp:DropDownList ID="ddlEvent" CssClass="form-control"  AppendDataBoundItems="true" runat="server">
     <asp:ListItem>-- Select Gallery --</asp:ListItem>
     </asp:DropDownList>
             <span class="form-group input-group-btn">
                                                  <asp:Button ID="btnEvent" runat="server" CssClass="btn btn-success form-control" 
                        Text="Add New Gallery" onclick="btnEvent_Click" />
                                                  </span>
                                                </div> 
                   <div class="form-group">
                        <asp:TextBox ID="txtImageCaption" runat="server"  CssClass="form-control"  placeholder="Image Caption" ></asp:TextBox>      
                      </div>

               <div class="form-group">
               <asp:TextBox ID="txtEventdate" required placeholder="Gallery Date" runat="server"  CssClass="form-control"></asp:TextBox>
                <cc1:calendarextender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEventdate"  ></cc1:calendarextender>
                  </div>
                 
                
                <div class ="form-group ">
                <input ID="fupProPic" type="file" name="file" onchange="previewFile()"  runat="server" accept='image/*' />
                                 <br />    <asp:Image ID="ImgProduct" CssClass="fileupload-preview thumbnail" style="width: 200px; height: 150px;float:none"  runat="server" ImageUrl="~/media/NoProfile.png" />
                                <script type="text/javascript">
                                    function previewFile() {

                                        var preview = document.querySelector('#<%=ImgProduct.ClientID %>');
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
                     </div>

                   
                  <div class="form-group">
                   <asp:Button ID="btnEventSubmit" runat="server" CssClass="btn btn-success"  
                          Text="Add Gallary Name" onclick="btnEventSubmit_Click" 
                          > </asp:Button>          
                
                 <asp:LinkButton ID="btnEventCancel" runat="server" CssClass="btn btn-danger"   
                     Text="Cancel" onclick="btnEventCancel_Click" />  
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success"  Text="Submit" 
                            onclick="btnSubmit_Click"> </asp:Button>          
                
                 <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger"   
                    onclick="btnCancel_Click" Text="Cancel"> </asp:Button>          
       
                </div> 
                    <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
              </div>
               <div class="col-md-2 col-sm-2"> 
               </div>
           <div class="col-md-6 col-sm-6">
           <h3 > Uploaded Images</h3>
              <asp:GridView ID="grdPackage" runat="server" 
             CssClass="table table-bordered table-hover" AllowPaging="True" 
             AutoGenerateColumns="False" onrowcommand="grdPackage_RowCommand" 
                      onpageindexchanging="grdPackage_PageIndexChanging"   > 
             <Columns> 
                <asp:BoundField DataField="album" HeaderText="Event Name"   />
                <asp:BoundField DataField="VarCaption" HeaderText="Caption"   />
                  <asp:TemplateField>
                <HeaderTemplate>Image</HeaderTemplate>
                <ItemTemplate>
                
                <asp:Image ID="imgCollege" runat="server" CssClass="fancybox" ImageUrl='<%# "~/media/galleryimages/" + Eval("varImagePath") %>' Width="20px"   Height="20px"   />
                </ItemTemplate> 
                </asp:TemplateField>   
                <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="btnEdit" runat="server"  CommandName="Selects"  CommandArgument='<%#Eval("intGalleryId") %>' CssClass="icon md-delete btn-xs  btn btn-danger"/>
                </ItemTemplate> 
                </asp:TemplateField>   
              </Columns>
        </asp:GridView>
           <asp:SqlDataSource ID="sqlGallery" runat="server" 
            ConnectionString="<%$ ConnectionStrings:solarConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:solarConnectionString.ProviderName %>" 
                     
          >        
        </asp:SqlDataSource> </div>
            </div>
                            </div>
          </div>
       </div>
        </div>
</asp:Content>
        
