<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AssignTask.aspx.cs" Inherits="ProjectManagement.Admin.AssignTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form runat="server">
    <div class="card">
        <div class="card-body">
            <div class="dataTables_wrapper container-fluid mb-4">
                <div class="row">
                    <div class="col-sm-12 col-md-3">
                        <div class="dataTables_filter" id="zero_config_length">
                            <label>
                                Client Name
                     
                                <input type="search" class="form-control form-control-sm" placeholder="">
                            </label>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-3">
                        <div class="dataTables_filter" id="zero_config_length">
                            <label>
                                Project Name
                     
                                <input type="search" class="form-control form-control-sm" placeholder="">
                            </label>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-3">
                        <div class="dataTables_filter" id="zero_config_length">
                            <label>
                                Employee Name
                     
                                <input type="search" class="form-control form-control-sm" placeholder="">
                            </label>
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
                               
                                    <asp:GridView ID="grvAssignedTaskDetails" runat="server" class="table table-striped table-bordered" AllowPaging="true" PageSize="40" ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowCommand="grvAssignedTaskDetails_RowCommand">
                                        <Columns>
                                            <%--<asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnTaskID" runat="server" Text='<%#Eval("TaskId") %>' OnClick="lnkbtnTaskID_Click" ></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Client Name">
                                                <ItemTemplate>
                                                    <%--<asp:LinkButton ID="lnkbtnClientName" runat="server" Text='<%#Eval("ClientName") %>' CommandName="ClientName" CommandArgument='<%# Eval("ClientId") %>'></asp:LinkButton>--%>
                                                    <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Project Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnProjectName" runat="server" Text='<%#Eval("ProjectName") %>'  CommandName="ProjectName" CommandArgument='<%# Eval("ProjectId") %>'></asp:LinkButton>
                                                    <%--<asp:Label ID="lblProjectName" runat="server" Text='<%#Eval("ProjectName") %>'></asp:Label>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Task Name">
                                                <ItemTemplate>
                                                    <%--<asp:LinkButton ID="lnkbtnTaskName" runat="server" Text='<%#Eval("TaskName") %>'  CommandName="TaskName" CommandArgument='<%# Eval("TaskId") %>'></asp:LinkButton>--%>
                                                    <asp:Label ID="lblTaskName" runat="server" Text='<%#Eval("TaskName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnEmployeeName" runat="server" Text='<%#Eval("UserName") %>' CommandName="UserName" CommandArgument='<%# Eval("UserID") %>'></asp:LinkButton>
                                                    <%--<asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>--%>
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
                                                    <asp:LinkButton ID="btnViewAssignedTask"  CommandName="ViewAssignedTask" runat="server" CommandArgument='<%# Eval("TaskId") %>' class="badge bg-info" Text="View"></asp:LinkButton>
                                                    <%--<span class="badge bg-info">View</span>--%>
                                                    <asp:LinkButton ID="btnAssignTask" CommandName="Assign" runat="server" CommandArgument='<%#Eval("TaskId")+","+ Eval("UserId")%>' Text="Assign" Visible='<%# Eval("UserId").ToString() == "" ? true : false %>' class="badge bg-success"></asp:LinkButton>
                                                    <%--<span class="badge bg-success">Assign</span>--%>
                                                    <asp:LinkButton ID="btnReAssignTask" CommandName="ReAssign" runat="server" CommandArgument='<%#Eval("TaskId")+","+ Eval("UserId")%>' Text="Reassign" Visible='<%# Eval("UserId").ToString() != "" ? true : false %>' class="badge bg-success"></asp:LinkButton>
                                                    <%--<span class="badge bg-success">Reassign</span>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Panel ID="pnlDisplayTaskDetails" runat="server">
                  
                                    <asp:GridView ID="gvTaskDetails" DataKeyNames="" runat="server" class="table table-striped table-bordered" AllowPaging="true" PageSize="40"
                                        ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Task ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaskId" runat="server" Text='<%#Eval("TaskId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Client Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Project Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectName" runat="server" Text='<%#Eval("ProjectName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Task Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaskName" runat="server" Text='<%#Eval("TaskName") %>'></asp:Label>
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
                                            <%--<asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnViewAssignedTask" CssClass="link-info" CommandName="ViewAssignedTask" runat="server" CommandArgument='<%# Eval("TaskId") %>'><span class="badge bg-info">View</span></asp:LinkButton>
                                                    <asp:LinkButton ID="btnAssignTask" class="link-success" CommandName="Assign" runat="server" CommandArgument='<%# Eval("TaskId") %>'><span class="badge bg-success">Assign</span></asp:LinkButton>
                                                    <asp:LinkButton ID="btnReAssignTask" class="link-danger" CommandName="ReAssign" runat="server" CommandArgument='<%# Eval("TaskId") %>'><span class="badge bg-success">Reassign</span></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>

                                        </Columns>
                                    </asp:GridView>
                             
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
        </div>
    </div>
    </form>
</asp:Content>
