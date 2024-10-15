<%@ Page Title="" Language="C#" MasterPageFile="~/Personnel/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddVariation.aspx.cs" Inherits="SudarshanSolar.Personnel.Admin.AddVariation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page animsition">
        <div class="page-content">

            <div class="row">
                <div class="col-md-6 col-sm-6 ">
                    <div class="panel">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="icon md-case" aria-hidden="true"></i>Add Attributes</h3>
                        </div>

                        <div class="panel-body container-fluid">
                            <div class="form-group">

                                <label class="control-label ">Attribute Name</label>

                                <asp:TextBox ID="txtvariation" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="form-group">

                                <label class="control-label">Description</label>

                                <asp:TextBox ID="txtdescription" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>

                            </div>
                            <div class="form-group">

                                <asp:Button ID="btnsubmit" class="btn btn-success" runat="server" OnClick="btnsubmit_Click" Text="Submit" />
                                <asp:Button ID="btnupdate" class="btn btn-warning" OnClick="Btnupdate_Click" Visible="false" runat="server" Text="Update" />
                                <a id="btncancle" class="btn btn-danger" href="Default.aspx" runat="server" text="Cancel">Cancel</a>

                            </div>
                            <div class="form-group form-material floating">
           <div clientidmode="static" role="alert" id="divMessage" runat="server" visible="false">
              
           </div>
           </div>

                        </div>

                    </div>
                </div>
                <div class="col-md-6 col-sm-6">
                    <div class="panel">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="icon md-eye" aria-hidden="true"></i>View Attributes</h3>
                        </div>
                        <div class="panel-body">
                            <div class="  table-responsive">

                                <asp:ListView ID="lstType" runat="server" OnPagePropertiesChanging="OnPagePropertiesChanging" OnItemCommand="lstType_ItemCommand">

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

                                    <ItemTemplate>
                                        <tr style="">

                                            <td>
                                                <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label></td>

                                            <td>
                                                <asp:Label Text='<%# Eval("varVariation") %>' runat="server" ID="Label1" /></td>

                                            <td>
                                                <asp:Label Text='<%# Eval("varDescription") %>' runat="server" ID="Label3" /></td>



                                            <td>
                                                <asp:LinkButton ID="lnkListEdit" CommandArgument='<%# Eval("intId") %>' CommandName="Edits" runat="server" ToolTip="Edit"  CssClass=" icon md-edit btn-xs  btn btn-warning"/></td>
                                            <%-- <td><asp:LinkButton  ID="lnkListDelete" CommandArgument='<%# Eval("intId") %>' CommandName="Delets"  runat="server"  CssClass="btn btn-xs btn-danger" ToolTip="Delete Attribute" Text="Delete"/></td>
                                            --%>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>

                                        <table runat="server" id="itemPlaceholderContainer" cellpadding="1" class="table table-bordered table-hover">
                                            <tr id="Tr1" runat="server" class="">

                                                <th id="Th2" runat="server">SrNo</th>

                                                <th id="Th3" runat="server">Attribute</th>
                                                <th id="Th5" runat="server">Description</th>

                                                <th id="Th1" runat="server" colspan="2">Operation</th>
                                            </tr>
                                            <tr runat="server" id="itemPlaceholder"></tr>
                                        </table>
                                    </LayoutTemplate>

                                </asp:ListView>
                            </div>
                            <div class="panel-footer">
                                <div class="text-right">

                                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstType" PageSize="10">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-primary btn-xs" ShowFirstPageButton="True" ShowPreviousPageButton="False" FirstPageText="< First " ShowNextPageButton="false" />
                                            <asp:NumericPagerField ButtonType="Link" />
                                            <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-primary btn-xs" ShowNextPageButton="False" ShowLastPageButton="True" ShowPreviousPageButton="false" LastPageText=" Last >" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
