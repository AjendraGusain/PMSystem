<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="ProjectManagement.Admin.AddEmployee" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Add Employee</h4>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body wizard-content">
            <form runat="server">
                <div class="wizard clearfix">
                    <div class="content clearfix">
                        <section class="body current">
                            <div class="form-group row">
                                <label for="Ecode" class="col-sm-3 text-center control-label col-form-label">Employee Code</label>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="txtEmployeeCode" class="form-control" placeholder="Employee Code...." OnTextChanged="txtEmployeeCode_TextChanged" AutoPostBack="true" />
                                    <asp:label runat="server" id="lblCheckCode" ForeColor="Red"></asp:label>
                                    <asp:RequiredFieldValidator ID="rvEmployeeCode" runat="server" ControlToValidate="txtEmployeeCode" ErrorMessage="*" ForeColor="Red" ValidationGroup="ED"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="Ename" class="col-sm-3 text-center control-label col-form-label">Employee Name</label>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="txtEmployeeName" class="form-control" placeholder="Employee Name...." />
                                    <asp:RequiredFieldValidator ID="rvEmployeeName" runat="server" ControlToValidate="txtEmployeeName" ErrorMessage="*" ForeColor="Red" ValidationGroup="ED"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="EmailID" class="col-sm-3 text-center control-label col-form-label">Email ID</label>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="txtEmail" class="form-control" placeholder="Email ID...." OnTextChanged="txtEmail_TextChanged" AutoPostBack="true" />
                                    <asp:label runat="server" id="lblCheckEmail" ForeColor="Red"></asp:label>

                                    <asp:RequiredFieldValidator ID="rvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red" Display="Dynamic" ValidationGroup="ED"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rvPhoneNoExp" runat="server" ControlToValidate="txtEmail"
                                        ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                        Display="Dynamic" ErrorMessage="Invalid email address" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="PhoneNo" class="col-sm-3 text-center control-label col-form-label">Phone No</label>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="txtPhoneNo" class="form-control" placeholder="Phone No...." OnTextChanged="txtPhoneNo_TextChanged" AutoPostBack="true" />
                                    <asp:label runat="server" id="lblCheckPhone" ForeColor="Red"></asp:label>
                                    <asp:RequiredFieldValidator ID="rvPhoneNo" runat="server" ControlToValidate="txtPhoneNo" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="ED"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rvEmailExp" runat="server" ControlToValidate="txtPhoneNo" ErrorMessage="Invalid Phone Number" ForeColor="Red" ValidationExpression="^[0-9]{10}$" Display="Dynamic" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="Role" class="col-sm-3 text-center control-label col-form-label">Role</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlRoleList" runat="server" class="select2 form-select shadow-none">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rvRoleList" runat="server" ControlToValidate="ddlRoleList" InitialValue="0" ErrorMessage="*" ValidationGroup="ED" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="Designation" class="col-sm-3 text-center control-label col-form-label">Designation</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlDesignation" runat="server" class="select2 form-select shadow-none">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rvDesignation" runat="server" ControlToValidate="ddlDesignation" InitialValue="0" ErrorMessage="*" ValidationGroup="ED" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">&nbsp;</div>
                                <div class="col-sm-6">
                                    <div class="form-check">
                                        <asp:CheckBox ID="chkAdminAuth" runat="server" />
                                        <label class="form-check-label mb-0" for="customControlAutosizing1">Can create admin role?</label>
                                    </div>
                                </div>
                            </div>
                        </section>
                        <div class="card-body text-center">
                            <asp:Button Text="Add Employee" runat="server" ID="btnAddEmployee" OnClick="btnAddEmployee_Click" CssClass="btn btn-info" ValidationGroup="ED" />
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>