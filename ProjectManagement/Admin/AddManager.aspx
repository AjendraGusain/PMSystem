<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddManager.aspx.cs" Inherits="ProjectManagement.Admin.AddManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Add Manager</h4>
    <div class="ms-auto text-end">
        <i class="mdi mdi-chevron-left"></i>
        <input type="submit" name="btnEdit" value="Back" onclick="return Back();" class="btn btn-warning btn-sm" id="btnEdit" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<form class="mt-3" runat="server">--%>
    <div class="container-fluid">
        <div class="card">
            <div class="card-body">

                <div class="dataTables_wrapper">
                    <div class="row">
                        <div class="col-sm-7 d-flex mb-5 details">
                            <div class="card-body">

                                <section class="body current">
                                    <div class="form-group row">
                                        <label for="Project" class="col-sm-3 text-center control-label col-form-label">Project</label>
                                        <div class="col-sm-6">
                                            <asp:DropDownList ID="ddlMProject" runat="server" class="select2 form-select shadow-none" OnSelectedIndexChanged="ddlMProject_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="Tname" class="col-sm-3 text-center control-label col-form-label">Team Name</label>
                                        <div class="col-sm-6">
                                            <asp:DropDownList ID="ddlMTeamName" runat="server" class="select2 form-select shadow-none" OnSelectedIndexChanged="ddlMTeamName_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="Mname" class="col-sm-3 text-center control-label col-form-label">Manager</label>
                                        <div class="col-sm-6">
                                            <asp:ListBox ID="lsManager" runat="server" data-live-search="true" SelectionMode="Multiple" CssClass="form-control js-example-placeholder-single" AutoPostBack="true"></asp:ListBox>

                                            <asp:Label ID="lblCheckUser" CssClass="lblCheckUser" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </section>
                                <div class="text-center">
                                    <div class="card-body">
                                        <asp:Button Text="Add Manager" runat="server" ID="btnAddTeamName" OnClick="btnAddTeamName_Click" CssClass="btn btn-info" ValidationGroup="ED" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <asp:GridView ID="grvViewManager" DataKeyNames="" runat="server" class="table table-striped table-bordered"
                    ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" EnablePaging="true" OnRowCommand="grvViewManager_RowCommand"
                    OnRowEditing="grvViewManager_RowEditing" OnRowDeleting="grvViewManager_RowDeleting">
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
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEditTeam" class="link-success" CommandName="EditManager" runat="server" CommandArgument='<%#Eval("ProjectId")+","+ Eval("TeamId")%>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                <asp:LinkButton ID="btnDeleteEmployee" class="link-danger" CommandName="DeleteManager" runat="server" CommandArgument='<%#Eval("ProjectId")+","+ Eval("TeamId")+","+ Eval("UserId")+","+ Eval("TeamMemberId")%>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
    <%--</form>--%>
    <script language="javascript" type="text/javascript">
        function Back() {
            history.go(-1);
            return false;
        }
    </script>
</asp:Content>
