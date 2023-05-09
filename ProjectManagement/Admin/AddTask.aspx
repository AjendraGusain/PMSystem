<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="ProjectManagement.Admin.addTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Add Task</h4>
    <div class="ms-auto text-end">
                        <i class="mdi mdi-chevron-left"></i>
                        <input type="submit" name="btnEdit" value="Back" onclick="return Back();" class="btn btn-warning btn-sm" id="btnEdit" />
                    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body wizard-content">
            <%--<form class="mt-3" runat="server">--%>
                <div class="wizard clearfix">
                    <div class="content clearfix">
                        <section class="body current">
                            <div class="form-group row">
                                <label for="Cname" class="col-sm-3 text-center control-label col-form-label">Client Name</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlClientName" runat="server" CssClass="select2 form-select shadow-none" AutoPostBack="true" OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvClientName" ErrorMessage="Required" ControlToValidate="ddlClientName" InitialValue="0" runat="server" ValidationGroup="val" ForeColor="Red" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="Pname" class="col-sm-3 text-center control-label col-form-label">Project Name</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlProjectName" runat="server" CssClass="select2 form-select shadow-none" OnSelectedIndexChanged="ddlProjectName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvProjectName" ErrorMessage="Required" ControlToValidate="ddlProjectName" InitialValue="0" runat="server" ValidationGroup="val" ForeColor="Red" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="Tname" class="col-sm-3 text-center control-label col-form-label">Team Name</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlTeamName" runat="server" CssClass="select2 form-select shadow-none"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvTeamName" ErrorMessage="Required" ControlToValidate="ddlTeamName" InitialValue="0" runat="server" ValidationGroup="val" ForeColor="Red" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="Tnum" class="col-sm-3 text-center control-label col-form-label">Task Number</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtTaskNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTaskNumber" ErrorMessage="Required" ControlToValidate="txtTaskNumber" runat="server" ValidationGroup="val" ForeColor="Red" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="Tname" class="col-sm-3 text-center control-label col-form-label">Task Name</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtTaskName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTaskName" ErrorMessage="Required" ControlToValidate="txtTaskName" runat="server" ValidationGroup="val" ForeColor="Red" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="Tdetails" class="col-sm-3 text-center control-label col-form-label">Task Details</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtTaskDescription" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="col-sm-6">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtSearch" runat="server" Visible="false"  placeholder="Search..."></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" Visible="false" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnClearAll" runat="server" Text="Clear" Visible="false"  OnClick="btnClearAll_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group row">
                                <asp:GridView ID="gvAllEmployee" runat="server" AutoGenerateColumns="false" class="col-sm-9 text-center control-label col-form-label"
                                    HorizontalAlign="Left" BorderStyle="None" DataKeyNames="TeamMemberID,UserId" >
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkTeamMemberID" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTeamID" runat="server" Text='<%# Bind("TeamId") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTeamMemberID" runat="server" Text='<%# Bind("TeamMemberID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Team">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTeamName" runat="server" Text='<%# Bind("TeamName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Manager">
                                            <ItemTemplate>
                                                <asp:Label ID="lblManagerName" runat="server" Text='<%# Bind("ManagerName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserId" runat="server" Text='<%# Bind("UserId") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Role">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRoleName" runat="server" Text='<%# Bind("Role") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </section>
                        <div class="border-top text-center">
                            <div class="card-body">
                                <asp:Button ID="btnAddTask" runat="server" Text="Create Task" CssClass="btn btn-info" ValidationGroup="val" OnClick="btnAddTask_Click" />
                                <asp:Button ID="btnResetField" runat="server" Text="Reset" CssClass="btn btn-info" OnClick="btnResetField_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            <%--</form>--%>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        function Back() {
            history.go(-1);
            return false;
        }
    </script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.13/js/bootstrap-multiselect.js"></script>
</asp:Content>

