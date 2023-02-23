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
                    <asp:Panel ID="pnlDisplayTaskDetails" runat="server">
                        <form runat="server">
                            <div class="table-responsive">
                                <div class="dataTables_wrapper container-fluid mb-4">
                                    <div class="row">
                                        <div class="col-sm-6 d-flex mb-5 details">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <p class="mb-0">Client Name</p>
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <asp:Label ID="lblClientName" runat="server" class="text-muted mb-0"></asp:Label>
                                                    </div>
                                                </div>
                                                <hr>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <p class="mb-0">Project Name</p>
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <asp:Label ID="lblProjectName" runat="server" class="text-muted mb-0"></asp:Label>
                                                    </div>
                                                </div>
                                                <hr>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <p class="mb-0">Task Name</p>
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <asp:Label ID="lblTaskName" runat="server" class="text-muted mb-0"></asp:Label>
                                                    </div>
                                                </div>
                                                <hr>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <p class="mb-0">Task#</p>
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <asp:Label ID="lblTaskNumber" runat="server" class="text-muted mb-0"></asp:Label>
                                                    </div>
                                                </div>
                                                <hr>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <p class="mb-0">Task Details</p>
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <asp:Label ID="lblTaskDetails" runat="server" class="text-muted mb-0"></asp:Label>
                                                    </div>
                                                </div>
                                                <hr>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <p class="mb-0">Start Date</p>
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <asp:Label ID="lblStartDate" runat="server" class="text-muted mb-0"></asp:Label>
                                                    </div>
                                                </div>
                                                <hr>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <p class="mb-0">End Date</p>
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <asp:Label ID="lblEndDate" runat="server" class="text-muted mb-0"></asp:Label>
                                                    </div>
                                                </div>
                                                <hr>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <p class="mb-0">Time Estimate</p>
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <asp:Label ID="lblTimeEstimate" runat="server" class="text-muted mb-0"></asp:Label>
                                                    </div>
                                                </div>
                                                <hr>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <p class="mb-0">Actual Time</p>
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <asp:Label ID="lblActualTime" runat="server" class="text-muted mb-0"></asp:Label>
                                                    </div>
                                                </div>
                                                <hr>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <p class="mb-0">Work in progress</p>
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <asp:Label ID="lblWIP" runat="server" class="text-muted mb-0"></asp:Label>
                                                    </div>
                                                </div>
                                                <hr>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <p class="mb-0">Pause</p>
                                                    </div>
                                                    <div class="col-sm-9">
                                                        <asp:Label ID="lblPause" runat="server" class="text-muted mb-0"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 d-flex mb-5 details">
                                            <div class="card-body">
                                                <asp:GridView ID="grvDisplayTaskDetails" runat="server" class="table table-striped table-bordered" AllowPaging="true" 
                                                    PageSize="40" ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" 
                                                    OnRowCommand="grvDisplayTaskDetails_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTaskID" runat="server" Text='<%#Eval("TaskId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("StartTime") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Start Time">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStartTime" runat="server" Text='<%#Eval("StartTime") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="End Time">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEndTime" runat="server" Text='<%#Eval("EndTime") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <%--<asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>' Visible='<%# Eval("EndTime").ToString() == "" ? true : false %>'></asp:Label>--%>
                                                                <asp:Label ID="lblWIP" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
