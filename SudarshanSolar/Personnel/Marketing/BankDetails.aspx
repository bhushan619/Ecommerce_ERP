<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Marketing.Master" AutoEventWireup="true" CodeBehind="BankDetails.aspx.cs" Inherits="SudarshanSolar.Personnel.Marketing.BankDetails" %>

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
                <li role="presentation"><a  href="KYCDocument.aspx" >KYC Document</a></li>
                <li class="active" role="presentation"><a  href="BankDetails.aspx" 
                  role="tab">Bank Details</a></li>
               
              </ul>

              <div class="tab-content">
                <div class="tab-pane active animation-slide-left" id="activities" role="tabpanel">
          
				<div class="panel-body">
					<div  class="form-horizontal">                     
                     
                         <div class="form-group">
									<label for="focusedinput" class="col-sm-4   control-label">Bank  Name</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtbankname" onkeyup="checkText(this);" runat="server" CssClass="form-control empty"  required="required"></asp:TextBox>
									</div>
								</div>	
                          <div class="form-group">
									<label for="focusedinput" class="col-sm-4   control-label">Branch Name</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtBranchName" runat="server" onkeyup="checkTextNum(this);" CssClass="form-control empty"  ></asp:TextBox>
									</div>
									</div>
                                                       <div class="form-group">
									<label for="focusedinput" class="col-sm-4   control-label">Branch City</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtbranchaddress" runat="server" CssClass="form-control empty" onkeyup="checkText(this);" required="required"></asp:TextBox>
									</div></div>
                         <div class="form-group">
									<label for="focusedinput" class="col-sm-4   control-label">Account Holder Name</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtAcholder" runat="server" CssClass="form-control empty"  required="required" onkeyup="checkText(this);"></asp:TextBox>
									</div>
									
								</div>
                              <div class="form-group">
									<label for="focusedinput" class="col-sm-4   control-label">Account Number</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtaccountno" runat="server" CssClass="form-control empty" onkeyup="checkTextNum(this);"  required="required"></asp:TextBox>
									</div>
									</div>
                                   <div class="form-group">
									<label for="focusedinput" class="col-sm-4   control-label">Account Type</label>
									<div class="col-sm-8">
										 <asp:DropDownList ID="ddlaccountype" runat="server" CssClass="form-control empty" required="required">
                                                    <asp:ListItem Value="0">:: Select Account Type ::</asp:ListItem>
                                             <asp:ListItem Value="1">Saving</asp:ListItem>
                                             <asp:ListItem Value="2">Current</asp:ListItem>
                                             <asp:ListItem Value="3">Personal</asp:ListItem>
                                              <asp:ListItem Value="4">Real</asp:ListItem>
                                              <asp:ListItem Value="5">Nominal</asp:ListItem>
                                                  </asp:DropDownList>
									</div>
									</div>
                                        <div class="form-group">
									<label for="focusedinput" class="col-sm-4   control-label">IFSC Code</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtifsc" runat="server" CssClass="form-control empty" onkeyup="checkTextNum(this);"></asp:TextBox>
									</div>
									</div>
                                             <div class="form-group">
									<label for="focusedinput" class="col-sm-4   control-label"> MCIR Code</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtmcir" runat="server" CssClass="form-control empty" onkeyup="checkTextNum(this);" ></asp:TextBox>
									</div>
									</div>
                                                
                      
                        	<div class="form-group">
                                		<div class="col-sm-4  "></div>	
									<div class="col-sm-8">
									<label class="checkbox-inline">	  <asp:CheckBox ID="chkIsActive" runat="server"  /> Is Active 	 </label>
									</div>
                                </div>
							
                        <div class="form-group">
									<div class="col-sm-4  "></div>
									<div class="col-sm-8 example example-buttons">
									  <button ID="btnUpdate" runat="server" class="btn btn-warning" Text="Update" Visible="false"  onserverclick="btnUpdate_Click">Update</button>
                       <button ID="btnSubmit" runat="server" class="btn btn-success" Text="Submit" onserverclick="btnSubmit_Click"  >Submit</button>
                          <a  class="btn  btn-danger" href="AddBankDetails.aspx" >Reset</a>
									</div>
								</div>
                        
                                      <div class="form-group">
   <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
           </div> 
                   	
					
                 
	  
			
				  <h3 class="panel-title"><i class="icon md-case" aria-hidden="true"></i>View </h3>
						
		
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
                                              
                                                             <td> <asp:Label Text='<%# Eval("varAccountHolderName") %>' runat="server" ID="varAccountHolderName" /></td>
                                                              <td>   <asp:Label Text='<%# Eval("varAccountNo") %>' runat="server" ID="varAccountNo" /></td> 
                                                              <td><asp:Label Text='<%# Eval("varBankName") %>' runat="server" ID="varBankName" /></td>
                                                            
                                                              <td> <asp:Label Text='<%# Eval("intIsActive") %>' runat="server" ID="IsActive" /></td>
                                                           <td><asp:LinkButton  ID="lnkListEdit" CommandArgument='<%# Eval("intId") %>' CommandName="Edits"  runat="server" ToolTip="Edit"  CssClass=" icon md-edit btn-xs  btn btn-warning">
</asp:LinkButton> </td>
                                                            
                                                             
                                                             
                                                         </tr>
                                                     </ItemTemplate>
                                                     <LayoutTemplate>
                                                        <div class="example table-responsive">
                                                                     <table runat="server" id="itemPlaceholderContainer" cellpadding="1" class="table table-bordered " >
                                                                         <tr id="Tr1" runat="server" class="">
                                                                            
                                                                             <th id="Th2" runat="server">SrNo</th>
                                                                             <th id="Th3" runat="server">Account Holder Name</th>
                                                                                 <th id="Th6" runat="server">Account Number</th>
                                                                             <th id="Th4" runat="server">Bank Name</th>                                                                          
                                                                             <th id="Th5" runat="server">IsActive</th>
                                                                              <th id="Th1" runat="server" >Operation</th>                                                                       
                                                                         </tr>
                                                                         <tr runat="server" id="itemPlaceholder"></tr>
                                                                     </table>
                                                            </div>
                                                     </LayoutTemplate>
                                                     
                                                 </asp:ListView>
  </div>
             
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
          <!-- End Panel -->
        </div>
      </div>
    </div>
  </div>
</asp:Content>
