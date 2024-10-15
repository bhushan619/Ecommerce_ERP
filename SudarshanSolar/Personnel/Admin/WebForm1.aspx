<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--
        
        <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page animsition">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <div class="page-content">
      <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">Add Titile</h3>
                     </div>
                  
       
                        <div class="panel-body container-fluid">
                        <div class="row"> 
                            </div>
                            </div>
          </div>
       </div>
        </div>
</asp:Content>
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        <style>
        #ContentPlaceHolder1_divMessage {
            -moz-animation: cssAnimation 0s ease-in 5s forwards;
            /* Firefox */
            -webkit-animation: cssAnimation 0s ease-in 5s forwards;
            /* Safari and Chrome */
            -o-animation: cssAnimation 0s ease-in 5s forwards;
            /* Opera */
            animation: cssAnimation 0s ease-in 5s forwards;
            -webkit-animation-fill-mode: forwards;
            animation-fill-mode: forwards;
        }

        @keyframes cssAnimation {
            to {
                width: 0;
                height: 0;
                overflow: hidden;
            }
        }

        @-webkit-keyframes cssAnimation {
            to {
                width: 0;
                height: 0;
                visibility: hidden;
            }
        }
    </style>--%>
    <script type="text/javascript">
        function autoHide() {  //hide after 5 seconds   
            setTimeout(function () { document.getlementById('<%=divMessage.ClientID%>').style.display = 'none'; }, 5000);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="col-sm-6 col-md-4">
        <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
           
        </div>
    </div>



    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />


</asp:Content>

