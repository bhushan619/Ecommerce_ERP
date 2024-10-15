<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewDivision.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.AddNewDivision" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">
        <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">Add New Division</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">
       
         <div class="row">
            <div class="col-md-4">

              <!-- Profile Image -->
              <div class="box box-primary">
                <div class="box-body" >
                       <div class="form-group has-feedback"> 
            <asp:TextBox runat="server" id="txtdcode" class="form-control" placeholder="Division Code" required="required" oninvalid="this.setCustomValidity('Divisionाची माहिती टाका.')" onchange="this.setCustomValidity('')"></asp:TextBox>
            <span class="glyphicon glyphicon-th form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
              <asp:TextBox runat="server" id="txtdname" class="form-control" placeholder="Division Name" required="required" oninvalid="this.setCustomValidity('Divisionाची माहिती टाका.')" onchange="this.setCustomValidity('')"></asp:TextBox>
            <span class="glyphicon glyphicon-user form-control-feedback"></span>
          </div>
                       <div class="form-group has-feedback"> 
               <asp:TextBox runat="server" id="txtdwork" class="form-control" placeholder="Division Work" TextMode="MultiLine" required="required" oninvalid="this.setCustomValidity('Divisionाची माहिती टाका.')" onchange="this.setCustomValidity('')"></asp:TextBox>
            <span class="glyphicon glyphicon-file form-control-feedback"></span>
          </div>
                      <div class="form-group has-feedback"> 
               <asp:TextBox runat="server" id="txtAmount" class="form-control" placeholder="Initial Amount"  onkeyup="checkDec(this);" required="required" oninvalid="this.setCustomValidity('Divisionाची माहिती टाका.')" onchange="this.setCustomValidity('')"></asp:TextBox>
            <span class="glyphicon glyphicon-file form-control-feedback"></span>
          </div>
                     
                     <div class="form-group has-feedback"> 
                         <asp:Button ID="btnsubmit" runat="server" Text="Submit"  OnClick="btnsubmit_Click" class="btn btn-success"/>  
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
                 <asp:ListView ID="lstDivisions" runat="server"> 
    <LayoutTemplate>
        <table class="table table-bordered table-striped">
            <thead>
                <th>
                  Division Code
                </th>
                <th>
                   Division Name
                </th><th>
                  Division Work
                </th> 
            </thead>
           <tr id="itemPlaceholder" runat="server"></tr>
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <%# Eval("Division Code") %>
            </td>
            <td>
                <%# Eval("Division Name") %>
            </td>  <td>
                <%# Eval("Division Work") %>
            </td>  
        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
        <h2>
         Division not Avaliable!!</h2>
    </EmptyDataTemplate>
</asp:ListView>
                 
                </div>
                  </div>
                </div>
                </div>
      </div>    
            </div>
       </div>
        </div>  
</asp:Content>
