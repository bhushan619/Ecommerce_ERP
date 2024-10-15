<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/Admin/Reports/AdminReport.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.Reports.Report" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
        <div class="page-header">
      <h1 class="page-title">All Reports</h1>
   
    </div>
   <div class="page-content">
  
              <div class="row">
                                <div class="col-md-4">
                                      <div class="widget">
                                        <div class="widget-content padding-25 bg-white">
                                          <div class="counter counter-lg">
                                            <div class="font-size-20 margin-top-3"> <a href="ExpenseSheetReport.aspx" title="Expense sheet report">Expense sheet report</a></div>
                                            <div class="counter-label text-uppercase"></div>
                                          </div>
                                        </div>
                                      </div>
                                 </div>
                                  <div class="col-md-4">
                                      <div class="widget">
                                        <div class="widget-content padding-25 bg-white">
                                          <div class="counter counter-lg">
                                               <div class="font-size-20 margin-top-3"> abc report</div>
                                            <div class="counter-label text-uppercase"></div>
                                          </div>
                                        </div>
                                      </div>
                                 </div>
                    <div class="col-md-4">
                                      <div class="widget">
                                        <div class="widget-content padding-25 bg-white">
                                          <div class="counter counter-lg">
                                             <div class="font-size-20 margin-top-3"> abc report</div>
                                            <div class="counter-label text-uppercase"></div>
                                          </div>
                                        </div>
                                      </div>
                                 </div>
                               <div class="col-md-4">
                                      <div class="widget">
                                        <div class="widget-content padding-25 bg-white">
                                          <div class="counter counter-lg">
                                              <div class="font-size-20 margin-top-3"> abc report</div>
                                            <div class="counter-label text-uppercase"></div>
                                          </div>
                                        </div>
                                      </div>
                                 </div>
   
              </div>
                        </div>
        
        
        </div>
</asp:Content>
