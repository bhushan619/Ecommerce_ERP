<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Marketing.Master" AutoEventWireup="true" CodeBehind="CreateDSR.aspx.cs" Inherits="SudarshanSolar.Personnel.Marketing.CreateDSR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure.. You want to Add/Update/Delete ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page animsition">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!-- /. ROW  -->
        <div class="page-content">
            <!-- Panel Form Elements -->
            <div class="panel">
                <div class="panel-heading">
                    <h3 class="panel-title">Daily Sales Report </h3>
                </div>
                <div class="panel-body container-fluid">
                    <div class="row row-lg">

                        <div class="col-md-6 col-sm-6">
                            <asp:Label ID="lblCustName" runat="server" Text="lblCustName" Visible="false"></asp:Label>

                            <div class="form-group">
                                <asp:RadioButton ID="rdbNewCall" Text="New Call" GroupName="call" Checked="true"
                                    runat="server" />
                                <asp:RadioButton ID="rdbFollowUp" runat="server" GroupName="call" Text="Follow Up Call" />
                                <asp:RadioButton ID="rdbVisit" runat="server" GroupName="call" Text="Visit" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" required placeholder="Select Date"></asp:TextBox>
                                <cc1:CalendarExtender Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server"
                                    Enabled="True" TargetControlID="txtDate"></cc1:CalendarExtender>
                            </div>
                            <div class="form-group">
                                <div class="clearfix">
                                    <div class="input-group clockpicker pull-center" data-placement="left" data-align="top" data-autoclose="true">
                                        <asp:TextBox ID="txtTime" runat="server" placeholder="Select Time" CssClass="form-control" required></asp:TextBox>
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-time"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server" required placeholder="Location"></asp:TextBox>
                            </div>


                            <div class="form-group">
                                <asp:TextBox ID="txtCustomerName" runat="server"
                                    placeholder="Company/Customer Name" class="form-control" AutoPostBack="true"
                                    OnTextChanged="txtCustomerName_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                    MinimumPrefixLength="1" CompletionInterval="1"
                                    EnableCaching="true"
                                    DelimiterCharacters=""
                                    Enabled="True"
                                    ServiceMethod="GetCompletionList"
                                    CompletionSetCount="1"
                                    TargetControlID="txtCustomerName" UseContextKey="True">
                                </cc1:AutoCompleteExtender>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="txtContactPerson" CssClass="form-control" runat="server" required placeholder="Contact Person"></asp:TextBox>
                            </div>

                        </div>


                        <div class="col-md-6 col-sm-6">

                            <div class="form-group">
                                <asp:TextBox ID="txtLandLine" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" CssClass="form-control" runat="server" placeholder="Landline Number"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtMobile" CssClass="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" runat="server" required placeholder="Mobile Number"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" required placeholder="Remark"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtNextCall" CssClass="form-control" runat="server" placeholder="Next Follow Up Date"></asp:TextBox>
                                <cc1:CalendarExtender Format="dd-MM-yyyy" ID="CalendarExtender1" runat="server"
                                    Enabled="True" TargetControlID="txtNextCall"></cc1:CalendarExtender>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" required>
                                    <asp:ListItem Value="">:: Select Status ::</asp:ListItem>
                                    <asp:ListItem Value="Closed">Closed</asp:ListItem>
                                    <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                    <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="form-group text-right">
                                <asp:LinkButton ID="btnSubmit" CssClass="btn btn-warning" runat="server" OnClientClick="return Confirm();"
                                    Text="Submit" OnClick="btnSubmit_Click" />
                                <asp:LinkButton ID="btnReset" CssClass="btn btn-danger" runat="server"
                                    Text="Reset" OnClick="btnReset_Click" />
                            </div>
                            <div class="form-group form-material floating">
                                <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="panel">
                <div class="panel-heading">
                    <h3 class="panel-title">View Daily Sales Report </h3>
                </div>
                <div class="panel-body container-fluid">
                    <div class="row row-lg">
                        <div role="form">
                            <div class="col-lg-4 col-sm-4">
                                <div class="form-group ">
                                    <asp:TextBox ID="txtCmpName" runat="server" class="form-control" CausesValidation="false"
                                        placeholder="-- Select Customer --"></asp:TextBox>

                                    <cc1:AutoCompleteExtender ID="txtCmpName_AutoCompleteExtender" runat="server"
                                        MinimumPrefixLength="1" CompletionInterval="1"
                                        EnableCaching="true"
                                        DelimiterCharacters=""
                                        Enabled="True"
                                        ServiceMethod="GetCompletionList"
                                        CompletionSetCount="1"
                                        TargetControlID="txtCmpName" UseContextKey="True">
                                    </cc1:AutoCompleteExtender>

                                </div>
                            </div>
                            <div class="col-lg-2 col-sm-2">
                                <div class="form-group">

                                    <asp:TextBox ID="txtFromDate" placeholder="From Date" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender Format="dd-MM-yyyy" ID="txtFromDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-lg-2 col-sm-2">
                                <div class="form-group">

                                    <asp:TextBox ID="txtToDate" placeholder="To Date" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender Format="dd-MM-yyyy" ID="txtToDate_CalendarExtender1" runat="server"
                                        Enabled="True" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-lg-4 col-sm-4">

                                <div class="form-group">
                                    <asp:LinkButton ID="btnview" runat="server" Text="View" OnClick="btnview_Click" CssClass="btn btn-primary" />
                                    <a class="btn btn-danger" href="CreateDSR.aspx">Reset</a>
                                    <asp:LinkButton ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" CssClass="btn btn-warning" />
                                </div>
                            </div>
                        </div>
                        <div class="table table-responsive">
                            <asp:GridView ID="grdDSR" runat="server"
                                CssClass="table table-striped table-bordered table-responsive"
                                DataSourceID="SqlDataSourceDSR" AutoGenerateColumns="False"
                                DataKeyNames="intId">
                                <Columns>
                                    <asp:BoundField DataField="varDate" HeaderText="Date"
                                        SortExpression="varDate" />
                                    <asp:BoundField DataField="varLocation" HeaderText="Location"
                                        SortExpression="varLocation" />
                                    <asp:BoundField DataField="varCallType" HeaderText="CallType"
                                        SortExpression="varCallType" />
                                    <asp:BoundField DataField="varCustName" HeaderText="CustomerName"
                                        SortExpression="varCustName" />
                                    <asp:BoundField DataField="varRepersentName" HeaderText="ContactPerson"
                                        SortExpression="varRepersentName" />
                                    <asp:BoundField DataField="varLandline" HeaderText="Landline"
                                        SortExpression="varLandline" />
                                    <asp:BoundField DataField="varMobile" HeaderText="Mobile"
                                        SortExpression="varMobile" />
                                    <asp:BoundField DataField="varRemark" HeaderText="Remark"
                                        SortExpression="varRemark" />
                                    <asp:BoundField DataField="varNextDate" HeaderText="NextCallDate"
                                        SortExpression="varNextDate" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <table id="Table1" runat="server" style="width: 90%" cssclass="table table-bordered table-hover">
                                        <tr>
                                            <td>
                                                <div class="alert alert-dismissable alert-info " style="width: 100%">
                                                    <i class="ti ti-info-alt"></i>&nbsp; <strong>Oops !!!&nbsp;&nbsp;</strong> No Data Found..... !!!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						                                              	
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceDSR" runat="server"
                                ConnectionString="<%$ ConnectionStrings:solarConnectionString %>"
                                ProviderName="<%$ ConnectionStrings:solarConnectionString.ProviderName %>"></asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
