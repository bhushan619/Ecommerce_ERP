<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Marketing.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SudarshanSolar.Personnel.Marketing.ChangePassword" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">

<div class="row">
          <div class="col-md-6 col-sm-6 ">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title"><i class="icon md-account" aria-hidden="true"></i>Change Password </h3>
                     </div>
                  
                    <div class="panel-body container-fluid">  
                                          <div class="form-group ">
              <label class="">Enter Old Password</label>
          <div class=" ">      <asp:TextBox ID="txtOld" runat="server" required="required" placeholder="Old Password" CssClass="form-control" TextMode="Password"></asp:TextBox>
         </div> 
          </div>   <div class="form-group ">
              <label class="">Enter New Password</label>
          <div class=" ">    <asp:TextBox ID="txtNew" runat="server" required="required" placeholder="New Password" CssClass="form-control" TextMode="Password"></asp:TextBox>
           </div> 
          </div>              
          <div class="form-group ">
              <label class="">Enter Confirm Password</label>
          <div class=" ">    <asp:TextBox ID="txtNewCon" CssClass="form-control" runat="server" required="required" placeholder="Confirm Password"   TextMode="Password"></asp:TextBox>
         </div> 
          </div>
                                  
                                    <div class="form-group  ">                                     
                                      <asp:Button ID="btnSubmit"  runat="server" Text="Change Password"  OnClick="btnSubmit_Click" CssClass="btn btn-success"  />                            
                                        <a href="Default.aspx" runat="server"  class="btn btn-danger">Cancel</a>
                              </div>  
                       <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                     
                   
                   </div>
              
          </div>
            </div>

   </div>
</div>    
        </div>      
</asp:Content>


