<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Marketing.Master" AutoEventWireup="true" CodeBehind="KYCDocument.aspx.cs" Inherits="SudarshanSolar.Personnel.Marketing.KYCDocument" %>

<%@ Register Src="~/Personnel/Usercontrol/EmployeeProfilePhoto.ascx" TagPrefix="uc1" TagName="EmployeeProfilePhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page animsition">
    <div class="page-content container-fluid">
      <div class="row">
        <div class="col-md-3">
          <!-- Page Widget -->
<uc1:EmployeeProfilePhoto runat="server" ID="EmployeeProfilePhoto" />
          <!-- End Page Widget -->
        </div>

        <div class="col-md-9">
          <!-- Panel -->
          <div class="panel">
            <div class="panel-body nav-tabs-animate nav-tabs-horizontal">
              <ul class="nav nav-tabs nav-tabs-line" >
                <li  role="presentation"><a  href="EditProfile.aspx" 
                  role="tab">Profile</a></li>
                <li class="active" role="presentation"><a  href="KYCDocument.aspx" >KYC Document</a></li>
                <li role="presentation"><a  href="BankDetails.aspx" 
                  role="tab">Bank Details</a></li>
               
              </ul>

              <div class="tab-content">
                <div class="tab-pane active animation-slide-left" id="activities" role="tabpanel">
                          	<div  class=" panel-body form-horizontal">          
                                   
                    <div class="form-group">
                                            <label for="focusedinput" class="col-sm-4   control-label">Description</label>
                              <div class="col-sm-8">	  <asp:TextBox ID="txtDescription" runat="server" onkeyup="checkTextNum(this);" CssClass="form-control empty" TextMode="MultiLine"></asp:TextBox>
                                            
                                    </div>    </div>
                <div class="form-group">
                                   <label for="focusedinput" class="col-sm-4   control-label">Document File</label>
                                    <div class="col-sm-8">   <input id="fupProPic" type="file" name="file" class="fileinput-new"  onchange="previewFile()"  runat="server" accept='image/*' />
                    </div>  </div>
                     <div class="form-group">
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
                         <div class="col-sm-4  "></div>
                    <div class="col-sm-8">  <asp:Image ID="ImgProfile" CssClass="fileupload-preview thumbnail" style="width: 120px; height: 120px;float:none"  runat="server" ImageUrl="~/Media/Documents/NoProfile.png" /> 
                        </div>  </div>
                     		
                        <div class="form-group">
									<div class="col-sm-4  "></div>
									<div class="col-sm-8 example example-buttons">
   <button ID="btnUpdate" runat="server" class="btn btn-warning" Text="Update" Visible="false"  onserverclick="btnUpdate_Click">Update</button>
              <button ID="btnSubmit" runat="server" class="btn btn-success" Text="Submit" onserverclick="btnSubmit_Click"  >Submit</button>
                                          <a  class="btn  btn-danger" href="KYCDocument.aspx" >Reset</a>

                </div>
                            </div>
                       
                       <div class="form-group ">
        <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
           </div> 
                <div class="panel">
            <div class="panel-heading">
              <h3 class="panel-title"><i class="icon md-case" aria-hidden="true"></i>View Documents</h3>
            </div>
            <div class="panel-body">
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
                                              

                                                              <td>   <asp:Label Text='<%# Eval("varDescription") %>' runat="server" ID="varAccountNo" /></td> 
                                                            
                                                          <td>   <asp:Image ID="imgSimilarPic" runat="server" CssClass="fancybox" Height="50px" Width="50px"   ImageUrl='<%# "~/Media/Documents/" + Eval("varDocument") %>' /> </td> 
                                                              <td> <asp:Label Text='<%# Eval("varStatus") %>' runat="server" ID="IsActive"  CssClass='<%# Eval("varStatus").ToString() == "Approved" ? "label label-success" :Eval("varStatus").ToString()=="Rejected"? "label label-danger":"label label-warning" %>' /></td>
                                                           <td class="text-nowrap"><asp:LinkButton  ID="lnkListEdit" CommandArgument='<%# Eval("intId") %>' CommandName="Edits"  runat="server"  CssClass=" icon md-edit btn-xs  btn btn-warning" data-toggle="tooltip" data-original-title="Edit">
</asp:LinkButton> 
                                                                               </td>
                                                             <td><asp:LinkButton  ID="lnkListDelete" CommandArgument='<%# Eval("intId") %>' CommandName="Delets"  runat="server"    data-toggle="tooltip" ToolTip="Delete"  CssClass=" icon md-delete btn-xs  btn btn-danger">
                                                                  </asp:LinkButton>
                                                             </td>
                                                             
                                                              </tr>
                                                     </ItemTemplate>
                                                     <LayoutTemplate>
                                                            <div class="example table-responsive">
                                                                     <table runat="server" id="itemPlaceholderContainer" cellpadding="1" class="table table-bordered " >
                                                                         <tr id="Tr1" runat="server" class="">
                                                                            
                                                                            <th id="Th2" runat="server">SrNo</th>
                                                                            
                                                                                 <th id="Th6" runat="server">Description</th>
                                                                           
                                                                                  <th id="Th7" runat="server">Image </th>                                                                                    
                                                                             <th id="Th5" runat="server">Status</th>
                                                                              <th id="Th1" runat="server"  colspan="2">Operation</th>                                                                       
                                                                         </tr>
                                                                         <tr runat="server" id="itemPlaceholder"></tr>
                                                                     </table>
                                                                </div>
                                                     </LayoutTemplate>
                                                     
                                                 </asp:ListView>
                                                    

             
                     <div class="text-right">
                                                   
                                                     <asp:DataPager ID="DataPager1" runat="server"  PagedControlID="lstType" PageSize="10">
                                                          <Fields  >
                                                           <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-primary btn-xs" ShowFirstPageButton="True" ShowPreviousPageButton="False"   FirstPageText="< First "      ShowNextPageButton="false" />
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
            </div>
          </div>
          <!-- End Panel -->
        </div>
      </div>

</asp:Content>
