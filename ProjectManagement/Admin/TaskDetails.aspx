<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TaskDetails.aspx.cs" Inherits="ProjectManagement.Admin.TaskDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-responsive">
                <div id="zero_config_wrapper" class="dataTables_wrapper container-fluid">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Panel ID="pnlAssignTask" runat="server">
                                <form runat="server">
                                    <asp:GridView ID="grvTaskDetails" DataKeyNames="" runat="server" class="table table-striped table-bordered" AllowPaging="true" PageSize="40"
                                        ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowCommand="grvTaskDetails_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Task ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaskId" runat="server" Text='<%#Eval("TaskId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Task Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaskName" runat="server" Text='<%#Eval("TaskName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Task Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaskDescription" runat="server" Text='<%#Eval("TaskDescription") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Task Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="" runat="server" Text='<%#Eval("TaskName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>

                                            <%-- <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("StartDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnViewAssignedTask" CssClass="link-info" CommandName="ViewAssignedTask" runat="server" CommandArgument='<%# Eval("TaskId") %>'><span class="badge bg-info">View</span></asp:LinkButton>
                                                    <asp:LinkButton ID="btnAssignTask" class="link-success" CommandName="Assign" runat="server" CommandArgument='<%# Eval("TaskId") %>'><span class="badge bg-success">Assign</span></asp:LinkButton>
                                                    <asp:LinkButton ID="btnReAssignTask" class="link-danger" CommandName="ReAssign" runat="server" CommandArgument='<%# Eval("TaskId") %>'><span class="badge bg-success">Reassign</span></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </form>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-5">
                            <div class="dataTables_info" id="zero_config_info" role="status" aria-live="polite">Showing 1 to 10 of 57 entries</div>
                        </div>
                        <div class="col-sm-12 col-md-7">
                            <div class="dataTables_paginate paging_simple_numbers" id="zero_config_paginate">
                                <ul class="pagination">
                                    <li class="paginate_button page-item previous disabled" id="zero_config_previous"><a href="#" aria-controls="zero_config" data-dt-idx="0" tabindex="0" class="page-link">Previous</a></li>
                                    <li class="paginate_button page-item active"><a href="#" aria-controls="zero_config" data-dt-idx="1" tabindex="0" class="page-link">1</a></li>
                                    <li class="paginate_button page-item "><a href="#" aria-controls="zero_config" data-dt-idx="2" tabindex="0" class="page-link">2</a></li>
                                    <li class="paginate_button page-item next" id="zero_config_next"><a href="#" aria-controls="zero_config" data-dt-idx="7" tabindex="0" class="page-link">Next</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
