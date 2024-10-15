<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeProfilePhoto.ascx.cs" Inherits="SudarshanSolar.Personnel.Usercontrol.EmployeeProfilePhoto" %>
          <div class=" widget-shadow text-center" style="background-color:#fff">
            <div class="widget-header">
              <div class="widget-header-content">
               <div class="example-wrap" style="padding-top:10px">
               
                <div class="example">
                 
                        <asp:Image ID="ImgProfile"   Height="170px" Width="170px" CssClass="avatar-lg avatar"  runat="server" ></asp:Image>

              
                    <h4 class="profile-user"><asp:Label ID="lblCustName" runat="server" Text="lblCustName"></asp:Label></h4>
                <p class="profile-job"><asp:Label ID="lbldesignation" runat="server" Text="lblCustName"></asp:Label></p> 
                 <%--  <asp:FileUpload ID="fupProPic"  runat="server" CssClass="file " /> --%>
                <input id="fupProPic" type="file" name="file" class="fileinput-new"  onchange="previewFile()"  runat="server" accept='image/*' />
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
                    <br />
                      <asp:LinkButton ID="btnUploadPro" runat="server" Text="Upload" CssClass="btn btn-success waves-effect waves-light" OnClick="btnUploadPro_Click" >  
                      <i class="icon md-upload text" aria-hidden="true"></i>
                      <span class="text">Upload</span>
                          </asp:LinkButton>
                          </div>       
                    
              </div>
            
              </div>
            </div>
            
          </div>