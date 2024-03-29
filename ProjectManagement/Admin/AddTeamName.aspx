﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddTeamName.aspx.cs" Inherits="ProjectManagement.Admin.AddTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Add Team</h4>
    <div class="ms-auto text-end">
        <i class="mdi mdi-chevron-left"></i>
        <input type="submit" name="btnEdit" value="Back" onclick="return Back();" class="btn btn-warning btn-sm" id="btnEdit" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                        <asp:DropDownList ID="ddlProject" runat="server" class="select2 form-select shadow-none">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rvProject" runat="server" ControlToValidate="ddlProject" InitialValue="0" ErrorMessage="Select Project" ValidationGroup="ED" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="Tname" class="col-sm-3 text-center control-label col-form-label">Team Name</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox runat="server" ID="txtTeamName" class="form-control" placeholder="Team Name...." />
                                        <asp:RequiredFieldValidator ID="rvTeamName" runat="server" ControlToValidate="txtTeamName" ErrorMessage="Enter Team Name" Display="Dynamic" ForeColor="Red" ValidationGroup="ED"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </section>
                            <div class="text-center">
                                <div class="card-body">
                                    <asp:Button Text="Add Team" runat="server" ID="btnAddTeamName" OnClick="btnAddTeamName_Click" CssClass="btn btn-info" ValidationGroup="ED" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:GridView ID="grvViewTeam" DataKeyNames="" runat="server" class="table table-striped table-bordered"
                ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" EnablePaging="true" OnRowCommand="grvViewTeam_RowCommand" OnRowDeleting="grvViewTeam_RowDeleting" OnRowEditing="grvViewTeam_RowEditing">
                <Columns>
                    <asp:TemplateField HeaderText="Project Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCreationDate" runat="server" Text='<%# Eval("ProjectName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Team Name">
                        <ItemTemplate>
                            <asp:Label ID="lblTeamName" runat="server" Text='<%# Eval("TeamName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEditTeam" class="link-success" CommandName="Edit" runat="server" CommandArgument='<%# Eval("Id") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                            <asp:LinkButton ID="btnDeleteEmployee" class="link-danger" CommandName="Delete" runat="server" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete this record?');"><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        function Back() {
            history.go(-1);
            return false;
        }
    </script>
</asp:Content>
