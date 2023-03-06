<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="UserTask.aspx.cs" Inherits="ProjectManagement.Users.UserTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body">
            <form runat="server">
                <div class="dataTables_wrapper mb-4">
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
                                    Status
                                   
                                    <input type="search" class="form-control form-control-sm" placeholder="">
                                </label>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-3">
                            <div id="zero_config_filter" class="dataTables_filter"><a href="#" class="link-success"><span class="fa-stack"><i class="fa fa-square fa-stack-2x"></i><i class="fa fa-file-excel fa-stack-1x fa-inverse"></i></span></a></div>
                        </div>
                    </div>
                </div>
                <asp:Panel ID="pnlDisplayUserTask" runat="server">
                    <asp:GridView ID="gvDisplayUserTask" runat="server" OnRowCommand="gvDisplayUserTask_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="ClientName">
                                <ItemTemplate>
                                    <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("ClientName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ProjectName">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Task#">
                                <ItemTemplate>
                                    <asp:Label ID="lblTaskNumber" runat="server" Text='<%# Eval("TaskNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Start Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StartTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("EndTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnViewUserTask" CommandName="ViewUserTask" runat="server" CommandArgument='<%# Eval("TaskId") %>' class="badge bg-info" Text="View"></asp:LinkButton>                                    
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Assign/Play/Pause">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnAssignPlayUserTask" CommandName="AssignPlayUserTask" runat="server" CommandArgument='<%# Eval("TaskId") %>' Text="Assign" Visible='<%# Eval("StartTime").ToString() == "" ? true : false %>' class="badge bg-info"></asp:LinkButton>                                    
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatusUserTask" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </form>
        </div>
    </div>

</asp:Content>
