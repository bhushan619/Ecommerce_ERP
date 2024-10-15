<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/OutsideMaster.Master" AutoEventWireup="true" CodeBehind="AddEnquiry.aspx.cs" Inherits="SudarshanSolar.Customer.AddEnquiry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <section class="page_breadcrumbs ds ms parallax section_padding_bottom_30">
				<div class="container">
					<div class="row">
						<div class="col-sm-12 text-center">
							<div class="breadcrumbs_logo">
								<img src="../Content/o/images/logo.png" alt="">
							</div>
							<h1 class="highlight bold">Enquiry</h1>
							<ol class="breadcrumb">
								<li>
									<a href="Dashboard.aspx">
										HomePage
									</a>
								</li>
								
								<li class="active">Add Enquiry</li>
							</ol>
						</div>
					</div>
				</div>
			</section>

    <section class="ls ms   columns_padding_25">
				<div class="container">
                    <div class="row">
                 <div class="col-md-6 col-sm-6 col-xs-12">
               <div class="panel panel-info">
                        <div class="panel-heading">
                          <i class="fa fa-envelope"></i>    New Message 
                         
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
        </section>
</asp:Content>
