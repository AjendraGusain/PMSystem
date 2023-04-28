<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ViewAllEmployee.aspx.cs" Inherits="ProjectManagement.Admin.ViewAllEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>View Employees</h4>
     <div class="ms-auto text-end">
                        <i class="mdi mdi-chevron-left"></i>
                        <input type="submit" name="btnEdit" value="Back" onclick="return Back();" class="btn btn-warning btn-sm" id="btnEdit" />
                    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card">
            <div class="card-body">
               <div class="dataTables_wrapper container-fluid mb-4">
                    <div class="row">
                        <div class="col-sm-12 col-md-5">
                            <div id="zero_config_filter" class="dataTables_filter">
                                <label>
                                    Search:
                      <asp:TextBox ID="txtEmpNameSearch" runat="server" placeholder="Search.."></asp:TextBox>
                                </label>
                            </div>
                        </div>
                       <%-- <div class="col-sm-12 col-md-5">
                            <div id="zero_config_filter" class="dataTables_filter">
                                <label>
                                    Date Range:
                         <asp:TextBox ID="txtClientStartDateSearch" runat="server" class="form-control" placeholder="Start Date...." type="date"></asp:TextBox>
                                </label>
                                <label>
                                    to
                        <asp:TextBox ID="txtClientEndDateSearch" runat="server" class="form-control" placeholder="Start Date...." type="date"></asp:TextBox>
                                </label>

                            </div>
                        </div>--%>
                        <div class="col-sm-12 col-md-2">
                            <div class="dataTables_length" id="zero_config_length">
                                <label>
                                    <asp:Button Text="Search" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                                </label>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-2">
                            <div id="zero_config_filter" class="dataTables_filter"><a href="#" class="link-success">Export to Excel <span class="fa-stack"><i class="fa fa-square fa-stack-2x"></i><i class="fa fa-file-excel fa-stack-1x fa-inverse"></i></span></a></div>
                        </div>
                    </div>
                </div>
                <div class="table-responsive">
                    <div id="zero_config_wrapper" class="dataTables_wrapper container-fluid">
                        <%--<form runat="server">--%>
                            <asp:GridView ID="grvEmployeeDetails" DataKeyNames="" runat="server" class="table table-striped table-bordered"  PageSize="10"
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

                                            <asp:TemplateField HeaderText="Phone Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
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
                                                    <asp:LinkButton ID="btnDeleteEmployee" class="link-danger" CommandName="DeleteEmployee" runat="server" CommandArgument='<%# Eval("UserId") %>' OnClientClick="return confirm('Are you sure you want to delete this record?');"><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>

                                </asp:GridView>
                        <%--</form>--%>
                    </div>
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
