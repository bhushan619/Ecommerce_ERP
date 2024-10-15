<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Terij.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.Terij" %>
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
                frameDoc.document.write('<html><head>');
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content">
        <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title"> Balance Sheet </h3>
                     </div>
                  
                    <div class="panel-body container-fluid">
  
        <!-- Main content -->
      <section class="content">
          <!-- Info boxes --> 
          <div class="row">
            <div class="col-md-12">
              <div class="box"> 
                <div class="box-body">
                    <div class="row">
                         <div class="col-md-12">
                               <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>
                               <div class="col-md-4"> 
                                   <div class="form-group "> 
                                           <asp:DropDownList ID="ddldivision" runat="server" class="form-control" 
                                                autoPostBack="false"     required="required" AppendDataBoundItems="true" >
                                               <asp:ListItem Value="0">Please Select Division</asp:ListItem>
                                           </asp:DropDownList>
                           
                                          </div>

                               </div> 
                                <div class="col-md-2">
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
                                <div class="col-md-2">
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

                               <div class="col-md-2"> 
                                     <div class="input-group input-group-sm">
                                         <span class="input-group-btn">
                                          <asp:Button CssClass="btn btn-info" id="btnsearch" Text="Search" runat="server"  OnClick="btnSearch_Click"></asp:Button>
                                         
                                                 <input type="button"  class="btn btn-warning" value="Print" id="btnPrint" />
                                          </span>
                  </div>
                                   </div>
                         </div>
                    </div>
                    <!-- /input-group --> 
                     
                         <div id="dvContents" >
                               <div class="row text-center" id="divmyheader" runat="server" visible="false">
                                    
                                <h4>  Balance Sheet <br />  <asp:Label ID="lblDept" runat="server" Text=""></asp:Label>, 
                               <asp:Label ID="lbldatefrom" runat="server" Text="Label"></asp:Label> To <asp:Label ID="lbldateto" runat="server" Text="Label"></asp:Label> 
                             </h4> </div> 
                                      <div class="col-xs-6  table-responsive" > 
                                    <asp:GridView ID="gdvAccount" ShowFooter="True"    CssClass="table table-striped table-bordered table-hover"   runat="server" AutoGenerateColumns="False"  OnRowDataBound="gdvAccount_RowDataBound" >
                                         <Columns>
                                                <%--  <asp:BoundField DataField="intId" HeaderText="ID" SortExpression="intId" />    --%>        
                 <%-- <asp:BoundField DataField="Date" HeaderText="Date"  />  
                         <asp:BoundField DataField="Account  Name" HeaderText="Account  Name"  /> --%>      
                                  <asp:BoundField DataField="Account  Name" HeaderText="Details - Credit"   FooterText="Total Credit :" FooterStyle-CssClass="text-bold"  ControlStyle-Font-Bold="false"/>              
                  <%-- 
                                               <asp:BoundField DataField="Day Book No" HeaderText="Day Book No"  />  --%>
                                               <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-CssClass="text-right" FooterStyle-CssClass="text-right text-bold" />  
                                            <%--   <asp:BoundField DataField="Debit Amount" HeaderText="Debit Amount"  />  
                                               <asp:BoundField DataField="Credit / Debit" HeaderText="Credit / Debit"  />   --%>    
            
        </Columns>   <EmptyDataTemplate>

           <strong>Details Not Available!!</strong>

        </EmptyDataTemplate> <PagerSettings Mode="Numeric" />
                                    </asp:GridView>
                                 </div> 
                         <div class="col-xs-6 table-responsive" >
                                   
                                    <asp:GridView ID="grdAccountNave" ShowFooter="True"    CssClass="table table-striped table-bordered table-hover"   runat="server" AutoGenerateColumns="False"  OnRowDataBound="grdAccountNave_RowDataBound" >
                                         <Columns>
                                
           
                                                <%--  <asp:BoundField DataField="intId" HeaderText="ID" SortExpression="intId" />    --%>        
                 <%-- <asp:BoundField DataField="Date" HeaderText="Date"  />  
                         <asp:BoundField DataField="Account  Name" HeaderText="Account  Name"  /> --%>      
                                  <asp:BoundField DataField="Account  Name" HeaderText="Details - Debit"   FooterText="Total Debit :" FooterStyle-CssClass="text-bold"  ControlStyle-Font-Bold="false"/>              
                  <%-- 
                                               <asp:BoundField DataField="Day Book No" HeaderText="Day Book No"  />  --%>
                                             
                                              <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-CssClass="text-right" FooterStyle-CssClass="text-right text-bold"  />  
                                             <%--   <asp:BoundField DataField="Credit Amount" HeaderText="Credit Amount"  />    <asp:BoundField DataField="Credit / Debit" HeaderText="Credit / Debit"  />   --%>    
            <%--    <asp:TemplateField>
                   <HeaderTemplate>Work</HeaderTemplate>
                <ItemTemplate>
              <center>  
                  <asp:LinkButton ID="lnkbtndelet" runat="server" ToolTip="Edit" CommandName="Edits" CommandArgument='<%#Eval("intId") %>'  CssClass="fa fa-2x fa-pencil-square"/>
                 
               <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Account गाळा" CommandName="Deletes" CommandArgument='<%#Eval("intId") %>'  CssClass="fa fa-2x  fa-trash  " forecolor="red" />
              </center>
            

                </ItemTemplate> 
                </asp:TemplateField>  --%>
        </Columns>   <EmptyDataTemplate>

           <strong>Details Not Available!!</strong>

        </EmptyDataTemplate> <PagerSettings Mode="Numeric" />
                                    </asp:GridView>
                                 </div>
                                  
                         </div>
                  <!-- /.table-responsive -->
                </div><!-- /.box-body --> 
            </div> 
            </div><!-- /.col -->
          </div><!-- /.row -->

          <!-- Main row -->
       
        </section><!-- /.content -->
        </div>
            </div>
       </div>
      </div><!-- /.content-wrapper -->
</asp:Content>
