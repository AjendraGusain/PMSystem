﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ViewTeam.aspx.cs" Inherits="ProjectManagement.Admin.ViewTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>View All Team</h4>
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
                    <div class="col-sm-12 col-md-5">
                        <div class="dataTables_filter" id="zero_config_length">
                            <label>
                                Search
                                <asp:TextBox ID="txtSearchTeam" runat="server" CssClass="form-control form-control-sm" placeholder="Search.."></asp:TextBox>
                            </label>
                            <asp:Button ID="btnSearchTeam" runat="server" Text="Search" CssClass="form-control form-control-sm" OnClick="btnSearchTeam_Click" />
                            <asp:Button ID="btnCancelSearch" runat="server" Text="Clear Search" CssClass="form-control form-control-sm" OnClick="btnCancelSearch_Click" />
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-2">
                        <div class="dataTables_filter" id="zero_config_length">
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-3">
                        <div id="zero_config_filter" class="dataTables_filter"><a href="#" class="link-success">Export to Excel <span class="fa-stack"><i class="fa fa-square fa-stack-2x"></i><i class="fa fa-file-excel fa-stack-1x fa-inverse"></i></span></a></div>
                    </div>
                </div>
            </div>
            <div class="table-responsive">
                <div class="dataTables_wrapper container-fluid">
                    <div class="row">
                        <div class="col-sm-12 d-flex">
                            <asp:GridView ID="grvAllViewTeam" DataKeyNames="" runat="server" class="table table-striped table-bordered"
                                ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowCommand="grvViewTeam_RowCommand" OnRowDataBound="grvAllViewTeam_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Project Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Team Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTeamName" runat="server" Text='<%# Eval("TeamName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Manager Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblManager" runat="server" Text='<%# Eval("ManagerName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Team Leader">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTeamLeader" runat="server" Text='<%# Eval("TeamLeaderName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployee" runat="server" Text='<%# Eval("UserName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ShowHeader="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditEmployee" class="link-success" CommandName="EditTeam" runat="server" CommandArgument='<%#Eval("ProjectId")+","+ Eval("TeamId")+","+ Eval("ManagerId")+","+ Eval("ParrentTeamMemberId")%>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                            <asp:LinkButton ID="btnDeleteEmployee" class="link-danger" CommandName="DeleteTeam" runat="server" CommandArgument='<%#Eval("ProjectId")+","+ Eval("TeamId")+","+ Eval("ParrentTeamMemberId")%>' OnClientClick="return confirm('Are you sure you want to delete this record?');"><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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
