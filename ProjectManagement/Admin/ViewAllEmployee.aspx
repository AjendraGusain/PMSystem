<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ViewAllEmployee.aspx.cs" Inherits="ProjectManagement.Admin.ViewAllEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>View Employees</h4>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card">
            <div class="card-body">
                <div class="table-responsive">
                    <div id="zero_config_wrapper" class="dataTables_wrapper container-fluid">
                        <form runat="server">
                            <asp:GridView ID="grvEmployeeDetails" DataKeyNames="" runat="server" class="table table-striped table-bordered"  PageSize="2"
                                        ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowCommand="grvEmployeeDetails_RowCommand" EnablePaging="true" AllowPaging="true" 
                                OnPageIndexChanging="grvEmployeeDetails_PageIndexChanging"  >
                                <PagerStyle CssClass="" HorizontalAlign="Right" />
                                <PagerSettings PageButtonCount="5" FirstPageText="Previous"  PreviousPageText="1" NextPageText="2" LastPageText="Next"  Mode="Numeric"  />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeCode" runat="server" Text='<%# Eval("EmployeeCode") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("UserName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("PhoneNumber") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Phone Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Eval("Email") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Role">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Role") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnViewEmployee" CssClass="link-info" CommandName="ViewEmployee" runat="server" CommandArgument='<%# Eval("UserId") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-eye fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                    <asp:LinkButton ID="btnEditEmployee" class="link-success" CommandName="EditEmployee" runat="server" CommandArgument='<%# Eval("UserId") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                    <asp:LinkButton ID="btnDeleteEmployee" class="link-danger" CommandName="DeleteEmployee" runat="server" CommandArgument='<%# Eval("UserId") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                            </asp:TemplateField>
<%--                                             <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="myCb" runat="server" Text='Hi'/>
                <ul id="myUnorderedList" runat="server" Visible="True">
                    <li>
                        <asp:TextBox ID="myTb" runat="server" Width="300" />
                    </li>
                </ul>
            </ItemTemplate>
        </asp:TemplateField>--%>
                                        </Columns>

                                </asp:GridView>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
