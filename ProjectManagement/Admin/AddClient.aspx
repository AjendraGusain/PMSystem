<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="ProjectManagement.Admin.AddClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Add Client</h4>
                    <div class="ms-auto text-end">
                        <i class="mdi mdi-chevron-left"></i>
                        <input type="submit" name="btnEdit" value="Back" onclick="return Back();" class="btn btn-warning btn-sm" id="btnEdit" />
                    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body wizard-content">
            <%--<form runat="server">--%>
                <div class="wizard clearfix">
                    
                    <div class="content clearfix">
                        <section class="body current">
                            <div class="form-group row">
                                <label for="Cname" class="col-sm-3 text-center control-label col-form-label">Client Name</label>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="txtClient" class="form-control" placeholder="Client Name...." />
                                    <asp:RequiredFieldValidator ID="ClientName" runat="server" ControlToValidate="txtClient" ErrorMessage="*" ForeColor="Red" ValidationGroup="AC"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="Country" class="col-sm-3 text-center control-label col-form-label">Country</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlClientCountry" runat="server" class="select2 form-select shadow-none">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Country" runat="server" ControlToValidate="ddlClientCountry" InitialValue="0" ErrorMessage="*" ValidationGroup="AC" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </section>
                        <div class="card-body text-center">
                            <asp:Button Text="Add Client" runat="server" ID="btnAddClient" OnClick="btnAddClient_Click" CssClass="btn btn-info" ValidationGroup="AC" />
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
</asp:Content>
