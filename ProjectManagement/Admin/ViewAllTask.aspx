﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ViewAllTask.aspx.cs" Inherits="ProjectManagement.Admin.ViewAllTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>View All Task</h4>
    <div class="ms-auto text-end">
        <i class="mdi mdi-chevron-left"></i>
        <input type="submit" name="btnEdit" value="Back" onclick="return Back();" class="btn btn-warning btn-sm" id="btnEdit" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body">
            <div class="dataTables_wrapper container-fluid mb-4">
                <div class="row">
                    <div class="col-sm-12 col-md-3">
                        <div class="dataTables_filter" id="zero_config_length">
                            <label>
                                Search
                                    <asp:TextBox ID="txtSearchEmp" runat="server" CssClass="form-control form-control-sm" placeholder="Search.."></asp:TextBox>
                            </label>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-5">
                        <div id="zero_config_filter" class="dataTables_filter">
                            <label>
                                Date Range:
                         <asp:TextBox ID="txtTaskStartDateSearch" runat="server" class="form-control" placeholder="Start Date...." type="date"></asp:TextBox>
                            </label>
                            <label>
                                to
                        <asp:TextBox ID="txtTaskEndDateSearch" runat="server" class="form-control" placeholder="End Date...." type="date"></asp:TextBox>
                            </label>
                            <asp:Button ID="btnSearchEmp" runat="server" Text="Search" CssClass="form-control form-control-sm" OnClick="btnSearchEmp_Click" />
                            <asp:Button ID="btnCancelSearch" runat="server" Text="Clear Search" CssClass="form-control form-control-sm" OnClick="btnCancelSearch_Click" />
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-3">
                        <div id="zero_config_filter" class="dataTables_filter"><a href="#" class="link-success">Export to Excel <span class="fa-stack"><i class="fa fa-square fa-stack-2x"></i><i class="fa fa-file-excel fa-stack-1x fa-inverse"></i></span></a></div>
                    </div>
                </div>
            </div>
            <div class="table-responsive">
                <div id="zero_config_wrapper" class="dataTables_wrapper container-fluid">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Panel ID="pnlDisplayAssignTask" runat="server">
                                <asp:GridView ID="grvViewAllTask" runat="server" class="table table-striped table-bordered" AllowPaging="true" PageSize="15"
                                    ShowHeader="true" AutoGenerateColumns="False" EnablePaging="true" EmptyDataText="No Record Found" OnRowCommand="grvViewAllTask_RowCommand">
                                    <PagerStyle CssClass="" HorizontalAlign="Right" />
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="2" FirstPageText="First" LastPageText="Last" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Team Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTeamName" runat="server" Text='<%#Eval("TeamName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Project Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProjectName" runat="server" Text='<%#Eval("ProjectName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Task#">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTaskNumber" runat="server" Text='<%#Eval("TaskNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Task Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTaskName" runat="server" Text='<%#Eval("TaskName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTaskStart" runat="server" Text='<%#Eval("StartTime", "{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTaskEnd" runat="server" Text='<%#Eval("EndTime", "{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Assigned To">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmpName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("StatusName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnViewAssignedTask" CommandName="ViewAssignedTask" runat="server" CommandArgument='<%#Eval("TaskId")+","+ Eval("UserId")+", "+Eval("ProjectId")+", "+Eval("ClientId")+", "+Eval("StatusId")%>' Visible='<%# Eval("StatusName").ToString() == "Completed" ? true : false %>' class="badge bg-info" Text="View"></asp:LinkButton>
                                                <asp:LinkButton ID="btnEditTeam" class="link-success" CommandName="EditTask" runat="server" CommandArgument='<%#Eval("TaskId")+","+ Eval("UserId")+", "+Eval("ProjectId")+", "+Eval("ClientId")%>' Visible='<%# Eval("StatusName").ToString() == "Completed" ? false : true %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                <asp:LinkButton ID="btnDeleteEmployee" class="link-danger" CommandName="DeleteTask" runat="server" CommandArgument='<%#Eval("TaskId")+","+ Eval("UserId")+", "+Eval("ProjectId")+", "+Eval("ClientId")%>' Visible='<%# Eval("StatusName").ToString() == "Completed" ? false : true %>' OnClientClick="return confirm('Are you sure you want to delete this record?');"><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-5">
                            <div class="dataTables_info" id="zero_config_info" role="status" aria-live="polite"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        function Back() {
            history.go(-1);
            return false;
        }
    </script>
</asp:Content>
