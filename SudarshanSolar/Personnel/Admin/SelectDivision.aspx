<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="SelectDivision.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.SelectDivision" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">
        <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title"> Select Division</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">
       
          <section class="content">
          <!-- Info boxes -->
          <div class="row">
              <asp:ListView ID="lstDivisions" runat="server" OnItemCommand="lstDivisions_ItemCommand"  >
                  <ItemTemplate>
                      <div class="col-md-4">
              <!-- Widget: user widget style 1 -->
              <div class="box box-widget widget-user">
                <!-- Add the bg color to the header using any of the bg-* classes -->
                <div class="widget-user-header bg-gray-light">
                  <h3 class="widget-user-username">
                      <asp:Label ID="lblVibhagName" runat="server" Text= <%# Eval("Division Name") %>></asp:Label></h3> 
                    <br />
                    <asp:LinkButton CssClass="btn btn-success" runat="server" ID="newEntry" CommandName="newEntry" CommandArgument= <%# Eval("Division Code") %>>New Entry</asp:LinkButton> 
                    <asp:LinkButton CssClass="btn btn-danger" runat="server" ID="previousEntry" CommandName="previousEntry" CommandArgument= <%# Eval("Division Code") %>>Previous Entry</asp:LinkButton>
                      <asp:LinkButton CssClass="btn btn-primary" runat="server" ID="LinkButton1" CommandName="printEntry" CommandArgument= <%# Eval("Division Code") %>>Entry Print</asp:LinkButton>
                    
                </div> 
                 
              </div><!-- /.widget-user -->
            </div>
                  </ItemTemplate>
              </asp:ListView>
            
          
            
    
          </div><!-- /.row --> 
          <!-- Main row -->
       
        </section><!-- /.content -->
        </div>
            </div>
       </div>
      </div>
    
</asp:Content>
