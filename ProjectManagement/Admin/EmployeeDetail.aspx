<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EmployeeDetail.aspx.cs" Inherits="ProjectManagement.Admin.EmployeeDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Label runat="server" ID="lblName" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="mt-3" runat="server">
    <div class="card">
        <div class="card-body">
            <div class="dataTables_wrapper">
                <div class="row">
                    <h4 class="text-center mb-3">Employee Details</h4>
                    <div class="col-sm-7 d-flex mb-5 details">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-3">
                                    <lable id="lblEmployee" class="mb-0">Employee Code</lable>
                                </div>
                                <div class="col-sm-9">
                                    <asp:Label ID="lblEmployeeCode" runat="server" class="text-muted mb-0"></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Employee Name</p>
                                </div>
                                <div class="col-sm-9">
                                    <asp:Label runat="server" ID="lblEmployeeName" class="text-muted mb-0"></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Email ID</p>
                                </div>
                                <div class="col-sm-9">
                                    <asp:Label runat="server" ID="lblEmail" class="text-muted mb-0"></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Phone No</p>
                                </div>
                                <div class="col-sm-9">
                                    <asp:Label runat="server" ID="lblPhoneNo" class="text-muted mb-0"></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Role</p>
                                </div>
                                <div class="col-sm-9">
                                    <asp:Label runat="server" ID="lblRole" class="text-muted mb-0"></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Designation</p>
                                </div>
                                <div class="col-sm-9">
                                    <asp:Label runat="server" ID="lblDesignation" class="text-muted mb-0"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="dataTables_wrapper">
                <h4>Current Project</h4>
                <div class="table-responsive">
                   <asp:GridView ID="grvCurrentProject" DataKeyNames="" EmptyDataText="No Record Found"  runat="server" class="table table-striped table-bordered" AutoGenerateColumns="false" OnRowCommand="grvCurrentProject_RowCommand" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Client Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("ClientName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Project Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("EntryDate") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnView" CssClass="btn btn-success btn-sm text-white" CommandName="ViewProject" runat="server" CommandArgument='<%#Eval("ProjectId")+","+ Eval("ClientId")+","+ Eval("UserId")%>'>View</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                       </asp:GridView>
                </div>
            </div>
            <div class="dataTables_wrapper">
                <h4>Previous Project</h4>
                <div class="table-responsive">
                   <asp:GridView ID="grvPreviousProject" DataKeyNames="" runat="server" class="table table-striped table-bordered"  PageSize="2"
                                        ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" >
                                         <Columns>
                                            
                                            <asp:TemplateField HeaderText="Client Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPClientName" runat="server" Text='<%# Eval("ClientName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Project Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPProjectName" runat="server" Text='<%# Eval("ProjectName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPrevStartDate" runat="server" Text='<%# Eval("EntryDate") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="End Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPrevEndDate" runat="server" Text='<%# Eval("EndDate") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                       </asp:GridView>
                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
