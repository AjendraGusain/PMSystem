<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EmployeeTask.aspx.cs" Inherits="ProjectManagement.Admin.EmployeeTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Employee Task</h4>
    <div class="ms-auto text-end">
        <i class="mdi mdi-chevron-left"></i>
        <input type="submit" name="btnEdit" value="Back" onclick="return Back();" class="btn btn-warning btn-sm" id="btnEdit" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body">
            <div class="dataTables_wrapper">
                <h4>Current Task</h4>
                <div class="table-responsive">
                    <asp:GridView ID="grvEmployeeTask" DataKeyNames="" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="false" EmptyDataText="No Record Found" OnRowCommand="grvEmployeeTask_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Task Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("TaskNumber") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Task Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("TaskName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartTime" runat="server" Text='<%# Convert.ToDateTime(Eval("StartTime")).ToShortDateString() %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StatusName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="dataTables_wrapper">
                <h4>Reassigned History</h4>
                <div class="table-responsive">
                    <asp:GridView ID="grvReassign" DataKeyNames="" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="false" EmptyDataText="No Record Found" OnRowCommand="grvEmployeeTask_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Task Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("TaskNumber") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Task Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("TaskName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartTime" runat="server" Text='<%# Convert.ToDateTime(Eval("StartTime")).ToShortDateString() %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StatusName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
