<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="PrintEntries.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.PrintEntries" %>

       
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">
          $(function () {
              $("#btnPrint").click(function () {
                  var contents = $("#dvContents").html();
                  var frame1 = $('<iframe />');
                  frame1[0].name = "frame1";
                  frame1.css({ "position": "absolute", "top": "-1000000px" });
                  $("body").append(frame1);
                  var frameDoc = frame1[0].contentWindow ? frame1[0].contentWindow : frame1[0].contentDocument.document ? frame1[0].contentDocument.document : frame1[0].contentDocument;
                  frameDoc.document.open();
                  //Create a new HTML document.
                  frameDoc.document.write('<html><head> <style type="text/css" media="print">    @page { size: landscape; font-size:small;}.page{-webkit-transform: rotate(-90deg); -moz-transform:rotate(-90deg); filter:progid:DXImageTransform.Microsoft.BasicImage(rotation=3);}</style>');
                  frameDoc.document.write('</head><body>');
                  //Append the external CSS file.
                  frameDoc.document.write('<link rel="stylesheet" href="../../Content/i/global/css/bootstrap.min.css">');
                  //Append the DIV contents.
                  frameDoc.document.write(contents);
                  frameDoc.document.write('</body></html>');
                  frameDoc.document.close();
                  setTimeout(function () {
                      window.frames["frame1"].focus();
                      window.frames["frame1"].print();
                      frame1.remove();
                  }, 500);
              });
          });
    </script>
      <style type="text/css" media="print">
   #dvContents
    {
     -webkit-transform: rotate(-90deg); 
     -moz-transform:rotate(-90deg);
     filter:progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">
        <!-- Content Header (Page header) -->
         <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">    <asp:Label ID="lblVibhagName" runat="server" Text="" Font-Bold="true"></asp:Label> 
     Entry Prints</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">
        <!-- Main content -->
      <section class="content"> 
          <div class="row">
              <div class="col-lg-12">
                    <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                  <div class="col-lg-4"> 
                <div class="form-group">
                  
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                      </div>
                    <asp:TextBox ID="txtFromDate" placeholder="From Date" runat="server" required CssClass="form-control"></asp:TextBox>
                                  <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtFromDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFromDate" >
                                </cc1:CalendarExtender>
                        
                    </div><!-- /.input group -->
                  </div> 
                                 </div>
                                <div class="col-lg-4">
               <div class="form-group">
                  
                    <div class="input-group">
                  <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                      </div>
                    
                 
                          <asp:TextBox ID="txtToDate" placeholder="To Date"  runat="server" required CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtToDate_CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtToDate" >
                                </cc1:CalendarExtender>
                    </div><!-- /.input group -->
                  </div> 
                                </div>
                  <div class="col-lg-4"> 
                <div class="input-group input-group-sm">
                    <span class="input-group-btn">
                    <asp:Button CssClass="btn btn-info" id="btnsearch" Text="Search" runat="server"  OnClick="btnsearch_Click"></asp:Button>&nbsp;
                        <a href="PrintEntries.aspx" class="btn btn-foursquare">Reset</a>&nbsp;
                         <input type="button"  class="btn btn-warning" value="Print" id="btnPrint" />&nbsp;
                       
                        <a href="NewEntry.aspx" class="btn btn-adn">New Entry</a> &nbsp;
                        <a href="PreviousEntries.aspx" class="btn btn-bitbucket">Previous Entry</a> 
                    </span>
                  </div> 
                  </div>
                  </div>
              </div> 
          <div class="row">
            <div class="col-md-12">
              <div class="box">
                 <!-- /.box-header -->
                <div class="box-body">
                 
                   <div id="dvContents" >     
                               <div class="row " id="divmyheader" runat="server">
                                  
                              
                            
                                      <div class="col-xs-12  table-responsive  " > 
                                       <h4 class="text-center">  Day Book  </h4>  
                     <asp:GridView ID="gdvAccount" OnDataBound="gdvAccount_DataBound" OnRowCreated="gdvAccount_RowCreated"   CssClass="table table-bordered"  runat="server"  AutoGenerateColumns="False"   >
                                         <Columns> 
                                        
                 <asp:BoundField DataField="CDates" HeaderText="Date"  />    
                                               <asp:BoundField DataField="CAccCode" HeaderText="Day Book No"  />        
                                               <asp:BoundField DataField="CVoucher" HeaderText="Voucher No"    />  
                         <asp:BoundField DataField="CAccName" HeaderText="Account  Name"  />    
                                         
                  <asp:BoundField DataField="CDetails" HeaderText="Details" />   
                                          
                                               <asp:BoundField DataField="CAmts" HeaderText="Amount"  ItemStyle-CssClass="text-right" />       
                                             
                                              
                                               <asp:BoundField DataField="DAccCode" HeaderText="Day Book No"  />        
                                               <asp:BoundField DataField="DVoucher" HeaderText="Voucher No"    />  
                         <asp:BoundField DataField="DAccName" HeaderText="Account  Name"  />    
                                         
                  <asp:BoundField DataField="DDetails" HeaderText="Details" />   
                                          
                                               <asp:BoundField DataField="DAmts" HeaderText="Amount" ItemStyle-CssClass="text-right" />                                                
                     
        </Columns>   <EmptyDataTemplate>

         Today Debit Not Available!!

        </EmptyDataTemplate> <PagerSettings Mode="Numeric" />
                                    </asp:GridView>
                                 </div> 
                                  
                
                                               
                               </div>
                        
                         </div><!-- ./box-body -->
                 <!-- /.box-footer -->
             </div><!-- /.box -->
            </div><!-- /.col -->
          </div><!-- /.row -->
              </div>
          <!-- Main row -->
       
        </section><!-- /.content -->
       </div> 
             </div>
       </div>
      </div>
</asp:Content>
