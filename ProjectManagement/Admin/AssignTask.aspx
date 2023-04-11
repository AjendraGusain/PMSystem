<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AssignTask.aspx.cs" Inherits="ProjectManagement.Admin.AssignTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Assign Task</h4>
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
                               <asp:DropDownList ID="ddlSearchClient" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchClient_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </label>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-3">
                            <div class="dataTables_filter" id="zero_config_length">
                                <label>
                                    Project Name
                                <asp:DropDownList ID="ddlSerachProject" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlSerachProject_SelectedIndexChanged">
                                </asp:DropDownList>    
                                </label>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-3">
                            <div class="dataTables_filter" id="zero_config_length">
                                <label>
                                    Employee Name
                                    <asp:TextBox ID="txtSearchEmp" runat="server" CssClass="form-control form-control-sm" placeholder="Search Employee.."></asp:TextBox>
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

                                    <asp:GridView ID="grvAssignedTaskDetails" runat="server" class="table table-striped table-bordered" AllowPaging="true" PageSize="15"
                                        ShowHeader="true" AutoGenerateColumns="False" EnablePaging="true" EmptyDataText="No Record Found"
                                        OnRowCommand="grvAssignedTaskDetails_RowCommand" OnPageIndexChanging="grvAssignedTaskDetails_PageIndexChanging">
                                        <PagerStyle CssClass="" HorizontalAlign="Right" />
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="2" FirstPageText="First" LastPageText="Last" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Client Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Project Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnProjectName" runat="server" Text='<%#Eval("ProjectName") %>' CommandName="ProjectName" CommandArgument='<%# Eval("ProjectId") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Task#">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaskNum" runat="server" Text='<%#Eval("TaskNumber") %>'></asp:Label>
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
                                                    <asp:LinkButton ID="lnkbtnEmployeeName" runat="server" Text='<%#Eval("UserName") %>' CommandName="UserName" CommandArgument='<%# Eval("UserID") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnViewAssignedTask" CommandName="ViewAssignedTask" runat="server" CommandArgument='<%#Eval("TaskId")+","+ Eval("UserId")+", "+Eval("ProjectId")+", "+Eval("ClientId")%>' class="badge bg-info" Text="View"></asp:LinkButton>
                                                    <asp:LinkButton ID="btnAssignTask" CommandName="Assign" runat="server" CommandArgument='<%#Eval("TaskId")+","+ Eval("UserId")+", "+Eval("ProjectId")%>' Text="Assign" Visible='<%# Eval("UserId").ToString() == "" ? true : false %>' class="badge bg-success"></asp:LinkButton>
                                                    <asp:LinkButton ID="btnReAssignTask" CommandName="ReAssign" runat="server" CommandArgument='<%#Eval("TaskId")+","+ Eval("UserId")+", "+Eval("ProjectId")%>' Text="Reassign" Visible='<%# Eval("UserId").ToString() != "" ? true : false %>' class="badge bg-success"></asp:LinkButton>
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
    </form>
</asp:Content>
