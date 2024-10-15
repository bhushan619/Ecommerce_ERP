<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="EditProductGallary.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.EditProductGallary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mydeletebtn {
            margin:-270px 0px 0px 102px; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
        <div class="page-content">
            <div class="panel">
                <div class="panel-heading">
                    <h3 class="panel-title">Edit Photo Gallary of :
                        <asp:Label ID="lblProductName" runat="server" CssClass="label label-outline label-primary" Text=""></asp:Label>
                    </h3>

                </div>

                <div class="panel-body container-fluid">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                Room Gallary
                                                     <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />

                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-warning" OnClick="btnsubmit_Click" />
                                <a id="btncancle" class="btn btn-danger" href="Default.aspx" runat="server" text="Cancel">Cancel</a>
                            </div>
                            <div class=" form-group">
                                  <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <asp:ListView ID="lstGallary" runat="server"  DataKeyNames="id" OnPagePropertiesChanging="lstGallary_PagePropertiesChanging" OnItemCommand="lstGallary_ItemCommand">

                                 <EmptyDataTemplate>
                                        <table id="Table1" runat="server" style="width: 90%" cssclass="table table-bordered table-hover">
                                            <tr>
                                                <td>
                                                    <div class="alert alert-dismissable alert-info " style="width: 100%">
                                                        <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>

                                <ItemTemplate>
                                    <div class="col-md-4"> 
                                                <asp:Image Height="150px" Width="150px" CssClass="img-bordered"   ImageUrl='<%#"~/Media/Product/"+ Eval("file") %>' runat="server" ID="gallaryImageLabel" /><br />
                                                <asp:LinkButton ID="lnkDeleteFamily" runat="server" CssClass=" " Text="" CommandName="Deletes" CommandArgument='<%#Eval("id") %>'><i class="btn mydeletebtn btn-danger icon-2x icon  md-close-circle"></i></asp:LinkButton>
                                       </div>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <div runat="server" id="itemPlaceholder" />

                                </LayoutTemplate>
                            </asp:ListView>
                            <%--<asp:GridView ID="grdPackage" runat="server" 
             CssClass="table table-bordered table-hover" AllowPaging="True" 
             AutoGenerateColumns="False" onrowcommand="grdPackage_RowCommand" 
                      onpageindexchanging="grdPackage_PageIndexChanging"   > 
             <Columns> 
            
                  <asp:TemplateField>
                <HeaderTemplate>Image</HeaderTemplate>
                <ItemTemplate>
                
                <asp:Image ID="imgCollege" runat="server" CssClass="fancybox" ImageUrl='<%# "~/media/product/" + Eval("file") %>' Width="70px"   Height="70px"   />
  <asp:LinkButton ID="lnkDeleteFamily" runat="server"  CssClass="btn  over mydeletebtn"  Text="" CommandName="Deletes"  CommandArgument='<%#Eval("id") %>' ><i class=" icon-2x icon  md-close-circle"></i></asp:LinkButton>
                </ItemTemplate> 
                </asp:TemplateField>   
             
              </Columns>
        </asp:GridView>--%>


                            <asp:SqlDataSource ID="sqlGallery" runat="server"
                                ConnectionString="<%$ ConnectionStrings:SolarConnectionString %>"
                                ProviderName="<%$ ConnectionStrings:SolarConnectionString.ProviderName %>"></asp:SqlDataSource>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>

