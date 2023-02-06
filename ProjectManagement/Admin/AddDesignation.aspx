<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddDesignation.aspx.cs" Inherits="ProjectManagement.Admin.AddDesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Add Designatio</h4>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body wizard-content">
            <form runat="server">
                <div class="wizard clearfix">
                    <div class="content clearfix">
                        <section class="body current">
                            <div class="form-group row">
                                <label for="Dname" class="col-sm-3 text-center control-label col-form-label">Designation Name</label>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="txtDesignation" class="form-control" placeholder="Designation Name...." />
                                    <asp:RequiredFieldValidator ID="ClientName" runat="server" ControlToValidate="txtDesignation" ErrorMessage="*" ForeColor="Red" ValidationGroup="AD"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </section>
                        <div class="card-body text-center">
                            <asp:Button Text="Add Designation" runat="server" ID="btnAddDesignation" OnClick="btnAddDesignation_Click" CssClass="btn btn-info" ValidationGroup="AD" />
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>

</asp:Content>
