<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewAccount.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.AddNewAccount" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">
          <!-- Info boxes -->
        <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">Add New Account</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">
       
         <div class="row">
            <div class="col-md-4">

              <!-- Profile Image -->
              <div class="box box-primary">
                <div class="box-body" >
                    <div class="form-group has-feedback"> 
            Account Code : &nbsp;<asp:Label id="txtacccode"  runat="server" Font-Bold="true" ></asp:Label>
          
          </div>
                       <div class="form-group has-feedback"> 
            <asp:TextBox id="txtaccname"    class="form-control" placeholder="Account  Name"   required="required"  oninvalid="this.setCustomValidity('Accountची माहिती टाका.')" onchange="this.setCustomValidity('')" runat="server"></asp:TextBox>
            <span class="glyphicon glyphicon-user form-control-feedback"></span>
          </div>  
                      <div class="form-group has-feedback"> 
               <asp:TextBox id="txtaccmobile"  class="form-control" placeholder="Mobile No"   pattern="[7-9]{1}[0-9]{9}"  oninvalid="this.setCustomValidity('Mobile No टाका.')" onchange="this.setCustomValidity('')" runat="server"></asp:TextBox> 
            <span class="glyphicon glyphicon-phone form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
               <asp:TextBox id="txtaccphone"  class="form-control" placeholder="Phone No" runat="server" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
            <span class="glyphicon glyphicon-phone form-control-feedback"></span>
          </div>
                
                            <div class="form-group has-feedback"> 
               <asp:TextBox id="txtaccEmail"  class="form-control" placeholder="Email" runat="server"  pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum|in|co.in)"></asp:TextBox>
            <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
                <asp:TextBox id="txtaccaddress"  class="form-control" placeholder="Address" TextMode="MultiLine" runat="server"></asp:TextBox>
            <span class="glyphicon glyphicon-home form-control-feedback"></span>
          </div>
                  
                     <div class="form-group has-feedback"> 
     <asp:Button ID="btnsubmit" class="btn btn-success" runat="server" Text="Submit" OnClick="btnsubmit_Click"/>
          </div>
                      <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                    </div>
                  </div>
                </div>
             <div class="col-md-8">

              <!-- Profile Image -->
              <div class="box box-danger">
              <div class="box-body">
                   <div class="table-responsive">
                  <asp:ListView ID="lstDivisions" runat="server"> 
    <LayoutTemplate>
        <table class="table table-bordered table-striped">
            <thead>
                <th>
                 Account Code
                </th>
                <th>
                  Account  Name
                </th><th>
                 Mobile No
                </th> 
                <th>
                  Address
                </th> 
            </thead>
           <tr id="itemPlaceholder" runat="server"></tr>
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <%# Eval("Account Code") %>
            </td>
            <td>
                <%# Eval("Account  Name") %>
            </td>  <td>
                <%# Eval("Mobile No") %>
            </td>  
             <td>
                <%# Eval("Address") %>
            </td>  
        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
        <h2>
       Accounts not Available!!</h2>
    </EmptyDataTemplate>
</asp:ListView></div>
                  
                </div>
                  </div>
                </div>
                </div>
                        </div>
            </div>
      </div>    
        </div>  
</asp:Content>
