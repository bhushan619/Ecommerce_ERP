<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="GeneralLedger.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.GeneralLedger" %>
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
                //Append the external CSS file.<link href="../../Content/i/global/css/bootstrap.min.css" rel="stylesheet" />
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
   <div class="page-content ">
       <div class="panel">
                     <div class="panel-heading">
                      <h3 class="panel-title">General Ledger</h3>
                     </div>
                  
                    <div class="panel-body container-fluid">
       
          <!-- Info boxes --> 
          <div class="row ">
            <div class="col-md-12">
              <div class="box"> 
                <div class="box-body">
                    <div class="row">
                         <div class="col-md-12">
                               <div class="col-md-3"> 
                                   <div class="form-group "> 
                                           <asp:DropDownList ID="ddldivision" runat="server" class="form-control" 
                                                autoPostBack="false"     required="required" AppendDataBoundItems="true" >
                                               <asp:ListItem Value="0">Please Select Division</asp:ListItem>
                                           </asp:DropDownList>
                           
                                          </div>

                               </div>
                               <div class="col-md-3"> 
                                            <div class="form-group "> 
                                       
                                                 <asp:DropDownList ID="ddlAccount" runat="server" class="form-control" 
                                                autoPostBack="false"    AppendDataBoundItems="true" >
                                               <asp:ListItem Value="0">Please Select Account Name</asp:ListItem>
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
                                          <asp:Button CssClass="btn btn-warning" id="btnsearch" Text="Search" runat="server"  OnClick="btnSearch_Click"></asp:Button>
                                            <input type="button"  class="btn btn-warning" value="Print" id="btnPrint" /> 
                                         </span>
                  </div>
                                   </div>
                         </div>
                    </div>
                    <!-- /input-group -->
                     <div class="row">
                           <div id="dvContents" >
                                 <div class="col-lg-12">
                                  <div class="box">
                <div class="box-body" >
                                        <div class="row text-center" id="divmyheader" runat="server" visible="false">
                                 <div class="col-lg-12"> 
    <h4>  Division :  <asp:Label ID="lblDept" runat="server" Text=""></asp:Label>, Account No & Name : <asp:Label ID="lblAccNo" runat="server" Text=""></asp:Label>-<asp:Label ID="lblmyacc" runat="server" Text=""></asp:Label> , 
    <br />   Date :  <asp:Label ID="lbldatefrom" runat="server" Text="Label"></asp:Label> To <asp:Label ID="lbldateto" runat="server" Text="Label"></asp:Label> 
    </h4> </div>   </div>
                               
                                    <asp:GridView ID="gdvAccount" ShowFooter="true" OnRowDataBound="gdvAccount_RowDataBound" CssClass="table table-striped table-bordered table-hover"    runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gdvAccount_PageIndexChanging"  >
                                         <Columns>
                                
           
                                                <%--  <asp:BoundField DataField="intId" HeaderText="ID" SortExpression="intId" />    --%>        
                  <asp:BoundField DataField="Date" HeaderText="Date"  />   
                                               <asp:BoundField DataField="Account Code" HeaderText="Day Book No"  />     
                         <asp:BoundField DataField="Account  Name" HeaderText="Account  Name"  />   
                                              
                  <asp:BoundField DataField="Details" HeaderText="Details" FooterText="Total:" FooterStyle-CssClass="text-right text-bold" />   
                                             
                                               <asp:BoundField DataField="Credit Amount" HeaderText="Credit Amount" ItemStyle-CssClass="text-right"  FooterStyle-CssClass="text-right text-bold"  />  
                                               <asp:BoundField DataField="Debit Amount" HeaderText="Debit Amount" ItemStyle-CssClass="text-right"   FooterStyle-CssClass="text-right text-bold" />  
                                               <asp:BoundField DataField="Credit / Debit" HeaderText="Credit / Debit"  />       
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

           <strong>Account Details Not Available!!</strong>

        </EmptyDataTemplate> <PagerSettings Mode="Numeric" />
                                    </asp:GridView>
                                 </div>
                                         
                    </div>
                                      </div>
                               </div>
                         </div>
                  <%--<div class="table-responsive">

                    <table class="table no-margin">
                      <thead>
                        <tr>
                            <th>Account  Name</th>
                          <th>Date </th>
                          <th>Details</th>
                          <th>Day Book No</th>                           
                            <th>Credit Amount</th>
                            <th>Debit Amount</th> 
                            <th>Credit / Debit</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                            <td>जे डी सी सी बँक</td>
                          <td>11-12-2015</td>
                          <td>85421456</td>
                          <td>152</td>                            
                          <td>1508</td>
                            <td>0</td>
                            <td>Credit</td>
                        </tr>
                        <tr>
                            <td>जे डी सी सी बँक</td>
                         <td>11-12-2015</td>
                          <td>85421456</td>
                          <td>152</td>
                            <td>0</td>
                            <td>1500</td>
                            <td> Debit</td> 
                        </tr>
                        <tr>
                            <td>जे डी सी सी बँक</td>
                         <td>11-12-2015</td>
                          <td>85421456</td>
                            <td>152</td>
                        <td>0</td>
                            <td>1500</td>
                            <td> Debit</td> 
                        </tr>
                        <tr>
                            <td>जे डी सी सी बँक</td>
                          <td>11-12-2015</td>
                          <td>85421456</td>
                             <td>150</td> 
                          <td>1508</td>
                            <td>0</td>
                            <td>Credit</td> 
                        </tr>
                      </tbody>
                    </table>
                  </div>--%><!-- /.table-responsive -->
                </div><!-- /.box-body --> 
            </div> 
            </div><!-- /.col -->
          </div><!-- /.row -->

          <!-- Main row -->
       </div>
           </div>
       </div>
        </div><!-- /.content -->
</asp:Content>
