<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Marketing.Master" AutoEventWireup="true" CodeBehind="AddEnquiry.aspx.cs" Inherits="SudarshanSolar.Personnel.Marketing.AddEnquiry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    

  <div class="page animsition">
    <div class="page-content container-fluid">
                    <div class="row">
                 <div class="col-md-6 col-sm-6 col-xs-12">
               <div class="panel ">
                        <div class="panel-heading">
                       <h3 class="panel-title"> <i class="icon md-mail-send" ></i>   New Message To Admin </h3>
                         
                        </div>
                        <div class="panel-body "> 
                          <div class="form-group" align="right"> 
                          
                               <asp:Label ID="Label1" runat="server" Text="Date:"></asp:Label> <asp:Label ID="lbldate" runat="server"  ></asp:Label>&nbsp;&nbsp;
                               <asp:Label ID="Label2" runat="server" Text="Time:"></asp:Label> <asp:Label ID="lblTime" runat="server"  ></asp:Label>
                               </div> 
<div class="form-group">
    <asp:Label ID="lblEnqSub" runat="server" Text="Enquiry Subject"></asp:Label>
                <asp:TextBox ID="txtSubject" runat="server" class="form-control" 
                 placeholder="Enter Subject"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject"
                                ErrorMessage="*"  SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>

 <div class="form-group">
                            <asp:Label ID="lblEnqDesc" runat="server" Text="Enquiry Description"></asp:Label>
                  <asp:TextBox ID="txtMsg" runat="server" class="form-control" 
                                        placeholder="Enter Message" TextMode="MultiLine" ></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMsg"
                                ErrorMessage="*"  SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </div>

<div class="form-group">
  <asp:Button ID="btnSend" runat="server" Text="SEND" class="btn btn-success" onclick="btnSend_Click"  OnClientClick="return Confirm();"></asp:Button>
                               &nbsp;&nbsp; &nbsp;&nbsp;
                                     <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                class="btn btn-warning" onclick="btnCancel_Click"></asp:Button>
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
