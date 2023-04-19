<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="ProjectManagement.Admin.AddRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Add Role</h4>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body wizard-content">
            <form runat="server">
                <div class="wizard clearfix">
                    <div class="ms-auto text-end">
                        <i class="mdi mdi-chevron-left"></i>
                        <input type="submit" name="btnEdit" value="Back" onclick="return Back();" class="btn btn-warning btn-sm" id="btnEdit" />
                    </div>
                    <div class="content clearfix">
                        <section class="body current">
                            <div class="form-group row">
                                <label for="Rname" class="col-sm-3 text-center control-label col-form-label">Role Name</label>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="txtRole" class="form-control" placeholder="Role Name...." />
                                    <asp:RequiredFieldValidator ID="rfvRole" runat="server" ControlToValidate="txtRole" ErrorMessage="*" ForeColor="Red" ValidationGroup="AR"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </section>
                        <div class="card-body text-center">
                            <asp:Button Text="Add Role" runat="server" ID="btnAddRole" OnClick="btnAddRole_Click" CssClass="btn btn-info" ValidationGroup="AR" />
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
     <script language="javascript" type="text/javascript">
        function Back() {
            history.go(-1);
            return false;
        }
     </script>
</asp:Content>
